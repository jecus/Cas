using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.PurchaseControls
{
	partial class ModelForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxAccessoryStandard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.labelStandard = new System.Windows.Forms.Label();
            this.labelSeries = new System.Windows.Forms.Label();
            this.textBoxSeries = new System.Windows.Forms.TextBox();
            this.labelProductCode = new System.Windows.Forms.Label();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.labelShortName = new System.Windows.Forms.Label();
            this.textBoxShortName = new System.Windows.Forms.TextBox();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.textBoxManufacturer = new System.Windows.Forms.TextBox();
            this.labelFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelDesigner = new System.Windows.Forms.Label();
            this.textBoxDesigner = new System.Windows.Forms.TextBox();
            this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelAta = new System.Windows.Forms.Label();
            this.comboBoxAtaChapter = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
            this.comboBoxManufRegion = new System.Windows.Forms.ComboBox();
            this.labelManufRegion = new System.Windows.Forms.Label();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.textBoxPartNumber = new System.Windows.Forms.TextBox();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelImage = new System.Windows.Forms.Label();
            this.fileControlImage = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.checkBoxDangerous = new System.Windows.Forms.CheckBox();
            this.labelSuppliers = new System.Windows.Forms.Label();
            this.textBoxDescRus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHts = new System.Windows.Forms.TextBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.labelDoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelName.Location = new System.Drawing.Point(9, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(69, 25);
            this.labelName.TabIndex = 106;
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.White;
            this.textBoxName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxName.Location = new System.Drawing.Point(125, 8);
            this.textBoxName.MaxLength = 128;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(313, 22);
            this.textBoxName.TabIndex = 107;
            // 
            // comboBoxAccessoryStandard
            // 
            this.comboBoxAccessoryStandard.Displayer = null;
            this.comboBoxAccessoryStandard.DisplayerText = null;
            this.comboBoxAccessoryStandard.Entity = null;
            this.comboBoxAccessoryStandard.Location = new System.Drawing.Point(125, 37);
            this.comboBoxAccessoryStandard.Name = "comboBoxAccessoryStandard";
            this.comboBoxAccessoryStandard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.comboBoxAccessoryStandard.Size = new System.Drawing.Size(312, 21);
            this.comboBoxAccessoryStandard.TabIndex = 89;
            this.comboBoxAccessoryStandard.Type = null;
            // 
            // labelStandard
            // 
            this.labelStandard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStandard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelStandard.Location = new System.Drawing.Point(9, 34);
            this.labelStandard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStandard.Name = "labelStandard";
            this.labelStandard.Size = new System.Drawing.Size(79, 25);
            this.labelStandard.TabIndex = 90;
            this.labelStandard.Text = "Standard:";
            this.labelStandard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSeries
            // 
            this.labelSeries.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSeries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSeries.Location = new System.Drawing.Point(449, 8);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(69, 25);
            this.labelSeries.TabIndex = 108;
            this.labelSeries.Text = "Series:";
            this.labelSeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSeries
            // 
            this.textBoxSeries.BackColor = System.Drawing.Color.White;
            this.textBoxSeries.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSeries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxSeries.Location = new System.Drawing.Point(559, 8);
            this.textBoxSeries.MaxLength = 128;
            this.textBoxSeries.Name = "textBoxSeries";
            this.textBoxSeries.Size = new System.Drawing.Size(313, 22);
            this.textBoxSeries.TabIndex = 109;
            // 
            // labelProductCode
            // 
            this.labelProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelProductCode.Location = new System.Drawing.Point(449, 34);
            this.labelProductCode.Name = "labelProductCode";
            this.labelProductCode.Size = new System.Drawing.Size(101, 25);
            this.labelProductCode.TabIndex = 110;
            this.labelProductCode.Text = "Product Code:";
            this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.BackColor = System.Drawing.Color.White;
            this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxProductCode.Location = new System.Drawing.Point(559, 35);
            this.textBoxProductCode.MaxLength = 128;
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(313, 22);
            this.textBoxProductCode.TabIndex = 111;
            // 
            // labelShortName
            // 
            this.labelShortName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelShortName.Location = new System.Drawing.Point(449, 61);
            this.labelShortName.Name = "labelShortName";
            this.labelShortName.Size = new System.Drawing.Size(101, 25);
            this.labelShortName.TabIndex = 112;
            this.labelShortName.Text = "Short Name:";
            this.labelShortName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxShortName
            // 
            this.textBoxShortName.BackColor = System.Drawing.Color.White;
            this.textBoxShortName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxShortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxShortName.Location = new System.Drawing.Point(559, 62);
            this.textBoxShortName.MaxLength = 128;
            this.textBoxShortName.Name = "textBoxShortName";
            this.textBoxShortName.Size = new System.Drawing.Size(313, 22);
            this.textBoxShortName.TabIndex = 113;
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufacturer.Location = new System.Drawing.Point(449, 87);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(101, 25);
            this.labelManufacturer.TabIndex = 114;
            this.labelManufacturer.Text = "Manufacturer:";
            this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxManufacturer
            // 
            this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
            this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxManufacturer.Location = new System.Drawing.Point(559, 89);
            this.textBoxManufacturer.MaxLength = 128;
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.Size = new System.Drawing.Size(313, 22);
            this.textBoxManufacturer.TabIndex = 115;
            // 
            // labelFullName
            // 
            this.labelFullName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFullName.Location = new System.Drawing.Point(9, 61);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(101, 25);
            this.labelFullName.TabIndex = 116;
            this.labelFullName.Text = "Full Name:";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.BackColor = System.Drawing.Color.White;
            this.textBoxFullName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxFullName.Location = new System.Drawing.Point(125, 62);
            this.textBoxFullName.MaxLength = 128;
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(313, 22);
            this.textBoxFullName.TabIndex = 117;
            // 
            // labelDesigner
            // 
            this.labelDesigner.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDesigner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDesigner.Location = new System.Drawing.Point(9, 87);
            this.labelDesigner.Name = "labelDesigner";
            this.labelDesigner.Size = new System.Drawing.Size(101, 25);
            this.labelDesigner.TabIndex = 118;
            this.labelDesigner.Text = "Designer:";
            this.labelDesigner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDesigner
            // 
            this.textBoxDesigner.BackColor = System.Drawing.Color.White;
            this.textBoxDesigner.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDesigner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDesigner.Location = new System.Drawing.Point(125, 89);
            this.textBoxDesigner.MaxLength = 128;
            this.textBoxDesigner.Name = "textBoxDesigner";
            this.textBoxDesigner.Size = new System.Drawing.Size(313, 22);
            this.textBoxDesigner.TabIndex = 119;
            // 
            // comboBoxDetailClass
            // 
            this.comboBoxDetailClass.Displayer = null;
            this.comboBoxDetailClass.DisplayerText = null;
            this.comboBoxDetailClass.DropDownHeight = 106;
            this.comboBoxDetailClass.Entity = null;
            this.comboBoxDetailClass.Location = new System.Drawing.Point(559, 116);
            this.comboBoxDetailClass.Name = "comboBoxDetailClass";
            this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.comboBoxDetailClass.RootNodesNames = null;
            this.comboBoxDetailClass.Size = new System.Drawing.Size(312, 21);
            this.comboBoxDetailClass.TabIndex = 145;
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClass.Location = new System.Drawing.Point(449, 118);
            this.labelClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(47, 14);
            this.labelClass.TabIndex = 146;
            this.labelClass.Text = "Class:";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAta
            // 
            this.labelAta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAta.Location = new System.Drawing.Point(449, 141);
            this.labelAta.Name = "labelAta";
            this.labelAta.Size = new System.Drawing.Size(69, 25);
            this.labelAta.TabIndex = 147;
            this.labelAta.Text = "ATA:";
            this.labelAta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxAtaChapter
            // 
            this.comboBoxAtaChapter.BackColor = System.Drawing.Color.White;
            this.comboBoxAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxAtaChapter.FormattingEnabled = true;
            this.comboBoxAtaChapter.Location = new System.Drawing.Point(559, 144);
            this.comboBoxAtaChapter.Name = "comboBoxAtaChapter";
            this.comboBoxAtaChapter.Size = new System.Drawing.Size(311, 22);
            this.comboBoxAtaChapter.TabIndex = 148;
            // 
            // comboBoxManufRegion
            // 
            this.comboBoxManufRegion.FormattingEnabled = true;
            this.comboBoxManufRegion.Location = new System.Drawing.Point(125, 116);
            this.comboBoxManufRegion.Name = "comboBoxManufRegion";
            this.comboBoxManufRegion.Size = new System.Drawing.Size(313, 21);
            this.comboBoxManufRegion.TabIndex = 102;
            // 
            // labelManufRegion
            // 
            this.labelManufRegion.AutoSize = true;
            this.labelManufRegion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.labelManufRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufRegion.Location = new System.Drawing.Point(9, 118);
            this.labelManufRegion.Name = "labelManufRegion";
            this.labelManufRegion.Size = new System.Drawing.Size(105, 14);
            this.labelManufRegion.TabIndex = 103;
            this.labelManufRegion.Text = "Manuf. Region:";
            this.labelManufRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPartNumber.Location = new System.Drawing.Point(9, 141);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(101, 25);
            this.labelPartNumber.TabIndex = 149;
            this.labelPartNumber.Text = "Part Number:";
            this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNumber
            // 
            this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPartNumber.Location = new System.Drawing.Point(125, 144);
            this.textBoxPartNumber.MaxLength = 128;
            this.textBoxPartNumber.Name = "textBoxPartNumber";
            this.textBoxPartNumber.Size = new System.Drawing.Size(312, 22);
            this.textBoxPartNumber.TabIndex = 150;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(9, 169);
            this.labelRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(100, 25);
            this.labelRemarks.TabIndex = 90;
            this.labelRemarks.Text = "Remarks:";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.White;
            this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxRemarks.Location = new System.Drawing.Point(125, 171);
            this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRemarks.MaxLength = 100;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(312, 90);
            this.textBoxRemarks.TabIndex = 89;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(449, 169);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(100, 25);
            this.labelDescription.TabIndex = 152;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescription.Location = new System.Drawing.Point(559, 171);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.MaxLength = 100;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(313, 44);
            this.textBoxDescription.TabIndex = 151;
            // 
            // labelImage
            // 
            this.labelImage.AutoSize = true;
            this.labelImage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelImage.Location = new System.Drawing.Point(449, 273);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(52, 14);
            this.labelImage.TabIndex = 144;
            this.labelImage.Text = "Image:";
            this.labelImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileControlImage
            // 
            this.fileControlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileControlImage.AutoSize = true;
            this.fileControlImage.Description1 = "";
            this.fileControlImage.Description2 = "";
            this.fileControlImage.Filter = null;
            this.fileControlImage.Icon = global::CAS.UI.Properties.Resources.ImageIcon_Small;
            this.fileControlImage.IconNotEnabled = global::CAS.UI.Properties.Resources.ImageIcon_Small_Gray;
            this.fileControlImage.Location = new System.Drawing.Point(559, 268);
            this.fileControlImage.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControlImage.Name = "fileControlImage";
            this.fileControlImage.ShowLinkLabelBrowse = true;
            this.fileControlImage.ShowLinkLabelRemove = false;
            this.fileControlImage.Size = new System.Drawing.Size(201, 37);
            this.fileControlImage.TabIndex = 145;
            // 
            // checkBoxDangerous
            // 
            this.checkBoxDangerous.AutoSize = true;
            this.checkBoxDangerous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDangerous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxDangerous.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxDangerous.Location = new System.Drawing.Point(125, 397);
            this.checkBoxDangerous.Name = "checkBoxDangerous";
            this.checkBoxDangerous.Size = new System.Drawing.Size(108, 18);
            this.checkBoxDangerous.TabIndex = 146;
            this.checkBoxDangerous.Text = "Is Dangerous";
            // 
            // labelSuppliers
            // 
            this.labelSuppliers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSuppliers.Location = new System.Drawing.Point(391, 415);
            this.labelSuppliers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuppliers.Name = "labelSuppliers";
            this.labelSuppliers.Size = new System.Drawing.Size(75, 25);
            this.labelSuppliers.TabIndex = 153;
            this.labelSuppliers.Text = "Suppliers";
            this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescRus
            // 
            this.textBoxDescRus.BackColor = System.Drawing.Color.White;
            this.textBoxDescRus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescRus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescRus.Location = new System.Drawing.Point(559, 217);
            this.textBoxDescRus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescRus.MaxLength = 100;
            this.textBoxDescRus.Multiline = true;
            this.textBoxDescRus.Name = "textBoxDescRus";
            this.textBoxDescRus.Size = new System.Drawing.Size(313, 44);
            this.textBoxDescRus.TabIndex = 154;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(449, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 44);
            this.label1.TabIndex = 155;
            this.label1.Text = "Description    (Rus):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewControlSuppliers
            // 
            this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
            this.dataGridViewControlSuppliers.Displayer = null;
            this.dataGridViewControlSuppliers.DisplayerText = null;
            this.dataGridViewControlSuppliers.Entity = null;
            this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(9, 442);
            this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
            this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dataGridViewControlSuppliers.RowHeadersVisible = false;
            this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridViewControlSuppliers.ShowQuickSearch = false;
            this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(863, 131);
            this.dataGridViewControlSuppliers.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(6, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 156;
            this.label2.Text = "HTS tariff:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxHts
            // 
            this.textBoxHts.BackColor = System.Drawing.Color.White;
            this.textBoxHts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxHts.Location = new System.Drawing.Point(124, 270);
            this.textBoxHts.MaxLength = 128;
            this.textBoxHts.Name = "textBoxHts";
            this.textBoxHts.Size = new System.Drawing.Size(313, 22);
            this.textBoxHts.TabIndex = 157;
            // 
            // fileControl
            // 
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.IconNotEnabled = null;
            this.fileControl.Location = new System.Drawing.Point(520, 336);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "fileControl";
            this.fileControl.ShowLinkLabelBrowse = true;
            this.fileControl.ShowLinkLabelRemove = false;
            this.fileControl.Size = new System.Drawing.Size(350, 100);
            this.fileControl.TabIndex = 158;
            // 
            // labelDoc
            // 
            this.labelDoc.AutoSize = true;
            this.labelDoc.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDoc.Location = new System.Drawing.Point(452, 345);
            this.labelDoc.Name = "labelDoc";
            this.labelDoc.Size = new System.Drawing.Size(35, 14);
            this.labelDoc.TabIndex = 159;
            this.labelDoc.Text = "Doc:";
            this.labelDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.panelMain.Controls.Add(textBoxHts);
            this.panelMain.Controls.Add(label2);
            this.panelMain.Controls.Add(labelName);
            this.panelMain.Controls.Add(textBoxName);
            this.panelMain.Controls.Add(labelStandard);
            this.panelMain.Controls.Add(comboBoxAccessoryStandard);
            this.panelMain.Controls.Add(labelSeries);
            this.panelMain.Controls.Add(textBoxSeries);
            this.panelMain.Controls.Add(labelProductCode);
            this.panelMain.Controls.Add(textBoxProductCode);
            this.panelMain.Controls.Add(labelShortName);
            this.panelMain.Controls.Add(textBoxShortName);
            this.panelMain.Controls.Add(labelManufacturer);
            this.panelMain.Controls.Add(textBoxManufacturer);
            this.panelMain.Controls.Add(labelFullName);
            this.panelMain.Controls.Add(textBoxFullName);
            this.panelMain.Controls.Add(labelDesigner);
            this.panelMain.Controls.Add(textBoxDesigner);
            this.panelMain.Controls.Add(labelAta);
            this.panelMain.Controls.Add(comboBoxAtaChapter);
            this.panelMain.Controls.Add(labelClass);
            this.panelMain.Controls.Add(comboBoxDetailClass);
            this.panelMain.Controls.Add(labelManufRegion);
            this.panelMain.Controls.Add(comboBoxManufRegion);
            this.panelMain.Controls.Add(labelPartNumber);
            this.panelMain.Controls.Add(textBoxPartNumber);
            this.panelMain.Controls.Add(labelRemarks);
            this.panelMain.Controls.Add(textBoxRemarks);
            this.panelMain.Controls.Add(labelDescription);
            this.panelMain.Controls.Add(textBoxDescription);
            this.panelMain.Controls.Add(textBoxDescRus);
            this.panelMain.Controls.Add(label1);
            this.panelMain.Controls.Add(checkBoxDangerous);
            this.panelMain.Controls.Add(labelImage);
            this.panelMain.Controls.Add(labelDoc);
            this.panelMain.Controls.Add(labelSuppliers);
            this.panelMain.Controls.Add(dataGridViewControlSuppliers);
            this.panelMain.Controls.Add(fileControlImage);
            this.panelMain.Controls.Add(fileControl);
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 624);
            this.MaximumSize = new System.Drawing.Size(1023, 766);
            this.MinimumSize = new System.Drawing.Size(284, 164);
            this.Name = "ModelForm";
            this.Text = "Model Form";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private Auxiliary.LookupCombobox comboBoxAccessoryStandard;
		private System.Windows.Forms.Label labelStandard;
		private System.Windows.Forms.Label labelSeries;
		private System.Windows.Forms.TextBox textBoxSeries;
		private System.Windows.Forms.Label labelProductCode;
		private System.Windows.Forms.TextBox textBoxProductCode;
		private System.Windows.Forms.Label labelShortName;
		private System.Windows.Forms.TextBox textBoxShortName;
		private System.Windows.Forms.Label labelManufacturer;
		private System.Windows.Forms.TextBox textBoxManufacturer;
		private System.Windows.Forms.Label labelFullName;
		private System.Windows.Forms.TextBox textBoxFullName;
		private System.Windows.Forms.Label labelDesigner;
		private System.Windows.Forms.TextBox textBoxDesigner;
		private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
		private System.Windows.Forms.Label labelClass;
		private System.Windows.Forms.Label labelAta;
		private Auxiliary.ATAChapterComboBox comboBoxAtaChapter;
		private System.Windows.Forms.ComboBox comboBoxManufRegion;
		private System.Windows.Forms.Label labelManufRegion;
		private System.Windows.Forms.Label labelPartNumber;
		private System.Windows.Forms.TextBox textBoxPartNumber;
		private System.Windows.Forms.Label labelRemarks;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBoxDescRus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelImage;
		private Auxiliary.AttachedFileControl fileControlImage;
		private System.Windows.Forms.CheckBox checkBoxDangerous;
		private System.Windows.Forms.Label labelSuppliers;
		private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxHts;
        public Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.Label labelDoc;
    }
}