using System;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentAddingScreen
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
            this.extendableRichContainerBaseDetail = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.extendableRichContainerGeneral = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.GeneralInformationControl = new ComponentAddingGeneralInformationControl();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.CompliancePerformanceListControl = new ComponentCompliancePerformanceListControl();
            this.addNewComponentControl1 = new AddNewComponentControl();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.SaveButtonToolTipText = "Save and Edit";
            this.headerControl.SaveReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.headerControl.ShowReloadButton = false;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.ShowSaveButton2 = true;
            this.headerControl.Size = new System.Drawing.Size(720, 54);
            this.headerControl.SaveButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlSaveButtonDisplayerRequested);
            this.headerControl.SaveButton2Click += new System.EventHandler(this.HeaderControlSaveButton2Click);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Size = new System.Drawing.Size(724, 277);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            // 
            // extendableRichContainerBaseDetail
            // 
            this.extendableRichContainerBaseDetail.AfterCaptionControl = null;
            this.extendableRichContainerBaseDetail.AfterCaptionControl2 = null;
            this.extendableRichContainerBaseDetail.AfterCaptionControl3 = null;
            this.extendableRichContainerBaseDetail.AutoSize = true;
            this.extendableRichContainerBaseDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerBaseDetail.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerBaseDetail.Caption = "Base Component";
            this.extendableRichContainerBaseDetail.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerBaseDetail.Condition = null;
            this.extendableRichContainerBaseDetail.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerBaseDetail.Extendable = true;
            this.extendableRichContainerBaseDetail.Extended = true;
            this.extendableRichContainerBaseDetail.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainerBaseDetail.MainControl = this.addNewComponentControl1;
            this.extendableRichContainerBaseDetail.Name = "extendableRichContainerBaseDetail";
            this.extendableRichContainerBaseDetail.Size = new System.Drawing.Size(295, 46);
            this.extendableRichContainerBaseDetail.TabIndex = 0;
            this.extendableRichContainerBaseDetail.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
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
            this.extendableRichContainerGeneral.Location = new System.Drawing.Point(3, 55);
            this.extendableRichContainerGeneral.MainControl = this.GeneralInformationControl;
            this.extendableRichContainerGeneral.Name = "extendableRichContainerGeneral";
            this.extendableRichContainerGeneral.Size = new System.Drawing.Size(1165, 516);
            this.extendableRichContainerGeneral.TabIndex = 1;
            this.extendableRichContainerGeneral.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // GeneralInformationControl
            // 
            this.GeneralInformationControl.AutoSize = true;
            this.GeneralInformationControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.GeneralInformationControl.DateAsOf = new System.DateTime(2013, 5, 12, 20, 20, 21, 138);
            this.GeneralInformationControl.Description = "";
            this.GeneralInformationControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.GeneralInformationControl.InstallationDate = new System.DateTime(2013, 5, 12, 20, 20, 21, 146);
            this.GeneralInformationControl.LLPMark = false;
            this.GeneralInformationControl.Location = new System.Drawing.Point(3, 43);
            this.GeneralInformationControl.ManufactureDate = new System.DateTime(2013, 5, 12, 20, 20, 21, 121);
            this.GeneralInformationControl.MPDItem = "";
            this.GeneralInformationControl.Name = "GeneralInformationControl";
            this.GeneralInformationControl.PartNumber = "";
            this.GeneralInformationControl.Position = "";
            this.GeneralInformationControl.SerialNumber = "";
            this.GeneralInformationControl.Size = new System.Drawing.Size(1159, 470);
            this.GeneralInformationControl.TabIndex = 3;
            this.GeneralInformationControl.LLPMarkChecked += new System.EventHandler(this.GeneralInformationControlLLPMarkChecked);
            this.GeneralInformationControl.ComponentTypeChanged += new Auxiliary.Events.ValueChangedEventHandler(GeneralDataAndPerformanceControlComponentTypeChanged);
            this.GeneralInformationControl.ManufactureDateChanged += new Auxiliary.Events.DateChangedEventHandler(GeneralInformationControlManufactureDateChanged);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerBaseDetail);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerGeneral);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPerformance);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(724, 277);
            this.flowLayoutPanelMain.TabIndex = 2;
            this.flowLayoutPanelMain.WrapContents = false;
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
            this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 577);
            this.extendableRichContainerPerformance.MainControl = this.CompliancePerformanceListControl;
            this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this.extendableRichContainerPerformance.Size = new System.Drawing.Size(1212, 96);
            this.extendableRichContainerPerformance.TabIndex = 2;
            this.extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // CompliancePerformanceListControl
            // 
            this.CompliancePerformanceListControl.AutoSize = true;
            this.CompliancePerformanceListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CompliancePerformanceListControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CompliancePerformanceListControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompliancePerformanceListControl.Location = new System.Drawing.Point(3, 43);
            this.CompliancePerformanceListControl.MinimumSize = new System.Drawing.Size(1206, 50);
            this.CompliancePerformanceListControl.Name = "CompliancePerformanceListControl";
            this.CompliancePerformanceListControl.Size = new System.Drawing.Size(1206, 50);
            this.CompliancePerformanceListControl.TabIndex = 3;
            // 
            // addNewComponentControl1
            // 
            this.addNewComponentControl1.AutoSize = true;
            this.addNewComponentControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.addNewComponentControl1.Location = new System.Drawing.Point(3, 43);
            this.addNewComponentControl1.Name = "addNewComponentControl1";
            this.addNewComponentControl1.Size = new System.Drawing.Size(289, 0);
            this.addNewComponentControl1.TabIndex = 3;
            this.addNewComponentControl1.CheckedChanged +=	AddNewComponentControl1OnCheckedChanged;
            // 
            // DetailAddingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildClickable = true;
            this.Name = "ComponentAddingScreen";
            this.OperatorClickable = true;
            this.ShowAircraftStatusPanel = false;
            this.ShowTopPanelContainer = false;
            this.Size = new System.Drawing.Size(724, 383);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

	    #endregion

        private ReferenceControls.ExtendableRichContainer extendableRichContainerBaseDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerGeneral;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
        private ComponentAddingGeneralInformationControl GeneralInformationControl;
        private ComponentCompliancePerformanceListControl CompliancePerformanceListControl;
        private AddNewComponentControl addNewComponentControl1;
    }
}
