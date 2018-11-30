namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelPageNum = new System.Windows.Forms.Label();
			this.textBoxPageNum = new System.Windows.Forms.TextBox();
			this.dateTimePickerFlightDate = new System.Windows.Forms.DateTimePicker();
			this.labelRecordType = new System.Windows.Forms.Label();
			this.comboBoxRecordType = new System.Windows.Forms.ComboBox();
			this.dateTimePickerTakeOff = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLDG = new System.Windows.Forms.DateTimePicker();
			this.label14 = new System.Windows.Forms.Label();
			this.textFlight = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.checkDY = new System.Windows.Forms.CheckBox();
			this.checkTC = new System.Windows.Forms.CheckBox();
			this.checkPFC = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lookupComboboxFrom = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lookupComboboxTo = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.label6 = new System.Windows.Forms.Label();
			this.lookupComboboxFlightNumber = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.checkBoxRC = new System.Windows.Forms.CheckBox();
			this.checkBoxSC = new System.Windows.Forms.CheckBox();
			this.checkBoxA = new System.Windows.Forms.CheckBox();
			this.checkBoxC = new System.Windows.Forms.CheckBox();
			this.checkADD = new System.Windows.Forms.CheckBox();
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 182);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Flight No";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Date";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "From";
			// 
			// labelPageNum
			// 
			this.labelPageNum.AutoSize = true;
			this.labelPageNum.Location = new System.Drawing.Point(3, 156);
			this.labelPageNum.Name = "labelPageNum";
			this.labelPageNum.Size = new System.Drawing.Size(49, 13);
			this.labelPageNum.TabIndex = 14;
			this.labelPageNum.Text = "Page No";
			// 
			// textBoxPageNum
			// 
			this.textBoxPageNum.Location = new System.Drawing.Point(86, 153);
			this.textBoxPageNum.Name = "textBoxPageNum";
			this.textBoxPageNum.Size = new System.Drawing.Size(137, 20);
			this.textBoxPageNum.TabIndex = 13;
			this.textBoxPageNum.Text = "1258";
			// 
			// dateTimePickerFlightDate
			// 
			this.dateTimePickerFlightDate.Location = new System.Drawing.Point(86, 50);
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
			this.comboBoxRecordType.Location = new System.Drawing.Point(86, 27);
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
			this.dateTimePickerTakeOff.Location = new System.Drawing.Point(86, 128);
			this.dateTimePickerTakeOff.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTakeOff.Name = "dateTimePickerTakeOff";
			this.dateTimePickerTakeOff.ShowUpDown = true;
			this.dateTimePickerTakeOff.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerTakeOff.TabIndex = 33;
			this.dateTimePickerTakeOff.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOff_ValueChanged);
			// 
			// dateTimePickerLDG
			// 
			this.dateTimePickerLDG.CustomFormat = "HH:mm";
			this.dateTimePickerLDG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerLDG.Location = new System.Drawing.Point(158, 128);
			this.dateTimePickerLDG.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerLDG.Name = "dateTimePickerLDG";
			this.dateTimePickerLDG.ShowUpDown = true;
			this.dateTimePickerLDG.Size = new System.Drawing.Size(56, 20);
			this.dateTimePickerLDG.TabIndex = 34;
			this.dateTimePickerLDG.ValueChanged += new System.EventHandler(this.dateTimePickerTakeOff_ValueChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(219, 131);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 13);
			this.label14.TabIndex = 37;
			this.label14.Text = "Flight";
			// 
			// textFlight
			// 
			this.textFlight.Location = new System.Drawing.Point(259, 128);
			this.textFlight.Name = "textFlight";
			this.textFlight.ReadOnly = true;
			this.textFlight.Size = new System.Drawing.Size(45, 20);
			this.textFlight.TabIndex = 36;
			this.textFlight.TabStop = false;
			this.textFlight.Text = "03:40";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 131);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 13);
			this.label10.TabIndex = 35;
			this.label10.Text = "Take-off - LDG";
			// 
			// checkDY
			// 
			this.checkDY.AutoSize = true;
			this.checkDY.Location = new System.Drawing.Point(194, 205);
			this.checkDY.Name = "checkDY";
			this.checkDY.Size = new System.Drawing.Size(41, 17);
			this.checkDY.TabIndex = 40;
			this.checkDY.Text = "DY";
			this.checkDY.UseVisualStyleBackColor = true;
			// 
			// checkTC
			// 
			this.checkTC.AutoSize = true;
			this.checkTC.Location = new System.Drawing.Point(148, 205);
			this.checkTC.Name = "checkTC";
			this.checkTC.Size = new System.Drawing.Size(40, 17);
			this.checkTC.TabIndex = 39;
			this.checkTC.Text = "TC";
			this.checkTC.UseVisualStyleBackColor = true;
			// 
			// checkPFC
			// 
			this.checkPFC.AutoSize = true;
			this.checkPFC.Location = new System.Drawing.Point(96, 205);
			this.checkPFC.Name = "checkPFC";
			this.checkPFC.Size = new System.Drawing.Size(46, 17);
			this.checkPFC.TabIndex = 38;
			this.checkPFC.Text = "PFC";
			this.checkPFC.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 206);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 41;
			this.label2.Text = "Check complete";
			// 
			// lookupComboboxFrom
			// 
			this.lookupComboboxFrom.Displayer = null;
			this.lookupComboboxFrom.DisplayerText = null;
			this.lookupComboboxFrom.Entity = null;
			this.lookupComboboxFrom.Location = new System.Drawing.Point(86, 76);
			this.lookupComboboxFrom.Name = "lookupComboboxFrom";
			this.lookupComboboxFrom.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFrom.Size = new System.Drawing.Size(218, 21);
			this.lookupComboboxFrom.TabIndex = 42;
			this.lookupComboboxFrom.Type = null;
			// 
			// lookupComboboxTo
			// 
			this.lookupComboboxTo.Displayer = null;
			this.lookupComboboxTo.DisplayerText = null;
			this.lookupComboboxTo.Entity = null;
			this.lookupComboboxTo.Location = new System.Drawing.Point(86, 101);
			this.lookupComboboxTo.Name = "lookupComboboxTo";
			this.lookupComboboxTo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxTo.Size = new System.Drawing.Size(218, 21);
			this.lookupComboboxTo.TabIndex = 43;
			this.lookupComboboxTo.Type = null;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 109);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 44;
			this.label6.Text = "To";
			// 
			// lookupComboboxFlightNumber
			// 
			this.lookupComboboxFlightNumber.Displayer = null;
			this.lookupComboboxFlightNumber.DisplayerText = null;
			this.lookupComboboxFlightNumber.Entity = null;
			this.lookupComboboxFlightNumber.Location = new System.Drawing.Point(86, 178);
			this.lookupComboboxFlightNumber.Name = "lookupComboboxFlightNumber";
			this.lookupComboboxFlightNumber.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFlightNumber.Size = new System.Drawing.Size(218, 21);
			this.lookupComboboxFlightNumber.TabIndex = 45;
			this.lookupComboboxFlightNumber.Type = null;
			// 
			// checkBoxRC
			// 
			this.checkBoxRC.AutoSize = true;
			this.checkBoxRC.Location = new System.Drawing.Point(96, 228);
			this.checkBoxRC.Name = "checkBoxRC";
			this.checkBoxRC.Size = new System.Drawing.Size(41, 17);
			this.checkBoxRC.TabIndex = 46;
			this.checkBoxRC.Text = "RC";
			this.checkBoxRC.UseVisualStyleBackColor = true;
			// 
			// checkBoxSC
			// 
			this.checkBoxSC.AutoSize = true;
			this.checkBoxSC.Location = new System.Drawing.Point(135, 228);
			this.checkBoxSC.Name = "checkBoxSC";
			this.checkBoxSC.Size = new System.Drawing.Size(40, 17);
			this.checkBoxSC.TabIndex = 47;
			this.checkBoxSC.Text = "SC";
			this.checkBoxSC.UseVisualStyleBackColor = true;
			// 
			// checkBoxA
			// 
			this.checkBoxA.AutoSize = true;
			this.checkBoxA.Location = new System.Drawing.Point(181, 228);
			this.checkBoxA.Name = "checkBoxA";
			this.checkBoxA.Size = new System.Drawing.Size(33, 17);
			this.checkBoxA.TabIndex = 48;
			this.checkBoxA.Text = "A";
			this.checkBoxA.UseVisualStyleBackColor = true;
			// 
			// checkBoxC
			// 
			this.checkBoxC.AutoSize = true;
			this.checkBoxC.Location = new System.Drawing.Point(218, 228);
			this.checkBoxC.Name = "checkBoxC";
			this.checkBoxC.Size = new System.Drawing.Size(33, 17);
			this.checkBoxC.TabIndex = 49;
			this.checkBoxC.Text = "C";
			this.checkBoxC.UseVisualStyleBackColor = true;
			// 
			// checkADD
			// 
			this.checkADD.AutoSize = true;
			this.checkADD.Location = new System.Drawing.Point(241, 205);
			this.checkADD.Name = "checkADD";
			this.checkADD.Size = new System.Drawing.Size(49, 17);
			this.checkADD.TabIndex = 50;
			this.checkADD.Text = "ADD";
			this.checkADD.UseVisualStyleBackColor = true;
			// 
			// FlightDateRouteControlLight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkADD);
			this.Controls.Add(this.checkBoxC);
			this.Controls.Add(this.checkBoxA);
			this.Controls.Add(this.checkBoxSC);
			this.Controls.Add(this.checkBoxRC);
			this.Controls.Add(this.lookupComboboxFlightNumber);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lookupComboboxTo);
			this.Controls.Add(this.lookupComboboxFrom);
			this.Controls.Add(this.checkDY);
			this.Controls.Add(this.checkTC);
			this.Controls.Add(this.checkPFC);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePickerTakeOff);
			this.Controls.Add(this.dateTimePickerLDG);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textFlight);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.labelRecordType);
			this.Controls.Add(this.comboBoxRecordType);
			this.Controls.Add(this.dateTimePickerFlightDate);
			this.Controls.Add(this.labelPageNum);
			this.Controls.Add(this.textBoxPageNum);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightDateRouteControlLight";
			this.Size = new System.Drawing.Size(307, 254);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPageNum;
        private System.Windows.Forms.TextBox textBoxPageNum;
        private System.Windows.Forms.DateTimePicker dateTimePickerFlightDate;
        private System.Windows.Forms.Label labelRecordType;
        private System.Windows.Forms.ComboBox comboBoxRecordType;
		private System.Windows.Forms.DateTimePicker dateTimePickerTakeOff;
		private System.Windows.Forms.DateTimePicker dateTimePickerLDG;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textFlight;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox checkDY;
		private System.Windows.Forms.CheckBox checkTC;
		private System.Windows.Forms.CheckBox checkPFC;
		private System.Windows.Forms.Label label2;
		private Auxiliary.LookupCombobox lookupComboboxFrom;
		private Auxiliary.LookupCombobox lookupComboboxTo;
		private System.Windows.Forms.Label label6;
		private Auxiliary.LookupCombobox lookupComboboxFlightNumber;
		private System.Windows.Forms.CheckBox checkBoxRC;
		private System.Windows.Forms.CheckBox checkBoxSC;
		private System.Windows.Forms.CheckBox checkBoxA;
		private System.Windows.Forms.CheckBox checkBoxC;
		private System.Windows.Forms.CheckBox checkADD;
	}
}
