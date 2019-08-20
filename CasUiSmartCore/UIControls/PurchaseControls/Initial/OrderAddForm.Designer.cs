using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	partial class OrderAddForm
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
			var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.dateTimePickerOpeningDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxAuthor = new MetroFramework.Controls.MetroTextBox();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.labelOpeningDate = new MetroFramework.Controls.MetroLabel();
			this.labelAuthor = new MetroFramework.Controls.MetroLabel();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.labelQOTitle = new MetroFramework.Controls.MetroLabel();
			this.flowLayoutPanelKitSelection = new System.Windows.Forms.FlowLayoutPanel();
			this.labelSearchSupplier = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchSupplier = new MetroFramework.Controls.MetroTextBox();
			this.labelSearchPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.comboBoxPriority = new System.Windows.Forms.ComboBox();
			this.label19 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.textBoxProductDesc = new MetroFramework.Controls.MetroTextBox();
			this.labelPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBoxProductRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelSuppliers = new MetroFramework.Controls.MetroLabel();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelProduct = new MetroFramework.Controls.MetroLabel();
			this.labelTotal = new MetroFramework.Controls.MetroLabel();
			this.textBoxTotal = new MetroFramework.Controls.MetroTextBox();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.comboBoxDefferedCategory = new System.Windows.Forms.ComboBox();
			this.labelDefferedCategory = new MetroFramework.Controls.MetroLabel();
			this.labelReason = new MetroFramework.Controls.MetroLabel();
			this.comboBoxReason = new System.Windows.Forms.ComboBox();
			this.labelDestination = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDestination = new System.Windows.Forms.ComboBox();
			this.checkBoxRepair = new System.Windows.Forms.CheckBox();
			this.checkBoxOverhaul = new System.Windows.Forms.CheckBox();
			this.checkBoxServiceable = new System.Windows.Forms.CheckBox();
			this.checkBoxNew = new System.Windows.Forms.CheckBox();
			this.labelPriority = new MetroFramework.Controls.MetroLabel();
			this.labelNotify = new MetroFramework.Controls.MetroLabel();
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxTypeOfOperation = new System.Windows.Forms.ComboBox();
			this.comboBoxApprovedBy = new System.Windows.Forms.ComboBox();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxPublishedBy = new System.Windows.Forms.ComboBox();
			this.label5 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxClosedBy = new System.Windows.Forms.ComboBox();
			this.label6 = new MetroFramework.Controls.MetroLabel();
			this.textBoxRFQ = new MetroFramework.Controls.MetroTextBox();
			this.label7 = new MetroFramework.Controls.MetroLabel();
			this.textBoxQR = new MetroFramework.Controls.MetroTextBox();
			this.label8 = new MetroFramework.Controls.MetroLabel();
			this.textBoxPO = new MetroFramework.Controls.MetroTextBox();
			this.label9 = new MetroFramework.Controls.MetroLabel();
			this.textBoxInvoice = new MetroFramework.Controls.MetroTextBox();
			this.label10 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxShipBy = new System.Windows.Forms.ComboBox();
			this.label11 = new MetroFramework.Controls.MetroLabel();
			this.textBoxShipTo = new MetroFramework.Controls.MetroTextBox();
			this.labelShipTo = new MetroFramework.Controls.MetroLabel();
			this.comboBoxIncoTerm = new System.Windows.Forms.ComboBox();
			this.label13 = new MetroFramework.Controls.MetroLabel();
			this.label14 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxCarrier = new System.Windows.Forms.ComboBox();
			this.label15 = new MetroFramework.Controls.MetroLabel();
			this.textBoxPickUp = new MetroFramework.Controls.MetroTextBox();
			this.label16 = new MetroFramework.Controls.MetroLabel();
			this.textBoxWeight = new MetroFramework.Controls.MetroTextBox();
			this.label17 = new MetroFramework.Controls.MetroLabel();
			this.textBoxDIMS = new MetroFramework.Controls.MetroTextBox();
			this.label18 = new MetroFramework.Controls.MetroLabel();
			this.listViewInitialItems = new CAS.UI.UIControls.PurchaseControls.Initial.InitialOrderListView();
			this.listViewKits = new CAS.UI.UIControls.PurchaseControls.Quatation.RequestProductListView();
			this.comboBoxCountry = new System.Windows.Forms.ComboBox();
			this.listViewQuatationItems = new CAS.UI.UIControls.PurchaseControls.Quatation.QuatationOrderListView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(167, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(59, 59);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(141, 600);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(229, 64);
			this.textBoxRemarks.TabIndex = 8;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerOpeningDate
			// 
			this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(141, 474);
			this.dateTimePickerOpeningDate.Name = "dateTimePickerOpeningDate";
			this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(229, 22);
			this.dateTimePickerOpeningDate.TabIndex = 1;
			this.dateTimePickerOpeningDate.ValueChanged += new System.EventHandler(this.DateTimePickerOpeningDateValueChanged);
			// 
			// textBoxAuthor
			// 
			// 
			// 
			// 
			this.textBoxAuthor.CustomButton.Image = null;
			this.textBoxAuthor.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxAuthor.CustomButton.Name = "";
			this.textBoxAuthor.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxAuthor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAuthor.CustomButton.TabIndex = 1;
			this.textBoxAuthor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAuthor.CustomButton.UseSelectable = true;
			this.textBoxAuthor.CustomButton.Visible = false;
			this.textBoxAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAuthor.Lines = new string[0];
			this.textBoxAuthor.Location = new System.Drawing.Point(141, 670);
			this.textBoxAuthor.MaxLength = 32767;
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.PasswordChar = '\0';
			this.textBoxAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAuthor.SelectedText = "";
			this.textBoxAuthor.SelectionLength = 0;
			this.textBoxAuthor.SelectionStart = 0;
			this.textBoxAuthor.ShortcutsEnabled = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(229, 22);
			this.textBoxAuthor.TabIndex = 7;
			this.textBoxAuthor.UseSelectable = true;
			this.textBoxAuthor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAuthor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxDescription
			// 
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(167, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(59, 59);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(141, 530);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(229, 64);
			this.textBoxDescription.TabIndex = 6;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelRemarks
			// 
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(8, 600);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(69, 23);
			this.labelRemarks.TabIndex = 5;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTitle
			// 
			// 
			// 
			// 
			this.textBoxTitle.CustomButton.Image = null;
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxTitle.CustomButton.Name = "";
			this.textBoxTitle.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTitle.CustomButton.TabIndex = 1;
			this.textBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTitle.CustomButton.UseSelectable = true;
			this.textBoxTitle.CustomButton.Visible = false;
			this.textBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTitle.Lines = new string[0];
			this.textBoxTitle.Location = new System.Drawing.Point(141, 502);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.SelectionLength = 0;
			this.textBoxTitle.SelectionStart = 0;
			this.textBoxTitle.ShortcutsEnabled = true;
			this.textBoxTitle.Size = new System.Drawing.Size(229, 22);
			this.textBoxTitle.TabIndex = 1;
			this.textBoxTitle.UseSelectable = true;
			this.textBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelOpeningDate
			// 
			this.labelOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOpeningDate.Location = new System.Drawing.Point(8, 474);
			this.labelOpeningDate.Name = "labelOpeningDate";
			this.labelOpeningDate.Size = new System.Drawing.Size(87, 23);
			this.labelOpeningDate.TabIndex = 4;
			this.labelOpeningDate.Text = "Open. date:";
			this.labelOpeningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAuthor
			// 
			this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAuthor.Location = new System.Drawing.Point(8, 670);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(87, 23);
			this.labelAuthor.TabIndex = 3;
			this.labelAuthor.Text = "Author:";
			this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(8, 530);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(87, 23);
			this.labelDescription.TabIndex = 2;
			this.labelDescription.Text = "Subject:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelQOTitle
			// 
			this.labelQOTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQOTitle.Location = new System.Drawing.Point(8, 502);
			this.labelQOTitle.Name = "labelQOTitle";
			this.labelQOTitle.Size = new System.Drawing.Size(87, 23);
			this.labelQOTitle.TabIndex = 1;
			this.labelQOTitle.Text = "№:";
			this.labelQOTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanelKitSelection
			// 
			this.flowLayoutPanelKitSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelKitSelection.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelKitSelection.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelKitSelection.Name = "flowLayoutPanelKitSelection";
			this.flowLayoutPanelKitSelection.Size = new System.Drawing.Size(810, 684);
			this.flowLayoutPanelKitSelection.TabIndex = 1;
			this.flowLayoutPanelKitSelection.WrapContents = false;
			// 
			// labelSearchSupplier
			// 
			this.labelSearchSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchSupplier.Location = new System.Drawing.Point(229, 60);
			this.labelSearchSupplier.Name = "labelSearchSupplier";
			this.labelSearchSupplier.Size = new System.Drawing.Size(66, 23);
			this.labelSearchSupplier.TabIndex = 61;
			this.labelSearchSupplier.Text = "Supplier:";
			this.labelSearchSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelSearchSupplier.UseCustomForeColor = true;
			// 
			// textBoxSearchSupplier
			// 
			// 
			// 
			// 
			this.textBoxSearchSupplier.CustomButton.Image = null;
			this.textBoxSearchSupplier.CustomButton.Location = new System.Drawing.Point(150, 2);
			this.textBoxSearchSupplier.CustomButton.Name = "";
			this.textBoxSearchSupplier.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchSupplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchSupplier.CustomButton.TabIndex = 1;
			this.textBoxSearchSupplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchSupplier.CustomButton.UseSelectable = true;
			this.textBoxSearchSupplier.CustomButton.Visible = false;
			this.textBoxSearchSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchSupplier.Lines = new string[0];
			this.textBoxSearchSupplier.Location = new System.Drawing.Point(301, 60);
			this.textBoxSearchSupplier.MaxLength = 32767;
			this.textBoxSearchSupplier.Name = "textBoxSearchSupplier";
			this.textBoxSearchSupplier.PasswordChar = '\0';
			this.textBoxSearchSupplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchSupplier.SelectedText = "";
			this.textBoxSearchSupplier.SelectionLength = 0;
			this.textBoxSearchSupplier.SelectionStart = 0;
			this.textBoxSearchSupplier.ShortcutsEnabled = true;
			this.textBoxSearchSupplier.Size = new System.Drawing.Size(170, 22);
			this.textBoxSearchSupplier.TabIndex = 62;
			this.textBoxSearchSupplier.UseSelectable = true;
			this.textBoxSearchSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchSupplier.TextChanged += new System.EventHandler(this.TextBoxSearchSupplierTextChanged);
			// 
			// labelSearchPartNumber
			// 
			this.labelSearchPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchPartNumber.Location = new System.Drawing.Point(7, 60);
			this.labelSearchPartNumber.Name = "labelSearchPartNumber";
			this.labelSearchPartNumber.Size = new System.Drawing.Size(36, 23);
			this.labelSearchPartNumber.TabIndex = 59;
			this.labelSearchPartNumber.Text = "P/N:";
			this.labelSearchPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelSearchPartNumber.UseCustomForeColor = true;
			// 
			// textBoxSearchPartNumber
			// 
			// 
			// 
			// 
			this.textBoxSearchPartNumber.CustomButton.Image = null;
			this.textBoxSearchPartNumber.CustomButton.Location = new System.Drawing.Point(150, 2);
			this.textBoxSearchPartNumber.CustomButton.Name = "";
			this.textBoxSearchPartNumber.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchPartNumber.CustomButton.TabIndex = 1;
			this.textBoxSearchPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchPartNumber.CustomButton.UseSelectable = true;
			this.textBoxSearchPartNumber.CustomButton.Visible = false;
			this.textBoxSearchPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchPartNumber.Lines = new string[0];
			this.textBoxSearchPartNumber.Location = new System.Drawing.Point(49, 60);
			this.textBoxSearchPartNumber.MaxLength = 32767;
			this.textBoxSearchPartNumber.Name = "textBoxSearchPartNumber";
			this.textBoxSearchPartNumber.PasswordChar = '\0';
			this.textBoxSearchPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchPartNumber.SelectedText = "";
			this.textBoxSearchPartNumber.SelectionLength = 0;
			this.textBoxSearchPartNumber.SelectionStart = 0;
			this.textBoxSearchPartNumber.ShortcutsEnabled = true;
			this.textBoxSearchPartNumber.Size = new System.Drawing.Size(170, 22);
			this.textBoxSearchPartNumber.TabIndex = 60;
			this.textBoxSearchPartNumber.UseSelectable = true;
			this.textBoxSearchPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchPartNumber.TextChanged += new System.EventHandler(this.TextBoxSearchPartNumberTextChanged);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1108, 748);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 246;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			this.buttonOk.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(1189, 748);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 245;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
			this.ButtonAdd.Location = new System.Drawing.Point(584, 239);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
			this.ButtonAdd.TabIndex = 1;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Selected";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
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
			this.ButtonDelete.Location = new System.Drawing.Point(570, 430);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(133, 22);
			this.ButtonDelete.TabIndex = 58;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.ButtonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Controls.Add(this.comboBoxPriority);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxProductDesc);
			this.groupBox1.Controls.Add(this.labelPartNumber);
			this.groupBox1.Controls.Add(this.textBoxPartNumber);
			this.groupBox1.Controls.Add(this.numericUpDownQuantity);
			this.groupBox1.Controls.Add(this.labelQuantity);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxProductRemarks);
			this.groupBox1.Controls.Add(this.labelSuppliers);
			this.groupBox1.Controls.Add(this.comboBoxMeasure);
			this.groupBox1.Controls.Add(this.labelMeasure);
			this.groupBox1.Controls.Add(this.dataGridViewControlSuppliers);
			this.groupBox1.Controls.Add(this.dictionaryComboProduct);
			this.groupBox1.Controls.Add(this.labelProduct);
			this.groupBox1.Controls.Add(this.labelTotal);
			this.groupBox1.Controls.Add(this.textBoxTotal);
			this.groupBox1.Controls.Add(this.lifelengthViewerNotify);
			this.groupBox1.Controls.Add(this.lifelengthViewerLifeLimit);
			this.groupBox1.Controls.Add(this.comboBoxDefferedCategory);
			this.groupBox1.Controls.Add(this.labelDefferedCategory);
			this.groupBox1.Controls.Add(this.labelReason);
			this.groupBox1.Controls.Add(this.comboBoxReason);
			this.groupBox1.Controls.Add(this.labelDestination);
			this.groupBox1.Controls.Add(this.comboBoxDestination);
			this.groupBox1.Controls.Add(this.checkBoxRepair);
			this.groupBox1.Controls.Add(this.checkBoxOverhaul);
			this.groupBox1.Controls.Add(this.checkBoxServiceable);
			this.groupBox1.Controls.Add(this.checkBoxNew);
			this.groupBox1.Controls.Add(this.labelPriority);
			this.groupBox1.Controls.Add(this.labelNotify);
			this.groupBox1.Location = new System.Drawing.Point(710, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(558, 684);
			this.groupBox1.TabIndex = 248;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Product";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(28, 520);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(523, 119);
			this.dataGridView1.TabIndex = 252;
			this.dataGridView1.Visible = false;
			// 
			// comboBoxPriority
			// 
			this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPriority.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxPriority.FormattingEnabled = true;
			this.comboBoxPriority.Location = new System.Drawing.Point(130, 305);
			this.comboBoxPriority.Name = "comboBoxPriority";
			this.comboBoxPriority.Size = new System.Drawing.Size(421, 25);
			this.comboBoxPriority.TabIndex = 250;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label19.Location = new System.Drawing.Point(27, 307);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(54, 19);
			this.label19.TabIndex = 251;
			this.label19.Text = "Priority:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(476, 645);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(27, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 155;
			this.label1.Text = "Description:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductDesc
			// 
			this.textBoxProductDesc.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxProductDesc.CustomButton.Image = null;
			this.textBoxProductDesc.CustomButton.Location = new System.Drawing.Point(371, 2);
			this.textBoxProductDesc.CustomButton.Name = "";
			this.textBoxProductDesc.CustomButton.Size = new System.Drawing.Size(47, 47);
			this.textBoxProductDesc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxProductDesc.CustomButton.TabIndex = 1;
			this.textBoxProductDesc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxProductDesc.CustomButton.UseSelectable = true;
			this.textBoxProductDesc.CustomButton.Visible = false;
			this.textBoxProductDesc.Enabled = false;
			this.textBoxProductDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductDesc.Lines = new string[0];
			this.textBoxProductDesc.Location = new System.Drawing.Point(130, 78);
			this.textBoxProductDesc.MaxLength = 128;
			this.textBoxProductDesc.Multiline = true;
			this.textBoxProductDesc.Name = "textBoxProductDesc";
			this.textBoxProductDesc.PasswordChar = '\0';
			this.textBoxProductDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxProductDesc.SelectedText = "";
			this.textBoxProductDesc.SelectionLength = 0;
			this.textBoxProductDesc.SelectionStart = 0;
			this.textBoxProductDesc.ShortcutsEnabled = true;
			this.textBoxProductDesc.Size = new System.Drawing.Size(421, 52);
			this.textBoxProductDesc.TabIndex = 139;
			this.textBoxProductDesc.UseSelectable = true;
			this.textBoxProductDesc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxProductDesc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.AutoSize = true;
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(27, 53);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(35, 19);
			this.labelPartNumber.TabIndex = 154;
			this.labelPartNumber.Text = "P/N:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxPartNumber.CustomButton.Image = null;
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(401, 2);
			this.textBoxPartNumber.CustomButton.Name = "";
			this.textBoxPartNumber.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPartNumber.CustomButton.TabIndex = 1;
			this.textBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPartNumber.CustomButton.UseSelectable = true;
			this.textBoxPartNumber.CustomButton.Visible = false;
			this.textBoxPartNumber.Enabled = false;
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNumber.Lines = new string[0];
			this.textBoxPartNumber.Location = new System.Drawing.Point(130, 50);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(421, 22);
			this.textBoxPartNumber.TabIndex = 138;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(130, 163);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(421, 20);
			this.numericUpDownQuantity.TabIndex = 142;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.numericUpDownQuantity_ValueChanged);
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(27, 163);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(61, 19);
			this.labelQuantity.TabIndex = 158;
			this.labelQuantity.Text = "Quantity:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(27, 446);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 19);
			this.label2.TabIndex = 164;
			this.label2.Text = "Remarks:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductRemarks
			// 
			this.textBoxProductRemarks.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxProductRemarks.CustomButton.Image = null;
			this.textBoxProductRemarks.CustomButton.Location = new System.Drawing.Point(365, 1);
			this.textBoxProductRemarks.CustomButton.Name = "";
			this.textBoxProductRemarks.CustomButton.Size = new System.Drawing.Size(57, 57);
			this.textBoxProductRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxProductRemarks.CustomButton.TabIndex = 1;
			this.textBoxProductRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxProductRemarks.CustomButton.UseSelectable = true;
			this.textBoxProductRemarks.CustomButton.Visible = false;
			this.textBoxProductRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductRemarks.Lines = new string[0];
			this.textBoxProductRemarks.Location = new System.Drawing.Point(128, 441);
			this.textBoxProductRemarks.MaxLength = 100;
			this.textBoxProductRemarks.Multiline = true;
			this.textBoxProductRemarks.Name = "textBoxProductRemarks";
			this.textBoxProductRemarks.PasswordChar = '\0';
			this.textBoxProductRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxProductRemarks.SelectedText = "";
			this.textBoxProductRemarks.SelectionLength = 0;
			this.textBoxProductRemarks.SelectionStart = 0;
			this.textBoxProductRemarks.ShortcutsEnabled = true;
			this.textBoxProductRemarks.Size = new System.Drawing.Size(423, 59);
			this.textBoxProductRemarks.TabIndex = 148;
			this.textBoxProductRemarks.UseSelectable = true;
			this.textBoxProductRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxProductRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelSuppliers
			// 
			this.labelSuppliers.AutoSize = true;
			this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSuppliers.Location = new System.Drawing.Point(260, 503);
			this.labelSuppliers.Name = "labelSuppliers";
			this.labelSuppliers.Size = new System.Drawing.Size(75, 19);
			this.labelSuppliers.TabIndex = 163;
			this.labelSuppliers.Text = "SUPPLIERS:";
			this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(130, 136);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(421, 21);
			this.comboBoxMeasure.TabIndex = 141;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.comboBoxMeasure_SelectedIndexChanged);
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(27, 137);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 165;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(28, 520);
			this.dataGridViewControlSuppliers.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(523, 126);
			this.dataGridViewControlSuppliers.TabIndex = 149;
			this.dataGridViewControlSuppliers.Visible = false;
			// 
			// dictionaryComboProduct
			// 
			this.dictionaryComboProduct.Displayer = null;
			this.dictionaryComboProduct.DisplayerText = null;
			this.dictionaryComboProduct.Entity = null;
			this.dictionaryComboProduct.Location = new System.Drawing.Point(128, 22);
			this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboProduct.Name = "dictionaryComboProduct";
			this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboProduct.Size = new System.Drawing.Size(423, 21);
			this.dictionaryComboProduct.TabIndex = 135;
			this.dictionaryComboProduct.Type = null;
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProduct.Location = new System.Drawing.Point(25, 25);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(58, 19);
			this.labelProduct.TabIndex = 167;
			this.labelProduct.Text = "Product:";
			this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTotal.Location = new System.Drawing.Point(27, 188);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(39, 19);
			this.labelTotal.TabIndex = 168;
			this.labelTotal.Text = "Total:";
			this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTotal
			// 
			this.textBoxTotal.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxTotal.CustomButton.Image = null;
			this.textBoxTotal.CustomButton.Location = new System.Drawing.Point(403, 2);
			this.textBoxTotal.CustomButton.Name = "";
			this.textBoxTotal.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTotal.CustomButton.TabIndex = 1;
			this.textBoxTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTotal.CustomButton.UseSelectable = true;
			this.textBoxTotal.CustomButton.Visible = false;
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Lines = new string[0];
			this.textBoxTotal.Location = new System.Drawing.Point(130, 186);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.PasswordChar = '\0';
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTotal.SelectedText = "";
			this.textBoxTotal.SelectionLength = 0;
			this.textBoxTotal.SelectionStart = 0;
			this.textBoxTotal.ShortcutsEnabled = true;
			this.textBoxTotal.Size = new System.Drawing.Size(421, 20);
			this.textBoxTotal.TabIndex = 143;
			this.textBoxTotal.UseSelectable = true;
			this.textBoxTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// lifelengthViewerNotify
			// 
			this.lifelengthViewerNotify.AutoSize = true;
			this.lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerNotify.CalendarApplicable = false;
			this.lifelengthViewerNotify.CyclesApplicable = false;
			this.lifelengthViewerNotify.EnabledCalendar = true;
			this.lifelengthViewerNotify.EnabledCycle = false;
			this.lifelengthViewerNotify.EnabledHours = false;
			this.lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderHours = "Hours";
			this.lifelengthViewerNotify.HoursApplicable = false;
			this.lifelengthViewerNotify.LeftHeader = "";
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(119, 406);
			this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerNotify.Modified = false;
			this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
			this.lifelengthViewerNotify.ReadOnly = false;
			this.lifelengthViewerNotify.ShowCalendar = true;
			this.lifelengthViewerNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerNotify.ShowHeaders = false;
			this.lifelengthViewerNotify.ShowMinutes = false;
			this.lifelengthViewerNotify.Size = new System.Drawing.Size(358, 35);
			this.lifelengthViewerNotify.SystemCalculated = true;
			this.lifelengthViewerNotify.TabIndex = 147;
			// 
			// lifelengthViewerLifeLimit
			// 
			this.lifelengthViewerLifeLimit.AutoSize = true;
			this.lifelengthViewerLifeLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerLifeLimit.CalendarApplicable = false;
			this.lifelengthViewerLifeLimit.CyclesApplicable = false;
			this.lifelengthViewerLifeLimit.EnabledCalendar = true;
			this.lifelengthViewerLifeLimit.EnabledCycle = false;
			this.lifelengthViewerLifeLimit.EnabledHours = false;
			this.lifelengthViewerLifeLimit.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerLifeLimit.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerLifeLimit.HeaderCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderCycles = "Cycles";
			this.lifelengthViewerLifeLimit.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderHours = "Hours";
			this.lifelengthViewerLifeLimit.HoursApplicable = false;
			this.lifelengthViewerLifeLimit.LeftHeader = "";
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(119, 355);
			this.lifelengthViewerLifeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerLifeLimit.Modified = false;
			this.lifelengthViewerLifeLimit.Name = "lifelengthViewerLifeLimit";
			this.lifelengthViewerLifeLimit.ReadOnly = false;
			this.lifelengthViewerLifeLimit.ShowCalendar = true;
			this.lifelengthViewerLifeLimit.ShowFormattedCalendar = false;
			this.lifelengthViewerLifeLimit.ShowMinutes = false;
			this.lifelengthViewerLifeLimit.Size = new System.Drawing.Size(358, 52);
			this.lifelengthViewerLifeLimit.SystemCalculated = true;
			this.lifelengthViewerLifeLimit.TabIndex = 146;
			// 
			// comboBoxDefferedCategory
			// 
			this.comboBoxDefferedCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDefferedCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDefferedCategory.FormattingEnabled = true;
			this.comboBoxDefferedCategory.Location = new System.Drawing.Point(130, 274);
			this.comboBoxDefferedCategory.Name = "comboBoxDefferedCategory";
			this.comboBoxDefferedCategory.Size = new System.Drawing.Size(421, 25);
			this.comboBoxDefferedCategory.TabIndex = 145;
			// 
			// labelDefferedCategory
			// 
			this.labelDefferedCategory.AutoSize = true;
			this.labelDefferedCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDefferedCategory.Location = new System.Drawing.Point(27, 276);
			this.labelDefferedCategory.Name = "labelDefferedCategory";
			this.labelDefferedCategory.Size = new System.Drawing.Size(67, 19);
			this.labelDefferedCategory.TabIndex = 161;
			this.labelDefferedCategory.Text = "Category:";
			// 
			// labelReason
			// 
			this.labelReason.AutoSize = true;
			this.labelReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReason.Location = new System.Drawing.Point(27, 215);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(54, 19);
			this.labelReason.TabIndex = 170;
			this.labelReason.Text = "Reason:";
			// 
			// comboBoxReason
			// 
			this.comboBoxReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxReason.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxReason.FormattingEnabled = true;
			this.comboBoxReason.Location = new System.Drawing.Point(130, 212);
			this.comboBoxReason.Name = "comboBoxReason";
			this.comboBoxReason.Size = new System.Drawing.Size(421, 25);
			this.comboBoxReason.TabIndex = 169;
			// 
			// labelDestination
			// 
			this.labelDestination.AutoSize = true;
			this.labelDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDestination.Location = new System.Drawing.Point(27, 245);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(76, 19);
			this.labelDestination.TabIndex = 172;
			this.labelDestination.Text = "Destination:";
			// 
			// comboBoxDestination
			// 
			this.comboBoxDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDestination.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDestination.FormattingEnabled = true;
			this.comboBoxDestination.Location = new System.Drawing.Point(130, 243);
			this.comboBoxDestination.Name = "comboBoxDestination";
			this.comboBoxDestination.Size = new System.Drawing.Size(421, 25);
			this.comboBoxDestination.TabIndex = 171;
			this.comboBoxDestination.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestination_SelectedIndexChanged);
			// 
			// checkBoxRepair
			// 
			this.checkBoxRepair.AutoSize = true;
			this.checkBoxRepair.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRepair.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRepair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxRepair.Location = new System.Drawing.Point(405, 331);
			this.checkBoxRepair.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxRepair.Name = "checkBoxRepair";
			this.checkBoxRepair.Size = new System.Drawing.Size(71, 21);
			this.checkBoxRepair.TabIndex = 153;
			this.checkBoxRepair.Text = "Repair";
			this.checkBoxRepair.UseVisualStyleBackColor = true;
			// 
			// checkBoxOverhaul
			// 
			this.checkBoxOverhaul.AutoSize = true;
			this.checkBoxOverhaul.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxOverhaul.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxOverhaul.Location = new System.Drawing.Point(325, 331);
			this.checkBoxOverhaul.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxOverhaul.Name = "checkBoxOverhaul";
			this.checkBoxOverhaul.Size = new System.Drawing.Size(48, 21);
			this.checkBoxOverhaul.TabIndex = 152;
			this.checkBoxOverhaul.Text = "OH";
			this.checkBoxOverhaul.UseVisualStyleBackColor = true;
			// 
			// checkBoxServiceable
			// 
			this.checkBoxServiceable.AutoSize = true;
			this.checkBoxServiceable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxServiceable.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxServiceable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxServiceable.Location = new System.Drawing.Point(222, 331);
			this.checkBoxServiceable.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxServiceable.Name = "checkBoxServiceable";
			this.checkBoxServiceable.Size = new System.Drawing.Size(63, 21);
			this.checkBoxServiceable.TabIndex = 151;
			this.checkBoxServiceable.Text = "Serv.";
			this.checkBoxServiceable.UseVisualStyleBackColor = true;
			// 
			// checkBoxNew
			// 
			this.checkBoxNew.AutoSize = true;
			this.checkBoxNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxNew.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxNew.Location = new System.Drawing.Point(130, 331);
			this.checkBoxNew.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxNew.Name = "checkBoxNew";
			this.checkBoxNew.Size = new System.Drawing.Size(56, 21);
			this.checkBoxNew.TabIndex = 150;
			this.checkBoxNew.Text = "New";
			this.checkBoxNew.UseVisualStyleBackColor = true;
			// 
			// labelPriority
			// 
			this.labelPriority.AutoSize = true;
			this.labelPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPriority.Location = new System.Drawing.Point(27, 377);
			this.labelPriority.Name = "labelPriority";
			this.labelPriority.Size = new System.Drawing.Size(54, 19);
			this.labelPriority.TabIndex = 173;
			this.labelPriority.Text = "Priority:";
			// 
			// labelNotify
			// 
			this.labelNotify.AutoSize = true;
			this.labelNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNotify.Location = new System.Drawing.Point(27, 415);
			this.labelNotify.Name = "labelNotify";
			this.labelNotify.Size = new System.Drawing.Size(47, 19);
			this.labelNotify.TabIndex = 174;
			this.labelNotify.Text = "Notify:";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(8, 449);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 23);
			this.label3.TabIndex = 249;
			this.label3.Text = "Type of Operation:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxTypeOfOperation
			// 
			this.comboBoxTypeOfOperation.FormattingEnabled = true;
			this.comboBoxTypeOfOperation.Location = new System.Drawing.Point(141, 449);
			this.comboBoxTypeOfOperation.Name = "comboBoxTypeOfOperation";
			this.comboBoxTypeOfOperation.Size = new System.Drawing.Size(229, 21);
			this.comboBoxTypeOfOperation.TabIndex = 250;
			// 
			// comboBoxApprovedBy
			// 
			this.comboBoxApprovedBy.FormattingEnabled = true;
			this.comboBoxApprovedBy.Location = new System.Drawing.Point(141, 698);
			this.comboBoxApprovedBy.Name = "comboBoxApprovedBy";
			this.comboBoxApprovedBy.Size = new System.Drawing.Size(229, 21);
			this.comboBoxApprovedBy.TabIndex = 252;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(8, 698);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 23);
			this.label4.TabIndex = 251;
			this.label4.Text = "Approved By:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxPublishedBy
			// 
			this.comboBoxPublishedBy.FormattingEnabled = true;
			this.comboBoxPublishedBy.Location = new System.Drawing.Point(141, 725);
			this.comboBoxPublishedBy.Name = "comboBoxPublishedBy";
			this.comboBoxPublishedBy.Size = new System.Drawing.Size(229, 21);
			this.comboBoxPublishedBy.TabIndex = 254;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(8, 725);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 23);
			this.label5.TabIndex = 253;
			this.label5.Text = "Published By:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxClosedBy
			// 
			this.comboBoxClosedBy.FormattingEnabled = true;
			this.comboBoxClosedBy.Location = new System.Drawing.Point(141, 751);
			this.comboBoxClosedBy.Name = "comboBoxClosedBy";
			this.comboBoxClosedBy.Size = new System.Drawing.Size(229, 21);
			this.comboBoxClosedBy.TabIndex = 256;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(8, 751);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 23);
			this.label6.TabIndex = 255;
			this.label6.Text = "Closed By:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRFQ
			// 
			// 
			// 
			// 
			this.textBoxRFQ.CustomButton.Image = null;
			this.textBoxRFQ.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxRFQ.CustomButton.Name = "";
			this.textBoxRFQ.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxRFQ.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRFQ.CustomButton.TabIndex = 1;
			this.textBoxRFQ.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRFQ.CustomButton.UseSelectable = true;
			this.textBoxRFQ.CustomButton.Visible = false;
			this.textBoxRFQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRFQ.Lines = new string[0];
			this.textBoxRFQ.Location = new System.Drawing.Point(461, 448);
			this.textBoxRFQ.MaxLength = 32767;
			this.textBoxRFQ.Name = "textBoxRFQ";
			this.textBoxRFQ.PasswordChar = '\0';
			this.textBoxRFQ.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRFQ.SelectedText = "";
			this.textBoxRFQ.SelectionLength = 0;
			this.textBoxRFQ.SelectionStart = 0;
			this.textBoxRFQ.ShortcutsEnabled = true;
			this.textBoxRFQ.Size = new System.Drawing.Size(229, 22);
			this.textBoxRFQ.TabIndex = 257;
			this.textBoxRFQ.UseSelectable = true;
			this.textBoxRFQ.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRFQ.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label7.Location = new System.Drawing.Point(384, 448);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 23);
			this.label7.TabIndex = 258;
			this.label7.Text = "RFQ №:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxQR
			// 
			// 
			// 
			// 
			this.textBoxQR.CustomButton.Image = null;
			this.textBoxQR.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxQR.CustomButton.Name = "";
			this.textBoxQR.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxQR.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxQR.CustomButton.TabIndex = 1;
			this.textBoxQR.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxQR.CustomButton.UseSelectable = true;
			this.textBoxQR.CustomButton.Visible = false;
			this.textBoxQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxQR.Lines = new string[0];
			this.textBoxQR.Location = new System.Drawing.Point(461, 476);
			this.textBoxQR.MaxLength = 32767;
			this.textBoxQR.Name = "textBoxQR";
			this.textBoxQR.PasswordChar = '\0';
			this.textBoxQR.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxQR.SelectedText = "";
			this.textBoxQR.SelectionLength = 0;
			this.textBoxQR.SelectionStart = 0;
			this.textBoxQR.ShortcutsEnabled = true;
			this.textBoxQR.Size = new System.Drawing.Size(229, 22);
			this.textBoxQR.TabIndex = 259;
			this.textBoxQR.UseSelectable = true;
			this.textBoxQR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxQR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label8.Location = new System.Drawing.Point(384, 476);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 23);
			this.label8.TabIndex = 260;
			this.label8.Text = "QR №:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPO
			// 
			// 
			// 
			// 
			this.textBoxPO.CustomButton.Image = null;
			this.textBoxPO.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxPO.CustomButton.Name = "";
			this.textBoxPO.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxPO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPO.CustomButton.TabIndex = 1;
			this.textBoxPO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPO.CustomButton.UseSelectable = true;
			this.textBoxPO.CustomButton.Visible = false;
			this.textBoxPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPO.Lines = new string[0];
			this.textBoxPO.Location = new System.Drawing.Point(461, 502);
			this.textBoxPO.MaxLength = 32767;
			this.textBoxPO.Name = "textBoxPO";
			this.textBoxPO.PasswordChar = '\0';
			this.textBoxPO.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPO.SelectedText = "";
			this.textBoxPO.SelectionLength = 0;
			this.textBoxPO.SelectionStart = 0;
			this.textBoxPO.ShortcutsEnabled = true;
			this.textBoxPO.Size = new System.Drawing.Size(229, 22);
			this.textBoxPO.TabIndex = 261;
			this.textBoxPO.UseSelectable = true;
			this.textBoxPO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label9.Location = new System.Drawing.Point(384, 501);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 23);
			this.label9.TabIndex = 262;
			this.label9.Text = "PO №:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxInvoice
			// 
			// 
			// 
			// 
			this.textBoxInvoice.CustomButton.Image = null;
			this.textBoxInvoice.CustomButton.Location = new System.Drawing.Point(209, 2);
			this.textBoxInvoice.CustomButton.Name = "";
			this.textBoxInvoice.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxInvoice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxInvoice.CustomButton.TabIndex = 1;
			this.textBoxInvoice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxInvoice.CustomButton.UseSelectable = true;
			this.textBoxInvoice.CustomButton.Visible = false;
			this.textBoxInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxInvoice.Lines = new string[0];
			this.textBoxInvoice.Location = new System.Drawing.Point(461, 530);
			this.textBoxInvoice.MaxLength = 32767;
			this.textBoxInvoice.Name = "textBoxInvoice";
			this.textBoxInvoice.PasswordChar = '\0';
			this.textBoxInvoice.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxInvoice.SelectedText = "";
			this.textBoxInvoice.SelectionLength = 0;
			this.textBoxInvoice.SelectionStart = 0;
			this.textBoxInvoice.ShortcutsEnabled = true;
			this.textBoxInvoice.Size = new System.Drawing.Size(229, 22);
			this.textBoxInvoice.TabIndex = 263;
			this.textBoxInvoice.UseSelectable = true;
			this.textBoxInvoice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxInvoice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label10
			// 
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label10.Location = new System.Drawing.Point(384, 530);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 23);
			this.label10.TabIndex = 264;
			this.label10.Text = "Invoice:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxShipBy
			// 
			this.comboBoxShipBy.FormattingEnabled = true;
			this.comboBoxShipBy.Location = new System.Drawing.Point(461, 558);
			this.comboBoxShipBy.Name = "comboBoxShipBy";
			this.comboBoxShipBy.Size = new System.Drawing.Size(229, 21);
			this.comboBoxShipBy.TabIndex = 266;
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label11.Location = new System.Drawing.Point(384, 558);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 23);
			this.label11.TabIndex = 265;
			this.label11.Text = "Ship By:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxShipTo
			// 
			this.textBoxShipTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxShipTo.CustomButton.Image = null;
			this.textBoxShipTo.CustomButton.Location = new System.Drawing.Point(185, 1);
			this.textBoxShipTo.CustomButton.Name = "";
			this.textBoxShipTo.CustomButton.Size = new System.Drawing.Size(43, 43);
			this.textBoxShipTo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxShipTo.CustomButton.TabIndex = 1;
			this.textBoxShipTo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxShipTo.CustomButton.UseSelectable = true;
			this.textBoxShipTo.CustomButton.Visible = false;
			this.textBoxShipTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxShipTo.Lines = new string[0];
			this.textBoxShipTo.Location = new System.Drawing.Point(461, 584);
			this.textBoxShipTo.MaxLength = 32767;
			this.textBoxShipTo.Multiline = true;
			this.textBoxShipTo.Name = "textBoxShipTo";
			this.textBoxShipTo.PasswordChar = '\0';
			this.textBoxShipTo.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxShipTo.SelectedText = "";
			this.textBoxShipTo.SelectionLength = 0;
			this.textBoxShipTo.SelectionStart = 0;
			this.textBoxShipTo.ShortcutsEnabled = true;
			this.textBoxShipTo.Size = new System.Drawing.Size(229, 45);
			this.textBoxShipTo.TabIndex = 268;
			this.textBoxShipTo.UseSelectable = true;
			this.textBoxShipTo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxShipTo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelShipTo
			// 
			this.labelShipTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelShipTo.Location = new System.Drawing.Point(384, 584);
			this.labelShipTo.Name = "labelShipTo";
			this.labelShipTo.Size = new System.Drawing.Size(69, 23);
			this.labelShipTo.TabIndex = 267;
			this.labelShipTo.Text = "Ship To:";
			this.labelShipTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxIncoTerm
			// 
			this.comboBoxIncoTerm.FormattingEnabled = true;
			this.comboBoxIncoTerm.Location = new System.Drawing.Point(461, 635);
			this.comboBoxIncoTerm.Name = "comboBoxIncoTerm";
			this.comboBoxIncoTerm.Size = new System.Drawing.Size(229, 21);
			this.comboBoxIncoTerm.TabIndex = 270;
			// 
			// label13
			// 
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label13.Location = new System.Drawing.Point(384, 635);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(69, 23);
			this.label13.TabIndex = 269;
			this.label13.Text = "Inco Term:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label14.Location = new System.Drawing.Point(384, 661);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(69, 23);
			this.label14.TabIndex = 271;
			this.label14.Text = "Country:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxCarrier
			// 
			this.comboBoxCarrier.FormattingEnabled = true;
			this.comboBoxCarrier.Location = new System.Drawing.Point(461, 686);
			this.comboBoxCarrier.Name = "comboBoxCarrier";
			this.comboBoxCarrier.Size = new System.Drawing.Size(229, 21);
			this.comboBoxCarrier.TabIndex = 274;
			// 
			// label15
			// 
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label15.Location = new System.Drawing.Point(384, 686);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(69, 23);
			this.label15.TabIndex = 273;
			this.label15.Text = "Carrier:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPickUp
			// 
			this.textBoxPickUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxPickUp.CustomButton.Image = null;
			this.textBoxPickUp.CustomButton.Location = new System.Drawing.Point(185, 1);
			this.textBoxPickUp.CustomButton.Name = "";
			this.textBoxPickUp.CustomButton.Size = new System.Drawing.Size(43, 43);
			this.textBoxPickUp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPickUp.CustomButton.TabIndex = 1;
			this.textBoxPickUp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPickUp.CustomButton.UseSelectable = true;
			this.textBoxPickUp.CustomButton.Visible = false;
			this.textBoxPickUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPickUp.Lines = new string[0];
			this.textBoxPickUp.Location = new System.Drawing.Point(461, 712);
			this.textBoxPickUp.MaxLength = 32767;
			this.textBoxPickUp.Multiline = true;
			this.textBoxPickUp.Name = "textBoxPickUp";
			this.textBoxPickUp.PasswordChar = '\0';
			this.textBoxPickUp.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPickUp.SelectedText = "";
			this.textBoxPickUp.SelectionLength = 0;
			this.textBoxPickUp.SelectionStart = 0;
			this.textBoxPickUp.ShortcutsEnabled = true;
			this.textBoxPickUp.Size = new System.Drawing.Size(229, 45);
			this.textBoxPickUp.TabIndex = 276;
			this.textBoxPickUp.UseSelectable = true;
			this.textBoxPickUp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPickUp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label16
			// 
			this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label16.Location = new System.Drawing.Point(384, 712);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(69, 23);
			this.label16.TabIndex = 275;
			this.label16.Text = "Pick Up:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxWeight
			// 
			// 
			// 
			// 
			this.textBoxWeight.CustomButton.Image = null;
			this.textBoxWeight.CustomButton.Location = new System.Drawing.Point(54, 2);
			this.textBoxWeight.CustomButton.Name = "";
			this.textBoxWeight.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxWeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxWeight.CustomButton.TabIndex = 1;
			this.textBoxWeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxWeight.CustomButton.UseSelectable = true;
			this.textBoxWeight.CustomButton.Visible = false;
			this.textBoxWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxWeight.Lines = new string[0];
			this.textBoxWeight.Location = new System.Drawing.Point(461, 763);
			this.textBoxWeight.MaxLength = 32767;
			this.textBoxWeight.Name = "textBoxWeight";
			this.textBoxWeight.PasswordChar = '\0';
			this.textBoxWeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxWeight.SelectedText = "";
			this.textBoxWeight.SelectionLength = 0;
			this.textBoxWeight.SelectionStart = 0;
			this.textBoxWeight.ShortcutsEnabled = true;
			this.textBoxWeight.Size = new System.Drawing.Size(74, 22);
			this.textBoxWeight.TabIndex = 277;
			this.textBoxWeight.UseSelectable = true;
			this.textBoxWeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxWeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label17
			// 
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label17.Location = new System.Drawing.Point(384, 763);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(69, 23);
			this.label17.TabIndex = 278;
			this.label17.Text = "Weight:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDIMS
			// 
			// 
			// 
			// 
			this.textBoxDIMS.CustomButton.Image = null;
			this.textBoxDIMS.CustomButton.Location = new System.Drawing.Point(86, 2);
			this.textBoxDIMS.CustomButton.Name = "";
			this.textBoxDIMS.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxDIMS.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDIMS.CustomButton.TabIndex = 1;
			this.textBoxDIMS.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDIMS.CustomButton.UseSelectable = true;
			this.textBoxDIMS.CustomButton.Visible = false;
			this.textBoxDIMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDIMS.Lines = new string[0];
			this.textBoxDIMS.Location = new System.Drawing.Point(584, 763);
			this.textBoxDIMS.MaxLength = 32767;
			this.textBoxDIMS.Name = "textBoxDIMS";
			this.textBoxDIMS.PasswordChar = '\0';
			this.textBoxDIMS.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDIMS.SelectedText = "";
			this.textBoxDIMS.SelectionLength = 0;
			this.textBoxDIMS.SelectionStart = 0;
			this.textBoxDIMS.ShortcutsEnabled = true;
			this.textBoxDIMS.Size = new System.Drawing.Size(106, 22);
			this.textBoxDIMS.TabIndex = 279;
			this.textBoxDIMS.UseSelectable = true;
			this.textBoxDIMS.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDIMS.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label18.Location = new System.Drawing.Point(537, 763);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(47, 23);
			this.label18.TabIndex = 280;
			this.label18.Text = "DIMS:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listViewInitialItems
			// 
			this.listViewInitialItems.Displayer = null;
			this.listViewInitialItems.DisplayerText = null;
			this.listViewInitialItems.Entity = null;
			this.listViewInitialItems.IgnoreEnterPress = false;
			this.listViewInitialItems.Location = new System.Drawing.Point(16, 266);
			this.listViewInitialItems.MenuOpeningAction = null;
			this.listViewInitialItems.Name = "listViewInitialItems";
			this.listViewInitialItems.OldColumnIndex = 0;
			this.listViewInitialItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewInitialItems.Size = new System.Drawing.Size(684, 166);
			this.listViewInitialItems.SortMultiplier = 0;
			this.listViewInitialItems.TabIndex = 247;
			this.listViewInitialItems.Visible = false;
			this.listViewInitialItems.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewAddedItems_SelectedItemsChanged);
			// 
			// listViewKits
			// 
			this.listViewKits.Displayer = null;
			this.listViewKits.DisplayerText = null;
			this.listViewKits.Entity = null;
			this.listViewKits.IgnoreEnterPress = false;
			this.listViewKits.Location = new System.Drawing.Point(16, 89);
			this.listViewKits.MenuOpeningAction = null;
			this.listViewKits.Name = "listViewKits";
			this.listViewKits.OldColumnIndex = 2;
			this.listViewKits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewKits.Size = new System.Drawing.Size(687, 155);
			this.listViewKits.SortMultiplier = 1;
			this.listViewKits.TabIndex = 67;
			// 
			// comboBoxCountry
			// 
			this.comboBoxCountry.FormattingEnabled = true;
			this.comboBoxCountry.Location = new System.Drawing.Point(461, 661);
			this.comboBoxCountry.Name = "comboBoxCountry";
			this.comboBoxCountry.Size = new System.Drawing.Size(229, 21);
			this.comboBoxCountry.TabIndex = 281;
			// 
			// listViewQuatationItems
			// 
			this.listViewQuatationItems.Displayer = null;
			this.listViewQuatationItems.DisplayerText = null;
			this.listViewQuatationItems.Entity = null;
			this.listViewQuatationItems.IgnoreEnterPress = false;
			this.listViewQuatationItems.Location = new System.Drawing.Point(16, 266);
			this.listViewQuatationItems.MenuOpeningAction = null;
			this.listViewQuatationItems.Name = "listViewQuatationItems";
			this.listViewQuatationItems.OldColumnIndex = 0;
			this.listViewQuatationItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewQuatationItems.Size = new System.Drawing.Size(684, 166);
			this.listViewQuatationItems.SortMultiplier = 0;
			this.listViewQuatationItems.TabIndex = 282;
			this.listViewQuatationItems.Visible = false;
			this.listViewQuatationItems.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewQuatationItems_SelectedItemsChanged);
			// 
			// OrderAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1276, 793);
			this.Controls.Add(this.listViewQuatationItems);
			this.Controls.Add(this.comboBoxCountry);
			this.Controls.Add(this.textBoxDIMS);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.textBoxWeight);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.textBoxPickUp);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.comboBoxCarrier);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.comboBoxIncoTerm);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBoxShipTo);
			this.Controls.Add(this.labelShipTo);
			this.Controls.Add(this.comboBoxShipBy);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxInvoice);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxPO);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxQR);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBoxRFQ);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.comboBoxClosedBy);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBoxPublishedBy);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBoxApprovedBy);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxTypeOfOperation);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listViewInitialItems);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.listViewKits);
			this.Controls.Add(this.labelSearchSupplier);
			this.Controls.Add(this.textBoxSearchSupplier);
			this.Controls.Add(this.labelSearchPartNumber);
			this.Controls.Add(this.textBoxSearchPartNumber);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.dateTimePickerOpeningDate);
			this.Controls.Add(this.textBoxAuthor);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.labelOpeningDate);
			this.Controls.Add(this.labelAuthor);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.labelQOTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(770, 460);
			this.Name = "OrderAddForm";
			this.ShowIcon = false;
			this.Text = "Initional Order Kit Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private MetroTextBox textBoxRemarks;
		private System.Windows.Forms.DateTimePicker dateTimePickerOpeningDate;
		private MetroTextBox textBoxAuthor;
		private MetroTextBox textBoxDescription;
		private MetroLabel labelRemarks;
		private MetroTextBox textBoxTitle;
		private MetroLabel labelOpeningDate;
		private MetroLabel labelAuthor;
		private MetroLabel labelDescription;
		private MetroLabel labelQOTitle;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelKitSelection;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private MetroLabel labelSearchPartNumber;
		private MetroTextBox textBoxSearchPartNumber;
		private MetroLabel labelSearchSupplier;
		private MetroTextBox textBoxSearchSupplier;
		private Quatation.RequestProductListView listViewKits;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private Initial.InitialOrderListView listViewInitialItems;
		private System.Windows.Forms.GroupBox groupBox1;
		private MetroLabel label1;
		private MetroTextBox textBoxProductDesc;
		private MetroLabel labelPartNumber;
		private MetroTextBox textBoxPartNumber;
		private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private MetroLabel labelQuantity;
		private MetroLabel label2;
		private MetroTextBox textBoxProductRemarks;
		private MetroLabel labelSuppliers;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private MetroLabel labelMeasure;
		private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
		private Auxiliary.LookupCombobox dictionaryComboProduct;
		private MetroLabel labelProduct;
		private MetroLabel labelTotal;
		private MetroTextBox textBoxTotal;
		private Auxiliary.LifelengthViewer lifelengthViewerNotify;
		private Auxiliary.LifelengthViewer lifelengthViewerLifeLimit;
		private System.Windows.Forms.ComboBox comboBoxDefferedCategory;
		private MetroLabel labelDefferedCategory;
		private MetroLabel labelReason;
		private System.Windows.Forms.ComboBox comboBoxReason;
		private MetroLabel labelDestination;
		private System.Windows.Forms.ComboBox comboBoxDestination;
		private System.Windows.Forms.CheckBox checkBoxRepair;
		private System.Windows.Forms.CheckBox checkBoxOverhaul;
		private System.Windows.Forms.CheckBox checkBoxServiceable;
		private System.Windows.Forms.CheckBox checkBoxNew;
		private MetroLabel labelPriority;
		private MetroLabel labelNotify;
		private System.Windows.Forms.Button button1;
		private MetroLabel label3;
		private System.Windows.Forms.ComboBox comboBoxTypeOfOperation;
		private System.Windows.Forms.ComboBox comboBoxApprovedBy;
		private MetroLabel label4;
		private System.Windows.Forms.ComboBox comboBoxPublishedBy;
		private MetroLabel label5;
		private System.Windows.Forms.ComboBox comboBoxClosedBy;
		private MetroLabel label6;
		private MetroTextBox textBoxRFQ;
		private MetroLabel label7;
		private MetroTextBox textBoxQR;
		private MetroLabel label8;
		private MetroTextBox textBoxPO;
		private MetroLabel label9;
		private MetroTextBox textBoxInvoice;
		private MetroLabel label10;
		private System.Windows.Forms.ComboBox comboBoxShipBy;
		private MetroLabel label11;
		private MetroTextBox textBoxShipTo;
		private MetroLabel labelShipTo;
		private System.Windows.Forms.ComboBox comboBoxIncoTerm;
		private MetroLabel label13;
		private MetroLabel label14;
		private System.Windows.Forms.ComboBox comboBoxCarrier;
		private MetroLabel label15;
		private MetroTextBox textBoxPickUp;
		private MetroLabel label16;
		private MetroTextBox textBoxWeight;
		private MetroLabel label17;
		private MetroTextBox textBoxDIMS;
		private MetroLabel label18;
		private System.Windows.Forms.ComboBox comboBoxPriority;
		private MetroLabel label19;
		private System.Windows.Forms.ComboBox comboBoxCountry;
		private Quatation.QuatationOrderListView listViewQuatationItems;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}