namespace CAS.UI.UIControls.FiltersControls
{
    partial class CommonBoolFilterControl
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
			this.checkBoxValue = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBoxValue
			// 
			this.checkBoxValue.AutoSize = true;
			this.checkBoxValue.Checked = true;
			this.checkBoxValue.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxValue.Location = new System.Drawing.Point(3, 2);
			this.checkBoxValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxValue.Name = "checkBoxValue";
			this.checkBoxValue.Size = new System.Drawing.Size(18, 17);
			this.checkBoxValue.TabIndex = 4;
			this.checkBoxValue.ThreeState = true;
			this.checkBoxValue.UseVisualStyleBackColor = true;
			// 
			// CommonBoolFilterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxValue);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(8, 16);
			this.Name = "CommonBoolFilterControl";
			this.Size = new System.Drawing.Size(319, 26);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxValue;


    }
}
