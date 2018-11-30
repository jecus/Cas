namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class DiscrepanciesListControl
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
            this.panelDiscrepancies = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.labelMEL = new System.Windows.Forms.Label();
            this.labelOldMEL = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMEL = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOldMEL = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDiscrepancies.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDiscrepancies
            // 
            this.panelDiscrepancies.AutoSize = true;
            this.panelDiscrepancies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDiscrepancies.Controls.Add(this.panelAdd);
            this.panelDiscrepancies.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelDiscrepancies.Location = new System.Drawing.Point(3, 3);
            this.panelDiscrepancies.Name = "panelDiscrepancies";
            this.panelDiscrepancies.Size = new System.Drawing.Size(1000, 36);
            this.panelDiscrepancies.TabIndex = 0;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(3, 3);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(994, 30);
            this.panelAdd.TabIndex = 2;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(457, 3);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(70, 23);
            this.linkLabelAddNew.TabIndex = 1;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // labelMEL
            // 
            this.labelMEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMEL.Location = new System.Drawing.Point(4, 42);
            this.labelMEL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMEL.Name = "labelMEL";
            this.labelMEL.Size = new System.Drawing.Size(1000, 20);
            this.labelMEL.TabIndex = 0;
            this.labelMEL.Text = "MEL";
            this.labelMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOldMEL
            // 
            this.labelOldMEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOldMEL.Location = new System.Drawing.Point(4, 68);
            this.labelOldMEL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOldMEL.Name = "labelOldMEL";
            this.labelOldMEL.Size = new System.Drawing.Size(1000, 20);
            this.labelOldMEL.TabIndex = 0;
            this.labelOldMEL.Text = "Old MELs";
            this.labelOldMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.panelDiscrepancies);
            this.panelMain.Controls.Add(this.labelMEL);
            this.panelMain.Controls.Add(this.panelMEL);
            this.panelMain.Controls.Add(this.labelOldMEL);
            this.panelMain.Controls.Add(this.panelOldMEL);
            this.panelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1008, 94);
            this.panelMain.TabIndex = 2;
            this.panelMain.WrapContents = false;
            // 
            // panelMEL
            // 
            this.panelMEL.AutoSize = true;
            this.panelMEL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMEL.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMEL.Location = new System.Drawing.Point(3, 65);
            this.panelMEL.Name = "panelMEL";
            this.panelMEL.Size = new System.Drawing.Size(0, 0);
            this.panelMEL.TabIndex = 3;
            // 
            // panelOldMEL
            // 
            this.panelOldMEL.AutoSize = true;
            this.panelOldMEL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOldMEL.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelOldMEL.Location = new System.Drawing.Point(3, 91);
            this.panelOldMEL.Name = "panelOldMEL";
            this.panelOldMEL.Size = new System.Drawing.Size(0, 0);
            this.panelOldMEL.TabIndex = 4;
            // 
            // DiscrepanciesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelMain);
            this.Name = "DiscrepanciesListControl";
            this.Size = new System.Drawing.Size(1011, 97);
            this.panelDiscrepancies.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelDiscrepancies;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.FlowLayoutPanel panelMain;
        private System.Windows.Forms.Label labelMEL;
        private System.Windows.Forms.FlowLayoutPanel panelMEL;
        private System.Windows.Forms.Label labelOldMEL;
        private System.Windows.Forms.FlowLayoutPanel panelOldMEL;
    }
}
