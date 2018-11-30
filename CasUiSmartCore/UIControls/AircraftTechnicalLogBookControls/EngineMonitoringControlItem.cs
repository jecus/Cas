using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    ///</summary>
    public partial class EngineMonitoringControlItem : EditObjectControl
    {
        private readonly Aircraft _currentAircraft;

        private FlightRegime _flightRegime;
        private GroundAir _groundAir;
        private ComponentWorkInRegimeParams _workParams;

        private BaseComponent _currentSelectionBaseComponent;

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

        #region public EngineCondition Condition

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public EngineCondition Condition
        {
            get{return AttachedObject as EngineCondition; }
            set{AttachedObject = value;}
        }
        #endregion

        #region public FlightRegime FlightRegime
        ///<summary>
        /// задает режим полета для замеров
        ///</summary>
        public FlightRegime FlightRegime
        {
            set { _flightRegime = value; CheckParametres();}
        }
        #endregion

        #region public GroundAir GroundAir
        ///<summary>
        /// задает место проведения замеров
        ///</summary>
        public GroundAir GroundAir
        {
            set { _groundAir = value; CheckParametres(); }
        }
        #endregion

        #region public double OilFlow
        ///<summary>
        /// задает среднечасовой расход масла
        ///</summary>
        public double OilFlow
        {
            set { numericUpDownOilFlow.Value = (decimal)value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public EngineMonitoringControlItem()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public EngineMonitoringControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public EngineMonitoringControlItem(Aircraft aircraft, EngineCondition condition) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public EngineMonitoringControlItem(Aircraft aircraft, EngineCondition condition): this()
        {
            _currentAircraft = aircraft;
            AttachedObject = condition;
        }
        #endregion

        #region public EngineMonitoringControlItem(Aircraft aircraft) : this(aircraft, new EngineCondition())
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public EngineMonitoringControlItem(Aircraft aircraft)
            : this(aircraft, new EngineCondition())
        {
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
                    Condition.Engine = (BaseComponent)comboBoxEngine.SelectedItem;
                }
                Condition.TimeInRegime = (short) numericUpDownTimeInRegime.Value;
                Condition.ThrottleLeverAngle = (int)numericUpDownThrottleLeverAngle.Value;
                Condition.FuelPress = (double) numericUpDownFuelPress.Value;
                Condition.OilPressTorque = (double) numericUpDownOilPressTorque.Value;
                Condition.OilFlow = (double) numericUpDownOilFlow.Value;
                Condition.VibroOverload = (double) numericUpDownVibrationOverload.Value;
                Condition.VibroOverload2 = (double) numericUpDownVibrationOverload2.Value;
                Condition.ERP = (double)numericUpDownERP.Value;
                Condition.N1 = (double)numericUpDownN1.Value;
                Condition.EGT = (double)numericUpDownEGT.Value;
                Condition.N2 = (double)numericUpDownN2.Value;
                Condition.OilTemperature = (double)numericUpDownOilTemp.Value;
                Condition.OilPressure = (double)numericUpDownOilPress.Value;
                Condition.FuelFlow = (double)numericUpDownFuelFlow.Value;
                Condition.FuelBurn = (double)numericUpDownFuelBurn.Value;
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

			var baseDetailTypeIds = new[] { BaseComponentType.Apu.ItemId, BaseComponentType.Engine.ItemId };
			//поиск базовой детали
			var aircraftBaseDetails = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId, baseDetailTypeIds).ToList();

            comboBoxEngine.Items.Clear();
            if (Condition.ItemId <= 0)
            {
                //новая запись по уровню масла
                //тогда в список добавляются все двигатели и ВСУ
                if (aircraftBaseDetails.Count > 0)
                {
                    comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                    comboBoxEngine.SelectedItem = Condition.Engine;
                }
            }
            else if (Condition.Engine != null)
            {
                if (_currentAircraft != null && _currentAircraft.ItemId == Condition.Engine.ParentAircraftId)
				{
                    //Деталь для которой создавалась запись находится на этом самолете;
                    if (aircraftBaseDetails.Count > 0)
                        comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
                }
                else comboBoxEngine.Items.Add(Condition.Engine);
                comboBoxEngine.SelectedItem = Condition.Engine;
            }
            else
            {
                //Базовый компонент для которого сделана запись не найден
                comboBoxEngine.Items.Add("Error: Can't Find component");
            }

            numericUpDownERP.Value = (decimal)Condition.ERP;
            numericUpDownN1.Value = (decimal)Condition.N1;
            numericUpDownEGT.Value = (decimal)Condition.EGT;
            numericUpDownN2.Value = (decimal)Condition.N2;
            numericUpDownOilTemp.Value = (decimal)Condition.OilTemperature;
            numericUpDownOilPress.Value = (decimal)Condition.OilPressure;
            numericUpDownFuelFlow.Value = (decimal)Condition.FuelFlow;
            numericUpDownFuelBurn.Value = (decimal)Condition.FuelBurn;
            numericUpDownTimeInRegime.Value = Condition.TimeInRegime;
            numericUpDownThrottleLeverAngle.Value = Condition.ThrottleLeverAngle;
            numericUpDownFuelPress.Value = (decimal)Condition.FuelPress;
            numericUpDownOilPressTorque.Value = (decimal)Condition.OilPressTorque;
            numericUpDownOilFlow.Value = (decimal) Condition.OilFlow;
            numericUpDownVibrationOverload.Value = (decimal)Condition.VibroOverload;
            numericUpDownVibrationOverload2.Value = (decimal) Condition.VibroOverload2;
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
                labelTimeInRegime.Visible = value;
                labelTLA.Visible = value;
                labelVibrationOverload1.Visible = value;
                labelVibrationOverload2.Visible = value;
                labelOilPressTorque.Visible = value;
                labelFuelPress.Visible = value;
                labelFlightEngine.Visible = value;
                labelERP.Visible = value;
                labelEGT.Visible = value;
                labelFuelBurn.Visible = value;
                labelFuelFlow.Visible = value;
                labelOilFlow.Visible = value;
                labelN1.Visible = value;
                labelN2.Visible = value;
                labelOilPress.Visible = value;
                labelOilTemp.Visible = value;
            }
        }

        #endregion

        /*
         * Реализация
         */
        #region private void CheckParametres()
        private void CheckParametres()
        {
            if(comboBoxEngine.SelectedItem == null || 
               comboBoxEngine.SelectedItem as BaseComponent == null || 
               _flightRegime == null)
            {
                _workParams = null;
                Color white = Color.White;
                numericUpDownTimeInRegime.BackColor = white;
                numericUpDownThrottleLeverAngle.BackColor = white;
                numericUpDownFuelPress.BackColor = white;
                numericUpDownOilPressTorque.BackColor = white;
                numericUpDownOilFlow.BackColor = white;
                numericUpDownVibrationOverload.BackColor = white;
                numericUpDownVibrationOverload2.BackColor = white;
                numericUpDownERP.BackColor = white;
                numericUpDownN1.BackColor = white;
                numericUpDownEGT.BackColor = white;
                numericUpDownN2.BackColor = white;
                numericUpDownOilTemp.BackColor = white;
                numericUpDownOilPress.BackColor = white;
                numericUpDownFuelFlow.BackColor = white;
                numericUpDownFuelBurn.BackColor = white;
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

                    if (((double)numericUpDownThrottleLeverAngle.Value > _workParams.TLAMax && _workParams.TLAMaxEnabled) ||
                        ((double)numericUpDownThrottleLeverAngle.Value < _workParams.TLAMin && _workParams.TLAMinEnabled))
                        numericUpDownThrottleLeverAngle.BackColor = red;
                    else numericUpDownThrottleLeverAngle.BackColor = white;

                    if (((double)numericUpDownFuelPress.Value > _workParams.FuelPressMax && _workParams.FuelPressMaxEnabled) ||
                        ((double)numericUpDownFuelPress.Value < _workParams.FuelPressMin && _workParams.FuelPressMinEnabled))
                        numericUpDownFuelPress.BackColor = red;
                    else numericUpDownFuelPress.BackColor = white;

                    if (((double)numericUpDownOilPressTorque.Value > _workParams.OilPressTorqueMax && _workParams.OilPressTorqueMaxEnabled) ||
                        ((double)numericUpDownOilPressTorque.Value < _workParams.OilPressTorqueMin && _workParams.OilPressTorqueMinEnabled))
                        numericUpDownOilPressTorque.BackColor = red;
                    else numericUpDownOilPressTorque.BackColor = white;

                    if (((double)numericUpDownVibrationOverload.Value > _workParams.VibroOverloadMax && _workParams.VibroOverloadMaxEnabled) ||
                        ((double)numericUpDownVibrationOverload.Value < _workParams.VibroOverloadMin && _workParams.VibroOverloadMinEnabled))
                        numericUpDownVibrationOverload.BackColor = red;
                    else numericUpDownVibrationOverload.BackColor = white;

                    if (((double)numericUpDownVibrationOverload2.Value > _workParams.VibroOverload2Max && _workParams.VibroOverload2MaxEnabled) ||
                        ((double)numericUpDownVibrationOverload2.Value < _workParams.VibroOverload2Min && _workParams.VibroOverload2MinEnabled))
                        numericUpDownVibrationOverload2.BackColor = red;
                    else numericUpDownVibrationOverload2.BackColor = white;

                    if (((double)numericUpDownERP.Value > _workParams.EPRMax && _workParams.EPRMaxEnabled)||
                        ((double)numericUpDownERP.Value < _workParams.EPRMin && _workParams.EPRMinEnabled))
                        numericUpDownERP.BackColor = red;
                    else numericUpDownERP.BackColor = white;

                    if (((double)numericUpDownN1.Value > _workParams.N1Max && _workParams.N1MaxEnabled) ||
                        ((double)numericUpDownN1.Value < _workParams.N1Min && _workParams.N1MinEnabled))
                        numericUpDownN1.BackColor = red;
                    else numericUpDownN1.BackColor = white;

                    if (((double)numericUpDownEGT.Value > _workParams.EGTMax && _workParams.EGTMaxEnabled) ||
                        ((double)numericUpDownEGT.Value < _workParams.EGTMin && _workParams.EGTMinEnabled))
                        numericUpDownEGT.BackColor = red;
                    else numericUpDownEGT.BackColor = white;

                    if (((double)numericUpDownN2.Value > _workParams.N2Max && _workParams.N2MaxEnabled)||
                        ((double)numericUpDownN2.Value < _workParams.N2Min && _workParams.N2MinEnabled))
                        numericUpDownN2.BackColor = red;
                    else numericUpDownN2.BackColor = white;

                    if (((double)numericUpDownOilTemp.Value > _workParams.OilTemperatureMax && _workParams.OilTemperatureMaxEnabled)||
                        ((double)numericUpDownOilTemp.Value < _workParams.OilTemperatureMin && _workParams.OilTemperatureMinEnabled))
                        numericUpDownOilTemp.BackColor = red;
                    else numericUpDownOilTemp.BackColor = white;

                    if (((double)numericUpDownOilPress.Value > _workParams.OilPressureMax && _workParams.OilPressureMaxEnabled) ||
                        ((double)numericUpDownOilPress.Value < _workParams.OilPressureMin && _workParams.OilPressureMinEnabled))
                        numericUpDownOilPress.BackColor = red;
                    else numericUpDownOilPress.BackColor = white;

                    if (((double)numericUpDownOilFlow.Value > _workParams.OilFlowMax && _workParams.OilFlowMaxEnabled) ||
                        ((double)numericUpDownOilFlow.Value < _workParams.OilFlowMin && _workParams.OilFlowMinEnabled))
                        numericUpDownOilFlow.BackColor = red;
                    else numericUpDownOilFlow.BackColor = white;

                    if (((double)numericUpDownFuelFlow.Value > _workParams.FuelFlowMax && _workParams.FuelFlowMaxEnabled)||
                        ((double)numericUpDownFuelFlow.Value < _workParams.FuelFlowMin && _workParams.FuelFlowMinEnabled))
                        numericUpDownFuelFlow.BackColor = red;
                    else numericUpDownFuelFlow.BackColor = white;

                    if (((double)numericUpDownFuelBurn.Value > _workParams.FuelBurnMax && _workParams.FuelBurnMaxEnabled) ||
                        ((double)numericUpDownFuelBurn.Value < _workParams.FuelBurnMin && _workParams.FuelBurnMinEnabled))
                        numericUpDownFuelBurn.BackColor = red;
                    else numericUpDownFuelBurn.BackColor = white;    
                }
                else
                {
                    Color white = Color.White;
                    numericUpDownTimeInRegime.BackColor = white;
                    numericUpDownThrottleLeverAngle.BackColor = white;
                    numericUpDownFuelPress.BackColor = white;
                    numericUpDownOilPressTorque.BackColor = white;
                    numericUpDownVibrationOverload.BackColor = white;
                    numericUpDownVibrationOverload2.BackColor = white;
                    numericUpDownERP.BackColor = white;
                    numericUpDownN1.BackColor = white;
                    numericUpDownEGT.BackColor = white;
                    numericUpDownN2.BackColor = white;
                    numericUpDownOilTemp.BackColor = white;
                    numericUpDownOilPress.BackColor = white;
                    numericUpDownOilFlow.BackColor = white;
                    numericUpDownFuelFlow.BackColor = white;
                    numericUpDownFuelBurn.BackColor = white;
                }
            }
        }
        #endregion

        #region private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxEngineSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSelectionBaseComponent = comboBoxEngine.SelectedItem as BaseComponent;

            CheckParametres();
            InvokeComponentChanget();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        private void NumericUpDownTimeInRegimeValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownTimeInRegime.Value > _workParams.TimeInRegimeMax.TotalMinutes && _workParams.TLAMaxEnabled))
                    numericUpDownTimeInRegime.BackColor = Color.Red;
                else numericUpDownTimeInRegime.BackColor = Color.White;
            }
            else numericUpDownTimeInRegime.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownThrottleLeverAngleValueChanged(object sender, EventArgs e)
        private void NumericUpDownThrottleLeverAngleValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownThrottleLeverAngle.Value > _workParams.TLAMax && _workParams.TLAMaxEnabled) ||
                    ((double)numericUpDownThrottleLeverAngle.Value < _workParams.TLAMin && _workParams.TLAMinEnabled))
                    numericUpDownThrottleLeverAngle.BackColor = Color.Red;
                else numericUpDownThrottleLeverAngle.BackColor = Color.White;
            }
            else numericUpDownThrottleLeverAngle.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownErpValueChanged(object sender, EventArgs e)
        private void NumericUpDownErpValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownERP.Value > _workParams.EPRMax && _workParams.EPRMaxEnabled) ||
                    ((double)numericUpDownERP.Value < _workParams.EPRMin && _workParams.EPRMinEnabled))
                    numericUpDownERP.BackColor = Color.Red;
                else numericUpDownERP.BackColor = Color.White;
            }
            else numericUpDownERP.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownN1ValueChanged(object sender, EventArgs e)
        private void NumericUpDownN1ValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownN1.Value > _workParams.N1Max && _workParams.N1MaxEnabled) ||
                    ((double)numericUpDownN1.Value < _workParams.N1Min && _workParams.N1MinEnabled))
                    numericUpDownN1.BackColor = Color.Red;
                else numericUpDownN1.BackColor = Color.White;
            }
            else numericUpDownN1.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownEgtValueChanged(object sender, EventArgs e)
        private void NumericUpDownEgtValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownEGT.Value > _workParams.EGTMax && _workParams.EGTMaxEnabled) ||
                    ((double)numericUpDownEGT.Value < _workParams.EGTMin && _workParams.EGTMinEnabled))
                    numericUpDownEGT.BackColor = Color.Red;
                else numericUpDownEGT.BackColor = Color.White;
            }
            else numericUpDownEGT.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownN2ValueChanged(object sender, EventArgs e)
        private void NumericUpDownN2ValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownN2.Value > _workParams.N2Max && _workParams.N2MaxEnabled) ||
                    ((double)numericUpDownN2.Value < _workParams.N2Min && _workParams.N2MinEnabled))
                    numericUpDownN2.BackColor = Color.Red;
                else numericUpDownN2.BackColor = Color.White;
            }
            else numericUpDownN2.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownOilTempValueChanged(object sender, EventArgs e)
        private void NumericUpDownOilTempValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownOilTemp.Value > _workParams.OilTemperatureMax && _workParams.OilTemperatureMaxEnabled) ||
                    ((double)numericUpDownOilTemp.Value < _workParams.OilTemperatureMin && _workParams.OilTemperatureMinEnabled))
                    numericUpDownOilTemp.BackColor = Color.Red;
                else numericUpDownOilTemp.BackColor = Color.White;
            }
            else numericUpDownOilTemp.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownOilPressValueChanged(object sender, EventArgs e)
        private void NumericUpDownOilPressValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownOilPress.Value > _workParams.OilPressureMax && _workParams.OilPressureMaxEnabled) ||
                    ((double)numericUpDownOilPress.Value < _workParams.OilPressureMin && _workParams.OilPressureMinEnabled))
                    numericUpDownOilPress.BackColor = Color.Red;
                else numericUpDownOilPress.BackColor = Color.White;
            }
            else numericUpDownOilPress.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownOilPressTorqueValueChanged(object sender, EventArgs e)
        private void NumericUpDownOilPressTorqueValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownOilPressTorque.Value > _workParams.OilPressTorqueMax && _workParams.OilPressTorqueMaxEnabled) ||
                    ((double)numericUpDownOilPressTorque.Value < _workParams.OilPressTorqueMin && _workParams.OilPressTorqueMinEnabled))
                    numericUpDownOilPressTorque.BackColor = Color.Red;
                else numericUpDownOilPressTorque.BackColor = Color.White;
            }
            else numericUpDownOilPress.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownOilFlowValueChanged(object sender, EventArgs e)
        private void NumericUpDownOilFlowValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownOilFlow.Value > _workParams.OilFlowMax && _workParams.OilFlowMaxEnabled) ||
                    ((double)numericUpDownOilFlow.Value < _workParams.OilFlowMin && _workParams.OilFlowMinEnabled))
                    numericUpDownOilFlow.BackColor = Color.Red;
                else numericUpDownOilFlow.BackColor = Color.White;
            }
            else numericUpDownOilFlow.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownFuelPressValueChanged(object sender, EventArgs e)
        private void NumericUpDownFuelPressValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownFuelPress.Value > _workParams.FuelPressMax && _workParams.FuelPressMaxEnabled) ||
                    ((double)numericUpDownFuelPress.Value < _workParams.FuelPressMin && _workParams.FuelPressMinEnabled))
                    numericUpDownFuelPress.BackColor = Color.Red;
                else numericUpDownFuelPress.BackColor = Color.White;
            }
            else numericUpDownFuelPress.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownFuelFlowValueChanged(object sender, EventArgs e)
        private void NumericUpDownFuelFlowValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownFuelFlow.Value > _workParams.FuelFlowMax && _workParams.FuelFlowMaxEnabled) ||
                    ((double)numericUpDownFuelFlow.Value < _workParams.FuelFlowMin && _workParams.FuelFlowMinEnabled))
                    numericUpDownFuelFlow.BackColor = Color.Red;
                else numericUpDownFuelFlow.BackColor = Color.White;
            }
            else numericUpDownFuelFlow.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownFuelBurnValueChanged(object sender, EventArgs e)
        private void NumericUpDownFuelBurnValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownFuelBurn.Value > _workParams.FuelBurnMax && _workParams.FuelBurnMaxEnabled) ||
                    ((double)numericUpDownFuelBurn.Value < _workParams.FuelBurnMin && _workParams.FuelBurnMinEnabled))
                    numericUpDownFuelBurn.BackColor = Color.Red;
                else numericUpDownFuelBurn.BackColor = Color.White; 
            }
            else numericUpDownFuelBurn.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownVibrationOverloadValueChanged(object sender, EventArgs e)
        private void NumericUpDownVibrationOverloadValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownVibrationOverload.Value > _workParams.VibroOverloadMax && _workParams.VibroOverloadMaxEnabled) ||
                    ((double)numericUpDownVibrationOverload.Value < _workParams.VibroOverloadMin && _workParams.VibroOverloadMinEnabled))
                    numericUpDownVibrationOverload.BackColor = Color.Red;
                else numericUpDownVibrationOverload.BackColor = Color.White;
            }
            else numericUpDownVibrationOverload.BackColor = Color.White;
        }
        #endregion

        #region private void NumericUpDownVibrationOverload2ValueChanged(object sender, EventArgs e)
        private void NumericUpDownVibrationOverload2ValueChanged(object sender, EventArgs e)
        {
            if (_workParams != null)
            {
                if (((double)numericUpDownVibrationOverload2.Value > _workParams.VibroOverload2Max && _workParams.VibroOverload2MaxEnabled) ||
                    ((double)numericUpDownVibrationOverload2.Value < _workParams.VibroOverload2Min && _workParams.VibroOverload2MinEnabled))
                    numericUpDownVibrationOverload2.BackColor = Color.Red;
                else numericUpDownVibrationOverload2.BackColor = Color.White;
            }
            else numericUpDownVibrationOverload2.BackColor = Color.White;
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// Событие, оповещающее об изменении времени работы Силовой установки
        /// </summary>
        [Category("Power unit data")]
        [Description("Событие, оповещающее об изменении Силовой установки")]
        public event EventHandler ComponentChanget;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении Силовой установки
        ///</summary>
        private void InvokeComponentChanget()
        {
            EventHandler handler = ComponentChanget;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
