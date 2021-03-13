using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DirectiveScreen
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

            _directiveGeneralInformation.EffDateChanget -= FlightDateRouteControl1FlightDateChanget;

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._directiveSummary = new CAS.UI.UIControls.DirectivesControls.DirectiveSummary();
            this.extendableRichContainerGeneral = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._directiveGeneralInformation = new CAS.UI.UIControls.DirectivesControls.DirectiveInformationControl();
            this.extendableRichContainerPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._performanceControl = new CAS.UI.UIControls.DirectivesControls.DirectiveParametersControl();
            this._complianceControl = new CAS.UI.UIControls.DirectivesControls.DirectiveComplianceControl();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.Size = new System.Drawing.Size(773, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
            this.headerControl.SaveButton2Click += new System.EventHandler(this.HeaderControlButtonSaveAndAddClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Location = new System.Drawing.Point(0, 105);
            this.panel1.Size = new System.Drawing.Size(777, 230);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            // 
            // statusControl
            // 
            this.statusControl.MinimumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(1000, 35);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerSummary);
            this.flowLayoutPanelMain.Controls.Add(this._directiveSummary);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerGeneral);
            this.flowLayoutPanelMain.Controls.Add(this._directiveGeneralInformation);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPerformance);
            this.flowLayoutPanelMain.Controls.Add(this._performanceControl);
            this.flowLayoutPanelMain.Controls.Add(this._complianceControl);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(777, 230);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
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
            this.extendableRichContainerSummary.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainerSummary.MainControl = null;
            this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this.extendableRichContainerSummary.Size = new System.Drawing.Size(192, 40);
            this.extendableRichContainerSummary.TabIndex = 7;
            this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // _directiveSummary
            // 
            this._directiveSummary.AutoSize = true;
            this._directiveSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._directiveSummary.CurrentDirective = null;
            this._directiveSummary.Location = new System.Drawing.Point(3, 49);
            this._directiveSummary.MinimumSize = new System.Drawing.Size(1162, 250);
            this._directiveSummary.Name = "_directiveSummary";
            this._directiveSummary.Size = new System.Drawing.Size(1162, 615);
            this._directiveSummary.TabIndex = 8;
            // 
            // extendableRichContainerGeneral
            // 
            this.extendableRichContainerGeneral.AfterCaptionControl = null;
            this.extendableRichContainerGeneral.AfterCaptionControl2 = null;
            this.extendableRichContainerGeneral.AfterCaptionControl3 = null;
            this.extendableRichContainerGeneral.AutoSize = true;
            this.extendableRichContainerGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerGeneral.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerGeneral.Caption = "General Data";
            this.extendableRichContainerGeneral.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerGeneral.Condition = null;
            this.extendableRichContainerGeneral.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerGeneral.Extendable = true;
            this.extendableRichContainerGeneral.Extended = true;
            this.extendableRichContainerGeneral.Location = new System.Drawing.Point(3, 670);
            this.extendableRichContainerGeneral.MainControl = null;
            this.extendableRichContainerGeneral.Name = "extendableRichContainerGeneral";
            this.extendableRichContainerGeneral.Size = new System.Drawing.Size(244, 40);
            this.extendableRichContainerGeneral.TabIndex = 9;
            this.extendableRichContainerGeneral.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerGeneral.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralExtending);
            // 
            // _directiveGeneralInformation
            // 
            this._directiveGeneralInformation.AutoSize = true;
            this._directiveGeneralInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._directiveGeneralInformation.Displayer = null;
            this._directiveGeneralInformation.DisplayerText = null;
            this._directiveGeneralInformation.EffectiveDate = new System.DateTime(2014, 2, 9, 17, 58, 13, 574);
            this._directiveGeneralInformation.Entity = null;
            this._directiveGeneralInformation.Location = new System.Drawing.Point(3, 716);
            this._directiveGeneralInformation.Name = "_directiveGeneralInformation";
            this._directiveGeneralInformation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._directiveGeneralInformation.Size = new System.Drawing.Size(1103, 500);
            this._directiveGeneralInformation.TabIndex = 10;
            this._directiveGeneralInformation.Title = "";
            this._directiveGeneralInformation.Visible = false;
            this._directiveGeneralInformation.EffDateChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightDateRouteControl1FlightDateChanget);
            
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
            this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 1222);
            this.extendableRichContainerPerformance.MainControl = null;
            this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this.extendableRichContainerPerformance.Size = new System.Drawing.Size(234, 40);
            this.extendableRichContainerPerformance.TabIndex = 11;
            this.extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
            // 
            // _performanceControl
            // 
            this._performanceControl.AutoSize = true;
            this._performanceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._performanceControl.DamageChartLocation = "";
            this._performanceControl.isClosed = false;
            this._performanceControl.Location = new System.Drawing.Point(3, 1268);
            this._performanceControl.Name = "_performanceControl";
            this._performanceControl.Size = new System.Drawing.Size(1182, 425);
            this._performanceControl.TabIndex = 14;
            this._performanceControl.Visible = false;
            this._performanceControl.DataWereChanged += new System.EventHandler(PerformanceControlDataWereChanged);
            // 
            // _complianceControl
            // 
            this._complianceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._complianceControl.Displayer = null;
            this._complianceControl.DisplayerText = null;
            this._complianceControl.Entity = null;
            this._complianceControl.Location = new System.Drawing.Point(3, 1699);
            this._complianceControl.Name = "_complianceControl";
            this._complianceControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._complianceControl.ShowContent = true;
            this._complianceControl.Size = new System.Drawing.Size(851, 350);
            this._complianceControl.TabIndex = 13;
            this._complianceControl.ComplianceAdded += new System.EventHandler(this.ComplianceControlComplianceAdded);
            // 
            // DirectiveScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildClickable = true;
            this.Name = "DirectiveScreen";
            this.OperatorClickable = true;
            this.ShowTopPanelContainer = false;
            this.Size = new System.Drawing.Size(777, 383);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        private DirectiveSummary _directiveSummary;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerGeneral;
        public DirectiveInformationControl _directiveGeneralInformation;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
        private DirectiveComplianceControl _complianceControl;
        private DirectiveParametersControl _performanceControl;
    }
}
