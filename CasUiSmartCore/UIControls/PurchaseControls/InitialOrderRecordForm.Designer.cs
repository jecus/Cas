using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls
{
	partial class InitialOrderRecordForm
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

			dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;
			dictionaryComboStandard.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;
			comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
			comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;
			comboBoxDestination.SelectedIndexChanged -= ComboBoxDestinationSelectedIndexChanged;
			comboBoxReason.SelectedIndexChanged -= ComboBoxReasonSelectedIndexChanged;
			comboBoxDefferedCategory.SelectedIndexChanged -= ComboBoxDeferredCategorySelectedIndexChanged;
			numericUpDownQuantity.ValueChanged -= NumericUpDownQuantityValueChanged;

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialOrderRecordForm));
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelClass = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelPartNumber = new System.Windows.Forms.Label();
			this.textBoxPartNumber = new System.Windows.Forms.TextBox();
			this.labelStandart = new System.Windows.Forms.Label();
			this.dictionaryComboStandard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelSuppliers = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.labelProductCode = new System.Windows.Forms.Label();
			this.textBoxProductCode = new System.Windows.Forms.TextBox();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelProduct = new System.Windows.Forms.Label();
			this.labelTotal = new System.Windows.Forms.Label();
			this.textBoxTotal = new System.Windows.Forms.TextBox();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelEffDate = new System.Windows.Forms.Label();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxDefferedCategory = new System.Windows.Forms.ComboBox();
			this.labelDefferedCategory = new System.Windows.Forms.Label();
			this.comboBoxReason = new System.Windows.Forms.ComboBox();
			this.labelReason = new System.Windows.Forms.Label();
			this.comboBoxDestination = new System.Windows.Forms.ComboBox();
			this.labelDestination = new System.Windows.Forms.Label();
			this.checkBoxRepair = new System.Windows.Forms.CheckBox();
			this.checkBoxOverhaul = new System.Windows.Forms.CheckBox();
			this.checkBoxServiceable = new System.Windows.Forms.CheckBox();
			this.checkBoxNew = new System.Windows.Forms.CheckBox();
			this.labelPriority = new System.Windows.Forms.Label();
			this.labelNotify = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 106;
			this.comboBoxDetailClass.Enabled = false;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(109, 59);
			this.comboBoxDetailClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(347, 21);
			this.comboBoxDetailClass.TabIndex = 2;
			this.comboBoxDetailClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailClassSelectedIndexChanged);
			this.comboBoxDetailClass.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelClass
			// 
			this.labelClass.AutoSize = true;
			this.labelClass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClass.Location = new System.Drawing.Point(6, 63);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(47, 14);
			this.labelClass.TabIndex = 99;
			this.labelClass.Text = "Class:";
			this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(6, 116);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(87, 14);
			this.labelDescription.TabIndex = 81;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Enabled = false;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(109, 114);
			this.textBoxDescription.MaxLength = 128;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(348, 52);
			this.textBoxDescription.TabIndex = 4;
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.AutoSize = true;
			this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(6, 89);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(39, 14);
			this.labelPartNumber.TabIndex = 79;
			this.labelPartNumber.Text = "P/N:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			this.textBoxPartNumber.Enabled = false;
			this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNumber.Location = new System.Drawing.Point(109, 86);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.Size = new System.Drawing.Size(347, 22);
			this.textBoxPartNumber.TabIndex = 3;
			// 
			// labelStandart
			// 
			this.labelStandart.AutoSize = true;
			this.labelStandart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStandart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStandart.Location = new System.Drawing.Point(6, 35);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 14);
			this.labelStandart.TabIndex = 88;
			this.labelStandart.Text = "Standart:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dictionaryComboStandard
			// 
			this.dictionaryComboStandard.Displayer = null;
			this.dictionaryComboStandard.DisplayerText = null;
			this.dictionaryComboStandard.Enabled = false;
			this.dictionaryComboStandard.Entity = null;
			this.dictionaryComboStandard.Location = new System.Drawing.Point(109, 32);
			this.dictionaryComboStandard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dictionaryComboStandard.Name = "dictionaryComboStandard";
			this.dictionaryComboStandard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboStandard.Size = new System.Drawing.Size(350, 21);
			this.dictionaryComboStandard.TabIndex = 1;
			this.dictionaryComboStandard.Type = null;
			this.dictionaryComboStandard.SelectedIndexChanged += new System.EventHandler(this.DictComboDescriptionSelectedIndexChanged);
			this.dictionaryComboStandard.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(109, 255);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(347, 20);
			this.numericUpDownQuantity.TabIndex = 7;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.NumericUpDownQuantityValueChanged);
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(6, 255);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(66, 14);
			this.labelQuantity.TabIndex = 103;
			this.labelQuantity.Text = "Quantity:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(6, 544);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(66, 14);
			this.labelRemarks.TabIndex = 111;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(109, 542);
			this.textBoxRemarks.MaxLength = 100;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(347, 90);
			this.textBoxRemarks.TabIndex = 13;
			this.textBoxRemarks.Text = "Line1\r\nLin2\r\nLine3\r\nLine4\r\nLine5\r\nLine 6";
			// 
			// labelSuppliers
			// 
			this.labelSuppliers.AutoSize = true;
			this.labelSuppliers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSuppliers.Location = new System.Drawing.Point(198, 635);
			this.labelSuppliers.Name = "labelSuppliers";
			this.labelSuppliers.Size = new System.Drawing.Size(81, 14);
			this.labelSuppliers.TabIndex = 110;
			this.labelSuppliers.Text = "SUPPLIERS:";
			this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(6, 202);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(95, 14);
			this.labelManufacturer.TabIndex = 109;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(109, 200);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(348, 22);
			this.textBoxManufacturer.TabIndex = 5;
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(109, 228);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(348, 21);
			this.comboBoxMeasure.TabIndex = 6;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
			this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(6, 229);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(68, 14);
			this.labelMeasure.TabIndex = 112;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelProductCode
			// 
			this.labelProductCode.AutoSize = true;
			this.labelProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProductCode.Location = new System.Drawing.Point(6, 175);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(97, 14);
			this.labelProductCode.TabIndex = 113;
			this.labelProductCode.Text = "Product Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductCode.Location = new System.Drawing.Point(109, 172);
			this.textBoxProductCode.MaxLength = 128;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.Size = new System.Drawing.Size(348, 22);
			this.textBoxProductCode.TabIndex = 104;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(8, 653);
			this.dataGridViewControlSuppliers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReadOnly = true;
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowAddNew = false;
			this.dataGridViewControlSuppliers.ShowDelete = false;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(447, 131);
			this.dataGridViewControlSuppliers.TabIndex = 14;
			// 
			// dictionaryComboProduct
			// 
			this.dictionaryComboProduct.Displayer = null;
			this.dictionaryComboProduct.DisplayerText = null;
			this.dictionaryComboProduct.Entity = null;
			this.dictionaryComboProduct.Location = new System.Drawing.Point(109, 4);
			this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dictionaryComboProduct.Name = "dictionaryComboProduct";
			this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboProduct.Size = new System.Drawing.Size(347, 21);
			this.dictionaryComboProduct.TabIndex = 0;
			this.dictionaryComboProduct.Type = null;
			this.dictionaryComboProduct.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
			this.dictionaryComboProduct.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProduct.Location = new System.Drawing.Point(6, 7);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(63, 14);
			this.labelProduct.TabIndex = 115;
			this.labelProduct.Text = "Product:";
			this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTotal.Location = new System.Drawing.Point(6, 283);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(43, 14);
			this.labelTotal.TabIndex = 128;
			this.labelTotal.Text = "Total:";
			this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTotal
			// 
			this.textBoxTotal.BackColor = System.Drawing.Color.White;
			this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Location = new System.Drawing.Point(109, 281);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.Size = new System.Drawing.Size(348, 20);
			this.textBoxTotal.TabIndex = 8;
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
			this.lifelengthViewerNotify.HeaderHours = "Hours";
			this.lifelengthViewerNotify.HoursApplicable = false;
			this.lifelengthViewerNotify.LeftHeader = "";
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(98, 504);
			this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerNotify.Modified = false;
			this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
			this.lifelengthViewerNotify.ReadOnly = false;
			this.lifelengthViewerNotify.ShowCalendar = true;
			this.lifelengthViewerNotify.ShowHeaders = false;
			this.lifelengthViewerNotify.ShowMinutes = false;
			this.lifelengthViewerNotify.Size = new System.Drawing.Size(358, 35);
			this.lifelengthViewerNotify.SystemCalculated = true;
			this.lifelengthViewerNotify.TabIndex = 12;
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
			this.lifelengthViewerLifeLimit.HeaderHours = "Hours";
			this.lifelengthViewerLifeLimit.HoursApplicable = false;
			this.lifelengthViewerLifeLimit.LeftHeader = "";
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(98, 453);
			this.lifelengthViewerLifeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerLifeLimit.Modified = false;
			this.lifelengthViewerLifeLimit.Name = "lifelengthViewerLifeLimit";
			this.lifelengthViewerLifeLimit.ReadOnly = false;
			this.lifelengthViewerLifeLimit.ShowCalendar = true;
			this.lifelengthViewerLifeLimit.ShowMinutes = false;
			this.lifelengthViewerLifeLimit.Size = new System.Drawing.Size(358, 52);
			this.lifelengthViewerLifeLimit.SystemCalculated = true;
			this.lifelengthViewerLifeLimit.TabIndex = 11;
			// 
			// labelEffDate
			// 
			this.labelEffDate.AutoSize = true;
			this.labelEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffDate.Location = new System.Drawing.Point(6, 311);
			this.labelEffDate.Name = "labelEffDate";
			this.labelEffDate.Size = new System.Drawing.Size(76, 17);
			this.labelEffDate.TabIndex = 107;
			this.labelEffDate.Text = "Eff. Date:";
			this.labelEffDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerEffDate
			// 
			this.dateTimePickerEffDate.BackColor = System.Drawing.Color.White;
			this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.Black;
			this.dateTimePickerEffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(109, 307);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(348, 25);
			this.dateTimePickerEffDate.TabIndex = 9;
			// 
			// comboBoxDefferedCategory
			// 
			this.comboBoxDefferedCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDefferedCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDefferedCategory.FormattingEnabled = true;
			this.comboBoxDefferedCategory.Location = new System.Drawing.Point(109, 399);
			this.comboBoxDefferedCategory.Name = "comboBoxDefferedCategory";
			this.comboBoxDefferedCategory.Size = new System.Drawing.Size(349, 25);
			this.comboBoxDefferedCategory.TabIndex = 10;
			this.comboBoxDefferedCategory.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDeferredCategorySelectedIndexChanged);
			this.comboBoxDefferedCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelDefferedCategory
			// 
			this.labelDefferedCategory.AutoSize = true;
			this.labelDefferedCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDefferedCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDefferedCategory.Location = new System.Drawing.Point(6, 401);
			this.labelDefferedCategory.Name = "labelDefferedCategory";
			this.labelDefferedCategory.Size = new System.Drawing.Size(78, 17);
			this.labelDefferedCategory.TabIndex = 108;
			this.labelDefferedCategory.Text = "Category:";
			// 
			// comboBoxReason
			// 
			this.comboBoxReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxReason.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxReason.FormattingEnabled = true;
			this.comboBoxReason.Location = new System.Drawing.Point(109, 337);
			this.comboBoxReason.Name = "comboBoxReason";
			this.comboBoxReason.Size = new System.Drawing.Size(349, 25);
			this.comboBoxReason.TabIndex = 129;
			this.comboBoxReason.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReasonSelectedIndexChanged);
			this.comboBoxReason.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelReason
			// 
			this.labelReason.AutoSize = true;
			this.labelReason.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReason.Location = new System.Drawing.Point(6, 340);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(66, 17);
			this.labelReason.TabIndex = 130;
			this.labelReason.Text = "Reason:";
			// 
			// comboBoxDestination
			// 
			this.comboBoxDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDestination.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDestination.FormattingEnabled = true;
			this.comboBoxDestination.Location = new System.Drawing.Point(109, 368);
			this.comboBoxDestination.Name = "comboBoxDestination";
			this.comboBoxDestination.Size = new System.Drawing.Size(349, 25);
			this.comboBoxDestination.TabIndex = 131;
			this.comboBoxDestination.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDestinationSelectedIndexChanged);
			this.comboBoxDestination.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelDestination
			// 
			this.labelDestination.AutoSize = true;
			this.labelDestination.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDestination.Location = new System.Drawing.Point(6, 370);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(94, 17);
			this.labelDestination.TabIndex = 132;
			this.labelDestination.Text = "Destination:";
			// 
			// checkBoxRepair
			// 
			this.checkBoxRepair.AutoSize = true;
			this.checkBoxRepair.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRepair.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRepair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxRepair.Location = new System.Drawing.Point(384, 429);
			this.checkBoxRepair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxRepair.Name = "checkBoxRepair";
			this.checkBoxRepair.Size = new System.Drawing.Size(71, 21);
			this.checkBoxRepair.TabIndex = 71;
			this.checkBoxRepair.Text = "Repair";
			this.checkBoxRepair.UseVisualStyleBackColor = true;
			// 
			// checkBoxOverhaul
			// 
			this.checkBoxOverhaul.AutoSize = true;
			this.checkBoxOverhaul.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxOverhaul.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxOverhaul.Location = new System.Drawing.Point(304, 429);
			this.checkBoxOverhaul.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxOverhaul.Name = "checkBoxOverhaul";
			this.checkBoxOverhaul.Size = new System.Drawing.Size(48, 21);
			this.checkBoxOverhaul.TabIndex = 70;
			this.checkBoxOverhaul.Text = "OH";
			this.checkBoxOverhaul.UseVisualStyleBackColor = true;
			// 
			// checkBoxServiceable
			// 
			this.checkBoxServiceable.AutoSize = true;
			this.checkBoxServiceable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxServiceable.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxServiceable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxServiceable.Location = new System.Drawing.Point(201, 429);
			this.checkBoxServiceable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxServiceable.Name = "checkBoxServiceable";
			this.checkBoxServiceable.Size = new System.Drawing.Size(64, 21);
			this.checkBoxServiceable.TabIndex = 69;
			this.checkBoxServiceable.Text = "Serv.";
			this.checkBoxServiceable.UseVisualStyleBackColor = true;
			// 
			// checkBoxNew
			// 
			this.checkBoxNew.AutoSize = true;
			this.checkBoxNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxNew.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxNew.Location = new System.Drawing.Point(109, 429);
			this.checkBoxNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxNew.Name = "checkBoxNew";
			this.checkBoxNew.Size = new System.Drawing.Size(56, 21);
			this.checkBoxNew.TabIndex = 68;
			this.checkBoxNew.Text = "New";
			this.checkBoxNew.UseVisualStyleBackColor = true;
			// 
			// labelPriority
			// 
			this.labelPriority.AutoSize = true;
			this.labelPriority.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPriority.Location = new System.Drawing.Point(6, 475);
			this.labelPriority.Name = "labelPriority";
			this.labelPriority.Size = new System.Drawing.Size(63, 17);
			this.labelPriority.TabIndex = 133;
			this.labelPriority.Text = "Priority:";
			// 
			// labelNotify
			// 
			this.labelNotify.AutoSize = true;
			this.labelNotify.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNotify.Location = new System.Drawing.Point(6, 513);
			this.labelNotify.Name = "labelNotify";
			this.labelNotify.Size = new System.Drawing.Size(55, 17);
			this.labelNotify.TabIndex = 134;
			this.labelNotify.Text = "Notify:";

			this.panelMain.Controls.Add(this.comboBoxDetailClass);
			this.panelMain.Controls.Add(this.labelClass);
			this.panelMain.Controls.Add(this.labelDescription);
			this.panelMain.Controls.Add(this.textBoxDescription);
			this.panelMain.Controls.Add(this.labelPartNumber);
			this.panelMain.Controls.Add(this.textBoxPartNumber);
			this.panelMain.Controls.Add(this.labelStandart);
			this.panelMain.Controls.Add(this.dictionaryComboStandard);
			this.panelMain.Controls.Add(this.numericUpDownQuantity);
			this.panelMain.Controls.Add(this.labelQuantity);
			this.panelMain.Controls.Add(this.labelRemarks);
			this.panelMain.Controls.Add(this.textBoxRemarks);
			this.panelMain.Controls.Add(this.labelSuppliers);
			this.panelMain.Controls.Add(this.labelManufacturer);
			this.panelMain.Controls.Add(this.textBoxManufacturer);
			this.panelMain.Controls.Add(this.comboBoxMeasure);
			this.panelMain.Controls.Add(this.labelMeasure);
			this.panelMain.Controls.Add(this.labelProductCode);
			this.panelMain.Controls.Add(this.textBoxProductCode);
			this.panelMain.Controls.Add(this.dataGridViewControlSuppliers);
			this.panelMain.Controls.Add(this.dictionaryComboProduct);
			this.panelMain.Controls.Add(this.labelProduct);
			this.panelMain.Controls.Add(this.labelTotal);
			this.panelMain.Controls.Add(this.textBoxTotal);
			this.panelMain.Controls.Add(this.lifelengthViewerNotify);
			this.panelMain.Controls.Add(this.lifelengthViewerLifeLimit);
			this.panelMain.Controls.Add(this.labelEffDate);
			this.panelMain.Controls.Add(this.dateTimePickerEffDate);
			this.panelMain.Controls.Add(this.comboBoxDefferedCategory);
			this.panelMain.Controls.Add(this.labelDefferedCategory);
			this.panelMain.Controls.Add(this.labelReason);
			this.panelMain.Controls.Add(this.comboBoxReason);
			this.panelMain.Controls.Add(this.labelDestination);
			this.panelMain.Controls.Add(this.comboBoxDestination);
			this.panelMain.Controls.Add(this.checkBoxRepair);
			this.panelMain.Controls.Add(this.checkBoxOverhaul);
			this.panelMain.Controls.Add(this.checkBoxServiceable);
			this.panelMain.Controls.Add(this.checkBoxNew);
			this.panelMain.Controls.Add(this.labelPriority);
			this.panelMain.Controls.Add(this.labelNotify);
			// 
			// InitialOrderRecordForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 742);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1022, 1023);
			this.MinimumSize = new System.Drawing.Size(284, 161);
			this.Name = "InitialOrderRecordForm";
			this.Text = "Initial Record Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TreeDictionaryComboBox comboBoxDetailClass;
		private System.Windows.Forms.Label labelClass;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelPartNumber;
		private System.Windows.Forms.TextBox textBoxPartNumber;
		private System.Windows.Forms.Label labelStandart;
		private LookupCombobox dictionaryComboStandard;
		private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private System.Windows.Forms.Label labelQuantity;
		private System.Windows.Forms.Label labelRemarks;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.Label labelSuppliers;
		private System.Windows.Forms.Label labelManufacturer;
		private System.Windows.Forms.TextBox textBoxManufacturer;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private System.Windows.Forms.Label labelMeasure;
		private System.Windows.Forms.Label labelProductCode;
		private System.Windows.Forms.TextBox textBoxProductCode;
		private CommonDataGridViewControl dataGridViewControlSuppliers;
		private LookupCombobox dictionaryComboProduct;
		private System.Windows.Forms.Label labelProduct;
		private System.Windows.Forms.Label labelTotal;
		private System.Windows.Forms.TextBox textBoxTotal;
		private LifelengthViewer lifelengthViewerNotify;
		private LifelengthViewer lifelengthViewerLifeLimit;
		private System.Windows.Forms.Label labelEffDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerEffDate;
		private System.Windows.Forms.ComboBox comboBoxDefferedCategory;
		private System.Windows.Forms.Label labelDefferedCategory;
		private System.Windows.Forms.ComboBox comboBoxReason;
		private System.Windows.Forms.Label labelReason;
		private System.Windows.Forms.ComboBox comboBoxDestination;
		private System.Windows.Forms.Label labelDestination;
		private System.Windows.Forms.CheckBox checkBoxRepair;
		private System.Windows.Forms.CheckBox checkBoxOverhaul;
		private System.Windows.Forms.CheckBox checkBoxServiceable;
		private System.Windows.Forms.CheckBox checkBoxNew;
		private System.Windows.Forms.Label labelPriority;
		private System.Windows.Forms.Label labelNotify;

	}
}