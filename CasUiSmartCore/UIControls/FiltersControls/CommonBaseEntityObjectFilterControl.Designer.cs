namespace CAS.UI.UIControls.FiltersControls
{
    partial class CommonBaseEntityObjectFilterControl
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
            this.SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxItems.CheckOnClick = true;
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Location = new System.Drawing.Point(0, 21);
            this.checkedListBoxItems.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(319, 79);
            this.checkedListBoxItems.TabIndex = 3;
            this.checkedListBoxItems.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxItemsSelectedIndexChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Checked = true;
            this.checkBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(2, 2);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSelectAll.TabIndex = 4;
            this.checkBoxSelectAll.Text = "Select all";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
            // 
            // CommonDictionaryFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.checkedListBoxItems);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(8, 16);
            this.Name = "CommonDictionaryFilterControl";
            this.Size = new System.Drawing.Size(319, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;


    }
}
