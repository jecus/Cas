using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class EngineFailureDataControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineFailureDataControl));
            this.labelEngineName = new System.Windows.Forms.Label();
            this.textBoxEngineName = new System.Windows.Forms.TextBox();
            this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelTotalTimeAboveGageRedLine = new System.Windows.Forms.Label();
            this.numericUpDownTimeToRedLine = new System.Windows.Forms.NumericUpDown();
            this.labelMeasure1 = new System.Windows.Forms.Label();
            this.labelPeakEGTAttained = new System.Windows.Forms.Label();
            this.numericUpDownPeakEGTAttained = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTotalTimeAtPeakEGT = new System.Windows.Forms.NumericUpDown();
            this.labelTotalTimeAtPeakEGT = new System.Windows.Forms.Label();
            this.labelMeasure2 = new System.Windows.Forms.Label();
            this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.label1FuelFlow = new System.Windows.Forms.Label();
            this.labelOilPress = new System.Windows.Forms.Label();
            this.labelOilTemp = new System.Windows.Forms.Label();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelEGT = new System.Windows.Forms.Label();
            this.labelN1 = new System.Windows.Forms.Label();
            this.numericUpDownN1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownN2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOilPress = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEGT = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOilTemp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFuelFlow = new System.Windows.Forms.NumericUpDown();
            this.labelStall = new System.Windows.Forms.Label();
            this.radioButtonAudible = new System.Windows.Forms.RadioButton();
            this.radioButtonSilent = new System.Windows.Forms.RadioButton();
            this.labelOverTempData = new System.Windows.Forms.Label();
            this.labelPriorToFaulire = new System.Windows.Forms.Label();
            this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelFlightConditions = new System.Windows.Forms.Label();
            this.labelIAS = new System.Windows.Forms.Label();
            this.labelALT = new System.Windows.Forms.Label();
            this.numericUpDownIAS = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownALT = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMACH = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTAT = new System.Windows.Forms.NumericUpDown();
            this.labelMACH = new System.Windows.Forms.Label();
            this.labelTAT = new System.Windows.Forms.Label();
            this.numericUpDownOAT = new System.Windows.Forms.NumericUpDown();
            this.labelOAT = new System.Windows.Forms.Label();
            this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelFlightRegime = new System.Windows.Forms.Label();
            this.comboBoxFlightRegime = new System.Windows.Forms.ComboBox();
            this.labelTimeInRegime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTimeInRegime = new System.Windows.Forms.NumericUpDown();
            this.labelWeather = new System.Windows.Forms.Label();
            this.checkBoxTurb = new System.Windows.Forms.CheckBox();
            this.checkBoxClear = new System.Windows.Forms.CheckBox();
            this.checkBoxClouds = new System.Windows.Forms.CheckBox();
            this.checkBoxRainShow = new System.Windows.Forms.CheckBox();
            this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelFuelConditions = new System.Windows.Forms.Label();
            this.labelFuelTempTank = new System.Windows.Forms.Label();
            this.labelFuelTempEngine = new System.Windows.Forms.Label();
            this.labelFuelHeat = new System.Windows.Forms.Label();
            this.labelFuelDump = new System.Windows.Forms.Label();
            this.numericUpDownFuelTempEngine = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFuelTempTank = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFuelHeat = new System.Windows.Forms.CheckBox();
            this.checkBoxFuelDump = new System.Windows.Forms.CheckBox();
            this.delimiter6 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.checkBoxCenterToEngines = new System.Windows.Forms.CheckBox();
            this.checkBoxTankToEngine = new System.Windows.Forms.CheckBox();
            this.checkBoxInboardToEngines = new System.Windows.Forms.CheckBox();
            this.labelAmountFuelDumped = new System.Windows.Forms.Label();
            this.textBoxCenterToEngines = new System.Windows.Forms.TextBox();
            this.labelTo1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelMeasure3 = new System.Windows.Forms.Label();
            this.delimiter7 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelIndicationTime = new System.Windows.Forms.Label();
            this.textGMT = new System.Windows.Forms.TextBox();
            this.labelOtherConditions = new System.Windows.Forms.Label();
            this.panelPowerLoss = new System.Windows.Forms.Panel();
            this.radioButtonGradual = new System.Windows.Forms.RadioButton();
            this.radioButtonSudden = new System.Windows.Forms.RadioButton();
            this.labelPowerLoss = new System.Windows.Forms.Label();
            this.panelThrustLevers = new System.Windows.Forms.Panel();
            this.radioButtonNoMoved = new System.Windows.Forms.RadioButton();
            this.radioButtonDecelerating = new System.Windows.Forms.RadioButton();
            this.labelThrustLevers = new System.Windows.Forms.Label();
            this.radioButtonAccelerating = new System.Windows.Forms.RadioButton();
            this.panelEngineAntiIce = new System.Windows.Forms.Panel();
            this.radioButtonActivated = new System.Windows.Forms.RadioButton();
            this.labelEngimeAntiIce = new System.Windows.Forms.Label();
            this.radioButtonOff = new System.Windows.Forms.RadioButton();
            this.radioButtonOn = new System.Windows.Forms.RadioButton();
            this.panelRelight = new System.Windows.Forms.Panel();
            this.numericUpDownRelightALT = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelEngineRelight = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSuccesful = new System.Windows.Forms.RadioButton();
            this.delimiter8 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelIncindentRemarks = new System.Windows.Forms.Label();
            this.textMach = new System.Windows.Forms.TextBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.delimiter9 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelWindmillingInformation = new System.Windows.Forms.Label();
            this.numericUpDownWMIAS = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWMALT = new System.Windows.Forms.NumericUpDown();
            this.labelWMIAS = new System.Windows.Forms.Label();
            this.labelWMALT = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWMN2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWMN1 = new System.Windows.Forms.NumericUpDown();
            this.labelWMOilPress = new System.Windows.Forms.Label();
            this.labelWMN2 = new System.Windows.Forms.Label();
            this.labelWMN1 = new System.Windows.Forms.Label();
            this.delimiter10 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter11 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFireSwitch = new System.Windows.Forms.CheckBox();
            this.labelTimeWindMilling = new System.Windows.Forms.Label();
            this.numericUpDownTotalTimeWindMilling = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeToRedLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeakEGTAttained)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTimeAtPeakEGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOilPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOilTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownALT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeInRegime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelTempEngine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelTempTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelPowerLoss.SuspendLayout();
            this.panelThrustLevers.SuspendLayout();
            this.panelEngineAntiIce.SuspendLayout();
            this.panelRelight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelightALT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMIAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMALT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMN2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTimeWindMilling)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEngineName
            // 
            this.labelEngineName.AutoSize = true;
            this.labelEngineName.Location = new System.Drawing.Point(3, 9);
            this.labelEngineName.Name = "labelEngineName";
            this.labelEngineName.Size = new System.Drawing.Size(43, 13);
            this.labelEngineName.TabIndex = 70;
            this.labelEngineName.Text = "Engine:";
            // 
            // textBoxEngineName
            // 
            this.textBoxEngineName.Location = new System.Drawing.Point(52, 6);
            this.textBoxEngineName.Name = "textBoxEngineName";
            this.textBoxEngineName.ReadOnly = true;
            this.textBoxEngineName.Size = new System.Drawing.Size(150, 20);
            this.textBoxEngineName.TabIndex = 85;
            this.textBoxEngineName.TabStop = false;
            // 
            // delimiter1
            // 
            this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
            this.delimiter1.Location = new System.Drawing.Point(6, 35);
            this.delimiter1.Name = "delimiter1";
            this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter1.Size = new System.Drawing.Size(750, 1);
            this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter1.TabIndex = 86;
            // 
            // labelTotalTimeAboveGageRedLine
            // 
            this.labelTotalTimeAboveGageRedLine.AutoSize = true;
            this.labelTotalTimeAboveGageRedLine.Location = new System.Drawing.Point(3, 68);
            this.labelTotalTimeAboveGageRedLine.Name = "labelTotalTimeAboveGageRedLine";
            this.labelTotalTimeAboveGageRedLine.Size = new System.Drawing.Size(162, 13);
            this.labelTotalTimeAboveGageRedLine.TabIndex = 87;
            this.labelTotalTimeAboveGageRedLine.Text = "Total Time Above Gage Redline:";
            // 
            // numericUpDownTimeToRedLine
            // 
            this.numericUpDownTimeToRedLine.Location = new System.Drawing.Point(171, 66);
            this.numericUpDownTimeToRedLine.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownTimeToRedLine.Name = "numericUpDownTimeToRedLine";
            this.numericUpDownTimeToRedLine.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownTimeToRedLine.TabIndex = 88;
            this.numericUpDownTimeToRedLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMeasure1
            // 
            this.labelMeasure1.AutoSize = true;
            this.labelMeasure1.Location = new System.Drawing.Point(251, 68);
            this.labelMeasure1.Name = "labelMeasure1";
            this.labelMeasure1.Size = new System.Drawing.Size(26, 13);
            this.labelMeasure1.TabIndex = 89;
            this.labelMeasure1.Text = "min.";
            // 
            // labelPeakEGTAttained
            // 
            this.labelPeakEGTAttained.AutoSize = true;
            this.labelPeakEGTAttained.Location = new System.Drawing.Point(3, 91);
            this.labelPeakEGTAttained.Name = "labelPeakEGTAttained";
            this.labelPeakEGTAttained.Size = new System.Drawing.Size(102, 13);
            this.labelPeakEGTAttained.TabIndex = 90;
            this.labelPeakEGTAttained.Text = "Peak EGT Attained:";
            // 
            // numericUpDownPeakEGTAttained
            // 
            this.numericUpDownPeakEGTAttained.Location = new System.Drawing.Point(171, 89);
            this.numericUpDownPeakEGTAttained.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPeakEGTAttained.Name = "numericUpDownPeakEGTAttained";
            this.numericUpDownPeakEGTAttained.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownPeakEGTAttained.TabIndex = 91;
            this.numericUpDownPeakEGTAttained.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownTotalTimeAtPeakEGT
            // 
            this.numericUpDownTotalTimeAtPeakEGT.Location = new System.Drawing.Point(171, 112);
            this.numericUpDownTotalTimeAtPeakEGT.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownTotalTimeAtPeakEGT.Name = "numericUpDownTotalTimeAtPeakEGT";
            this.numericUpDownTotalTimeAtPeakEGT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownTotalTimeAtPeakEGT.TabIndex = 92;
            this.numericUpDownTotalTimeAtPeakEGT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTotalTimeAtPeakEGT
            // 
            this.labelTotalTimeAtPeakEGT.AutoSize = true;
            this.labelTotalTimeAtPeakEGT.Location = new System.Drawing.Point(3, 114);
            this.labelTotalTimeAtPeakEGT.Name = "labelTotalTimeAtPeakEGT";
            this.labelTotalTimeAtPeakEGT.Size = new System.Drawing.Size(125, 13);
            this.labelTotalTimeAtPeakEGT.TabIndex = 93;
            this.labelTotalTimeAtPeakEGT.Text = "Total Time at Peak EGT:";
            // 
            // labelMeasure2
            // 
            this.labelMeasure2.AutoSize = true;
            this.labelMeasure2.Location = new System.Drawing.Point(251, 114);
            this.labelMeasure2.Name = "labelMeasure2";
            this.labelMeasure2.Size = new System.Drawing.Size(26, 13);
            this.labelMeasure2.TabIndex = 94;
            this.labelMeasure2.Text = "min.";
            // 
            // delimiter2
            // 
            this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
            this.delimiter2.Location = new System.Drawing.Point(280, 45);
            this.delimiter2.Name = "delimiter2";
            this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter2.Size = new System.Drawing.Size(1, 102);
            this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter2.TabIndex = 95;
            // 
            // label1FuelFlow
            // 
            this.label1FuelFlow.AutoSize = true;
            this.label1FuelFlow.Location = new System.Drawing.Point(538, 68);
            this.label1FuelFlow.Name = "label1FuelFlow";
            this.label1FuelFlow.Size = new System.Drawing.Size(55, 13);
            this.label1FuelFlow.TabIndex = 110;
            this.label1FuelFlow.Text = "Fuel Flow:";
            // 
            // labelOilPress
            // 
            this.labelOilPress.AutoSize = true;
            this.labelOilPress.Location = new System.Drawing.Point(401, 91);
            this.labelOilPress.Name = "labelOilPress";
            this.labelOilPress.Size = new System.Drawing.Size(51, 13);
            this.labelOilPress.TabIndex = 109;
            this.labelOilPress.Text = "Oil Press:";
            // 
            // labelOilTemp
            // 
            this.labelOilTemp.AutoSize = true;
            this.labelOilTemp.Location = new System.Drawing.Point(538, 91);
            this.labelOilTemp.Name = "labelOilTemp";
            this.labelOilTemp.Size = new System.Drawing.Size(52, 13);
            this.labelOilTemp.TabIndex = 108;
            this.labelOilTemp.Text = "Oil Temp:";
            // 
            // labelN2
            // 
            this.labelN2.AutoSize = true;
            this.labelN2.Location = new System.Drawing.Point(287, 91);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(24, 13);
            this.labelN2.TabIndex = 107;
            this.labelN2.Text = "N2:";
            // 
            // labelEGT
            // 
            this.labelEGT.AutoSize = true;
            this.labelEGT.Location = new System.Drawing.Point(401, 68);
            this.labelEGT.Name = "labelEGT";
            this.labelEGT.Size = new System.Drawing.Size(32, 13);
            this.labelEGT.TabIndex = 106;
            this.labelEGT.Text = "EGT:";
            // 
            // labelN1
            // 
            this.labelN1.AutoSize = true;
            this.labelN1.Location = new System.Drawing.Point(287, 68);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(24, 13);
            this.labelN1.TabIndex = 105;
            this.labelN1.Text = "N1:";
            // 
            // numericUpDownN1
            // 
            this.numericUpDownN1.Location = new System.Drawing.Point(321, 66);
            this.numericUpDownN1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownN1.Name = "numericUpDownN1";
            this.numericUpDownN1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownN1.TabIndex = 112;
            this.numericUpDownN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownN2
            // 
            this.numericUpDownN2.Location = new System.Drawing.Point(321, 89);
            this.numericUpDownN2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownN2.Name = "numericUpDownN2";
            this.numericUpDownN2.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownN2.TabIndex = 113;
            this.numericUpDownN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownOilPress
            // 
            this.numericUpDownOilPress.Location = new System.Drawing.Point(458, 89);
            this.numericUpDownOilPress.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOilPress.Name = "numericUpDownOilPress";
            this.numericUpDownOilPress.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownOilPress.TabIndex = 115;
            this.numericUpDownOilPress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownEGT
            // 
            this.numericUpDownEGT.Location = new System.Drawing.Point(458, 66);
            this.numericUpDownEGT.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownEGT.Name = "numericUpDownEGT";
            this.numericUpDownEGT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownEGT.TabIndex = 114;
            this.numericUpDownEGT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownOilTemp
            // 
            this.numericUpDownOilTemp.Location = new System.Drawing.Point(598, 89);
            this.numericUpDownOilTemp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownOilTemp.Name = "numericUpDownOilTemp";
            this.numericUpDownOilTemp.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownOilTemp.TabIndex = 117;
            this.numericUpDownOilTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownFuelFlow
            // 
            this.numericUpDownFuelFlow.Location = new System.Drawing.Point(598, 66);
            this.numericUpDownFuelFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFuelFlow.Name = "numericUpDownFuelFlow";
            this.numericUpDownFuelFlow.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownFuelFlow.TabIndex = 116;
            this.numericUpDownFuelFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelStall
            // 
            this.labelStall.AutoSize = true;
            this.labelStall.Location = new System.Drawing.Point(287, 119);
            this.labelStall.Name = "labelStall";
            this.labelStall.Size = new System.Drawing.Size(70, 13);
            this.labelStall.TabIndex = 120;
            this.labelStall.Text = "If Stall It was:";
            // 
            // radioButtonAudible
            // 
            this.radioButtonAudible.AutoSize = true;
            this.radioButtonAudible.Location = new System.Drawing.Point(363, 117);
            this.radioButtonAudible.Name = "radioButtonAudible";
            this.radioButtonAudible.Size = new System.Drawing.Size(60, 17);
            this.radioButtonAudible.TabIndex = 121;
            this.radioButtonAudible.TabStop = true;
            this.radioButtonAudible.Text = "Audible";
            this.radioButtonAudible.UseVisualStyleBackColor = true;
            // 
            // radioButtonSilent
            // 
            this.radioButtonSilent.AutoSize = true;
            this.radioButtonSilent.Location = new System.Drawing.Point(429, 117);
            this.radioButtonSilent.Name = "radioButtonSilent";
            this.radioButtonSilent.Size = new System.Drawing.Size(51, 17);
            this.radioButtonSilent.TabIndex = 122;
            this.radioButtonSilent.TabStop = true;
            this.radioButtonSilent.Text = "Silent";
            this.radioButtonSilent.UseVisualStyleBackColor = true;
            // 
            // labelOverTempData
            // 
            this.labelOverTempData.AutoSize = true;
            this.labelOverTempData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOverTempData.Location = new System.Drawing.Point(49, 42);
            this.labelOverTempData.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelOverTempData.Name = "labelOverTempData";
            this.labelOverTempData.Size = new System.Drawing.Size(116, 13);
            this.labelOverTempData.TabIndex = 123;
            this.labelOverTempData.Text = "OVER TEMP DATA";
            // 
            // labelPriorToFaulire
            // 
            this.labelPriorToFaulire.AutoSize = true;
            this.labelPriorToFaulire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPriorToFaulire.Location = new System.Drawing.Point(401, 45);
            this.labelPriorToFaulire.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelPriorToFaulire.Name = "labelPriorToFaulire";
            this.labelPriorToFaulire.Size = new System.Drawing.Size(173, 13);
            this.labelPriorToFaulire.TabIndex = 124;
            this.labelPriorToFaulire.Text = "PRIOR TO FAILURE (Known)";
            // 
            // delimiter3
            // 
            this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
            this.delimiter3.Location = new System.Drawing.Point(6, 153);
            this.delimiter3.Name = "delimiter3";
            this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter3.Size = new System.Drawing.Size(750, 1);
            this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter3.TabIndex = 125;
            // 
            // labelFlightConditions
            // 
            this.labelFlightConditions.AutoSize = true;
            this.labelFlightConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFlightConditions.Location = new System.Drawing.Point(49, 160);
            this.labelFlightConditions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelFlightConditions.Name = "labelFlightConditions";
            this.labelFlightConditions.Size = new System.Drawing.Size(132, 13);
            this.labelFlightConditions.TabIndex = 126;
            this.labelFlightConditions.Text = "FLIGHT CONDITIONS";
            // 
            // labelIAS
            // 
            this.labelIAS.AutoSize = true;
            this.labelIAS.Location = new System.Drawing.Point(3, 211);
            this.labelIAS.Name = "labelIAS";
            this.labelIAS.Size = new System.Drawing.Size(27, 13);
            this.labelIAS.TabIndex = 128;
            this.labelIAS.Text = "IAS:";
            // 
            // labelALT
            // 
            this.labelALT.AutoSize = true;
            this.labelALT.Location = new System.Drawing.Point(3, 188);
            this.labelALT.Name = "labelALT";
            this.labelALT.Size = new System.Drawing.Size(30, 13);
            this.labelALT.TabIndex = 127;
            this.labelALT.Text = "ALT:";
            // 
            // numericUpDownIAS
            // 
            this.numericUpDownIAS.Location = new System.Drawing.Point(39, 209);
            this.numericUpDownIAS.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownIAS.Name = "numericUpDownIAS";
            this.numericUpDownIAS.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownIAS.TabIndex = 130;
            this.numericUpDownIAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownALT
            // 
            this.numericUpDownALT.Location = new System.Drawing.Point(39, 186);
            this.numericUpDownALT.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDownALT.Name = "numericUpDownALT";
            this.numericUpDownALT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownALT.TabIndex = 129;
            this.numericUpDownALT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownMACH
            // 
            this.numericUpDownMACH.Location = new System.Drawing.Point(171, 209);
            this.numericUpDownMACH.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownMACH.Name = "numericUpDownMACH";
            this.numericUpDownMACH.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownMACH.TabIndex = 134;
            this.numericUpDownMACH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownTAT
            // 
            this.numericUpDownTAT.Location = new System.Drawing.Point(171, 186);
            this.numericUpDownTAT.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDownTAT.Name = "numericUpDownTAT";
            this.numericUpDownTAT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownTAT.TabIndex = 133;
            this.numericUpDownTAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMACH
            // 
            this.labelMACH.AutoSize = true;
            this.labelMACH.Location = new System.Drawing.Point(125, 211);
            this.labelMACH.Name = "labelMACH";
            this.labelMACH.Size = new System.Drawing.Size(41, 13);
            this.labelMACH.TabIndex = 132;
            this.labelMACH.Text = "MACH:";
            // 
            // labelTAT
            // 
            this.labelTAT.AutoSize = true;
            this.labelTAT.Location = new System.Drawing.Point(125, 188);
            this.labelTAT.Name = "labelTAT";
            this.labelTAT.Size = new System.Drawing.Size(31, 13);
            this.labelTAT.TabIndex = 131;
            this.labelTAT.Text = "TAT:";
            // 
            // numericUpDownOAT
            // 
            this.numericUpDownOAT.Location = new System.Drawing.Point(171, 232);
            this.numericUpDownOAT.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownOAT.Name = "numericUpDownOAT";
            this.numericUpDownOAT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownOAT.TabIndex = 136;
            this.numericUpDownOAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOAT
            // 
            this.labelOAT.AutoSize = true;
            this.labelOAT.Location = new System.Drawing.Point(125, 234);
            this.labelOAT.Name = "labelOAT";
            this.labelOAT.Size = new System.Drawing.Size(32, 13);
            this.labelOAT.TabIndex = 135;
            this.labelOAT.Text = "OAT:";
            // 
            // delimiter4
            // 
            this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
            this.delimiter4.Location = new System.Drawing.Point(280, 188);
            this.delimiter4.Name = "delimiter4";
            this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter4.Size = new System.Drawing.Size(1, 64);
            this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter4.TabIndex = 137;
            // 
            // labelFlightRegime
            // 
            this.labelFlightRegime.AutoSize = true;
            this.labelFlightRegime.Location = new System.Drawing.Point(287, 188);
            this.labelFlightRegime.Name = "labelFlightRegime";
            this.labelFlightRegime.Size = new System.Drawing.Size(74, 13);
            this.labelFlightRegime.TabIndex = 138;
            this.labelFlightRegime.Text = "Flight Regime:";
            // 
            // comboBoxFlightRegime
            // 
            this.comboBoxFlightRegime.FormattingEnabled = true;
            this.comboBoxFlightRegime.Location = new System.Drawing.Point(404, 185);
            this.comboBoxFlightRegime.Name = "comboBoxFlightRegime";
            this.comboBoxFlightRegime.Size = new System.Drawing.Size(128, 21);
            this.comboBoxFlightRegime.TabIndex = 139;
            this.comboBoxFlightRegime.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelTimeInRegime
			// 
			this.labelTimeInRegime.AutoSize = true;
            this.labelTimeInRegime.Location = new System.Drawing.Point(538, 188);
            this.labelTimeInRegime.Name = "labelTimeInRegime";
            this.labelTimeInRegime.Size = new System.Drawing.Size(84, 13);
            this.labelTimeInRegime.TabIndex = 140;
            this.labelTimeInRegime.Text = "Time In Regime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "min.";
            // 
            // numericUpDownTimeInRegime
            // 
            this.numericUpDownTimeInRegime.Location = new System.Drawing.Point(628, 186);
            this.numericUpDownTimeInRegime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownTimeInRegime.Name = "numericUpDownTimeInRegime";
            this.numericUpDownTimeInRegime.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownTimeInRegime.TabIndex = 141;
            this.numericUpDownTimeInRegime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWeather
            // 
            this.labelWeather.AutoSize = true;
            this.labelWeather.Location = new System.Drawing.Point(287, 211);
            this.labelWeather.Name = "labelWeather";
            this.labelWeather.Size = new System.Drawing.Size(51, 13);
            this.labelWeather.TabIndex = 143;
            this.labelWeather.Text = "Weather:";
            // 
            // checkBoxTurb
            // 
            this.checkBoxTurb.AutoSize = true;
            this.checkBoxTurb.Location = new System.Drawing.Point(404, 210);
            this.checkBoxTurb.Name = "checkBoxTurb";
            this.checkBoxTurb.Size = new System.Drawing.Size(48, 17);
            this.checkBoxTurb.TabIndex = 144;
            this.checkBoxTurb.Text = "Turb";
            this.checkBoxTurb.UseVisualStyleBackColor = true;
            // 
            // checkBoxClear
            // 
            this.checkBoxClear.AutoSize = true;
            this.checkBoxClear.Location = new System.Drawing.Point(482, 210);
            this.checkBoxClear.Name = "checkBoxClear";
            this.checkBoxClear.Size = new System.Drawing.Size(50, 17);
            this.checkBoxClear.TabIndex = 145;
            this.checkBoxClear.Text = "Clear";
            this.checkBoxClear.UseVisualStyleBackColor = true;
            // 
            // checkBoxClouds
            // 
            this.checkBoxClouds.AutoSize = true;
            this.checkBoxClouds.Location = new System.Drawing.Point(541, 210);
            this.checkBoxClouds.Name = "checkBoxClouds";
            this.checkBoxClouds.Size = new System.Drawing.Size(58, 17);
            this.checkBoxClouds.TabIndex = 146;
            this.checkBoxClouds.Text = "Clouds";
            this.checkBoxClouds.UseVisualStyleBackColor = true;
            // 
            // checkBoxRainShow
            // 
            this.checkBoxRainShow.AutoSize = true;
            this.checkBoxRainShow.Location = new System.Drawing.Point(628, 210);
            this.checkBoxRainShow.Name = "checkBoxRainShow";
            this.checkBoxRainShow.Size = new System.Drawing.Size(80, 17);
            this.checkBoxRainShow.TabIndex = 147;
            this.checkBoxRainShow.Text = "Rain/Snow";
            this.checkBoxRainShow.UseVisualStyleBackColor = true;
            // 
            // delimiter5
            // 
            this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
            this.delimiter5.Location = new System.Drawing.Point(6, 258);
            this.delimiter5.Name = "delimiter5";
            this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter5.Size = new System.Drawing.Size(750, 1);
            this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter5.TabIndex = 148;
            // 
            // labelFuelConditions
            // 
            this.labelFuelConditions.AutoSize = true;
            this.labelFuelConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFuelConditions.Location = new System.Drawing.Point(49, 265);
            this.labelFuelConditions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelFuelConditions.Name = "labelFuelConditions";
            this.labelFuelConditions.Size = new System.Drawing.Size(119, 13);
            this.labelFuelConditions.TabIndex = 149;
            this.labelFuelConditions.Text = "FUEL CONDITIONS";
            // 
            // labelFuelTempTank
            // 
            this.labelFuelTempTank.AutoSize = true;
            this.labelFuelTempTank.Location = new System.Drawing.Point(3, 293);
            this.labelFuelTempTank.Name = "labelFuelTempTank";
            this.labelFuelTempTank.Size = new System.Drawing.Size(94, 13);
            this.labelFuelTempTank.TabIndex = 150;
            this.labelFuelTempTank.Text = "Fuel Temp - Tank:";
            // 
            // labelFuelTempEngine
            // 
            this.labelFuelTempEngine.AutoSize = true;
            this.labelFuelTempEngine.Location = new System.Drawing.Point(3, 316);
            this.labelFuelTempEngine.Name = "labelFuelTempEngine";
            this.labelFuelTempEngine.Size = new System.Drawing.Size(158, 13);
            this.labelFuelTempEngine.TabIndex = 151;
            this.labelFuelTempEngine.Text = "Fuel Temp - Engine (if Installed):";
            // 
            // labelFuelHeat
            // 
            this.labelFuelHeat.AutoSize = true;
            this.labelFuelHeat.Location = new System.Drawing.Point(3, 339);
            this.labelFuelHeat.Name = "labelFuelHeat";
            this.labelFuelHeat.Size = new System.Drawing.Size(112, 13);
            this.labelFuelHeat.TabIndex = 152;
            this.labelFuelHeat.Text = "Fuel Heat (if Installed):";
            // 
            // labelFuelDump
            // 
            this.labelFuelDump.AutoSize = true;
            this.labelFuelDump.Location = new System.Drawing.Point(3, 361);
            this.labelFuelDump.Name = "labelFuelDump";
            this.labelFuelDump.Size = new System.Drawing.Size(61, 13);
            this.labelFuelDump.TabIndex = 153;
            this.labelFuelDump.Text = "Fuel Dump:";
            // 
            // numericUpDownFuelTempEngine
            // 
            this.numericUpDownFuelTempEngine.Location = new System.Drawing.Point(171, 314);
            this.numericUpDownFuelTempEngine.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownFuelTempEngine.Name = "numericUpDownFuelTempEngine";
            this.numericUpDownFuelTempEngine.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownFuelTempEngine.TabIndex = 155;
            this.numericUpDownFuelTempEngine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownFuelTempTank
            // 
            this.numericUpDownFuelTempTank.Location = new System.Drawing.Point(171, 291);
            this.numericUpDownFuelTempTank.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDownFuelTempTank.Name = "numericUpDownFuelTempTank";
            this.numericUpDownFuelTempTank.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownFuelTempTank.TabIndex = 154;
            this.numericUpDownFuelTempTank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxFuelHeat
            // 
            this.checkBoxFuelHeat.AutoSize = true;
            this.checkBoxFuelHeat.Location = new System.Drawing.Point(171, 338);
            this.checkBoxFuelHeat.Name = "checkBoxFuelHeat";
            this.checkBoxFuelHeat.Size = new System.Drawing.Size(44, 17);
            this.checkBoxFuelHeat.TabIndex = 156;
            this.checkBoxFuelHeat.Text = "Yes";
            this.checkBoxFuelHeat.UseVisualStyleBackColor = true;
            // 
            // checkBoxFuelDump
            // 
            this.checkBoxFuelDump.AutoSize = true;
            this.checkBoxFuelDump.Location = new System.Drawing.Point(171, 360);
            this.checkBoxFuelDump.Name = "checkBoxFuelDump";
            this.checkBoxFuelDump.Size = new System.Drawing.Size(44, 17);
            this.checkBoxFuelDump.TabIndex = 157;
            this.checkBoxFuelDump.Text = "Yes";
            this.checkBoxFuelDump.UseVisualStyleBackColor = true;
            // 
            // delimiter6
            // 
            this.delimiter6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter6.BackgroundImage")));
            this.delimiter6.Location = new System.Drawing.Point(280, 288);
            this.delimiter6.Name = "delimiter6";
            this.delimiter6.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter6.Size = new System.Drawing.Size(1, 89);
            this.delimiter6.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter6.TabIndex = 158;
            // 
            // checkBoxCenterToEngines
            // 
            this.checkBoxCenterToEngines.AutoSize = true;
            this.checkBoxCenterToEngines.Location = new System.Drawing.Point(294, 315);
            this.checkBoxCenterToEngines.Name = "checkBoxCenterToEngines";
            this.checkBoxCenterToEngines.Size = new System.Drawing.Size(100, 17);
            this.checkBoxCenterToEngines.TabIndex = 160;
            this.checkBoxCenterToEngines.Text = "Center Tank to:";
            this.checkBoxCenterToEngines.UseVisualStyleBackColor = true;
            // 
            // checkBoxTankToEngine
            // 
            this.checkBoxTankToEngine.AutoSize = true;
            this.checkBoxTankToEngine.Location = new System.Drawing.Point(294, 292);
            this.checkBoxTankToEngine.Name = "checkBoxTankToEngine";
            this.checkBoxTankToEngine.Size = new System.Drawing.Size(99, 17);
            this.checkBoxTankToEngine.TabIndex = 159;
            this.checkBoxTankToEngine.Text = "Tank to Engine";
            this.checkBoxTankToEngine.UseVisualStyleBackColor = true;
            // 
            // checkBoxInboardToEngines
            // 
            this.checkBoxInboardToEngines.AutoSize = true;
            this.checkBoxInboardToEngines.Location = new System.Drawing.Point(294, 338);
            this.checkBoxInboardToEngines.Name = "checkBoxInboardToEngines";
            this.checkBoxInboardToEngines.Size = new System.Drawing.Size(118, 17);
            this.checkBoxInboardToEngines.TabIndex = 161;
            this.checkBoxInboardToEngines.Text = "Inboard to Engines:";
            this.checkBoxInboardToEngines.UseVisualStyleBackColor = true;
            // 
            // labelAmountFuelDumped
            // 
            this.labelAmountFuelDumped.AutoSize = true;
            this.labelAmountFuelDumped.Location = new System.Drawing.Point(291, 361);
            this.labelAmountFuelDumped.Name = "labelAmountFuelDumped";
            this.labelAmountFuelDumped.Size = new System.Drawing.Size(124, 13);
            this.labelAmountFuelDumped.TabIndex = 162;
            this.labelAmountFuelDumped.Text = "Amount of Fuel Dumped:";
            // 
            // textBoxCenterToEngines
            // 
            this.textBoxCenterToEngines.Enabled = false;
            this.textBoxCenterToEngines.Location = new System.Drawing.Point(421, 313);
            this.textBoxCenterToEngines.Name = "textBoxCenterToEngines";
            this.textBoxCenterToEngines.Size = new System.Drawing.Size(111, 20);
            this.textBoxCenterToEngines.TabIndex = 163;
            // 
            // labelTo1
            // 
            this.labelTo1.AutoSize = true;
            this.labelTo1.Location = new System.Drawing.Point(538, 316);
            this.labelTo1.Name = "labelTo1";
            this.labelTo1.Size = new System.Drawing.Size(48, 13);
            this.labelTo1.TabIndex = 164;
            this.labelTo1.Text = "Engines.";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(421, 359);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown1.TabIndex = 165;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMeasure3
            // 
            this.labelMeasure3.AutoSize = true;
            this.labelMeasure3.Location = new System.Drawing.Point(538, 361);
            this.labelMeasure3.Name = "labelMeasure3";
            this.labelMeasure3.Size = new System.Drawing.Size(28, 13);
            this.labelMeasure3.TabIndex = 166;
            this.labelMeasure3.Text = "Kgs.";
            // 
            // delimiter7
            // 
            this.delimiter7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter7.BackgroundImage")));
            this.delimiter7.Location = new System.Drawing.Point(0, 385);
            this.delimiter7.Name = "delimiter7";
            this.delimiter7.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter7.Size = new System.Drawing.Size(750, 1);
            this.delimiter7.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter7.TabIndex = 167;
            // 
            // labelIndicationTime
            // 
            this.labelIndicationTime.AutoSize = true;
            this.labelIndicationTime.Location = new System.Drawing.Point(3, 426);
            this.labelIndicationTime.Name = "labelIndicationTime";
            this.labelIndicationTime.Size = new System.Drawing.Size(158, 13);
            this.labelIndicationTime.TabIndex = 169;
            this.labelIndicationTime.Text = "First time Indication Failure GMT";
            // 
            // textGMT
            // 
            this.textGMT.Location = new System.Drawing.Point(171, 423);
            this.textGMT.Name = "textGMT";
            this.textGMT.Size = new System.Drawing.Size(74, 20);
            this.textGMT.TabIndex = 168;
            // 
            // labelOtherConditions
            // 
            this.labelOtherConditions.AutoSize = true;
            this.labelOtherConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOtherConditions.Location = new System.Drawing.Point(49, 392);
            this.labelOtherConditions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelOtherConditions.Name = "labelOtherConditions";
            this.labelOtherConditions.Size = new System.Drawing.Size(340, 13);
            this.labelOtherConditions.TabIndex = 170;
            this.labelOtherConditions.Text = "OTHER CONDITIONS AT TIME OF FAILURE/SHUTDOWN";
            // 
            // panelPowerLoss
            // 
            this.panelPowerLoss.Controls.Add(this.radioButtonGradual);
            this.panelPowerLoss.Controls.Add(this.radioButtonSudden);
            this.panelPowerLoss.Controls.Add(this.labelPowerLoss);
            this.panelPowerLoss.Location = new System.Drawing.Point(3, 449);
            this.panelPowerLoss.Name = "panelPowerLoss";
            this.panelPowerLoss.Size = new System.Drawing.Size(162, 89);
            this.panelPowerLoss.TabIndex = 171;
            // 
            // radioButtonGradual
            // 
            this.radioButtonGradual.AutoSize = true;
            this.radioButtonGradual.Location = new System.Drawing.Point(6, 45);
            this.radioButtonGradual.Name = "radioButtonGradual";
            this.radioButtonGradual.Size = new System.Drawing.Size(110, 17);
            this.radioButtonGradual.TabIndex = 175;
            this.radioButtonGradual.Text = "Gradual (>5 sec\'s)";
            this.radioButtonGradual.UseVisualStyleBackColor = true;
            // 
            // radioButtonSudden
            // 
            this.radioButtonSudden.AutoSize = true;
            this.radioButtonSudden.Checked = true;
            this.radioButtonSudden.Location = new System.Drawing.Point(6, 22);
            this.radioButtonSudden.Name = "radioButtonSudden";
            this.radioButtonSudden.Size = new System.Drawing.Size(113, 17);
            this.radioButtonSudden.TabIndex = 174;
            this.radioButtonSudden.TabStop = true;
            this.radioButtonSudden.Text = "Sudden (< 5 sec\'s)";
            this.radioButtonSudden.UseVisualStyleBackColor = true;
            // 
            // labelPowerLoss
            // 
            this.labelPowerLoss.AutoSize = true;
            this.labelPowerLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPowerLoss.Location = new System.Drawing.Point(3, 3);
            this.labelPowerLoss.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelPowerLoss.Name = "labelPowerLoss";
            this.labelPowerLoss.Size = new System.Drawing.Size(76, 13);
            this.labelPowerLoss.TabIndex = 173;
            this.labelPowerLoss.Text = "Power Loss:";
            // 
            // panelThrustLevers
            // 
            this.panelThrustLevers.Controls.Add(this.radioButtonNoMoved);
            this.panelThrustLevers.Controls.Add(this.radioButtonDecelerating);
            this.panelThrustLevers.Controls.Add(this.labelThrustLevers);
            this.panelThrustLevers.Controls.Add(this.radioButtonAccelerating);
            this.panelThrustLevers.Location = new System.Drawing.Point(171, 449);
            this.panelThrustLevers.Name = "panelThrustLevers";
            this.panelThrustLevers.Size = new System.Drawing.Size(178, 89);
            this.panelThrustLevers.TabIndex = 172;
            // 
            // radioButtonNoMoved
            // 
            this.radioButtonNoMoved.AutoSize = true;
            this.radioButtonNoMoved.Location = new System.Drawing.Point(6, 68);
            this.radioButtonNoMoved.Name = "radioButtonNoMoved";
            this.radioButtonNoMoved.Size = new System.Drawing.Size(105, 17);
            this.radioButtonNoMoved.TabIndex = 178;
            this.radioButtonNoMoved.Text = "No Being Moved";
            this.radioButtonNoMoved.UseVisualStyleBackColor = true;
            // 
            // radioButtonDecelerating
            // 
            this.radioButtonDecelerating.AutoSize = true;
            this.radioButtonDecelerating.Location = new System.Drawing.Point(6, 45);
            this.radioButtonDecelerating.Name = "radioButtonDecelerating";
            this.radioButtonDecelerating.Size = new System.Drawing.Size(85, 17);
            this.radioButtonDecelerating.TabIndex = 177;
            this.radioButtonDecelerating.Text = "Decelerating";
            this.radioButtonDecelerating.UseVisualStyleBackColor = true;
            // 
            // labelThrustLevers
            // 
            this.labelThrustLevers.AutoSize = true;
            this.labelThrustLevers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelThrustLevers.Location = new System.Drawing.Point(3, 3);
            this.labelThrustLevers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelThrustLevers.Name = "labelThrustLevers";
            this.labelThrustLevers.Size = new System.Drawing.Size(89, 13);
            this.labelThrustLevers.TabIndex = 176;
            this.labelThrustLevers.Text = "Thrust Levers:";
            // 
            // radioButtonAccelerating
            // 
            this.radioButtonAccelerating.AutoSize = true;
            this.radioButtonAccelerating.Checked = true;
            this.radioButtonAccelerating.Location = new System.Drawing.Point(6, 22);
            this.radioButtonAccelerating.Name = "radioButtonAccelerating";
            this.radioButtonAccelerating.Size = new System.Drawing.Size(84, 17);
            this.radioButtonAccelerating.TabIndex = 176;
            this.radioButtonAccelerating.TabStop = true;
            this.radioButtonAccelerating.Text = "Accelerating";
            this.radioButtonAccelerating.UseVisualStyleBackColor = true;
            // 
            // panelEngineAntiIce
            // 
            this.panelEngineAntiIce.Controls.Add(this.radioButtonActivated);
            this.panelEngineAntiIce.Controls.Add(this.labelEngimeAntiIce);
            this.panelEngineAntiIce.Controls.Add(this.radioButtonOff);
            this.panelEngineAntiIce.Controls.Add(this.radioButtonOn);
            this.panelEngineAntiIce.Location = new System.Drawing.Point(352, 449);
            this.panelEngineAntiIce.Name = "panelEngineAntiIce";
            this.panelEngineAntiIce.Size = new System.Drawing.Size(135, 89);
            this.panelEngineAntiIce.TabIndex = 172;
            // 
            // radioButtonActivated
            // 
            this.radioButtonActivated.AutoSize = true;
            this.radioButtonActivated.Location = new System.Drawing.Point(6, 68);
            this.radioButtonActivated.Name = "radioButtonActivated";
            this.radioButtonActivated.Size = new System.Drawing.Size(100, 17);
            this.radioButtonActivated.TabIndex = 181;
            this.radioButtonActivated.Text = "Being Activated";
            this.radioButtonActivated.UseVisualStyleBackColor = true;
            // 
            // labelEngimeAntiIce
            // 
            this.labelEngimeAntiIce.AutoSize = true;
            this.labelEngimeAntiIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEngimeAntiIce.Location = new System.Drawing.Point(3, 3);
            this.labelEngimeAntiIce.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelEngimeAntiIce.Name = "labelEngimeAntiIce";
            this.labelEngimeAntiIce.Size = new System.Drawing.Size(97, 13);
            this.labelEngimeAntiIce.TabIndex = 179;
            this.labelEngimeAntiIce.Text = "Engine Anti-ice:";
            // 
            // radioButtonOff
            // 
            this.radioButtonOff.AutoSize = true;
            this.radioButtonOff.Location = new System.Drawing.Point(6, 45);
            this.radioButtonOff.Name = "radioButtonOff";
            this.radioButtonOff.Size = new System.Drawing.Size(45, 17);
            this.radioButtonOff.TabIndex = 180;
            this.radioButtonOff.Text = "OFF";
            this.radioButtonOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonOn
            // 
            this.radioButtonOn.AutoSize = true;
            this.radioButtonOn.Checked = true;
            this.radioButtonOn.Location = new System.Drawing.Point(6, 22);
            this.radioButtonOn.Name = "radioButtonOn";
            this.radioButtonOn.Size = new System.Drawing.Size(41, 17);
            this.radioButtonOn.TabIndex = 179;
            this.radioButtonOn.TabStop = true;
            this.radioButtonOn.Text = "ON";
            this.radioButtonOn.UseVisualStyleBackColor = true;
            // 
            // panelRelight
            // 
            this.panelRelight.Controls.Add(this.numericUpDownRelightALT);
            this.panelRelight.Controls.Add(this.radioButton1);
            this.panelRelight.Controls.Add(this.labelEngineRelight);
            this.panelRelight.Controls.Add(this.radioButton2);
            this.panelRelight.Controls.Add(this.radioButtonSuccesful);
            this.panelRelight.Location = new System.Drawing.Point(493, 449);
            this.panelRelight.Name = "panelRelight";
            this.panelRelight.Size = new System.Drawing.Size(209, 89);
            this.panelRelight.TabIndex = 172;
            // 
            // numericUpDownRelightALT
            // 
            this.numericUpDownRelightALT.Location = new System.Drawing.Point(127, 22);
            this.numericUpDownRelightALT.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDownRelightALT.Name = "numericUpDownRelightALT";
            this.numericUpDownRelightALT.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownRelightALT.TabIndex = 173;
            this.numericUpDownRelightALT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 68);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 184;
            this.radioButton1.Text = "Not Attempted";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // labelEngineRelight
            // 
            this.labelEngineRelight.AutoSize = true;
            this.labelEngineRelight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEngineRelight.Location = new System.Drawing.Point(3, 3);
            this.labelEngineRelight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelEngineRelight.Name = "labelEngineRelight";
            this.labelEngineRelight.Size = new System.Drawing.Size(120, 13);
            this.labelEngineRelight.TabIndex = 182;
            this.labelEngineRelight.Text = "Engine Relight was:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 45);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 17);
            this.radioButton2.TabIndex = 183;
            this.radioButton2.Text = "Not Successful";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButtonSuccesful
            // 
            this.radioButtonSuccesful.AutoSize = true;
            this.radioButtonSuccesful.Checked = true;
            this.radioButtonSuccesful.Location = new System.Drawing.Point(6, 22);
            this.radioButtonSuccesful.Name = "radioButtonSuccesful";
            this.radioButtonSuccesful.Size = new System.Drawing.Size(115, 17);
            this.radioButtonSuccesful.TabIndex = 182;
            this.radioButtonSuccesful.TabStop = true;
            this.radioButtonSuccesful.Text = "Successful at ALT:";
            this.radioButtonSuccesful.UseVisualStyleBackColor = true;
            // 
            // delimiter8
            // 
            this.delimiter8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter8.BackgroundImage")));
            this.delimiter8.Location = new System.Drawing.Point(3, 669);
            this.delimiter8.Name = "delimiter8";
            this.delimiter8.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter8.Size = new System.Drawing.Size(750, 1);
            this.delimiter8.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter8.TabIndex = 173;
            // 
            // labelIncindentRemarks
            // 
            this.labelIncindentRemarks.AutoSize = true;
            this.labelIncindentRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIncindentRemarks.Location = new System.Drawing.Point(49, 676);
            this.labelIncindentRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelIncindentRemarks.Name = "labelIncindentRemarks";
            this.labelIncindentRemarks.Size = new System.Drawing.Size(216, 13);
            this.labelIncindentRemarks.TabIndex = 174;
            this.labelIncindentRemarks.Text = "INCIDENT DETAILS AND REMARKS";
            // 
            // textMach
            // 
            this.textMach.Location = new System.Drawing.Point(6, 707);
            this.textMach.Multiline = true;
            this.textMach.Name = "textMach";
            this.textMach.Size = new System.Drawing.Size(696, 74);
            this.textMach.TabIndex = 175;
            // 
            // _fileControl
            // 
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.IconNotEnabled = null;
            this.fileControl.Location = new System.Drawing.Point(352, 787);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "_fileControl";
            this.fileControl.Size = new System.Drawing.Size(350, 53);
            this.fileControl.TabIndex = 176;
            // 
            // delimiter9
            // 
            this.delimiter9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter9.BackgroundImage")));
            this.delimiter9.Location = new System.Drawing.Point(6, 544);
            this.delimiter9.Name = "delimiter9";
            this.delimiter9.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter9.Size = new System.Drawing.Size(750, 1);
            this.delimiter9.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter9.TabIndex = 177;
            // 
            // labelWindmillingInformation
            // 
            this.labelWindmillingInformation.AutoSize = true;
            this.labelWindmillingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWindmillingInformation.Location = new System.Drawing.Point(49, 551);
            this.labelWindmillingInformation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.labelWindmillingInformation.Name = "labelWindmillingInformation";
            this.labelWindmillingInformation.Size = new System.Drawing.Size(181, 13);
            this.labelWindmillingInformation.TabIndex = 178;
            this.labelWindmillingInformation.Text = "WINDMILLING INFORMATION";
            // 
            // numericUpDownWMIAS
            // 
            this.numericUpDownWMIAS.Location = new System.Drawing.Point(264, 582);
            this.numericUpDownWMIAS.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownWMIAS.Name = "numericUpDownWMIAS";
            this.numericUpDownWMIAS.Size = new System.Drawing.Size(159, 20);
            this.numericUpDownWMIAS.TabIndex = 188;
            this.numericUpDownWMIAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownWMALT
            // 
            this.numericUpDownWMALT.Location = new System.Drawing.Point(60, 582);
            this.numericUpDownWMALT.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numericUpDownWMALT.Name = "numericUpDownWMALT";
            this.numericUpDownWMALT.Size = new System.Drawing.Size(142, 20);
            this.numericUpDownWMALT.TabIndex = 187;
            this.numericUpDownWMALT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWMIAS
            // 
            this.labelWMIAS.AutoSize = true;
            this.labelWMIAS.Location = new System.Drawing.Point(228, 584);
            this.labelWMIAS.Name = "labelWMIAS";
            this.labelWMIAS.Size = new System.Drawing.Size(27, 13);
            this.labelWMIAS.TabIndex = 186;
            this.labelWMIAS.Text = "IAS:";
            // 
            // labelWMALT
            // 
            this.labelWMALT.AutoSize = true;
            this.labelWMALT.Location = new System.Drawing.Point(3, 584);
            this.labelWMALT.Name = "labelWMALT";
            this.labelWMALT.Size = new System.Drawing.Size(30, 13);
            this.labelWMALT.TabIndex = 185;
            this.labelWMALT.Text = "ALT:";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(60, 606);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(142, 20);
            this.numericUpDown4.TabIndex = 184;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownWMN2
            // 
            this.numericUpDownWMN2.Location = new System.Drawing.Point(482, 606);
            this.numericUpDownWMN2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWMN2.Name = "numericUpDownWMN2";
            this.numericUpDownWMN2.Size = new System.Drawing.Size(160, 20);
            this.numericUpDownWMN2.TabIndex = 183;
            this.numericUpDownWMN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownWMN1
            // 
            this.numericUpDownWMN1.Location = new System.Drawing.Point(264, 606);
            this.numericUpDownWMN1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWMN1.Name = "numericUpDownWMN1";
            this.numericUpDownWMN1.Size = new System.Drawing.Size(159, 20);
            this.numericUpDownWMN1.TabIndex = 182;
            this.numericUpDownWMN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWMOilPress
            // 
            this.labelWMOilPress.AutoSize = true;
            this.labelWMOilPress.Location = new System.Drawing.Point(3, 608);
            this.labelWMOilPress.Name = "labelWMOilPress";
            this.labelWMOilPress.Size = new System.Drawing.Size(51, 13);
            this.labelWMOilPress.TabIndex = 181;
            this.labelWMOilPress.Text = "Oil Press:";
            // 
            // labelWMN2
            // 
            this.labelWMN2.AutoSize = true;
            this.labelWMN2.Location = new System.Drawing.Point(448, 608);
            this.labelWMN2.Name = "labelWMN2";
            this.labelWMN2.Size = new System.Drawing.Size(24, 13);
            this.labelWMN2.TabIndex = 180;
            this.labelWMN2.Text = "N2:";
            // 
            // labelWMN1
            // 
            this.labelWMN1.AutoSize = true;
            this.labelWMN1.Location = new System.Drawing.Point(228, 608);
            this.labelWMN1.Name = "labelWMN1";
            this.labelWMN1.Size = new System.Drawing.Size(24, 13);
            this.labelWMN1.TabIndex = 179;
            this.labelWMN1.Text = "N1:";
            // 
            // delimiter10
            // 
            this.delimiter10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter10.BackgroundImage")));
            this.delimiter10.Location = new System.Drawing.Point(211, 574);
            this.delimiter10.Name = "delimiter10";
            this.delimiter10.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter10.Size = new System.Drawing.Size(1, 89);
            this.delimiter10.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter10.TabIndex = 189;
            // 
            // delimiter11
            // 
            this.delimiter11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter11.BackgroundImage")));
            this.delimiter11.Location = new System.Drawing.Point(432, 574);
            this.delimiter11.Name = "delimiter11";
            this.delimiter11.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter11.Size = new System.Drawing.Size(1, 89);
            this.delimiter11.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter11.TabIndex = 190;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 191;
            this.label2.Text = "Fire Switch Pulled:";
            // 
            // checkBoxFireSwitch
            // 
            this.checkBoxFireSwitch.AutoSize = true;
            this.checkBoxFireSwitch.Location = new System.Drawing.Point(542, 583);
            this.checkBoxFireSwitch.Name = "checkBoxFireSwitch";
            this.checkBoxFireSwitch.Size = new System.Drawing.Size(44, 17);
            this.checkBoxFireSwitch.TabIndex = 192;
            this.checkBoxFireSwitch.Text = "Yes";
            this.checkBoxFireSwitch.UseVisualStyleBackColor = true;
            // 
            // labelTimeWindMilling
            // 
            this.labelTimeWindMilling.AutoSize = true;
            this.labelTimeWindMilling.Location = new System.Drawing.Point(3, 631);
            this.labelTimeWindMilling.Name = "labelTimeWindMilling";
            this.labelTimeWindMilling.Size = new System.Drawing.Size(116, 13);
            this.labelTimeWindMilling.TabIndex = 193;
            this.labelTimeWindMilling.Text = "Total Time Windmilling:";
            // 
            // numericUpDownTotalTimeWindMilling
            // 
            this.numericUpDownTotalTimeWindMilling.Location = new System.Drawing.Point(125, 629);
            this.numericUpDownTotalTimeWindMilling.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownTotalTimeWindMilling.Name = "numericUpDownTotalTimeWindMilling";
            this.numericUpDownTotalTimeWindMilling.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownTotalTimeWindMilling.TabIndex = 194;
            this.numericUpDownTotalTimeWindMilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EngineFailureDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownTotalTimeWindMilling);
            this.Controls.Add(this.labelTimeWindMilling);
            this.Controls.Add(this.checkBoxFireSwitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delimiter11);
            this.Controls.Add(this.delimiter10);
            this.Controls.Add(this.numericUpDownWMIAS);
            this.Controls.Add(this.numericUpDownWMALT);
            this.Controls.Add(this.labelWMIAS);
            this.Controls.Add(this.labelWMALT);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDownWMN2);
            this.Controls.Add(this.numericUpDownWMN1);
            this.Controls.Add(this.labelWMOilPress);
            this.Controls.Add(this.labelWMN2);
            this.Controls.Add(this.labelWMN1);
            this.Controls.Add(this.labelWindmillingInformation);
            this.Controls.Add(this.delimiter9);
            this.Controls.Add(this.fileControl);
            this.Controls.Add(this.textMach);
            this.Controls.Add(this.labelIncindentRemarks);
            this.Controls.Add(this.delimiter8);
            this.Controls.Add(this.panelRelight);
            this.Controls.Add(this.panelEngineAntiIce);
            this.Controls.Add(this.panelThrustLevers);
            this.Controls.Add(this.panelPowerLoss);
            this.Controls.Add(this.labelOtherConditions);
            this.Controls.Add(this.labelIndicationTime);
            this.Controls.Add(this.textGMT);
            this.Controls.Add(this.delimiter7);
            this.Controls.Add(this.labelMeasure3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelTo1);
            this.Controls.Add(this.textBoxCenterToEngines);
            this.Controls.Add(this.labelAmountFuelDumped);
            this.Controls.Add(this.checkBoxInboardToEngines);
            this.Controls.Add(this.checkBoxCenterToEngines);
            this.Controls.Add(this.checkBoxTankToEngine);
            this.Controls.Add(this.delimiter6);
            this.Controls.Add(this.checkBoxFuelDump);
            this.Controls.Add(this.checkBoxFuelHeat);
            this.Controls.Add(this.numericUpDownFuelTempEngine);
            this.Controls.Add(this.numericUpDownFuelTempTank);
            this.Controls.Add(this.labelFuelDump);
            this.Controls.Add(this.labelFuelHeat);
            this.Controls.Add(this.labelFuelTempEngine);
            this.Controls.Add(this.labelFuelTempTank);
            this.Controls.Add(this.labelFuelConditions);
            this.Controls.Add(this.delimiter5);
            this.Controls.Add(this.checkBoxRainShow);
            this.Controls.Add(this.checkBoxClouds);
            this.Controls.Add(this.checkBoxClear);
            this.Controls.Add(this.checkBoxTurb);
            this.Controls.Add(this.labelWeather);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownTimeInRegime);
            this.Controls.Add(this.labelTimeInRegime);
            this.Controls.Add(this.comboBoxFlightRegime);
            this.Controls.Add(this.labelFlightRegime);
            this.Controls.Add(this.delimiter4);
            this.Controls.Add(this.numericUpDownOAT);
            this.Controls.Add(this.labelOAT);
            this.Controls.Add(this.numericUpDownMACH);
            this.Controls.Add(this.numericUpDownTAT);
            this.Controls.Add(this.labelMACH);
            this.Controls.Add(this.labelTAT);
            this.Controls.Add(this.numericUpDownIAS);
            this.Controls.Add(this.numericUpDownALT);
            this.Controls.Add(this.labelIAS);
            this.Controls.Add(this.labelALT);
            this.Controls.Add(this.labelFlightConditions);
            this.Controls.Add(this.delimiter3);
            this.Controls.Add(this.labelPriorToFaulire);
            this.Controls.Add(this.labelOverTempData);
            this.Controls.Add(this.radioButtonSilent);
            this.Controls.Add(this.radioButtonAudible);
            this.Controls.Add(this.labelStall);
            this.Controls.Add(this.numericUpDownOilTemp);
            this.Controls.Add(this.numericUpDownFuelFlow);
            this.Controls.Add(this.numericUpDownOilPress);
            this.Controls.Add(this.numericUpDownEGT);
            this.Controls.Add(this.numericUpDownN2);
            this.Controls.Add(this.numericUpDownN1);
            this.Controls.Add(this.label1FuelFlow);
            this.Controls.Add(this.labelOilPress);
            this.Controls.Add(this.labelOilTemp);
            this.Controls.Add(this.labelN2);
            this.Controls.Add(this.labelEGT);
            this.Controls.Add(this.labelN1);
            this.Controls.Add(this.delimiter2);
            this.Controls.Add(this.labelMeasure2);
            this.Controls.Add(this.labelTotalTimeAtPeakEGT);
            this.Controls.Add(this.numericUpDownTotalTimeAtPeakEGT);
            this.Controls.Add(this.numericUpDownPeakEGTAttained);
            this.Controls.Add(this.labelPeakEGTAttained);
            this.Controls.Add(this.labelMeasure1);
            this.Controls.Add(this.numericUpDownTimeToRedLine);
            this.Controls.Add(this.labelTotalTimeAboveGageRedLine);
            this.Controls.Add(this.delimiter1);
            this.Controls.Add(this.textBoxEngineName);
            this.Controls.Add(this.labelEngineName);
            this.Name = "EngineFailureDataControl";
            this.Size = new System.Drawing.Size(760, 898);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeToRedLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeakEGTAttained)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTimeAtPeakEGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOilPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOilTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownALT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeInRegime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelTempEngine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelTempTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelPowerLoss.ResumeLayout(false);
            this.panelPowerLoss.PerformLayout();
            this.panelThrustLevers.ResumeLayout(false);
            this.panelThrustLevers.PerformLayout();
            this.panelEngineAntiIce.ResumeLayout(false);
            this.panelEngineAntiIce.PerformLayout();
            this.panelRelight.ResumeLayout(false);
            this.panelRelight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelightALT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMIAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMALT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMN2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWMN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalTimeWindMilling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEngineName;
        private System.Windows.Forms.TextBox textBoxEngineName;
        private Auxiliary.Delimiter delimiter1;
        private System.Windows.Forms.Label labelTotalTimeAboveGageRedLine;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeToRedLine;
        private System.Windows.Forms.Label labelMeasure1;
        private System.Windows.Forms.Label labelPeakEGTAttained;
        private System.Windows.Forms.NumericUpDown numericUpDownPeakEGTAttained;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalTimeAtPeakEGT;
        private System.Windows.Forms.Label labelTotalTimeAtPeakEGT;
        private System.Windows.Forms.Label labelMeasure2;
        private Auxiliary.Delimiter delimiter2;
        private System.Windows.Forms.Label label1FuelFlow;
        private System.Windows.Forms.Label labelOilPress;
        private System.Windows.Forms.Label labelOilTemp;
        private System.Windows.Forms.Label labelN2;
        private System.Windows.Forms.Label labelEGT;
        private System.Windows.Forms.Label labelN1;
        private System.Windows.Forms.NumericUpDown numericUpDownN1;
        private System.Windows.Forms.NumericUpDown numericUpDownN2;
        private System.Windows.Forms.NumericUpDown numericUpDownOilPress;
        private System.Windows.Forms.NumericUpDown numericUpDownEGT;
        private System.Windows.Forms.NumericUpDown numericUpDownOilTemp;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelFlow;
        private System.Windows.Forms.Label labelStall;
        private System.Windows.Forms.RadioButton radioButtonAudible;
        private System.Windows.Forms.RadioButton radioButtonSilent;
        private System.Windows.Forms.Label labelOverTempData;
        private System.Windows.Forms.Label labelPriorToFaulire;
        private Auxiliary.Delimiter delimiter3;
        private System.Windows.Forms.Label labelFlightConditions;
        private System.Windows.Forms.Label labelIAS;
        private System.Windows.Forms.Label labelALT;
        private System.Windows.Forms.NumericUpDown numericUpDownIAS;
        private System.Windows.Forms.NumericUpDown numericUpDownALT;
        private System.Windows.Forms.NumericUpDown numericUpDownMACH;
        private System.Windows.Forms.NumericUpDown numericUpDownTAT;
        private System.Windows.Forms.Label labelMACH;
        private System.Windows.Forms.Label labelTAT;
        private System.Windows.Forms.NumericUpDown numericUpDownOAT;
        private System.Windows.Forms.Label labelOAT;
        private Auxiliary.Delimiter delimiter4;
        private System.Windows.Forms.Label labelFlightRegime;
        private System.Windows.Forms.ComboBox comboBoxFlightRegime;
        private System.Windows.Forms.Label labelTimeInRegime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeInRegime;
        private System.Windows.Forms.Label labelWeather;
        private System.Windows.Forms.CheckBox checkBoxTurb;
        private System.Windows.Forms.CheckBox checkBoxClear;
        private System.Windows.Forms.CheckBox checkBoxClouds;
        private System.Windows.Forms.CheckBox checkBoxRainShow;
        private Auxiliary.Delimiter delimiter5;
        private System.Windows.Forms.Label labelFuelConditions;
        private System.Windows.Forms.Label labelFuelTempTank;
        private System.Windows.Forms.Label labelFuelTempEngine;
        private System.Windows.Forms.Label labelFuelHeat;
        private System.Windows.Forms.Label labelFuelDump;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelTempEngine;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelTempTank;
        private System.Windows.Forms.CheckBox checkBoxFuelHeat;
        private System.Windows.Forms.CheckBox checkBoxFuelDump;
        private Auxiliary.Delimiter delimiter6;
        private System.Windows.Forms.CheckBox checkBoxCenterToEngines;
        private System.Windows.Forms.CheckBox checkBoxTankToEngine;
        private System.Windows.Forms.CheckBox checkBoxInboardToEngines;
        private System.Windows.Forms.Label labelAmountFuelDumped;
        private System.Windows.Forms.TextBox textBoxCenterToEngines;
        private System.Windows.Forms.Label labelTo1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelMeasure3;
        private Auxiliary.Delimiter delimiter7;
        private System.Windows.Forms.Label labelIndicationTime;
        private System.Windows.Forms.TextBox textGMT;
        private System.Windows.Forms.Label labelOtherConditions;
        private System.Windows.Forms.Panel panelPowerLoss;
        private System.Windows.Forms.RadioButton radioButtonGradual;
        private System.Windows.Forms.RadioButton radioButtonSudden;
        private System.Windows.Forms.Label labelPowerLoss;
        private System.Windows.Forms.Panel panelThrustLevers;
        private System.Windows.Forms.RadioButton radioButtonNoMoved;
        private System.Windows.Forms.RadioButton radioButtonDecelerating;
        private System.Windows.Forms.Label labelThrustLevers;
        private System.Windows.Forms.RadioButton radioButtonAccelerating;
        private System.Windows.Forms.Panel panelEngineAntiIce;
        private System.Windows.Forms.RadioButton radioButtonActivated;
        private System.Windows.Forms.Label labelEngimeAntiIce;
        private System.Windows.Forms.RadioButton radioButtonOff;
        private System.Windows.Forms.RadioButton radioButtonOn;
        private System.Windows.Forms.Panel panelRelight;
        private System.Windows.Forms.NumericUpDown numericUpDownRelightALT;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelEngineRelight;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButtonSuccesful;
        private Auxiliary.Delimiter delimiter8;
        private System.Windows.Forms.Label labelIncindentRemarks;
        private System.Windows.Forms.TextBox textMach;
        public Auxiliary.AttachedFileControl fileControl;
        private Auxiliary.Delimiter delimiter9;
        private System.Windows.Forms.Label labelWindmillingInformation;
        private System.Windows.Forms.NumericUpDown numericUpDownWMIAS;
        private System.Windows.Forms.NumericUpDown numericUpDownWMALT;
        private System.Windows.Forms.Label labelWMIAS;
        private System.Windows.Forms.Label labelWMALT;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDownWMN2;
        private System.Windows.Forms.NumericUpDown numericUpDownWMN1;
        private System.Windows.Forms.Label labelWMOilPress;
        private System.Windows.Forms.Label labelWMN2;
        private System.Windows.Forms.Label labelWMN1;
        private Auxiliary.Delimiter delimiter10;
        private Auxiliary.Delimiter delimiter11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxFireSwitch;
        private System.Windows.Forms.Label labelTimeWindMilling;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalTimeWindMilling;
    }
}
