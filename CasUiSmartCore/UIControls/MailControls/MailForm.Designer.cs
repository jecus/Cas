using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MailControls
{
	partial class MailForm
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
			MetroFramework.Controls.MetroLabel labelDocumentType;
			MetroFramework.Controls.MetroLabel labelNumber;
			MetroFramework.Controls.MetroLabel labelTitle;
			MetroFramework.Controls.MetroLabel labelRemark;
			MetroFramework.Controls.MetroLabel labelNotifyRevision;
			MetroFramework.Controls.MetroLabel labelValidToRevision;
			MetroFramework.Controls.MetroLabel label2;
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel labelDescription;
			MetroFramework.Controls.MetroLabel labelLocation;
			this.comboBoxDocumentType = new System.Windows.Forms.ComboBox();
			this.textBoxNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelFrom = new MetroFramework.Controls.MetroLabel();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.textBoxReferenceNumber = new MetroFramework.Controls.MetroTextBox();
			this.dateTimePickerReceiveMailDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerCreateMailDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.checkBoxRevisionPerformeUpTo = new System.Windows.Forms.CheckBox();
			this.dateTimePickerRevisionPerformeUpTo = new System.Windows.Forms.DateTimePicker();
			this.numericUpDownRevisionNotify = new System.Windows.Forms.NumericUpDown();
			this.labelDepartment = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
			this.labelResponsible = new MetroFramework.Controls.MetroLabel();
			this.comboBoxOccupation = new System.Windows.Forms.ComboBox();
			this.labelExecutor = new MetroFramework.Controls.MetroLabel();
			this.comboBoxSpecialist = new System.Windows.Forms.ComboBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.comboBoxDocumentClass = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxNomenclature = new System.Windows.Forms.ComboBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			labelDocumentType = new MetroFramework.Controls.MetroLabel();
			labelNumber = new MetroFramework.Controls.MetroLabel();
			labelTitle = new MetroFramework.Controls.MetroLabel();
			labelRemark = new MetroFramework.Controls.MetroLabel();
			labelNotifyRevision = new MetroFramework.Controls.MetroLabel();
			labelValidToRevision = new MetroFramework.Controls.MetroLabel();
			label2 = new MetroFramework.Controls.MetroLabel();
			label1 = new MetroFramework.Controls.MetroLabel();
			labelDescription = new MetroFramework.Controls.MetroLabel();
			labelLocation = new MetroFramework.Controls.MetroLabel();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDocumentType
			// 
			labelDocumentType.AutoSize = true;
			labelDocumentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDocumentType.Location = new System.Drawing.Point(18, 102);
			labelDocumentType.Name = "labelDocumentType";
			labelDocumentType.Size = new System.Drawing.Size(69, 19);
			labelDocumentType.TabIndex = 19;
			labelDocumentType.Text = "Doc. Type:";
			labelDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(18, 154);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(28, 19);
			labelNumber.TabIndex = 26;
			labelNumber.Text = "№:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTitle
			// 
			labelTitle.AutoSize = true;
			labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelTitle.Location = new System.Drawing.Point(18, 208);
			labelTitle.Name = "labelTitle";
			labelTitle.Size = new System.Drawing.Size(36, 19);
			labelTitle.TabIndex = 209;
			labelTitle.Text = "Title:";
			labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRemark
			// 
			labelRemark.AutoSize = true;
			labelRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRemark.Location = new System.Drawing.Point(18, 383);
			labelRemark.Name = "labelRemark";
			labelRemark.Size = new System.Drawing.Size(57, 19);
			labelRemark.TabIndex = 212;
			labelRemark.Text = "Remark:";
			labelRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyRevision
			// 
			labelNotifyRevision.AutoSize = true;
			labelNotifyRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyRevision.Location = new System.Drawing.Point(369, 258);
			labelNotifyRevision.Name = "labelNotifyRevision";
			labelNotifyRevision.Size = new System.Drawing.Size(85, 19);
			labelNotifyRevision.TabIndex = 218;
			labelNotifyRevision.Text = "Notify (days):";
			labelNotifyRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToRevision
			// 
			labelValidToRevision.AutoSize = true;
			labelValidToRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToRevision.Location = new System.Drawing.Point(369, 231);
			labelValidToRevision.Name = "labelValidToRevision";
			labelValidToRevision.Size = new System.Drawing.Size(98, 19);
			labelValidToRevision.TabIndex = 217;
			labelValidToRevision.Text = "Perform Up To:";
			labelValidToRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(369, 152);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(90, 19);
			label2.TabIndex = 230;
			label2.Text = "Reference №:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(18, 74);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 19);
			label1.TabIndex = 232;
			label1.Text = "Doc. Class:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDescription.Location = new System.Drawing.Point(17, 294);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(77, 19);
			labelDescription.TabIndex = 233;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLocation
			// 
			labelLocation.AutoSize = true;
			labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelLocation.Location = new System.Drawing.Point(369, 393);
			labelLocation.Name = "labelLocation";
			labelLocation.Size = new System.Drawing.Size(61, 19);
			labelLocation.TabIndex = 238;
			labelLocation.Text = "Location:";
			labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxDocumentType
			// 
			this.comboBoxDocumentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDocumentType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDocumentType.FormattingEnabled = true;
			this.comboBoxDocumentType.Location = new System.Drawing.Point(113, 99);
			this.comboBoxDocumentType.Name = "comboBoxDocumentType";
			this.comboBoxDocumentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentType.TabIndex = 18;
			this.comboBoxDocumentType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxNumber
			// 
			// 
			// 
			// 
			this.textBoxNumber.CustomButton.Image = null;
			this.textBoxNumber.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxNumber.CustomButton.Name = "";
			this.textBoxNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNumber.CustomButton.TabIndex = 1;
			this.textBoxNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNumber.CustomButton.UseSelectable = true;
			this.textBoxNumber.CustomButton.Visible = false;
			this.textBoxNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxNumber.Lines = new string[0];
			this.textBoxNumber.Location = new System.Drawing.Point(113, 152);
			this.textBoxNumber.MaxLength = 32767;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.PasswordChar = '\0';
			this.textBoxNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNumber.SelectedText = "";
			this.textBoxNumber.SelectionLength = 0;
			this.textBoxNumber.SelectionStart = 0;
			this.textBoxNumber.ShortcutsEnabled = true;
			this.textBoxNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxNumber.TabIndex = 27;
			this.textBoxNumber.UseSelectable = true;
			this.textBoxNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelFrom
			// 
			this.labelFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFrom.Location = new System.Drawing.Point(18, 125);
			this.labelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(72, 25);
			this.labelFrom.TabIndex = 203;
			this.labelFrom.Text = "From:";
			this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.BackColor = System.Drawing.Color.White;
			this.comboBoxSupplier.Enabled = false;
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupplier.Location = new System.Drawing.Point(113, 125);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplier.TabIndex = 202;
			this.comboBoxSupplier.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxReferenceNumber
			// 
			// 
			// 
			// 
			this.textBoxReferenceNumber.CustomButton.Image = null;
			this.textBoxReferenceNumber.CustomButton.Location = new System.Drawing.Point(221, 2);
			this.textBoxReferenceNumber.CustomButton.Name = "";
			this.textBoxReferenceNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxReferenceNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxReferenceNumber.CustomButton.TabIndex = 1;
			this.textBoxReferenceNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxReferenceNumber.CustomButton.UseSelectable = true;
			this.textBoxReferenceNumber.CustomButton.Visible = false;
			this.textBoxReferenceNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxReferenceNumber.Lines = new string[0];
			this.textBoxReferenceNumber.Location = new System.Drawing.Point(467, 152);
			this.textBoxReferenceNumber.MaxLength = 32767;
			this.textBoxReferenceNumber.Name = "textBoxReferenceNumber";
			this.textBoxReferenceNumber.PasswordChar = '\0';
			this.textBoxReferenceNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxReferenceNumber.SelectedText = "";
			this.textBoxReferenceNumber.SelectionLength = 0;
			this.textBoxReferenceNumber.SelectionStart = 0;
			this.textBoxReferenceNumber.ShortcutsEnabled = true;
			this.textBoxReferenceNumber.Size = new System.Drawing.Size(239, 20);
			this.textBoxReferenceNumber.TabIndex = 205;
			this.textBoxReferenceNumber.UseSelectable = true;
			this.textBoxReferenceNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxReferenceNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerReceiveMailDate
			// 
			this.dateTimePickerReceiveMailDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerReceiveMailDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReceiveMailDate.Location = new System.Drawing.Point(113, 178);
			this.dateTimePickerReceiveMailDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerReceiveMailDate.Name = "dateTimePickerReceiveMailDate";
			this.dateTimePickerReceiveMailDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerReceiveMailDate.TabIndex = 206;
			// 
			// dateTimePickerCreateMailDate
			// 
			this.dateTimePickerCreateMailDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerCreateMailDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerCreateMailDate.Location = new System.Drawing.Point(467, 178);
			this.dateTimePickerCreateMailDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerCreateMailDate.Name = "dateTimePickerCreateMailDate";
			this.dateTimePickerCreateMailDate.Size = new System.Drawing.Size(239, 22);
			this.dateTimePickerCreateMailDate.TabIndex = 207;
			// 
			// textBoxTitle
			// 
			// 
			// 
			// 
			this.textBoxTitle.CustomButton.Image = null;
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(172, 2);
			this.textBoxTitle.CustomButton.Name = "";
			this.textBoxTitle.CustomButton.Size = new System.Drawing.Size(75, 75);
			this.textBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTitle.CustomButton.TabIndex = 1;
			this.textBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTitle.CustomButton.UseSelectable = true;
			this.textBoxTitle.CustomButton.Visible = false;
			this.textBoxTitle.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxTitle.Lines = new string[0];
			this.textBoxTitle.Location = new System.Drawing.Point(113, 206);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Multiline = true;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.SelectionLength = 0;
			this.textBoxTitle.SelectionStart = 0;
			this.textBoxTitle.ShortcutsEnabled = true;
			this.textBoxTitle.Size = new System.Drawing.Size(250, 80);
			this.textBoxTitle.TabIndex = 210;
			this.textBoxTitle.UseSelectable = true;
			this.textBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
			this.textBoxRemarks.Location = new System.Drawing.Point(113, 381);
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
			this.textBoxRemarks.TabIndex = 213;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// checkBoxRevisionPerformeUpTo
			// 
			this.checkBoxRevisionPerformeUpTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRevisionPerformeUpTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxRevisionPerformeUpTo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRevisionPerformeUpTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxRevisionPerformeUpTo.Location = new System.Drawing.Point(467, 202);
			this.checkBoxRevisionPerformeUpTo.Name = "checkBoxRevisionPerformeUpTo";
			this.checkBoxRevisionPerformeUpTo.Size = new System.Drawing.Size(127, 25);
			this.checkBoxRevisionPerformeUpTo.TabIndex = 216;
			this.checkBoxRevisionPerformeUpTo.Text = "Perform Up To";
			this.checkBoxRevisionPerformeUpTo.CheckedChanged += new System.EventHandler(this.checkBoxRevisionPerformeUpTo_CheckedChanged);
			// 
			// dateTimePickerRevisionPerformeUpTo
			// 
			this.dateTimePickerRevisionPerformeUpTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerRevisionPerformeUpTo.Enabled = false;
			this.dateTimePickerRevisionPerformeUpTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerRevisionPerformeUpTo.Location = new System.Drawing.Point(467, 231);
			this.dateTimePickerRevisionPerformeUpTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerRevisionPerformeUpTo.Name = "dateTimePickerRevisionPerformeUpTo";
			this.dateTimePickerRevisionPerformeUpTo.Size = new System.Drawing.Size(239, 22);
			this.dateTimePickerRevisionPerformeUpTo.TabIndex = 215;
			// 
			// numericUpDownRevisionNotify
			// 
			this.numericUpDownRevisionNotify.Enabled = false;
			this.numericUpDownRevisionNotify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownRevisionNotify.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownRevisionNotify.Location = new System.Drawing.Point(467, 258);
			this.numericUpDownRevisionNotify.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
			this.numericUpDownRevisionNotify.Name = "numericUpDownRevisionNotify";
			this.numericUpDownRevisionNotify.Size = new System.Drawing.Size(239, 22);
			this.numericUpDownRevisionNotify.TabIndex = 219;
			this.numericUpDownRevisionNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelDepartment
			// 
			this.labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDepartment.Location = new System.Drawing.Point(369, 286);
			this.labelDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDepartment.Name = "labelDepartment";
			this.labelDepartment.Size = new System.Drawing.Size(92, 25);
			this.labelDepartment.TabIndex = 221;
			this.labelDepartment.Text = "Department:";
			this.labelDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxDepartment
			// 
			this.comboBoxDepartment.BackColor = System.Drawing.Color.White;
			this.comboBoxDepartment.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxDepartment.Location = new System.Drawing.Point(467, 286);
			this.comboBoxDepartment.Name = "comboBoxDepartment";
			this.comboBoxDepartment.Size = new System.Drawing.Size(239, 22);
			this.comboBoxDepartment.TabIndex = 220;
			this.comboBoxDepartment.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelResponsible
			// 
			this.labelResponsible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelResponsible.Location = new System.Drawing.Point(369, 314);
			this.labelResponsible.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelResponsible.Name = "labelResponsible";
			this.labelResponsible.Size = new System.Drawing.Size(92, 25);
			this.labelResponsible.TabIndex = 223;
			this.labelResponsible.Text = "Responsible:";
			this.labelResponsible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxOccupation
			// 
			this.comboBoxOccupation.BackColor = System.Drawing.Color.White;
			this.comboBoxOccupation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxOccupation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxOccupation.Location = new System.Drawing.Point(467, 314);
			this.comboBoxOccupation.Name = "comboBoxOccupation";
			this.comboBoxOccupation.Size = new System.Drawing.Size(239, 22);
			this.comboBoxOccupation.TabIndex = 222;
			this.comboBoxOccupation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelExecutor
			// 
			this.labelExecutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelExecutor.Location = new System.Drawing.Point(369, 341);
			this.labelExecutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelExecutor.Name = "labelExecutor";
			this.labelExecutor.Size = new System.Drawing.Size(92, 25);
			this.labelExecutor.TabIndex = 225;
			this.labelExecutor.Text = "Executor:";
			this.labelExecutor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSpecialist
			// 
			this.comboBoxSpecialist.BackColor = System.Drawing.Color.White;
			this.comboBoxSpecialist.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSpecialist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSpecialist.Location = new System.Drawing.Point(467, 341);
			this.comboBoxSpecialist.Name = "comboBoxSpecialist";
			this.comboBoxSpecialist.Size = new System.Drawing.Size(239, 22);
			this.comboBoxSpecialist.TabIndex = 224;
			this.comboBoxSpecialist.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(624, 511);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 228;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(543, 511);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 229;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// comboBoxDocumentClass
			// 
			this.comboBoxDocumentClass.Enabled = false;
			this.comboBoxDocumentClass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDocumentClass.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDocumentClass.FormattingEnabled = true;
			this.comboBoxDocumentClass.Location = new System.Drawing.Point(113, 71);
			this.comboBoxDocumentClass.Name = "comboBoxDocumentClass";
			this.comboBoxDocumentClass.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentClass.TabIndex = 231;
			this.comboBoxDocumentClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocumentClass_SelectedIndexChanged);
			this.comboBoxDocumentClass.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			this.textBoxDescription.Location = new System.Drawing.Point(113, 292);
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
			this.textBoxDescription.TabIndex = 234;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(369, 367);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(99, 25);
			this.label4.TabIndex = 235;
			this.label4.Text = "Nomenclature:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxNomenclature
			// 
			this.comboBoxNomenclature.BackColor = System.Drawing.Color.White;
			this.comboBoxNomenclature.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxNomenclature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxNomenclature.Location = new System.Drawing.Point(467, 367);
			this.comboBoxNomenclature.Name = "comboBoxNomenclature";
			this.comboBoxNomenclature.Size = new System.Drawing.Size(239, 22);
			this.comboBoxNomenclature.TabIndex = 237;
			this.comboBoxNomenclature.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(467, 393);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(239, 21);
			this.dictionaryComboBoxLocation.TabIndex = 239;
			this.dictionaryComboBoxLocation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.Description1 = "";
			this.fileControl.Description2 = "";
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControl.Location = new System.Drawing.Point(21, 467);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 214;
			// 
			// MailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 550);
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(labelLocation);
			this.Controls.Add(this.comboBoxNomenclature);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(labelDescription);
			this.Controls.Add(label1);
			this.Controls.Add(this.comboBoxDocumentClass);
			this.Controls.Add(label2);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelExecutor);
			this.Controls.Add(this.comboBoxSpecialist);
			this.Controls.Add(this.labelResponsible);
			this.Controls.Add(this.comboBoxOccupation);
			this.Controls.Add(this.labelDepartment);
			this.Controls.Add(this.comboBoxDepartment);
			this.Controls.Add(this.numericUpDownRevisionNotify);
			this.Controls.Add(labelNotifyRevision);
			this.Controls.Add(labelValidToRevision);
			this.Controls.Add(this.checkBoxRevisionPerformeUpTo);
			this.Controls.Add(this.dateTimePickerRevisionPerformeUpTo);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(labelRemark);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(labelTitle);
			this.Controls.Add(this.dateTimePickerCreateMailDate);
			this.Controls.Add(this.dateTimePickerReceiveMailDate);
			this.Controls.Add(this.textBoxReferenceNumber);
			this.Controls.Add(this.labelFrom);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(labelNumber);
			this.Controls.Add(labelDocumentType);
			this.Controls.Add(this.comboBoxDocumentType);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(722, 550);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(722, 550);
			this.Name = "MailForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Receive Mail Form";
			this.Load += new System.EventHandler(this.ReceiveMailForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxDocumentType;
		private MetroTextBox textBoxNumber;
		private MetroLabel labelFrom;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private MetroTextBox textBoxReferenceNumber;
		private System.Windows.Forms.DateTimePicker dateTimePickerReceiveMailDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerCreateMailDate;
		private MetroTextBox textBoxTitle;
		private MetroTextBox textBoxRemarks;
		private Auxiliary.AttachedFileControl fileControl;
		private System.Windows.Forms.CheckBox checkBoxRevisionPerformeUpTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerRevisionPerformeUpTo;
		private System.Windows.Forms.NumericUpDown numericUpDownRevisionNotify;
		private MetroLabel labelDepartment;
		private System.Windows.Forms.ComboBox comboBoxDepartment;
		private MetroLabel labelResponsible;
		private System.Windows.Forms.ComboBox comboBoxOccupation;
		private MetroLabel labelExecutor;
		private System.Windows.Forms.ComboBox comboBoxSpecialist;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.ComboBox comboBoxDocumentClass;
		private MetroTextBox textBoxDescription;
		private MetroLabel label4;
		private System.Windows.Forms.ComboBox comboBoxNomenclature;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxLocation;
	}
}