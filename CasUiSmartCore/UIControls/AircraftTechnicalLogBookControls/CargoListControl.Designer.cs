namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class CargoListControl
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
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.textWeightTotal = new System.Windows.Forms.TextBox();
            this.labelTitle4 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 40;
            this.label11.Text = "Cargo";
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.panelAdd);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(4, 21);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(600, 177);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(600, 31);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(600, 177);
            this.flowLayoutPanelMain.TabIndex = 41;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(600, 37);
            this.panelAdd.TabIndex = 3;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(254, 5);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(93, 28);
            this.linkLabelAddNew.TabIndex = 2;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // textWeightTotal
            // 
            this.textWeightTotal.Location = new System.Drawing.Point(210, 206);
            this.textWeightTotal.Margin = new System.Windows.Forms.Padding(4);
            this.textWeightTotal.Name = "textWeightTotal";
            this.textWeightTotal.ReadOnly = true;
            this.textWeightTotal.Size = new System.Drawing.Size(323, 22);
            this.textWeightTotal.TabIndex = 93;
            this.textWeightTotal.TabStop = false;
            // 
            // labelTitle4
            // 
            this.labelTitle4.AutoSize = true;
            this.labelTitle4.Location = new System.Drawing.Point(1, 211);
            this.labelTitle4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle4.Name = "labelTitle4";
            this.labelTitle4.Size = new System.Drawing.Size(40, 17);
            this.labelTitle4.TabIndex = 92;
            this.labelTitle4.Text = "Total";
            // 
            // CargoListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textWeightTotal);
            this.Controls.Add(this.labelTitle4);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CargoListControl";
            this.Size = new System.Drawing.Size(608, 243);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.TextBox textWeightTotal;
        private System.Windows.Forms.Label labelTitle4;
    }
}
