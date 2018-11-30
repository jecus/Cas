namespace CAS.UI.UIControls.PersonnelControls.EmployeeCompliance
{
    partial class MedicalCompliance
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
			this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// extendableRichContainer1
			// 
			this.extendableRichContainer1.Caption = "Medical Records";
			this.extendableRichContainer1.Size = new System.Drawing.Size(284, 40);
			// 
			// listViewCompliance
			// 
			this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Subject,
            this.Date,
            this.Remarks});
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
			this.listViewCompliance.Size = new System.Drawing.Size(811, 133);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Location = new System.Drawing.Point(3, 139);
			// 
			// ButtonEdit
			// 
			this.ButtonEdit.Location = new System.Drawing.Point(118, 139);
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.Location = new System.Drawing.Point(237, 139);
			// 
			// panelContainer
			// 
			this.panelContainer.Size = new System.Drawing.Size(814, 196);
			// 
			// ButtonRegisterActualState
			// 
			this.ButtonRegisterActualState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonRegisterActualState.Location = new System.Drawing.Point(370, 139);
			this.ButtonRegisterActualState.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.ButtonRegisterActualState.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.ButtonRegisterActualState.TextMain = "Change";
			this.ButtonRegisterActualState.TextSecondary = "Program";
			this.ButtonRegisterActualState.Visible = true;
			// 
			// Subject
			// 
			this.Subject.Text = "Subject";
			this.Subject.Width = 80;
			// 
			// Date
			// 
			this.Date.Text = "Date";
			this.Date.Width = 100;
			// 
			// Remarks
			// 
			this.Remarks.Text = "Remarks";
			this.Remarks.Width = 130;
			// 
			// MedicalCompliance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "MedicalCompliance";
			this.Size = new System.Drawing.Size(820, 248);
			this.panelContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Remarks;
    }
}
