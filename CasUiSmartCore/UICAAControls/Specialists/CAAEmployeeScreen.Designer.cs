using System.Collections.Generic;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PersonnelControls.EmployeeCompliance;
using CAS.UI.UIControls.PersonnelControls.EmployeeControls;
using CAS.UI.UIControls.SupplierControls;

namespace CAS.UI.UICAAControls.Specialists
{
    partial class CAAEmployeeScreen
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

            //_directiveGeneralInformation.EffDateChanget -= FlightDateRouteControl1FlightDateChanget;

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
			this.extendableRichContainer2 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.employeeSummary = new CAS.UI.UIControls.PersonnelControls.EmployeeSummary();
			this.extendableRichContainerGeneral = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this._directiveGeneralInformation = new CAAEmployeeGeneralInformationControl();
			this.extendableRichContainerDocuments = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.DocumentsControl = new CAS.UI.UIControls.PersonnelControls.EmployeeDocumentsControl();
			this.extendableRichContainerLicense = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.employeeLicenceControl = new CAS.UI.UIControls.PersonnelControls.EmployeeControls.EmployeeLicenceControl();
			this.extendableRichContainerMedical = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerLicenseRecord = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerTrainingRecord = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerTraining = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerProcessing = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.employeeTrainingListControl1 = new CAAEmployeeTraining();
			this.extendableRichContainerRecords = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.employeeFlightControl = new CAS.UI.UIControls.PersonnelControls.EmployeeFlightControl();
			this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.employeeWorkPackageControl = new CAS.UI.UIControls.PersonnelControls.EmployeeWorkPackageControl();
			this.maintenanceDirectiveComplianceControl1 = new CAS.UI.UIControls.MaintananceProgram.MaintenanceDirectiveComplianceControl();
			this.medicalCompliance = new MedicalCompliance();
			this.trainingCompliance = new TrainingCompliance();
			this.employeeMedicalControl1 = new CAS.UI.UIControls.PersonnelControls.EmployeeControls.EmployeeMedicalControl();
			this.headerControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5);
			this.headerControl.ShowPrintButton = true;
			this.headerControl.ShowSaveButton = true;
			this.headerControl.ShowSaveButton2 = true;
			this.headerControl.Size = new System.Drawing.Size(1406, 58);
			this.headerControl.ShowForecastButton = true;
			this.headerControl.CustomMenu = new List<string>()
			{
				"None",
				"1 Month",
				"3 Month",
				"6 Month",
				"1 Year",
				"2 Year",
				"3 Year",
				"4 Year",
				"5 Year",
	            
			};
			this.headerControl.ForecastContextMenuClick += new System.EventHandler(this.ForecastMenuClick);
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
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(1410, 520);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoScroll = true;
			this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainer2);
			this.flowLayoutPanelMain.Controls.Add(this.employeeSummary);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerGeneral);
			this.flowLayoutPanelMain.Controls.Add(this._directiveGeneralInformation);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerDocuments);
			this.flowLayoutPanelMain.Controls.Add(this.DocumentsControl);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerLicense);
			this.flowLayoutPanelMain.Controls.Add(this.employeeLicenceControl);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerMedical);
			this.flowLayoutPanelMain.Controls.Add(this.employeeMedicalControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerTraining);
			this.flowLayoutPanelMain.Controls.Add(this.employeeTrainingListControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerProcessing);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerRecords);
			this.flowLayoutPanelMain.Controls.Add(this.employeeFlightControl);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainer1);
			this.flowLayoutPanelMain.Controls.Add(this.employeeWorkPackageControl);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerLicenseRecord);
			this.flowLayoutPanelMain.Controls.Add(this.medicalCompliance);
			//this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerTrainingRecord);
			this.flowLayoutPanelMain.Controls.Add(this.trainingCompliance);
			this.flowLayoutPanelMain.Controls.Add(this.maintenanceDirectiveComplianceControl1);
			this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1410, 520);
			this.flowLayoutPanelMain.TabIndex = 0;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// extendableRichContainer2
			// 
			this.extendableRichContainer2.AfterCaptionControl = null;
			this.extendableRichContainer2.AfterCaptionControl2 = null;
			this.extendableRichContainer2.AfterCaptionControl3 = null;
			this.extendableRichContainer2.AutoSize = true;
			this.extendableRichContainer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainer2.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer2.Caption = "Summary";
			this.extendableRichContainer2.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer2.Condition = null;
			this.extendableRichContainer2.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer2.Extendable = true;
			this.extendableRichContainer2.Extended = true;
			this.extendableRichContainer2.Location = new System.Drawing.Point(4, 4);
			this.extendableRichContainer2.MainControl = null;
			this.extendableRichContainer2.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer2.Name = "extendableRichContainer2";
			this.extendableRichContainer2.Size = new System.Drawing.Size(192, 40);
			this.extendableRichContainer2.TabIndex = 20;
			this.extendableRichContainer2.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer2.Extending += new System.EventHandler(this.extendableRichContainer2_Load);
			// 
			// employeeSummary
			// 
			this.employeeSummary.Location = new System.Drawing.Point(3, 51);
			this.employeeSummary.Name = "employeeSummary";
			this.employeeSummary.Size = new System.Drawing.Size(1010, 499);
			this.employeeSummary.TabIndex = 21;
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
			this.extendableRichContainerGeneral.Location = new System.Drawing.Point(4, 557);
			this.extendableRichContainerGeneral.MainControl = null;
			this.extendableRichContainerGeneral.Margin = new System.Windows.Forms.Padding(4);
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
			this._directiveGeneralInformation.Entity = null;
			this._directiveGeneralInformation.Location = new System.Drawing.Point(3, 604);
			this._directiveGeneralInformation.Name = "_directiveGeneralInformation";
			this._directiveGeneralInformation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this._directiveGeneralInformation.Size = new System.Drawing.Size(984, 525);
			this._directiveGeneralInformation.TabIndex = 10;
			this._directiveGeneralInformation.Visible = false;
			// 
			// extendableRichContainerDocuments
			// 
			this.extendableRichContainerDocuments.AfterCaptionControl = null;
			this.extendableRichContainerDocuments.AfterCaptionControl2 = null;
			this.extendableRichContainerDocuments.AfterCaptionControl3 = null;
			this.extendableRichContainerDocuments.AutoSize = true;
			this.extendableRichContainerDocuments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerDocuments.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerDocuments.Caption = "Documents";
			this.extendableRichContainerDocuments.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerDocuments.Condition = null;
			this.extendableRichContainerDocuments.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerDocuments.Extendable = true;
			this.extendableRichContainerDocuments.Extended = true;
			this.extendableRichContainerDocuments.Location = new System.Drawing.Point(4, 1136);
			this.extendableRichContainerDocuments.MainControl = null;
			this.extendableRichContainerDocuments.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerDocuments.Name = "extendableRichContainerDocuments";
			this.extendableRichContainerDocuments.Size = new System.Drawing.Size(215, 40);
			this.extendableRichContainerDocuments.TabIndex = 11;
			this.extendableRichContainerDocuments.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerDocuments.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
			// 
			// DocumentsControl
			// 
			this.DocumentsControl.AutoSize = true;
			this.DocumentsControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.DocumentsControl.Displayer = null;
			this.DocumentsControl.DisplayerText = null;
			this.DocumentsControl.Entity = null;
			this.DocumentsControl.Location = new System.Drawing.Point(3, 1183);
			this.DocumentsControl.Name = "DocumentsControl";
			this.DocumentsControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.DocumentsControl.Size = new System.Drawing.Size(1123, 522);
			this.DocumentsControl.TabIndex = 12;
			// 
			// extendableRichContainerLicense
			// 
			this.extendableRichContainerLicense.AfterCaptionControl = null;
			this.extendableRichContainerLicense.AfterCaptionControl2 = null;
			this.extendableRichContainerLicense.AfterCaptionControl3 = null;
			this.extendableRichContainerLicense.AutoSize = true;
			this.extendableRichContainerLicense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerLicense.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerLicense.Caption = "License";
			this.extendableRichContainerLicense.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerLicense.Condition = null;
			this.extendableRichContainerLicense.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerLicense.Extendable = true;
			this.extendableRichContainerLicense.Extended = true;
			this.extendableRichContainerLicense.Location = new System.Drawing.Point(4, 1712);
			this.extendableRichContainerLicense.MainControl = null;
			this.extendableRichContainerLicense.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerLicense.Name = "extendableRichContainerLicense";
			this.extendableRichContainerLicense.Size = new System.Drawing.Size(162, 40);
			this.extendableRichContainerLicense.TabIndex = 11;
			this.extendableRichContainerLicense.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
	        this.extendableRichContainerLicense.Extending += ExtendableRichContainerLicense_Extending;
			// 
			// employeeLicenceControl
			// 
			this.employeeLicenceControl.Location = new System.Drawing.Point(3, 1759);
			this.employeeLicenceControl.Name = "employeeLicenceControl";
			this.employeeLicenceControl.Size = new System.Drawing.Size(1310, 900);
			this.employeeLicenceControl.TabIndex = 14;
			this.employeeLicenceControl.Visible = false;
			// 
			// extendableRichContainerMedical
			// 
			this.extendableRichContainerMedical.AfterCaptionControl = null;
			this.extendableRichContainerMedical.AfterCaptionControl2 = null;
			this.extendableRichContainerMedical.AfterCaptionControl3 = null;
			this.extendableRichContainerMedical.AutoSize = true;
			this.extendableRichContainerMedical.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerMedical.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerMedical.Caption = "Medical";
			this.extendableRichContainerMedical.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerMedical.Condition = null;
			this.extendableRichContainerMedical.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerMedical.Extendable = true;
			this.extendableRichContainerMedical.Extended = true;
			this.extendableRichContainerMedical.Location = new System.Drawing.Point(4, 2618);
			this.extendableRichContainerMedical.MainControl = null;
			this.extendableRichContainerMedical.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerMedical.Name = "extendableRichContainerMedical";
			this.extendableRichContainerMedical.Size = new System.Drawing.Size(163, 40);
			this.extendableRichContainerMedical.TabIndex = 11;
			this.extendableRichContainerMedical.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
	        this.extendableRichContainerMedical.Extending += ExtendableRichContainerMedical_Extending;
			// 
			// extendableRichContainerLicenseRecord
			// 
			this.extendableRichContainerLicenseRecord.AfterCaptionControl = null;
			this.extendableRichContainerLicenseRecord.AfterCaptionControl2 = null;
			this.extendableRichContainerLicenseRecord.AfterCaptionControl3 = null;
			this.extendableRichContainerLicenseRecord.AutoSize = true;
			this.extendableRichContainerLicenseRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerLicenseRecord.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerLicenseRecord.Caption = "Licence Records";
			this.extendableRichContainerLicenseRecord.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerLicenseRecord.Condition = null;
			this.extendableRichContainerLicenseRecord.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerLicenseRecord.Extendable = true;
			this.extendableRichContainerLicenseRecord.Extended = true;
			this.extendableRichContainerLicenseRecord.Location = new System.Drawing.Point(4, 2618);
			this.extendableRichContainerLicenseRecord.MainControl = null;
			this.extendableRichContainerLicenseRecord.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerLicenseRecord.Name = "extendableRichContainerMedical";
			this.extendableRichContainerLicenseRecord.Size = new System.Drawing.Size(163, 40);
			this.extendableRichContainerLicenseRecord.TabIndex = 11;
			this.extendableRichContainerLicenseRecord.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
	        this.extendableRichContainerLicenseRecord.Extending += ExtendableRichContainerLicenceRecords_Extending;
			// 
			// extendableRichContainerTrainingRecord
			// 
			this.extendableRichContainerTrainingRecord.AfterCaptionControl = null;
			this.extendableRichContainerTrainingRecord.AfterCaptionControl2 = null;
			this.extendableRichContainerTrainingRecord.AfterCaptionControl3 = null;
			this.extendableRichContainerTrainingRecord.AutoSize = true;
			this.extendableRichContainerTrainingRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerTrainingRecord.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerTrainingRecord.Caption = "Training Records";
			this.extendableRichContainerTrainingRecord.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerTrainingRecord.Condition = null;
			this.extendableRichContainerTrainingRecord.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerTrainingRecord.Extendable = true;
			this.extendableRichContainerTrainingRecord.Extended = true;
			this.extendableRichContainerTrainingRecord.Location = new System.Drawing.Point(4, 2618);
			this.extendableRichContainerTrainingRecord.MainControl = null;
			this.extendableRichContainerTrainingRecord.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerTrainingRecord.Name = "extendableRichContainerMedical";
			this.extendableRichContainerTrainingRecord.Size = new System.Drawing.Size(163, 40);
			this.extendableRichContainerTrainingRecord.TabIndex = 11;
			this.extendableRichContainerTrainingRecord.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
	        this.extendableRichContainerTrainingRecord.Extending += ExtendableRichContainerTrainingRecords_Extending;
			// 
			// extendableRichContainerTraining
			// 
			this.extendableRichContainerTraining.AfterCaptionControl = null;
			this.extendableRichContainerTraining.AfterCaptionControl2 = null;
			this.extendableRichContainerTraining.AfterCaptionControl3 = null;
			this.extendableRichContainerTraining.AutoSize = true;
			this.extendableRichContainerTraining.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerTraining.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerTraining.Caption = "Training";
			this.extendableRichContainerTraining.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerTraining.Condition = null;
			this.extendableRichContainerTraining.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerTraining.Extendable = true;
			this.extendableRichContainerTraining.Extended = true;
			this.extendableRichContainerTraining.Location = new System.Drawing.Point(4, 2713);
			this.extendableRichContainerTraining.MainControl = null;
			this.extendableRichContainerTraining.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerTraining.Name = "extendableRichContainerTraining";
			this.extendableRichContainerTraining.Size = new System.Drawing.Size(169, 40);
			this.extendableRichContainerTraining.TabIndex = 23;
			this.extendableRichContainerTraining.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerTraining.Extending += new System.EventHandler(this.extendableRichContainerTraining_Extending);

            // 
			// extendableRichContainerProcessing
			// 
			this.extendableRichContainerProcessing.AfterCaptionControl = null;
			this.extendableRichContainerProcessing.AfterCaptionControl2 = null;
			this.extendableRichContainerProcessing.AfterCaptionControl3 = null;
			this.extendableRichContainerProcessing.AutoSize = true;
			this.extendableRichContainerProcessing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerProcessing.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerProcessing.Caption = "Inventory";
			this.extendableRichContainerProcessing.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerProcessing.Condition = null;
			this.extendableRichContainerProcessing.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerProcessing.Extendable = true;
			this.extendableRichContainerProcessing.Extended = true;
			this.extendableRichContainerProcessing.Location = new System.Drawing.Point(4, 2713);
			this.extendableRichContainerProcessing.MainControl = null;
			this.extendableRichContainerProcessing.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerProcessing.Name = "extendableRichContainerProcessing";
			this.extendableRichContainerProcessing.Size = new System.Drawing.Size(169, 40);
			this.extendableRichContainerProcessing.TabIndex = 23;
			this.extendableRichContainerProcessing.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerProcessing.Extending += new System.EventHandler(this.extendableRichContainerProcessing_Extending);
			// 
			// employeeTrainingListControl1
			// 
			this.employeeTrainingListControl1.AutoSize = true;
			this.employeeTrainingListControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.employeeTrainingListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.employeeTrainingListControl1.Location = new System.Drawing.Point(3, 2760);
			this.employeeTrainingListControl1.MinimumSize = new System.Drawing.Size(1300, 50);
			this.employeeTrainingListControl1.Name = "employeeTrainingListControl1";
			this.employeeTrainingListControl1.Size = new System.Drawing.Size(1206, 50);
			this.employeeTrainingListControl1.TabIndex = 24;
			this.employeeTrainingListControl1.Visible = false;
			// 
			// extendableRichContainerRecords
			// 
			this.extendableRichContainerRecords.AfterCaptionControl = null;
			this.extendableRichContainerRecords.AfterCaptionControl2 = null;
			this.extendableRichContainerRecords.AfterCaptionControl3 = null;
			this.extendableRichContainerRecords.AutoSize = true;
			this.extendableRichContainerRecords.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerRecords.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerRecords.Caption = "Flight Records";
			this.extendableRichContainerRecords.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerRecords.Condition = null;
			this.extendableRichContainerRecords.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerRecords.Extendable = true;
			this.extendableRichContainerRecords.Extended = true;
			this.extendableRichContainerRecords.Location = new System.Drawing.Point(4, 3164);
			this.extendableRichContainerRecords.MainControl = null;
			this.extendableRichContainerRecords.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainerRecords.Name = "extendableRichContainerRecords";
			this.extendableRichContainerRecords.Size = new System.Drawing.Size(256, 40);
			this.extendableRichContainerRecords.TabIndex = 15;
			this.extendableRichContainerRecords.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerRecords.Extending += new System.EventHandler(this.extendableRichContainerRecords_Extending);
			// 
			// employeeFlightControl
			// 
			this.employeeFlightControl.Location = new System.Drawing.Point(3, 3211);
			this.employeeFlightControl.Name = "employeeFlightControl";
			this.employeeFlightControl.Size = new System.Drawing.Size(1237, 583);
			this.employeeFlightControl.TabIndex = 16;
			this.employeeFlightControl.Visible = false;
			// 
			// extendableRichContainer1
			// 
			this.extendableRichContainer1.AfterCaptionControl = null;
			this.extendableRichContainer1.AfterCaptionControl2 = null;
			this.extendableRichContainer1.AfterCaptionControl3 = null;
			this.extendableRichContainer1.AutoSize = true;
			this.extendableRichContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer1.Caption = "Maintenance Records";
			this.extendableRichContainer1.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer1.Condition = null;
			this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer1.Extendable = true;
			this.extendableRichContainer1.Extended = true;
			this.extendableRichContainer1.Location = new System.Drawing.Point(4, 3801);
			this.extendableRichContainer1.MainControl = null;
			this.extendableRichContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer1.Name = "extendableRichContainer1";
			this.extendableRichContainer1.Size = new System.Drawing.Size(357, 40);
			this.extendableRichContainer1.TabIndex = 17;
			this.extendableRichContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer1.Extending += new System.EventHandler(this.extendableRichContainer1_Load);
			// 
			// employeeWorkPackageControl
			// 
			this.employeeWorkPackageControl.Location = new System.Drawing.Point(3, 3848);
			this.employeeWorkPackageControl.Name = "employeeWorkPackageControl";
			this.employeeWorkPackageControl.Size = new System.Drawing.Size(1237, 553);
			this.employeeWorkPackageControl.TabIndex = 18;
			this.employeeWorkPackageControl.Visible = false;
			// 
			// maintenanceDirectiveComplianceControl1
			// 
			this.maintenanceDirectiveComplianceControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.maintenanceDirectiveComplianceControl1.Displayer = null;
			this.maintenanceDirectiveComplianceControl1.DisplayerText = null;
			this.maintenanceDirectiveComplianceControl1.Entity = null;
			this.maintenanceDirectiveComplianceControl1.Location = new System.Drawing.Point(4, 4408);
			this.maintenanceDirectiveComplianceControl1.Margin = new System.Windows.Forms.Padding(4);
			this.maintenanceDirectiveComplianceControl1.Name = "maintenanceDirectiveComplianceControl1";
			this.maintenanceDirectiveComplianceControl1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.maintenanceDirectiveComplianceControl1.ShowContent = true;
			this.maintenanceDirectiveComplianceControl1.Size = new System.Drawing.Size(851, 350);
			this.maintenanceDirectiveComplianceControl1.TabIndex = 13;
			// 
			// medicalCompliance
			// 
			this.medicalCompliance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.medicalCompliance.Displayer = null;
			this.medicalCompliance.DisplayerText = null;
			this.medicalCompliance.Entity = null;
			this.medicalCompliance.Location = new System.Drawing.Point(4, 4408);
			this.medicalCompliance.Margin = new System.Windows.Forms.Padding(4);
			this.medicalCompliance.Name = "maintenanceDirectiveComplianceControl1";
			this.medicalCompliance.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.medicalCompliance.ShowContent = true;
			this.medicalCompliance.ShowContainer = false;
			this.medicalCompliance.Size = new System.Drawing.Size(851, 350);
			this.medicalCompliance.TabIndex = 13;
			this.medicalCompliance.Visible = false;
			// 
			// trainingCompliance
			// 
			this.trainingCompliance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.trainingCompliance.Displayer = null;
			this.trainingCompliance.DisplayerText = null;
			this.trainingCompliance.Entity = null;
			this.trainingCompliance.Location = new System.Drawing.Point(4, 4408);
			this.trainingCompliance.Margin = new System.Windows.Forms.Padding(4);
			this.trainingCompliance.Name = "maintenanceDirectiveComplianceControl1";
			this.trainingCompliance.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.trainingCompliance.ShowContent = true;
			this.trainingCompliance.ShowContainer = false;
			this.trainingCompliance.Size = new System.Drawing.Size(851, 350);
			this.trainingCompliance.TabIndex = 13;
			this.trainingCompliance.Visible = false;
			// 
			// employeeMedicalControl1
			// 
			this.employeeMedicalControl1.Location = new System.Drawing.Point(3, 2665);
			this.employeeMedicalControl1.Name = "employeeMedicalControl1";
			this.employeeMedicalControl1.Size = new System.Drawing.Size(870, 135);
			this.employeeMedicalControl1.TabIndex = 25;
			this.employeeMedicalControl1.Visible = false;
			// 
			// EmployeeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "EmployeeScreen";
			this.OperatorClickable = true;
			this.ShowTopPanelContainer = false;
			this.Size = new System.Drawing.Size(1410, 673);
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
        //private ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        //private MaintenanceDirectiveSummary _directiveSummary;
        private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerGeneral;
        public CAAEmployeeGeneralInformationControl _directiveGeneralInformation;
        private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerDocuments;
        public EmployeeDocumentsControl DocumentsControl;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerLicense;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerMedical;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerLicenseRecord;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerTrainingRecord;
        private MaintenanceDirectiveComplianceControl maintenanceDirectiveComplianceControl1;
        private MedicalCompliance medicalCompliance;
        private TrainingCompliance trainingCompliance;
		private EmployeeLicenceControl employeeLicenceControl;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerRecords;
		private EmployeeFlightControl employeeFlightControl;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer1;
		private EmployeeWorkPackageControl employeeWorkPackageControl;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer2;
		private EmployeeSummary employeeSummary;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerTraining;
		private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerProcessing;
		private CAAEmployeeTraining employeeTrainingListControl1;
		private EmployeeMedicalControl employeeMedicalControl1;
    }
}
