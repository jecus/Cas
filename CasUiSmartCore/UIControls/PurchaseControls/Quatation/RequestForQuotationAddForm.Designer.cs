using System.ComponentModel;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Controls;
using CAS.UI.Helpers;
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	partial class RequestForQuotationAddForm
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
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
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
			this.labelSearchKitManufacturer = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchManufacturer = new MetroFramework.Controls.MetroTextBox();
			this.labelSearchSupplier = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchSupplier = new MetroFramework.Controls.MetroTextBox();
			this.labelSearchPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.labelTotal = new MetroFramework.Controls.MetroLabel();
			this.textBoxTotal = new MetroFramework.Controls.MetroTextBox();
			this.labelProduct = new MetroFramework.Controls.MetroLabel();
			this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.dictionaryComboStandard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelClass = new MetroFramework.Controls.MetroLabel();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.textBoxProdRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelSuppliers = new MetroFramework.Controls.MetroLabel();
			this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.labelManufacturer = new MetroFramework.Controls.MetroLabel();
			this.textBoxManufacturer = new MetroFramework.Controls.MetroTextBox();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBoxProdDesc = new MetroFramework.Controls.MetroTextBox();
			this.labelPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.labelStandart = new MetroFramework.Controls.MetroLabel();
			this.listViewAddedItems = new CAS.UI.UIControls.PurchaseControls.Quatation.QuatationOrderListView();
			this.listViewKits = new CAS.UI.UIControls.PurchaseControls.Quatation.RequestProductListView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
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
			this.ButtonDelete.Location = new System.Drawing.Point(596, 518);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(145, 38);
			this.ButtonDelete.TabIndex = 58;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.ButtonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(179, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(47, 47);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(110, 618);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(229, 52);
			this.textBoxRemarks.TabIndex = 8;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerOpeningDate
			// 
			this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(457, 563);
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
			this.textBoxAuthor.Location = new System.Drawing.Point(110, 590);
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
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(179, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(47, 47);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(457, 592);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(229, 52);
			this.textBoxDescription.TabIndex = 6;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelRemarks
			// 
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(17, 618);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(66, 23);
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
			this.textBoxTitle.Location = new System.Drawing.Point(110, 562);
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
			this.labelOpeningDate.Location = new System.Drawing.Point(364, 563);
			this.labelOpeningDate.Name = "labelOpeningDate";
			this.labelOpeningDate.Size = new System.Drawing.Size(87, 23);
			this.labelOpeningDate.TabIndex = 4;
			this.labelOpeningDate.Text = "Open. date:";
			this.labelOpeningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAuthor
			// 
			this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAuthor.Location = new System.Drawing.Point(17, 590);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(87, 23);
			this.labelAuthor.TabIndex = 3;
			this.labelAuthor.Text = "Author:";
			this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(364, 592);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(87, 23);
			this.labelDescription.TabIndex = 2;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelQOTitle
			// 
			this.labelQOTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQOTitle.Location = new System.Drawing.Point(17, 561);
			this.labelQOTitle.Name = "labelQOTitle";
			this.labelQOTitle.Size = new System.Drawing.Size(87, 23);
			this.labelQOTitle.TabIndex = 1;
			this.labelQOTitle.Text = "Title:";
			this.labelQOTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSearchKitManufacturer
			// 
			this.labelSearchKitManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchKitManufacturer.Location = new System.Drawing.Point(464, 62);
			this.labelSearchKitManufacturer.Name = "labelSearchKitManufacturer";
			this.labelSearchKitManufacturer.Size = new System.Drawing.Size(100, 23);
			this.labelSearchKitManufacturer.TabIndex = 65;
			this.labelSearchKitManufacturer.Text = "Manufacturer:";
			this.labelSearchKitManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelSearchKitManufacturer.UseCustomForeColor = true;
			// 
			// textBoxSearchManufacturer
			// 
			// 
			// 
			// 
			this.textBoxSearchManufacturer.CustomButton.Image = null;
			this.textBoxSearchManufacturer.CustomButton.Location = new System.Drawing.Point(151, 2);
			this.textBoxSearchManufacturer.CustomButton.Name = "";
			this.textBoxSearchManufacturer.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchManufacturer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchManufacturer.CustomButton.TabIndex = 1;
			this.textBoxSearchManufacturer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchManufacturer.CustomButton.UseSelectable = true;
			this.textBoxSearchManufacturer.CustomButton.Visible = false;
			this.textBoxSearchManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchManufacturer.Lines = new string[0];
			this.textBoxSearchManufacturer.Location = new System.Drawing.Point(570, 62);
			this.textBoxSearchManufacturer.MaxLength = 32767;
			this.textBoxSearchManufacturer.Name = "textBoxSearchManufacturer";
			this.textBoxSearchManufacturer.PasswordChar = '\0';
			this.textBoxSearchManufacturer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchManufacturer.SelectedText = "";
			this.textBoxSearchManufacturer.SelectionLength = 0;
			this.textBoxSearchManufacturer.SelectionStart = 0;
			this.textBoxSearchManufacturer.ShortcutsEnabled = true;
			this.textBoxSearchManufacturer.Size = new System.Drawing.Size(171, 22);
			this.textBoxSearchManufacturer.TabIndex = 66;
			this.textBoxSearchManufacturer.UseSelectable = true;
			this.textBoxSearchManufacturer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchManufacturer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchManufacturer.TextChanged += new System.EventHandler(this.TextBoxSearchManufacturerTextChanged);
			// 
			// labelSearchSupplier
			// 
			this.labelSearchSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchSupplier.Location = new System.Drawing.Point(215, 63);
			this.labelSearchSupplier.Name = "labelSearchSupplier";
			this.labelSearchSupplier.Size = new System.Drawing.Size(67, 23);
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
			this.textBoxSearchSupplier.CustomButton.Location = new System.Drawing.Point(157, 2);
			this.textBoxSearchSupplier.CustomButton.Name = "";
			this.textBoxSearchSupplier.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchSupplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchSupplier.CustomButton.TabIndex = 1;
			this.textBoxSearchSupplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchSupplier.CustomButton.UseSelectable = true;
			this.textBoxSearchSupplier.CustomButton.Visible = false;
			this.textBoxSearchSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchSupplier.Lines = new string[0];
			this.textBoxSearchSupplier.Location = new System.Drawing.Point(286, 63);
			this.textBoxSearchSupplier.MaxLength = 32767;
			this.textBoxSearchSupplier.Name = "textBoxSearchSupplier";
			this.textBoxSearchSupplier.PasswordChar = '\0';
			this.textBoxSearchSupplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchSupplier.SelectedText = "";
			this.textBoxSearchSupplier.SelectionLength = 0;
			this.textBoxSearchSupplier.SelectionStart = 0;
			this.textBoxSearchSupplier.ShortcutsEnabled = true;
			this.textBoxSearchSupplier.Size = new System.Drawing.Size(177, 22);
			this.textBoxSearchSupplier.TabIndex = 62;
			this.textBoxSearchSupplier.UseSelectable = true;
			this.textBoxSearchSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchSupplier.TextChanged += new System.EventHandler(this.TextBoxSearchSupplierTextChanged);
			// 
			// labelSearchPartNumber
			// 
			this.labelSearchPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchPartNumber.Location = new System.Drawing.Point(2, 65);
			this.labelSearchPartNumber.Name = "labelSearchPartNumber";
			this.labelSearchPartNumber.Size = new System.Drawing.Size(38, 23);
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
			this.textBoxSearchPartNumber.CustomButton.Location = new System.Drawing.Point(149, 2);
			this.textBoxSearchPartNumber.CustomButton.Name = "";
			this.textBoxSearchPartNumber.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxSearchPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearchPartNumber.CustomButton.TabIndex = 1;
			this.textBoxSearchPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearchPartNumber.CustomButton.UseSelectable = true;
			this.textBoxSearchPartNumber.CustomButton.Visible = false;
			this.textBoxSearchPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSearchPartNumber.Lines = new string[0];
			this.textBoxSearchPartNumber.Location = new System.Drawing.Point(46, 65);
			this.textBoxSearchPartNumber.MaxLength = 32767;
			this.textBoxSearchPartNumber.Name = "textBoxSearchPartNumber";
			this.textBoxSearchPartNumber.PasswordChar = '\0';
			this.textBoxSearchPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchPartNumber.SelectedText = "";
			this.textBoxSearchPartNumber.SelectionLength = 0;
			this.textBoxSearchPartNumber.SelectionStart = 0;
			this.textBoxSearchPartNumber.ShortcutsEnabled = true;
			this.textBoxSearchPartNumber.Size = new System.Drawing.Size(169, 22);
			this.textBoxSearchPartNumber.TabIndex = 60;
			this.textBoxSearchPartNumber.UseSelectable = true;
			this.textBoxSearchPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearchPartNumber.TextChanged += new System.EventHandler(this.TextBoxSearchPartNumberTextChanged);
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
			this.ButtonAdd.Location = new System.Drawing.Point(626, 290);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(115, 31);
			this.ButtonAdd.TabIndex = 1;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Selected";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1064, 650);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 244;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			this.buttonOk.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(1145, 650);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 243;
			this.buttonCancel.Text = "Cancel";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.labelTotal);
			this.groupBox1.Controls.Add(this.textBoxTotal);
			this.groupBox1.Controls.Add(this.labelProduct);
			this.groupBox1.Controls.Add(this.dictionaryComboProduct);
			this.groupBox1.Controls.Add(this.dictionaryComboStandard);
			this.groupBox1.Controls.Add(this.comboBoxDetailClass);
			this.groupBox1.Controls.Add(this.labelClass);
			this.groupBox1.Controls.Add(this.labelQuantity);
			this.groupBox1.Controls.Add(this.numericUpDownQuantity);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxProdRemarks);
			this.groupBox1.Controls.Add(this.labelSuppliers);
			this.groupBox1.Controls.Add(this.dataGridViewControlSuppliers);
			this.groupBox1.Controls.Add(this.labelManufacturer);
			this.groupBox1.Controls.Add(this.textBoxManufacturer);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxProdDesc);
			this.groupBox1.Controls.Add(this.labelPartNumber);
			this.groupBox1.Controls.Add(this.textBoxPartNumber);
			this.groupBox1.Controls.Add(this.comboBoxMeasure);
			this.groupBox1.Controls.Add(this.labelMeasure);
			this.groupBox1.Controls.Add(this.labelStandart);
			this.groupBox1.Location = new System.Drawing.Point(758, 65);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 579);
			this.groupBox1.TabIndex = 245;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Product";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(387, 540);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 247;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTotal.Location = new System.Drawing.Point(25, 257);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(39, 19);
			this.labelTotal.TabIndex = 150;
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
			this.textBoxTotal.CustomButton.Location = new System.Drawing.Point(295, 2);
			this.textBoxTotal.CustomButton.Name = "";
			this.textBoxTotal.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTotal.CustomButton.TabIndex = 1;
			this.textBoxTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTotal.CustomButton.UseSelectable = true;
			this.textBoxTotal.CustomButton.Visible = false;
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Lines = new string[0];
			this.textBoxTotal.Location = new System.Drawing.Point(131, 257);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.PasswordChar = '\0';
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTotal.SelectedText = "";
			this.textBoxTotal.SelectionLength = 0;
			this.textBoxTotal.SelectionStart = 0;
			this.textBoxTotal.ShortcutsEnabled = true;
			this.textBoxTotal.Size = new System.Drawing.Size(313, 20);
			this.textBoxTotal.TabIndex = 149;
			this.textBoxTotal.UseSelectable = true;
			this.textBoxTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelProduct
			// 
			this.labelProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProduct.Location = new System.Drawing.Point(25, 19);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(69, 25);
			this.labelProduct.TabIndex = 148;
			this.labelProduct.Text = "Product:";
			this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dictionaryComboProduct
			// 
			this.dictionaryComboProduct.Displayer = null;
			this.dictionaryComboProduct.DisplayerText = null;
			this.dictionaryComboProduct.Entity = null;
			this.dictionaryComboProduct.Location = new System.Drawing.Point(131, 19);
			this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboProduct.Name = "dictionaryComboProduct";
			this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboProduct.Size = new System.Drawing.Size(312, 21);
			this.dictionaryComboProduct.TabIndex = 147;
			this.dictionaryComboProduct.Type = null;
			this.dictionaryComboProduct.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictionaryComboStandard
			// 
			this.dictionaryComboStandard.Displayer = null;
			this.dictionaryComboStandard.DisplayerText = null;
			this.dictionaryComboStandard.Enabled = false;
			this.dictionaryComboStandard.Entity = null;
			this.dictionaryComboStandard.Location = new System.Drawing.Point(131, 45);
			this.dictionaryComboStandard.Name = "dictionaryComboStandard";
			this.dictionaryComboStandard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboStandard.Size = new System.Drawing.Size(312, 21);
			this.dictionaryComboStandard.TabIndex = 129;
			this.dictionaryComboStandard.Type = null;
			this.dictionaryComboStandard.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 106;
			this.comboBoxDetailClass.Enabled = false;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(131, 72);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(312, 21);
			this.comboBoxDetailClass.TabIndex = 130;
			this.comboBoxDetailClass.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelClass
			// 
			this.labelClass.AutoSize = true;
			this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClass.Location = new System.Drawing.Point(25, 72);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(41, 19);
			this.labelClass.TabIndex = 137;
			this.labelClass.Text = "Class:";
			this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelQuantity
			// 
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(25, 228);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(81, 25);
			this.labelQuantity.TabIndex = 138;
			this.labelQuantity.Text = "Quantity:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(131, 232);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(313, 20);
			this.numericUpDownQuantity.TabIndex = 133;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.numericUpDownQuantity_ValueChanged);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(25, 282);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 25);
			this.label1.TabIndex = 145;
			this.label1.Text = "Remarks:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProdRemarks
			// 
			this.textBoxProdRemarks.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxProdRemarks.CustomButton.Image = null;
			this.textBoxProdRemarks.CustomButton.Location = new System.Drawing.Point(225, 2);
			this.textBoxProdRemarks.CustomButton.Name = "";
			this.textBoxProdRemarks.CustomButton.Size = new System.Drawing.Size(85, 85);
			this.textBoxProdRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxProdRemarks.CustomButton.TabIndex = 1;
			this.textBoxProdRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxProdRemarks.CustomButton.UseSelectable = true;
			this.textBoxProdRemarks.CustomButton.Visible = false;
			this.textBoxProdRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProdRemarks.Lines = new string[0];
			this.textBoxProdRemarks.Location = new System.Drawing.Point(131, 282);
			this.textBoxProdRemarks.MaxLength = 100;
			this.textBoxProdRemarks.Multiline = true;
			this.textBoxProdRemarks.Name = "textBoxProdRemarks";
			this.textBoxProdRemarks.PasswordChar = '\0';
			this.textBoxProdRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxProdRemarks.SelectedText = "";
			this.textBoxProdRemarks.SelectionLength = 0;
			this.textBoxProdRemarks.SelectionStart = 0;
			this.textBoxProdRemarks.ShortcutsEnabled = true;
			this.textBoxProdRemarks.Size = new System.Drawing.Size(313, 90);
			this.textBoxProdRemarks.TabIndex = 141;
			this.textBoxProdRemarks.UseSelectable = true;
			this.textBoxProdRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxProdRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelSuppliers
			// 
			this.labelSuppliers.AutoSize = true;
			this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSuppliers.Location = new System.Drawing.Point(196, 375);
			this.labelSuppliers.Name = "labelSuppliers";
			this.labelSuppliers.Size = new System.Drawing.Size(65, 19);
			this.labelSuppliers.TabIndex = 144;
			this.labelSuppliers.Text = "Suppliers:";
			this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridViewControlSuppliers
			// 
			this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewControlSuppliers.Displayer = null;
			this.dataGridViewControlSuppliers.DisplayerText = null;
			this.dataGridViewControlSuppliers.Entity = null;
			this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(28, 398);
			this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
			this.dataGridViewControlSuppliers.ReadOnly = true;
			this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewControlSuppliers.RowHeadersVisible = false;
			this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewControlSuppliers.ShowAddNew = false;
			this.dataGridViewControlSuppliers.ShowDelete = false;
			this.dataGridViewControlSuppliers.ShowQuickSearch = false;
			this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(416, 131);
			this.dataGridViewControlSuppliers.TabIndex = 142;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(25, 178);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(100, 25);
			this.labelManufacturer.TabIndex = 143;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxManufacturer.CustomButton.Image = null;
			this.textBoxManufacturer.CustomButton.Location = new System.Drawing.Point(293, 2);
			this.textBoxManufacturer.CustomButton.Name = "";
			this.textBoxManufacturer.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxManufacturer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxManufacturer.CustomButton.TabIndex = 1;
			this.textBoxManufacturer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxManufacturer.CustomButton.UseSelectable = true;
			this.textBoxManufacturer.CustomButton.Visible = false;
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Lines = new string[0];
			this.textBoxManufacturer.Location = new System.Drawing.Point(131, 178);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.PasswordChar = '\0';
			this.textBoxManufacturer.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxManufacturer.SelectedText = "";
			this.textBoxManufacturer.SelectionLength = 0;
			this.textBoxManufacturer.SelectionStart = 0;
			this.textBoxManufacturer.ShortcutsEnabled = true;
			this.textBoxManufacturer.Size = new System.Drawing.Size(313, 22);
			this.textBoxManufacturer.TabIndex = 139;
			this.textBoxManufacturer.UseSelectable = true;
			this.textBoxManufacturer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxManufacturer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(25, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 25);
			this.label2.TabIndex = 135;
			this.label2.Text = "Description:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProdDesc
			// 
			this.textBoxProdDesc.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxProdDesc.CustomButton.Image = null;
			this.textBoxProdDesc.CustomButton.Location = new System.Drawing.Point(263, 2);
			this.textBoxProdDesc.CustomButton.Name = "";
			this.textBoxProdDesc.CustomButton.Size = new System.Drawing.Size(47, 47);
			this.textBoxProdDesc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxProdDesc.CustomButton.TabIndex = 1;
			this.textBoxProdDesc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxProdDesc.CustomButton.UseSelectable = true;
			this.textBoxProdDesc.CustomButton.Visible = false;
			this.textBoxProdDesc.Enabled = false;
			this.textBoxProdDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProdDesc.Lines = new string[0];
			this.textBoxProdDesc.Location = new System.Drawing.Point(131, 124);
			this.textBoxProdDesc.MaxLength = 128;
			this.textBoxProdDesc.Multiline = true;
			this.textBoxProdDesc.Name = "textBoxProdDesc";
			this.textBoxProdDesc.PasswordChar = '\0';
			this.textBoxProdDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxProdDesc.SelectedText = "";
			this.textBoxProdDesc.SelectionLength = 0;
			this.textBoxProdDesc.SelectionStart = 0;
			this.textBoxProdDesc.ShortcutsEnabled = true;
			this.textBoxProdDesc.Size = new System.Drawing.Size(313, 52);
			this.textBoxProdDesc.TabIndex = 132;
			this.textBoxProdDesc.UseSelectable = true;
			this.textBoxProdDesc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxProdDesc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(25, 98);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(69, 25);
			this.labelPartNumber.TabIndex = 134;
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
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(293, 2);
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
			this.textBoxPartNumber.Location = new System.Drawing.Point(131, 98);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(313, 22);
			this.textBoxPartNumber.TabIndex = 131;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(131, 206);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(313, 21);
			this.comboBoxMeasure.TabIndex = 140;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.comboBoxMeasure_SelectedIndexChanged);
			this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(25, 206);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 146;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStandart
			// 
			this.labelStandart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStandart.Location = new System.Drawing.Point(25, 45);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 25);
			this.labelStandart.TabIndex = 136;
			this.labelStandart.Text = "Standart:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listViewAddedItems
			// 
			this.listViewAddedItems.Displayer = null;
			this.listViewAddedItems.DisplayerText = null;
			this.listViewAddedItems.Entity = null;
			this.listViewAddedItems.IgnoreEnterPress = false;
			this.listViewAddedItems.Location = new System.Drawing.Point(17, 317);
			this.listViewAddedItems.MenuOpeningAction = null;
			this.listViewAddedItems.Name = "listViewAddedItems";
			this.listViewAddedItems.OldColumnIndex = 0;
			this.listViewAddedItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewAddedItems.Size = new System.Drawing.Size(724, 205);
			this.listViewAddedItems.SortDirection = SortDirection.Asc;
			this.listViewAddedItems.TabIndex = 246;
			this.listViewAddedItems.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewAddedItems_SelectedItemsChanged_1);
			// 
			// listViewKits
			// 
			this.listViewKits.Displayer = null;
			this.listViewKits.DisplayerText = null;
			this.listViewKits.Entity = null;
			this.listViewKits.IgnoreEnterPress = false;
			this.listViewKits.Location = new System.Drawing.Point(17, 93);
			this.listViewKits.MenuOpeningAction = null;
			this.listViewKits.Name = "listViewKits";
			this.listViewKits.OldColumnIndex = 2;
			this.listViewKits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewKits.Size = new System.Drawing.Size(724, 190);
			this.listViewKits.SortDirection = SortDirection.Desc;
			this.listViewKits.TabIndex = 67;
			// 
			// RequestForQuotationAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1233, 696);
			this.Controls.Add(this.listViewAddedItems);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.listViewKits);
			this.Controls.Add(this.labelSearchKitManufacturer);
			this.Controls.Add(this.textBoxSearchManufacturer);
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
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(770, 460);
			this.Name = "RequestForQuotationAddForm";
			this.ShowIcon = false;
			this.Text = "Request for Quotation Kit Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private MetroLabel labelSearchPartNumber;
		private MetroTextBox textBoxSearchPartNumber;
		private MetroLabel labelSearchKitManufacturer;
		private MetroTextBox textBoxSearchManufacturer;
		private MetroLabel labelSearchSupplier;
		private MetroTextBox textBoxSearchSupplier;
		private RequestProductListView listViewKits;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private MetroLabel labelTotal;
		private MetroTextBox textBoxTotal;
		private MetroLabel labelProduct;
		private Auxiliary.LookupCombobox dictionaryComboProduct;
		private Auxiliary.LookupCombobox dictionaryComboStandard;
		private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
		private MetroLabel labelClass;
		private MetroLabel labelQuantity;
		private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private MetroLabel label1;
		private MetroTextBox textBoxProdRemarks;
		private MetroLabel labelSuppliers;
		private Auxiliary.CommonDataGridViewControl dataGridViewControlSuppliers;
		private MetroLabel labelManufacturer;
		private MetroTextBox textBoxManufacturer;
		private MetroLabel label2;
		private MetroTextBox textBoxProdDesc;
		private MetroLabel labelPartNumber;
		private MetroTextBox textBoxPartNumber;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private MetroLabel labelMeasure;
		private MetroLabel labelStandart;
		private QuatationOrderListView listViewAddedItems;
		private System.Windows.Forms.Button button1;
	}
}