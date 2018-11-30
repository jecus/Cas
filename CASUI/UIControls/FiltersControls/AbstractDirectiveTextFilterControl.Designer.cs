using System.Windows.Forms;

namespace CAS.UI.UIControls.FiltersControls
{
    abstract partial class AbstractDirectiveTextFilterControl
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
            textBoxSerialMask = new TextBox();
            checkBoxSerialFilterAppliance = new CheckBox();
            SuspendLayout();
            // 
            // textBoxSerialMask
            // 
            textBoxSerialMask.Location = new System.Drawing.Point(138, 4);
            textBoxSerialMask.MaxLength = 30;
            textBoxSerialMask.Name = "textBoxSerialMask";
            textBoxSerialMask.Size = new System.Drawing.Size(241, 23);
            textBoxSerialMask.TabIndex = 19;
            textBoxSerialMask.Text = "*";
            // 
            // checkBoxSerialFilterAppliance
            // 
            checkBoxSerialFilterAppliance.AutoSize = true;
            checkBoxSerialFilterAppliance.Checked = true;
            checkBoxSerialFilterAppliance.CheckState = CheckState.Checked;
            checkBoxSerialFilterAppliance.Location = new System.Drawing.Point(0, 6);
            checkBoxSerialFilterAppliance.Name = "checkBoxSerialFilterAppliance";
            checkBoxSerialFilterAppliance.Size = new System.Drawing.Size(82, 20);
            checkBoxSerialFilterAppliance.TabIndex = 18;
            checkBoxSerialFilterAppliance.Text = "Title filter";
            checkBoxSerialFilterAppliance.UseVisualStyleBackColor = true;
            // 
            // AbstractDirectiveTextFilterControl
            // 
            AutoSize = true;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(textBoxSerialMask);
            Controls.Add(checkBoxSerialFilterAppliance);
            Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            Name = "AbstractDirectiveTextFilterControl";
            Size = new System.Drawing.Size(414, 36);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSerialMask;
        private CheckBox checkBoxSerialFilterAppliance;
    }
}
