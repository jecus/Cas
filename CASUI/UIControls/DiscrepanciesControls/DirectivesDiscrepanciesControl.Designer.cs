namespace CAS.UI.UIControls.DiscrepanciesControls
{
    partial class DirectivesDiscrepanciesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectivesDiscrepanciesControl));
            this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.SuspendLayout();
            // 
            // extendableRichContainer1
            // 
            this.extendableRichContainer1.AfterCaptionControl = null;
            this.extendableRichContainer1.AfterCaptionControl2 = null;
            this.extendableRichContainer1.AfterCaptionControl3 = null;
            this.extendableRichContainer1.AutoSize = true;
            this.extendableRichContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer1.Caption = "Discrepancies";
            this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendableRichContainer1.Extendable = true;
            this.extendableRichContainer1.Extended = true;
            this.extendableRichContainer1.Location = new System.Drawing.Point(0, 0);
            this.extendableRichContainer1.MainControl = null;
            this.extendableRichContainer1.Name = "extendableRichContainer1";
            this.extendableRichContainer1.Size = new System.Drawing.Size(607, 40);
            this.extendableRichContainer1.TabIndex = 0;
            this.extendableRichContainer1.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("extendableRichContainer1.UpperLeftIcon")));
            // 
            // DirectivesDiscrepanciesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.extendableRichContainer1);
            this.Name = "DirectivesDiscrepancies";
            this.Size = new System.Drawing.Size(607, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer1;
    }
}
