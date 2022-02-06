using CAS.UI.UICAAControls.Airacraft;
using CAS.UI.UICAAControls.CurrentOperator;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UIControls.HangarControls;
using CAS.UI.UIControls.ReferenceControls;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UICAAControls
{
	partial class CurrentOperatorSymmaryCAADemoScreen
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
			this._operatorInfoReference = new CAAOperatorInfoReference();
            _aircrafts = new AllAircraftsDemoCollectionControl();
            this._documentsReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkRigestry = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ExportMonthly = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel(true);
			this.Users = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Activity = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Aircraft = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.Store = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
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
			this.LinkAudit = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRoutineAudit = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
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
            this._adminContainer.Visible = GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin ||
                                           GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.OperatorAdmin;
			// 
			// _settingContainer
			// 
			this._settingContainer.AutoSize = true;
			this._settingContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._settingContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._settingContainer.Caption = "Setting";
			this._settingContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this._settingContainer.Extended = true;
			this._settingContainer.Location = new System.Drawing.Point(3, 232);
			this._settingContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._settingContainer.Name = "_settingContainer";
			this._settingContainer.ReferenceLink = this.Aircraft;
            this._settingContainer.ReferenceLink03 = this.Store;
			this._settingContainer.ReferenceLink04 = null;
			this._settingContainer.ReferenceLink05 = this.LinkDepartments;
			this._settingContainer.ReferenceLink06 = this.LinkSpecializations;
			this._settingContainer.ReferenceLink07 = this.LinkNomenclatures;
            this._settingContainer.ReferenceLink08 = this.LinkFindingLevels;
			this._settingContainer.ReferenceLink09 = this.LinkRootCause;
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
            this._settingContainer.Visible =GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin ||
                                            GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.OperatorAdmin;
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
			// QuotationSupp
			// 
			this.Store.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Store.Displayer = null;
			this.Store.DisplayerText = null;
			this.Store.Entity = null;
			this.Store.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Store.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Store.ImageBackColor = System.Drawing.Color.Transparent;
			this.Store.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Store.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.Store.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.Store.Location = new System.Drawing.Point(10, 0);
			this.Store.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Store.Name = "Store";
			this.Store.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.Store.Size = new System.Drawing.Size(188, 20);
			this.Store.Status = AvControls.Statuses.Satisfactory;
			this.Store.TabIndex = 2;
			this.Store.Text = "Add Store";
			this.Store.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Store.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.Store.DisplayerRequested += Store_Click;
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
			this._personnelReferenceContainer.ReferenceLink02 = null;
			this._personnelReferenceContainer.ReferenceLink03 = null;
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
			this.LinkPersonnel.Visible = GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin ||
                                         GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.OperatorAdmin;
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
			this._qualityAssuranceReferenceContainer.ReferenceLink02 = this.LinkRoutineAudit;
			this._qualityAssuranceReferenceContainer.ReferenceLink03 = this.LinkAudit;
			this._qualityAssuranceReferenceContainer.ReferenceLink04 = null;
			this._qualityAssuranceReferenceContainer.ReferenceLink05 = null;
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
			this.LinkAudit.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAudit.Displayer = null;
			this.LinkAudit.DisplayerText = null;
			this.LinkAudit.Entity = null;
			this.LinkAudit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAudit.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAudit.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAudit.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAudit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAudit.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAudit.Location = new System.Drawing.Point(10, 0);
			this.LinkAudit.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAudit.Name = "LinkAudit";
			this.LinkAudit.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAudit.Size = new System.Drawing.Size(188, 20);
			this.LinkAudit.Status = AvControls.Statuses.Satisfactory;
			this.LinkAudit.TabIndex = 16;
			this.LinkAudit.Text = "Audit Operator";
			this.LinkAudit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAudit.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.LinkAudit.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAuditDisplayerRequested);
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
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoScroll = true;
			this.flowLayoutPanelAircrafts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelAircrafts.Controls.Add(this._aircrafts);
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
        private AllAircraftsDemoCollectionControl _aircrafts;
		private CAAOperatorInfoReference _operatorInfoReference;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _documentsReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _personnelReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _qualityAssuranceReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _adminContainer;
		private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _settingContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _certificationReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _oversightReferenceContainer;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRigestry;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportMonthly;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Users;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel ExportATLB;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Activity;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Aircraft;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel Store;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRecords;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkNomenclatures;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFindingLevels;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRootCause;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPersonnel;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSpecializations;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAircraftStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsPlanOPS;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkUnFligthsSchedule;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSchedulePeriod;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDepartments;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCheckList;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRoutineAudit;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAudit;
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
