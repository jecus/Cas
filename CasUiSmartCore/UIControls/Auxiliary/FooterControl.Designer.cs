using System.Drawing;
using System.Windows.Forms;
using AvControls.AvButtonT;
using CASTerms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class FooterControl
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureSeparatorLine = new System.Windows.Forms.PictureBox();
            this.pictureSeparatorEnd = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLogoutButtons = new System.Windows.Forms.Panel();
            this.avButtonLogout = new AvControls.AvButtonT.AvButtonT();
            this.avButtonExit = new AvControls.AvButtonT.AvButtonT();
            this.panelCopyRight = new System.Windows.Forms.Panel();
            this.pictureAirplane = new System.Windows.Forms.PictureBox();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.panelProductName = new System.Windows.Forms.Panel();
            this.labelProductname = new System.Windows.Forms.Label();
            this.labelBuildVersion = new System.Windows.Forms.Label();
            this.pictureCopySeparator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorEnd)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelLogoutButtons.SuspendLayout();
            this.panelCopyRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAirplane)).BeginInit();
            this.panelProductName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopySeparator)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.ForeColor = System.Drawing.Color.Gray;
            this.labelUsername.Location = new System.Drawing.Point(15, 12);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(233, 36);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Not connected";
            // 
            // pictureSeparatorLine
            // 
            this.pictureSeparatorLine.BackColor = System.Drawing.Color.Transparent;
            this.pictureSeparatorLine.Location = new System.Drawing.Point(189, 2);
            this.pictureSeparatorLine.Margin = new System.Windows.Forms.Padding(0);
            this.pictureSeparatorLine.Name = "pictureSeparatorLine";
            this.pictureSeparatorLine.Size = new System.Drawing.Size(2, 37);
            this.pictureSeparatorLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSeparatorLine.TabIndex = 6;
            this.pictureSeparatorLine.TabStop = false;
            // 
            // pictureSeparatorEnd
            // 
            this.pictureSeparatorEnd.BackColor = System.Drawing.Color.Transparent;
            this.pictureSeparatorEnd.Image = global::CAS.UI.Properties.Resources.LogoutSeparatorLine;
            this.pictureSeparatorEnd.Location = new System.Drawing.Point(286, 0);
            this.pictureSeparatorEnd.Margin = new System.Windows.Forms.Padding(0);
            this.pictureSeparatorEnd.Name = "pictureSeparatorEnd";
            this.pictureSeparatorEnd.Size = new System.Drawing.Size(1, 43);
            this.pictureSeparatorEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSeparatorEnd.TabIndex = 7;
            this.pictureSeparatorEnd.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::CAS.UI.Properties.Resources.LogoutBar;
            this.splitContainer1.Panel1.Controls.Add(this.panelLogoutButtons);
            this.splitContainer1.Panel1.Controls.Add(this.labelUsername);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::CAS.UI.Properties.Resources.CopyrightBar;
            this.splitContainer1.Panel2.Controls.Add(this.panelCopyRight);
            this.splitContainer1.Panel2.Controls.Add(this.panelProductName);
            this.splitContainer1.Panel2.Controls.Add(this.pictureCopySeparator);
            this.splitContainer1.Size = new System.Drawing.Size(1540, 60);
            this.splitContainer1.SplitterDistance = 548;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // panelLogoutButtons
            // 
            this.panelLogoutButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLogoutButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelLogoutButtons.Controls.Add(this.avButtonLogout);
            this.panelLogoutButtons.Controls.Add(this.avButtonExit);
            this.panelLogoutButtons.Controls.Add(this.pictureSeparatorLine);
            this.panelLogoutButtons.Controls.Add(this.pictureSeparatorEnd);
            this.panelLogoutButtons.Location = new System.Drawing.Point(260, 0);
            this.panelLogoutButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogoutButtons.Name = "panelLogoutButtons";
            this.panelLogoutButtons.Size = new System.Drawing.Size(290, 60);
            this.panelLogoutButtons.TabIndex = 8;
            // 
            // avButtonLogout
            // 
            this.avButtonLogout.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonLogout.ActiveBackgroundImage = null;
            this.avButtonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonLogout.FontMain = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avButtonLogout.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.avButtonLogout.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.avButtonLogout.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.avButtonLogout.Icon = global::CAS.UI.Properties.Resources.LogoutIcon;
            this.avButtonLogout.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonLogout.IconNotEnabled = global::CAS.UI.Properties.Resources.LogoutIcon_gray;
            this.avButtonLogout.Location = new System.Drawing.Point(0, 0);
            this.avButtonLogout.Margin = new System.Windows.Forms.Padding(5);
            this.avButtonLogout.Name = "avButtonLogout";
            this.avButtonLogout.NormalBackgroundImage = null;
            this.avButtonLogout.PaddingMain = new System.Windows.Forms.Padding(2);
            this.avButtonLogout.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonLogout.Size = new System.Drawing.Size(189, 60);
            this.avButtonLogout.TabIndex = 3;
            this.avButtonLogout.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonLogout.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonLogout.TextMain = "Log out";
            this.avButtonLogout.TextSecondary = "";
            this.avButtonLogout.LocationChanged += new System.EventHandler(this.AvButtonLogoutLocationChanged);
            this.avButtonLogout.Click += new System.EventHandler(this.AvButtonLogoutClick);
            // 
            // avButtonExit
            // 
            this.avButtonExit.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonExit.ActiveBackgroundImage = null;
            this.avButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonExit.FontMain = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avButtonExit.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.avButtonExit.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.avButtonExit.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.avButtonExit.Icon = null;
            this.avButtonExit.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonExit.IconNotEnabled = null;
            this.avButtonExit.Location = new System.Drawing.Point(191, 0);
            this.avButtonExit.Margin = new System.Windows.Forms.Padding(5);
            this.avButtonExit.Name = "avButtonExit";
            this.avButtonExit.NormalBackgroundImage = null;
            this.avButtonExit.PaddingMain = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.avButtonExit.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonExit.Size = new System.Drawing.Size(94, 60);
            this.avButtonExit.TabIndex = 4;
            this.avButtonExit.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonExit.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonExit.TextMain = "Exit";
            this.avButtonExit.TextSecondary = "";
            this.avButtonExit.Click += new System.EventHandler(this.AvButtonExitClick);
            // 
            // panelCopyRight
            // 
            this.panelCopyRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCopyRight.BackColor = System.Drawing.Color.Transparent;
            this.panelCopyRight.Controls.Add(this.pictureAirplane);
            this.panelCopyRight.Controls.Add(this.labelCopyright);
            this.panelCopyRight.Location = new System.Drawing.Point(746, 0);
            this.panelCopyRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelCopyRight.Name = "panelCopyRight";
            this.panelCopyRight.Size = new System.Drawing.Size(245, 60);
            this.panelCopyRight.TabIndex = 6;
            // 
            // pictureAirplane
            // 
            this.pictureAirplane.BackColor = System.Drawing.Color.Transparent;
            this.pictureAirplane.BackgroundImage = global::CAS.UI.Properties.Resources.CopyrightAirPlane;
            this.pictureAirplane.Location = new System.Drawing.Point(4, 5);
            this.pictureAirplane.Margin = new System.Windows.Forms.Padding(4);
            this.pictureAirplane.Name = "pictureAirplane";
            this.pictureAirplane.Size = new System.Drawing.Size(48, 52);
            this.pictureAirplane.TabIndex = 4;
            this.pictureAirplane.TabStop = false;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCopyright.ForeColor = System.Drawing.Color.White;
            this.labelCopyright.Location = new System.Drawing.Point(76, 6);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(0, 14);
            this.labelCopyright.TabIndex = 2;
            // 
            // panelProductName
            // 
            this.panelProductName.BackColor = System.Drawing.Color.Transparent;
            this.panelProductName.Controls.Add(this.labelProductname);
            this.panelProductName.Controls.Add(this.labelBuildVersion);
            this.panelProductName.Location = new System.Drawing.Point(64, 0);
            this.panelProductName.Margin = new System.Windows.Forms.Padding(4);
            this.panelProductName.Name = "panelProductName";
            this.panelProductName.Size = new System.Drawing.Size(394, 60);
            this.panelProductName.TabIndex = 5;
            // 
            // labelProductname
            // 
            this.labelProductname.AutoSize = true;
            this.labelProductname.BackColor = System.Drawing.Color.Transparent;
            this.labelProductname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProductname.ForeColor = System.Drawing.Color.White;
            this.labelProductname.Location = new System.Drawing.Point(4, 29);
            this.labelProductname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProductname.Name = "labelProductname";
            this.labelProductname.Size = new System.Drawing.Size(0, 25);
            this.labelProductname.TabIndex = 1;
            // 
            // labelBuildVersion
            // 
            this.labelBuildVersion.AutoSize = true;
            this.labelBuildVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelBuildVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBuildVersion.ForeColor = System.Drawing.Color.White;
            this.labelBuildVersion.Location = new System.Drawing.Point(4, 8);
            this.labelBuildVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBuildVersion.Name = "labelBuildVersion";
            this.labelBuildVersion.Size = new System.Drawing.Size(0, 18);
            this.labelBuildVersion.TabIndex = 0;
            // 
            // pictureCopySeparator
            // 
            this.pictureCopySeparator.BackColor = System.Drawing.Color.Transparent;
            this.pictureCopySeparator.BackgroundImage = global::CAS.UI.Properties.Resources.CopyrightSeparatorLine;
            this.pictureCopySeparator.Location = new System.Drawing.Point(0, 0);
            this.pictureCopySeparator.Margin = new System.Windows.Forms.Padding(0);
            this.pictureCopySeparator.Name = "pictureCopySeparator";
            this.pictureCopySeparator.Size = new System.Drawing.Size(3, 48);
            this.pictureCopySeparator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureCopySeparator.TabIndex = 3;
            this.pictureCopySeparator.TabStop = false;
            // 
            // FooterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(1250, 60);
            this.Name = "FooterControl";
            this.Size = new System.Drawing.Size(1540, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorEnd)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panelLogoutButtons.ResumeLayout(false);
            this.panelLogoutButtons.PerformLayout();
            this.panelCopyRight.ResumeLayout(false);
            this.panelCopyRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAirplane)).EndInit();
            this.panelProductName.ResumeLayout(false);
            this.panelProductName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopySeparator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Label labelUsername;
        private AvButtonT avButtonExit;
        private PictureBox pictureSeparatorLine;
        private AvButtonT avButtonLogout;
        private PictureBox pictureSeparatorEnd;
        private Label labelBuildVersion;
        private Label labelProductname;
        private Label labelCopyright;
        private PictureBox pictureCopySeparator;
        private PictureBox pictureAirplane;
        private Panel panelLogoutButtons;
        private Panel panelProductName;
        private Panel panelCopyRight;

    }
}
