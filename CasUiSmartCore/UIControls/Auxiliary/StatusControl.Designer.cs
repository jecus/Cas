using AvControls.StatusImageLink;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class StatusControl
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

            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusImageLinkLabel1 = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPerformance = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 11.25F);
            label2.ForeColor = System.Drawing.Color.DimGray;
            label2.Location = new System.Drawing.Point(154, 7);
            label2.Margin = new System.Windows.Forms.Padding(30, 7, 0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 18);
            label2.TabIndex = 4;
            label2.Text = "Date as of:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 11.25F);
            label1.ForeColor = System.Drawing.Color.DimGray;
            label1.Location = new System.Drawing.Point(435, 7);
            label1.Margin = new System.Windows.Forms.Padding(20, 7, 0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 18);
            label1.TabIndex = 6;
            label1.Text = "Aircraft TSN/CSN:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.statusImageLinkLabel1);
            this.flowLayoutPanel1.Controls.Add(this.labelStatus);
            this.flowLayoutPanel1.Controls.Add(label2);
            this.flowLayoutPanel1.Controls.Add(this.labelDate);
            this.flowLayoutPanel1.Controls.Add(this.labelTitle);
            this.flowLayoutPanel1.Controls.Add(label1);
            this.flowLayoutPanel1.Controls.Add(this.labelPerformance);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(900, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // statusImageLinkLabel1
            // 
            this.statusImageLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.statusImageLinkLabel1.Enabled = false;
            this.statusImageLinkLabel1.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
            this.statusImageLinkLabel1.ImageBackColor = System.Drawing.Color.Transparent;
            this.statusImageLinkLabel1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusImageLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.statusImageLinkLabel1.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.statusImageLinkLabel1.Location = new System.Drawing.Point(3, 3);
            this.statusImageLinkLabel1.MaximumSize = new System.Drawing.Size(30, 30);
            this.statusImageLinkLabel1.Name = "statusImageLinkLabel1";
            this.statusImageLinkLabel1.Size = new System.Drawing.Size(30, 30);
            this.statusImageLinkLabel1.Status = AvControls.Statuses.NotActive;
            this.statusImageLinkLabel1.TabIndex = 0;
            this.statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusImageLinkLabel1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatus.Location = new System.Drawing.Point(36, 7);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(0, 7, 3, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(85, 18);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Condition:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelDate.Location = new System.Drawing.Point(246, 7);
            this.labelDate.Margin = new System.Windows.Forms.Padding(0, 7, 3, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(98, 18);
            this.labelDate.TabIndex = 5;
            this.labelDate.Text = "00.00.0000";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.Location = new System.Drawing.Point(377, 7);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(30, 7, 0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(38, 18);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "Title";
            // 
            // labelPerformance
            // 
            this.labelPerformance.AutoSize = true;
            this.labelPerformance.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelPerformance.ForeColor = System.Drawing.Color.DimGray;
            this.labelPerformance.Location = new System.Drawing.Point(577, 7);
            this.labelPerformance.Margin = new System.Windows.Forms.Padding(0, 7, 3, 0);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(52, 18);
            this.labelPerformance.TabIndex = 7;
            this.labelPerformance.Text = "0|0|0";
            // 
            // StatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1200, 35);
            this.MinimumSize = new System.Drawing.Size(800, 35);
            this.Name = "StatusControl";
            this.Size = new System.Drawing.Size(900, 35);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        System.Windows.Forms.Label label2;
        System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private StatusImageLinkLabel statusImageLinkLabel1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelPerformance;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelTitle;
    }
}
