namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceSummaryControl
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.maintenancePerformanceControl1 = new CAS.UI.UIControls.MaintananceProgram.MaintenancePerformanceControl();
            this.listViewNextCheck = new System.Windows.Forms.ListView();
            this.columnHeaderCheckName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRemain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewLastCheck = new System.Windows.Forms.ListView();
            this.columnHeaderLastCheckName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastTSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(7, 10);
            label4.Margin = new System.Windows.Forms.Padding(7, 10, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(52, 18);
            label4.TabIndex = 10;
            label4.Text = "Notify";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(6, 0);
            label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(155, 18);
            label2.TabIndex = 12;
            label2.Text = "Maintenance review";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(label4);
            this.flowLayoutPanel1.Controls.Add(this.maintenancePerformanceControl1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 333);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1213, 391);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // maintenancePerformanceControl1
            // 
            this.maintenancePerformanceControl1.CheckItems = null;
            this.maintenancePerformanceControl1.Location = new System.Drawing.Point(3, 38);
            this.maintenancePerformanceControl1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.maintenancePerformanceControl1.Name = "maintenancePerformanceControl1";
            this.maintenancePerformanceControl1.Size = new System.Drawing.Size(1200, 350);
            this.maintenancePerformanceControl1.TabIndex = 5;
            // 
            // listViewNextCheck
            // 
            this.listViewNextCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheckName,
            this.columnHeaderDate,
            this.columnHeaderTSN,
            this.columnHeaderRemain});
            this.listViewNextCheck.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listViewNextCheck.FullRowSelect = true;
            this.listViewNextCheck.GridLines = true;
            this.listViewNextCheck.Location = new System.Drawing.Point(6, 21);
            this.listViewNextCheck.Name = "listViewNextCheck";
            this.listViewNextCheck.Size = new System.Drawing.Size(1210, 150);
            this.listViewNextCheck.TabIndex = 1;
            this.listViewNextCheck.UseCompatibleStateImageBehavior = false;
            this.listViewNextCheck.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCheckName
            // 
            this.columnHeaderCheckName.Text = "Next Check";
            this.columnHeaderCheckName.Width = 100;
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
            this.columnHeaderRemain.Text = "Remain";
            this.columnHeaderRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderRemain.Width = 250;
            // 
            // listViewLastCheck
            // 
            this.listViewLastCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLastCheckName,
            this.columnHeaderLastDate,
            this.columnHeaderLastTSN});
            this.listViewLastCheck.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listViewLastCheck.FullRowSelect = true;
            this.listViewLastCheck.GridLines = true;
            this.listViewLastCheck.Location = new System.Drawing.Point(6, 177);
            this.listViewLastCheck.Name = "listViewLastCheck";
            this.listViewLastCheck.Size = new System.Drawing.Size(1210, 150);
            this.listViewLastCheck.TabIndex = 2;
            this.listViewLastCheck.UseCompatibleStateImageBehavior = false;
            this.listViewLastCheck.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLastCheckName
            // 
            this.columnHeaderLastCheckName.Text = "Last Check";
            this.columnHeaderLastCheckName.Width = 100;
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
            // MaintenanceSummaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.listViewLastCheck);
            this.Controls.Add(label2);
            this.Controls.Add(this.listViewNextCheck);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MaintenanceSummaryControl";
            this.Size = new System.Drawing.Size(1219, 727);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaintenancePerformanceControl maintenancePerformanceControl1;
        private System.Windows.Forms.ListView listViewNextCheck;
        private System.Windows.Forms.ColumnHeader columnHeaderCheckName;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTSN;
        private System.Windows.Forms.ColumnHeader columnHeaderRemain;
        private System.Windows.Forms.ListView listViewLastCheck;
        private System.Windows.Forms.ColumnHeader columnHeaderLastCheckName;
        private System.Windows.Forms.ColumnHeader columnHeaderLastDate;
        private System.Windows.Forms.ColumnHeader columnHeaderLastTSN;

    }
}
