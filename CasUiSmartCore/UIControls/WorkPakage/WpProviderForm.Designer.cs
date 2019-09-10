using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.WorkPakage
{
	partial class WpProviderForm
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
			this.supplierListView1 = new CAS.UI.UIControls.WorkPakage.ProviderPriceListView();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelSearchName = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchName = new MetroFramework.Controls.MetroTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownNRCKMH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownNRC = new System.Windows.Forms.NumericUpDown();
			this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownADKMH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownNDTKMH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownRoutineKMH = new System.Windows.Forms.NumericUpDown();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxOffering = new System.Windows.Forms.ComboBox();
			this.numericUpDownAD = new System.Windows.Forms.NumericUpDown();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownNDT = new System.Windows.Forms.NumericUpDown();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownOffering = new System.Windows.Forms.NumericUpDown();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownRoutine = new System.Windows.Forms.NumericUpDown();
			this.labelRoutine = new MetroFramework.Controls.MetroLabel();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNRCKMH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNRC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownADKMH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNDTKMH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRoutineKMH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNDT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffering)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRoutine)).BeginInit();
			this.SuspendLayout();
			// 
			// supplierListView
			// 
			this.supplierListView.Displayer = null;
			this.supplierListView.DisplayerText = null;
			this.supplierListView.Entity = null;
			this.supplierListView.Location = new System.Drawing.Point(23, 89);
			this.supplierListView.Name = "supplierListView";
			this.supplierListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView.Size = new System.Drawing.Size(782, 237);
			this.supplierListView.TabIndex = 69;
			// 
			// supplierListView1
			// 
			this.supplierListView1.Displayer = null;
			this.supplierListView1.DisplayerText = null;
			this.supplierListView1.Entity = null;
			this.supplierListView1.Location = new System.Drawing.Point(23, 370);
			this.supplierListView1.Name = "supplierListView1";
			this.supplierListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.supplierListView1.Size = new System.Drawing.Size(782, 246);
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
			this.ButtonAdd.Location = new System.Drawing.Point(687, 330);
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
			this.ButtonDelete.Location = new System.Drawing.Point(681, 623);
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
			this.buttonOk.Location = new System.Drawing.Point(941, 608);
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
			this.buttonCancel.Location = new System.Drawing.Point(1022, 608);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDownNRCKMH);
			this.groupBox1.Controls.Add(this.numericUpDownNRC);
			this.groupBox1.Controls.Add(this.metroLabel7);
			this.groupBox1.Controls.Add(this.numericUpDownADKMH);
			this.groupBox1.Controls.Add(this.numericUpDownNDTKMH);
			this.groupBox1.Controls.Add(this.numericUpDownRoutineKMH);
			this.groupBox1.Controls.Add(this.metroLabel6);
			this.groupBox1.Controls.Add(this.metroLabel5);
			this.groupBox1.Controls.Add(this.metroLabel4);
			this.groupBox1.Controls.Add(this.comboBoxOffering);
			this.groupBox1.Controls.Add(this.numericUpDownAD);
			this.groupBox1.Controls.Add(this.metroLabel3);
			this.groupBox1.Controls.Add(this.numericUpDownNDT);
			this.groupBox1.Controls.Add(this.metroLabel2);
			this.groupBox1.Controls.Add(this.numericUpDownOffering);
			this.groupBox1.Controls.Add(this.metroLabel1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.numericUpDownRoutine);
			this.groupBox1.Controls.Add(this.labelRoutine);
			this.groupBox1.Location = new System.Drawing.Point(811, 83);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(300, 257);
			this.groupBox1.TabIndex = 299;
			this.groupBox1.TabStop = false;
			// 
			// numericUpDownNRCKMH
			// 
			this.numericUpDownNRCKMH.DecimalPlaces = 2;
			this.numericUpDownNRCKMH.Location = new System.Drawing.Point(196, 162);
			this.numericUpDownNRCKMH.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownNRCKMH.Name = "numericUpDownNRCKMH";
			this.numericUpDownNRCKMH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownNRCKMH.TabIndex = 311;
			// 
			// numericUpDownNRC
			// 
			this.numericUpDownNRC.DecimalPlaces = 2;
			this.numericUpDownNRC.Location = new System.Drawing.Point(102, 161);
			this.numericUpDownNRC.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownNRC.Name = "numericUpDownNRC";
			this.numericUpDownNRC.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownNRC.TabIndex = 309;
			// 
			// metroLabel7
			// 
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel7.Location = new System.Drawing.Point(5, 162);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(39, 19);
			this.metroLabel7.TabIndex = 310;
			this.metroLabel7.Text = "NRC:";
			this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownADKMH
			// 
			this.numericUpDownADKMH.DecimalPlaces = 2;
			this.numericUpDownADKMH.Location = new System.Drawing.Point(196, 136);
			this.numericUpDownADKMH.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownADKMH.Name = "numericUpDownADKMH";
			this.numericUpDownADKMH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownADKMH.TabIndex = 308;
			// 
			// numericUpDownNDTKMH
			// 
			this.numericUpDownNDTKMH.DecimalPlaces = 2;
			this.numericUpDownNDTKMH.Location = new System.Drawing.Point(196, 110);
			this.numericUpDownNDTKMH.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownNDTKMH.Name = "numericUpDownNDTKMH";
			this.numericUpDownNDTKMH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownNDTKMH.TabIndex = 307;
			// 
			// numericUpDownRoutineKMH
			// 
			this.numericUpDownRoutineKMH.DecimalPlaces = 2;
			this.numericUpDownRoutineKMH.Location = new System.Drawing.Point(196, 84);
			this.numericUpDownRoutineKMH.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownRoutineKMH.Name = "numericUpDownRoutineKMH";
			this.numericUpDownRoutineKMH.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownRoutineKMH.TabIndex = 306;
			// 
			// metroLabel6
			// 
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel6.Location = new System.Drawing.Point(212, 62);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(62, 19);
			this.metroLabel6.TabIndex = 305;
			this.metroLabel6.Text = "K for MH";
			this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel5.Location = new System.Drawing.Point(212, 16);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(61, 19);
			this.metroLabel5.TabIndex = 304;
			this.metroLabel5.Text = "Currency";
			this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel4.Location = new System.Drawing.Point(126, 16);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(35, 19);
			this.metroLabel4.TabIndex = 303;
			this.metroLabel4.Text = "Cost";
			this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxOffering
			// 
			this.comboBoxOffering.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxOffering.FormattingEnabled = true;
			this.comboBoxOffering.ItemHeight = 12;
			this.comboBoxOffering.Location = new System.Drawing.Point(196, 38);
			this.comboBoxOffering.Name = "comboBoxOffering";
			this.comboBoxOffering.Size = new System.Drawing.Size(88, 20);
			this.comboBoxOffering.TabIndex = 299;
			this.comboBoxOffering.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// numericUpDownAD
			// 
			this.numericUpDownAD.DecimalPlaces = 2;
			this.numericUpDownAD.Location = new System.Drawing.Point(102, 135);
			this.numericUpDownAD.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownAD.Name = "numericUpDownAD";
			this.numericUpDownAD.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownAD.TabIndex = 254;
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel3.Location = new System.Drawing.Point(5, 136);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(30, 19);
			this.metroLabel3.TabIndex = 255;
			this.metroLabel3.Text = "AD:";
			this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownNDT
			// 
			this.numericUpDownNDT.DecimalPlaces = 2;
			this.numericUpDownNDT.Location = new System.Drawing.Point(102, 109);
			this.numericUpDownNDT.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownNDT.Name = "numericUpDownNDT";
			this.numericUpDownNDT.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownNDT.TabIndex = 252;
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(5, 110);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(37, 19);
			this.metroLabel2.TabIndex = 253;
			this.metroLabel2.Text = "NDT:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownOffering
			// 
			this.numericUpDownOffering.DecimalPlaces = 2;
			this.numericUpDownOffering.Location = new System.Drawing.Point(103, 37);
			this.numericUpDownOffering.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownOffering.Name = "numericUpDownOffering";
			this.numericUpDownOffering.Size = new System.Drawing.Size(87, 20);
			this.numericUpDownOffering.TabIndex = 250;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel1.Location = new System.Drawing.Point(6, 38);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(61, 19);
			this.metroLabel1.TabIndex = 251;
			this.metroLabel1.Text = "Offering:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(209, 209);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click_1);
			// 
			// numericUpDownRoutine
			// 
			this.numericUpDownRoutine.DecimalPlaces = 2;
			this.numericUpDownRoutine.Location = new System.Drawing.Point(102, 83);
			this.numericUpDownRoutine.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownRoutine.Name = "numericUpDownRoutine";
			this.numericUpDownRoutine.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownRoutine.TabIndex = 142;
			// 
			// labelRoutine
			// 
			this.labelRoutine.AutoSize = true;
			this.labelRoutine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRoutine.Location = new System.Drawing.Point(5, 84);
			this.labelRoutine.Name = "labelRoutine";
			this.labelRoutine.Size = new System.Drawing.Size(56, 19);
			this.labelRoutine.TabIndex = 158;
			this.labelRoutine.Text = "Routine:";
			this.labelRoutine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QuotationSupplierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1120, 664);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelSearchName);
			this.Controls.Add(this.textBoxSearchName);
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
			this.Text = "Quotation Provider Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNRCKMH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNRC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownADKMH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNDTKMH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRoutineKMH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNDT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffering)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRoutine)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CAS.UI.UIControls.SupplierControls.SupplierListView supplierListView;
		private CAS.UI.UIControls.WorkPakage.ProviderPriceListView supplierListView1;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private MetroFramework.Controls.MetroLabel labelSearchName;
		private MetroFramework.Controls.MetroTextBox textBoxSearchName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDownNRCKMH;
		private System.Windows.Forms.NumericUpDown numericUpDownNRC;
		private MetroFramework.Controls.MetroLabel metroLabel7;
		private System.Windows.Forms.NumericUpDown numericUpDownADKMH;
		private System.Windows.Forms.NumericUpDown numericUpDownNDTKMH;
		private System.Windows.Forms.NumericUpDown numericUpDownRoutineKMH;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private System.Windows.Forms.ComboBox comboBoxOffering;
		private System.Windows.Forms.NumericUpDown numericUpDownAD;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private System.Windows.Forms.NumericUpDown numericUpDownNDT;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private System.Windows.Forms.NumericUpDown numericUpDownOffering;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDownRoutine;
		private MetroFramework.Controls.MetroLabel labelRoutine;
	}
}