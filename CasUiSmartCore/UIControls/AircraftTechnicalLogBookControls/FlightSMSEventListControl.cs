using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{


    /*
     * Общий принцип - пользователю всегда отображается минимум 4 отклонения и те отклонения которые он заполнил сохраняются в базу данных
     * Если на форме отображается 4 отклонения но заполнено только одно, это означает, что во время полета было обнаружено только одно отклонение
     */

    /// <summary>
    /// Строит список отклонений воздушного судна
    /// </summary>
    public partial class FlightSmsEventListControl : Interfaces.EditObjectControl
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

        //private string _station;

        private DateTime _eventDate = DateTime.Today;
        /*
         * 
         */

        #region public DateTime RTSDate
        ///<summary>
        /// Возвращает или задает дату События
        ///</summary>
        public DateTime EventDate
        {
            get
            {
                foreach (Control c in panelMain.Controls)
                {
                    if (!(c is FlightSmsEventControl))
                        continue;

                    return ((FlightSmsEventControl)c).EventDate;
                }
                return DateTime.Today;
            }
            set
            {
                _eventDate = value;
                foreach (Control c in panelMain.Controls)
                {
                    if (!(c is FlightSmsEventControl))
                        continue;

                    ((FlightSmsEventControl)c).EventDate = _eventDate;
                }
            }
        }
        #endregion

        #region public String Station
        /////<summary>
        ///// Возвращает или задает станцию выпуска в сервис
        /////</summary>
        //public String Station
        //{
        //    get
        //    {
        //        foreach (Control c in panelDiscrepancies.Controls)
        //        {
        //            if (!(c is SmsEventControl))
        //                continue;

        //            return ((SmsEventControl)c).Station;
        //        }
        //        return "";
        //    }
        //    set
        //    {
        //        _station = value;
        //        foreach (Control c in panelDiscrepancies.Controls)
        //        {
        //            if (!(c is SmsEventControl))
        //                continue;

        //            ((SmsEventControl)c).Station = _station;
        //        }
        //    }
        //}
        #endregion
        /*
         * Конструктор
         */

        #region public SmsEventListListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FlightSmsEventListControl()
        {
            InitializeComponent();
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
                FlightSmsEventControl d = panelMain.Controls[i] as FlightSmsEventControl;
                if (d != null && d.Event != null)
                {
                    d.ApplyChanges();
                    if (d.Event.ItemId <= 0)
                    {
                        //Новый Discrepancy, добавляем его в AircraftFlight
                        Flight.Events.Add(d.Event);
                    }
                }
            }
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
            List<FlightSmsEventControl> dcs = new List<FlightSmsEventControl>();
            dcs.AddRange(panelMain.Controls.OfType<FlightSmsEventControl>());
            // Проверяем введенные данные
            // Проверяем только те отклонения которые реально были вбиты пользователем (!d.IsNull));
            return dcs.Where(dc => dc != null && dc.Event != null).All(dc => dc.CheckData());
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
            #region Освобождение панелей от контролов
            
            foreach (Control control in panelMain.Controls)
            {
                if (control is FlightSmsEventControl)
                {
                    ((FlightSmsEventControl)control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
                else if (control != panelAdd)
                {
                    control.Dispose();
                }
            }
            panelMain.Controls.Clear();

            #endregion

            #region Добавление контролов

            IRecordCollection<Event> events = Flight != null
                                                ? Flight.Events
                                                : new BaseRecordCollection<Event>();
            for (int i = 0; i < events.Count; i++)
            {
                // Добавляем контрол - неисправность
                FlightSmsEventControl d = new FlightSmsEventControl
                                           {
                                               EnableExtendedControl = events.Count >= 2,
                                               Extended = i <= 1
                                           };
                d.Deleted += ConditionControlDeleted;
                if (Flight != null && i < events.Count)
                {
                    d.Event = events[i];
                }
                panelMain.Controls.Add(d);
            }
            panelMain.Controls.Add(panelAdd);

            #endregion
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// При изменении размера контрола расширяем Flow Layout Panel т.к. сама она этого делать не умеет )
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (panelMain != null) panelMain.Dock = DockStyle.Fill;
            base.OnSizeChanged(e);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelMain.Controls.Remove(panelAdd);
            // Добавляем контрол - неисправность
            FlightSmsEventControl d = new FlightSmsEventControl(new Event { Parent = Flight, AircraftId = Flight.AircraftId})
                                          {
                                              EventDate = _eventDate,
                                              Extended = true,
                                              EnableExtendedControl = false
                                          };
            d.Deleted += ConditionControlDeleted;

            panelMain.Controls.Add(d);
            panelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            FlightSmsEventControl control = (FlightSmsEventControl)sender;
            Event cond = control.Event;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Event?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
                    Flight.Events.Remove(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                if (panelMain.Controls.Contains(control))
                    panelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                if (panelMain.Controls.Contains(control))
                    panelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion

    }
}


