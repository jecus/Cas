namespace CAS.UI.UIControls.ForecastControls
{
    partial class ForecastAdvancedControlItem
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForecastAdvancedControlItem));
            this.lifelengthViewerCurrent = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewerDifferentSource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.lifelengthViewer_ForecastResource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
            this.radioButtonDayly = new System.Windows.Forms.RadioButton();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelCycles = new System.Windows.Forms.Label();
            this.labelBaseDetailName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            this.SuspendLayout();
            // 
            // lifelengthViewerCurrent
            // 
            this.lifelengthViewerCurrent.AutoSize = true;
            this.lifelengthViewerCurrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerCurrent.CalendarApplicable = false;
            this.lifelengthViewerCurrent.Cycles = null;
            this.lifelengthViewerCurrent.CyclesApplicable = false;
            this.lifelengthViewerCurrent.Enabled = false;
            this.lifelengthViewerCurrent.EnabledCalendar = true;
            this.lifelengthViewerCurrent.EnabledCycle = true;
            this.lifelengthViewerCurrent.EnabledHours = true;
            this.lifelengthViewerCurrent.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerCurrent.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerCurrent.HeaderCalendar = "Calendar";
            this.lifelengthViewerCurrent.HeaderCycles = "Cycles";
            this.lifelengthViewerCurrent.HeaderHours = "Hours";
            this.lifelengthViewerCurrent.HoursApplicable = false;
            this.lifelengthViewerCurrent.LeftHeader = "Current";
            this.lifelengthViewerCurrent.Lifelength = ((SmartCore.Calculations.Lifelength)(resources.GetObject("lifelengthViewerCurrent.Lifelength")));
            this.lifelengthViewerCurrent.Location = new System.Drawing.Point(10, 35);
            this.lifelengthViewerCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewerCurrent.Modified = false;
            this.lifelengthViewerCurrent.Name = "lifelengthViewerCurrent";
            this.lifelengthViewerCurrent.ReadOnly = false;
            this.lifelengthViewerCurrent.ShowCalendar = true;
            this.lifelengthViewerCurrent.ShowHeaders = true;
            this.lifelengthViewerCurrent.ShowLeftHeader = true;
            this.lifelengthViewerCurrent.ShowMinutes = true;
            this.lifelengthViewerCurrent.Size = new System.Drawing.Size(420, 52);
            this.lifelengthViewerCurrent.SystemCalculated = true;
            this.lifelengthViewerCurrent.TabIndex = 47;
            // 
            // lifelengthViewerDifferentSource
            // 
            this.lifelengthViewerDifferentSource.AutoSize = true;
            this.lifelengthViewerDifferentSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerDifferentSource.CalendarApplicable = false;
            this.lifelengthViewerDifferentSource.Cycles = null;
            this.lifelengthViewerDifferentSource.CyclesApplicable = false;
            this.lifelengthViewerDifferentSource.Enabled = false;
            this.lifelengthViewerDifferentSource.EnabledCalendar = true;
            this.lifelengthViewerDifferentSource.EnabledCycle = true;
            this.lifelengthViewerDifferentSource.EnabledHours = true;
            this.lifelengthViewerDifferentSource.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerDifferentSource.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerDifferentSource.HeaderCalendar = "Calendar";
            this.lifelengthViewerDifferentSource.HeaderCycles = "Cycles";
            this.lifelengthViewerDifferentSource.HeaderHours = "Hours";
            this.lifelengthViewerDifferentSource.HoursApplicable = false;
            this.lifelengthViewerDifferentSource.LeftHeader = "Different";
            this.lifelengthViewerDifferentSource.Lifelength = ((SmartCore.Calculations.Lifelength)(resources.GetObject("lifelengthViewerDifferentSource.Lifelength")));
            this.lifelengthViewerDifferentSource.Location = new System.Drawing.Point(3, 91);
            this.lifelengthViewerDifferentSource.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewerDifferentSource.Modified = false;
            this.lifelengthViewerDifferentSource.Name = "lifelengthViewerDifferentSource";
            this.lifelengthViewerDifferentSource.ReadOnly = false;
            this.lifelengthViewerDifferentSource.ShowCalendar = true;
            this.lifelengthViewerDifferentSource.ShowHeaders = false;
            this.lifelengthViewerDifferentSource.ShowLeftHeader = true;
            this.lifelengthViewerDifferentSource.ShowMinutes = true;
            this.lifelengthViewerDifferentSource.Size = new System.Drawing.Size(427, 35);
            this.lifelengthViewerDifferentSource.SystemCalculated = true;
            this.lifelengthViewerDifferentSource.TabIndex = 46;
            // 
            // numericUpDownCycles
            // 
            this.numericUpDownCycles.DecimalPlaces = 1;
            this.numericUpDownCycles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownCycles.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownCycles.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownCycles.Location = new System.Drawing.Point(80, 197);
            this.numericUpDownCycles.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownCycles.Name = "numericUpDownCycles";
            this.numericUpDownCycles.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownCycles.TabIndex = 45;
            this.numericUpDownCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.NumericUpDownsValueChanged);
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.DecimalPlaces = 1;
            this.numericUpDownHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownHours.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownHours.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHours.Location = new System.Drawing.Point(80, 170);
            this.numericUpDownHours.Maximum = new decimal(new int[] {
            744,
            0,
            0,
            0});
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownHours.TabIndex = 44;
            this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHours.ValueChanged += new System.EventHandler(this.NumericUpDownsValueChanged);
            // 
            // lifelengthViewer_ForecastResource
            // 
            this.lifelengthViewer_ForecastResource.AutoSize = true;
            this.lifelengthViewer_ForecastResource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_ForecastResource.CalendarApplicable = false;
            this.lifelengthViewer_ForecastResource.Cycles = null;
            this.lifelengthViewer_ForecastResource.CyclesApplicable = false;
            this.lifelengthViewer_ForecastResource.Enabled = false;
            this.lifelengthViewer_ForecastResource.EnabledCalendar = true;
            this.lifelengthViewer_ForecastResource.EnabledCycle = true;
            this.lifelengthViewer_ForecastResource.EnabledHours = true;
            this.lifelengthViewer_ForecastResource.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_ForecastResource.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_ForecastResource.HeaderCalendar = "Calendar";
            this.lifelengthViewer_ForecastResource.HeaderCycles = "Cycles";
            this.lifelengthViewer_ForecastResource.HeaderHours = "Hours";
            this.lifelengthViewer_ForecastResource.HoursApplicable = false;
            this.lifelengthViewer_ForecastResource.LeftHeader = "Forecast";
            this.lifelengthViewer_ForecastResource.Lifelength = ((SmartCore.Calculations.Lifelength)(resources.GetObject("lifelengthViewer_ForecastResource.Lifelength")));
            this.lifelengthViewer_ForecastResource.Location = new System.Drawing.Point(4, 130);
            this.lifelengthViewer_ForecastResource.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_ForecastResource.Modified = false;
            this.lifelengthViewer_ForecastResource.Name = "lifelengthViewer_ForecastResource";
            this.lifelengthViewer_ForecastResource.ReadOnly = false;
            this.lifelengthViewer_ForecastResource.ShowCalendar = true;
            this.lifelengthViewer_ForecastResource.ShowHeaders = false;
            this.lifelengthViewer_ForecastResource.ShowLeftHeader = true;
            this.lifelengthViewer_ForecastResource.ShowMinutes = true;
            this.lifelengthViewer_ForecastResource.Size = new System.Drawing.Size(426, 35);
            this.lifelengthViewer_ForecastResource.SystemCalculated = true;
            this.lifelengthViewer_ForecastResource.TabIndex = 43;
            // 
            // radioButtonMonthly
            // 
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radioButtonMonthly.ForeColor = System.Drawing.Color.DimGray;
            this.radioButtonMonthly.Location = new System.Drawing.Point(154, 197);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(73, 22);
            this.radioButtonMonthly.TabIndex = 42;
            this.radioButtonMonthly.TabStop = true;
            this.radioButtonMonthly.Text = "Month";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            // 
            // radioButtonDayly
            // 
            this.radioButtonDayly.AutoSize = true;
            this.radioButtonDayly.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radioButtonDayly.ForeColor = System.Drawing.Color.DimGray;
            this.radioButtonDayly.Location = new System.Drawing.Point(154, 170);
            this.radioButtonDayly.Name = "radioButtonDayly";
            this.radioButtonDayly.Size = new System.Drawing.Size(67, 22);
            this.radioButtonDayly.TabIndex = 41;
            this.radioButtonDayly.TabStop = true;
            this.radioButtonDayly.Text = "Dayly";
            this.radioButtonDayly.UseVisualStyleBackColor = true;
            this.radioButtonDayly.CheckedChanged += new System.EventHandler(this.RadioButtonDaylyClick);
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelHours.ForeColor = System.Drawing.Color.DimGray;
            this.labelHours.Location = new System.Drawing.Point(18, 172);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(52, 18);
            this.labelHours.TabIndex = 40;
            this.labelHours.Text = "Hours";
            // 
            // labelCycles
            // 
            this.labelCycles.AutoSize = true;
            this.labelCycles.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
            this.labelCycles.Location = new System.Drawing.Point(14, 199);
            this.labelCycles.Name = "labelCycles";
            this.labelCycles.Size = new System.Drawing.Size(56, 18);
            this.labelCycles.TabIndex = 39;
            this.labelCycles.Text = "Cycles";
            // 
            // labelBaseDetailName
            // 
            this.labelBaseDetailName.AutoSize = true;
            this.labelBaseDetailName.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelBaseDetailName.ForeColor = System.Drawing.Color.DimGray;
            this.labelBaseDetailName.Location = new System.Drawing.Point(3, 3);
            this.labelBaseDetailName.MaximumSize = new System.Drawing.Size(220, 60);
            this.labelBaseDetailName.Name = "labelBaseDetailName";
            this.labelBaseDetailName.Size = new System.Drawing.Size(139, 18);
            this.labelBaseDetailName.TabIndex = 50;
            this.labelBaseDetailName.Text = "Base Detail Name";
            // 
            // ForecastAdvancedControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelBaseDetailName);
            this.Controls.Add(this.lifelengthViewerCurrent);
            this.Controls.Add(this.lifelengthViewerDifferentSource);
            this.Controls.Add(this.numericUpDownCycles);
            this.Controls.Add(this.numericUpDownHours);
            this.Controls.Add(this.lifelengthViewer_ForecastResource);
            this.Controls.Add(this.radioButtonMonthly);
            this.Controls.Add(this.radioButtonDayly);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.labelCycles);
            this.Name = "ForecastAdvancedControlItem";
            this.Size = new System.Drawing.Size(435, 230);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Auxiliary.LifelengthViewer lifelengthViewerCurrent;
        public Auxiliary.LifelengthViewer lifelengthViewerDifferentSource;
        private System.Windows.Forms.NumericUpDown numericUpDownCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        public Auxiliary.LifelengthViewer lifelengthViewer_ForecastResource;
        private System.Windows.Forms.RadioButton radioButtonMonthly;
        private System.Windows.Forms.RadioButton radioButtonDayly;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelCycles;
        private System.Windows.Forms.Label labelBaseDetailName;
    }
}
