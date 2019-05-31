using MetroFramework.Controls;

namespace CAS.UI.UIControls.StoresControls
{
    partial class ComponentForm
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

            comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;
            comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
            comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;
            dateTimePickerInstallDate.ValueChanged -= DateTimePickerInstallationDateValueChanged;
            dateTimePickerManufactureDate.ValueChanged -= DateTimePickerManufactureDateValueChanged;
            numericUpDownQuantity.ValueChanged -= NumericUpDownQuantityValueChanged;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentForm));
			this.labelInstallDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerInstallDate = new System.Windows.Forms.DateTimePicker();
			this.labelManufactureDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelLocation = new MetroFramework.Controls.MetroLabel();
			this.comboBoxPosition = new System.Windows.Forms.ComboBox();
			this.labelPosition = new MetroFramework.Controls.MetroLabel();
			this.labelBatchNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxBatchNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelIdNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxIdNumber = new MetroFramework.Controls.MetroTextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelType = new MetroFramework.Controls.MetroLabel();
			this.labelSerialNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxSerialNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.labelSeparator = new MetroFramework.Controls.MetroLabel();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelProduct = new MetroFramework.Controls.MetroLabel();
			this.labelSupplier = new MetroFramework.Controls.MetroLabel();
			this.labelStandart = new MetroFramework.Controls.MetroLabel();
			this.labelManufacturer = new MetroFramework.Controls.MetroLabel();
			this.textBoxManufacturer = new MetroFramework.Controls.MetroTextBox();
			this.labelProductCode = new MetroFramework.Controls.MetroLabel();
			this.textBoxProductCode = new MetroFramework.Controls.MetroTextBox();
			this.buttonSaveAndAdd = new System.Windows.Forms.Button();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.labelStatus = new MetroFramework.Controls.MetroLabel();
			this.labelTotal = new MetroFramework.Controls.MetroLabel();
			this.textBoxTotal = new MetroFramework.Controls.MetroTextBox();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.checkBoxIncoming = new MetroFramework.Controls.MetroCheckBox();
			this.labelDiscrepancy = new MetroFramework.Controls.MetroLabel();
			this.textBoxDiscrepancy = new MetroFramework.Controls.MetroTextBox();
			this.labelFaaForm = new MetroFramework.Controls.MetroLabel();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.labelIamge = new MetroFramework.Controls.MetroLabel();
			this.fileControlImage = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.comboBoxStandart = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarrantyNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.checkBoxDangerous = new MetroFramework.Controls.MetroCheckBox();
			this.checkBoxPOOL = new MetroFramework.Controls.MetroCheckBox();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.dateTimePickerReciveDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.labelAltpartNum = new MetroFramework.Controls.MetroLabel();
			this.textBoxAltPartNum = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxReceived = new System.Windows.Forms.ComboBox();
			this.metroLabelReceived = new MetroFramework.Controls.MetroLabel();
			this.documentControlFaa = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControlShip = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.metroLabelPacking = new MetroFramework.Controls.MetroLabel();
			this.metroTextBoxPacking = new MetroFramework.Controls.MetroTextBox();
			this.linkLabelEditComponents = new System.Windows.Forms.LinkLabel();
			this.TextBoxProduct = new MetroFramework.Controls.MetroTextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.metroLabelEffectivity = new MetroFramework.Controls.MetroLabel();
			this.metroTextBoxEffectivity = new MetroFramework.Controls.MetroTextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// labelInstallDate
			// 
			this.labelInstallDate.AutoSize = true;
			this.labelInstallDate.ForeColor = System.Drawing.Color.Black;
			this.labelInstallDate.Location = new System.Drawing.Point(619, 254);
			this.labelInstallDate.Name = "labelInstallDate";
			this.labelInstallDate.Size = new System.Drawing.Size(78, 19);
			this.labelInstallDate.TabIndex = 103;
			this.labelInstallDate.Text = "Install. Date:";
			this.labelInstallDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerInstallDate
			// 
			this.dateTimePickerInstallDate.BackColor = System.Drawing.Color.White;
			this.dateTimePickerInstallDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerInstallDate.ForeColor = System.Drawing.Color.Black;
			this.dateTimePickerInstallDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerInstallDate.Location = new System.Drawing.Point(706, 254);
			this.dateTimePickerInstallDate.Name = "dateTimePickerInstallDate";
			this.dateTimePickerInstallDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerInstallDate.TabIndex = 14;
			this.dateTimePickerInstallDate.ValueChanged += new System.EventHandler(this.DateTimePickerInstallationDateValueChanged);
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.ForeColor = System.Drawing.Color.Black;
			this.labelManufactureDate.Location = new System.Drawing.Point(619, 226);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(82, 19);
			this.labelManufactureDate.TabIndex = 101;
			this.labelManufactureDate.Text = "Manuf. Date:";
			this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerManufactureDate
			// 
			this.dateTimePickerManufactureDate.BackColor = System.Drawing.Color.White;
			this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.Black;
			this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(706, 226);
			this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
			this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerManufactureDate.TabIndex = 13;
			this.dateTimePickerManufactureDate.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(410, 279);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(200, 21);
			this.comboBoxMeasure.TabIndex = 7;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.ForeColor = System.Drawing.Color.Black;
			this.labelLocation.Location = new System.Drawing.Point(324, 252);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.Size = new System.Drawing.Size(61, 19);
			this.labelLocation.TabIndex = 98;
			this.labelLocation.Text = "Location:";
			this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxPosition
			// 
			this.comboBoxPosition.FormattingEnabled = true;
			this.comboBoxPosition.Location = new System.Drawing.Point(410, 223);
			this.comboBoxPosition.Name = "comboBoxPosition";
			this.comboBoxPosition.Size = new System.Drawing.Size(200, 21);
			this.comboBoxPosition.TabIndex = 3;
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.ForeColor = System.Drawing.Color.Black;
			this.labelPosition.Location = new System.Drawing.Point(324, 223);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(41, 19);
			this.labelPosition.TabIndex = 96;
			this.labelPosition.Text = "State:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBatchNumber
			// 
			this.labelBatchNumber.AutoSize = true;
			this.labelBatchNumber.ForeColor = System.Drawing.Color.Black;
			this.labelBatchNumber.Location = new System.Drawing.Point(13, 223);
			this.labelBatchNumber.Name = "labelBatchNumber";
			this.labelBatchNumber.Size = new System.Drawing.Size(98, 19);
			this.labelBatchNumber.TabIndex = 92;
			this.labelBatchNumber.Text = "Batch Number:";
			this.labelBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxBatchNumber
			// 
			this.textBoxBatchNumber.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxBatchNumber.CustomButton.Image = null;
			this.textBoxBatchNumber.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxBatchNumber.CustomButton.Name = "";
			this.textBoxBatchNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxBatchNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxBatchNumber.CustomButton.TabIndex = 1;
			this.textBoxBatchNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxBatchNumber.CustomButton.UseSelectable = true;
			this.textBoxBatchNumber.CustomButton.Visible = false;
			this.textBoxBatchNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxBatchNumber.Lines = new string[0];
			this.textBoxBatchNumber.Location = new System.Drawing.Point(118, 223);
			this.textBoxBatchNumber.MaxLength = 128;
			this.textBoxBatchNumber.Name = "textBoxBatchNumber";
			this.textBoxBatchNumber.PasswordChar = '\0';
			this.textBoxBatchNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxBatchNumber.SelectedText = "";
			this.textBoxBatchNumber.SelectionLength = 0;
			this.textBoxBatchNumber.SelectionStart = 0;
			this.textBoxBatchNumber.ShortcutsEnabled = true;
			this.textBoxBatchNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxBatchNumber.TabIndex = 6;
			this.textBoxBatchNumber.UseSelectable = true;
			this.textBoxBatchNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxBatchNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelIdNumber
			// 
			this.labelIdNumber.AutoSize = true;
			this.labelIdNumber.ForeColor = System.Drawing.Color.Black;
			this.labelIdNumber.Location = new System.Drawing.Point(13, 250);
			this.labelIdNumber.Name = "labelIdNumber";
			this.labelIdNumber.Size = new System.Drawing.Size(78, 19);
			this.labelIdNumber.TabIndex = 94;
			this.labelIdNumber.Text = "ID Number:";
			this.labelIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIdNumber
			// 
			this.textBoxIdNumber.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxIdNumber.CustomButton.Image = null;
			this.textBoxIdNumber.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxIdNumber.CustomButton.Name = "";
			this.textBoxIdNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxIdNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxIdNumber.CustomButton.TabIndex = 1;
			this.textBoxIdNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxIdNumber.CustomButton.UseSelectable = true;
			this.textBoxIdNumber.CustomButton.Visible = false;
			this.textBoxIdNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxIdNumber.Lines = new string[0];
			this.textBoxIdNumber.Location = new System.Drawing.Point(118, 250);
			this.textBoxIdNumber.MaxLength = 128;
			this.textBoxIdNumber.Name = "textBoxIdNumber";
			this.textBoxIdNumber.PasswordChar = '\0';
			this.textBoxIdNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxIdNumber.SelectedText = "";
			this.textBoxIdNumber.SelectionLength = 0;
			this.textBoxIdNumber.SelectionStart = 0;
			this.textBoxIdNumber.ShortcutsEnabled = true;
			this.textBoxIdNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxIdNumber.TabIndex = 8;
			this.textBoxIdNumber.UseSelectable = true;
			this.textBoxIdNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxIdNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(748, 715);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 20;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(827, 715);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(706, 147);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(200, 20);
			this.numericUpDownQuantity.TabIndex = 9;
			this.numericUpDownQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.NumericUpDownQuantityValueChanged);
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.ForeColor = System.Drawing.Color.Black;
			this.labelType.Location = new System.Drawing.Point(324, 196);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(41, 19);
			this.labelType.TabIndex = 76;
			this.labelType.Text = "Class:";
			this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.AutoSize = true;
			this.labelSerialNumber.ForeColor = System.Drawing.Color.Black;
			this.labelSerialNumber.Location = new System.Drawing.Point(13, 196);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(98, 19);
			this.labelSerialNumber.TabIndex = 77;
			this.labelSerialNumber.Text = "Serial Number:";
			this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSerialNumber
			// 
			this.textBoxSerialNumber.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxSerialNumber.CustomButton.Image = null;
			this.textBoxSerialNumber.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxSerialNumber.CustomButton.Name = "";
			this.textBoxSerialNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxSerialNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSerialNumber.CustomButton.TabIndex = 1;
			this.textBoxSerialNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSerialNumber.CustomButton.UseSelectable = true;
			this.textBoxSerialNumber.CustomButton.Visible = false;
			this.textBoxSerialNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxSerialNumber.Lines = new string[0];
			this.textBoxSerialNumber.Location = new System.Drawing.Point(118, 197);
			this.textBoxSerialNumber.MaxLength = 128;
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.PasswordChar = '\0';
			this.textBoxSerialNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSerialNumber.SelectedText = "";
			this.textBoxSerialNumber.SelectionLength = 0;
			this.textBoxSerialNumber.SelectionStart = 0;
			this.textBoxSerialNumber.ShortcutsEnabled = true;
			this.textBoxSerialNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxSerialNumber.TabIndex = 4;
			this.textBoxSerialNumber.UseSelectable = true;
			this.textBoxSerialNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSerialNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.AutoSize = true;
			this.labelPartNumber.ForeColor = System.Drawing.Color.Black;
			this.labelPartNumber.Location = new System.Drawing.Point(13, 145);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(90, 19);
			this.labelPartNumber.TabIndex = 79;
			this.labelPartNumber.Text = "Part Number:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxPartNumber.CustomButton.Image = null;
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxPartNumber.CustomButton.Name = "";
			this.textBoxPartNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPartNumber.CustomButton.TabIndex = 1;
			this.textBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPartNumber.CustomButton.UseSelectable = true;
			this.textBoxPartNumber.CustomButton.Visible = false;
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxPartNumber.Lines = new string[0];
			this.textBoxPartNumber.Location = new System.Drawing.Point(118, 145);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxPartNumber.TabIndex = 2;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.ForeColor = System.Drawing.Color.Black;
			this.labelDescription.Location = new System.Drawing.Point(13, 334);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(77, 19);
			this.labelDescription.TabIndex = 81;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(120, 1);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(79, 79);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.Black;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(118, 334);
			this.textBoxDescription.MaxLength = 256;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(200, 81);
			this.textBoxDescription.TabIndex = 10;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.ForeColor = System.Drawing.Color.Black;
			this.labelMeasure.Location = new System.Drawing.Point(324, 279);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 83;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.ForeColor = System.Drawing.Color.Black;
			this.labelQuantity.Location = new System.Drawing.Point(619, 147);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(75, 19);
			this.labelQuantity.TabIndex = 84;
			this.labelQuantity.Text = "Quantity In:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeparator
			// 
			this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelSeparator.Location = new System.Drawing.Point(22, 607);
			this.labelSeparator.Name = "labelSeparator";
			this.labelSeparator.Size = new System.Drawing.Size(880, 1);
			this.labelSeparator.TabIndex = 85;
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.ForeColor = System.Drawing.Color.Black;
			this.labelRemarks.Location = new System.Drawing.Point(324, 334);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(62, 19);
			this.labelRemarks.TabIndex = 86;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(121, 1);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(79, 79);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.Black;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(410, 334);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(201, 81);
			this.textBoxRemarks.TabIndex = 11;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Location = new System.Drawing.Point(13, 64);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(50, 19);
			this.labelProduct.TabIndex = 105;
			this.labelProduct.Text = "Model:";
			// 
			// labelSupplier
			// 
			this.labelSupplier.AutoSize = true;
			this.labelSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelSupplier.Location = new System.Drawing.Point(437, 520);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(111, 19);
			this.labelSupplier.TabIndex = 108;
			this.labelSupplier.Text = "PRODUCT COST:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStandart
			// 
			this.labelStandart.Location = new System.Drawing.Point(13, 115);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 25);
			this.labelStandart.TabIndex = 110;
			this.labelStandart.Text = "Standart:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.ForeColor = System.Drawing.Color.Black;
			this.labelManufacturer.Location = new System.Drawing.Point(13, 305);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(91, 19);
			this.labelManufacturer.TabIndex = 118;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxManufacturer.CustomButton.Image = null;
			this.textBoxManufacturer.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxManufacturer.CustomButton.Name = "";
			this.textBoxManufacturer.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxManufacturer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxManufacturer.CustomButton.TabIndex = 1;
			this.textBoxManufacturer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxManufacturer.CustomButton.UseSelectable = true;
			this.textBoxManufacturer.CustomButton.Visible = false;
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.Black;
			this.textBoxManufacturer.Lines = new string[0];
			this.textBoxManufacturer.Location = new System.Drawing.Point(118, 306);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.PasswordChar = '\0';
			this.textBoxManufacturer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxManufacturer.SelectedText = "";
			this.textBoxManufacturer.SelectionLength = 0;
			this.textBoxManufacturer.SelectionStart = 0;
			this.textBoxManufacturer.ShortcutsEnabled = true;
			this.textBoxManufacturer.Size = new System.Drawing.Size(200, 20);
			this.textBoxManufacturer.TabIndex = 117;
			this.textBoxManufacturer.UseSelectable = true;
			this.textBoxManufacturer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxManufacturer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelProductCode
			// 
			this.labelProductCode.AutoSize = true;
			this.labelProductCode.ForeColor = System.Drawing.Color.Black;
			this.labelProductCode.Location = new System.Drawing.Point(13, 279);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(44, 19);
			this.labelProductCode.TabIndex = 120;
			this.labelProductCode.Text = "Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxProductCode.CustomButton.Image = null;
			this.textBoxProductCode.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxProductCode.CustomButton.Name = "";
			this.textBoxProductCode.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxProductCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxProductCode.CustomButton.TabIndex = 1;
			this.textBoxProductCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxProductCode.CustomButton.UseSelectable = true;
			this.textBoxProductCode.CustomButton.Visible = false;
			this.textBoxProductCode.ForeColor = System.Drawing.Color.Black;
			this.textBoxProductCode.Lines = new string[0];
			this.textBoxProductCode.Location = new System.Drawing.Point(118, 279);
			this.textBoxProductCode.MaxLength = 128;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.PasswordChar = '\0';
			this.textBoxProductCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxProductCode.SelectedText = "";
			this.textBoxProductCode.SelectionLength = 0;
			this.textBoxProductCode.SelectionStart = 0;
			this.textBoxProductCode.ShortcutsEnabled = true;
			this.textBoxProductCode.Size = new System.Drawing.Size(200, 20);
			this.textBoxProductCode.TabIndex = 119;
			this.textBoxProductCode.UseSelectable = true;
			this.textBoxProductCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxProductCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonSaveAndAdd
			// 
			this.buttonSaveAndAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveAndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSaveAndAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonSaveAndAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonSaveAndAdd.Location = new System.Drawing.Point(780, 773);
			this.buttonSaveAndAdd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSaveAndAdd.Name = "buttonSaveAndAdd";
			this.buttonSaveAndAdd.Size = new System.Drawing.Size(128, 27);
			this.buttonSaveAndAdd.TabIndex = 121;
			this.buttonSaveAndAdd.Text = "Save and Add";
			this.buttonSaveAndAdd.Click += new System.EventHandler(this.ButtonSaveAndAddClick);
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(410, 171);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(200, 21);
			this.comboBoxStatus.TabIndex = 122;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.ForeColor = System.Drawing.Color.Black;
			this.labelStatus.Location = new System.Drawing.Point(324, 171);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(46, 19);
			this.labelStatus.TabIndex = 123;
			this.labelStatus.Text = "Status:";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.ForeColor = System.Drawing.Color.Black;
			this.labelTotal.Location = new System.Drawing.Point(619, 199);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(56, 19);
			this.labelTotal.TabIndex = 126;
			this.labelTotal.Text = "Current:";
			this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTotal
			// 
			this.textBoxTotal.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxTotal.CustomButton.Image = null;
			this.textBoxTotal.CustomButton.Location = new System.Drawing.Point(183, 2);
			this.textBoxTotal.CustomButton.Name = "";
			this.textBoxTotal.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTotal.CustomButton.TabIndex = 1;
			this.textBoxTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTotal.CustomButton.UseSelectable = true;
			this.textBoxTotal.CustomButton.Visible = false;
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Lines = new string[0];
			this.textBoxTotal.Location = new System.Drawing.Point(706, 199);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.PasswordChar = '\0';
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTotal.SelectedText = "";
			this.textBoxTotal.SelectionLength = 0;
			this.textBoxTotal.SelectionStart = 0;
			this.textBoxTotal.ShortcutsEnabled = true;
			this.textBoxTotal.Size = new System.Drawing.Size(201, 20);
			this.textBoxTotal.TabIndex = 125;
			this.textBoxTotal.UseSelectable = true;
			this.textBoxTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(324, 147);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 19);
			this.label1.TabIndex = 128;
			this.label1.Text = "ATA:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxIncoming
			// 
			this.checkBoxIncoming.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIncoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIncoming.Location = new System.Drawing.Point(759, 307);
			this.checkBoxIncoming.Name = "checkBoxIncoming";
			this.checkBoxIncoming.Size = new System.Drawing.Size(147, 26);
			this.checkBoxIncoming.TabIndex = 131;
			this.checkBoxIncoming.Text = "Incoming Control";
			this.checkBoxIncoming.UseSelectable = true;
			this.checkBoxIncoming.CheckedChanged += new System.EventHandler(this.checkBoxIncoming_CheckedChanged);
			// 
			// labelDiscrepancy
			// 
			this.labelDiscrepancy.AutoSize = true;
			this.labelDiscrepancy.ForeColor = System.Drawing.Color.Black;
			this.labelDiscrepancy.Location = new System.Drawing.Point(619, 329);
			this.labelDiscrepancy.Name = "labelDiscrepancy";
			this.labelDiscrepancy.Size = new System.Drawing.Size(81, 19);
			this.labelDiscrepancy.TabIndex = 133;
			this.labelDiscrepancy.Text = "Discrepancy:";
			this.labelDiscrepancy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDiscrepancy
			// 
			this.textBoxDiscrepancy.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxDiscrepancy.CustomButton.Image = null;
			this.textBoxDiscrepancy.CustomButton.Location = new System.Drawing.Point(145, 2);
			this.textBoxDiscrepancy.CustomButton.Name = "";
			this.textBoxDiscrepancy.CustomButton.Size = new System.Drawing.Size(53, 53);
			this.textBoxDiscrepancy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDiscrepancy.CustomButton.TabIndex = 1;
			this.textBoxDiscrepancy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDiscrepancy.CustomButton.UseSelectable = true;
			this.textBoxDiscrepancy.CustomButton.Visible = false;
			this.textBoxDiscrepancy.ForeColor = System.Drawing.Color.Black;
			this.textBoxDiscrepancy.Lines = new string[0];
			this.textBoxDiscrepancy.Location = new System.Drawing.Point(706, 329);
			this.textBoxDiscrepancy.MaxLength = 32767;
			this.textBoxDiscrepancy.Multiline = true;
			this.textBoxDiscrepancy.Name = "textBoxDiscrepancy";
			this.textBoxDiscrepancy.PasswordChar = '\0';
			this.textBoxDiscrepancy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDiscrepancy.SelectedText = "";
			this.textBoxDiscrepancy.SelectionLength = 0;
			this.textBoxDiscrepancy.SelectionStart = 0;
			this.textBoxDiscrepancy.ShortcutsEnabled = true;
			this.textBoxDiscrepancy.Size = new System.Drawing.Size(201, 58);
			this.textBoxDiscrepancy.TabIndex = 132;
			this.textBoxDiscrepancy.UseSelectable = true;
			this.textBoxDiscrepancy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDiscrepancy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelFaaForm
			// 
			this.labelFaaForm.AutoSize = true;
			this.labelFaaForm.ForeColor = System.Drawing.Color.Black;
			this.labelFaaForm.Location = new System.Drawing.Point(19, 435);
			this.labelFaaForm.Name = "labelFaaForm";
			this.labelFaaForm.Size = new System.Drawing.Size(72, 19);
			this.labelFaaForm.TabIndex = 135;
			this.labelFaaForm.Text = "FAA Form:";
			this.labelFaaForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(323, 435);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 19);
			this.label4.TabIndex = 137;
			this.label4.Text = "Shipping Doc.:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelIamge
			// 
			this.labelIamge.AutoSize = true;
			this.labelIamge.ForeColor = System.Drawing.Color.Black;
			this.labelIamge.Location = new System.Drawing.Point(618, 435);
			this.labelIamge.Name = "labelIamge";
			this.labelIamge.Size = new System.Drawing.Size(49, 19);
			this.labelIamge.TabIndex = 140;
			this.labelIamge.Text = "Image:";
			this.labelIamge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fileControlImage
			// 
			this.fileControlImage.AutoSize = true;
			this.fileControlImage.Description1 = "";
			this.fileControlImage.Description2 = "";
			this.fileControlImage.Enabled = false;
			this.fileControlImage.Filter = null;
			this.fileControlImage.Icon = global::CAS.UI.Properties.Resources.ImageIcon_Small;
			this.fileControlImage.IconNotEnabled = global::CAS.UI.Properties.Resources.ImageIcon_Small_Gray;
			this.fileControlImage.Location = new System.Drawing.Point(706, 421);
			this.fileControlImage.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlImage.Name = "fileControlImage";
			this.fileControlImage.ShowLinkLabelBrowse = true;
			this.fileControlImage.ShowLinkLabelRemove = false;
			this.fileControlImage.Size = new System.Drawing.Size(201, 37);
			this.fileControlImage.TabIndex = 139;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.Location = new System.Drawing.Point(410, 147);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(200, 21);
			this.ataChapterComboBox.TabIndex = 129;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(410, 252);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(200, 21);
			this.dictionaryComboBoxLocation.TabIndex = 127;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(24, 537);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowAddNew = false;
			this.dataGridViewControlSuppliers.ShowDelete = false;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(885, 70);
			this.dataGridViewControlSuppliers.TabIndex = 124;
			// 
			// comboBoxStandart
			// 
			this.comboBoxStandart.Displayer = null;
			this.comboBoxStandart.DisplayerText = null;
			this.comboBoxStandart.Entity = null;
			this.comboBoxStandart.Location = new System.Drawing.Point(118, 119);
			this.comboBoxStandart.Name = "comboBoxStandart";
			this.comboBoxStandart.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxStandart.Size = new System.Drawing.Size(791, 21);
			this.comboBoxStandart.TabIndex = 109;
			this.comboBoxStandart.Type = null;
			this.comboBoxStandart.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStandartSelectedIndexChanged);
			// 
			// lifelengthViewerWarranty
			// 
			this.lifelengthViewerWarranty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerWarranty.AutoSize = true;
			this.lifelengthViewerWarranty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerWarranty.CalendarApplicable = false;
			this.lifelengthViewerWarranty.CyclesApplicable = false;
			this.lifelengthViewerWarranty.EnabledCalendar = true;
			this.lifelengthViewerWarranty.EnabledCycle = false;
			this.lifelengthViewerWarranty.EnabledHours = false;
			this.lifelengthViewerWarranty.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerWarranty.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerWarranty.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderCycles = "Cycles";
			this.lifelengthViewerWarranty.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderHours = "Hours";
			this.lifelengthViewerWarranty.HoursApplicable = false;
			this.lifelengthViewerWarranty.LeftHeader = "Warranty:";
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(29, 668);
			this.lifelengthViewerWarranty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarranty.Modified = false;
			this.lifelengthViewerWarranty.Name = "lifelengthViewerWarranty";
			this.lifelengthViewerWarranty.ReadOnly = false;
			this.lifelengthViewerWarranty.ShowCalendar = true;
			this.lifelengthViewerWarranty.ShowFormattedCalendar = false;
			this.lifelengthViewerWarranty.ShowHeaders = false;
			this.lifelengthViewerWarranty.ShowMinutes = false;
			this.lifelengthViewerWarranty.Size = new System.Drawing.Size(437, 35);
			this.lifelengthViewerWarranty.SystemCalculated = true;
			this.lifelengthViewerWarranty.TabIndex = 16;
			// 
			// lifelengthViewerWarrantyNotify
			// 
			this.lifelengthViewerWarrantyNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerWarrantyNotify.AutoSize = true;
			this.lifelengthViewerWarrantyNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerWarrantyNotify.CalendarApplicable = false;
			this.lifelengthViewerWarrantyNotify.CyclesApplicable = false;
			this.lifelengthViewerWarrantyNotify.EnabledCalendar = true;
			this.lifelengthViewerWarrantyNotify.EnabledCycle = false;
			this.lifelengthViewerWarrantyNotify.EnabledHours = false;
			this.lifelengthViewerWarrantyNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerWarrantyNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerWarrantyNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerWarrantyNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderHours = "Hours";
			this.lifelengthViewerWarrantyNotify.HoursApplicable = false;
			this.lifelengthViewerWarrantyNotify.LeftHeader = "Notify:";
			this.lifelengthViewerWarrantyNotify.Location = new System.Drawing.Point(495, 668);
			this.lifelengthViewerWarrantyNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarrantyNotify.Modified = false;
			this.lifelengthViewerWarrantyNotify.Name = "lifelengthViewerWarrantyNotify";
			this.lifelengthViewerWarrantyNotify.ReadOnly = false;
			this.lifelengthViewerWarrantyNotify.ShowCalendar = true;
			this.lifelengthViewerWarrantyNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerWarrantyNotify.ShowHeaders = false;
			this.lifelengthViewerWarrantyNotify.ShowMinutes = false;
			this.lifelengthViewerWarrantyNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerWarrantyNotify.SystemCalculated = true;
			this.lifelengthViewerWarrantyNotify.TabIndex = 18;
			// 
			// lifelengthViewerNotify
			// 
			this.lifelengthViewerNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerNotify.AutoSize = true;
			this.lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerNotify.CalendarApplicable = false;
			this.lifelengthViewerNotify.CyclesApplicable = false;
			this.lifelengthViewerNotify.EnabledCalendar = true;
			this.lifelengthViewerNotify.EnabledCycle = false;
			this.lifelengthViewerNotify.EnabledHours = false;
			this.lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderHours = "Hours";
			this.lifelengthViewerNotify.HoursApplicable = false;
			this.lifelengthViewerNotify.LeftHeader = "Notify:";
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(495, 612);
			this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerNotify.Modified = false;
			this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
			this.lifelengthViewerNotify.ReadOnly = false;
			this.lifelengthViewerNotify.ShowCalendar = true;
			this.lifelengthViewerNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerNotify.ShowMinutes = false;
			this.lifelengthViewerNotify.Size = new System.Drawing.Size(413, 52);
			this.lifelengthViewerNotify.SystemCalculated = true;
			this.lifelengthViewerNotify.TabIndex = 17;
			// 
			// lifelengthViewerLifeLimit
			// 
			this.lifelengthViewerLifeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerLifeLimit.AutoSize = true;
			this.lifelengthViewerLifeLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerLifeLimit.CalendarApplicable = false;
			this.lifelengthViewerLifeLimit.CyclesApplicable = false;
			this.lifelengthViewerLifeLimit.EnabledCalendar = true;
			this.lifelengthViewerLifeLimit.EnabledCycle = false;
			this.lifelengthViewerLifeLimit.EnabledHours = false;
			this.lifelengthViewerLifeLimit.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerLifeLimit.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerLifeLimit.HeaderCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderCycles = "Cycles";
			this.lifelengthViewerLifeLimit.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderHours = "Hours";
			this.lifelengthViewerLifeLimit.HoursApplicable = false;
			this.lifelengthViewerLifeLimit.LeftHeader = "Life limit:";
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(35, 612);
			this.lifelengthViewerLifeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerLifeLimit.Modified = false;
			this.lifelengthViewerLifeLimit.Name = "lifelengthViewerLifeLimit";
			this.lifelengthViewerLifeLimit.ReadOnly = false;
			this.lifelengthViewerLifeLimit.ShowCalendar = true;
			this.lifelengthViewerLifeLimit.ShowFormattedCalendar = false;
			this.lifelengthViewerLifeLimit.ShowMinutes = false;
			this.lifelengthViewerLifeLimit.Size = new System.Drawing.Size(429, 52);
			this.lifelengthViewerLifeLimit.SystemCalculated = true;
			this.lifelengthViewerLifeLimit.TabIndex = 15;
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 256;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(410, 196);
			this.comboBoxDetailClass.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(200, 21);
			this.comboBoxDetailClass.TabIndex = 1;
			this.comboBoxDetailClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailClassSelectedIndexChanged);
			// 
			// checkBoxDangerous
			// 
			this.checkBoxDangerous.AutoSize = true;
			this.checkBoxDangerous.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxDangerous.Location = new System.Drawing.Point(798, 282);
			this.checkBoxDangerous.Name = "checkBoxDangerous";
			this.checkBoxDangerous.Size = new System.Drawing.Size(91, 15);
			this.checkBoxDangerous.TabIndex = 142;
			this.checkBoxDangerous.Text = "Is Dangerous";
			this.checkBoxDangerous.UseSelectable = true;
			// 
			// checkBoxPOOL
			// 
			this.checkBoxPOOL.AutoSize = true;
			this.checkBoxPOOL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPOOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPOOL.Location = new System.Drawing.Point(718, 282);
			this.checkBoxPOOL.Name = "checkBoxPOOL";
			this.checkBoxPOOL.Size = new System.Drawing.Size(65, 15);
			this.checkBoxPOOL.TabIndex = 141;
			this.checkBoxPOOL.Text = "Is POOL";
			this.checkBoxPOOL.UseSelectable = true;
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(118, 91);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(678, 21);
			this.comboBoxSupplier.TabIndex = 143;
			this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
			// 
			// dateTimePickerReciveDate
			// 
			this.dateTimePickerReciveDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReciveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerReciveDate.Location = new System.Drawing.Point(802, 91);
			this.dateTimePickerReciveDate.Name = "dateTimePickerReciveDate";
			this.dateTimePickerReciveDate.Size = new System.Drawing.Size(105, 22);
			this.dateTimePickerReciveDate.TabIndex = 150;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 20);
			this.label2.TabIndex = 151;
			this.label2.Text = "ReceivedFrom:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAltpartNum
			// 
			this.labelAltpartNum.AutoSize = true;
			this.labelAltpartNum.ForeColor = System.Drawing.Color.Black;
			this.labelAltpartNum.Location = new System.Drawing.Point(13, 171);
			this.labelAltpartNum.Name = "labelAltpartNum";
			this.labelAltpartNum.Size = new System.Drawing.Size(89, 19);
			this.labelAltpartNum.TabIndex = 153;
			this.labelAltpartNum.Text = "Alt Part Num:";
			this.labelAltpartNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAltPartNum
			// 
			this.textBoxAltPartNum.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxAltPartNum.CustomButton.Image = null;
			this.textBoxAltPartNum.CustomButton.Location = new System.Drawing.Point(182, 2);
			this.textBoxAltPartNum.CustomButton.Name = "";
			this.textBoxAltPartNum.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxAltPartNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAltPartNum.CustomButton.TabIndex = 1;
			this.textBoxAltPartNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAltPartNum.CustomButton.UseSelectable = true;
			this.textBoxAltPartNum.CustomButton.Visible = false;
			this.textBoxAltPartNum.ForeColor = System.Drawing.Color.Black;
			this.textBoxAltPartNum.Lines = new string[0];
			this.textBoxAltPartNum.Location = new System.Drawing.Point(118, 171);
			this.textBoxAltPartNum.MaxLength = 128;
			this.textBoxAltPartNum.Name = "textBoxAltPartNum";
			this.textBoxAltPartNum.PasswordChar = '\0';
			this.textBoxAltPartNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAltPartNum.SelectedText = "";
			this.textBoxAltPartNum.SelectionLength = 0;
			this.textBoxAltPartNum.SelectionStart = 0;
			this.textBoxAltPartNum.ShortcutsEnabled = true;
			this.textBoxAltPartNum.Size = new System.Drawing.Size(200, 20);
			this.textBoxAltPartNum.TabIndex = 152;
			this.textBoxAltPartNum.UseSelectable = true;
			this.textBoxAltPartNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAltPartNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxReceived
			// 
			this.comboBoxReceived.FormattingEnabled = true;
			this.comboBoxReceived.Location = new System.Drawing.Point(706, 393);
			this.comboBoxReceived.Name = "comboBoxReceived";
			this.comboBoxReceived.Size = new System.Drawing.Size(200, 21);
			this.comboBoxReceived.TabIndex = 154;
			// 
			// metroLabelReceived
			// 
			this.metroLabelReceived.AutoSize = true;
			this.metroLabelReceived.ForeColor = System.Drawing.Color.Black;
			this.metroLabelReceived.Location = new System.Drawing.Point(619, 393);
			this.metroLabelReceived.Name = "metroLabelReceived";
			this.metroLabelReceived.Size = new System.Drawing.Size(64, 19);
			this.metroLabelReceived.TabIndex = 155;
			this.metroLabelReceived.Text = "Received:";
			this.metroLabelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentControlFaa
			// 
			this.documentControlFaa.CurrentDocument = null;
			this.documentControlFaa.Location = new System.Drawing.Point(118, 425);
			this.documentControlFaa.Name = "documentControlFaa";
			this.documentControlFaa.Size = new System.Drawing.Size(200, 41);
			this.documentControlFaa.TabIndex = 154;
			// 
			// documentControlShip
			// 
			this.documentControlShip.CurrentDocument = null;
			this.documentControlShip.Location = new System.Drawing.Point(412, 425);
			this.documentControlShip.Name = "documentControlShip";
			this.documentControlShip.Size = new System.Drawing.Size(200, 41);
			this.documentControlShip.TabIndex = 155;
			// 
			// metroLabelPacking
			// 
			this.metroLabelPacking.AutoSize = true;
			this.metroLabelPacking.ForeColor = System.Drawing.Color.Black;
			this.metroLabelPacking.Location = new System.Drawing.Point(619, 173);
			this.metroLabelPacking.Name = "metroLabelPacking";
			this.metroLabelPacking.Size = new System.Drawing.Size(56, 19);
			this.metroLabelPacking.TabIndex = 157;
			this.metroLabelPacking.Text = "Packing:";
			this.metroLabelPacking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroTextBoxPacking
			// 
			this.metroTextBoxPacking.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.metroTextBoxPacking.CustomButton.Image = null;
			this.metroTextBoxPacking.CustomButton.Location = new System.Drawing.Point(183, 2);
			this.metroTextBoxPacking.CustomButton.Name = "";
			this.metroTextBoxPacking.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBoxPacking.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxPacking.CustomButton.TabIndex = 1;
			this.metroTextBoxPacking.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxPacking.CustomButton.UseSelectable = true;
			this.metroTextBoxPacking.CustomButton.Visible = false;
			this.metroTextBoxPacking.ForeColor = System.Drawing.Color.Black;
			this.metroTextBoxPacking.Lines = new string[0];
			this.metroTextBoxPacking.Location = new System.Drawing.Point(706, 173);
			this.metroTextBoxPacking.MaxLength = 128;
			this.metroTextBoxPacking.Name = "metroTextBoxPacking";
			this.metroTextBoxPacking.PasswordChar = '\0';
			this.metroTextBoxPacking.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxPacking.SelectedText = "";
			this.metroTextBoxPacking.SelectionLength = 0;
			this.metroTextBoxPacking.SelectionStart = 0;
			this.metroTextBoxPacking.ShortcutsEnabled = true;
			this.metroTextBoxPacking.Size = new System.Drawing.Size(201, 20);
			this.metroTextBoxPacking.TabIndex = 156;
			this.metroTextBoxPacking.UseSelectable = true;
			this.metroTextBoxPacking.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxPacking.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// linkLabelEditComponents
			// 
			this.linkLabelEditComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditComponents.Location = new System.Drawing.Point(790, 63);
			this.linkLabelEditComponents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditComponents.Name = "linkLabelEditComponents";
			this.linkLabelEditComponents.Size = new System.Drawing.Size(48, 23);
			this.linkLabelEditComponents.TabIndex = 191;
			this.linkLabelEditComponents.TabStop = true;
			this.linkLabelEditComponents.Text = "Bind";
			this.linkLabelEditComponents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditComponents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditComponents_LinkClicked);
			// 
			// TextBoxProduct
			// 
			this.TextBoxProduct.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.TextBoxProduct.CustomButton.Image = null;
			this.TextBoxProduct.CustomButton.Location = new System.Drawing.Point(660, 2);
			this.TextBoxProduct.CustomButton.Name = "";
			this.TextBoxProduct.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.TextBoxProduct.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.TextBoxProduct.CustomButton.TabIndex = 1;
			this.TextBoxProduct.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.TextBoxProduct.CustomButton.UseSelectable = true;
			this.TextBoxProduct.CustomButton.Visible = false;
			this.TextBoxProduct.Enabled = false;
			this.TextBoxProduct.ForeColor = System.Drawing.Color.Black;
			this.TextBoxProduct.Lines = new string[0];
			this.TextBoxProduct.Location = new System.Drawing.Point(118, 65);
			this.TextBoxProduct.MaxLength = 128;
			this.TextBoxProduct.Name = "TextBoxProduct";
			this.TextBoxProduct.PasswordChar = '\0';
			this.TextBoxProduct.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TextBoxProduct.SelectedText = "";
			this.TextBoxProduct.SelectionLength = 0;
			this.TextBoxProduct.SelectionStart = 0;
			this.TextBoxProduct.ShortcutsEnabled = true;
			this.TextBoxProduct.Size = new System.Drawing.Size(678, 20);
			this.TextBoxProduct.TabIndex = 192;
			this.TextBoxProduct.UseSelectable = true;
			this.TextBoxProduct.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.TextBoxProduct.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel1.Location = new System.Drawing.Point(840, 63);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(37, 23);
			this.linkLabel1.TabIndex = 193;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Edit";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel2.Location = new System.Drawing.Point(878, 63);
			this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(50, 23);
			this.linkLabel2.TabIndex = 194;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Clear";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
			// 
			// metroLabelEffectivity
			// 
			this.metroLabelEffectivity.AutoSize = true;
			this.metroLabelEffectivity.ForeColor = System.Drawing.Color.Black;
			this.metroLabelEffectivity.Location = new System.Drawing.Point(324, 305);
			this.metroLabelEffectivity.Name = "metroLabelEffectivity";
			this.metroLabelEffectivity.Size = new System.Drawing.Size(66, 19);
			this.metroLabelEffectivity.TabIndex = 198;
			this.metroLabelEffectivity.Text = "Effectivity:";
			this.metroLabelEffectivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroTextBoxEffectivity
			// 
			this.metroTextBoxEffectivity.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.metroTextBoxEffectivity.CustomButton.Image = null;
			this.metroTextBoxEffectivity.CustomButton.Location = new System.Drawing.Point(183, 2);
			this.metroTextBoxEffectivity.CustomButton.Name = "";
			this.metroTextBoxEffectivity.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBoxEffectivity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxEffectivity.CustomButton.TabIndex = 1;
			this.metroTextBoxEffectivity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxEffectivity.CustomButton.UseSelectable = true;
			this.metroTextBoxEffectivity.CustomButton.Visible = false;
			this.metroTextBoxEffectivity.Enabled = false;
			this.metroTextBoxEffectivity.ForeColor = System.Drawing.Color.Black;
			this.metroTextBoxEffectivity.Lines = new string[0];
			this.metroTextBoxEffectivity.Location = new System.Drawing.Point(409, 306);
			this.metroTextBoxEffectivity.MaxLength = 128;
			this.metroTextBoxEffectivity.Name = "metroTextBoxEffectivity";
			this.metroTextBoxEffectivity.PasswordChar = '\0';
			this.metroTextBoxEffectivity.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxEffectivity.SelectedText = "";
			this.metroTextBoxEffectivity.SelectionLength = 0;
			this.metroTextBoxEffectivity.SelectionStart = 0;
			this.metroTextBoxEffectivity.ShortcutsEnabled = true;
			this.metroTextBoxEffectivity.Size = new System.Drawing.Size(201, 20);
			this.metroTextBoxEffectivity.TabIndex = 197;
			this.metroTextBoxEffectivity.UseSelectable = true;
			this.metroTextBoxEffectivity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxEffectivity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// ComponentForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(924, 770);
			this.Controls.Add(this.metroLabelEffectivity);
			this.Controls.Add(this.metroTextBoxEffectivity);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.TextBoxProduct);
			this.Controls.Add(this.linkLabelEditComponents);
			this.Controls.Add(this.metroLabelPacking);
			this.Controls.Add(this.metroTextBoxPacking);
			this.Controls.Add(this.comboBoxReceived);
			this.Controls.Add(this.metroLabelReceived);
			this.Controls.Add(this.documentControlShip);
			this.Controls.Add(this.documentControlFaa);
			this.Controls.Add(this.labelAltpartNum);
			this.Controls.Add(this.textBoxAltPartNum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePickerReciveDate);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.checkBoxDangerous);
			this.Controls.Add(this.checkBoxPOOL);
			this.Controls.Add(this.labelIamge);
			this.Controls.Add(this.fileControlImage);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelFaaForm);
			this.Controls.Add(this.labelDiscrepancy);
			this.Controls.Add(this.textBoxDiscrepancy);
			this.Controls.Add(this.checkBoxIncoming);
			this.Controls.Add(this.ataChapterComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(this.labelTotal);
			this.Controls.Add(this.textBoxTotal);
			this.Controls.Add(this.dataGridViewControlSuppliers);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonSaveAndAdd);
			this.Controls.Add(this.labelProductCode);
			this.Controls.Add(this.textBoxProductCode);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.textBoxManufacturer);
			this.Controls.Add(this.comboBoxStandart);
			this.Controls.Add(this.labelStandart);
			this.Controls.Add(this.lifelengthViewerWarranty);
			this.Controls.Add(this.lifelengthViewerWarrantyNotify);
			this.Controls.Add(this.labelSupplier);
			this.Controls.Add(this.labelProduct);
			this.Controls.Add(this.lifelengthViewerNotify);
			this.Controls.Add(this.lifelengthViewerLifeLimit);
			this.Controls.Add(this.labelInstallDate);
			this.Controls.Add(this.dateTimePickerInstallDate);
			this.Controls.Add(this.labelManufactureDate);
			this.Controls.Add(this.dateTimePickerManufactureDate);
			this.Controls.Add(this.comboBoxMeasure);
			this.Controls.Add(this.labelLocation);
			this.Controls.Add(this.comboBoxPosition);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.labelBatchNumber);
			this.Controls.Add(this.textBoxBatchNumber);
			this.Controls.Add(this.labelIdNumber);
			this.Controls.Add(this.textBoxIdNumber);
			this.Controls.Add(this.comboBoxDetailClass);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.numericUpDownQuantity);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.labelSerialNumber);
			this.Controls.Add(this.textBoxSerialNumber);
			this.Controls.Add(this.labelPartNumber);
			this.Controls.Add(this.textBoxPartNumber);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelMeasure);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.labelSeparator);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textBoxRemarks);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(924, 780);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(924, 730);
			this.Name = "ComponentForm";
			this.Resizable = false;
			this.Text = "Component form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Auxiliary.LifelengthViewer lifelengthViewerNotify;
        private Auxiliary.LifelengthViewer lifelengthViewerLifeLimit;
        private MetroLabel labelInstallDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstallDate;
        private MetroLabel labelManufactureDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private MetroLabel labelLocation;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private MetroLabel labelPosition;
        private MetroLabel labelBatchNumber;
        private MetroTextBox textBoxBatchNumber;
        private MetroLabel labelIdNumber;
        private MetroTextBox textBoxIdNumber;
        private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private MetroLabel labelType;
        private MetroLabel labelSerialNumber;
        private MetroTextBox textBoxSerialNumber;
		private MetroLabel labelPartNumber;
        private MetroTextBox textBoxPartNumber;
        private MetroLabel labelDescription;
        private MetroTextBox textBoxDescription;
        private MetroLabel labelMeasure;
        private MetroLabel labelQuantity;
        private MetroLabel labelSeparator;
        private MetroLabel labelRemarks;
        private MetroTextBox textBoxRemarks;
        private MetroLabel labelProduct;
        private MetroLabel labelSupplier;
        private Auxiliary.LifelengthViewer lifelengthViewerWarranty;
        private Auxiliary.LifelengthViewer lifelengthViewerWarrantyNotify;
        private MetroLabel labelStandart;
        private Auxiliary.LookupCombobox comboBoxStandart;
        private MetroLabel labelManufacturer;
        private MetroTextBox textBoxManufacturer;
        private MetroLabel labelProductCode;
        private MetroTextBox textBoxProductCode;
        private System.Windows.Forms.Button buttonSaveAndAdd;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private MetroLabel labelStatus;
        private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
        private MetroLabel labelTotal;
        private MetroTextBox textBoxTotal;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxLocation;
		private MetroLabel label1;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private MetroCheckBox checkBoxIncoming;
		private MetroLabel labelDiscrepancy;
		private MetroTextBox textBoxDiscrepancy;
		private MetroLabel labelFaaForm;
		private MetroLabel label4;
		private Auxiliary.AttachedFileControl fileControlImage;
		private MetroLabel labelIamge;
		private MetroCheckBox checkBoxDangerous;
		private MetroCheckBox checkBoxPOOL;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.DateTimePicker dateTimePickerReciveDate;
		private MetroLabel label2;
		private MetroLabel labelAltpartNum;
		private MetroTextBox textBoxAltPartNum;
		private System.Windows.Forms.ComboBox comboBoxReceived;
		private MetroLabel metroLabelReceived;
		private DocumentationControls.DocumentControl documentControlFaa;
		private DocumentationControls.DocumentControl documentControlShip;
		private MetroLabel metroLabelPacking;
		private MetroTextBox metroTextBoxPacking;
		private System.Windows.Forms.LinkLabel linkLabelEditComponents;
		private MetroTextBox TextBoxProduct;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private MetroLabel metroLabelEffectivity;
		private MetroTextBox metroTextBoxEffectivity;
	}
}