using System.ComponentModel;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    partial class ShowMoveToForm
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
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.radChat2 = new Telerik.WinControls.UI.RadChat();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radChat2)).BeginInit();
            this.SuspendLayout();
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
            // radChat2
            // 
            this.radChat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChat2.Location = new System.Drawing.Point(20, 60);
            this.radChat2.Name = "radChat2";
            this.radChat2.Size = new System.Drawing.Size(580, 672);
            this.radChat2.TabIndex = 352;
            this.radChat2.Text = "radChat2";
            this.radChat2.ThemeName = "TelerikMetroBlue";
            this.radChat2.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabel1.Location = new System.Drawing.Point(538, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabel1.Size = new System.Drawing.Size(62, 17);
            this.linkLabel1.TabIndex = 353;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CheckMoveToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 752);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.radChat2);
            this.Controls.Add(this.fileControl);
            this.Name = "CheckMoveToForm";
            this.Resizable = false;
            this.Text = "Transfer Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckMoveToForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.radChat2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.LinkLabel linkLabel1;

        private Telerik.WinControls.UI.RadChat radChat2;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        public CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;

        #endregion
    }
}