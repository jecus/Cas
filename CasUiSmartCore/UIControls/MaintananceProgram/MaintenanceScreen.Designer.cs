using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceScreen
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.maintenanceSummaryControl1 = new CAS.UI.UIControls.MaintananceProgram.MaintenanceSummaryControl();
            this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.maintenanceLimitationControl1 = new CAS.UI.UIControls.MaintananceProgram.MaintenanceGeneralDateControl();
            this.extendableRichContainerPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.maintenancePerformanceControl1 = new CAS.UI.UIControls.MaintananceProgram.MaintenancePlanningControl();
            this.complianceControl = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCompliance();
            this.headerControl.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.Size = new System.Drawing.Size(735, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 105);
            this.panel1.Size = new System.Drawing.Size(739, 230);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerSummary);
            this.flowLayoutPanel1.Controls.Add(this.maintenanceSummaryControl1);
            this.flowLayoutPanel1.Controls.Add(this.extendableRichContainer1);
            this.flowLayoutPanel1.Controls.Add(this.maintenanceLimitationControl1);
            this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerPerformance);
            this.flowLayoutPanel1.Controls.Add(this.maintenancePerformanceControl1);
            this.flowLayoutPanel1.Controls.Add(this.complianceControl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 105);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 230);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
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
            this.extendableRichContainerSummary.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerSummary.Condition = null;
            this.extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerSummary.Extendable = true;
            this.extendableRichContainerSummary.Extended = true;
            this.extendableRichContainerSummary.Location = new System.Drawing.Point(3, 59);
            this.extendableRichContainerSummary.MainControl = null;
            this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this.extendableRichContainerSummary.Size = new System.Drawing.Size(192, 40);
            this.extendableRichContainerSummary.TabIndex = 7;
            this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // maintenanceSummaryControl1
            // 
            this.maintenanceSummaryControl1.AutoSize = true;
            this.maintenanceSummaryControl1.CheckItems = null;
            this.maintenanceSummaryControl1.Location = new System.Drawing.Point(3, 105);
            this.maintenanceSummaryControl1.Name = "maintenanceSummaryControl1";
            this.maintenanceSummaryControl1.Size = new System.Drawing.Size(1219, 823);
            this.maintenanceSummaryControl1.TabIndex = 8;
            // 
            // extendableRichContainer1
            // 
            this.extendableRichContainer1.AfterCaptionControl = null;
            this.extendableRichContainer1.AfterCaptionControl2 = null;
            this.extendableRichContainer1.AfterCaptionControl3 = null;
            this.extendableRichContainer1.AutoSize = true;
            this.extendableRichContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer1.Caption = "General Data";
            this.extendableRichContainer1.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer1.Condition = null;
            this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer1.Extendable = true;
            this.extendableRichContainer1.Extended = true;
            this.extendableRichContainer1.Location = new System.Drawing.Point(3, 934);
            this.extendableRichContainer1.MainControl = null;
            this.extendableRichContainer1.Name = "extendableRichContainer1";
            this.extendableRichContainer1.Size = new System.Drawing.Size(244, 40);
            this.extendableRichContainer1.TabIndex = 1;
            this.extendableRichContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer1.Extending += new System.EventHandler(this.ExtendableRichContainer1Extending);
            // 
            // maintenanceLimitationControl1
            // 
            this.maintenanceLimitationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maintenanceLimitationControl1.CheckItems = null;
            this.maintenanceLimitationControl1.Location = new System.Drawing.Point(3, 980);
            this.maintenanceLimitationControl1.MaximumSize = new System.Drawing.Size(1200, 575);
            this.maintenanceLimitationControl1.MinimumSize = new System.Drawing.Size(1200, 375);
            this.maintenanceLimitationControl1.Name = "maintenanceLimitationControl1";
            this.maintenanceLimitationControl1.Size = new System.Drawing.Size(1200, 575);
            this.maintenanceLimitationControl1.TabIndex = 2;
            this.maintenanceLimitationControl1.Visible = false;
            // 
            // extendableRichContainerPerformance
            // 
            this.extendableRichContainerPerformance.AfterCaptionControl = null;
            this.extendableRichContainerPerformance.AfterCaptionControl2 = null;
            this.extendableRichContainerPerformance.AfterCaptionControl3 = null;
            this.extendableRichContainerPerformance.AutoSize = true;
            this.extendableRichContainerPerformance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerPerformance.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerPerformance.Caption = "Performance";
            this.extendableRichContainerPerformance.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerPerformance.Condition = null;
            this.extendableRichContainerPerformance.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerPerformance.Extendable = true;
            this.extendableRichContainerPerformance.Extended = true;
            this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 1561);
            this.extendableRichContainerPerformance.MainControl = null;
            this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this.extendableRichContainerPerformance.Size = new System.Drawing.Size(234, 40);
            this.extendableRichContainerPerformance.TabIndex = 6;
            this.extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending1);
            // 
            // maintenancePerformanceControl1
            // 
            this.maintenancePerformanceControl1.CheckItems = null;
            this.maintenancePerformanceControl1.Location = new System.Drawing.Point(3, 1607);
            this.maintenancePerformanceControl1.MaximumSize = new System.Drawing.Size(1200, 456);
            this.maintenancePerformanceControl1.MinimumSize = new System.Drawing.Size(1200, 456);
            this.maintenancePerformanceControl1.Name = "maintenancePerformanceControl1";
            this.maintenancePerformanceControl1.Size = new System.Drawing.Size(1200, 456);
            this.maintenancePerformanceControl1.TabIndex = 5;
            this.maintenancePerformanceControl1.Visible = false;
            // 
            // maintenanceCompliance1
            // 
            this.complianceControl.CheckItems = null;
            this.complianceControl.Displayer = null;
            this.complianceControl.DisplayerText = null;
            this.complianceControl.Entity = null;
            this.complianceControl.Location = new System.Drawing.Point(3, 2069);
            this.complianceControl.Name = "maintenanceCompliance1";
            this.complianceControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.complianceControl.ShowContent = true;
            this.complianceControl.Size = new System.Drawing.Size(1200, 448);
            this.complianceControl.TabIndex = 9;
            this.complianceControl.ComplianceAdded += new System.EventHandler(this.MaintenanceCompliance1ComplianceAdded);
            // 
            // statusControl
            // 
            this.statusControl.MaximumSize = new System.Drawing.Size(1280, 35);
            this.statusControl.MinimumSize = new System.Drawing.Size(800, 35);
            this.statusControl.Size = new System.Drawing.Size(1280, 35);
            // 
            // MaintenanceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildClickable = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MaintenanceScreen";
            this.OperatorClickable = true;
            this.ShowTopPanelContainer = false;
            this.Size = new System.Drawing.Size(739, 383);
            this.StatusTitle = "Maintenance program";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer1;
        private MaintenanceGeneralDateControl maintenanceLimitationControl1;

        private MaintenancePlanningControl maintenancePerformanceControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        private MaintenanceSummaryControl maintenanceSummaryControl1;
        private MaintenanceCompliance complianceControl;
    }
}
