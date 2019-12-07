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
			this.comboBoxCostType = new System.Windows.Forms.ComboBox();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxCostNew = new System.Windows.Forms.ComboBox();
			this.numericUpDownReadinessNew = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownExNew = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCostNew = new System.Windows.Forms.NumericUpDown();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.supplierListView1 = new CAS.UI.UIControls.SupplierControls.SupplierPriceListView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExNew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1029, 346);
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
			this.buttonCancel.Location = new System.Drawing.Point(1110, 346);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBoxCostType);
			this.groupBox1.Controls.Add(this.metroLabel5);
			this.groupBox1.Controls.Add(this.metroLabel4);
			this.groupBox1.Controls.Add(this.comboBoxCostNew);
			this.groupBox1.Controls.Add(this.numericUpDownReadinessNew);
			this.groupBox1.Controls.Add(this.numericUpDownExNew);
			this.groupBox1.Controls.Add(this.numericUpDownCostNew);
			this.groupBox1.Controls.Add(this.metroLabel1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(686, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(499, 108);
			this.groupBox1.TabIndex = 296;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cost";
			// 
			// comboBoxCostType
			// 
			this.comboBoxCostType.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostType.FormattingEnabled = true;
			this.comboBoxCostType.ItemHeight = 12;
			this.comboBoxCostType.Location = new System.Drawing.Point(41, 35);
			this.comboBoxCostType.Name = "comboBoxCostType";
			this.comboBoxCostType.Size = new System.Drawing.Size(99, 20);
			this.comboBoxCostType.TabIndex = 313;
			this.comboBoxCostType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCostType_SelectedIndexChanged);
			// 
			// metroLabel5
			// 
			this.metroLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel5.Location = new System.Drawing.Point(390, 12);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(87, 19);
			this.metroLabel5.TabIndex = 312;
			this.metroLabel5.Text = "Readiness";
			this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// metroLabel4
			// 
			this.metroLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel4.Location = new System.Drawing.Point(239, 12);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(87, 19);
			this.metroLabel4.TabIndex = 311;
			this.metroLabel4.Text = "Exchange";
			this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxCostNew
			// 
			this.comboBoxCostNew.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostNew.FormattingEnabled = true;
			this.comboBoxCostNew.ItemHeight = 12;
			this.comboBoxCostNew.Location = new System.Drawing.Point(332, 34);
			this.comboBoxCostNew.Name = "comboBoxCostNew";
			this.comboBoxCostNew.Size = new System.Drawing.Size(52, 20);
			this.comboBoxCostNew.TabIndex = 299;
			// 
			// numericUpDownReadinessNew
			// 
			this.numericUpDownReadinessNew.DecimalPlaces = 2;
			this.numericUpDownReadinessNew.Location = new System.Drawing.Point(390, 34);
			this.numericUpDownReadinessNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownReadinessNew.Name = "numericUpDownReadinessNew";
			this.numericUpDownReadinessNew.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownReadinessNew.TabIndex = 308;
			// 
			// numericUpDownExNew
			// 
			this.numericUpDownExNew.DecimalPlaces = 2;
			this.numericUpDownExNew.Location = new System.Drawing.Point(239, 34);
			this.numericUpDownExNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExNew.Name = "numericUpDownExNew";
			this.numericUpDownExNew.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownExNew.TabIndex = 304;
			// 
			// numericUpDownCostNew
			// 
			this.numericUpDownCostNew.DecimalPlaces = 2;
			this.numericUpDownCostNew.Location = new System.Drawing.Point(146, 34);
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
			this.metroLabel1.Size = new System.Drawing.Size(38, 19);
			this.metroLabel1.TabIndex = 251;
			this.metroLabel1.Text = "Cost:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(418, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// supplierListView1
			// 
			this.supplierListView1.ConfigurePaste = null;
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.EnableCustomSorting = true;
			this.supplierListView1.Entity = null;
			this.supplierListView1.GroupBySupplie = true;
			this.supplierListView1.IgnoreEnterPress = false;
			this.supplierListView1.Location = new System.Drawing.Point(3, 63);
			this.supplierListView1.MenuOpeningAction = null;
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.OldColumnIndex = 0;
			this.supplierListView1.PasteComplete = null;
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.Size = new System.Drawing.Size(677, 321);
			this.supplierListView1.SortMultiplier = 0;
			this.supplierListView1.TabIndex = 70;
			this.supplierListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.SupplierListView1_SelectedItemsChanged);
			// 
			// QuotationCostForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1189, 402);
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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadinessNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExNew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private CAS.UI.UIControls.SupplierControls.SupplierPriceListView supplierListView1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDownCostNew;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxCostNew;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private System.Windows.Forms.NumericUpDown numericUpDownReadinessNew;
		private System.Windows.Forms.NumericUpDown numericUpDownExNew;
		private System.Windows.Forms.ComboBox comboBoxCostType;
	}
}