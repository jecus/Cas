using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Строит список контролов для отображения информации по маслу
    /// </summary>
    public partial class ComponentOilListControl : CAS.UI.Interfaces.EditObjectControl
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

        #region public ComponentOilListControl()
        /// <summary>
        /// Строит список контролов для отображения информации по маслу
        /// </summary>
        public ComponentOilListControl()
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
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                ComponentOilControl c = flowLayoutPanel1.Controls[i] as ComponentOilControl;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.OilConditionCollection != null && !ConditionExists(c.OilCondition))
                    Flight.OilConditionCollection.Add(c.OilCondition);
            }


            /*
             * Все изменения сохранены в коллекции 
             * 
             * Здесь необходимо сохранить внесенные данные 
             * Коллекция является StringConvertibleCollection и не имеет отдельной таблицы в базе данных, 
             * а хранится в качестве поля таблицы AircraftFlights
             */

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
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                ComponentOilControl c = flowLayoutPanel1.Controls[i] as ComponentOilControl;
                if (c != null)
                    if (!c.CheckData()) return false;
            }

            // Все данные введены корректно
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
            flowLayoutPanel1.Controls.Clear();


            int count = 5;
            if (Flight != null && Flight.OilConditionCollection != null && Flight.OilConditionCollection.Count > count)
                count = Flight.OilConditionCollection.Count;

            for (int i = 0; i < count; i++)
            {
                // Добавляем контрол для ввода данных по маслу
                ComponentOilControl c = new ComponentOilControl();
                if (Flight != null && Flight.OilConditionCollection != null && i < Flight.OilConditionCollection.Count)
                {
                    c.OilCondition = Flight.OilConditionCollection[i];
                }
                else if (Flight != null) 
                {
                    ComponentOilCondition condition = new ComponentOilCondition();
                    c.OilCondition = condition;
                }
                // 
                this.flowLayoutPanel1.Controls.Add(c);
            }
        }
        #endregion

        #region private bool ConditionExists(ComponentOilCondition con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private bool ConditionExists(ComponentOilCondition con)
        {
            //
            if (Flight == null || Flight.OilConditionCollection == null) return false;

            //
            for (int i = 0; i < Flight.OilConditionCollection.Count; i++)
                if (Flight.OilConditionCollection[i] == con)
                    return true;

            //
            return false;
        }
        #endregion



    }
}

