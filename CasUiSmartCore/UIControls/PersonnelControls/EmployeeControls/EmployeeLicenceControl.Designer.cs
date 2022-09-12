using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxPersonnel = new System.Windows.Forms.ComboBox();
			this.linkLabelAddGeneralControl = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanelRemark = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelRemark = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanelOtherDetail = new System.Windows.Forms.FlowLayoutPanel();
			this.linkLabelAddOtherDetail = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelPersonel = new System.Windows.Forms.Label();
			this.flowLayoutPanelGeneralControl = new System.Windows.Forms.FlowLayoutPanel();
			this.employeeLicenceGeneralControl = new CAS.UI.UIControls.PersonnelControls.EmployeeControls.EmployeeLicenceGeneralControl();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.comboBoxClass = new System.Windows.Forms.ComboBox();
			this.labelIssue = new System.Windows.Forms.Label();
			this.dateTimePickerClassIssue = new System.Windows.Forms.DateTimePicker();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.comboBoxGrade = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePickerGradeIssue = new System.Windows.Forms.DateTimePicker();
			this.labelStatus = new System.Windows.Forms.Label();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanelRemark.SuspendLayout();
			this.flowLayoutPanelOtherDetail.SuspendLayout();
			this.flowLayoutPanelGeneralControl.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(71, 736);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 14);
			this.label1.TabIndex = 78;
			this.label1.Text = "Class:";
			// 
			// comboBoxPersonnel
			// 
			this.comboBoxPersonnel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxPersonnel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxPersonnel.FormattingEnabled = true;
			this.comboBoxPersonnel.Location = new System.Drawing.Point(150, 3);
			this.comboBoxPersonnel.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
			this.comboBoxPersonnel.Name = "comboBoxPersonnel";
			this.comboBoxPersonnel.Size = new System.Drawing.Size(564, 25);
			this.comboBoxPersonnel.TabIndex = 31;
			this.comboBoxPersonnel.SelectedIndexChanged += new System.EventHandler(this.comboBoxPersonnel_SelectedIndexChanged);
			// 
			// linkLabelAddGeneralControl
			// 
			this.linkLabelAddGeneralControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelAddGeneralControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddGeneralControl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddGeneralControl.Location = new System.Drawing.Point(500, 638);
			this.linkLabelAddGeneralControl.Margin = new System.Windows.Forms.Padding(380, 0, 3, 0);
			this.linkLabelAddGeneralControl.Name = "linkLabelAddGeneralControl";
			this.linkLabelAddGeneralControl.Size = new System.Drawing.Size(162, 20);
			this.linkLabelAddGeneralControl.TabIndex = 33;
			this.linkLabelAddGeneralControl.TabStop = true;
			this.linkLabelAddGeneralControl.Text = "Add new";
			this.linkLabelAddGeneralControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddGeneralControl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// flowLayoutPanelRemark
			// 
			this.flowLayoutPanelRemark.Controls.Add(this.linkLabelRemark);
			this.flowLayoutPanelRemark.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelRemark.Location = new System.Drawing.Point(123, 661);
			this.flowLayoutPanelRemark.Name = "flowLayoutPanelRemark";
			this.flowLayoutPanelRemark.Size = new System.Drawing.Size(958, 24);
			this.flowLayoutPanelRemark.TabIndex = 76;
			// 
			// linkLabelRemark
			// 
			this.linkLabelRemark.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelRemark.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemark.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemark.Location = new System.Drawing.Point(3, 5);
			this.linkLabelRemark.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabelRemark.Name = "linkLabelRemark";
			this.linkLabelRemark.Size = new System.Drawing.Size(88, 20);
			this.linkLabelRemark.TabIndex = 1;
			this.linkLabelRemark.TabStop = true;
			this.linkLabelRemark.Text = "Add new";
			this.linkLabelRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemark_LinkClicked);
			// 
			// flowLayoutPanelOtherDetail
			// 
			this.flowLayoutPanelOtherDetail.Controls.Add(this.linkLabelAddOtherDetail);
			this.flowLayoutPanelOtherDetail.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelOtherDetail.Location = new System.Drawing.Point(123, 695);
			this.flowLayoutPanelOtherDetail.Name = "flowLayoutPanelOtherDetail";
			this.flowLayoutPanelOtherDetail.Size = new System.Drawing.Size(958, 27);
			this.flowLayoutPanelOtherDetail.TabIndex = 77;
			// 
			// linkLabelAddOtherDetail
			// 
			this.linkLabelAddOtherDetail.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelAddOtherDetail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddOtherDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddOtherDetail.Location = new System.Drawing.Point(3, 5);
			this.linkLabelAddOtherDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.linkLabelAddOtherDetail.Name = "linkLabelAddOtherDetail";
			this.linkLabelAddOtherDetail.Size = new System.Drawing.Size(88, 20);
			this.linkLabelAddOtherDetail.TabIndex = 1;
			this.linkLabelAddOtherDetail.TabStop = true;
			this.linkLabelAddOtherDetail.Text = "Add new";
			this.linkLabelAddOtherDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddOtherDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddOtherDetail_LinkClicked);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(3, 668);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 14);
			this.label3.TabIndex = 73;
			this.label3.Text = "Special Remarks:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(23, 702);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 14);
			this.label4.TabIndex = 75;
			this.label4.Text = "Other details:";
			// 
			// labelPersonel
			// 
			this.labelPersonel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelPersonel.AutoSize = true;
			this.labelPersonel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPersonel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPersonel.Location = new System.Drawing.Point(42, 8);
			this.labelPersonel.Name = "labelPersonel";
			this.labelPersonel.Size = new System.Drawing.Size(75, 14);
			this.labelPersonel.TabIndex = 30;
			this.labelPersonel.Text = "Personnel:";
			// 
			// flowLayoutPanelGeneralControl
			// 
			this.flowLayoutPanelGeneralControl.AutoScroll = true;
			this.flowLayoutPanelGeneralControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanelGeneralControl, 2);
			this.flowLayoutPanelGeneralControl.Controls.Add(this.employeeLicenceGeneralControl);
			this.flowLayoutPanelGeneralControl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelGeneralControl.Location = new System.Drawing.Point(5, 34);
			this.flowLayoutPanelGeneralControl.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.flowLayoutPanelGeneralControl.Name = "flowLayoutPanelGeneralControl";
			this.flowLayoutPanelGeneralControl.Size = new System.Drawing.Size(1118, 601);
			this.flowLayoutPanelGeneralControl.TabIndex = 33;
			this.flowLayoutPanelGeneralControl.WrapContents = false;
			// 
			// employeeLicenceGeneralControl
			// 
			this.employeeLicenceGeneralControl.AutoScroll = true;
			this.employeeLicenceGeneralControl.Location = new System.Drawing.Point(3, 3);
			this.employeeLicenceGeneralControl.Name = "employeeLicenceGeneralControl";
			this.employeeLicenceGeneralControl.OperatorId = 0;
			this.employeeLicenceGeneralControl.Size = new System.Drawing.Size(1090, 583);
			this.employeeLicenceGeneralControl.TabIndex = 32;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(67, 776);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 14);
			this.label2.TabIndex = 79;
			this.label2.Text = "Grade:";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.comboBoxStatus, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelStatus, 0, 0);
			
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 7);
			
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelGeneralControl, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPersonel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelOtherDetail, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelRemark, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelAddGeneralControl, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxPersonnel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 7);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 31);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1152, 816);
			this.tableLayoutPanel1.TabIndex = 33;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.comboBoxClass);
			this.flowLayoutPanel1.Controls.Add(this.labelIssue);
			this.flowLayoutPanel1.Controls.Add(this.dateTimePickerClassIssue);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(123, 729);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 34);
			this.flowLayoutPanel1.TabIndex = 80;
			// 
			// comboBoxClass
			// 
			this.comboBoxClass.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxClass.FormattingEnabled = true;
			this.comboBoxClass.Location = new System.Drawing.Point(3, 3);
			this.comboBoxClass.Name = "comboBoxClass";
			this.comboBoxClass.Size = new System.Drawing.Size(88, 25);
			this.comboBoxClass.TabIndex = 52;
			// 
			// labelIssue
			// 
			this.labelIssue.AutoSize = true;
			this.labelIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssue.Location = new System.Drawing.Point(97, 8);
			this.labelIssue.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.labelIssue.Name = "labelIssue";
			this.labelIssue.Size = new System.Drawing.Size(47, 14);
			this.labelIssue.TabIndex = 50;
			this.labelIssue.Text = "Issue:";
			// 
			// dateTimePickerClassIssue
			// 
			this.dateTimePickerClassIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerClassIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClassIssue.Location = new System.Drawing.Point(150, 5);
			this.dateTimePickerClassIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.dateTimePickerClassIssue.Name = "dateTimePickerClassIssue";
			this.dateTimePickerClassIssue.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerClassIssue.TabIndex = 51;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.comboBoxGrade);
			this.flowLayoutPanel2.Controls.Add(this.label5);
			this.flowLayoutPanel2.Controls.Add(this.dateTimePickerGradeIssue);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(123, 769);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(412, 34);
			this.flowLayoutPanel2.TabIndex = 81;
			// 
			// comboBoxGrade
			// 
			this.comboBoxGrade.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxGrade.FormattingEnabled = true;
			this.comboBoxGrade.Location = new System.Drawing.Point(3, 3);
			this.comboBoxGrade.Name = "comboBoxGrade";
			this.comboBoxGrade.Size = new System.Drawing.Size(88, 25);
			this.comboBoxGrade.TabIndex = 52;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(97, 8);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 14);
			this.label5.TabIndex = 50;
			this.label5.Text = "Issue:";
			// 
			// dateTimePickerGradeIssue
			// 
			this.dateTimePickerGradeIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerGradeIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerGradeIssue.Location = new System.Drawing.Point(150, 5);
			this.dateTimePickerGradeIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.dateTimePickerGradeIssue.Name = "dateTimePickerGradeIssue";
			this.dateTimePickerGradeIssue.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerGradeIssue.TabIndex = 51;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStatus.Location = new System.Drawing.Point(14, 834);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(103, 14);
			this.labelStatus.TabIndex = 82;
			this.labelStatus.Text = "Licence Status:";
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(150, 829);
			this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(564, 25);
			this.comboBoxStatus.TabIndex = 83;
			// 
			// EmployeeLicenceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "EmployeeLicenceControl";
			this.Size = new System.Drawing.Size(1159, 854);
			this.flowLayoutPanelRemark.ResumeLayout(false);
			this.flowLayoutPanelOtherDetail.ResumeLayout(false);
			this.flowLayoutPanelGeneralControl.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.ComboBox comboBoxStatus;

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxPersonnel;
		private System.Windows.Forms.LinkLabel linkLabelAddGeneralControl;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRemark;
		private System.Windows.Forms.LinkLabel linkLabelRemark;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOtherDetail;
		private System.Windows.Forms.LinkLabel linkLabelAddOtherDetail;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelPersonel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGeneralControl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private CAS.UI.UIControls.PersonnelControls.EmployeeControls.EmployeeLicenceGeneralControl employeeLicenceGeneralControl;
		private System.Windows.Forms.ComboBox comboBoxClass;
		private System.Windows.Forms.Label labelIssue;
		private System.Windows.Forms.DateTimePicker dateTimePickerClassIssue;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.ComboBox comboBoxGrade;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePickerGradeIssue;
	}
}
