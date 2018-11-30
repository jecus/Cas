using System.Drawing;

namespace CAS.UI.UIControls.ReferenceControls
{
    partial class ReferenceLinkLabelCollectionContainer
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
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = null;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Aircrafts";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = true;
            this.extendableRichContainer.Location = new System.Drawing.Point(4, 4);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
            this.extendableRichContainer.MaximumSize = new System.Drawing.Size(400, 40);
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(143, 34);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainer);
            this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelContainer);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(151, 62);
            this.flowLayoutPanelMain.TabIndex = 40;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // flowLayoutPanelContainer
            // 
            this.flowLayoutPanelContainer.AutoSize = true;
            this.flowLayoutPanelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelContainer.Location = new System.Drawing.Point(2, 44);
            this.flowLayoutPanelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelContainer.MinimumSize = new System.Drawing.Size(90, 16);
            this.flowLayoutPanelContainer.Name = "flowLayoutPanelContainer";
            this.flowLayoutPanelContainer.Size = new System.Drawing.Size(90, 16);
            this.flowLayoutPanelContainer.TabIndex = 41;
            // 
            // ReferenceLinkLabelCollectionContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReferenceLinkLabelCollectionContainer";
            this.Size = new System.Drawing.Size(151, 62);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContainer;
    }
}
