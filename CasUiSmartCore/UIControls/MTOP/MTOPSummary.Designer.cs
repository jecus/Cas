namespace CAS.UI.UIControls.MTOP
{
	partial class MTOPSummary
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
			this.listViewNextCheck = new System.Windows.Forms.ListView();
			this.columnHeaderCheckName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderGroup1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRemain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewLastCheck = new System.Windows.Forms.ListView();
			this.columnHeaderLastCheckName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastTSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewSchedule = new System.Windows.Forms.ListView();
			this.listViewNotify = new System.Windows.Forms.ListView();
			this.columnHeaderCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewScheduleZero = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// listViewNextCheck
			// 
			this.listViewNextCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheckName,
            this.columnHeaderGroup1,
            this.columnHeaderDate,
            this.columnHeaderTSN,
            this.columnHeaderRemain});
			this.listViewNextCheck.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.listViewNextCheck.FullRowSelect = true;
			this.listViewNextCheck.GridLines = true;
			this.listViewNextCheck.Location = new System.Drawing.Point(3, 3);
			this.listViewNextCheck.Name = "listViewNextCheck";
			this.listViewNextCheck.Size = new System.Drawing.Size(1210, 180);
			this.listViewNextCheck.TabIndex = 2;
			this.listViewNextCheck.UseCompatibleStateImageBehavior = false;
			this.listViewNextCheck.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderCheckName
			// 
			this.columnHeaderCheckName.Text = "Next Check";
			this.columnHeaderCheckName.Width = 100;
			// 
			// columnHeaderGroup1
			// 
			this.columnHeaderGroup1.Text = "Group";
			// 
			// columnHeaderDate
			// 
			this.columnHeaderDate.Text = "Date";
			this.columnHeaderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderDate.Width = 180;
			// 
			// columnHeaderTSN
			// 
			this.columnHeaderTSN.Text = "TSN/CSN";
			this.columnHeaderTSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderTSN.Width = 250;
			// 
			// columnHeaderRemain
			// 
			this.columnHeaderRemain.Text = "Remain/Overdue";
			this.columnHeaderRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderRemain.Width = 250;
			// 
			// listViewLastCheck
			// 
			this.listViewLastCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLastCheckName,
            this.columnHeaderGroup,
            this.columnHeaderLastDate,
            this.columnHeaderLastTSN});
			this.listViewLastCheck.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.listViewLastCheck.FullRowSelect = true;
			this.listViewLastCheck.GridLines = true;
			this.listViewLastCheck.Location = new System.Drawing.Point(3, 189);
			this.listViewLastCheck.Name = "listViewLastCheck";
			this.listViewLastCheck.Size = new System.Drawing.Size(1210, 180);
			this.listViewLastCheck.TabIndex = 3;
			this.listViewLastCheck.UseCompatibleStateImageBehavior = false;
			this.listViewLastCheck.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderLastCheckName
			// 
			this.columnHeaderLastCheckName.Text = "Last Check";
			this.columnHeaderLastCheckName.Width = 100;
			// 
			// columnHeaderGroup
			// 
			this.columnHeaderGroup.Text = "Group";
			// 
			// columnHeaderLastDate
			// 
			this.columnHeaderLastDate.Text = "Date";
			this.columnHeaderLastDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderLastDate.Width = 180;
			// 
			// columnHeaderLastTSN
			// 
			this.columnHeaderLastTSN.Text = "TSN/CSN";
			this.columnHeaderLastTSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderLastTSN.Width = 250;
			// 
			// listViewSchedule
			// 
			this.listViewSchedule.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.listViewSchedule.FullRowSelect = true;
			this.listViewSchedule.GridLines = true;
			this.listViewSchedule.Location = new System.Drawing.Point(3, 375);
			this.listViewSchedule.Name = "listViewSchedule";
			this.listViewSchedule.Size = new System.Drawing.Size(1210, 178);
			this.listViewSchedule.TabIndex = 4;
			this.listViewSchedule.UseCompatibleStateImageBehavior = false;
			this.listViewSchedule.View = System.Windows.Forms.View.Details;
			// 
			// listViewNotify
			// 
			this.listViewNotify.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheck,
            this.columnHeaderLC,
            this.columnHeaderLL,
            this.columnHeaderLG,
            this.columnHeaderLGName,
            this.columnHeaderNC,
            this.columnHeaderNL,
            this.columnHeaderNG,
            this.columnHeaderNGName,
            this.columnHeaderRO});
			this.listViewNotify.FullRowSelect = true;
			this.listViewNotify.GridLines = true;
			this.listViewNotify.HideSelection = false;
			this.listViewNotify.Location = new System.Drawing.Point(0, 743);
			this.listViewNotify.MultiSelect = false;
			this.listViewNotify.Name = "listViewNotify";
			this.listViewNotify.Size = new System.Drawing.Size(1210, 214);
			this.listViewNotify.TabIndex = 5;
			this.listViewNotify.UseCompatibleStateImageBehavior = false;
			this.listViewNotify.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderCheck
			// 
			this.columnHeaderCheck.Text = "Check";
			this.columnHeaderCheck.Width = 70;
			// 
			// columnHeaderLC
			// 
			this.columnHeaderLC.Text = "Last Compliance";
			this.columnHeaderLC.Width = 115;
			// 
			// columnHeaderLL
			// 
			this.columnHeaderLL.Text = "Last TSN/CSN";
			this.columnHeaderLL.Width = 130;
			// 
			// columnHeaderLG
			// 
			this.columnHeaderLG.Text = "Last Group";
			this.columnHeaderLG.Width = 80;
			// 
			// columnHeaderLGName
			// 
			this.columnHeaderLGName.Text = "Check Name";
			this.columnHeaderLGName.Width = 80;
			// 
			// columnHeaderNC
			// 
			this.columnHeaderNC.Text = "Next Compliance";
			this.columnHeaderNC.Width = 143;
			// 
			// columnHeaderNL
			// 
			this.columnHeaderNL.Text = "Next TSN/CSN";
			this.columnHeaderNL.Width = 132;
			// 
			// columnHeaderNG
			// 
			this.columnHeaderNG.Text = "Next Group";
			this.columnHeaderNG.Width = 80;
			// 
			// columnHeaderNGName
			// 
			this.columnHeaderNGName.Text = "Check Name";
			this.columnHeaderNGName.Width = 80;
			// 
			// columnHeaderRO
			// 
			this.columnHeaderRO.Text = "Remain/Overdue";
			this.columnHeaderRO.Width = 159;
			// 
			// listViewScheduleZero
			// 
			this.listViewScheduleZero.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.listViewScheduleZero.FullRowSelect = true;
			this.listViewScheduleZero.GridLines = true;
			this.listViewScheduleZero.Location = new System.Drawing.Point(3, 559);
			this.listViewScheduleZero.Name = "listViewScheduleZero";
			this.listViewScheduleZero.Size = new System.Drawing.Size(1210, 178);
			this.listViewScheduleZero.TabIndex = 6;
			this.listViewScheduleZero.UseCompatibleStateImageBehavior = false;
			this.listViewScheduleZero.View = System.Windows.Forms.View.Details;
			// 
			// MTOPSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listViewScheduleZero);
			this.Controls.Add(this.listViewNotify);
			this.Controls.Add(this.listViewSchedule);
			this.Controls.Add(this.listViewLastCheck);
			this.Controls.Add(this.listViewNextCheck);
			this.Name = "MTOPSummary";
			this.Size = new System.Drawing.Size(1223, 961);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewNextCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderCheckName;
		private System.Windows.Forms.ColumnHeader columnHeaderGroup1;
		private System.Windows.Forms.ColumnHeader columnHeaderDate;
		private System.Windows.Forms.ColumnHeader columnHeaderTSN;
		private System.Windows.Forms.ColumnHeader columnHeaderRemain;
		private System.Windows.Forms.ListView listViewLastCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderLastCheckName;
		private System.Windows.Forms.ColumnHeader columnHeaderLastDate;
		private System.Windows.Forms.ColumnHeader columnHeaderLastTSN;
		private System.Windows.Forms.ColumnHeader columnHeaderGroup;
		private MTOPListView mtopListView1;
		private System.Windows.Forms.ListView listViewSchedule;
		private System.Windows.Forms.ListView listViewNotify;
		private System.Windows.Forms.ColumnHeader columnHeaderCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderLC;
		private System.Windows.Forms.ColumnHeader columnHeaderLL;
		private System.Windows.Forms.ColumnHeader columnHeaderLG;
		private System.Windows.Forms.ColumnHeader columnHeaderLGName;
		private System.Windows.Forms.ColumnHeader columnHeaderNC;
		private System.Windows.Forms.ColumnHeader columnHeaderNL;
		private System.Windows.Forms.ColumnHeader columnHeaderNG;
		private System.Windows.Forms.ColumnHeader columnHeaderNGName;
		private System.Windows.Forms.ColumnHeader columnHeaderRO;
		private System.Windows.Forms.ListView listViewScheduleZero;
	}
}
