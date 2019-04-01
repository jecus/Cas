using MetroFramework.Controls;

namespace CAS.UI.UIControls.OpepatorsControls
{
    partial class PasswordChangeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			MetroFramework.Controls.MetroLabel labelNewPassword;
			MetroFramework.Controls.MetroLabel labelConfirmPassword;
			this.textBoxNewPassword = new MetroFramework.Controls.MetroTextBox();
			this.textBoxConfirmPassword = new MetroFramework.Controls.MetroTextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			labelNewPassword = new MetroFramework.Controls.MetroLabel();
			labelConfirmPassword = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// labelNewPassword
			// 
			labelNewPassword.AutoSize = true;
			labelNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNewPassword.Location = new System.Drawing.Point(11, 73);
			labelNewPassword.Name = "labelNewPassword";
			labelNewPassword.Size = new System.Drawing.Size(97, 19);
			labelNewPassword.TabIndex = 26;
			labelNewPassword.Text = "New password:";
			labelNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelConfirmPassword
			// 
			labelConfirmPassword.AutoSize = true;
			labelConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelConfirmPassword.Location = new System.Drawing.Point(11, 110);
			labelConfirmPassword.Name = "labelConfirmPassword";
			labelConfirmPassword.Size = new System.Drawing.Size(119, 19);
			labelConfirmPassword.TabIndex = 28;
			labelConfirmPassword.Text = "Confirm password:";
			labelConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxNewPassword
			// 
			// 
			// 
			// 
			this.textBoxNewPassword.CustomButton.Image = null;
			this.textBoxNewPassword.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxNewPassword.CustomButton.Name = "";
			this.textBoxNewPassword.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxNewPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNewPassword.CustomButton.TabIndex = 1;
			this.textBoxNewPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNewPassword.CustomButton.UseSelectable = true;
			this.textBoxNewPassword.CustomButton.Visible = false;
			this.textBoxNewPassword.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxNewPassword.Lines = new string[0];
			this.textBoxNewPassword.Location = new System.Drawing.Point(143, 73);
			this.textBoxNewPassword.MaxLength = 32767;
			this.textBoxNewPassword.Name = "textBoxNewPassword";
			this.textBoxNewPassword.PasswordChar = '*';
			this.textBoxNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNewPassword.SelectedText = "";
			this.textBoxNewPassword.SelectionLength = 0;
			this.textBoxNewPassword.SelectionStart = 0;
			this.textBoxNewPassword.ShortcutsEnabled = true;
			this.textBoxNewPassword.Size = new System.Drawing.Size(250, 20);
			this.textBoxNewPassword.TabIndex = 27;
			this.textBoxNewPassword.UseSelectable = true;
			this.textBoxNewPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNewPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxConfirmPassword
			// 
			// 
			// 
			// 
			this.textBoxConfirmPassword.CustomButton.Image = null;
			this.textBoxConfirmPassword.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxConfirmPassword.CustomButton.Name = "";
			this.textBoxConfirmPassword.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxConfirmPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxConfirmPassword.CustomButton.TabIndex = 1;
			this.textBoxConfirmPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxConfirmPassword.CustomButton.UseSelectable = true;
			this.textBoxConfirmPassword.CustomButton.Visible = false;
			this.textBoxConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxConfirmPassword.Lines = new string[0];
			this.textBoxConfirmPassword.Location = new System.Drawing.Point(143, 110);
			this.textBoxConfirmPassword.MaxLength = 32767;
			this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
			this.textBoxConfirmPassword.PasswordChar = '*';
			this.textBoxConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxConfirmPassword.SelectedText = "";
			this.textBoxConfirmPassword.SelectionLength = 0;
			this.textBoxConfirmPassword.SelectionStart = 0;
			this.textBoxConfirmPassword.ShortcutsEnabled = true;
			this.textBoxConfirmPassword.Size = new System.Drawing.Size(250, 20);
			this.textBoxConfirmPassword.TabIndex = 29;
			this.textBoxConfirmPassword.UseSelectable = true;
			this.textBoxConfirmPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxConfirmPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(318, 159);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 33;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(237, 159);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 32;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(288, 138);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(105, 15);
			this.checkBox1.TabIndex = 34;
			this.checkBox1.Text = "Show password";
			this.checkBox1.UseSelectable = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// PasswordChangeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 204);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBoxConfirmPassword);
			this.Controls.Add(labelConfirmPassword);
			this.Controls.Add(this.textBoxNewPassword);
			this.Controls.Add(labelNewPassword);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PasswordChangeForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Password Change";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MetroTextBox textBoxNewPassword;
        private MetroTextBox textBoxConfirmPassword;
        public System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonOk;
		private MetroCheckBox checkBox1;
	}
}