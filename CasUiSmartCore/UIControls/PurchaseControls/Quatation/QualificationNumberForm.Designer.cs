using System.Windows.Forms;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	partial class QualificationNumberForm
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.labelSupplier = new MetroFramework.Controls.MetroLabel();
			this.textBoxQualificationNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelQualificationNumber = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(171, 158);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 295;
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
			this.buttonCancel.Location = new System.Drawing.Point(252, 158);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.ItemHeight = 17;
			this.comboBoxSupplier.Location = new System.Drawing.Point(127, 75);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(200, 25);
			this.comboBoxSupplier.TabIndex = 299;
			// 
			// labelSupplier
			// 
			this.labelSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplier.Location = new System.Drawing.Point(7, 75);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(87, 23);
			this.labelSupplier.TabIndex = 298;
			this.labelSupplier.Text = "Supplier:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxQualificationNumber
			// 
			// 
			// 
			// 
			this.textBoxQualificationNumber.CustomButton.Image = null;
			this.textBoxQualificationNumber.CustomButton.Location = new System.Drawing.Point(177, 1);
			this.textBoxQualificationNumber.CustomButton.Name = "";
			this.textBoxQualificationNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.textBoxQualificationNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxQualificationNumber.CustomButton.TabIndex = 1;
			this.textBoxQualificationNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxQualificationNumber.CustomButton.UseSelectable = true;
			this.textBoxQualificationNumber.CustomButton.Visible = false;
			this.textBoxQualificationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxQualificationNumber.Lines = new string[0];
			this.textBoxQualificationNumber.Location = new System.Drawing.Point(127, 106);
			this.textBoxQualificationNumber.MaxLength = 32767;
			this.textBoxQualificationNumber.Name = "textBoxQualificationNumber";
			this.textBoxQualificationNumber.PasswordChar = '\0';
			this.textBoxQualificationNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxQualificationNumber.SelectedText = "";
			this.textBoxQualificationNumber.SelectionLength = 0;
			this.textBoxQualificationNumber.SelectionStart = 0;
			this.textBoxQualificationNumber.ShortcutsEnabled = true;
			this.textBoxQualificationNumber.Size = new System.Drawing.Size(201, 25);
			this.textBoxQualificationNumber.TabIndex = 297;
			this.textBoxQualificationNumber.UseSelectable = true;
			this.textBoxQualificationNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxQualificationNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelQualificationNumber
			// 
			this.labelQualificationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQualificationNumber.Location = new System.Drawing.Point(7, 106);
			this.labelQualificationNumber.Name = "labelQualificationNumber";
			this.labelQualificationNumber.Size = new System.Drawing.Size(104, 23);
			this.labelQualificationNumber.TabIndex = 296;
			this.labelQualificationNumber.Text = "Qualification #:";
			this.labelQualificationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualificationNumberForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 204);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.labelSupplier);
			this.Controls.Add(this.textBoxQualificationNumber);
			this.Controls.Add(this.labelQualificationNumber);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QualificationNumberForm";
			this.Resizable = false;
			this.Text = "Qualification Number Form";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private MetroFramework.Controls.MetroLabel labelSupplier;
		private MetroFramework.Controls.MetroTextBox textBoxQualificationNumber;
		private MetroFramework.Controls.MetroLabel labelQualificationNumber;
	}
}