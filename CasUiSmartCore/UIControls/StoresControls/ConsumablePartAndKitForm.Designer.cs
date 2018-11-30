namespace CAS.UI.UIControls.StoresControls
{
    partial class ConsumablePartAndKitForm
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

            dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsumablePartAndKitForm));
			this.labelInstallDate = new System.Windows.Forms.Label();
			this.dateTimePickerInstallDate = new System.Windows.Forms.DateTimePicker();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelLocation = new System.Windows.Forms.Label();
			this.comboBoxPosition = new System.Windows.Forms.ComboBox();
			this.labelPosition = new System.Windows.Forms.Label();
			this.labelBatchNumber = new System.Windows.Forms.Label();
			this.textBoxBatchNumber = new System.Windows.Forms.TextBox();
			this.labelIdNumber = new System.Windows.Forms.Label();
			this.textBoxIdNumber = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelType = new System.Windows.Forms.Label();
			this.labelSerialNumber = new System.Windows.Forms.Label();
			this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
			this.labelPartNumber = new System.Windows.Forms.Label();
			this.textBoxPartNumber = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.labelSeparator = new System.Windows.Forms.Label();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelProduct = new System.Windows.Forms.Label();
			this.labelSupplier = new System.Windows.Forms.Label();
			this.labelStandart = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.labelProductCode = new System.Windows.Forms.Label();
			this.textBoxProductCode = new System.Windows.Forms.TextBox();
			this.buttonSaveAndAdd = new System.Windows.Forms.Button();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelTotal = new System.Windows.Forms.Label();
			this.textBoxTotal = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxIncoming = new System.Windows.Forms.CheckBox();
			this.labelDiscrepancy = new System.Windows.Forms.Label();
			this.textBoxDiscrepancy = new System.Windows.Forms.TextBox();
			this.labelFaaForm = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelIamge = new System.Windows.Forms.Label();
			this.fileControlImage = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlShipping = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlFaaForm = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.comboBoxStandart = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarrantyNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.checkBoxDangerous = new System.Windows.Forms.CheckBox();
			this.checkBoxPOOL = new System.Windows.Forms.CheckBox();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.dateTimePickerReciveDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// labelInstallDate
			// 
			this.labelInstallDate.AutoSize = true;
			this.labelInstallDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelInstallDate.ForeColor = System.Drawing.Color.Black;
			this.labelInstallDate.Location = new System.Drawing.Point(609, 174);
			this.labelInstallDate.Name = "labelInstallDate";
			this.labelInstallDate.Size = new System.Drawing.Size(80, 13);
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
			this.dateTimePickerInstallDate.Location = new System.Drawing.Point(696, 172);
			this.dateTimePickerInstallDate.Name = "dateTimePickerInstallDate";
			this.dateTimePickerInstallDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerInstallDate.TabIndex = 14;
			this.dateTimePickerInstallDate.ValueChanged += new System.EventHandler(this.DateTimePickerInstallationDateValueChanged);
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufactureDate.ForeColor = System.Drawing.Color.Black;
			this.labelManufactureDate.Location = new System.Drawing.Point(609, 147);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(81, 13);
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
			this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(696, 144);
			this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
			this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerManufactureDate.TabIndex = 13;
			this.dateTimePickerManufactureDate.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(400, 221);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(200, 21);
			this.comboBoxMeasure.TabIndex = 7;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLocation.ForeColor = System.Drawing.Color.Black;
			this.labelLocation.Location = new System.Drawing.Point(314, 198);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.Size = new System.Drawing.Size(51, 13);
			this.labelLocation.TabIndex = 98;
			this.labelLocation.Text = "Location:";
			this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxPosition
			// 
			this.comboBoxPosition.FormattingEnabled = true;
			this.comboBoxPosition.Location = new System.Drawing.Point(400, 165);
			this.comboBoxPosition.Name = "comboBoxPosition";
			this.comboBoxPosition.Size = new System.Drawing.Size(200, 21);
			this.comboBoxPosition.TabIndex = 3;
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPosition.ForeColor = System.Drawing.Color.Black;
			this.labelPosition.Location = new System.Drawing.Point(313, 168);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(35, 13);
			this.labelPosition.TabIndex = 96;
			this.labelPosition.Text = "State:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBatchNumber
			// 
			this.labelBatchNumber.AutoSize = true;
			this.labelBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBatchNumber.ForeColor = System.Drawing.Color.Black;
			this.labelBatchNumber.Location = new System.Drawing.Point(12, 142);
			this.labelBatchNumber.Name = "labelBatchNumber";
			this.labelBatchNumber.Size = new System.Drawing.Size(78, 13);
			this.labelBatchNumber.TabIndex = 92;
			this.labelBatchNumber.Text = "Batch Number:";
			this.labelBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxBatchNumber
			// 
			this.textBoxBatchNumber.BackColor = System.Drawing.Color.White;
			this.textBoxBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxBatchNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxBatchNumber.Location = new System.Drawing.Point(108, 139);
			this.textBoxBatchNumber.MaxLength = 128;
			this.textBoxBatchNumber.Name = "textBoxBatchNumber";
			this.textBoxBatchNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxBatchNumber.TabIndex = 6;
			// 
			// labelIdNumber
			// 
			this.labelIdNumber.AutoSize = true;
			this.labelIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIdNumber.ForeColor = System.Drawing.Color.Black;
			this.labelIdNumber.Location = new System.Drawing.Point(12, 168);
			this.labelIdNumber.Name = "labelIdNumber";
			this.labelIdNumber.Size = new System.Drawing.Size(61, 13);
			this.labelIdNumber.TabIndex = 94;
			this.labelIdNumber.Text = "ID Number:";
			this.labelIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIdNumber
			// 
			this.textBoxIdNumber.BackColor = System.Drawing.Color.White;
			this.textBoxIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxIdNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxIdNumber.Location = new System.Drawing.Point(108, 165);
			this.textBoxIdNumber.MaxLength = 128;
			this.textBoxIdNumber.Name = "textBoxIdNumber";
			this.textBoxIdNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxIdNumber.TabIndex = 8;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(764, 650);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(56, 27);
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
			this.buttonCancel.Location = new System.Drawing.Point(823, 650);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(69, 27);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(696, 87);
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
			this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelType.ForeColor = System.Drawing.Color.Black;
			this.labelType.Location = new System.Drawing.Point(313, 144);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(41, 13);
			this.labelType.TabIndex = 76;
			this.labelType.Text = "Class:";
			this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.AutoSize = true;
			this.labelSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSerialNumber.ForeColor = System.Drawing.Color.Black;
			this.labelSerialNumber.Location = new System.Drawing.Point(12, 116);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(76, 13);
			this.labelSerialNumber.TabIndex = 77;
			this.labelSerialNumber.Text = "Serial Number:";
			this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSerialNumber
			// 
			this.textBoxSerialNumber.BackColor = System.Drawing.Color.White;
			this.textBoxSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxSerialNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxSerialNumber.Location = new System.Drawing.Point(108, 113);
			this.textBoxSerialNumber.MaxLength = 128;
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxSerialNumber.TabIndex = 4;
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.AutoSize = true;
			this.labelPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPartNumber.ForeColor = System.Drawing.Color.Black;
			this.labelPartNumber.Location = new System.Drawing.Point(12, 90);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(81, 13);
			this.labelPartNumber.TabIndex = 79;
			this.labelPartNumber.Text = "Part Number:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			this.textBoxPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.Black;
			this.textBoxPartNumber.Location = new System.Drawing.Point(108, 87);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.Size = new System.Drawing.Size(200, 20);
			this.textBoxPartNumber.TabIndex = 2;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.Black;
			this.labelDescription.Location = new System.Drawing.Point(12, 252);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(75, 13);
			this.labelDescription.TabIndex = 81;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.Black;
			this.textBoxDescription.Location = new System.Drawing.Point(106, 250);
			this.textBoxDescription.MaxLength = 256;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(202, 81);
			this.textBoxDescription.TabIndex = 10;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMeasure.ForeColor = System.Drawing.Color.Black;
			this.labelMeasure.Location = new System.Drawing.Point(314, 225);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(59, 13);
			this.labelMeasure.TabIndex = 83;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelQuantity.ForeColor = System.Drawing.Color.Black;
			this.labelQuantity.Location = new System.Drawing.Point(609, 91);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(73, 13);
			this.labelQuantity.TabIndex = 84;
			this.labelQuantity.Text = "Quantity In:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeparator
			// 
			this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelSeparator.Location = new System.Drawing.Point(12, 549);
			this.labelSeparator.Name = "labelSeparator";
			this.labelSeparator.Size = new System.Drawing.Size(880, 1);
			this.labelSeparator.TabIndex = 85;
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.Black;
			this.labelRemarks.Location = new System.Drawing.Point(314, 250);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(52, 13);
			this.labelRemarks.TabIndex = 86;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxRemarks.ForeColor = System.Drawing.Color.Black;
			this.textBoxRemarks.Location = new System.Drawing.Point(400, 248);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(201, 81);
			this.textBoxRemarks.TabIndex = 11;
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProduct.Location = new System.Drawing.Point(12, 11);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(55, 13);
			this.labelProduct.TabIndex = 105;
			this.labelProduct.Text = "Product:";
			// 
			// labelSupplier
			// 
			this.labelSupplier.AutoSize = true;
			this.labelSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelSupplier.Location = new System.Drawing.Point(427, 462);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(95, 13);
			this.labelSupplier.TabIndex = 108;
			this.labelSupplier.Text = "PRODUCT COST:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStandart
			// 
			this.labelStandart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelStandart.Location = new System.Drawing.Point(12, 58);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 25);
			this.labelStandart.TabIndex = 110;
			this.labelStandart.Text = "Standart:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufacturer.ForeColor = System.Drawing.Color.Black;
			this.labelManufacturer.Location = new System.Drawing.Point(12, 225);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(73, 13);
			this.labelManufacturer.TabIndex = 118;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.Black;
			this.textBoxManufacturer.Location = new System.Drawing.Point(108, 222);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(200, 20);
			this.textBoxManufacturer.TabIndex = 117;
			// 
			// labelProductCode
			// 
			this.labelProductCode.AutoSize = true;
			this.labelProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProductCode.ForeColor = System.Drawing.Color.Black;
			this.labelProductCode.Location = new System.Drawing.Point(12, 197);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(35, 13);
			this.labelProductCode.TabIndex = 120;
			this.labelProductCode.Text = "Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			this.textBoxProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxProductCode.ForeColor = System.Drawing.Color.Black;
			this.textBoxProductCode.Location = new System.Drawing.Point(108, 195);
			this.textBoxProductCode.MaxLength = 128;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.Size = new System.Drawing.Size(200, 20);
			this.textBoxProductCode.TabIndex = 119;
			// 
			// buttonSaveAndAdd
			// 
			this.buttonSaveAndAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveAndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSaveAndAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonSaveAndAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonSaveAndAdd.Location = new System.Drawing.Point(780, 733);
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
			this.comboBoxStatus.Location = new System.Drawing.Point(401, 113);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(200, 21);
			this.comboBoxStatus.TabIndex = 122;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStatus.ForeColor = System.Drawing.Color.Black;
			this.labelStatus.Location = new System.Drawing.Point(314, 116);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(40, 13);
			this.labelStatus.TabIndex = 123;
			this.labelStatus.Text = "Status:";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTotal.ForeColor = System.Drawing.Color.Black;
			this.labelTotal.Location = new System.Drawing.Point(609, 119);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(44, 13);
			this.labelTotal.TabIndex = 126;
			this.labelTotal.Text = "Current:";
			this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTotal
			// 
			this.textBoxTotal.BackColor = System.Drawing.Color.White;
			this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Location = new System.Drawing.Point(697, 117);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.Size = new System.Drawing.Size(200, 20);
			this.textBoxTotal.TabIndex = 125;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(314, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 128;
			this.label1.Text = "ATA:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxIncoming
			// 
			this.checkBoxIncoming.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIncoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxIncoming.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxIncoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIncoming.Location = new System.Drawing.Point(749, 225);
			this.checkBoxIncoming.Name = "checkBoxIncoming";
			this.checkBoxIncoming.Size = new System.Drawing.Size(147, 26);
			this.checkBoxIncoming.TabIndex = 131;
			this.checkBoxIncoming.Text = "Incoming Control";
			this.checkBoxIncoming.CheckedChanged += new System.EventHandler(this.checkBoxIncoming_CheckedChanged);
			// 
			// labelDiscrepancy
			// 
			this.labelDiscrepancy.AutoSize = true;
			this.labelDiscrepancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDiscrepancy.ForeColor = System.Drawing.Color.Black;
			this.labelDiscrepancy.Location = new System.Drawing.Point(609, 252);
			this.labelDiscrepancy.Name = "labelDiscrepancy";
			this.labelDiscrepancy.Size = new System.Drawing.Size(69, 13);
			this.labelDiscrepancy.TabIndex = 133;
			this.labelDiscrepancy.Text = "Discrepancy:";
			this.labelDiscrepancy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDiscrepancy
			// 
			this.textBoxDiscrepancy.BackColor = System.Drawing.Color.White;
			this.textBoxDiscrepancy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDiscrepancy.ForeColor = System.Drawing.Color.Black;
			this.textBoxDiscrepancy.Location = new System.Drawing.Point(696, 247);
			this.textBoxDiscrepancy.Multiline = true;
			this.textBoxDiscrepancy.Name = "textBoxDiscrepancy";
			this.textBoxDiscrepancy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDiscrepancy.Size = new System.Drawing.Size(201, 81);
			this.textBoxDiscrepancy.TabIndex = 132;
			// 
			// labelFaaForm
			// 
			this.labelFaaForm.AutoSize = true;
			this.labelFaaForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFaaForm.ForeColor = System.Drawing.Color.Black;
			this.labelFaaForm.Location = new System.Drawing.Point(9, 351);
			this.labelFaaForm.Name = "labelFaaForm";
			this.labelFaaForm.Size = new System.Drawing.Size(56, 13);
			this.labelFaaForm.TabIndex = 135;
			this.labelFaaForm.Text = "FAA Form:";
			this.labelFaaForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(314, 351);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 137;
			this.label4.Text = "Shipping Doc.:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelIamge
			// 
			this.labelIamge.AutoSize = true;
			this.labelIamge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIamge.ForeColor = System.Drawing.Color.Black;
			this.labelIamge.Location = new System.Drawing.Point(609, 351);
			this.labelIamge.Name = "labelIamge";
			this.labelIamge.Size = new System.Drawing.Size(39, 13);
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
			this.fileControlImage.Location = new System.Drawing.Point(697, 337);
			this.fileControlImage.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlImage.Name = "fileControlImage";
			this.fileControlImage.ShowLinkLabelBrowse = true;
			this.fileControlImage.ShowLinkLabelRemove = false;
			this.fileControlImage.Size = new System.Drawing.Size(201, 37);
			this.fileControlImage.TabIndex = 139;
			// 
			// fileControlShipping
			// 
			this.fileControlShipping.AutoSize = true;
			this.fileControlShipping.Description1 = "";
			this.fileControlShipping.Description2 = "";
			this.fileControlShipping.Filter = null;
			this.fileControlShipping.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlShipping.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlShipping.Location = new System.Drawing.Point(400, 337);
			this.fileControlShipping.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlShipping.Name = "fileControlShipping";
			this.fileControlShipping.ShowLinkLabelBrowse = true;
			this.fileControlShipping.ShowLinkLabelRemove = false;
			this.fileControlShipping.Size = new System.Drawing.Size(201, 37);
			this.fileControlShipping.TabIndex = 138;
			// 
			// fileControlFaaForm
			// 
			this.fileControlFaaForm.AutoSize = true;
			this.fileControlFaaForm.Description1 = "";
			this.fileControlFaaForm.Description2 = "";
			this.fileControlFaaForm.Filter = null;
			this.fileControlFaaForm.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlFaaForm.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlFaaForm.Location = new System.Drawing.Point(108, 337);
			this.fileControlFaaForm.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlFaaForm.Name = "fileControlFaaForm";
			this.fileControlFaaForm.ShowLinkLabelBrowse = true;
			this.fileControlFaaForm.ShowLinkLabelRemove = false;
			this.fileControlFaaForm.Size = new System.Drawing.Size(200, 37);
			this.fileControlFaaForm.TabIndex = 136;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.Location = new System.Drawing.Point(400, 89);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(200, 21);
			this.ataChapterComboBox.TabIndex = 129;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(400, 194);
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
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(14, 479);
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
			this.comboBoxStandart.Location = new System.Drawing.Point(108, 61);
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
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(19, 610);
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
			this.lifelengthViewerWarrantyNotify.Location = new System.Drawing.Point(485, 610);
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
			// dictionaryComboProduct
			// 
			this.dictionaryComboProduct.Displayer = null;
			this.dictionaryComboProduct.DisplayerText = null;
			this.dictionaryComboProduct.Entity = null;
			this.dictionaryComboProduct.Location = new System.Drawing.Point(108, 6);
			this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboProduct.Name = "dictionaryComboProduct";
			this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboProduct.Size = new System.Drawing.Size(791, 21);
			this.dictionaryComboProduct.TabIndex = 0;
			this.dictionaryComboProduct.Type = null;
			this.dictionaryComboProduct.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
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
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(485, 554);
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
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(25, 554);
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
			this.comboBoxDetailClass.Location = new System.Drawing.Point(400, 138);
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
			this.checkBoxDangerous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxDangerous.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxDangerous.Location = new System.Drawing.Point(788, 200);
			this.checkBoxDangerous.Name = "checkBoxDangerous";
			this.checkBoxDangerous.Size = new System.Drawing.Size(108, 18);
			this.checkBoxDangerous.TabIndex = 142;
			this.checkBoxDangerous.Text = "Is Dangerous";
			// 
			// checkBoxPOOL
			// 
			this.checkBoxPOOL.AutoSize = true;
			this.checkBoxPOOL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPOOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxPOOL.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxPOOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPOOL.Location = new System.Drawing.Point(708, 200);
			this.checkBoxPOOL.Name = "checkBoxPOOL";
			this.checkBoxPOOL.Size = new System.Drawing.Size(74, 18);
			this.checkBoxPOOL.TabIndex = 141;
			this.checkBoxPOOL.Text = "Is POOL";
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(108, 33);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(200, 21);
			this.comboBoxSupplier.TabIndex = 143;
			this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
			// 
			// dateTimePickerReciveDate
			// 
			this.dateTimePickerReciveDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReciveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReciveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerReciveDate.Location = new System.Drawing.Point(314, 33);
			this.dateTimePickerReciveDate.Name = "dateTimePickerReciveDate";
			this.dateTimePickerReciveDate.Size = new System.Drawing.Size(105, 22);
			this.dateTimePickerReciveDate.TabIndex = 150;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 20);
			this.label2.TabIndex = 151;
			this.label2.Text = "ReceivedFrom:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConsumablePartAndKitForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(908, 688);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePickerReciveDate);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.checkBoxDangerous);
			this.Controls.Add(this.checkBoxPOOL);
			this.Controls.Add(this.labelIamge);
			this.Controls.Add(this.fileControlImage);
			this.Controls.Add(this.fileControlShipping);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.fileControlFaaForm);
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
			this.Controls.Add(this.dictionaryComboProduct);
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
			this.MaximumSize = new System.Drawing.Size(924, 730);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(924, 730);
			this.Name = "ConsumablePartAndKitForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consumable part/KIT/FLM form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Auxiliary.LifelengthViewer lifelengthViewerNotify;
        private Auxiliary.LifelengthViewer lifelengthViewerLifeLimit;
        private System.Windows.Forms.Label labelInstallDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstallDate;
        private System.Windows.Forms.Label labelManufactureDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelBatchNumber;
        private System.Windows.Forms.TextBox textBoxBatchNumber;
        private System.Windows.Forms.Label labelIdNumber;
        private System.Windows.Forms.TextBox textBoxIdNumber;
        private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelProduct;
        private Auxiliary.LookupCombobox dictionaryComboProduct;
        private System.Windows.Forms.Label labelSupplier;
        private Auxiliary.LifelengthViewer lifelengthViewerWarranty;
        private Auxiliary.LifelengthViewer lifelengthViewerWarrantyNotify;
        private System.Windows.Forms.Label labelStandart;
        private Auxiliary.LookupCombobox comboBoxStandart;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.Button buttonSaveAndAdd;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxLocation;
		private System.Windows.Forms.Label label1;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private System.Windows.Forms.CheckBox checkBoxIncoming;
		private System.Windows.Forms.Label labelDiscrepancy;
		private System.Windows.Forms.TextBox textBoxDiscrepancy;
		private System.Windows.Forms.Label labelFaaForm;
		private Auxiliary.AttachedFileControl fileControlFaaForm;
		private Auxiliary.AttachedFileControl fileControlShipping;
		private System.Windows.Forms.Label label4;
		private Auxiliary.AttachedFileControl fileControlImage;
		private System.Windows.Forms.Label labelIamge;
		private System.Windows.Forms.CheckBox checkBoxDangerous;
		private System.Windows.Forms.CheckBox checkBoxPOOL;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.DateTimePicker dateTimePickerReciveDate;
		private System.Windows.Forms.Label label2;
	}
}