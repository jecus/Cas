namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DirectiveThresholdControl
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
            this.groupBox_Repetative = new System.Windows.Forms.GroupBox();
            this.radio_RepeatWhicheverLast = new System.Windows.Forms.RadioButton();
            this.lifelengthViewer_RepeatNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.radio_RepeatWhicheverFirst = new System.Windows.Forms.RadioButton();
            this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
            this.lifelengthViewer_Repeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.groupFirstPerformance = new System.Windows.Forms.GroupBox();
            this.radio_FirstWhicheverLast = new System.Windows.Forms.RadioButton();
            this.radio_FirstWhicheverFirst = new System.Windows.Forms.RadioButton();
            this.lifelengthViewer_SinceEffDate = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewer_SinceNew = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.groupBox_Repetative.SuspendLayout();
            this.groupFirstPerformance.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Repetative
            // 
            this.groupBox_Repetative.AutoSize = true;
            this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverLast);
            this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_RepeatNotify);
            this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverFirst);
            this.groupBox_Repetative.Controls.Add(this.checkBoxRepeat);
            this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_Repeat);
            this.groupBox_Repetative.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox_Repetative.Location = new System.Drawing.Point(687, 0);
            this.groupBox_Repetative.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Repetative.Name = "groupBox_Repetative";
            this.groupBox_Repetative.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Repetative.Size = new System.Drawing.Size(631, 276);
            this.groupBox_Repetative.TabIndex = 24;
            this.groupBox_Repetative.TabStop = false;
            this.groupBox_Repetative.Text = "REPEAT";
            // 
            // radio_RepeatWhicheverLast
            // 
            this.radio_RepeatWhicheverLast.AutoSize = true;
            this.radio_RepeatWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radio_RepeatWhicheverLast.Location = new System.Drawing.Point(429, 217);
            this.radio_RepeatWhicheverLast.Margin = new System.Windows.Forms.Padding(4);
            this.radio_RepeatWhicheverLast.Name = "radio_RepeatWhicheverLast";
            this.radio_RepeatWhicheverLast.Size = new System.Drawing.Size(186, 27);
            this.radio_RepeatWhicheverLast.TabIndex = 24;
            this.radio_RepeatWhicheverLast.Text = "Whichever Later";
            this.radio_RepeatWhicheverLast.UseVisualStyleBackColor = true;
            // 
            // lifelengthViewer_RepeatNotify
            // 
            this.lifelengthViewer_RepeatNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_RepeatNotify.AutoSize = true;
            this.lifelengthViewer_RepeatNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_RepeatNotify.CalendarApplicable = false;
            this.lifelengthViewer_RepeatNotify.Cycles = null;
            this.lifelengthViewer_RepeatNotify.CyclesApplicable = false;
            this.lifelengthViewer_RepeatNotify.Enabled = false;
            this.lifelengthViewer_RepeatNotify.EnabledCalendar = true;
            this.lifelengthViewer_RepeatNotify.EnabledCycle = true;
            this.lifelengthViewer_RepeatNotify.EnabledHours = true;
            this.lifelengthViewer_RepeatNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_RepeatNotify.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_RepeatNotify.HeaderCalendar = "Calendar";
            this.lifelengthViewer_RepeatNotify.HeaderCycles = "Cycles";
            this.lifelengthViewer_RepeatNotify.HeaderHours = "Hours";
            this.lifelengthViewer_RepeatNotify.HoursApplicable = false;
            this.lifelengthViewer_RepeatNotify.LeftHeader = "Notify";
            this.lifelengthViewer_RepeatNotify.Location = new System.Drawing.Point(90, 110);
            this.lifelengthViewer_RepeatNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer_RepeatNotify.Modified = false;
            this.lifelengthViewer_RepeatNotify.Name = "lifelengthViewer_RepeatNotify";
            this.lifelengthViewer_RepeatNotify.ReadOnly = false;
            this.lifelengthViewer_RepeatNotify.ShowCalendar = true;
            this.lifelengthViewer_RepeatNotify.ShowHeaders = false;
            this.lifelengthViewer_RepeatNotify.ShowLeftHeader = true;
            this.lifelengthViewer_RepeatNotify.ShowMinutes = true;
            this.lifelengthViewer_RepeatNotify.Size = new System.Drawing.Size(528, 41);
            this.lifelengthViewer_RepeatNotify.SystemCalculated = true;
            this.lifelengthViewer_RepeatNotify.TabIndex = 13;
            // 
            // radio_RepeatWhicheverFirst
            // 
            this.radio_RepeatWhicheverFirst.AutoSize = true;
            this.radio_RepeatWhicheverFirst.Checked = true;
            this.radio_RepeatWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radio_RepeatWhicheverFirst.Location = new System.Drawing.Point(80, 217);
            this.radio_RepeatWhicheverFirst.Margin = new System.Windows.Forms.Padding(4);
            this.radio_RepeatWhicheverFirst.Name = "radio_RepeatWhicheverFirst";
            this.radio_RepeatWhicheverFirst.Size = new System.Drawing.Size(180, 27);
            this.radio_RepeatWhicheverFirst.TabIndex = 23;
            this.radio_RepeatWhicheverFirst.TabStop = true;
            this.radio_RepeatWhicheverFirst.Text = "Whichever First";
            this.radio_RepeatWhicheverFirst.UseVisualStyleBackColor = true;
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.AutoSize = true;
            this.checkBoxRepeat.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.checkBoxRepeat.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxRepeat.Location = new System.Drawing.Point(19, 26);
            this.checkBoxRepeat.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(132, 27);
            this.checkBoxRepeat.TabIndex = 11;
            this.checkBoxRepeat.Text = "Repetative";
            this.checkBoxRepeat.UseVisualStyleBackColor = true;
            // 
            // lifelengthViewer_Repeat
            // 
            this.lifelengthViewer_Repeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_Repeat.AutoSize = true;
            this.lifelengthViewer_Repeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_Repeat.CalendarApplicable = false;
            this.lifelengthViewer_Repeat.Cycles = null;
            this.lifelengthViewer_Repeat.CyclesApplicable = false;
            this.lifelengthViewer_Repeat.Enabled = false;
            this.lifelengthViewer_Repeat.EnabledCalendar = true;
            this.lifelengthViewer_Repeat.EnabledCycle = true;
            this.lifelengthViewer_Repeat.EnabledHours = true;
            this.lifelengthViewer_Repeat.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_Repeat.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_Repeat.HeaderCalendar = "Calendar";
            this.lifelengthViewer_Repeat.HeaderCycles = "Cycles";
            this.lifelengthViewer_Repeat.HeaderHours = "Hours";
            this.lifelengthViewer_Repeat.HoursApplicable = false;
            this.lifelengthViewer_Repeat.LeftHeader = "Repeat Interval";
            this.lifelengthViewer_Repeat.Location = new System.Drawing.Point(21, 38);
            this.lifelengthViewer_Repeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer_Repeat.Modified = false;
            this.lifelengthViewer_Repeat.Name = "lifelengthViewer_Repeat";
            this.lifelengthViewer_Repeat.ReadOnly = false;
            this.lifelengthViewer_Repeat.ShowCalendar = true;
            this.lifelengthViewer_Repeat.ShowHeaders = true;
            this.lifelengthViewer_Repeat.ShowLeftHeader = true;
            this.lifelengthViewer_Repeat.ShowMinutes = true;
            this.lifelengthViewer_Repeat.Size = new System.Drawing.Size(597, 59);
            this.lifelengthViewer_Repeat.SystemCalculated = true;
            this.lifelengthViewer_Repeat.TabIndex = 12;
            // 
            // groupFirstPerformance
            // 
            this.groupFirstPerformance.AutoSize = true;
            this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverLast);
            this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverFirst);
            this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceEffDate);
            this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceNew);
            this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_FirstNotify);
            this.groupFirstPerformance.ForeColor = System.Drawing.Color.DimGray;
            this.groupFirstPerformance.Location = new System.Drawing.Point(0, 0);
            this.groupFirstPerformance.Margin = new System.Windows.Forms.Padding(4);
            this.groupFirstPerformance.Name = "groupFirstPerformance";
            this.groupFirstPerformance.Padding = new System.Windows.Forms.Padding(4);
            this.groupFirstPerformance.Size = new System.Drawing.Size(632, 276);
            this.groupFirstPerformance.TabIndex = 23;
            this.groupFirstPerformance.TabStop = false;
            this.groupFirstPerformance.Text = "FIRST PERFORMANCE";
            // 
            // radio_FirstWhicheverLast
            // 
            this.radio_FirstWhicheverLast.AutoSize = true;
            this.radio_FirstWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radio_FirstWhicheverLast.Location = new System.Drawing.Point(429, 217);
            this.radio_FirstWhicheverLast.Margin = new System.Windows.Forms.Padding(4);
            this.radio_FirstWhicheverLast.Name = "radio_FirstWhicheverLast";
            this.radio_FirstWhicheverLast.Size = new System.Drawing.Size(186, 27);
            this.radio_FirstWhicheverLast.TabIndex = 22;
            this.radio_FirstWhicheverLast.Text = "Whichever Later";
            this.radio_FirstWhicheverLast.UseVisualStyleBackColor = true;
            // 
            // radio_FirstWhicheverFirst
            // 
            this.radio_FirstWhicheverFirst.AutoSize = true;
            this.radio_FirstWhicheverFirst.Checked = true;
            this.radio_FirstWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radio_FirstWhicheverFirst.Location = new System.Drawing.Point(80, 217);
            this.radio_FirstWhicheverFirst.Margin = new System.Windows.Forms.Padding(4);
            this.radio_FirstWhicheverFirst.Name = "radio_FirstWhicheverFirst";
            this.radio_FirstWhicheverFirst.Size = new System.Drawing.Size(180, 27);
            this.radio_FirstWhicheverFirst.TabIndex = 21;
            this.radio_FirstWhicheverFirst.TabStop = true;
            this.radio_FirstWhicheverFirst.Text = "Whichever First";
            this.radio_FirstWhicheverFirst.UseVisualStyleBackColor = true;
            // 
            // lifelengthViewer_SinceEffDate
            // 
            this.lifelengthViewer_SinceEffDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_SinceEffDate.AutoSize = true;
            this.lifelengthViewer_SinceEffDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_SinceEffDate.CalendarApplicable = false;
            this.lifelengthViewer_SinceEffDate.Cycles = null;
            this.lifelengthViewer_SinceEffDate.CyclesApplicable = false;
            this.lifelengthViewer_SinceEffDate.EnabledCalendar = true;
            this.lifelengthViewer_SinceEffDate.EnabledCycle = true;
            this.lifelengthViewer_SinceEffDate.EnabledHours = true;
            this.lifelengthViewer_SinceEffDate.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_SinceEffDate.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_SinceEffDate.HeaderCalendar = "Calendar";
            this.lifelengthViewer_SinceEffDate.HeaderCycles = "Cycles";
            this.lifelengthViewer_SinceEffDate.HeaderHours = "Hours";
            this.lifelengthViewer_SinceEffDate.HoursApplicable = false;
            this.lifelengthViewer_SinceEffDate.LeftHeader = "Sine Eff. Date";
            this.lifelengthViewer_SinceEffDate.Location = new System.Drawing.Point(34, 110);
            this.lifelengthViewer_SinceEffDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer_SinceEffDate.Modified = false;
            this.lifelengthViewer_SinceEffDate.Name = "lifelengthViewer_SinceEffDate";
            this.lifelengthViewer_SinceEffDate.ReadOnly = false;
            this.lifelengthViewer_SinceEffDate.ShowCalendar = true;
            this.lifelengthViewer_SinceEffDate.ShowHeaders = false;
            this.lifelengthViewer_SinceEffDate.ShowLeftHeader = true;
            this.lifelengthViewer_SinceEffDate.ShowMinutes = true;
            this.lifelengthViewer_SinceEffDate.Size = new System.Drawing.Size(584, 41);
            this.lifelengthViewer_SinceEffDate.SystemCalculated = true;
            this.lifelengthViewer_SinceEffDate.TabIndex = 20;
            // 
            // lifelengthViewer_SinceNew
            // 
            this.lifelengthViewer_SinceNew.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_SinceNew.AutoSize = true;
            this.lifelengthViewer_SinceNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_SinceNew.CalendarApplicable = false;
            this.lifelengthViewer_SinceNew.Cycles = null;
            this.lifelengthViewer_SinceNew.CyclesApplicable = false;
            this.lifelengthViewer_SinceNew.EnabledCalendar = true;
            this.lifelengthViewer_SinceNew.EnabledCycle = true;
            this.lifelengthViewer_SinceNew.EnabledHours = true;
            this.lifelengthViewer_SinceNew.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_SinceNew.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_SinceNew.HeaderCalendar = "Calendar";
            this.lifelengthViewer_SinceNew.HeaderCycles = "Cycles";
            this.lifelengthViewer_SinceNew.HeaderHours = "Hours";
            this.lifelengthViewer_SinceNew.HoursApplicable = false;
            this.lifelengthViewer_SinceNew.LeftHeader = "Since New";
            this.lifelengthViewer_SinceNew.Location = new System.Drawing.Point(57, 38);
            this.lifelengthViewer_SinceNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer_SinceNew.Modified = false;
            this.lifelengthViewer_SinceNew.Name = "lifelengthViewer_SinceNew";
            this.lifelengthViewer_SinceNew.ReadOnly = false;
            this.lifelengthViewer_SinceNew.ShowCalendar = true;
            this.lifelengthViewer_SinceNew.ShowHeaders = true;
            this.lifelengthViewer_SinceNew.ShowLeftHeader = true;
            this.lifelengthViewer_SinceNew.ShowMinutes = true;
            this.lifelengthViewer_SinceNew.Size = new System.Drawing.Size(561, 59);
            this.lifelengthViewer_SinceNew.SystemCalculated = true;
            this.lifelengthViewer_SinceNew.TabIndex = 7;
            // 
            // lifelengthViewer_FirstNotify
            // 
            this.lifelengthViewer_FirstNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lifelengthViewer_FirstNotify.AutoSize = true;
            this.lifelengthViewer_FirstNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_FirstNotify.CalendarApplicable = false;
            this.lifelengthViewer_FirstNotify.Cycles = null;
            this.lifelengthViewer_FirstNotify.CyclesApplicable = false;
            this.lifelengthViewer_FirstNotify.EnabledCalendar = true;
            this.lifelengthViewer_FirstNotify.EnabledCycle = true;
            this.lifelengthViewer_FirstNotify.EnabledHours = true;
            this.lifelengthViewer_FirstNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
            this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
            this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
            this.lifelengthViewer_FirstNotify.HoursApplicable = false;
            this.lifelengthViewer_FirstNotify.LeftHeader = "Notify";
            this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(90, 160);
            this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer_FirstNotify.Modified = false;
            this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
            this.lifelengthViewer_FirstNotify.ReadOnly = false;
            this.lifelengthViewer_FirstNotify.ShowCalendar = true;
            this.lifelengthViewer_FirstNotify.ShowHeaders = false;
            this.lifelengthViewer_FirstNotify.ShowLeftHeader = true;
            this.lifelengthViewer_FirstNotify.ShowMinutes = true;
            this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(528, 41);
            this.lifelengthViewer_FirstNotify.SystemCalculated = true;
            this.lifelengthViewer_FirstNotify.TabIndex = 8;
            // 
            // DirectiveThresholdControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox_Repetative);
            this.Controls.Add(this.groupFirstPerformance);
            this.Name = "DirectiveThresholdControl";
            this.Size = new System.Drawing.Size(1322, 280);
            this.groupBox_Repetative.ResumeLayout(false);
            this.groupBox_Repetative.PerformLayout();
            this.groupFirstPerformance.ResumeLayout(false);
            this.groupFirstPerformance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Repetative;
        private System.Windows.Forms.RadioButton radio_RepeatWhicheverLast;
        private Auxiliary.LifelengthViewer lifelengthViewer_RepeatNotify;
        private System.Windows.Forms.RadioButton radio_RepeatWhicheverFirst;
        private System.Windows.Forms.CheckBox checkBoxRepeat;
        private Auxiliary.LifelengthViewer lifelengthViewer_Repeat;
        private System.Windows.Forms.GroupBox groupFirstPerformance;
        private System.Windows.Forms.RadioButton radio_FirstWhicheverLast;
        private System.Windows.Forms.RadioButton radio_FirstWhicheverFirst;
        private Auxiliary.LifelengthViewer lifelengthViewer_SinceEffDate;
        private Auxiliary.LifelengthViewer lifelengthViewer_SinceNew;
        private Auxiliary.LifelengthViewer lifelengthViewer_FirstNotify;
    }
}
