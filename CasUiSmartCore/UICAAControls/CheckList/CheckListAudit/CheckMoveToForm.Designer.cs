using System.ComponentModel;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    partial class CheckMoveToForm
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
            MetroFramework.Controls.MetroLabel labelValidFrom;
            MetroFramework.Controls.MetroLabel metroLabel2;
            this.dateTimePickerIssueCreateDate = new System.Windows.Forms.DateTimePicker();
            this.metroTextBoxAuditNumber = new MetroFramework.Controls.MetroTextBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.attachedFileControl1 = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            labelValidFrom = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // labelValidFrom
            // 
            labelValidFrom.AutoSize = true;
            labelValidFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            labelValidFrom.Location = new System.Drawing.Point(13, 66);
            labelValidFrom.Name = "labelValidFrom";
            labelValidFrom.Size = new System.Drawing.Size(82, 19);
            labelValidFrom.TabIndex = 348;
            labelValidFrom.Text = "Create Date:";
            labelValidFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel2.Location = new System.Drawing.Point(12, 92);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new System.Drawing.Size(57, 19);
            metroLabel2.TabIndex = 345;
            metroLabel2.Text = "Remark:";
            metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerIssueCreateDate
            // 
            this.dateTimePickerIssueCreateDate.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickerIssueCreateDate.Enabled = false;
            this.dateTimePickerIssueCreateDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerIssueCreateDate.Location = new System.Drawing.Point(112, 64);
            this.dateTimePickerIssueCreateDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerIssueCreateDate.Name = "dateTimePickerIssueCreateDate";
            this.dateTimePickerIssueCreateDate.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerIssueCreateDate.TabIndex = 347;
            // 
            // metroTextBoxAuditNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxAuditNumber.CustomButton.Image = null;
            this.metroTextBoxAuditNumber.CustomButton.Location = new System.Drawing.Point(151, 1);
            this.metroTextBoxAuditNumber.CustomButton.Name = "";
            this.metroTextBoxAuditNumber.CustomButton.Size = new System.Drawing.Size(99, 99);
            this.metroTextBoxAuditNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxAuditNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxAuditNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxAuditNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxAuditNumber.CustomButton.Visible = false;
            this.metroTextBoxAuditNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxAuditNumber.Lines = new string[0];
            this.metroTextBoxAuditNumber.Location = new System.Drawing.Point(111, 92);
            this.metroTextBoxAuditNumber.MaxLength = 32767;
            this.metroTextBoxAuditNumber.Multiline = true;
            this.metroTextBoxAuditNumber.Name = "metroTextBoxAuditNumber";
            this.metroTextBoxAuditNumber.PasswordChar = '\0';
            this.metroTextBoxAuditNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxAuditNumber.SelectedText = "";
            this.metroTextBoxAuditNumber.SelectionLength = 0;
            this.metroTextBoxAuditNumber.SelectionStart = 0;
            this.metroTextBoxAuditNumber.ShortcutsEnabled = true;
            this.metroTextBoxAuditNumber.Size = new System.Drawing.Size(251, 101);
            this.metroTextBoxAuditNumber.TabIndex = 346;
            this.metroTextBoxAuditNumber.UseSelectable = true;
            this.metroTextBoxAuditNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxAuditNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // fileControl
            // 
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = null;
            this.fileControl.IconNotEnabled = null;
            this.fileControl.Location = new System.Drawing.Point(-938, -8);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "fileControl";
            this.fileControl.ShowLinkLabelBrowse = true;
            this.fileControl.ShowLinkLabelRemove = false;
            this.fileControl.Size = new System.Drawing.Size(350, 100);
            this.fileControl.TabIndex = 351;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(210, 302);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 350;
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
            this.buttonCancel.Location = new System.Drawing.Point(291, 302);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 349;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // attachedFileControl1
            // 
            this.attachedFileControl1.AutoSize = true;
            this.attachedFileControl1.BackColor = System.Drawing.Color.Transparent;
            this.attachedFileControl1.Description1 = null;
            this.attachedFileControl1.Description2 = null;
            this.attachedFileControl1.Filter = "PDF file (*.pdf)|*.pdf";
            this.attachedFileControl1.Icon = null;
            this.attachedFileControl1.IconNotEnabled = null;
            this.attachedFileControl1.Location = new System.Drawing.Point(12, 198);
            this.attachedFileControl1.MaximumSize = new System.Drawing.Size(350, 100);
            this.attachedFileControl1.MinimumSize = new System.Drawing.Size(350, 50);
            this.attachedFileControl1.Name = "attachedFileControl1";
            this.attachedFileControl1.ShowLinkLabelBrowse = true;
            this.attachedFileControl1.ShowLinkLabelRemove = false;
            this.attachedFileControl1.Size = new System.Drawing.Size(350, 100);
            this.attachedFileControl1.TabIndex = 352;
            // 
            // CheckMoveToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 340);
            this.Controls.Add(this.attachedFileControl1);
            this.Controls.Add(this.fileControl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(labelValidFrom);
            this.Controls.Add(this.dateTimePickerIssueCreateDate);
            this.Controls.Add(this.metroTextBoxAuditNumber);
            this.Controls.Add(metroLabel2);
            this.Name = "CheckMoveToForm";
            this.Resizable = false;
            this.Text = "CheckMoveToForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public CAS.UI.UIControls.Auxiliary.AttachedFileControl attachedFileControl1;

        public CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        private System.Windows.Forms.DateTimePicker dateTimePickerIssueCreateDate;
        private MetroFramework.Controls.MetroTextBox metroTextBoxAuditNumber;

        #endregion
    }
}