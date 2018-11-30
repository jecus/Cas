using System;
using Controls.AvButton;
using LTR.UI.Management.Dispatchering;

namespace LTR.UI.UIControls.Auxiliary
{
    partial class UILogoutControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UILogoutControl));
            this.labelUsername = new System.Windows.Forms.Label();
            this.pictureSeparatorLine = new System.Windows.Forms.PictureBox();
            this.avButtonExit = new Controls.AvButton.AvButton();
            this.pictureSeparatorEnd = new System.Windows.Forms.PictureBox();
            this.avButtonLogout = new AvButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.ForeColor = System.Drawing.Color.Gray;
            this.labelUsername.Location = new System.Drawing.Point(12, 10);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(258, 29);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Aleksey Baryshnikov";
            // 
            // pictureSeparatorLine
            // 
            this.pictureSeparatorLine.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureSeparatorLine.BackColor = System.Drawing.Color.Transparent;
            this.pictureSeparatorLine.BackgroundImage = global::LTR.UI.Properties.Resources.SeparatorLine;
            this.pictureSeparatorLine.Image = global::LTR.UI.Properties.Resources.SeparatorLine;
            this.pictureSeparatorLine.Location = new System.Drawing.Point(443, 6);
            this.pictureSeparatorLine.Margin = new System.Windows.Forms.Padding(0);
            this.pictureSeparatorLine.Name = "pictureSeparatorLine";
            this.pictureSeparatorLine.Size = new System.Drawing.Size(2, 37);
            this.pictureSeparatorLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSeparatorLine.TabIndex = 6;
            this.pictureSeparatorLine.TabStop = false;
            // 
            // avButtonExit
            // 
            this.avButtonExit.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.avButtonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonExit.ExtendedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.avButtonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.avButtonExit.FlatAppearance.BorderSize = 0;
            this.avButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avButtonExit.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avButtonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.avButtonExit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.avButtonExit.Hoverable = true;
            this.avButtonExit.Icon = null;
            this.avButtonExit.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.avButtonExit.Location = new System.Drawing.Point(447, 0);
            this.avButtonExit.Name = "avButtonExit";
            this.avButtonExit.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(208)))), ((int)(((byte)(207)))));
            this.avButtonExit.Padding = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.avButtonExit.Selected = false;
            this.avButtonExit.Size = new System.Drawing.Size(75, 48);
            this.avButtonExit.TabIndex = 4;
            this.avButtonExit.Text = "Exit";
            this.avButtonExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonExit.Click += new System.EventHandler(this.avButtonExit_Click);
            // 
            // pictureSeparatorEnd
            // 
            this.pictureSeparatorEnd.BackColor = System.Drawing.Color.Transparent;
            this.pictureSeparatorEnd.BackgroundImage = global::LTR.UI.Properties.Resources.SeparatorLine;
            this.pictureSeparatorEnd.Image = global::LTR.UI.Properties.Resources.LogoutSeparatorLine;
            this.pictureSeparatorEnd.Location = new System.Drawing.Point(531, 4);
            this.pictureSeparatorEnd.Margin = new System.Windows.Forms.Padding(0);
            this.pictureSeparatorEnd.Name = "pictureSeparatorEnd";
            this.pictureSeparatorEnd.Size = new System.Drawing.Size(1, 43);
            this.pictureSeparatorEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSeparatorEnd.TabIndex = 7;
            this.pictureSeparatorEnd.TabStop = false;
            // 
            // avButtonLogout
            // 
            this.avButtonLogout.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.avButtonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avButtonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonLogout.ExtendedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.avButtonLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(207)))), ((int)(((byte)(208)))));
            this.avButtonLogout.FlatAppearance.BorderSize = 0;
            this.avButtonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avButtonLogout.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avButtonLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.avButtonLogout.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.avButtonLogout.Hoverable = true;
            this.avButtonLogout.Icon = global::LTR.UI.Properties.Resources.LogoutIcon;
            this.avButtonLogout.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.avButtonLogout.Location = new System.Drawing.Point(291, 0);
            this.avButtonLogout.Margin = new System.Windows.Forms.Padding(0);
            this.avButtonLogout.Name = "avButtonLogout";
            this.avButtonLogout.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(208)))), ((int)(((byte)(207)))));
            this.avButtonLogout.Padding = new System.Windows.Forms.Padding(2);
            this.avButtonLogout.Selected = false;
            this.avButtonLogout.Size = new System.Drawing.Size(151, 48);
            this.avButtonLogout.TabIndex = 3;
            this.avButtonLogout.Text = "Log out";
            this.avButtonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonLogout.Click += new System.EventHandler(this.avButtonLogout_Click);
            // 
            // pictureSeparatorEnd
            // 
            this.pictureSeparatorEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSeparatorEnd.BackColor = System.Drawing.Color.Transparent;
            this.pictureSeparatorEnd.BackgroundImage = global::LTR.UI.Properties.Resources.SeparatorLine;
            this.pictureSeparatorEnd.Image = global::LTR.UI.Properties.Resources.LogoutSeparatorLine;
            this.pictureSeparatorEnd.Location = new System.Drawing.Point(530, 4);
            this.pictureSeparatorEnd.Margin = new System.Windows.Forms.Padding(0);
            this.pictureSeparatorEnd.Name = "pictureSeparatorEnd";
            this.pictureSeparatorEnd.Size = new System.Drawing.Size(1, 43);
            this.pictureSeparatorEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSeparatorEnd.TabIndex = 7;
            this.pictureSeparatorEnd.TabStop = false;
            // 
            // UILogoutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pictureSeparatorEnd);
            this.Controls.Add(this.pictureSeparatorLine);
            this.Controls.Add(this.avButtonExit);
            this.Controls.Add(this.avButtonLogout);
            this.Controls.Add(this.labelUsername);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 48);
            this.Name = "UILogoutControl";
            this.Size = new System.Drawing.Size(532, 48);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparatorEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private AvButton avButtonExit;
        private System.Windows.Forms.PictureBox pictureSeparatorLine;
        private AvButton avButtonLogout;
        private System.Windows.Forms.PictureBox pictureSeparatorEnd;
    }
}
