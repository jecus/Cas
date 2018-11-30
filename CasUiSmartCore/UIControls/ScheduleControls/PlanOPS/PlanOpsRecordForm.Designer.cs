namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	partial class PlanOpsRecordForm
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label12;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanOpsRecordForm));
			System.Windows.Forms.Label label13;
			this.comboBoxAircrafts = new System.Windows.Forms.ComboBox();
			this.comboBoxAircraftExchange = new System.Windows.Forms.ComboBox();
			this.delayComboBox = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
			this.reasonComboBoxCancel = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePickerTakeOffS = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDGS = new System.Windows.Forms.DateTimePicker();
			this.label14 = new System.Windows.Forms.Label();
			this.textFlightS = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dateTimePickerTakeOffD = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDGD = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.textFlightD = new System.Windows.Forms.TextBox();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.dataGridViewFlights = new System.Windows.Forms.DataGridView();
			this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnFlightNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PageNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnFlightDate = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn();
			this.ColumnTakeOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnLDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reasonComboBox = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.documentControlReason = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlDelay = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter6 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlCancellation = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter7 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter8 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlFlight = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			labelSubType = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(8, 15);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(56, 14);
			labelSubType.TabIndex = 11;
			labelSubType.Text = "Aircraft:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(8, 43);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(113, 14);
			label1.TabIndex = 13;
			label1.Text = "Aircraft Excange:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(10, 232);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 14);
			label2.TabIndex = 14;
			label2.Text = "Delay:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(8, 286);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(89, 14);
			label3.TabIndex = 16;
			label3.Text = "Cancellation:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label9.Location = new System.Drawing.Point(10, 173);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(73, 14);
			label9.TabIndex = 268;
			label9.Text = "Exchange:";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label10.Location = new System.Drawing.Point(8, 326);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(66, 14);
			label10.TabIndex = 272;
			label10.Text = "Remarks:";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label11.Location = new System.Drawing.Point(364, 326);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(114, 14);
			label11.TabIndex = 274;
			label11.Text = "Hidden Remarks:";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label12.Location = new System.Drawing.Point(8, 71);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(53, 14);
			label12.TabIndex = 289;
			label12.Text = "Status:";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxAircrafts
			// 
			this.comboBoxAircrafts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAircrafts.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircrafts.FormattingEnabled = true;
			this.comboBoxAircrafts.Location = new System.Drawing.Point(122, 12);
			this.comboBoxAircrafts.Name = "comboBoxAircrafts";
			this.comboBoxAircrafts.Size = new System.Drawing.Size(236, 22);
			this.comboBoxAircrafts.TabIndex = 10;
			this.comboBoxAircrafts.SelectedIndexChanged += new System.EventHandler(this.comboBoxAircrafts_SelectedIndexChanged);
			// 
			// comboBoxAircraftExchange
			// 
			this.comboBoxAircraftExchange.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAircraftExchange.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircraftExchange.FormattingEnabled = true;
			this.comboBoxAircraftExchange.Location = new System.Drawing.Point(122, 40);
			this.comboBoxAircraftExchange.Name = "comboBoxAircraftExchange";
			this.comboBoxAircraftExchange.Size = new System.Drawing.Size(236, 22);
			this.comboBoxAircraftExchange.TabIndex = 12;
			this.comboBoxAircraftExchange.SelectedIndexChanged += new System.EventHandler(this.comboBoxAircrafts_SelectedIndexChanged);
			// 
			// delayComboBox
			// 
			this.delayComboBox.AutoSize = true;
			this.delayComboBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.delayComboBox.Location = new System.Drawing.Point(122, 229);
			this.delayComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.delayComboBox.Name = "delayComboBox";
			this.delayComboBox.SelectedReason = null;
			this.delayComboBox.Size = new System.Drawing.Size(236, 24);
			this.delayComboBox.TabIndex = 15;
			// 
			// reasonComboBoxCancel
			// 
			this.reasonComboBoxCancel.AutoSize = true;
			this.reasonComboBoxCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.reasonComboBoxCancel.Location = new System.Drawing.Point(122, 284);
			this.reasonComboBoxCancel.Margin = new System.Windows.Forms.Padding(4);
			this.reasonComboBoxCancel.Name = "reasonComboBoxCancel";
			this.reasonComboBoxCancel.SelectedReason = null;
			this.reasonComboBoxCancel.Size = new System.Drawing.Size(236, 24);
			this.reasonComboBoxCancel.TabIndex = 17;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1031, 420);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 245;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(1112, 420);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 244;
			this.buttonDelete.Text = "Cancel";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(497, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 14);
			this.label4.TabIndex = 251;
			this.label4.Text = "Arr(S)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(381, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 14);
			this.label5.TabIndex = 250;
			this.label5.Text = "Dep(S)";
			// 
			// dateTimePickerTakeOffS
			// 
			this.dateTimePickerTakeOffS.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOffS.Enabled = false;
			this.dateTimePickerTakeOffS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOffS.Location = new System.Drawing.Point(436, 12);
			this.dateTimePickerTakeOffS.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTakeOffS.Name = "dateTimePickerTakeOffS";
			this.dateTimePickerTakeOffS.ShowUpDown = true;
			this.dateTimePickerTakeOffS.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerTakeOffS.TabIndex = 246;
			this.dateTimePickerTakeOffS.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOffS_ValueChanged);
			// 
			// dateTimePickerLDGS
			// 
			this.dateTimePickerLDGS.CustomFormat = "HH:mm";
			this.dateTimePickerLDGS.Enabled = false;
			this.dateTimePickerLDGS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerLDGS.Location = new System.Drawing.Point(545, 12);
			this.dateTimePickerLDGS.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerLDGS.Name = "dateTimePickerLDGS";
			this.dateTimePickerLDGS.ShowUpDown = true;
			this.dateTimePickerLDGS.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerLDGS.TabIndex = 247;
			this.dateTimePickerLDGS.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOffS_ValueChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label14.Location = new System.Drawing.Point(606, 15);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 14);
			this.label14.TabIndex = 249;
			this.label14.Text = "Flight(S)";
			// 
			// textFlightS
			// 
			this.textFlightS.Location = new System.Drawing.Point(671, 12);
			this.textFlightS.Name = "textFlightS";
			this.textFlightS.ReadOnly = true;
			this.textFlightS.Size = new System.Drawing.Size(45, 20);
			this.textFlightS.TabIndex = 248;
			this.textFlightS.TabStop = false;
			this.textFlightS.Text = "03:40";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(893, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 14);
			this.label6.TabIndex = 257;
			this.label6.Text = "Arr(D)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label7.Location = new System.Drawing.Point(756, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(51, 14);
			this.label7.TabIndex = 256;
			this.label7.Text = "Dep(D)";
			// 
			// dateTimePickerTakeOffD
			// 
			this.dateTimePickerTakeOffD.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOffD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOffD.Location = new System.Drawing.Point(811, 13);
			this.dateTimePickerTakeOffD.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTakeOffD.Name = "dateTimePickerTakeOffD";
			this.dateTimePickerTakeOffD.ShowUpDown = true;
			this.dateTimePickerTakeOffD.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerTakeOffD.TabIndex = 252;
			this.dateTimePickerTakeOffD.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOffD_ValueChanged);
			// 
			// dateTimePickerLDGD
			// 
			this.dateTimePickerLDGD.CustomFormat = "HH:mm";
			this.dateTimePickerLDGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerLDGD.Location = new System.Drawing.Point(941, 13);
			this.dateTimePickerLDGD.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerLDGD.Name = "dateTimePickerLDGD";
			this.dateTimePickerLDGD.ShowUpDown = true;
			this.dateTimePickerLDGD.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerLDGD.TabIndex = 253;
			this.dateTimePickerLDGD.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOffD_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label8.Location = new System.Drawing.Point(1002, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 14);
			this.label8.TabIndex = 255;
			this.label8.Text = "Flight(D)";
			// 
			// textFlightD
			// 
			this.textFlightD.Location = new System.Drawing.Point(1067, 13);
			this.textFlightD.Name = "textFlightD";
			this.textFlightD.ReadOnly = true;
			this.textFlightD.Size = new System.Drawing.Size(45, 20);
			this.textFlightD.TabIndex = 254;
			this.textFlightD.TabStop = false;
			this.textFlightD.Text = "03:40";
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(367, 7);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 145);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 265;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(13, 151);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(1184, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 264;
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(727, 7);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 27);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 266;
			// 
			// dataGridViewFlights
			// 
			this.dataGridViewFlights.AllowUserToAddRows = false;
			this.dataGridViewFlights.AllowUserToDeleteRows = false;
			this.dataGridViewFlights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewFlights.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck,
            this.ColumnFlightNo,
            this.PageNoColumn,
            this.ColumnFrom,
            this.ColumnTo,
            this.ColumnFlightDate,
            this.ColumnTakeOff,
            this.ColumnLDG});
			this.dataGridViewFlights.Location = new System.Drawing.Point(384, 43);
			this.dataGridViewFlights.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewFlights.Name = "dataGridViewFlights";
			this.dataGridViewFlights.RowHeadersVisible = false;
			this.dataGridViewFlights.RowHeadersWidth = 4;
			this.dataGridViewFlights.RowTemplate.Height = 24;
			this.dataGridViewFlights.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewFlights.Size = new System.Drawing.Size(813, 50);
			this.dataGridViewFlights.TabIndex = 267;
			this.dataGridViewFlights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFlights_CellContentClick);
			this.dataGridViewFlights.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewFlights_ColumnWidthChanged_1);
			this.dataGridViewFlights.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewFlights_Scroll_1);
			// 
			// ColumnCheck
			// 
			this.ColumnCheck.HeaderText = "";
			this.ColumnCheck.Name = "ColumnCheck";
			this.ColumnCheck.Width = 30;
			// 
			// ColumnFlightNo
			// 
			this.ColumnFlightNo.HeaderText = "FlightNo";
			this.ColumnFlightNo.Name = "ColumnFlightNo";
			this.ColumnFlightNo.ReadOnly = true;
			this.ColumnFlightNo.Width = 80;
			// 
			// PageNoColumn
			// 
			this.PageNoColumn.HeaderText = "PageNo";
			this.PageNoColumn.Name = "PageNoColumn";
			// 
			// ColumnFrom
			// 
			this.ColumnFrom.HeaderText = "From";
			this.ColumnFrom.Name = "ColumnFrom";
			this.ColumnFrom.ReadOnly = true;
			this.ColumnFrom.Width = 150;
			// 
			// ColumnTo
			// 
			this.ColumnTo.HeaderText = "To";
			this.ColumnTo.Name = "ColumnTo";
			this.ColumnTo.ReadOnly = true;
			this.ColumnTo.Width = 150;
			// 
			// ColumnFlightDate
			// 
			this.ColumnFlightDate.HeaderText = "Flight Date";
			this.ColumnFlightDate.Name = "ColumnFlightDate";
			// 
			// ColumnTakeOff
			// 
			this.ColumnTakeOff.HeaderText = "Take-off";
			this.ColumnTakeOff.Name = "ColumnTakeOff";
			// 
			// ColumnLDG
			// 
			this.ColumnLDG.HeaderText = "LDG";
			this.ColumnLDG.Name = "ColumnLDG";
			// 
			// reasonComboBox
			// 
			this.reasonComboBox.AutoSize = true;
			this.reasonComboBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.reasonComboBox.Location = new System.Drawing.Point(122, 169);
			this.reasonComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.reasonComboBox.Name = "reasonComboBox";
			this.reasonComboBox.SelectedReason = null;
			this.reasonComboBox.Size = new System.Drawing.Size(236, 24);
			this.reasonComboBox.TabIndex = 269;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Location = new System.Drawing.Point(127, 329);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxRemarks.MaxLength = 1024;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(231, 66);
			this.textBoxRemarks.TabIndex = 271;
			// 
			// textBoxHiddenRemarks
			// 
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(484, 329);
			this.textBoxHiddenRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxHiddenRemarks.MaxLength = 1024;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(231, 66);
			this.textBoxHiddenRemarks.TabIndex = 273;
			// 
			// documentControlReason
			// 
			this.documentControlReason.CurrentDocument = null;
			this.documentControlReason.Location = new System.Drawing.Point(375, 161);
			this.documentControlReason.Name = "documentControlReason";
			this.documentControlReason.Size = new System.Drawing.Size(308, 41);
			this.documentControlReason.TabIndex = 278;
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
			this.delimiter5.Location = new System.Drawing.Point(13, 209);
			this.delimiter5.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter5.Name = "delimiter5";
			this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter5.Size = new System.Drawing.Size(1184, 1);
			this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter5.TabIndex = 279;
			// 
			// documentControlDelay
			// 
			this.documentControlDelay.CurrentDocument = null;
			this.documentControlDelay.Location = new System.Drawing.Point(375, 217);
			this.documentControlDelay.Name = "documentControlDelay";
			this.documentControlDelay.Size = new System.Drawing.Size(308, 41);
			this.documentControlDelay.TabIndex = 280;
			// 
			// delimiter6
			// 
			this.delimiter6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter6.BackgroundImage")));
			this.delimiter6.Location = new System.Drawing.Point(11, 265);
			this.delimiter6.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter6.Name = "delimiter6";
			this.delimiter6.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter6.Size = new System.Drawing.Size(1184, 1);
			this.delimiter6.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter6.TabIndex = 281;
			// 
			// documentControlCancellation
			// 
			this.documentControlCancellation.CurrentDocument = null;
			this.documentControlCancellation.Location = new System.Drawing.Point(367, 273);
			this.documentControlCancellation.Name = "documentControlCancellation";
			this.documentControlCancellation.Size = new System.Drawing.Size(316, 41);
			this.documentControlCancellation.TabIndex = 282;
			// 
			// delimiter7
			// 
			this.delimiter7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter7.BackgroundImage")));
			this.delimiter7.Location = new System.Drawing.Point(11, 321);
			this.delimiter7.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter7.Name = "delimiter7";
			this.delimiter7.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter7.Size = new System.Drawing.Size(1184, 1);
			this.delimiter7.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter7.TabIndex = 283;
			// 
			// delimiter8
			// 
			this.delimiter8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter8.BackgroundImage")));
			this.delimiter8.Location = new System.Drawing.Point(367, 153);
			this.delimiter8.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter8.Name = "delimiter8";
			this.delimiter8.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter8.Size = new System.Drawing.Size(1, 161);
			this.delimiter8.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter8.TabIndex = 284;
			// 
			// documentControlFlight
			// 
			this.documentControlFlight.CurrentDocument = null;
			this.documentControlFlight.Location = new System.Drawing.Point(887, 98);
			this.documentControlFlight.Name = "documentControlFlight";
			this.documentControlFlight.Size = new System.Drawing.Size(308, 41);
			this.documentControlFlight.TabIndex = 285;
			this.documentControlFlight.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(735, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(15, 14);
			this.checkBox1.TabIndex = 286;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(872, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(15, 14);
			this.checkBox2.TabIndex = 287;
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(122, 68);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(236, 22);
			this.comboBoxStatus.TabIndex = 288;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label13.Location = new System.Drawing.Point(200, 137);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(54, 14);
			label13.TabIndex = 290;
			label13.Text = "Reason";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// PlanOpsRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1209, 465);
			this.Controls.Add(label13);
			this.Controls.Add(label12);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.documentControlFlight);
			this.Controls.Add(this.delimiter8);
			this.Controls.Add(this.delimiter7);
			this.Controls.Add(this.documentControlCancellation);
			this.Controls.Add(this.delimiter6);
			this.Controls.Add(this.documentControlDelay);
			this.Controls.Add(this.delimiter5);
			this.Controls.Add(this.documentControlReason);
			this.Controls.Add(label11);
			this.Controls.Add(this.textBoxHiddenRemarks);
			this.Controls.Add(label10);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.reasonComboBox);
			this.Controls.Add(label9);
			this.Controls.Add(this.dataGridViewFlights);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dateTimePickerTakeOffD);
			this.Controls.Add(this.dateTimePickerLDGD);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textFlightD);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dateTimePickerTakeOffS);
			this.Controls.Add(this.dateTimePickerLDGS);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textFlightS);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.reasonComboBoxCancel);
			this.Controls.Add(label3);
			this.Controls.Add(this.delayComboBox);
			this.Controls.Add(label2);
			this.Controls.Add(label1);
			this.Controls.Add(this.comboBoxAircraftExchange);
			this.Controls.Add(labelSubType);
			this.Controls.Add(this.comboBoxAircrafts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlanOpsRecordForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PlanOpsRecordForm";
			this.Load += new System.EventHandler(this.PlanOpsRecordForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxAircrafts;
		private System.Windows.Forms.ComboBox comboBoxAircraftExchange;
		private Auxiliary.ReasonComboBox delayComboBox;
		private Auxiliary.ReasonComboBox reasonComboBoxCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOffS;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDGS;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textFlightS;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOffD;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDGD;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textFlightD;
		private Auxiliary.Delimiter delimiter2;
		private Auxiliary.Delimiter delimiter1;
		private Auxiliary.Delimiter delimiter3;
		private System.Windows.Forms.DataGridView dataGridViewFlights;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFlightNo;
		private System.Windows.Forms.DataGridViewTextBoxColumn PageNoColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrom;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTo;
		private Auxiliary.DataGridViewElements.DataGridViewCalendarColumn ColumnFlightDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTakeOff;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLDG;
		private Auxiliary.ReasonComboBox reasonComboBox;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.TextBox textBoxHiddenRemarks;
		private DocumentationControls.DocumentControl documentControlReason;
		private Auxiliary.Delimiter delimiter5;
		private DocumentationControls.DocumentControl documentControlDelay;
		private Auxiliary.Delimiter delimiter6;
		private DocumentationControls.DocumentControl documentControlCancellation;
		private Auxiliary.Delimiter delimiter7;
		private Auxiliary.Delimiter delimiter8;
		private DocumentationControls.DocumentControl documentControlFlight;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBoxStatus;
	}
}