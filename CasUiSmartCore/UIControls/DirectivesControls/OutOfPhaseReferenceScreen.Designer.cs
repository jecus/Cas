﻿using CASTerms;

namespace CAS.UI.UIControls.DirectivesControls
{
    partial class OutOfPhaseReferenceScreen
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._outOfPhaseSummary = new CAS.UI.UIControls.DirectivesControls.OutOfPhaseReferenceSummary();
            this.extendableRichContainerGeneral = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._outOfPhaseReferenceGeneralInformation = new CAS.UI.UIControls.DirectivesControls.OutOfPhaseReferenceGeneralInformationControl();
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
            this.headerControl.Size = new System.Drawing.Size(959, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
            this.headerControl.SaveButton2Click += new System.EventHandler(this.HeaderControlButtonSaveAndAddClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Size = new System.Drawing.Size(961, 447);
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
            this.statusControl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(959, 35);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerSummary);
            this.flowLayoutPanelMain.Controls.Add(this._outOfPhaseSummary);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerGeneral);
            this.flowLayoutPanelMain.Controls.Add(this._outOfPhaseReferenceGeneralInformation);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPerformance);
            this.flowLayoutPanelMain.Controls.Add(this._performanceControl);
            this.flowLayoutPanelMain.Controls.Add(this._complianceControl);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(961, 447);
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
            this.extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerSummary.Extendable = true;
            this.extendableRichContainerSummary.Extended = true;
            this.extendableRichContainerSummary.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainerSummary.MainControl = null;
            this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this.extendableRichContainerSummary.Size = new System.Drawing.Size(200, 40);
            this.extendableRichContainerSummary.TabIndex = 1;
            this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // _outOfPhaseSummary
            // 
            this._outOfPhaseSummary.AutoSize = true;
            this._outOfPhaseSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._outOfPhaseSummary.CurrentOutOfPhase = null;
            this._outOfPhaseSummary.Location = new System.Drawing.Point(3, 49);
            this._outOfPhaseSummary.MinimumSize = new System.Drawing.Size(1162, 250);
            this._outOfPhaseSummary.Name = "_outOfPhaseSummary";
            this._outOfPhaseSummary.Size = new System.Drawing.Size(1162, 308);
            this._outOfPhaseSummary.TabIndex = 2;
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
            this.extendableRichContainerGeneral.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerGeneral.Extendable = true;
            this.extendableRichContainerGeneral.Extended = true;
            this.extendableRichContainerGeneral.Location = new System.Drawing.Point(3, 363);
            this.extendableRichContainerGeneral.MainControl = null;
            this.extendableRichContainerGeneral.Name = "extendableRichContainerGeneral";
            this.extendableRichContainerGeneral.Size = new System.Drawing.Size(252, 40);
            this.extendableRichContainerGeneral.TabIndex = 3;
            this.extendableRichContainerGeneral.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerGeneral.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralExtending);
            // 
            // _outOfPhaseReferenceGeneralInformation
            // 
            this._outOfPhaseReferenceGeneralInformation.ADType = SmartCore.Entities.Dictionaries.ADType.Apliance;
            this._outOfPhaseReferenceGeneralInformation.Applicability = "";
            this._outOfPhaseReferenceGeneralInformation.AutoSize = true;
            this._outOfPhaseReferenceGeneralInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._outOfPhaseReferenceGeneralInformation.BiWeeklyReport = "";
            this._outOfPhaseReferenceGeneralInformation.CurrentOutOfPhaseItem = null;
            this._outOfPhaseReferenceGeneralInformation.Displayer = null;
            this._outOfPhaseReferenceGeneralInformation.DisplayerText = null;
            this._outOfPhaseReferenceGeneralInformation.EffectiveDate = new System.DateTime(2011, 4, 27, 11, 13, 53, 921);
            this._outOfPhaseReferenceGeneralInformation.EngOrderNumber = "";
            this._outOfPhaseReferenceGeneralInformation.Entity = null;
            this._outOfPhaseReferenceGeneralInformation.HiddenRemarks = "";
            this._outOfPhaseReferenceGeneralInformation.Location = new System.Drawing.Point(3, 409);
            this._outOfPhaseReferenceGeneralInformation.Name = "_outOfPhaseReferenceGeneralInformation";
            this._outOfPhaseReferenceGeneralInformation.Paragraph = null;
            this._outOfPhaseReferenceGeneralInformation.References = null;
            this._outOfPhaseReferenceGeneralInformation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._outOfPhaseReferenceGeneralInformation.Remarks = "";
            this._outOfPhaseReferenceGeneralInformation.ServiceBulletin = "";
            this._outOfPhaseReferenceGeneralInformation.Size = new System.Drawing.Size(1103, 500);
            this._outOfPhaseReferenceGeneralInformation.Subject = "";
            this._outOfPhaseReferenceGeneralInformation.TabIndex = 4;
            this._outOfPhaseReferenceGeneralInformation.Title = "";
            this._outOfPhaseReferenceGeneralInformation.Visible = false;
            this._outOfPhaseReferenceGeneralInformation.EffDateChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightDateRouteControl1FlightDateChanget);
            
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
            this.extendableRichContainerPerformance.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerPerformance.Extendable = true;
            this.extendableRichContainerPerformance.Extended = true;
            this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 915);
            this.extendableRichContainerPerformance.MainControl = null;
            this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this.extendableRichContainerPerformance.Size = new System.Drawing.Size(242, 40);
            this.extendableRichContainerPerformance.TabIndex = 7;
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
            // 
            // _complianceControl
            // 
            this._complianceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._complianceControl.Location = new System.Drawing.Point(3, 998);
            this._complianceControl.Name = "_complianceControl";
            this._complianceControl.ShowContent = true;
            this._complianceControl.Size = new System.Drawing.Size(851, 350);
            this._complianceControl.TabIndex = 9;
            this._complianceControl.ComplianceAdded += new System.EventHandler(this.ComplianceControlComplianceAdded);
            // 
            // OutOfPhaseReferenceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ShowTopPanelContainer = false;
            this.AutoScroll = true;
            this.Name = "OutOfPhaseReferenceScreen";
            this.Size = new System.Drawing.Size(961, 590);
            this.Controls.SetChildIndex(this.panel1, 0);
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
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        private OutOfPhaseReferenceSummary _outOfPhaseSummary;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerGeneral;
        private OutOfPhaseReferenceGeneralInformationControl _outOfPhaseReferenceGeneralInformation;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
        private DirectiveParametersControl _performanceControl;
        private DirectiveComplianceControl _complianceControl;
    }
}
