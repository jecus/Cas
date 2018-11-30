using System.Windows.Forms;
using LTR.Core;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.OpepatorsControls;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.DirectivesControls
{
    partial class OperatorScreen
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

        #region private void InitializeComponent()
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorScreen));
            this.uiFooterControl1 = new LTR.UI.UIControls.Auxiliary.UIFooterControl();
            this.headerControl1 = new LTR.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftScreenHeaderControl = new LTR.UI.UIControls.AircraftsControls.AircraftScreenHeaderControl();
            this.contextActionControl1 = new LTR.UI.UIControls.Auxiliary.ContextActionControl();
            this.actionControl1 = new LTR.UI.UIControls.Auxiliary.ActionControl();
            this.flowLayoutPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerControl1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiFooterControl1
            // 
            this.uiFooterControl1.AutoSize = true;
            this.uiFooterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiFooterControl1.BackColor = System.Drawing.Color.Transparent;
            this.uiFooterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiFooterControl1.Location = new System.Drawing.Point(0, 568);
            this.uiFooterControl1.Margin = new System.Windows.Forms.Padding(0);
            this.uiFooterControl1.MaximumSize = new System.Drawing.Size(0, 48);
            this.uiFooterControl1.MinimumSize = new System.Drawing.Size(0, 48);
            this.uiFooterControl1.Name = "uiFooterControl1";
            this.uiFooterControl1.Size = new System.Drawing.Size(1042, 48);
            this.uiFooterControl1.TabIndex = 10;
            // 
            // headerControl1
            // 
            this.headerControl1.BackColor = System.Drawing.Color.Transparent;
            this.headerControl1.BackgroundImage = global::LTR.UI.Properties.Resources.HeaderBar;
            this.headerControl1.Controls.Add(this.aircraftScreenHeaderControl);
            this.headerControl1.Controls.Add(this.contextActionControl1);
            this.headerControl1.Controls.Add(this.actionControl1);
            this.headerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(1042, 58);
            this.headerControl1.TabIndex = 6;
            // 
            // aircraftScreenHeaderControl
            // 
            this.aircraftScreenHeaderControl.BackColor = System.Drawing.Color.Transparent;
            this.aircraftScreenHeaderControl.Displayer = null;
            this.aircraftScreenHeaderControl.DisplayerText = "Operator";
            this.aircraftScreenHeaderControl.Entity = null;
            this.aircraftScreenHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.aircraftScreenHeaderControl.Name = "aircraftScreenHeaderControl";
            this.aircraftScreenHeaderControl.OperatorImage = null;
            this.aircraftScreenHeaderControl.OperatorText = "avButton1";
            this.aircraftScreenHeaderControl.ReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.aircraftScreenHeaderControl.Size = new System.Drawing.Size(381, 58);
            this.aircraftScreenHeaderControl.TabIndex = 10;
            // 
            // contextActionControl1
            // 
            this.contextActionControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contextActionControl1.AutoSize = true;
            this.contextActionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contextActionControl1.BackColor = System.Drawing.Color.Transparent;
            this.contextActionControl1.EditDisplayer = null;
            this.contextActionControl1.EditDisplayerText = null;
            this.contextActionControl1.EditEntity = null;
            this.contextActionControl1.EditReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.contextActionControl1.Location = new System.Drawing.Point(739, 0);
            this.contextActionControl1.Name = "contextActionControl1";
            this.contextActionControl1.Size = new System.Drawing.Size(300, 57);
            this.contextActionControl1.TabIndex = 9;
            this.contextActionControl1.TopicID = null;
            // 
            // actionControl1
            // 
            this.actionControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionControl1.AutoSize = true;
            this.actionControl1.BackColor = System.Drawing.Color.Transparent;
            this.actionControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("actionControl1.BackgroundImage")));
            this.actionControl1.EditDisplayer = null;
            this.actionControl1.EditDisplayerText = "Edit operator";
            this.actionControl1.EditEntity = null;
            this.actionControl1.EditReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.actionControl1.Location = new System.Drawing.Point(384, 0);
            this.actionControl1.Margin = new System.Windows.Forms.Padding(0);
            this.actionControl1.MinimumSize = new System.Drawing.Size(0, 57);
            this.actionControl1.Name = "actionControl1";
            this.actionControl1.Size = new System.Drawing.Size(308, 57);
            this.actionControl1.TabIndex = 8;
            // 
            // flowLayoutPanelRight
            // 
            this.flowLayoutPanelRight.AutoSize = true;
            this.flowLayoutPanelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelRight.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRight.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRight.Location = new System.Drawing.Point(1042, 0);
            this.flowLayoutPanelRight.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            this.flowLayoutPanelRight.Size = new System.Drawing.Size(0, 510);
            this.flowLayoutPanelRight.TabIndex = 12;
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.AutoSize = true;
            this.flowLayoutPanelTop.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelTop.ColumnCount = 2;
            this.flowLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.RowCount = 1;
            this.flowLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(1042, 0);
            this.flowLayoutPanelTop.TabIndex = 111;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.flowLayoutPanelTop);
            this.mainPanel.Controls.Add(this.flowLayoutPanelRight);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 58);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1042, 510);
            this.mainPanel.TabIndex = 11;
            this.mainPanel.SizeChanged += new System.EventHandler(this.mainPanel_SizeChanged);
            // 
            // OperatorScreen
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.uiFooterControl1);
            this.Controls.Add(this.headerControl1);
            this.Name = "OperatorScreen";
            this.Size = new System.Drawing.Size(1042, 616);
            this.headerControl1.ResumeLayout(false);
            this.headerControl1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Aircraft currentAircraft;
        private HeaderControl headerControl1;
        private ContextActionControl contextActionControl1;
        private ActionControl actionControl1;
        private UIFooterControl uiFooterControl1;
        private LTR.UI.UIControls.AircraftsControls.AircraftScreenHeaderControl aircraftScreenHeaderControl;
        private FlowLayoutPanel flowLayoutPanelRight;
        private TableLayoutPanel flowLayoutPanelTop;
        private Panel mainPanel;
    }
}
