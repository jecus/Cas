namespace CAS.UI.UIControls.ProductControls
{
	partial class ProductBindForm
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
			MetroFramework.Controls.MetroLabel labelNumber;
			this.allProductListView1 = new CAS.UI.UIControls.PurchaseControls.AllProductListView();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			labelNumber = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// allProductListView1
			// 
			this.allProductListView1.Displayer = null;
			this.allProductListView1.DisplayerText = null;
			this.allProductListView1.Entity = null;
			this.allProductListView1.IgnoreAutoResize = true;
			this.allProductListView1.Location = new System.Drawing.Point(8, 102);
			this.allProductListView1.Name = "allProductListView1";
			this.allProductListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.allProductListView1.ShowGroups = true;
			this.allProductListView1.Size = new System.Drawing.Size(944, 396);
			this.allProductListView1.TabIndex = 0;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(796, 499);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 297;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(877, 499);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 296;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(867, 63);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 298;
			this.button1.Text = "Find";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// textBoxPartNumber
			// 
			// 
			// 
			// 
			this.textBoxPartNumber.CustomButton.Image = null;
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxPartNumber.CustomButton.Name = "";
			this.textBoxPartNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPartNumber.CustomButton.TabIndex = 1;
			this.textBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPartNumber.CustomButton.UseSelectable = true;
			this.textBoxPartNumber.CustomButton.Visible = false;
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxPartNumber.Lines = new string[0];
			this.textBoxPartNumber.Location = new System.Drawing.Point(67, 78);
			this.textBoxPartNumber.MaxLength = 32767;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(250, 20);
			this.textBoxPartNumber.TabIndex = 300;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(10, 78);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(56, 19);
			labelNumber.TabIndex = 299;
			labelNumber.Text = "Part №:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// metroProgressSpinner1
			// 
			this.metroProgressSpinner1.Location = new System.Drawing.Point(373, 194);
			this.metroProgressSpinner1.Maximum = 100;
			this.metroProgressSpinner1.Name = "metroProgressSpinner1";
			this.metroProgressSpinner1.Size = new System.Drawing.Size(180, 156);
			this.metroProgressSpinner1.Speed = 2F;
			this.metroProgressSpinner1.TabIndex = 301;
			this.metroProgressSpinner1.UseSelectable = true;
			this.metroProgressSpinner1.Visible = false;
			// 
			// ProductBindForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 540);
			this.Controls.Add(this.metroProgressSpinner1);
			this.Controls.Add(this.textBoxPartNumber);
			this.Controls.Add(labelNumber);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.allProductListView1);
			this.Name = "ProductBindForm";
			this.Resizable = false;
			this.Text = "ProductFind";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PurchaseControls.AllProductListView allProductListView1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button button1;
		private MetroFramework.Controls.MetroTextBox textBoxPartNumber;
		private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
	}
}