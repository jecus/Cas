using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DocumentationControls
{
    partial class DocumentForm
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.Label labelSubType;
			System.Windows.Forms.Label labelDescription;
			System.Windows.Forms.Label labelValidFrom;
			System.Windows.Forms.Label labelValidToIssue;
			System.Windows.Forms.Label labelDocumentType;
			System.Windows.Forms.Label labelPayerName;
			System.Windows.Forms.Label labelServiceType;
			System.Windows.Forms.Label labelProlongation;
			System.Windows.Forms.Label labelNumber;
			System.Windows.Forms.Label labelResponsible;
			System.Windows.Forms.Label labelNotifyIssue;
			System.Windows.Forms.Label labelRevNumber;
			System.Windows.Forms.Label labelTemplate;
			System.Windows.Forms.Label labelDepartment;
			System.Windows.Forms.Label labelNomenclature;
			System.Windows.Forms.Label labelNumberIssue;
			System.Windows.Forms.Label labelNotifyRevision;
			System.Windows.Forms.Label labelValidToRevision;
			System.Windows.Forms.Label labelStatus;
			System.Windows.Forms.Label labelRemarks;
			System.Windows.Forms.Label labelLocation;
			this.comboBoxSubType = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.dateTimePickerIssueValidFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerIssueValidTo = new System.Windows.Forms.DateTimePicker();
			this.comboBoxDocumentType = new System.Windows.Forms.ComboBox();
			this.textBoxContractNumber = new System.Windows.Forms.TextBox();
			this.checkBoxIssueValidTo = new System.Windows.Forms.CheckBox();
			this.numericUpDownIssueNotify = new System.Windows.Forms.NumericUpDown();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this._buttonEditTypes = new System.Windows.Forms.Button();
			this.checkBoxRevision = new System.Windows.Forms.CheckBox();
			this.dateTimePickerRevisionDateFrom = new System.Windows.Forms.DateTimePicker();
			this.textBoxRevNumber = new System.Windows.Forms.TextBox();
			this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
			this.checkBoxClosed = new System.Windows.Forms.CheckBox();
			this.comboBoxPrologWay = new System.Windows.Forms.ComboBox();
			this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
			this.comboBoxNomenclature = new System.Windows.Forms.ComboBox();
			this.textBoxNumberIssue = new System.Windows.Forms.TextBox();
			this.numericUpDownRevisionNotify = new System.Windows.Forms.NumericUpDown();
			this.checkBoxRevisionValidTo = new System.Windows.Forms.CheckBox();
			this.dateTimePickerRevisionValidTo = new System.Windows.Forms.DateTimePicker();
			this.checkBoxAboard = new System.Windows.Forms.CheckBox();
			this.comboBoxResponsible = new System.Windows.Forms.ComboBox();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.checkBoxPrivy = new System.Windows.Forms.CheckBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dictComboBoxServiceType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			labelSubType = new System.Windows.Forms.Label();
			labelDescription = new System.Windows.Forms.Label();
			labelValidFrom = new System.Windows.Forms.Label();
			labelValidToIssue = new System.Windows.Forms.Label();
			labelDocumentType = new System.Windows.Forms.Label();
			labelPayerName = new System.Windows.Forms.Label();
			labelServiceType = new System.Windows.Forms.Label();
			labelProlongation = new System.Windows.Forms.Label();
			labelNumber = new System.Windows.Forms.Label();
			labelResponsible = new System.Windows.Forms.Label();
			labelNotifyIssue = new System.Windows.Forms.Label();
			labelRevNumber = new System.Windows.Forms.Label();
			labelTemplate = new System.Windows.Forms.Label();
			labelDepartment = new System.Windows.Forms.Label();
			labelNomenclature = new System.Windows.Forms.Label();
			labelNumberIssue = new System.Windows.Forms.Label();
			labelNotifyRevision = new System.Windows.Forms.Label();
			labelValidToRevision = new System.Windows.Forms.Label();
			labelStatus = new System.Windows.Forms.Label();
			labelRemarks = new System.Windows.Forms.Label();
			labelLocation = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIssueNotify)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).BeginInit();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(352, 38);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(38, 14);
			labelSubType.TabIndex = 9;
			labelSubType.Text = "Title:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDescription.Location = new System.Drawing.Point(2, 89);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(82, 14);
			labelDescription.TabIndex = 10;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidFrom
			// 
			labelValidFrom.AutoSize = true;
			labelValidFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelValidFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidFrom.Location = new System.Drawing.Point(2, 258);
			labelValidFrom.Name = "labelValidFrom";
			labelValidFrom.Size = new System.Drawing.Size(47, 14);
			labelValidFrom.TabIndex = 13;
			labelValidFrom.Text = "Issue:";
			labelValidFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToIssue
			// 
			labelValidToIssue.AutoSize = true;
			labelValidToIssue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelValidToIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToIssue.Location = new System.Drawing.Point(2, 342);
			labelValidToIssue.Name = "labelValidToIssue";
			labelValidToIssue.Size = new System.Drawing.Size(59, 14);
			labelValidToIssue.TabIndex = 15;
			labelValidToIssue.Text = "Valid To:";
			labelValidToIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDocumentType
			// 
			labelDocumentType.AutoSize = true;
			labelDocumentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDocumentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDocumentType.Location = new System.Drawing.Point(2, 38);
			labelDocumentType.Name = "labelDocumentType";
			labelDocumentType.Size = new System.Drawing.Size(72, 14);
			labelDocumentType.TabIndex = 17;
			labelDocumentType.Text = "Doc. Type:";
			labelDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPayerName
			// 
			labelPayerName.AutoSize = true;
			labelPayerName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelPayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelPayerName.Location = new System.Drawing.Point(352, 89);
			labelPayerName.Name = "labelPayerName";
			labelPayerName.Size = new System.Drawing.Size(79, 14);
			labelPayerName.TabIndex = 18;
			labelPayerName.Text = "Contractor:";
			labelPayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelServiceType
			// 
			labelServiceType.AutoSize = true;
			labelServiceType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelServiceType.Location = new System.Drawing.Point(2, 173);
			labelServiceType.Name = "labelServiceType";
			labelServiceType.Size = new System.Drawing.Size(89, 14);
			labelServiceType.TabIndex = 20;
			labelServiceType.Text = "Service type:";
			labelServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelProlongation
			// 
			labelProlongation.AutoSize = true;
			labelProlongation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelProlongation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelProlongation.Location = new System.Drawing.Point(352, 116);
			labelProlongation.Name = "labelProlongation";
			labelProlongation.Size = new System.Drawing.Size(94, 14);
			labelProlongation.TabIndex = 22;
			labelProlongation.Text = "Prolong. way:";
			labelProlongation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(2, 63);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(26, 14);
			labelNumber.TabIndex = 24;
			labelNumber.Text = "№:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelResponsible
			// 
			labelResponsible.AutoSize = true;
			labelResponsible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelResponsible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelResponsible.Location = new System.Drawing.Point(352, 63);
			labelResponsible.Name = "labelResponsible";
			labelResponsible.Size = new System.Drawing.Size(88, 14);
			labelResponsible.TabIndex = 26;
			labelResponsible.Text = "Responsible:";
			labelResponsible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyIssue
			// 
			labelNotifyIssue.AutoSize = true;
			labelNotifyIssue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNotifyIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyIssue.Location = new System.Drawing.Point(2, 365);
			labelNotifyIssue.Name = "labelNotifyIssue";
			labelNotifyIssue.Size = new System.Drawing.Size(92, 14);
			labelNotifyIssue.TabIndex = 30;
			labelNotifyIssue.Text = "Notify (days):";
			labelNotifyIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRevNumber
			// 
			labelRevNumber.AutoSize = true;
			labelRevNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelRevNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRevNumber.Location = new System.Drawing.Point(353, 225);
			labelRevNumber.Name = "labelRevNumber";
			labelRevNumber.Size = new System.Drawing.Size(52, 14);
			labelRevNumber.TabIndex = 38;
			labelRevNumber.Text = "Rev.№:";
			labelRevNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTemplate
			// 
			labelTemplate.AutoSize = true;
			labelTemplate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelTemplate.Location = new System.Drawing.Point(2, 11);
			labelTemplate.Name = "labelTemplate";
			labelTemplate.Size = new System.Drawing.Size(80, 14);
			labelTemplate.TabIndex = 41;
			labelTemplate.Text = "Use Templ.:";
			labelTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDepartment
			// 
			labelDepartment.AutoSize = true;
			labelDepartment.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDepartment.Location = new System.Drawing.Point(2, 201);
			labelDepartment.Name = "labelDepartment";
			labelDepartment.Size = new System.Drawing.Size(87, 14);
			labelDepartment.TabIndex = 49;
			labelDepartment.Text = "Department:";
			labelDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNomenclature
			// 
			labelNomenclature.AutoSize = true;
			labelNomenclature.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNomenclature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNomenclature.Location = new System.Drawing.Point(352, 144);
			labelNomenclature.Name = "labelNomenclature";
			labelNomenclature.Size = new System.Drawing.Size(99, 14);
			labelNomenclature.TabIndex = 50;
			labelNomenclature.Text = "Nomenclature:";
			labelNomenclature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNumberIssue
			// 
			labelNumberIssue.AutoSize = true;
			labelNumberIssue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNumberIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumberIssue.Location = new System.Drawing.Point(2, 283);
			labelNumberIssue.Name = "labelNumberIssue";
			labelNumberIssue.Size = new System.Drawing.Size(65, 14);
			labelNumberIssue.TabIndex = 52;
			labelNumberIssue.Text = "№ Issue:";
			labelNumberIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyRevision
			// 
			labelNotifyRevision.AutoSize = true;
			labelNotifyRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNotifyRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyRevision.Location = new System.Drawing.Point(352, 307);
			labelNotifyRevision.Name = "labelNotifyRevision";
			labelNotifyRevision.Size = new System.Drawing.Size(92, 14);
			labelNotifyRevision.TabIndex = 57;
			labelNotifyRevision.Text = "Notify (days):";
			labelNotifyRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToRevision
			// 
			labelValidToRevision.AutoSize = true;
			labelValidToRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelValidToRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToRevision.Location = new System.Drawing.Point(353, 284);
			labelValidToRevision.Name = "labelValidToRevision";
			labelValidToRevision.Size = new System.Drawing.Size(59, 14);
			labelValidToRevision.TabIndex = 55;
			labelValidToRevision.Text = "Valid To:";
			labelValidToRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelStatus
			// 
			labelStatus.AutoSize = true;
			labelStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelStatus.Location = new System.Drawing.Point(353, 339);
			labelStatus.Name = "labelStatus";
			labelStatus.Size = new System.Drawing.Size(52, 14);
			labelStatus.TabIndex = 60;
			labelStatus.Text = "STATUS";
			labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRemarks
			// 
			labelRemarks.AutoSize = true;
			labelRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRemarks.Location = new System.Drawing.Point(2, 399);
			labelRemarks.Name = "labelRemarks";
			labelRemarks.Size = new System.Drawing.Size(66, 14);
			labelRemarks.TabIndex = 63;
			labelRemarks.Text = "Remarks:";
			labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLocation
			// 
			labelLocation.AutoSize = true;
			labelLocation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelLocation.Location = new System.Drawing.Point(353, 174);
			labelLocation.Name = "labelLocation";
			labelLocation.Size = new System.Drawing.Size(65, 14);
			labelLocation.TabIndex = 65;
			labelLocation.Text = "Location:";
			labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxSubType
			// 
			this.comboBoxSubType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSubType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxSubType.FormattingEnabled = true;
			this.comboBoxSubType.Location = new System.Drawing.Point(448, 35);
			this.comboBoxSubType.Name = "comboBoxSubType";
			this.comboBoxSubType.Size = new System.Drawing.Size(221, 22);
			this.comboBoxSubType.TabIndex = 0;
			this.comboBoxSubType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubType_SelectedIndexChanged);
			this.comboBoxSubType.TextUpdate += new System.EventHandler(this.comboBoxSubType_TextUpdate);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Location = new System.Drawing.Point(97, 87);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(250, 80);
			this.textBoxDescription.TabIndex = 11;
			// 
			// dateTimePickerIssueValidFrom
			// 
			this.dateTimePickerIssueValidFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerIssueValidFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerIssueValidFrom.Location = new System.Drawing.Point(97, 253);
			this.dateTimePickerIssueValidFrom.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerIssueValidFrom.Name = "dateTimePickerIssueValidFrom";
			this.dateTimePickerIssueValidFrom.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerIssueValidFrom.TabIndex = 12;
			this.dateTimePickerIssueValidFrom.ValueChanged += new System.EventHandler(this.DateTimePickerIssueValidFromValueChanged);
			// 
			// dateTimePickerIssueValidTo
			// 
			this.dateTimePickerIssueValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerIssueValidTo.Enabled = false;
			this.dateTimePickerIssueValidTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerIssueValidTo.Location = new System.Drawing.Point(97, 336);
			this.dateTimePickerIssueValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerIssueValidTo.Name = "dateTimePickerIssueValidTo";
			this.dateTimePickerIssueValidTo.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerIssueValidTo.TabIndex = 14;
			this.dateTimePickerIssueValidTo.ValueChanged += new System.EventHandler(this.DateTimePickerIssueValidToValueChanged);
			// 
			// comboBoxDocumentType
			// 
			this.comboBoxDocumentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDocumentType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDocumentType.FormattingEnabled = true;
			this.comboBoxDocumentType.Location = new System.Drawing.Point(97, 35);
			this.comboBoxDocumentType.Name = "comboBoxDocumentType";
			this.comboBoxDocumentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentType.TabIndex = 16;
			this.comboBoxDocumentType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDocumentTypeSelectedIndexChanged);
			// 
			// textBoxContractNumber
			// 
			this.textBoxContractNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxContractNumber.Location = new System.Drawing.Point(97, 61);
			this.textBoxContractNumber.Name = "textBoxContractNumber";
			this.textBoxContractNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxContractNumber.TabIndex = 25;
			// 
			// checkBoxIssueValidTo
			// 
			this.checkBoxIssueValidTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIssueValidTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxIssueValidTo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxIssueValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIssueValidTo.Location = new System.Drawing.Point(97, 307);
			this.checkBoxIssueValidTo.Name = "checkBoxIssueValidTo";
			this.checkBoxIssueValidTo.Size = new System.Drawing.Size(80, 25);
			this.checkBoxIssueValidTo.TabIndex = 29;
			this.checkBoxIssueValidTo.Text = "Valid To";
			this.checkBoxIssueValidTo.CheckedChanged += new System.EventHandler(this.CheckBoxIssueValidToCheckedChanged);
			// 
			// numericUpDownIssueNotify
			// 
			this.numericUpDownIssueNotify.Enabled = false;
			this.numericUpDownIssueNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownIssueNotify.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownIssueNotify.Location = new System.Drawing.Point(97, 365);
			this.numericUpDownIssueNotify.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownIssueNotify.Name = "numericUpDownIssueNotify";
			this.numericUpDownIssueNotify.Size = new System.Drawing.Size(250, 22);
			this.numericUpDownIssueNotify.TabIndex = 31;
			this.numericUpDownIssueNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(623, 525);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 33;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Location = new System.Drawing.Point(542, 525);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 32;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// _buttonEditTypes
			// 
			this._buttonEditTypes.Location = new System.Drawing.Point(675, 35);
			this._buttonEditTypes.Name = "_buttonEditTypes";
			this._buttonEditTypes.Size = new System.Drawing.Size(23, 20);
			this._buttonEditTypes.TabIndex = 34;
			this._buttonEditTypes.Text = "...";
			this._buttonEditTypes.UseVisualStyleBackColor = true;
			this._buttonEditTypes.Click += new System.EventHandler(this.ButtonEditTypesClick);
			// 
			// checkBoxRevision
			// 
			this.checkBoxRevision.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxRevision.Location = new System.Drawing.Point(355, 195);
			this.checkBoxRevision.Name = "checkBoxRevision";
			this.checkBoxRevision.Size = new System.Drawing.Size(89, 25);
			this.checkBoxRevision.TabIndex = 37;
			this.checkBoxRevision.Text = "Revision";
			this.checkBoxRevision.CheckedChanged += new System.EventHandler(this.CheckBoxRevisionCheckedChanged);
			// 
			// dateTimePickerRevisionDateFrom
			// 
			this.dateTimePickerRevisionDateFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerRevisionDateFrom.Enabled = false;
			this.dateTimePickerRevisionDateFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerRevisionDateFrom.Location = new System.Drawing.Point(448, 195);
			this.dateTimePickerRevisionDateFrom.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRevisionDateFrom.Name = "dateTimePickerRevisionDateFrom";
			this.dateTimePickerRevisionDateFrom.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerRevisionDateFrom.TabIndex = 35;
			// 
			// textBoxRevNumber
			// 
			this.textBoxRevNumber.Enabled = false;
			this.textBoxRevNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRevNumber.Location = new System.Drawing.Point(448, 222);
			this.textBoxRevNumber.Name = "textBoxRevNumber";
			this.textBoxRevNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxRevNumber.TabIndex = 39;
			// 
			// comboBoxTemplate
			// 
			this.comboBoxTemplate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxTemplate.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxTemplate.FormattingEnabled = true;
			this.comboBoxTemplate.Location = new System.Drawing.Point(97, 8);
			this.comboBoxTemplate.Name = "comboBoxTemplate";
			this.comboBoxTemplate.Size = new System.Drawing.Size(601, 22);
			this.comboBoxTemplate.TabIndex = 40;
			this.comboBoxTemplate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTemplateSelectedIndexChanged);
			// 
			// checkBoxClosed
			// 
			this.checkBoxClosed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxClosed.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxClosed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxClosed.Location = new System.Drawing.Point(448, 333);
			this.checkBoxClosed.Name = "checkBoxClosed";
			this.checkBoxClosed.Size = new System.Drawing.Size(75, 25);
			this.checkBoxClosed.TabIndex = 42;
			this.checkBoxClosed.Text = "Closed";
			// 
			// comboBoxPrologWay
			// 
			this.comboBoxPrologWay.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxPrologWay.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxPrologWay.FormattingEnabled = true;
			this.comboBoxPrologWay.Location = new System.Drawing.Point(448, 113);
			this.comboBoxPrologWay.Name = "comboBoxPrologWay";
			this.comboBoxPrologWay.Size = new System.Drawing.Size(250, 22);
			this.comboBoxPrologWay.TabIndex = 45;
			// 
			// comboBoxDepartment
			// 
			this.comboBoxDepartment.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDepartment.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDepartment.FormattingEnabled = true;
			this.comboBoxDepartment.Location = new System.Drawing.Point(97, 198);
			this.comboBoxDepartment.Name = "comboBoxDepartment";
			this.comboBoxDepartment.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDepartment.TabIndex = 48;
			this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
			// 
			// comboBoxNomenclature
			// 
			this.comboBoxNomenclature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.comboBoxNomenclature.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxNomenclature.FormattingEnabled = true;
			this.comboBoxNomenclature.Location = new System.Drawing.Point(448, 141);
			this.comboBoxNomenclature.Name = "comboBoxNomenclature";
			this.comboBoxNomenclature.Size = new System.Drawing.Size(250, 21);
			this.comboBoxNomenclature.TabIndex = 51;
			this.comboBoxNomenclature.TextUpdate += new System.EventHandler(this.comboBoxNomenclature_TextUpdate);
			// 
			// textBoxNumberIssue
			// 
			this.textBoxNumberIssue.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxNumberIssue.Location = new System.Drawing.Point(97, 281);
			this.textBoxNumberIssue.Name = "textBoxNumberIssue";
			this.textBoxNumberIssue.Size = new System.Drawing.Size(250, 20);
			this.textBoxNumberIssue.TabIndex = 53;
			// 
			// numericUpDownRevisionNotify
			// 
			this.numericUpDownRevisionNotify.Enabled = false;
			this.numericUpDownRevisionNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownRevisionNotify.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownRevisionNotify.Location = new System.Drawing.Point(448, 305);
			this.numericUpDownRevisionNotify.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownRevisionNotify.Name = "numericUpDownRevisionNotify";
			this.numericUpDownRevisionNotify.Size = new System.Drawing.Size(250, 22);
			this.numericUpDownRevisionNotify.TabIndex = 58;
			this.numericUpDownRevisionNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// checkBoxRevisionValidTo
			// 
			this.checkBoxRevisionValidTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRevisionValidTo.Enabled = false;
			this.checkBoxRevisionValidTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxRevisionValidTo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRevisionValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxRevisionValidTo.Location = new System.Drawing.Point(448, 247);
			this.checkBoxRevisionValidTo.Name = "checkBoxRevisionValidTo";
			this.checkBoxRevisionValidTo.Size = new System.Drawing.Size(80, 25);
			this.checkBoxRevisionValidTo.TabIndex = 56;
			this.checkBoxRevisionValidTo.Text = "Valid To";
			this.checkBoxRevisionValidTo.CheckedChanged += new System.EventHandler(this.CheckBoxRevisionValidToCheckedChanged);
			// 
			// dateTimePickerRevisionValidTo
			// 
			this.dateTimePickerRevisionValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerRevisionValidTo.Enabled = false;
			this.dateTimePickerRevisionValidTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerRevisionValidTo.Location = new System.Drawing.Point(448, 276);
			this.dateTimePickerRevisionValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRevisionValidTo.Name = "dateTimePickerRevisionValidTo";
			this.dateTimePickerRevisionValidTo.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerRevisionValidTo.TabIndex = 54;
			// 
			// checkBoxAboard
			// 
			this.checkBoxAboard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxAboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxAboard.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxAboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxAboard.Location = new System.Drawing.Point(529, 333);
			this.checkBoxAboard.Name = "checkBoxAboard";
			this.checkBoxAboard.Size = new System.Drawing.Size(75, 25);
			this.checkBoxAboard.TabIndex = 59;
			this.checkBoxAboard.Text = "Aboard";
			// 
			// comboBoxResponsible
			// 
			this.comboBoxResponsible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxResponsible.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxResponsible.FormattingEnabled = true;
			this.comboBoxResponsible.Location = new System.Drawing.Point(448, 61);
			this.comboBoxResponsible.Name = "comboBoxResponsible";
			this.comboBoxResponsible.Size = new System.Drawing.Size(250, 22);
			this.comboBoxResponsible.TabIndex = 61;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Location = new System.Drawing.Point(97, 397);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(250, 80);
			this.textBoxRemarks.TabIndex = 64;
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplier.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(448, 87);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplier.TabIndex = 67;
			// 
			// checkBoxPrivy
			// 
			this.checkBoxPrivy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPrivy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxPrivy.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxPrivy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPrivy.Location = new System.Drawing.Point(610, 333);
			this.checkBoxPrivy.Name = "checkBoxPrivy";
			this.checkBoxPrivy.Size = new System.Drawing.Size(75, 25);
			this.checkBoxPrivy.TabIndex = 68;
			this.checkBoxPrivy.Text = "Privy";
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(448, 169);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(250, 21);
			this.dictionaryComboBoxLocation.TabIndex = 66;
			// 
			// dictComboBoxServiceType
			// 
			this.dictComboBoxServiceType.Displayer = null;
			this.dictComboBoxServiceType.DisplayerText = null;
			this.dictComboBoxServiceType.Entity = null;
			this.dictComboBoxServiceType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dictComboBoxServiceType.ForeColor = System.Drawing.Color.DimGray;
			this.dictComboBoxServiceType.Location = new System.Drawing.Point(99, 171);
			this.dictComboBoxServiceType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dictComboBoxServiceType.Name = "dictComboBoxServiceType";
			this.dictComboBoxServiceType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictComboBoxServiceType.Size = new System.Drawing.Size(248, 22);
			this.dictComboBoxServiceType.TabIndex = 62;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.BackColor = System.Drawing.Color.Transparent;
			this.fileControl.Description1 = null;
			this.fileControl.Description2 = null;
			this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = null;
			this.fileControl.Location = new System.Drawing.Point(356, 366);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 100);
			this.fileControl.TabIndex = 28;
			// 
			// DocumentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 555);
			this.Controls.Add(this.checkBoxPrivy);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(labelLocation);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(labelRemarks);
			this.Controls.Add(this.dictComboBoxServiceType);
			this.Controls.Add(this.comboBoxResponsible);
			this.Controls.Add(labelStatus);
			this.Controls.Add(this.checkBoxAboard);
			this.Controls.Add(this.numericUpDownRevisionNotify);
			this.Controls.Add(labelNotifyRevision);
			this.Controls.Add(this.checkBoxRevisionValidTo);
			this.Controls.Add(labelValidToRevision);
			this.Controls.Add(this.dateTimePickerRevisionValidTo);
			this.Controls.Add(this.textBoxNumberIssue);
			this.Controls.Add(labelNumberIssue);
			this.Controls.Add(this.comboBoxNomenclature);
			this.Controls.Add(labelNomenclature);
			this.Controls.Add(labelDepartment);
			this.Controls.Add(this.comboBoxDepartment);
			this.Controls.Add(this.comboBoxPrologWay);
			this.Controls.Add(this.checkBoxClosed);
			this.Controls.Add(labelTemplate);
			this.Controls.Add(this.comboBoxTemplate);
			this.Controls.Add(this.textBoxRevNumber);
			this.Controls.Add(labelRevNumber);
			this.Controls.Add(this.checkBoxRevision);
			this.Controls.Add(this.dateTimePickerRevisionDateFrom);
			this.Controls.Add(this._buttonEditTypes);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.numericUpDownIssueNotify);
			this.Controls.Add(labelNotifyIssue);
			this.Controls.Add(this.checkBoxIssueValidTo);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(labelResponsible);
			this.Controls.Add(this.textBoxContractNumber);
			this.Controls.Add(labelNumber);
			this.Controls.Add(labelProlongation);
			this.Controls.Add(labelServiceType);
			this.Controls.Add(labelPayerName);
			this.Controls.Add(labelDocumentType);
			this.Controls.Add(this.comboBoxDocumentType);
			this.Controls.Add(labelValidToIssue);
			this.Controls.Add(this.dateTimePickerIssueValidTo);
			this.Controls.Add(labelValidFrom);
			this.Controls.Add(this.dateTimePickerIssueValidFrom);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(labelDescription);
			this.Controls.Add(labelSubType);
			this.Controls.Add(this.comboBoxSubType);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(722, 690);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(722, 523);
			this.Name = "DocumentForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Document Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIssueNotify)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
	        this.Load += DocumentForm_Load;

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxSubType;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssueValidFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssueValidTo;
        private System.Windows.Forms.ComboBox comboBoxDocumentType;
        private System.Windows.Forms.TextBox textBoxContractNumber;
        public AttachedFileControl fileControl;
        private System.Windows.Forms.CheckBox checkBoxIssueValidTo;
        private System.Windows.Forms.NumericUpDown numericUpDownIssueNotify;
        public System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button _buttonEditTypes;
        private System.Windows.Forms.CheckBox checkBoxRevision;
        private System.Windows.Forms.DateTimePicker dateTimePickerRevisionDateFrom;
        private System.Windows.Forms.TextBox textBoxRevNumber;
        private System.Windows.Forms.ComboBox comboBoxTemplate;
        private System.Windows.Forms.CheckBox checkBoxClosed;
		private System.Windows.Forms.ComboBox comboBoxPrologWay;
		private System.Windows.Forms.ComboBox comboBoxDepartment;
		private System.Windows.Forms.ComboBox comboBoxNomenclature;
		private System.Windows.Forms.TextBox textBoxNumberIssue;
		private System.Windows.Forms.NumericUpDown numericUpDownRevisionNotify;
		private System.Windows.Forms.CheckBox checkBoxRevisionValidTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerRevisionValidTo;
		private System.Windows.Forms.CheckBox checkBoxAboard;
		private System.Windows.Forms.ComboBox comboBoxResponsible;
		private DictionaryComboBox dictComboBoxServiceType;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private DictionaryComboBox dictionaryComboBoxLocation;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.CheckBox checkBoxPrivy;
	}
}