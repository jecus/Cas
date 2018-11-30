using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.DetailsControls
{
    ///<summary>
    ///</summary>
    public partial class PowerUnitWorkInRegimeParamsControl : EditObjectControl
    {
        private readonly BaseComponent _currentBaseComponent;
        private readonly string _notApplicableString = "N/A";
        
        #region public EngineCondition Condition

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public ComponentWorkInRegimeParams Condition
        {
            get { return AttachedObject as ComponentWorkInRegimeParams; }
            set {AttachedObject = value;}
        }
        #endregion

        #region public FlightRegime FlightRegime
        /// <summary>
        /// 
        /// </summary>
        public FlightRegime FlightRegime
        {
            get { return comboBoxFlightRegime.SelectedItem as FlightRegime; }
            set { comboBoxFlightRegime.SelectedItem = value; }
        }
        #endregion

        #region public double Persent

        /// <summary>
        /// 
        /// </summary>
        public double Persent
        {
            get { return (double)numericUpDownPersentTime.Value; }
            set { numericUpDownPersentTime.Value = (decimal) value; }
        }
        #endregion

        #region public object ResourceProvider

        /// <summary>
        /// 
        /// </summary>
        public object ResourceProvider
        {
            get
            {
                if (comboBoxResourceProvider.SelectedItem == null || 
                    comboBoxResourceProvider.SelectedItem.ToString() == _notApplicableString)
                    return null;
                return comboBoxResourceProvider.SelectedItem;
            }
            set
            {
                if (value == null || value as BaseEntityObject == null)
                    comboBoxResourceProvider.SelectedItem = _notApplicableString;
                else
                {
                    BaseEntityObject resProvider =
                        comboBoxResourceProvider.Items
                            .OfType<BaseEntityObject>()
                            .Where(o => o.SmartCoreObjectType == ((BaseEntityObject)value).SmartCoreObjectType
                                        && o.ItemId == ((BaseEntityObject)value).ItemId)
                            .FirstOrDefault();

                    if (resProvider != null)
                        comboBoxResourceProvider.SelectedItem = resProvider;
                    else comboBoxResourceProvider.SelectedItem = _notApplicableString;   
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        ///</summary>
        public bool Extended
        {
            get { return tableLayoutPanelMain.Visible; }
            set
            {
                tableLayoutPanelMain.Visible = value;
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PowerUnitWorkInRegimeParamsControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitWorkInRegimeParamsControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public PowerUnitWorkInRegimeParamsControl(BaseDetail baseDetail) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitWorkInRegimeParamsControl(BaseComponent baseComponent)
            : this()
        {
            _currentBaseComponent = baseComponent;
            AttachedObject = new ComponentWorkInRegimeParams
                                 {
                                     ComponentId = _currentBaseComponent.ItemId,
                                     Engine = _currentBaseComponent
                                 };
        }
        #endregion

        #region public PowerUnitWorkInRegimeParamsControl(DetailWorkInRegimeParams @params) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PowerUnitWorkInRegimeParamsControl(ComponentWorkInRegimeParams @params)
            : this()
        {
            _currentBaseComponent = @params.Engine;
            AttachedObject = @params;
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
                Condition.FlightRegime = comboBoxFlightRegime.SelectedItem is FlightRegime
                                             ? (FlightRegime) comboBoxFlightRegime.SelectedItem
                                             : null;
                Condition.GroundAir = comboBoxGroundAir.SelectedItem is GroundAir
                                          ? (GroundAir) comboBoxGroundAir.SelectedItem
                                          : GroundAir.Ground;
                Condition.TimeInRegimeMax = dateTimePickerTime.Value.TimeOfDay;
                Condition.PersentTime = (double) numericUpDownPersentTime.Value;
                Condition.ResorceProvider =
                    comboBoxResourceProvider.SelectedItem is BaseComponent
                        ? SmartCoreType.BaseComponent
                        : comboBoxResourceProvider.SelectedItem is ComponentDirective
                              ? SmartCoreType.ComponentDirective
                              : SmartCoreType.Unknown;
                Condition.ResorceProviderId =
                    comboBoxResourceProvider.SelectedItem is BaseComponent
                        ? ((BaseComponent)comboBoxResourceProvider.SelectedItem).ItemId
                        : comboBoxResourceProvider.SelectedItem is ComponentDirective
                              ? ((ComponentDirective)comboBoxResourceProvider.SelectedItem).ItemId
                              : -1;
                Condition.TLAMax = (double)numericUpDownMaxTLA.Value;
                Condition.TLARecomended = (double)numericUpDownRecTLA.Value;
                Condition.TLAMin = (double)numericUpDownMinTLA.Value;
                Condition.TLAMaxEnabled = checkBoxTLAMaxEnabled.Checked;
                Condition.TLARecomendedEnabled = checkBoxTLARecEnabled.Checked;
                Condition.TLAMinEnabled = checkBoxTLAMinEnabled.Checked;

                Condition.EPRMin = (double)numericUpDownMinEPR.Value;
                Condition.EPRRecomended = (double) numericUpDownRecEPR.Value;
                Condition.EPRMax = (double)numericUpDownMaxERP.Value;
                Condition.EPRMaxEnabled = checkBoxEPRMaxEnabled.Checked;
                Condition.EPRRecomendedEnabled = checkBoxEPRRecEnabled.Checked;
                Condition.EPRMinEnabled = checkBoxEPRMinEnabled.Checked;
                
                Condition.N1Min = (double)numericUpDownMinN1.Value;
                Condition.N1Recomended = (double)numericUpDownRecN1.Value;
                Condition.N1Max = (double)numericUpDownMaxN1.Value;
                Condition.N1MaxEnabled = checkBoxN1MaxEnabled.Checked;
                Condition.N1RecomendedEnabled = checkBoxN1RecEnabled.Checked;
                Condition.N1MinEnabled = checkBoxN1MinEnabled.Checked;

                Condition.EGTMin = (double)numericUpDownMinEGT.Value;
                Condition.EGTRecomended = (double)numericUpDownRecEGT.Value;
                Condition.EGTMax = (double)numericUpDownMaxEGT.Value;
                Condition.EGTMaxEnabled = checkBoxEGTMaxEnabled.Checked;
                Condition.EGTRecomendedEnabled = checkBoxEGTRecEnabled.Checked;
                Condition.EGTMinEnabled = checkBoxEGTMinEnabled.Checked;
                Condition.EGTMeasure = comboBoxMeasureEGT.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureEGT.SelectedItem : Measure.Unknown;

                Condition.N2Min = (double)numericUpDownMinN2.Value;
                Condition.N2Recomended = (double)numericUpDowRecN25.Value;
                Condition.N2Max = (double)numericUpDownMaxN2.Value;
                Condition.N2MaxEnabled = checkBoxN2MaxEnabled.Checked;
                Condition.N2RecomendedEnabled = checkBoxN2RecEnabled.Checked;
                Condition.N2MinEnabled = checkBoxN2MinEnabled.Checked;

                Condition.OilTemperatureMin = (double)numericUpDownMinOilTemp.Value;
                Condition.OilTemperatureRecomended = (double)numericUpDownRecOilTemp.Value;
                Condition.OilTemperatureMax = (double)numericUpDownMaxOilTemp.Value;
                Condition.OilTemperatureMaxEnabled = checkBoxOilTempMaxEnabled.Checked;
                Condition.OilTemperatureRecomendedEnabled = checkBoxOilTempRecEnabled.Checked;
                Condition.OilTemperatureMinEnabled = checkBoxOilTempMinEnabled.Checked;
                Condition.OilTemperatureMeasure = comboBoxMeasureOilTemp.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureOilTemp.SelectedItem : Measure.Unknown;

                Condition.OilPressureMin = (double)numericUpDownMinOilPress.Value;
                Condition.OilPressureRecomended = (double)numericUpDownRecOillPress.Value;
                Condition.OilPressureMax = (double)numericUpDownMaxOilPress.Value;
                Condition.OilPressureMaxEnabled = checkBoxOilPressMaxEnabled.Checked;
                Condition.OilPressureRecomendedEnabled = checkBoxOilPressRecEnabled.Checked;
                Condition.OilPressureMinEnabled = checkBoxOilPressMinEnabled.Checked;
                Condition.OilPressureMeasure = comboBoxMeasureOilPress.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureOilPress.SelectedItem : Measure.Unknown;

                Condition.OilPressTorqueMin = (double)numericUpDownMinOilPressTorque.Value;
                Condition.OilPressTorqueRecomended = (double)numericUpDownRecOilPressTorque.Value;
                Condition.OilPressTorqueMax = (double)numericUpDownMaxOilPressTorque.Value;
                Condition.OilPressTorqueMaxEnabled = checkBoxOilPressTorqMaxEnabled.Checked;
                Condition.OilPressTorqueRecomendedEnabled = checkBoxOilPressTorqueRecEnabled.Checked;
                Condition.OilPressTorqueMinEnabled = checkBoxOilPressTorqMinEnabled.Checked;
                Condition.OilPressTorqueMeasure = comboBoxMeasureOilPressTorque.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureOilPressTorque.SelectedItem : Measure.Unknown;

                Condition.OilFlowMin = (double)numericUpDownMinOilFlow.Value;
                Condition.OilFlowRecomended = (double)numericUpDownRecOilFlow.Value;
                Condition.OilFlowMax = (double)numericUpDownMaxOilFlow.Value;
                Condition.OilFlowMaxEnabled = checkBoxOilFlowMaxEnabled.Checked;
                Condition.OilFlowRecomendedEnabled = checkBoxOilFlowRecEnabled.Checked;
                Condition.OilFlowMinEnabled = checkBoxOilFlowMinEnabled.Checked;
                Condition.OilFlowMeasure = comboBoxMeasureOilFlow.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureOilFlow.SelectedItem : Measure.Unknown;

                Condition.FuelPressMin = (double)numericUpDownMinFuelPress.Value;
                Condition.FuelPressMax = (double)numericUpDownMaxFuelPress.Value;
                Condition.FuelPressMaxEnabled = checkBoxFuelPressMaxEnabled.Checked;
                Condition.FuelPressRecomendedEnabled = checkBoxFuelPressRecEnabled.Checked;
                Condition.FuelPressMinEnabled = checkBoxFuelPressMinEnabled.Checked;
                Condition.FuelPressMeasure = comboBoxMeasureFuelPress.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureFuelPress.SelectedItem : Measure.Unknown;

                Condition.FuelFlowMin = (double)numericUpDownMinFuelFlow.Value;
                Condition.FuelPressRecomended = (double)numericUpDownRecFuelPress.Value;
                Condition.FuelFlowMax = (double)numericUpDownMaxFuelFlow.Value;
                Condition.FuelFlowMaxEnabled = checkBoxFuelFlowMaxEnabled.Checked;
                Condition.FuelFlowRecomendedEnabled = checkBoxFuelFlowRecEnabled.Checked;
                Condition.FuelFlowMinEnabled = checkBoxFuelFlowMinEnabled.Checked;
                Condition.FuelFlowMeasure = comboBoxMeasureFuelFlow.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureFuelFlow.SelectedItem : Measure.Unknown;

                Condition.FuelBurnMin = (double)numericUpDownMinFuelBurn.Value;
                Condition.FuelBurnRecomended = (double)numericUpDownRecFuelBurn.Value;
                Condition.FuelBurnMax = (double)numericUpDownMaxFuelBurn.Value;
                Condition.FuelBurnMaxEnabled = checkBoxFuelBurnMaxEnabled.Checked;
                Condition.FuelBurnRecomendedEnabled = checkBoxFuelBurnRecEnabled.Checked;
                Condition.FuelBurnMinEnabled = checkBoxFuelBurnMinEnabled.Checked;
                Condition.FuelBurnMeasure = comboBoxMeasureFuelBurn.SelectedItem is Measure
                    ? (Measure)comboBoxMeasureFuelBurn.SelectedItem : Measure.Unknown;

                Condition.VibroOverloadMin = (double)numericUpDownMinVibroOverload.Value;
                Condition.VibroOverloadRecomended = (double)numericUpDownRecV1.Value;
                Condition.VibroOverloadMax = (double)numericUpDownMaxVibrationOverload.Value;
                Condition.VibroOverloadMaxEnabled = checkBoxVO1MaxEnabled.Checked;
                Condition.VibroOverloadRecomendedEnabled = checkBoxV1RecEnabled.Checked;
                Condition.VibroOverloadMinEnabled = checkBoxVO1MinEnabled.Checked;

                Condition.VibroOverload2Min = (double)numericUpDownMinVibroOverload2.Value;
                Condition.VibroOverload2Recomended = (double)numericUpDownRecV2.Value;
                Condition.VibroOverload2Max = (double)numericUpDownMaxVibrationOverload2.Value;
                Condition.VibroOverload2MaxEnabled = checkBoxVO2MaxEnabled.Checked;
                Condition.VibroOverload2RecomendedEnabled = checkBoxV2RecEnabled.Checked;
                Condition.VibroOverload2MinEnabled = checkBoxVO2MinEnabled.Checked;

                Condition.Remarks = textBoxRemarks.Text;
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
            if (comboBoxResourceProvider.SelectedItem != null)
            {
                if (comboBoxResourceProvider.SelectedItem is BaseComponent)
                {
                    int? hours =
                        ((BaseComponent)comboBoxResourceProvider.SelectedItem)
                        .LifeLimit.GetSubresource(LifelengthSubResource.Hours);
                    if(hours == null || hours <= 0)
                    {
                        MessageBox.Show("In resource provider not set hours", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxResourceProvider.Focus();
                        return false;
                    }
                }
                if (comboBoxResourceProvider.SelectedItem is ComponentDirective)
                {
                    ComponentDirectiveThreshold ddt =
                        ((ComponentDirective) comboBoxResourceProvider.SelectedItem).Threshold;
                    if (ddt == null)
                    {
                        MessageBox.Show("In resource provider not set threshold", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxResourceProvider.Focus();
                        return false;
                    }
                    
                    if(((ComponentDirective) comboBoxResourceProvider.SelectedItem).LastPerformance == null)
                    {
                        int? hours = ddt.FirstPerformanceSinceNew.GetSubresource(LifelengthSubResource.Hours);
                        if(hours == null || hours <= 0)
                        {
                            MessageBox.Show("In directive not set hours", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBoxResourceProvider.Focus();
                            return false;  
                        }
                        hours = ddt.RepeatInterval.GetSubresource(LifelengthSubResource.Hours);
                        if (!ddt.RepeatInterval.IsNullOrZero() && (hours == null || hours <= 0))
                        {
                            MessageBox.Show("In directive not set repeat hours", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBoxResourceProvider.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        int? hours = ddt.RepeatInterval.GetSubresource(LifelengthSubResource.Hours);
                        if (!ddt.RepeatInterval.IsNullOrZero() && (hours == null || hours <= 0))
                        {
                            MessageBox.Show("In directive not set repeat hours", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBoxResourceProvider.Focus();
                            return false;
                        }   
                    }
                }    
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

            comboBoxFlightRegime.Items.Clear();
            comboBoxFlightRegime.Items.AddRange(FlightRegime.Items.ToArray());

            comboBoxGroundAir.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(GroundAir)))
                comboBoxGroundAir.Items.Add(o);

            comboBoxResourceProvider.Items.Clear();
            comboBoxResourceProvider.Items.Add(_notApplicableString);
            comboBoxResourceProvider.Items.Add(_currentBaseComponent);
            comboBoxResourceProvider.Items.AddRange(_currentBaseComponent.ComponentDirectives.ToArray());

            var temperatures = Measure.GetByCategory(MeasureCategory.Temperature);
            var pressure = Measure.GetByCategory(MeasureCategory.Pressure);
            var massFlow = Measure.GetByCategory(MeasureCategory.MassFlowRate);
            var flow = Measure.GetByCategory(MeasureCategory.FlowRate);

            comboBoxMeasureEGT.Items.Clear();
            comboBoxMeasureEGT.Items.AddRange(temperatures);
            comboBoxMeasureOilTemp.Items.Clear();
            comboBoxMeasureOilTemp.Items.AddRange(temperatures);
            comboBoxMeasureOilPress.Items.Clear();
            comboBoxMeasureOilPress.Items.AddRange(pressure);
            comboBoxMeasureOilPressTorque.Items.Clear();
            comboBoxMeasureOilPressTorque.Items.AddRange(pressure);
            comboBoxMeasureFuelPress.Items.Clear();
            comboBoxMeasureFuelPress.Items.AddRange(pressure);
            comboBoxMeasureOilFlow.Items.Clear();
            comboBoxMeasureOilFlow.Items.AddRange(flow);
            comboBoxMeasureOilFlow.Items.AddRange(massFlow);
            comboBoxMeasureFuelFlow.Items.Clear();
            comboBoxMeasureFuelFlow.Items.AddRange(flow);
            comboBoxMeasureFuelFlow.Items.AddRange(massFlow);
            comboBoxMeasureFuelBurn.Items.Clear();
            comboBoxMeasureFuelBurn.Items.AddRange(flow);
            comboBoxMeasureFuelBurn.Items.AddRange(massFlow);

            comboBoxFlightRegime.SelectedItem = Condition.FlightRegime;
            comboBoxGroundAir.SelectedItem = Condition.GroundAir;

            BaseEntityObject resProvider =
                comboBoxResourceProvider.Items
                    .OfType<BaseEntityObject>()
                    .Where(o => o.SmartCoreObjectType == Condition.ResorceProvider
                                && o.ItemId == Condition.ResorceProviderId)
                    .FirstOrDefault();
            
            if(resProvider != null)
                comboBoxResourceProvider.SelectedItem = resProvider;
            else comboBoxResourceProvider.SelectedItem = _notApplicableString;

            dateTimePickerTime.Value = DateTime.Today.Add(Condition.TimeInRegimeMax);
            numericUpDownPersentTime.Value = (decimal) Condition.PersentTime;

            numericUpDownMaxTLA.Value = (decimal) Condition.TLAMax;
            numericUpDownRecTLA.Value = (decimal) Condition.TLARecomended;
            numericUpDownMinTLA.Value = (decimal) Condition.TLAMin;
            checkBoxTLAMaxEnabled.Checked = Condition.TLAMaxEnabled;
            checkBoxTLARecEnabled.Checked = Condition.TLARecomendedEnabled;
            checkBoxTLAMinEnabled.Checked = Condition.TLAMinEnabled;

            numericUpDownMaxERP.Value = (decimal)Condition.EPRMax;
            numericUpDownRecEPR.Value = (decimal)Condition.EPRRecomended;
            numericUpDownMinEPR.Value = (decimal)Condition.EPRMin;
            checkBoxEPRMinEnabled.Checked = Condition.EPRMinEnabled;
            checkBoxEPRRecEnabled.Checked = Condition.EPRRecomendedEnabled;
            checkBoxEPRMaxEnabled.Checked = Condition.EPRMaxEnabled;

            numericUpDownMaxN1.Value = (decimal)Condition.N1Max;
            numericUpDownRecN1.Value = (decimal)Condition.N1Recomended;
            numericUpDownMinN1.Value = (decimal)Condition.N1Min;
            checkBoxN1MaxEnabled.Checked = Condition.N1MaxEnabled;
            checkBoxN1RecEnabled.Checked = Condition.N1RecomendedEnabled;
            checkBoxN1MinEnabled.Checked = Condition.N1MinEnabled;

            numericUpDownMaxEGT.Value = (decimal)Condition.EGTMax;
            numericUpDownRecEGT.Value = (decimal)Condition.EGTRecomended;
            numericUpDownMinEGT.Value = (decimal)Condition.EGTMin;
            checkBoxEGTMaxEnabled.Checked = Condition.EGTMaxEnabled;
            checkBoxEGTRecEnabled.Checked = Condition.EGTRecomendedEnabled;
            checkBoxEGTMinEnabled.Checked = Condition.EGTMinEnabled;
            comboBoxMeasureEGT.SelectedItem = Condition.EGTMeasure;

            numericUpDownMaxN2.Value = (decimal)Condition.N2Max;
            numericUpDowRecN25.Value = (decimal)Condition.N2Recomended;
            numericUpDownMinN2.Value = (decimal)Condition.N2Min;
            checkBoxN2MaxEnabled.Checked = Condition.N2MaxEnabled;
            checkBoxN2RecEnabled.Checked = Condition.N2RecomendedEnabled;
            checkBoxN2MinEnabled.Checked = Condition.N2MinEnabled;

            numericUpDownMaxOilTemp.Value = (decimal)Condition.OilTemperatureMax;
            numericUpDownRecOilTemp.Value = (decimal)Condition.OilTemperatureRecomended;
            numericUpDownMinOilTemp.Value = (decimal)Condition.OilTemperatureMin;
            checkBoxOilTempMaxEnabled.Checked = Condition.OilTemperatureMaxEnabled;
            checkBoxOilTempRecEnabled.Checked = Condition.OilTemperatureRecomendedEnabled;
            checkBoxOilTempMinEnabled.Checked = Condition.OilTemperatureMinEnabled;
            comboBoxMeasureOilTemp.SelectedItem = Condition.OilTemperatureMeasure;

            numericUpDownMaxOilPress.Value = (decimal)Condition.OilPressureMax;
            numericUpDownRecOillPress.Value = (decimal)Condition.OilPressureRecomended;
            numericUpDownMinOilPress.Value = (decimal)Condition.OilPressureMin;
            checkBoxOilPressMaxEnabled.Checked = Condition.OilPressureMaxEnabled;
            checkBoxOilPressRecEnabled.Checked = Condition.OilPressureRecomendedEnabled;
            checkBoxOilPressMinEnabled.Checked = Condition.OilPressureMinEnabled;
            comboBoxMeasureOilPress.SelectedItem = Condition.OilPressureMeasure;

            numericUpDownMaxOilFlow.Value = (decimal)Condition.OilFlowMax;
            numericUpDownRecOilFlow.Value = (decimal)Condition.OilFlowRecomended;
            numericUpDownMinOilFlow.Value = (decimal)Condition.OilFlowMin;
            checkBoxOilFlowMaxEnabled.Checked = Condition.OilFlowMaxEnabled;
            checkBoxOilFlowRecEnabled.Checked = Condition.OilFlowRecomendedEnabled;
            checkBoxOilFlowMinEnabled.Checked = Condition.OilFlowMinEnabled;
            comboBoxMeasureOilFlow.SelectedItem = Condition.OilFlowMeasure;

            numericUpDownMaxFuelFlow.Value = (decimal)Condition.FuelFlowMax;
            numericUpDownRecFuelFlow.Value = (decimal)Condition.FuelFlowRecomended;
            numericUpDownMinFuelFlow.Value = (decimal)Condition.FuelFlowMin;
            checkBoxFuelFlowMaxEnabled.Checked = Condition.FuelFlowMaxEnabled;
            checkBoxFuelFlowRecEnabled.Checked = Condition.FuelFlowRecomendedEnabled;
            checkBoxFuelFlowMinEnabled.Checked = Condition.FuelFlowMinEnabled;
            comboBoxMeasureFuelFlow.SelectedItem = Condition.FuelFlowMeasure;

            numericUpDownMaxFuelBurn.Value = (decimal)Condition.FuelBurnMax;
            numericUpDownRecFuelBurn.Value = (decimal)Condition.FuelBurnRecomended;
            numericUpDownMinFuelBurn.Value = (decimal)Condition.FuelBurnMin;
            checkBoxFuelBurnMaxEnabled.Checked = Condition.FuelBurnMaxEnabled;
            checkBoxFuelBurnRecEnabled.Checked = Condition.FuelBurnRecomendedEnabled;
            checkBoxFuelBurnMinEnabled.Checked = Condition.FuelBurnMinEnabled;
            comboBoxMeasureFuelBurn.SelectedItem = Condition.FuelBurnMeasure;

            numericUpDownMaxFuelPress.Value = (decimal)Condition.FuelPressMax;
            numericUpDownRecFuelPress.Value = (decimal)Condition.FuelPressRecomended;
            numericUpDownMinFuelPress.Value = (decimal)Condition.FuelPressMin;
            checkBoxFuelPressMaxEnabled.Checked = Condition.FuelPressMaxEnabled;
            checkBoxFuelPressRecEnabled.Checked = Condition.FuelPressRecomendedEnabled;
            checkBoxFuelPressMinEnabled.Checked = Condition.FuelPressMinEnabled;
            comboBoxMeasureFuelPress.SelectedItem = Condition.FuelPressMeasure;

            numericUpDownMaxOilPressTorque.Value = (decimal)Condition.OilPressTorqueMax;
            numericUpDownRecOilPressTorque.Value = (decimal)Condition.OilPressTorqueRecomended;
            numericUpDownMinOilPressTorque.Value = (decimal)Condition.OilPressTorqueMin;
            checkBoxOilPressTorqMaxEnabled.Checked = Condition.OilPressTorqueMaxEnabled;
            checkBoxOilPressTorqueRecEnabled.Checked = Condition.OilPressTorqueRecomendedEnabled;
            checkBoxOilPressTorqMinEnabled.Checked = Condition.OilPressTorqueMinEnabled;
            comboBoxMeasureOilPressTorque.SelectedItem = Condition.OilPressTorqueMeasure;

            numericUpDownMaxVibrationOverload.Value = (decimal)Condition.VibroOverloadMax;
            numericUpDownRecV1.Value = (decimal)Condition.VibroOverloadRecomended;
            numericUpDownMinVibroOverload.Value = (decimal)Condition.VibroOverloadMin;
            checkBoxVO1MaxEnabled.Checked = Condition.VibroOverloadMaxEnabled;
            checkBoxV1RecEnabled.Checked = Condition.VibroOverloadRecomendedEnabled;
            checkBoxVO1MinEnabled.Checked = Condition.VibroOverloadMinEnabled;

            numericUpDownMaxVibrationOverload2.Value = (decimal)Condition.VibroOverload2Max;
            numericUpDownRecV2.Value = (decimal)Condition.VibroOverload2Recomended;
            numericUpDownMinVibroOverload2.Value = (decimal)Condition.VibroOverload2Min;
            checkBoxVO2MaxEnabled.Checked = Condition.VibroOverload2MaxEnabled;
            checkBoxV2RecEnabled.Checked = Condition.VibroOverload2RecomendedEnabled;
            checkBoxVO2MinEnabled.Checked = Condition.VibroOverload2MinEnabled;

            textBoxRemarks.Text = Condition.Remarks;

            SetExtendableControlCaption();
            
            EndUpdate();
        }
        #endregion

        #region public override bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public override bool GetChangeStatus()
        {
            try
            {
                if (Condition != null)
                {
                    if ((comboBoxResourceProvider.SelectedItem == null || comboBoxResourceProvider.SelectedItem.ToString() == _notApplicableString) && 
                        (Condition.ResorceProvider != SmartCoreType.Unknown || Condition.ResorceProviderId > 0))
                    {
                        return true;
                    }
                    if (comboBoxResourceProvider.SelectedItem != null && comboBoxResourceProvider.SelectedItem is BaseEntityObject
                        && (Condition.ResorceProvider != ((BaseEntityObject)comboBoxResourceProvider.SelectedItem).SmartCoreObjectType
                         || Condition.ResorceProviderId != ((BaseEntityObject)comboBoxResourceProvider.SelectedItem).ItemId))
                    {
                        return true;
                    }

                    if( Condition.FlightRegime != comboBoxFlightRegime.SelectedItem
                        || Condition.GroundAir != (GroundAir)comboBoxGroundAir.SelectedItem
                        || Condition.PersentTime != (double)numericUpDownPersentTime.Value
                        || Condition.TimeInRegimeMax != dateTimePickerTime.Value.TimeOfDay
                        || Condition.TLAMax != (double)numericUpDownMaxTLA.Value
                        || Condition.TLARecomended != (double)numericUpDownRecTLA.Value
                        || Condition.TLAMin != (double)numericUpDownMinTLA.Value
                        || Condition.TLAMaxEnabled != checkBoxTLAMaxEnabled.Checked
                        || Condition.TLARecomendedEnabled != checkBoxTLARecEnabled.Checked
                        || Condition.TLAMinEnabled != checkBoxTLAMinEnabled.Checked
                        || Condition.EPRMin != (double)numericUpDownMaxERP.Value
                        || Condition.EPRRecomended != (double)numericUpDownRecEPR.Value
                        || Condition.EPRMax != (double)numericUpDownMinEPR.Value
                        || Condition.EPRMaxEnabled != checkBoxEPRMaxEnabled.Checked
                        || Condition.EPRRecomendedEnabled != checkBoxEPRRecEnabled.Checked
                        || Condition.EPRMinEnabled != checkBoxEPRMinEnabled.Checked
                        || Condition.N1Min != (double)numericUpDownMinN1.Value
                        || Condition.N1Recomended != (double)numericUpDownRecN1.Value
                        || Condition.N1Max != (double)numericUpDownMaxN1.Value
                        || Condition.N1MaxEnabled != checkBoxN1MaxEnabled.Checked
                        || Condition.N1RecomendedEnabled != checkBoxN1RecEnabled.Checked
                        || Condition.N1MinEnabled != checkBoxN2MinEnabled.Checked 
                        || Condition.EGTMin != (double)numericUpDownMinEGT.Value
                        || Condition.EGTRecomended != (double)numericUpDownRecEGT.Value
                        || Condition.EGTMax != (double)numericUpDownMaxEGT.Value
                        || Condition.EGTMaxEnabled != checkBoxEGTMaxEnabled.Checked
                        || Condition.EGTRecomendedEnabled != checkBoxEGTRecEnabled.Checked
                        || Condition.EGTMinEnabled != checkBoxEGTMinEnabled.Checked
                        || Condition.EGTMeasure != comboBoxMeasureEGT.SelectedItem
                        || Condition.N2Min != (double)numericUpDownMinN2.Value
                        || Condition.N2Recomended != (double)numericUpDowRecN25.Value
                        || Condition.N2Max != (double)numericUpDownMaxN2.Value
                        || Condition.N2MaxEnabled != checkBoxN2MaxEnabled.Checked
                        || Condition.N2RecomendedEnabled != checkBoxN2RecEnabled.Checked
                        || Condition.N2MinEnabled != checkBoxN2MinEnabled.Checked    
                        || Condition.OilTemperatureMin != (double)numericUpDownMinOilTemp.Value
                        || Condition.OilTemperatureRecomended != (double)numericUpDownRecOilTemp.Value
                        || Condition.OilTemperatureMax != (double)numericUpDownMaxOilTemp.Value
                        || Condition.OilTemperatureMaxEnabled != checkBoxOilTempMaxEnabled.Checked
                        || Condition.OilTemperatureRecomendedEnabled != checkBoxOilTempRecEnabled.Checked
                        || Condition.OilTemperatureMinEnabled != checkBoxOilTempMinEnabled.Checked
                        || Condition.OilTemperatureMeasure != comboBoxMeasureOilTemp.SelectedItem 
                        || Condition.OilPressureMin != (double)numericUpDownMinOilPress.Value
                        || Condition.OilPressureRecomended != (double)numericUpDownRecOillPress.Value
                        || Condition.OilPressureMax != (double)numericUpDownMaxOilPress.Value
                        || Condition.OilPressureMaxEnabled != checkBoxOilPressMaxEnabled.Checked
                        || Condition.OilPressureRecomendedEnabled != checkBoxOilPressRecEnabled.Checked
                        || Condition.OilPressureMinEnabled != checkBoxOilPressMinEnabled.Checked
                        || Condition.OilPressureMeasure != comboBoxMeasureOilPress.SelectedItem
                        || Condition.OilPressTorqueMin != (double)numericUpDownMinOilPressTorque.Value
                        || Condition.OilPressTorqueRecomended != (double)numericUpDownRecOilPressTorque.Value
                        || Condition.OilPressTorqueMax != (double)numericUpDownMaxOilPressTorque.Value
                        || Condition.OilPressTorqueMaxEnabled != checkBoxOilPressTorqMaxEnabled.Checked
                        || Condition.OilPressTorqueRecomendedEnabled != checkBoxOilPressTorqueRecEnabled.Checked
                        || Condition.OilPressTorqueMinEnabled != checkBoxOilPressTorqMinEnabled.Checked
                        || Condition.OilPressTorqueMeasure != comboBoxMeasureOilPressTorque.SelectedItem
                        || Condition.OilFlowMin != (double)numericUpDownMinOilFlow.Value
                        || Condition.OilFlowRecomended != (double)numericUpDownRecOilFlow.Value
                        || Condition.OilFlowMax != (double)numericUpDownMaxOilFlow.Value
                        || Condition.OilFlowMaxEnabled != checkBoxOilFlowMaxEnabled.Checked
                        || Condition.OilFlowRecomendedEnabled != checkBoxOilFlowRecEnabled.Checked
                        || Condition.OilFlowMinEnabled != checkBoxOilFlowMinEnabled.Checked
                        || Condition.OilFlowMeasure != comboBoxMeasureOilFlow.SelectedItem
                        || Condition.FuelPressMin != (double)numericUpDownMinFuelPress.Value
                        || Condition.FuelPressRecomended != (double)numericUpDownRecFuelPress.Value
                        || Condition.FuelPressMax != (double)numericUpDownMaxFuelPress.Value
                        || Condition.FuelPressMaxEnabled != checkBoxFuelPressMaxEnabled.Checked
                        || Condition.FuelPressRecomendedEnabled != checkBoxFuelPressRecEnabled.Checked
                        || Condition.FuelPressMinEnabled != checkBoxFuelPressMinEnabled.Checked
                        || Condition.FuelPressMeasure != comboBoxMeasureFuelPress.SelectedItem
                        || Condition.FuelFlowMin != (double)numericUpDownMinFuelFlow.Value
                        || Condition.FuelFlowRecomended != (double)numericUpDownRecFuelFlow.Value
                        || Condition.FuelFlowMax != (double)numericUpDownMaxFuelFlow.Value
                        || Condition.FuelFlowMaxEnabled != checkBoxFuelFlowMaxEnabled.Checked
                        || Condition.FuelFlowRecomendedEnabled != checkBoxFuelFlowRecEnabled.Checked
                        || Condition.FuelFlowMinEnabled != checkBoxFuelFlowMinEnabled.Checked
                        || Condition.FuelFlowMeasure != comboBoxMeasureFuelFlow.SelectedItem
                        || Condition.FuelBurnMin != (double)numericUpDownMinFuelBurn.Value
                        || Condition.FuelBurnRecomended != (double)numericUpDownRecFuelBurn.Value
                        || Condition.FuelBurnMax != (double)numericUpDownMaxFuelBurn.Value
                        || Condition.FuelBurnMaxEnabled != checkBoxFuelBurnMaxEnabled.Checked
                        || Condition.FuelBurnRecomendedEnabled != checkBoxFuelBurnRecEnabled.Checked
                        || Condition.FuelBurnMinEnabled != checkBoxFuelBurnMinEnabled.Checked
                        || Condition.FuelBurnMeasure != comboBoxMeasureFuelBurn.SelectedItem
                        || Condition.VibroOverloadMin != (double)numericUpDownMinVibroOverload.Value
                        || Condition.VibroOverloadRecomended != (double)numericUpDownRecV1.Value
                        || Condition.VibroOverloadMax != (double)numericUpDownMaxVibrationOverload.Value
                        || Condition.VibroOverloadMaxEnabled != checkBoxVO1MaxEnabled.Checked
                        || Condition.VibroOverloadRecomendedEnabled != checkBoxV1RecEnabled.Checked
                        || Condition.VibroOverloadMinEnabled != checkBoxVO2MinEnabled.Checked
                        || Condition.VibroOverload2Min != (double)numericUpDownMinVibroOverload2.Value
                        || Condition.VibroOverload2Recomended != (double)numericUpDownRecV2.Value
                        || Condition.VibroOverload2Max != (double)numericUpDownMaxVibrationOverload2.Value
                        || Condition.VibroOverload2MaxEnabled != checkBoxVO2MaxEnabled.Checked
                        || Condition.VibroOverload2RecomendedEnabled != checkBoxV2RecEnabled.Checked
                        || Condition.VibroOverload2MinEnabled != checkBoxVO2MinEnabled.Checked
                        || Condition.Remarks != textBoxRemarks.Text)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
            return false;
        }

        #endregion

        #region private void SetExtendableControlCaption()
        private void SetExtendableControlCaption()
        {
            extendableRichContainer1.labelCaption.Text = "";

            if (comboBoxFlightRegime.SelectedItem as FlightRegime != null)
                extendableRichContainer1.labelCaption.Text = comboBoxFlightRegime.SelectedItem.ToString();
            if (extendableRichContainer1.labelCaption.Text != "")
                extendableRichContainer1.labelCaption.Text += " ";
            if (comboBoxGroundAir.SelectedItem is GroundAir)
                extendableRichContainer1.labelCaption.Text += comboBoxGroundAir.SelectedItem.ToString();
  
        }
        #endregion

        #region public bool ShowHeaders

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelFlightRegime.Visible; }
            set
            {
                //labelFlightRegime.Visible = value;
                //labelMaxTimeInRegime.Visible = value;
                //labelVibrationOverload1.Visible = value;
                //labelVibrationOverload2.Visible = value;
                //labelOilPressTorque.Visible = value;
                //labelFuelPress.Visible = value;
                //labelERP.Visible = value;
                //labelEGT.Visible = value;
                //labelFuelBurn.Visible = value;
                //labelFuelFlow.Visible = value;
                //labelN1.Visible = value;
                //labelN2.Visible = value;
                //labelOilPress.Visible = value;
                //labelOilTemp.Visible = value;
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

        #region private void CheckBoxVo2MaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxVo2MaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxVibrationOverload2.Enabled = checkBoxVO2MaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxV2RecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxV2RecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecV2.Enabled = checkBoxV2RecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxVo2MinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxVo2MinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinVibroOverload2.Enabled = checkBoxVO2MinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxVo1MaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxVo1MaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxVibrationOverload.Enabled = checkBoxVO1MaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxV1RecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxV1RecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecV1.Enabled = checkBoxV1RecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxVo1MinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxVo1MinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinVibroOverload.Enabled = checkBoxVO1MinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelBurnMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelBurnMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxFuelBurn.Enabled = checkBoxFuelBurnMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelBurnRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelBurnRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecFuelBurn.Enabled = checkBoxFuelBurnRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelBurnMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelBurnMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinFuelBurn.Enabled = checkBoxFuelBurnMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelPressMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelPressMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxFuelPress.Enabled = checkBoxFuelPressMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelPressRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelPressRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecFuelPress.Enabled = checkBoxFuelPressRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelPressMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelPressMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinFuelPress.Enabled = checkBoxFuelPressMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelFlowMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelFlowMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxFuelFlow.Enabled = checkBoxFuelFlowMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelFlowRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelFlowRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecFuelFlow.Enabled = checkBoxFuelFlowRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxFuelFlowMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxFuelFlowMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinFuelFlow.Enabled = checkBoxFuelFlowMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressTorqMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilPressTorqMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxOilPressTorque.Enabled = checkBoxOilPressTorqMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressTorqueRecEnabledCheckedChanged(object sender, EventArgs e)
        
        private void CheckBoxOilPressTorqueRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecOilPressTorque.Enabled = checkBoxOilPressTorqueRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressTorqMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilPressTorqMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinOilPressTorque.Enabled = checkBoxOilPressTorqMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilPressMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxOilPress.Enabled = checkBoxOilPressMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilPressRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecOillPress.Enabled = checkBoxOilPressRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilPressMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilPressMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinOilPress.Enabled = checkBoxOilPressMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilTempMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilTempMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxOilTemp.Enabled = checkBoxOilTempMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilTempRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilTempRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecOilTemp.Enabled = checkBoxOilTempRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilTempMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilTempMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinOilTemp.Enabled = checkBoxOilTempMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxN2MaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN2MaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxN2.Enabled = checkBoxN2MaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxN2RecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN2RecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDowRecN25.Enabled = checkBoxN2RecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxN2MainEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN2MainEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinN2.Enabled = checkBoxN2MinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEGTMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEGTMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxEGT.Enabled = checkBoxEGTMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEGTRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEGTRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecEGT.Enabled = checkBoxEGTRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEGTMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEGTMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinEGT.Enabled = checkBoxEGTMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxN1MaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN1MaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxN1.Enabled = checkBoxN1MaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxN1RecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN1RecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecN1.Enabled = checkBoxN1RecEnabled.Checked;
        }
        #endregion

        #region  private void CheckBoxN1MinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxN1MinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinN1.Enabled = checkBoxN1MinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEPRMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEPRMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxERP.Enabled = checkBoxEPRMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEPRRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEPRRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecEPR.Enabled = checkBoxEPRRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxEPRMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxEPRMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinEPR.Enabled = checkBoxEPRMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxTLAMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxTLAMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxTLA.Enabled = checkBoxTLAMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxTLARecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxTLARecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecTLA.Enabled = checkBoxTLARecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxTLAMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxTLAMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinTLA.Enabled = checkBoxTLAMinEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilFlowMaxEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilFlowMaxEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxOilFlow.Enabled = checkBoxOilFlowMaxEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilFlowRecEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilFlowRecEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRecOilFlow.Enabled = checkBoxOilFlowRecEnabled.Checked;
        }
        #endregion

        #region private void CheckBoxOilFlowMinEnabledCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOilFlowMinEnabledCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMinOilFlow.Enabled = checkBoxOilFlowMinEnabled.Checked;
        }
        #endregion

        #region private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        {
            SetExtendableControlCaption();
            InvokeWorkTimeChanget();
        }
        #endregion

        #region private void NumericUpDownPersentTimeValueChanged(object sender, EventArgs e)
        private void NumericUpDownPersentTimeValueChanged(object sender, EventArgs e)
        {
            InvokeWorkTimeChanget();
        }
        #endregion

        #region private void ComboBoxResourceProviderSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxResourceProviderSelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeWorkTimeChanget();
        }
        #endregion

        #region private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        {
            tableLayoutPanelMain.Visible = !tableLayoutPanelMain.Visible;
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// Событие, оповещающее об изменении режима работы Силовой установки
        /// </summary>
        [Category("Power unit work data")]
        [Description("Событие, оповещающее об изменении режима работы Силовой установки")]
        public event EventHandler RegimeChanged;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении режима работы Силовой установки
        ///</summary>
        private void InvokeWorkTimeChanget()
        {
            EventHandler handler = RegimeChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion

    }
}
