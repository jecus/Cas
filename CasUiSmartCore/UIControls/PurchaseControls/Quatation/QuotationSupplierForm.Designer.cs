using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	partial class QuotationSupplierForm
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
			this.supplierListView = new CAS.UI.UIControls.SupplierControls.SupplierListView();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelSearchName = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchName = new MetroFramework.Controls.MetroTextBox();
			this.supplierListView1 = new CAS.UI.UIControls.SupplierControls.SupplierListView();
			this.SuspendLayout();
			// 
			// supplierListView
			// 
			this.supplierListView.Displayer = null;
			this.supplierListView.DisplayerText = null;
			this.supplierListView.Entity = null;
			this.supplierListView.IgnoreEnterPress = false;
			this.supplierListView.Location = new System.Drawing.Point(23, 89);
			this.supplierListView.MenuOpeningAction = null;
			this.supplierListView.Name = "supplierListView";
			this.supplierListView.OldColumnIndex = 0;
			this.supplierListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView.Size = new System.Drawing.Size(946, 237);
			this.supplierListView.SortMultiplier = 0;
			this.supplierListView.TabIndex = 69;
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAdd.ActiveBackgroundImage = null;
			this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 8F);
			this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 8F);
			this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
			this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAdd.IconNotEnabled = null;
			this.ButtonAdd.Location = new System.Drawing.Point(853, 333);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
			this.ButtonAdd.TabIndex = 290;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Selected";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 8F);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 8F);
			this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = null;
			this.ButtonDelete.Location = new System.Drawing.Point(853, 609);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
			this.ButtonDelete.TabIndex = 291;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(813, 645);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 295;
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
			this.buttonCancel.Location = new System.Drawing.Point(894, 645);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// labelSearchName
			// 
			this.labelSearchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchName.Location = new System.Drawing.Point(23, 60);
			this.labelSearchName.Name = "labelSearchName";
			this.labelSearchName.Size = new System.Drawing.Size(55, 23);
			this.labelSearchName.TabIndex = 297;
			this.labelSearchName.Text = "Name:";
			this.labelSearchName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSearchName
			// 
			// 
			// 
			// 
			this.textBoxSearchName.CustomButton.Image = null;
			this.textBoxSearchName.CustomButton.Location = new System.Drawing.Point(150, 2);
			this.textBoxSearchName.CustomButton.Name = "";
			this.textBoxSearchName.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchName.CustomButton.TabIndex = 1;
			this.textBoxSearchName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchName.CustomButton.UseSelectable = true;
			this.textBoxSearchName.CustomButton.Visible = false;
			this.textBoxSearchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchName.Lines = new string[0];
			this.textBoxSearchName.Location = new System.Drawing.Point(84, 61);
			this.textBoxSearchName.MaxLength = 32767;
			this.textBoxSearchName.Name = "textBoxSearchName";
			this.textBoxSearchName.PasswordChar = '\0';
			this.textBoxSearchName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchName.SelectedText = "";
			this.textBoxSearchName.SelectionLength = 0;
			this.textBoxSearchName.SelectionStart = 0;
			this.textBoxSearchName.ShortcutsEnabled = true;
			this.textBoxSearchName.Size = new System.Drawing.Size(170, 22);
			this.textBoxSearchName.TabIndex = 298;
			this.textBoxSearchName.UseSelectable = true;
			this.textBoxSearchName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchName.TextChanged += new System.EventHandler(this.textBoxSearchPartNumber_TextChanged);
			// 
			// supplierListView1
			// 
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.Entity = null;
			this.supplierListView1.IgnoreEnterPress = false;
			this.supplierListView1.Location = new System.Drawing.Point(23, 365);
			this.supplierListView1.MenuOpeningAction = null;
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.OldColumnIndex = 0;
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.Size = new System.Drawing.Size(946, 237);
			this.supplierListView1.SortMultiplier = 0;
			this.supplierListView1.TabIndex = 299;
			// 
			// QuotationSupplierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 701);
			this.Controls.Add(this.supplierListView1);
			this.Controls.Add(this.labelSearchName);
			this.Controls.Add(this.textBoxSearchName);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.supplierListView);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuotationSupplierForm";
			this.Resizable = false;
			this.Text = "Quotation Supplier Form";
			this.ResumeLayout(false);

		}

		#endregion

		private CAS.UI.UIControls.SupplierControls.SupplierListView supplierListView;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private MetroFramework.Controls.MetroLabel labelSearchName;
		private MetroFramework.Controls.MetroTextBox textBoxSearchName;
		private SupplierControls.SupplierListView supplierListView1;
	}
}