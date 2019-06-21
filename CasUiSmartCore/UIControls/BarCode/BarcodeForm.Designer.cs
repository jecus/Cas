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
			Telerik.WinControls.UI.Barcode.Symbology.EAN128 eaN1281 = new Telerik.WinControls.UI.Barcode.Symbology.EAN128();
			this.radBarcode1 = new Telerik.WinControls.UI.RadBarcode();
			this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
			this.QR = new Telerik.WinControls.UI.RadRadioButton();
			this.Code128 = new Telerik.WinControls.UI.RadRadioButton();
			this.EAN128 = new Telerik.WinControls.UI.RadRadioButton();
			this.buttonOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.radBarcode1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.QR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Code128)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EAN128)).BeginInit();
			this.SuspendLayout();
			// 
			// radBarcode1
			// 
			this.radBarcode1.Location = new System.Drawing.Point(8, 89);
			this.radBarcode1.Name = "radBarcode1";
			this.radBarcode1.Size = new System.Drawing.Size(369, 200);
			eaN1281.ShowText = true;
			eaN1281.Stretch = true;
			this.radBarcode1.Symbology = eaN1281;
			this.radBarcode1.TabIndex = 0;
			this.radBarcode1.Text = "radBarcode1";
			// 
			// QR
			// 
			this.QR.Location = new System.Drawing.Point(8, 64);
			this.QR.Name = "QR";
			this.QR.Size = new System.Drawing.Size(39, 19);
			this.QR.TabIndex = 1;
			this.QR.IsChecked = true;
			this.QR.Text = "QR";
			this.QR.ThemeName = "TelerikMetroBlue";
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
			this.EAN128.Size = new System.Drawing.Size(66, 19);
			this.EAN128.TabIndex = 3;
			this.EAN128.Text = "EAN128";
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
			this.buttonOk.Location = new System.Drawing.Point(302, 299);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 296;
			this.buttonOk.Text = "Print";
			// 
			// BarcodeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 342);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.EAN128);
			this.Controls.Add(this.Code128);
			this.Controls.Add(this.QR);
			this.Controls.Add(this.radBarcode1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BarcodeForm";
			this.Resizable = false;
			this.Text = "BarcodeForm";
			((System.ComponentModel.ISupportInitialize)(this.radBarcode1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.QR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Code128)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EAN128)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Telerik.WinControls.UI.RadBarcode radBarcode1;
		private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
		private Telerik.WinControls.UI.RadRadioButton QR;
		private Telerik.WinControls.UI.RadRadioButton Code128;
		private Telerik.WinControls.UI.RadRadioButton EAN128;
		private System.Windows.Forms.Button buttonOk;
	}
}