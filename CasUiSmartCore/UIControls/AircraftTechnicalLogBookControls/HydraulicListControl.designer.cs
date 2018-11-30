namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class HydraulicListControl
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
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.label = new System.Windows.Forms.Label();
            this.textBoxRemainAfter = new System.Windows.Forms.TextBox();
            this.textBoxTotalSpent = new System.Windows.Forms.TextBox();
            this.textCorrectionTotal = new System.Windows.Forms.TextBox();
            this.textOnBoardTotal = new System.Windows.Forms.TextBox();
            this.textRemainTotal = new System.Windows.Forms.TextBox();
            this.labelTitle4 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.panelAdd);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(537, 113);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(518, 24);
            this.panelAdd.TabIndex = 4;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(219, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(70, 20);
            this.linkLabelAddNew.TabIndex = 1;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(3, 3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(184, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Component Hydraulic Condition";
            // 
            // textBoxRemainAfter
            // 
            this.textBoxRemainAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxRemainAfter.Location = new System.Drawing.Point(380, 140);
            this.textBoxRemainAfter.Name = "textBoxRemainAfter";
            this.textBoxRemainAfter.ReadOnly = true;
            this.textBoxRemainAfter.Size = new System.Drawing.Size(75, 20);
            this.textBoxRemainAfter.TabIndex = 103;
            this.textBoxRemainAfter.TabStop = false;
            // 
            // textBoxTotalSpent
            // 
            this.textBoxTotalSpent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTotalSpent.Location = new System.Drawing.Point(306, 140);
            this.textBoxTotalSpent.Name = "textBoxTotalSpent";
            this.textBoxTotalSpent.ReadOnly = true;
            this.textBoxTotalSpent.Size = new System.Drawing.Size(75, 20);
            this.textBoxTotalSpent.TabIndex = 102;
            this.textBoxTotalSpent.TabStop = false;
            // 
            // textCorrectionTotal
            // 
            this.textCorrectionTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.textCorrectionTotal.Location = new System.Drawing.Point(158, 140);
            this.textCorrectionTotal.Name = "textCorrectionTotal";
            this.textCorrectionTotal.ReadOnly = true;
            this.textCorrectionTotal.Size = new System.Drawing.Size(75, 20);
            this.textCorrectionTotal.TabIndex = 101;
            this.textCorrectionTotal.TabStop = false;
            // 
            // textOnBoardTotal
            // 
            this.textOnBoardTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.textOnBoardTotal.Location = new System.Drawing.Point(232, 140);
            this.textOnBoardTotal.Name = "textOnBoardTotal";
            this.textOnBoardTotal.ReadOnly = true;
            this.textOnBoardTotal.Size = new System.Drawing.Size(75, 20);
            this.textOnBoardTotal.TabIndex = 100;
            this.textOnBoardTotal.TabStop = false;
            // 
            // textRemainTotal
            // 
            this.textRemainTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.textRemainTotal.Location = new System.Drawing.Point(83, 140);
            this.textRemainTotal.Name = "textRemainTotal";
            this.textRemainTotal.ReadOnly = true;
            this.textRemainTotal.Size = new System.Drawing.Size(75, 20);
            this.textRemainTotal.TabIndex = 99;
            this.textRemainTotal.TabStop = false;
            // 
            // labelTitle4
            // 
            this.labelTitle4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTitle4.AutoSize = true;
            this.labelTitle4.Location = new System.Drawing.Point(3, 144);
            this.labelTitle4.Name = "labelTitle4";
            this.labelTitle4.Size = new System.Drawing.Size(31, 13);
            this.labelTitle4.TabIndex = 98;
            this.labelTitle4.Text = "Total";
            // 
            // HydraulicListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.textBoxRemainAfter);
            this.Controls.Add(this.textBoxTotalSpent);
            this.Controls.Add(this.textCorrectionTotal);
            this.Controls.Add(this.textOnBoardTotal);
            this.Controls.Add(this.textRemainTotal);
            this.Controls.Add(this.labelTitle4);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(540, 165);
            this.Name = "HydraulicListControl";
            this.Size = new System.Drawing.Size(540, 165);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.TextBox textBoxRemainAfter;
        private System.Windows.Forms.TextBox textBoxTotalSpent;
        private System.Windows.Forms.TextBox textCorrectionTotal;
        private System.Windows.Forms.TextBox textOnBoardTotal;
        private System.Windows.Forms.TextBox textRemainTotal;
        private System.Windows.Forms.Label labelTitle4;
    }
}
