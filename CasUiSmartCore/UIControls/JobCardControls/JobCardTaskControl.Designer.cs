namespace CAS.UI.UIControls.JobCardControls
{
    partial class JobCardTaskControl
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
            this.labelJobTskHeader = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxJobTaskNumber = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelJobTskHeader
            // 
            this.labelJobTskHeader.AutoSize = true;
            this.labelJobTskHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJobTskHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelJobTskHeader.Location = new System.Drawing.Point(3, 0);
            this.labelJobTskHeader.Name = "labelJobTskHeader";
            this.labelJobTskHeader.Size = new System.Drawing.Size(23, 28);
            this.labelJobTskHeader.TabIndex = 40;
            this.labelJobTskHeader.Text = "¹";
            this.labelJobTskHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tableLayoutPanelMain.SetColumnSpan(this.flowLayoutPanelMain, 3);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(4, 196);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(1460, 20000);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(640, 1);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1018, 1);
            this.flowLayoutPanelMain.TabIndex = 41;
            // 
            // linkLabelAddNew
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.linkLabelAddNew, 3);
            this.linkLabelAddNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(4, 201);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(1018, 35);
            this.linkLabelAddNew.TabIndex = 2;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add sub";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.linkLabelAddNew, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.labelDescription, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelMain, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxJobTaskNumber, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelJobTskHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.richTextBoxDescription, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1026, 236);
            this.tableLayoutPanelMain.TabIndex = 42;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelDescription, 3);
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelDescription.Location = new System.Drawing.Point(3, 28);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(1020, 17);
            this.labelDescription.TabIndex = 43;
            this.labelDescription.Text = "Job Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxJobTaskNumber
            // 
            this.textBoxJobTaskNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJobTaskNumber.Location = new System.Drawing.Point(32, 3);
            this.textBoxJobTaskNumber.Name = "textBoxJobTaskNumber";
            this.textBoxJobTaskNumber.Size = new System.Drawing.Size(948, 22);
            this.textBoxJobTaskNumber.TabIndex = 41;
            this.textBoxJobTaskNumber.TextChanged += new System.EventHandler(this.TextBoxJobTaskNumberTextChanged);
            // 
            // richTextBoxDescription
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.richTextBoxDescription, 3);
            this.richTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDescription.Location = new System.Drawing.Point(1, 45);
            this.richTextBoxDescription.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.richTextBoxDescription.MinimumSize = new System.Drawing.Size(768, 120);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(1024, 147);
            this.richTextBoxDescription.TabIndex = 42;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.RichTextBoxDescriptionContentsResized);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(987, 0);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 44;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // JobCardTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "JobCardTaskControl";
            this.Size = new System.Drawing.Size(1026, 236);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJobTskHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxJobTaskNumber;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonDelete;
    }
}
