using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentScreenNew
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
            if (disposing)
            {
                _complianceControl.ComplianceAdded -= ComplianceControlComplianceAdded;
            }
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._summaryControl = new ComponentSummary();
            this.extendableRichContainerGeneral = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._generalInformation = new ComponentGeneralInformationControl();
            this.extendableRichContainerWorkParams = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._detailWorkParamsControl = new CAS.UI.UIControls.DetailsControls.PowerUnitWorkInRegimeListControl();
            this.extendableRichContainerPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._performanceControl = new ComponentCompliancePerformanceListControl();
            this._complianceControl = new ComponentComplianceControl();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.Margin = new System.Windows.Forms.Padding(3);
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.Size = new System.Drawing.Size(773, 54);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlReloadButtonClick);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlPrintButtonDisplayerRequested);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // statusControl
            // 
            this.statusControl.MinimumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(1000, 35);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Location = new System.Drawing.Point(0, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(777, 234);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerSummary);
            this.flowLayoutPanelMain.Controls.Add(this._summaryControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerGeneral);
            this.flowLayoutPanelMain.Controls.Add(this._generalInformation);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerWorkParams);
            this.flowLayoutPanelMain.Controls.Add(this._detailWorkParamsControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPerformance);
            this.flowLayoutPanelMain.Controls.Add(this._performanceControl);
            this.flowLayoutPanelMain.Controls.Add(this._complianceControl);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(777, 234);
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
            this.extendableRichContainerSummary.TabIndex = 2;
            this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // _summaryControl
            // 
            this._summaryControl.AutoSize = true;
            this._summaryControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._summaryControl.Location = new System.Drawing.Point(3, 49);
            this._summaryControl.MinimumSize = new System.Drawing.Size(1000, 450);
            this._summaryControl.Name = "_summaryControl";
            this._summaryControl.Size = new System.Drawing.Size(1107, 470);
            this._summaryControl.TabIndex = 10;
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
            this.extendableRichContainerGeneral.Extended = false;
            this.extendableRichContainerGeneral.Location = new System.Drawing.Point(3, 525);
            this.extendableRichContainerGeneral.MainControl = null;
            this.extendableRichContainerGeneral.Name = "extendableRichContainerGeneral";
            this.extendableRichContainerGeneral.Size = new System.Drawing.Size(244, 40);
            this.extendableRichContainerGeneral.TabIndex = 3;
            this.extendableRichContainerGeneral.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerGeneral.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralExtending);
            // 
            // _generalInformation
            // 
            this._generalInformation.AutoSize = true;
            this._generalInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._generalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._generalInformation.Location = new System.Drawing.Point(3, 571);
            this._generalInformation.Name = "_generalInformation";
            this._generalInformation.Size = new System.Drawing.Size(1190, 310);
            this._generalInformation.TabIndex = 9;
            this._generalInformation.Visible = false;
			this._generalInformation.LLPLifeLimitChanged += LLPLifeLimitChanged; ;
            this._generalInformation.LLPMarkChecked += new System.EventHandler(this.GeneralInformationLLPMarkChecked);
            this._generalInformation.ComponentTypeChanged += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.GeneralInformationComponentTypeChanged);
            // 
            // extendableRichContainerWorkParams
            // 
            this.extendableRichContainerWorkParams.AfterCaptionControl = null;
            this.extendableRichContainerWorkParams.AfterCaptionControl2 = null;
            this.extendableRichContainerWorkParams.AfterCaptionControl3 = null;
            this.extendableRichContainerWorkParams.AutoSize = true;
            this.extendableRichContainerWorkParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerWorkParams.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerWorkParams.Caption = "Work Params";
            this.extendableRichContainerWorkParams.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerWorkParams.Condition = null;
            this.extendableRichContainerWorkParams.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerWorkParams.Extendable = true;
            this.extendableRichContainerWorkParams.Extended = false;
            this.extendableRichContainerWorkParams.Location = new System.Drawing.Point(3, 868);
            this.extendableRichContainerWorkParams.MainControl = null;
            this.extendableRichContainerWorkParams.Name = "extendableRichContainerWorkParams";
            this.extendableRichContainerWorkParams.Size = new System.Drawing.Size(244, 40);
            this.extendableRichContainerWorkParams.TabIndex = 4;
            this.extendableRichContainerWorkParams.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerWorkParams.Extending += new System.EventHandler(this.ExtendableRichContainerWorkParamsExtending);
            // 
            // _detailWorkParamsControl
            // 
            this._detailWorkParamsControl.AttachedObject = null;
            this._detailWorkParamsControl.AutoSize = true;
            this._detailWorkParamsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._detailWorkParamsControl.BaseComponent = null;
            this._detailWorkParamsControl.Location = new System.Drawing.Point(4, 915);
            this._detailWorkParamsControl.Margin = new System.Windows.Forms.Padding(4);
            this._detailWorkParamsControl.MaximumSize = new System.Drawing.Size(1600, 640);
            this._detailWorkParamsControl.MinimumSize = new System.Drawing.Size(840, 360);
            this._detailWorkParamsControl.Name = "_detailWorkParamsControl";
            this._detailWorkParamsControl.Size = new System.Drawing.Size(1168, 545);
            this._detailWorkParamsControl.TabIndex = 8;
            this._detailWorkParamsControl.Visible = false;
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
            this.extendableRichContainerPerformance.Extended = false;
            this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 1467);
            this.extendableRichContainerPerformance.MainControl = null;
            this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this.extendableRichContainerPerformance.Size = new System.Drawing.Size(234, 40);
            this.extendableRichContainerPerformance.TabIndex = 5;
            this.extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
            // 
            // _performanceControl
            // 
            this._performanceControl.AutoSize = true;
            this._performanceControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._performanceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._performanceControl.Location = new System.Drawing.Point(3, 1513);
            this._performanceControl.MinimumSize = new System.Drawing.Size(1206, 50);
            this._performanceControl.Name = "_performanceControl";
            this._performanceControl.Size = new System.Drawing.Size(1206, 50);
            this._performanceControl.TabIndex = 7;
            this._performanceControl.Visible = false;
            this._performanceControl.DirectiveRemoved += new System.EventHandler(this.PerformanceControlDirectiveRemoved);
            this._performanceControl.LLPLifeLimitChanged += new System.EventHandler(this.PerformanceControlLLPLifeLimitChanged);
            // 
            // _complianceControl
            // 
            this._complianceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._complianceControl.Displayer = null;
            this._complianceControl.DisplayerText = null;
            this._complianceControl.Entity = null;
            this._complianceControl.Location = new System.Drawing.Point(4, 1570);
            this._complianceControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._complianceControl.Name = "_complianceControl";
            this._complianceControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._complianceControl.ShowContent = true;
            this._complianceControl.Size = new System.Drawing.Size(851, 354);
            this._complianceControl.TabIndex = 6;
            this._complianceControl.ComplianceAdded += new System.EventHandler(this.ComplianceControlComplianceAdded);
            // 
            // DetailScreenNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComponentScreenNew";
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
        private ReferenceControls.ExtendableRichContainer extendableRichContainerGeneral;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerWorkParams;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
        private ComponentComplianceControl _complianceControl;
        private ComponentCompliancePerformanceListControl _performanceControl;
        private PowerUnitWorkInRegimeListControl _detailWorkParamsControl;
        private ComponentGeneralInformationControl _generalInformation;
        private ComponentSummary _summaryControl;
    }
}
