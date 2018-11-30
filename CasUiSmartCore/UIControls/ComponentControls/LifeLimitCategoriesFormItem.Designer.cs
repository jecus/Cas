namespace CAS.UI.UIControls.DetailsControls
{
    partial class LifeLimitCategoriesFormItem
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
            this.textBoxCategoryType = new System.Windows.Forms.TextBox();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.dictionaryComboBoxAircraftModel = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.SuspendLayout();
            // 
            // textBoxCategoryType
            // 
            this.textBoxCategoryType.BackColor = System.Drawing.Color.White;
            this.textBoxCategoryType.Enabled = false;
            this.textBoxCategoryType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCategoryType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCategoryType.Location = new System.Drawing.Point(3, 3);
            this.textBoxCategoryType.MaxLength = 128;
            this.textBoxCategoryType.Name = "textBoxCategoryType";
            this.textBoxCategoryType.Size = new System.Drawing.Size(150, 22);
            this.textBoxCategoryType.TabIndex = 43;
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.BackColor = System.Drawing.Color.White;
            this.textBoxCategoryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCategoryName.Location = new System.Drawing.Point(159, 3);
            this.textBoxCategoryName.MaxLength = 128;
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(150, 22);
            this.textBoxCategoryName.TabIndex = 44;
            // 
            // dictionaryComboBoxAircraftModel
            // 
            this.dictionaryComboBoxAircraftModel.Displayer = null;
            this.dictionaryComboBoxAircraftModel.DisplayerText = null;
            this.dictionaryComboBoxAircraftModel.Enabled = false;
            this.dictionaryComboBoxAircraftModel.Entity = null;
            this.dictionaryComboBoxAircraftModel.Location = new System.Drawing.Point(314, 3);
            this.dictionaryComboBoxAircraftModel.Name = "dictionaryComboBoxAircraftModel";
            this.dictionaryComboBoxAircraftModel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxAircraftModel.Size = new System.Drawing.Size(153, 23);
            this.dictionaryComboBoxAircraftModel.TabIndex = 47;
            // 
            // LifeLimitCategoriesFormItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dictionaryComboBoxAircraftModel);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.textBoxCategoryType);
            this.Name = "LifeLimitCategoriesFormItem";
            this.Size = new System.Drawing.Size(470, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCategoryType;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private Auxiliary.LookupCombobox dictionaryComboBoxAircraftModel;
    }
}
