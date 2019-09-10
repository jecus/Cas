using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.WorkPakage
{
	partial class NonRoutineJobForm
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
			this.labelTitle = new MetroFramework.Controls.MetroLabel();
			this.textboxTitle = new MetroFramework.Controls.MetroTextBox();
			this.labelATAChapter = new MetroFramework.Controls.MetroLabel();
			this.textboxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.textboxCost = new MetroFramework.Controls.MetroTextBox();
			this.labelCost = new MetroFramework.Controls.MetroLabel();
			this.textboxManHours = new MetroFramework.Controls.MetroTextBox();
			this.labelManHours = new MetroFramework.Controls.MetroLabel();
			this.textBoxKitRequired = new MetroFramework.Controls.MetroTextBox();
			this.labelKitRequired = new MetroFramework.Controls.MetroLabel();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this._mainPanel = new System.Windows.Forms.Panel();
			this.labelNumber = new MetroFramework.Controls.MetroLabel();
			this.textBoxNumber = new MetroFramework.Controls.MetroTextBox();
			this.linkLabelEditKit = new MetroFramework.Controls.MetroLabel();
			this.labelNonRoutineJobCategory = new MetroFramework.Controls.MetroLabel();
			this.comboBoxCategories = new System.Windows.Forms.ComboBox();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this._workPackageFileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.buttonsPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTitle.Location = new System.Drawing.Point(5, 58);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(100, 23);
			this.labelTitle.TabIndex = 4;
			this.labelTitle.Text = "Title:";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textboxTitle
			// 
			this.textboxTitle.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxTitle, 2);
			// 
			// 
			// 
			this.textboxTitle.CustomButton.Image = null;
			this.textboxTitle.CustomButton.Location = new System.Drawing.Point(280, 2);
			this.textboxTitle.CustomButton.Name = "";
			this.textboxTitle.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textboxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textboxTitle.CustomButton.TabIndex = 1;
			this.textboxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textboxTitle.CustomButton.UseSelectable = true;
			this.textboxTitle.CustomButton.Visible = false;
			this.textboxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxTitle.Lines = new string[0];
			this.textboxTitle.Location = new System.Drawing.Point(113, 59);
			this.textboxTitle.MaxLength = 50;
			this.textboxTitle.Name = "textboxTitle";
			this.textboxTitle.PasswordChar = '\0';
			this.textboxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textboxTitle.SelectedText = "";
			this.textboxTitle.SelectionLength = 0;
			this.textboxTitle.SelectionStart = 0;
			this.textboxTitle.ShortcutsEnabled = true;
			this.textboxTitle.Size = new System.Drawing.Size(300, 22);
			this.textboxTitle.TabIndex = 5;
			this.textboxTitle.UseSelectable = true;
			this.textboxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textboxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelATAChapter
			// 
			this.labelATAChapter.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelATAChapter.Location = new System.Drawing.Point(5, 86);
			this.labelATAChapter.Name = "labelATAChapter";
			this.labelATAChapter.Size = new System.Drawing.Size(100, 23);
			this.labelATAChapter.TabIndex = 6;
			this.labelATAChapter.Text = "ATA Chapter:";
			this.labelATAChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textboxDescription
			// 
			this.textboxDescription.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxDescription, 2);
			// 
			// 
			// 
			this.textboxDescription.CustomButton.Image = null;
			this.textboxDescription.CustomButton.Location = new System.Drawing.Point(234, 2);
			this.textboxDescription.CustomButton.Name = "";
			this.textboxDescription.CustomButton.Size = new System.Drawing.Size(63, 63);
			this.textboxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textboxDescription.CustomButton.TabIndex = 1;
			this.textboxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textboxDescription.CustomButton.UseSelectable = true;
			this.textboxDescription.CustomButton.Visible = false;
			this.textboxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxDescription.Lines = new string[0];
			this.textboxDescription.Location = new System.Drawing.Point(113, 115);
			this.textboxDescription.MaxLength = 1000;
			this.textboxDescription.Multiline = true;
			this.textboxDescription.Name = "textboxDescription";
			this.textboxDescription.PasswordChar = '\0';
			this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxDescription.SelectedText = "";
			this.textboxDescription.SelectionLength = 0;
			this.textboxDescription.SelectionStart = 0;
			this.textboxDescription.ShortcutsEnabled = true;
			this.textboxDescription.Size = new System.Drawing.Size(300, 68);
			this.textboxDescription.TabIndex = 9;
			this.textboxDescription.UseSelectable = true;
			this.textboxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textboxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelDescription
			// 
			this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(5, 115);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(100, 23);
			this.labelDescription.TabIndex = 8;
			this.labelDescription.Text = "Description:";
			// 
			// textboxCost
			// 
			this.textboxCost.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxCost, 2);
			// 
			// 
			// 
			this.textboxCost.CustomButton.Image = null;
			this.textboxCost.CustomButton.Location = new System.Drawing.Point(280, 2);
			this.textboxCost.CustomButton.Name = "";
			this.textboxCost.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textboxCost.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textboxCost.CustomButton.TabIndex = 1;
			this.textboxCost.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textboxCost.CustomButton.UseSelectable = true;
			this.textboxCost.CustomButton.Visible = false;
			this.textboxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxCost.Lines = new string[0];
			this.textboxCost.Location = new System.Drawing.Point(113, 217);
			this.textboxCost.MaxLength = 32767;
			this.textboxCost.Name = "textboxCost";
			this.textboxCost.PasswordChar = '\0';
			this.textboxCost.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textboxCost.SelectedText = "";
			this.textboxCost.SelectionLength = 0;
			this.textboxCost.SelectionStart = 0;
			this.textboxCost.ShortcutsEnabled = true;
			this.textboxCost.Size = new System.Drawing.Size(300, 22);
			this.textboxCost.TabIndex = 13;
			this.textboxCost.UseSelectable = true;
			this.textboxCost.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textboxCost.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelCost
			// 
			this.labelCost.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(5, 216);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(100, 23);
			this.labelCost.TabIndex = 11;
			this.labelCost.Text = "Cost (USD):";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textboxManHours
			// 
			this.textboxManHours.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxManHours, 2);
			// 
			// 
			// 
			this.textboxManHours.CustomButton.Image = null;
			this.textboxManHours.CustomButton.Location = new System.Drawing.Point(280, 2);
			this.textboxManHours.CustomButton.Name = "";
			this.textboxManHours.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textboxManHours.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textboxManHours.CustomButton.TabIndex = 1;
			this.textboxManHours.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textboxManHours.CustomButton.UseSelectable = true;
			this.textboxManHours.CustomButton.Visible = false;
			this.textboxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxManHours.Lines = new string[0];
			this.textboxManHours.Location = new System.Drawing.Point(113, 189);
			this.textboxManHours.MaxLength = 32767;
			this.textboxManHours.Name = "textboxManHours";
			this.textboxManHours.PasswordChar = '\0';
			this.textboxManHours.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textboxManHours.SelectedText = "";
			this.textboxManHours.SelectionLength = 0;
			this.textboxManHours.SelectionStart = 0;
			this.textboxManHours.ShortcutsEnabled = true;
			this.textboxManHours.Size = new System.Drawing.Size(300, 22);
			this.textboxManHours.TabIndex = 12;
			this.textboxManHours.UseSelectable = true;
			this.textboxManHours.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textboxManHours.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelManHours
			// 
			this.labelManHours.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(5, 188);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(100, 23);
			this.labelManHours.TabIndex = 10;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.textBoxKitRequired.CustomButton.Image = null;
			this.textBoxKitRequired.CustomButton.Location = new System.Drawing.Point(234, 2);
			this.textBoxKitRequired.CustomButton.Name = "";
			this.textBoxKitRequired.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxKitRequired.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxKitRequired.CustomButton.TabIndex = 1;
			this.textBoxKitRequired.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxKitRequired.CustomButton.UseSelectable = true;
			this.textBoxKitRequired.CustomButton.Visible = false;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Lines = new string[0];
			this.textBoxKitRequired.Location = new System.Drawing.Point(113, 245);
			this.textBoxKitRequired.MaxLength = 50;
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.PasswordChar = '\0';
			this.textBoxKitRequired.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxKitRequired.SelectedText = "";
			this.textBoxKitRequired.SelectionLength = 0;
			this.textBoxKitRequired.SelectionStart = 0;
			this.textBoxKitRequired.ShortcutsEnabled = true;
			this.textBoxKitRequired.Size = new System.Drawing.Size(254, 22);
			this.textBoxKitRequired.TabIndex = 16;
			this.textBoxKitRequired.UseSelectable = true;
			this.textBoxKitRequired.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxKitRequired.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(5, 244);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(100, 23);
			this.labelKitRequired.TabIndex = 15;
			this.labelKitRequired.Text = "Kit Required:";
			this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(255, 3);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 295;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(335, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 294;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// _mainPanel
			// 
			this._mainPanel.AutoSize = true;
			this._mainPanel.Location = new System.Drawing.Point(3, 3);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(422, 418);
			this._mainPanel.TabIndex = 19;
			// 
			// labelNumber
			// 
			this.labelNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Location = new System.Drawing.Point(5, 30);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(100, 23);
			this.labelNumber.TabIndex = 36;
			this.labelNumber.Text = "JO Number:";
			this.labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelNumber.Visible = false;
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxNumber, 2);
			// 
			// 
			// 
			this.textBoxNumber.CustomButton.Image = null;
			this.textBoxNumber.CustomButton.Location = new System.Drawing.Point(280, 2);
			this.textBoxNumber.CustomButton.Name = "";
			this.textBoxNumber.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNumber.CustomButton.TabIndex = 1;
			this.textBoxNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNumber.CustomButton.UseSelectable = true;
			this.textBoxNumber.CustomButton.Visible = false;
			this.textBoxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNumber.Lines = new string[0];
			this.textBoxNumber.Location = new System.Drawing.Point(113, 31);
			this.textBoxNumber.MaxLength = 50;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.PasswordChar = '\0';
			this.textBoxNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNumber.SelectedText = "";
			this.textBoxNumber.SelectionLength = 0;
			this.textBoxNumber.SelectionStart = 0;
			this.textBoxNumber.ShortcutsEnabled = true;
			this.textBoxNumber.Size = new System.Drawing.Size(300, 22);
			this.textBoxNumber.TabIndex = 37;
			this.textBoxNumber.UseSelectable = true;
			this.textBoxNumber.Visible = false;
			this.textBoxNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelEditKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(379, 246);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(31, 19);
			this.linkLabelEditKit.Style = MetroFramework.MetroColorStyle.Blue;
			this.linkLabelEditKit.TabIndex = 35;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelEditKit.UseCustomForeColor = true;
			this.linkLabelEditKit.Click += new System.EventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// labelNonRoutineJobCategory
			// 
			this.labelNonRoutineJobCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelNonRoutineJobCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNonRoutineJobCategory.Location = new System.Drawing.Point(3, 1);
			this.labelNonRoutineJobCategory.Name = "labelNonRoutineJobCategory";
			this.labelNonRoutineJobCategory.Size = new System.Drawing.Size(104, 25);
			this.labelNonRoutineJobCategory.TabIndex = 19;
			this.labelNonRoutineJobCategory.Text = "Category:";
			this.labelNonRoutineJobCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelNonRoutineJobCategory.Visible = false;
			// 
			// comboBoxCategories
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxCategories, 2);
			this.comboBoxCategories.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCategories.FormattingEnabled = true;
			this.comboBoxCategories.Location = new System.Drawing.Point(113, 3);
			this.comboBoxCategories.Name = "comboBoxCategories";
			this.comboBoxCategories.Size = new System.Drawing.Size(300, 22);
			this.comboBoxCategories.TabIndex = 18;
			this.comboBoxCategories.Visible = false;
			this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategoriesSelectedIndexChanged);
			this.comboBoxCategories.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// buttonsPanel
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.buttonsPanel, 3);
			this.buttonsPanel.Controls.Add(this.buttonOk);
			this.buttonsPanel.Controls.Add(this.buttonCancel);
			this.buttonsPanel.Location = new System.Drawing.Point(3, 359);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(414, 41);
			this.buttonsPanel.TabIndex = 20;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Controls.Add(this.labelNonRoutineJobCategory, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxCategories, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelNumber, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxNumber, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textboxTitle, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelATAChapter, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.ataChapterComboBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelDescription, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.textboxDescription, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelManHours, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.textboxManHours, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelCost, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.textboxCost, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelKitRequired, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.textBoxKitRequired, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelEditKit, 2, 7);
			this.tableLayoutPanel1.Controls.Add(this.fileControl, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this._workPackageFileControl, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.buttonsPanel, 0, 10);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 63);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 11;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 403);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.ataChapterComboBox, 2);
			this.ataChapterComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ataChapterComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Location = new System.Drawing.Point(113, 87);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(300, 22);
			this.ataChapterComboBox.TabIndex = 7;
			this.ataChapterComboBox.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.SetColumnSpan(this.fileControl, 3);
			this.fileControl.Description1 = null;
			this.fileControl.Description2 = null;
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = null;
			this.fileControl.Location = new System.Drawing.Point(3, 273);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 80);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 14;
			// 
			// _workPackageFileControl
			// 
			this._workPackageFileControl.AutoSize = true;
			this._workPackageFileControl.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.SetColumnSpan(this._workPackageFileControl, 3);
			this._workPackageFileControl.Description1 = null;
			this._workPackageFileControl.Description2 = null;
			this._workPackageFileControl.Filter = null;
			this._workPackageFileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this._workPackageFileControl.IconNotEnabled = null;
			this._workPackageFileControl.Location = new System.Drawing.Point(3, 316);
			this._workPackageFileControl.MaximumSize = new System.Drawing.Size(350, 80);
			this._workPackageFileControl.Name = "_workPackageFileControl";
			this._workPackageFileControl.ShowLinkLabelBrowse = true;
			this._workPackageFileControl.ShowLinkLabelRemove = false;
			this._workPackageFileControl.Size = new System.Drawing.Size(350, 37);
			this._workPackageFileControl.TabIndex = 17;
			this._workPackageFileControl.Visible = false;
			// 
			// NonRoutineJobForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(444, 468);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(474, 499);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(444, 359);
			this.Name = "NonRoutineJobForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Non-Routine Job Form";
			this.buttonsPanel.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroLabel labelTitle;
		private MetroTextBox textboxTitle;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private MetroLabel labelATAChapter;
		private MetroTextBox textboxDescription;
		private MetroLabel labelDescription;
		private MetroTextBox textboxCost;
		private MetroLabel labelCost;
		private MetroTextBox textboxManHours;
		private MetroLabel labelManHours;
		private Auxiliary.AttachedFileControl fileControl;
		private MetroTextBox textBoxKitRequired;
		private MetroLabel labelKitRequired;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel _mainPanel;
		private Auxiliary.AttachedFileControl _workPackageFileControl;
		private System.Windows.Forms.Panel buttonsPanel;
		private MetroLabel labelNonRoutineJobCategory;
		private System.Windows.Forms.ComboBox comboBoxCategories;
		public MetroLabel linkLabelEditKit;
		private MetroLabel labelNumber;
		private MetroTextBox textBoxNumber;
		private TableLayoutPanel tableLayoutPanel1;
	}
}