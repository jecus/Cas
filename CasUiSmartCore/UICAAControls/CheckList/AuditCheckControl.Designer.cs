using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class AuditCheckControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            labelType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(277, 2);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(53, 53);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(138, 3);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ReadOnly = true;
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(333, 58);
            this.metroTextBoxRemark.TabIndex = 25;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelType
            // 
            labelType.Font = new System.Drawing.Font("Verdana", 9F);
            labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            labelType.Location = new System.Drawing.Point(26, 3);
            labelType.Name = "labelType";
            labelType.Size = new System.Drawing.Size(106, 58);
            labelType.TabIndex = 26;
            labelType.Text = "Option:";
            // 
            // AuditCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(labelType);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Name = "AuditCheckControl";
            this.Size = new System.Drawing.Size(473, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        System.Windows.Forms.Label labelType;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
