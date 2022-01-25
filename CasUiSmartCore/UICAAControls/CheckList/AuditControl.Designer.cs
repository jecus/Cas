namespace CAS.UI.UICAAControls.CheckList
{
    partial class AuditControl
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
            System.Windows.Forms.Label label1;
            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxOptionNumber = new System.Windows.Forms.ComboBox();
            this.comboBoxOptionType = new System.Windows.Forms.ComboBox();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 14);
            label1.TabIndex = 19;
            label1.Text = "Option:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(220, 1);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(53, 53);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(210, 34);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(274, 55);
            this.metroTextBoxRemark.TabIndex = 25;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxOptionNumber
            // 
            this.comboBoxOptionNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxOptionNumber.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxOptionNumber.FormattingEnabled = true;
            this.comboBoxOptionNumber.Location = new System.Drawing.Point(63, 6);
            this.comboBoxOptionNumber.Name = "comboBoxOptionNumber";
            this.comboBoxOptionNumber.Size = new System.Drawing.Size(141, 22);
            this.comboBoxOptionNumber.TabIndex = 26;
            // 
            // comboBoxOptionType
            // 
            this.comboBoxOptionType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxOptionType.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxOptionType.FormattingEnabled = true;
            this.comboBoxOptionType.Location = new System.Drawing.Point(6, 34);
            this.comboBoxOptionType.Name = "comboBoxOptionType";
            this.comboBoxOptionType.Size = new System.Drawing.Size(198, 22);
            this.comboBoxOptionType.TabIndex = 27;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(411, 4);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(70, 23);
            this.linkLabelAddNew.TabIndex = 28;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Remove";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNew_LinkClicked);
            // 
            // AuditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelAddNew);
            this.Controls.Add(this.comboBoxOptionType);
            this.Controls.Add(this.comboBoxOptionNumber);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Controls.Add(label1);
            this.Name = "AuditControl";
            this.Size = new System.Drawing.Size(484, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;
        private System.Windows.Forms.ComboBox comboBoxOptionNumber;
        private System.Windows.Forms.ComboBox comboBoxOptionType;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
    }
}
