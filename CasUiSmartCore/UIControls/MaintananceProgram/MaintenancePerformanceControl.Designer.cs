using AvControls.AvButtonT;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenancePerformanceControl
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
            this.directivesListView = new System.Windows.Forms.ListView();
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
            this.SuspendLayout();
            // 
            // listViewPerformance
            // 
            this.directivesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.directivesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directivesListView.FullRowSelect = true;
            this.directivesListView.GridLines = true;
            this.directivesListView.HideSelection = false;
            this.directivesListView.Location = new System.Drawing.Point(0, 0);
            this.directivesListView.Margin = new System.Windows.Forms.Padding(4);
            this.directivesListView.MultiSelect = false;
            this.directivesListView.Name = "listViewPerformance";
            this.directivesListView.Size = new System.Drawing.Size(1197, 342);
            this.directivesListView.TabIndex = 0;
            this.directivesListView.UseCompatibleStateImageBehavior = false;
            this.directivesListView.View = System.Windows.Forms.View.Details;
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
            this.columnHeaderLG.Text = "Last Group/Ordinal №";
            this.columnHeaderLG.Width = 180;
            // 
            // columnHeaderLGName
            // 
            this.columnHeaderLGName.Text = "Check Name";
            this.columnHeaderLGName.Width = 120;
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
            this.columnHeaderNG.Text = "Next Group/Ordinal №";
            this.columnHeaderNG.Width = 180;
            // 
            // columnHeaderNGName
            // 
            this.columnHeaderNGName.Text = "Check Name";
            this.columnHeaderNGName.Width = 120;
            // 
            // columnHeaderRO
            // 
            this.columnHeaderRO.Text = "Remain/Overdue";
            this.columnHeaderRO.Width = 159;
            // 
            // MaintenancePerformanceControlNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.directivesListView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MaintenancePerformanceControlNew";
            this.Size = new System.Drawing.Size(1197, 342);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView directivesListView;
        private System.Windows.Forms.ColumnHeader columnHeaderCheck;
        private System.Windows.Forms.ColumnHeader columnHeaderLC;
        private System.Windows.Forms.ColumnHeader columnHeaderNC;
        private System.Windows.Forms.ColumnHeader columnHeaderLL;
        private System.Windows.Forms.ColumnHeader columnHeaderNL;
        private System.Windows.Forms.ColumnHeader columnHeaderRO;
        private System.Windows.Forms.ColumnHeader columnHeaderLG;
        private System.Windows.Forms.ColumnHeader columnHeaderLGName;
        private System.Windows.Forms.ColumnHeader columnHeaderNG;
        private System.Windows.Forms.ColumnHeader columnHeaderNGName;

    }
}
