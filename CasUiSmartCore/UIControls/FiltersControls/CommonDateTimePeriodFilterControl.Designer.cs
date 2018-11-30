namespace CAS.UI.UIControls.FiltersControls
{
    partial class CommonDateTimePeriodFilterControl
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
			this.labelFrom = new System.Windows.Forms.Label();
			this.labelTo = new System.Windows.Forms.Label();
			this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerTimeFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerTimeTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// labelFrom
			// 
			this.labelFrom.AutoSize = true;
			this.labelFrom.Location = new System.Drawing.Point(0, 0);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(33, 13);
			this.labelFrom.TabIndex = 5;
			this.labelFrom.Text = "From:";
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.Location = new System.Drawing.Point(224, 0);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(23, 13);
			this.labelTo.TabIndex = 6;
			this.labelTo.Text = "To:";
			// 
			// dateTimePickerDateFrom
			// 
			this.dateTimePickerDateFrom.Location = new System.Drawing.Point(39, 0);
			this.dateTimePickerDateFrom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
			this.dateTimePickerDateFrom.Size = new System.Drawing.Size(119, 20);
			this.dateTimePickerDateFrom.TabIndex = 1;
			this.dateTimePickerDateFrom.Tag = "";
			// 
			// dateTimePickerTimeFrom
			// 
			this.dateTimePickerTimeFrom.CustomFormat = "HH:mm";
			this.dateTimePickerTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTimeFrom.Location = new System.Drawing.Point(162, 0);
			this.dateTimePickerTimeFrom.Name = "dateTimePickerTimeFrom";
			this.dateTimePickerTimeFrom.ShowUpDown = true;
			this.dateTimePickerTimeFrom.Size = new System.Drawing.Size(53, 20);
			this.dateTimePickerTimeFrom.TabIndex = 2;
			this.dateTimePickerTimeFrom.Tag = "";
			// 
			// dateTimePickerTimeTo
			// 
			this.dateTimePickerTimeTo.CustomFormat = "HH:mm";
			this.dateTimePickerTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTimeTo.Location = new System.Drawing.Point(379, 0);
			this.dateTimePickerTimeTo.Name = "dateTimePickerTimeTo";
			this.dateTimePickerTimeTo.ShowUpDown = true;
			this.dateTimePickerTimeTo.Size = new System.Drawing.Size(55, 20);
			this.dateTimePickerTimeTo.TabIndex = 4;
			this.dateTimePickerTimeTo.Tag = "";
			// 
			// dateTimePickerDateTo
			// 
			this.dateTimePickerDateTo.Location = new System.Drawing.Point(247, 0);
			this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
			this.dateTimePickerDateTo.Size = new System.Drawing.Size(126, 20);
			this.dateTimePickerDateTo.TabIndex = 3;
			this.dateTimePickerDateTo.Tag = "";
			// 
			// CommonDateTimePeriodFilterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.dateTimePickerDateTo);
			this.Controls.Add(this.dateTimePickerTimeTo);
			this.Controls.Add(this.dateTimePickerTimeFrom);
			this.Controls.Add(this.dateTimePickerDateFrom);
			this.Controls.Add(this.labelTo);
			this.Controls.Add(this.labelFrom);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(8, 16);
			this.Name = "CommonDateTimePeriodFilterControl";
			this.Size = new System.Drawing.Size(437, 23);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
    }
}
