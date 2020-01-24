using System.Windows.Forms;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	partial class TransferInformationForm
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
			this.buttonApply = new System.Windows.Forms.Button();
			this.textBoxNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelNumber = new MetroFramework.Controls.MetroLabel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this._formListViewTransferInformation = new CAS.UI.UIControls.PurchaseControls.Purchase.TransferInformationFormListView();
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxSerialNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelSerialNumber = new MetroFramework.Controls.MetroLabel();
			this.buttonForAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(766, 326);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 295;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonApply.Location = new System.Drawing.Point(847, 156);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 33);
			this.buttonApply.TabIndex = 294;
			this.buttonApply.Text = "Apply";
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// textBoxNumber
			// 
			// 
			// 
			// 
			this.textBoxNumber.CustomButton.Image = null;
			this.textBoxNumber.CustomButton.Location = new System.Drawing.Point(177, 1);
			this.textBoxNumber.CustomButton.Name = "";
			this.textBoxNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.textBoxNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNumber.CustomButton.TabIndex = 1;
			this.textBoxNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNumber.CustomButton.UseSelectable = true;
			this.textBoxNumber.CustomButton.Visible = false;
			this.textBoxNumber.Enabled = false;
			this.textBoxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNumber.Lines = new string[0];
			this.textBoxNumber.Location = new System.Drawing.Point(721, 63);
			this.textBoxNumber.MaxLength = 32767;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.PasswordChar = '\0';
			this.textBoxNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNumber.SelectedText = "";
			this.textBoxNumber.SelectionLength = 0;
			this.textBoxNumber.SelectionStart = 0;
			this.textBoxNumber.ShortcutsEnabled = true;
			this.textBoxNumber.Size = new System.Drawing.Size(201, 25);
			this.textBoxNumber.TabIndex = 297;
			this.textBoxNumber.UseSelectable = true;
			this.textBoxNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelNumber
			// 
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Location = new System.Drawing.Point(601, 63);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(104, 23);
			this.labelNumber.TabIndex = 296;
			this.labelNumber.Text = "Number:";
			this.labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(847, 326);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 298;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// _formListViewTransferInformation
			// 
			this._formListViewTransferInformation.ConfigurePaste = null;
			this._formListViewTransferInformation.Displayer = null;
			this._formListViewTransferInformation.DisplayerText = null;
			this._formListViewTransferInformation.EnableCustomSorting = true;
			this._formListViewTransferInformation.Entity = null;
			this._formListViewTransferInformation.IgnoreEnterPress = false;
			this._formListViewTransferInformation.Location = new System.Drawing.Point(4, 63);
			this._formListViewTransferInformation.MenuOpeningAction = null;
			this._formListViewTransferInformation.Name = "_formListViewTransferInformation";
			this._formListViewTransferInformation.OldColumnIndex = 0;
			this._formListViewTransferInformation.PasteComplete = null;
			this._formListViewTransferInformation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this._formListViewTransferInformation.Size = new System.Drawing.Size(580, 280);
			this._formListViewTransferInformation.SortMultiplier = 0;
			this._formListViewTransferInformation.TabIndex = 299;
			this._formListViewTransferInformation.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewTransferInformation_SelectedItemsChanged);
			// 
			// textBoxPartNumber
			// 
			// 
			// 
			// 
			this.textBoxPartNumber.CustomButton.Image = null;
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(177, 1);
			this.textBoxPartNumber.CustomButton.Name = "";
			this.textBoxPartNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.textBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPartNumber.CustomButton.TabIndex = 1;
			this.textBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPartNumber.CustomButton.UseSelectable = true;
			this.textBoxPartNumber.CustomButton.Visible = false;
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNumber.Lines = new string[0];
			this.textBoxPartNumber.Location = new System.Drawing.Point(721, 94);
			this.textBoxPartNumber.MaxLength = 32767;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(201, 25);
			this.textBoxPartNumber.TabIndex = 301;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(601, 94);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(104, 23);
			this.labelPartNumber.TabIndex = 300;
			this.labelPartNumber.Text = "Part Number:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSerialNumber
			// 
			// 
			// 
			// 
			this.textBoxSerialNumber.CustomButton.Image = null;
			this.textBoxSerialNumber.CustomButton.Location = new System.Drawing.Point(177, 1);
			this.textBoxSerialNumber.CustomButton.Name = "";
			this.textBoxSerialNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.textBoxSerialNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSerialNumber.CustomButton.TabIndex = 1;
			this.textBoxSerialNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSerialNumber.CustomButton.UseSelectable = true;
			this.textBoxSerialNumber.CustomButton.Visible = false;
			this.textBoxSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSerialNumber.Lines = new string[0];
			this.textBoxSerialNumber.Location = new System.Drawing.Point(721, 125);
			this.textBoxSerialNumber.MaxLength = 32767;
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.PasswordChar = '\0';
			this.textBoxSerialNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSerialNumber.SelectedText = "";
			this.textBoxSerialNumber.SelectionLength = 0;
			this.textBoxSerialNumber.SelectionStart = 0;
			this.textBoxSerialNumber.ShortcutsEnabled = true;
			this.textBoxSerialNumber.Size = new System.Drawing.Size(201, 25);
			this.textBoxSerialNumber.TabIndex = 303;
			this.textBoxSerialNumber.UseSelectable = true;
			this.textBoxSerialNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSerialNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNumber.Location = new System.Drawing.Point(601, 125);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(104, 23);
			this.labelSerialNumber.TabIndex = 302;
			this.labelSerialNumber.Text = "Serial Number:";
			this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonForAll
			// 
			this.buttonForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonForAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonForAll.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonForAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonForAll.Location = new System.Drawing.Point(740, 156);
			this.buttonForAll.Name = "buttonForAll";
			this.buttonForAll.Size = new System.Drawing.Size(101, 33);
			this.buttonForAll.TabIndex = 304;
			this.buttonForAll.Text = "Apply for all";
			this.buttonForAll.Click += new System.EventHandler(this.buttonForAll_Click);
			// 
			// TransferInformationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(926, 366);
			this.Controls.Add(this.buttonForAll);
			this.Controls.Add(this.textBoxSerialNumber);
			this.Controls.Add(this.labelSerialNumber);
			this.Controls.Add(this.textBoxPartNumber);
			this.Controls.Add(this.labelPartNumber);
			this.Controls.Add(this._formListViewTransferInformation);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonApply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TransferInformationForm";
			this.Resizable = false;
			this.Text = "Transfer Information Form";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonApply;
		private MetroFramework.Controls.MetroTextBox textBoxNumber;
		private MetroFramework.Controls.MetroLabel labelNumber;
		private Button buttonCancel;
		private Purchase.TransferInformationFormListView _formListViewTransferInformation;
		private MetroFramework.Controls.MetroTextBox textBoxPartNumber;
		private MetroFramework.Controls.MetroLabel labelPartNumber;
		private MetroFramework.Controls.MetroTextBox textBoxSerialNumber;
		private MetroFramework.Controls.MetroLabel labelSerialNumber;
		private Button buttonForAll;
	}
}