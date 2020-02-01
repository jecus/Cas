using System.Threading;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.LDND
{
	partial class LDNDForecastForm
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
				if (_checkItems != null)
					_checkItems.Clear();

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
			this.button1 = new System.Windows.Forms.Button();
			this.labelHours = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
			this.labelCycles = new MetroFramework.Controls.MetroLabel();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lifelengthViewerCurrent = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dateTimePickerForecastDate = new System.Windows.Forms.DateTimePicker();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.lifelengthViewerDifferentSource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_ForecastResource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.radioButtonCurrentUtil = new System.Windows.Forms.RadioButton();
			this.radioButtonLast7Days = new System.Windows.Forms.RadioButton();
			this.radioButtonCustom = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(362, 315);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// labelHours
			// 
			this.labelHours.AutoSize = true;
			this.labelHours.ForeColor = System.Drawing.Color.DimGray;
			this.labelHours.Location = new System.Drawing.Point(11, 234);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(62, 19);
			this.labelHours.TabIndex = 42;
			this.labelHours.Text = "HRS/DAY";
			// 
			// numericUpDownHours
			// 
			this.numericUpDownHours.DecimalPlaces = 2;
			this.numericUpDownHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownHours.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownHours.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownHours.Location = new System.Drawing.Point(85, 234);
			this.numericUpDownHours.Maximum = new decimal(new int[] {
            744,
            0,
            0,
            0});
			this.numericUpDownHours.Name = "numericUpDownHours";
			this.numericUpDownHours.Size = new System.Drawing.Size(202, 22);
			this.numericUpDownHours.TabIndex = 48;
			this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownHours.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// numericUpDownCycles
			// 
			this.numericUpDownCycles.DecimalPlaces = 2;
			this.numericUpDownCycles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownCycles.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownCycles.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownCycles.Location = new System.Drawing.Point(85, 259);
			this.numericUpDownCycles.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDownCycles.Name = "numericUpDownCycles";
			this.numericUpDownCycles.Size = new System.Drawing.Size(202, 22);
			this.numericUpDownCycles.TabIndex = 49;
			this.numericUpDownCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// labelCycles
			// 
			this.labelCycles.AutoSize = true;
			this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
			this.labelCycles.Location = new System.Drawing.Point(11, 259);
			this.labelCycles.Name = "labelCycles";
			this.labelCycles.Size = new System.Drawing.Size(64, 19);
			this.labelCycles.TabIndex = 41;
			this.labelCycles.Text = "HRS/CYC";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(11, 284);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 19);
			this.label1.TabIndex = 50;
			this.label1.Text = "CYC/DAY";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDown1.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown1.Location = new System.Drawing.Point(85, 284);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(202, 22);
			this.numericUpDown1.TabIndex = 51;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lifelengthViewerCurrent
			// 
			this.lifelengthViewerCurrent.AutoSize = true;
			this.lifelengthViewerCurrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerCurrent.CalendarApplicable = false;
			this.lifelengthViewerCurrent.CyclesApplicable = false;
			this.lifelengthViewerCurrent.Enabled = false;
			this.lifelengthViewerCurrent.EnabledCalendar = true;
			this.lifelengthViewerCurrent.EnabledCycle = true;
			this.lifelengthViewerCurrent.EnabledHours = true;
			this.lifelengthViewerCurrent.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerCurrent.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerCurrent.HeaderCalendar = "Calendar";
			this.lifelengthViewerCurrent.HeaderCycles = "Cycles";
			this.lifelengthViewerCurrent.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerCurrent.HeaderHours = "Hours";
			this.lifelengthViewerCurrent.HoursApplicable = false;
			this.lifelengthViewerCurrent.LeftHeader = "Current";
			this.lifelengthViewerCurrent.Location = new System.Drawing.Point(17, 62);
			this.lifelengthViewerCurrent.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerCurrent.Modified = false;
			this.lifelengthViewerCurrent.Name = "lifelengthViewerCurrent";
			this.lifelengthViewerCurrent.ReadOnly = false;
			this.lifelengthViewerCurrent.ShowCalendar = true;
			this.lifelengthViewerCurrent.ShowFormattedCalendar = false;
			this.lifelengthViewerCurrent.ShowMinutes = true;
			this.lifelengthViewerCurrent.Size = new System.Drawing.Size(420, 52);
			this.lifelengthViewerCurrent.SystemCalculated = true;
			this.lifelengthViewerCurrent.TabIndex = 68;
			// 
			// dateTimePickerForecastDate
			// 
			this.dateTimePickerForecastDate.Font = new System.Drawing.Font("Verdana", 10F);
			this.dateTimePickerForecastDate.Location = new System.Drawing.Point(85, 197);
			this.dateTimePickerForecastDate.Name = "dateTimePickerForecastDate";
			this.dateTimePickerForecastDate.Size = new System.Drawing.Size(347, 24);
			this.dateTimePickerForecastDate.TabIndex = 64;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.DimGray;
			this.metroLabel1.Location = new System.Drawing.Point(11, 197);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(72, 19);
			this.metroLabel1.TabIndex = 65;
			this.metroLabel1.Text = "Date as of:";
			// 
			// lifelengthViewerDifferentSource
			// 
			this.lifelengthViewerDifferentSource.AutoSize = true;
			this.lifelengthViewerDifferentSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerDifferentSource.CalendarApplicable = false;
			this.lifelengthViewerDifferentSource.CyclesApplicable = false;
			this.lifelengthViewerDifferentSource.Enabled = false;
			this.lifelengthViewerDifferentSource.EnabledCalendar = true;
			this.lifelengthViewerDifferentSource.EnabledCycle = true;
			this.lifelengthViewerDifferentSource.EnabledHours = true;
			this.lifelengthViewerDifferentSource.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerDifferentSource.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerDifferentSource.HeaderCalendar = "Calendar";
			this.lifelengthViewerDifferentSource.HeaderCycles = "Cycles";
			this.lifelengthViewerDifferentSource.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerDifferentSource.HeaderHours = "Hours";
			this.lifelengthViewerDifferentSource.HoursApplicable = false;
			this.lifelengthViewerDifferentSource.LeftHeader = "Different";
			this.lifelengthViewerDifferentSource.Location = new System.Drawing.Point(10, 118);
			this.lifelengthViewerDifferentSource.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerDifferentSource.Modified = false;
			this.lifelengthViewerDifferentSource.Name = "lifelengthViewerDifferentSource";
			this.lifelengthViewerDifferentSource.ReadOnly = false;
			this.lifelengthViewerDifferentSource.ShowCalendar = true;
			this.lifelengthViewerDifferentSource.ShowFormattedCalendar = false;
			this.lifelengthViewerDifferentSource.ShowHeaders = false;
			this.lifelengthViewerDifferentSource.ShowMinutes = true;
			this.lifelengthViewerDifferentSource.Size = new System.Drawing.Size(427, 35);
			this.lifelengthViewerDifferentSource.SystemCalculated = true;
			this.lifelengthViewerDifferentSource.TabIndex = 67;
			// 
			// lifelengthViewer_ForecastResource
			// 
			this.lifelengthViewer_ForecastResource.AutoSize = true;
			this.lifelengthViewer_ForecastResource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_ForecastResource.CalendarApplicable = false;
			this.lifelengthViewer_ForecastResource.CyclesApplicable = false;
			this.lifelengthViewer_ForecastResource.Enabled = false;
			this.lifelengthViewer_ForecastResource.EnabledCalendar = true;
			this.lifelengthViewer_ForecastResource.EnabledCycle = true;
			this.lifelengthViewer_ForecastResource.EnabledHours = true;
			this.lifelengthViewer_ForecastResource.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_ForecastResource.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_ForecastResource.HeaderCalendar = "Calendar";
			this.lifelengthViewer_ForecastResource.HeaderCycles = "Cycles";
			this.lifelengthViewer_ForecastResource.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_ForecastResource.HeaderHours = "Hours";
			this.lifelengthViewer_ForecastResource.HoursApplicable = false;
			this.lifelengthViewer_ForecastResource.LeftHeader = "Forecast";
			this.lifelengthViewer_ForecastResource.Location = new System.Drawing.Point(11, 157);
			this.lifelengthViewer_ForecastResource.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_ForecastResource.Modified = false;
			this.lifelengthViewer_ForecastResource.Name = "lifelengthViewer_ForecastResource";
			this.lifelengthViewer_ForecastResource.ReadOnly = false;
			this.lifelengthViewer_ForecastResource.ShowCalendar = true;
			this.lifelengthViewer_ForecastResource.ShowFormattedCalendar = false;
			this.lifelengthViewer_ForecastResource.ShowHeaders = false;
			this.lifelengthViewer_ForecastResource.ShowMinutes = true;
			this.lifelengthViewer_ForecastResource.Size = new System.Drawing.Size(426, 35);
			this.lifelengthViewer_ForecastResource.SystemCalculated = true;
			this.lifelengthViewer_ForecastResource.TabIndex = 66;
			// 
			// radioButtonCurrentUtil
			// 
			this.radioButtonCurrentUtil.AutoSize = true;
			this.radioButtonCurrentUtil.Location = new System.Drawing.Point(300, 234);
			this.radioButtonCurrentUtil.Name = "radioButtonCurrentUtil";
			this.radioButtonCurrentUtil.Size = new System.Drawing.Size(126, 17);
			this.radioButtonCurrentUtil.TabIndex = 69;
			this.radioButtonCurrentUtil.TabStop = true;
			this.radioButtonCurrentUtil.Text = "Use current utilization";
			this.radioButtonCurrentUtil.UseVisualStyleBackColor = true;
			// 
			// radioButtonLast7Days
			// 
			this.radioButtonLast7Days.AutoSize = true;
			this.radioButtonLast7Days.Location = new System.Drawing.Point(300, 260);
			this.radioButtonLast7Days.Name = "radioButtonLast7Days";
			this.radioButtonLast7Days.Size = new System.Drawing.Size(93, 17);
			this.radioButtonLast7Days.TabIndex = 70;
			this.radioButtonLast7Days.TabStop = true;
			this.radioButtonLast7Days.Text = "For last 7 days";
			this.radioButtonLast7Days.UseVisualStyleBackColor = true;
			// 
			// radioButtonCustom
			// 
			this.radioButtonCustom.AutoSize = true;
			this.radioButtonCustom.Location = new System.Drawing.Point(300, 286);
			this.radioButtonCustom.Name = "radioButtonCustom";
			this.radioButtonCustom.Size = new System.Drawing.Size(60, 17);
			this.radioButtonCustom.TabIndex = 71;
			this.radioButtonCustom.TabStop = true;
			this.radioButtonCustom.Text = "Custom";
			this.radioButtonCustom.UseVisualStyleBackColor = true;
			// 
			// LDNDForecastForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 359);
			this.Controls.Add(this.radioButtonCustom);
			this.Controls.Add(this.radioButtonLast7Days);
			this.Controls.Add(this.radioButtonCurrentUtil);
			this.Controls.Add(this.lifelengthViewerCurrent);
			this.Controls.Add(this.dateTimePickerForecastDate);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.lifelengthViewerDifferentSource);
			this.Controls.Add(this.lifelengthViewer_ForecastResource);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.labelCycles);
			this.Controls.Add(this.numericUpDownCycles);
			this.Controls.Add(this.labelHours);
			this.Controls.Add(this.numericUpDownHours);
			this.Controls.Add(this.button1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LDNDForecastForm";
			this.Resizable = false;
			this.Text = "LDND Forecast Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private MetroLabel labelHours;
		private System.Windows.Forms.NumericUpDown numericUpDownHours;
		private System.Windows.Forms.NumericUpDown numericUpDownCycles;
		private MetroLabel labelCycles;
		private MetroLabel label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		public Auxiliary.LifelengthViewer lifelengthViewerCurrent;
		private System.Windows.Forms.DateTimePicker dateTimePickerForecastDate;
		private MetroLabel metroLabel1;
		public Auxiliary.LifelengthViewer lifelengthViewerDifferentSource;
		public Auxiliary.LifelengthViewer lifelengthViewer_ForecastResource;
		private System.Windows.Forms.RadioButton radioButtonCurrentUtil;
		private System.Windows.Forms.RadioButton radioButtonLast7Days;
		private System.Windows.Forms.RadioButton radioButtonCustom;
	}
}