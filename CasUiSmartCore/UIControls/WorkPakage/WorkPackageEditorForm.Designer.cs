using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.WorkPakage
{
	partial class WorkPackageEditorForm
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
			MetroFramework.Controls.MetroLabel labelNumber;
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel labelValidFrom;
			MetroFramework.Controls.MetroLabel label2;
			MetroFramework.Controls.MetroLabel label3;
			MetroFramework.Controls.MetroLabel label9;
			MetroFramework.Controls.MetroLabel label10;
			MetroFramework.Controls.MetroLabel label11;
			MetroFramework.Controls.MetroLabel label12;
			MetroFramework.Controls.MetroLabel label14;
			MetroFramework.Controls.MetroLabel label18;
			MetroFramework.Controls.MetroLabel labelWorkType;
			MetroFramework.Controls.MetroLabel label4;
			MetroFramework.Controls.MetroLabel label6;
			MetroFramework.Controls.MetroLabel label7;
			MetroFramework.Controls.MetroLabel label13;
			MetroFramework.Controls.MetroLabel label15;
			MetroFramework.Controls.MetroLabel label17;
			MetroFramework.Controls.MetroLabel metroLabel1;
			MetroFramework.Controls.MetroLabel metroLabel2;
			this.textBoxWpNumber = new MetroFramework.Controls.MetroTextBox();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.dateTimePickerIssueCreateDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerPublishingDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxAuthor = new MetroFramework.Controls.MetroTextBox();
			this.textBoxStatus = new MetroFramework.Controls.MetroTextBox();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerOpeningDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl2 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl3 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl4 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl5 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl6 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl7 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl8 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl9 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl10 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lookupComboboxFlightNum = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.lookupComboboxTo = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.label19 = new System.Windows.Forms.Label();
			this.lookupComboboxFrom = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.dateTimePickerFlightDate = new System.Windows.Forms.DateTimePicker();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.linkLabelEditComponents = new System.Windows.Forms.LinkLabel();
			this.textBoxClosedBy = new MetroFramework.Controls.MetroTextBox();
			this.textBoxPublishingRemark = new MetroFramework.Controls.MetroTextBox();
			this.textBoxMRO = new MetroFramework.Controls.MetroTextBox();
			this.textBoxPublishedBy = new MetroFramework.Controls.MetroTextBox();
			this.textBoxClosingRemarks = new MetroFramework.Controls.MetroTextBox();
			this.textBoxStation = new MetroFramework.Controls.MetroTextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
			labelNumber = new MetroFramework.Controls.MetroLabel();
			label1 = new MetroFramework.Controls.MetroLabel();
			labelValidFrom = new MetroFramework.Controls.MetroLabel();
			label2 = new MetroFramework.Controls.MetroLabel();
			label3 = new MetroFramework.Controls.MetroLabel();
			label9 = new MetroFramework.Controls.MetroLabel();
			label10 = new MetroFramework.Controls.MetroLabel();
			label11 = new MetroFramework.Controls.MetroLabel();
			label12 = new MetroFramework.Controls.MetroLabel();
			label14 = new MetroFramework.Controls.MetroLabel();
			label18 = new MetroFramework.Controls.MetroLabel();
			labelWorkType = new MetroFramework.Controls.MetroLabel();
			label4 = new MetroFramework.Controls.MetroLabel();
			label6 = new MetroFramework.Controls.MetroLabel();
			label7 = new MetroFramework.Controls.MetroLabel();
			label13 = new MetroFramework.Controls.MetroLabel();
			label15 = new MetroFramework.Controls.MetroLabel();
			label17 = new MetroFramework.Controls.MetroLabel();
			metroLabel1 = new MetroFramework.Controls.MetroLabel();
			metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// labelNumber
			// 
			labelNumber.AutoSize = true;
			labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelNumber.Location = new System.Drawing.Point(23, 117);
			labelNumber.Name = "labelNumber";
			labelNumber.Size = new System.Drawing.Size(84, 19);
			labelNumber.TabIndex = 26;
			labelNumber.Text = "WP/WO No:";
			labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(23, 169);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 19);
			label1.TabIndex = 28;
			label1.Text = "Description:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidFrom
			// 
			labelValidFrom.AutoSize = true;
			labelValidFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidFrom.Location = new System.Drawing.Point(23, 195);
			labelValidFrom.Name = "labelValidFrom";
			labelValidFrom.Size = new System.Drawing.Size(82, 19);
			labelValidFrom.TabIndex = 31;
			labelValidFrom.Text = "Create Date:";
			labelValidFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(23, 251);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(102, 19);
			label2.TabIndex = 33;
			label2.Text = "Publishing Date:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(23, 307);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(53, 19);
			label3.TabIndex = 34;
			label3.Text = "Author:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label9.Location = new System.Drawing.Point(23, 63);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(46, 19);
			label9.TabIndex = 48;
			label9.Text = "Status:";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label10.Location = new System.Drawing.Point(23, 143);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(36, 19);
			label10.TabIndex = 46;
			label10.Text = "Title:";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label11.Location = new System.Drawing.Point(23, 279);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(86, 19);
			label11.TabIndex = 53;
			label11.Text = "Closing Date:";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label12.Location = new System.Drawing.Point(23, 223);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(94, 19);
			label12.TabIndex = 51;
			label12.Text = "Opening Date:";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label14.Location = new System.Drawing.Point(446, 170);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(57, 19);
			label14.TabIndex = 56;
			label14.Text = "Remark:";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label18.Location = new System.Drawing.Point(446, 242);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(72, 19);
			label18.TabIndex = 64;
			label18.Text = "Document:";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelWorkType
			// 
			labelWorkType.AutoSize = true;
			labelWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelWorkType.Location = new System.Drawing.Point(23, 89);
			labelWorkType.Name = "labelWorkType";
			labelWorkType.Size = new System.Drawing.Size(74, 19);
			labelWorkType.TabIndex = 253;
			labelWorkType.Text = "Work Type:";
			labelWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxWpNumber
			// 
			// 
			// 
			// 
			this.textBoxWpNumber.CustomButton.Image = null;
			this.textBoxWpNumber.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxWpNumber.CustomButton.Name = "";
			this.textBoxWpNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxWpNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxWpNumber.CustomButton.TabIndex = 1;
			this.textBoxWpNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxWpNumber.CustomButton.UseSelectable = true;
			this.textBoxWpNumber.CustomButton.Visible = false;
			this.textBoxWpNumber.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxWpNumber.Lines = new string[0];
			this.textBoxWpNumber.Location = new System.Drawing.Point(180, 117);
			this.textBoxWpNumber.MaxLength = 32767;
			this.textBoxWpNumber.Name = "textBoxWpNumber";
			this.textBoxWpNumber.PasswordChar = '\0';
			this.textBoxWpNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxWpNumber.SelectedText = "";
			this.textBoxWpNumber.SelectionLength = 0;
			this.textBoxWpNumber.SelectionStart = 0;
			this.textBoxWpNumber.ShortcutsEnabled = true;
			this.textBoxWpNumber.Size = new System.Drawing.Size(251, 20);
			this.textBoxWpNumber.TabIndex = 27;
			this.textBoxWpNumber.UseSelectable = true;
			this.textBoxWpNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxWpNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxDescription
			// 
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(180, 169);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(251, 20);
			this.textBoxDescription.TabIndex = 29;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerIssueCreateDate
			// 
			this.dateTimePickerIssueCreateDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerIssueCreateDate.Enabled = false;
			this.dateTimePickerIssueCreateDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerIssueCreateDate.Location = new System.Drawing.Point(180, 195);
			this.dateTimePickerIssueCreateDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerIssueCreateDate.Name = "dateTimePickerIssueCreateDate";
			this.dateTimePickerIssueCreateDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerIssueCreateDate.TabIndex = 30;
			// 
			// dateTimePickerPublishingDate
			// 
			this.dateTimePickerPublishingDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerPublishingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerPublishingDate.Location = new System.Drawing.Point(180, 251);
			this.dateTimePickerPublishingDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerPublishingDate.Name = "dateTimePickerPublishingDate";
			this.dateTimePickerPublishingDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerPublishingDate.TabIndex = 32;
			// 
			// textBoxAuthor
			// 
			// 
			// 
			// 
			this.textBoxAuthor.CustomButton.Image = null;
			this.textBoxAuthor.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxAuthor.CustomButton.Name = "";
			this.textBoxAuthor.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxAuthor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAuthor.CustomButton.TabIndex = 1;
			this.textBoxAuthor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAuthor.CustomButton.UseSelectable = true;
			this.textBoxAuthor.CustomButton.Visible = false;
			this.textBoxAuthor.Enabled = false;
			this.textBoxAuthor.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxAuthor.Lines = new string[0];
			this.textBoxAuthor.Location = new System.Drawing.Point(180, 307);
			this.textBoxAuthor.MaxLength = 32767;
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.PasswordChar = '\0';
			this.textBoxAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAuthor.SelectedText = "";
			this.textBoxAuthor.SelectionLength = 0;
			this.textBoxAuthor.SelectionStart = 0;
			this.textBoxAuthor.ShortcutsEnabled = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(251, 20);
			this.textBoxAuthor.TabIndex = 35;
			this.textBoxAuthor.UseSelectable = true;
			this.textBoxAuthor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAuthor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxStatus
			// 
			// 
			// 
			// 
			this.textBoxStatus.CustomButton.Image = null;
			this.textBoxStatus.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxStatus.CustomButton.Name = "";
			this.textBoxStatus.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxStatus.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxStatus.CustomButton.TabIndex = 1;
			this.textBoxStatus.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxStatus.CustomButton.UseSelectable = true;
			this.textBoxStatus.CustomButton.Visible = false;
			this.textBoxStatus.Enabled = false;
			this.textBoxStatus.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxStatus.Lines = new string[0];
			this.textBoxStatus.Location = new System.Drawing.Point(180, 63);
			this.textBoxStatus.MaxLength = 32767;
			this.textBoxStatus.Name = "textBoxStatus";
			this.textBoxStatus.PasswordChar = '\0';
			this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxStatus.SelectedText = "";
			this.textBoxStatus.SelectionLength = 0;
			this.textBoxStatus.SelectionStart = 0;
			this.textBoxStatus.ShortcutsEnabled = true;
			this.textBoxStatus.Size = new System.Drawing.Size(251, 20);
			this.textBoxStatus.TabIndex = 49;
			this.textBoxStatus.UseSelectable = true;
			this.textBoxStatus.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxStatus.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxTitle
			// 
			// 
			// 
			// 
			this.textBoxTitle.CustomButton.Image = null;
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxTitle.CustomButton.Name = "";
			this.textBoxTitle.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTitle.CustomButton.TabIndex = 1;
			this.textBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTitle.CustomButton.UseSelectable = true;
			this.textBoxTitle.CustomButton.Visible = false;
			this.textBoxTitle.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxTitle.Lines = new string[0];
			this.textBoxTitle.Location = new System.Drawing.Point(180, 143);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.SelectionLength = 0;
			this.textBoxTitle.SelectionStart = 0;
			this.textBoxTitle.ShortcutsEnabled = true;
			this.textBoxTitle.Size = new System.Drawing.Size(251, 20);
			this.textBoxTitle.TabIndex = 47;
			this.textBoxTitle.UseSelectable = true;
			this.textBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(180, 279);
			this.dateTimePickerClosingDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerClosingDate.TabIndex = 52;
			// 
			// dateTimePickerOpeningDate
			// 
			this.dateTimePickerOpeningDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(180, 223);
			this.dateTimePickerOpeningDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerOpeningDate.Name = "dateTimePickerOpeningDate";
			this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerOpeningDate.TabIndex = 50;
			// 
			// textBoxRemarks
			// 
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(291, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(39, 39);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(521, 170);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(333, 44);
			this.textBoxRemarks.TabIndex = 57;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(694, 694);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 242;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(775, 694);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 241;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(540, 220);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(314, 41);
			this.documentControl1.TabIndex = 65;
			// 
			// documentControl2
			// 
			this.documentControl2.CurrentDocument = null;
			this.documentControl2.Location = new System.Drawing.Point(540, 267);
			this.documentControl2.Name = "documentControl2";
			this.documentControl2.Size = new System.Drawing.Size(314, 41);
			this.documentControl2.TabIndex = 243;
			// 
			// documentControl3
			// 
			this.documentControl3.CurrentDocument = null;
			this.documentControl3.Location = new System.Drawing.Point(540, 314);
			this.documentControl3.Name = "documentControl3";
			this.documentControl3.Size = new System.Drawing.Size(314, 41);
			this.documentControl3.TabIndex = 244;
			// 
			// documentControl4
			// 
			this.documentControl4.CurrentDocument = null;
			this.documentControl4.Location = new System.Drawing.Point(540, 361);
			this.documentControl4.Name = "documentControl4";
			this.documentControl4.Size = new System.Drawing.Size(314, 41);
			this.documentControl4.TabIndex = 245;
			// 
			// documentControl5
			// 
			this.documentControl5.CurrentDocument = null;
			this.documentControl5.Location = new System.Drawing.Point(540, 408);
			this.documentControl5.Name = "documentControl5";
			this.documentControl5.Size = new System.Drawing.Size(314, 41);
			this.documentControl5.TabIndex = 246;
			// 
			// documentControl6
			// 
			this.documentControl6.CurrentDocument = null;
			this.documentControl6.Location = new System.Drawing.Point(540, 455);
			this.documentControl6.Name = "documentControl6";
			this.documentControl6.Size = new System.Drawing.Size(314, 41);
			this.documentControl6.TabIndex = 247;
			// 
			// documentControl7
			// 
			this.documentControl7.CurrentDocument = null;
			this.documentControl7.Location = new System.Drawing.Point(541, 502);
			this.documentControl7.Name = "documentControl7";
			this.documentControl7.Size = new System.Drawing.Size(314, 41);
			this.documentControl7.TabIndex = 248;
			// 
			// documentControl8
			// 
			this.documentControl8.CurrentDocument = null;
			this.documentControl8.Location = new System.Drawing.Point(540, 549);
			this.documentControl8.Name = "documentControl8";
			this.documentControl8.Size = new System.Drawing.Size(314, 41);
			this.documentControl8.TabIndex = 249;
			// 
			// documentControl9
			// 
			this.documentControl9.CurrentDocument = null;
			this.documentControl9.Location = new System.Drawing.Point(541, 596);
			this.documentControl9.Name = "documentControl9";
			this.documentControl9.Size = new System.Drawing.Size(314, 41);
			this.documentControl9.TabIndex = 250;
			// 
			// documentControl10
			// 
			this.documentControl10.CurrentDocument = null;
			this.documentControl10.Location = new System.Drawing.Point(540, 643);
			this.documentControl10.Name = "documentControl10";
			this.documentControl10.Size = new System.Drawing.Size(314, 41);
			this.documentControl10.TabIndex = 251;
			// 
			// comboBoxWorkType
			// 
			this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkType.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxWorkType.FormattingEnabled = true;
			this.comboBoxWorkType.Location = new System.Drawing.Point(180, 89);
			this.comboBoxWorkType.Name = "comboBoxWorkType";
			this.comboBoxWorkType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxWorkType.TabIndex = 252;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lookupComboboxFlightNum);
			this.groupBox1.Controls.Add(this.lookupComboboxTo);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.lookupComboboxFrom);
			this.groupBox1.Controls.Add(this.dateTimePickerFlightDate);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Location = new System.Drawing.Point(448, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 131);
			this.groupBox1.TabIndex = 254;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Perform after";
			// 
			// lookupComboboxFlightNum
			// 
			this.lookupComboboxFlightNum.Displayer = null;
			this.lookupComboboxFlightNum.DisplayerText = null;
			this.lookupComboboxFlightNum.Entity = null;
			this.lookupComboboxFlightNum.Location = new System.Drawing.Point(73, 19);
			this.lookupComboboxFlightNum.Name = "lookupComboboxFlightNum";
			this.lookupComboboxFlightNum.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFlightNum.Size = new System.Drawing.Size(317, 21);
			this.lookupComboboxFlightNum.TabIndex = 35;
			this.lookupComboboxFlightNum.Type = null;
			// 
			// lookupComboboxTo
			// 
			this.lookupComboboxTo.Displayer = null;
			this.lookupComboboxTo.DisplayerText = null;
			this.lookupComboboxTo.Entity = null;
			this.lookupComboboxTo.Location = new System.Drawing.Point(73, 97);
			this.lookupComboboxTo.Name = "lookupComboboxTo";
			this.lookupComboboxTo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxTo.Size = new System.Drawing.Size(317, 21);
			this.lookupComboboxTo.TabIndex = 34;
			this.lookupComboboxTo.Type = null;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(6, 99);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(20, 13);
			this.label19.TabIndex = 33;
			this.label19.Text = "To";
			// 
			// lookupComboboxFrom
			// 
			this.lookupComboboxFrom.Displayer = null;
			this.lookupComboboxFrom.DisplayerText = null;
			this.lookupComboboxFrom.Entity = null;
			this.lookupComboboxFrom.Location = new System.Drawing.Point(73, 70);
			this.lookupComboboxFrom.Name = "lookupComboboxFrom";
			this.lookupComboboxFrom.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxFrom.Size = new System.Drawing.Size(317, 21);
			this.lookupComboboxFrom.TabIndex = 32;
			this.lookupComboboxFrom.Type = null;
			// 
			// dateTimePickerFlightDate
			// 
			this.dateTimePickerFlightDate.Location = new System.Drawing.Point(73, 45);
			this.dateTimePickerFlightDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerFlightDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerFlightDate.Name = "dateTimePickerFlightDate";
			this.dateTimePickerFlightDate.Size = new System.Drawing.Size(317, 20);
			this.dateTimePickerFlightDate.TabIndex = 31;
			this.dateTimePickerFlightDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(6, 74);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(30, 13);
			this.label20.TabIndex = 30;
			this.label20.Text = "From";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(6, 50);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(30, 13);
			this.label21.TabIndex = 29;
			this.label21.Text = "Date";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(6, 24);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(49, 13);
			this.label22.TabIndex = 28;
			this.label22.Text = "Flight No";
			// 
			// linkLabelEditComponents
			// 
			this.linkLabelEditComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditComponents.Location = new System.Drawing.Point(393, 513);
			this.linkLabelEditComponents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditComponents.Name = "linkLabelEditComponents";
			this.linkLabelEditComponents.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditComponents.TabIndex = 259;
			this.linkLabelEditComponents.TabStop = true;
			this.linkLabelEditComponents.Text = "Edit";
			this.linkLabelEditComponents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditComponents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditComponents_LinkClicked);
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label4.Location = new System.Drawing.Point(23, 385);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(70, 19);
			label4.TabIndex = 36;
			label4.Text = "Closed By:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxClosedBy
			// 
			// 
			// 
			// 
			this.textBoxClosedBy.CustomButton.Image = null;
			this.textBoxClosedBy.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxClosedBy.CustomButton.Name = "";
			this.textBoxClosedBy.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxClosedBy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxClosedBy.CustomButton.TabIndex = 1;
			this.textBoxClosedBy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxClosedBy.CustomButton.UseSelectable = true;
			this.textBoxClosedBy.CustomButton.Visible = false;
			this.textBoxClosedBy.Enabled = false;
			this.textBoxClosedBy.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxClosedBy.Lines = new string[0];
			this.textBoxClosedBy.Location = new System.Drawing.Point(180, 385);
			this.textBoxClosedBy.MaxLength = 32767;
			this.textBoxClosedBy.Name = "textBoxClosedBy";
			this.textBoxClosedBy.PasswordChar = '\0';
			this.textBoxClosedBy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxClosedBy.SelectedText = "";
			this.textBoxClosedBy.SelectionLength = 0;
			this.textBoxClosedBy.SelectionStart = 0;
			this.textBoxClosedBy.ShortcutsEnabled = true;
			this.textBoxClosedBy.Size = new System.Drawing.Size(251, 20);
			this.textBoxClosedBy.TabIndex = 37;
			this.textBoxClosedBy.UseSelectable = true;
			this.textBoxClosedBy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxClosedBy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label6.Location = new System.Drawing.Point(23, 360);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(125, 19);
			label6.TabIndex = 38;
			label6.Text = "Publishing Remarks:";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxPublishingRemark
			// 
			// 
			// 
			// 
			this.textBoxPublishingRemark.CustomButton.Image = null;
			this.textBoxPublishingRemark.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxPublishingRemark.CustomButton.Name = "";
			this.textBoxPublishingRemark.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxPublishingRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPublishingRemark.CustomButton.TabIndex = 1;
			this.textBoxPublishingRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPublishingRemark.CustomButton.UseSelectable = true;
			this.textBoxPublishingRemark.CustomButton.Visible = false;
			this.textBoxPublishingRemark.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxPublishingRemark.Lines = new string[0];
			this.textBoxPublishingRemark.Location = new System.Drawing.Point(180, 359);
			this.textBoxPublishingRemark.MaxLength = 32767;
			this.textBoxPublishingRemark.Name = "textBoxPublishingRemark";
			this.textBoxPublishingRemark.PasswordChar = '\0';
			this.textBoxPublishingRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPublishingRemark.SelectedText = "";
			this.textBoxPublishingRemark.SelectionLength = 0;
			this.textBoxPublishingRemark.SelectionStart = 0;
			this.textBoxPublishingRemark.ShortcutsEnabled = true;
			this.textBoxPublishingRemark.Size = new System.Drawing.Size(251, 20);
			this.textBoxPublishingRemark.TabIndex = 39;
			this.textBoxPublishingRemark.UseSelectable = true;
			this.textBoxPublishingRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPublishingRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label7.Location = new System.Drawing.Point(23, 437);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(43, 19);
			label7.TabIndex = 44;
			label7.Text = "MRO:";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxMRO
			// 
			// 
			// 
			// 
			this.textBoxMRO.CustomButton.Image = null;
			this.textBoxMRO.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxMRO.CustomButton.Name = "";
			this.textBoxMRO.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxMRO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxMRO.CustomButton.TabIndex = 1;
			this.textBoxMRO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxMRO.CustomButton.UseSelectable = true;
			this.textBoxMRO.CustomButton.Visible = false;
			this.textBoxMRO.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxMRO.Lines = new string[0];
			this.textBoxMRO.Location = new System.Drawing.Point(180, 437);
			this.textBoxMRO.MaxLength = 32767;
			this.textBoxMRO.Name = "textBoxMRO";
			this.textBoxMRO.PasswordChar = '\0';
			this.textBoxMRO.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxMRO.SelectedText = "";
			this.textBoxMRO.SelectionLength = 0;
			this.textBoxMRO.SelectionStart = 0;
			this.textBoxMRO.ShortcutsEnabled = true;
			this.textBoxMRO.Size = new System.Drawing.Size(251, 20);
			this.textBoxMRO.TabIndex = 45;
			this.textBoxMRO.UseSelectable = true;
			this.textBoxMRO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxMRO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label13.Location = new System.Drawing.Point(23, 333);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(86, 19);
			label13.TabIndex = 54;
			label13.Text = "Published By:";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxPublishedBy
			// 
			// 
			// 
			// 
			this.textBoxPublishedBy.CustomButton.Image = null;
			this.textBoxPublishedBy.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxPublishedBy.CustomButton.Name = "";
			this.textBoxPublishedBy.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxPublishedBy.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPublishedBy.CustomButton.TabIndex = 1;
			this.textBoxPublishedBy.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPublishedBy.CustomButton.UseSelectable = true;
			this.textBoxPublishedBy.CustomButton.Visible = false;
			this.textBoxPublishedBy.Enabled = false;
			this.textBoxPublishedBy.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxPublishedBy.Lines = new string[0];
			this.textBoxPublishedBy.Location = new System.Drawing.Point(180, 333);
			this.textBoxPublishedBy.MaxLength = 32767;
			this.textBoxPublishedBy.Name = "textBoxPublishedBy";
			this.textBoxPublishedBy.PasswordChar = '\0';
			this.textBoxPublishedBy.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPublishedBy.SelectedText = "";
			this.textBoxPublishedBy.SelectionLength = 0;
			this.textBoxPublishedBy.SelectionStart = 0;
			this.textBoxPublishedBy.ShortcutsEnabled = true;
			this.textBoxPublishedBy.Size = new System.Drawing.Size(251, 20);
			this.textBoxPublishedBy.TabIndex = 55;
			this.textBoxPublishedBy.UseSelectable = true;
			this.textBoxPublishedBy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPublishedBy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label15.Location = new System.Drawing.Point(23, 411);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(109, 19);
			label15.TabIndex = 58;
			label15.Text = "Closing Remarks:";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxClosingRemarks
			// 
			// 
			// 
			// 
			this.textBoxClosingRemarks.CustomButton.Image = null;
			this.textBoxClosingRemarks.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxClosingRemarks.CustomButton.Name = "";
			this.textBoxClosingRemarks.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxClosingRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxClosingRemarks.CustomButton.TabIndex = 1;
			this.textBoxClosingRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxClosingRemarks.CustomButton.UseSelectable = true;
			this.textBoxClosingRemarks.CustomButton.Visible = false;
			this.textBoxClosingRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxClosingRemarks.Lines = new string[0];
			this.textBoxClosingRemarks.Location = new System.Drawing.Point(180, 411);
			this.textBoxClosingRemarks.MaxLength = 32767;
			this.textBoxClosingRemarks.Name = "textBoxClosingRemarks";
			this.textBoxClosingRemarks.PasswordChar = '\0';
			this.textBoxClosingRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxClosingRemarks.SelectedText = "";
			this.textBoxClosingRemarks.SelectionLength = 0;
			this.textBoxClosingRemarks.SelectionStart = 0;
			this.textBoxClosingRemarks.ShortcutsEnabled = true;
			this.textBoxClosingRemarks.Size = new System.Drawing.Size(251, 20);
			this.textBoxClosingRemarks.TabIndex = 59;
			this.textBoxClosingRemarks.UseSelectable = true;
			this.textBoxClosingRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxClosingRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label17.Location = new System.Drawing.Point(23, 463);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(52, 19);
			label17.TabIndex = 62;
			label17.Text = "Station:";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxStation
			// 
			// 
			// 
			// 
			this.textBoxStation.CustomButton.Image = null;
			this.textBoxStation.CustomButton.Location = new System.Drawing.Point(233, 2);
			this.textBoxStation.CustomButton.Name = "";
			this.textBoxStation.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxStation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxStation.CustomButton.TabIndex = 1;
			this.textBoxStation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxStation.CustomButton.UseSelectable = true;
			this.textBoxStation.CustomButton.Visible = false;
			this.textBoxStation.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxStation.Lines = new string[0];
			this.textBoxStation.Location = new System.Drawing.Point(180, 463);
			this.textBoxStation.MaxLength = 32767;
			this.textBoxStation.Name = "textBoxStation";
			this.textBoxStation.PasswordChar = '\0';
			this.textBoxStation.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxStation.SelectedText = "";
			this.textBoxStation.SelectionLength = 0;
			this.textBoxStation.SelectionStart = 0;
			this.textBoxStation.ShortcutsEnabled = true;
			this.textBoxStation.Size = new System.Drawing.Size(251, 20);
			this.textBoxStation.TabIndex = 63;
			this.textBoxStation.UseSelectable = true;
			this.textBoxStation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxStation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel1
			// 
			metroLabel1.AutoSize = true;
			metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			metroLabel1.Location = new System.Drawing.Point(23, 489);
			metroLabel1.Name = "metroLabel1";
			metroLabel1.Size = new System.Drawing.Size(65, 19);
			metroLabel1.TabIndex = 255;
			metroLabel1.Text = "K for MH:";
			metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Location = new System.Drawing.Point(180, 489);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(251, 20);
			this.numericUpDown1.TabIndex = 256;
			// 
			// metroLabel2
			// 
			metroLabel2.AutoSize = true;
			metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			metroLabel2.Location = new System.Drawing.Point(23, 515);
			metroLabel2.Name = "metroLabel2";
			metroLabel2.Size = new System.Drawing.Size(67, 19);
			metroLabel2.TabIndex = 257;
			metroLabel2.Text = "Providers:";
			metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// metroTextBox1
			// 
			// 
			// 
			// 
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(190, 2);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.ForeColor = System.Drawing.Color.DimGray;
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new System.Drawing.Point(180, 515);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new System.Drawing.Size(208, 20);
			this.metroTextBox1.TabIndex = 258;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// WorkPackageEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 741);
			this.Controls.Add(this.linkLabelEditComponents);
			this.Controls.Add(this.metroTextBox1);
			this.Controls.Add(metroLabel2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(metroLabel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(labelWorkType);
			this.Controls.Add(this.comboBoxWorkType);
			this.Controls.Add(this.documentControl10);
			this.Controls.Add(this.documentControl9);
			this.Controls.Add(this.documentControl8);
			this.Controls.Add(this.documentControl7);
			this.Controls.Add(this.documentControl6);
			this.Controls.Add(this.documentControl5);
			this.Controls.Add(this.documentControl4);
			this.Controls.Add(this.documentControl3);
			this.Controls.Add(this.documentControl2);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(label18);
			this.Controls.Add(this.textBoxStation);
			this.Controls.Add(label17);
			this.Controls.Add(this.textBoxClosingRemarks);
			this.Controls.Add(label15);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(label14);
			this.Controls.Add(this.textBoxPublishedBy);
			this.Controls.Add(label13);
			this.Controls.Add(label11);
			this.Controls.Add(this.dateTimePickerClosingDate);
			this.Controls.Add(label12);
			this.Controls.Add(this.dateTimePickerOpeningDate);
			this.Controls.Add(this.textBoxStatus);
			this.Controls.Add(label9);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(label10);
			this.Controls.Add(this.textBoxMRO);
			this.Controls.Add(label7);
			this.Controls.Add(this.textBoxPublishingRemark);
			this.Controls.Add(label6);
			this.Controls.Add(this.textBoxClosedBy);
			this.Controls.Add(label4);
			this.Controls.Add(this.textBoxAuthor);
			this.Controls.Add(label3);
			this.Controls.Add(label2);
			this.Controls.Add(this.dateTimePickerPublishingDate);
			this.Controls.Add(labelValidFrom);
			this.Controls.Add(this.dateTimePickerIssueCreateDate);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(label1);
			this.Controls.Add(this.textBoxWpNumber);
			this.Controls.Add(labelNumber);
			this.MaximumSize = new System.Drawing.Size(937, 750);
			this.MinimumSize = new System.Drawing.Size(800, 382);
			this.Name = "WorkPackageEditorForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Work Package Editor Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroTextBox textBoxWpNumber;
		private MetroTextBox textBoxDescription;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssueCreateDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerPublishingDate;
		private MetroTextBox textBoxAuthor;
		private MetroTextBox textBoxStatus;
		private MetroTextBox textBoxTitle;
		private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerOpeningDate;
		private MetroTextBox textBoxRemarks;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonClose;
		private DocumentationControls.DocumentControl documentControl2;
		private DocumentationControls.DocumentControl documentControl3;
		private DocumentationControls.DocumentControl documentControl4;
		private DocumentationControls.DocumentControl documentControl5;
		private DocumentationControls.DocumentControl documentControl6;
		private DocumentationControls.DocumentControl documentControl7;
		private DocumentationControls.DocumentControl documentControl8;
		private DocumentationControls.DocumentControl documentControl9;
		private DocumentationControls.DocumentControl documentControl10;
		private System.Windows.Forms.ComboBox comboBoxWorkType;
		private System.Windows.Forms.GroupBox groupBox1;
		private Auxiliary.LookupCombobox lookupComboboxFlightNum;
		private Auxiliary.LookupCombobox lookupComboboxTo;
		private System.Windows.Forms.Label label19;
		private Auxiliary.LookupCombobox lookupComboboxFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerFlightDate;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.LinkLabel linkLabelEditComponents;
		private MetroTextBox textBoxClosedBy;
		private MetroTextBox textBoxPublishingRemark;
		private MetroTextBox textBoxMRO;
		private MetroTextBox textBoxPublishedBy;
		private MetroTextBox textBoxClosingRemarks;
		private MetroTextBox textBoxStation;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private MetroTextBox metroTextBox1;
	}
}