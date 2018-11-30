using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class PowerUnitRunupControl : EditObjectControl
    {
        private readonly Aircraft _currentAircraft;
        private BaseComponent _prevSelectionBaseComponent;
        private BaseComponent _currentSelectionBaseComponent;

        private DateTime _flightDate;
        private DateTime _outTime;
        private DateTime _takeOffTime;
        private DateTime _landingTime;
        private DateTime _inTime;

        #region public DetailType DetailType

        private BaseComponentType _componentType;
        ///<summary>
        /// Задает тип деталей для которых будут производится записи о пусках
        ///</summary>
        public BaseComponentType ComponentType
        {
            set { _componentType = value; }
        }
        #endregion

        #region public RunUp Runup

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public RunUp Runup
        {
            get { return AttachedObject as RunUp; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PowerUnitRunupControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private PowerUnitRunupControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public PowerUnitRunupControl(Aircraft aircraft, RunUp runup) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitRunupControl(Aircraft aircraft, RunUp runup)
            : this()
        {
            _currentAircraft = aircraft;
            _componentType = runup.BaseComponent.BaseComponentType;
            AttachedObject = runup;
        }
        #endregion

        #region public PowerUnitRunupControl(Aircraft aircraft, AircraftFlight flight, RunUp runup): this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitRunupControl(Aircraft aircraft, AircraftFlight flight, RunUp runup)
            : this()
        {
            _currentAircraft = aircraft;
            _componentType = runup.BaseComponent.BaseComponentType;
            _outTime = flight.FlightDate.Date.AddMinutes(flight.OutTime);
            _takeOffTime = flight.FlightDate.Date.AddMinutes(flight.TakeOffTime);
            _landingTime = flight.FlightDate.Date.AddMinutes(flight.LDGTime);
            _inTime = flight.FlightDate.Date.AddMinutes(flight.InTime);
            AttachedObject = runup;
        }
        #endregion

        #region public PowerUnitRunupControl(Aircraft aircraft, DetailType detailType) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitRunupControl(Aircraft aircraft, BaseComponentType componentType) : this()
        {
            _currentAircraft = aircraft;
            _componentType = componentType;
            AttachedObject = new RunUp();
        }
        #endregion

        /*
         * Своиства
         */
        #region public BaseDetail PrevPowerUnit
        /// <summary>
        /// Возвращаетпред. выранную силовую установку или null
        /// </summary>
        public BaseComponent PrevPowerUnit
        {
            get
            {
                return _prevSelectionBaseComponent;
            }
        }
        #endregion

        #region public BaseDetail PowerUnit
        /// <summary>
        /// Возвращает выранную силовую установку или null
        /// </summary>
        public BaseComponent PowerUnit
        {
            get
            {
                return _currentSelectionBaseComponent;    
            }
        }
        #endregion

        #region public TimeSpan WorkTime
        ///<summary>
        /// Возвращает время работы силовой установки
        ///</summary>
        public TimeSpan WorkTime
        {
            get
            {
                return UsefulMethods.GetDifference(dateTimePickerOff.Value.TimeOfDay,
                                                   dateTimePickerStart.Value.TimeOfDay);
            }
        }
        #endregion

        #region public DateTime FligthDate
        ///<summary>
        /// Возвращает или задает дату полета
        ///</summary>
        public DateTime FligthDate
        {
            set { _flightDate = value; SetLifelenght();}
        }
        #endregion

        #region public DateTime StartTime
        ///<summary>
        /// Возвращает или задает время запуска силовой установки
        ///</summary>
        public DateTime StartTime
        {
            get { return dateTimePickerStart.Value; }
            set
            {
                _outTime = value;
                if(Runup.ItemId < 0)
				{
					dateTimePickerStart.Value = _outTime;
					if (_currentAircraft.ApuUtizationPerFlightinMinutes != null)
						dateTimePickerOff.Value = _outTime + TimeSpan.FromMinutes((double)_currentAircraft.ApuUtizationPerFlightinMinutes);	
				}
			}
        }
        #endregion

        #region public DateTime EndTime
        ///<summary>
        /// Возвращает или задает время остановки силовой установки
        ///</summary>
        public DateTime EndTime
        {
            get { return dateTimePickerOff.Value; }
            set
            {
                _inTime = value;
                if (Runup.ItemId < 0 && _currentAircraft.ApuUtizationPerFlightinMinutes == null)
					dateTimePickerOff.Value = _inTime;
            }
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
                _takeOffTime = value;
                SetWorkLandAirTime();
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
                _landingTime = value;
                SetWorkLandAirTime();
            }
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
            if (Runup != null)
            {
                if (comboBoxEngine.SelectedItem is BaseComponent)
                {
                    Runup.BaseComponentId =
                        ((BaseComponent)comboBoxEngine.SelectedItem).ItemId;
                    Runup.BaseComponent = (BaseComponent)comboBoxEngine.SelectedItem;
                }

                Runup.StartTime = dateTimePickerStart.Value.TimeOfDay;
                if (comboBoxRunupType.SelectedItem != null)
                    Runup.RunUpType = (RunUpType) comboBoxRunupType.SelectedItem;
                if (comboBoxRunupPhase.SelectedItem != null)
                    Runup.RunUpPhase = (DetectionPhase)comboBoxRunupPhase.SelectedItem;
                if (comboBoxRunupCond.SelectedItem != null)
                    Runup.RunUpCondition = (RunUpCondition) comboBoxRunupCond.SelectedItem;

                Runup.EndTime = dateTimePickerOff.Value.TimeOfDay;
                if (comboBoxOffPhase.SelectedItem != null) 
                    Runup.EndPhase = (DetectionPhase)comboBoxOffPhase.SelectedItem;
                if (comboBoxShutDownType.SelectedItem != null)
                    Runup.ShutDownType = (ShutDownType)comboBoxShutDownType.SelectedItem;
                
                Runup.ShutDownReasonId = reasonComboBox.SelectedReason != null ? reasonComboBox.SelectedReason.ItemId : 0;
                Runup.LandTime = dateTimePickerLandTime.Value.TimeOfDay;
                Runup.AirTime = dateTimePickerAirTime.Value.TimeOfDay;
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {

            BeginUpdate();

            reasonComboBox.ReasonCategory = "ShutDown";
            
            if (Runup != null)
            {

                //поиск базовой детали
                List<BaseComponent> aircraftBaseDetails;
                comboBoxEngine.Items.Clear();

                if (Runup.ItemId <= 0)
                {
					//новая запись по уровню масла
					//тогда в список добавляются все двигатели и ВСУ
					aircraftBaseDetails =  GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, _componentType.ItemId).ToList();

                    if (aircraftBaseDetails.Count > 0)
                    {
                        comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                        if (Runup.BaseComponent != null) comboBoxEngine.SelectedItem = Runup.BaseComponent;
                        else comboBoxEngine.SelectedIndex = 0;
                    }
                }
                else if (Runup.BaseComponent != null)
                {
                    if (_currentAircraft != null && _currentAircraft.ItemId == Runup.BaseComponent.ParentAircraftId)
					{
						//Деталь для которой создавалась запись находится на этом самолете
						aircraftBaseDetails =  GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, Runup.BaseComponent.BaseComponentType.ItemId).ToList();

                        if (aircraftBaseDetails.Count > 0)
                            comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                    }
                    else
                    {
                        comboBoxEngine.Items.Add(Runup.BaseComponent);
                        comboBoxEngine.Enabled = false;
                    }
                    comboBoxEngine.SelectedItem = Runup.BaseComponent;
                }
                else
                {
                    //Базовый компонент для которого сделана запись не найден
                    comboBoxEngine.Items.Add("Error: Can't Find component");
                }

                dateTimePickerStart.Value = Runup.ItemId > 0 ? Runup.RecordDate.Date.Add(Runup.StartTime) : DateTime.Today;
                comboBoxRunupType.Items.Clear();
                foreach (object o in Enum.GetValues(typeof(RunUpType)))
                    comboBoxRunupType.Items.Add(o);
                comboBoxRunupType.SelectedItem = Runup.RunUpType > 0 ? Runup.RunUpType : 0;
                
                comboBoxRunupPhase.Items.Clear();
                foreach (object o in Enum.GetValues(typeof(DetectionPhase)))
                    comboBoxRunupPhase.Items.Add(o);
                comboBoxRunupPhase.SelectedItem = Runup.RunUpPhase > 0 ? Runup.RunUpPhase : 0;

                comboBoxRunupCond.Items.Clear();
                foreach (object o in Enum.GetValues(typeof(RunUpCondition)))
                    comboBoxRunupCond.Items.Add(o);
                comboBoxRunupCond.SelectedItem = Runup.RunUpCondition > 0 ? Runup.RunUpCondition : 0;

                dateTimePickerOff.Value = Runup.ItemId > 0 ? Runup.RecordDate.Date.Add(Runup.EndTime) : DateTime.Today;


				comboBoxOffPhase.Items.Clear();
                foreach (object o in Enum.GetValues(typeof(DetectionPhase)))
                    comboBoxOffPhase.Items.Add(o);
                comboBoxOffPhase.SelectedItem = Runup.EndPhase > 0 ? Runup.EndPhase : 0;

                comboBoxShutDownType.Items.Clear();
                foreach (object o in Enum.GetValues(typeof(ShutDownType)))
                    comboBoxShutDownType.Items.Add(o);
                comboBoxShutDownType.SelectedItem = Runup.ShutDownType > 0 ? Runup.ShutDownType : ShutDownType.Manual;

                reasonComboBox.SelectedReason = 
                    GlobalObjects.CasEnvironment.Reasons.GetItemById(Runup.ShutDownReasonId);

                dateTimePickerLandTime.Value = Runup.ItemId > 0 ? Runup.RecordDate.Date.Add(Runup.LandTime) : DateTime.Today;
                dateTimePickerAirTime.Value = Runup.ItemId > 0 ? Runup.RecordDate.Date.Add(Runup.AirTime) : DateTime.Today;


				if (comboBoxEngine.SelectedItem != null && ((BaseComponent)comboBoxEngine.SelectedItem).IsDeleted)
					comboBoxEngine.BackColor = Color.FromArgb(Highlight.Red.Color);
				else comboBoxEngine.BackColor = Color.White;
			}
            EndUpdate();
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
            //TimeSpan time;
            //if (!TimeSpan.TryParse(textStartTime.Text, out time))
            //{
            //    SimpleBalloon.Show(textStartTime, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time in the following format: HH:MM");
            //    return false;
            //}
            //if (!TimeSpan.TryParse(textBoxOffTime.Text, out time))
            //{
            //    SimpleBalloon.Show(textBoxOffTime, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time in the following format: HH:MM");
            //    return false;
            //}
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region public bool ShowHeaders { get; set; }

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelFlightEngine.Visible; }
            set
            {
                labelFlightEngine.Visible = value;
                labelOffPhase.Visible = value;
                labelReason.Visible = value;
                labelRunupCondition.Visible = value;
                labelRunUpPhase.Visible = value;
                labelRunupType.Visible = value;
                labelShutdownTime.Visible = value;
                labelShutdownType.Visible = value;
                labelTime.Visible = value;
                labelTimeOnLand.Visible = value;
                labelAirTime.Visible = value;
                labelWorkTime.Visible = value;
                labelWork120.Visible = value;
                labelLifelenght.Visible = value;
            }
        }

        #endregion

        #region private void SetLifelenght()
        private void SetLifelenght()
        {
            if (_currentSelectionBaseComponent != null)
            {
                var baseDetailLifeLenght =
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentSelectionBaseComponent, _flightDate);
                if (_currentAircraft != null)
                {
	                var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(_currentAircraft.ItemId, _flightDate);

                    foreach (var aircraftFlight in flights)
                    {
                        if (aircraftFlight.FlightDate < _flightDate.Date.Add(_outTime.TimeOfDay))
                        {
                            baseDetailLifeLenght.Add(GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(aircraftFlight, _currentSelectionBaseComponent));
                        }
                    }
                }

                baseDetailLifeLenght.Add(LifelengthSubResource.Minutes, (int)dateTimePickerWork120.Value.TimeOfDay.TotalMinutes);
                textBoxLifelenght.Text = baseDetailLifeLenght.ToHoursMinutesFormat("hrs");
            }
        }
        #endregion

        #region private void SetWorkLandAirTime()
        private void SetWorkLandAirTime()
        {
            dateTimePickerAirTime.ValueChanged -= DateTimePickerAirTimeValueChanged;
            dateTimePickerLandTime.ValueChanged -= DateTimePickerLandTimeValueChanged;

            TimeSpan air =
                UsefulMethods.GetDifference(_landingTime.TimeOfDay,
                                            _takeOffTime.TimeOfDay);

            dateTimePickerAirTime.Value = dateTimePickerStart.Value.Date.Add(air);

	        TimeSpan workTime = UsefulMethods.GetDifference(dateTimePickerOff.Value.TimeOfDay,dateTimePickerStart.Value.TimeOfDay);

			dateTimePickerWorkTime.Value = dateTimePickerStart.Value.Date.Add(workTime);

            TimeSpan land =
                UsefulMethods.GetDifference(workTime,air);

            dateTimePickerLandTime.Value = dateTimePickerStart.Value.Date.Add(land);

            //общее время работы в воздухе с учетом 20% времени работы на земле за данный пуск
            TimeSpan work120Time = air.Add(TimeSpan.FromMinutes(land.TotalMinutes * 0.2));
            dateTimePickerWork120.Value = dateTimePickerStart.Value.Date.Add(work120Time);

            SetLifelenght();

            dateTimePickerAirTime.ValueChanged += DateTimePickerAirTimeValueChanged;
            dateTimePickerLandTime.ValueChanged += DateTimePickerLandTimeValueChanged;
        }
        #endregion

        #region public string DetailLabelText
        /// <summary>
        /// Текст над списком дкталей
        /// </summary>
        public string DetailLabelText 
        {
            get { return labelFlightEngine.Text; }
            set { labelFlightEngine.Text = value; }
        }

        #endregion

        #region public bool EnableDetailCombobox
        /// <summary>
        /// Блокировать ли Список деталей
        /// </summary>
        public bool EnableDetailCombobox
        {
            get { return comboBoxEngine.Enabled; }
            set { comboBoxEngine.Enabled = value; }
        }

        #endregion

        #region private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        {
            _prevSelectionBaseComponent = _currentSelectionBaseComponent;
            _currentSelectionBaseComponent = comboBoxEngine.SelectedItem as BaseComponent;
            
            InvokeWorkTimeChanget();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void DateTimePickerValueChanged(object sender, EventArgs args)
        private void DateTimePickerValueChanged(object sender, EventArgs args)
        {
            if(sender == dateTimePickerStart || sender == dateTimePickerOff)
            {
                SetWorkLandAirTime();
                InvokeWorkTimeChanget();
            }
        }
        #endregion

        #region private void DateTimePickerLandTimeValueChanged(object sender, EventArgs e)
        private void DateTimePickerLandTimeValueChanged(object sender, EventArgs e)
        {
            dateTimePickerAirTime.ValueChanged -= DateTimePickerAirTimeValueChanged;

            TimeSpan workTime =
                UsefulMethods.GetDifference(dateTimePickerOff.Value.TimeOfDay,
                                            dateTimePickerStart.Value.TimeOfDay);

            dateTimePickerWorkTime.Value = dateTimePickerStart.Value.Date.Add(workTime);

            TimeSpan air =
                UsefulMethods.GetDifference(workTime, 
                                            dateTimePickerLandTime.Value.TimeOfDay);

            dateTimePickerAirTime.Value = dateTimePickerStart.Value.Date.Add(air);

            //общее время работы в воздухе с учетом 20% времени работы на земле за данный пуск
            TimeSpan work120Time = air.Add(TimeSpan.FromMinutes(dateTimePickerLandTime.Value.TimeOfDay.TotalMinutes * 0.2));
            dateTimePickerWork120.Value = dateTimePickerStart.Value.Date.Add(work120Time);

            SetLifelenght();

            dateTimePickerAirTime.ValueChanged += DateTimePickerAirTimeValueChanged;
        }
        #endregion

        #region private void DateTimePickerAirTimeValueChanged(object sender, EventArgs e)
        private void DateTimePickerAirTimeValueChanged(object sender, EventArgs e)
        {
            dateTimePickerLandTime.ValueChanged -= DateTimePickerLandTimeValueChanged;

            TimeSpan workTime =
                UsefulMethods.GetDifference(dateTimePickerOff.Value.TimeOfDay,
                                            dateTimePickerStart.Value.TimeOfDay);

            dateTimePickerWorkTime.Value = dateTimePickerStart.Value.Date.Add(workTime);

            TimeSpan land =
                UsefulMethods.GetDifference(workTime,
                                            dateTimePickerAirTime.Value.TimeOfDay);

            dateTimePickerLandTime.Value = dateTimePickerStart.Value.Date.Add(land);

            //общее время работы в воздухе с учетом 20% времени работы на земле за данный пуск
            TimeSpan work120Time = dateTimePickerAirTime.Value.TimeOfDay.Add(TimeSpan.FromMinutes(land.TotalMinutes * 0.2));
            dateTimePickerWork120.Value = dateTimePickerStart.Value.Date.Add(work120Time);

            SetLifelenght();

            dateTimePickerLandTime.ValueChanged += DateTimePickerLandTimeValueChanged;
        }
        #endregion

        #region Events
        /// <summary>
        /// Событие удаления контрола
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// Событие, оповещающее об изменении времени работы Силовой установки
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении времени работы Силовой установки")]
        public event EventHandler WorkTimeChanged;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении времени работы Силовой установки
        ///</summary>
        private void InvokeWorkTimeChanget()
        {
            EventHandler handler = WorkTimeChanged;
            if (handler != null) 
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
