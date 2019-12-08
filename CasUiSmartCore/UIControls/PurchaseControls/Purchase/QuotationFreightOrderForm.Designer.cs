using System.Windows.Forms;
using MetroFramework.Controls;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	partial class QuotationFreightOrderForm
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.metroTextBoxNumber = new MetroFramework.Controls.MetroTextBox();
			this.metroLabelNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxClosingBy = new MetroFramework.Controls.MetroTextBox();
			this.textBoxPublishedBy = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.labelClosedBy = new MetroFramework.Controls.MetroLabel();
			this.labelClosingDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.labelPublishDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerPublishDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerOpeningDate = new System.Windows.Forms.DateTimePicker();
			this.labelOpeningDate = new MetroFramework.Controls.MetroLabel();
			this.labelStatus = new MetroFramework.Controls.MetroLabel();
			this.textBoxAuthor = new MetroFramework.Controls.MetroTextBox();
			this.labelAuthor = new MetroFramework.Controls.MetroLabel();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.labelQOTitle = new MetroFramework.Controls.MetroLabel();
			this.purchaseRecordListView1 = new CAS.UI.UIControls.PurchaseControls.Purchase.QuatationFreightListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.listViewKits = new CAS.UI.UIControls.PurchaseControls.Quatation.RequestProductListView();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonAddSupplierForAll = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxCostType = new System.Windows.Forms.ComboBox();
			this.numericUpDownCostNew = new System.Windows.Forms.NumericUpDown();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(914, 718);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 293;
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
			this.buttonCancel.Location = new System.Drawing.Point(995, 718);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 292;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.metroTextBoxNumber);
			this.groupBox2.Controls.Add(this.metroLabelNumber);
			this.groupBox2.Controls.Add(this.textBoxClosingBy);
			this.groupBox2.Controls.Add(this.textBoxPublishedBy);
			this.groupBox2.Controls.Add(this.comboBoxStatus);
			this.groupBox2.Controls.Add(this.textBoxRemarks);
			this.groupBox2.Controls.Add(this.labelRemarks);
			this.groupBox2.Controls.Add(this.labelClosedBy);
			this.groupBox2.Controls.Add(this.labelClosingDate);
			this.groupBox2.Controls.Add(this.dateTimePickerClosingDate);
			this.groupBox2.Controls.Add(this.labelPublishDate);
			this.groupBox2.Controls.Add(this.dateTimePickerPublishDate);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dateTimePickerOpeningDate);
			this.groupBox2.Controls.Add(this.labelOpeningDate);
			this.groupBox2.Controls.Add(this.labelStatus);
			this.groupBox2.Controls.Add(this.textBoxAuthor);
			this.groupBox2.Controls.Add(this.labelAuthor);
			this.groupBox2.Controls.Add(this.textBoxTitle);
			this.groupBox2.Controls.Add(this.labelQOTitle);
			this.groupBox2.Location = new System.Drawing.Point(777, 63);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(293, 304);
			this.groupBox2.TabIndex = 324;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Purchase";
			// 
			// metroTextBoxNumber
			// 
			// 
			// 
			// 
			this.metroTextBoxNumber.CustomButton.Image = null;
			this.metroTextBoxNumber.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.metroTextBoxNumber.CustomButton.Name = "";
			this.metroTextBoxNumber.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.metroTextBoxNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxNumber.CustomButton.TabIndex = 1;
			this.metroTextBoxNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxNumber.CustomButton.UseSelectable = true;
			this.metroTextBoxNumber.CustomButton.Visible = false;
			this.metroTextBoxNumber.Enabled = false;
			this.metroTextBoxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroTextBoxNumber.Lines = new string[0];
			this.metroTextBoxNumber.Location = new System.Drawing.Point(118, 19);
			this.metroTextBoxNumber.MaxLength = 32767;
			this.metroTextBoxNumber.Name = "metroTextBoxNumber";
			this.metroTextBoxNumber.PasswordChar = '\0';
			this.metroTextBoxNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxNumber.SelectedText = "";
			this.metroTextBoxNumber.SelectionLength = 0;
			this.metroTextBoxNumber.SelectionStart = 0;
			this.metroTextBoxNumber.ShortcutsEnabled = true;
			this.metroTextBoxNumber.Size = new System.Drawing.Size(167, 22);
			this.metroTextBoxNumber.TabIndex = 268;
			this.metroTextBoxNumber.UseSelectable = true;
			this.metroTextBoxNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabelNumber
			// 
			this.metroLabelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelNumber.Location = new System.Drawing.Point(20, 16);
			this.metroLabelNumber.Name = "metroLabelNumber";
			this.metroLabelNumber.Size = new System.Drawing.Size(87, 27);
			this.metroLabelNumber.TabIndex = 269;
			this.metroLabelNumber.Text = "№:";
			this.metroLabelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxClosingBy
			// 
			// 
			// 
			// 
			this.textBoxClosingBy.CustomButton.Image = null;
			this.textBoxClosingBy.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.textBoxClosingBy.CustomButton.Name = "";
			this.textBoxClosingBy.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxClosingBy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxClosingBy.CustomButton.TabIndex = 1;
			this.textBoxClosingBy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxClosingBy.CustomButton.UseSelectable = true;
			this.textBoxClosingBy.CustomButton.Visible = false;
			this.textBoxClosingBy.Enabled = false;
			this.textBoxClosingBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxClosingBy.Lines = new string[0];
			this.textBoxClosingBy.Location = new System.Drawing.Point(118, 242);
			this.textBoxClosingBy.MaxLength = 32767;
			this.textBoxClosingBy.Name = "textBoxClosingBy";
			this.textBoxClosingBy.PasswordChar = '\0';
			this.textBoxClosingBy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxClosingBy.SelectedText = "";
			this.textBoxClosingBy.SelectionLength = 0;
			this.textBoxClosingBy.SelectionStart = 0;
			this.textBoxClosingBy.ShortcutsEnabled = true;
			this.textBoxClosingBy.Size = new System.Drawing.Size(167, 22);
			this.textBoxClosingBy.TabIndex = 267;
			this.textBoxClosingBy.UseSelectable = true;
			this.textBoxClosingBy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxClosingBy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxPublishedBy
			// 
			// 
			// 
			// 
			this.textBoxPublishedBy.CustomButton.Image = null;
			this.textBoxPublishedBy.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.textBoxPublishedBy.CustomButton.Name = "";
			this.textBoxPublishedBy.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxPublishedBy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPublishedBy.CustomButton.TabIndex = 1;
			this.textBoxPublishedBy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPublishedBy.CustomButton.UseSelectable = true;
			this.textBoxPublishedBy.CustomButton.Visible = false;
			this.textBoxPublishedBy.Enabled = false;
			this.textBoxPublishedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPublishedBy.Lines = new string[0];
			this.textBoxPublishedBy.Location = new System.Drawing.Point(118, 187);
			this.textBoxPublishedBy.MaxLength = 32767;
			this.textBoxPublishedBy.Name = "textBoxPublishedBy";
			this.textBoxPublishedBy.PasswordChar = '\0';
			this.textBoxPublishedBy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPublishedBy.SelectedText = "";
			this.textBoxPublishedBy.SelectionLength = 0;
			this.textBoxPublishedBy.SelectionStart = 0;
			this.textBoxPublishedBy.ShortcutsEnabled = true;
			this.textBoxPublishedBy.Size = new System.Drawing.Size(167, 22);
			this.textBoxPublishedBy.TabIndex = 266;
			this.textBoxPublishedBy.UseSelectable = true;
			this.textBoxPublishedBy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPublishedBy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.Enabled = false;
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.ItemHeight = 17;
			this.comboBoxStatus.Location = new System.Drawing.Point(118, 102);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(166, 25);
			this.comboBoxStatus.TabIndex = 265;
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(118, 273);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(167, 22);
			this.textBoxRemarks.TabIndex = 264;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelRemarks
			// 
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(21, 273);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(69, 23);
			this.labelRemarks.TabIndex = 263;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelClosedBy
			// 
			this.labelClosedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClosedBy.Location = new System.Drawing.Point(20, 240);
			this.labelClosedBy.Name = "labelClosedBy";
			this.labelClosedBy.Size = new System.Drawing.Size(94, 23);
			this.labelClosedBy.TabIndex = 261;
			this.labelClosedBy.Text = "Closing By:";
			this.labelClosedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelClosingDate
			// 
			this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClosingDate.Location = new System.Drawing.Point(20, 213);
			this.labelClosingDate.Name = "labelClosingDate";
			this.labelClosingDate.Size = new System.Drawing.Size(94, 23);
			this.labelClosingDate.TabIndex = 260;
			this.labelClosingDate.Text = "Closing date:";
			this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.Enabled = false;
			this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(118, 214);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerClosingDate.TabIndex = 259;
			// 
			// labelPublishDate
			// 
			this.labelPublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPublishDate.Location = new System.Drawing.Point(20, 158);
			this.labelPublishDate.Name = "labelPublishDate";
			this.labelPublishDate.Size = new System.Drawing.Size(94, 23);
			this.labelPublishDate.TabIndex = 258;
			this.labelPublishDate.Text = "Publish. date:";
			this.labelPublishDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerPublishDate
			// 
			this.dateTimePickerPublishDate.Enabled = false;
			this.dateTimePickerPublishDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerPublishDate.Location = new System.Drawing.Point(118, 159);
			this.dateTimePickerPublishDate.Name = "dateTimePickerPublishDate";
			this.dateTimePickerPublishDate.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerPublishDate.TabIndex = 257;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(20, 185);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 23);
			this.label5.TabIndex = 255;
			this.label5.Text = "Publishing By:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerOpeningDate
			// 
			this.dateTimePickerOpeningDate.Enabled = false;
			this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(118, 131);
			this.dateTimePickerOpeningDate.Name = "dateTimePickerOpeningDate";
			this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerOpeningDate.TabIndex = 162;
			// 
			// labelOpeningDate
			// 
			this.labelOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOpeningDate.Location = new System.Drawing.Point(20, 131);
			this.labelOpeningDate.Name = "labelOpeningDate";
			this.labelOpeningDate.Size = new System.Drawing.Size(87, 23);
			this.labelOpeningDate.TabIndex = 163;
			this.labelOpeningDate.Text = "Open. date:";
			this.labelOpeningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStatus.Location = new System.Drawing.Point(20, 102);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(87, 23);
			this.labelStatus.TabIndex = 160;
			this.labelStatus.Text = "Status:";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAuthor
			// 
			// 
			// 
			// 
			this.textBoxAuthor.CustomButton.Image = null;
			this.textBoxAuthor.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.textBoxAuthor.CustomButton.Name = "";
			this.textBoxAuthor.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxAuthor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAuthor.CustomButton.TabIndex = 1;
			this.textBoxAuthor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAuthor.CustomButton.UseSelectable = true;
			this.textBoxAuthor.CustomButton.Visible = false;
			this.textBoxAuthor.Enabled = false;
			this.textBoxAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAuthor.Lines = new string[0];
			this.textBoxAuthor.Location = new System.Drawing.Point(118, 75);
			this.textBoxAuthor.MaxLength = 32767;
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.PasswordChar = '\0';
			this.textBoxAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAuthor.SelectedText = "";
			this.textBoxAuthor.SelectionLength = 0;
			this.textBoxAuthor.SelectionStart = 0;
			this.textBoxAuthor.ShortcutsEnabled = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(167, 22);
			this.textBoxAuthor.TabIndex = 159;
			this.textBoxAuthor.UseSelectable = true;
			this.textBoxAuthor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAuthor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelAuthor
			// 
			this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAuthor.Location = new System.Drawing.Point(20, 74);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(87, 23);
			this.labelAuthor.TabIndex = 158;
			this.labelAuthor.Text = "Author:";
			this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTitle
			// 
			// 
			// 
			// 
			this.textBoxTitle.CustomButton.Image = null;
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(147, 2);
			this.textBoxTitle.CustomButton.Name = "";
			this.textBoxTitle.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTitle.CustomButton.TabIndex = 1;
			this.textBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTitle.CustomButton.UseSelectable = true;
			this.textBoxTitle.CustomButton.Visible = false;
			this.textBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTitle.Lines = new string[0];
			this.textBoxTitle.Location = new System.Drawing.Point(118, 47);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.SelectionLength = 0;
			this.textBoxTitle.SelectionStart = 0;
			this.textBoxTitle.ShortcutsEnabled = true;
			this.textBoxTitle.Size = new System.Drawing.Size(167, 22);
			this.textBoxTitle.TabIndex = 2;
			this.textBoxTitle.UseSelectable = true;
			this.textBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelQOTitle
			// 
			this.labelQOTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQOTitle.Location = new System.Drawing.Point(20, 44);
			this.labelQOTitle.Name = "labelQOTitle";
			this.labelQOTitle.Size = new System.Drawing.Size(87, 27);
			this.labelQOTitle.TabIndex = 3;
			this.labelQOTitle.Text = "Title:";
			this.labelQOTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// purchaseRecordListView1
			// 
			this.purchaseRecordListView1.ConfigurePaste = null;
			this.purchaseRecordListView1.Displayer = null;
			this.purchaseRecordListView1.DisplayerText = null;
			this.purchaseRecordListView1.EnableCustomSorting = true;
			this.purchaseRecordListView1.Entity = null;
			this.purchaseRecordListView1.IgnoreEnterPress = false;
			this.purchaseRecordListView1.Location = new System.Drawing.Point(23, 397);
			this.purchaseRecordListView1.MenuOpeningAction = null;
			this.purchaseRecordListView1.Name = "purchaseRecordListView1";
			this.purchaseRecordListView1.OldColumnIndex = 2;
			this.purchaseRecordListView1.PasteComplete = null;
			this.purchaseRecordListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.purchaseRecordListView1.Size = new System.Drawing.Size(740, 303);
			this.purchaseRecordListView1.SortMultiplier = 1;
			this.purchaseRecordListView1.TabIndex = 296;
			this.purchaseRecordListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.PurchaseRecordListView1_SelectedItemsChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBoxCostType);
			this.groupBox1.Controls.Add(this.numericUpDownCostNew);
			this.groupBox1.Controls.Add(this.metroLabel3);
			this.groupBox1.Controls.Add(this.metroLabel1);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.metroTextBox1);
			this.groupBox1.Controls.Add(this.metroLabel2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(777, 397);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(294, 237);
			this.groupBox1.TabIndex = 325;
			this.groupBox1.TabStop = false;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button3.Location = new System.Drawing.Point(62, 189);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(125, 33);
			this.button3.TabIndex = 269;
			this.button3.Text = "Apply for PO";
			// 
			// metroTextBox1
			// 
			// 
			// 
			// 
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(80, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(87, 87);
			this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new System.Drawing.Point(120, 19);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Multiline = true;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new System.Drawing.Size(168, 89);
			this.metroTextBox1.TabIndex = 267;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel2
			// 
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(23, 18);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(69, 23);
			this.metroLabel2.TabIndex = 266;
			this.metroLabel2.Text = "Remarks:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(193, 189);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			// 
			// listViewKits
			// 
			this.listViewKits.ConfigurePaste = null;
			this.listViewKits.Displayer = null;
			this.listViewKits.DisplayerText = null;
			this.listViewKits.EnableCustomSorting = true;
			this.listViewKits.Entity = null;
			this.listViewKits.IgnoreEnterPress = false;
			this.listViewKits.Location = new System.Drawing.Point(23, 63);
			this.listViewKits.MenuOpeningAction = null;
			this.listViewKits.Name = "listViewKits";
			this.listViewKits.OldColumnIndex = 2;
			this.listViewKits.PasteComplete = null;
			this.listViewKits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewKits.Size = new System.Drawing.Size(740, 290);
			this.listViewKits.SortMultiplier = 1;
			this.listViewKits.TabIndex = 326;
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
			this.ButtonAdd.Location = new System.Drawing.Point(647, 357);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
			this.ButtonAdd.TabIndex = 327;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Selected";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
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
			this.ButtonDelete.Location = new System.Drawing.Point(641, 714);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
			this.ButtonDelete.TabIndex = 328;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			// 
			// buttonAddSupplierForAll
			// 
			this.buttonAddSupplierForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddSupplierForAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddSupplierForAll.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddSupplierForAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAddSupplierForAll.Location = new System.Drawing.Point(262, 713);
			this.buttonAddSupplierForAll.Name = "buttonAddSupplierForAll";
			this.buttonAddSupplierForAll.Size = new System.Drawing.Size(160, 33);
			this.buttonAddSupplierForAll.TabIndex = 330;
			this.buttonAddSupplierForAll.Text = "Add Supplier For All";
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.ItemHeight = 17;
			this.comboBox1.Location = new System.Drawing.Point(23, 718);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(233, 25);
			this.comboBox1.TabIndex = 329;
			// 
			// metroLabel1
			// 
			this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel1.Location = new System.Drawing.Point(23, 114);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(69, 23);
			this.metroLabel1.TabIndex = 270;
			this.metroLabel1.Text = "Cost:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroLabel3
			// 
			this.metroLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel3.Location = new System.Drawing.Point(23, 140);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(69, 23);
			this.metroLabel3.TabIndex = 271;
			this.metroLabel3.Text = "Currency:";
			this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxCostType
			// 
			this.comboBoxCostType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCostType.FormattingEnabled = true;
			this.comboBoxCostType.ItemHeight = 13;
			this.comboBoxCostType.Location = new System.Drawing.Point(120, 140);
			this.comboBoxCostType.Name = "comboBoxCostType";
			this.comboBoxCostType.Size = new System.Drawing.Size(168, 21);
			this.comboBoxCostType.TabIndex = 315;
			// 
			// numericUpDownCostNew
			// 
			this.numericUpDownCostNew.DecimalPlaces = 2;
			this.numericUpDownCostNew.Location = new System.Drawing.Point(120, 114);
			this.numericUpDownCostNew.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownCostNew.Name = "numericUpDownCostNew";
			this.numericUpDownCostNew.Size = new System.Drawing.Size(168, 20);
			this.numericUpDownCostNew.TabIndex = 314;
			// 
			// QuotationFreightOrderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1075, 760);
			this.Controls.Add(this.buttonAddSupplierForAll);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.listViewKits);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.purchaseRecordListView1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuotationFreightOrderForm";
			this.Resizable = false;
			this.Text = "Quotation Freight Form";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostNew)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private Purchase.QuatationFreightListView purchaseRecordListView1;
		private GroupBox groupBox2;
		private MetroTextBox metroTextBoxNumber;
		private MetroLabel metroLabelNumber;
		private MetroTextBox textBoxClosingBy;
		private MetroTextBox textBoxPublishedBy;
		private ComboBox comboBoxStatus;
		private MetroTextBox textBoxRemarks;
		private MetroLabel labelRemarks;
		private MetroLabel labelClosedBy;
		private MetroLabel labelClosingDate;
		private DateTimePicker dateTimePickerClosingDate;
		private MetroLabel labelPublishDate;
		private DateTimePicker dateTimePickerPublishDate;
		private MetroLabel label5;
		private DateTimePicker dateTimePickerOpeningDate;
		private MetroLabel labelOpeningDate;
		private MetroLabel labelStatus;
		private MetroTextBox textBoxAuthor;
		private MetroLabel labelAuthor;
		private MetroTextBox textBoxTitle;
		private MetroLabel labelQOTitle;
		private GroupBox groupBox1;
		private Button button3;
		private MetroTextBox metroTextBox1;
		private MetroLabel metroLabel2;
		private Button button1;
		private Quatation.RequestProductListView listViewKits;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private MetroLabel metroLabel3;
		private MetroLabel metroLabel1;
		private Button buttonAddSupplierForAll;
		private ComboBox comboBox1;
		private ComboBox comboBoxCostType;
		private NumericUpDown numericUpDownCostNew;
	}
}