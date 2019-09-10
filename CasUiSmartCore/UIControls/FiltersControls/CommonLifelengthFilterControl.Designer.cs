using CAS.UI.Helpers;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class CommonLifelengthFilterControl
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
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.lifelengthViewerLifelength = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.radio_ByInterval = new System.Windows.Forms.RadioButton();
            this.radio_ByLifelength = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxItems.CheckOnClick = true;
            this.checkedListBoxItems.Enabled = false;
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Location = new System.Drawing.Point(0, 63);
            this.checkedListBoxItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(442, 124);
            this.checkedListBoxItems.TabIndex = 5;
            this.checkedListBoxItems.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxItemsSelectedIndexChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Checked = true;
            this.checkBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSelectAll.Enabled = false;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(22, 41);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSelectAll.TabIndex = 4;
            this.checkBoxSelectAll.Text = "Select all";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Location = new System.Drawing.Point(22, 9);
            this.comboBoxFilterType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(66, 21);
            this.comboBoxFilterType.TabIndex = 1;
            this.comboBoxFilterType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// lifelengthViewerLifelength
			// 
			this.lifelengthViewerLifelength.AutoSize = true;
            this.lifelengthViewerLifelength.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerLifelength.CalendarApplicable = false;
            this.lifelengthViewerLifelength.CyclesApplicable = false;
            this.lifelengthViewerLifelength.EnabledCalendar = true;
            this.lifelengthViewerLifelength.EnabledCycle = true;
            this.lifelengthViewerLifelength.EnabledHours = true;
            this.lifelengthViewerLifelength.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerLifelength.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerLifelength.HeaderCalendar = "Calendar";
            this.lifelengthViewerLifelength.HeaderCycles = "Cycles";
            this.lifelengthViewerLifelength.HeaderHours = "Hours";
            this.lifelengthViewerLifelength.HoursApplicable = false;
            this.lifelengthViewerLifelength.LeftHeader = "";
            this.lifelengthViewerLifelength.Location = new System.Drawing.Point(92, 2);
            this.lifelengthViewerLifelength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lifelengthViewerLifelength.Modified = false;
            this.lifelengthViewerLifelength.Name = "lifelengthViewerLifelength";
            this.lifelengthViewerLifelength.ReadOnly = false;
            this.lifelengthViewerLifelength.ShowCalendar = true;
            this.lifelengthViewerLifelength.ShowHeaders = false;
            this.lifelengthViewerLifelength.ShowLeftHeader = false;
            this.lifelengthViewerLifelength.ShowMinutes = true;
            this.lifelengthViewerLifelength.Size = new System.Drawing.Size(354, 35);
            this.lifelengthViewerLifelength.SystemCalculated = true;
            this.lifelengthViewerLifelength.TabIndex = 2;
            // 
            // radio_ByInterval
            // 
            this.radio_ByInterval.AutoSize = true;
            this.radio_ByInterval.Location = new System.Drawing.Point(4, 41);
            this.radio_ByInterval.Name = "radio_ByInterval";
            this.radio_ByInterval.Size = new System.Drawing.Size(14, 13);
            this.radio_ByInterval.TabIndex = 3;
            this.radio_ByInterval.UseVisualStyleBackColor = true;
            // 
            // radio_ByLifelength
            // 
            this.radio_ByLifelength.AutoSize = true;
            this.radio_ByLifelength.Checked = true;
            this.radio_ByLifelength.Location = new System.Drawing.Point(4, 11);
            this.radio_ByLifelength.Name = "radio_ByLifelength";
            this.radio_ByLifelength.Size = new System.Drawing.Size(14, 13);
            this.radio_ByLifelength.TabIndex = 0;
            this.radio_ByLifelength.TabStop = true;
            this.radio_ByLifelength.UseVisualStyleBackColor = true;
            this.radio_ByLifelength.CheckedChanged += new System.EventHandler(this.RadioByLifelengthCheckedChanged);
            // 
            // CommonLifelengthFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radio_ByInterval);
            this.Controls.Add(this.radio_ByLifelength);
            this.Controls.Add(this.lifelengthViewerLifelength);
            this.Controls.Add(this.comboBoxFilterType);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.checkedListBoxItems);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(8, 16);
            this.Name = "CommonLifelengthFilterControl";
            this.Size = new System.Drawing.Size(444, 197);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
        private Auxiliary.LifelengthViewer lifelengthViewerLifelength;
        private System.Windows.Forms.RadioButton radio_ByInterval;
        private System.Windows.Forms.RadioButton radio_ByLifelength;


    }
}
