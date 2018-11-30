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
			System.Windows.Forms.Label labelDocumentType;
			System.Windows.Forms.Label labelNumber;
			System.Windows.Forms.Label labelTitle;
			System.Windows.Forms.Label labelRemark;
			System.Windows.Forms.Label labelNotifyRevision;
			System.Windows.Forms.Label labelValidToRevision;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label labelDescription;
			System.Windows.Forms.Label labelLocation;
			this.comboBoxDocumentType = new System.Windows.Forms.ComboBox();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.labelFrom = new System.Windows.Forms.Label();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.textBoxReferenceNumber = new System.Windows.Forms.TextBox();
			this.dateTimePickerReceiveMailDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerCreateMailDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.checkBoxRevisionPerformeUpTo = new System.Windows.Forms.CheckBox();
			this.dateTimePickerRevisionPerformeUpTo = new System.Windows.Forms.DateTimePicker();
			this.numericUpDownRevisionNotify = new System.Windows.Forms.NumericUpDown();
			this.labelDepartment = new System.Windows.Forms.Label();
			this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
			this.labelResponsible = new System.Windows.Forms.Label();
			this.comboBoxOccupation = new System.Windows.Forms.ComboBox();
			this.labelExecutor = new System.Windows.Forms.Label();
			this.comboBoxSpecialist = new System.Windows.Forms.ComboBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.comboBoxDocumentClass = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxNomenclature = new System.Windows.Forms.ComboBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			labelDocumentType = new System.Windows.Forms.Label();
			labelNumber = new System.Windows.Forms.Label();
			labelTitle = new System.Windows.Forms.Label();
			labelRemark = new System.Windows.Forms.Label();
			labelNotifyRevision = new System.Windows.Forms.Label();
			labelValidToRevision = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			labelDescription = new System.Windows.Forms.Label();
			labelLocation = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).BeginInit();
			this.SuspendLayout();
			// 
			// labelDocumentType
			// 
			labelDocumentType.AutoSize = true;
			labelDocumentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDocumentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDocumentType.Location = new System.Drawing.Point(12, 40);
			labelDocumentType.Name = "labelDocumentType";
			labelDocumentType.Size = new System.Drawing.Size(72, 14);
			labelDocumentType.TabIndex = 19;
			labelDocumentType.Text = "Doc. Type:";
			labelDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(12, 92);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(26, 14);
			labelNumber.TabIndex = 26;
			labelNumber.Text = "№:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTitle
			// 
			labelTitle.AutoSize = true;
			labelTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelTitle.Location = new System.Drawing.Point(12, 146);
			labelTitle.Name = "labelTitle";
			labelTitle.Size = new System.Drawing.Size(38, 14);
			labelTitle.TabIndex = 209;
			labelTitle.Text = "Title:";
			labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRemark
			// 
			labelRemark.AutoSize = true;
			labelRemark.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelRemark.Location = new System.Drawing.Point(12, 321);
			labelRemark.Name = "labelRemark";
			labelRemark.Size = new System.Drawing.Size(59, 14);
			labelRemark.TabIndex = 212;
			labelRemark.Text = "Remark:";
			labelRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNotifyRevision
			// 
			labelNotifyRevision.AutoSize = true;
			labelNotifyRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelNotifyRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNotifyRevision.Location = new System.Drawing.Point(361, 198);
			labelNotifyRevision.Name = "labelNotifyRevision";
			labelNotifyRevision.Size = new System.Drawing.Size(92, 14);
			labelNotifyRevision.TabIndex = 218;
			labelNotifyRevision.Text = "Notify (days):";
			labelNotifyRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidToRevision
			// 
			labelValidToRevision.AutoSize = true;
			labelValidToRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelValidToRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidToRevision.Location = new System.Drawing.Point(360, 175);
			labelValidToRevision.Name = "labelValidToRevision";
			labelValidToRevision.Size = new System.Drawing.Size(100, 14);
			labelValidToRevision.TabIndex = 217;
			labelValidToRevision.Text = "Perform Up To:";
			labelValidToRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(361, 92);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 14);
			label2.TabIndex = 230;
			label2.Text = "Reference №:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(12, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 14);
			label1.TabIndex = 232;
			label1.Text = "Doc. Class:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDescription.Location = new System.Drawing.Point(11, 232);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(82, 14);
			labelDescription.TabIndex = 233;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLocation
			// 
			labelLocation.AutoSize = true;
			labelLocation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelLocation.Location = new System.Drawing.Point(363, 333);
			labelLocation.Name = "labelLocation";
			labelLocation.Size = new System.Drawing.Size(65, 14);
			labelLocation.TabIndex = 238;
			labelLocation.Text = "Location:";
			labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxDocumentType
			// 
			this.comboBoxDocumentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxDocumentType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxDocumentType.FormattingEnabled = true;
			this.comboBoxDocumentType.Location = new System.Drawing.Point(107, 37);
			this.comboBoxDocumentType.Name = "comboBoxDocumentType";
			this.comboBoxDocumentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentType.TabIndex = 18;
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxNumber.Location = new System.Drawing.Point(107, 90);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxNumber.TabIndex = 27;
			// 
			// labelFrom
			// 
			this.labelFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFrom.Location = new System.Drawing.Point(12, 63);
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
			this.comboBoxSupplier.Location = new System.Drawing.Point(107, 63);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplier.TabIndex = 202;
			// 
			// textBoxReferenceNumber
			// 
			this.textBoxReferenceNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxReferenceNumber.Location = new System.Drawing.Point(461, 90);
			this.textBoxReferenceNumber.Name = "textBoxReferenceNumber";
			this.textBoxReferenceNumber.Size = new System.Drawing.Size(239, 20);
			this.textBoxReferenceNumber.TabIndex = 205;
			// 
			// dateTimePickerReceiveMailDate
			// 
			this.dateTimePickerReceiveMailDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerReceiveMailDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReceiveMailDate.Location = new System.Drawing.Point(107, 116);
			this.dateTimePickerReceiveMailDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerReceiveMailDate.Name = "dateTimePickerReceiveMailDate";
			this.dateTimePickerReceiveMailDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerReceiveMailDate.TabIndex = 206;
			// 
			// dateTimePickerCreateMailDate
			// 
			this.dateTimePickerCreateMailDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerCreateMailDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerCreateMailDate.Location = new System.Drawing.Point(461, 116);
			this.dateTimePickerCreateMailDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerCreateMailDate.Name = "dateTimePickerCreateMailDate";
			this.dateTimePickerCreateMailDate.Size = new System.Drawing.Size(239, 22);
			this.dateTimePickerCreateMailDate.TabIndex = 207;
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxTitle.Location = new System.Drawing.Point(107, 144);
			this.textBoxTitle.Multiline = true;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(250, 80);
			this.textBoxTitle.TabIndex = 210;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Location = new System.Drawing.Point(107, 319);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(250, 80);
			this.textBoxRemarks.TabIndex = 213;
			// 
			// checkBoxRevisionPerformeUpTo
			// 
			this.checkBoxRevisionPerformeUpTo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxRevisionPerformeUpTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxRevisionPerformeUpTo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRevisionPerformeUpTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxRevisionPerformeUpTo.Location = new System.Drawing.Point(461, 140);
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
			this.dateTimePickerRevisionPerformeUpTo.Location = new System.Drawing.Point(461, 169);
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
			this.numericUpDownRevisionNotify.Location = new System.Drawing.Point(461, 196);
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
			this.labelDepartment.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDepartment.Location = new System.Drawing.Point(361, 221);
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
			this.comboBoxDepartment.Location = new System.Drawing.Point(461, 224);
			this.comboBoxDepartment.Name = "comboBoxDepartment";
			this.comboBoxDepartment.Size = new System.Drawing.Size(239, 22);
			this.comboBoxDepartment.TabIndex = 220;
			// 
			// labelResponsible
			// 
			this.labelResponsible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelResponsible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelResponsible.Location = new System.Drawing.Point(361, 249);
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
			this.comboBoxOccupation.Location = new System.Drawing.Point(461, 252);
			this.comboBoxOccupation.Name = "comboBoxOccupation";
			this.comboBoxOccupation.Size = new System.Drawing.Size(239, 22);
			this.comboBoxOccupation.TabIndex = 222;
			// 
			// labelExecutor
			// 
			this.labelExecutor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelExecutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelExecutor.Location = new System.Drawing.Point(361, 277);
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
			this.comboBoxSpecialist.Location = new System.Drawing.Point(461, 280);
			this.comboBoxSpecialist.Name = "comboBoxSpecialist";
			this.comboBoxSpecialist.Size = new System.Drawing.Size(239, 22);
			this.comboBoxSpecialist.TabIndex = 224;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(619, 463);
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
			this.buttonOk.Location = new System.Drawing.Point(538, 463);
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
			this.comboBoxDocumentClass.Location = new System.Drawing.Point(107, 9);
			this.comboBoxDocumentClass.Name = "comboBoxDocumentClass";
			this.comboBoxDocumentClass.Size = new System.Drawing.Size(250, 22);
			this.comboBoxDocumentClass.TabIndex = 231;
			this.comboBoxDocumentClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocumentClass_SelectedIndexChanged);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Location = new System.Drawing.Point(107, 230);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(250, 80);
			this.textBoxDescription.TabIndex = 234;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(361, 302);
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
			this.comboBoxNomenclature.Location = new System.Drawing.Point(461, 304);
			this.comboBoxNomenclature.Name = "comboBoxNomenclature";
			this.comboBoxNomenclature.Size = new System.Drawing.Size(239, 22);
			this.comboBoxNomenclature.TabIndex = 237;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(461, 330);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(239, 21);
			this.dictionaryComboBoxLocation.TabIndex = 239;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.Description1 = "";
			this.fileControl.Description2 = "";
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControl.Location = new System.Drawing.Point(15, 405);
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
			this.ClientSize = new System.Drawing.Size(706, 508);
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ReceiveMailForm";
			this.Load += new System.EventHandler(this.ReceiveMailForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRevisionNotify)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxDocumentType;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.TextBox textBoxReferenceNumber;
		private System.Windows.Forms.DateTimePicker dateTimePickerReceiveMailDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerCreateMailDate;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private Auxiliary.AttachedFileControl fileControl;
		private System.Windows.Forms.CheckBox checkBoxRevisionPerformeUpTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerRevisionPerformeUpTo;
		private System.Windows.Forms.NumericUpDown numericUpDownRevisionNotify;
		private System.Windows.Forms.Label labelDepartment;
		private System.Windows.Forms.ComboBox comboBoxDepartment;
		private System.Windows.Forms.Label labelResponsible;
		private System.Windows.Forms.ComboBox comboBoxOccupation;
		private System.Windows.Forms.Label labelExecutor;
		private System.Windows.Forms.ComboBox comboBoxSpecialist;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.ComboBox comboBoxDocumentClass;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxNomenclature;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxLocation;
	}
}