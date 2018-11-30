using System.Windows.Forms;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    partial class BasedetailDiscrepancies
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
            this.richReferenceContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.componentDiscrepancies1 = new CAS.UI.UIControls.DiscrepanciesControls.ComponentDiscrepancies();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // richReferenceContainer1
            // 
            this.richReferenceContainer1.AfterCaptionControl = null;
            this.richReferenceContainer1.AfterCaptionControl2 = null;
            this.richReferenceContainer1.AfterCaptionControl3 = null;
            this.richReferenceContainer1.BackColor = System.Drawing.Color.Transparent;
            this.richReferenceContainer1.Caption = "Discrepancies";
            this.richReferenceContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.richReferenceContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richReferenceContainer1.Location = new System.Drawing.Point(0, 0);
            this.richReferenceContainer1.MainControl = panel1;
            this.richReferenceContainer1.Name = "richReferenceContainer1";
            this.richReferenceContainer1.Size = new System.Drawing.Size(761, 47);
            this.richReferenceContainer1.TabIndex = 1;
            this.richReferenceContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // componentDiscrepancies1
            // 
            componentDiscrepancies1.AutoSize = true;
            this.componentDiscrepancies1.BackColor = System.Drawing.Color.Transparent;
            this.componentDiscrepancies1.Caption = "Component Status";
            this.componentDiscrepancies1.Dock = System.Windows.Forms.DockStyle.Top;
            this.componentDiscrepancies1.Location = new System.Drawing.Point(0, 47);
            this.componentDiscrepancies1.Name = "componentDiscrepancies1";
            this.componentDiscrepancies1.Size = new System.Drawing.Size(761, 82);
            this.componentDiscrepancies1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(componentDiscrepancies1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 100);
            this.panel1.TabIndex = 5;
            // 
            // BasedetailDiscrepancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.richReferenceContainer1);
            this.Name = "BasedetailDiscrepancies";
            this.Size = new System.Drawing.Size(761, 488);
            this.ResumeLayout(false);

        }

        #endregion

        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer richReferenceContainer1;
        private ComponentDiscrepancies componentDiscrepancies1;
        private System.Windows.Forms.Panel panel1;
    }
}
