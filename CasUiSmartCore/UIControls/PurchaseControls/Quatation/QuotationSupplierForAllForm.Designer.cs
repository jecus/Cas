using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	partial class QuotationSupplierForAllForm
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
			this.supplierListView1 = new CAS.UI.UIControls.SupplierControls.SupplierPriceListView();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.labelSearchName = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchName = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.textBox1 = new MetroFramework.Controls.MetroTextBox();
			this.groupBox1.SuspendLayout();
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
			this.supplierListView.Size = new System.Drawing.Size(657, 237);
			this.supplierListView.SortMultiplier = 0;
			this.supplierListView.TabIndex = 69;
			// 
			// supplierListView1
			// 
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.Entity = null;
			this.supplierListView1.IgnoreEnterPress = false;
			this.supplierListView1.Location = new System.Drawing.Point(23, 370);
			this.supplierListView1.MenuOpeningAction = null;
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.OldColumnIndex = 0;
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.Size = new System.Drawing.Size(657, 246);
			this.supplierListView1.SortMultiplier = 0;
			this.supplierListView1.TabIndex = 70;
			this.supplierListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.SupplierListView1_SelectedItemsChanged);
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
			this.ButtonAdd.Location = new System.Drawing.Point(564, 330);
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
			this.ButtonDelete.Location = new System.Drawing.Point(558, 623);
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
			this.buttonOk.Location = new System.Drawing.Point(813, 608);
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
			this.buttonCancel.Location = new System.Drawing.Point(894, 608);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.metroLabel2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.metroLabel1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(686, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(301, 120);
			this.groupBox1.TabIndex = 296;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cost";
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.ItemHeight = 12;
			this.comboBox1.Location = new System.Drawing.Point(77, 41);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(218, 20);
			this.comboBox1.TabIndex = 299;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel1.Location = new System.Drawing.Point(6, 16);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(48, 19);
			this.metroLabel1.TabIndex = 251;
			this.metroLabel1.Text = "Label1:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(220, 74);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
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
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(6, 42);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(50, 19);
			this.metroLabel2.TabIndex = 300;
			this.metroLabel2.Text = "Label2:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			// 
			// 
			// 
			this.textBox1.CustomButton.Image = null;
			this.textBox1.CustomButton.Location = new System.Drawing.Point(201, 2);
			this.textBox1.CustomButton.Name = "";
			this.textBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBox1.CustomButton.TabIndex = 1;
			this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBox1.CustomButton.UseSelectable = true;
			this.textBox1.CustomButton.Visible = false;
			this.textBox1.ForeColor = System.Drawing.Color.DimGray;
			this.textBox1.Lines = new string[0];
			this.textBox1.Location = new System.Drawing.Point(77, 15);
			this.textBox1.MaxLength = 32767;
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '\0';
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox1.SelectedText = "";
			this.textBox1.SelectionLength = 0;
			this.textBox1.SelectionStart = 0;
			this.textBox1.ShortcutsEnabled = true;
			this.textBox1.Size = new System.Drawing.Size(219, 20);
			this.textBox1.TabIndex = 301;
			this.textBox1.UseSelectable = true;
			this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// QuotationSupplierForAllForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 664);
			this.Controls.Add(this.labelSearchName);
			this.Controls.Add(this.textBoxSearchName);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.supplierListView1);
			this.Controls.Add(this.supplierListView);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuotationSupplierForAllForm";
			this.Resizable = false;
			this.Text = "Quotation Supplier Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CAS.UI.UIControls.SupplierControls.SupplierListView supplierListView;
		private CAS.UI.UIControls.SupplierControls.SupplierPriceListView supplierListView1;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.Button button1;
		private MetroFramework.Controls.MetroLabel labelSearchName;
		private MetroFramework.Controls.MetroTextBox textBoxSearchName;
		private System.Windows.Forms.ComboBox comboBox1;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroTextBox textBox1;
	}
}