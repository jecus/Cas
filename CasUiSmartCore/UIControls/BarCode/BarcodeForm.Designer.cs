namespace CAS.UI.UIControls.BarCode
{
	partial class BarcodeForm
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
			this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
			this.QR = new Telerik.WinControls.UI.RadRadioButton();
			this.Code128 = new Telerik.WinControls.UI.RadRadioButton();
			this.EAN128 = new Telerik.WinControls.UI.RadRadioButton();
			this.buttonOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxInstData = new System.Windows.Forms.TextBox();
			this.textBoxBatchNo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxPartNo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxSerialNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxQty = new System.Windows.Forms.TextBox();
			this.textBoxStatus = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxAta = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.QR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Code128)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EAN128)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// QR
			// 
			this.QR.CheckState = System.Windows.Forms.CheckState.Checked;
			this.QR.Location = new System.Drawing.Point(8, 64);
			this.QR.Name = "QR";
			this.QR.Size = new System.Drawing.Size(39, 19);
			this.QR.TabIndex = 1;
			this.QR.Text = "QR";
			this.QR.ThemeName = "TelerikMetroBlue";
			this.QR.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
			this.QR.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ToggleStateChanged);
			// 
			// Code128
			// 
			this.Code128.Location = new System.Drawing.Point(53, 64);
			this.Code128.Name = "Code128";
			this.Code128.Size = new System.Drawing.Size(71, 19);
			this.Code128.TabIndex = 2;
			this.Code128.Text = "Code128";
			this.Code128.ThemeName = "TelerikMetroBlue";
			this.Code128.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ToggleStateChanged);
			// 
			// EAN128
			// 
			this.EAN128.Location = new System.Drawing.Point(130, 64);
			this.EAN128.Name = "EAN128";
			this.EAN128.Size = new System.Drawing.Size(59, 19);
			this.EAN128.TabIndex = 3;
			this.EAN128.Text = "EAN13";
			this.EAN128.ThemeName = "TelerikMetroBlue";
			this.EAN128.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ToggleStateChanged);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(302, 548);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 296;
			this.buttonOk.Text = "Print";
			this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(-1, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(386, 2);
			this.label1.TabIndex = 297;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.textBoxInstData);
			this.panel1.Controls.Add(this.textBoxBatchNo);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.textBoxPartNo);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBoxSerialNo);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBoxQty);
			this.panel1.Controls.Add(this.textBoxStatus);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBoxAta);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBoxName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(1, 90);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(386, 452);
			this.panel1.TabIndex = 298;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(6, 260);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(375, 187);
			this.pictureBox1.TabIndex = 313;
			this.pictureBox1.TabStop = false;
			// 
			// label8
			// 
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Location = new System.Drawing.Point(182, 211);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(1, 43);
			this.label8.TabIndex = 312;
			this.label8.Text = "label8";
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Location = new System.Drawing.Point(182, 170);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(1, 43);
			this.label7.TabIndex = 311;
			this.label7.Text = "label7";
			// 
			// textBoxInstData
			// 
			this.textBoxInstData.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxInstData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxInstData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxInstData.Location = new System.Drawing.Point(190, 217);
			this.textBoxInstData.Multiline = true;
			this.textBoxInstData.Name = "textBoxInstData";
			this.textBoxInstData.ReadOnly = true;
			this.textBoxInstData.Size = new System.Drawing.Size(191, 34);
			this.textBoxInstData.TabIndex = 310;
			this.textBoxInstData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxBatchNo
			// 
			this.textBoxBatchNo.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxBatchNo.Location = new System.Drawing.Point(3, 217);
			this.textBoxBatchNo.Multiline = true;
			this.textBoxBatchNo.Name = "textBoxBatchNo";
			this.textBoxBatchNo.ReadOnly = true;
			this.textBoxBatchNo.Size = new System.Drawing.Size(181, 34);
			this.textBoxBatchNo.TabIndex = 309;
			this.textBoxBatchNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Location = new System.Drawing.Point(-1, 254);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(386, 2);
			this.label6.TabIndex = 308;
			// 
			// textBoxPartNo
			// 
			this.textBoxPartNo.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxPartNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.textBoxPartNo.Location = new System.Drawing.Point(3, 132);
			this.textBoxPartNo.Multiline = true;
			this.textBoxPartNo.Name = "textBoxPartNo";
			this.textBoxPartNo.ReadOnly = true;
			this.textBoxPartNo.Size = new System.Drawing.Size(378, 34);
			this.textBoxPartNo.TabIndex = 307;
			this.textBoxPartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(-1, 170);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(386, 2);
			this.label5.TabIndex = 306;
			// 
			// textBoxSerialNo
			// 
			this.textBoxSerialNo.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxSerialNo.Location = new System.Drawing.Point(-1, 89);
			this.textBoxSerialNo.Multiline = true;
			this.textBoxSerialNo.Name = "textBoxSerialNo";
			this.textBoxSerialNo.ReadOnly = true;
			this.textBoxSerialNo.Size = new System.Drawing.Size(378, 34);
			this.textBoxSerialNo.TabIndex = 305;
			this.textBoxSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(0, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(386, 2);
			this.label4.TabIndex = 304;
			// 
			// textBoxQty
			// 
			this.textBoxQty.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxQty.Location = new System.Drawing.Point(190, 175);
			this.textBoxQty.Multiline = true;
			this.textBoxQty.Name = "textBoxQty";
			this.textBoxQty.ReadOnly = true;
			this.textBoxQty.Size = new System.Drawing.Size(191, 34);
			this.textBoxQty.TabIndex = 303;
			this.textBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxStatus
			// 
			this.textBoxStatus.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxStatus.Location = new System.Drawing.Point(3, 175);
			this.textBoxStatus.Multiline = true;
			this.textBoxStatus.Name = "textBoxStatus";
			this.textBoxStatus.ReadOnly = true;
			this.textBoxStatus.Size = new System.Drawing.Size(181, 34);
			this.textBoxStatus.TabIndex = 302;
			this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(-1, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(386, 2);
			this.label3.TabIndex = 301;
			// 
			// textBoxAta
			// 
			this.textBoxAta.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxAta.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxAta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAta.Location = new System.Drawing.Point(3, 46);
			this.textBoxAta.Multiline = true;
			this.textBoxAta.Name = "textBoxAta";
			this.textBoxAta.ReadOnly = true;
			this.textBoxAta.Size = new System.Drawing.Size(378, 34);
			this.textBoxAta.TabIndex = 300;
			this.textBoxAta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(-1, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(386, 2);
			this.label2.TabIndex = 299;
			// 
			// textBoxName
			// 
			this.textBoxName.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxName.Location = new System.Drawing.Point(3, 4);
			this.textBoxName.Multiline = true;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(378, 34);
			this.textBoxName.TabIndex = 298;
			this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// BarcodeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 591);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.EAN128);
			this.Controls.Add(this.Code128);
			this.Controls.Add(this.QR);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BarcodeForm";
			this.Resizable = false;
			this.Text = "BarcodeForm";
			((System.ComponentModel.ISupportInitialize)(this.QR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Code128)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EAN128)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
		private Telerik.WinControls.UI.RadRadioButton QR;
		private Telerik.WinControls.UI.RadRadioButton Code128;
		private Telerik.WinControls.UI.RadRadioButton EAN128;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBoxAta;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxInstData;
		private System.Windows.Forms.TextBox textBoxBatchNo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxPartNo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxSerialNo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxQty;
		private System.Windows.Forms.TextBox textBoxStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}