using AvControls.ExtendableList;
using AvControls.ImageLink;
using AvControls.StatusImageLink;

namespace AvControls
{
    partial class Form1
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
            this.splitViewer1 = new AvControls.SplitViewer.SplitViewer();
            this.splitViewer2 = new AvControls.SplitViewer.SplitViewer();
            this.avVScroll1 = new AvControls.ExtendableList.AvVScroll();
            this.avMultitabControl1 = new AvControls.AvMultitabControl.AvMultitabControl();
            this.avTabPage1 = new AvControls.AvMultitabControl.MultitabPage();
            this.avTabPage2 = new AvControls.AvMultitabControl.MultitabPage();
            this.avTabPage3 = new AvControls.AvMultitabControl.MultitabPage();
            this.avTabPage4 = new AvControls.AvMultitabControl.MultitabPage();
            this.avTabPage5 = new AvControls.AvMultitabControl.MultitabPage();
            this.avMultitabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitViewer1
            // 
            this.splitViewer1.AutoSize = true;
            this.splitViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitViewer1.BackColor = System.Drawing.Color.Transparent;
            this.splitViewer1.ControlsAmount = 1;
            this.splitViewer1.Location = new System.Drawing.Point(694, 320);
            this.splitViewer1.Name = "splitViewer1";
            this.splitViewer1.Size = new System.Drawing.Size(0, 0);
            this.splitViewer1.SplitterImage = null;
            this.splitViewer1.TabIndex = 9;
            // 
            // splitViewer2
            // 
            this.splitViewer2.AutoSize = true;
            this.splitViewer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitViewer2.BackColor = System.Drawing.Color.Transparent;
            this.splitViewer2.ControlsAmount = 1;
            this.splitViewer2.Location = new System.Drawing.Point(567, 368);
            this.splitViewer2.Name = "splitViewer2";
            this.splitViewer2.Size = new System.Drawing.Size(0, 0);
            this.splitViewer2.SplitterImage = null;
            this.splitViewer2.TabIndex = 10;
            // 
            // avVScroll1
            // 
            this.avVScroll1.ApproximateHeigth = 0;
            this.avVScroll1.Location = new System.Drawing.Point(669, 22);
            this.avVScroll1.Name = "avVScroll1";
            this.avVScroll1.Size = new System.Drawing.Size(17, 269);
            this.avVScroll1.TabIndex = 14;
            // 
            // avMultitabControl1
            // 
            this.avMultitabControl1.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.avMultitabControl1.ActiveBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.avMultitabControl1.ActiveElementBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.avMultitabControl1.ActiveElementBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.avMultitabControl1.ActiveTabsButtonHint = "Active Tabs";
            this.avMultitabControl1.ActiveTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.avMultitabControl1.CloseButtonHint = "Close";
            this.avMultitabControl1.Controls.Add(this.avTabPage3);
            this.avMultitabControl1.Controls.Add(this.avTabPage4);
            this.avMultitabControl1.Controls.Add(this.avTabPage5);
            this.avMultitabControl1.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.avMultitabControl1.InactiveBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.avMultitabControl1.InactiveTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.avMultitabControl1.Location = new System.Drawing.Point(35, 12);
            this.avMultitabControl1.MaxTabWidth = 185;
            this.avMultitabControl1.Name = "avMultitabControl1";
            this.avMultitabControl1.SelectedTab = this.avTabPage4;
            this.avMultitabControl1.ShowToolTips = true;
            this.avMultitabControl1.Size = new System.Drawing.Size(648, 372);
            this.avMultitabControl1.TabIndex = 17;
            this.avMultitabControl1.TabPages.AddRange(new AvControls.AvMultitabControl.MultitabPage[] {
            this.avTabPage3,
            this.avTabPage4,
            this.avTabPage5});
            // 
            // avTabPage1
            // 
            this.avTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.avTabPage1.Icon = null;
            this.avTabPage1.Name = "avTabPage1";
            this.avTabPage1.Owner = this.avMultitabControl1;
            this.avTabPage1.Size = new System.Drawing.Size(646, 351);
            this.avTabPage1.Text = "AvTabPage1";
            this.avTabPage1.ToolTipText = "AvTabPage1";
            // 
            // avTabPage2
            // 
            this.avTabPage2.BackColor = System.Drawing.Color.Transparent;
            this.avTabPage2.Icon = null;
            this.avTabPage2.Name = "avTabPage2";
            this.avTabPage2.Owner = this.avMultitabControl1;
            this.avTabPage2.Size = new System.Drawing.Size(646, 351);
            this.avTabPage2.Text = "AvTabPage2";
            this.avTabPage2.ToolTipText = "AvTabPage2";
            // 
            // avTabPage3
            // 
            this.avTabPage3.BackColor = System.Drawing.Color.Transparent;
            this.avTabPage3.Icon = null;
            this.avTabPage3.Name = "avTabPage3";
            this.avTabPage3.Owner = this.avMultitabControl1;
            this.avTabPage3.Size = new System.Drawing.Size(646, 351);
            this.avTabPage3.Text = "AvTabPage1";
            this.avTabPage3.ToolTipText = "AvTabPage1";
            // 
            // avTabPage4
            // 
            this.avTabPage4.BackColor = System.Drawing.Color.Transparent;
            this.avTabPage4.Icon = null;
            this.avTabPage4.Name = "avTabPage4";
            this.avTabPage4.Owner = this.avMultitabControl1;
            this.avTabPage4.Size = new System.Drawing.Size(646, 351);
            this.avTabPage4.Text = "AvTabPage2";
            this.avTabPage4.ToolTipText = "AvTabPage2";
            // 
            // avTabPage5
            // 
            this.avTabPage5.BackColor = System.Drawing.Color.Transparent;
            this.avTabPage5.Icon = null;
            this.avTabPage5.Name = "avTabPage5";
            this.avTabPage5.Owner = this.avMultitabControl1;
            this.avTabPage5.Size = new System.Drawing.Size(646, 351);
            this.avTabPage5.Text = "AvTabPage3";
            this.avTabPage5.ToolTipText = "AvTabPage3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 544);
            this.Controls.Add(this.avMultitabControl1);
            this.Controls.Add(this.avVScroll1);
            this.Controls.Add(this.splitViewer2);
            this.Controls.Add(this.splitViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.avMultitabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitViewer.SplitViewer splitViewer1;
        private SplitViewer.SplitViewer splitViewer2;
        private AvVScroll avVScroll1;
        private AvMultitabControl.AvMultitabControl avMultitabControl1;
        private AvControls.AvMultitabControl.MultitabPage avTabPage1;
        private AvControls.AvMultitabControl.MultitabPage avTabPage2;
        private AvControls.AvMultitabControl.MultitabPage avTabPage3;
        private AvControls.AvMultitabControl.MultitabPage avTabPage4;
        private AvControls.AvMultitabControl.MultitabPage avTabPage5;
    }
}