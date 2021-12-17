using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Controls;
using CASTerms;

using CAS.UI.Helpers;
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	partial class PurchaseOrderForm
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
			this.purchaseRecordListView1 = new CAS.UI.UIControls.PurchaseControls.Purchase.PurchaseRecordListView(true);
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.labelTotal = new MetroFramework.Controls.MetroLabel();
			this.textBoxTotal = new MetroFramework.Controls.MetroTextBox();
			this.labelReason = new MetroFramework.Controls.MetroLabel();
			this.comboBoxCondition = new System.Windows.Forms.ComboBox();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl2 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl3 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl4 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl5 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl6 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl7 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl8 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl9 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.buttonTransferInformation = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// purchaseRecordListView1
			// 
			this.purchaseRecordListView1.ConfigurePaste = null;
			this.purchaseRecordListView1.Displayer = null;
			this.purchaseRecordListView1.DisplayerText = null;
			this.purchaseRecordListView1.EnableCustomSorting = true;
			this.purchaseRecordListView1.Entity = null;
			this.purchaseRecordListView1.IgnoreEnterPress = false;
			this.purchaseRecordListView1.Location = new System.Drawing.Point(7, 63);
			this.purchaseRecordListView1.MenuOpeningAction = null;
			this.purchaseRecordListView1.Name = "purchaseRecordListView1";
			this.purchaseRecordListView1.OldColumnIndex = 2;
			this.purchaseRecordListView1.PasteComplete = null;
			this.purchaseRecordListView1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.purchaseRecordListView1.Size = new System.Drawing.Size(984, 396);
			this.purchaseRecordListView1.SortDirection = SortDirection.Desc;
			this.purchaseRecordListView1.TabIndex = 296;
			this.purchaseRecordListView1.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.PurchaseRecordListView1_SelectedItemsChanged);
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
			this.ButtonDelete.Location = new System.Drawing.Point(869, 466);
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
			// buttonSettings
			// 
			this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSettings.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonSettings.Location = new System.Drawing.Point(1028, 658);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(85, 33);
			this.buttonSettings.TabIndex = 323;
			this.buttonSettings.Text = "Extended";
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1119, 658);
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
			this.buttonCancel.Location = new System.Drawing.Point(1200, 658);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 292;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// comboBoxCurrency
			// 
			this.comboBoxCurrency.Enabled = false;
			this.comboBoxCurrency.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxCurrency.FormattingEnabled = true;
			this.comboBoxCurrency.ItemHeight = 17;
			this.comboBoxCurrency.Location = new System.Drawing.Point(104, 75);
			this.comboBoxCurrency.Name = "comboBoxCurrency";
			this.comboBoxCurrency.Size = new System.Drawing.Size(165, 25);
			this.comboBoxCurrency.TabIndex = 252;
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel2.Location = new System.Drawing.Point(6, 77);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(64, 19);
			this.metroLabel2.TabIndex = 253;
			this.metroLabel2.Text = "Currency:";
			this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownCost
			// 
			this.numericUpDownCost.DecimalPlaces = 2;
			this.numericUpDownCost.Enabled = false;
			this.numericUpDownCost.Location = new System.Drawing.Point(104, 131);
			this.numericUpDownCost.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownCost.Name = "numericUpDownCost";
			this.numericUpDownCost.Size = new System.Drawing.Size(165, 20);
			this.numericUpDownCost.TabIndex = 250;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabel1.Location = new System.Drawing.Point(7, 131);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(38, 19);
			this.metroLabel1.TabIndex = 251;
			this.metroLabel1.Text = "Cost:";
			this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(195, 185);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 249;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.DecimalPlaces = 2;
			this.numericUpDownQuantity.Location = new System.Drawing.Point(104, 105);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(165, 20);
			this.numericUpDownQuantity.TabIndex = 142;
			this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.NumericUpDownQuantity_ValueChanged);
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(7, 105);
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
			this.comboBoxMeasure.Location = new System.Drawing.Point(104, 44);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(165, 25);
			this.comboBoxMeasure.TabIndex = 141;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasure_SelectedIndexChanged);
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMeasure.Location = new System.Drawing.Point(6, 46);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 165;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTotal
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTotal.Location = new System.Drawing.Point(7, 158);
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
			this.textBoxTotal.CustomButton.Location = new System.Drawing.Point(146, 2);
			this.textBoxTotal.CustomButton.Name = "";
			this.textBoxTotal.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTotal.CustomButton.TabIndex = 1;
			this.textBoxTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTotal.CustomButton.UseSelectable = true;
			this.textBoxTotal.CustomButton.Visible = false;
			this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
			this.textBoxTotal.Lines = new string[0];
			this.textBoxTotal.Location = new System.Drawing.Point(104, 157);
			this.textBoxTotal.MaxLength = 128;
			this.textBoxTotal.Name = "textBoxTotal";
			this.textBoxTotal.PasswordChar = '\0';
			this.textBoxTotal.ReadOnly = true;
			this.textBoxTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTotal.SelectedText = "";
			this.textBoxTotal.SelectionLength = 0;
			this.textBoxTotal.SelectionStart = 0;
			this.textBoxTotal.ShortcutsEnabled = true;
			this.textBoxTotal.Size = new System.Drawing.Size(166, 22);
			this.textBoxTotal.TabIndex = 143;
			this.textBoxTotal.UseSelectable = true;
			this.textBoxTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelReason
			// 
			this.labelReason.AutoSize = true;
			this.labelReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReason.Location = new System.Drawing.Point(6, 16);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(69, 19);
			this.labelReason.TabIndex = 170;
			this.labelReason.Text = "Condition:";
			// 
			// comboBoxCondition
			// 
			this.comboBoxCondition.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBoxCondition.FormattingEnabled = true;
			this.comboBoxCondition.ItemHeight = 17;
			this.comboBoxCondition.Location = new System.Drawing.Point(104, 13);
			this.comboBoxCondition.Name = "comboBoxCondition";
			this.comboBoxCondition.Size = new System.Drawing.Size(165, 25);
			this.comboBoxCondition.TabIndex = 169;
			this.comboBoxCondition.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCondition_SelectedIndexChanged);
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(1005, 63);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(270, 41);
			this.documentControl1.TabIndex = 297;
			// 
			// documentControl2
			// 
			this.documentControl2.CurrentDocument = null;
			this.documentControl2.Location = new System.Drawing.Point(1005, 110);
			this.documentControl2.Name = "documentControl2";
			this.documentControl2.Size = new System.Drawing.Size(270, 41);
			this.documentControl2.TabIndex = 298;
			// 
			// documentControl3
			// 
			this.documentControl3.CurrentDocument = null;
			this.documentControl3.Location = new System.Drawing.Point(1005, 157);
			this.documentControl3.Name = "documentControl3";
			this.documentControl3.Size = new System.Drawing.Size(270, 41);
			this.documentControl3.TabIndex = 299;
			// 
			// documentControl4
			// 
			this.documentControl4.CurrentDocument = null;
			this.documentControl4.Location = new System.Drawing.Point(1005, 204);
			this.documentControl4.Name = "documentControl4";
			this.documentControl4.Size = new System.Drawing.Size(270, 41);
			this.documentControl4.TabIndex = 300;
			// 
			// documentControl5
			// 
			this.documentControl5.CurrentDocument = null;
			this.documentControl5.Location = new System.Drawing.Point(1005, 251);
			this.documentControl5.Name = "documentControl5";
			this.documentControl5.Size = new System.Drawing.Size(270, 41);
			this.documentControl5.TabIndex = 301;
			// 
			// documentControl6
			// 
			this.documentControl6.CurrentDocument = null;
			this.documentControl6.Location = new System.Drawing.Point(1005, 298);
			this.documentControl6.Name = "documentControl6";
			this.documentControl6.Size = new System.Drawing.Size(270, 41);
			this.documentControl6.TabIndex = 302;
			// 
			// documentControl7
			// 
			this.documentControl7.CurrentDocument = null;
			this.documentControl7.Location = new System.Drawing.Point(1005, 345);
			this.documentControl7.Name = "documentControl7";
			this.documentControl7.Size = new System.Drawing.Size(270, 41);
			this.documentControl7.TabIndex = 303;
			// 
			// documentControl8
			// 
			this.documentControl8.CurrentDocument = null;
			this.documentControl8.Location = new System.Drawing.Point(1005, 392);
			this.documentControl8.Name = "documentControl8";
			this.documentControl8.Size = new System.Drawing.Size(270, 41);
			this.documentControl8.TabIndex = 304;
			// 
			// documentControl9
			// 
			this.documentControl9.CurrentDocument = null;
			this.documentControl9.Location = new System.Drawing.Point(1005, 439);
			this.documentControl9.Name = "documentControl9";
			this.documentControl9.Size = new System.Drawing.Size(270, 41);
			this.documentControl9.TabIndex = 305;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labelReason);
			this.groupBox3.Controls.Add(this.comboBoxCurrency);
			this.groupBox3.Controls.Add(this.comboBoxCondition);
			this.groupBox3.Controls.Add(this.textBoxTotal);
			this.groupBox3.Controls.Add(this.metroLabel2);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.labelTotal);
			this.groupBox3.Controls.Add(this.labelMeasure);
			this.groupBox3.Controls.Add(this.numericUpDownCost);
			this.groupBox3.Controls.Add(this.comboBoxMeasure);
			this.groupBox3.Controls.Add(this.labelQuantity);
			this.groupBox3.Controls.Add(this.metroLabel1);
			this.groupBox3.Controls.Add(this.numericUpDownQuantity);
			this.groupBox3.Location = new System.Drawing.Point(7, 465);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(291, 225);
			this.groupBox3.TabIndex = 307;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Product";
			// 
			// buttonTransferInformation
			// 
			this.buttonTransferInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTransferInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTransferInformation.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonTransferInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonTransferInformation.Location = new System.Drawing.Point(826, 658);
			this.buttonTransferInformation.Name = "buttonTransferInformation";
			this.buttonTransferInformation.Size = new System.Drawing.Size(196, 33);
			this.buttonTransferInformation.TabIndex = 324;
			this.buttonTransferInformation.Text = "Add Transfer Information";
			this.buttonTransferInformation.Click += new System.EventHandler(this.buttonTransferInformation_Click);
			// 
			// PurchaseOrderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 700);
			this.Controls.Add(this.buttonTransferInformation);
			this.Controls.Add(this.buttonSettings);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.documentControl9);
			this.Controls.Add(this.documentControl8);
			this.Controls.Add(this.documentControl7);
			this.Controls.Add(this.documentControl6);
			this.Controls.Add(this.documentControl5);
			this.Controls.Add(this.documentControl4);
			this.Controls.Add(this.documentControl3);
			this.Controls.Add(this.documentControl2);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.purchaseRecordListView1);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PurchaseOrderForm";
			this.Resizable = false;
			this.Text = "Purchase Order Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
		private MetroLabel labelQuantity;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private MetroLabel labelMeasure;
		private MetroLabel labelTotal;
		private MetroTextBox textBoxTotal;
		private MetroLabel labelReason;
		private System.Windows.Forms.ComboBox comboBoxCondition;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.NumericUpDown numericUpDownCost;
		private MetroLabel metroLabel1;
		private Purchase.PurchaseRecordListView purchaseRecordListView1;
		private System.Windows.Forms.ComboBox comboBoxCurrency;
		private MetroLabel metroLabel2;
		private DocumentationControls.DocumentControl documentControl1;
		private DocumentationControls.DocumentControl documentControl2;
		private DocumentationControls.DocumentControl documentControl3;
		private DocumentationControls.DocumentControl documentControl4;
		private DocumentationControls.DocumentControl documentControl5;
		private DocumentationControls.DocumentControl documentControl6;
		private DocumentationControls.DocumentControl documentControl7;
		private DocumentationControls.DocumentControl documentControl8;
		private DocumentationControls.DocumentControl documentControl9;
		private GroupBox groupBox3;
		private Button buttonSettings;
		private Button buttonTransferInformation;
	}
}