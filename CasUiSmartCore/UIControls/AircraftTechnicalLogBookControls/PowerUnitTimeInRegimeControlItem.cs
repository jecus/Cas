using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
    ///</summary>
    public partial class PowerUnitTimeInRegimeControlItem : EditObjectControl
    {
        private readonly Aircraft _currentAircraft;

        private BaseComponent _prevSelectionBaseComponent;
        private BaseComponent _currentSelectionBaseComponent;

        private FlightRegime _flightRegime;
        private FlightRegime _prevFlightRegime;

        private GroundAir _groundAir;
        private ComponentWorkInRegimeParams _workParams;

        #region public EngineTimeInRegime Condition

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public EngineTimeInRegime Condition
        {
            get { return AttachedObject as EngineTimeInRegime; }
            set {AttachedObject = value;}
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
        /*
         * Конструктор
         */

        #region public EngineTimeInRegimeControlItem()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitTimeInRegimeControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public EngineTimeInRegimeControlItem(Aircraft aircraft, EngineTimeInRegime condition) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitTimeInRegimeControlItem(Aircraft aircraft, EngineTimeInRegime condition): this()
        {
            _currentAircraft = aircraft;
            AttachedObject = condition;
        }
        #endregion

        #region public EngineTimeInRegimeControlItem(Aircraft aircraft) : this(aircraft, new EngineTimeInRegime())
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitTimeInRegimeControlItem(Aircraft aircraft)
            : this(aircraft, new EngineTimeInRegime())
        {
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

        #region public int WorkTime
        /// <summary>
        /// Возвращает или задает время работы
        /// </summary>
        public int WorkTime
        {
            get { return (int)numericUpDownTimeInRegime.Value; }
            set { numericUpDownTimeInRegime.Value = value; }
        }
        #endregion

        #region public int WorkTimeGA
        /// <summary>
        /// Возвращает или задает общее время работы заданной силово установки в заданном режиме за данный полет
        /// </summary>
        public int WorkTimeGA
        {
            get { return (int)numericUpDownTimeInRegimeGroundAir.Value; }
            set { numericUpDownTimeInRegimeGroundAir.Value = value; }
        }
        #endregion

        #region public Lifelength WorkTimeSinceNew
        /// <summary>
        /// задает общее время работы заданной силовой установки в заданном режиме с начала эксплуатации
        /// </summary>
        public Lifelength WorkTimeSinceNew
        {
            set { textBoxTimeInRegimeSN.Text = value == null ? "" : value.ToHoursMinutesFormat("hrs");}
        }
        #endregion

        #region public double PersentSN
        /// <summary>
        /// Возвращает или задает процент отношения работы силовой установки в указанном режиме 
        /// <br/> от общего времени работы силовой установки
        /// </summary>
        public double PersentSN
        {
            get { return (double)numericUpDownPersentSN.Value; }
            set { numericUpDownPersentSN.Value = (decimal)value; }
        }
        #endregion

        #region public double PersentLifeLimit
        /// <summary>
        /// Возвращает или задает процент отношения работы силовой установки в указанном режиме 
        /// <br/> от срока службы агрегата
        /// </summary>
        public double PersentLifeLimit
        {
            get { return (double)numericUpDownPersentLifeLimit.Value; }
            set { numericUpDownPersentLifeLimit.Value = (decimal)value; }
        }
        #endregion

        #region public Lifelength WorkTimeSLO
        /// <summary>
        /// задает общее время работы заданной силовой установки в заданном режиме с момоента последнего ремонта
        /// </summary>
        public Lifelength WorkTimeSLO
        {
            set { textBoxTimeInRegimeSLO.Text = value == null ? "" : value.ToHoursMinutesFormat("hrs"); }
        }
        #endregion

        #region public double PersentSLO
        /// <summary>
        /// Возвращает или задает процент отношения работы силовой установки в указанном режиме 
        /// <br/> от времени работы силовой установки с последнего ремонта
        /// </summary>
        public double PersentSLO
        {
            get { return (double)numericUpDownPersentSLO.Value; }
            set { numericUpDownPersentSLO.Value = (decimal)value; }
        }
        #endregion

        #region public double PersentOhInt
        /// <summary>
        /// Возвращает или задает процент отношения работы силовой установки в указанном режиме 
        /// <br/> от интервала ремонта агрегата
        /// </summary>
        public double PersentOhInt
        {
            get { return (double)numericUpDownPersentOhInt.Value; }
            set { numericUpDownPersentOhInt.Value = (decimal)value; }
        }
        #endregion

        #region public BaseDetail PrevPowerUnit
        /// <summary>
        /// Возвращает пред. выранный режим работы или FlightRegime.UNK
        /// </summary>
        public FlightRegime PrevFlightRegime
        {
            get
            {
                return _prevFlightRegime ?? (_prevFlightRegime = FlightRegime.UNK);
            }
        }
        #endregion

        #region public FlightRegime FlightRegime
        /// <summary>
        /// Возвращает текущий режим работы
        /// </summary>
        public FlightRegime FlightRegime
        {
            get { return _flightRegime ?? (_flightRegime = FlightRegime.UNK); }
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

            //Заполняем общие данные о проведении измерений

            if (Condition != null)
            {
                if (comboBoxEngine.SelectedItem is BaseComponent)
                {
                    Condition.BaseComponent = (BaseComponent)comboBoxEngine.SelectedItem;
                    Condition.BaseComponentId = Condition.BaseComponent.ItemId;
                }
                if (comboBoxFlightRegime.SelectedItem is FlightRegime)
                {
                    Condition.FlightRegime = (FlightRegime)comboBoxFlightRegime.SelectedItem;
                }
                if (comboBoxGroundAir.SelectedItem is GroundAir)
                    Condition.GroundAir = (GroundAir)comboBoxGroundAir.SelectedItem;
                else Condition.GroundAir = GroundAir.Ground;

                Condition.TimeInRegime = TimeSpan.FromMinutes((int)numericUpDownTimeInRegime.Value);
            }
            base.ApplyChanges();
        }
        #endregion

        #region public override bool CheckData()
        public override bool CheckData()
        {
            if (comboBoxFlightRegime.SelectedItem == null)
            {
                MessageBox.Show("Not set Flight Regime", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxFlightRegime.Focus();
                return false;
            }
            if (comboBoxGroundAir.SelectedItem == null)
            {
                MessageBox.Show("Not set Ground/Air", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxGroundAir.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

			//поиск базовой детали
			var aircraftBaseDetails = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, BaseComponentType.Engine.ItemId).ToList();

            comboBoxEngine.Items.Clear();
            if (Condition.ItemId <= 0)
            {
                //новая запись по уровню масла
                //тогда в список добавляются все двигатели и ВСУ
                if (aircraftBaseDetails.Count > 0)
                {
                    comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                    comboBoxEngine.SelectedItem = Condition.BaseComponent;
                }
            }
            else if (Condition.BaseComponent != null)
            {
                if (_currentAircraft != null && _currentAircraft.ItemId == Condition.BaseComponent.ParentAircraftId)
				{
                    //Деталь для которой создавалась запись находится на этом самолете;
                    if (aircraftBaseDetails.Count > 0)
                        comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                }
                else comboBoxEngine.Items.Add(Condition.BaseComponent);
                comboBoxEngine.SelectedItem = Condition.BaseComponent;
            }
            else
            {
                //Базовый компонент для которого сделана запись не найден
                comboBoxEngine.Items.Add("Error: Can't Find component");
            }


            comboBoxFlightRegime.Items.Clear();
            comboBoxFlightRegime.Items.AddRange(FlightRegime.Items.ToArray());
            comboBoxFlightRegime.SelectedItem = Condition.FlightRegime ?? FlightRegime.UNK;

            comboBoxGroundAir.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(GroundAir)))
                comboBoxGroundAir.Items.Add(o);
            comboBoxGroundAir.SelectedItem = Condition.GroundAir;

            numericUpDownTimeInRegime.Value = (decimal)Condition.TimeInRegime.TotalMinutes;
            EndUpdate();
        }
        #endregion

        #region public bool ShowHeaders

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelFlightEngine.Visible; }
            set
            {
                labelTimeInRegimeSinceNew.Visible = value;
                labelGroundAir.Visible = value;
                labelPersentOverhaulInterval.Visible = value;
                labelPersentLifeLimit.Visible = value;
                labelPersentSinceNew.Visible = value;
                labelPersentSLO.Visible = value;
                labelTimeInRegimeSinceLastOH.Visible = value;
                labelRegime.Visible = value;
                labelFlightEngine.Visible = value;
                labelTimeInRegime.Visible = value;
                labelTimeAll.Visible = value;
            }
        }

        #endregion

        #region private void CheckParametres()
        /// <summary>
        /// Проверяет введенные параметры на состветсвие параметрам работы заданной силовой установки
        /// </summary>
        private void CheckParametres()
        {
            if (comboBoxEngine.SelectedItem == null ||
                comboBoxEngine.SelectedItem as BaseComponent == null ||
               _flightRegime == null)
            {
                _workParams = null;
                Color white = Color.White;
                numericUpDownTimeInRegime.BackColor = white;
                numericUpDownPersentSN.BackColor = white;
                numericUpDownPersentSLO.BackColor = white;
                numericUpDownPersentLifeLimit.BackColor = white;
                numericUpDownPersentOhInt.BackColor = white;
                numericUpDownPersentSN.Value = 0;
                numericUpDownPersentSLO.Value = 0;
                numericUpDownPersentLifeLimit.Value = 0;
                numericUpDownPersentOhInt.Value = 0;
                textBoxTimeInRegimeSN.Text = "";
                textBoxTimeInRegimeSLO.Text = "";

            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                _workParams = bd.ComponentWorkParams.Where(wp => wp.FlightRegime == _flightRegime &&
                                                              wp.GroundAir == _groundAir)
                        .FirstOrDefault();
                if (_workParams != null)
                {
                    Color white = Color.White;
                    Color red = Color.Red;

                    if (((double)numericUpDownTimeInRegime.Value > _workParams.TimeInRegimeMax.TotalMinutes && _workParams.TLAMaxEnabled))
                        numericUpDownTimeInRegime.BackColor = red;
                    else numericUpDownTimeInRegime.BackColor = white;

                    //numericUpDownPersentSN.Value = 0;
                    //numericUpDownPersentSLO.Value = 0;
                    //textBoxTimeInRegimeSN.Text = "";
                    //textBoxTimeInRegimeSLO.Text = "";
                }
                else
                {
                    Color white = Color.White;
                    numericUpDownTimeInRegime.BackColor = white;
                    numericUpDownPersentSN.BackColor = white;
                    numericUpDownPersentSLO.BackColor = white;
                    numericUpDownPersentLifeLimit.BackColor = white;
                    numericUpDownPersentOhInt.BackColor = white;
                    //numericUpDownPersentSN.Value = 0;
                    //numericUpDownPersentSLO.Value = 0;
                    //textBoxTimeInRegimeSN.Text = "";
                    //textBoxTimeInRegimeSLO.Text = "";
                }
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        {
            _prevSelectionBaseComponent = _currentSelectionBaseComponent;
            _currentSelectionBaseComponent = comboBoxEngine.SelectedItem as BaseComponent;

            CheckParametres();
            InvokePowerUnitChanget();
        }
        #endregion

        #region private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        {
            _prevFlightRegime = _flightRegime;
            _flightRegime = comboBoxFlightRegime.SelectedItem as FlightRegime;
            
            CheckParametres();
            InvokeFligthRegimeChanget();
        }
        #endregion

        #region private void ComboBoxGroundAirSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxGroundAirSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroundAir.SelectedItem is GroundAir)
                _groundAir = (GroundAir)comboBoxGroundAir.SelectedItem;
            else _groundAir = GroundAir.Ground;

            CheckParametres();
        }
        #endregion

        #region private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        {
            CheckParametres();

            InvokeWorkTimeChanget();
        }
        #endregion

        #region private void NumericUpDownTimeSNValueChanged(object sender, EventArgs e)
        private void NumericUpDownTimeSNValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEngine.SelectedItem == null ||
                comboBoxEngine.SelectedItem as BaseComponent == null ||
               _flightRegime == null)
            {
                numericUpDownPersentSN.BackColor = Color.White;
            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                ComponentWorkInRegimeParams workParams = bd.ComponentWorkParams.Where(wp => wp.FlightRegime == _flightRegime)
                                                                         .FirstOrDefault();
                if (workParams != null)
                {
                    if (workParams.ResorceProvider != SmartCoreType.ComponentDirective 
                        && ((double)numericUpDownPersentSN.Value > workParams.PersentTime))
                        numericUpDownPersentSN.BackColor = Color.Red;
                    else numericUpDownPersentSN.BackColor = Color.White;
                }
                else
                {
                    numericUpDownPersentSN.BackColor = Color.White;
                }
            }
        }
        #endregion

        #region private void NumericUpDownTimeSLOValueChanged(object sender, EventArgs e)
        private void NumericUpDownTimeSLOValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEngine.SelectedItem == null ||
                comboBoxEngine.SelectedItem as BaseComponent == null ||
               _flightRegime == null)
            {
                numericUpDownPersentSLO.BackColor = Color.White;
                numericUpDownPersentLifeLimit.BackColor = Color.White;
                numericUpDownPersentOhInt.BackColor = Color.White;
            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                ComponentWorkInRegimeParams workParams = bd.ComponentWorkParams.Where(wp => wp.FlightRegime == _flightRegime)
                                                                         .FirstOrDefault();
                if (workParams != null)
                {
                    if (workParams.ResorceProvider == SmartCoreType.ComponentDirective
                        && ((double)numericUpDownPersentSLO.Value > workParams.PersentTime))
                        numericUpDownPersentSLO.BackColor = Color.Red;
                    else numericUpDownPersentSLO.BackColor = Color.White;
                }
                else
                {
                    numericUpDownPersentSLO.BackColor = Color.White;
                }
            }
        }
        #endregion

        #region private void NumericUpDownPersentLifeLimitValueChanged(object sender, EventArgs e)
        private void NumericUpDownPersentLifeLimitValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEngine.SelectedItem == null ||
               comboBoxEngine.SelectedItem as BaseComponent == null ||
              _flightRegime == null)
            {
                numericUpDownPersentLifeLimit.BackColor = Color.White;
            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                ComponentWorkInRegimeParams workParams = bd.ComponentWorkParams.Where(wp => wp.FlightRegime == _flightRegime)
                                                                         .FirstOrDefault();
                if (workParams != null)
                {
                    if (workParams.ResorceProvider != SmartCoreType.ComponentDirective
                        && ((double)numericUpDownPersentLifeLimit.Value > workParams.PersentTime))
                        numericUpDownPersentLifeLimit.BackColor = Color.Red;
                    else numericUpDownPersentLifeLimit.BackColor = Color.White;
                }
                else
                {
                    numericUpDownPersentLifeLimit.BackColor = Color.White;
                }
            }
        }
        #endregion

        #region private void NumericUpDownPersentOhIntValueChanged(object sender, EventArgs e)
        private void NumericUpDownPersentOhIntValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEngine.SelectedItem == null ||
                comboBoxEngine.SelectedItem as BaseComponent == null ||
               _flightRegime == null)
            {
                numericUpDownPersentOhInt.BackColor = Color.White;
            }
            else
            {
                BaseComponent bd = comboBoxEngine.SelectedItem as BaseComponent;
                ComponentWorkInRegimeParams workParams = bd.ComponentWorkParams.Where(wp => wp.FlightRegime == _flightRegime)
                                                                         .FirstOrDefault();
                if (workParams != null)
                {
                    if (workParams.ResorceProvider == SmartCoreType.ComponentDirective
                        && ((double)numericUpDownPersentOhInt.Value > workParams.PersentTime))
                        numericUpDownPersentOhInt.BackColor = Color.Red;
                    else numericUpDownPersentOhInt.BackColor = Color.White;
                }
                else
                {
                    numericUpDownPersentOhInt.BackColor = Color.White;
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// Событие, оповещающее об изменении параметров
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении силовой установки")]
        public event EventHandler PowerUnitChanget;

        /// <summary>
        /// Событие, оповещающее об изменении параметров
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении Режима работы")]
        public event EventHandler FligthRegimeChanget;

        /// <summary>
        /// Событие, оповещающее об изменении параметров
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении Времени работы")]
        public event EventHandler WorkTimeChanget;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении силовой установки
        ///</summary>
        private void InvokePowerUnitChanget()
        {
            EventHandler handler = PowerUnitChanget;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        ///<summary>
        /// Возбуждает событие оповещающее об изменении Режима работы
        ///</summary>
        private void InvokeFligthRegimeChanget()
        {
            EventHandler handler = FligthRegimeChanget;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        ///<summary>
        /// Возбуждает событие оповещающее об изменении Времени работы
        ///</summary>
        private void InvokeWorkTimeChanget()
        {
            EventHandler handler = WorkTimeChanget;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

    }
}
