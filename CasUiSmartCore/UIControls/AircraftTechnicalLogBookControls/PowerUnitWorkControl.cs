using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary.Events;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для отображения информации о пассажирах и грузе
    ///</summary>
    public partial class PowerUnitWorkControl : EditObjectControl
    {
        /*
         * Своиства
         */

        #region public DateTime StartTime
        ///<summary>
        /// Возвращает или задает время запуска силовых установок
        ///</summary>
        public DateTime StartTime
        {
            set
            {
                powerUnitRunupsListControl.StartTime = value;
                powerUnitTimeInRegimeListControl.StartTime = value;
            }
        }
        #endregion

        #region public DateTime EndTime
        ///<summary>
        /// Возвращает или задает время остановки силовых установок
        ///</summary>
        public DateTime EndTime
        {
            set { powerUnitRunupsListControl.EndTime = value; }
        }
        #endregion

        #region public DateTime TakeOffTime
        ///<summary>
        /// задает время взлета
        ///</summary>
        public DateTime TakeOffTime
        {
            set
            {
                powerUnitRunupsListControl.TakeOffTime = value;
            }
        }
        #endregion

        #region public DateTime LandingTime
        ///<summary>
        /// задает время посадки
        ///</summary>
        public DateTime LandingTime
        {
            set
            {
                powerUnitRunupsListControl.LandingTime = value;
            }
        }
        #endregion

        #region public DetailType DetailType

        ///<summary>
        /// Задает тип деталей для которых будут производится записи о пусках
        ///</summary>
        public BaseComponentType ComponentType
        {
            set 
            { 
                powerUnitRunupsListControl.ComponentType = value;
                powerUnitTimeInRegimeListControl.ComponentType = value;
                if(value != null && value == BaseComponentType.Apu)
                {
                    flowLayoutPanelMain.Controls.Remove(powerUnitAccelerationListControl);
                    powerUnitAccelerationListControl.Dispose();
                }    
                else powerUnitAccelerationListControl.ComponentType = value;
            }
        }
        #endregion

        #region public AircraftFlight Flight
        ///<summary>
        /// Возвращает редактируемый полет
        ///</summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        #region public DateTime FlightDate
        ///<summary>
        /// Возвращает или задает дату полета
        ///</summary>
        public DateTime FlightDate
        {
            set
            {
                powerUnitRunupsListControl.FlightDate = value;
                powerUnitTimeInRegimeListControl.FlightDate = value;
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PowerUnitWorkControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public PowerUnitWorkControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * Методы
         */

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            if (Flight != null)
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    EditObjectControl cc = c as EditObjectControl;
                    if (cc != null) cc.AttachedObject = AttachedObject;
                }
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Сохраняет данные текущей директивы
        /// </summary>
        public override bool CheckData()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    if (!cc.CheckData()) return false;
            }
            // Все проверки завершились успешно
            return true;
        }

        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Вызывает метод ApplyChanges у каждого контрола
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null) cc.ApplyChanges();
            }
        }
        #endregion

        #region private void PowerUnitRunupsListControlWorkTimeChanged(object sender, EventArgs e)
        private void PowerUnitRunupsListControlWorkTimeChanged(object sender, EventArgs e)
        {
            if (sender as BaseComponent == null 
                ||  e as ValueChangedEventArgs == null 
                || !(((ValueChangedEventArgs)e).Value is TimeSpan)) return;
            
            BaseComponent powerUnit = (BaseComponent)sender;
            TimeSpan workTime = (TimeSpan)((ValueChangedEventArgs)e).Value;
            InvokeWorkTimeChanget(powerUnit, workTime);
        }
        #endregion

        #region Events

        /// <summary>
        /// Событие, оповещающее об изменении времени работы Силовой установки
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении времени работы Силовой установки")]
        public event EventHandler WorkTimeChanged;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении времени работы Силовой установки
        ///</summary>
        private void InvokeWorkTimeChanget(BaseComponent powerUnit, TimeSpan workTime)
        {
            EventHandler handler = WorkTimeChanged;
            if (handler != null)
                handler(powerUnit, new ValueChangedEventArgs(workTime));
        }

        #endregion
    }
}
