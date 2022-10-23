using System.Windows.Forms;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceGeneralControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeLicenceGeneralControl));
			this.flowLayoutPanelCaa = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelAddNewCAA = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanelLicenceType = new System.Windows.Forms.FlowLayoutPanel();
			this.comboBoxLicenceType = new System.Windows.Forms.ComboBox();
			this.employeeLicenceLicenseCaaControl = new CAS.UI.UIControls.PersonnelControls.EmployeeControls.EmployeeLicenceCaaControl();
			this.labelLicenseType = new System.Windows.Forms.Label();
			this.checkBoxConfirmation = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanelRating = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelAddNewRating = new System.Windows.Forms.LinkLabel();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanelInstrumentRatings = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelInstrumentRatings = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.flowLayoutPanelRemark = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelRemark = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanelOtherDetail = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelAddOtherDetail = new System.Windows.Forms.LinkLabel();
			this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dateTimePickerIssueDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePickerValidToCAA = new System.Windows.Forms.DateTimePicker();
			this.labelIssueBy = new System.Windows.Forms.Label();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.flowLayoutPanelCaa.SuspendLayout();
			this.flowLayoutPanelLicenceType.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanelRating.SuspendLayout();
			this.flowLayoutPanelInstrumentRatings.SuspendLayout();
			this.flowLayoutPanelRemark.SuspendLayout();
			this.flowLayoutPanelOtherDetail.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelCaa
			// 
			this.flowLayoutPanelCaa.AutoSize = true;
			this.flowLayoutPanelCaa.Controls.Add(this.linkLabelAddNewCAA);
			this.flowLayoutPanelCaa.Location = new System.Drawing.Point(142, 27);
			this.flowLayoutPanelCaa.Name = "flowLayoutPanelCaa";
			this.flowLayoutPanelCaa.Size = new System.Drawing.Size(87, 30);
			this.flowLayoutPanelCaa.TabIndex = 0;
			// 
			// linkLabelAddNewCAA
			// 
			this.linkLabelAddNewCAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabelAddNewCAA.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddNewCAA.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddNewCAA.Location = new System.Drawing.Point(3, 5);
			this.linkLabelAddNewCAA.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabelAddNewCAA.Name = "linkLabelAddNewCAA";
			this.linkLabelAddNewCAA.Size = new System.Drawing.Size(81, 20);
			this.linkLabelAddNewCAA.TabIndex = 1;
			this.linkLabelAddNewCAA.TabStop = true;
			this.linkLabelAddNewCAA.Text = "Add new";
			this.linkLabelAddNewCAA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddNewCAA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNew_LinkClicked);
			// 
			// flowLayoutPanelLicenceType
			// 
			this.flowLayoutPanelLicenceType.AllowDrop = true;
			this.flowLayoutPanelLicenceType.Controls.Add(this.comboBoxLicenceType);
			this.flowLayoutPanelLicenceType.Controls.Add(this.employeeLicenceLicenseCaaControl);
			this.flowLayoutPanelLicenceType.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelLicenceType.Location = new System.Drawing.Point(142, 63);
			this.flowLayoutPanelLicenceType.Name = "flowLayoutPanelLicenceType";
			this.flowLayoutPanelLicenceType.Size = new System.Drawing.Size(908, 72);
			this.flowLayoutPanelLicenceType.TabIndex = 29;
			// 
			// comboBoxLicenceType
			// 
			this.comboBoxLicenceType.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxLicenceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxLicenceType.FormattingEnabled = true;
			this.comboBoxLicenceType.Location = new System.Drawing.Point(10, 5);
			this.comboBoxLicenceType.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
			this.comboBoxLicenceType.Name = "comboBoxLicenceType";
			this.comboBoxLicenceType.Size = new System.Drawing.Size(559, 25);
			this.comboBoxLicenceType.TabIndex = 28;
			this.comboBoxLicenceType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLicenceType_SelectedIndexChanged);
			this.comboBoxLicenceType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// employeeLicenceLicenseCaaControl
			// 
			this.employeeLicenceLicenseCaaControl.Location = new System.Drawing.Point(3, 38);
			this.employeeLicenceLicenseCaaControl.Name = "employeeLicenceLicenseCaaControl";
			this.employeeLicenceLicenseCaaControl.Size = new System.Drawing.Size(905, 27);
			this.employeeLicenceLicenseCaaControl.TabIndex = 29;
			// 
			// labelLicenseType
			// 
			this.labelLicenseType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelLicenseType.AutoSize = true;
			this.labelLicenseType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLicenseType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLicenseType.Location = new System.Drawing.Point(45, 70);
			this.labelLicenseType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.labelLicenseType.Name = "labelLicenseType";
			this.labelLicenseType.Size = new System.Drawing.Size(91, 14);
			this.labelLicenseType.TabIndex = 27;
			this.labelLicenseType.Text = "Licence Type:";
			// 
			// checkBoxConfirmation
			// 
			this.checkBoxConfirmation.AutoSize = true;
			this.checkBoxConfirmation.Font = new System.Drawing.Font("Verdana", 9F);
			this.checkBoxConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxConfirmation.Location = new System.Drawing.Point(149, 3);
			this.checkBoxConfirmation.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.checkBoxConfirmation.Name = "checkBoxConfirmation";
			this.checkBoxConfirmation.Size = new System.Drawing.Size(241, 18);
			this.checkBoxConfirmation.TabIndex = 24;
			this.checkBoxConfirmation.Text = "Confirmation of the validity of the:";
			this.checkBoxConfirmation.UseVisualStyleBackColor = true;
			this.checkBoxConfirmation.CheckedChanged += new System.EventHandler(this.checkBoxConfirmation_CheckedChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelRating, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelCaa, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelLicenseType, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.checkBoxConfirmation, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelLicenceType, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelBirthDate, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxCategory, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelInstrumentRatings, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelRemark, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelOtherDetail, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelRemove, 1, 10);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 12;
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
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1089, 540);
			this.tableLayoutPanel1.TabIndex = 30;
			// 
			// flowLayoutPanelRating
			// 
			this.flowLayoutPanelRating.Controls.Add(this.linkLabelAddNewRating);
			this.flowLayoutPanelRating.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelRating.Location = new System.Drawing.Point(142, 300);
			this.flowLayoutPanelRating.Name = "flowLayoutPanelRating";
			this.flowLayoutPanelRating.Size = new System.Drawing.Size(908, 28);
			this.flowLayoutPanelRating.TabIndex = 31;
			// 
			// linkLabelAddNewRating
			// 
			this.linkLabelAddNewRating.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelAddNewRating.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddNewRating.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddNewRating.Location = new System.Drawing.Point(3, 5);
			this.linkLabelAddNewRating.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.linkLabelAddNewRating.Name = "linkLabelAddNewRating";
			this.linkLabelAddNewRating.Size = new System.Drawing.Size(81, 20);
			this.linkLabelAddNewRating.TabIndex = 1;
			this.linkLabelAddNewRating.TabStop = true;
			this.linkLabelAddNewRating.Text = "Add new";
			this.linkLabelAddNewRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddNewRating.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNewRating_LinkClicked);
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBirthDate.Location = new System.Drawing.Point(319, 243);
			this.labelBirthDate.Margin = new System.Windows.Forms.Padding(180, 5, 0, 5);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(212, 14);
			this.labelBirthDate.TabIndex = 30;
			this.labelBirthDate.Text = "Category, Class, Type of Aircraft:";
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(149, 267);
			this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(562, 25);
			this.comboBoxCategory.TabIndex = 69;
			this.comboBoxCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
			this.comboBoxCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBoxCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(77, 307);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 14);
			this.label1.TabIndex = 70;
			this.label1.Text = "Ratings:";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(3, 341);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(133, 14);
			this.label5.TabIndex = 77;
			this.label5.Text = "Instrument Ratings:";
			// 
			// flowLayoutPanelInstrumentRatings
			// 
			this.flowLayoutPanelInstrumentRatings.Controls.Add(this.linkLabelInstrumentRatings);
			this.flowLayoutPanelInstrumentRatings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelInstrumentRatings.Location = new System.Drawing.Point(142, 334);
			this.flowLayoutPanelInstrumentRatings.Name = "flowLayoutPanelInstrumentRatings";
			this.flowLayoutPanelInstrumentRatings.Size = new System.Drawing.Size(908, 28);
			this.flowLayoutPanelInstrumentRatings.TabIndex = 31;
			// 
			// linkLabelInstrumentRatings
			// 
			this.linkLabelInstrumentRatings.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelInstrumentRatings.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelInstrumentRatings.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelInstrumentRatings.Location = new System.Drawing.Point(3, 5);
			this.linkLabelInstrumentRatings.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.linkLabelInstrumentRatings.Name = "linkLabelInstrumentRatings";
			this.linkLabelInstrumentRatings.Size = new System.Drawing.Size(81, 20);
			this.linkLabelInstrumentRatings.TabIndex = 1;
			this.linkLabelInstrumentRatings.TabStop = true;
			this.linkLabelInstrumentRatings.Text = "Add new";
			this.linkLabelInstrumentRatings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelInstrumentRatings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInstrumentRatings_LinkClicked);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(22, 375);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 14);
			this.label3.TabIndex = 72;
			this.label3.Text = "Special Remarks:";
			// 
			// flowLayoutPanelRemark
			// 
			this.flowLayoutPanelRemark.Controls.Add(this.linkLabelRemark);
			this.flowLayoutPanelRemark.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelRemark.Location = new System.Drawing.Point(142, 368);
			this.flowLayoutPanelRemark.Name = "flowLayoutPanelRemark";
			this.flowLayoutPanelRemark.Size = new System.Drawing.Size(908, 26);
			this.flowLayoutPanelRemark.TabIndex = 73;
			// 
			// linkLabelRemark
			// 
			this.linkLabelRemark.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelRemark.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemark.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemark.Location = new System.Drawing.Point(3, 5);
			this.linkLabelRemark.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabelRemark.Name = "linkLabelRemark";
			this.linkLabelRemark.Size = new System.Drawing.Size(81, 20);
			this.linkLabelRemark.TabIndex = 1;
			this.linkLabelRemark.TabStop = true;
			this.linkLabelRemark.Text = "Add new";
			this.linkLabelRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemark_LinkClicked);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(42, 409);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 14);
			this.label4.TabIndex = 74;
			this.label4.Text = "Other details:";
			// 
			// flowLayoutPanelOtherDetail
			// 
			this.flowLayoutPanelOtherDetail.Controls.Add(this.linkLabelAddOtherDetail);
			this.flowLayoutPanelOtherDetail.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelOtherDetail.Location = new System.Drawing.Point(142, 402);
			this.flowLayoutPanelOtherDetail.Name = "flowLayoutPanelOtherDetail";
			this.flowLayoutPanelOtherDetail.Size = new System.Drawing.Size(908, 27);
			this.flowLayoutPanelOtherDetail.TabIndex = 75;
			// 
			// linkLabelAddOtherDetail
			// 
			this.linkLabelAddOtherDetail.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelAddOtherDetail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddOtherDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddOtherDetail.Location = new System.Drawing.Point(3, 5);
			this.linkLabelAddOtherDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabelAddOtherDetail.Name = "linkLabelAddOtherDetail";
			this.linkLabelAddOtherDetail.Size = new System.Drawing.Size(81, 20);
			this.linkLabelAddOtherDetail.TabIndex = 1;
			this.linkLabelAddOtherDetail.TabStop = true;
			this.linkLabelAddOtherDetail.Text = "Add new";
			this.linkLabelAddOtherDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddOtherDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddOtherDetail_LinkClicked);
			// 
			// linkLabelRemove
			// 
			this.linkLabelRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.linkLabelRemove.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemove.Location = new System.Drawing.Point(995, 438);
			this.linkLabelRemove.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
			this.linkLabelRemove.Name = "linkLabelRemove";
			this.linkLabelRemove.Size = new System.Drawing.Size(84, 20);
			this.linkLabelRemove.TabIndex = 76;
			this.linkLabelRemove.TabStop = true;
			this.linkLabelRemove.Text = "Remove";
			this.linkLabelRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemove.Visible = false;
			this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.documentControl1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lifelengthViewer1, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.dateTimePickerIssueDate, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.dateTimePickerValidToCAA, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.labelIssueBy, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.delimiter1, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(142, 141);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(908, 94);
			this.tableLayoutPanel2.TabIndex = 78;
			// 
			// documentControl1
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.documentControl1, 5);
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(3, 42);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(664, 41);
			this.documentControl1.TabIndex = 82;
			// 
			// lifelengthViewer1
			// 
			this.lifelengthViewer1.AutoSize = true;
			this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer1.CalendarApplicable = false;
			this.lifelengthViewer1.CyclesApplicable = false;
			this.lifelengthViewer1.EnabledCalendar = true;
			this.lifelengthViewer1.EnabledCycle = true;
			this.lifelengthViewer1.EnabledHours = true;
			this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer1.HeaderCalendar = "Calendar";
			this.lifelengthViewer1.HeaderCycles = "Cycles";
			this.lifelengthViewer1.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer1.HeaderHours = "Hours";
			this.lifelengthViewer1.HoursApplicable = false;
			this.lifelengthViewer1.LeftHeader = "Notify";
			this.lifelengthViewer1.Location = new System.Drawing.Point(464, 2);
			this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer1.Modified = false;
			this.lifelengthViewer1.Name = "lifelengthViewer1";
			this.lifelengthViewer1.ReadOnly = false;
			this.lifelengthViewer1.ShowCalendar = true;
			this.lifelengthViewer1.ShowCalendarOnly = true;
			this.lifelengthViewer1.ShowFormattedCalendar = false;
			this.lifelengthViewer1.ShowHeaders = false;
			this.lifelengthViewer1.ShowMinutes = true;
			this.lifelengthViewer1.Size = new System.Drawing.Size(225, 35);
			this.lifelengthViewer1.SystemCalculated = true;
			this.lifelengthViewer1.TabIndex = 81;
			// 
			// dateTimePickerIssueDate
			// 
			this.dateTimePickerIssueDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerIssueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerIssueDate.Location = new System.Drawing.Point(293, 7);
			this.dateTimePickerIssueDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
			this.dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
			this.dateTimePickerIssueDate.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerIssueDate.TabIndex = 79;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(240, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.label2.Size = new System.Drawing.Size(47, 24);
			this.label2.TabIndex = 80;
			this.label2.Text = "Issue:";
			// 
			// dateTimePickerValidToCAA
			// 
			this.dateTimePickerValidToCAA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerValidToCAA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerValidToCAA.Location = new System.Drawing.Point(68, 7);
			this.dateTimePickerValidToCAA.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
			this.dateTimePickerValidToCAA.Name = "dateTimePickerValidToCAA";
			this.dateTimePickerValidToCAA.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerValidToCAA.TabIndex = 79;
			// 
			// labelIssueBy
			// 
			this.labelIssueBy.AutoSize = true;
			this.labelIssueBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssueBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssueBy.Location = new System.Drawing.Point(3, 0);
			this.labelIssueBy.Name = "labelIssueBy";
			this.labelIssueBy.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.labelIssueBy.Size = new System.Drawing.Size(59, 24);
			this.labelIssueBy.TabIndex = 79;
			this.labelIssueBy.Text = "Valid To:";
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.tableLayoutPanel2.SetColumnSpan(this.delimiter1, 5);
			this.delimiter1.Location = new System.Drawing.Point(3, 89);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(696, 2);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
			this.delimiter1.TabIndex = 83;
			// 
			// EmployeeLicenceGeneralControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "EmployeeLicenceGeneralControl";
			this.Size = new System.Drawing.Size(1092, 556);
			this.flowLayoutPanelCaa.ResumeLayout(false);
			this.flowLayoutPanelLicenceType.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanelRating.ResumeLayout(false);
			this.flowLayoutPanelInstrumentRatings.ResumeLayout(false);
			this.flowLayoutPanelRemark.ResumeLayout(false);
			this.flowLayoutPanelOtherDetail.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCaa;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLicenceType;
		private System.Windows.Forms.Label labelLicenseType;
		private System.Windows.Forms.ComboBox comboBoxLicenceType;
		private EmployeeLicenceCaaControl employeeLicenceLicenseCaaControl;
		private System.Windows.Forms.CheckBox checkBoxConfirmation;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRating;
		private System.Windows.Forms.LinkLabel linkLabelAddNewRating;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInstrumentRatings;
		private System.Windows.Forms.LinkLabel linkLabelInstrumentRatings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRemark;
		private System.Windows.Forms.LinkLabel linkLabelRemark;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOtherDetail;
		private System.Windows.Forms.LinkLabel linkLabelAddOtherDetail;
		private System.Windows.Forms.LinkLabel linkLabelRemove;
		private System.Windows.Forms.LinkLabel linkLabelAddNewCAA;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label labelIssueBy;
		private System.Windows.Forms.DateTimePicker dateTimePickerValidToCAA;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssueDate;
		private Auxiliary.LifelengthViewer lifelengthViewer1;
		private DocumentationControls.DocumentControl documentControl1;
		private Auxiliary.Delimiter delimiter1;
	}
}
