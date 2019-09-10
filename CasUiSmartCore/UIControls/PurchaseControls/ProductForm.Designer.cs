using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls
{
	partial class ProductForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelClass = new System.Windows.Forms.Label();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelSuppliers = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelPartNumber = new System.Windows.Forms.Label();
			this.textBoxPartNumber = new System.Windows.Forms.TextBox();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.labelStandard = new System.Windows.Forms.Label();
			this.comboBoxAccessoryStandard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelProductCode = new System.Windows.Forms.Label();
			this.textBoxProductCode = new System.Windows.Forms.TextBox();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelImage = new System.Windows.Forms.Label();
			this.fileControlImage = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.checkBoxDangerous = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxAtaChapter = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxDescRus = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxHTS = new System.Windows.Forms.TextBox();
			this.labelReference = new System.Windows.Forms.Label();
			this.textBoxReference = new System.Windows.Forms.TextBox();
			this.labelDoc = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxAltPartNum = new System.Windows.Forms.TextBox();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.labelIsEffectivity = new System.Windows.Forms.Label();
			this.textBoxIsEffectivity = new System.Windows.Forms.TextBox();
			this.checkBoxIsForbidden = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 106;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(110, 33);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(312, 21);
			this.comboBoxDetailClass.TabIndex = 1;
			// 
			// labelClass
			// 
			this.labelClass.AutoSize = true;
			this.labelClass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClass.Location = new System.Drawing.Point(5, 35);
			this.labelClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(47, 14);
			this.labelClass.TabIndex = 99;
			this.labelClass.Text = "Class:";
			this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(6, 172);
			this.labelRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(100, 25);
			this.labelRemarks.TabIndex = 88;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(110, 173);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(313, 90);
			this.textBoxRemarks.TabIndex = 8;
			this.textBoxRemarks.Text = "Line1\r\nLin2\r\nLine3\r\nLine4\r\nLine5\r\nLine 6";
			// 
			// labelSuppliers
			// 
			this.labelSuppliers.AutoSize = true;
			this.labelSuppliers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSuppliers.Location = new System.Drawing.Point(414, 441);
			this.labelSuppliers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSuppliers.Name = "labelSuppliers";
			this.labelSuppliers.Size = new System.Drawing.Size(70, 14);
			this.labelSuppliers.TabIndex = 85;
			this.labelSuppliers.Text = "Suppliers:";
			this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(432, 33);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(100, 25);
			this.labelManufacturer.TabIndex = 83;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(557, 33);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(294, 22);
			this.textBoxManufacturer.TabIndex = 6;
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(6, 325);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(89, 25);
			this.labelDescription.TabIndex = 81;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(110, 328);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(313, 90);
			this.textBoxDescription.TabIndex = 4;
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(5, 113);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(69, 25);
			this.labelPartNumber.TabIndex = 79;
			this.labelPartNumber.Text = "P/N:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNumber.Location = new System.Drawing.Point(110, 116);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.Size = new System.Drawing.Size(313, 22);
			this.textBoxPartNumber.TabIndex = 3;
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(557, 61);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(294, 21);
			this.comboBoxMeasure.TabIndex = 7;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(432, 64);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(68, 14);
			this.labelMeasure.TabIndex = 101;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStandard
			// 
			this.labelStandard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStandard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStandard.Location = new System.Drawing.Point(7, 5);
			this.labelStandard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelStandard.Name = "labelStandard";
			this.labelStandard.Size = new System.Drawing.Size(69, 25);
			this.labelStandard.TabIndex = 88;
			this.labelStandard.Text = "Standard:";
			this.labelStandard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxAccessoryStandard
			// 
			this.comboBoxAccessoryStandard.Displayer = null;
			this.comboBoxAccessoryStandard.DisplayerText = null;
			this.comboBoxAccessoryStandard.Entity = null;
			this.comboBoxAccessoryStandard.Location = new System.Drawing.Point(110, 6);
			this.comboBoxAccessoryStandard.Name = "comboBoxAccessoryStandard";
			this.comboBoxAccessoryStandard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxAccessoryStandard.Size = new System.Drawing.Size(312, 21);
			this.comboBoxAccessoryStandard.TabIndex = 0;
			this.comboBoxAccessoryStandard.Type = null;
			this.comboBoxAccessoryStandard.SelectedIndexChanged += new System.EventHandler(this.DictComboStandardSelectedIndexChanged);
			// 
			// labelProductCode
			// 
			this.labelProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProductCode.Location = new System.Drawing.Point(432, 3);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(100, 25);
			this.labelProductCode.TabIndex = 103;
			this.labelProductCode.Text = "Product Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductCode.Location = new System.Drawing.Point(557, 5);
			this.textBoxProductCode.MaxLength = 128;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.Size = new System.Drawing.Size(294, 22);
			this.textBoxProductCode.TabIndex = 5;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(8, 458);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(838, 131);
			this.dataGridViewControlSuppliers.TabIndex = 9;
			// 
			// labelName
			// 
			this.labelName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelName.Location = new System.Drawing.Point(5, 86);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(69, 25);
			this.labelName.TabIndex = 105;
			this.labelName.Text = "Name:";
			this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxName
			// 
			this.textBoxName.BackColor = System.Drawing.Color.White;
			this.textBoxName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxName.Location = new System.Drawing.Point(110, 88);
			this.textBoxName.MaxLength = 128;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(313, 22);
			this.textBoxName.TabIndex = 2;
			// 
			// labelImage
			// 
			this.labelImage.AutoSize = true;
			this.labelImage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelImage.Location = new System.Drawing.Point(432, 239);
			this.labelImage.Name = "labelImage";
			this.labelImage.Size = new System.Drawing.Size(52, 14);
			this.labelImage.TabIndex = 112;
			this.labelImage.Text = "Image:";
			this.labelImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fileControlImage
			// 
			this.fileControlImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.fileControlImage.AutoSize = true;
			this.fileControlImage.Description1 = "";
			this.fileControlImage.Description2 = "";
			this.fileControlImage.Filter = null;
			this.fileControlImage.Icon = global::CAS.UI.Properties.Resources.ImageIcon_Small;
			this.fileControlImage.IconNotEnabled = global::CAS.UI.Properties.Resources.ImageIcon_Small_Gray;
			this.fileControlImage.Location = new System.Drawing.Point(557, 239);
			this.fileControlImage.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlImage.Name = "fileControlImage";
			this.fileControlImage.ShowLinkLabelBrowse = true;
			this.fileControlImage.ShowLinkLabelRemove = false;
			this.fileControlImage.Size = new System.Drawing.Size(201, 37);
			this.fileControlImage.TabIndex = 140;
			// 
			// checkBoxDangerous
			// 
			this.checkBoxDangerous.AutoSize = true;
			this.checkBoxDangerous.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDangerous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxDangerous.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxDangerous.Location = new System.Drawing.Point(110, 422);
			this.checkBoxDangerous.Name = "checkBoxDangerous";
			this.checkBoxDangerous.Size = new System.Drawing.Size(108, 18);
			this.checkBoxDangerous.TabIndex = 143;
			this.checkBoxDangerous.Text = "Is Dangerous";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(5, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 25);
			this.label1.TabIndex = 144;
			this.label1.Text = "ATA:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxAtaChapter
			// 
			this.comboBoxAtaChapter.BackColor = System.Drawing.Color.White;
			this.comboBoxAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxAtaChapter.FormattingEnabled = true;
			this.comboBoxAtaChapter.Location = new System.Drawing.Point(110, 59);
			this.comboBoxAtaChapter.Name = "comboBoxAtaChapter";
			this.comboBoxAtaChapter.Size = new System.Drawing.Size(313, 22);
			this.comboBoxAtaChapter.TabIndex = 144;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(432, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 36);
			this.label2.TabIndex = 146;
			this.label2.Text = "Description    (Rus):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescRus
			// 
			this.textBoxDescRus.BackColor = System.Drawing.Color.White;
			this.textBoxDescRus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescRus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescRus.Location = new System.Drawing.Point(557, 143);
			this.textBoxDescRus.Multiline = true;
			this.textBoxDescRus.Name = "textBoxDescRus";
			this.textBoxDescRus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescRus.Size = new System.Drawing.Size(294, 90);
			this.textBoxDescRus.TabIndex = 145;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(432, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 25);
			this.label3.TabIndex = 148;
			this.label3.Text = "HTS tariff :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHTS
			// 
			this.textBoxHTS.BackColor = System.Drawing.Color.White;
			this.textBoxHTS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxHTS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxHTS.Location = new System.Drawing.Point(557, 116);
			this.textBoxHTS.MaxLength = 128;
			this.textBoxHTS.Name = "textBoxHTS";
			this.textBoxHTS.Size = new System.Drawing.Size(294, 22);
			this.textBoxHTS.TabIndex = 147;
			// 
			// labelReference
			// 
			this.labelReference.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReference.Location = new System.Drawing.Point(432, 88);
			this.labelReference.Name = "labelReference";
			this.labelReference.Size = new System.Drawing.Size(98, 25);
			this.labelReference.TabIndex = 150;
			this.labelReference.Text = "Reference:";
			this.labelReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxReference
			// 
			this.textBoxReference.BackColor = System.Drawing.Color.White;
			this.textBoxReference.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxReference.Location = new System.Drawing.Point(557, 90);
			this.textBoxReference.MaxLength = 128;
			this.textBoxReference.Name = "textBoxReference";
			this.textBoxReference.Size = new System.Drawing.Size(294, 22);
			this.textBoxReference.TabIndex = 149;
			// 
			// labelDoc
			// 
			this.labelDoc.AutoSize = true;
			this.labelDoc.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDoc.Location = new System.Drawing.Point(432, 323);
			this.labelDoc.Name = "labelDoc";
			this.labelDoc.Size = new System.Drawing.Size(35, 14);
			this.labelDoc.TabIndex = 152;
			this.labelDoc.Text = "Doc:";
			this.labelDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelMain.Controls.Add(this.label3);
			this.panelMain.Controls.Add(this.textBoxHTS);
			this.panelMain.Controls.Add(this.comboBoxAccessoryStandard);
			this.panelMain.Controls.Add(this.comboBoxDetailClass);
			this.panelMain.Controls.Add(this.labelClass);
			this.panelMain.Controls.Add(this.labelRemarks);
			this.panelMain.Controls.Add(this.textBoxRemarks);
			this.panelMain.Controls.Add(this.labelName);
			this.panelMain.Controls.Add(this.textBoxName);
			this.panelMain.Controls.Add(this.labelSuppliers);
			this.panelMain.Controls.Add(this.labelManufacturer);
			this.panelMain.Controls.Add(this.textBoxManufacturer);
			this.panelMain.Controls.Add(this.labelDescription);
			this.panelMain.Controls.Add(this.textBoxDescription);
			this.panelMain.Controls.Add(this.labelPartNumber);
			this.panelMain.Controls.Add(this.textBoxPartNumber);
			this.panelMain.Controls.Add(this.comboBoxMeasure);
			this.panelMain.Controls.Add(this.labelMeasure);
			this.panelMain.Controls.Add(this.labelStandard);
			this.panelMain.Controls.Add(this.labelProductCode);
			this.panelMain.Controls.Add(this.textBoxProductCode);
			this.panelMain.Controls.Add(this.dataGridViewControlSuppliers);
			this.panelMain.Controls.Add(this.labelImage);
			this.panelMain.Controls.Add(this.fileControlImage);
			this.panelMain.Controls.Add(this.checkBoxDangerous);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.comboBoxAtaChapter);
			this.panelMain.Controls.Add(this.label2);
			this.panelMain.Controls.Add(this.textBoxDescRus);
			this.panelMain.Controls.Add(this.labelReference);
			this.panelMain.Controls.Add(this.textBoxReference);
			this.panelMain.Controls.Add(this.documentControl1);
			this.panelMain.Controls.Add(this.labelDoc);
			this.panelMain.Controls.Add(this.label4);
			this.panelMain.Controls.Add(this.textBoxAltPartNum);
			this.panelMain.Controls.Add(this.textBoxIsEffectivity);
			this.panelMain.Controls.Add(this.labelIsEffectivity);
			this.panelMain.Controls.Add(this.checkBoxIsForbidden);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(4, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 25);
			this.label4.TabIndex = 154;
			this.label4.Text = "ALT P/N:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAltPartNum
			// 
			this.textBoxAltPartNum.BackColor = System.Drawing.Color.White;
			this.textBoxAltPartNum.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAltPartNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAltPartNum.Location = new System.Drawing.Point(110, 144);
			this.textBoxAltPartNum.MaxLength = 128;
			this.textBoxAltPartNum.Name = "textBoxAltPartNum";
			this.textBoxAltPartNum.Size = new System.Drawing.Size(313, 22);
			this.textBoxAltPartNum.TabIndex = 153;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(537, 323);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(314, 41);
			this.documentControl1.TabIndex = 161;
			// 
			// labelIsEffectivity
			// 
			this.labelIsEffectivity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIsEffectivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIsEffectivity.Location = new System.Drawing.Point(5, 267);
			this.labelIsEffectivity.Name = "labelIsEffectivity";
			this.labelIsEffectivity.Size = new System.Drawing.Size(89, 25);
			this.labelIsEffectivity.TabIndex = 163;
			this.labelIsEffectivity.Text = "Effectivity:";
			this.labelIsEffectivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIsEffectivity
			// 
			this.textBoxIsEffectivity.BackColor = System.Drawing.Color.White;
			this.textBoxIsEffectivity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxIsEffectivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxIsEffectivity.Location = new System.Drawing.Point(110, 270);
			this.textBoxIsEffectivity.Multiline = true;
			this.textBoxIsEffectivity.Name = "textBoxIsEffectivity";
			this.textBoxIsEffectivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxIsEffectivity.Size = new System.Drawing.Size(313, 52);
			this.textBoxIsEffectivity.TabIndex = 162;
			// 
			// checkBoxIsForbidden
			// 
			this.checkBoxIsForbidden.AutoSize = true;
			this.checkBoxIsForbidden.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIsForbidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxIsForbidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxIsForbidden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIsForbidden.Location = new System.Drawing.Point(315, 422);
			this.checkBoxIsForbidden.Name = "checkBoxIsForbidden";
			this.checkBoxIsForbidden.Size = new System.Drawing.Size(102, 18);
			this.checkBoxIsForbidden.TabIndex = 164;
			this.checkBoxIsForbidden.Text = "Is Forbidden";
			// 
			// ProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(883, 713);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1023, 766);
			this.MinimumSize = new System.Drawing.Size(284, 164);
			this.Name = "ProductForm";
			this.Resizable = false;
			this.Text = "Product Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TreeDictionaryComboBox comboBoxDetailClass;
		private System.Windows.Forms.Label labelClass;
		private System.Windows.Forms.Label labelRemarks;
		private System.Windows.Forms.Label labelImage;
		private AttachedFileControl fileControlImage;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.Label labelSuppliers;
		private System.Windows.Forms.Label labelManufacturer;
		private System.Windows.Forms.TextBox textBoxManufacturer;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelPartNumber;
		private System.Windows.Forms.TextBox textBoxPartNumber;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private System.Windows.Forms.Label labelMeasure;
		private System.Windows.Forms.Label labelStandard;
		private LookupCombobox comboBoxAccessoryStandard;
		private System.Windows.Forms.Label labelProductCode;
		private System.Windows.Forms.TextBox textBoxProductCode;
		private CommonDataGridViewControl dataGridViewControlSuppliers;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxDangerous;
		private System.Windows.Forms.Label label1;
		private ATAChapterComboBox comboBoxAtaChapter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxDescRus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxHTS;
		private System.Windows.Forms.Label labelReference;
		private System.Windows.Forms.TextBox textBoxReference;
		private System.Windows.Forms.Label labelDoc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxAltPartNum;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label labelIsEffectivity;
		private System.Windows.Forms.TextBox textBoxIsEffectivity;
		private System.Windows.Forms.CheckBox checkBoxIsForbidden;
	}
}