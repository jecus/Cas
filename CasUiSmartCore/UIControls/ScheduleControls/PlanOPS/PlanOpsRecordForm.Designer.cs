using MetroFramework.Controls;

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
			MetroFramework.Controls.MetroLabel labelSubType;
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel label2;
			MetroFramework.Controls.MetroLabel label3;
			MetroFramework.Controls.MetroLabel label9;
			MetroFramework.Controls.MetroLabel label10;
			MetroFramework.Controls.MetroLabel label11;
			MetroFramework.Controls.MetroLabel label12;
			MetroFramework.Controls.MetroLabel label13;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanOpsRecordForm));
			this.comboBoxAircrafts = new System.Windows.Forms.ComboBox();
			this.comboBoxAircraftExchange = new System.Windows.Forms.ComboBox();
			this.delayComboBox = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
			this.reasonComboBoxCancel = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.label5 = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerTakeOffS = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDGS = new System.Windows.Forms.DateTimePicker();
			this.label14 = new MetroFramework.Controls.MetroLabel();
			this.textFlightS = new MetroFramework.Controls.MetroTextBox();
			this.label6 = new MetroFramework.Controls.MetroLabel();
			this.label7 = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerTakeOffD = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDGD = new System.Windows.Forms.DateTimePicker();
			this.label8 = new MetroFramework.Controls.MetroLabel();
			this.textFlightD = new MetroFramework.Controls.MetroTextBox();
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
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.textBoxHiddenRemarks = new MetroFramework.Controls.MetroTextBox();
			this.documentControlReason = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlDelay = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter6 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlCancellation = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter7 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter8 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControlFlight = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			this.checkBox2 = new MetroFramework.Controls.MetroCheckBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			labelSubType = new MetroFramework.Controls.MetroLabel();
			label1 = new MetroFramework.Controls.MetroLabel();
			label2 = new MetroFramework.Controls.MetroLabel();
			label3 = new MetroFramework.Controls.MetroLabel();
			label9 = new MetroFramework.Controls.MetroLabel();
			label10 = new MetroFramework.Controls.MetroLabel();
			label11 = new MetroFramework.Controls.MetroLabel();
			label12 = new MetroFramework.Controls.MetroLabel();
			label13 = new MetroFramework.Controls.MetroLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(13, 63);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(55, 19);
			labelSubType.TabIndex = 11;
			labelSubType.Text = "Aircraft:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(13, 91);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(107, 19);
			label1.TabIndex = 13;
			label1.Text = "Aircraft Excange:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(13, 280);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 19);
			label2.TabIndex = 14;
			label2.Text = "Delay:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(13, 335);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(83, 19);
			label3.TabIndex = 16;
			label3.Text = "Cancellation:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label9.Location = new System.Drawing.Point(13, 220);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(67, 19);
			label9.TabIndex = 268;
			label9.Text = "Exchange:";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label10.Location = new System.Drawing.Point(13, 380);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(62, 19);
			label10.TabIndex = 272;
			label10.Text = "Remarks:";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label11.Location = new System.Drawing.Point(378, 380);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(108, 19);
			label11.TabIndex = 274;
			label11.Text = "Hidden Remarks:";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label12.Location = new System.Drawing.Point(13, 119);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(46, 19);
			label12.TabIndex = 289;
			label12.Text = "Status:";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label13.Location = new System.Drawing.Point(203, 188);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(51, 19);
			label13.TabIndex = 290;
			label13.Text = "Reason";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxAircrafts
			// 
			this.comboBoxAircrafts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAircrafts.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircrafts.FormattingEnabled = true;
			this.comboBoxAircrafts.Location = new System.Drawing.Point(125, 63);
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
			this.comboBoxAircraftExchange.Location = new System.Drawing.Point(125, 91);
			this.comboBoxAircraftExchange.Name = "comboBoxAircraftExchange";
			this.comboBoxAircraftExchange.Size = new System.Drawing.Size(236, 22);
			this.comboBoxAircraftExchange.TabIndex = 12;
			this.comboBoxAircraftExchange.SelectedIndexChanged += new System.EventHandler(this.comboBoxAircrafts_SelectedIndexChanged);
			// 
			// delayComboBox
			// 
			this.delayComboBox.AutoSize = true;
			this.delayComboBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.delayComboBox.Location = new System.Drawing.Point(125, 280);
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
			this.reasonComboBoxCancel.Location = new System.Drawing.Point(125, 335);
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
			this.buttonOk.Location = new System.Drawing.Point(1031, 428);
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
			this.buttonDelete.Location = new System.Drawing.Point(1112, 428);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 244;
			this.buttonDelete.Text = "Cancel";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(500, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 19);
			this.label4.TabIndex = 251;
			this.label4.Text = "Arr(S)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(386, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 19);
			this.label5.TabIndex = 250;
			this.label5.Text = "Dep(S)";
			// 
			// dateTimePickerTakeOffS
			// 
			this.dateTimePickerTakeOffS.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOffS.Enabled = false;
			this.dateTimePickerTakeOffS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOffS.Location = new System.Drawing.Point(439, 64);
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
			this.dateTimePickerLDGS.Location = new System.Drawing.Point(548, 64);
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
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label14.Location = new System.Drawing.Point(612, 63);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 19);
			this.label14.TabIndex = 249;
			this.label14.Text = "Flight(S)";
			// 
			// textFlightS
			// 
			// 
			// 
			// 
			this.textFlightS.CustomButton.Image = null;
			this.textFlightS.CustomButton.Location = new System.Drawing.Point(27, 2);
			this.textFlightS.CustomButton.Name = "";
			this.textFlightS.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textFlightS.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textFlightS.CustomButton.TabIndex = 1;
			this.textFlightS.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textFlightS.CustomButton.UseSelectable = true;
			this.textFlightS.CustomButton.Visible = false;
			this.textFlightS.Lines = new string[] {
        "03:40"};
			this.textFlightS.Location = new System.Drawing.Point(674, 64);
			this.textFlightS.MaxLength = 32767;
			this.textFlightS.Name = "textFlightS";
			this.textFlightS.PasswordChar = '\0';
			this.textFlightS.ReadOnly = true;
			this.textFlightS.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textFlightS.SelectedText = "";
			this.textFlightS.SelectionLength = 0;
			this.textFlightS.SelectionStart = 0;
			this.textFlightS.ShortcutsEnabled = true;
			this.textFlightS.Size = new System.Drawing.Size(45, 20);
			this.textFlightS.TabIndex = 248;
			this.textFlightS.TabStop = false;
			this.textFlightS.Text = "03:40";
			this.textFlightS.UseSelectable = true;
			this.textFlightS.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textFlightS.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(894, 63);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 19);
			this.label6.TabIndex = 257;
			this.label6.Text = "Arr(D)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label7.Location = new System.Drawing.Point(759, 63);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 19);
			this.label7.TabIndex = 256;
			this.label7.Text = "Dep(D)";
			// 
			// dateTimePickerTakeOffD
			// 
			this.dateTimePickerTakeOffD.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOffD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOffD.Location = new System.Drawing.Point(814, 64);
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
			this.dateTimePickerLDGD.Location = new System.Drawing.Point(944, 64);
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
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label8.Location = new System.Drawing.Point(1006, 63);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 19);
			this.label8.TabIndex = 255;
			this.label8.Text = "Flight(D)";
			// 
			// textFlightD
			// 
			// 
			// 
			// 
			this.textFlightD.CustomButton.Image = null;
			this.textFlightD.CustomButton.Location = new System.Drawing.Point(27, 2);
			this.textFlightD.CustomButton.Name = "";
			this.textFlightD.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textFlightD.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textFlightD.CustomButton.TabIndex = 1;
			this.textFlightD.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textFlightD.CustomButton.UseSelectable = true;
			this.textFlightD.CustomButton.Visible = false;
			this.textFlightD.Lines = new string[] {
        "03:40"};
			this.textFlightD.Location = new System.Drawing.Point(1070, 64);
			this.textFlightD.MaxLength = 32767;
			this.textFlightD.Name = "textFlightD";
			this.textFlightD.PasswordChar = '\0';
			this.textFlightD.ReadOnly = true;
			this.textFlightD.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textFlightD.SelectedText = "";
			this.textFlightD.SelectionLength = 0;
			this.textFlightD.SelectionStart = 0;
			this.textFlightD.ShortcutsEnabled = true;
			this.textFlightD.Size = new System.Drawing.Size(45, 20);
			this.textFlightD.TabIndex = 254;
			this.textFlightD.TabStop = false;
			this.textFlightD.Text = "03:40";
			this.textFlightD.UseSelectable = true;
			this.textFlightD.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textFlightD.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(370, 58);
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
			this.delimiter1.Location = new System.Drawing.Point(16, 202);
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
			this.delimiter3.Location = new System.Drawing.Point(730, 58);
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
			this.dataGridViewFlights.Location = new System.Drawing.Point(387, 94);
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
			this.reasonComboBox.Location = new System.Drawing.Point(125, 220);
			this.reasonComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.reasonComboBox.Name = "reasonComboBox";
			this.reasonComboBox.SelectedReason = null;
			this.reasonComboBox.Size = new System.Drawing.Size(236, 24);
			this.reasonComboBox.TabIndex = 269;
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(172, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(61, 61);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(125, 380);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxRemarks.MaxLength = 1024;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(236, 66);
			this.textBoxRemarks.TabIndex = 271;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxHiddenRemarks
			// 
			// 
			// 
			// 
			this.textBoxHiddenRemarks.CustomButton.Image = null;
			this.textBoxHiddenRemarks.CustomButton.Location = new System.Drawing.Point(167, 2);
			this.textBoxHiddenRemarks.CustomButton.Name = "";
			this.textBoxHiddenRemarks.CustomButton.Size = new System.Drawing.Size(61, 61);
			this.textBoxHiddenRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxHiddenRemarks.CustomButton.TabIndex = 1;
			this.textBoxHiddenRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxHiddenRemarks.CustomButton.UseSelectable = true;
			this.textBoxHiddenRemarks.CustomButton.Visible = false;
			this.textBoxHiddenRemarks.Lines = new string[0];
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(487, 380);
			this.textBoxHiddenRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxHiddenRemarks.MaxLength = 1024;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.PasswordChar = '\0';
			this.textBoxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxHiddenRemarks.SelectedText = "";
			this.textBoxHiddenRemarks.SelectionLength = 0;
			this.textBoxHiddenRemarks.SelectionStart = 0;
			this.textBoxHiddenRemarks.ShortcutsEnabled = true;
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(231, 66);
			this.textBoxHiddenRemarks.TabIndex = 273;
			this.textBoxHiddenRemarks.UseSelectable = true;
			this.textBoxHiddenRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxHiddenRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// documentControlReason
			// 
			this.documentControlReason.CurrentDocument = null;
			this.documentControlReason.Location = new System.Drawing.Point(378, 212);
			this.documentControlReason.Name = "documentControlReason";
			this.documentControlReason.Size = new System.Drawing.Size(308, 41);
			this.documentControlReason.TabIndex = 278;
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
			this.delimiter5.Location = new System.Drawing.Point(16, 260);
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
			this.documentControlDelay.Location = new System.Drawing.Point(378, 268);
			this.documentControlDelay.Name = "documentControlDelay";
			this.documentControlDelay.Size = new System.Drawing.Size(308, 41);
			this.documentControlDelay.TabIndex = 280;
			// 
			// delimiter6
			// 
			this.delimiter6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter6.BackgroundImage")));
			this.delimiter6.Location = new System.Drawing.Point(14, 316);
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
			this.documentControlCancellation.Location = new System.Drawing.Point(370, 324);
			this.documentControlCancellation.Name = "documentControlCancellation";
			this.documentControlCancellation.Size = new System.Drawing.Size(316, 41);
			this.documentControlCancellation.TabIndex = 282;
			// 
			// delimiter7
			// 
			this.delimiter7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter7.BackgroundImage")));
			this.delimiter7.Location = new System.Drawing.Point(14, 372);
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
			this.delimiter8.Location = new System.Drawing.Point(370, 204);
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
			this.documentControlFlight.Location = new System.Drawing.Point(890, 149);
			this.documentControlFlight.Name = "documentControlFlight";
			this.documentControlFlight.Size = new System.Drawing.Size(308, 41);
			this.documentControlFlight.TabIndex = 285;
			this.documentControlFlight.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(738, 67);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(16, 0);
			this.checkBox1.TabIndex = 286;
			this.checkBox1.UseSelectable = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(875, 67);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(16, 0);
			this.checkBox2.TabIndex = 287;
			this.checkBox2.UseSelectable = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(125, 119);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(236, 22);
			this.comboBoxStatus.TabIndex = 288;
			// 
			// PlanOpsRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1209, 473);
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
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlanOpsRecordForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Plan Ops Record Form";
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
		private MetroLabel label4;
		private MetroLabel label5;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOffS;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDGS;
		private MetroLabel label14;
		private MetroTextBox textFlightS;
		private MetroLabel label6;
		private MetroLabel label7;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOffD;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDGD;
		private MetroLabel label8;
		private MetroTextBox textFlightD;
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
		private MetroTextBox textBoxRemarks;
		private MetroTextBox textBoxHiddenRemarks;
		private DocumentationControls.DocumentControl documentControlReason;
		private Auxiliary.Delimiter delimiter5;
		private DocumentationControls.DocumentControl documentControlDelay;
		private Auxiliary.Delimiter delimiter6;
		private DocumentationControls.DocumentControl documentControlCancellation;
		private Auxiliary.Delimiter delimiter7;
		private Auxiliary.Delimiter delimiter8;
		private DocumentationControls.DocumentControl documentControlFlight;
		private MetroCheckBox checkBox1;
		private MetroCheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBoxStatus;
	}
}