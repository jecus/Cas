using CAS.UI.Helpers;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class DictionaryComboBox
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

            if (disposing)
            {
                comboBoxReason.SelectedIndexChanged -= ComboBoxReasonSelectedIndexChanged;
                comboBoxReason.TextUpdate -= ComboBoxReasonTextUpdate;

                this.SelectedIndexChanged = null;
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxReason = new System.Windows.Forms.ComboBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxReason
            // 
            this.comboBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReason.FormattingEnabled = true;
            this.comboBoxReason.Location = new System.Drawing.Point(0, 0);
            this.comboBoxReason.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxReason.Name = "comboBoxReason";
            this.comboBoxReason.Size = new System.Drawing.Size(146, 21);
            this.comboBoxReason.TabIndex = 1;
            this.comboBoxReason.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReasonSelectedIndexChanged);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEdit.Location = new System.Drawing.Point(146, 0);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(24, 20);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "...";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // DictionaryComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.comboBoxReason);
            this.Name = "DictionaryComboBox";
            this.Size = new System.Drawing.Size(170, 20);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxReason;
        private System.Windows.Forms.Button buttonEdit;
    }
}
