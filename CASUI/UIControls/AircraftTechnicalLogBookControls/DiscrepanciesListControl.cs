using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.Interfaces
{


    /*
     * Общий принцип - пользователю всегда отображается минимум 4 отклонения и те отклонения которые он заполнил сохраняются в базу данных
     * Если на форме отображается 4 отклонения но заполнено только одно, это означает, что во время полета было обнаружено только одно отклонение
     */

    /// <summary>
    /// Строит список отклонений воздушного судна
    /// </summary>
    public partial class DiscrepanciesListControl : CAS.UI.Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public DiscrepanciesListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DiscrepanciesListControl()
        {
            InitializeComponent();
            FillControls();
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {

            // Применяем сделанные изменения объектам
            for (int i = 0; i < panelMain.Controls.Count; i++)
            {
                DiscrepancyControl d = panelMain.Controls[i] as DiscrepancyControl;
                if (d != null && !d.IsNull)
                {
                    d.ApplyChanges();

                    /*
                     * Возможны три ситуации
                     * 
                     * 1) AircraftFlight существует и мы вносим изменения в существующую Discrepancy - самый лучший
                     * 2) AircraftFlight не существует и мы создали новую Discrepancy - решаемо
                     * 3) AircraftFlight не существует (мы открыли скрин создания записи в борт журнали) и соответственно Discrepancy тоже новый
                     * 
                     * В третьем случае оставляем мы должны возвратиться к этому диалогу после создания ВС 
                     */

                    if (DiscrepancyExists(d.Discrepancy))
                    {
                        // Первый случай
                        d.Discrepancy.Save();
                    }
                    else if (Flight.ExistAtDataBase)
                    {
                        // Второй случай
                        Flight.AddDiscrepancy(d.Discrepancy);
                    }
                    else
                    {
                        // Третий случай
                        // Ничего не делаем, подразумевая, что этот метод будет вызван заново после сохранения AircraftFlight
                    }
                }
            }

            // Теперь мы должны сохранить сам объект а потом добавить только что созданные отклонения 


            //
            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BuildControls();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {

            // Проверяем введенные данные
            // Проверяем только те отклонения которые реально были вбиты пользователем (!d.IsNull)
            for (int i = 0; i < panelMain.Controls.Count; i++)
            {
                DiscrepancyControl d = panelMain.Controls[i] as DiscrepancyControl;
                if (d != null && !d.IsNull) 
                    if (!d.CheckData()) return false;
            }

            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            // Освобождаем старые контролы
            panelMain.Controls.Clear();


            int count = 4;
            if (Flight != null && Flight.Discrepancies != null && Flight.Discrepancies.Length > count) count = Flight.Discrepancies.Length;

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter();
                    delimiter.Style = DelimiterStyle.Solid;
                    delimiter.Orientation = DelimiterOrientation.Horizontal;
                    delimiter.Margin = new Padding(0, 10, 0, 10);
                    delimiter.Width = 1000;
                    this.panelMain.Controls.Add(delimiter);
                }

                // Добавляем контрол - неисправность
                DiscrepancyControl d = new DiscrepancyControl();
                d.Index = i + 1;
                if (Flight != null && Flight.Discrepancies != null && i < Flight.Discrepancies.Length)
                {
                    d.Discrepancy = Flight.Discrepancies[i];
                }
                else if (Flight != null) // Не будем создавать Discrepancy, если объект Flight не задан - черевато дальнейшими ошибками
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                    //discrepancy.LoadChildObjectsFromDatabase();
                    //discrepancy.CorrectiveAction.LoadChildObjectsFromDatabase();
                    //discrepancy.Flight = Flight;
                }

                this.panelMain.Controls.Add(d);
            }
        }
        #endregion

        #region private bool DiscrepancyExists(Discrepancy d)
        /// <summary>
        /// Существует ли данное отклонение у полета
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private bool DiscrepancyExists(Discrepancy d)
        {
            //
            if (Flight == null || Flight.Discrepancies == null) return false;

            //
            for (int i = 0; i < Flight.Discrepancies.Length; i++)
                if (Flight.Discrepancies[i] == d)
                    return true;

            //
            return false;
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// При изменении размера контрола расширяем Flow Layout Panel т.к. сама она этого делать не умеет )
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            panelMain.Dock = DockStyle.Fill;
            base.OnSizeChanged(e);
        }
        #endregion


    }
}


