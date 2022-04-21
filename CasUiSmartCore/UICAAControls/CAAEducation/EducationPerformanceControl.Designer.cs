using System.ComponentModel;

namespace CAS.UI.UICAAControls.CAAEducation
{
    partial class EducationPerformanceControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.groupBoxClose = new System.Windows.Forms.GroupBox();
            this.lifelengthViewer_Repeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.labelEffectivityDate = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.groupBoxClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.AutoSize = true;
            this.checkBoxClose.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.checkBoxClose.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxClose.Location = new System.Drawing.Point(8, 21);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(68, 22);
            this.checkBoxClose.TabIndex = 25;
            this.checkBoxClose.Text = "Close";
            this.checkBoxClose.UseVisualStyleBackColor = true;
            // 
            // groupBoxClose
            // 
            this.groupBoxClose.Controls.Add(this.checkBoxClose);
            this.groupBoxClose.ForeColor = System.Drawing.Color.DimGray;
            this.groupBoxClose.Location = new System.Drawing.Point(262, 3);
            this.groupBoxClose.Name = "groupBoxClose";
            this.groupBoxClose.Size = new System.Drawing.Size(86, 162);
            this.groupBoxClose.TabIndex = 196;
            this.groupBoxClose.TabStop = false;
            this.groupBoxClose.Text = "STATUS";
            // 
            // lifelengthViewer_Repeat
            // 
            this.lifelengthViewer_Repeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_Repeat.AutoSize = true;
            this.lifelengthViewer_Repeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_Repeat.CalendarApplicable = false;
            this.lifelengthViewer_Repeat.CyclesApplicable = false;
            this.lifelengthViewer_Repeat.EnabledCalendar = true;
            this.lifelengthViewer_Repeat.EnabledCycle = false;
            this.lifelengthViewer_Repeat.EnabledHours = true;
            this.lifelengthViewer_Repeat.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_Repeat.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_Repeat.HeaderCalendar = "";
            this.lifelengthViewer_Repeat.HeaderCycles = "Cycles";
            this.lifelengthViewer_Repeat.HeaderFormattedCalendar = "Calendar";
            this.lifelengthViewer_Repeat.HeaderHours = "Hours";
            this.lifelengthViewer_Repeat.HoursApplicable = false;
            this.lifelengthViewer_Repeat.LeftHeader = "Repeat";
            this.lifelengthViewer_Repeat.Location = new System.Drawing.Point(14, 44);
            this.lifelengthViewer_Repeat.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_Repeat.Modified = false;
            this.lifelengthViewer_Repeat.Name = "lifelengthViewer_Repeat";
            this.lifelengthViewer_Repeat.ReadOnly = false;
            this.lifelengthViewer_Repeat.ShowCalendar = true;
            this.lifelengthViewer_Repeat.ShowCalendarOnly = true;
            this.lifelengthViewer_Repeat.ShowFormattedCalendar = false;
            this.lifelengthViewer_Repeat.ShowMinutes = false;
            this.lifelengthViewer_Repeat.Size = new System.Drawing.Size(233, 52);
            this.lifelengthViewer_Repeat.SystemCalculated = true;
            this.lifelengthViewer_Repeat.TabIndex = 197;
            // 
            // lifelengthViewerNotify
            // 
            this.lifelengthViewerNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewerNotify.AutoSize = true;
            this.lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerNotify.CalendarApplicable = false;
            this.lifelengthViewerNotify.CyclesApplicable = false;
            this.lifelengthViewerNotify.EnabledCalendar = true;
            this.lifelengthViewerNotify.EnabledCycle = false;
            this.lifelengthViewerNotify.EnabledHours = true;
            this.lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerNotify.HeaderCalendar = "";
            this.lifelengthViewerNotify.HeaderCycles = "Cycles";
            this.lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
            this.lifelengthViewerNotify.HeaderHours = "Hours";
            this.lifelengthViewerNotify.HoursApplicable = false;
            this.lifelengthViewerNotify.LeftHeader = "Notify  ";
            this.lifelengthViewerNotify.Location = new System.Drawing.Point(14, 101);
            this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewerNotify.Modified = false;
            this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
            this.lifelengthViewerNotify.ReadOnly = false;
            this.lifelengthViewerNotify.ShowCalendar = true;
            this.lifelengthViewerNotify.ShowCalendarOnly = true;
            this.lifelengthViewerNotify.ShowFormattedCalendar = false;
            this.lifelengthViewerNotify.ShowMinutes = false;
            this.lifelengthViewerNotify.Size = new System.Drawing.Size(235, 52);
            this.lifelengthViewerNotify.SystemCalculated = true;
            this.lifelengthViewerNotify.TabIndex = 198;
            // 
            // labelEffectivityDate
            // 
            this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectivityDate.Location = new System.Drawing.Point(14, 20);
            this.labelEffectivityDate.Name = "labelEffectivityDate";
            this.labelEffectivityDate.Size = new System.Drawing.Size(56, 25);
            this.labelEffectivityDate.TabIndex = 199;
            this.labelEffectivityDate.Text = "Start";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerStart.Location = new System.Drawing.Point(77, 14);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(170, 25);
            this.dateTimePickerStart.TabIndex = 200;
            // 
            // EducationPerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEffectivityDate);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.lifelengthViewerNotify);
            this.Controls.Add(this.lifelengthViewer_Repeat);
            this.Controls.Add(this.groupBoxClose);
            this.Name = "EducationPerformanceControl";
            this.Size = new System.Drawing.Size(401, 172);
            this.groupBoxClose.ResumeLayout(false);
            this.groupBoxClose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelEffectivityDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;

        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerNotify;

        public System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.GroupBox groupBoxClose;
        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewer_Repeat;

        #endregion
    }
}