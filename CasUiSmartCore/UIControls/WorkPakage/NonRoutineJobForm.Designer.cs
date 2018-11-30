using System.Drawing;
using System.Windows.Forms;

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
			this.labelTitle = new System.Windows.Forms.Label();
			this.textboxTitle = new System.Windows.Forms.TextBox();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.labelATAChapter = new System.Windows.Forms.Label();
			this.textboxDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textboxCost = new System.Windows.Forms.TextBox();
			this.labelCost = new System.Windows.Forms.Label();
			this.textboxManHours = new System.Windows.Forms.TextBox();
			this.labelManHours = new System.Windows.Forms.Label();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this._mainPanel = new System.Windows.Forms.Panel();
			this.labelNumber = new System.Windows.Forms.Label();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.labelNonRoutineJobCategory = new System.Windows.Forms.Label();
			this.comboBoxCategories = new System.Windows.Forms.ComboBox();
			this._workPackageFileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this._mainPanel.SuspendLayout();
			this.buttonsPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.TextAlign = ContentAlignment.MiddleLeft;
			this.labelTitle.Anchor = AnchorStyles.None;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.TabIndex = 4;
			this.labelTitle.Text = "Title:";
			// 
			// textboxTitle
			// 
			this.textboxTitle.BackColor = System.Drawing.Color.White;
			this.textboxTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxTitle.MaxLength = 50;
			this.textboxTitle.Name = "textboxTitle";
			this.textboxTitle.Size = new System.Drawing.Size(300, 22);
			this.textboxTitle.TabIndex = 5;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.BackColor = System.Drawing.Color.White;
			this.ataChapterComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ataChapterComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(300, 22);
			this.ataChapterComboBox.TabIndex = 7;
			// 
			// labelATAChapter
			// 
			this.labelATAChapter.TextAlign = ContentAlignment.MiddleLeft;
			this.labelATAChapter.Anchor = AnchorStyles.None;
			this.labelATAChapter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelATAChapter.Name = "labelATAChapter";
			this.labelATAChapter.TabIndex = 6;
			this.labelATAChapter.Text = "ATA Chapter:";
			// 
			// textboxDescription
			// 
			this.textboxDescription.BackColor = System.Drawing.Color.White;
			this.textboxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxDescription.MaxLength = 1000;
			this.textboxDescription.Multiline = true;
			this.textboxDescription.Name = "textboxDescription";
			this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxDescription.Size = new System.Drawing.Size(300, 68);
			this.textboxDescription.TabIndex = 9;
			// 
			// labelDescription
			// 
			this.labelDescription.TextAlign = ContentAlignment.TopLeft;
			this.labelDescription.Anchor = AnchorStyles.Top;
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.TabIndex = 8;
			this.labelDescription.Text = "Description:";
			// 
			// textboxCost
			// 
			this.textboxCost.BackColor = System.Drawing.Color.White;
			this.textboxCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxCost.Name = "textboxCost";
			this.textboxCost.Size = new System.Drawing.Size(300, 22);
			this.textboxCost.TabIndex = 13;
			// 
			// labelCost
			// 
			this.labelCost.TextAlign = ContentAlignment.MiddleLeft;
			this.labelCost.Anchor = AnchorStyles.None;
			this.labelCost.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Name = "labelCost";
			this.labelCost.TabIndex = 11;
			this.labelCost.Text = "Cost (USD):";
			// 
			// textboxManHours
			// 
			this.textboxManHours.BackColor = System.Drawing.Color.White;
			this.textboxManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxManHours.Name = "textboxManHours";
			this.textboxManHours.Size = new System.Drawing.Size(300, 22);
			this.textboxManHours.TabIndex = 12;
			// 
			// labelManHours
			// 
			this.labelManHours.TextAlign = ContentAlignment.MiddleLeft;
			this.labelManHours.Anchor = AnchorStyles.None;
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.TabIndex = 10;
			this.labelManHours.Text = "Man Hours:";
			// 
			// fileControl
			// 
			this.fileControl.AttachedFile = null;
			this.fileControl.AutoSize = true;
			this.fileControl.BackColor = System.Drawing.Color.Transparent;
			this.fileControl.Description1 = null;
			this.fileControl.Description2 = null;
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = null;
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 70);
			this.fileControl.Name = "fileControl";
			this.fileControl.Size = new System.Drawing.Size(350, 70);
			this.fileControl.TabIndex = 14;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.MaxLength = 50;
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(257, 22);
			this.textBoxKitRequired.TabIndex = 16;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.TextAlign = ContentAlignment.MiddleLeft;
			this.labelKitRequired.Anchor = AnchorStyles.None;
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.TabIndex = 15;
			this.labelKitRequired.Text = "Kit Required:";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(255, 3);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 17;
			this.buttonOk.Text = "Add";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(335, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 18;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// _mainPanel
			// 
			this._mainPanel.AutoSize = true;
			this._mainPanel.Controls.Add(this.labelNumber);
			this._mainPanel.Controls.Add(this.textBoxNumber);
			this._mainPanel.Controls.Add(this.linkLabelEditKit);
			this._mainPanel.Controls.Add(this.labelNonRoutineJobCategory);
			this._mainPanel.Controls.Add(this.comboBoxCategories);
			this._mainPanel.Controls.Add(this._workPackageFileControl);
			this._mainPanel.Controls.Add(this.labelTitle);
			this._mainPanel.Controls.Add(this.textboxTitle);
			this._mainPanel.Controls.Add(this.labelATAChapter);
			this._mainPanel.Controls.Add(this.textBoxKitRequired);
			this._mainPanel.Controls.Add(this.ataChapterComboBox);
			this._mainPanel.Controls.Add(this.labelKitRequired);
			this._mainPanel.Controls.Add(this.labelDescription);
			this._mainPanel.Controls.Add(this.fileControl);
			this._mainPanel.Controls.Add(this.textboxDescription);
			this._mainPanel.Controls.Add(this.textboxCost);
			this._mainPanel.Controls.Add(this.labelManHours);
			this._mainPanel.Controls.Add(this.labelCost);
			this._mainPanel.Controls.Add(this.textboxManHours);
			this._mainPanel.Location = new System.Drawing.Point(3, 3);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(422, 418);
			this._mainPanel.TabIndex = 19;
			// 
			// labelNumber
			// 
			this.labelNumber.TextAlign = ContentAlignment.MiddleLeft;
			this.labelNumber.Anchor = AnchorStyles.None;
			this.labelNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.TabIndex = 36;
			this.labelNumber.Text = "JO Number:";
			this.labelNumber.Visible = false;
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.BackColor = System.Drawing.Color.White;
			this.textBoxNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNumber.MaxLength = 50;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(300, 22);
			this.textBoxNumber.TabIndex = 37;
			this.textBoxNumber.Visible = false;
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 35;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = ContentAlignment.MiddleLeft;
			this.linkLabelEditKit.Anchor = AnchorStyles.None;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// labelNonRoutineJobCategory
			// 
			this.labelNonRoutineJobCategory.TextAlign = ContentAlignment.MiddleLeft;
			this.labelNonRoutineJobCategory.Anchor = AnchorStyles.None;
			this.labelNonRoutineJobCategory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNonRoutineJobCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNonRoutineJobCategory.Name = "labelNonRoutineJobCategory";
			this.labelNonRoutineJobCategory.Size = new System.Drawing.Size(110, 25);
			this.labelNonRoutineJobCategory.TabIndex = 19;
			this.labelNonRoutineJobCategory.Text = "Category:";
			this.labelNonRoutineJobCategory.Visible = false;
			// 
			// comboBoxCategories
			// 
			this.comboBoxCategories.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCategories.FormattingEnabled = true;
			this.comboBoxCategories.Name = "comboBoxCategories";
			this.comboBoxCategories.Size = new System.Drawing.Size(300, 22);
			this.comboBoxCategories.TabIndex = 18;
			this.comboBoxCategories.Visible = false;
			this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategoriesSelectedIndexChanged);
			// 
			// _workPackageFileControl
			// 
			this._workPackageFileControl.AttachedFile = null;
			this._workPackageFileControl.AutoSize = true;
			this._workPackageFileControl.BackColor = System.Drawing.Color.Transparent;
			this._workPackageFileControl.Description1 = null;
			this._workPackageFileControl.Description2 = null;
			this._workPackageFileControl.Filter = null;
			this._workPackageFileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this._workPackageFileControl.IconNotEnabled = null;
			this._workPackageFileControl.MaximumSize = new System.Drawing.Size(350, 70);
			this._workPackageFileControl.Name = "_workPackageFileControl";
			this._workPackageFileControl.Size = new System.Drawing.Size(350, 70);
			this._workPackageFileControl.TabIndex = 17;
			this._workPackageFileControl.Visible = false;
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.Controls.Add(this.buttonOk);
			this.buttonsPanel.Controls.Add(this.buttonCancel);
			this.buttonsPanel.Location = new System.Drawing.Point(3, 427);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(422, 32);
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

			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxCategories, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxNumber, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.textboxTitle, 2);
			this.tableLayoutPanel1.SetColumnSpan(this._workPackageFileControl, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.ataChapterComboBox, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.textboxDescription, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.textboxManHours, 2);
			this.tableLayoutPanel1.SetColumnSpan(this.textboxCost, 2);
			this.tableLayoutPanel1.SetColumnSpan(this._workPackageFileControl, 3);
			this.tableLayoutPanel1.SetColumnSpan(this.fileControl, 3);
			this.tableLayoutPanel1.SetColumnSpan(this.buttonsPanel, 3);

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

			// 
			// NonRoutineJobForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(430, 461);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(474, 499);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(444, 359);
			this.Name = "NonRoutineJobForm";
			this.ShowIcon = false;
			this.Text = "Non-Routine Job Form";
			this._mainPanel.ResumeLayout(false);
			this._mainPanel.PerformLayout();
			this.buttonsPanel.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textboxTitle;
		private Auxiliary.ATAChapterComboBox ataChapterComboBox;
		private System.Windows.Forms.Label labelATAChapter;
		private System.Windows.Forms.TextBox textboxDescription;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textboxCost;
		private System.Windows.Forms.Label labelCost;
		private System.Windows.Forms.TextBox textboxManHours;
		private System.Windows.Forms.Label labelManHours;
		private Auxiliary.AttachedFileControl fileControl;
		private System.Windows.Forms.TextBox textBoxKitRequired;
		private System.Windows.Forms.Label labelKitRequired;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel _mainPanel;
		private Auxiliary.AttachedFileControl _workPackageFileControl;
		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.Label labelNonRoutineJobCategory;
		private System.Windows.Forms.ComboBox comboBoxCategories;
		public System.Windows.Forms.LinkLabel linkLabelEditKit;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.TextBox textBoxNumber;
		private TableLayoutPanel tableLayoutPanel1;
	}
}