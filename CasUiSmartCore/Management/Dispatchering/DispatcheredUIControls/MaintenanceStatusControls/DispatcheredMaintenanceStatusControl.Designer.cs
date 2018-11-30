namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls
{
    partial class DispatcheredMaintenanceStatusControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DispatcheredMaintenanceStatusControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.extendableRichContainerLimitations = new LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.extendableRichContainerSummary = new LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.headerControl = new LTR.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftHeaderControl1 = new LTR.UI.UIControls.Auxiliary.AircraftHeaderControl();
            this.footerControl1 = new LTR.UI.UIControls.Auxiliary.FooterControl();
            this.extendableRichContainerCompliance = new LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.panel1.SuspendLayout();
            this.headerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.extendableRichContainerCompliance);
            this.panel1.Controls.Add(this.extendableRichContainerLimitations);
            this.panel1.Controls.Add(this.extendableRichContainerSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 454);
            this.panel1.TabIndex = 1;
            // 
            // extendableRichContainerLimitations
            // 
            this.extendableRichContainerLimitations.AfterCaptionControl = null;
            this.extendableRichContainerLimitations.AfterCaptionControl2 = null;
            this.extendableRichContainerLimitations.AfterCaptionControl3 = null;
            this.extendableRichContainerLimitations.AutoSize = true;
            this.extendableRichContainerLimitations.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerLimitations.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerLimitations.Caption = "Limitations. Max resources";
            this.extendableRichContainerLimitations.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerLimitations.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendableRichContainerLimitations.Extendable = true;
            this.extendableRichContainerLimitations.Extended = false;
            this.extendableRichContainerLimitations.Location = new System.Drawing.Point(0, 40);
            this.extendableRichContainerLimitations.MainControl = null;
            this.extendableRichContainerLimitations.Name = "extendableRichContainerLimitations";
            this.extendableRichContainerLimitations.Size = new System.Drawing.Size(1204, 40);
            this.extendableRichContainerLimitations.TabIndex = 1;
            this.extendableRichContainerLimitations.UpperLeftIcon = null;
            // 
            // extendableRichContainerSummary
            // 
            this.extendableRichContainerSummary.AfterCaptionControl = null;
            this.extendableRichContainerSummary.AfterCaptionControl2 = null;
            this.extendableRichContainerSummary.AfterCaptionControl3 = null;
            this.extendableRichContainerSummary.AutoSize = true;
            this.extendableRichContainerSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerSummary.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerSummary.Caption = "Summary";
            this.extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendableRichContainerSummary.Extendable = true;
            this.extendableRichContainerSummary.Extended = true;
            this.extendableRichContainerSummary.Location = new System.Drawing.Point(0, 0);
            this.extendableRichContainerSummary.MainControl = null;
            this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this.extendableRichContainerSummary.Size = new System.Drawing.Size(1204, 40);
            this.extendableRichContainerSummary.TabIndex = 0;
            this.extendableRichContainerSummary.UpperLeftIcon = null;
            // 
            // headerControl
            // 
            this.headerControl.ActionControlSplitterVisible = true;
            this.headerControl.BackColor = System.Drawing.Color.Transparent;
            this.headerControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl1.BackgroundImage")));
            this.headerControl.Controls.Add(this.aircraftHeaderControl1);
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl.EditDisplayerText = "";
            this.headerControl.EditReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(1204, 58);
            this.headerControl.TabIndex = 0;
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.Aircraft = null;
            this.aircraftHeaderControl1.AircraftClickable = true;
            this.aircraftHeaderControl1.AutoSize = true;
            this.aircraftHeaderControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftHeaderControl1.BackColor = System.Drawing.Color.Transparent;
            this.aircraftHeaderControl1.Location = new System.Drawing.Point(3, 0);
            this.aircraftHeaderControl1.Name = "aircraftHeaderControl1";
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.Size = new System.Drawing.Size(532, 60);
            this.aircraftHeaderControl1.TabIndex = 0;
            // 
            // footerControl1
            // 
            this.footerControl1.AutoSize = true;
            this.footerControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.footerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerControl1.Location = new System.Drawing.Point(0, 512);
            this.footerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.footerControl1.MinimumSize = new System.Drawing.Size(1000, 48);
            this.footerControl1.Name = "footerControl1";
            this.footerControl1.Size = new System.Drawing.Size(1204, 48);
            this.footerControl1.TabIndex = 0;
            // 
            // extendableRichContainerCompliance
            // 
            this.extendableRichContainerCompliance.AfterCaptionControl = null;
            this.extendableRichContainerCompliance.AfterCaptionControl2 = null;
            this.extendableRichContainerCompliance.AfterCaptionControl3 = null;
            this.extendableRichContainerCompliance.AutoSize = true;
            this.extendableRichContainerCompliance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerCompliance.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerCompliance.Caption = "Compliance";
            this.extendableRichContainerCompliance.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerCompliance.Dock = System.Windows.Forms.DockStyle.Top;
            this.extendableRichContainerCompliance.Extendable = true;
            this.extendableRichContainerCompliance.Extended = false;
            this.extendableRichContainerCompliance.Location = new System.Drawing.Point(0, 80);
            this.extendableRichContainerCompliance.MainControl = null;
            this.extendableRichContainerCompliance.Name = "extendableRichContainerCompliance";
            this.extendableRichContainerCompliance.Size = new System.Drawing.Size(1204, 40);
            this.extendableRichContainerCompliance.TabIndex = 2;
            this.extendableRichContainerCompliance.UpperLeftIcon = null;
            // 
            // DispatcheredMaintenanceStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerControl);
            this.Controls.Add(this.footerControl1);
            this.Name = "DispatcheredMaintenanceStatusControl";
            this.Size = new System.Drawing.Size(1204, 560);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LTR.UI.UIControls.Auxiliary.FooterControl footerControl1;
        private LTR.UI.UIControls.Auxiliary.HeaderControl headerControl;
        private LTR.UI.UIControls.Auxiliary.AircraftHeaderControl aircraftHeaderControl1;
        private System.Windows.Forms.Panel panel1;
        private LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        private LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerLimitations;
        private LTR.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerCompliance;
    }
}
