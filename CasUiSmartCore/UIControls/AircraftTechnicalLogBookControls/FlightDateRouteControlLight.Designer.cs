namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
	partial class FlightDateRouteControlLight
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
			this.label1 = new System.Windows.Forms.Label();
			this.textFlightNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textFrom = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textTo = new System.Windows.Forms.TextBox();
			this.labelPageNum = new System.Windows.Forms.Label();
			this.textBoxPageNum = new System.Windows.Forms.TextBox();
			this.dateTimePickerFlightDate = new System.Windows.Forms.DateTimePicker();
			this.labelRecordType = new System.Windows.Forms.Label();
			this.comboBoxRecordType = new System.Windows.Forms.ComboBox();
			this.dateTimePickerTakeOff = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDG = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.textFlight = new System.Windows.Forms.TextBox();
			this.checkDY = new System.Windows.Forms.CheckBox();
			this.checkTC = new System.Windows.Forms.CheckBox();
			this.checkPFC = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Flight General Information";
			// 
			// textFlightNo
			// 
			this.textFlightNo.Location = new System.Drawing.Point(83, 133);
			this.textFlightNo.Name = "textFlightNo";
			this.textFlightNo.Size = new System.Drawing.Size(137, 20);
			this.textFlightNo.TabIndex = 3;
			this.textFlightNo.Text = "1258";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Flight No";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Date";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 85);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Station";
			// 
			// textFrom
			// 
			this.textFrom.Location = new System.Drawing.Point(115, 83);
			this.textFrom.Name = "textFrom";
			this.textFrom.Size = new System.Drawing.Size(38, 20);
			this.textFrom.TabIndex = 8;
			this.textFrom.Text = "FRU";
			this.textFrom.TextChanged += new System.EventHandler(this.TextFromTextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(83, 85);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(27, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "from";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(159, 85);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "to";
			// 
			// textTo
			// 
			this.textTo.Location = new System.Drawing.Point(182, 83);
			this.textTo.Name = "textTo";
			this.textTo.Size = new System.Drawing.Size(38, 20);
			this.textTo.TabIndex = 12;
			this.textTo.Text = "MSK";
			// 
			// labelPageNum
			// 
			this.labelPageNum.AutoSize = true;
			this.labelPageNum.Location = new System.Drawing.Point(3, 110);
			this.labelPageNum.Name = "labelPageNum";
			this.labelPageNum.Size = new System.Drawing.Size(49, 13);
			this.labelPageNum.TabIndex = 14;
			this.labelPageNum.Text = "Page No";
			// 
			// textBoxPageNum
			// 
			this.textBoxPageNum.Location = new System.Drawing.Point(83, 107);
			this.textBoxPageNum.Name = "textBoxPageNum";
			this.textBoxPageNum.Size = new System.Drawing.Size(137, 20);
			this.textBoxPageNum.TabIndex = 13;
			this.textBoxPageNum.Text = "1258";
			// 
			// dateTimePickerFlightDate
			// 
			this.dateTimePickerFlightDate.Location = new System.Drawing.Point(83, 52);
			this.dateTimePickerFlightDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerFlightDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerFlightDate.Name = "dateTimePickerFlightDate";
			this.dateTimePickerFlightDate.Size = new System.Drawing.Size(137, 20);
			this.dateTimePickerFlightDate.TabIndex = 15;
			this.dateTimePickerFlightDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			this.dateTimePickerFlightDate.ValueChanged += new System.EventHandler(this.DateTimePickerFlightDateValueChanged);
			// 
			// labelRecordType
			// 
			this.labelRecordType.AutoSize = true;
			this.labelRecordType.Location = new System.Drawing.Point(3, 30);
			this.labelRecordType.Name = "labelRecordType";
			this.labelRecordType.Size = new System.Drawing.Size(56, 13);
			this.labelRecordType.TabIndex = 21;
			this.labelRecordType.Text = "FL./Maint.";
			// 
			// comboBoxRecordType
			// 
			this.comboBoxRecordType.FormattingEnabled = true;
			this.comboBoxRecordType.Location = new System.Drawing.Point(83, 27);
			this.comboBoxRecordType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxRecordType.Name = "comboBoxRecordType";
			this.comboBoxRecordType.Size = new System.Drawing.Size(137, 21);
			this.comboBoxRecordType.TabIndex = 20;
			this.comboBoxRecordType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecordType_SelectedIndexChanged);
			// 
			// dateTimePickerTakeOff
			// 
			this.dateTimePickerTakeOff.CustomFormat = "HH:mm";
			this.dateTimePickerTakeOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTakeOff.Location = new System.Drawing.Point(84, 157);
			this.dateTimePickerTakeOff.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTakeOff.Name = "dateTimePickerTakeOff";
			this.dateTimePickerTakeOff.ShowUpDown = true;
			this.dateTimePickerTakeOff.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerTakeOff.TabIndex = 23;
			// 
			// dateTimePickerLDG
			// 
			this.dateTimePickerLDG.CustomFormat = "HH:mm";
			this.dateTimePickerLDG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerLDG.Location = new System.Drawing.Point(144, 157);
			this.dateTimePickerLDG.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerLDG.Name = "dateTimePickerLDG";
			this.dateTimePickerLDG.ShowUpDown = true;
			this.dateTimePickerLDG.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerLDG.TabIndex = 24;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(2, 159);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 13);
			this.label10.TabIndex = 31;
			this.label10.Text = "Take-off - LDG";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(201, 159);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 13);
			this.label14.TabIndex = 33;
			this.label14.Text = "Flight";
			// 
			// textFlight
			// 
			this.textFlight.Location = new System.Drawing.Point(235, 156);
			this.textFlight.Name = "textFlight";
			this.textFlight.ReadOnly = true;
			this.textFlight.Size = new System.Drawing.Size(45, 20);
			this.textFlight.TabIndex = 34;
			this.textFlight.TabStop = false;
			this.textFlight.Text = "03:40";
			// 
			// checkDY
			// 
			this.checkDY.AutoSize = true;
			this.checkDY.Location = new System.Drawing.Point(185, 182);
			this.checkDY.Name = "checkDY";
			this.checkDY.Size = new System.Drawing.Size(41, 17);
			this.checkDY.TabIndex = 37;
			this.checkDY.Text = "DY";
			this.checkDY.UseVisualStyleBackColor = true;
			// 
			// checkTC
			// 
			this.checkTC.AutoSize = true;
			this.checkTC.Location = new System.Drawing.Point(139, 182);
			this.checkTC.Name = "checkTC";
			this.checkTC.Size = new System.Drawing.Size(40, 17);
			this.checkTC.TabIndex = 36;
			this.checkTC.Text = "TC";
			this.checkTC.UseVisualStyleBackColor = true;
			// 
			// checkPFC
			// 
			this.checkPFC.AutoSize = true;
			this.checkPFC.Location = new System.Drawing.Point(87, 182);
			this.checkPFC.Name = "checkPFC";
			this.checkPFC.Size = new System.Drawing.Size(46, 17);
			this.checkPFC.TabIndex = 35;
			this.checkPFC.Text = "PFC";
			this.checkPFC.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(-3, 183);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 38;
			this.label2.Text = "Check complete";
			// 
			// FlightDateRouteControlLight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkDY);
			this.Controls.Add(this.checkTC);
			this.Controls.Add(this.checkPFC);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textFlight);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.dateTimePickerLDG);
			this.Controls.Add(this.dateTimePickerTakeOff);
			this.Controls.Add(this.labelRecordType);
			this.Controls.Add(this.comboBoxRecordType);
			this.Controls.Add(this.dateTimePickerFlightDate);
			this.Controls.Add(this.labelPageNum);
			this.Controls.Add(this.textBoxPageNum);
			this.Controls.Add(this.textTo);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textFrom);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textFlightNo);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightDateRouteControlLight";
			this.Size = new System.Drawing.Size(313, 210);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textFlightNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textFrom;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textTo;
		private System.Windows.Forms.Label labelPageNum;
		private System.Windows.Forms.TextBox textBoxPageNum;
		private System.Windows.Forms.DateTimePicker dateTimePickerFlightDate;
		private System.Windows.Forms.Label labelRecordType;
		private System.Windows.Forms.ComboBox comboBoxRecordType;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOff;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDG;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textFlight;
		private System.Windows.Forms.CheckBox checkDY;
		private System.Windows.Forms.CheckBox checkTC;
		private System.Windows.Forms.CheckBox checkPFC;
		private System.Windows.Forms.Label label2;
	}
}
