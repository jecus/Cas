﻿using CAS.UI.UICAAControls.Airacraft;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UIControls.HangarControls;
using CAS.UI.UIControls.ReferenceControls;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UICAAControls
{
	partial class OperatorSymmaryCAADemoScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorSymmaryCAADemoScreen));
			this.flowLayoutPanelReferences = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelExport = new System.Windows.Forms.FlowLayoutPanel();
			this._operatorInfoReference = new CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference();
            _operators = new AllOperatorsDemoCollectionControl();
            _aircrafts = new AllAircraftsDemoCollectionControl();
            this._documentsReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            
            //_occurenceReferenceReportContainer
            this._occurenceReferenceReportContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.OccurenceReReport = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            //_directiveContainer
            this._directiveContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.DirectiveLink = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            //_occurenceReferenceReportContainer
            this._concessionRequestContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.ConcessionRequestLink = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            //_smdContainer
            this._smsContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.EventsLink = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            //_authContainer
            this._authContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            
            this._settingSMS = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            
            this._settingProvider = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.LinkProvider = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            
            this.LinkTaskList = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEducation = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEducationSummary = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEducationManagment = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            
            
            this.LinkEducationProcess = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();


            this._settingPersonnel = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.LinkPersonnelTraining = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkAuditRiskManagment = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEvents = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEventsCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEventsClasses = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEventsTypes = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            
			this.LinkRigestry = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ExportMonthly = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel(true);
			this.Users = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Activity = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Aircraft = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Operator = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ExportATLB = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel(true);
			this.LinkRecords = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkNomenclatures = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkFindingLevels = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkRootCause = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkFligthsSchedule = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAircraftStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkFligthsPlanOPS = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkUnFligthsSchedule = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSchedulePeriod = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._personnelReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.LinkPersonnel = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkPersonnelLicense = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkGeneral = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkEvent = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSystem = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponents = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEngines = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDefects = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDefferedDefects = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkReportBuilder = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSpecializations = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkDepartments = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._qualityAssuranceReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkCheckList = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAuditCAA = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAuditOp = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAuditManagment = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAuditAll = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRoutineAudit = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkStandartManual = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkInitialOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPurchaseOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRequestOffers = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPurchaseStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDocumentPurchase = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkInvoice = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkQuotationOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSuppliers = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSupplierComponents = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.LinkCommercialWorkOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkCommercialRequests = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
            this._certificationReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this._oversightReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.flowLayoutPanelStores = new System.Windows.Forms.FlowLayoutPanel();
            this._adminContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._settingContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._settingQuality = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.headerControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanelReferences.SuspendLayout();
			this.flowLayoutPanelExport.SuspendLayout();
			this.flowLayoutPanelAircrafts.SuspendLayout();
			this.flowLayoutPanelStores.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5);
			this.headerControl.Size = new System.Drawing.Size(711, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
            this.panel1.Controls.Add(this.flowLayoutPanelExport);
			//this.panel1.Controls.Add(this.flowLayoutPanelStores);
			this.panel1.Controls.Add(this.flowLayoutPanelAircrafts);
			this.panel1.Controls.Add(this.flowLayoutPanelReferences);

            this.panel1.Location = new System.Drawing.Point(0, 62);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(715, 274);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanelReferences
			// 
            this.flowLayoutPanelReferences.Controls.Add(this._operatorInfoReference);
			this.flowLayoutPanelReferences.Controls.Add(this._documentsReferenceContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._personnelReferenceContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._qualityAssuranceReferenceContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._occurenceReferenceReportContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._directiveContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._concessionRequestContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._smsContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._authContainer);

            this.flowLayoutPanelReferences.AutoScroll = true;
			this.flowLayoutPanelReferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));

			this.flowLayoutPanelReferences.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelReferences.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelReferences.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelReferences.MinimumSize = new System.Drawing.Size(400, 10);
			this.flowLayoutPanelReferences.Name = "flowLayoutPanelReferences";
			this.flowLayoutPanelReferences.Size = new System.Drawing.Size(400, 274);
			this.flowLayoutPanelReferences.TabIndex = 0;
			this.flowLayoutPanelReferences.WrapContents = false;
			// 
			// flowLayoutPanelExport
			// 
			this.flowLayoutPanelExport.AutoScroll = true;
			this.flowLayoutPanelExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
#if DEMO
			this.flowLayoutPanelExport.Controls.Add(this._adminContainer);
#else
            this.flowLayoutPanelExport.Controls.Add(this._adminContainer);
			this.flowLayoutPanelExport.Controls.Add(this._settingContainer);
			this.flowLayoutPanelExport.Controls.Add(this._settingQuality);
			this.flowLayoutPanelExport.Controls.Add(this._settingSMS);
			this.flowLayoutPanelExport.Controls.Add(this._settingPersonnel);
			this.flowLayoutPanelExport.Controls.Add(this._settingProvider);
#endif
			this.flowLayoutPanelExport.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelExport.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelExport.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelExport.MinimumSize = new System.Drawing.Size(400, 10);
			this.flowLayoutPanelExport.Name = "flowLayoutPanelExport";
			this.flowLayoutPanelExport.Size = new System.Drawing.Size(400, 274);
			this.flowLayoutPanelExport.TabIndex = 0;
			this.flowLayoutPanelExport.WrapContents = false;
			// 
			// _operatorInfoReference
			// 
			this._operatorInfoReference.AfterCaptionControl = null;
			this._operatorInfoReference.AfterCaptionControl2 = null;
			this._operatorInfoReference.AfterCaptionControl3 = null;
			this._operatorInfoReference.AutoSize = true;
			this._operatorInfoReference.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._operatorInfoReference.BackColor = System.Drawing.Color.Transparent;
			this._operatorInfoReference.Caption = "General information";
			this._operatorInfoReference.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this._operatorInfoReference.Condition = null;
			this._operatorInfoReference.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._operatorInfoReference.Location = new System.Drawing.Point(5, 5);
			this._operatorInfoReference.MainControl = null;
			this._operatorInfoReference.Margin = new System.Windows.Forms.Padding(5);
			this._operatorInfoReference.Name = "_operatorInfoReference";
			this._operatorInfoReference.Size = new System.Drawing.Size(342, 220);
			this._operatorInfoReference.TabIndex = 0;
			this._operatorInfoReference.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("_operatorInfoReference.UpperLeftIcon")));

			// 
			// _adminContainer
			// 
			this._adminContainer.AutoSize = true;
			this._adminContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._adminContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._adminContainer.Caption = "Admin";
			this._adminContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._adminContainer.Extended = true;
			this._adminContainer.Location = new System.Drawing.Point(3, 232);
			this._adminContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._adminContainer.Name = "_adminContainer";
			this._adminContainer.ReferenceLink = this.Activity;
			this._adminContainer.ReferenceLink02 = this.Users;
			this._adminContainer.ReferenceLink03 = null;
			this._adminContainer.ReferenceLink04 = null;
			this._adminContainer.ReferenceLink05 = null;
			this._adminContainer.ReferenceLink06 = null;
			this._adminContainer.ReferenceLink07 = null;
			this._adminContainer.ReferenceLink08 = null;
			this._adminContainer.ReferenceLink09 = null;
			this._adminContainer.ReferenceLink10 = null;
			this._adminContainer.ReferenceLink11 = null;
			this._adminContainer.ReferenceLink12 = null;
			this._adminContainer.ReferenceLink13 = null;
			this._adminContainer.ReferenceLink14 = null;
			this._adminContainer.ReferenceLink15 = null;
			this._adminContainer.ReferenceLink16 = null;
			this._adminContainer.Size = new System.Drawing.Size(105, 42);
			this._adminContainer.TabIndex = 1;
			this._adminContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._adminContainer.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
			// 
			// _settingContainer
			// 
			this._settingContainer.AutoSize = true;
			this._settingContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._settingContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._settingContainer.Caption = "Setting (General)";
			this._settingContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._settingContainer.Extended = true;
			this._settingContainer.Location = new System.Drawing.Point(3, 232);
			this._settingContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._settingContainer.Name = "_settingContainer";
			this._settingContainer.ReferenceLink = this.Aircraft;
			this._settingContainer.ReferenceLink02 = this.Operator;
			this._settingContainer.ReferenceLink03 = null;
			this._settingContainer.ReferenceLink04 = null;
			this._settingContainer.ReferenceLink05 = null;
			this._settingContainer.ReferenceLink06 = null;
			this._settingContainer.ReferenceLink07 = null;
            this._settingContainer.ReferenceLink08 = null;
			this._settingContainer.ReferenceLink09 = null;
			this._settingContainer.ReferenceLink10 = null;
			this._settingContainer.ReferenceLink11 = null;
			this._settingContainer.ReferenceLink12 = null;
			this._settingContainer.ReferenceLink13 = null;
			this._settingContainer.ReferenceLink14 = null;
			this._settingContainer.ReferenceLink15 = null;
			this._settingContainer.ReferenceLink16 = null;
			this._settingContainer.Size = new System.Drawing.Size(105, 42);
			this._settingContainer.TabIndex = 1;
			this._settingContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._settingContainer.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;// 
			// _settingQuality
			// 
			this._settingQuality.AutoSize = true;
			this._settingQuality.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._settingQuality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._settingQuality.Caption = "Setting (Quality)";
			this._settingQuality.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._settingQuality.Extended = true;
			this._settingQuality.Location = new System.Drawing.Point(3, 232);
			this._settingQuality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._settingQuality.Name = "_settingQuality";
			this._settingQuality.ReferenceLink = this.LinkStandartManual;
			this._settingQuality.ReferenceLink02 = this.LinkRoutineAudit;
			this._settingQuality.ReferenceLink03 = this.LinkAuditManagment;
			this._settingQuality.ReferenceLink04 = this.LinkFindingLevels;
			this._settingQuality.ReferenceLink05 = this.LinkRootCause;
			this._settingQuality.ReferenceLink06 = null;
			this._settingQuality.ReferenceLink07 = null;
            this._settingQuality.ReferenceLink08 = null;
			this._settingQuality.ReferenceLink09 = null;
			this._settingQuality.ReferenceLink10 = null;
			this._settingQuality.ReferenceLink11 = null;
			this._settingQuality.ReferenceLink12 = null;
			this._settingQuality.ReferenceLink13 = null;
			this._settingQuality.ReferenceLink14 = null;
			this._settingQuality.ReferenceLink15 = null;
			this._settingQuality.ReferenceLink16 = null;
			this._settingQuality.Size = new System.Drawing.Size(105, 42);
			this._settingQuality.TabIndex = 1;
			this._settingQuality.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._settingQuality.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
            
			// 
			// ExportMonthly
			// 
			this.ExportMonthly.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportMonthly.Displayer = null;
			this.ExportMonthly.DisplayerText = null;
			this.ExportMonthly.Entity = null;
			this.ExportMonthly.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ExportMonthly.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportMonthly.ImageBackColor = System.Drawing.Color.Transparent;
			this.ExportMonthly.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ExportMonthly.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportMonthly.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.ExportMonthly.Location = new System.Drawing.Point(10, 0);
			this.ExportMonthly.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.ExportMonthly.Name = "ExportMonthly";
			this.ExportMonthly.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.ExportMonthly.Size = new System.Drawing.Size(188, 20);
			this.ExportMonthly.Status = AvControls.Statuses.Satisfactory;
			this.ExportMonthly.TabIndex = 2;
			this.ExportMonthly.Text = "Export Monthly";
			this.ExportMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExportMonthly.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// Activity
			// 
			this.Activity.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Activity.Displayer = null;
			this.Activity.DisplayerText = null;
			this.Activity.Entity = null;
			this.Activity.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Activity.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Activity.ImageBackColor = System.Drawing.Color.Transparent;
			this.Activity.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Activity.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Activity.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Activity.Location = new System.Drawing.Point(10, 0);
			this.Activity.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Activity.Name = "Activity";
			this.Activity.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Activity.Size = new System.Drawing.Size(188, 20);
			this.Activity.Status = AvControls.Statuses.Satisfactory;
			this.Activity.TabIndex = 2;
			this.Activity.Text = "Activity";
			this.Activity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Activity.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Activity.DisplayerRequested += Activity_DisplayerRequested;
			// 
			// Purchase
			// 
			this.Aircraft.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Aircraft.Displayer = null;
			this.Aircraft.DisplayerText = null;
			this.Aircraft.Entity = null;
			this.Aircraft.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Aircraft.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Aircraft.ImageBackColor = System.Drawing.Color.Transparent;
			this.Aircraft.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Aircraft.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Aircraft.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Aircraft.Location = new System.Drawing.Point(10, 0);
			this.Aircraft.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Aircraft.Name = "Aircraft";
			this.Aircraft.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Aircraft.Size = new System.Drawing.Size(188, 20);
			this.Aircraft.Status = AvControls.Statuses.Satisfactory;
			this.Aircraft.TabIndex = 2;
			this.Aircraft.Text = "Add Aircraft";
			this.Aircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Aircraft.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Aircraft.DisplayerRequested += Aircraft_Click;
            // 
			// mail
			// 
			this.Operator.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Operator.Displayer = null;
			this.Operator.DisplayerText = null;
			this.Operator.Entity = null;
			this.Operator.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Operator.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Operator.ImageBackColor = System.Drawing.Color.Transparent;
			this.Operator.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Operator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Operator.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Operator.Location = new System.Drawing.Point(10, 0);
			this.Operator.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Operator.Name = "Operator";
			this.Operator.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Operator.Size = new System.Drawing.Size(188, 20);
			this.Operator.Status = AvControls.Statuses.Satisfactory;
			this.Operator.TabIndex = 2;
			this.Operator.Text = "Add Operator";
			this.Operator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Operator.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Operator.DisplayerRequested += Operator_Click;
			// 
			// Users
			// 
			this.Users.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Users.Displayer = null;
			this.Users.DisplayerText = null;
			this.Users.Entity = null;
			this.Users.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Users.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Users.ImageBackColor = System.Drawing.Color.Transparent;
			this.Users.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Users.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Users.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Users.Location = new System.Drawing.Point(10, 0);
			this.Users.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Users.Name = "Users";
			this.Users.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Users.Size = new System.Drawing.Size(188, 20);
			this.Users.Status = AvControls.Statuses.Satisfactory;
			this.Users.TabIndex = 2;
			this.Users.Text = "Users";
			this.Users.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Users.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Users.DisplayerRequested += Users_Click;
			// 
			// ExportMonthly
			// 
			this.ExportATLB.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportATLB.Displayer = null;
			this.ExportATLB.DisplayerText = null;
			this.ExportATLB.Entity = null;
			this.ExportATLB.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ExportATLB.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportATLB.ImageBackColor = System.Drawing.Color.Transparent;
			this.ExportATLB.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ExportATLB.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ExportATLB.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.ExportATLB.Location = new System.Drawing.Point(10, 0);
			this.ExportATLB.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.ExportATLB.Name = "ExportATLB";
			this.ExportATLB.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.ExportATLB.Size = new System.Drawing.Size(188, 20);
			this.ExportATLB.Status = AvControls.Statuses.Satisfactory;
			this.ExportATLB.TabIndex = 2;
			this.ExportATLB.Text = "Export ATLB-Works";
			this.ExportATLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExportATLB.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));

            // 
			// _documentsReferenceContainer
			// 
			this._documentsReferenceContainer.AutoSize = true;
			this._documentsReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._documentsReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._documentsReferenceContainer.Caption = "Documents";
			this._documentsReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._documentsReferenceContainer.Extended = false;
			this._documentsReferenceContainer.Location = new System.Drawing.Point(3, 232);
			this._documentsReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._documentsReferenceContainer.Name = "_documentsReferenceContainer";
			this._documentsReferenceContainer.ReferenceLink = this.LinkRigestry;
			//this._documentsReferenceContainer.ReferenceLink02 = this.LinkRecords;
			this._documentsReferenceContainer.ReferenceLink03 = null;
			this._documentsReferenceContainer.ReferenceLink04 = null;
			this._documentsReferenceContainer.ReferenceLink05 = null;
			this._documentsReferenceContainer.ReferenceLink06 = null;
			this._documentsReferenceContainer.ReferenceLink07 = null;
			this._documentsReferenceContainer.ReferenceLink08 = null;
			this._documentsReferenceContainer.ReferenceLink09 = null;
			this._documentsReferenceContainer.ReferenceLink10 = null;
			this._documentsReferenceContainer.ReferenceLink11 = null;
			this._documentsReferenceContainer.ReferenceLink12 = null;
			this._documentsReferenceContainer.ReferenceLink13 = null;
			this._documentsReferenceContainer.ReferenceLink14 = null;
			this._documentsReferenceContainer.ReferenceLink15 = null;
			this._documentsReferenceContainer.ReferenceLink16 = null;
			this._documentsReferenceContainer.Size = new System.Drawing.Size(105, 42);
			this._documentsReferenceContainer.TabIndex = 1;
			this._documentsReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._documentsReferenceContainer.Visible = true;
			// 
			// LinkRigestry
			// 
			this.LinkRigestry.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRigestry.Displayer = null;
			this.LinkRigestry.DisplayerText = null;
			this.LinkRigestry.Entity = null;
			this.LinkRigestry.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRigestry.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRigestry.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRigestry.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRigestry.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRigestry.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRigestry.Location = new System.Drawing.Point(10, 0);
			this.LinkRigestry.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRigestry.Name = "LinkRigestry";
			this.LinkRigestry.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRigestry.Size = new System.Drawing.Size(188, 20);
			this.LinkRigestry.Status = AvControls.Statuses.Satisfactory;
			this.LinkRigestry.TabIndex = 2;
			this.LinkRigestry.Text = "Registry";
			this.LinkRigestry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRigestry.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkRigestry.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LabelDocumentsDisplayerRequested);
			// 
			// LinkRecords
			// 
			this.LinkRecords.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRecords.Displayer = null;
			this.LinkRecords.DisplayerText = null;
			this.LinkRecords.Entity = null;
			this.LinkRecords.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRecords.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRecords.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRecords.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRecords.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRecords.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRecords.Location = new System.Drawing.Point(10, 0);
			this.LinkRecords.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRecords.Name = "LinkRecords";
			this.LinkRecords.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRecords.Size = new System.Drawing.Size(188, 20);
			this.LinkRecords.Status = AvControls.Statuses.Satisfactory;
			this.LinkRecords.TabIndex = 3;
			this.LinkRecords.Text = "Correspondence";
			this.LinkRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRecords.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkNomenclatures
			// 
			this.LinkNomenclatures.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNomenclatures.Displayer = null;
			this.LinkNomenclatures.DisplayerText = null;
			this.LinkNomenclatures.Entity = null;
			this.LinkNomenclatures.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkNomenclatures.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNomenclatures.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkNomenclatures.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkNomenclatures.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNomenclatures.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkNomenclatures.Location = new System.Drawing.Point(10, 0);
			this.LinkNomenclatures.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkNomenclatures.Name = "LinkNomenclatures";
			this.LinkNomenclatures.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkNomenclatures.Size = new System.Drawing.Size(188, 20);
			this.LinkNomenclatures.Status = AvControls.Statuses.Satisfactory;
			this.LinkNomenclatures.TabIndex = 4;
			this.LinkNomenclatures.Text = "Nomenclature";
			this.LinkNomenclatures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkNomenclatures.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkNomenclatures.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkNomenclaturesDisplayerRequested);
			// 
			// LinkFindingLevels
			// 
			this.LinkFindingLevels.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFindingLevels.Displayer = null;
			this.LinkFindingLevels.DisplayerText = null;
			this.LinkFindingLevels.Entity = null;
			this.LinkFindingLevels.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkFindingLevels.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFindingLevels.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkFindingLevels.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkFindingLevels.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFindingLevels.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkFindingLevels.Location = new System.Drawing.Point(10, 0);
			this.LinkFindingLevels.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkFindingLevels.Name = "LinkFindingLevels";
			this.LinkFindingLevels.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkFindingLevels.Size = new System.Drawing.Size(188, 20);
			this.LinkFindingLevels.Status = AvControls.Statuses.Satisfactory;
			this.LinkFindingLevels.TabIndex = 4;
			this.LinkFindingLevels.Text = "Finding Level";
			this.LinkFindingLevels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkFindingLevels.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkFindingLevels.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkFindingLevelsDisplayerRequested);
			// 
			// LinkRootCause
			// 
			this.LinkRootCause.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRootCause.Displayer = null;
			this.LinkRootCause.DisplayerText = null;
			this.LinkRootCause.Entity = null;
			this.LinkRootCause.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRootCause.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRootCause.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRootCause.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRootCause.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRootCause.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRootCause.Location = new System.Drawing.Point(10, 0);
			this.LinkRootCause.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRootCause.Name = "LinkRootCause";
			this.LinkRootCause.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRootCause.Size = new System.Drawing.Size(188, 20);
			this.LinkRootCause.Status = AvControls.Statuses.Satisfactory;
			this.LinkRootCause.TabIndex = 4;
			this.LinkRootCause.Text = "Root Cause";
			this.LinkRootCause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRootCause.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkRootCause.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRootCauseDisplayerRequested);

			// 
			// LinkAircraftStatus
			// 
			this.LinkAircraftStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftStatus.Displayer = null;
			this.LinkAircraftStatus.DisplayerText = null;
			this.LinkAircraftStatus.Entity = null;
			this.LinkAircraftStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAircraftStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAircraftStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAircraftStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAircraftStatus.Location = new System.Drawing.Point(10, 0);
			this.LinkAircraftStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAircraftStatus.Name = "LinkAircraftStatus";
			this.LinkAircraftStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAircraftStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkAircraftStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkAircraftStatus.TabIndex = 6;
			this.LinkAircraftStatus.Text = "Aircraft Status";
			this.LinkAircraftStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAircraftStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkFligthsPlanOPS
			// 
			this.LinkFligthsPlanOPS.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsPlanOPS.Displayer = null;
			this.LinkFligthsPlanOPS.DisplayerText = null;
			this.LinkFligthsPlanOPS.Entity = null;
			this.LinkFligthsPlanOPS.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkFligthsPlanOPS.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsPlanOPS.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkFligthsPlanOPS.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkFligthsPlanOPS.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsPlanOPS.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkFligthsPlanOPS.Location = new System.Drawing.Point(10, 0);
			this.LinkFligthsPlanOPS.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkFligthsPlanOPS.Name = "LinkFligthsPlanOPS";
			this.LinkFligthsPlanOPS.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkFligthsPlanOPS.Size = new System.Drawing.Size(188, 20);
			this.LinkFligthsPlanOPS.Status = AvControls.Statuses.Satisfactory;
			this.LinkFligthsPlanOPS.TabIndex = 6;
			this.LinkFligthsPlanOPS.Text = "Plan OPS";
			this.LinkFligthsPlanOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkFligthsPlanOPS.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkFligthsSchedule
			// 
			this.LinkFligthsSchedule.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsSchedule.Displayer = null;
			this.LinkFligthsSchedule.DisplayerText = null;
			this.LinkFligthsSchedule.Entity = null;
			this.LinkFligthsSchedule.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkFligthsSchedule.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsSchedule.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkFligthsSchedule.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkFligthsSchedule.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkFligthsSchedule.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkFligthsSchedule.Location = new System.Drawing.Point(10, 0);
			this.LinkFligthsSchedule.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkFligthsSchedule.Name = "LinkFligthsSchedule";
			this.LinkFligthsSchedule.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkFligthsSchedule.Size = new System.Drawing.Size(188, 20);
			this.LinkFligthsSchedule.Status = AvControls.Statuses.Satisfactory;
			this.LinkFligthsSchedule.TabIndex = 6;
			this.LinkFligthsSchedule.Text = "Flights Schedule";
			this.LinkFligthsSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkFligthsSchedule.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkUnFligthsSchedule
			// 
			this.LinkUnFligthsSchedule.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkUnFligthsSchedule.Displayer = null;
			this.LinkUnFligthsSchedule.DisplayerText = null;
			this.LinkUnFligthsSchedule.Entity = null;
			this.LinkUnFligthsSchedule.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkUnFligthsSchedule.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkUnFligthsSchedule.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkUnFligthsSchedule.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkUnFligthsSchedule.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkUnFligthsSchedule.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkUnFligthsSchedule.Location = new System.Drawing.Point(10, 0);
			this.LinkUnFligthsSchedule.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkUnFligthsSchedule.Name = "LinkFligthsSchedule";
			this.LinkUnFligthsSchedule.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkUnFligthsSchedule.Size = new System.Drawing.Size(188, 20);
			this.LinkUnFligthsSchedule.Status = AvControls.Statuses.Satisfactory;
			this.LinkUnFligthsSchedule.TabIndex = 6;
			this.LinkUnFligthsSchedule.Text = "Flights UnSchedule";
			this.LinkUnFligthsSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkUnFligthsSchedule.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkSchedulePeriod
			// 
			this.LinkSchedulePeriod.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSchedulePeriod.Displayer = null;
			this.LinkSchedulePeriod.DisplayerText = null;
			this.LinkSchedulePeriod.Entity = null;
			this.LinkSchedulePeriod.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkSchedulePeriod.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSchedulePeriod.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSchedulePeriod.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSchedulePeriod.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSchedulePeriod.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSchedulePeriod.Location = new System.Drawing.Point(10, 0);
			this.LinkSchedulePeriod.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSchedulePeriod.Name = "LinkFligthsSchedule";
			this.LinkSchedulePeriod.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSchedulePeriod.Size = new System.Drawing.Size(188, 20);
			this.LinkSchedulePeriod.Status = AvControls.Statuses.Satisfactory;
			this.LinkSchedulePeriod.TabIndex = 6;
			this.LinkSchedulePeriod.Text = "Schedule Period";
			this.LinkSchedulePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSchedulePeriod.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// _personnelReferenceContainer
			// 
			this._personnelReferenceContainer.AutoSize = true;
			this._personnelReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._personnelReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._personnelReferenceContainer.Caption = "Personnel";
			this._personnelReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._personnelReferenceContainer.Extended = false;
			this._personnelReferenceContainer.Location = new System.Drawing.Point(3, 278);
			this._personnelReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._personnelReferenceContainer.Name = "_personnelReferenceContainer";
			this._personnelReferenceContainer.ReferenceLink = this.LinkPersonnel;
			this._personnelReferenceContainer.ReferenceLink02 = this.LinkPersonnelLicense;
			this._personnelReferenceContainer.ReferenceLink03 = this.LinkEducationProcess;
			this._personnelReferenceContainer.ReferenceLink04 = null;
			this._personnelReferenceContainer.ReferenceLink05 = null;
			this._personnelReferenceContainer.ReferenceLink06 = null;
			this._personnelReferenceContainer.ReferenceLink06 = null;
			this._personnelReferenceContainer.ReferenceLink07 = null;
			this._personnelReferenceContainer.ReferenceLink08 = null;
			this._personnelReferenceContainer.ReferenceLink09 = null;
			this._personnelReferenceContainer.ReferenceLink10 = null;
			this._personnelReferenceContainer.ReferenceLink11 = null;
			this._personnelReferenceContainer.ReferenceLink12 = null;
			this._personnelReferenceContainer.ReferenceLink13 = null;
			this._personnelReferenceContainer.ReferenceLink14 = null;
			this._personnelReferenceContainer.ReferenceLink15 = null;
			this._personnelReferenceContainer.ReferenceLink16 = null;
			this._personnelReferenceContainer.Size = new System.Drawing.Size(166, 42);
			this._personnelReferenceContainer.TabIndex = 7;
			this._personnelReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;





			// 
			// LinkGeneral
			// 
			this.LinkGeneral.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGeneral.Displayer = null;
			this.LinkGeneral.DisplayerText = null;
			this.LinkGeneral.Entity = null;
			this.LinkGeneral.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkGeneral.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGeneral.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkGeneral.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkGeneral.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGeneral.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkGeneral.Location = new System.Drawing.Point(10, 0);
			this.LinkGeneral.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkGeneral.Name = "LinkGeneral";
			this.LinkGeneral.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkGeneral.Size = new System.Drawing.Size(220, 20);
			this.LinkGeneral.Status = AvControls.Statuses.Satisfactory;
			this.LinkGeneral.TabIndex = 6;
			this.LinkGeneral.Text = "General";
			this.LinkGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkGeneral.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkEvent
			// 
			this.LinkEvent.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvent.Displayer = null;
			this.LinkEvent.DisplayerText = null;
			this.LinkEvent.Entity = null;
			this.LinkEvent.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkEvent.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvent.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEvent.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEvent.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvent.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEvent.Location = new System.Drawing.Point(10, 0);
			this.LinkEvent.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEvent.Name = "LinkEvent";
			this.LinkEvent.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEvent.Size = new System.Drawing.Size(280, 20);
			this.LinkEvent.Status = AvControls.Statuses.Satisfactory;
			this.LinkEvent.TabIndex = 6;
			this.LinkEvent.Text = "Event";
			this.LinkEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEvent.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkSystem
			// 
			this.LinkSystem.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSystem.Displayer = null;
			this.LinkSystem.DisplayerText = null;
			this.LinkSystem.Entity = null;
			this.LinkSystem.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkSystem.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSystem.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSystem.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSystem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSystem.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSystem.Location = new System.Drawing.Point(10, 0);
			this.LinkSystem.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSystem.Name = "LinkSystem";
			this.LinkSystem.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSystem.Size = new System.Drawing.Size(220, 20);
			this.LinkSystem.Status = AvControls.Statuses.Satisfactory;
			this.LinkSystem.TabIndex = 6;
			this.LinkSystem.Text = "System reliability";
			this.LinkSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSystem.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkComponents
			// 
			this.LinkComponents.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponents.Displayer = null;
			this.LinkComponents.DisplayerText = null;
			this.LinkComponents.Entity = null;
			this.LinkComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkComponents.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponents.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponents.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponents.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponents.Location = new System.Drawing.Point(10, 0);
			this.LinkComponents.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponents.Name = "LinkComponents";
			this.LinkComponents.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponents.Size = new System.Drawing.Size(220, 20);
			this.LinkComponents.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponents.TabIndex = 6;
			this.LinkComponents.Text = "Components reliability";
			this.LinkComponents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponents.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkEngines
			// 
			this.LinkEngines.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEngines.Displayer = null;
			this.LinkEngines.DisplayerText = null;
			this.LinkEngines.Entity = null;
			this.LinkEngines.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkEngines.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEngines.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEngines.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEngines.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEngines.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEngines.Location = new System.Drawing.Point(10, 0);
			this.LinkEngines.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEngines.Name = "LinkEngines";
			this.LinkEngines.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEngines.Size = new System.Drawing.Size(220, 20);
			this.LinkEngines.Status = AvControls.Statuses.Satisfactory;
			this.LinkEngines.TabIndex = 6;
			this.LinkEngines.Text = "Engines and APU";
			this.LinkEngines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEngines.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			//
			// LinkDefects
			// 
			this.LinkDefects.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefects.Displayer = null;
			this.LinkDefects.DisplayerText = null;
			this.LinkDefects.Entity = null;
			this.LinkDefects.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkDefects.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefects.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDefects.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDefects.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefects.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDefects.Location = new System.Drawing.Point(10, 0);
			this.LinkDefects.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDefects.Name = "LinkEngines";
			this.LinkDefects.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDefects.Size = new System.Drawing.Size(220, 20);
			this.LinkDefects.Status = AvControls.Statuses.Satisfactory;
			this.LinkDefects.TabIndex = 6;
			this.LinkDefects.Text = "Defects";
			this.LinkDefects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDefects.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            //
			// LinkDefferedDefects
			// 
			this.LinkDefferedDefects.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefferedDefects.Displayer = null;
			this.LinkDefferedDefects.DisplayerText = null;
			this.LinkDefferedDefects.Entity = null;
			this.LinkDefferedDefects.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkDefferedDefects.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefferedDefects.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDefferedDefects.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDefferedDefects.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDefferedDefects.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDefferedDefects.Location = new System.Drawing.Point(10, 0);
			this.LinkDefferedDefects.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDefferedDefects.Name = "LinkDefferedDefects";
			this.LinkDefferedDefects.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDefferedDefects.Size = new System.Drawing.Size(220, 20);
			this.LinkDefferedDefects.Status = AvControls.Statuses.Satisfactory;
			this.LinkDefferedDefects.TabIndex = 6;
			this.LinkDefferedDefects.Text = "Deferred defects";
			this.LinkDefferedDefects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDefferedDefects.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            //
			// LinkReportBuilder
			// 
			this.LinkReportBuilder.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkReportBuilder.Displayer = null;
			this.LinkReportBuilder.DisplayerText = null;
			this.LinkReportBuilder.Entity = null;
			this.LinkReportBuilder.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkReportBuilder.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkReportBuilder.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkReportBuilder.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkReportBuilder.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkReportBuilder.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkReportBuilder.Location = new System.Drawing.Point(10, 0);
			this.LinkReportBuilder.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkReportBuilder.Name = "LinkDefferedDefects";
			this.LinkReportBuilder.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkReportBuilder.Size = new System.Drawing.Size(220, 20);
			this.LinkReportBuilder.Status = AvControls.Statuses.Satisfactory;
			this.LinkReportBuilder.TabIndex = 6;
			this.LinkReportBuilder.Text = "Reliability report builder";
			this.LinkReportBuilder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkReportBuilder.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));

			// 
			// LinkPersonnel
			// 
			this.LinkPersonnel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnel.Displayer = null;
			this.LinkPersonnel.DisplayerText = null;
			this.LinkPersonnel.Entity = null;
			this.LinkPersonnel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPersonnel.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnel.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPersonnel.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPersonnel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnel.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPersonnel.Location = new System.Drawing.Point(10, 0);
			this.LinkPersonnel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPersonnel.Name = "LinkPersonnel";
			this.LinkPersonnel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPersonnel.Size = new System.Drawing.Size(188, 20);
			this.LinkPersonnel.Status = AvControls.Statuses.Satisfactory;
			this.LinkPersonnel.TabIndex = 8;
			this.LinkPersonnel.Text = "Personnel";
			this.LinkPersonnel.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
			this.LinkPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPersonnel.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkPersonnel.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPersonnelDisplayerRequested);
             // 
			// LinkPersonnelLicense
			// 
			this.LinkPersonnelLicense.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnelLicense.Displayer = null;
			this.LinkPersonnelLicense.DisplayerText = null;
			this.LinkPersonnelLicense.Entity = null;
			this.LinkPersonnelLicense.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPersonnelLicense.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnelLicense.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPersonnelLicense.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPersonnelLicense.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPersonnelLicense.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPersonnelLicense.Location = new System.Drawing.Point(10, 0);
			this.LinkPersonnelLicense.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPersonnelLicense.Name = "LinkPersonnel";
			this.LinkPersonnelLicense.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPersonnelLicense.Size = new System.Drawing.Size(188, 20);
			this.LinkPersonnelLicense.Status = AvControls.Statuses.Satisfactory;
			this.LinkPersonnelLicense.TabIndex = 8;
			this.LinkPersonnelLicense.Text = "Personnel License";
			this.LinkPersonnelLicense.Visible = GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin ||
			                                    GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.OperatorAdmin;
			this.LinkPersonnelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPersonnelLicense.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkPersonnelLicense.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPersonnelLicenseDisplayerRequested);
			// 
			// LinkSpecializations
			// 
			this.LinkSpecializations.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSpecializations.Displayer = null;
			this.LinkSpecializations.DisplayerText = null;
			this.LinkSpecializations.Entity = null;
			this.LinkSpecializations.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkSpecializations.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSpecializations.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSpecializations.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSpecializations.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSpecializations.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSpecializations.Location = new System.Drawing.Point(208, 0);
			this.LinkSpecializations.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSpecializations.Name = "LinkSpecializations";
			this.LinkSpecializations.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSpecializations.Size = new System.Drawing.Size(188, 20);
			this.LinkSpecializations.Status = AvControls.Statuses.Satisfactory;
			this.LinkSpecializations.TabIndex = 9;
			this.LinkSpecializations.Text = "Occupations";
			this.LinkSpecializations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSpecializations.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkSpecializations.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSpecializationsDisplayerRequested);
			// 
			// LinkDepartments
			// 
			this.LinkDepartments.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDepartments.Displayer = null;
			this.LinkDepartments.DisplayerText = null;
			this.LinkDepartments.Entity = null;
			this.LinkDepartments.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkDepartments.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDepartments.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDepartments.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDepartments.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDepartments.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDepartments.Location = new System.Drawing.Point(1000, 0);
			this.LinkDepartments.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDepartments.Name = "LinkDepartments";
			this.LinkDepartments.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDepartments.Size = new System.Drawing.Size(188, 20);
			this.LinkDepartments.Status = AvControls.Statuses.Satisfactory;
			this.LinkDepartments.TabIndex = 14;
			this.LinkDepartments.Text = "Departments";
			this.LinkDepartments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDepartments.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkDepartments.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDepartmentsDisplayerRequested);
			// 
			// _qualityAssuranceReferenceContainer
			// 
			this._qualityAssuranceReferenceContainer.AutoSize = true;
			this._qualityAssuranceReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._qualityAssuranceReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._qualityAssuranceReferenceContainer.Caption = "Quality Assurance";
			this._qualityAssuranceReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._qualityAssuranceReferenceContainer.Extended = false;
			this._qualityAssuranceReferenceContainer.Location = new System.Drawing.Point(3, 324);
			this._qualityAssuranceReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._qualityAssuranceReferenceContainer.Name = "_qualityAssuranceReferenceContainer";
			this._qualityAssuranceReferenceContainer.ReferenceLink = this.LinkCheckList;
			this._qualityAssuranceReferenceContainer.ReferenceLink02 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink03 = this.LinkAuditCAA;
			this._qualityAssuranceReferenceContainer.ReferenceLink04 = this.LinkAuditOp;
			this._qualityAssuranceReferenceContainer.ReferenceLink05 = this.LinkAuditAll;
			this._qualityAssuranceReferenceContainer.ReferenceLink06 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink07 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink08 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink09 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink10 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink11 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink12 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink13 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink14 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink15 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink16 = null;
			this._qualityAssuranceReferenceContainer.Size = new System.Drawing.Size(257, 42);
			this._qualityAssuranceReferenceContainer.TabIndex = 15;
			this._qualityAssuranceReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;

#if SCAT
			this._qualityAssuranceReferenceContainer.Visible = false;
#endif
			// 
			// LinkCheckList
			// 
			this.LinkCheckList.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCheckList.Displayer = null;
			this.LinkCheckList.DisplayerText = null;
			this.LinkCheckList.Entity = null;
			this.LinkCheckList.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkCheckList.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCheckList.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkCheckList.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkCheckList.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCheckList.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkCheckList.Location = new System.Drawing.Point(10, 0);
			this.LinkCheckList.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkCheckList.Name = "LinkCheckList";
			this.LinkCheckList.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkCheckList.Size = new System.Drawing.Size(188, 20);
			this.LinkCheckList.Status = AvControls.Statuses.Satisfactory;
			this.LinkCheckList.TabIndex = 16;
			this.LinkCheckList.Text = "Check List";
			this.LinkCheckList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkCheckList.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkCheckList.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkCheckListsDisplayerRequested);
            // 
			// LinkCheckList
			// 
			this.LinkAuditCAA.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAuditCAA.Displayer = null;
			this.LinkAuditCAA.DisplayerText = null;
			this.LinkAuditCAA.Entity = null;
			this.LinkAuditCAA.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAuditCAA.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAuditCAA.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAuditCAA.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAuditCAA.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAuditCAA.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAuditCAA.Location = new System.Drawing.Point(10, 0);
			this.LinkAuditCAA.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAuditCAA.Name = "LinkAuditCAA";
			this.LinkAuditCAA.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAuditCAA.Size = new System.Drawing.Size(188, 20);
			this.LinkAuditCAA.Status = AvControls.Statuses.Satisfactory;
			this.LinkAuditCAA.TabIndex = 16;
			this.LinkAuditCAA.Text = "Audit CAA";
			this.LinkAuditCAA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAuditCAA.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAuditCAA.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditDisplayerRequested);

			// 
			// LinkAuditOp
            // 
			this.LinkAuditOp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditOp.Displayer = null;
            this.LinkAuditOp.DisplayerText = null;
            this.LinkAuditOp.Entity = null;
            this.LinkAuditOp.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkAuditOp.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditOp.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkAuditOp.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkAuditOp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditOp.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkAuditOp.Location = new System.Drawing.Point(10, 0);
            this.LinkAuditOp.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkAuditOp.Name = "LinkAuditOp";
            this.LinkAuditOp.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkAuditOp.Size = new System.Drawing.Size(188, 20);
            this.LinkAuditOp.Status = AvControls.Statuses.Satisfactory;
            this.LinkAuditOp.TabIndex = 16;
            this.LinkAuditOp.Text = "Audit Operator";
            this.LinkAuditOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkAuditOp.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAuditOp.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditOpDisplayerRequested);
			// 
			// LinkAuditManagment
            // 
			this.LinkAuditManagment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditManagment.Displayer = null;
            this.LinkAuditManagment.DisplayerText = null;
            this.LinkAuditManagment.Entity = null;
            this.LinkAuditManagment.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkAuditManagment.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditManagment.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkAuditManagment.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkAuditManagment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditManagment.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkAuditManagment.Location = new System.Drawing.Point(10, 0);
            this.LinkAuditManagment.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkAuditManagment.Name = "LinkAuditOp";
            this.LinkAuditManagment.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkAuditManagment.Size = new System.Drawing.Size(188, 20);
            this.LinkAuditManagment.Status = AvControls.Statuses.Satisfactory;
            this.LinkAuditManagment.TabIndex = 16;
            this.LinkAuditManagment.Text = "Audit Managment";
            this.LinkAuditManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkAuditManagment.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAuditManagment.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditManagmentDisplayerRequested);
            // 
            // LinkAuditOp
            // 
            this.LinkAuditAll.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditAll.Displayer = null;
            this.LinkAuditAll.DisplayerText = null;
            this.LinkAuditAll.Entity = null;
            this.LinkAuditAll.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkAuditAll.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditAll.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkAuditAll.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkAuditAll.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditAll.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkAuditAll.Location = new System.Drawing.Point(10, 0);
            this.LinkAuditAll.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkAuditAll.Name = "LinkAuditOp";
            this.LinkAuditAll.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkAuditAll.Size = new System.Drawing.Size(188, 20);
            this.LinkAuditAll.Status = AvControls.Statuses.Satisfactory;
            this.LinkAuditAll.TabIndex = 16;
            this.LinkAuditAll.Text = "Audit All";
            this.LinkAuditAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkAuditAll.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAuditAll.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditAllDisplayerRequested);
			// 
			// LinkRoutineAudit
			// 
			this.LinkRoutineAudit.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRoutineAudit.Displayer = null;
			this.LinkRoutineAudit.DisplayerText = null;
			this.LinkRoutineAudit.Entity = null;
			this.LinkRoutineAudit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRoutineAudit.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRoutineAudit.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRoutineAudit.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRoutineAudit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRoutineAudit.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRoutineAudit.Location = new System.Drawing.Point(10, 0);
			this.LinkRoutineAudit.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRoutineAudit.Name = "LinkCheckList";
			this.LinkRoutineAudit.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRoutineAudit.Size = new System.Drawing.Size(188, 20);
			this.LinkRoutineAudit.Status = AvControls.Statuses.Satisfactory;
			this.LinkRoutineAudit.TabIndex = 16;
			this.LinkRoutineAudit.Text = "Routine Audit";
			this.LinkRoutineAudit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRoutineAudit.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkRoutineAudit.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRoutineAuditDisplayerRequested);
            // 
			// LinkStandartManual
			// 
			this.LinkStandartManual.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkStandartManual.Displayer = null;
			this.LinkStandartManual.DisplayerText = null;
			this.LinkStandartManual.Entity = null;
			this.LinkStandartManual.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkStandartManual.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkStandartManual.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkStandartManual.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkStandartManual.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkStandartManual.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkStandartManual.Location = new System.Drawing.Point(10, 0);
			this.LinkStandartManual.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkStandartManual.Name = "LinkStandartManual";
			this.LinkStandartManual.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkStandartManual.Size = new System.Drawing.Size(188, 20);
			this.LinkStandartManual.Status = AvControls.Statuses.Satisfactory;
			this.LinkStandartManual.TabIndex = 16;
			this.LinkStandartManual.Text = "Standart Manual";
			this.LinkStandartManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkStandartManual.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkStandartManual.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkStandartManualDisplayerRequested);
            // 
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoScroll = true;
			this.flowLayoutPanelAircrafts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelAircrafts.Controls.Add(this._aircrafts);
            this.flowLayoutPanelAircrafts.Controls.Add(this._operators);
            this.flowLayoutPanelAircrafts.Controls.Add(this._certificationReferenceContainer);
			this.flowLayoutPanelAircrafts.Controls.Add(this._oversightReferenceContainer);
            this.flowLayoutPanelAircrafts.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(400, 0);
			this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(400, 10);
			this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
			this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(400, 274);
			this.flowLayoutPanelAircrafts.TabIndex = 1;
			this.flowLayoutPanelAircrafts.WrapContents = false;
            // 
			// _certificationReferenceContainer
			// 
			this._certificationReferenceContainer.AutoSize = true;
			this._certificationReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._certificationReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._certificationReferenceContainer.Caption = "Certification";
			this._certificationReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._certificationReferenceContainer.Extended = false;
			this._certificationReferenceContainer.Location = new System.Drawing.Point(3, 174);
			this._certificationReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._certificationReferenceContainer.Name = "_certificationReferenceContainer";
            this._certificationReferenceContainer.ReferenceLink02 = null;
			this._certificationReferenceContainer.ReferenceLink03 = null;
			this._certificationReferenceContainer.ReferenceLink04 = null;
			this._certificationReferenceContainer.ReferenceLink05 = null;
			this._certificationReferenceContainer.ReferenceLink06 = null;
			this._certificationReferenceContainer.ReferenceLink07 = null;
			this._certificationReferenceContainer.ReferenceLink08 = null;
			this._certificationReferenceContainer.ReferenceLink09 = null;
			this._certificationReferenceContainer.ReferenceLink10 = null;
			this._certificationReferenceContainer.ReferenceLink11 = null;
			this._certificationReferenceContainer.ReferenceLink12 = null;
			this._certificationReferenceContainer.ReferenceLink13 = null;
			this._certificationReferenceContainer.ReferenceLink14 = null;
			this._certificationReferenceContainer.ReferenceLink15 = null;
			this._certificationReferenceContainer.ReferenceLink16 = null;
			this._certificationReferenceContainer.Size = new System.Drawing.Size(109, 42);
			this._certificationReferenceContainer.TabIndex = 26;
			this._certificationReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
			// _oversightReferenceContainer
			// 
			this._oversightReferenceContainer.AutoSize = true;
			this._oversightReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._oversightReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._oversightReferenceContainer.Caption = "Oversight";
			this._oversightReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._oversightReferenceContainer.Extended = false;
			this._oversightReferenceContainer.Location = new System.Drawing.Point(3, 220);
			this._oversightReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._oversightReferenceContainer.Name = "_oversightReferenceContainer";
			this._oversightReferenceContainer.ReferenceLink = null;
			this._oversightReferenceContainer.ReferenceLink02 = null;
			this._oversightReferenceContainer.ReferenceLink03 = null;
			this._oversightReferenceContainer.ReferenceLink04 = null;
			this._oversightReferenceContainer.ReferenceLink05 = null;
			this._oversightReferenceContainer.ReferenceLink06 = null;
			this._oversightReferenceContainer.ReferenceLink07 = null;
			this._oversightReferenceContainer.ReferenceLink08 = null;
			this._oversightReferenceContainer.ReferenceLink09 = null;
			this._oversightReferenceContainer.ReferenceLink10 = null;
			this._oversightReferenceContainer.ReferenceLink11 = null;
			this._oversightReferenceContainer.ReferenceLink12 = null;
			this._oversightReferenceContainer.ReferenceLink13 = null;
			this._oversightReferenceContainer.ReferenceLink14 = null;
			this._oversightReferenceContainer.ReferenceLink15 = null;
			this._oversightReferenceContainer.ReferenceLink16 = null;
			this._oversightReferenceContainer.Size = new System.Drawing.Size(118, 42);
			this._oversightReferenceContainer.TabIndex = 27;
			this._oversightReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // flowLayoutPanelStores
			// 
#if DEMO
			this.flowLayoutPanelStores.Controls.Add(this._purchaseReferenceContainer);
#else
#endif
			this.flowLayoutPanelStores.AutoScroll = true;
			this.flowLayoutPanelStores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));

			this.flowLayoutPanelStores.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelStores.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelStores.Location = new System.Drawing.Point(800, 0);
			this.flowLayoutPanelStores.MinimumSize = new System.Drawing.Size(400, 10);
			this.flowLayoutPanelStores.Name = "flowLayoutPanelStores";
			this.flowLayoutPanelStores.Size = new System.Drawing.Size(400, 274);
			this.flowLayoutPanelStores.TabIndex = 34;
			this.flowLayoutPanelStores.WrapContents = false;
            // 
			// LinkCommercialRequests
			// 
			this.LinkCommercialRequests.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialRequests.Displayer = null;
			this.LinkCommercialRequests.DisplayerText = null;
			this.LinkCommercialRequests.Entity = null;
			this.LinkCommercialRequests.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkCommercialRequests.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialRequests.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkCommercialRequests.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkCommercialRequests.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialRequests.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkCommercialRequests.Location = new System.Drawing.Point(10, 0);
			this.LinkCommercialRequests.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkCommercialRequests.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkCommercialRequests.Name = "LinkCommercialRequests";
			this.LinkCommercialRequests.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkCommercialRequests.Size = new System.Drawing.Size(250, 20);
			this.LinkCommercialRequests.Status = AvControls.Statuses.Satisfactory;
			this.LinkCommercialRequests.TabIndex = 36;
			this.LinkCommercialRequests.Text = "Requests";
			this.LinkCommercialRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkCommercialRequests.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkCommercialWorkOrders
			// 
			this.LinkCommercialWorkOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialWorkOrders.Displayer = null;
			this.LinkCommercialWorkOrders.DisplayerText = null;
			this.LinkCommercialWorkOrders.Entity = null;
			this.LinkCommercialWorkOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkCommercialWorkOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialWorkOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkCommercialWorkOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkCommercialWorkOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCommercialWorkOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkCommercialWorkOrders.Location = new System.Drawing.Point(10, 0);
			this.LinkCommercialWorkOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkCommercialWorkOrders.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkCommercialWorkOrders.Name = "LinkCommercialWorkOrders";
			this.LinkCommercialWorkOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkCommercialWorkOrders.Size = new System.Drawing.Size(250, 20);
			this.LinkCommercialWorkOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkCommercialWorkOrders.TabIndex = 37;
			this.LinkCommercialWorkOrders.Text = "Work Orders";
			this.LinkCommercialWorkOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkCommercialWorkOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
 
            // 
			// LinkOrders
			// 
			this.LinkOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOrders.Displayer = null;
			this.LinkOrders.DisplayerText = null;
			this.LinkOrders.Entity = null;
			this.LinkOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkOrders.Location = new System.Drawing.Point(10, 0);
			this.LinkOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkOrders.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkOrders.Name = "LinkOrders";
			this.LinkOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkOrders.Size = new System.Drawing.Size(250, 20);
			this.LinkOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkOrders.TabIndex = 52;
			this.LinkOrders.Text = "All Orders";
			this.LinkOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkInitialOrders
			// 
			this.LinkInitialOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInitialOrders.Displayer = null;
			this.LinkInitialOrders.DisplayerText = null;
			this.LinkInitialOrders.Entity = null;
			this.LinkInitialOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkInitialOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInitialOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkInitialOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkInitialOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInitialOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkInitialOrders.Location = new System.Drawing.Point(10, 0);
			this.LinkInitialOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkInitialOrders.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkInitialOrders.Name = "LinkInitialOrders";
			this.LinkInitialOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkInitialOrders.Size = new System.Drawing.Size(250, 20);
			this.LinkInitialOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkInitialOrders.TabIndex = 52;
			this.LinkInitialOrders.Text = "Initial Orders";
			this.LinkInitialOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkInitialOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkPurchaseOrders
			// 
			this.LinkPurchaseOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseOrders.Displayer = null;
			this.LinkPurchaseOrders.DisplayerText = null;
			this.LinkPurchaseOrders.Entity = null;
			this.LinkPurchaseOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPurchaseOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPurchaseOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPurchaseOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPurchaseOrders.Location = new System.Drawing.Point(270, 0);
			this.LinkPurchaseOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPurchaseOrders.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkPurchaseOrders.Name = "LinkPurchaseOrders";
			this.LinkPurchaseOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPurchaseOrders.Size = new System.Drawing.Size(250, 20);
			this.LinkPurchaseOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkPurchaseOrders.TabIndex = 53;
			this.LinkPurchaseOrders.Text = "Purchase Orders";
			this.LinkPurchaseOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPurchaseOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkRequestOffers
			// 
			this.LinkRequestOffers.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequestOffers.Displayer = null;
			this.LinkRequestOffers.DisplayerText = null;
			this.LinkRequestOffers.Entity = null;
			this.LinkRequestOffers.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRequestOffers.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequestOffers.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRequestOffers.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRequestOffers.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequestOffers.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRequestOffers.Location = new System.Drawing.Point(270, 0);
			this.LinkRequestOffers.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRequestOffers.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkRequestOffers.Name = "LinkRequestOffers";
			this.LinkRequestOffers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRequestOffers.Size = new System.Drawing.Size(250, 20);
			this.LinkRequestOffers.Status = AvControls.Statuses.Satisfactory;
			this.LinkRequestOffers.TabIndex = 53;
			this.LinkRequestOffers.Text = "Request Offers";
			this.LinkRequestOffers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRequestOffers.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkPurchaseStatus
			// 
			this.LinkPurchaseStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseStatus.Displayer = null;
			this.LinkPurchaseStatus.DisplayerText = null;
			this.LinkPurchaseStatus.Entity = null;
			this.LinkPurchaseStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPurchaseStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPurchaseStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPurchaseStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPurchaseStatus.Location = new System.Drawing.Point(270, 0);
			this.LinkPurchaseStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPurchaseStatus.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkPurchaseStatus.Name = "LinkPurchaseStatus";
			this.LinkPurchaseStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPurchaseStatus.Size = new System.Drawing.Size(250, 20);
			this.LinkPurchaseStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkPurchaseStatus.TabIndex = 53;
			this.LinkPurchaseStatus.Text = "Purchase Status";
			this.LinkPurchaseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPurchaseStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkQuotationOrders
			// 
			this.LinkQuotationOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQuotationOrders.Displayer = null;
			this.LinkQuotationOrders.DisplayerText = null;
			this.LinkQuotationOrders.Entity = null;
			this.LinkQuotationOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkQuotationOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQuotationOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkQuotationOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkQuotationOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQuotationOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkQuotationOrders.Location = new System.Drawing.Point(530, 0);
			this.LinkQuotationOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkQuotationOrders.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkQuotationOrders.Name = "LinkQuotationOrders";
			this.LinkQuotationOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkQuotationOrders.Size = new System.Drawing.Size(250, 20);
			this.LinkQuotationOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkQuotationOrders.TabIndex = 54;
			this.LinkQuotationOrders.Text = "Quotation Orders";
			this.LinkQuotationOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkQuotationOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204))); // 
			// LinkDocumentPurchase
			// 
			this.LinkDocumentPurchase.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDocumentPurchase.Displayer = null;
			this.LinkDocumentPurchase.DisplayerText = null;
			this.LinkDocumentPurchase.Entity = null;
			this.LinkDocumentPurchase.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkDocumentPurchase.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDocumentPurchase.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDocumentPurchase.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDocumentPurchase.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDocumentPurchase.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDocumentPurchase.Location = new System.Drawing.Point(10, 0);
			this.LinkDocumentPurchase.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDocumentPurchase.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkDocumentPurchase.Name = "LinkDocumentPurchase";
			this.LinkDocumentPurchase.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDocumentPurchase.Size = new System.Drawing.Size(250, 20);
			this.LinkDocumentPurchase.Status = AvControls.Statuses.Satisfactory;
			this.LinkDocumentPurchase.TabIndex = 52;
			this.LinkDocumentPurchase.Text = "Documents";
			this.LinkDocumentPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDocumentPurchase.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkInvoice
			// 
			this.LinkInvoice.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInvoice.Displayer = null;
			this.LinkInvoice.DisplayerText = null;
			this.LinkInvoice.Entity = null;
			this.LinkInvoice.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkInvoice.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInvoice.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkInvoice.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkInvoice.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInvoice.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkInvoice.Location = new System.Drawing.Point(10, 0);
			this.LinkInvoice.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkInvoice.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkInvoice.Name = "LinkInvoice";
			this.LinkInvoice.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkInvoice.Size = new System.Drawing.Size(250, 20);
			this.LinkInvoice.Status = AvControls.Statuses.Satisfactory;
			this.LinkInvoice.TabIndex = 52;
			this.LinkInvoice.Text = "Invoice";
			this.LinkInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkInvoice.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            // 
			// LinkSuppliers
			// 
			this.LinkSuppliers.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSuppliers.Displayer = null;
			this.LinkSuppliers.DisplayerText = null;
			this.LinkSuppliers.Entity = null;
			this.LinkSuppliers.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkSuppliers.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSuppliers.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSuppliers.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSuppliers.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSuppliers.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSuppliers.Location = new System.Drawing.Point(790, 0);
			this.LinkSuppliers.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSuppliers.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkSuppliers.Name = "LinkSuppliers";
			this.LinkSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSuppliers.Size = new System.Drawing.Size(250, 20);
			this.LinkSuppliers.Status = AvControls.Statuses.Satisfactory;
			this.LinkSuppliers.TabIndex = 55;
			this.LinkSuppliers.Text = "Suppliers";
			this.LinkSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSuppliers.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));

            // 
			// LinkSupplierComponents
			// 
			this.LinkSupplierComponents.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSupplierComponents.Displayer = null;
			this.LinkSupplierComponents.DisplayerText = null;
			this.LinkSupplierComponents.Entity = null;
			this.LinkSupplierComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkSupplierComponents.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSupplierComponents.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSupplierComponents.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSupplierComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSupplierComponents.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSupplierComponents.Location = new System.Drawing.Point(790, 0);
			this.LinkSupplierComponents.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSupplierComponents.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkSupplierComponents.Name = "LinkSuppliers";
			this.LinkSupplierComponents.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSupplierComponents.Size = new System.Drawing.Size(250, 20);
			this.LinkSupplierComponents.Status = AvControls.Statuses.Satisfactory;
			this.LinkSupplierComponents.TabIndex = 55;
			this.LinkSupplierComponents.Text = "Processing";
			this.LinkSupplierComponents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSupplierComponents.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// _operators
            // 
			this._operators.OperatorCollection = null;
            this._operators.AutoSize = true;
            this._operators.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._operators.Extended = true;
            this._operators.Location = new System.Drawing.Point(3, 2);
            this._operators.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._operators.MaximumSize = new System.Drawing.Size(400, 0);
            this._operators.Name = "_operators";
            this._operators.Size = new System.Drawing.Size(362, 168);
            this._operators.TabIndex = 25;
            // 
			// _operators
            // 
			this._aircrafts.AircraftCollection = null;
            this._aircrafts.AutoSize = true;
            this._aircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._aircrafts.Extended = true;
            this._aircrafts.Location = new System.Drawing.Point(3, 2);
            this._aircrafts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._aircrafts.MaximumSize = new System.Drawing.Size(400, 0);
            this._aircrafts.Name = "_operators";
            this._aircrafts.Size = new System.Drawing.Size(362, 168);
            this._aircrafts.TabIndex = 25;
            
            // 
			// _occurenceReferenceReportContainer
			// 
			this._occurenceReferenceReportContainer.AutoSize = true;
			this._occurenceReferenceReportContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._occurenceReferenceReportContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._occurenceReferenceReportContainer.Caption = "Occurrence Report";
			this._occurenceReferenceReportContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._occurenceReferenceReportContainer.Extended = false;
			this._occurenceReferenceReportContainer.Location = new System.Drawing.Point(3, 232);
			this._occurenceReferenceReportContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._occurenceReferenceReportContainer.Name = "_occurenceReferenceReportContainer";
			this._occurenceReferenceReportContainer.ReferenceLink = this.OccurenceReReport;
			this._documentsReferenceContainer.ReferenceLink02 = null;
			this._occurenceReferenceReportContainer.ReferenceLink03 = null;
			this._occurenceReferenceReportContainer.ReferenceLink04 = null;
			this._occurenceReferenceReportContainer.ReferenceLink05 = null;
			this._occurenceReferenceReportContainer.ReferenceLink06 = null;
			this._occurenceReferenceReportContainer.ReferenceLink07 = null;
			this._occurenceReferenceReportContainer.ReferenceLink08 = null;
			this._occurenceReferenceReportContainer.ReferenceLink09 = null;
			this._occurenceReferenceReportContainer.ReferenceLink10 = null;
			this._occurenceReferenceReportContainer.ReferenceLink11 = null;
			this._occurenceReferenceReportContainer.ReferenceLink12 = null;
			this._occurenceReferenceReportContainer.ReferenceLink13 = null;
			this._occurenceReferenceReportContainer.ReferenceLink14 = null;
			this._occurenceReferenceReportContainer.ReferenceLink15 = null;
			this._occurenceReferenceReportContainer.ReferenceLink16 = null;
			this._occurenceReferenceReportContainer.Size = new System.Drawing.Size(105, 42);
			this._occurenceReferenceReportContainer.TabIndex = 1;
			this._occurenceReferenceReportContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._occurenceReferenceReportContainer.Visible = true;
			
			// 
			// OccurenceReReport
			// 
			this.OccurenceReReport.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.OccurenceReReport.Displayer = null;
			this.OccurenceReReport.DisplayerText = null;
			this.OccurenceReReport.Entity = null;
			this.OccurenceReReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.OccurenceReReport.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.OccurenceReReport.ImageBackColor = System.Drawing.Color.Transparent;
			this.OccurenceReReport.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.OccurenceReReport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.OccurenceReReport.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.OccurenceReReport.Location = new System.Drawing.Point(10, 0);
			this.OccurenceReReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.OccurenceReReport.Name = "LinkCheckList";
			this.OccurenceReReport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.OccurenceReReport.Size = new System.Drawing.Size(188, 20);
			this.OccurenceReReport.Status = AvControls.Statuses.Satisfactory;
			this.OccurenceReReport.TabIndex = 16;
			this.OccurenceReReport.Text = "Occurrence Report";
			this.OccurenceReReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OccurenceReReport.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.OccurenceReReport.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkOccurenceReReportRequested);
			
			
			// 
			// _directiveContainer
			// 
			this._directiveContainer.AutoSize = true;
			this._directiveContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._directiveContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._directiveContainer.Caption = "Directives";
			this._directiveContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._directiveContainer.Extended = false;
			this._directiveContainer.Location = new System.Drawing.Point(3, 232);
			this._directiveContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._directiveContainer.Name = "_directiveContainer";
			this._directiveContainer.ReferenceLink = this.DirectiveLink;
			this._directiveContainer.ReferenceLink02 = null;
			this._directiveContainer.ReferenceLink03 = null;
			this._directiveContainer.ReferenceLink04 = null;
			this._directiveContainer.ReferenceLink05 = null;
			this._directiveContainer.ReferenceLink06 = null;
			this._directiveContainer.ReferenceLink07 = null;
			this._directiveContainer.ReferenceLink08 = null;
			this._directiveContainer.ReferenceLink09 = null;
			this._directiveContainer.ReferenceLink10 = null;
			this._directiveContainer.ReferenceLink11 = null;
			this._directiveContainer.ReferenceLink12 = null;
			this._directiveContainer.ReferenceLink13 = null;
			this._directiveContainer.ReferenceLink14 = null;
			this._directiveContainer.ReferenceLink15 = null;
			this._directiveContainer.ReferenceLink16 = null;
			this._directiveContainer.Size = new System.Drawing.Size(105, 42);
			this._directiveContainer.TabIndex = 1;
			this._directiveContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._directiveContainer.Visible = true;
			
			// 
			// _directiveContainer
			// 
			this.DirectiveLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.DirectiveLink.Displayer = null;
			this.DirectiveLink.DisplayerText = null;
			this.DirectiveLink.Entity = null;
			this.DirectiveLink.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.DirectiveLink.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.DirectiveLink.ImageBackColor = System.Drawing.Color.Transparent;
			this.DirectiveLink.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.DirectiveLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.DirectiveLink.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.DirectiveLink.Location = new System.Drawing.Point(10, 0);
			this.DirectiveLink.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.DirectiveLink.Name = "LinkCheckList";
			this.DirectiveLink.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.DirectiveLink.Size = new System.Drawing.Size(188, 20);
			this.DirectiveLink.Status = AvControls.Statuses.Satisfactory;
			this.DirectiveLink.TabIndex = 16;
			this.DirectiveLink.Text = "Directives";
			this.DirectiveLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.DirectiveLink.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.DirectiveLink.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDirectiveLinkRequested);
			
			
			// 
			// _concessionRequestContainer
			// 
			this._concessionRequestContainer.AutoSize = true;
			this._concessionRequestContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._concessionRequestContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._concessionRequestContainer.Caption = "Concession Request";
			this._concessionRequestContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._concessionRequestContainer.Extended = false;
			this._concessionRequestContainer.Location = new System.Drawing.Point(3, 232);
			this._concessionRequestContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._concessionRequestContainer.Name = "_concessionRequestContainer";
			this._concessionRequestContainer.ReferenceLink = this.ConcessionRequestLink;
			this._concessionRequestContainer.ReferenceLink02 = null;
			this._concessionRequestContainer.ReferenceLink03 = null;
			this._concessionRequestContainer.ReferenceLink04 = null;
			this._concessionRequestContainer.ReferenceLink05 = null;
			this._concessionRequestContainer.ReferenceLink06 = null;
			this._concessionRequestContainer.ReferenceLink07 = null;
			this._concessionRequestContainer.ReferenceLink08 = null;
			this._concessionRequestContainer.ReferenceLink09 = null;
			this._concessionRequestContainer.ReferenceLink10 = null;
			this._concessionRequestContainer.ReferenceLink11 = null;
			this._concessionRequestContainer.ReferenceLink12 = null;
			this._concessionRequestContainer.ReferenceLink13 = null;
			this._concessionRequestContainer.ReferenceLink14 = null;
			this._concessionRequestContainer.ReferenceLink15 = null;
			this._concessionRequestContainer.ReferenceLink16 = null;
			this._concessionRequestContainer.Size = new System.Drawing.Size(105, 42);
			this._concessionRequestContainer.TabIndex = 1;
			this._concessionRequestContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._concessionRequestContainer.Visible = true;
			
			// 
			// ConcessionRequestLink
			// 
			this.ConcessionRequestLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ConcessionRequestLink.Displayer = null;
			this.ConcessionRequestLink.DisplayerText = null;
			this.ConcessionRequestLink.Entity = null;
			this.ConcessionRequestLink.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ConcessionRequestLink.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ConcessionRequestLink.ImageBackColor = System.Drawing.Color.Transparent;
			this.ConcessionRequestLink.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ConcessionRequestLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ConcessionRequestLink.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.ConcessionRequestLink.Location = new System.Drawing.Point(10, 0);
			this.ConcessionRequestLink.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.ConcessionRequestLink.Name = "LinkCheckList";
			this.ConcessionRequestLink.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.ConcessionRequestLink.Size = new System.Drawing.Size(188, 20);
			this.ConcessionRequestLink.Status = AvControls.Statuses.Satisfactory;
			this.ConcessionRequestLink.TabIndex = 16;
			this.ConcessionRequestLink.Text = "Concession Request";
			this.ConcessionRequestLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ConcessionRequestLink.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.ConcessionRequestLink.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkConcessionRequestLinkRequested);
			
			
			// 
			// _smdContainer
			// 
			this._smsContainer.AutoSize = true;
			this._smsContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._smsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._smsContainer.Caption = "SMS";
			this._smsContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._smsContainer.Extended = false;
			this._smsContainer.Location = new System.Drawing.Point(3, 232);
			this._smsContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._smsContainer.Name = "_smdContainer";
			this._smsContainer.ReferenceLink = this.EventsLink;
			this._smsContainer.ReferenceLink02 = null;
			this._smsContainer.ReferenceLink03 = null;
			this._smsContainer.ReferenceLink04 = null;
			this._smsContainer.ReferenceLink05 = null;
			this._smsContainer.ReferenceLink06 = null;
			this._smsContainer.ReferenceLink07 = null;
			this._smsContainer.ReferenceLink08 = null;
			this._smsContainer.ReferenceLink09 = null;
			this._smsContainer.ReferenceLink10 = null;
			this._smsContainer.ReferenceLink11 = null;
			this._smsContainer.ReferenceLink12 = null;
			this._smsContainer.ReferenceLink13 = null;
			this._smsContainer.ReferenceLink14 = null;
			this._smsContainer.ReferenceLink15 = null;
			this._smsContainer.ReferenceLink16 = null;
			this._smsContainer.Size = new System.Drawing.Size(105, 42);
			this._smsContainer.TabIndex = 1;
			this._smsContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._smsContainer.Visible = true;
			
			// 
			// EventsLink
			// 
			this.EventsLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.EventsLink.Displayer = null;
			this.EventsLink.DisplayerText = null;
			this.EventsLink.Entity = null;
			this.EventsLink.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.EventsLink.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.EventsLink.ImageBackColor = System.Drawing.Color.Transparent;
			this.EventsLink.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EventsLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.EventsLink.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.EventsLink.Location = new System.Drawing.Point(10, 0);
			this.EventsLink.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.EventsLink.Name = "LinkCheckList";
			this.EventsLink.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.EventsLink.Size = new System.Drawing.Size(188, 20);
			this.EventsLink.Status = AvControls.Statuses.Satisfactory;
			this.EventsLink.TabIndex = 16;
			this.EventsLink.Text = "Events";
			this.EventsLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.EventsLink.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.EventsLink.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.EventsLinkRequested);
			
			// 
			// _authContainer
			// 
			this._authContainer.AutoSize = true;
			this._authContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._authContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._authContainer.Caption = "Authorization";
			this._authContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._authContainer.Extended = false;
			this._authContainer.Location = new System.Drawing.Point(3, 232);
			this._authContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._authContainer.Name = "_smdContainer";
			this._authContainer.ReferenceLink = null;
			this._authContainer.ReferenceLink04 = null;
			this._authContainer.ReferenceLink05 = null;
			this._authContainer.ReferenceLink06 = null;
			this._authContainer.ReferenceLink07 = null;
			this._authContainer.ReferenceLink08 = null;
			this._authContainer.ReferenceLink09 = null;
			this._authContainer.ReferenceLink10 = null;
			this._authContainer.ReferenceLink11 = null;
			this._authContainer.ReferenceLink12 = null;
			this._authContainer.ReferenceLink13 = null;
			this._authContainer.ReferenceLink14 = null;
			this._authContainer.ReferenceLink15 = null;
			this._authContainer.ReferenceLink16 = null;
			this._authContainer.Size = new System.Drawing.Size(105, 42);
			this._authContainer.TabIndex = 1;
			this._authContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._authContainer.Visible = true;
			
			            
            // _settingSMS
            // 
            this._settingSMS.AutoSize = true;
            this._settingSMS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._settingSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._settingSMS.Caption = "Setting (SMS)";
            this._settingSMS.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._settingSMS.Extended = true;
            this._settingSMS.Location = new System.Drawing.Point(3, 232);
            this._settingSMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._settingSMS.Name = "_settingSMS";
            this._settingSMS.ReferenceLink = LinkAuditRiskManagment;
            this._settingSMS.ReferenceLink02 = LinkEvents;
            this._settingSMS.ReferenceLink03 = LinkEventsCategories;
            this._settingSMS.ReferenceLink04 = LinkEventsClasses;
            this._settingSMS.ReferenceLink05 = LinkEventsTypes;
            this._settingSMS.ReferenceLink06 = null;
            this._settingSMS.ReferenceLink07 = null;
            this._settingSMS.ReferenceLink08 = null;
            this._settingSMS.ReferenceLink09 = null;
            this._settingSMS.ReferenceLink10 = null;
            this._settingSMS.ReferenceLink11 = null;
            this._settingSMS.ReferenceLink12 = null;
            this._settingSMS.ReferenceLink13 = null;
            this._settingSMS.ReferenceLink14 = null;
            this._settingSMS.ReferenceLink15 = null;
            this._settingSMS.ReferenceLink16 = null;
            this._settingSMS.Size = new System.Drawing.Size(105, 42);
            this._settingSMS.TabIndex = 1;
            this._settingSMS.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._settingSMS.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
            
            
            // 
            // LinkAuditRiskManagment
            // 
            this.LinkAuditRiskManagment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditRiskManagment.Displayer = null;
            this.LinkAuditRiskManagment.DisplayerText = null;
            this.LinkAuditRiskManagment.Entity = null;
            this.LinkAuditRiskManagment.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkAuditRiskManagment.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditRiskManagment.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkAuditRiskManagment.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkAuditRiskManagment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkAuditRiskManagment.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkAuditRiskManagment.Location = new System.Drawing.Point(10, 0);
            this.LinkAuditRiskManagment.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkAuditRiskManagment.Name = "LinkAuditRiskManagment";
            this.LinkAuditRiskManagment.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkAuditRiskManagment.Size = new System.Drawing.Size(188, 20);
            this.LinkAuditRiskManagment.Status = AvControls.Statuses.Satisfactory;
            this.LinkAuditRiskManagment.TabIndex = 16;
            this.LinkAuditRiskManagment.Text = "Audit Risk Management";
            this.LinkAuditRiskManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkAuditRiskManagment.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAuditRiskManagment.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditRiskManagmentRequested);
            
            // 
            // LinkEvents
            // 
            this.LinkEvents.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEvents.Displayer = null;
            this.LinkEvents.DisplayerText = null;
            this.LinkEvents.Entity = null;
            this.LinkEvents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEvents.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEvents.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEvents.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEvents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEvents.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEvents.Location = new System.Drawing.Point(10, 0);
            this.LinkEvents.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEvents.Name = "LinkEvents";
            this.LinkEvents.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEvents.Size = new System.Drawing.Size(188, 20);
            this.LinkEvents.Status = AvControls.Statuses.Satisfactory;
            this.LinkEvents.TabIndex = 16;
            this.LinkEvents.Text = "Events";
            this.LinkEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEvents.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEvents.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEventsRequested);
            
            // 
            // LinkEventsCategories
            // 
            this.LinkEventsCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsCategories.Displayer = null;
            this.LinkEventsCategories.DisplayerText = null;
            this.LinkEventsCategories.Entity = null;
            this.LinkEventsCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEventsCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsCategories.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEventsCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEventsCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEventsCategories.Location = new System.Drawing.Point(10, 0);
            this.LinkEventsCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEventsCategories.Name = "LinkEventsCategories";
            this.LinkEventsCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEventsCategories.Size = new System.Drawing.Size(188, 20);
            this.LinkEventsCategories.Status = AvControls.Statuses.Satisfactory;
            this.LinkEventsCategories.TabIndex = 16;
            this.LinkEventsCategories.Text = "Events Categories";
            this.LinkEventsCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEventsCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEventsCategories.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEventsCategoriesRequested);
            
            // 
            // LinkEventsClasses
            // 
            this.LinkEventsClasses.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsClasses.Displayer = null;
            this.LinkEventsClasses.DisplayerText = null;
            this.LinkEventsClasses.Entity = null;
            this.LinkEventsClasses.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEventsClasses.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsClasses.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEventsClasses.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEventsClasses.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsClasses.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEventsClasses.Location = new System.Drawing.Point(10, 0);
            this.LinkEventsClasses.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEventsClasses.Name = "LinkEventsClasses";
            this.LinkEventsClasses.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEventsClasses.Size = new System.Drawing.Size(188, 20);
            this.LinkEventsClasses.Status = AvControls.Statuses.Satisfactory;
            this.LinkEventsClasses.TabIndex = 16;
            this.LinkEventsClasses.Text = "Events Classes";
            this.LinkEventsClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEventsClasses.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEventsClasses.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEventsClassesRequested);
            
             // 
            // LinkEventsTypes
            // 
            this.LinkEventsTypes.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsTypes.Displayer = null;
            this.LinkEventsTypes.DisplayerText = null;
            this.LinkEventsTypes.Entity = null;
            this.LinkEventsTypes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEventsTypes.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsTypes.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEventsTypes.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEventsTypes.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEventsTypes.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEventsTypes.Location = new System.Drawing.Point(10, 0);
            this.LinkEventsTypes.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEventsTypes.Name = "LinkEventsTypes";
            this.LinkEventsTypes.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEventsTypes.Size = new System.Drawing.Size(188, 20);
            this.LinkEventsTypes.Status = AvControls.Statuses.Satisfactory;
            this.LinkEventsTypes.TabIndex = 16;
            this.LinkEventsTypes.Text = "Events Types";
            this.LinkEventsTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEventsTypes.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEventsTypes.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEventsTypesRequested);
            
            
            
            // _settingPersonnel
            // 
            this._settingPersonnel.AutoSize = true;
            this._settingPersonnel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._settingPersonnel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._settingPersonnel.Caption = "Setting (Personnel)";
            this._settingPersonnel.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._settingPersonnel.Extended = true;
            this._settingPersonnel.Location = new System.Drawing.Point(3, 232);
            this._settingPersonnel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._settingPersonnel.Name = "_settingPersonnel";
            this._settingPersonnel.ReferenceLink = this.LinkPersonnelTraining;
            this._settingPersonnel.ReferenceLink02 = this.LinkTaskList;
            this._settingPersonnel.ReferenceLink03 = this.LinkEducation;
            this._settingPersonnel.ReferenceLink04 = this.LinkEducationSummary;
            this._settingPersonnel.ReferenceLink05 = this.LinkEducationManagment;
            this._settingPersonnel.ReferenceLink06 = this.LinkSpecializations;
            this._settingPersonnel.ReferenceLink07 = this.LinkNomenclatures;
            this._settingPersonnel.ReferenceLink08 = this.LinkDepartments;
            this._settingPersonnel.ReferenceLink09 = null;
            this._settingPersonnel.ReferenceLink10 = null;
            this._settingPersonnel.ReferenceLink11 = null;
            this._settingPersonnel.ReferenceLink12 = null;
            this._settingPersonnel.ReferenceLink13 = null;
            this._settingPersonnel.ReferenceLink14 = null;
            this._settingPersonnel.ReferenceLink15 = null;
            this._settingPersonnel.ReferenceLink16 = null;
            this._settingPersonnel.Size = new System.Drawing.Size(105, 42);
            this._settingPersonnel.TabIndex = 1;
            this._settingPersonnel.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._settingPersonnel.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
            
             // 
            // LinkPersonnelTraining
            // 
            this.LinkPersonnelTraining.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkPersonnelTraining.Displayer = null;
            this.LinkPersonnelTraining.DisplayerText = null;
            this.LinkPersonnelTraining.Entity = null;
            this.LinkPersonnelTraining.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkPersonnelTraining.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkPersonnelTraining.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkPersonnelTraining.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkPersonnelTraining.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkPersonnelTraining.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkPersonnelTraining.Location = new System.Drawing.Point(10, 0);
            this.LinkPersonnelTraining.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkPersonnelTraining.Name = "LinkPersonnelTraining";
            this.LinkPersonnelTraining.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkPersonnelTraining.Size = new System.Drawing.Size(188, 20);
            this.LinkPersonnelTraining.Status = AvControls.Statuses.Satisfactory;
            this.LinkPersonnelTraining.TabIndex = 16;
            this.LinkPersonnelTraining.Text = "Personnel Training";
            this.LinkPersonnelTraining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkPersonnelTraining.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkPersonnelTraining.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPersonnelTrainingRequested);

            // 
            // LinkTaskList
            // 
            this.LinkTaskList.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkTaskList.Displayer = null;
            this.LinkTaskList.DisplayerText = null;
            this.LinkTaskList.Entity = null;
            this.LinkTaskList.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkTaskList.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkTaskList.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkTaskList.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkTaskList.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkTaskList.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkTaskList.Location = new System.Drawing.Point(10, 0);
            this.LinkTaskList.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkTaskList.Name = "LinkPersonnelTraining";
            this.LinkTaskList.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkTaskList.Size = new System.Drawing.Size(188, 20);
            this.LinkTaskList.Status = AvControls.Statuses.Satisfactory;
            this.LinkTaskList.TabIndex = 16;
            this.LinkTaskList.Text = "Task List";
            this.LinkTaskList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkTaskList.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkTaskList.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkTaskListsRequested);
            
            // 
            // LinkEducation
            // 
            this.LinkEducation.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducation.Displayer = null;
            this.LinkEducation.DisplayerText = null;
            this.LinkEducation.Entity = null;
            this.LinkEducation.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEducation.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducation.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEducation.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEducation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducation.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEducation.Location = new System.Drawing.Point(10, 0);
            this.LinkEducation.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEducation.Name = "LinkEducation";
            this.LinkEducation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEducation.Size = new System.Drawing.Size(188, 20);
            this.LinkEducation.Status = AvControls.Statuses.Satisfactory;
            this.LinkEducation.TabIndex = 16;
            this.LinkEducation.Text = "Education";
            this.LinkEducation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEducation.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEducation.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEducationRequested);
            
            // 
            // LinkEducationProcessManagement
            // 
            this.LinkEducationSummary.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationSummary.Displayer = null;
            this.LinkEducationSummary.DisplayerText = null;
            this.LinkEducationSummary.Entity = null;
            this.LinkEducationSummary.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEducationSummary.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationSummary.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEducationSummary.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEducationSummary.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationSummary.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEducationSummary.Location = new System.Drawing.Point(10, 0);
            this.LinkEducationSummary.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEducationSummary.Name = "LinkEducation";
            this.LinkEducationSummary.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEducationSummary.Size = new System.Drawing.Size(250, 20);
            this.LinkEducationSummary.Status = AvControls.Statuses.Satisfactory;
            this.LinkEducationSummary.TabIndex = 16;
            this.LinkEducationSummary.Text = "Education Summary Page";
            this.LinkEducationSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEducationSummary.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEducationSummary.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEducationSummaryRequested);
            // 
            // LinkEducationManagment
            // 
            this.LinkEducationManagment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationManagment.Displayer = null;
            this.LinkEducationManagment.DisplayerText = null;
            this.LinkEducationManagment.Entity = null;
            this.LinkEducationManagment.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEducationManagment.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationManagment.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEducationManagment.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEducationManagment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationManagment.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEducationManagment.Location = new System.Drawing.Point(10, 0);
            this.LinkEducationManagment.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEducationManagment.Name = "LinkEducationManagment";
            this.LinkEducationManagment.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEducationManagment.Size = new System.Drawing.Size(250, 20);
            this.LinkEducationManagment.Status = AvControls.Statuses.Satisfactory;
            this.LinkEducationManagment.TabIndex = 16;
            this.LinkEducationManagment.Text = "Education Process Management";
            this.LinkEducationManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEducationManagment.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEducationManagment.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEducationLinkEducationManagmentRequested);
            
            

            
            // _settingProvider
            // 
            this._settingProvider.AutoSize = true;
            this._settingProvider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._settingProvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._settingProvider.Caption = "Setting (Provider)";
            this._settingProvider.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._settingProvider.Extended = true;
            this._settingProvider.Location = new System.Drawing.Point(3, 232);
            this._settingProvider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._settingProvider.Name = "_settingPersonnel";
            this._settingProvider.ReferenceLink = this.LinkProvider;
            this._settingProvider.ReferenceLink02 = null;
            this._settingProvider.ReferenceLink03 = null;
            this._settingProvider.ReferenceLink04 = null;
            this._settingProvider.ReferenceLink05 = null;
            this._settingProvider.ReferenceLink06 = null;
            this._settingProvider.ReferenceLink07 = null;
            this._settingProvider.ReferenceLink08 = null;
            this._settingProvider.ReferenceLink09 = null;
            this._settingProvider.ReferenceLink10 = null;
            this._settingProvider.ReferenceLink11 = null;
            this._settingProvider.ReferenceLink12 = null;
            this._settingProvider.ReferenceLink13 = null;
            this._settingProvider.ReferenceLink14 = null;
            this._settingProvider.ReferenceLink15 = null;
            this._settingProvider.ReferenceLink16 = null;
            this._settingProvider.Size = new System.Drawing.Size(105, 42);
            this._settingProvider.TabIndex = 1;
            this._settingProvider.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._settingProvider.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UserType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
            
             // 
            // LinkProvider
            // 
            this.LinkProvider.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkProvider.Displayer = null;
            this.LinkProvider.DisplayerText = null;
            this.LinkProvider.Entity = null;
            this.LinkProvider.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkProvider.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkProvider.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkProvider.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkProvider.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkProvider.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkProvider.Location = new System.Drawing.Point(10, 0);
            this.LinkProvider.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkProvider.Name = "LinkPersonnelTraining";
            this.LinkProvider.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkProvider.Size = new System.Drawing.Size(188, 20);
            this.LinkProvider.Status = AvControls.Statuses.Satisfactory;
            this.LinkProvider.TabIndex = 16;
            this.LinkProvider.Text = "Provider";
            this.LinkProvider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkProvider.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkProvider.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkProviderRequested); 
            
            // 
            // LinkEducationProcess
            // 
            this.LinkEducationProcess.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationProcess.Displayer = null;
            this.LinkEducationProcess.DisplayerText = null;
            this.LinkEducationProcess.Entity = null;
            this.LinkEducationProcess.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LinkEducationProcess.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationProcess.ImageBackColor = System.Drawing.Color.Transparent;
            this.LinkEducationProcess.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LinkEducationProcess.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.LinkEducationProcess.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.LinkEducationProcess.Location = new System.Drawing.Point(10, 0);
            this.LinkEducationProcess.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LinkEducationProcess.Name = "LinkEducationProcess";
            this.LinkEducationProcess.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.LinkEducationProcess.Size = new System.Drawing.Size(188, 20);
            this.LinkEducationProcess.Status = AvControls.Statuses.Satisfactory;
            this.LinkEducationProcess.TabIndex = 16;
            this.LinkEducationProcess.Text = "Education Process";
            this.LinkEducationProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LinkEducationProcess.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkEducationProcess.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEducationProcessRequested);
            
            


			// 
			// OperatorSymmaryDemoScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "OperatorSymmaryDemoScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.ShowTopPanelContainer = false;
			this.Size = new System.Drawing.Size(715, 384);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanelReferences.ResumeLayout(false);
			this.flowLayoutPanelReferences.PerformLayout();
			this.flowLayoutPanelExport.ResumeLayout(false);
			this.flowLayoutPanelExport.PerformLayout();
			this.flowLayoutPanelAircrafts.ResumeLayout(false);
			this.flowLayoutPanelAircrafts.PerformLayout();
			this.flowLayoutPanelStores.ResumeLayout(false);
			this.flowLayoutPanelStores.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
			
			

		}

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReferences;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStores;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExport;
        private AllOperatorsDemoCollectionControl _operators;
        private AllAircraftsDemoCollectionControl _aircrafts;
		private CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference _operatorInfoReference;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _documentsReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _personnelReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _qualityAssuranceReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _adminContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingQuality;
		
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingSMS;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingPersonnel;
		
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPersonnelTraining;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAuditRiskManagment;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEvents;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEventsCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEventsClasses;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEventsTypes;
		
		
		
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _certificationReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _oversightReferenceContainer;
        
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _occurenceReferenceReportContainer;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel OccurenceReReport;
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _directiveContainer;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel DirectiveLink;
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _concessionRequestContainer;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel ConcessionRequestLink;
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _smsContainer;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel EventsLink;
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _authContainer;
        
        
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkTaskList;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEducation;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEducationSummary;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEducationManagment;
        
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingProvider;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkProvider;
        
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEducationProcess;
        
        
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRigestry;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportMonthly;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Users;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportATLB;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Activity;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Aircraft;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Operator;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRecords;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkNomenclatures;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFindingLevels;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRootCause;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPersonnel;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPersonnelLicense;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSpecializations;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAircraftStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsPlanOPS;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkUnFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSchedulePeriod;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDepartments;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCheckList;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRoutineAudit;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkStandartManual;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAuditCAA;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAuditOp;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAuditAll;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAuditManagment;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkInitialOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDocumentPurchase;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkInvoice;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPurchaseOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRequestOffers;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPurchaseStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkQuotationOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSuppliers;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSupplierComponents;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCommercialWorkOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCommercialRequests;


		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkGeneral;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEvent;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSystem;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponents;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEngines;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDefects;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDefferedDefects;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkReportBuilder;
	}
}
