﻿using System.ComponentModel;
using MetroFramework.Controls;
using CASTerms;

using CAS.UI.Helpers;
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	partial class InitialOrderFormNew
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
			this.labelSearchPartNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearchPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.metroTextBoxReference = new MetroFramework.Controls.MetroTextBox();
			this.metroLabelReference = new MetroFramework.Controls.MetroLabel();
			this.metroLabelStation = new MetroFramework.Controls.MetroLabel();
			this.comboBoxStation = new System.Windows.Forms.ComboBox();
			this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDIR = new System.Windows.Forms.ComboBox();
			this.comboBoxPriority = new System.Windows.Forms.ComboBox();
			this.label19 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.labelDefferedCategory = new MetroFramework.Controls.MetroLabel();
			this.labelDestination = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDestination = new System.Windows.Forms.ComboBox();
			this.checkBoxRepair = new MetroFramework.Controls.MetroCheckBox();
			this.checkBoxOverhaul = new MetroFramework.Controls.MetroCheckBox();
			this.checkBoxServiceable = new MetroFramework.Controls.MetroCheckBox();
			this.checkBoxNew = new MetroFramework.Controls.MetroCheckBox();
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this._formListViewInitialItems = new CAS.UI.UIControls.PurchaseControls.Initial.InitialOrderFormListView();
			this.listViewKits = new CAS.UI.UIControls.PurchaseControls.Quatation.RequestProductListView();
			this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			this.button2 = new System.Windows.Forms.Button();
			this.buttonAddProd = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelSearchPartNumber
			// 
			this.labelSearchPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelSearchPartNumber.Location = new System.Drawing.Point(18, 63);
			this.labelSearchPartNumber.Name = "labelSearchPartNumber";
			this.labelSearchPartNumber.Size = new System.Drawing.Size(59, 23);
			this.labelSearchPartNumber.TabIndex = 284;
			this.labelSearchPartNumber.Text = "Search:";
			this.labelSearchPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.textBoxSearchPartNumber.Location = new System.Drawing.Point(83, 63);
			this.textBoxSearchPartNumber.MaxLength = 32767;
			this.textBoxSearchPartNumber.Name = "textBoxSearchPartNumber";
			this.textBoxSearchPartNumber.PasswordChar = '\0';
			this.textBoxSearchPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearchPartNumber.SelectedText = "";
			this.textBoxSearchPartNumber.SelectionLength = 0;
			this.textBoxSearchPartNumber.SelectionStart = 0;
			this.textBoxSearchPartNumber.ShortcutsEnabled = true;
			this.textBoxSearchPartNumber.Size = new System.Drawing.Size(170, 22);
			this.textBoxSearchPartNumber.TabIndex = 285;
			this.textBoxSearchPartNumber.UseSelectable = true;
			this.textBoxSearchPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearchPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
			this.ButtonAdd.Location = new System.Drawing.Point(844, 371);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
			this.ButtonAdd.TabIndex = 288;
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
			this.ButtonDelete.Location = new System.Drawing.Point(838, 690);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
			this.ButtonDelete.TabIndex = 289;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.metroTextBoxReference);
			this.groupBox1.Controls.Add(this.metroLabelReference);
			this.groupBox1.Controls.Add(this.metroLabelStation);
			this.groupBox1.Controls.Add(this.comboBoxStation);
			this.groupBox1.Controls.Add(this.metroTextBox1);
			this.groupBox1.Controls.Add(this.metroLabel2);
			this.groupBox1.Controls.Add(this.comboBoxDIR);
			this.groupBox1.Controls.Add(this.comboBoxPriority);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.numericUpDownQuantity);
			this.groupBox1.Controls.Add(this.labelQuantity);
			this.groupBox1.Controls.Add(this.comboBoxMeasure);
			this.groupBox1.Controls.Add(this.labelMeasure);
			this.groupBox1.Controls.Add(this.labelDefferedCategory);
			this.groupBox1.Controls.Add(this.labelDestination);
			this.groupBox1.Controls.Add(this.comboBoxDestination);
			this.groupBox1.Controls.Add(this.checkBoxRepair);
			this.groupBox1.Controls.Add(this.checkBoxOverhaul);
			this.groupBox1.Controls.Add(this.checkBoxServiceable);
			this.groupBox1.Controls.Add(this.checkBoxNew);
			this.groupBox1.Location = new System.Drawing.Point(972, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 337);
			this.groupBox1.TabIndex = 290;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Product";
			// 
			// metroTextBoxReference
			// 
			// 
			// 
			// 
			this.metroTextBoxReference.CustomButton.Image = null;
			this.metroTextBoxReference.CustomButton.Location = new System.Drawing.Point(129, 2);
			this.metroTextBoxReference.CustomButton.Name = "";
			this.metroTextBoxReference.CustomButton.Size = new System.Drawing.Size(39, 39);
			this.metroTextBoxReference.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBoxReference.CustomButton.TabIndex = 1;
			this.metroTextBoxReference.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBoxReference.CustomButton.UseSelectable = true;
			this.metroTextBoxReference.CustomButton.Visible = false;
			this.metroTextBoxReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroTextBoxReference.Lines = new string[0];
			this.metroTextBoxReference.Location = new System.Drawing.Point(118, 248);
			this.metroTextBoxReference.MaxLength = 32767;
			this.metroTextBoxReference.Multiline = true;
			this.metroTextBoxReference.Name = "metroTextBoxReference";
			this.metroTextBoxReference.PasswordChar = '\0';
			this.metroTextBoxReference.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBoxReference.SelectedText = "";
			this.metroTextBoxReference.SelectionLength = 0;
			this.metroTextBoxReference.SelectionStart = 0;
			this.metroTextBoxReference.ShortcutsEnabled = true;
			this.metroTextBoxReference.Size = new System.Drawing.Size(171, 44);
			this.metroTextBoxReference.TabIndex = 271;
			this.metroTextBoxReference.UseSelectable = true;
			this.metroTextBoxReference.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBoxReference.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabelReference
			// 
			this.metroLabelReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelReference.Location = new System.Drawing.Point(21, 247);
			this.metroLabelReference.Name = "metroLabelReference";
			this.metroLabelReference.Size = new System.Drawing.Size(75, 23);
			this.metroLabelReference.TabIndex = 270;
			this.metroLabelReference.Text = "Reference:";
			this.metroLabelReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// metroLabelStation
			// 
			this.metroLabelStation.AutoSize = true;
			this.metroLabelStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelStation.Location = new System.Drawing.Point(20, 52);
			this.metroLabelStation.Name = "metroLabelStation";
			this.metroLabelStation.Size = new System.Drawing.Size(52, 19);
			this.metroLabelStation.TabIndex = 269;
			this.metroLabelStation.Text = "Station:";
			// 
			// comboBoxStation
			// 
			this.comboBoxStation.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxStation.FormattingEnabled = true;
			this.comboBoxStation.ItemHeight = 17;
			this.comboBoxStation.Location = new System.Drawing.Point(118, 50);
			this.comboBoxStation.Name = "comboBoxStation";
			this.comboBoxStation.Size = new System.Drawing.Size(170, 25);
			this.comboBoxStation.TabIndex = 268;
			// 
			// metroTextBox1
			// 
			// 
			// 
			// 
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(151, 2);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new System.Drawing.Point(118, 220);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new System.Drawing.Size(171, 22);
			this.metroTextBox1.TabIndex = 267;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel2
			// 
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(21, 219);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(69, 23);
			this.metroLabel2.TabIndex = 266;
			this.metroLabel2.Text = "IPC Ref.:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxDIR
			// 
			this.comboBoxDIR.Enabled = false;
			this.comboBoxDIR.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDIR.FormattingEnabled = true;
			this.comboBoxDIR.ItemHeight = 17;
			this.comboBoxDIR.Location = new System.Drawing.Point(118, 81);
			this.comboBoxDIR.Name = "comboBoxDIR";
			this.comboBoxDIR.Size = new System.Drawing.Size(170, 25);
			this.comboBoxDIR.TabIndex = 252;
			// 
			// comboBoxPriority
			// 
			this.comboBoxPriority.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxPriority.FormattingEnabled = true;
			this.comboBoxPriority.ItemHeight = 17;
			this.comboBoxPriority.Location = new System.Drawing.Point(118, 112);
			this.comboBoxPriority.Name = "comboBoxPriority";
			this.comboBoxPriority.Size = new System.Drawing.Size(170, 25);
			this.comboBoxPriority.TabIndex = 250;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label19.Location = new System.Drawing.Point(20, 114);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(54, 19);
			this.label19.TabIndex = 251;
			this.label19.Text = "Priority:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(212, 300);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(118, 195);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(170, 20);
			this.numericUpDownQuantity.TabIndex = 142;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.numericUpDownQuantity_ValueChanged);
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(20, 196);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(61, 19);
			this.labelQuantity.TabIndex = 158;
			this.labelQuantity.Text = "Quantity:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.Enabled = false;
			this.comboBoxMeasure.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.ItemHeight = 17;
			this.comboBoxMeasure.Location = new System.Drawing.Point(118, 164);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(170, 25);
			this.comboBoxMeasure.TabIndex = 141;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.comboBoxMeasure_SelectedIndexChanged);
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(20, 166);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 165;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDefferedCategory
			// 
			this.labelDefferedCategory.AutoSize = true;
			this.labelDefferedCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDefferedCategory.Location = new System.Drawing.Point(20, 81);
			this.labelDefferedCategory.Name = "labelDefferedCategory";
			this.labelDefferedCategory.Size = new System.Drawing.Size(32, 19);
			this.labelDefferedCategory.TabIndex = 161;
			this.labelDefferedCategory.Text = "DIR:";
			// 
			// labelDestination
			// 
			this.labelDestination.AutoSize = true;
			this.labelDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDestination.Location = new System.Drawing.Point(20, 21);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(76, 19);
			this.labelDestination.TabIndex = 172;
			this.labelDestination.Text = "Destination:";
			// 
			// comboBoxDestination
			// 
			this.comboBoxDestination.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxDestination.FormattingEnabled = true;
			this.comboBoxDestination.ItemHeight = 17;
			this.comboBoxDestination.Location = new System.Drawing.Point(118, 19);
			this.comboBoxDestination.Name = "comboBoxDestination";
			this.comboBoxDestination.Size = new System.Drawing.Size(170, 25);
			this.comboBoxDestination.TabIndex = 171;
			// 
			// checkBoxRepair
			// 
			this.checkBoxRepair.AutoSize = true;
			this.checkBoxRepair.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRepair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxRepair.Location = new System.Drawing.Point(232, 169);
			this.checkBoxRepair.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxRepair.Name = "checkBoxRepair";
			this.checkBoxRepair.Size = new System.Drawing.Size(56, 15);
			this.checkBoxRepair.TabIndex = 153;
			this.checkBoxRepair.Text = "Repair";
			this.checkBoxRepair.UseSelectable = true;
			// 
			// checkBoxOverhaul
			// 
			this.checkBoxOverhaul.AutoSize = true;
			this.checkBoxOverhaul.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxOverhaul.Location = new System.Drawing.Point(187, 142);
			this.checkBoxOverhaul.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxOverhaul.Name = "checkBoxOverhaul";
			this.checkBoxOverhaul.Size = new System.Drawing.Size(41, 15);
			this.checkBoxOverhaul.TabIndex = 152;
			this.checkBoxOverhaul.Text = "OH";
			this.checkBoxOverhaul.UseSelectable = true;
			// 
			// checkBoxServiceable
			// 
			this.checkBoxServiceable.AutoSize = true;
			this.checkBoxServiceable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxServiceable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxServiceable.Location = new System.Drawing.Point(135, 142);
			this.checkBoxServiceable.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxServiceable.Name = "checkBoxServiceable";
			this.checkBoxServiceable.Size = new System.Drawing.Size(48, 15);
			this.checkBoxServiceable.TabIndex = 151;
			this.checkBoxServiceable.Text = "Serv.";
			this.checkBoxServiceable.UseSelectable = true;
			// 
			// checkBoxNew
			// 
			this.checkBoxNew.AutoSize = true;
			this.checkBoxNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxNew.Location = new System.Drawing.Point(84, 142);
			this.checkBoxNew.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxNew.Name = "checkBoxNew";
			this.checkBoxNew.Size = new System.Drawing.Size(47, 15);
			this.checkBoxNew.TabIndex = 150;
			this.checkBoxNew.Text = "New";
			this.checkBoxNew.UseSelectable = true;
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
			this.groupBox2.Location = new System.Drawing.Point(972, 350);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(293, 319);
			this.groupBox2.TabIndex = 291;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Initial";
			// 
			// metroTextBoxNumber
			// 
			// 
			// 
			// 
			this.metroTextBoxNumber.CustomButton.Image = null;
			this.metroTextBoxNumber.CustomButton.Location = new System.Drawing.Point(150, 2);
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
			this.metroTextBoxNumber.Size = new System.Drawing.Size(170, 22);
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
			this.textBoxClosingBy.CustomButton.Location = new System.Drawing.Point(150, 2);
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
			this.textBoxClosingBy.Size = new System.Drawing.Size(170, 22);
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
			this.textBoxPublishedBy.CustomButton.Location = new System.Drawing.Point(150, 2);
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
			this.textBoxPublishedBy.Size = new System.Drawing.Size(170, 22);
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
			this.comboBoxStatus.Size = new System.Drawing.Size(169, 25);
			this.comboBoxStatus.TabIndex = 265;
			this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(128, 1);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(41, 41);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(118, 270);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(170, 43);
			this.textBoxRemarks.TabIndex = 264;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelRemarks
			// 
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(20, 270);
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
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(169, 22);
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
			this.dateTimePickerPublishDate.Size = new System.Drawing.Size(169, 22);
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
			this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(169, 22);
			this.dateTimePickerOpeningDate.TabIndex = 162;
			this.dateTimePickerOpeningDate.ValueChanged += new System.EventHandler(this.dateTimePickerOpeningDate_ValueChanged);
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
			this.textBoxAuthor.CustomButton.Location = new System.Drawing.Point(150, 2);
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
			this.textBoxAuthor.Size = new System.Drawing.Size(170, 22);
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
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(150, 2);
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
			this.textBoxTitle.Size = new System.Drawing.Size(170, 22);
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
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1115, 679);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 293;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(1196, 679);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 292;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// _formListViewInitialItems
			// 
			this._formListViewInitialItems.ConfigurePaste = null;
			this._formListViewInitialItems.Displayer = null;
			this._formListViewInitialItems.DisplayerText = null;
			this._formListViewInitialItems.EnableCustomSorting = true;
			this._formListViewInitialItems.Entity = null;
			this._formListViewInitialItems.IgnoreEnterPress = false;
			this._formListViewInitialItems.Location = new System.Drawing.Point(18, 403);
			this._formListViewInitialItems.MenuOpeningAction = null;
			this._formListViewInitialItems.Name = "_formListViewInitialItems";
			this._formListViewInitialItems.OldColumnIndex = 0;
			this._formListViewInitialItems.PasteComplete = null;
			this._formListViewInitialItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this._formListViewInitialItems.Size = new System.Drawing.Size(942, 280);
			this._formListViewInitialItems.SortDirection = SortDirection.Asc;
			this._formListViewInitialItems.TabIndex = 294;
			this._formListViewInitialItems.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewInitialItems_SelectedItemsChanged);
			// 
			// listViewKits
			// 
			this.listViewKits.ConfigurePaste = null;
			this.listViewKits.Displayer = null;
			this.listViewKits.DisplayerText = null;
			this.listViewKits.EnableCustomSorting = true;
			this.listViewKits.Entity = null;
			this.listViewKits.IgnoreEnterPress = false;
			this.listViewKits.Location = new System.Drawing.Point(18, 91);
			this.listViewKits.MenuOpeningAction = null;
			this.listViewKits.Name = "listViewKits";
			this.listViewKits.OldColumnIndex = 2;
			this.listViewKits.PasteComplete = null;
			this.listViewKits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewKits.Size = new System.Drawing.Size(942, 280);
			this.listViewKits.SortDirection = SortDirection.Desc;
			this.listViewKits.TabIndex = 68;
			// 
			// metroProgressSpinner1
			// 
			this.metroProgressSpinner1.Location = new System.Drawing.Point(393, 162);
			this.metroProgressSpinner1.Maximum = 100;
			this.metroProgressSpinner1.Name = "metroProgressSpinner1";
			this.metroProgressSpinner1.Size = new System.Drawing.Size(180, 156);
			this.metroProgressSpinner1.Speed = 2F;
			this.metroProgressSpinner1.TabIndex = 302;
			this.metroProgressSpinner1.UseSelectable = true;
			this.metroProgressSpinner1.Visible = false;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button2.Location = new System.Drawing.Point(885, 52);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 33);
			this.button2.TabIndex = 303;
			this.button2.Text = "Find";
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// buttonAddProd
			// 
			this.buttonAddProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddProd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAddProd.Location = new System.Drawing.Point(966, 679);
			this.buttonAddProd.Name = "buttonAddProd";
			this.buttonAddProd.Size = new System.Drawing.Size(143, 33);
			this.buttonAddProd.TabIndex = 304;
			this.buttonAddProd.Text = "Add New Product";
			this.buttonAddProd.Click += new System.EventHandler(this.ButtonAddProduct_Click);
			// 
			// InitialOrderFormNew
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttonAddProd);
			this.Controls.Add(this.metroProgressSpinner1);
			this.Controls.Add(this._formListViewInitialItems);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.labelSearchPartNumber);
			this.Controls.Add(this.textBoxSearchPartNumber);
			this.Controls.Add(this.listViewKits);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InitialOrderFormNew";
			this.Resizable = false;
			this.Text = "Initial Order Form";
			this.Load += new System.EventHandler(this.InitialOrderFormNew_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Quatation.RequestProductListView listViewKits;
		private MetroLabel labelSearchPartNumber;
		private MetroTextBox textBoxSearchPartNumber;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBoxPriority;
		private MetroLabel label19;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private MetroLabel labelQuantity;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private MetroLabel labelMeasure;
		private MetroLabel labelDefferedCategory;
		private MetroLabel labelDestination;
		private System.Windows.Forms.ComboBox comboBoxDestination;
		private MetroCheckBox checkBoxRepair;
		private MetroCheckBox checkBoxOverhaul;
		private MetroCheckBox checkBoxServiceable;
		private MetroCheckBox checkBoxNew;
		private System.Windows.Forms.GroupBox groupBox2;
		private MetroTextBox textBoxTitle;
		private MetroLabel labelQOTitle;
		private MetroTextBox textBoxAuthor;
		private MetroLabel labelAuthor;
		private MetroLabel labelStatus;
		private System.Windows.Forms.DateTimePicker dateTimePickerOpeningDate;
		private MetroLabel labelOpeningDate;
		private MetroLabel label5;
		private MetroLabel labelPublishDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerPublishDate;
		private MetroLabel labelClosingDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private MetroLabel labelClosedBy;
		private MetroTextBox textBoxRemarks;
		private MetroLabel labelRemarks;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private InitialOrderFormListView _formListViewInitialItems;
		private System.Windows.Forms.ComboBox comboBoxStatus;
		private MetroTextBox metroTextBox1;
		private MetroLabel metroLabel2;
		private System.Windows.Forms.ComboBox comboBoxDIR;
		private MetroTextBox textBoxClosingBy;
		private MetroTextBox textBoxPublishedBy;
		private MetroTextBox metroTextBoxNumber;
		private MetroLabel metroLabelNumber;
		private MetroProgressSpinner metroProgressSpinner1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button buttonAddProd;
		private MetroLabel metroLabelStation;
		private System.Windows.Forms.ComboBox comboBoxStation;
		private MetroTextBox metroTextBoxReference;
		private MetroLabel metroLabelReference;
	}
}