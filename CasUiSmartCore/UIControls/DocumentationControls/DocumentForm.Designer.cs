using CAS.UI.Helpers;
using CAS.UI.UIControls.Auxiliary;
using  MetroFramework.Controls;

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
			MetroFramework.Controls.MetroLabel labelSubType;
			MetroFramework.Controls.MetroLabel labelDescription;
			MetroFramework.Controls.MetroLabel labelValidFrom;
			MetroFramework.Controls.MetroLabel labelValidToIssue;
			MetroFramework.Controls.MetroLabel labelDocumentType;
			MetroFramework.Controls.MetroLabel labelPayerName;
			MetroFramework.Controls.MetroLabel labelServiceType;
			MetroFramework.Controls.MetroLabel labelProlongation;
			MetroFramework.Controls.MetroLabel labelNumber;
			MetroFramework.Controls.MetroLabel labelResponsible;
			MetroFramework.Controls.MetroLabel labelNotifyIssue;
			MetroFramework.Controls.MetroLabel labelRevNumber;
			MetroFramework.Controls.MetroLabel labelTemplate;
			MetroFramework.Controls.MetroLabel labelDepartment;
			MetroFramework.Controls.MetroLabel labelNomenclature;
			MetroFramework.Controls.MetroLabel labelNumberIssue;
			MetroFramework.Controls.MetroLabel labelNotifyRevision;
			MetroFramework.Controls.MetroLabel labelValidToRevision;
			MetroFramework.Controls.MetroLabel labelStatus;
			MetroFramework.Controls.MetroLabel labelRemarks;
			MetroFramework.Controls.MetroLabel labelLocation;
			MetroFramework.Controls.MetroLabel labelIdNumber;
			this.comboBoxSubType = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.dateTimePickerIssueValidFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerIssueValidTo = new System.Windows.Forms.DateTimePicker();
			this.comboBoxDocumentType = new System.Windows.Forms.ComboBox();
			this.textBoxContractNumber = new MetroFramework.Controls.MetroTextBox();
			this.checkBoxIssueValidTo = new MetroFramework.Controls.MetroCheckBox();
			this.numericUpDownIssueNotify = new System.Windows.Forms.NumericUpDown();
			this._buttonEditTypes = new System.Windows.Forms.Button();
			this.checkBoxRevision = new MetroFramework.Controls.MetroCheckBox();
			this.dateTimePickerRevisionDateFrom = new System.Windows.Forms.DateTimePicker();
			this.textBoxRevNumber = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
			this.checkBoxClosed = new MetroFramework.Controls.MetroCheckBox();
			this.comboBoxPrologWay = new System.Windows.Forms.ComboBox();
			this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
			this.comboBoxNomenclature = new System.Windows.Forms.ComboBox();
			this.textBoxNumberIssue = new MetroFramework.Controls.MetroTextBox();
			this.numericUpDownRevisionNotify = new System.Windows.Forms.NumericUpDown();
			this.checkBoxRevisionValidTo = new MetroFramework.Controls.MetroCheckBox();
			this.dateTimePickerRevisionValidTo = new System.Windows.Forms.DateTimePicker();
			this.checkBoxAboard = new MetroFramework.Controls.MetroCheckBox();
			this.comboBoxResponsible = new System.Windows.Forms.ComboBox();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.checkBoxPrivy = new MetroFramework.Controls.MetroCheckBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dictComboBoxServiceType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.textBoxIdNumber = new MetroFramework.Controls.MetroTextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			labelSubType = new MetroFramework.Controls.MetroLabel();
			labelDescription = new MetroFramework.Controls.MetroLabel();
			labelValidFrom = new MetroFramework.Controls.MetroLabel();
			labelValidToIssue = new MetroFramework.Controls.MetroLabel();
			labelDocumentType = new MetroFramework.Controls.MetroLabel();
			labelPayerName = new MetroFramework.Controls.MetroLabel();
			labelServiceType = new MetroFramework.Controls.MetroLabel();
			labelProlongation = new MetroFramework.Controls.MetroLabel();
			labelNumber = new MetroFramework.Controls.MetroLabel();
			labelResponsible = new MetroFramework.Controls.MetroLabel();
			labelNotifyIssue = new MetroFramework.Controls.MetroLabel();
			labelRevNumber = new MetroFramework.Controls.MetroLabel();
			labelTemplate = new MetroFramework.Controls.MetroLabel();
			labelDepartment = new MetroFramework.Controls.MetroLabel();
			labelNomenclature = new MetroFramework.Controls.MetroLabel();
			labelNumberIssue = new MetroFramework.Controls.MetroLabel();
			labelNotifyRevision = new MetroFramework.Controls.MetroLabel();
			labelValidToRevision = new MetroFramework.Controls.MetroLabel();
			labelStatus = new MetroFramework.Controls.MetroLabel();
			labelRemarks = new MetroFramework.Controls.MetroLabel();
			labelLocation = new MetroFramework.Controls.MetroLabel();
			labelIdNumber = new MetroFramework.Controls.MetroLabel();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIssueNotify)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).BeginInit();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(361, 96);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(36, 19);
			labelSubType.TabIndex = 9;
			labelSubType.Text = "Title:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDescription.Location = new System.Drawing.Point(11, 147);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(77, 19);
			labelDescription.TabIndex = 10;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidFrom
			// 
			labelValidFrom.AutoSize = true;
			labelValidFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidFrom.Location = new System.Drawing.Point(11, 310);
			labelValidFrom.Name = "labelValidFrom";
			labelValidFrom.Size = new System.Drawing.Size(39, 19);
			labelValidFrom.TabIndex = 13;
			labelValidFrom.Text = "Issue:";
			labelValidFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToIssue
			// 
			labelValidToIssue.AutoSize = true;
			labelValidToIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToIssue.Location = new System.Drawing.Point(11, 400);
			labelValidToIssue.Name = "labelValidToIssue";
			labelValidToIssue.Size = new System.Drawing.Size(56, 19);
			labelValidToIssue.TabIndex = 15;
			labelValidToIssue.Text = "Valid To:";
			labelValidToIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDocumentType
			// 
			labelDocumentType.AutoSize = true;
			labelDocumentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDocumentType.Location = new System.Drawing.Point(11, 96);
			labelDocumentType.Name = "labelDocumentType";
			labelDocumentType.Size = new System.Drawing.Size(69, 19);
			labelDocumentType.TabIndex = 17;
			labelDocumentType.Text = "Doc. Type:";
			labelDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPayerName
			// 
			labelPayerName.AutoSize = true;
			labelPayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelPayerName.Location = new System.Drawing.Point(361, 175);
			labelPayerName.Name = "labelPayerName";
			labelPayerName.Size = new System.Drawing.Size(76, 19);
			labelPayerName.TabIndex = 18;
			labelPayerName.Text = "Contractor:";
			labelPayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelServiceType
			// 
			labelServiceType.AutoSize = true;
			labelServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelServiceType.Location = new System.Drawing.Point(11, 231);
			labelServiceType.Name = "labelServiceType";
			labelServiceType.Size = new System.Drawing.Size(83, 19);
			labelServiceType.TabIndex = 20;
			labelServiceType.Text = "Service type:";
			labelServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelProlongation
			// 
			labelProlongation.AutoSize = true;
			labelProlongation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelProlongation.Location = new System.Drawing.Point(361, 202);
			labelProlongation.Name = "labelProlongation";
			labelProlongation.Size = new System.Drawing.Size(88, 19);
			labelProlongation.TabIndex = 22;
			labelProlongation.Text = "Prolong. way:";
			labelProlongation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(11, 121);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(28, 19);
			labelNumber.TabIndex = 24;
			labelNumber.Text = "№:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelResponsible
			// 
			labelResponsible.AutoSize = true;
			labelResponsible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelResponsible.Location = new System.Drawing.Point(361, 149);
			labelResponsible.Name = "labelResponsible";
			labelResponsible.Size = new System.Drawing.Size(81, 19);
			labelResponsible.TabIndex = 26;
			labelResponsible.Text = "Responsible:";
			labelResponsible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyIssue
			// 
			labelNotifyIssue.AutoSize = true;
			labelNotifyIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyIssue.Location = new System.Drawing.Point(11, 423);
			labelNotifyIssue.Name = "labelNotifyIssue";
			labelNotifyIssue.Size = new System.Drawing.Size(85, 19);
			labelNotifyIssue.TabIndex = 30;
			labelNotifyIssue.Text = "Notify (days):";
			labelNotifyIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRevNumber
			// 
			labelRevNumber.AutoSize = true;
			labelRevNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRevNumber.Location = new System.Drawing.Point(362, 311);
			labelRevNumber.Name = "labelRevNumber";
			labelRevNumber.Size = new System.Drawing.Size(51, 19);
			labelRevNumber.TabIndex = 38;
			labelRevNumber.Text = "Rev.№:";
			labelRevNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTemplate
			// 
			labelTemplate.AutoSize = true;
			labelTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelTemplate.Location = new System.Drawing.Point(11, 69);
			labelTemplate.Name = "labelTemplate";
			labelTemplate.Size = new System.Drawing.Size(75, 19);
			labelTemplate.TabIndex = 41;
			labelTemplate.Text = "Use Templ.:";
			labelTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDepartment
			// 
			labelDepartment.AutoSize = true;
			labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDepartment.Location = new System.Drawing.Point(11, 259);
			labelDepartment.Name = "labelDepartment";
			labelDepartment.Size = new System.Drawing.Size(83, 19);
			labelDepartment.TabIndex = 49;
			labelDepartment.Text = "Department:";
			labelDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNomenclature
			// 
			labelNomenclature.AutoSize = true;
			labelNomenclature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNomenclature.Location = new System.Drawing.Point(361, 230);
			labelNomenclature.Name = "labelNomenclature";
			labelNomenclature.Size = new System.Drawing.Size(95, 19);
			labelNomenclature.TabIndex = 50;
			labelNomenclature.Text = "Nomenclature:";
			labelNomenclature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNumberIssue
			// 
			labelNumberIssue.AutoSize = true;
			labelNumberIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumberIssue.Location = new System.Drawing.Point(11, 283);
			labelNumberIssue.Name = "labelNumberIssue";
			labelNumberIssue.Size = new System.Drawing.Size(59, 19);
			labelNumberIssue.TabIndex = 52;
			labelNumberIssue.Text = "№ Issue:";
			labelNumberIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyRevision
			// 
			labelNotifyRevision.AutoSize = true;
			labelNotifyRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyRevision.Location = new System.Drawing.Point(361, 425);
			labelNotifyRevision.Name = "labelNotifyRevision";
			labelNotifyRevision.Size = new System.Drawing.Size(85, 19);
			labelNotifyRevision.TabIndex = 57;
			labelNotifyRevision.Text = "Notify (days):";
			labelNotifyRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToRevision
			// 
			labelValidToRevision.AutoSize = true;
			labelValidToRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToRevision.Location = new System.Drawing.Point(362, 402);
			labelValidToRevision.Name = "labelValidToRevision";
			labelValidToRevision.Size = new System.Drawing.Size(56, 19);
			labelValidToRevision.TabIndex = 55;
			labelValidToRevision.Text = "Valid To:";
			labelValidToRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelStatus
			// 
			labelStatus.AutoSize = true;
			labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelStatus.Location = new System.Drawing.Point(362, 455);
			labelStatus.Name = "labelStatus";
			labelStatus.Size = new System.Drawing.Size(51, 19);
			labelStatus.TabIndex = 60;
			labelStatus.Text = "STATUS";
			labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRemarks
			// 
			labelRemarks.AutoSize = true;
			labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRemarks.Location = new System.Drawing.Point(11, 457);
			labelRemarks.Name = "labelRemarks";
			labelRemarks.Size = new System.Drawing.Size(62, 19);
			labelRemarks.TabIndex = 63;
			labelRemarks.Text = "Remarks:";
			labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLocation
			// 
			labelLocation.AutoSize = true;
			labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelLocation.Location = new System.Drawing.Point(362, 260);
			labelLocation.Name = "labelLocation";
			labelLocation.Size = new System.Drawing.Size(61, 19);
			labelLocation.TabIndex = 65;
			labelLocation.Text = "Location:";
			labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelIdNumber
			// 
			labelIdNumber.AutoSize = true;
			labelIdNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelIdNumber.Location = new System.Drawing.Point(362, 123);
			labelIdNumber.Name = "labelIdNumber";
			labelIdNumber.Size = new System.Drawing.Size(44, 19);
			labelIdNumber.TabIndex = 69;
			labelIdNumber.Text = "ID №:";
			labelIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxSubType
			// 
			this.comboBoxSubType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSubType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxSubType.FormattingEnabled = true;
			this.comboBoxSubType.Location = new System.Drawing.Point(457, 93);
			this.comboBoxSubType.Name = "comboBoxSubType";
			this.comboBoxSubType.Size = new System.Drawing.Size(221, 22);
			this.comboBoxSubType.TabIndex = 0;
			this.comboBoxSubType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubType_SelectedIndexChanged);
			this.comboBoxSubType.TextUpdate += new System.EventHandler(this.comboBoxSubType_TextUpdate);
			this.comboBoxSubType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxDescription
			// 
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(172, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(75, 75);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(106, 145);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(250, 80);
			this.textBoxDescription.TabIndex = 11;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerIssueValidFrom
			// 
			this.dateTimePickerIssueValidFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerIssueValidFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerIssueValidFrom.Location = new System.Drawing.Point(106, 305);
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
			this.dateTimePickerIssueValidTo.Location = new System.Drawing.Point(106, 394);
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
			this.comboBoxDocumentType.Location = new System.Drawing.Point(106, 93);
			this.comboBoxDocumentType.Name = "comboBoxDocumentType";
			this.comboBoxDocumentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentType.TabIndex = 16;
			this.comboBoxDocumentType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDocumentTypeSelectedIndexChanged);
			this.comboBoxDocumentType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxContractNumber
			// 
			// 
			// 
			// 
			this.textBoxContractNumber.CustomButton.Image = null;
			this.textBoxContractNumber.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxContractNumber.CustomButton.Name = "";
			this.textBoxContractNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxContractNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxContractNumber.CustomButton.TabIndex = 1;
			this.textBoxContractNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxContractNumber.CustomButton.UseSelectable = true;
			this.textBoxContractNumber.CustomButton.Visible = false;
			this.textBoxContractNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxContractNumber.Lines = new string[0];
			this.textBoxContractNumber.Location = new System.Drawing.Point(106, 119);
			this.textBoxContractNumber.MaxLength = 32767;
			this.textBoxContractNumber.Name = "textBoxContractNumber";
			this.textBoxContractNumber.PasswordChar = '\0';
			this.textBoxContractNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxContractNumber.SelectedText = "";
			this.textBoxContractNumber.SelectionLength = 0;
			this.textBoxContractNumber.SelectionStart = 0;
			this.textBoxContractNumber.ShortcutsEnabled = true;
			this.textBoxContractNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxContractNumber.TabIndex = 25;
			this.textBoxContractNumber.UseSelectable = true;
			this.textBoxContractNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxContractNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// checkBoxIssueValidTo
			// 
			this.checkBoxIssueValidTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIssueValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIssueValidTo.Location = new System.Drawing.Point(106, 365);
			this.checkBoxIssueValidTo.Name = "checkBoxIssueValidTo";
			this.checkBoxIssueValidTo.Size = new System.Drawing.Size(80, 25);
			this.checkBoxIssueValidTo.TabIndex = 29;
			this.checkBoxIssueValidTo.Text = "Valid To";
			this.checkBoxIssueValidTo.UseSelectable = true;
			this.checkBoxIssueValidTo.CheckedChanged += new System.EventHandler(this.CheckBoxIssueValidToCheckedChanged);
			// 
			// numericUpDownIssueNotify
			// 
			this.numericUpDownIssueNotify.Enabled = false;
			this.numericUpDownIssueNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownIssueNotify.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownIssueNotify.Location = new System.Drawing.Point(106, 423);
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
			// _buttonEditTypes
			// 
			this._buttonEditTypes.Location = new System.Drawing.Point(684, 93);
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
			this.checkBoxRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxRevision.Location = new System.Drawing.Point(364, 281);
			this.checkBoxRevision.Name = "checkBoxRevision";
			this.checkBoxRevision.Size = new System.Drawing.Size(89, 25);
			this.checkBoxRevision.TabIndex = 37;
			this.checkBoxRevision.Text = "Revision";
			this.checkBoxRevision.UseSelectable = true;
			this.checkBoxRevision.CheckedChanged += new System.EventHandler(this.CheckBoxRevisionCheckedChanged);
			// 
			// dateTimePickerRevisionDateFrom
			// 
			this.dateTimePickerRevisionDateFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerRevisionDateFrom.Enabled = false;
			this.dateTimePickerRevisionDateFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerRevisionDateFrom.Location = new System.Drawing.Point(457, 281);
			this.dateTimePickerRevisionDateFrom.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRevisionDateFrom.Name = "dateTimePickerRevisionDateFrom";
			this.dateTimePickerRevisionDateFrom.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerRevisionDateFrom.TabIndex = 35;
			// 
			// textBoxRevNumber
			// 
			// 
			// 
			// 
			this.textBoxRevNumber.CustomButton.Image = null;
			this.textBoxRevNumber.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxRevNumber.CustomButton.Name = "";
			this.textBoxRevNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxRevNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRevNumber.CustomButton.TabIndex = 1;
			this.textBoxRevNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRevNumber.CustomButton.UseSelectable = true;
			this.textBoxRevNumber.CustomButton.Visible = false;
			this.textBoxRevNumber.Enabled = false;
			this.textBoxRevNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRevNumber.Lines = new string[0];
			this.textBoxRevNumber.Location = new System.Drawing.Point(457, 308);
			this.textBoxRevNumber.MaxLength = 32767;
			this.textBoxRevNumber.Name = "textBoxRevNumber";
			this.textBoxRevNumber.PasswordChar = '\0';
			this.textBoxRevNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRevNumber.SelectedText = "";
			this.textBoxRevNumber.SelectionLength = 0;
			this.textBoxRevNumber.SelectionStart = 0;
			this.textBoxRevNumber.ShortcutsEnabled = true;
			this.textBoxRevNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxRevNumber.TabIndex = 39;
			this.textBoxRevNumber.UseSelectable = true;
			this.textBoxRevNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRevNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxTemplate
			// 
			this.comboBoxTemplate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxTemplate.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxTemplate.FormattingEnabled = true;
			this.comboBoxTemplate.Location = new System.Drawing.Point(106, 66);
			this.comboBoxTemplate.Name = "comboBoxTemplate";
			this.comboBoxTemplate.Size = new System.Drawing.Size(601, 22);
			this.comboBoxTemplate.TabIndex = 40;
			this.comboBoxTemplate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTemplateSelectedIndexChanged);
			this.comboBoxTemplate.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// checkBoxClosed
			// 
			this.checkBoxClosed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxClosed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxClosed.Location = new System.Drawing.Point(457, 449);
			this.checkBoxClosed.Name = "checkBoxClosed";
			this.checkBoxClosed.Size = new System.Drawing.Size(75, 25);
			this.checkBoxClosed.TabIndex = 42;
			this.checkBoxClosed.Text = "Closed";
			this.checkBoxClosed.UseSelectable = true;
			// 
			// comboBoxPrologWay
			// 
			this.comboBoxPrologWay.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxPrologWay.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxPrologWay.FormattingEnabled = true;
			this.comboBoxPrologWay.Location = new System.Drawing.Point(457, 199);
			this.comboBoxPrologWay.Name = "comboBoxPrologWay";
			this.comboBoxPrologWay.Size = new System.Drawing.Size(250, 22);
			this.comboBoxPrologWay.TabIndex = 45;
			this.comboBoxPrologWay.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxDepartment
			// 
			this.comboBoxDepartment.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDepartment.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDepartment.FormattingEnabled = true;
			this.comboBoxDepartment.Location = new System.Drawing.Point(106, 256);
			this.comboBoxDepartment.Name = "comboBoxDepartment";
			this.comboBoxDepartment.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDepartment.TabIndex = 48;
			this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
			this.comboBoxDepartment.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxNomenclature
			// 
			this.comboBoxNomenclature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.comboBoxNomenclature.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxNomenclature.FormattingEnabled = true;
			this.comboBoxNomenclature.Location = new System.Drawing.Point(457, 227);
			this.comboBoxNomenclature.Name = "comboBoxNomenclature";
			this.comboBoxNomenclature.Size = new System.Drawing.Size(250, 21);
			this.comboBoxNomenclature.TabIndex = 51;
			this.comboBoxNomenclature.TextUpdate += new System.EventHandler(this.comboBoxNomenclature_TextUpdate);
			this.comboBoxNomenclature.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxNumberIssue
			// 
			// 
			// 
			// 
			this.textBoxNumberIssue.CustomButton.Image = null;
			this.textBoxNumberIssue.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxNumberIssue.CustomButton.Name = "";
			this.textBoxNumberIssue.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxNumberIssue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNumberIssue.CustomButton.TabIndex = 1;
			this.textBoxNumberIssue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNumberIssue.CustomButton.UseSelectable = true;
			this.textBoxNumberIssue.CustomButton.Visible = false;
			this.textBoxNumberIssue.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxNumberIssue.Lines = new string[0];
			this.textBoxNumberIssue.Location = new System.Drawing.Point(106, 281);
			this.textBoxNumberIssue.MaxLength = 32767;
			this.textBoxNumberIssue.Name = "textBoxNumberIssue";
			this.textBoxNumberIssue.PasswordChar = '\0';
			this.textBoxNumberIssue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNumberIssue.SelectedText = "";
			this.textBoxNumberIssue.SelectionLength = 0;
			this.textBoxNumberIssue.SelectionStart = 0;
			this.textBoxNumberIssue.ShortcutsEnabled = true;
			this.textBoxNumberIssue.Size = new System.Drawing.Size(250, 20);
			this.textBoxNumberIssue.TabIndex = 53;
			this.textBoxNumberIssue.UseSelectable = true;
			this.textBoxNumberIssue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNumberIssue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// numericUpDownRevisionNotify
			// 
			this.numericUpDownRevisionNotify.Enabled = false;
			this.numericUpDownRevisionNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownRevisionNotify.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownRevisionNotify.Location = new System.Drawing.Point(457, 423);
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
			this.checkBoxRevisionValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxRevisionValidTo.Location = new System.Drawing.Point(457, 365);
			this.checkBoxRevisionValidTo.Name = "checkBoxRevisionValidTo";
			this.checkBoxRevisionValidTo.Size = new System.Drawing.Size(80, 25);
			this.checkBoxRevisionValidTo.TabIndex = 56;
			this.checkBoxRevisionValidTo.Text = "Valid To";
			this.checkBoxRevisionValidTo.UseSelectable = true;
			this.checkBoxRevisionValidTo.CheckedChanged += new System.EventHandler(this.CheckBoxRevisionValidToCheckedChanged);
			// 
			// dateTimePickerRevisionValidTo
			// 
			this.dateTimePickerRevisionValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerRevisionValidTo.Enabled = false;
			this.dateTimePickerRevisionValidTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerRevisionValidTo.Location = new System.Drawing.Point(457, 394);
			this.dateTimePickerRevisionValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRevisionValidTo.Name = "dateTimePickerRevisionValidTo";
			this.dateTimePickerRevisionValidTo.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerRevisionValidTo.TabIndex = 54;
			// 
			// checkBoxAboard
			// 
			this.checkBoxAboard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxAboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxAboard.Location = new System.Drawing.Point(538, 449);
			this.checkBoxAboard.Name = "checkBoxAboard";
			this.checkBoxAboard.Size = new System.Drawing.Size(75, 25);
			this.checkBoxAboard.TabIndex = 59;
			this.checkBoxAboard.Text = "Aboard";
			this.checkBoxAboard.UseSelectable = true;
			// 
			// comboBoxResponsible
			// 
			this.comboBoxResponsible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxResponsible.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxResponsible.FormattingEnabled = true;
			this.comboBoxResponsible.Location = new System.Drawing.Point(457, 147);
			this.comboBoxResponsible.Name = "comboBoxResponsible";
			this.comboBoxResponsible.Size = new System.Drawing.Size(250, 22);
			this.comboBoxResponsible.TabIndex = 61;
			this.comboBoxResponsible.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(172, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(75, 75);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(106, 455);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(250, 80);
			this.textBoxRemarks.TabIndex = 64;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplier.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(457, 173);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplier.TabIndex = 67;
			this.comboBoxSupplier.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// checkBoxPrivy
			// 
			this.checkBoxPrivy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPrivy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPrivy.Location = new System.Drawing.Point(619, 449);
			this.checkBoxPrivy.Name = "checkBoxPrivy";
			this.checkBoxPrivy.Size = new System.Drawing.Size(75, 25);
			this.checkBoxPrivy.TabIndex = 68;
			this.checkBoxPrivy.Text = "Privy";
			this.checkBoxPrivy.UseSelectable = true;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(457, 255);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(250, 21);
			this.dictionaryComboBoxLocation.TabIndex = 66;
			this.dictionaryComboBoxLocation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictComboBoxServiceType
			// 
			this.dictComboBoxServiceType.Displayer = null;
			this.dictComboBoxServiceType.DisplayerText = null;
			this.dictComboBoxServiceType.Entity = null;
			this.dictComboBoxServiceType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dictComboBoxServiceType.ForeColor = System.Drawing.Color.DimGray;
			this.dictComboBoxServiceType.Location = new System.Drawing.Point(108, 229);
			this.dictComboBoxServiceType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dictComboBoxServiceType.Name = "dictComboBoxServiceType";
			this.dictComboBoxServiceType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictComboBoxServiceType.Size = new System.Drawing.Size(248, 22);
			this.dictComboBoxServiceType.TabIndex = 62;
			this.dictComboBoxServiceType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			this.fileControl.Location = new System.Drawing.Point(365, 477);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 100);
			this.fileControl.TabIndex = 28;
			// 
			// textBoxIdNumber
			// 
			// 
			// 
			// 
			this.textBoxIdNumber.CustomButton.Image = null;
			this.textBoxIdNumber.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxIdNumber.CustomButton.Name = "";
			this.textBoxIdNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxIdNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxIdNumber.CustomButton.TabIndex = 1;
			this.textBoxIdNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxIdNumber.CustomButton.UseSelectable = true;
			this.textBoxIdNumber.CustomButton.Visible = false;
			this.textBoxIdNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxIdNumber.Lines = new string[0];
			this.textBoxIdNumber.Location = new System.Drawing.Point(457, 121);
			this.textBoxIdNumber.MaxLength = 32767;
			this.textBoxIdNumber.Name = "textBoxIdNumber";
			this.textBoxIdNumber.PasswordChar = '\0';
			this.textBoxIdNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxIdNumber.SelectedText = "";
			this.textBoxIdNumber.SelectionLength = 0;
			this.textBoxIdNumber.SelectionStart = 0;
			this.textBoxIdNumber.ShortcutsEnabled = true;
			this.textBoxIdNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxIdNumber.TabIndex = 70;
			this.textBoxIdNumber.UseSelectable = true;
			this.textBoxIdNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxIdNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(559, 583);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 295;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(640, 583);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// DocumentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 639);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxIdNumber);
			this.Controls.Add(labelIdNumber);
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
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Document Form";
			this.Load += new System.EventHandler(this.DocumentForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIssueNotify)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		

		#endregion

		private System.Windows.Forms.ComboBox comboBoxSubType;
		private MetroTextBox textBoxDescription;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssueValidFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssueValidTo;
		private System.Windows.Forms.ComboBox comboBoxDocumentType;
		private MetroTextBox textBoxContractNumber;
		public AttachedFileControl fileControl;
		private MetroCheckBox checkBoxIssueValidTo;
		private System.Windows.Forms.NumericUpDown numericUpDownIssueNotify;
		private System.Windows.Forms.Button _buttonEditTypes;
		private MetroCheckBox checkBoxRevision;
		private System.Windows.Forms.DateTimePicker dateTimePickerRevisionDateFrom;
		private MetroTextBox textBoxRevNumber;
		private System.Windows.Forms.ComboBox comboBoxTemplate;
		private MetroCheckBox checkBoxClosed;
		private System.Windows.Forms.ComboBox comboBoxPrologWay;
		private System.Windows.Forms.ComboBox comboBoxDepartment;
		private System.Windows.Forms.ComboBox comboBoxNomenclature;
		private MetroTextBox textBoxNumberIssue;
		private System.Windows.Forms.NumericUpDown numericUpDownRevisionNotify;
		private MetroCheckBox checkBoxRevisionValidTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerRevisionValidTo;
		private MetroCheckBox checkBoxAboard;
		private System.Windows.Forms.ComboBox comboBoxResponsible;
		private DictionaryComboBox dictComboBoxServiceType;
		private MetroTextBox textBoxRemarks;
		private DictionaryComboBox dictionaryComboBoxLocation;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private MetroCheckBox checkBoxPrivy;
		private MetroTextBox textBoxIdNumber;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
	}
}