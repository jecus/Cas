namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentLifeLimitControlItem
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
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerRemain = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.radioButtonCurrent = new System.Windows.Forms.RadioButton();
			this.lifelengthViewerCurrent = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.SuspendLayout();
			// 
			// lifelengthViewerLifeLimit
			// 
			this.lifelengthViewerLifeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerLifeLimit.AutoSize = true;
			this.lifelengthViewerLifeLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerLifeLimit.CalendarApplicable = false;
			this.lifelengthViewerLifeLimit.CyclesApplicable = false;
			this.lifelengthViewerLifeLimit.EnabledCalendar = true;
			this.lifelengthViewerLifeLimit.EnabledCycle = true;
			this.lifelengthViewerLifeLimit.EnabledHours = true;
			this.lifelengthViewerLifeLimit.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerLifeLimit.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerLifeLimit.HeaderCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderCycles = "Cycles";
			this.lifelengthViewerLifeLimit.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderHours = "Hours";
			this.lifelengthViewerLifeLimit.HoursApplicable = false;
			this.lifelengthViewerLifeLimit.LeftHeader = "";
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(137, 0);
			this.lifelengthViewerLifeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerLifeLimit.Modified = false;
			this.lifelengthViewerLifeLimit.Name = "lifelengthViewerLifeLimit";
			this.lifelengthViewerLifeLimit.ReadOnly = false;
			this.lifelengthViewerLifeLimit.ShowCalendar = true;
			this.lifelengthViewerLifeLimit.ShowFormattedCalendar = false;
			this.lifelengthViewerLifeLimit.ShowHeaders = false;
			this.lifelengthViewerLifeLimit.ShowMinutes = false;
			this.lifelengthViewerLifeLimit.Size = new System.Drawing.Size(358, 35);
			this.lifelengthViewerLifeLimit.SystemCalculated = true;
			this.lifelengthViewerLifeLimit.TabIndex = 73;
			// 
			// lifelengthViewerRemain
			// 
			this.lifelengthViewerRemain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerRemain.AutoSize = true;
			this.lifelengthViewerRemain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRemain.CalendarApplicable = false;
			this.lifelengthViewerRemain.CyclesApplicable = false;
			this.lifelengthViewerRemain.Enabled = false;
			this.lifelengthViewerRemain.EnabledCalendar = true;
			this.lifelengthViewerRemain.EnabledCycle = true;
			this.lifelengthViewerRemain.EnabledHours = true;
			this.lifelengthViewerRemain.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRemain.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerRemain.HeaderCalendar = "Calendar";
			this.lifelengthViewerRemain.HeaderCycles = "Cycles";
			this.lifelengthViewerRemain.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerRemain.HeaderHours = "Hours";
			this.lifelengthViewerRemain.HoursApplicable = false;
			this.lifelengthViewerRemain.LeftHeader = "Remain:";
			this.lifelengthViewerRemain.Location = new System.Drawing.Point(610, 39);
			this.lifelengthViewerRemain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerRemain.Modified = false;
			this.lifelengthViewerRemain.Name = "lifelengthViewerRemain";
			this.lifelengthViewerRemain.ReadOnly = false;
			this.lifelengthViewerRemain.ShowCalendar = true;
			this.lifelengthViewerRemain.ShowFormattedCalendar = false;
			this.lifelengthViewerRemain.ShowHeaders = false;
			this.lifelengthViewerRemain.ShowMinutes = false;
			this.lifelengthViewerRemain.Size = new System.Drawing.Size(423, 35);
			this.lifelengthViewerRemain.SystemCalculated = true;
			this.lifelengthViewerRemain.TabIndex = 74;
			// 
			// radioButtonCurrent
			// 
			this.radioButtonCurrent.AutoSize = true;
			this.radioButtonCurrent.Enabled = false;
			this.radioButtonCurrent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButtonCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radioButtonCurrent.Location = new System.Drawing.Point(3, 8);
			this.radioButtonCurrent.Name = "radioButtonCurrent";
			this.radioButtonCurrent.Size = new System.Drawing.Size(14, 13);
			this.radioButtonCurrent.TabIndex = 76;
			this.radioButtonCurrent.UseVisualStyleBackColor = true;
			this.radioButtonCurrent.Click += new System.EventHandler(this.RadioButtonCurrentCheckedChanged);
			// 
			// lifelengthViewerCurrent
			// 
			this.lifelengthViewerCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			this.lifelengthViewerCurrent.LeftHeader = "Current:";
			this.lifelengthViewerCurrent.Location = new System.Drawing.Point(69, 39);
			this.lifelengthViewerCurrent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerCurrent.Modified = false;
			this.lifelengthViewerCurrent.Name = "lifelengthViewerCurrent";
			this.lifelengthViewerCurrent.ReadOnly = false;
			this.lifelengthViewerCurrent.ShowCalendar = true;
			this.lifelengthViewerCurrent.ShowFormattedCalendar = false;
			this.lifelengthViewerCurrent.ShowHeaders = false;
			this.lifelengthViewerCurrent.ShowMinutes = false;
			this.lifelengthViewerCurrent.Size = new System.Drawing.Size(426, 35);
			this.lifelengthViewerCurrent.SystemCalculated = true;
			this.lifelengthViewerCurrent.TabIndex = 77;
			// 
			// lifelengthViewerNotify
			// 
			this.lifelengthViewerNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewerNotify.AutoSize = true;
			this.lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerNotify.CalendarApplicable = false;
			this.lifelengthViewerNotify.CyclesApplicable = false;
			this.lifelengthViewerNotify.EnabledCalendar = true;
			this.lifelengthViewerNotify.EnabledCycle = true;
			this.lifelengthViewerNotify.EnabledHours = true;
			this.lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderHours = "Hours";
			this.lifelengthViewerNotify.HoursApplicable = false;
			this.lifelengthViewerNotify.LeftHeader = "Notify:";
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(620, 0);
			this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerNotify.Modified = false;
			this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
			this.lifelengthViewerNotify.ReadOnly = false;
			this.lifelengthViewerNotify.ShowCalendar = true;
			this.lifelengthViewerNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerNotify.ShowHeaders = false;
			this.lifelengthViewerNotify.ShowMinutes = false;
			this.lifelengthViewerNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerNotify.SystemCalculated = true;
			this.lifelengthViewerNotify.TabIndex = 78;
			// 
			// ComponentLifeLimitControlItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.lifelengthViewerNotify);
			this.Controls.Add(this.lifelengthViewerCurrent);
			this.Controls.Add(this.radioButtonCurrent);
			this.Controls.Add(this.lifelengthViewerLifeLimit);
			this.Controls.Add(this.lifelengthViewerRemain);
			this.Name = "ComponentLifeLimitControlItem";
			this.Size = new System.Drawing.Size(1048, 76);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Auxiliary.LifelengthViewer lifelengthViewerLifeLimit;
        private Auxiliary.LifelengthViewer lifelengthViewerRemain;
        private System.Windows.Forms.RadioButton radioButtonCurrent;
        private Auxiliary.LifelengthViewer lifelengthViewerCurrent;
        private Auxiliary.LifelengthViewer lifelengthViewerNotify;
    }
}
