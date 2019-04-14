using CAS.UI.UIControls.Auxiliary;

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
			this.supplierListView1 = new CAS.UI.UIControls.SupplierControls.SupplierPriceListView();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownCostRepair = new System.Windows.Forms.NumericUpDown();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownCostOH = new System.Windows.Forms.NumericUpDown();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownCostNew = new System.Windows.Forms.NumericUpDown();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownCostServ = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.labelSearchName = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchName = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxCostNew = new System.Windows.Forms.ComboBox();
			this.comboBoxCostServ = new System.Windows.Forms.ComboBox();
			this.comboBoxCostOH = new System.Windows.Forms.ComboBox();
			this.comboBoxCostRepair = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostRepair)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostOH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostServ)).BeginInit();
			this.SuspendLayout();
			// 
			// supplierListView
			// 
			this.supplierListView.Displayer = null;
			this.supplierListView.DisplayerText = null;
			this.supplierListView.Entity = null;
			this.supplierListView.IgnoreAutoResize = false;
			this.supplierListView.Location = new System.Drawing.Point(23, 89);
			this.supplierListView.Name = "supplierListView";
			this.supplierListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView.ShowGroups = true;
			this.supplierListView.Size = new System.Drawing.Size(657, 237);
			this.supplierListView.TabIndex = 69;
			// 
			// supplierListView1
			// 
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.Entity = null;
			this.supplierListView1.IgnoreAutoResize = false;
			this.supplierListView1.Location = new System.Drawing.Point(23, 370);
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.ShowGroups = true;
			this.supplierListView1.Size = new System.Drawing.Size(657, 246);
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
			this.groupBox1.Controls.Add(this.comboBoxCostRepair);
			this.groupBox1.Controls.Add(this.comboBoxCostOH);
			this.groupBox1.Controls.Add(this.comboBoxCostServ);
			this.groupBox1.Controls.Add(this.comboBoxCostNew);
			this.groupBox1.Controls.Add(this.numericUpDownCostRepair);
			this.groupBox1.Controls.Add(this.metroLabel3);
			this.groupBox1.Controls.Add(this.numericUpDownCostOH);
			this.groupBox1.Controls.Add(this.metroLabel2);
			this.groupBox1.Controls.Add(this.numericUpDownCostNew);
			this.groupBox1.Controls.Add(this.metroLabel1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.numericUpDownCostServ);
			this.groupBox1.Controls.Add(this.labelQuantity);
			this.groupBox1.Location = new System.Drawing.Point(686, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(301, 173);
			this.groupBox1.TabIndex = 296;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cost";
			// 
			// numericUpDownCostRepair
			// 
			this.numericUpDownCostRepair.DecimalPlaces = 2;
			this.numericUpDownCostRepair.Location = new System.Drawing.Point(102, 93);
			this.numericUpDownCostRepair.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownCostRepair.Name = "numericUpDownCostRepair";
			this.numericUpDownCostRepair.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownCostRepair.TabIndex = 254;
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel3.Location = new System.Drawing.Point(5, 94);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(78, 19);
			this.metroLabel3.TabIndex = 255;
			this.metroLabel3.Text = "Cost repair:";
			this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownCostOH
			// 
			this.numericUpDownCostOH.DecimalPlaces = 2;
			this.numericUpDownCostOH.Location = new System.Drawing.Point(102, 67);
			this.numericUpDownCostOH.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownCostOH.Name = "numericUpDownCostOH";
			this.numericUpDownCostOH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownCostOH.TabIndex = 252;
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(5, 68);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(62, 19);
			this.metroLabel2.TabIndex = 253;
			this.metroLabel2.Text = "Cost OH:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownCostNew
			// 
			this.numericUpDownCostNew.DecimalPlaces = 2;
			this.numericUpDownCostNew.Location = new System.Drawing.Point(103, 15);
			this.numericUpDownCostNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownCostNew.Name = "numericUpDownCostNew";
			this.numericUpDownCostNew.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownCostNew.TabIndex = 250;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel1.Location = new System.Drawing.Point(6, 16);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(65, 19);
			this.metroLabel1.TabIndex = 251;
			this.metroLabel1.Text = "Cost new:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(220, 127);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// numericUpDownCostServ
			// 
			this.numericUpDownCostServ.DecimalPlaces = 2;
			this.numericUpDownCostServ.Location = new System.Drawing.Point(102, 41);
			this.numericUpDownCostServ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownCostServ.Name = "numericUpDownCostServ";
			this.numericUpDownCostServ.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownCostServ.TabIndex = 142;
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(5, 42);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(66, 19);
			this.labelQuantity.TabIndex = 158;
			this.labelQuantity.Text = "Cost serv:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// comboBoxCostNew
			// 
			this.comboBoxCostNew.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostNew.FormattingEnabled = true;
			this.comboBoxCostNew.ItemHeight = 12;
			this.comboBoxCostNew.Location = new System.Drawing.Point(196, 16);
			this.comboBoxCostNew.Name = "comboBoxCostNew";
			this.comboBoxCostNew.Size = new System.Drawing.Size(99, 20);
			this.comboBoxCostNew.TabIndex = 299;
			// 
			// comboBoxCostServ
			// 
			this.comboBoxCostServ.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostServ.FormattingEnabled = true;
			this.comboBoxCostServ.ItemHeight = 12;
			this.comboBoxCostServ.Location = new System.Drawing.Point(196, 41);
			this.comboBoxCostServ.Name = "comboBoxCostServ";
			this.comboBoxCostServ.Size = new System.Drawing.Size(99, 20);
			this.comboBoxCostServ.TabIndex = 300;
			// 
			// comboBoxCostOH
			// 
			this.comboBoxCostOH.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostOH.FormattingEnabled = true;
			this.comboBoxCostOH.ItemHeight = 12;
			this.comboBoxCostOH.Location = new System.Drawing.Point(196, 67);
			this.comboBoxCostOH.Name = "comboBoxCostOH";
			this.comboBoxCostOH.Size = new System.Drawing.Size(99, 20);
			this.comboBoxCostOH.TabIndex = 301;
			// 
			// comboBoxCostRepair
			// 
			this.comboBoxCostRepair.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostRepair.FormattingEnabled = true;
			this.comboBoxCostRepair.ItemHeight = 12;
			this.comboBoxCostRepair.Location = new System.Drawing.Point(196, 93);
			this.comboBoxCostRepair.Name = "comboBoxCostRepair";
			this.comboBoxCostRepair.Size = new System.Drawing.Size(99, 20);
			this.comboBoxCostRepair.TabIndex = 302;
			// 
			// QuotationSupplierForm
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
			this.Name = "QuotationSupplierForm";
			this.Resizable = false;
			this.Text = "Quotation Supplier Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostRepair)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostOH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostServ)).EndInit();
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
		private System.Windows.Forms.NumericUpDown numericUpDownCostRepair;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private System.Windows.Forms.NumericUpDown numericUpDownCostOH;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private System.Windows.Forms.NumericUpDown numericUpDownCostNew;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDownCostServ;
		private MetroFramework.Controls.MetroLabel labelQuantity;
		private MetroFramework.Controls.MetroLabel labelSearchName;
		private MetroFramework.Controls.MetroTextBox textBoxSearchName;
		private System.Windows.Forms.ComboBox comboBoxCostRepair;
		private System.Windows.Forms.ComboBox comboBoxCostOH;
		private System.Windows.Forms.ComboBox comboBoxCostServ;
		private System.Windows.Forms.ComboBox comboBoxCostNew;
	}
}