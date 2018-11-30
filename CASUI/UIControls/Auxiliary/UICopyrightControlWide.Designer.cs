using LTR.Core.ProjectTerms;
using LTR.Settings;

namespace LTR.UI.UIControls.Auxiliary
{
    partial class UICopyrightControlWide
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
            this.labelBuildVersion = new System.Windows.Forms.Label();
            this.labelProductname = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.pictureCopySeparator = new System.Windows.Forms.PictureBox();
            this.pictureAirplane = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopySeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAirplane)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBuildVersion
            // 
            this.labelBuildVersion.AutoSize = true;
            this.labelBuildVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelBuildVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBuildVersion.ForeColor = System.Drawing.Color.White;
            this.labelBuildVersion.Location = new System.Drawing.Point(51, 6);
            this.labelBuildVersion.Name = "labelBuildVersion";
            this.labelBuildVersion.Size = new System.Drawing.Size(122, 14);
            this.labelBuildVersion.TabIndex = 0;
            this.labelBuildVersion.Text = "LTR v2.0 build 200";
            // 
            // labelProductname
            // 
            this.labelProductname.AutoSize = true;
            this.labelProductname.BackColor = System.Drawing.Color.Transparent;
            this.labelProductname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProductname.ForeColor = System.Drawing.Color.White;
            this.labelProductname.Location = new System.Drawing.Point(51, 23);
            this.labelProductname.Name = "labelProductname";
            this.labelProductname.Size = new System.Drawing.Size(288, 18);
            this.labelProductname.TabIndex = 1;
            this.labelProductname.Text = new StaticProjectTermsProvider()["SystemName"].ToString();
            // 
            // labelCopyright
            // 
            this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCopyright.ForeColor = System.Drawing.Color.White;
            this.labelCopyright.Location = new System.Drawing.Point(457, 5);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(101, 36);
            this.labelCopyright.TabIndex = 2;
            this.labelCopyright.Text = "© 2006-2008\r\n Avalon Company\r\n All rights reserved";
            // 
            // pictureCopySeparator
            // 
            this.pictureCopySeparator.BackColor = System.Drawing.Color.Transparent;
            this.pictureCopySeparator.BackgroundImage = global::LTR.UI.Properties.Resources.CopyrightSeparatorLine;
            this.pictureCopySeparator.Location = new System.Drawing.Point(0, 0);
            this.pictureCopySeparator.Margin = new System.Windows.Forms.Padding(0);
            this.pictureCopySeparator.Name = "pictureCopySeparator";
            this.pictureCopySeparator.Size = new System.Drawing.Size(3, 48);
            this.pictureCopySeparator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureCopySeparator.TabIndex = 3;
            this.pictureCopySeparator.TabStop = false;
            // 
            // pictureAirplane
            // 
            this.pictureAirplane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureAirplane.BackColor = System.Drawing.Color.Transparent;
            this.pictureAirplane.BackgroundImage = global::LTR.UI.Properties.Resources.CopyrightAirPlane;
            this.pictureAirplane.Location = new System.Drawing.Point(404, 4);
            this.pictureAirplane.Name = "pictureAirplane";
            this.pictureAirplane.Size = new System.Drawing.Size(38, 42);
            this.pictureAirplane.TabIndex = 4;
            this.pictureAirplane.TabStop = false;
            // 
            // UICopyrightControlWide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::LTR.UI.Properties.Resources.CopyrightBar;
            this.Controls.Add(this.pictureAirplane);
            this.Controls.Add(this.pictureCopySeparator);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelProductname);
            this.Controls.Add(this.labelBuildVersion);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Name = "UICopyrightControlWide";
            this.Size = new System.Drawing.Size(581, 48);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopySeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAirplane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBuildVersion;
        private System.Windows.Forms.Label labelProductname;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.PictureBox pictureCopySeparator;
        private System.Windows.Forms.PictureBox pictureAirplane;
    }
}
