namespace CAS.UI.UIControls.JobCardControls
{
    partial class JobCardTaskListControl
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.jobCardTaskControl1 = new CAS.UI.UIControls.JobCardControls.JobCardTaskControl();
            this.flowLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.jobCardTaskControl1);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(1460, 20000);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(640, 1);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(968, 246);
            this.flowLayoutPanelMain.TabIndex = 41;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(4, 254);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(968, 35);
            this.linkLabelAddNew.TabIndex = 2;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.linkLabelAddNew, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelMain, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(976, 289);
            this.tableLayoutPanelMain.TabIndex = 4;
            // 
            // jobCardTaskControl1
            // 
            this.jobCardTaskControl1.AttachedObject = null;
            this.jobCardTaskControl1.JobCardTask = null;
            this.jobCardTaskControl1.Location = new System.Drawing.Point(5, 5);
            this.jobCardTaskControl1.Margin = new System.Windows.Forms.Padding(5);
            this.jobCardTaskControl1.Name = "jobCardTaskControl1";
            this.jobCardTaskControl1.Size = new System.Drawing.Size(696, 236);
            this.jobCardTaskControl1.TabIndex = 0;
            // 
            // JobCardTaskListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "JobCardTaskListControl";
            this.Size = new System.Drawing.Size(976, 289);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private JobCardTaskControl jobCardTaskControl1;
    }
}
