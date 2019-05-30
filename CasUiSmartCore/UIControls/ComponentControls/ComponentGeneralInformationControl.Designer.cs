using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentGeneralInformationControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            //comboBoxModel.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.GroupBox groupBoxStart;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentGeneralInformationControl));
			this.lifelengthViewerStart = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
			this.labelPosition = new System.Windows.Forms.Label();
			this.labelModel = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.labelPartNo = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelSerialNo = new System.Windows.Forms.Label();
			this.labelMPDItem = new System.Windows.Forms.Label();
			this.textBoxSerialNo = new System.Windows.Forms.TextBox();
			this.textBoxMPDItem = new System.Windows.Forms.TextBox();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.labelInstallationDate = new System.Windows.Forms.Label();
			this.labelAtaChapter = new System.Windows.Forms.Label();
			this.textBoxPartNo = new System.Windows.Forms.TextBox();
			this.labelMaintFreq = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelMaxTakeOffWeight = new System.Windows.Forms.Label();
			this.textBoxMaxTakeOffWeight = new System.Windows.Forms.TextBox();
			this.checkBoxAvionicsInventory = new System.Windows.Forms.CheckBox();
			this.panelAvionicsInventory = new System.Windows.Forms.Panel();
			this.radioButtonInventoryOptional = new System.Windows.Forms.RadioButton();
			this.radioButtonInventoryRequired = new System.Windows.Forms.RadioButton();
			this.radioButtonAvionicsInventoryUnknown = new System.Windows.Forms.RadioButton();
			this.textBoxALTPN = new System.Windows.Forms.TextBox();
			this.textBoxHushKit = new System.Windows.Forms.TextBox();
			this.labelALTPN = new System.Windows.Forms.Label();
			this.labelHushKit = new System.Windows.Forms.Label();
			this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerInstallationDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.textBoxPosition = new System.Windows.Forms.TextBox();
			this.panelLandingGearMark = new System.Windows.Forms.Panel();
			this.radioButtonLLG = new System.Windows.Forms.RadioButton();
			this.radioButtonNLG = new System.Windows.Forms.RadioButton();
			this.radioButtonRLG = new System.Windows.Forms.RadioButton();
			this.labelCurrentTSNCSN = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.labelNotify = new System.Windows.Forms.Label();
			this.labelDeliverDate = new System.Windows.Forms.Label();
			this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.comboBoxStorePosition = new System.Windows.Forms.ComboBox();
			this.checkBoxLLPMark = new System.Windows.Forms.CheckBox();
			this.checkBoxLLPCategories = new System.Windows.Forms.CheckBox();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.comboBoxMaintProc = new System.Windows.Forms.ComboBox();
			this.labelComponentType = new System.Windows.Forms.Label();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.labelLocation = new System.Windows.Forms.Label();
			this.labelBatchNumber = new System.Windows.Forms.Label();
			this.textBoxBatchNumber = new System.Windows.Forms.TextBox();
			this.labelIdNumber = new System.Windows.Forms.Label();
			this.textBoxIdNumber = new System.Windows.Forms.TextBox();
			this.labelThrust = new System.Windows.Forms.Label();
			this.textBoxThrust = new System.Windows.Forms.TextBox();
			this.checkBoxDangerous = new System.Windows.Forms.CheckBox();
			this.checkBoxPOOL = new System.Windows.Forms.CheckBox();
			this.labelProductCode = new System.Windows.Forms.Label();
			this.textBoxProductCode = new System.Windows.Forms.TextBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.labelDiscrepancy = new System.Windows.Forms.Label();
			this.textBoxDiscrepancy = new System.Windows.Forms.TextBox();
			this.checkBoxIncoming = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.labelImage = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.dateTimePickerReciveDate = new System.Windows.Forms.DateTimePicker();
			this.labelSupplier = new System.Windows.Forms.Label();
			this.labelAStartFrom = new System.Windows.Forms.Label();
			this.labelBStartFrom = new System.Windows.Forms.Label();
			this.labelCStartFrom = new System.Windows.Forms.Label();
			this.labelDStartFrom = new System.Windows.Forms.Label();
			this.dateTimePickerAStartFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerBStartFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerCStartFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDStartFrom = new System.Windows.Forms.DateTimePicker();
			this.radioButtonA = new System.Windows.Forms.RadioButton();
			this.radioButtonB = new System.Windows.Forms.RadioButton();
			this.radioButtonC = new System.Windows.Forms.RadioButton();
			this.radioButtonD = new System.Windows.Forms.RadioButton();
			this.labelCheck = new System.Windows.Forms.Label();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.lifelengthViewerDStartFrom = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerCStartFrom = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerBStartFrom = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerAStartFrom = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.lifelengthViewer5 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer4 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer3 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer2 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.fileControlImage = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlShipping = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.comboBoxComponentType = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.comboBoxAtaChapter = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.lifelengthNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelAltPartNum = new System.Windows.Forms.Label();
			this.textBoxAltPartNum = new System.Windows.Forms.TextBox();
			this.textBoxModel = new System.Windows.Forms.TextBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabelEditComponents = new System.Windows.Forms.LinkLabel();
			groupBoxStart = new System.Windows.Forms.GroupBox();
			groupBoxStart.SuspendLayout();
			this.panelAvionicsInventory.SuspendLayout();
			this.panelLandingGearMark.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxStart
			// 
			groupBoxStart.Controls.Add(this.lifelengthViewerStart);
			groupBoxStart.Controls.Add(this.dateTimePickerStart);
			groupBoxStart.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			groupBoxStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			groupBoxStart.Location = new System.Drawing.Point(3, 395);
			groupBoxStart.Name = "groupBoxStart";
			groupBoxStart.Size = new System.Drawing.Size(371, 112);
			groupBoxStart.TabIndex = 172;
			groupBoxStart.TabStop = false;
			groupBoxStart.Text = "Start";
			groupBoxStart.Visible = false;
			// 
			// lifelengthViewerStart
			// 
			this.lifelengthViewerStart.AutoSize = true;
			this.lifelengthViewerStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerStart.CalendarApplicable = false;
			this.lifelengthViewerStart.CyclesApplicable = false;
			this.lifelengthViewerStart.EnabledCalendar = false;
			this.lifelengthViewerStart.EnabledCycle = true;
			this.lifelengthViewerStart.EnabledHours = true;
			this.lifelengthViewerStart.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerStart.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerStart.HeaderCalendar = "Calendar";
			this.lifelengthViewerStart.HeaderCycles = "Cycles";
			this.lifelengthViewerStart.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerStart.HeaderHours = "Hours";
			this.lifelengthViewerStart.HoursApplicable = false;
			this.lifelengthViewerStart.LeftHeader = "";
			this.lifelengthViewerStart.Location = new System.Drawing.Point(6, 50);
			this.lifelengthViewerStart.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerStart.Modified = false;
			this.lifelengthViewerStart.Name = "lifelengthViewerStart";
			this.lifelengthViewerStart.ReadOnly = false;
			this.lifelengthViewerStart.ShowCalendar = true;
			this.lifelengthViewerStart.ShowFormattedCalendar = false;
			this.lifelengthViewerStart.ShowLeftHeader = false;
			this.lifelengthViewerStart.ShowMinutes = true;
			this.lifelengthViewerStart.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerStart.SystemCalculated = true;
			this.lifelengthViewerStart.TabIndex = 26;
			this.lifelengthViewerStart.Visible = false;
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerStart.Location = new System.Drawing.Point(6, 19);
			this.dateTimePickerStart.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerStart.Name = "dateTimePickerStart";
			this.dateTimePickerStart.Size = new System.Drawing.Size(176, 25);
			this.dateTimePickerStart.TabIndex = 27;
			this.dateTimePickerStart.Visible = false;
			this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPosition.Location = new System.Drawing.Point(3, 265);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelPosition.Size = new System.Drawing.Size(62, 14);
			this.labelPosition.TabIndex = 5;
			this.labelPosition.Text = "Position:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelModel
			// 
			this.labelModel.AutoSize = true;
			this.labelModel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelModel.Location = new System.Drawing.Point(3, 11);
			this.labelModel.Name = "labelModel";
			this.labelModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelModel.Size = new System.Drawing.Size(49, 14);
			this.labelModel.TabIndex = 6;
			this.labelModel.Text = "Model:";
			this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(3, 66);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(95, 14);
			this.labelManufacturer.TabIndex = 7;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPartNo
			// 
			this.labelPartNo.AutoSize = true;
			this.labelPartNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNo.Location = new System.Drawing.Point(3, 94);
			this.labelPartNo.Name = "labelPartNo";
			this.labelPartNo.Size = new System.Drawing.Size(59, 14);
			this.labelPartNo.TabIndex = 0;
			this.labelPartNo.Text = "Part No:";
			this.labelPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(113, 202);
			this.textBoxDescription.MaxLength = 250;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(249, 52);
			this.textBoxDescription.TabIndex = 6;
			// 
			// labelSerialNo
			// 
			this.labelSerialNo.AutoSize = true;
			this.labelSerialNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNo.Location = new System.Drawing.Point(3, 149);
			this.labelSerialNo.Name = "labelSerialNo";
			this.labelSerialNo.Size = new System.Drawing.Size(68, 14);
			this.labelSerialNo.TabIndex = 1;
			this.labelSerialNo.Text = "Serial No:";
			this.labelSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMPDItem
			// 
			this.labelMPDItem.AutoSize = true;
			this.labelMPDItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItem.Location = new System.Drawing.Point(401, 92);
			this.labelMPDItem.Name = "labelMPDItem";
			this.labelMPDItem.Size = new System.Drawing.Size(72, 14);
			this.labelMPDItem.TabIndex = 2;
			this.labelMPDItem.Text = "MPD Item:";
			this.labelMPDItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSerialNo
			// 
			this.textBoxSerialNo.BackColor = System.Drawing.Color.White;
			this.textBoxSerialNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSerialNo.Location = new System.Drawing.Point(113, 146);
			this.textBoxSerialNo.MaxLength = 100;
			this.textBoxSerialNo.Name = "textBoxSerialNo";
			this.textBoxSerialNo.Size = new System.Drawing.Size(249, 22);
			this.textBoxSerialNo.TabIndex = 5;
			// 
			// textBoxMPDItem
			// 
			this.textBoxMPDItem.BackColor = System.Drawing.Color.White;
			this.textBoxMPDItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMPDItem.Location = new System.Drawing.Point(537, 89);
			this.textBoxMPDItem.MaxLength = 50;
			this.textBoxMPDItem.Name = "textBoxMPDItem";
			this.textBoxMPDItem.Size = new System.Drawing.Size(250, 22);
			this.textBoxMPDItem.TabIndex = 11;
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDate.Location = new System.Drawing.Point(400, 180);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(87, 14);
			this.labelManufactureDate.TabIndex = 8;
			this.labelManufactureDate.Text = "Manuf. Date:";
			// 
			// labelInstallationDate
			// 
			this.labelInstallationDate.AutoSize = true;
			this.labelInstallationDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelInstallationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInstallationDate.Location = new System.Drawing.Point(400, 236);
			this.labelInstallationDate.Name = "labelInstallationDate";
			this.labelInstallationDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelInstallationDate.Size = new System.Drawing.Size(89, 14);
			this.labelInstallationDate.TabIndex = 9;
			this.labelInstallationDate.Text = "Install. Date:";
			// 
			// labelAtaChapter
			// 
			this.labelAtaChapter.AutoSize = true;
			this.labelAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAtaChapter.Location = new System.Drawing.Point(401, 120);
			this.labelAtaChapter.Name = "labelAtaChapter";
			this.labelAtaChapter.Size = new System.Drawing.Size(33, 14);
			this.labelAtaChapter.TabIndex = 3;
			this.labelAtaChapter.Text = "ATA:";
			this.labelAtaChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNo
			// 
			this.textBoxPartNo.BackColor = System.Drawing.Color.White;
			this.textBoxPartNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNo.Location = new System.Drawing.Point(113, 90);
			this.textBoxPartNo.MaxLength = 100;
			this.textBoxPartNo.Name = "textBoxPartNo";
			this.textBoxPartNo.Size = new System.Drawing.Size(249, 22);
			this.textBoxPartNo.TabIndex = 4;
			// 
			// labelMaintFreq
			// 
			this.labelMaintFreq.AutoSize = true;
			this.labelMaintFreq.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaintFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaintFreq.Location = new System.Drawing.Point(832, 38);
			this.labelMaintFreq.Name = "labelMaintFreq";
			this.labelMaintFreq.Size = new System.Drawing.Size(85, 14);
			this.labelMaintFreq.TabIndex = 10;
			this.labelMaintFreq.Text = "Maint. Proc.:";
			this.labelMaintFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(2, 208);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(82, 14);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxTakeOffWeight
			// 
			this.labelMaxTakeOffWeight.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxTakeOffWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxTakeOffWeight.Location = new System.Drawing.Point(403, 145);
			this.labelMaxTakeOffWeight.Name = "labelMaxTakeOffWeight";
			this.labelMaxTakeOffWeight.Size = new System.Drawing.Size(100, 25);
			this.labelMaxTakeOffWeight.TabIndex = 33;
			this.labelMaxTakeOffWeight.Text = "Max Take Off Weight:";
			this.labelMaxTakeOffWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxMaxTakeOffWeight
			// 
			this.textBoxMaxTakeOffWeight.BackColor = System.Drawing.Color.White;
			this.textBoxMaxTakeOffWeight.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxMaxTakeOffWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMaxTakeOffWeight.Location = new System.Drawing.Point(542, 140);
			this.textBoxMaxTakeOffWeight.MaxLength = 200;
			this.textBoxMaxTakeOffWeight.Name = "textBoxMaxTakeOffWeight";
			this.textBoxMaxTakeOffWeight.Size = new System.Drawing.Size(250, 22);
			this.textBoxMaxTakeOffWeight.TabIndex = 34;
			// 
			// checkBoxAvionicsInventory
			// 
			this.checkBoxAvionicsInventory.AutoSize = true;
			this.checkBoxAvionicsInventory.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxAvionicsInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxAvionicsInventory.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxAvionicsInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxAvionicsInventory.Location = new System.Drawing.Point(403, 145);
			this.checkBoxAvionicsInventory.Name = "checkBoxAvionicsInventory";
			this.checkBoxAvionicsInventory.Size = new System.Drawing.Size(133, 18);
			this.checkBoxAvionicsInventory.TabIndex = 14;
			this.checkBoxAvionicsInventory.Text = "Avionx. Inventory";
			this.checkBoxAvionicsInventory.CheckedChanged += new System.EventHandler(this.CheckBoxAvionicsInventoryMarkCheckedChanged);
			// 
			// panelAvionicsInventory
			// 
			this.panelAvionicsInventory.AutoSize = true;
			this.panelAvionicsInventory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelAvionicsInventory.Controls.Add(this.radioButtonInventoryOptional);
			this.panelAvionicsInventory.Controls.Add(this.radioButtonInventoryRequired);
			this.panelAvionicsInventory.Controls.Add(this.radioButtonAvionicsInventoryUnknown);
			this.panelAvionicsInventory.Location = new System.Drawing.Point(539, 140);
			this.panelAvionicsInventory.Name = "panelAvionicsInventory";
			this.panelAvionicsInventory.Size = new System.Drawing.Size(255, 27);
			this.panelAvionicsInventory.TabIndex = 15;
			// 
			// radioButtonInventoryOptional
			// 
			this.radioButtonInventoryOptional.AutoSize = true;
			this.radioButtonInventoryOptional.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonInventoryOptional.Enabled = false;
			this.radioButtonInventoryOptional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonInventoryOptional.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonInventoryOptional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonInventoryOptional.Location = new System.Drawing.Point(0, 6);
			this.radioButtonInventoryOptional.Name = "radioButtonInventoryOptional";
			this.radioButtonInventoryOptional.Size = new System.Drawing.Size(77, 18);
			this.radioButtonInventoryOptional.TabIndex = 0;
			this.radioButtonInventoryOptional.Text = "Optional";
			// 
			// radioButtonInventoryRequired
			// 
			this.radioButtonInventoryRequired.AutoSize = true;
			this.radioButtonInventoryRequired.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonInventoryRequired.Enabled = false;
			this.radioButtonInventoryRequired.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonInventoryRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonInventoryRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonInventoryRequired.Location = new System.Drawing.Point(83, 6);
			this.radioButtonInventoryRequired.Name = "radioButtonInventoryRequired";
			this.radioButtonInventoryRequired.Size = new System.Drawing.Size(80, 18);
			this.radioButtonInventoryRequired.TabIndex = 1;
			this.radioButtonInventoryRequired.Text = "Required";
			// 
			// radioButtonAvionicsInventoryUnknown
			// 
			this.radioButtonAvionicsInventoryUnknown.AutoSize = true;
			this.radioButtonAvionicsInventoryUnknown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonAvionicsInventoryUnknown.Enabled = false;
			this.radioButtonAvionicsInventoryUnknown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonAvionicsInventoryUnknown.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonAvionicsInventoryUnknown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonAvionicsInventoryUnknown.Location = new System.Drawing.Point(169, 6);
			this.radioButtonAvionicsInventoryUnknown.Name = "radioButtonAvionicsInventoryUnknown";
			this.radioButtonAvionicsInventoryUnknown.Size = new System.Drawing.Size(83, 18);
			this.radioButtonAvionicsInventoryUnknown.TabIndex = 2;
			this.radioButtonAvionicsInventoryUnknown.Text = "Unknown";
			// 
			// textBoxALTPN
			// 
			this.textBoxALTPN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxALTPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxALTPN.Location = new System.Drawing.Point(937, 6);
			this.textBoxALTPN.MaxLength = 200;
			this.textBoxALTPN.Name = "textBoxALTPN";
			this.textBoxALTPN.Size = new System.Drawing.Size(250, 22);
			this.textBoxALTPN.TabIndex = 23;
			// 
			// textBoxHushKit
			// 
			this.textBoxHushKit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxHushKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxHushKit.Location = new System.Drawing.Point(542, 140);
			this.textBoxHushKit.MaxLength = 200;
			this.textBoxHushKit.Name = "textBoxHushKit";
			this.textBoxHushKit.Size = new System.Drawing.Size(250, 22);
			this.textBoxHushKit.TabIndex = 36;
			// 
			// labelALTPN
			// 
			this.labelALTPN.AutoSize = true;
			this.labelALTPN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelALTPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelALTPN.Location = new System.Drawing.Point(832, 11);
			this.labelALTPN.Name = "labelALTPN";
			this.labelALTPN.Size = new System.Drawing.Size(59, 14);
			this.labelALTPN.TabIndex = 31;
			this.labelALTPN.Text = "ALT P/N:";
			// 
			// labelHushKit
			// 
			this.labelHushKit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHushKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHushKit.Location = new System.Drawing.Point(403, 145);
			this.labelHushKit.Name = "labelHushKit";
			this.labelHushKit.Size = new System.Drawing.Size(100, 25);
			this.labelHushKit.TabIndex = 35;
			this.labelHushKit.Text = "Hush Kit Equipped:";
			// 
			// dateTimePickerManufactureDate
			// 
			this.dateTimePickerManufactureDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(539, 174);
			this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
			this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerManufactureDate.TabIndex = 18;
			// 
			// dateTimePickerInstallationDate
			// 
			this.dateTimePickerInstallationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerInstallationDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerInstallationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerInstallationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerInstallationDate.Location = new System.Drawing.Point(539, 230);
			this.dateTimePickerInstallationDate.Name = "dateTimePickerInstallationDate";
			this.dateTimePickerInstallationDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerInstallationDate.TabIndex = 20;
			this.dateTimePickerInstallationDate.ValueChanged += new System.EventHandler(this.DateTimePickerInstallationDateValueChanged);
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(113, 62);
			this.textBoxManufacturer.MaxLength = 100;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(249, 22);
			this.textBoxManufacturer.TabIndex = 3;
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.BackColor = System.Drawing.Color.White;
			this.textBoxPosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPosition.Location = new System.Drawing.Point(113, 260);
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.Size = new System.Drawing.Size(249, 22);
			this.textBoxPosition.TabIndex = 7;
			// 
			// panelLandingGearMark
			// 
			this.panelLandingGearMark.AutoSize = true;
			this.panelLandingGearMark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelLandingGearMark.Controls.Add(this.radioButtonLLG);
			this.panelLandingGearMark.Controls.Add(this.radioButtonNLG);
			this.panelLandingGearMark.Controls.Add(this.radioButtonRLG);
			this.panelLandingGearMark.Location = new System.Drawing.Point(1017, 323);
			this.panelLandingGearMark.Name = "panelLandingGearMark";
			this.panelLandingGearMark.Size = new System.Drawing.Size(175, 27);
			this.panelLandingGearMark.TabIndex = 27;
			this.panelLandingGearMark.Visible = false;
			// 
			// radioButtonLLG
			// 
			this.radioButtonLLG.AutoSize = true;
			this.radioButtonLLG.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonLLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonLLG.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonLLG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonLLG.Location = new System.Drawing.Point(0, 6);
			this.radioButtonLLG.Name = "radioButtonLLG";
			this.radioButtonLLG.Size = new System.Drawing.Size(48, 18);
			this.radioButtonLLG.TabIndex = 0;
			this.radioButtonLLG.Text = "Left";
			// 
			// radioButtonNLG
			// 
			this.radioButtonNLG.AutoSize = true;
			this.radioButtonNLG.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonNLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonNLG.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonNLG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonNLG.Location = new System.Drawing.Point(54, 6);
			this.radioButtonNLG.Name = "radioButtonNLG";
			this.radioButtonNLG.Size = new System.Drawing.Size(56, 18);
			this.radioButtonNLG.TabIndex = 1;
			this.radioButtonNLG.Text = "Nose";
			// 
			// radioButtonRLG
			// 
			this.radioButtonRLG.AutoSize = true;
			this.radioButtonRLG.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonRLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonRLG.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonRLG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonRLG.Location = new System.Drawing.Point(116, 6);
			this.radioButtonRLG.Name = "radioButtonRLG";
			this.radioButtonRLG.Size = new System.Drawing.Size(56, 18);
			this.radioButtonRLG.TabIndex = 2;
			this.radioButtonRLG.Text = "Right";
			// 
			// labelCurrentTSNCSN
			// 
			this.labelCurrentTSNCSN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCurrentTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCurrentTSNCSN.Location = new System.Drawing.Point(810, 25);
			this.labelCurrentTSNCSN.Name = "labelCurrentTSNCSN";
			this.labelCurrentTSNCSN.Size = new System.Drawing.Size(200, 25);
			this.labelCurrentTSNCSN.TabIndex = 47;
			this.labelCurrentTSNCSN.Text = "Current TSN/CSN:";
			this.labelCurrentTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(384, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 25);
			this.label1.TabIndex = 55;
			this.label1.Text = "Cost overhaul:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.White;
			this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBox2.Location = new System.Drawing.Point(510, 185);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(250, 22);
			this.textBox2.TabIndex = 58;
			// 
			// labelNotify
			// 
			this.labelNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNotify.Location = new System.Drawing.Point(810, 226);
			this.labelNotify.Name = "labelNotify";
			this.labelNotify.Size = new System.Drawing.Size(200, 25);
			this.labelNotify.TabIndex = 53;
			this.labelNotify.Text = "Notify:";
			this.labelNotify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDeliverDate
			// 
			this.labelDeliverDate.AutoSize = true;
			this.labelDeliverDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDeliverDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDeliverDate.Location = new System.Drawing.Point(400, 208);
			this.labelDeliverDate.Name = "labelDeliverDate";
			this.labelDeliverDate.Size = new System.Drawing.Size(96, 14);
			this.labelDeliverDate.TabIndex = 63;
			this.labelDeliverDate.Text = "Delivery Date:";
			// 
			// dateTimePickerDeliveryDate
			// 
			this.dateTimePickerDeliveryDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDeliveryDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerDeliveryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(539, 202);
			this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
			this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerDeliveryDate.TabIndex = 19;
			this.dateTimePickerDeliveryDate.ValueChanged += new System.EventHandler(this.dateTimePickerDeliveryDate_ValueChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(110, 385);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(250, 22);
			this.dateTimePicker1.TabIndex = 64;
			// 
			// comboBoxStorePosition
			// 
			this.comboBoxStorePosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStorePosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStorePosition.FormattingEnabled = true;
			this.comboBoxStorePosition.Location = new System.Drawing.Point(942, 295);
			this.comboBoxStorePosition.Name = "comboBoxStorePosition";
			this.comboBoxStorePosition.Size = new System.Drawing.Size(250, 22);
			this.comboBoxStorePosition.TabIndex = 7;
			this.comboBoxStorePosition.Visible = false;
			// 
			// checkBoxLLPMark
			// 
			this.checkBoxLLPMark.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxLLPMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxLLPMark.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxLLPMark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxLLPMark.Location = new System.Drawing.Point(403, 253);
			this.checkBoxLLPMark.Name = "checkBoxLLPMark";
			this.checkBoxLLPMark.Size = new System.Drawing.Size(93, 35);
			this.checkBoxLLPMark.TabIndex = 21;
			this.checkBoxLLPMark.Text = "Is LLP Disk";
			this.checkBoxLLPMark.Click += new System.EventHandler(this.CheckBoxLLPMarkClick);
			// 
			// checkBoxLLPCategories
			// 
			this.checkBoxLLPCategories.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxLLPCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxLLPCategories.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxLLPCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxLLPCategories.Location = new System.Drawing.Point(539, 253);
			this.checkBoxLLPCategories.Name = "checkBoxLLPCategories";
			this.checkBoxLLPCategories.Size = new System.Drawing.Size(122, 35);
			this.checkBoxLLPCategories.TabIndex = 22;
			this.checkBoxLLPCategories.Text = "LLP Categories";
			this.checkBoxLLPCategories.Visible = false;
			this.checkBoxLLPCategories.CheckedChanged += new System.EventHandler(this.checkBoxLLPCategories_CheckedChanged);
			this.checkBoxLLPCategories.Click += new System.EventHandler(this.CheckBoxLLPCategoriesClick);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownQuantity.Location = new System.Drawing.Point(937, 196);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(252, 22);
			this.numericUpDownQuantity.TabIndex = 26;
			this.numericUpDownQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownQuantity.Visible = false;
			// 
			// comboBoxMaintProc
			// 
			this.comboBoxMaintProc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxMaintProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxMaintProc.FormattingEnabled = true;
			this.comboBoxMaintProc.Location = new System.Drawing.Point(937, 34);
			this.comboBoxMaintProc.Name = "comboBoxMaintProc";
			this.comboBoxMaintProc.Size = new System.Drawing.Size(250, 22);
			this.comboBoxMaintProc.TabIndex = 24;
			// 
			// labelComponentType
			// 
			this.labelComponentType.AutoSize = true;
			this.labelComponentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComponentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComponentType.Location = new System.Drawing.Point(832, 65);
			this.labelComponentType.Name = "labelComponentType";
			this.labelComponentType.Size = new System.Drawing.Size(46, 14);
			this.labelComponentType.TabIndex = 72;
			this.labelComponentType.Text = "Class:";
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(832, 199);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(66, 14);
			this.labelQuantity.TabIndex = 74;
			this.labelQuantity.Text = "Quantity:";
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLocation.Location = new System.Drawing.Point(3, 291);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelLocation.Size = new System.Drawing.Size(65, 14);
			this.labelLocation.TabIndex = 77;
			this.labelLocation.Text = "Location:";
			this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelLocation.Visible = false;
			// 
			// labelBatchNumber
			// 
			this.labelBatchNumber.AutoSize = true;
			this.labelBatchNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBatchNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBatchNumber.Location = new System.Drawing.Point(400, 37);
			this.labelBatchNumber.Name = "labelBatchNumber";
			this.labelBatchNumber.Size = new System.Drawing.Size(68, 14);
			this.labelBatchNumber.TabIndex = 89;
			this.labelBatchNumber.Text = "Batch No:";
			this.labelBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxBatchNumber
			// 
			this.textBoxBatchNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxBatchNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxBatchNumber.Location = new System.Drawing.Point(537, 32);
			this.textBoxBatchNumber.MaxLength = 200;
			this.textBoxBatchNumber.Name = "textBoxBatchNumber";
			this.textBoxBatchNumber.Size = new System.Drawing.Size(250, 22);
			this.textBoxBatchNumber.TabIndex = 9;
			// 
			// labelIdNumber
			// 
			this.labelIdNumber.AutoSize = true;
			this.labelIdNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelIdNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIdNumber.Location = new System.Drawing.Point(400, 63);
			this.labelIdNumber.Name = "labelIdNumber";
			this.labelIdNumber.Size = new System.Drawing.Size(47, 14);
			this.labelIdNumber.TabIndex = 88;
			this.labelIdNumber.Text = "ID No:";
			this.labelIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIdNumber
			// 
			this.textBoxIdNumber.BackColor = System.Drawing.Color.White;
			this.textBoxIdNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxIdNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxIdNumber.Location = new System.Drawing.Point(537, 60);
			this.textBoxIdNumber.MaxLength = 50;
			this.textBoxIdNumber.Name = "textBoxIdNumber";
			this.textBoxIdNumber.Size = new System.Drawing.Size(250, 22);
			this.textBoxIdNumber.TabIndex = 10;
			// 
			// labelThrust
			// 
			this.labelThrust.AutoSize = true;
			this.labelThrust.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelThrust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelThrust.Location = new System.Drawing.Point(832, 229);
			this.labelThrust.Name = "labelThrust";
			this.labelThrust.Size = new System.Drawing.Size(52, 14);
			this.labelThrust.TabIndex = 91;
			this.labelThrust.Text = "Thrust:";
			this.labelThrust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelThrust.Visible = false;
			// 
			// textBoxThrust
			// 
			this.textBoxThrust.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxThrust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxThrust.Location = new System.Drawing.Point(937, 224);
			this.textBoxThrust.MaxLength = 200;
			this.textBoxThrust.Name = "textBoxThrust";
			this.textBoxThrust.Size = new System.Drawing.Size(252, 22);
			this.textBoxThrust.TabIndex = 90;
			this.textBoxThrust.Visible = false;
			// 
			// checkBoxDangerous
			// 
			this.checkBoxDangerous.AutoSize = true;
			this.checkBoxDangerous.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDangerous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxDangerous.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxDangerous.Location = new System.Drawing.Point(937, 261);
			this.checkBoxDangerous.Name = "checkBoxDangerous";
			this.checkBoxDangerous.Size = new System.Drawing.Size(108, 18);
			this.checkBoxDangerous.TabIndex = 93;
			this.checkBoxDangerous.Text = "Is Dangerous";
			// 
			// checkBoxPOOL
			// 
			this.checkBoxPOOL.AutoSize = true;
			this.checkBoxPOOL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPOOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxPOOL.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxPOOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPOOL.Location = new System.Drawing.Point(835, 261);
			this.checkBoxPOOL.Name = "checkBoxPOOL";
			this.checkBoxPOOL.Size = new System.Drawing.Size(74, 18);
			this.checkBoxPOOL.TabIndex = 92;
			this.checkBoxPOOL.Text = "Is POOL";
			// 
			// labelProductCode
			// 
			this.labelProductCode.AutoSize = true;
			this.labelProductCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProductCode.Location = new System.Drawing.Point(3, 180);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(45, 14);
			this.labelProductCode.TabIndex = 94;
			this.labelProductCode.Text = "Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductCode.Location = new System.Drawing.Point(113, 174);
			this.textBoxProductCode.MaxLength = 100;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.Size = new System.Drawing.Size(249, 22);
			this.textBoxProductCode.TabIndex = 95;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStatus.Location = new System.Drawing.Point(2, 319);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelStatus.Size = new System.Drawing.Size(53, 14);
			this.labelStatus.TabIndex = 97;
			this.labelStatus.Text = "Status:";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(113, 315);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(249, 22);
			this.comboBoxStatus.TabIndex = 96;
			// 
			// labelDiscrepancy
			// 
			this.labelDiscrepancy.AutoSize = true;
			this.labelDiscrepancy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDiscrepancy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDiscrepancy.Location = new System.Drawing.Point(832, 116);
			this.labelDiscrepancy.Name = "labelDiscrepancy";
			this.labelDiscrepancy.Size = new System.Drawing.Size(87, 14);
			this.labelDiscrepancy.TabIndex = 99;
			this.labelDiscrepancy.Text = "Discrepancy:";
			this.labelDiscrepancy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDiscrepancy
			// 
			this.textBoxDiscrepancy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxDiscrepancy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDiscrepancy.Location = new System.Drawing.Point(937, 113);
			this.textBoxDiscrepancy.MaxLength = 200;
			this.textBoxDiscrepancy.Multiline = true;
			this.textBoxDiscrepancy.Name = "textBoxDiscrepancy";
			this.textBoxDiscrepancy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDiscrepancy.Size = new System.Drawing.Size(252, 77);
			this.textBoxDiscrepancy.TabIndex = 100;
			// 
			// checkBoxIncoming
			// 
			this.checkBoxIncoming.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIncoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxIncoming.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxIncoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIncoming.Location = new System.Drawing.Point(1031, 87);
			this.checkBoxIncoming.Name = "checkBoxIncoming";
			this.checkBoxIncoming.Size = new System.Drawing.Size(155, 26);
			this.checkBoxIncoming.TabIndex = 132;
			this.checkBoxIncoming.Text = "Incoming Control";
			this.checkBoxIncoming.CheckedChanged += new System.EventHandler(this.checkBoxIncoming_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(2, 352);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(97, 14);
			this.label2.TabIndex = 133;
			this.label2.Text = "Shipping Doc.:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelImage
			// 
			this.labelImage.AutoSize = true;
			this.labelImage.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelImage.Location = new System.Drawing.Point(403, 322);
			this.labelImage.Name = "labelImage";
			this.labelImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelImage.Size = new System.Drawing.Size(52, 14);
			this.labelImage.TabIndex = 140;
			this.labelImage.Text = "Image:";
			this.labelImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(3, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 14);
			this.label3.TabIndex = 147;
			this.label3.Text = "ReceivedFrom:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(113, 34);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(140, 22);
			this.comboBoxSupplier.TabIndex = 148;
			this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
			// 
			// dateTimePickerReciveDate
			// 
			this.dateTimePickerReciveDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReciveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerReciveDate.Location = new System.Drawing.Point(259, 34);
			this.dateTimePickerReciveDate.Name = "dateTimePickerReciveDate";
			this.dateTimePickerReciveDate.Size = new System.Drawing.Size(103, 22);
			this.dateTimePickerReciveDate.TabIndex = 149;
			this.dateTimePickerReciveDate.ValueChanged += new System.EventHandler(this.dateTimePickerReciveDate_ValueChanged);
			// 
			// labelSupplier
			// 
			this.labelSupplier.AutoSize = true;
			this.labelSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelSupplier.Location = new System.Drawing.Point(554, 625);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(95, 13);
			this.labelSupplier.TabIndex = 150;
			this.labelSupplier.Text = "PRODUCT COST:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAStartFrom
			// 
			this.labelAStartFrom.AutoSize = true;
			this.labelAStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAStartFrom.Location = new System.Drawing.Point(401, 424);
			this.labelAStartFrom.Name = "labelAStartFrom";
			this.labelAStartFrom.Size = new System.Drawing.Size(78, 14);
			this.labelAStartFrom.TabIndex = 156;
			this.labelAStartFrom.Text = "Start From:";
			this.labelAStartFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelAStartFrom.Visible = false;
			// 
			// labelBStartFrom
			// 
			this.labelBStartFrom.AutoSize = true;
			this.labelBStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBStartFrom.Location = new System.Drawing.Point(401, 474);
			this.labelBStartFrom.Name = "labelBStartFrom";
			this.labelBStartFrom.Size = new System.Drawing.Size(78, 14);
			this.labelBStartFrom.TabIndex = 157;
			this.labelBStartFrom.Text = "Start From:";
			this.labelBStartFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelBStartFrom.Visible = false;
			// 
			// labelCStartFrom
			// 
			this.labelCStartFrom.AutoSize = true;
			this.labelCStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCStartFrom.Location = new System.Drawing.Point(403, 526);
			this.labelCStartFrom.Name = "labelCStartFrom";
			this.labelCStartFrom.Size = new System.Drawing.Size(78, 14);
			this.labelCStartFrom.TabIndex = 158;
			this.labelCStartFrom.Text = "Start From:";
			this.labelCStartFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelCStartFrom.Visible = false;
			// 
			// labelDStartFrom
			// 
			this.labelDStartFrom.AutoSize = true;
			this.labelDStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDStartFrom.Location = new System.Drawing.Point(401, 580);
			this.labelDStartFrom.Name = "labelDStartFrom";
			this.labelDStartFrom.Size = new System.Drawing.Size(78, 14);
			this.labelDStartFrom.TabIndex = 159;
			this.labelDStartFrom.Text = "Start From:";
			this.labelDStartFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelDStartFrom.Visible = false;
			// 
			// dateTimePickerAStartFrom
			// 
			this.dateTimePickerAStartFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerAStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerAStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerAStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerAStartFrom.Location = new System.Drawing.Point(493, 419);
			this.dateTimePickerAStartFrom.Name = "dateTimePickerAStartFrom";
			this.dateTimePickerAStartFrom.Size = new System.Drawing.Size(125, 22);
			this.dateTimePickerAStartFrom.TabIndex = 160;
			this.dateTimePickerAStartFrom.Visible = false;
			// 
			// dateTimePickerBStartFrom
			// 
			this.dateTimePickerBStartFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerBStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerBStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerBStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerBStartFrom.Location = new System.Drawing.Point(492, 469);
			this.dateTimePickerBStartFrom.Name = "dateTimePickerBStartFrom";
			this.dateTimePickerBStartFrom.Size = new System.Drawing.Size(126, 22);
			this.dateTimePickerBStartFrom.TabIndex = 161;
			this.dateTimePickerBStartFrom.Visible = false;
			// 
			// dateTimePickerCStartFrom
			// 
			this.dateTimePickerCStartFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerCStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerCStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerCStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerCStartFrom.Location = new System.Drawing.Point(493, 524);
			this.dateTimePickerCStartFrom.Name = "dateTimePickerCStartFrom";
			this.dateTimePickerCStartFrom.Size = new System.Drawing.Size(125, 22);
			this.dateTimePickerCStartFrom.TabIndex = 162;
			this.dateTimePickerCStartFrom.Visible = false;
			// 
			// dateTimePickerDStartFrom
			// 
			this.dateTimePickerDStartFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDStartFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerDStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDStartFrom.Location = new System.Drawing.Point(493, 577);
			this.dateTimePickerDStartFrom.Name = "dateTimePickerDStartFrom";
			this.dateTimePickerDStartFrom.Size = new System.Drawing.Size(126, 22);
			this.dateTimePickerDStartFrom.TabIndex = 163;
			this.dateTimePickerDStartFrom.Visible = false;
			// 
			// radioButtonA
			// 
			this.radioButtonA.AutoSize = true;
			this.radioButtonA.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonA.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonA.Location = new System.Drawing.Point(537, 287);
			this.radioButtonA.Name = "radioButtonA";
			this.radioButtonA.Size = new System.Drawing.Size(32, 18);
			this.radioButtonA.TabIndex = 3;
			this.radioButtonA.Text = "A";
			this.radioButtonA.Visible = false;
			this.radioButtonA.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButtonB
			// 
			this.radioButtonB.AutoSize = true;
			this.radioButtonB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonB.Location = new System.Drawing.Point(575, 287);
			this.radioButtonB.Name = "radioButtonB";
			this.radioButtonB.Size = new System.Drawing.Size(32, 18);
			this.radioButtonB.TabIndex = 168;
			this.radioButtonB.Text = "B";
			this.radioButtonB.Visible = false;
			this.radioButtonB.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButtonC
			// 
			this.radioButtonC.AutoSize = true;
			this.radioButtonC.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonC.Location = new System.Drawing.Point(613, 287);
			this.radioButtonC.Name = "radioButtonC";
			this.radioButtonC.Size = new System.Drawing.Size(33, 18);
			this.radioButtonC.TabIndex = 169;
			this.radioButtonC.Text = "C";
			this.radioButtonC.Visible = false;
			this.radioButtonC.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButtonD
			// 
			this.radioButtonD.AutoSize = true;
			this.radioButtonD.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonD.Location = new System.Drawing.Point(652, 287);
			this.radioButtonD.Name = "radioButtonD";
			this.radioButtonD.Size = new System.Drawing.Size(33, 18);
			this.radioButtonD.TabIndex = 170;
			this.radioButtonD.Text = "D";
			this.radioButtonD.Visible = false;
			this.radioButtonD.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// labelCheck
			// 
			this.labelCheck.AutoSize = true;
			this.labelCheck.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCheck.Location = new System.Drawing.Point(401, 291);
			this.labelCheck.Name = "labelCheck";
			this.labelCheck.Size = new System.Drawing.Size(122, 14);
			this.labelCheck.TabIndex = 171;
			this.labelCheck.Text = "Current Category:";
			this.labelCheck.Visible = false;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(1185, 403);
			this.delimiter4.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 218);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 167;
			this.delimiter4.Visible = false;
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(0, 620);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter3.Size = new System.Drawing.Size(1186, 1);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 166;
			this.delimiter3.Visible = false;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(391, 404);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 218);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 165;
			this.delimiter2.Visible = false;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(1, 395);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(1186, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 164;
			this.delimiter1.Visible = false;
			// 
			// lifelengthViewerDStartFrom
			// 
			this.lifelengthViewerDStartFrom.AutoSize = true;
			this.lifelengthViewerDStartFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerDStartFrom.CalendarApplicable = false;
			this.lifelengthViewerDStartFrom.CyclesApplicable = false;
			this.lifelengthViewerDStartFrom.EnabledCalendar = false;
			this.lifelengthViewerDStartFrom.EnabledCycle = true;
			this.lifelengthViewerDStartFrom.EnabledHours = false;
			this.lifelengthViewerDStartFrom.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerDStartFrom.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerDStartFrom.HeaderCalendar = "Calendar";
			this.lifelengthViewerDStartFrom.HeaderCycles = "Cycles";
			this.lifelengthViewerDStartFrom.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerDStartFrom.HeaderHours = "Hours";
			this.lifelengthViewerDStartFrom.HoursApplicable = false;
			this.lifelengthViewerDStartFrom.LeftHeader = "D";
			this.lifelengthViewerDStartFrom.Location = new System.Drawing.Point(624, 555);
			this.lifelengthViewerDStartFrom.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerDStartFrom.Modified = false;
			this.lifelengthViewerDStartFrom.Name = "lifelengthViewerDStartFrom";
			this.lifelengthViewerDStartFrom.ReadOnly = false;
			this.lifelengthViewerDStartFrom.ShowCalendar = true;
			this.lifelengthViewerDStartFrom.ShowFormattedCalendar = false;
			this.lifelengthViewerDStartFrom.ShowMinutes = true;
			this.lifelengthViewerDStartFrom.Size = new System.Drawing.Size(377, 52);
			this.lifelengthViewerDStartFrom.SystemCalculated = true;
			this.lifelengthViewerDStartFrom.TabIndex = 155;
			this.lifelengthViewerDStartFrom.Visible = false;
			// 
			// lifelengthViewerCStartFrom
			// 
			this.lifelengthViewerCStartFrom.AutoSize = true;
			this.lifelengthViewerCStartFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerCStartFrom.CalendarApplicable = false;
			this.lifelengthViewerCStartFrom.CyclesApplicable = false;
			this.lifelengthViewerCStartFrom.EnabledCalendar = false;
			this.lifelengthViewerCStartFrom.EnabledCycle = true;
			this.lifelengthViewerCStartFrom.EnabledHours = false;
			this.lifelengthViewerCStartFrom.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerCStartFrom.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerCStartFrom.HeaderCalendar = "Calendar";
			this.lifelengthViewerCStartFrom.HeaderCycles = "Cycles";
			this.lifelengthViewerCStartFrom.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerCStartFrom.HeaderHours = "Hours";
			this.lifelengthViewerCStartFrom.HoursApplicable = false;
			this.lifelengthViewerCStartFrom.LeftHeader = "C";
			this.lifelengthViewerCStartFrom.Location = new System.Drawing.Point(623, 499);
			this.lifelengthViewerCStartFrom.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerCStartFrom.Modified = false;
			this.lifelengthViewerCStartFrom.Name = "lifelengthViewerCStartFrom";
			this.lifelengthViewerCStartFrom.ReadOnly = false;
			this.lifelengthViewerCStartFrom.ShowCalendar = true;
			this.lifelengthViewerCStartFrom.ShowFormattedCalendar = false;
			this.lifelengthViewerCStartFrom.ShowMinutes = true;
			this.lifelengthViewerCStartFrom.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewerCStartFrom.SystemCalculated = true;
			this.lifelengthViewerCStartFrom.TabIndex = 154;
			this.lifelengthViewerCStartFrom.Visible = false;
			// 
			// lifelengthViewerBStartFrom
			// 
			this.lifelengthViewerBStartFrom.AutoSize = true;
			this.lifelengthViewerBStartFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerBStartFrom.CalendarApplicable = false;
			this.lifelengthViewerBStartFrom.CyclesApplicable = false;
			this.lifelengthViewerBStartFrom.EnabledCalendar = true;
			this.lifelengthViewerBStartFrom.EnabledCycle = true;
			this.lifelengthViewerBStartFrom.EnabledHours = false;
			this.lifelengthViewerBStartFrom.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerBStartFrom.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerBStartFrom.HeaderCalendar = "Calendar";
			this.lifelengthViewerBStartFrom.HeaderCycles = "Cycles";
			this.lifelengthViewerBStartFrom.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerBStartFrom.HeaderHours = "Hours";
			this.lifelengthViewerBStartFrom.HoursApplicable = false;
			this.lifelengthViewerBStartFrom.LeftHeader = "B";
			this.lifelengthViewerBStartFrom.Location = new System.Drawing.Point(623, 443);
			this.lifelengthViewerBStartFrom.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerBStartFrom.Modified = false;
			this.lifelengthViewerBStartFrom.Name = "lifelengthViewerBStartFrom";
			this.lifelengthViewerBStartFrom.ReadOnly = false;
			this.lifelengthViewerBStartFrom.ShowCalendar = true;
			this.lifelengthViewerBStartFrom.ShowFormattedCalendar = false;
			this.lifelengthViewerBStartFrom.ShowMinutes = true;
			this.lifelengthViewerBStartFrom.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewerBStartFrom.SystemCalculated = true;
			this.lifelengthViewerBStartFrom.TabIndex = 153;
			this.lifelengthViewerBStartFrom.Visible = false;
			// 
			// lifelengthViewerAStartFrom
			// 
			this.lifelengthViewerAStartFrom.AutoSize = true;
			this.lifelengthViewerAStartFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerAStartFrom.CalendarApplicable = false;
			this.lifelengthViewerAStartFrom.CyclesApplicable = false;
			this.lifelengthViewerAStartFrom.EnabledCalendar = false;
			this.lifelengthViewerAStartFrom.EnabledCycle = true;
			this.lifelengthViewerAStartFrom.EnabledHours = false;
			this.lifelengthViewerAStartFrom.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerAStartFrom.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerAStartFrom.HeaderCalendar = "Calendar";
			this.lifelengthViewerAStartFrom.HeaderCycles = "Cycles";
			this.lifelengthViewerAStartFrom.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerAStartFrom.HeaderHours = "Hours";
			this.lifelengthViewerAStartFrom.HoursApplicable = false;
			this.lifelengthViewerAStartFrom.LeftHeader = "A";
			this.lifelengthViewerAStartFrom.Location = new System.Drawing.Point(622, 394);
			this.lifelengthViewerAStartFrom.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerAStartFrom.Modified = false;
			this.lifelengthViewerAStartFrom.Name = "lifelengthViewerAStartFrom";
			this.lifelengthViewerAStartFrom.ReadOnly = false;
			this.lifelengthViewerAStartFrom.ShowCalendar = true;
			this.lifelengthViewerAStartFrom.ShowFormattedCalendar = false;
			this.lifelengthViewerAStartFrom.ShowMinutes = true;
			this.lifelengthViewerAStartFrom.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewerAStartFrom.SystemCalculated = true;
			this.lifelengthViewerAStartFrom.TabIndex = 152;
			this.lifelengthViewerAStartFrom.Visible = false;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(5, 645);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowAddNew = false;
			this.dataGridViewControlSuppliers.ShowDelete = false;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(1181, 70);
			this.dataGridViewControlSuppliers.TabIndex = 151;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(113, 344);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(251, 45);
			this.documentControl1.TabIndex = 146;
			// 
			// lifelengthViewer5
			// 
			this.lifelengthViewer5.AutoSize = true;
			this.lifelengthViewer5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer5.CalendarApplicable = false;
			this.lifelengthViewer5.CyclesApplicable = false;
			this.lifelengthViewer5.EnabledCalendar = false;
			this.lifelengthViewer5.EnabledCycle = true;
			this.lifelengthViewer5.EnabledHours = false;
			this.lifelengthViewer5.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer5.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer5.HeaderCalendar = "Calendar";
			this.lifelengthViewer5.HeaderCycles = "Cycles";
			this.lifelengthViewer5.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer5.HeaderHours = "Hours";
			this.lifelengthViewer5.HoursApplicable = false;
			this.lifelengthViewer5.LeftHeader = "D";
			this.lifelengthViewer5.Location = new System.Drawing.Point(8, 555);
			this.lifelengthViewer5.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer5.Modified = false;
			this.lifelengthViewer5.Name = "lifelengthViewer5";
			this.lifelengthViewer5.ReadOnly = false;
			this.lifelengthViewer5.ShowCalendar = true;
			this.lifelengthViewer5.ShowFormattedCalendar = false;
			this.lifelengthViewer5.ShowMinutes = true;
			this.lifelengthViewer5.Size = new System.Drawing.Size(377, 52);
			this.lifelengthViewer5.SystemCalculated = true;
			this.lifelengthViewer5.TabIndex = 145;
			this.lifelengthViewer5.Visible = false;
			// 
			// lifelengthViewer4
			// 
			this.lifelengthViewer4.AutoSize = true;
			this.lifelengthViewer4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer4.CalendarApplicable = false;
			this.lifelengthViewer4.CyclesApplicable = false;
			this.lifelengthViewer4.EnabledCalendar = false;
			this.lifelengthViewer4.EnabledCycle = true;
			this.lifelengthViewer4.EnabledHours = false;
			this.lifelengthViewer4.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer4.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer4.HeaderCalendar = "Calendar";
			this.lifelengthViewer4.HeaderCycles = "Cycles";
			this.lifelengthViewer4.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer4.HeaderHours = "Hours";
			this.lifelengthViewer4.HoursApplicable = false;
			this.lifelengthViewer4.LeftHeader = "C";
			this.lifelengthViewer4.Location = new System.Drawing.Point(6, 499);
			this.lifelengthViewer4.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer4.Modified = false;
			this.lifelengthViewer4.Name = "lifelengthViewer4";
			this.lifelengthViewer4.ReadOnly = false;
			this.lifelengthViewer4.ShowCalendar = true;
			this.lifelengthViewer4.ShowFormattedCalendar = false;
			this.lifelengthViewer4.ShowMinutes = true;
			this.lifelengthViewer4.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewer4.SystemCalculated = true;
			this.lifelengthViewer4.TabIndex = 144;
			this.lifelengthViewer4.Visible = false;
			// 
			// lifelengthViewer3
			// 
			this.lifelengthViewer3.AutoSize = true;
			this.lifelengthViewer3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer3.CalendarApplicable = false;
			this.lifelengthViewer3.CyclesApplicable = false;
			this.lifelengthViewer3.EnabledCalendar = false;
			this.lifelengthViewer3.EnabledCycle = true;
			this.lifelengthViewer3.EnabledHours = false;
			this.lifelengthViewer3.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer3.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer3.HeaderCalendar = "Calendar";
			this.lifelengthViewer3.HeaderCycles = "Cycles";
			this.lifelengthViewer3.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer3.HeaderHours = "Hours";
			this.lifelengthViewer3.HoursApplicable = false;
			this.lifelengthViewer3.LeftHeader = "B";
			this.lifelengthViewer3.Location = new System.Drawing.Point(6, 443);
			this.lifelengthViewer3.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer3.Modified = false;
			this.lifelengthViewer3.Name = "lifelengthViewer3";
			this.lifelengthViewer3.ReadOnly = false;
			this.lifelengthViewer3.ShowCalendar = true;
			this.lifelengthViewer3.ShowFormattedCalendar = false;
			this.lifelengthViewer3.ShowMinutes = true;
			this.lifelengthViewer3.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewer3.SystemCalculated = true;
			this.lifelengthViewer3.TabIndex = 143;
			this.lifelengthViewer3.Visible = false;
			// 
			// lifelengthViewer2
			// 
			this.lifelengthViewer2.AutoSize = true;
			this.lifelengthViewer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer2.CalendarApplicable = false;
			this.lifelengthViewer2.CyclesApplicable = false;
			this.lifelengthViewer2.EnabledCalendar = false;
			this.lifelengthViewer2.EnabledCycle = true;
			this.lifelengthViewer2.EnabledHours = false;
			this.lifelengthViewer2.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer2.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer2.HeaderCalendar = "Calendar";
			this.lifelengthViewer2.HeaderCycles = "Cycles";
			this.lifelengthViewer2.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer2.HeaderHours = "Hours";
			this.lifelengthViewer2.HoursApplicable = false;
			this.lifelengthViewer2.LeftHeader = "A";
			this.lifelengthViewer2.Location = new System.Drawing.Point(6, 394);
			this.lifelengthViewer2.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer2.Modified = false;
			this.lifelengthViewer2.Name = "lifelengthViewer2";
			this.lifelengthViewer2.ReadOnly = false;
			this.lifelengthViewer2.ShowCalendar = true;
			this.lifelengthViewer2.ShowFormattedCalendar = false;
			this.lifelengthViewer2.ShowMinutes = true;
			this.lifelengthViewer2.Size = new System.Drawing.Size(376, 52);
			this.lifelengthViewer2.SystemCalculated = true;
			this.lifelengthViewer2.TabIndex = 142;
			this.lifelengthViewer2.Visible = false;
			// 
			// fileControlImage
			// 
			this.fileControlImage.AutoSize = true;
			this.fileControlImage.Description1 = "";
			this.fileControlImage.Description2 = "";
			this.fileControlImage.Filter = null;
			this.fileControlImage.Icon = global::CAS.UI.Properties.Resources.ImageIcon_Small;
			this.fileControlImage.IconNotEnabled = global::CAS.UI.Properties.Resources.ImageIcon_Small_Gray;
			this.fileControlImage.Location = new System.Drawing.Point(539, 322);
			this.fileControlImage.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlImage.Name = "fileControlImage";
			this.fileControlImage.ShowLinkLabelBrowse = true;
			this.fileControlImage.ShowLinkLabelRemove = false;
			this.fileControlImage.Size = new System.Drawing.Size(250, 37);
			this.fileControlImage.TabIndex = 141;
			// 
			// fileControlShipping
			// 
			this.fileControlShipping.AutoSize = true;
			this.fileControlShipping.Description1 = "";
			this.fileControlShipping.Description2 = "";
			this.fileControlShipping.Filter = null;
			this.fileControlShipping.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlShipping.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlShipping.Location = new System.Drawing.Point(113, 352);
			this.fileControlShipping.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlShipping.Name = "fileControlShipping";
			this.fileControlShipping.ShowLinkLabelBrowse = true;
			this.fileControlShipping.ShowLinkLabelRemove = false;
			this.fileControlShipping.Size = new System.Drawing.Size(250, 37);
			this.fileControlShipping.TabIndex = 139;
			this.fileControlShipping.Visible = false;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(113, 288);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(249, 21);
			this.dictionaryComboBoxLocation.TabIndex = 98;
			this.dictionaryComboBoxLocation.Visible = false;
			// 
			// comboBoxComponentType
			// 
			this.comboBoxComponentType.Displayer = null;
			this.comboBoxComponentType.DisplayerText = null;
			this.comboBoxComponentType.DropDownHeight = 106;
			this.comboBoxComponentType.Entity = null;
			this.comboBoxComponentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxComponentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxComponentType.Location = new System.Drawing.Point(937, 62);
			this.comboBoxComponentType.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxComponentType.Name = "comboBoxComponentType";
			this.comboBoxComponentType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxComponentType.RootNodesNames = null;
			this.comboBoxComponentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxComponentType.TabIndex = 25;
			this.comboBoxComponentType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxComponentTypeSelectedIndexChanged);
			// 
			// comboBoxAtaChapter
			// 
			this.comboBoxAtaChapter.BackColor = System.Drawing.Color.White;
			this.comboBoxAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxAtaChapter.FormattingEnabled = true;
			this.comboBoxAtaChapter.Location = new System.Drawing.Point(537, 117);
			this.comboBoxAtaChapter.Name = "comboBoxAtaChapter";
			this.comboBoxAtaChapter.Size = new System.Drawing.Size(250, 22);
			this.comboBoxAtaChapter.TabIndex = 12;
			// 
			// lifelengthNotify
			// 
			this.lifelengthNotify.AutoSize = true;
			this.lifelengthNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthNotify.CalendarApplicable = false;
			this.lifelengthNotify.CyclesApplicable = false;
			this.lifelengthNotify.Enabled = false;
			this.lifelengthNotify.EnabledCalendar = true;
			this.lifelengthNotify.EnabledCycle = true;
			this.lifelengthNotify.EnabledHours = true;
			this.lifelengthNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lifelengthNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthNotify.HeaderCalendar = "Calendar";
			this.lifelengthNotify.HeaderCycles = "Cycles";
			this.lifelengthNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthNotify.HeaderHours = "Hours";
			this.lifelengthNotify.HoursApplicable = false;
			this.lifelengthNotify.LeftHeader = "Left";
			this.lifelengthNotify.Location = new System.Drawing.Point(816, 254);
			this.lifelengthNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthNotify.Modified = false;
			this.lifelengthNotify.Name = "lifelengthNotify";
			this.lifelengthNotify.ReadOnly = false;
			this.lifelengthNotify.ShowCalendar = true;
			this.lifelengthNotify.ShowFormattedCalendar = false;
			this.lifelengthNotify.ShowLeftHeader = false;
			this.lifelengthNotify.ShowMinutes = false;
			this.lifelengthNotify.Size = new System.Drawing.Size(421, 67);
			this.lifelengthNotify.SystemCalculated = true;
			this.lifelengthNotify.TabIndex = 54;
			// 
			// lifelengthViewer1
			// 
			this.lifelengthViewer1.AutoSize = true;
			this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer1.CalendarApplicable = false;
			this.lifelengthViewer1.CyclesApplicable = false;
			this.lifelengthViewer1.Enabled = false;
			this.lifelengthViewer1.EnabledCalendar = true;
			this.lifelengthViewer1.EnabledCycle = true;
			this.lifelengthViewer1.EnabledHours = true;
			this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer1.HeaderCalendar = "Calendar";
			this.lifelengthViewer1.HeaderCycles = "Cycles";
			this.lifelengthViewer1.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer1.HeaderHours = "Hours";
			this.lifelengthViewer1.HoursApplicable = false;
			this.lifelengthViewer1.LeftHeader = "Left";
			this.lifelengthViewer1.Location = new System.Drawing.Point(816, 466);
			this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewer1.Modified = false;
			this.lifelengthViewer1.Name = "lifelengthViewer1";
			this.lifelengthViewer1.ReadOnly = false;
			this.lifelengthViewer1.ShowCalendar = true;
			this.lifelengthViewer1.ShowFormattedCalendar = false;
			this.lifelengthViewer1.ShowLeftHeader = false;
			this.lifelengthViewer1.ShowMinutes = false;
			this.lifelengthViewer1.Size = new System.Drawing.Size(421, 67);
			this.lifelengthViewer1.SystemCalculated = true;
			this.lifelengthViewer1.TabIndex = 62;
			// 
			// labelAltPartNum
			// 
			this.labelAltPartNum.AutoSize = true;
			this.labelAltPartNum.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAltPartNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAltPartNum.Location = new System.Drawing.Point(3, 123);
			this.labelAltPartNum.Name = "labelAltPartNum";
			this.labelAltPartNum.Size = new System.Drawing.Size(76, 14);
			this.labelAltPartNum.TabIndex = 173;
			this.labelAltPartNum.Text = "Alt Part №:";
			this.labelAltPartNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAltPartNum
			// 
			this.textBoxAltPartNum.BackColor = System.Drawing.Color.White;
			this.textBoxAltPartNum.Enabled = false;
			this.textBoxAltPartNum.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxAltPartNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAltPartNum.Location = new System.Drawing.Point(113, 118);
			this.textBoxAltPartNum.MaxLength = 100;
			this.textBoxAltPartNum.Name = "textBoxAltPartNum";
			this.textBoxAltPartNum.Size = new System.Drawing.Size(249, 22);
			this.textBoxAltPartNum.TabIndex = 174;
			// 
			// textBoxModel
			// 
			this.textBoxModel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxModel.Location = new System.Drawing.Point(112, 6);
			this.textBoxModel.MaxLength = 200;
			this.textBoxModel.Name = "textBoxModel";
			this.textBoxModel.Size = new System.Drawing.Size(537, 22);
			this.textBoxModel.TabIndex = 175;
			// 
			// linkLabel2
			// 
			this.linkLabel2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel2.Location = new System.Drawing.Point(737, 5);
			this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(50, 23);
			this.linkLabel2.TabIndex = 197;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Clear";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel1.Location = new System.Drawing.Point(699, 5);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(37, 23);
			this.linkLabel1.TabIndex = 196;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Edit";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
			// 
			// linkLabelEditComponents
			// 
			this.linkLabelEditComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditComponents.Location = new System.Drawing.Point(649, 5);
			this.linkLabelEditComponents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditComponents.Name = "linkLabelEditComponents";
			this.linkLabelEditComponents.Size = new System.Drawing.Size(48, 23);
			this.linkLabelEditComponents.TabIndex = 195;
			this.linkLabelEditComponents.TabStop = true;
			this.linkLabelEditComponents.Text = "Bind";
			this.linkLabelEditComponents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditComponents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditComponents_LinkClicked);
			// 
			// ComponentGeneralInformationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.linkLabelEditComponents);
			this.Controls.Add(this.textBoxModel);
			this.Controls.Add(this.labelAltPartNum);
			this.Controls.Add(this.textBoxAltPartNum);
			this.Controls.Add(groupBoxStart);
			this.Controls.Add(this.labelCheck);
			this.Controls.Add(this.radioButtonD);
			this.Controls.Add(this.radioButtonC);
			this.Controls.Add(this.radioButtonB);
			this.Controls.Add(this.radioButtonA);
			this.Controls.Add(this.delimiter4);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.dateTimePickerDStartFrom);
			this.Controls.Add(this.dateTimePickerCStartFrom);
			this.Controls.Add(this.dateTimePickerBStartFrom);
			this.Controls.Add(this.dateTimePickerAStartFrom);
			this.Controls.Add(this.labelDStartFrom);
			this.Controls.Add(this.labelCStartFrom);
			this.Controls.Add(this.labelBStartFrom);
			this.Controls.Add(this.labelAStartFrom);
			this.Controls.Add(this.lifelengthViewerDStartFrom);
			this.Controls.Add(this.lifelengthViewerCStartFrom);
			this.Controls.Add(this.lifelengthViewerBStartFrom);
			this.Controls.Add(this.lifelengthViewerAStartFrom);
			this.Controls.Add(this.dataGridViewControlSuppliers);
			this.Controls.Add(this.labelSupplier);
			this.Controls.Add(this.dateTimePickerReciveDate);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.lifelengthViewer5);
			this.Controls.Add(this.lifelengthViewer4);
			this.Controls.Add(this.lifelengthViewer3);
			this.Controls.Add(this.lifelengthViewer2);
			this.Controls.Add(this.fileControlImage);
			this.Controls.Add(this.labelImage);
			this.Controls.Add(this.fileControlShipping);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkBoxIncoming);
			this.Controls.Add(this.textBoxDiscrepancy);
			this.Controls.Add(this.labelDiscrepancy);
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.labelProductCode);
			this.Controls.Add(this.textBoxProductCode);
			this.Controls.Add(this.checkBoxDangerous);
			this.Controls.Add(this.checkBoxPOOL);
			this.Controls.Add(this.labelThrust);
			this.Controls.Add(this.textBoxThrust);
			this.Controls.Add(this.labelBatchNumber);
			this.Controls.Add(this.textBoxBatchNumber);
			this.Controls.Add(this.labelIdNumber);
			this.Controls.Add(this.textBoxIdNumber);
			this.Controls.Add(this.labelLocation);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.comboBoxComponentType);
			this.Controls.Add(this.labelComponentType);
			this.Controls.Add(this.comboBoxMaintProc);
			this.Controls.Add(this.labelModel);
			this.Controls.Add(this.numericUpDownQuantity);
			this.Controls.Add(this.checkBoxLLPCategories);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.checkBoxLLPMark);
			this.Controls.Add(this.comboBoxAtaChapter);
			this.Controls.Add(this.panelLandingGearMark);
			this.Controls.Add(this.comboBoxStorePosition);
			this.Controls.Add(this.textBoxMPDItem);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.labelDeliverDate);
			this.Controls.Add(this.textBoxSerialNo);
			this.Controls.Add(this.dateTimePickerDeliveryDate);
			this.Controls.Add(this.labelPartNo);
			this.Controls.Add(this.textBoxPartNo);
			this.Controls.Add(this.labelSerialNo);
			this.Controls.Add(this.textBoxManufacturer);
			this.Controls.Add(this.labelMPDItem);
			this.Controls.Add(this.labelMaintFreq);
			this.Controls.Add(this.textBoxALTPN);
			this.Controls.Add(this.dateTimePickerManufactureDate);
			this.Controls.Add(this.labelAtaChapter);
			this.Controls.Add(this.labelInstallationDate);
			this.Controls.Add(this.labelALTPN);
			this.Controls.Add(this.dateTimePickerInstallationDate);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.labelManufactureDate);
			this.Controls.Add(this.panelAvionicsInventory);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.checkBoxAvionicsInventory);
			this.Controls.Add(this.labelMaxTakeOffWeight);
			this.Controls.Add(this.textBoxMaxTakeOffWeight);
			this.Controls.Add(this.labelHushKit);
			this.Controls.Add(this.textBoxHushKit);
			this.Name = "ComponentGeneralInformationControl";
			this.Size = new System.Drawing.Size(1195, 718);
			groupBoxStart.ResumeLayout(false);
			groupBoxStart.PerformLayout();
			this.panelAvionicsInventory.ResumeLayout(false);
			this.panelAvionicsInventory.PerformLayout();
			this.panelLandingGearMark.ResumeLayout(false);
			this.panelLandingGearMark.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAtaChapter;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelMaintFreq;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelPartNo;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelSerialNo;
        private System.Windows.Forms.Label labelMPDItem;
        private System.Windows.Forms.Label labelManufactureDate;
        private System.Windows.Forms.Label labelInstallationDate;
        private System.Windows.Forms.Label labelMaxTakeOffWeight;
        private System.Windows.Forms.CheckBox checkBoxAvionicsInventory;
        private System.Windows.Forms.Label labelHushKit;
        private System.Windows.Forms.Label labelALTPN;

        private System.Windows.Forms.TextBox textBoxALTPN;
        private System.Windows.Forms.TextBox textBoxHushKit;
        private System.Windows.Forms.Panel panelAvionicsInventory;
        private System.Windows.Forms.RadioButton radioButtonInventoryOptional;
        private System.Windows.Forms.RadioButton radioButtonInventoryRequired;
        private System.Windows.Forms.RadioButton radioButtonAvionicsInventoryUnknown;
        private ATAChapterComboBox comboBoxAtaChapter;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxPartNo;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.Panel panelLandingGearMark;
        private System.Windows.Forms.RadioButton radioButtonLLG;
        private System.Windows.Forms.RadioButton radioButtonNLG;
        private System.Windows.Forms.RadioButton radioButtonRLG;
        private System.Windows.Forms.TextBox textBoxSerialNo;
        private System.Windows.Forms.TextBox textBoxMPDItem;
        private System.Windows.Forms.TextBox textBoxMaxTakeOffWeight;
        private System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstallationDate;
        private System.Windows.Forms.Label labelCurrentTSNCSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private LifelengthViewer lifelengthNotify;
        private System.Windows.Forms.Label labelNotify;
        private System.Windows.Forms.Label labelDeliverDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private LifelengthViewer lifelengthViewer1;
        private System.Windows.Forms.ComboBox comboBoxStorePosition;
        private System.Windows.Forms.CheckBox checkBoxLLPMark;
        private System.Windows.Forms.CheckBox checkBoxLLPCategories;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.ComboBox comboBoxMaintProc;
        private System.Windows.Forms.Label labelComponentType;
        private TreeDictionaryComboBox comboBoxComponentType;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelBatchNumber;
        private System.Windows.Forms.TextBox textBoxBatchNumber;
        private System.Windows.Forms.Label labelIdNumber;
        private System.Windows.Forms.TextBox textBoxIdNumber;
        private System.Windows.Forms.Label labelThrust;
        private System.Windows.Forms.TextBox textBoxThrust;
        private System.Windows.Forms.CheckBox checkBoxDangerous;
        private System.Windows.Forms.CheckBox checkBoxPOOL;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
		private DictionaryComboBox dictionaryComboBoxLocation;
		private System.Windows.Forms.Label labelDiscrepancy;
		private System.Windows.Forms.TextBox textBoxDiscrepancy;
		private System.Windows.Forms.CheckBox checkBoxIncoming;
		private System.Windows.Forms.Label label2;
		private AttachedFileControl fileControlShipping;
		private AttachedFileControl fileControlImage;
		private System.Windows.Forms.Label labelImage;
		private LifelengthViewer lifelengthViewer2;
		private LifelengthViewer lifelengthViewer3;
		private LifelengthViewer lifelengthViewer4;
		private LifelengthViewer lifelengthViewer5;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.DateTimePicker dateTimePickerReciveDate;
		private CommonDataGridViewControl dataGridViewControlSuppliers;
		private System.Windows.Forms.Label labelSupplier;
		private LifelengthViewer lifelengthViewerAStartFrom;
		private LifelengthViewer lifelengthViewerBStartFrom;
		private LifelengthViewer lifelengthViewerCStartFrom;
		private LifelengthViewer lifelengthViewerDStartFrom;
		private System.Windows.Forms.Label labelAStartFrom;
		private System.Windows.Forms.Label labelBStartFrom;
		private System.Windows.Forms.Label labelCStartFrom;
		private System.Windows.Forms.Label labelDStartFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerAStartFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerBStartFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerCStartFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerDStartFrom;
		private Delimiter delimiter1;
		private Delimiter delimiter2;
		private Delimiter delimiter3;
		private Delimiter delimiter4;
		private System.Windows.Forms.RadioButton radioButtonA;
		private System.Windows.Forms.RadioButton radioButtonB;
		private System.Windows.Forms.RadioButton radioButtonC;
		private System.Windows.Forms.RadioButton radioButtonD;
		private System.Windows.Forms.Label labelCheck;
		private LifelengthViewer lifelengthViewerStart;
		private System.Windows.Forms.DateTimePicker dateTimePickerStart;
		private System.Windows.Forms.Label labelAltPartNum;
		private System.Windows.Forms.TextBox textBoxAltPartNum;
		private System.Windows.Forms.GroupBox groupBoxStart;
		private System.Windows.Forms.TextBox textBoxModel;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabelEditComponents;
	}
}
