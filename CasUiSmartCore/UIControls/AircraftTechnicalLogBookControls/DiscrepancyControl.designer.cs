using System.Threading;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class DiscrepancyControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            lookupComboboxDeferred.CancelAsync();
            lookupComboboxDeferred.SelectedIndexChanged -= LookupComboboxDeferredSelectedIndexChanged;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscrepancyControl));
			this.labelDiscrepancy = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textSNOn = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textSNOff = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textPNOff = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioClose = new System.Windows.Forms.RadioButton();
			this.radioOpen = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.textADDNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textPNOn = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textStation = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.labelAuthB1 = new System.Windows.Forms.Label();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioMaintenanceStaff = new System.Windows.Forms.RadioButton();
			this.radioCrew = new System.Windows.Forms.RadioButton();
			this.label12 = new System.Windows.Forms.Label();
			this.textCorrectiveAction = new System.Windows.Forms.TextBox();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.label10 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.textDescription = new System.Windows.Forms.TextBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.dateTimePickerRTSDate = new System.Windows.Forms.DateTimePicker();
			this.lookupComboboxDeferred = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboSpecialist1 = new System.Windows.Forms.ComboBox();
			this.comboSpecialist2 = new System.Windows.Forms.ComboBox();
			this.labelAuthB2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelFlight = new System.Windows.Forms.Label();
			this.lookupComboboxFlight = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.radioButtonPublish = new System.Windows.Forms.RadioButton();
			this.labelActinType = new System.Windows.Forms.Label();
			this.comboBoxActinType = new System.Windows.Forms.ComboBox();
			this.labelDeffectCat = new System.Windows.Forms.Label();
			this.comboBoxDeffectCat = new System.Windows.Forms.ComboBox();
			this.labelDeffectConfirm = new System.Windows.Forms.Label();
			this.comboBoxDeffectConfirm = new System.Windows.Forms.ComboBox();
			this.labelPhase = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.comboBoxPhase = new System.Windows.Forms.ComboBox();
			this.linkLabelEditChart = new System.Windows.Forms.LinkLabel();
			this.label18 = new System.Windows.Forms.Label();
			this.comboBoxWP = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxComp = new System.Windows.Forms.ComboBox();
			this.TemplateComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
			this.panelExtendable = new System.Windows.Forms.Panel();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelDeferredInfo = new System.Windows.Forms.Panel();
			this.labelExtTimes = new System.Windows.Forms.Label();
			this.numericUpDownExtTimes = new System.Windows.Forms.NumericUpDown();
			this.labelExtension = new System.Windows.Forms.Label();
			this.dateTimePickerExtension = new System.Windows.Forms.DateTimePicker();
			this.lifelengthViewerRemains = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelClosingDate = new System.Windows.Forms.Label();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.labelOpenDate = new System.Windows.Forms.Label();
			this.dateTimePickerOpenDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxDeferredCategory = new System.Windows.Forms.TextBox();
			this.labelDefferedCategory = new System.Windows.Forms.Label();
			this.textBoxMelCdl = new System.Windows.Forms.TextBox();
			this.labelMelCdl = new System.Windows.Forms.Label();
			this.panelRelease = new System.Windows.Forms.Panel();
			this.textBoxEngineRemark = new System.Windows.Forms.TextBox();
			this.labelEngineRemark = new System.Windows.Forms.Label();
			this.comboBoxEngine = new System.Windows.Forms.ComboBox();
			this.labelEngine = new System.Windows.Forms.Label();
			this.checkBoxEngine = new System.Windows.Forms.CheckBox();
			this.labelOccurrence = new System.Windows.Forms.Label();
			this.comboBoxOccurrence = new System.Windows.Forms.ComboBox();
			this.comboBoxAuth = new System.Windows.Forms.ComboBox();
			this.labelAuth = new System.Windows.Forms.Label();
			this.labelFDR = new System.Windows.Forms.Label();
			this.labelMessages = new System.Windows.Forms.Label();
			this.textBoxFDR = new System.Windows.Forms.TextBox();
			this.textBoxMessages = new System.Windows.Forms.TextBox();
			this.labelDelay = new System.Windows.Forms.Label();
			this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
			this.labelSubstitution = new System.Windows.Forms.Label();
			this.checkBoxSubstruction = new System.Windows.Forms.CheckBox();
			this.labelRemaks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelInterruptionType = new System.Windows.Forms.Label();
			this.comboBoxInterruptionType = new System.Windows.Forms.ComboBox();
			this.labelConsequenceType = new System.Windows.Forms.Label();
			this.comboBoxConsequenceType = new System.Windows.Forms.ComboBox();
			this.labelOPSConsequence = new System.Windows.Forms.Label();
			this.comboBoxOPSConsequence = new System.Windows.Forms.ComboBox();
			this.checkBoxOccurrence = new System.Windows.Forms.CheckBox();
			this.labelFaultConsequence = new System.Windows.Forms.Label();
			this.checkBoxReliability = new System.Windows.Forms.CheckBox();
			this.comboBoxFaultConsequence = new System.Windows.Forms.ComboBox();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.panel2.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
			this.panelExtendable.SuspendLayout();
			this.flowLayoutPanelMain.SuspendLayout();
			this.panelDeferredInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtTimes)).BeginInit();
			this.panelRelease.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDiscrepancy
			// 
			this.labelDiscrepancy.AutoSize = true;
			this.labelDiscrepancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDiscrepancy.Location = new System.Drawing.Point(3, 5);
			this.labelDiscrepancy.Name = "labelDiscrepancy";
			this.labelDiscrepancy.Size = new System.Drawing.Size(89, 13);
			this.labelDiscrepancy.TabIndex = 13;
			this.labelDiscrepancy.Text = "Discrepancy #";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(411, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Corrective Action ADD No";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(478, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Component Change";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(478, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "S/N on";
			// 
			// textSNOn
			// 
			this.textSNOn.Location = new System.Drawing.Point(523, 52);
			this.textSNOn.Name = "textSNOn";
			this.textSNOn.Size = new System.Drawing.Size(85, 20);
			this.textSNOn.TabIndex = 7;
			this.textSNOn.Text = " ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(614, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "S/N off";
			// 
			// textSNOff
			// 
			this.textSNOff.Location = new System.Drawing.Point(662, 51);
			this.textSNOff.Name = "textSNOff";
			this.textSNOff.Size = new System.Drawing.Size(85, 20);
			this.textSNOff.TabIndex = 9;
			this.textSNOff.Text = " ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(614, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "P/N off";
			// 
			// textPNOff
			// 
			this.textPNOff.Location = new System.Drawing.Point(662, 26);
			this.textPNOff.Name = "textPNOff";
			this.textPNOff.Size = new System.Drawing.Size(85, 20);
			this.textPNOff.TabIndex = 8;
			this.textPNOff.Text = " ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(478, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "ATA Chapter";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Location = new System.Drawing.Point(821, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 0);
			this.panel1.TabIndex = 3;
			// 
			// radioClose
			// 
			this.radioClose.AutoSize = true;
			this.radioClose.Location = new System.Drawing.Point(945, 6);
			this.radioClose.Name = "radioClose";
			this.radioClose.Size = new System.Drawing.Size(51, 17);
			this.radioClose.TabIndex = 1;
			this.radioClose.Text = "Close";
			this.radioClose.UseVisualStyleBackColor = true;
			// 
			// radioOpen
			// 
			this.radioOpen.AutoSize = true;
			this.radioOpen.Checked = true;
			this.radioOpen.Location = new System.Drawing.Point(823, 6);
			this.radioOpen.Name = "radioOpen";
			this.radioOpen.Size = new System.Drawing.Size(51, 17);
			this.radioOpen.TabIndex = 0;
			this.radioOpen.TabStop = true;
			this.radioOpen.Text = "Open";
			this.radioOpen.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(773, 8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(43, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Status: ";
			// 
			// textADDNo
			// 
			this.textADDNo.Location = new System.Drawing.Point(546, 3);
			this.textADDNo.Name = "textADDNo";
			this.textADDNo.Size = new System.Drawing.Size(173, 20);
			this.textADDNo.TabIndex = 2;
			this.textADDNo.Text = " ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(478, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "P/N on";
			// 
			// textPNOn
			// 
			this.textPNOn.Location = new System.Drawing.Point(523, 26);
			this.textPNOn.Name = "textPNOn";
			this.textPNOn.Size = new System.Drawing.Size(85, 20);
			this.textPNOn.TabIndex = 6;
			this.textPNOn.Text = "85796858";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(761, 10);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 13);
			this.label16.TabIndex = 49;
			this.label16.Text = "MRO";
			// 
			// textStation
			// 
			this.textStation.Location = new System.Drawing.Point(793, 7);
			this.textStation.Name = "textStation";
			this.textStation.Size = new System.Drawing.Size(38, 20);
			this.textStation.TabIndex = 10;
			this.textStation.Text = "DBX";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(837, 10);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(30, 13);
			this.label17.TabIndex = 51;
			this.label17.Text = "Date";
			// 
			// labelAuthB1
			// 
			this.labelAuthB1.AutoSize = true;
			this.labelAuthB1.Location = new System.Drawing.Point(761, 32);
			this.labelAuthB1.Name = "labelAuthB1";
			this.labelAuthB1.Size = new System.Drawing.Size(45, 13);
			this.labelAuthB1.TabIndex = 53;
			this.labelAuthB1.Text = "Auth B1";
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(754, 22);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 47);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 56;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.radioMaintenanceStaff);
			this.panel2.Controls.Add(this.radioCrew);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Location = new System.Drawing.Point(181, 3);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(224, 20);
			this.panel2.TabIndex = 0;
			// 
			// radioMaintenanceStaff
			// 
			this.radioMaintenanceStaff.AutoSize = true;
			this.radioMaintenanceStaff.Location = new System.Drawing.Point(109, 0);
			this.radioMaintenanceStaff.Name = "radioMaintenanceStaff";
			this.radioMaintenanceStaff.Size = new System.Drawing.Size(112, 17);
			this.radioMaintenanceStaff.TabIndex = 1;
			this.radioMaintenanceStaff.Text = "Maintenance Staff";
			this.radioMaintenanceStaff.UseVisualStyleBackColor = true;
			// 
			// radioCrew
			// 
			this.radioCrew.AutoSize = true;
			this.radioCrew.Checked = true;
			this.radioCrew.Location = new System.Drawing.Point(53, 0);
			this.radioCrew.Name = "radioCrew";
			this.radioCrew.Size = new System.Drawing.Size(49, 17);
			this.radioCrew.TabIndex = 0;
			this.radioCrew.TabStop = true;
			this.radioCrew.Text = "Crew";
			this.radioCrew.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(-3, 2);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Filled by:";
			// 
			// textCorrectiveAction
			// 
			this.textCorrectiveAction.Location = new System.Drawing.Point(243, 26);
			this.textCorrectiveAction.Multiline = true;
			this.textCorrectiveAction.Name = "textCorrectiveAction";
			this.textCorrectiveAction.Size = new System.Drawing.Size(200, 47);
			this.textCorrectiveAction.TabIndex = 5;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(460, 22);
			this.delimiter4.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 47);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 59;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(240, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 13);
			this.label10.TabIndex = 60;
			this.label10.Text = "Corrective Action";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 13);
			this.label13.TabIndex = 63;
			this.label13.Text = "Description";
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
			this.delimiter5.Location = new System.Drawing.Point(224, 22);
			this.delimiter5.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter5.Name = "delimiter5";
			this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter5.Size = new System.Drawing.Size(1, 47);
			this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter5.TabIndex = 62;
			// 
			// textDescription
			// 
			this.textDescription.Location = new System.Drawing.Point(6, 26);
			this.textDescription.Multiline = true;
			this.textDescription.Name = "textDescription";
			this.textDescription.Size = new System.Drawing.Size(200, 47);
			this.textDescription.TabIndex = 4;
			this.textDescription.Text = "What Where When Extent";
			this.textDescription.TextChanged += new System.EventHandler(this.textDescription_TextChanged);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(1002, 3);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 178;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// dateTimePickerRTSDate
			// 
			this.dateTimePickerRTSDate.Location = new System.Drawing.Point(873, 7);
			this.dateTimePickerRTSDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerRTSDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRTSDate.Name = "dateTimePickerRTSDate";
			this.dateTimePickerRTSDate.Size = new System.Drawing.Size(133, 20);
			this.dateTimePickerRTSDate.TabIndex = 179;
			this.dateTimePickerRTSDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// lookupComboboxDeferred
			// 
			this.lookupComboboxDeferred.Displayer = null;
			this.lookupComboboxDeferred.DisplayerText = null;
			this.lookupComboboxDeferred.Entity = null;
			this.lookupComboboxDeferred.Location = new System.Drawing.Point(68, 32);
			this.lookupComboboxDeferred.Name = "lookupComboboxDeferred";
			this.lookupComboboxDeferred.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxDeferred.Size = new System.Drawing.Size(157, 21);
			this.lookupComboboxDeferred.TabIndex = 180;
			this.lookupComboboxDeferred.Type = null;
			this.lookupComboboxDeferred.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxDeferredSelectedIndexChanged);
			// 
			// comboSpecialist1
			// 
			this.comboSpecialist1.FormattingEnabled = true;
			this.comboSpecialist1.Location = new System.Drawing.Point(812, 29);
			this.comboSpecialist1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboSpecialist1.Name = "comboSpecialist1";
			this.comboSpecialist1.Size = new System.Drawing.Size(194, 21);
			this.comboSpecialist1.TabIndex = 181;
			// 
			// comboSpecialist2
			// 
			this.comboSpecialist2.FormattingEnabled = true;
			this.comboSpecialist2.Location = new System.Drawing.Point(812, 56);
			this.comboSpecialist2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboSpecialist2.Name = "comboSpecialist2";
			this.comboSpecialist2.Size = new System.Drawing.Size(194, 21);
			this.comboSpecialist2.TabIndex = 183;
			// 
			// labelAuthB2
			// 
			this.labelAuthB2.AutoSize = true;
			this.labelAuthB2.Location = new System.Drawing.Point(761, 59);
			this.labelAuthB2.Name = "labelAuthB2";
			this.labelAuthB2.Size = new System.Drawing.Size(45, 13);
			this.labelAuthB2.TabIndex = 182;
			this.labelAuthB2.Text = "Auth B2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 184;
			this.label1.Text = "Deffered";
			// 
			// labelFlight
			// 
			this.labelFlight.AutoSize = true;
			this.labelFlight.Location = new System.Drawing.Point(240, 37);
			this.labelFlight.Name = "labelFlight";
			this.labelFlight.Size = new System.Drawing.Size(32, 13);
			this.labelFlight.TabIndex = 185;
			this.labelFlight.Text = "Flight";
			this.labelFlight.Visible = false;
			// 
			// lookupComboboxFlight
			// 
			this.lookupComboboxFlight.Displayer = null;
			this.lookupComboboxFlight.DisplayerText = null;
			this.lookupComboboxFlight.Entity = null;
			this.lookupComboboxFlight.Location = new System.Drawing.Point(286, 32);
			this.lookupComboboxFlight.Name = "lookupComboboxFlight";
			this.lookupComboboxFlight.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFlight.Size = new System.Drawing.Size(157, 21);
			this.lookupComboboxFlight.TabIndex = 186;
			this.lookupComboboxFlight.Type = null;
			this.lookupComboboxFlight.Visible = false;
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.Controls.Add(this.radioClose);
			this.panelMain.Controls.Add(this.radioButtonPublish);
			this.panelMain.Controls.Add(this.labelActinType);
			this.panelMain.Controls.Add(this.comboBoxActinType);
			this.panelMain.Controls.Add(this.radioOpen);
			this.panelMain.Controls.Add(this.labelDeffectCat);
			this.panelMain.Controls.Add(this.label11);
			this.panelMain.Controls.Add(this.comboBoxDeffectCat);
			this.panelMain.Controls.Add(this.labelDeffectConfirm);
			this.panelMain.Controls.Add(this.comboBoxDeffectConfirm);
			this.panelMain.Controls.Add(this.labelPhase);
			this.panelMain.Controls.Add(this.linkLabel1);
			this.panelMain.Controls.Add(this.comboBoxPhase);
			this.panelMain.Controls.Add(this.linkLabelEditChart);
			this.panelMain.Controls.Add(this.label18);
			this.panelMain.Controls.Add(this.comboBoxWP);
			this.panelMain.Controls.Add(this.label14);
			this.panelMain.Controls.Add(this.label3);
			this.panelMain.Controls.Add(this.comboBoxComp);
			this.panelMain.Controls.Add(this.TemplateComboBox);
			this.panelMain.Controls.Add(this.ataChapterComboBox);
			this.panelMain.Controls.Add(this.numericUpDownIndex);
			this.panelMain.Controls.Add(this.labelDiscrepancy);
			this.panelMain.Controls.Add(this.lookupComboboxFlight);
			this.panelMain.Controls.Add(this.label2);
			this.panelMain.Controls.Add(this.labelFlight);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.lookupComboboxDeferred);
			this.panelMain.Controls.Add(this.buttonDelete);
			this.panelMain.Controls.Add(this.label9);
			this.panelMain.Controls.Add(this.panel1);
			this.panelMain.Controls.Add(this.textADDNo);
			this.panelMain.Controls.Add(this.panel2);
			this.panelMain.Location = new System.Drawing.Point(3, 38);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1074, 130);
			this.panelMain.TabIndex = 187;
			this.panelMain.Visible = false;
			// 
			// radioButtonPublish
			// 
			this.radioButtonPublish.AutoSize = true;
			this.radioButtonPublish.Location = new System.Drawing.Point(880, 6);
			this.radioButtonPublish.Name = "radioButtonPublish";
			this.radioButtonPublish.Size = new System.Drawing.Size(59, 17);
			this.radioButtonPublish.TabIndex = 2;
			this.radioButtonPublish.Text = "Publish";
			this.radioButtonPublish.UseVisualStyleBackColor = true;
			// 
			// labelActinType
			// 
			this.labelActinType.AutoSize = true;
			this.labelActinType.Location = new System.Drawing.Point(789, 108);
			this.labelActinType.Name = "labelActinType";
			this.labelActinType.Size = new System.Drawing.Size(64, 13);
			this.labelActinType.TabIndex = 218;
			this.labelActinType.Text = "Action Type";
			this.labelActinType.Visible = false;
			// 
			// comboBoxActinType
			// 
			this.comboBoxActinType.Enabled = false;
			this.comboBoxActinType.FormattingEnabled = true;
			this.comboBoxActinType.Location = new System.Drawing.Point(877, 105);
			this.comboBoxActinType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxActinType.Name = "comboBoxActinType";
			this.comboBoxActinType.Size = new System.Drawing.Size(194, 21);
			this.comboBoxActinType.TabIndex = 219;
			this.comboBoxActinType.Visible = false;
			// 
			// labelDeffectCat
			// 
			this.labelDeffectCat.AutoSize = true;
			this.labelDeffectCat.Location = new System.Drawing.Point(789, 85);
			this.labelDeffectCat.Name = "labelDeffectCat";
			this.labelDeffectCat.Size = new System.Drawing.Size(66, 13);
			this.labelDeffectCat.TabIndex = 216;
			this.labelDeffectCat.Text = "Deffect CAT";
			this.labelDeffectCat.Visible = false;
			// 
			// comboBoxDeffectCat
			// 
			this.comboBoxDeffectCat.Enabled = false;
			this.comboBoxDeffectCat.FormattingEnabled = true;
			this.comboBoxDeffectCat.Location = new System.Drawing.Point(877, 82);
			this.comboBoxDeffectCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxDeffectCat.Name = "comboBoxDeffectCat";
			this.comboBoxDeffectCat.Size = new System.Drawing.Size(194, 21);
			this.comboBoxDeffectCat.TabIndex = 217;
			this.comboBoxDeffectCat.Visible = false;
			// 
			// labelDeffectConfirm
			// 
			this.labelDeffectConfirm.AutoSize = true;
			this.labelDeffectConfirm.Location = new System.Drawing.Point(789, 61);
			this.labelDeffectConfirm.Name = "labelDeffectConfirm";
			this.labelDeffectConfirm.Size = new System.Drawing.Size(80, 13);
			this.labelDeffectConfirm.TabIndex = 214;
			this.labelDeffectConfirm.Text = "Deffect Confirm";
			this.labelDeffectConfirm.Visible = false;
			// 
			// comboBoxDeffectConfirm
			// 
			this.comboBoxDeffectConfirm.Enabled = false;
			this.comboBoxDeffectConfirm.FormattingEnabled = true;
			this.comboBoxDeffectConfirm.Location = new System.Drawing.Point(877, 58);
			this.comboBoxDeffectConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxDeffectConfirm.Name = "comboBoxDeffectConfirm";
			this.comboBoxDeffectConfirm.Size = new System.Drawing.Size(194, 21);
			this.comboBoxDeffectConfirm.TabIndex = 215;
			this.comboBoxDeffectConfirm.Visible = false;
			// 
			// labelPhase
			// 
			this.labelPhase.AutoSize = true;
			this.labelPhase.Location = new System.Drawing.Point(789, 37);
			this.labelPhase.Name = "labelPhase";
			this.labelPhase.Size = new System.Drawing.Size(37, 13);
			this.labelPhase.TabIndex = 186;
			this.labelPhase.Text = "Phase";
			this.labelPhase.Visible = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel1.Location = new System.Drawing.Point(729, 105);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(42, 23);
			this.linkLabel1.TabIndex = 213;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Edit";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// comboBoxPhase
			// 
			this.comboBoxPhase.Enabled = false;
			this.comboBoxPhase.FormattingEnabled = true;
			this.comboBoxPhase.Location = new System.Drawing.Point(877, 34);
			this.comboBoxPhase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxPhase.Name = "comboBoxPhase";
			this.comboBoxPhase.Size = new System.Drawing.Size(194, 21);
			this.comboBoxPhase.TabIndex = 187;
			this.comboBoxPhase.Visible = false;
			// 
			// linkLabelEditChart
			// 
			this.linkLabelEditChart.Enabled = false;
			this.linkLabelEditChart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditChart.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditChart.Location = new System.Drawing.Point(731, 79);
			this.linkLabelEditChart.Name = "linkLabelEditChart";
			this.linkLabelEditChart.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditChart.TabIndex = 202;
			this.linkLabelEditChart.TabStop = true;
			this.linkLabelEditChart.Text = "Edit";
			this.linkLabelEditChart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditChart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEditChart_LinkClicked);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(3, 109);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(34, 13);
			this.label18.TabIndex = 203;
			this.label18.Text = "Comp";
			// 
			// comboBoxWP
			// 
			this.comboBoxWP.FormattingEnabled = true;
			this.comboBoxWP.Location = new System.Drawing.Point(68, 82);
			this.comboBoxWP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxWP.Name = "comboBoxWP";
			this.comboBoxWP.Size = new System.Drawing.Size(651, 21);
			this.comboBoxWP.TabIndex = 186;
			this.comboBoxWP.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWP_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 85);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(25, 13);
			this.label14.TabIndex = 185;
			this.label14.Text = "WP";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 212;
			this.label3.Text = "Use. Templ:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxComp
			// 
			this.comboBoxComp.FormattingEnabled = true;
			this.comboBoxComp.Location = new System.Drawing.Point(68, 106);
			this.comboBoxComp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxComp.Name = "comboBoxComp";
			this.comboBoxComp.Size = new System.Drawing.Size(651, 21);
			this.comboBoxComp.TabIndex = 204;
			this.comboBoxComp.SelectedIndexChanged += new System.EventHandler(this.comboBoxComp_SelectedIndexChanged);
			this.comboBoxComp.TextUpdate += new System.EventHandler(this.comboBoxComp_TextUpdate);
			// 
			// TemplateComboBox
			// 
			this.TemplateComboBox.FormattingEnabled = true;
			this.TemplateComboBox.Location = new System.Drawing.Point(68, 57);
			this.TemplateComboBox.Name = "TemplateComboBox";
			this.TemplateComboBox.Size = new System.Drawing.Size(651, 21);
			this.TemplateComboBox.TabIndex = 211;
			this.TemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.TemplateComboBox_SelectedIndexChanged);
			this.TemplateComboBox.TextUpdate += new System.EventHandler(this.TemplateComboBox_TextUpdate);
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Location = new System.Drawing.Point(546, 33);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(173, 21);
			this.ataChapterComboBox.TabIndex = 208;
			// 
			// numericUpDownIndex
			// 
			this.numericUpDownIndex.Location = new System.Drawing.Point(98, 3);
			this.numericUpDownIndex.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.numericUpDownIndex.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numericUpDownIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownIndex.Name = "numericUpDownIndex";
			this.numericUpDownIndex.Size = new System.Drawing.Size(38, 20);
			this.numericUpDownIndex.TabIndex = 207;
			this.numericUpDownIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// panelExtendable
			// 
			this.panelExtendable.AutoSize = true;
			this.panelExtendable.Controls.Add(this.extendableRichContainer);
			this.panelExtendable.Location = new System.Drawing.Point(3, 3);
			this.panelExtendable.Name = "panelExtendable";
			this.panelExtendable.Size = new System.Drawing.Size(434, 29);
			this.panelExtendable.TabIndex = 187;
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Discrepancy";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = false;
			this.extendableRichContainer.Location = new System.Drawing.Point(0, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(431, 22);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoSize = true;
			this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelMain.Controls.Add(this.panelExtendable);
			this.flowLayoutPanelMain.Controls.Add(this.panelMain);
			this.flowLayoutPanelMain.Controls.Add(this.panelDeferredInfo);
			this.flowLayoutPanelMain.Controls.Add(this.panelRelease);
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1209, 732);
			this.flowLayoutPanelMain.TabIndex = 188;
			this.flowLayoutPanelMain.WrapContents = false;
			this.flowLayoutPanelMain.VisibleChanged += new System.EventHandler(this.flowLayoutPanelMain_VisibleChanged);
			// 
			// panelDeferredInfo
			// 
			this.panelDeferredInfo.Controls.Add(this.labelExtTimes);
			this.panelDeferredInfo.Controls.Add(this.numericUpDownExtTimes);
			this.panelDeferredInfo.Controls.Add(this.labelExtension);
			this.panelDeferredInfo.Controls.Add(this.dateTimePickerExtension);
			this.panelDeferredInfo.Controls.Add(this.lifelengthViewerRemains);
			this.panelDeferredInfo.Controls.Add(this.labelClosingDate);
			this.panelDeferredInfo.Controls.Add(this.dateTimePickerClosingDate);
			this.panelDeferredInfo.Controls.Add(this.labelOpenDate);
			this.panelDeferredInfo.Controls.Add(this.dateTimePickerOpenDate);
			this.panelDeferredInfo.Controls.Add(this.textBoxDeferredCategory);
			this.panelDeferredInfo.Controls.Add(this.labelDefferedCategory);
			this.panelDeferredInfo.Controls.Add(this.textBoxMelCdl);
			this.panelDeferredInfo.Controls.Add(this.labelMelCdl);
			this.panelDeferredInfo.Location = new System.Drawing.Point(3, 174);
			this.panelDeferredInfo.Name = "panelDeferredInfo";
			this.panelDeferredInfo.Size = new System.Drawing.Size(1203, 83);
			this.panelDeferredInfo.TabIndex = 210;
			this.panelDeferredInfo.Visible = false;
			// 
			// labelExtTimes
			// 
			this.labelExtTimes.AutoSize = true;
			this.labelExtTimes.Location = new System.Drawing.Point(240, 58);
			this.labelExtTimes.Name = "labelExtTimes";
			this.labelExtTimes.Size = new System.Drawing.Size(35, 13);
			this.labelExtTimes.TabIndex = 217;
			this.labelExtTimes.Text = "Times";
			// 
			// numericUpDownExtTimes
			// 
			this.numericUpDownExtTimes.Location = new System.Drawing.Point(286, 52);
			this.numericUpDownExtTimes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.numericUpDownExtTimes.Name = "numericUpDownExtTimes";
			this.numericUpDownExtTimes.ReadOnly = true;
			this.numericUpDownExtTimes.Size = new System.Drawing.Size(157, 20);
			this.numericUpDownExtTimes.TabIndex = 209;
			this.numericUpDownExtTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownExtTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelExtension
			// 
			this.labelExtension.AutoSize = true;
			this.labelExtension.Location = new System.Drawing.Point(240, 34);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(25, 13);
			this.labelExtension.TabIndex = 215;
			this.labelExtension.Text = "Ext.";
			// 
			// dateTimePickerExtension
			// 
			this.dateTimePickerExtension.Enabled = false;
			this.dateTimePickerExtension.Location = new System.Drawing.Point(287, 28);
			this.dateTimePickerExtension.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerExtension.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerExtension.Name = "dateTimePickerExtension";
			this.dateTimePickerExtension.Size = new System.Drawing.Size(156, 20);
			this.dateTimePickerExtension.TabIndex = 216;
			this.dateTimePickerExtension.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// lifelengthViewerRemains
			// 
			this.lifelengthViewerRemains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerRemains.AutoSize = true;
			this.lifelengthViewerRemains.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRemains.CalendarApplicable = false;
			this.lifelengthViewerRemains.CyclesApplicable = false;
			this.lifelengthViewerRemains.EnabledCalendar = true;
			this.lifelengthViewerRemains.EnabledCycle = true;
			this.lifelengthViewerRemains.EnabledHours = true;
			this.lifelengthViewerRemains.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRemains.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerRemains.HeaderCalendar = "Calendar";
			this.lifelengthViewerRemains.HeaderCycles = "Cycles";
			this.lifelengthViewerRemains.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerRemains.HeaderHours = "Hours";
			this.lifelengthViewerRemains.HoursApplicable = false;
			this.lifelengthViewerRemains.LeftHeader = "Remain";
			this.lifelengthViewerRemains.Location = new System.Drawing.Point(464, 6);
			this.lifelengthViewerRemains.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRemains.Modified = false;
			this.lifelengthViewerRemains.Name = "lifelengthViewerRemains";
			this.lifelengthViewerRemains.ReadOnly = true;
			this.lifelengthViewerRemains.ShowCalendar = true;
			this.lifelengthViewerRemains.ShowFormattedCalendar = false;
			this.lifelengthViewerRemains.ShowMinutes = true;
			this.lifelengthViewerRemains.Size = new System.Drawing.Size(417, 52);
			this.lifelengthViewerRemains.SystemCalculated = true;
			this.lifelengthViewerRemains.TabIndex = 214;
			// 
			// labelClosingDate
			// 
			this.labelClosingDate.AutoSize = true;
			this.labelClosingDate.Location = new System.Drawing.Point(3, 58);
			this.labelClosingDate.Name = "labelClosingDate";
			this.labelClosingDate.Size = new System.Drawing.Size(62, 13);
			this.labelClosingDate.TabIndex = 212;
			this.labelClosingDate.Text = "Close. Date";
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.Enabled = false;
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(68, 52);
			this.dateTimePickerClosingDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerClosingDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(156, 20);
			this.dateTimePickerClosingDate.TabIndex = 213;
			this.dateTimePickerClosingDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// labelOpenDate
			// 
			this.labelOpenDate.AutoSize = true;
			this.labelOpenDate.Location = new System.Drawing.Point(3, 34);
			this.labelOpenDate.Name = "labelOpenDate";
			this.labelOpenDate.Size = new System.Drawing.Size(57, 13);
			this.labelOpenDate.TabIndex = 184;
			this.labelOpenDate.Text = "Disc. Date";
			// 
			// dateTimePickerOpenDate
			// 
			this.dateTimePickerOpenDate.Enabled = false;
			this.dateTimePickerOpenDate.Location = new System.Drawing.Point(69, 28);
			this.dateTimePickerOpenDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerOpenDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerOpenDate.Name = "dateTimePickerOpenDate";
			this.dateTimePickerOpenDate.Size = new System.Drawing.Size(156, 20);
			this.dateTimePickerOpenDate.TabIndex = 185;
			this.dateTimePickerOpenDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// textBoxDeferredCategory
			// 
			this.textBoxDeferredCategory.Location = new System.Drawing.Point(286, 3);
			this.textBoxDeferredCategory.Name = "textBoxDeferredCategory";
			this.textBoxDeferredCategory.ReadOnly = true;
			this.textBoxDeferredCategory.Size = new System.Drawing.Size(157, 20);
			this.textBoxDeferredCategory.TabIndex = 211;
			this.textBoxDeferredCategory.Text = " ";
			// 
			// labelDefferedCategory
			// 
			this.labelDefferedCategory.AutoSize = true;
			this.labelDefferedCategory.Location = new System.Drawing.Point(240, 6);
			this.labelDefferedCategory.Name = "labelDefferedCategory";
			this.labelDefferedCategory.Size = new System.Drawing.Size(26, 13);
			this.labelDefferedCategory.TabIndex = 210;
			this.labelDefferedCategory.Text = "Cat:";
			// 
			// textBoxMelCdl
			// 
			this.textBoxMelCdl.Location = new System.Drawing.Point(68, 3);
			this.textBoxMelCdl.Name = "textBoxMelCdl";
			this.textBoxMelCdl.ReadOnly = true;
			this.textBoxMelCdl.Size = new System.Drawing.Size(157, 20);
			this.textBoxMelCdl.TabIndex = 209;
			this.textBoxMelCdl.Text = " ";
			// 
			// labelMelCdl
			// 
			this.labelMelCdl.AutoSize = true;
			this.labelMelCdl.Location = new System.Drawing.Point(3, 6);
			this.labelMelCdl.Name = "labelMelCdl";
			this.labelMelCdl.Size = new System.Drawing.Size(55, 13);
			this.labelMelCdl.TabIndex = 209;
			this.labelMelCdl.Text = "MEL/CDL";
			// 
			// panelRelease
			// 
			this.panelRelease.AutoSize = true;
			this.panelRelease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelRelease.Controls.Add(this.textBoxEngineRemark);
			this.panelRelease.Controls.Add(this.labelEngineRemark);
			this.panelRelease.Controls.Add(this.comboBoxEngine);
			this.panelRelease.Controls.Add(this.labelEngine);
			this.panelRelease.Controls.Add(this.checkBoxEngine);
			this.panelRelease.Controls.Add(this.labelOccurrence);
			this.panelRelease.Controls.Add(this.comboBoxOccurrence);
			this.panelRelease.Controls.Add(this.comboBoxAuth);
			this.panelRelease.Controls.Add(this.labelAuth);
			this.panelRelease.Controls.Add(this.labelFDR);
			this.panelRelease.Controls.Add(this.labelMessages);
			this.panelRelease.Controls.Add(this.textBoxFDR);
			this.panelRelease.Controls.Add(this.textBoxMessages);
			this.panelRelease.Controls.Add(this.labelDelay);
			this.panelRelease.Controls.Add(this.numericUpDownDelay);
			this.panelRelease.Controls.Add(this.labelSubstitution);
			this.panelRelease.Controls.Add(this.checkBoxSubstruction);
			this.panelRelease.Controls.Add(this.labelRemaks);
			this.panelRelease.Controls.Add(this.textBoxRemarks);
			this.panelRelease.Controls.Add(this.labelInterruptionType);
			this.panelRelease.Controls.Add(this.comboBoxInterruptionType);
			this.panelRelease.Controls.Add(this.labelConsequenceType);
			this.panelRelease.Controls.Add(this.comboBoxConsequenceType);
			this.panelRelease.Controls.Add(this.labelOPSConsequence);
			this.panelRelease.Controls.Add(this.comboBoxOPSConsequence);
			this.panelRelease.Controls.Add(this.checkBoxOccurrence);
			this.panelRelease.Controls.Add(this.labelFaultConsequence);
			this.panelRelease.Controls.Add(this.checkBoxReliability);
			this.panelRelease.Controls.Add(this.comboBoxFaultConsequence);
			this.panelRelease.Controls.Add(this.delimiter1);
			this.panelRelease.Controls.Add(this.label13);
			this.panelRelease.Controls.Add(this.label17);
			this.panelRelease.Controls.Add(this.labelAuthB1);
			this.panelRelease.Controls.Add(this.label16);
			this.panelRelease.Controls.Add(this.delimiter3);
			this.panelRelease.Controls.Add(this.textStation);
			this.panelRelease.Controls.Add(this.label5);
			this.panelRelease.Controls.Add(this.label4);
			this.panelRelease.Controls.Add(this.textCorrectiveAction);
			this.panelRelease.Controls.Add(this.textSNOn);
			this.panelRelease.Controls.Add(this.textPNOn);
			this.panelRelease.Controls.Add(this.comboSpecialist2);
			this.panelRelease.Controls.Add(this.delimiter4);
			this.panelRelease.Controls.Add(this.label6);
			this.panelRelease.Controls.Add(this.label10);
			this.panelRelease.Controls.Add(this.labelAuthB2);
			this.panelRelease.Controls.Add(this.textDescription);
			this.panelRelease.Controls.Add(this.textPNOff);
			this.panelRelease.Controls.Add(this.delimiter5);
			this.panelRelease.Controls.Add(this.comboSpecialist1);
			this.panelRelease.Controls.Add(this.label7);
			this.panelRelease.Controls.Add(this.label8);
			this.panelRelease.Controls.Add(this.dateTimePickerRTSDate);
			this.panelRelease.Controls.Add(this.textSNOff);
			this.panelRelease.Location = new System.Drawing.Point(3, 263);
			this.panelRelease.Name = "panelRelease";
			this.panelRelease.Size = new System.Drawing.Size(1080, 466);
			this.panelRelease.TabIndex = 209;
			this.panelRelease.Visible = false;
			// 
			// textBoxEngineRemark
			// 
			this.textBoxEngineRemark.Enabled = false;
			this.textBoxEngineRemark.Location = new System.Drawing.Point(776, 100);
			this.textBoxEngineRemark.Multiline = true;
			this.textBoxEngineRemark.Name = "textBoxEngineRemark";
			this.textBoxEngineRemark.Size = new System.Drawing.Size(301, 68);
			this.textBoxEngineRemark.TabIndex = 247;
			this.textBoxEngineRemark.Visible = false;
			// 
			// labelEngineRemark
			// 
			this.labelEngineRemark.AutoSize = true;
			this.labelEngineRemark.Location = new System.Drawing.Point(689, 103);
			this.labelEngineRemark.Name = "labelEngineRemark";
			this.labelEngineRemark.Size = new System.Drawing.Size(85, 13);
			this.labelEngineRemark.TabIndex = 246;
			this.labelEngineRemark.Text = "Engine Remarks";
			this.labelEngineRemark.Visible = false;
			// 
			// comboBoxEngine
			// 
			this.comboBoxEngine.Enabled = false;
			this.comboBoxEngine.FormattingEnabled = true;
			this.comboBoxEngine.Location = new System.Drawing.Point(523, 100);
			this.comboBoxEngine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxEngine.Name = "comboBoxEngine";
			this.comboBoxEngine.Size = new System.Drawing.Size(160, 21);
			this.comboBoxEngine.TabIndex = 245;
			this.comboBoxEngine.Visible = false;
			// 
			// labelEngine
			// 
			this.labelEngine.AutoSize = true;
			this.labelEngine.Location = new System.Drawing.Point(399, 103);
			this.labelEngine.Name = "labelEngine";
			this.labelEngine.Size = new System.Drawing.Size(96, 13);
			this.labelEngine.TabIndex = 244;
			this.labelEngine.Text = "Engine Shut Down";
			this.labelEngine.Visible = false;
			// 
			// checkBoxEngine
			// 
			this.checkBoxEngine.AutoSize = true;
			this.checkBoxEngine.Enabled = false;
			this.checkBoxEngine.Location = new System.Drawing.Point(501, 103);
			this.checkBoxEngine.Name = "checkBoxEngine";
			this.checkBoxEngine.Size = new System.Drawing.Size(15, 14);
			this.checkBoxEngine.TabIndex = 243;
			this.checkBoxEngine.UseVisualStyleBackColor = true;
			this.checkBoxEngine.Visible = false;
			// 
			// labelOccurrence
			// 
			this.labelOccurrence.AutoSize = true;
			this.labelOccurrence.Location = new System.Drawing.Point(10, 181);
			this.labelOccurrence.Name = "labelOccurrence";
			this.labelOccurrence.Size = new System.Drawing.Size(90, 13);
			this.labelOccurrence.TabIndex = 241;
			this.labelOccurrence.Text = "Occurrence Type";
			this.labelOccurrence.Visible = false;
			// 
			// comboBoxOccurrence
			// 
			this.comboBoxOccurrence.Enabled = false;
			this.comboBoxOccurrence.FormattingEnabled = true;
			this.comboBoxOccurrence.Location = new System.Drawing.Point(118, 178);
			this.comboBoxOccurrence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxOccurrence.Name = "comboBoxOccurrence";
			this.comboBoxOccurrence.Size = new System.Drawing.Size(278, 21);
			this.comboBoxOccurrence.TabIndex = 242;
			this.comboBoxOccurrence.Visible = false;
			// 
			// comboBoxAuth
			// 
			this.comboBoxAuth.Enabled = false;
			this.comboBoxAuth.FormattingEnabled = true;
			this.comboBoxAuth.Location = new System.Drawing.Point(786, 318);
			this.comboBoxAuth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxAuth.Name = "comboBoxAuth";
			this.comboBoxAuth.Size = new System.Drawing.Size(194, 21);
			this.comboBoxAuth.TabIndex = 240;
			this.comboBoxAuth.Visible = false;
			// 
			// labelAuth
			// 
			this.labelAuth.AutoSize = true;
			this.labelAuth.Location = new System.Drawing.Point(735, 321);
			this.labelAuth.Name = "labelAuth";
			this.labelAuth.Size = new System.Drawing.Size(44, 13);
			this.labelAuth.TabIndex = 239;
			this.labelAuth.Text = "Sent By";
			this.labelAuth.Visible = false;
			// 
			// labelFDR
			// 
			this.labelFDR.AutoSize = true;
			this.labelFDR.Location = new System.Drawing.Point(11, 398);
			this.labelFDR.Name = "labelFDR";
			this.labelFDR.Size = new System.Drawing.Size(29, 13);
			this.labelFDR.TabIndex = 238;
			this.labelFDR.Text = "FDR";
			this.labelFDR.Visible = false;
			// 
			// labelMessages
			// 
			this.labelMessages.AutoSize = true;
			this.labelMessages.Location = new System.Drawing.Point(11, 326);
			this.labelMessages.Name = "labelMessages";
			this.labelMessages.Size = new System.Drawing.Size(55, 13);
			this.labelMessages.TabIndex = 237;
			this.labelMessages.Text = "Messages";
			this.labelMessages.Visible = false;
			// 
			// textBoxFDR
			// 
			this.textBoxFDR.Enabled = false;
			this.textBoxFDR.Location = new System.Drawing.Point(118, 395);
			this.textBoxFDR.Multiline = true;
			this.textBoxFDR.Name = "textBoxFDR";
			this.textBoxFDR.Size = new System.Drawing.Size(598, 68);
			this.textBoxFDR.TabIndex = 236;
			this.textBoxFDR.Visible = false;
			// 
			// textBoxMessages
			// 
			this.textBoxMessages.Enabled = false;
			this.textBoxMessages.Location = new System.Drawing.Point(118, 323);
			this.textBoxMessages.Multiline = true;
			this.textBoxMessages.Name = "textBoxMessages";
			this.textBoxMessages.Size = new System.Drawing.Size(598, 68);
			this.textBoxMessages.TabIndex = 235;
			this.textBoxMessages.Visible = false;
			// 
			// labelDelay
			// 
			this.labelDelay.AutoSize = true;
			this.labelDelay.Location = new System.Drawing.Point(920, 210);
			this.labelDelay.Name = "labelDelay";
			this.labelDelay.Size = new System.Drawing.Size(60, 13);
			this.labelDelay.TabIndex = 234;
			this.labelDelay.Text = "Time Delay";
			this.labelDelay.Visible = false;
			// 
			// numericUpDownDelay
			// 
			this.numericUpDownDelay.Enabled = false;
			this.numericUpDownDelay.Location = new System.Drawing.Point(997, 207);
			this.numericUpDownDelay.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownDelay.Name = "numericUpDownDelay";
			this.numericUpDownDelay.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownDelay.TabIndex = 233;
			this.numericUpDownDelay.Visible = false;
			// 
			// labelSubstitution
			// 
			this.labelSubstitution.AutoSize = true;
			this.labelSubstitution.Location = new System.Drawing.Point(10, 232);
			this.labelSubstitution.Name = "labelSubstitution";
			this.labelSubstitution.Size = new System.Drawing.Size(62, 13);
			this.labelSubstitution.TabIndex = 232;
			this.labelSubstitution.Text = "Substitution";
			this.labelSubstitution.Visible = false;
			// 
			// checkBoxSubstruction
			// 
			this.checkBoxSubstruction.AutoSize = true;
			this.checkBoxSubstruction.Enabled = false;
			this.checkBoxSubstruction.Location = new System.Drawing.Point(118, 231);
			this.checkBoxSubstruction.Name = "checkBoxSubstruction";
			this.checkBoxSubstruction.Size = new System.Drawing.Size(15, 14);
			this.checkBoxSubstruction.TabIndex = 231;
			this.checkBoxSubstruction.UseVisualStyleBackColor = true;
			this.checkBoxSubstruction.Visible = false;
			// 
			// labelRemaks
			// 
			this.labelRemaks.AutoSize = true;
			this.labelRemaks.Location = new System.Drawing.Point(12, 254);
			this.labelRemaks.Name = "labelRemaks";
			this.labelRemaks.Size = new System.Drawing.Size(49, 13);
			this.labelRemaks.TabIndex = 230;
			this.labelRemaks.Text = "Remarks";
			this.labelRemaks.Visible = false;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Enabled = false;
			this.textBoxRemarks.Location = new System.Drawing.Point(118, 251);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(598, 68);
			this.textBoxRemarks.TabIndex = 229;
			this.textBoxRemarks.Visible = false;
			// 
			// labelInterruptionType
			// 
			this.labelInterruptionType.AutoSize = true;
			this.labelInterruptionType.Location = new System.Drawing.Point(10, 207);
			this.labelInterruptionType.Name = "labelInterruptionType";
			this.labelInterruptionType.Size = new System.Drawing.Size(87, 13);
			this.labelInterruptionType.TabIndex = 227;
			this.labelInterruptionType.Text = "Interruption Type";
			this.labelInterruptionType.Visible = false;
			// 
			// comboBoxInterruptionType
			// 
			this.comboBoxInterruptionType.Enabled = false;
			this.comboBoxInterruptionType.FormattingEnabled = true;
			this.comboBoxInterruptionType.Location = new System.Drawing.Point(118, 204);
			this.comboBoxInterruptionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxInterruptionType.Name = "comboBoxInterruptionType";
			this.comboBoxInterruptionType.Size = new System.Drawing.Size(796, 21);
			this.comboBoxInterruptionType.TabIndex = 228;
			this.comboBoxInterruptionType.Visible = false;
			// 
			// labelConsequenceType
			// 
			this.labelConsequenceType.AutoSize = true;
			this.labelConsequenceType.Location = new System.Drawing.Point(10, 155);
			this.labelConsequenceType.Name = "labelConsequenceType";
			this.labelConsequenceType.Size = new System.Drawing.Size(100, 13);
			this.labelConsequenceType.TabIndex = 225;
			this.labelConsequenceType.Text = "Consequence Type";
			this.labelConsequenceType.Visible = false;
			// 
			// comboBoxConsequenceType
			// 
			this.comboBoxConsequenceType.Enabled = false;
			this.comboBoxConsequenceType.FormattingEnabled = true;
			this.comboBoxConsequenceType.Location = new System.Drawing.Point(118, 152);
			this.comboBoxConsequenceType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxConsequenceType.Name = "comboBoxConsequenceType";
			this.comboBoxConsequenceType.Size = new System.Drawing.Size(278, 21);
			this.comboBoxConsequenceType.TabIndex = 226;
			this.comboBoxConsequenceType.Visible = false;
			// 
			// labelOPSConsequence
			// 
			this.labelOPSConsequence.AutoSize = true;
			this.labelOPSConsequence.Location = new System.Drawing.Point(10, 129);
			this.labelOPSConsequence.Name = "labelOPSConsequence";
			this.labelOPSConsequence.Size = new System.Drawing.Size(98, 13);
			this.labelOPSConsequence.TabIndex = 223;
			this.labelOPSConsequence.Text = "OPS Consequence";
			this.labelOPSConsequence.Visible = false;
			// 
			// comboBoxOPSConsequence
			// 
			this.comboBoxOPSConsequence.Enabled = false;
			this.comboBoxOPSConsequence.FormattingEnabled = true;
			this.comboBoxOPSConsequence.Location = new System.Drawing.Point(118, 126);
			this.comboBoxOPSConsequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxOPSConsequence.Name = "comboBoxOPSConsequence";
			this.comboBoxOPSConsequence.Size = new System.Drawing.Size(278, 21);
			this.comboBoxOPSConsequence.TabIndex = 224;
			this.comboBoxOPSConsequence.Visible = false;
			// 
			// checkBoxOccurrence
			// 
			this.checkBoxOccurrence.AutoSize = true;
			this.checkBoxOccurrence.Location = new System.Drawing.Point(13, 79);
			this.checkBoxOccurrence.Name = "checkBoxOccurrence";
			this.checkBoxOccurrence.Size = new System.Drawing.Size(82, 17);
			this.checkBoxOccurrence.TabIndex = 222;
			this.checkBoxOccurrence.Text = "Occurrence";
			this.checkBoxOccurrence.UseVisualStyleBackColor = true;
			this.checkBoxOccurrence.Enabled = false;
			this.checkBoxOccurrence.Visible = false;
			this.checkBoxOccurrence.CheckedChanged += new System.EventHandler(this.checkBoxOccurrence_CheckedChanged);
			// 
			// labelFaultConsequence
			// 
			this.labelFaultConsequence.AutoSize = true;
			this.labelFaultConsequence.Location = new System.Drawing.Point(10, 103);
			this.labelFaultConsequence.Name = "labelFaultConsequence";
			this.labelFaultConsequence.Size = new System.Drawing.Size(99, 13);
			this.labelFaultConsequence.TabIndex = 220;
			this.labelFaultConsequence.Text = "Fault Consequence";
			this.labelFaultConsequence.Visible = false;
			// 
			// checkBoxReliability
			// 
			this.checkBoxReliability.AutoSize = true;
			this.checkBoxReliability.Location = new System.Drawing.Point(1018, 28);
			this.checkBoxReliability.Name = "checkBoxReliability";
			this.checkBoxReliability.Size = new System.Drawing.Size(34, 17);
			this.checkBoxReliability.TabIndex = 185;
			this.checkBoxReliability.Text = "R";
			this.checkBoxReliability.UseVisualStyleBackColor = true;
			this.checkBoxReliability.CheckedChanged += new System.EventHandler(this.checkBoxReliability_CheckedChanged);
			// 
			// comboBoxFaultConsequence
			// 
			this.comboBoxFaultConsequence.Enabled = false;
			this.comboBoxFaultConsequence.FormattingEnabled = true;
			this.comboBoxFaultConsequence.Location = new System.Drawing.Point(118, 100);
			this.comboBoxFaultConsequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.comboBoxFaultConsequence.Name = "comboBoxFaultConsequence";
			this.comboBoxFaultConsequence.Size = new System.Drawing.Size(278, 21);
			this.comboBoxFaultConsequence.TabIndex = 221;
			this.comboBoxFaultConsequence.Visible = false;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(1012, 22);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(15);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter1.Size = new System.Drawing.Size(1, 47);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 184;
			// 
			// DiscrepancyControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DiscrepancyControl";
			this.Size = new System.Drawing.Size(1215, 738);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).EndInit();
			this.panelExtendable.ResumeLayout(false);
			this.panelExtendable.PerformLayout();
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.panelDeferredInfo.ResumeLayout(false);
			this.panelDeferredInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtTimes)).EndInit();
			this.panelRelease.ResumeLayout(false);
			this.panelRelease.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label labelDiscrepancy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSNOn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textSNOff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textPNOff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioClose;
        private System.Windows.Forms.RadioButton radioOpen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textADDNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPNOn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textStation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelAuthB1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioMaintenanceStaff;
        private System.Windows.Forms.RadioButton radioCrew;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textCorrectiveAction;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter5;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DateTimePicker dateTimePickerRTSDate;
        private Auxiliary.LookupCombobox lookupComboboxDeferred;
        private System.Windows.Forms.ComboBox comboSpecialist1;
        private System.Windows.Forms.ComboBox comboSpecialist2;
        private System.Windows.Forms.Label labelAuthB2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFlight;
        private Auxiliary.LookupCombobox lookupComboboxFlight;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelExtendable;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.NumericUpDown numericUpDownIndex;
        private Auxiliary.ATAChapterComboBox ataChapterComboBox;
        private System.Windows.Forms.Panel panelDeferredInfo;
        private System.Windows.Forms.TextBox textBoxMelCdl;
        private System.Windows.Forms.Label labelMelCdl;
        private System.Windows.Forms.Panel panelRelease;
        private System.Windows.Forms.Label labelOpenDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerOpenDate;
        private System.Windows.Forms.TextBox textBoxDeferredCategory;
        private System.Windows.Forms.Label labelDefferedCategory;
        private System.Windows.Forms.Label labelExtTimes;
        private System.Windows.Forms.NumericUpDown numericUpDownExtTimes;
        private System.Windows.Forms.Label labelExtension;
        private System.Windows.Forms.DateTimePicker dateTimePickerExtension;
        private Auxiliary.LifelengthViewer lifelengthViewerRemains;
        private System.Windows.Forms.Label labelClosingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private System.Windows.Forms.Label label3;
		private Auxiliary.ATAChapterComboBox TemplateComboBox;
		private Auxiliary.Delimiter delimiter1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox comboBoxWP;
		public System.Windows.Forms.LinkLabel linkLabelEditChart;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox comboBoxComp;
		public System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.CheckBox checkBoxReliability;
		private System.Windows.Forms.Label labelActinType;
		private System.Windows.Forms.ComboBox comboBoxActinType;
		private System.Windows.Forms.Label labelDeffectCat;
		private System.Windows.Forms.ComboBox comboBoxDeffectCat;
		private System.Windows.Forms.Label labelDeffectConfirm;
		private System.Windows.Forms.ComboBox comboBoxDeffectConfirm;
		private System.Windows.Forms.Label labelPhase;
		private System.Windows.Forms.ComboBox comboBoxPhase;
		private System.Windows.Forms.Label labelSubstitution;
		private System.Windows.Forms.CheckBox checkBoxSubstruction;
		private System.Windows.Forms.Label labelRemaks;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.Label labelInterruptionType;
		private System.Windows.Forms.ComboBox comboBoxInterruptionType;
		private System.Windows.Forms.Label labelConsequenceType;
		private System.Windows.Forms.ComboBox comboBoxConsequenceType;
		private System.Windows.Forms.Label labelOPSConsequence;
		private System.Windows.Forms.ComboBox comboBoxOPSConsequence;
		private System.Windows.Forms.CheckBox checkBoxOccurrence;
		private System.Windows.Forms.Label labelFaultConsequence;
		private System.Windows.Forms.ComboBox comboBoxFaultConsequence;
		private System.Windows.Forms.Label labelDelay;
		private System.Windows.Forms.NumericUpDown numericUpDownDelay;
		private System.Windows.Forms.Label labelFDR;
		private System.Windows.Forms.Label labelMessages;
		private System.Windows.Forms.TextBox textBoxFDR;
		private System.Windows.Forms.TextBox textBoxMessages;
		private System.Windows.Forms.ComboBox comboBoxAuth;
		private System.Windows.Forms.Label labelAuth;
		private System.Windows.Forms.Label labelOccurrence;
		private System.Windows.Forms.ComboBox comboBoxOccurrence;
		private System.Windows.Forms.TextBox textBoxEngineRemark;
		private System.Windows.Forms.Label labelEngineRemark;
		private System.Windows.Forms.ComboBox comboBoxEngine;
		private System.Windows.Forms.Label labelEngine;
		private System.Windows.Forms.CheckBox checkBoxEngine;
		private System.Windows.Forms.RadioButton radioButtonPublish;
	}
}
