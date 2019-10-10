using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MailControls
{
	partial class MailSettingFrom
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
			this.labelHost = new MetroFramework.Controls.MetroLabel();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.textBoxHost = new MetroFramework.Controls.MetroTextBox();
			this.metroTextBoxPort = new MetroFramework.Controls.MetroTextBox();
			this.metroLabelPort = new MetroFramework.Controls.MetroLabel();
			this.metroLabelSSL = new MetroFramework.Controls.MetroLabel();
			this.checkBoxSSL = new System.Windows.Forms.CheckBox();
			this.metroTextBoxPassword = new MetroFramework.Controls.MetroTextBox();
			this.metroLabelUserMail = new MetroFramework.Controls.MetroLabel();
			this.labelPassword = new MetroFramework.Controls.MetroLabel();
			this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
			this.SuspendLayout();
			// 
			// labelHost
			// 
			this.labelHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHost.Location = new System.Drawing.Point(12, 63);
			this.labelHost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHost.Name = "labelHost";
			this.labelHost.Size = new System.Drawing.Size(72, 25);
			this.labelHost.TabIndex = 205;
			this.labelHost.Text = "Host:";
			this.labelHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(196, 199);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 240;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(277, 199);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 239;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// textBoxHost
			// 
			// 
			// 
			// 
			this.textBoxHost.CustomButton.Image = null;
			this.textBoxHost.CustomButton.Location = new System.Drawing.Point(221, 2);
			this.textBoxHost.CustomButton.Name = "";
			this.textBoxHost.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxHost.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxHost.CustomButton.TabIndex = 1;
			this.textBoxHost.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxHost.CustomButton.UseSelectable = true;
			this.textBoxHost.CustomButton.Visible = false;
			this.textBoxHost.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxHost.Lines = new string[0];
			this.textBoxHost.Location = new System.Drawing.Point(113, 68);
			this.textBoxHost.MaxLength = 32767;
			this.textBoxHost.Name = "textBoxHost";
			this.textBoxHost.PasswordChar = '\0';
			this.textBoxHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxHost.SelectedText = "";
			this.textBoxHost.SelectionLength = 0;
			this.textBoxHost.SelectionStart = 0;
			this.textBoxHost.ShortcutsEnabled = true;
			this.textBoxHost.Size = new System.Drawing.Size(239, 20);
			this.textBoxHost.TabIndex = 241;
			this.textBoxHost.UseSelectable = true;
			this.textBoxHost.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxHost.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroTextBoxPort
			// 
			// 
			// 
			// 
			this.metroTextBoxPort.CustomButton.Image = null;
			this.metroTextBoxPort.CustomButton.Location = new System.Drawing.Point(221, 2);
			this.metroTextBoxPort.CustomButton.Name = "";
			this.metroTextBoxPort.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBoxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxPort.CustomButton.TabIndex = 1;
			this.metroTextBoxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxPort.CustomButton.UseSelectable = true;
			this.metroTextBoxPort.CustomButton.Visible = false;
			this.metroTextBoxPort.ForeColor = System.Drawing.Color.DimGray;
			this.metroTextBoxPort.Lines = new string[0];
			this.metroTextBoxPort.Location = new System.Drawing.Point(113, 94);
			this.metroTextBoxPort.MaxLength = 32767;
			this.metroTextBoxPort.Name = "metroTextBoxPort";
			this.metroTextBoxPort.PasswordChar = '\0';
			this.metroTextBoxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxPort.SelectedText = "";
			this.metroTextBoxPort.SelectionLength = 0;
			this.metroTextBoxPort.SelectionStart = 0;
			this.metroTextBoxPort.ShortcutsEnabled = true;
			this.metroTextBoxPort.Size = new System.Drawing.Size(239, 20);
			this.metroTextBoxPort.TabIndex = 243;
			this.metroTextBoxPort.UseSelectable = true;
			this.metroTextBoxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabelPort
			// 
			this.metroLabelPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelPort.Location = new System.Drawing.Point(12, 89);
			this.metroLabelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.metroLabelPort.Name = "metroLabelPort";
			this.metroLabelPort.Size = new System.Drawing.Size(72, 25);
			this.metroLabelPort.TabIndex = 242;
			this.metroLabelPort.Text = "Port:";
			this.metroLabelPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroLabelSSL
			// 
			this.metroLabelSSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelSSL.Location = new System.Drawing.Point(12, 114);
			this.metroLabelSSL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.metroLabelSSL.Name = "metroLabelSSL";
			this.metroLabelSSL.Size = new System.Drawing.Size(72, 25);
			this.metroLabelSSL.TabIndex = 244;
			this.metroLabelSSL.Text = "SSL:";
			this.metroLabelSSL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxSSL
			// 
			this.checkBoxSSL.AutoSize = true;
			this.checkBoxSSL.Location = new System.Drawing.Point(113, 122);
			this.checkBoxSSL.Name = "checkBoxSSL";
			this.checkBoxSSL.Size = new System.Drawing.Size(79, 17);
			this.checkBoxSSL.TabIndex = 245;
			this.checkBoxSSL.Text = "EnableSSL";
			this.checkBoxSSL.UseVisualStyleBackColor = true;
			// 
			// metroTextBoxPassword
			// 
			// 
			// 
			// 
			this.metroTextBoxPassword.CustomButton.Image = null;
			this.metroTextBoxPassword.CustomButton.Location = new System.Drawing.Point(221, 2);
			this.metroTextBoxPassword.CustomButton.Name = "";
			this.metroTextBoxPassword.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBoxPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxPassword.CustomButton.TabIndex = 1;
			this.metroTextBoxPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxPassword.CustomButton.UseSelectable = true;
			this.metroTextBoxPassword.CustomButton.Visible = false;
			this.metroTextBoxPassword.ForeColor = System.Drawing.Color.DimGray;
			this.metroTextBoxPassword.Lines = new string[0];
			this.metroTextBoxPassword.Location = new System.Drawing.Point(113, 173);
			this.metroTextBoxPassword.MaxLength = 32767;
			this.metroTextBoxPassword.Name = "metroTextBoxPassword";
			this.metroTextBoxPassword.PasswordChar = '\0';
			this.metroTextBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxPassword.SelectedText = "";
			this.metroTextBoxPassword.SelectionLength = 0;
			this.metroTextBoxPassword.SelectionStart = 0;
			this.metroTextBoxPassword.ShortcutsEnabled = true;
			this.metroTextBoxPassword.Size = new System.Drawing.Size(239, 20);
			this.metroTextBoxPassword.TabIndex = 247;
			this.metroTextBoxPassword.UseSelectable = true;
			this.metroTextBoxPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabelUserMail
			// 
			this.metroLabelUserMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelUserMail.Location = new System.Drawing.Point(12, 142);
			this.metroLabelUserMail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.metroLabelUserMail.Name = "metroLabelUserMail";
			this.metroLabelUserMail.Size = new System.Drawing.Size(72, 25);
			this.metroLabelUserMail.TabIndex = 246;
			this.metroLabelUserMail.Text = "User Mail:";
			this.metroLabelUserMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPassword
			// 
			this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPassword.Location = new System.Drawing.Point(12, 168);
			this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(92, 25);
			this.labelPassword.TabIndex = 249;
			this.labelPassword.Text = "Password:";
			this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroTextBox2
			// 
			// 
			// 
			// 
			this.metroTextBox2.CustomButton.Image = null;
			this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(221, 2);
			this.metroTextBox2.CustomButton.Name = "";
			this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox2.CustomButton.TabIndex = 1;
			this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox2.CustomButton.UseSelectable = true;
			this.metroTextBox2.CustomButton.Visible = false;
			this.metroTextBox2.ForeColor = System.Drawing.Color.DimGray;
			this.metroTextBox2.Lines = new string[0];
			this.metroTextBox2.Location = new System.Drawing.Point(113, 147);
			this.metroTextBox2.MaxLength = 32767;
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.PasswordChar = '\0';
			this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox2.SelectedText = "";
			this.metroTextBox2.SelectionLength = 0;
			this.metroTextBox2.SelectionStart = 0;
			this.metroTextBox2.ShortcutsEnabled = true;
			this.metroTextBox2.Size = new System.Drawing.Size(239, 20);
			this.metroTextBox2.TabIndex = 250;
			this.metroTextBox2.UseSelectable = true;
			this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// MailSettingFrom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 242);
			this.Controls.Add(this.metroTextBox2);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.metroTextBoxPassword);
			this.Controls.Add(this.metroLabelUserMail);
			this.Controls.Add(this.checkBoxSSL);
			this.Controls.Add(this.metroLabelSSL);
			this.Controls.Add(this.metroTextBoxPort);
			this.Controls.Add(this.metroLabelPort);
			this.Controls.Add(this.textBoxHost);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelHost);
			this.Name = "MailSettingFrom";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Mail Setting From";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroLabel labelHost;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonClose;
		private MetroTextBox textBoxHost;
		private MetroTextBox metroTextBoxPort;
		private MetroLabel metroLabelPort;
		private MetroLabel metroLabelSSL;
		private System.Windows.Forms.CheckBox checkBoxSSL;
		private MetroTextBox metroTextBoxPassword;
		private MetroLabel metroLabelUserMail;
		private MetroLabel labelPassword;
		private MetroTextBox metroTextBox2;
	}
}