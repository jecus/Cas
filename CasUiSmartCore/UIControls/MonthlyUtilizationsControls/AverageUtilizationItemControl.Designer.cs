namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    partial class AverageUtilizationItemControl
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
			this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
			this.radioButtonDayly = new System.Windows.Forms.RadioButton();
			this.labelHours = new System.Windows.Forms.Label();
			this.labelCycles = new System.Windows.Forms.Label();
			this.labelBaseDetailName = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
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
			this.numericUpDownCycles.Location = new System.Drawing.Point(78, 66);
			this.numericUpDownCycles.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDownCycles.Name = "numericUpDownCycles";
			this.numericUpDownCycles.Size = new System.Drawing.Size(95, 22);
			this.numericUpDownCycles.TabIndex = 48;
			this.numericUpDownCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.NumericUpDownHoursValueChanged);
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
			this.numericUpDownHours.Location = new System.Drawing.Point(78, 39);
			this.numericUpDownHours.Maximum = new decimal(new int[] {
            744,
            0,
            0,
            0});
			this.numericUpDownHours.Name = "numericUpDownHours";
			this.numericUpDownHours.Size = new System.Drawing.Size(95, 22);
			this.numericUpDownHours.TabIndex = 47;
			this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownHours.ValueChanged += new System.EventHandler(this.NumericUpDownHoursValueChanged);
			// 
			// radioButtonMonthly
			// 
			this.radioButtonMonthly.AutoSize = true;
			this.radioButtonMonthly.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radioButtonMonthly.ForeColor = System.Drawing.Color.DimGray;
			this.radioButtonMonthly.Location = new System.Drawing.Point(179, 66);
			this.radioButtonMonthly.Name = "radioButtonMonthly";
			this.radioButtonMonthly.Size = new System.Drawing.Size(85, 22);
			this.radioButtonMonthly.TabIndex = 46;
			this.radioButtonMonthly.TabStop = true;
			this.radioButtonMonthly.Text = "Monthly";
			this.radioButtonMonthly.UseVisualStyleBackColor = true;
			// 
			// radioButtonDayly
			// 
			this.radioButtonDayly.AutoSize = true;
			this.radioButtonDayly.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radioButtonDayly.ForeColor = System.Drawing.Color.DimGray;
			this.radioButtonDayly.Location = new System.Drawing.Point(179, 39);
			this.radioButtonDayly.Name = "radioButtonDayly";
			this.radioButtonDayly.Size = new System.Drawing.Size(61, 22);
			this.radioButtonDayly.TabIndex = 45;
			this.radioButtonDayly.TabStop = true;
			this.radioButtonDayly.Text = "Daily";
			this.radioButtonDayly.UseVisualStyleBackColor = true;
			this.radioButtonDayly.CheckedChanged += new System.EventHandler(this.RadioButtonDaylyCheckedChanged);
			// 
			// labelHours
			// 
			this.labelHours.AutoSize = true;
			this.labelHours.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.labelHours.ForeColor = System.Drawing.Color.DimGray;
			this.labelHours.Location = new System.Drawing.Point(3, 41);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(75, 18);
			this.labelHours.TabIndex = 44;
			this.labelHours.Text = "HRS/DAY";
			// 
			// labelCycles
			// 
			this.labelCycles.AutoSize = true;
			this.labelCycles.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
			this.labelCycles.Location = new System.Drawing.Point(3, 68);
			this.labelCycles.Name = "labelCycles";
			this.labelCycles.Size = new System.Drawing.Size(77, 18);
			this.labelCycles.TabIndex = 43;
			this.labelCycles.Text = "HRS/CYC";
			// 
			// labelBaseDetailName
			// 
			this.labelBaseDetailName.AutoSize = true;
			this.labelBaseDetailName.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.labelBaseDetailName.ForeColor = System.Drawing.Color.DimGray;
			this.labelBaseDetailName.Location = new System.Drawing.Point(3, 0);
			this.labelBaseDetailName.MaximumSize = new System.Drawing.Size(220, 60);
			this.labelBaseDetailName.Name = "labelBaseDetailName";
			this.labelBaseDetailName.Size = new System.Drawing.Size(139, 18);
			this.labelBaseDetailName.TabIndex = 49;
			this.labelBaseDetailName.Text = "Base Detail Name";
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
			this.numericUpDown1.Location = new System.Drawing.Point(78, 94);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(95, 22);
			this.numericUpDown1.TabIndex = 51;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(3, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 18);
			this.label1.TabIndex = 50;
			this.label1.Text = "CYC/DAY";
			// 
			// AverageUtilizationItemControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelBaseDetailName);
			this.Controls.Add(this.numericUpDownCycles);
			this.Controls.Add(this.numericUpDownHours);
			this.Controls.Add(this.radioButtonMonthly);
			this.Controls.Add(this.radioButtonDayly);
			this.Controls.Add(this.labelHours);
			this.Controls.Add(this.labelCycles);
			this.Name = "AverageUtilizationItemControl";
			this.Size = new System.Drawing.Size(288, 126);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.RadioButton radioButtonMonthly;
        private System.Windows.Forms.RadioButton radioButtonDayly;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelCycles;
        private System.Windows.Forms.Label labelBaseDetailName;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
	}
}
