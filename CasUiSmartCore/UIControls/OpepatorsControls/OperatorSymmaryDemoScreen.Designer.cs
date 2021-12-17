
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.HangarControls;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.OpepatorsControls
{
	partial class OperatorSymmaryDemoScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorSymmaryDemoScreen));
			this.flowLayoutPanelReferences = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelExport = new System.Windows.Forms.FlowLayoutPanel();
			this._operatorInfoReference = new CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference();
			this._operationalReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._documentsReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkRigestry = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ExportMonthly = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel(true);
			this.Users = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Activity = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Purchase = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.QuotationSupp = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.mail = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ExportATLB = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel(true);
			this.LinkRecords = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkInternalDocuments = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkNomenclatures = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkFligthsSchedule = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAircraftStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkFligthsPlanOPS = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkUnFligthsSchedule = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSchedulePeriod = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._personnelReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._reliabilityReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkPersonnel = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkGeneral = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkOccurences = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEvent = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSystem = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponents = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEngines = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDefects = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDefferedDefects = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkReportBuilder = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSpecializations = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkTechnicalTraining = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRegularityTraining = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPrintIdCard = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkTesting = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDepartments = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._qualityAssuranceReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkCR = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkProceduresAndProcesses = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkQualityAudits = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRequirements = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkTrainingsAndQualification = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._smsReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkEventCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEventClasses = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEvets = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._purchaseReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
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
			this.LinkMcc = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkCommercialWorkOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkCommercialRequests = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
			this._aircrafts = new CAS.UI.UIControls.AircraftsControls.AircraftDemoCollectionControl();
			this._mccReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._programPlanningAndControlReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkPlanningBriefReport = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPlanningForecast = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPlanningTechnicalLibrary = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPlanningTechnicalRecords = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPlanningWorkPackages = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPlanningWorkPackagesLS = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._vehicles = new CAS.UI.UIControls.AircraftsControls.VehicleCollectionControl();
			this.flowLayoutPanelStores = new System.Windows.Forms.FlowLayoutPanel();
			this._cabinInteriorReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._comercialReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._developmentReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkContractMaintenanceService = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkGroundEquipment = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkITService = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkProjects = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._hangars = new HangarCollectionControl();
			this.workStationCollectionControl1 = new CAS.UI.UIControls.StoresControls.WorkStationCollectionControl();
			this._poolReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkPool = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkWarranty = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._productsReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkComponentModels = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkProducts = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAllProducts = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._stores = new CAS.UI.UIControls.StoresControls.StoreCollectionControl();
			this._workShops = new CAS.UI.UIControls.StoresControls.WorkShopCollectionControl();
			this._exportContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._adminContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this._settingContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
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
#if DEMO
			this.panel1.Controls.Add(this.flowLayoutPanelExport);
			this.panel1.Controls.Add(this.flowLayoutPanelStores);
			this.panel1.Controls.Add(this.flowLayoutPanelReferences);
#else
			this.panel1.Controls.Add(this.flowLayoutPanelExport);
			this.panel1.Controls.Add(this.flowLayoutPanelStores);
			this.panel1.Controls.Add(this.flowLayoutPanelAircrafts);
			this.panel1.Controls.Add(this.flowLayoutPanelReferences);
#endif

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
#if DEMO
			this.flowLayoutPanelReferences.Controls.Add(this._operatorInfoReference);
			this.flowLayoutPanelReferences.Controls.Add(this._documentsReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._personnelReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._qualityAssuranceReferenceContainer);
#else
			this.flowLayoutPanelReferences.Controls.Add(this._operatorInfoReference);
			this.flowLayoutPanelReferences.Controls.Add(this._documentsReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._operationalReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._personnelReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._reliabilityReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._qualityAssuranceReferenceContainer);
			this.flowLayoutPanelReferences.Controls.Add(this._smsReferenceContainer);        
#endif
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
			this.flowLayoutPanelExport.Controls.Add(this._exportContainer);
			this.flowLayoutPanelExport.Controls.Add(this._adminContainer);
			this.flowLayoutPanelExport.Controls.Add(this._settingContainer);
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
			// _exportContainer
			// 
			this._exportContainer.AutoSize = true;
			this._exportContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._exportContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._exportContainer.Caption = "Export";
			this._exportContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._exportContainer.Extended = false;
			this._exportContainer.Location = new System.Drawing.Point(3, 232);
			this._exportContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._exportContainer.Name = "_exportContainer";
			this._exportContainer.ReferenceLink = this.ExportMonthly;
			this._exportContainer.ReferenceLink02 = this.ExportATLB;
			this._exportContainer.ReferenceLink03 = null;
			this._exportContainer.ReferenceLink04 = null;
			this._exportContainer.ReferenceLink05 = null;
			this._exportContainer.ReferenceLink06 = null;
			this._exportContainer.ReferenceLink07 = null;
			this._exportContainer.ReferenceLink08 = null;
			this._exportContainer.ReferenceLink09 = null;
			this._exportContainer.ReferenceLink10 = null;
			this._exportContainer.ReferenceLink11 = null;
			this._exportContainer.ReferenceLink12 = null;
			this._exportContainer.ReferenceLink13 = null;
			this._exportContainer.ReferenceLink14 = null;
			this._exportContainer.ReferenceLink15 = null;
			this._exportContainer.ReferenceLink16 = null;
			this._exportContainer.Size = new System.Drawing.Size(105, 42);
			this._exportContainer.TabIndex = 1;
			this._exportContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._exportContainer.Visible = true;
			// 
			// _adminContainer
			// 
			this._adminContainer.AutoSize = true;
			this._adminContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._adminContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._adminContainer.Caption = "Admin";
			this._adminContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._adminContainer.Extended = false;
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
			this._adminContainer.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UsetType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.UserType == UsetType.Admin;
			// 
			// _settingContainer
			// 
			this._settingContainer.AutoSize = true;
			this._settingContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._settingContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._settingContainer.Caption = "Setting";
			this._settingContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._settingContainer.Extended = false;
			this._settingContainer.Location = new System.Drawing.Point(3, 232);
			this._settingContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._settingContainer.Name = "_settingContainer";
			this._settingContainer.ReferenceLink = this.Purchase;
			this._settingContainer.ReferenceLink02 = this.QuotationSupp;
			this._settingContainer.ReferenceLink03 = this.mail;
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
			this._settingContainer.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UsetType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.UserType == UsetType.Admin;
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
			this.ExportMonthly.Click +=	 ExportMonthly_Click;
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
			this.Purchase.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Purchase.Displayer = null;
			this.Purchase.DisplayerText = null;
			this.Purchase.Entity = null;
			this.Purchase.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Purchase.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Purchase.ImageBackColor = System.Drawing.Color.Transparent;
			this.Purchase.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Purchase.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Purchase.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Purchase.Location = new System.Drawing.Point(10, 0);
			this.Purchase.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Purchase.Name = "Purchase";
			this.Purchase.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Purchase.Size = new System.Drawing.Size(188, 20);
			this.Purchase.Status = AvControls.Statuses.Satisfactory;
			this.Purchase.TabIndex = 2;
			this.Purchase.Text = "Purchase";
			this.Purchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Purchase.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.Purchase.DisplayerRequested += Purchase_DisplayerRequested;
			// 
			// QuotationSupp
			// 
			this.QuotationSupp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.QuotationSupp.Displayer = null;
			this.QuotationSupp.DisplayerText = null;
			this.QuotationSupp.Entity = null;
			this.QuotationSupp.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.QuotationSupp.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.QuotationSupp.ImageBackColor = System.Drawing.Color.Transparent;
			this.QuotationSupp.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.QuotationSupp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.QuotationSupp.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.QuotationSupp.Location = new System.Drawing.Point(10, 0);
			this.QuotationSupp.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.QuotationSupp.Name = "QuotationSupp";
			this.QuotationSupp.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.QuotationSupp.Size = new System.Drawing.Size(188, 20);
			this.QuotationSupp.Status = AvControls.Statuses.Satisfactory;
			this.QuotationSupp.TabIndex = 2;
			this.QuotationSupp.Text = "Quotation Supplier";
			this.QuotationSupp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.QuotationSupp.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.QuotationSupp.DisplayerRequested += QuotationSupp_DisplayerRequested;
			// 
			// mail
			// 
			this.mail.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.mail.Displayer = null;
			this.mail.DisplayerText = null;
			this.mail.Entity = null;
			this.mail.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.mail.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.mail.ImageBackColor = System.Drawing.Color.Transparent;
			this.mail.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.mail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.mail.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.mail.Location = new System.Drawing.Point(10, 0);
			this.mail.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.mail.Name = "E-mail settings";
			this.mail.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.mail.Size = new System.Drawing.Size(188, 20);
			this.mail.Status = AvControls.Statuses.Satisfactory;
			this.mail.TabIndex = 2;
			this.mail.Text = "E-mail settings";
			this.mail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mail.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.mail.DisplayerRequested += mail_DisplayerRequested;
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
			this.ExportATLB.Click += ExportATLB_Click; 

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
			this._documentsReferenceContainer.ReferenceLink03 = this.LinkInternalDocuments;
			this._documentsReferenceContainer.ReferenceLink04 = this.LinkNomenclatures;
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
			this.LinkRecords.DisplayerRequested += LinkRecords_DisplayerRequested;
			// 
			// LinkInternalDocuments
			// 
			this.LinkInternalDocuments.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInternalDocuments.Displayer = null;
			this.LinkInternalDocuments.DisplayerText = null;
			this.LinkInternalDocuments.Entity = null;
			this.LinkInternalDocuments.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkInternalDocuments.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInternalDocuments.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkInternalDocuments.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkInternalDocuments.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInternalDocuments.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkInternalDocuments.Location = new System.Drawing.Point(10, 0);
			this.LinkInternalDocuments.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkInternalDocuments.Name = "LinkInternalDocuments";
			this.LinkInternalDocuments.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkInternalDocuments.Size = new System.Drawing.Size(188, 20);
			this.LinkInternalDocuments.Status = AvControls.Statuses.Satisfactory;
			this.LinkInternalDocuments.TabIndex = 3;
			this.LinkInternalDocuments.Text = "Internal Documents";
			this.LinkInternalDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkInternalDocuments.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkInternalDocuments.DisplayerRequested += LinkInternalDocuments_DisplayerRequested; ;
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
			this.LinkNomenclatures.Text = "Nomenclatures";
			this.LinkNomenclatures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkNomenclatures.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkNomenclatures.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkNomenclaturesDisplayerRequested);

			// 
			// _operationalReferenceContainer
			// 
			this._operationalReferenceContainer.AutoSize = true;
			this._operationalReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._operationalReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._operationalReferenceContainer.Caption = "OPS";
			this._operationalReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._operationalReferenceContainer.Extended = false;
			this._operationalReferenceContainer.Location = new System.Drawing.Point(3, 232);
			this._operationalReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._operationalReferenceContainer.Name = "_operationalReferenceContainer";
			this._operationalReferenceContainer.ReferenceLink = this.LinkAircraftStatus;
			this._operationalReferenceContainer.ReferenceLink02 = this.LinkFligthsPlanOPS;
			this._operationalReferenceContainer.ReferenceLink03 = this.LinkFligthsSchedule;
			this._operationalReferenceContainer.ReferenceLink04 = this.LinkUnFligthsSchedule;
			this._operationalReferenceContainer.ReferenceLink05 = this.LinkSchedulePeriod;
			this._operationalReferenceContainer.ReferenceLink06 = null;
			this._operationalReferenceContainer.ReferenceLink07 = null;
			this._operationalReferenceContainer.ReferenceLink08 = null;
			this._operationalReferenceContainer.ReferenceLink09 = null;
			this._operationalReferenceContainer.ReferenceLink10 = null;
			this._operationalReferenceContainer.ReferenceLink11 = null;
			this._operationalReferenceContainer.ReferenceLink12 = null;
			this._operationalReferenceContainer.ReferenceLink13 = null;
			this._operationalReferenceContainer.ReferenceLink14 = null;
			this._operationalReferenceContainer.ReferenceLink15 = null;
			this._operationalReferenceContainer.ReferenceLink16 = null;
			this._operationalReferenceContainer.Size = new System.Drawing.Size(105, 42);
			this._operationalReferenceContainer.TabIndex = 5;
			this._operationalReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this._operationalReferenceContainer.Visible = false;
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
			this.LinkAircraftStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAircraftStatusDisplayerRequested);
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
			this.LinkFligthsPlanOPS.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkFligthPlanOPSDisplayerRequested);
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
			this.LinkFligthsSchedule.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkFligthScheduleDisplayerRequested);
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
			this.LinkUnFligthsSchedule.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkFligthUnScheduleDisplayerRequested);
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
			this.LinkSchedulePeriod.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.SchedulePeriodDisplayerRequested);
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
			this._personnelReferenceContainer.ReferenceLink02 = this.LinkSpecializations;
			this._personnelReferenceContainer.ReferenceLink03 = this.LinkTechnicalTraining;
			this._personnelReferenceContainer.ReferenceLink04 = this.LinkRegularityTraining;
			this._personnelReferenceContainer.ReferenceLink05 = this.LinkPrintIdCard;
			this._personnelReferenceContainer.ReferenceLink06 = this.LinkTesting;
			this._personnelReferenceContainer.ReferenceLink06 = this.LinkDepartments;
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
			this.LinkEvent.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEventDisplayerRequested);
			// 
			// LinkOccurences
			// 
			this.LinkOccurences.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOccurences.Displayer = null;
			this.LinkOccurences.DisplayerText = null;
			this.LinkOccurences.Entity = null;
			this.LinkOccurences.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkOccurences.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOccurences.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkOccurences.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkOccurences.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOccurences.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkOccurences.Location = new System.Drawing.Point(10, 0);
			this.LinkOccurences.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkOccurences.Name = "LinkOccurences";
			this.LinkOccurences.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkOccurences.Size = new System.Drawing.Size(280, 20);
			this.LinkOccurences.Status = AvControls.Statuses.Satisfactory;
			this.LinkOccurences.TabIndex = 6;
			this.LinkOccurences.Text = "Occurrences and Interruptions";
			this.LinkOccurences.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkOccurences.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkOccurences.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkOccurencesDisplayerRequested);
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
			this.LinkSystem.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSystemDisplayerRequested);
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
			this.LinkComponents.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentsDisplayerRequested);
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
			this.LinkDefects.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDefectDisplayerRequested);
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
			this.LinkDefferedDefects.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDefferedDefectsDisplayerRequested);
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
			// _reliabilityReferenceContainer
			// 
			this._reliabilityReferenceContainer.AutoSize = true;
			this._reliabilityReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._reliabilityReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._reliabilityReferenceContainer.Caption = "Reliability";
			this._reliabilityReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._reliabilityReferenceContainer.Extended = false;
			this._reliabilityReferenceContainer.Location = new System.Drawing.Point(3, 278);
			this._reliabilityReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._reliabilityReferenceContainer.Name = "_reliabilityReferenceContainer";
			this._reliabilityReferenceContainer.ReferenceLink = LinkGeneral;
			this._reliabilityReferenceContainer.ReferenceLink02 = LinkEvent;
			this._reliabilityReferenceContainer.ReferenceLink03 = LinkOccurences;
			this._reliabilityReferenceContainer.ReferenceLink04 = LinkSystem;
			this._reliabilityReferenceContainer.ReferenceLink05 = LinkComponents;
			this._reliabilityReferenceContainer.ReferenceLink06 = LinkEngines;
			this._reliabilityReferenceContainer.ReferenceLink07 = LinkDefects;
			this._reliabilityReferenceContainer.ReferenceLink08 = LinkDefferedDefects;
			this._reliabilityReferenceContainer.ReferenceLink09 = LinkReportBuilder;
			this._reliabilityReferenceContainer.ReferenceLink10 = null;
			this._reliabilityReferenceContainer.ReferenceLink11 = null;
			this._reliabilityReferenceContainer.ReferenceLink12 = null;
			this._reliabilityReferenceContainer.ReferenceLink13 = null;
			this._reliabilityReferenceContainer.ReferenceLink14 = null;
			this._reliabilityReferenceContainer.ReferenceLink15 = null;
			this._reliabilityReferenceContainer.ReferenceLink16 = null;
			this._reliabilityReferenceContainer.Size = new System.Drawing.Size(166, 42);
			this._reliabilityReferenceContainer.TabIndex = 7;
			this._reliabilityReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
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
			this.LinkPersonnel.Visible = GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.IdentityUser.UserType == UsetType.Admin : GlobalObjects.CaaEnvironment.IdentityUser.UserType == UsetType.Admin;
			this.LinkPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPersonnel.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPersonnel.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPersonnelDisplayerRequested);
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
			// LinkTechnicalTraining
			// 
			this.LinkTechnicalTraining.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTechnicalTraining.Displayer = null;
			this.LinkTechnicalTraining.DisplayerText = null;
			this.LinkTechnicalTraining.Entity = null;
			this.LinkTechnicalTraining.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkTechnicalTraining.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTechnicalTraining.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkTechnicalTraining.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkTechnicalTraining.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTechnicalTraining.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkTechnicalTraining.Location = new System.Drawing.Point(406, 0);
			this.LinkTechnicalTraining.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkTechnicalTraining.Name = "LinkTechnicalTraining";
			this.LinkTechnicalTraining.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkTechnicalTraining.Size = new System.Drawing.Size(188, 20);
			this.LinkTechnicalTraining.Status = AvControls.Statuses.Satisfactory;
			this.LinkTechnicalTraining.TabIndex = 10;
			this.LinkTechnicalTraining.Text = "Technical Training";
			this.LinkTechnicalTraining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkTechnicalTraining.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkRegularityTraining
			// 
			this.LinkRegularityTraining.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegularityTraining.Displayer = null;
			this.LinkRegularityTraining.DisplayerText = null;
			this.LinkRegularityTraining.Entity = null;
			this.LinkRegularityTraining.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRegularityTraining.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegularityTraining.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRegularityTraining.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRegularityTraining.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegularityTraining.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRegularityTraining.Location = new System.Drawing.Point(604, 0);
			this.LinkRegularityTraining.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRegularityTraining.Name = "LinkRegularityTraining";
			this.LinkRegularityTraining.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRegularityTraining.Size = new System.Drawing.Size(188, 20);
			this.LinkRegularityTraining.Status = AvControls.Statuses.Satisfactory;
			this.LinkRegularityTraining.TabIndex = 11;
			this.LinkRegularityTraining.Text = "Regularity Training";
			this.LinkRegularityTraining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRegularityTraining.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkPrintIdCard
			// 
			this.LinkPrintIdCard.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPrintIdCard.Displayer = null;
			this.LinkPrintIdCard.DisplayerText = null;
			this.LinkPrintIdCard.Entity = null;
			this.LinkPrintIdCard.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPrintIdCard.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPrintIdCard.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPrintIdCard.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPrintIdCard.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPrintIdCard.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPrintIdCard.Location = new System.Drawing.Point(802, 0);
			this.LinkPrintIdCard.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPrintIdCard.Name = "LinkPrintIdCard";
			this.LinkPrintIdCard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPrintIdCard.Size = new System.Drawing.Size(188, 20);
			this.LinkPrintIdCard.Status = AvControls.Statuses.Satisfactory;
			this.LinkPrintIdCard.TabIndex = 12;
			this.LinkPrintIdCard.Text = "Print ID Cards";
			this.LinkPrintIdCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPrintIdCard.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkTesting
			// 
			this.LinkTesting.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTesting.Displayer = null;
			this.LinkTesting.DisplayerText = null;
			this.LinkTesting.Entity = null;
			this.LinkTesting.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkTesting.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTesting.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkTesting.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkTesting.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTesting.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkTesting.Location = new System.Drawing.Point(1000, 0);
			this.LinkTesting.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkTesting.Name = "LinkTesting";
			this.LinkTesting.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkTesting.Size = new System.Drawing.Size(188, 20);
			this.LinkTesting.Status = AvControls.Statuses.Satisfactory;
			this.LinkTesting.TabIndex = 13;
			this.LinkTesting.Text = "Testing";
			this.LinkTesting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkTesting.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
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
			this._qualityAssuranceReferenceContainer.ReferenceLink = this.LinkCR;
			this._qualityAssuranceReferenceContainer.ReferenceLink02 = this.LinkProceduresAndProcesses;
			this._qualityAssuranceReferenceContainer.ReferenceLink03 = this.LinkQualityAudits;
			this._qualityAssuranceReferenceContainer.ReferenceLink04 = this.LinkRequirements;
			this._qualityAssuranceReferenceContainer.ReferenceLink05 = this.LinkTrainingsAndQualification;
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
			// LinkCR
			// 
			this.LinkCR.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCR.Displayer = null;
			this.LinkCR.DisplayerText = null;
			this.LinkCR.Entity = null;
			this.LinkCR.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkCR.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCR.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkCR.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkCR.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCR.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkCR.Location = new System.Drawing.Point(10, 0);
			this.LinkCR.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkCR.Name = "LinkCR";
			this.LinkCR.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkCR.Size = new System.Drawing.Size(188, 20);
			this.LinkCR.Status = AvControls.Statuses.Satisfactory;
			this.LinkCR.TabIndex = 16;
			this.LinkCR.Text = "CR";
			this.LinkCR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkCR.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkProceduresAndProcesses
			// 
			this.LinkProceduresAndProcesses.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProceduresAndProcesses.Displayer = null;
			this.LinkProceduresAndProcesses.DisplayerText = null;
			this.LinkProceduresAndProcesses.Entity = null;
			this.LinkProceduresAndProcesses.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkProceduresAndProcesses.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProceduresAndProcesses.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkProceduresAndProcesses.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkProceduresAndProcesses.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProceduresAndProcesses.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkProceduresAndProcesses.Location = new System.Drawing.Point(10, 20);
			this.LinkProceduresAndProcesses.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkProceduresAndProcesses.Name = "LinkProceduresAndProcesses";
			this.LinkProceduresAndProcesses.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkProceduresAndProcesses.Size = new System.Drawing.Size(250, 20);
			this.LinkProceduresAndProcesses.Status = AvControls.Statuses.Satisfactory;
			this.LinkProceduresAndProcesses.TabIndex = 17;
			this.LinkProceduresAndProcesses.Text = "Procedures and Processes";
			this.LinkProceduresAndProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkProceduresAndProcesses.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkProceduresAndProcesses.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkProceduresDisplayerRequested);

			// 
			// LinkQualityAudits
			// 
			this.LinkQualityAudits.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQualityAudits.Displayer = null;
			this.LinkQualityAudits.DisplayerText = null;
			this.LinkQualityAudits.Entity = null;
			this.LinkQualityAudits.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkQualityAudits.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQualityAudits.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkQualityAudits.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkQualityAudits.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQualityAudits.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkQualityAudits.Location = new System.Drawing.Point(10, 40);
			this.LinkQualityAudits.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkQualityAudits.Name = "LinkQualityAudits";
			this.LinkQualityAudits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkQualityAudits.Size = new System.Drawing.Size(188, 20);
			this.LinkQualityAudits.Status = AvControls.Statuses.Satisfactory;
			this.LinkQualityAudits.TabIndex = 18;
			this.LinkQualityAudits.Text = "Quality Audits";
			this.LinkQualityAudits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkQualityAudits.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkQualityAudits.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditsDisplayerRequested);
			// 
			// LinkRequirements
			// 
			this.LinkRequirements.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequirements.Displayer = null;
			this.LinkRequirements.DisplayerText = null;
			this.LinkRequirements.Entity = null;
			this.LinkRequirements.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkRequirements.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequirements.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRequirements.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRequirements.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRequirements.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRequirements.Location = new System.Drawing.Point(10, 60);
			this.LinkRequirements.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRequirements.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkRequirements.Name = "LinkRequirements";
			this.LinkRequirements.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRequirements.Size = new System.Drawing.Size(250, 20);
			this.LinkRequirements.Status = AvControls.Statuses.Satisfactory;
			this.LinkRequirements.TabIndex = 19;
			this.LinkRequirements.Text = "Requirements";
			this.LinkRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRequirements.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkTrainingsAndQualification
			// 
			this.LinkTrainingsAndQualification.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTrainingsAndQualification.Displayer = null;
			this.LinkTrainingsAndQualification.DisplayerText = null;
			this.LinkTrainingsAndQualification.Entity = null;
			this.LinkTrainingsAndQualification.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkTrainingsAndQualification.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTrainingsAndQualification.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkTrainingsAndQualification.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkTrainingsAndQualification.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkTrainingsAndQualification.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkTrainingsAndQualification.Location = new System.Drawing.Point(10, 80);
			this.LinkTrainingsAndQualification.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkTrainingsAndQualification.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkTrainingsAndQualification.Name = "LinkTrainingsAndQualification";
			this.LinkTrainingsAndQualification.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkTrainingsAndQualification.Size = new System.Drawing.Size(250, 20);
			this.LinkTrainingsAndQualification.Status = AvControls.Statuses.Satisfactory;
			this.LinkTrainingsAndQualification.TabIndex = 20;
			this.LinkTrainingsAndQualification.Text = "Training and Staff Qualification Records";
			this.LinkTrainingsAndQualification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkTrainingsAndQualification.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// _smsReferenceContainer
			// 
			this._smsReferenceContainer.AutoSize = true;
			this._smsReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._smsReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._smsReferenceContainer.Caption = "SMS";
			this._smsReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._smsReferenceContainer.Extended = false;
			this._smsReferenceContainer.Location = new System.Drawing.Point(3, 370);
			this._smsReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._smsReferenceContainer.Name = "_smsReferenceContainer";
			this._smsReferenceContainer.ReferenceLink = this.LinkEventCategories;
			this._smsReferenceContainer.ReferenceLink02 = this.LinkEventClasses;
			this._smsReferenceContainer.ReferenceLink03 = this.LinkEvets;
			this._smsReferenceContainer.ReferenceLink04 = null;
			this._smsReferenceContainer.ReferenceLink05 = null;
			this._smsReferenceContainer.ReferenceLink06 = null;
			this._smsReferenceContainer.ReferenceLink07 = null;
			this._smsReferenceContainer.ReferenceLink08 = null;
			this._smsReferenceContainer.ReferenceLink09 = null;
			this._smsReferenceContainer.ReferenceLink10 = null;
			this._smsReferenceContainer.ReferenceLink11 = null;
			this._smsReferenceContainer.ReferenceLink12 = null;
			this._smsReferenceContainer.ReferenceLink13 = null;
			this._smsReferenceContainer.ReferenceLink14 = null;
			this._smsReferenceContainer.ReferenceLink15 = null;
			this._smsReferenceContainer.ReferenceLink16 = null;
			this._smsReferenceContainer.Size = new System.Drawing.Size(109, 42);
			this._smsReferenceContainer.TabIndex = 21;
			this._smsReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._smsReferenceContainer.Visible = false;
#endif
			// 
			// LinkEventCategories
			// 
			this.LinkEventCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventCategories.Displayer = null;
			this.LinkEventCategories.DisplayerText = null;
			this.LinkEventCategories.Entity = null;
			this.LinkEventCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkEventCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventCategories.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEventCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEventCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEventCategories.Location = new System.Drawing.Point(10, 0);
			this.LinkEventCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEventCategories.Name = "LinkEventCategories";
			this.LinkEventCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEventCategories.Size = new System.Drawing.Size(188, 20);
			this.LinkEventCategories.Status = AvControls.Statuses.Satisfactory;
			this.LinkEventCategories.TabIndex = 22;
			this.LinkEventCategories.Text = "Event Categories";
			this.LinkEventCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEventCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkEventClasses
			// 
			this.LinkEventClasses.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventClasses.Displayer = null;
			this.LinkEventClasses.DisplayerText = null;
			this.LinkEventClasses.Entity = null;
			this.LinkEventClasses.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkEventClasses.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventClasses.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEventClasses.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEventClasses.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEventClasses.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEventClasses.Location = new System.Drawing.Point(208, 0);
			this.LinkEventClasses.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEventClasses.Name = "LinkEventClasses";
			this.LinkEventClasses.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEventClasses.Size = new System.Drawing.Size(188, 20);
			this.LinkEventClasses.Status = AvControls.Statuses.Satisfactory;
			this.LinkEventClasses.TabIndex = 23;
			this.LinkEventClasses.Text = "Event Classes";
			this.LinkEventClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEventClasses.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkEvets
			// 
			this.LinkEvets.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvets.Displayer = null;
			this.LinkEvets.DisplayerText = null;
			this.LinkEvets.Entity = null;
			this.LinkEvets.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkEvets.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvets.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEvets.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEvets.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEvets.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEvets.Location = new System.Drawing.Point(406, 0);
			this.LinkEvets.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEvets.Name = "LinkEvets";
			this.LinkEvets.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEvets.Size = new System.Drawing.Size(188, 20);
			this.LinkEvets.Status = AvControls.Statuses.Satisfactory;
			this.LinkEvets.TabIndex = 24;
			this.LinkEvets.Text = "Events";
			this.LinkEvets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEvets.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkMcc
			// 
			this.LinkMcc.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMcc.Displayer = null;
			this.LinkMcc.DisplayerText = null;
			this.LinkMcc.Entity = null;
			this.LinkMcc.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkMcc.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMcc.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkMcc.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkMcc.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMcc.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkMcc.Location = new System.Drawing.Point(10, 0);
			this.LinkMcc.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkMcc.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkMcc.Name = "LinkMcc";
			this.LinkMcc.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkMcc.Size = new System.Drawing.Size(250, 20);
			this.LinkMcc.Status = AvControls.Statuses.Satisfactory;
			this.LinkMcc.TabIndex = 29;
			this.LinkMcc.Text = "Maintenance Control Center";
			this.LinkMcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkMcc.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMcc.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkMaintenanceControlCenterDisplayerRequested);
			// 
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoScroll = true;
			this.flowLayoutPanelAircrafts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelAircrafts.Controls.Add(this._aircrafts);
			this.flowLayoutPanelAircrafts.Controls.Add(this._mccReferenceContainer);
			this.flowLayoutPanelAircrafts.Controls.Add(this._programPlanningAndControlReferenceContainer);
			this.flowLayoutPanelAircrafts.Controls.Add(this._vehicles);
			this.flowLayoutPanelAircrafts.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(400, 0);
			this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(400, 10);
			this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
			this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(400, 274);
			this.flowLayoutPanelAircrafts.TabIndex = 1;
			this.flowLayoutPanelAircrafts.WrapContents = false;
			// 
			// _aircrafts
			// 
			this._aircrafts.AircraftCollection = null;
			this._aircrafts.AutoSize = true;
			this._aircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._aircrafts.Extended = true;
			this._aircrafts.Location = new System.Drawing.Point(3, 2);
			this._aircrafts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._aircrafts.MaximumSize = new System.Drawing.Size(400, 0);
			this._aircrafts.Name = "_aircrafts";
			this._aircrafts.Size = new System.Drawing.Size(362, 168);
			this._aircrafts.TabIndex = 25;
			// 
			// _mccReferenceContainer
			// 
			this._mccReferenceContainer.AutoSize = true;
			this._mccReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._mccReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._mccReferenceContainer.Caption = "MCC";
			this._mccReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._mccReferenceContainer.Extended = false;
			this._mccReferenceContainer.Location = new System.Drawing.Point(3, 174);
			this._mccReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._mccReferenceContainer.Name = "_mccReferenceContainer";
			this._mccReferenceContainer.ReferenceLink = this.LinkMcc;
			this._mccReferenceContainer.ReferenceLink02 = null;
			this._mccReferenceContainer.ReferenceLink03 = null;
			this._mccReferenceContainer.ReferenceLink04 = null;
			this._mccReferenceContainer.ReferenceLink05 = null;
			this._mccReferenceContainer.ReferenceLink06 = null;
			this._mccReferenceContainer.ReferenceLink07 = null;
			this._mccReferenceContainer.ReferenceLink08 = null;
			this._mccReferenceContainer.ReferenceLink09 = null;
			this._mccReferenceContainer.ReferenceLink10 = null;
			this._mccReferenceContainer.ReferenceLink11 = null;
			this._mccReferenceContainer.ReferenceLink12 = null;
			this._mccReferenceContainer.ReferenceLink13 = null;
			this._mccReferenceContainer.ReferenceLink14 = null;
			this._mccReferenceContainer.ReferenceLink15 = null;
			this._mccReferenceContainer.ReferenceLink16 = null;
			this._mccReferenceContainer.Size = new System.Drawing.Size(109, 42);
			this._mccReferenceContainer.TabIndex = 26;
			this._mccReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			// 
			// _programPlanningAndControlReferenceContainer
			// 
			this._programPlanningAndControlReferenceContainer.AutoSize = true;
			this._programPlanningAndControlReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._programPlanningAndControlReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._programPlanningAndControlReferenceContainer.Caption = "PPCD";
			this._programPlanningAndControlReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._programPlanningAndControlReferenceContainer.Extended = false;
			this._programPlanningAndControlReferenceContainer.Location = new System.Drawing.Point(3, 220);
			this._programPlanningAndControlReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._programPlanningAndControlReferenceContainer.Name = "_programPlanningAndControlReferenceContainer";
			this._programPlanningAndControlReferenceContainer.ReferenceLink = this.LinkPlanningBriefReport;
			this._programPlanningAndControlReferenceContainer.ReferenceLink02 = this.LinkPlanningForecast;
			this._programPlanningAndControlReferenceContainer.ReferenceLink03 = this.LinkPlanningTechnicalLibrary;
			this._programPlanningAndControlReferenceContainer.ReferenceLink04 = this.LinkPlanningTechnicalRecords;
			this._programPlanningAndControlReferenceContainer.ReferenceLink05 = this.LinkPlanningWorkPackages;
			this._programPlanningAndControlReferenceContainer.ReferenceLink06 = this.LinkPlanningWorkPackagesLS;
			this._programPlanningAndControlReferenceContainer.ReferenceLink07 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink08 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink09 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink10 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink11 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink12 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink13 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink14 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink15 = null;
			this._programPlanningAndControlReferenceContainer.ReferenceLink16 = null;
			this._programPlanningAndControlReferenceContainer.Size = new System.Drawing.Size(118, 42);
			this._programPlanningAndControlReferenceContainer.TabIndex = 27;
			this._programPlanningAndControlReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			// 
			// LinkPlanningBriefReport
			// 
			this.LinkPlanningBriefReport.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningBriefReport.Displayer = null;
			this.LinkPlanningBriefReport.DisplayerText = null;
			this.LinkPlanningBriefReport.Entity = null;
			this.LinkPlanningBriefReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningBriefReport.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningBriefReport.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningBriefReport.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningBriefReport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningBriefReport.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningBriefReport.Location = new System.Drawing.Point(10, 0);
			this.LinkPlanningBriefReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningBriefReport.Name = "LinkPlanningBriefReport";
			this.LinkPlanningBriefReport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningBriefReport.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningBriefReport.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningBriefReport.TabIndex = 28;
			this.LinkPlanningBriefReport.Text = "Brief Report";
			this.LinkPlanningBriefReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningBriefReport.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPlanningBriefReport.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkReportDisplayerRequested);
			// 
			// LinkPlanningForecast
			// 
			this.LinkPlanningForecast.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningForecast.Displayer = null;
			this.LinkPlanningForecast.DisplayerText = null;
			this.LinkPlanningForecast.Entity = null;
			this.LinkPlanningForecast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningForecast.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningForecast.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningForecast.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningForecast.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningForecast.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningForecast.Location = new System.Drawing.Point(208, 0);
			this.LinkPlanningForecast.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningForecast.Name = "LinkPlanningForecast";
			this.LinkPlanningForecast.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningForecast.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningForecast.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningForecast.TabIndex = 29;
			this.LinkPlanningForecast.Text = "Forecast";
			this.LinkPlanningForecast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningForecast.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPlanningForecast.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastAllAircraftDisplayerRequested);
			// 
			// LinkPlanningTechnicalLibrary
			// 
			this.LinkPlanningTechnicalLibrary.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalLibrary.Displayer = null;
			this.LinkPlanningTechnicalLibrary.DisplayerText = null;
			this.LinkPlanningTechnicalLibrary.Entity = null;
			this.LinkPlanningTechnicalLibrary.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningTechnicalLibrary.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalLibrary.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningTechnicalLibrary.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningTechnicalLibrary.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalLibrary.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningTechnicalLibrary.Location = new System.Drawing.Point(406, 0);
			this.LinkPlanningTechnicalLibrary.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningTechnicalLibrary.Name = "LinkPlanningTechnicalLibrary";
			this.LinkPlanningTechnicalLibrary.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningTechnicalLibrary.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningTechnicalLibrary.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningTechnicalLibrary.TabIndex = 30;
			this.LinkPlanningTechnicalLibrary.Text = "Technical Library";
			this.LinkPlanningTechnicalLibrary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningTechnicalLibrary.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkPlanningTechnicalRecords
			// 
			this.LinkPlanningTechnicalRecords.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalRecords.Displayer = null;
			this.LinkPlanningTechnicalRecords.DisplayerText = null;
			this.LinkPlanningTechnicalRecords.Entity = null;
			this.LinkPlanningTechnicalRecords.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningTechnicalRecords.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalRecords.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningTechnicalRecords.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningTechnicalRecords.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningTechnicalRecords.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningTechnicalRecords.Location = new System.Drawing.Point(604, 0);
			this.LinkPlanningTechnicalRecords.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningTechnicalRecords.Name = "LinkPlanningTechnicalRecords";
			this.LinkPlanningTechnicalRecords.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningTechnicalRecords.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningTechnicalRecords.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningTechnicalRecords.TabIndex = 31;
			this.LinkPlanningTechnicalRecords.Text = "Technical Records";
			this.LinkPlanningTechnicalRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningTechnicalRecords.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkPlanningWorkPackages
			// 
			this.LinkPlanningWorkPackages.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackages.Displayer = null;
			this.LinkPlanningWorkPackages.DisplayerText = null;
			this.LinkPlanningWorkPackages.Entity = null;
			this.LinkPlanningWorkPackages.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningWorkPackages.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackages.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningWorkPackages.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningWorkPackages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackages.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningWorkPackages.Location = new System.Drawing.Point(802, 0);
			this.LinkPlanningWorkPackages.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningWorkPackages.Name = "LinkPlanningWorkPackages";
			this.LinkPlanningWorkPackages.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningWorkPackages.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningWorkPackages.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningWorkPackages.TabIndex = 32;
			this.LinkPlanningWorkPackages.Text = "Work Packages";
			this.LinkPlanningWorkPackages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningWorkPackages.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPlanningWorkPackages.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAllWorkPackagesDisplayerRequested);
			// 
			// LinkPlanningWorkPackagesLS
			// 
			this.LinkPlanningWorkPackagesLS.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackagesLS.Displayer = null;
			this.LinkPlanningWorkPackagesLS.DisplayerText = null;
			this.LinkPlanningWorkPackagesLS.Entity = null;
			this.LinkPlanningWorkPackagesLS.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPlanningWorkPackagesLS.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackagesLS.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPlanningWorkPackagesLS.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPlanningWorkPackagesLS.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPlanningWorkPackagesLS.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPlanningWorkPackagesLS.Location = new System.Drawing.Point(802, 0);
			this.LinkPlanningWorkPackagesLS.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPlanningWorkPackagesLS.Name = "LinkPlanningWorkPackagesLS";
			this.LinkPlanningWorkPackagesLS.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPlanningWorkPackagesLS.Size = new System.Drawing.Size(188, 20);
			this.LinkPlanningWorkPackagesLS.Status = AvControls.Statuses.Satisfactory;
			this.LinkPlanningWorkPackagesLS.TabIndex = 32;
			this.LinkPlanningWorkPackagesLS.Text = "Work Packages LS";
			this.LinkPlanningWorkPackagesLS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPlanningWorkPackagesLS.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPlanningWorkPackagesLS.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkWorkPackageLSDisplayerRequested);
			// 
			// _vehicles
			// 
			this._vehicles.AutoSize = true;
			this._vehicles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._vehicles.Extended = false;
			this._vehicles.Location = new System.Drawing.Point(3, 266);
			this._vehicles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._vehicles.MaximumSize = new System.Drawing.Size(400, 0);
			this._vehicles.Name = "_vehicles";
			this._vehicles.Size = new System.Drawing.Size(207, 41);
			this._vehicles.TabIndex = 33;
			this._vehicles.VehiclesCollection = null;
#if SCAT
			this._vehicles.Visible = false;
#endif
			// 
			// flowLayoutPanelStores
			// 
#if DEMO
			this.flowLayoutPanelStores.Controls.Add(this._purchaseReferenceContainer);
#else
			this.flowLayoutPanelStores.Controls.Add(this._cabinInteriorReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._comercialReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._developmentReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._hangars);
			this.flowLayoutPanelStores.Controls.Add(this.workStationCollectionControl1);
			this.flowLayoutPanelStores.Controls.Add(this._poolReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._productsReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._purchaseReferenceContainer);
			this.flowLayoutPanelStores.Controls.Add(this._stores);
			this.flowLayoutPanelStores.Controls.Add(this._workShops);
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
			// _cabinInteriorReferenceContainer
			// 
			this._cabinInteriorReferenceContainer.AutoSize = true;
			this._cabinInteriorReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._cabinInteriorReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._cabinInteriorReferenceContainer.Caption = "Cabin Interior";
			this._cabinInteriorReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._cabinInteriorReferenceContainer.Extended = false;
			this._cabinInteriorReferenceContainer.Location = new System.Drawing.Point(3, 2);
			this._cabinInteriorReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._cabinInteriorReferenceContainer.Name = "_cabinInteriorReferenceContainer";
			this._cabinInteriorReferenceContainer.ReferenceLink = null;
			this._cabinInteriorReferenceContainer.ReferenceLink02 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink03 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink04 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink05 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink06 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink07 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink08 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink09 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink10 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink11 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink12 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink13 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink14 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink15 = null;
			this._cabinInteriorReferenceContainer.ReferenceLink16 = null;
			this._cabinInteriorReferenceContainer.Size = new System.Drawing.Size(213, 42);
			this._cabinInteriorReferenceContainer.TabIndex = 35;
			this._cabinInteriorReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._cabinInteriorReferenceContainer.Visible = false;
#endif
			// 
			// _comercialReferenceContainer
			// 
			this._comercialReferenceContainer.AutoSize = true;
			this._comercialReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._comercialReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._comercialReferenceContainer.Caption = "Comercial";
			this._comercialReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._comercialReferenceContainer.Extended = false;
			this._comercialReferenceContainer.Location = new System.Drawing.Point(3, 48);
			this._comercialReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._comercialReferenceContainer.Name = "_comercialReferenceContainer";
			this._comercialReferenceContainer.ReferenceLink = this.LinkCommercialRequests;
			this._comercialReferenceContainer.ReferenceLink02 = this.LinkCommercialWorkOrders;
			this._comercialReferenceContainer.ReferenceLink03 = null;
			this._comercialReferenceContainer.ReferenceLink04 = null;
			this._comercialReferenceContainer.ReferenceLink05 = null;
			this._comercialReferenceContainer.ReferenceLink06 = null;
			this._comercialReferenceContainer.ReferenceLink07 = null;
			this._comercialReferenceContainer.ReferenceLink08 = null;
			this._comercialReferenceContainer.ReferenceLink09 = null;
			this._comercialReferenceContainer.ReferenceLink10 = null;
			this._comercialReferenceContainer.ReferenceLink11 = null;
			this._comercialReferenceContainer.ReferenceLink12 = null;
			this._comercialReferenceContainer.ReferenceLink13 = null;
			this._comercialReferenceContainer.ReferenceLink14 = null;
			this._comercialReferenceContainer.ReferenceLink15 = null;
			this._comercialReferenceContainer.ReferenceLink16 = null;
			this._comercialReferenceContainer.Size = new System.Drawing.Size(167, 42);
			this._comercialReferenceContainer.TabIndex = 6;
			this._comercialReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._comercialReferenceContainer.Visible = false;
#endif

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
			this.LinkCommercialRequests.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRequestsDisplayerRequested);
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
			this.LinkCommercialWorkOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkWorkOrdersDisplayerRequested);
			// 
			// _developmentReferenceContainer
			// 
			this._developmentReferenceContainer.AutoSize = true;
			this._developmentReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._developmentReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._developmentReferenceContainer.Caption = "Development";
			this._developmentReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._developmentReferenceContainer.Extended = false;
			this._developmentReferenceContainer.Location = new System.Drawing.Point(3, 94);
			this._developmentReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._developmentReferenceContainer.Name = "_developmentReferenceContainer";
			this._developmentReferenceContainer.ReferenceLink = this.LinkContractMaintenanceService;
			this._developmentReferenceContainer.ReferenceLink02 = this.LinkGroundEquipment;
			this._developmentReferenceContainer.ReferenceLink03 = this.LinkITService;
			this._developmentReferenceContainer.ReferenceLink04 = this.LinkProjects;
			this._developmentReferenceContainer.ReferenceLink05 = null;
			this._developmentReferenceContainer.ReferenceLink06 = null;
			this._developmentReferenceContainer.ReferenceLink07 = null;
			this._developmentReferenceContainer.ReferenceLink08 = null;
			this._developmentReferenceContainer.ReferenceLink09 = null;
			this._developmentReferenceContainer.ReferenceLink10 = null;
			this._developmentReferenceContainer.ReferenceLink11 = null;
			this._developmentReferenceContainer.ReferenceLink12 = null;
			this._developmentReferenceContainer.ReferenceLink13 = null;
			this._developmentReferenceContainer.ReferenceLink14 = null;
			this._developmentReferenceContainer.ReferenceLink15 = null;
			this._developmentReferenceContainer.ReferenceLink16 = null;
			this._developmentReferenceContainer.Size = new System.Drawing.Size(206, 42);
			this._developmentReferenceContainer.TabIndex = 38;
			this._developmentReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._developmentReferenceContainer.Visible = false;
#endif
			// 
			// LinkContractMaintenanceService
			// 
			this.LinkContractMaintenanceService.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkContractMaintenanceService.Displayer = null;
			this.LinkContractMaintenanceService.DisplayerText = null;
			this.LinkContractMaintenanceService.Entity = null;
			this.LinkContractMaintenanceService.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkContractMaintenanceService.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkContractMaintenanceService.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkContractMaintenanceService.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkContractMaintenanceService.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkContractMaintenanceService.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkContractMaintenanceService.Location = new System.Drawing.Point(10, 0);
			this.LinkContractMaintenanceService.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkContractMaintenanceService.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkContractMaintenanceService.Name = "LinkContractMaintenanceService";
			this.LinkContractMaintenanceService.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkContractMaintenanceService.Size = new System.Drawing.Size(250, 20);
			this.LinkContractMaintenanceService.Status = AvControls.Statuses.Satisfactory;
			this.LinkContractMaintenanceService.TabIndex = 39;
			this.LinkContractMaintenanceService.Text = "Contract Maintenance Service";
			this.LinkContractMaintenanceService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkContractMaintenanceService.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkGroundEquipment
			// 
			this.LinkGroundEquipment.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGroundEquipment.Displayer = null;
			this.LinkGroundEquipment.DisplayerText = null;
			this.LinkGroundEquipment.Entity = null;
			this.LinkGroundEquipment.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkGroundEquipment.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGroundEquipment.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkGroundEquipment.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkGroundEquipment.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkGroundEquipment.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkGroundEquipment.Location = new System.Drawing.Point(270, 0);
			this.LinkGroundEquipment.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkGroundEquipment.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkGroundEquipment.Name = "LinkGroundEquipment";
			this.LinkGroundEquipment.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkGroundEquipment.Size = new System.Drawing.Size(250, 20);
			this.LinkGroundEquipment.Status = AvControls.Statuses.Satisfactory;
			this.LinkGroundEquipment.TabIndex = 40;
			this.LinkGroundEquipment.Text = "Ground Equipment";
			this.LinkGroundEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkGroundEquipment.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkGroundEquipment.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkGroundEquipmentDisplayerRequested);
			// 
			// LinkITService
			// 
			this.LinkITService.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkITService.Displayer = null;
			this.LinkITService.DisplayerText = null;
			this.LinkITService.Entity = null;
			this.LinkITService.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkITService.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkITService.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkITService.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkITService.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkITService.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkITService.Location = new System.Drawing.Point(530, 0);
			this.LinkITService.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkITService.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkITService.Name = "LinkITService";
			this.LinkITService.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkITService.Size = new System.Drawing.Size(250, 20);
			this.LinkITService.Status = AvControls.Statuses.Satisfactory;
			this.LinkITService.TabIndex = 41;
			this.LinkITService.Text = "IT Service";
			this.LinkITService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkITService.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkProjects
			// 
			this.LinkProjects.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProjects.Displayer = null;
			this.LinkProjects.DisplayerText = null;
			this.LinkProjects.Entity = null;
			this.LinkProjects.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkProjects.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProjects.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkProjects.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkProjects.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProjects.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkProjects.Location = new System.Drawing.Point(790, 0);
			this.LinkProjects.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkProjects.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkProjects.Name = "LinkProjects";
			this.LinkProjects.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkProjects.Size = new System.Drawing.Size(250, 20);
			this.LinkProjects.Status = AvControls.Statuses.Satisfactory;
			this.LinkProjects.TabIndex = 42;
			this.LinkProjects.Text = "Projects";
			this.LinkProjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkProjects.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// _hangars
			// 
			this._hangars.AutoSize = true;
			this._hangars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._hangars.Extended = false;
			this._hangars.ItemsCollection = null;
			this._hangars.Location = new System.Drawing.Point(3, 140);
			this._hangars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._hangars.MaximumSize = new System.Drawing.Size(533, 0);
			this._hangars.Name = "_hangars";
			this._hangars.Size = new System.Drawing.Size(208, 42);
			this._hangars.TabIndex = 43;
#if SCAT
			this._hangars.Visible = false;
#endif

			// 
			// workStationCollectionControl1
			// 
			this.workStationCollectionControl1.AutoSize = true;
			this.workStationCollectionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.workStationCollectionControl1.Extended = false;
			this.workStationCollectionControl1.ItemsCollection = null;
			this.workStationCollectionControl1.Location = new System.Drawing.Point(3, 186);
			this.workStationCollectionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.workStationCollectionControl1.MaximumSize = new System.Drawing.Size(400, 0);
			this.workStationCollectionControl1.Name = "workStationCollectionControl1";
			this.workStationCollectionControl1.Size = new System.Drawing.Size(258, 42);
			this.workStationCollectionControl1.TabIndex = 44;
#if SCAT
			this.workStationCollectionControl1.Visible = false;
#endif
			// 
			// _poolReferenceContainer
			// 
			this._poolReferenceContainer.AutoSize = true;
			this._poolReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._poolReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._poolReferenceContainer.Caption = "POOL, Warranty";
			this._poolReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._poolReferenceContainer.Extended = false;
			this._poolReferenceContainer.Location = new System.Drawing.Point(3, 232);
			this._poolReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._poolReferenceContainer.Name = "_poolReferenceContainer";
			this._poolReferenceContainer.ReferenceLink = this.LinkPool;
			this._poolReferenceContainer.ReferenceLink02 = this.LinkWarranty;
			this._poolReferenceContainer.ReferenceLink03 = null;
			this._poolReferenceContainer.ReferenceLink04 = null;
			this._poolReferenceContainer.ReferenceLink05 = null;
			this._poolReferenceContainer.ReferenceLink06 = null;
			this._poolReferenceContainer.ReferenceLink07 = null;
			this._poolReferenceContainer.ReferenceLink08 = null;
			this._poolReferenceContainer.ReferenceLink09 = null;
			this._poolReferenceContainer.ReferenceLink10 = null;
			this._poolReferenceContainer.ReferenceLink11 = null;
			this._poolReferenceContainer.ReferenceLink12 = null;
			this._poolReferenceContainer.ReferenceLink13 = null;
			this._poolReferenceContainer.ReferenceLink14 = null;
			this._poolReferenceContainer.ReferenceLink15 = null;
			this._poolReferenceContainer.ReferenceLink16 = null;
			this._poolReferenceContainer.Size = new System.Drawing.Size(237, 42);
			this._poolReferenceContainer.TabIndex = 45;
			this._poolReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._poolReferenceContainer.Visible = false;
#endif
			// 
			// LinkPool
			// 
			this.LinkPool.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPool.Displayer = null;
			this.LinkPool.DisplayerText = null;
			this.LinkPool.Entity = null;
			this.LinkPool.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkPool.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPool.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPool.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPool.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPool.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPool.Location = new System.Drawing.Point(10, 0);
			this.LinkPool.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPool.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkPool.Name = "LinkPool";
			this.LinkPool.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPool.Size = new System.Drawing.Size(250, 20);
			this.LinkPool.Status = AvControls.Statuses.Satisfactory;
			this.LinkPool.TabIndex = 46;
			this.LinkPool.Text = "Pool";
			this.LinkPool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPool.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// LinkWarranty
			// 
			this.LinkWarranty.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkWarranty.Displayer = null;
			this.LinkWarranty.DisplayerText = null;
			this.LinkWarranty.Entity = null;
			this.LinkWarranty.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkWarranty.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkWarranty.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkWarranty.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkWarranty.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkWarranty.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkWarranty.Location = new System.Drawing.Point(270, 0);
			this.LinkWarranty.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkWarranty.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkWarranty.Name = "LinkWarranty";
			this.LinkWarranty.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkWarranty.Size = new System.Drawing.Size(250, 20);
			this.LinkWarranty.Status = AvControls.Statuses.Satisfactory;
			this.LinkWarranty.TabIndex = 47;
			this.LinkWarranty.Text = "Warranty";
			this.LinkWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkWarranty.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// _productsReferenceContainer
			// 
			this._productsReferenceContainer.AutoSize = true;
			this._productsReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._productsReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._productsReferenceContainer.Caption = "Products";
			this._productsReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._productsReferenceContainer.Extended = false;
			this._productsReferenceContainer.Location = new System.Drawing.Point(3, 278);
			this._productsReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._productsReferenceContainer.Name = "_productsReferenceContainer";
			this._productsReferenceContainer.ReferenceLink = this.LinkComponentModels;
			this._productsReferenceContainer.ReferenceLink02 = this.LinkProducts;
			this._productsReferenceContainer.ReferenceLink03 = this.LinkAllProducts;
			this._productsReferenceContainer.ReferenceLink04 = null;
			this._productsReferenceContainer.ReferenceLink05 = null;
			this._productsReferenceContainer.ReferenceLink06 = null;
			this._productsReferenceContainer.ReferenceLink07 = null;
			this._productsReferenceContainer.ReferenceLink08 = null;
			this._productsReferenceContainer.ReferenceLink09 = null;
			this._productsReferenceContainer.ReferenceLink10 = null;
			this._productsReferenceContainer.ReferenceLink11 = null;
			this._productsReferenceContainer.ReferenceLink12 = null;
			this._productsReferenceContainer.ReferenceLink13 = null;
			this._productsReferenceContainer.ReferenceLink14 = null;
			this._productsReferenceContainer.ReferenceLink15 = null;
			this._productsReferenceContainer.ReferenceLink16 = null;
			this._productsReferenceContainer.Size = new System.Drawing.Size(154, 42);
			this._productsReferenceContainer.TabIndex = 48;
			this._productsReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
#if SCAT
			this._productsReferenceContainer.Visible = false;
#endif
			// 
			// LinkComponentModels
			// 
			this.LinkComponentModels.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentModels.Displayer = null;
			this.LinkComponentModels.DisplayerText = null;
			this.LinkComponentModels.Entity = null;
			this.LinkComponentModels.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkComponentModels.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentModels.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentModels.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentModels.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentModels.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentModels.Location = new System.Drawing.Point(10, 0);
			this.LinkComponentModels.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentModels.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkComponentModels.Name = "LinkComponentModels";
			this.LinkComponentModels.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentModels.Size = new System.Drawing.Size(250, 20);
			this.LinkComponentModels.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentModels.TabIndex = 49;
			this.LinkComponentModels.Text = "Component Models";
			this.LinkComponentModels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentModels.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentModels.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentModelsDisplayerRequested);
			// 
			// LinkProducts
			// 
			this.LinkProducts.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProducts.Displayer = null;
			this.LinkProducts.DisplayerText = null;
			this.LinkProducts.Entity = null;
			this.LinkProducts.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkProducts.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProducts.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkProducts.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkProducts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkProducts.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkProducts.Location = new System.Drawing.Point(270, 0);
			this.LinkProducts.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkProducts.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkProducts.Name = "LinkProducts";
			this.LinkProducts.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkProducts.Size = new System.Drawing.Size(250, 20);
			this.LinkProducts.Status = AvControls.Statuses.Satisfactory;
			this.LinkProducts.TabIndex = 50;
			this.LinkProducts.Text = "Equipment and Materials";
			this.LinkProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkProducts.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkProducts.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkProductsDisplayerRequested);
			// 
			// LinkProducts
			// 
			this.LinkAllProducts.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAllProducts.Displayer = null;
			this.LinkAllProducts.DisplayerText = null;
			this.LinkAllProducts.Entity = null;
			this.LinkAllProducts.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAllProducts.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAllProducts.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAllProducts.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAllProducts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAllProducts.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAllProducts.Location = new System.Drawing.Point(270, 0);
			this.LinkAllProducts.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAllProducts.MaximumSize = new System.Drawing.Size(250, 20);
			this.LinkAllProducts.Name = "LinkAllProducts";
			this.LinkAllProducts.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAllProducts.Size = new System.Drawing.Size(250, 20);
			this.LinkAllProducts.Status = AvControls.Statuses.Satisfactory;
			this.LinkAllProducts.TabIndex = 50;
			this.LinkAllProducts.Text = "Products";
			this.LinkAllProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAllProducts.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAllProducts.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAllProductsDisplayerRequested);
			// 
			// _purchaseReferenceContainer
			// 
#if DEMO
			this._purchaseReferenceContainer.ReferenceLink04 = this.LinkSuppliers;
#else
			this._purchaseReferenceContainer.ReferenceLink = this.LinkOrders;
			this._purchaseReferenceContainer.ReferenceLink = this.LinkInitialOrders;
			this._purchaseReferenceContainer.ReferenceLink03 = this.LinkQuotationOrders;
			this._purchaseReferenceContainer.ReferenceLink02 = this.LinkPurchaseOrders;
			this._purchaseReferenceContainer.ReferenceLink08 = this.LinkRequestOffers;
			this._purchaseReferenceContainer.ReferenceLink09 = this.LinkPurchaseStatus;
			this._purchaseReferenceContainer.ReferenceLink06 = this.LinkDocumentPurchase;
			this._purchaseReferenceContainer.ReferenceLink07 = this.LinkInvoice;
			this._purchaseReferenceContainer.ReferenceLink04 = this.LinkSuppliers;
			this._purchaseReferenceContainer.ReferenceLink05 = this.LinkSupplierComponents;
#endif
			this._purchaseReferenceContainer.AutoSize = true;
			this._purchaseReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._purchaseReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._purchaseReferenceContainer.Caption = "Purchase";
			this._purchaseReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._purchaseReferenceContainer.Extended = false;
			this._purchaseReferenceContainer.Location = new System.Drawing.Point(3, 324);
			this._purchaseReferenceContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._purchaseReferenceContainer.Name = "_purchaseReferenceContainer";
			
			
			this._purchaseReferenceContainer.ReferenceLink10 = null;
			this._purchaseReferenceContainer.ReferenceLink11 = null;
			this._purchaseReferenceContainer.ReferenceLink12 = null;
			this._purchaseReferenceContainer.ReferenceLink13 = null;
			this._purchaseReferenceContainer.ReferenceLink14 = null;
			this._purchaseReferenceContainer.ReferenceLink15 = null;
			this._purchaseReferenceContainer.ReferenceLink16 = null;
			this._purchaseReferenceContainer.Size = new System.Drawing.Size(158, 42);
			this._purchaseReferenceContainer.TabIndex = 51;
			this._purchaseReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
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
			this.LinkOrders.DisplayerRequested += LinkOrders_DisplayerRequested;
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
			this.LinkInitialOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkInitialOrderDisplayerRequested);
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
			this.LinkPurchaseOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPurchaseOrderDisplayerRequested);
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
			this.LinkRequestOffers.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRequestOffersDisplayerRequested);
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
			this.LinkPurchaseStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLinkPurchaseStatusDisplayerRequested);
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
			this.LinkQuotationOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkQuotationOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRequestForQuotationDisplayerRequested);
			// 
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
			this.LinkDocumentPurchase.DisplayerRequested += LinkDocumentPurchase_DisplayerRequested;
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
			this.LinkInvoice.DisplayerRequested += LinkInvoice_DisplayerRequested;
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
			this.LinkSuppliers.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSupplierDisplayerRequested);

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
			this.LinkSupplierComponents.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSupplierComponentsDisplayerRequested);

			// 
			// _stores
			// 
			this._stores.AutoSize = true;
			this._stores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._stores.Extended = false;
			this._stores.ItemsCollection = null;
			this._stores.Location = new System.Drawing.Point(3, 370);
			this._stores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._stores.MaximumSize = new System.Drawing.Size(533, 0);
			this._stores.Name = "_stores";
			this._stores.Size = new System.Drawing.Size(208, 42);
			this._stores.TabIndex = 56;
			// 
			// _workShops
			// 
			this._workShops.AutoSize = true;
			this._workShops.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._workShops.Extended = false;
			this._workShops.ItemsCollection = null;
			this._workShops.Location = new System.Drawing.Point(3, 416);
			this._workShops.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._workShops.MaximumSize = new System.Drawing.Size(533, 0);
			this._workShops.Name = "_workShops";
			this._workShops.Size = new System.Drawing.Size(208, 42);
			this._workShops.TabIndex = 57;
#if SCAT
			this._workShops.Visible = false;
#endif
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
		private CAS.UI.UIControls.AircraftsControls.VehicleCollectionControl _vehicles;
		private CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference _operatorInfoReference;
		private CAS.UI.UIControls.StoresControls.StoreCollectionControl _stores;
		private HangarCollectionControl _hangars;
		private CAS.UI.UIControls.StoresControls.WorkShopCollectionControl _workShops;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _documentsReferenceContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _operationalReferenceContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _personnelReferenceContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _reliabilityReferenceContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _purchaseReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _qualityAssuranceReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _exportContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _adminContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _settingContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _smsReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _mccReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _programPlanningAndControlReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _cabinInteriorReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _comercialReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _developmentReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _poolReferenceContainer;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer _productsReferenceContainer;
		private AircraftsControls.AircraftDemoCollectionControl _aircrafts;
		private StoresControls.WorkStationCollectionControl workStationCollectionControl1;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRigestry;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportMonthly;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Users;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportATLB;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Activity;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Purchase;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel QuotationSupp;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel mail;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRecords;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkInternalDocuments;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkNomenclatures;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPersonnel;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSpecializations;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAircraftStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsPlanOPS;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkUnFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSchedulePeriod;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkTechnicalTraining;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRegularityTraining;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPrintIdCard;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkTesting;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDepartments;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCR;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkProceduresAndProcesses;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkQualityAudits;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRequirements;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkTrainingsAndQualification;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEvets;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEventCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEventClasses;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkContractMaintenanceService;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningBriefReport;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningForecast;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningTechnicalLibrary;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningTechnicalRecords;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningWorkPackages;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPlanningWorkPackagesLS;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkGroundEquipment;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPool;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkITService;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkProjects;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkWarranty;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentModels;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkProducts;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAllProducts;
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
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkMcc;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCommercialWorkOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCommercialRequests;


		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkGeneral;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkOccurences;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEvent;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSystem;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponents;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEngines;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDefects;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDefferedDefects;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkReportBuilder;
	}
}
