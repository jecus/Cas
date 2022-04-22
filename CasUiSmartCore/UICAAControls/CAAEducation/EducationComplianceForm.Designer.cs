using System.ComponentModel;

namespace CAS.UI.UICAAControls.CAAEducation
{
    partial class EducationComplianceForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label13;
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.dateTimePickeValidTo = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(3, 91);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 14);
            label3.TabIndex = 333;
            label3.Text = "Remark:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Verdana", 9F);
            label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label13.Location = new System.Drawing.Point(3, 66);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(115, 14);
            label13.TabIndex = 337;
            label13.Text = "Last Compliance:";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(249, 197);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 330;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(330, 197);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 329;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(188, 2);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(91, 91);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(124, 92);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(282, 96);
            this.metroTextBoxRemark.TabIndex = 334;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateTimePickeValidTo
            // 
            this.dateTimePickeValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickeValidTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickeValidTo.Location = new System.Drawing.Point(124, 66);
            this.dateTimePickeValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickeValidTo.Name = "dateTimePickeValidTo";
            this.dateTimePickeValidTo.Size = new System.Drawing.Size(282, 20);
            this.dateTimePickeValidTo.TabIndex = 335;
            // 
            // EducationComplianceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 237);
            this.Controls.Add(label13);
            this.Controls.Add(this.dateTimePickeValidTo);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Controls.Add(label3);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.Name = "EducationComplianceForm";
            this.Resizable = false;
            this.Text = "Add New Compliance Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;
        private System.Windows.Forms.DateTimePicker dateTimePickeValidTo;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        #endregion
    }
}