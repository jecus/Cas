namespace CAS.UI.UIControls.MTOP
{
    partial class MTOPCompliance
	{
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Need new compliance", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Overdue check", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Last compliance", System.Windows.Forms.HorizontalAlignment.Left);
			this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TsnCsn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.GroupNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Phase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Avg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewCompliance
			// 
			this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupNum,
            this.Phase,
            this.Date,
            this.TsnCsn,
            this.Avg,
            this.remarks});
			this.listViewCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			listViewGroup1.Header = "Need new compliance";
			listViewGroup1.Name = "next";
			listViewGroup2.Header = "Overdue check";
			listViewGroup2.Name = "overdue";
			listViewGroup3.Header = "Last compliance";
			listViewGroup3.Name = "last";
			this.listViewCompliance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.listViewCompliance.MultiSelect = false;
			this.listViewCompliance.Size = new System.Drawing.Size(887, 275);
			this.listViewCompliance.Click += new System.EventHandler(this.ListViewComplianceClick);
			this.listViewCompliance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewComplainceMouseDoubleClick);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Location = new System.Drawing.Point(3, 284);
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// ButtonEdit
			// 
			this.ButtonEdit.Location = new System.Drawing.Point(118, 284);
			this.ButtonEdit.Click += new System.EventHandler(this.ButtonEditClick);
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.Location = new System.Drawing.Point(237, 284);
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// panelContainer
			// 
			this.panelContainer.Size = new System.Drawing.Size(887, 341);
			// 
			// ButtonRegisterActualState
			// 
			this.ButtonRegisterActualState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonRegisterActualState.Location = new System.Drawing.Point(370, 284);
			this.ButtonRegisterActualState.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.ButtonRegisterActualState.Size = new System.Drawing.Size(182, 54);
			this.ButtonRegisterActualState.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.ButtonRegisterActualState.TextMain = "Change";
			this.ButtonRegisterActualState.TextSecondary = "AverageUtilization";
			this.ButtonRegisterActualState.Visible = true;
			this.ButtonRegisterActualState.Click += new System.EventHandler(this.ButtonRegisterActualStateClick);
			// 
			// Date
			// 
			this.Date.Text = "Date";
			this.Date.Width = 100;
			// 
			// TsnCsn
			// 
			this.TsnCsn.Text = "TSN/CSN";
			this.TsnCsn.Width = 180;
			// 
			// remarks
			// 
			this.remarks.Text = "Remarks";
			this.remarks.Width = 350;
			// 
			// GroupNum
			// 
			this.GroupNum.Text = "Group";
			this.GroupNum.Width = 100;
			// 
			// Phase
			// 
			this.Phase.Text = "Phase Name";
			this.Phase.Width = 100;
			// 
			// Avg
			// 
			this.Avg.Text = "AverageUtilization";
			this.Avg.Width = 180;
			// 
			// MTOPCompliance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "MTOPCompliance";
			this.Size = new System.Drawing.Size(893, 390);
			this.panelContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader TsnCsn;
        private System.Windows.Forms.ColumnHeader remarks;
        private System.Windows.Forms.ColumnHeader GroupNum;
		private System.Windows.Forms.ColumnHeader Phase;
		private System.Windows.Forms.ColumnHeader Avg;
	}
}
