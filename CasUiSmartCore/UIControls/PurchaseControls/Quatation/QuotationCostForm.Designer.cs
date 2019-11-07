using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	partial class QuotationCostForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBoxCostRepair = new System.Windows.Forms.ComboBox();
			this.comboBoxCostOH = new System.Windows.Forms.ComboBox();
			this.comboBoxCostServ = new System.Windows.Forms.ComboBox();
			this.comboBoxCostNew = new System.Windows.Forms.ComboBox();
			this.numericUpDownCostRepair = new System.Windows.Forms.NumericUpDown();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownCostOH = new System.Windows.Forms.NumericUpDown();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownCostNew = new System.Windows.Forms.NumericUpDown();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownCostServ = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.supplierListView1 = new CAS.UI.UIControls.SupplierControls.SupplierPriceListView();
			this.numericUpDownExRepair = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownExOH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownExNew = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownExServ = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownReadinessRepair = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownReadinessOH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownReadinessNew = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownReadinessServ = new System.Windows.Forms.NumericUpDown();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostRepair)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostOH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostServ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExRepair)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExOH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExServ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessRepair)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessOH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessServ)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(970, 346);
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
			this.buttonCancel.Location = new System.Drawing.Point(1051, 346);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.metroLabel5);
			this.groupBox1.Controls.Add(this.metroLabel4);
			this.groupBox1.Controls.Add(this.numericUpDownReadinessRepair);
			this.groupBox1.Controls.Add(this.numericUpDownReadinessOH);
			this.groupBox1.Controls.Add(this.numericUpDownReadinessNew);
			this.groupBox1.Controls.Add(this.numericUpDownReadinessServ);
			this.groupBox1.Controls.Add(this.numericUpDownExRepair);
			this.groupBox1.Controls.Add(this.numericUpDownExOH);
			this.groupBox1.Controls.Add(this.numericUpDownExNew);
			this.groupBox1.Controls.Add(this.numericUpDownExServ);
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
			this.groupBox1.Size = new System.Drawing.Size(440, 187);
			this.groupBox1.TabIndex = 296;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cost";
			// 
			// comboBoxCostRepair
			// 
			this.comboBoxCostRepair.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostRepair.FormattingEnabled = true;
			this.comboBoxCostRepair.ItemHeight = 12;
			this.comboBoxCostRepair.Location = new System.Drawing.Point(382, 112);
			this.comboBoxCostRepair.Name = "comboBoxCostRepair";
			this.comboBoxCostRepair.Size = new System.Drawing.Size(52, 20);
			this.comboBoxCostRepair.TabIndex = 302;
			// 
			// comboBoxCostOH
			// 
			this.comboBoxCostOH.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostOH.FormattingEnabled = true;
			this.comboBoxCostOH.ItemHeight = 12;
			this.comboBoxCostOH.Location = new System.Drawing.Point(382, 86);
			this.comboBoxCostOH.Name = "comboBoxCostOH";
			this.comboBoxCostOH.Size = new System.Drawing.Size(52, 20);
			this.comboBoxCostOH.TabIndex = 301;
			// 
			// comboBoxCostServ
			// 
			this.comboBoxCostServ.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostServ.FormattingEnabled = true;
			this.comboBoxCostServ.ItemHeight = 12;
			this.comboBoxCostServ.Location = new System.Drawing.Point(382, 60);
			this.comboBoxCostServ.Name = "comboBoxCostServ";
			this.comboBoxCostServ.Size = new System.Drawing.Size(52, 20);
			this.comboBoxCostServ.TabIndex = 300;
			// 
			// comboBoxCostNew
			// 
			this.comboBoxCostNew.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostNew.FormattingEnabled = true;
			this.comboBoxCostNew.ItemHeight = 12;
			this.comboBoxCostNew.Location = new System.Drawing.Point(382, 35);
			this.comboBoxCostNew.Name = "comboBoxCostNew";
			this.comboBoxCostNew.Size = new System.Drawing.Size(52, 20);
			this.comboBoxCostNew.TabIndex = 299;
			// 
			// numericUpDownCostRepair
			// 
			this.numericUpDownCostRepair.DecimalPlaces = 2;
			this.numericUpDownCostRepair.Location = new System.Drawing.Point(102, 112);
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
			this.metroLabel3.Location = new System.Drawing.Point(5, 113);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(78, 19);
			this.metroLabel3.TabIndex = 255;
			this.metroLabel3.Text = "Cost repair:";
			this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownCostOH
			// 
			this.numericUpDownCostOH.DecimalPlaces = 2;
			this.numericUpDownCostOH.Location = new System.Drawing.Point(102, 86);
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
			this.metroLabel2.Location = new System.Drawing.Point(5, 87);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(62, 19);
			this.metroLabel2.TabIndex = 253;
			this.metroLabel2.Text = "Cost OH:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownCostNew
			// 
			this.numericUpDownCostNew.DecimalPlaces = 2;
			this.numericUpDownCostNew.Location = new System.Drawing.Point(103, 34);
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
			this.metroLabel1.Location = new System.Drawing.Point(6, 35);
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
			this.button1.Location = new System.Drawing.Point(359, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// numericUpDownCostServ
			// 
			this.numericUpDownCostServ.DecimalPlaces = 2;
			this.numericUpDownCostServ.Location = new System.Drawing.Point(102, 60);
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
			this.labelQuantity.Location = new System.Drawing.Point(5, 61);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(66, 19);
			this.labelQuantity.TabIndex = 158;
			this.labelQuantity.Text = "Cost serv:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// supplierListView1
			// 
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.Entity = null;
			this.supplierListView1.GroupBySupplie = true;
			this.supplierListView1.IgnoreEnterPress = false;
			this.supplierListView1.Location = new System.Drawing.Point(3, 63);
			this.supplierListView1.MenuOpeningAction = null;
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.OldColumnIndex = 0;
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.Size = new System.Drawing.Size(677, 321);
			this.supplierListView1.SortMultiplier = 0;
			this.supplierListView1.TabIndex = 70;
			this.supplierListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.SupplierListView1_SelectedItemsChanged);
			// 
			// numericUpDownExRepair
			// 
			this.numericUpDownExRepair.DecimalPlaces = 2;
			this.numericUpDownExRepair.Location = new System.Drawing.Point(195, 112);
			this.numericUpDownExRepair.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExRepair.Name = "numericUpDownExRepair";
			this.numericUpDownExRepair.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownExRepair.TabIndex = 306;
			// 
			// numericUpDownExOH
			// 
			this.numericUpDownExOH.DecimalPlaces = 2;
			this.numericUpDownExOH.Location = new System.Drawing.Point(195, 86);
			this.numericUpDownExOH.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExOH.Name = "numericUpDownExOH";
			this.numericUpDownExOH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownExOH.TabIndex = 305;
			// 
			// numericUpDownExNew
			// 
			this.numericUpDownExNew.DecimalPlaces = 2;
			this.numericUpDownExNew.Location = new System.Drawing.Point(196, 34);
			this.numericUpDownExNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExNew.Name = "numericUpDownExNew";
			this.numericUpDownExNew.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownExNew.TabIndex = 304;
			// 
			// numericUpDownExServ
			// 
			this.numericUpDownExServ.DecimalPlaces = 2;
			this.numericUpDownExServ.Location = new System.Drawing.Point(195, 60);
			this.numericUpDownExServ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExServ.Name = "numericUpDownExServ";
			this.numericUpDownExServ.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownExServ.TabIndex = 303;
			// 
			// numericUpDownReadinessRepair
			// 
			this.numericUpDownReadinessRepair.DecimalPlaces = 2;
			this.numericUpDownReadinessRepair.Location = new System.Drawing.Point(288, 112);
			this.numericUpDownReadinessRepair.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownReadinessRepair.Name = "numericUpDownReadinessRepair";
			this.numericUpDownReadinessRepair.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownReadinessRepair.TabIndex = 310;
			// 
			// numericUpDownReadinessOH
			// 
			this.numericUpDownReadinessOH.DecimalPlaces = 2;
			this.numericUpDownReadinessOH.Location = new System.Drawing.Point(288, 86);
			this.numericUpDownReadinessOH.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownReadinessOH.Name = "numericUpDownReadinessOH";
			this.numericUpDownReadinessOH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownReadinessOH.TabIndex = 309;
			// 
			// numericUpDownReadinessNew
			// 
			this.numericUpDownReadinessNew.DecimalPlaces = 2;
			this.numericUpDownReadinessNew.Location = new System.Drawing.Point(289, 34);
			this.numericUpDownReadinessNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownReadinessNew.Name = "numericUpDownReadinessNew";
			this.numericUpDownReadinessNew.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownReadinessNew.TabIndex = 308;
			// 
			// numericUpDownReadinessServ
			// 
			this.numericUpDownReadinessServ.DecimalPlaces = 2;
			this.numericUpDownReadinessServ.Location = new System.Drawing.Point(288, 60);
			this.numericUpDownReadinessServ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownReadinessServ.Name = "numericUpDownReadinessServ";
			this.numericUpDownReadinessServ.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownReadinessServ.TabIndex = 307;
			// 
			// metroLabel4
			// 
			this.metroLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel4.Location = new System.Drawing.Point(196, 12);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(87, 19);
			this.metroLabel4.TabIndex = 311;
			this.metroLabel4.Text = "Exchange";
			this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// metroLabel5
			// 
			this.metroLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel5.Location = new System.Drawing.Point(289, 12);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(87, 19);
			this.metroLabel5.TabIndex = 312;
			this.metroLabel5.Text = "Readiness";
			this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// QuotationCostForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1130, 402);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.supplierListView1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuotationCostForm";
			this.Resizable = false;
			this.Text = "Quotation Cost Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostRepair)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostOH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostServ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExRepair)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExOH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExServ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessRepair)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessOH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessServ)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private CAS.UI.UIControls.SupplierControls.SupplierPriceListView supplierListView1;
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
		private System.Windows.Forms.ComboBox comboBoxCostRepair;
		private System.Windows.Forms.ComboBox comboBoxCostOH;
		private System.Windows.Forms.ComboBox comboBoxCostServ;
		private System.Windows.Forms.ComboBox comboBoxCostNew;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private System.Windows.Forms.NumericUpDown numericUpDownReadinessRepair;
		private System.Windows.Forms.NumericUpDown numericUpDownReadinessOH;
		private System.Windows.Forms.NumericUpDown numericUpDownReadinessNew;
		private System.Windows.Forms.NumericUpDown numericUpDownReadinessServ;
		private System.Windows.Forms.NumericUpDown numericUpDownExRepair;
		private System.Windows.Forms.NumericUpDown numericUpDownExOH;
		private System.Windows.Forms.NumericUpDown numericUpDownExNew;
		private System.Windows.Forms.NumericUpDown numericUpDownExServ;
	}
}