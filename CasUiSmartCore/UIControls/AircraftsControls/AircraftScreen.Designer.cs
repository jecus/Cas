using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.AircraftsControls
{
	partial class AircraftScreen
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

			if(disposing)
			{
				if(this.headerControl != null)
					this.headerControl.ReloadButtonClick -= new System.EventHandler(this.HeaderControlButtonReloadClick);
			}
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AircraftScreen));
			this.flowLayoutPanelReferences = new System.Windows.Forms.FlowLayoutPanel();
			this.ContainerGD = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkAircraftGeneralData = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAircraftSummary = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDocuments = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerComponents = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkAvionxInventory = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponentStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponentStatusHT = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponentStatusOCCM = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponentTracking = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkComponentChangeReport = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkLandingGearStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkLLPCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerDirectives = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkADStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkADStatusAF = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkADStatusAP = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkCPCPStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkEOStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkModifications = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkOoPStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSBStatus = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerDiscrepancies = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkDiscrepancies = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDamageCharts = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDamages = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDeferredCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkDeferredItems = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerMP = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkMaintenanceProgram = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkMTOP = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkLDND = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkMaintenanceTasks = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkNonRoutineJobsCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkNonRoutineJobs = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerPlanning = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkATLBEvent = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkATLBs = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRegisterFlight = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkRegisterFlightLight = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkAverageUtilization = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkForecast = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkForecastMtop = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkForecastMtopOld = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkForecastKits = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkMonthlyUtilization = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkOil = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkWorkPackages = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerPurchase = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkEquipmentAndMaterials = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkInitialOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkPurchaseOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkQuotationOrders = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.ContainerSMS = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
			this.LinkSMSEvents = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSMSEventsCategories = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSMSEventsClasses = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.LinkSMSEventsTypes = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._baseComponentButtons = new BaseComponentButtonsControl();
			this.headerControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanelReferences.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(3);
			this.headerControl.Size = new System.Drawing.Size(711, 54);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this._baseComponentButtons);
			this.panel1.Controls.Add(this.flowLayoutPanelReferences);
			this.panel1.Location = new System.Drawing.Point(0, 58);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(715, 278);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanelReferences
			// 
			this.flowLayoutPanelReferences.AutoScroll = true;
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerGD);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerComponents);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerDirectives);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerDiscrepancies);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerMP);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerPlanning);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerPurchase);
			this.flowLayoutPanelReferences.Controls.Add(this.ContainerSMS);
			this.flowLayoutPanelReferences.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanelReferences.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelReferences.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelReferences.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelReferences.MinimumSize = new System.Drawing.Size(392, 325);
			this.flowLayoutPanelReferences.Name = "flowLayoutPanelReferences";
			this.flowLayoutPanelReferences.Size = new System.Drawing.Size(392, 556);
			this.flowLayoutPanelReferences.TabIndex = 1;
			this.flowLayoutPanelReferences.WrapContents = false;
			// 
			// ContainerGD
			// 
			this.ContainerGD.AutoSize = true;
			this.ContainerGD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerGD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerGD.Caption = "General Information";
			this.ContainerGD.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerGD.Extended = true;
			this.ContainerGD.Location = new System.Drawing.Point(2, 2);
			this.ContainerGD.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerGD.Name = "ContainerGD";
			this.ContainerGD.ReferenceLink = this.LinkAircraftGeneralData;
			this.ContainerGD.ReferenceLink02 = this.LinkAircraftSummary;
			this.ContainerGD.ReferenceLink03 = this.LinkDocuments;
			this.ContainerGD.ReferenceLink04 = null;
			this.ContainerGD.ReferenceLink05 = null;
			this.ContainerGD.ReferenceLink06 = null;
			this.ContainerGD.ReferenceLink07 = null;
			this.ContainerGD.ReferenceLink08 = null;
			this.ContainerGD.ReferenceLink09 = null;
			this.ContainerGD.ReferenceLink10 = null;
			this.ContainerGD.ReferenceLink11 = null;
			this.ContainerGD.ReferenceLink12 = null;
			this.ContainerGD.ReferenceLink13 = null;
			this.ContainerGD.ReferenceLink14 = null;
			this.ContainerGD.ReferenceLink15 = null;
			this.ContainerGD.ReferenceLink16 = null;
			this.ContainerGD.Size = new System.Drawing.Size(283, 106);
			this.ContainerGD.TabIndex = 6;
			this.ContainerGD.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerGD.UpperLeftIcon")));
			// 
			// LinkAircraftGeneralData
			// 
			this.LinkAircraftGeneralData.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftGeneralData.Displayer = null;
			this.LinkAircraftGeneralData.DisplayerText = null;
			this.LinkAircraftGeneralData.Entity = null;
			this.LinkAircraftGeneralData.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAircraftGeneralData.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftGeneralData.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAircraftGeneralData.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAircraftGeneralData.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftGeneralData.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAircraftGeneralData.Location = new System.Drawing.Point(10, 0);
			this.LinkAircraftGeneralData.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAircraftGeneralData.Name = "LinkAircraftGeneralData";
			this.LinkAircraftGeneralData.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAircraftGeneralData.Size = new System.Drawing.Size(188, 20);
			this.LinkAircraftGeneralData.Status = AvControls.Statuses.Satisfactory;
			this.LinkAircraftGeneralData.TabIndex = 8;
			this.LinkAircraftGeneralData.Text = "Aircraft General Data";
			this.LinkAircraftGeneralData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAircraftGeneralData.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAircraftGeneralData.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAircraftGeneralDataDisplayerRequested);
			// 
			// LinkAircraftSummary
			// 
			this.LinkAircraftSummary.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftSummary.Displayer = null;
			this.LinkAircraftSummary.DisplayerText = null;
			this.LinkAircraftSummary.Entity = null;
			this.LinkAircraftSummary.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkAircraftSummary.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftSummary.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAircraftSummary.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAircraftSummary.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAircraftSummary.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAircraftSummary.Location = new System.Drawing.Point(10, 20);
			this.LinkAircraftSummary.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAircraftSummary.Name = "LinkAircraftSummary";
			this.LinkAircraftSummary.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAircraftSummary.Size = new System.Drawing.Size(188, 20);
			this.LinkAircraftSummary.Status = AvControls.Statuses.Satisfactory;
			this.LinkAircraftSummary.TabIndex = 8;
			this.LinkAircraftSummary.Text = "Aircraft Summary";
			this.LinkAircraftSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAircraftSummary.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAircraftSummary.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAircraftSummaryDisplayerRequested);
			// 
			// LinkDocuments
			// 
			this.LinkDocuments.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDocuments.Displayer = null;
			this.LinkDocuments.DisplayerText = null;
			this.LinkDocuments.Entity = null;
			this.LinkDocuments.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDocuments.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDocuments.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDocuments.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDocuments.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDocuments.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDocuments.Location = new System.Drawing.Point(10, 40);
			this.LinkDocuments.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDocuments.Name = "LinkDocuments";
			this.LinkDocuments.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDocuments.Size = new System.Drawing.Size(188, 20);
			this.LinkDocuments.Status = AvControls.Statuses.Satisfactory;
			this.LinkDocuments.TabIndex = 3;
			this.LinkDocuments.Text = "Documents";
			this.LinkDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDocuments.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDocuments.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDocumentsDisplayerRequested);
			// 
			// ContainerComponents
			// 
			this.ContainerComponents.AutoSize = true;
			this.ContainerComponents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerComponents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerComponents.Caption = "Components";
			this.ContainerComponents.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerComponents.Extended = false;
			this.ContainerComponents.Location = new System.Drawing.Point(2, 112);
			this.ContainerComponents.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerComponents.Name = "ContainerComponents";
			this.ContainerComponents.ReferenceLink = this.LinkAvionxInventory;
			this.ContainerComponents.ReferenceLink02 = this.LinkComponentStatus;
			this.ContainerComponents.ReferenceLink03 = this.LinkComponentStatusHT;
			this.ContainerComponents.ReferenceLink04 = this.LinkComponentStatusOCCM;
			this.ContainerComponents.ReferenceLink05 = this.LinkComponentTracking;
			this.ContainerComponents.ReferenceLink06 = this.LinkComponentChangeReport;
			this.ContainerComponents.ReferenceLink07 = this.LinkLandingGearStatus;
			this.ContainerComponents.ReferenceLink08 = this.LinkLLPCategories;
			this.ContainerComponents.ReferenceLink09 = null;
			this.ContainerComponents.ReferenceLink10 = null;
			this.ContainerComponents.ReferenceLink11 = null;
			this.ContainerComponents.ReferenceLink12 = null;
			this.ContainerComponents.ReferenceLink13 = null;
			this.ContainerComponents.ReferenceLink14 = null;
			this.ContainerComponents.ReferenceLink15 = null;
			this.ContainerComponents.ReferenceLink16 = null;
			this.ContainerComponents.Size = new System.Drawing.Size(197, 42);
			this.ContainerComponents.TabIndex = 7;
			this.ContainerComponents.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerComponents.UpperLeftIcon")));
			// 
			// LinkAvionxInventory
			// 
			this.LinkAvionxInventory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAvionxInventory.Displayer = null;
			this.LinkAvionxInventory.DisplayerText = null;
			this.LinkAvionxInventory.Entity = null;
			this.LinkAvionxInventory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAvionxInventory.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkAvionxInventory.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAvionxInventory.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAvionxInventory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAvionxInventory.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAvionxInventory.Location = new System.Drawing.Point(10, 0);
			this.LinkAvionxInventory.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAvionxInventory.Name = "LinkAvionxInventory";
			this.LinkAvionxInventory.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAvionxInventory.Size = new System.Drawing.Size(188, 20);
			this.LinkAvionxInventory.Status = AvControls.Statuses.Satisfactory;
			this.LinkAvionxInventory.TabIndex = 8;
			this.LinkAvionxInventory.Text = "Avionics Inventory";
			this.LinkAvionxInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAvionxInventory.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAvionxInventory.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAvionxInventoryDisplayerRequested);
			// 
			// LinkComponentStatus
			// 
			this.LinkComponentStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatus.Displayer = null;
			this.LinkComponentStatus.DisplayerText = null;
			this.LinkComponentStatus.Entity = null;
			this.LinkComponentStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkComponentStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentStatus.Location = new System.Drawing.Point(208, 0);
			this.LinkComponentStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentStatus.Name = "LinkComponentStatus";
			this.LinkComponentStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkComponentStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentStatus.TabIndex = 9;
			this.LinkComponentStatus.Text = "Component Status All";
			this.LinkComponentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentStatusDisplayerRequested);
			// 
			// LinkComponentStatusHT
			// 
			this.LinkComponentStatusHT.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatusHT.Displayer = null;
			this.LinkComponentStatusHT.DisplayerText = null;
			this.LinkComponentStatusHT.Entity = null;
			this.LinkComponentStatusHT.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatusHT.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkComponentStatusHT.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentStatusHT.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentStatusHT.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatusHT.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentStatusHT.Location = new System.Drawing.Point(406, 0);
			this.LinkComponentStatusHT.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentStatusHT.Name = "LinkComponentStatusHT";
			this.LinkComponentStatusHT.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentStatusHT.Size = new System.Drawing.Size(188, 20);
			this.LinkComponentStatusHT.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentStatusHT.TabIndex = 10;
			this.LinkComponentStatusHT.Text = "Component Status HT";
			this.LinkComponentStatusHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentStatusHT.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatusHT.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentStatusHtDisplayerRequested);
			// 
			// LinkComponentStatusOCCM
			// 
			this.LinkComponentStatusOCCM.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatusOCCM.Displayer = null;
			this.LinkComponentStatusOCCM.DisplayerText = null;
			this.LinkComponentStatusOCCM.Entity = null;
			this.LinkComponentStatusOCCM.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatusOCCM.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkComponentStatusOCCM.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentStatusOCCM.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentStatusOCCM.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentStatusOCCM.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentStatusOCCM.Location = new System.Drawing.Point(604, 0);
			this.LinkComponentStatusOCCM.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentStatusOCCM.Name = "LinkComponentStatusOCCM";
			this.LinkComponentStatusOCCM.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentStatusOCCM.Size = new System.Drawing.Size(250, 20);
			this.LinkComponentStatusOCCM.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentStatusOCCM.TabIndex = 11;
			this.LinkComponentStatusOCCM.Text = "Component Status OC/CM";
			this.LinkComponentStatusOCCM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentStatusOCCM.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentStatusOCCM.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentStatusOCCMDisplayerRequested);
			// 
			// LinkComponentTracking
			// 
			this.LinkComponentTracking.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentTracking.Displayer = null;
			this.LinkComponentTracking.DisplayerText = null;
			this.LinkComponentTracking.Entity = null;
			this.LinkComponentTracking.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentTracking.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkComponentTracking.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentTracking.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentTracking.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentTracking.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentTracking.Location = new System.Drawing.Point(864, 0);
			this.LinkComponentTracking.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentTracking.Name = "LinkComponentTracking";
			this.LinkComponentTracking.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentTracking.Size = new System.Drawing.Size(250, 20);
			this.LinkComponentTracking.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentTracking.TabIndex = 20;
			this.LinkComponentTracking.Text = "Component Tracking";
			this.LinkComponentTracking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentTracking.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentTracking.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentChangeReportDisplayerRequested);
			// 
			// LinkComponentChangeReport
			// 
			this.LinkComponentChangeReport.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentChangeReport.Displayer = null;
			this.LinkComponentChangeReport.DisplayerText = null;
			this.LinkComponentChangeReport.Entity = null;
			this.LinkComponentChangeReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentChangeReport.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkComponentChangeReport.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkComponentChangeReport.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkComponentChangeReport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkComponentChangeReport.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkComponentChangeReport.Location = new System.Drawing.Point(864, 0);
			this.LinkComponentChangeReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkComponentChangeReport.Name = "LinkComponentChangeReport";
			this.LinkComponentChangeReport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkComponentChangeReport.Size = new System.Drawing.Size(250, 20);
			this.LinkComponentChangeReport.Status = AvControls.Statuses.Satisfactory;
			this.LinkComponentChangeReport.TabIndex = 20;
			this.LinkComponentChangeReport.Text = "Component Change Report";
			this.LinkComponentChangeReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkComponentChangeReport.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkComponentChangeReport.DisplayerRequested += LinkComponentChangeReport_DisplayerRequested;
			// 
			// LinkLandingGearStatus
			// 
			this.LinkLandingGearStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLandingGearStatus.Displayer = null;
			this.LinkLandingGearStatus.DisplayerText = null;
			this.LinkLandingGearStatus.Entity = null;
			this.LinkLandingGearStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLandingGearStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkLandingGearStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkLandingGearStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkLandingGearStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLandingGearStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkLandingGearStatus.Location = new System.Drawing.Point(1124, 0);
			this.LinkLandingGearStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkLandingGearStatus.Name = "LinkLandingGearStatus";
			this.LinkLandingGearStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkLandingGearStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkLandingGearStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkLandingGearStatus.TabIndex = 21;
			this.LinkLandingGearStatus.Text = "Landing Gear Status";
			this.LinkLandingGearStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkLandingGearStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLandingGearStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLandingGearStatusDisplayerRequested);
			// 
			// LinkLLPCategories
			// 
			this.LinkLLPCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLLPCategories.Displayer = null;
			this.LinkLLPCategories.DisplayerText = null;
			this.LinkLLPCategories.Entity = null;
			this.LinkLLPCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLLPCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkLLPCategories.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkLLPCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkLLPCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLLPCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkLLPCategories.Location = new System.Drawing.Point(1322, 0);
			this.LinkLLPCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkLLPCategories.Name = "LinkLLPCategories";
			this.LinkLLPCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkLLPCategories.Size = new System.Drawing.Size(250, 20);
			this.LinkLLPCategories.TabIndex = 22;
			this.LinkLLPCategories.Text = "LLP Life Limit Categories";
			this.LinkLLPCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkLLPCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLLPCategories.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLLPCategoriesDisplayerRequested);
			// 
			// ContainerDirectives
			// 
			this.ContainerDirectives.AutoSize = true;
			this.ContainerDirectives.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerDirectives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerDirectives.Caption = "Directives";
			this.ContainerDirectives.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerDirectives.Extended = false;
			this.ContainerDirectives.Location = new System.Drawing.Point(2, 158);
			this.ContainerDirectives.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerDirectives.Name = "ContainerDirectives";
			this.ContainerDirectives.ReferenceLink = this.LinkADStatus;
			this.ContainerDirectives.ReferenceLink02 = this.LinkADStatusAF;
			this.ContainerDirectives.ReferenceLink03 = this.LinkADStatusAP;
			this.ContainerDirectives.ReferenceLink04 = this.LinkCPCPStatus;
			this.ContainerDirectives.ReferenceLink05 = this.LinkEOStatus;
			this.ContainerDirectives.ReferenceLink06 = this.LinkModifications;
			this.ContainerDirectives.ReferenceLink07 = this.LinkOoPStatus;
			this.ContainerDirectives.ReferenceLink08 = this.LinkSBStatus;
			this.ContainerDirectives.ReferenceLink09 = null;
			this.ContainerDirectives.ReferenceLink10 = null;
			this.ContainerDirectives.ReferenceLink11 = null;
			this.ContainerDirectives.ReferenceLink12 = null;
			this.ContainerDirectives.ReferenceLink13 = null;
			this.ContainerDirectives.ReferenceLink14 = null;
			this.ContainerDirectives.ReferenceLink15 = null;
			this.ContainerDirectives.ReferenceLink16 = null;
			this.ContainerDirectives.Size = new System.Drawing.Size(168, 42);
			this.ContainerDirectives.TabIndex = 17;
			this.ContainerDirectives.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerDirectives.UpperLeftIcon")));
			// 
			// LinkADStatus
			// 
			this.LinkADStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatus.Displayer = null;
			this.LinkADStatus.DisplayerText = null;
			this.LinkADStatus.Entity = null;
			this.LinkADStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkADStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkADStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkADStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkADStatus.Location = new System.Drawing.Point(10, 0);
			this.LinkADStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkADStatus.Name = "LinkADStatus";
			this.LinkADStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkADStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkADStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkADStatus.TabIndex = 0;
			this.LinkADStatus.Text = "AD Status All";
			this.LinkADStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkADStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkADStatusDisplayerRequested);
			// 
			// LinkADStatusAF
			// 
			this.LinkADStatusAF.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatusAF.Displayer = null;
			this.LinkADStatusAF.DisplayerText = null;
			this.LinkADStatusAF.Entity = null;
			this.LinkADStatusAF.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatusAF.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkADStatusAF.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkADStatusAF.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkADStatusAF.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatusAF.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkADStatusAF.Location = new System.Drawing.Point(208, 0);
			this.LinkADStatusAF.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkADStatusAF.Name = "LinkADStatusAF";
			this.LinkADStatusAF.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkADStatusAF.Size = new System.Drawing.Size(188, 20);
			this.LinkADStatusAF.Status = AvControls.Statuses.Satisfactory;
			this.LinkADStatusAF.TabIndex = 12;
			this.LinkADStatusAF.Text = "AD Status AF";
			this.LinkADStatusAF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkADStatusAF.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatusAF.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkADStatusAFDisplayerRequested);
			// 
			// LinkADStatusAP
			// 
			this.LinkADStatusAP.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatusAP.Displayer = null;
			this.LinkADStatusAP.DisplayerText = null;
			this.LinkADStatusAP.Entity = null;
			this.LinkADStatusAP.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatusAP.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkADStatusAP.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkADStatusAP.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkADStatusAP.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkADStatusAP.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkADStatusAP.Location = new System.Drawing.Point(406, 0);
			this.LinkADStatusAP.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkADStatusAP.Name = "LinkADStatusAP";
			this.LinkADStatusAP.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkADStatusAP.Size = new System.Drawing.Size(188, 20);
			this.LinkADStatusAP.Status = AvControls.Statuses.Satisfactory;
			this.LinkADStatusAP.TabIndex = 13;
			this.LinkADStatusAP.Text = "AD Status AP";
			this.LinkADStatusAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkADStatusAP.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkADStatusAP.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkADStatusAPDisplayerRequested);
			// 
			// LinkCPCPStatus
			// 
			this.LinkCPCPStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCPCPStatus.Displayer = null;
			this.LinkCPCPStatus.DisplayerText = null;
			this.LinkCPCPStatus.Entity = null;
			this.LinkCPCPStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkCPCPStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkCPCPStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkCPCPStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkCPCPStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkCPCPStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkCPCPStatus.Location = new System.Drawing.Point(604, 0);
			this.LinkCPCPStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkCPCPStatus.Name = "LinkCPCPStatus";
			this.LinkCPCPStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkCPCPStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkCPCPStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkCPCPStatus.TabIndex = 14;
			this.LinkCPCPStatus.Text = "CPCP Status";
			this.LinkCPCPStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkCPCPStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkCPCPStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkCPCPStatusDisplayerRequested);
			// 
			// LinkEOStatus
			// 
			this.LinkEOStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEOStatus.Displayer = null;
			this.LinkEOStatus.DisplayerText = null;
			this.LinkEOStatus.Entity = null;
			this.LinkEOStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkEOStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkEOStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEOStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEOStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEOStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEOStatus.Location = new System.Drawing.Point(802, 0);
			this.LinkEOStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEOStatus.Name = "LinkEOStatus";
			this.LinkEOStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEOStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkEOStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkEOStatus.TabIndex = 21;
			this.LinkEOStatus.Text = "EO Status";
			this.LinkEOStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEOStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkEOStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEOStatusDisplayerRequested);
			// 
			// LinkModifications
			// 
			this.LinkModifications.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkModifications.Displayer = null;
			this.LinkModifications.DisplayerText = null;
			this.LinkModifications.Entity = null;
			this.LinkModifications.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkModifications.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkModifications.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkModifications.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkModifications.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkModifications.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkModifications.Location = new System.Drawing.Point(1000, 0);
			this.LinkModifications.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkModifications.Name = "LinkModifications";
			this.LinkModifications.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkModifications.Size = new System.Drawing.Size(188, 20);
			this.LinkModifications.Status = AvControls.Statuses.Satisfactory;
			this.LinkModifications.TabIndex = 22;
			this.LinkModifications.Text = "Modifications Status";
			this.LinkModifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkModifications.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkModifications.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkModificationsDisplayerRequested);
			// 
			// LinkOoPStatus
			// 
			this.LinkOoPStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOoPStatus.Displayer = null;
			this.LinkOoPStatus.DisplayerText = null;
			this.LinkOoPStatus.Entity = null;
			this.LinkOoPStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkOoPStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkOoPStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkOoPStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkOoPStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOoPStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkOoPStatus.Location = new System.Drawing.Point(1198, 0);
			this.LinkOoPStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkOoPStatus.Name = "LinkOoPStatus";
			this.LinkOoPStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkOoPStatus.Size = new System.Drawing.Size(250, 20);
			this.LinkOoPStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkOoPStatus.TabIndex = 24;
			this.LinkOoPStatus.Text = "Out of Phase Requirements";
			this.LinkOoPStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkOoPStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkOoPStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkOoPStatusDisplayerRequested);
			// 
			// LinkSBStatus
			// 
			this.LinkSBStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSBStatus.Displayer = null;
			this.LinkSBStatus.DisplayerText = null;
			this.LinkSBStatus.Entity = null;
			this.LinkSBStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSBStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkSBStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSBStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSBStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSBStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSBStatus.Location = new System.Drawing.Point(1458, 0);
			this.LinkSBStatus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSBStatus.Name = "LinkSBStatus";
			this.LinkSBStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSBStatus.Size = new System.Drawing.Size(188, 20);
			this.LinkSBStatus.Status = AvControls.Statuses.Satisfactory;
			this.LinkSBStatus.TabIndex = 23;
			this.LinkSBStatus.Text = "SB Status";
			this.LinkSBStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSBStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSBStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSBStatusDisplayerRequested);
			// 
			// ContainerDiscrepancies
			// 
			this.ContainerDiscrepancies.AutoSize = true;
			this.ContainerDiscrepancies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerDiscrepancies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerDiscrepancies.Caption = "Discrepancies";
			this.ContainerDiscrepancies.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerDiscrepancies.Extended = false;
			this.ContainerDiscrepancies.Location = new System.Drawing.Point(2, 204);
			this.ContainerDiscrepancies.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerDiscrepancies.Name = "ContainerDiscrepancies";
			this.ContainerDiscrepancies.ReferenceLink = this.LinkDiscrepancies;
			this.ContainerDiscrepancies.ReferenceLink02 = this.LinkDamageCharts;
			this.ContainerDiscrepancies.ReferenceLink03 = this.LinkDamages;
			this.ContainerDiscrepancies.ReferenceLink04 = this.LinkDeferredCategories;
			this.ContainerDiscrepancies.ReferenceLink05 = this.LinkDeferredItems;
			this.ContainerDiscrepancies.ReferenceLink06 = null;
			this.ContainerDiscrepancies.ReferenceLink07 = null;
			this.ContainerDiscrepancies.ReferenceLink08 = null;
			this.ContainerDiscrepancies.ReferenceLink09 = null;
			this.ContainerDiscrepancies.ReferenceLink10 = null;
			this.ContainerDiscrepancies.ReferenceLink11 = null;
			this.ContainerDiscrepancies.ReferenceLink12 = null;
			this.ContainerDiscrepancies.ReferenceLink13 = null;
			this.ContainerDiscrepancies.ReferenceLink14 = null;
			this.ContainerDiscrepancies.ReferenceLink15 = null;
			this.ContainerDiscrepancies.ReferenceLink16 = null;
			this.ContainerDiscrepancies.Size = new System.Drawing.Size(209, 42);
			this.ContainerDiscrepancies.TabIndex = 17;
			this.ContainerDiscrepancies.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerDiscrepancies.UpperLeftIcon")));
			// 
			// LinkDiscrepancies
			// 
			this.LinkDiscrepancies.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDiscrepancies.Displayer = null;
			this.LinkDiscrepancies.DisplayerText = null;
			this.LinkDiscrepancies.Entity = null;
			this.LinkDiscrepancies.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDiscrepancies.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDiscrepancies.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDiscrepancies.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDiscrepancies.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDiscrepancies.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDiscrepancies.Location = new System.Drawing.Point(10, 0);
			this.LinkDiscrepancies.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDiscrepancies.Name = "LinkDiscrepancies";
			this.LinkDiscrepancies.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDiscrepancies.Size = new System.Drawing.Size(188, 20);
			this.LinkDiscrepancies.Status = AvControls.Statuses.Satisfactory;
			this.LinkDiscrepancies.TabIndex = 0;
			this.LinkDiscrepancies.Text = "Discrepancies Status All";
			this.LinkDiscrepancies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDiscrepancies.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDiscrepancies.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDiscrepanciesStatusDisplayerRequested);
			// 
			// LinkDamageCharts
			// 
			this.LinkDamageCharts.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDamageCharts.Displayer = null;
			this.LinkDamageCharts.DisplayerText = null;
			this.LinkDamageCharts.Entity = null;
			this.LinkDamageCharts.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDamageCharts.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDamageCharts.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDamageCharts.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDamageCharts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDamageCharts.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDamageCharts.Location = new System.Drawing.Point(208, 0);
			this.LinkDamageCharts.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDamageCharts.Name = "LinkDamageCharts";
			this.LinkDamageCharts.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDamageCharts.Size = new System.Drawing.Size(188, 20);
			this.LinkDamageCharts.TabIndex = 15;
			this.LinkDamageCharts.Text = "Damage Charts";
			this.LinkDamageCharts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDamageCharts.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDamageCharts.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDamageChartsDisplayerRequested);
			// 
			// LinkDamages
			// 
			this.LinkDamages.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDamages.Displayer = null;
			this.LinkDamages.DisplayerText = null;
			this.LinkDamages.Entity = null;
			this.LinkDamages.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDamages.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDamages.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDamages.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDamages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDamages.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDamages.Location = new System.Drawing.Point(406, 0);
			this.LinkDamages.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDamages.Name = "LinkDamages";
			this.LinkDamages.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDamages.Size = new System.Drawing.Size(188, 20);
			this.LinkDamages.Status = AvControls.Statuses.Satisfactory;
			this.LinkDamages.TabIndex = 16;
			this.LinkDamages.Text = "Damages";
			this.LinkDamages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDamages.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDamages.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDamagesDisplayerRequested);
			// 
			// LinkDeferredCategories
			// 
			this.LinkDeferredCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDeferredCategories.Displayer = null;
			this.LinkDeferredCategories.DisplayerText = null;
			this.LinkDeferredCategories.Entity = null;
			this.LinkDeferredCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDeferredCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDeferredCategories.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDeferredCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDeferredCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDeferredCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDeferredCategories.Location = new System.Drawing.Point(604, 0);
			this.LinkDeferredCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDeferredCategories.Name = "LinkDeferredCategories";
			this.LinkDeferredCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDeferredCategories.Size = new System.Drawing.Size(188, 20);
			this.LinkDeferredCategories.TabIndex = 19;
			this.LinkDeferredCategories.Text = "Deferred Categories";
			this.LinkDeferredCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDeferredCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDeferredCategories.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDeferredCategoriesDisplayerRequested);
			// 
			// LinkDeferredItems
			// 
			this.LinkDeferredItems.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDeferredItems.Displayer = null;
			this.LinkDeferredItems.DisplayerText = null;
			this.LinkDeferredItems.Entity = null;
			this.LinkDeferredItems.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDeferredItems.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkDeferredItems.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkDeferredItems.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkDeferredItems.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkDeferredItems.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkDeferredItems.Location = new System.Drawing.Point(802, 0);
			this.LinkDeferredItems.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkDeferredItems.Name = "LinkDeferredItems";
			this.LinkDeferredItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkDeferredItems.Size = new System.Drawing.Size(188, 20);
			this.LinkDeferredItems.Status = AvControls.Statuses.Satisfactory;
			this.LinkDeferredItems.TabIndex = 20;
			this.LinkDeferredItems.Text = "Deferred Items";
			this.LinkDeferredItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkDeferredItems.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkDeferredItems.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDeferredItemsDisplayerRequested);
			// 
			// ContainerMP
			// 
			this.ContainerMP.AutoSize = true;
			this.ContainerMP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerMP.Caption = "Maintenance Program";
			this.ContainerMP.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerMP.Extended = false;
			this.ContainerMP.Location = new System.Drawing.Point(2, 250);
			this.ContainerMP.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerMP.Name = "ContainerMP";
			this.ContainerMP.ReferenceLink = this.LinkMaintenanceProgram;
			this.ContainerMP.ReferenceLink02 = this.LinkMTOP;
			this.ContainerMP.ReferenceLink02 = this.LinkLDND;
			this.ContainerMP.ReferenceLink03 = this.LinkMaintenanceTasks;
			this.ContainerMP.ReferenceLink04 = this.LinkNonRoutineJobsCategories;
			this.ContainerMP.ReferenceLink05 = this.LinkNonRoutineJobs;
			this.ContainerMP.ReferenceLink06 = null;
			this.ContainerMP.ReferenceLink07 = null;
			this.ContainerMP.ReferenceLink08 = null;
			this.ContainerMP.ReferenceLink09 = null;
			this.ContainerMP.ReferenceLink10 = null;
			this.ContainerMP.ReferenceLink11 = null;
			this.ContainerMP.ReferenceLink12 = null;
			this.ContainerMP.ReferenceLink13 = null;
			this.ContainerMP.ReferenceLink14 = null;
			this.ContainerMP.ReferenceLink15 = null;
			this.ContainerMP.ReferenceLink16 = null;
			this.ContainerMP.Size = new System.Drawing.Size(299, 42);
			this.ContainerMP.TabIndex = 18;
			this.ContainerMP.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerMP.UpperLeftIcon")));
			// 
			// LinkMaintenanceProgram
			// 
			this.LinkMaintenanceProgram.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMaintenanceProgram.Displayer = null;
			this.LinkMaintenanceProgram.DisplayerText = null;
			this.LinkMaintenanceProgram.Entity = null;
			this.LinkMaintenanceProgram.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMaintenanceProgram.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkMaintenanceProgram.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkMaintenanceProgram.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkMaintenanceProgram.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMaintenanceProgram.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkMaintenanceProgram.Location = new System.Drawing.Point(10, 0);
			this.LinkMaintenanceProgram.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkMaintenanceProgram.Name = "LinkMaintenanceProgram";
			this.LinkMaintenanceProgram.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkMaintenanceProgram.Size = new System.Drawing.Size(188, 20);
			this.LinkMaintenanceProgram.Status = AvControls.Statuses.Satisfactory;
			this.LinkMaintenanceProgram.TabIndex = 8;
			this.LinkMaintenanceProgram.Text = "Maintenance Schedule";
			this.LinkMaintenanceProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkMaintenanceProgram.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMaintenanceProgram.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkMaintenanceProgramDisplayerRequested);
			// 
			// LinkMTOP
			// 
			this.LinkMTOP.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMTOP.Displayer = null;
			this.LinkMTOP.DisplayerText = null;
			this.LinkMTOP.Entity = null;
			this.LinkMTOP.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMTOP.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkMTOP.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkMTOP.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkMTOP.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMTOP.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkMTOP.Location = new System.Drawing.Point(10, 0);
			this.LinkMTOP.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkMTOP.Name = "LinkMaintenanceProgram";
			this.LinkMTOP.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkMTOP.Size = new System.Drawing.Size(188, 20);
			this.LinkMTOP.Status = AvControls.Statuses.Satisfactory;
			this.LinkMTOP.TabIndex = 8;
			this.LinkMTOP.Text = "MTOP";
			this.LinkMTOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkMTOP.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMTOP.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLinkMTOPDisplayerRequested);
			// 
			// LinkMTOP
			// 
			this.LinkLDND.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLDND.Displayer = null;
			this.LinkLDND.DisplayerText = null;
			this.LinkLDND.Entity = null;
			this.LinkLDND.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLDND.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkLDND.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkLDND.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkLDND.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkLDND.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkLDND.Location = new System.Drawing.Point(10, 0);
			this.LinkLDND.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkLDND.Name = "LinkLDND";
			this.LinkLDND.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkLDND.Size = new System.Drawing.Size(188, 20);
			this.LinkLDND.Status = AvControls.Statuses.Satisfactory;
			this.LinkLDND.TabIndex = 8;
			this.LinkLDND.Text = "LDND";
			this.LinkLDND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkLDND.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkLDND.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLinkLDNDDisplayerRequested);
			// 
			// LinkMaintenanceTasks
			// 
			this.LinkMaintenanceTasks.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMaintenanceTasks.Displayer = null;
			this.LinkMaintenanceTasks.DisplayerText = null;
			this.LinkMaintenanceTasks.Entity = null;
			this.LinkMaintenanceTasks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMaintenanceTasks.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkMaintenanceTasks.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkMaintenanceTasks.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkMaintenanceTasks.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMaintenanceTasks.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkMaintenanceTasks.Location = new System.Drawing.Point(208, 0);
			this.LinkMaintenanceTasks.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkMaintenanceTasks.Name = "LinkMaintenanceTasks";
			this.LinkMaintenanceTasks.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkMaintenanceTasks.Size = new System.Drawing.Size(270, 20);
			this.LinkMaintenanceTasks.Status = AvControls.Statuses.Satisfactory;
			this.LinkMaintenanceTasks.TabIndex = 8;
			this.LinkMaintenanceTasks.Text = "Routine Tasks";
			this.LinkMaintenanceTasks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkMaintenanceTasks.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMaintenanceTasks.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkMaintenanceProgramDirectivesDisplayerRequested);
			// 
			// LinkNonRoutineJobsCategories
			// 
			this.LinkNonRoutineJobsCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNonRoutineJobsCategories.Displayer = null;
			this.LinkNonRoutineJobsCategories.DisplayerText = null;
			this.LinkNonRoutineJobsCategories.Entity = null;
			this.LinkNonRoutineJobsCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkNonRoutineJobsCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkNonRoutineJobsCategories.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkNonRoutineJobsCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkNonRoutineJobsCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNonRoutineJobsCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkNonRoutineJobsCategories.Location = new System.Drawing.Point(488, 0);
			this.LinkNonRoutineJobsCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkNonRoutineJobsCategories.Name = "LinkNonRoutineJobsCategories";
			this.LinkNonRoutineJobsCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkNonRoutineJobsCategories.Size = new System.Drawing.Size(250, 20);
			this.LinkNonRoutineJobsCategories.Status = AvControls.Statuses.Satisfactory;
			this.LinkNonRoutineJobsCategories.TabIndex = 19;
			this.LinkNonRoutineJobsCategories.Text = "Non-Routine Tasks";
			this.LinkNonRoutineJobsCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkNonRoutineJobsCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkNonRoutineJobsCategories.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkNonRoutineJobsCategoriesDisplayerRequested);
			// 
			// LinkNonRoutineJobs
			// 
			this.LinkNonRoutineJobs.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNonRoutineJobs.Displayer = null;
			this.LinkNonRoutineJobs.DisplayerText = null;
			this.LinkNonRoutineJobs.Entity = null;
			this.LinkNonRoutineJobs.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkNonRoutineJobs.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkNonRoutineJobs.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkNonRoutineJobs.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkNonRoutineJobs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkNonRoutineJobs.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkNonRoutineJobs.Location = new System.Drawing.Point(748, 0);
			this.LinkNonRoutineJobs.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkNonRoutineJobs.Name = "LinkNonRoutineJobs";
			this.LinkNonRoutineJobs.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkNonRoutineJobs.Size = new System.Drawing.Size(188, 20);
			this.LinkNonRoutineJobs.Status = AvControls.Statuses.Satisfactory;
			this.LinkNonRoutineJobs.TabIndex = 20;
			this.LinkNonRoutineJobs.Text = "Non-Routine Status";
			this.LinkNonRoutineJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkNonRoutineJobs.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkNonRoutineJobs.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkNonRoutineJobsDisplayerRequested);
			// 
			// ContainerPlanning
			// 
			this.ContainerPlanning.AutoSize = true;
			this.ContainerPlanning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerPlanning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerPlanning.Caption = "Planning";
			this.ContainerPlanning.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerPlanning.Extended = false;
			this.ContainerPlanning.Location = new System.Drawing.Point(2, 296);
			this.ContainerPlanning.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerPlanning.Name = "ContainerPlanning";
			this.ContainerPlanning.ReferenceLink = this.LinkATLBEvent;
			this.ContainerPlanning.ReferenceLink02 = this.LinkATLBs;
			this.ContainerPlanning.ReferenceLink03 = this.LinkRegisterFlight;
			this.ContainerPlanning.ReferenceLink04 = this.LinkRegisterFlightLight;
			this.ContainerPlanning.ReferenceLink05 = this.LinkAverageUtilization;
			this.ContainerPlanning.ReferenceLink06 = this.LinkForecast;
			this.ContainerPlanning.ReferenceLink07 = this.LinkForecastMtop;
			this.ContainerPlanning.ReferenceLink12 = LinkForecastMtopOld;
			this.ContainerPlanning.ReferenceLink08 = this.LinkForecastKits;
			this.ContainerPlanning.ReferenceLink09 = this.LinkMonthlyUtilization;
			this.ContainerPlanning.ReferenceLink10 = this.LinkOil;
			this.ContainerPlanning.ReferenceLink11 = this.LinkWorkPackages;
			this.ContainerPlanning.ReferenceLink13 = null;
			this.ContainerPlanning.ReferenceLink14 = null;
			this.ContainerPlanning.ReferenceLink15 = null;
			this.ContainerPlanning.ReferenceLink16 = null;
			this.ContainerPlanning.Size = new System.Drawing.Size(154, 42);
			this.ContainerPlanning.TabIndex = 23;
			this.ContainerPlanning.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerPlanning.UpperLeftIcon")));
			// 
			// AllATLB
			// 
			this.LinkATLBEvent.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkATLBEvent.Displayer = null;
			this.LinkATLBEvent.DisplayerText = null;
			this.LinkATLBEvent.Entity = null;
			this.LinkATLBEvent.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.LinkATLBEvent.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkATLBEvent.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkATLBEvent.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkATLBEvent.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkATLBEvent.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkATLBEvent.Location = new System.Drawing.Point(10, 0);
			this.LinkATLBEvent.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkATLBEvent.Name = "ATLBEvent";
			this.LinkATLBEvent.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkATLBEvent.Size = new System.Drawing.Size(188, 20);
			this.LinkATLBEvent.Status = AvControls.Statuses.Satisfactory;
			this.LinkATLBEvent.TabIndex = 2;
			this.LinkATLBEvent.Text = "ATLB Event";
			this.LinkATLBEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkATLBEvent.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkATLBEvent.DisplayerRequested += AllATLB_DisplayerRequested;
			// 
			// LinkATLBs
			// 
			this.LinkATLBs.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkATLBs.Displayer = null;
			this.LinkATLBs.DisplayerText = null;
			this.LinkATLBs.Entity = null;
			this.LinkATLBs.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkATLBs.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkATLBs.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkATLBs.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkATLBs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkATLBs.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkATLBs.Location = new System.Drawing.Point(10, 0);
			this.LinkATLBs.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkATLBs.Name = "LinkATLBs";
			this.LinkATLBs.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkATLBs.Size = new System.Drawing.Size(188, 20);
			this.LinkATLBs.Status = AvControls.Statuses.Satisfactory;
			this.LinkATLBs.TabIndex = 22;
			this.LinkATLBs.Text = "ATLBs";
			this.LinkATLBs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkATLBs.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkATLBs.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAtlBsDisplayerRequested);
			// 
			// LinkRegisterFlight
			// 
			this.LinkRegisterFlight.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegisterFlight.Displayer = null;
			this.LinkRegisterFlight.DisplayerText = null;
			this.LinkRegisterFlight.Entity = null;
			this.LinkRegisterFlight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkRegisterFlight.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkRegisterFlight.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRegisterFlight.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRegisterFlight.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegisterFlight.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRegisterFlight.Location = new System.Drawing.Point(208, 0);
			this.LinkRegisterFlight.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRegisterFlight.Name = "LinkRegisterFlight";
			this.LinkRegisterFlight.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRegisterFlight.Size = new System.Drawing.Size(188, 20);
			this.LinkRegisterFlight.Status = AvControls.Statuses.Satisfactory;
			this.LinkRegisterFlight.TabIndex = 26;
			this.LinkRegisterFlight.Text = "Register Flight";
			this.LinkRegisterFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRegisterFlight.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkRegisterFlight.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRegisterFlightDisplayerRequested);
			// 
			// LinkRegisterFlightLight
			// 
			this.LinkRegisterFlightLight.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegisterFlightLight.Displayer = null;
			this.LinkRegisterFlightLight.DisplayerText = null;
			this.LinkRegisterFlightLight.Entity = null;
			this.LinkRegisterFlightLight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkRegisterFlightLight.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkRegisterFlightLight.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkRegisterFlightLight.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkRegisterFlightLight.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkRegisterFlightLight.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkRegisterFlightLight.Location = new System.Drawing.Point(208, 0);
			this.LinkRegisterFlightLight.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkRegisterFlightLight.Name = "LinkRegisterFlightLight";
			this.LinkRegisterFlightLight.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkRegisterFlightLight.Size = new System.Drawing.Size(188, 20);
			this.LinkRegisterFlightLight.Status = AvControls.Statuses.Satisfactory;
			this.LinkRegisterFlightLight.TabIndex = 26;
			this.LinkRegisterFlightLight.Text = "Register Flight Light";
			this.LinkRegisterFlightLight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkRegisterFlightLight.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkRegisterFlightLight.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkRegisterFlightLightDisplayerRequested);
			// 
			// LinkAverageUtilization
			// 
			this.LinkAverageUtilization.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAverageUtilization.Displayer = null;
			this.LinkAverageUtilization.DisplayerText = null;
			this.LinkAverageUtilization.Entity = null;
			this.LinkAverageUtilization.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAverageUtilization.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkAverageUtilization.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkAverageUtilization.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkAverageUtilization.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkAverageUtilization.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkAverageUtilization.Location = new System.Drawing.Point(406, 0);
			this.LinkAverageUtilization.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkAverageUtilization.Name = "LinkAverageUtilization";
			this.LinkAverageUtilization.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkAverageUtilization.Size = new System.Drawing.Size(188, 20);
			this.LinkAverageUtilization.Status = AvControls.Statuses.Satisfactory;
			this.LinkAverageUtilization.TabIndex = 27;
			this.LinkAverageUtilization.Text = "Average Utilization";
			this.LinkAverageUtilization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkAverageUtilization.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkAverageUtilization.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAverageUtilizationDisplayerRequested);
			// 
			// LinkForecast
			// 
			this.LinkForecast.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecast.Displayer = null;
			this.LinkForecast.DisplayerText = null;
			this.LinkForecast.Entity = null;
			this.LinkForecast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecast.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkForecast.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkForecast.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkForecast.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecast.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkForecast.Location = new System.Drawing.Point(604, 0);
			this.LinkForecast.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkForecast.Name = "LinkForecast";
			this.LinkForecast.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkForecast.Size = new System.Drawing.Size(188, 20);
			this.LinkForecast.Status = AvControls.Statuses.Satisfactory;
			this.LinkForecast.TabIndex = 29;
			this.LinkForecast.Text = "Forecast Report";
			this.LinkForecast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkForecast.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecast.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastDisplayerRequested);
			// 
			// LinkForecastMtop
			// 
			this.LinkForecastMtop.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastMtop.Displayer = null;
			this.LinkForecastMtop.DisplayerText = null;
			this.LinkForecastMtop.Entity = null;
			this.LinkForecastMtop.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastMtop.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkForecastMtop.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkForecastMtop.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkForecastMtop.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastMtop.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkForecastMtop.Location = new System.Drawing.Point(604, 0);
			this.LinkForecastMtop.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkForecastMtop.Name = "LinkForecastMtop";
			this.LinkForecastMtop.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkForecastMtop.Size = new System.Drawing.Size(188, 20);
			this.LinkForecastMtop.Status = AvControls.Statuses.Satisfactory;
			this.LinkForecastMtop.TabIndex = 29;
			this.LinkForecastMtop.Text = "Forecast MTOP Report";
			this.LinkForecastMtop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkForecastMtop.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastMtop.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastMTOPDisplayerRequested);
			// 
			// LinkForecastMtopOld
			// 
			this.LinkForecastMtopOld.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastMtopOld.Displayer = null;
			this.LinkForecastMtopOld.DisplayerText = null;
			this.LinkForecastMtopOld.Entity = null;
			this.LinkForecastMtopOld.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastMtopOld.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkForecastMtopOld.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkForecastMtopOld.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkForecastMtopOld.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastMtopOld.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkForecastMtopOld.Location = new System.Drawing.Point(604, 0);
			this.LinkForecastMtopOld.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkForecastMtopOld.Name = "LinkForecastMtopOld";
			this.LinkForecastMtopOld.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkForecastMtopOld.Size = new System.Drawing.Size(220, 20);
			this.LinkForecastMtopOld.Status = AvControls.Statuses.Satisfactory;
			this.LinkForecastMtopOld.TabIndex = 29;
			this.LinkForecastMtopOld.Text = "Forecast MTOP Report Old";
			this.LinkForecastMtopOld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkForecastMtopOld.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastMtopOld.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastMTOPOldDisplayerRequested);
			// 
			// LinkForecastKits
			// 
			this.LinkForecastKits.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastKits.Displayer = null;
			this.LinkForecastKits.DisplayerText = null;
			this.LinkForecastKits.Entity = null;
			this.LinkForecastKits.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastKits.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkForecastKits.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkForecastKits.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkForecastKits.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkForecastKits.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkForecastKits.Location = new System.Drawing.Point(802, 0);
			this.LinkForecastKits.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkForecastKits.Name = "LinkForecastKits";
			this.LinkForecastKits.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkForecastKits.Size = new System.Drawing.Size(188, 20);
			this.LinkForecastKits.Status = AvControls.Statuses.Satisfactory;
			this.LinkForecastKits.TabIndex = 30;
			this.LinkForecastKits.Text = "Forecast Report Kits";
			this.LinkForecastKits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkForecastKits.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkForecastKits.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastKitsDisplayerRequested);
			// 
			// LinkMonthlyUtilization
			// 
			this.LinkMonthlyUtilization.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMonthlyUtilization.Displayer = null;
			this.LinkMonthlyUtilization.DisplayerText = null;
			this.LinkMonthlyUtilization.Entity = null;
			this.LinkMonthlyUtilization.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMonthlyUtilization.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkMonthlyUtilization.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkMonthlyUtilization.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkMonthlyUtilization.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkMonthlyUtilization.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkMonthlyUtilization.Location = new System.Drawing.Point(1000, 0);
			this.LinkMonthlyUtilization.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkMonthlyUtilization.Name = "LinkMonthlyUtilization";
			this.LinkMonthlyUtilization.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkMonthlyUtilization.Size = new System.Drawing.Size(188, 20);
			this.LinkMonthlyUtilization.Status = AvControls.Statuses.Satisfactory;
			this.LinkMonthlyUtilization.TabIndex = 28;
			this.LinkMonthlyUtilization.Text = "Monthly Utilization";
			this.LinkMonthlyUtilization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkMonthlyUtilization.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkMonthlyUtilization.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkMonthlyUtilizationDisplayerRequested);
			// 
			// LinkMonthlyUtilization
			// 
			this.LinkOil.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOil.Displayer = null;
			this.LinkOil.DisplayerText = null;
			this.LinkOil.Entity = null;
			this.LinkOil.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkOil.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkOil.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkOil.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkOil.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkOil.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkOil.Location = new System.Drawing.Point(1000, 0);
			this.LinkOil.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkOil.Name = "LinkOil";
			this.LinkOil.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkOil.Size = new System.Drawing.Size(188, 20);
			this.LinkOil.Status = AvControls.Statuses.Satisfactory;
			this.LinkOil.TabIndex = 28;
			this.LinkOil.Text = "Oil Statistics";
			this.LinkOil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkOil.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkOil.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkOilDisplayerRequested);
			// 
			// LinkWorkPackages
			// 
			this.LinkWorkPackages.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkWorkPackages.Displayer = null;
			this.LinkWorkPackages.DisplayerText = null;
			this.LinkWorkPackages.Entity = null;
			this.LinkWorkPackages.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkWorkPackages.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkWorkPackages.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkWorkPackages.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkWorkPackages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkWorkPackages.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkWorkPackages.Location = new System.Drawing.Point(1198, 0);
			this.LinkWorkPackages.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkWorkPackages.Name = "LinkWorkPackages";
			this.LinkWorkPackages.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkWorkPackages.Size = new System.Drawing.Size(188, 20);
			this.LinkWorkPackages.Status = AvControls.Statuses.Satisfactory;
			this.LinkWorkPackages.TabIndex = 31;
			this.LinkWorkPackages.Text = "Work Packages";
			this.LinkWorkPackages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkWorkPackages.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkWorkPackages.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkWorkPackagesDisplayerRequested);
			// 
			// ContainerPurchase
			// 
			this.ContainerPurchase.AutoSize = true;
			this.ContainerPurchase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerPurchase.Caption = "Purchase";
			this.ContainerPurchase.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerPurchase.Extended = false;
			this.ContainerPurchase.Location = new System.Drawing.Point(2, 342);
			this.ContainerPurchase.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerPurchase.Name = "ContainerPurchase";
			this.ContainerPurchase.ReferenceLink = this.LinkEquipmentAndMaterials;
			this.ContainerPurchase.ReferenceLink02 = this.LinkInitialOrders;
			this.ContainerPurchase.ReferenceLink03 = this.LinkPurchaseOrders;
			this.ContainerPurchase.ReferenceLink04 = this.LinkQuotationOrders;
			this.ContainerPurchase.ReferenceLink05 = null;
			this.ContainerPurchase.ReferenceLink06 = null;
			this.ContainerPurchase.ReferenceLink07 = null;
			this.ContainerPurchase.ReferenceLink08 = null;
			this.ContainerPurchase.ReferenceLink09 = null;
			this.ContainerPurchase.ReferenceLink10 = null;
			this.ContainerPurchase.ReferenceLink11 = null;
			this.ContainerPurchase.ReferenceLink12 = null;
			this.ContainerPurchase.ReferenceLink13 = null;
			this.ContainerPurchase.ReferenceLink14 = null;
			this.ContainerPurchase.ReferenceLink15 = null;
			this.ContainerPurchase.ReferenceLink16 = null;
			this.ContainerPurchase.Size = new System.Drawing.Size(158, 42);
			this.ContainerPurchase.TabIndex = 24;
			this.ContainerPurchase.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerPurchase.UpperLeftIcon")));
			// 
			// LinkEquipmentAndMaterials
			// 
			this.LinkEquipmentAndMaterials.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEquipmentAndMaterials.Displayer = null;
			this.LinkEquipmentAndMaterials.DisplayerText = null;
			this.LinkEquipmentAndMaterials.Entity = null;
			this.LinkEquipmentAndMaterials.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkEquipmentAndMaterials.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkEquipmentAndMaterials.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkEquipmentAndMaterials.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkEquipmentAndMaterials.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkEquipmentAndMaterials.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkEquipmentAndMaterials.Location = new System.Drawing.Point(10, 0);
			this.LinkEquipmentAndMaterials.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkEquipmentAndMaterials.Name = "LinkEquipmentAndMaterials";
			this.LinkEquipmentAndMaterials.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkEquipmentAndMaterials.Size = new System.Drawing.Size(250, 20);
			this.LinkEquipmentAndMaterials.Status = AvControls.Statuses.Satisfactory;
			this.LinkEquipmentAndMaterials.TabIndex = 32;
			this.LinkEquipmentAndMaterials.Text = "Equipment and Materials";
			this.LinkEquipmentAndMaterials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkEquipmentAndMaterials.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkEquipmentAndMaterials.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkEquipmentAndMaterialsDisplayerRequested);
			// 
			// LinkInitialOrders
			// 
			this.LinkInitialOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInitialOrders.Displayer = null;
			this.LinkInitialOrders.DisplayerText = null;
			this.LinkInitialOrders.Entity = null;
			this.LinkInitialOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkInitialOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkInitialOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkInitialOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkInitialOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkInitialOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkInitialOrders.Location = new System.Drawing.Point(270, 0);
			this.LinkInitialOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkInitialOrders.Name = "LinkInitialOrders";
			this.LinkInitialOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkInitialOrders.Size = new System.Drawing.Size(188, 20);
			this.LinkInitialOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkInitialOrders.TabIndex = 32;
			this.LinkInitialOrders.Text = "Initial Orders";
			this.LinkInitialOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkInitialOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkInitialOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkInitialOrdersDisplayerRequested);
			
			// 
			// LinkPurchaseOrders
			// 
			this.LinkPurchaseOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseOrders.Displayer = null;
			this.LinkPurchaseOrders.DisplayerText = null;
			this.LinkPurchaseOrders.Entity = null;
			this.LinkPurchaseOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPurchaseOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkPurchaseOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkPurchaseOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkPurchaseOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkPurchaseOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkPurchaseOrders.Location = new System.Drawing.Point(270, 0);
			this.LinkPurchaseOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkPurchaseOrders.Name = "LinkPurchaseOrders";
			this.LinkPurchaseOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkPurchaseOrders.Size = new System.Drawing.Size(188, 20);
			this.LinkPurchaseOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkPurchaseOrders.TabIndex = 32;
			this.LinkPurchaseOrders.Text = "Purchase Orders";
			this.LinkPurchaseOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkPurchaseOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkPurchaseOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPurchaseOrdersDisplayerRequested);
			// 
			// LinkQuotationOrders
			// 
			this.LinkQuotationOrders.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQuotationOrders.Displayer = null;
			this.LinkQuotationOrders.DisplayerText = null;
			this.LinkQuotationOrders.Entity = null;
			this.LinkQuotationOrders.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkQuotationOrders.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkQuotationOrders.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkQuotationOrders.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkQuotationOrders.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkQuotationOrders.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkQuotationOrders.Location = new System.Drawing.Point(468, 0);
			this.LinkQuotationOrders.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkQuotationOrders.Name = "LinkQuotationOrders";
			this.LinkQuotationOrders.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkQuotationOrders.Size = new System.Drawing.Size(188, 20);
			this.LinkQuotationOrders.Status = AvControls.Statuses.Satisfactory;
			this.LinkQuotationOrders.TabIndex = 33;
			this.LinkQuotationOrders.Text = "Quotation Orders";
			this.LinkQuotationOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkQuotationOrders.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkQuotationOrders.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkQuotationOrdersDisplayerRequested);
			// 
			// ContainerSMS
			// 
			this.ContainerSMS.AutoSize = true;
			this.ContainerSMS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContainerSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ContainerSMS.Caption = "SMS";
			this.ContainerSMS.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.ContainerSMS.Extended = false;
			this.ContainerSMS.Location = new System.Drawing.Point(2, 388);
			this.ContainerSMS.Margin = new System.Windows.Forms.Padding(2);
			this.ContainerSMS.Name = "ContainerSMS";
			this.ContainerSMS.ReferenceLink = this.LinkSMSEvents;
			this.ContainerSMS.ReferenceLink02 = this.LinkSMSEventsCategories;
			this.ContainerSMS.ReferenceLink03 = this.LinkSMSEventsClasses;
			this.ContainerSMS.ReferenceLink04 = this.LinkSMSEventsTypes;
			this.ContainerSMS.ReferenceLink05 = null;
			this.ContainerSMS.ReferenceLink06 = null;
			this.ContainerSMS.ReferenceLink07 = null;
			this.ContainerSMS.ReferenceLink08 = null;
			this.ContainerSMS.ReferenceLink09 = null;
			this.ContainerSMS.ReferenceLink10 = null;
			this.ContainerSMS.ReferenceLink11 = null;
			this.ContainerSMS.ReferenceLink12 = null;
			this.ContainerSMS.ReferenceLink13 = null;
			this.ContainerSMS.ReferenceLink14 = null;
			this.ContainerSMS.ReferenceLink15 = null;
			this.ContainerSMS.ReferenceLink16 = null;
			this.ContainerSMS.Size = new System.Drawing.Size(109, 42);
			this.ContainerSMS.TabIndex = 25;
			this.ContainerSMS.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerSMS.UpperLeftIcon")));
			// 
			// LinkSMSEvents
			// 
			this.LinkSMSEvents.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEvents.Displayer = null;
			this.LinkSMSEvents.DisplayerText = null;
			this.LinkSMSEvents.Entity = null;
			this.LinkSMSEvents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEvents.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkSMSEvents.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSMSEvents.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSMSEvents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEvents.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSMSEvents.Location = new System.Drawing.Point(10, 0);
			this.LinkSMSEvents.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSMSEvents.Name = "LinkSMSEvents";
			this.LinkSMSEvents.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSMSEvents.Size = new System.Drawing.Size(188, 20);
			this.LinkSMSEvents.Status = AvControls.Statuses.Satisfactory;
			this.LinkSMSEvents.TabIndex = 33;
			this.LinkSMSEvents.Text = "Events";
			this.LinkSMSEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSMSEvents.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEvents.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSmsEventsDisplayerRequested);
			// 
			// LinkSMSEventsCategories
			// 
			this.LinkSMSEventsCategories.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsCategories.Displayer = null;
			this.LinkSMSEventsCategories.DisplayerText = null;
			this.LinkSMSEventsCategories.Entity = null;
			this.LinkSMSEventsCategories.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsCategories.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkSMSEventsCategories.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSMSEventsCategories.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSMSEventsCategories.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsCategories.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSMSEventsCategories.Location = new System.Drawing.Point(208, 0);
			this.LinkSMSEventsCategories.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSMSEventsCategories.Name = "LinkSMSEventsCategories";
			this.LinkSMSEventsCategories.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSMSEventsCategories.Size = new System.Drawing.Size(188, 20);
			this.LinkSMSEventsCategories.Status = AvControls.Statuses.Satisfactory;
			this.LinkSMSEventsCategories.TabIndex = 34;
			this.LinkSMSEventsCategories.Text = "Events Categories";
			this.LinkSMSEventsCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSMSEventsCategories.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsCategories.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSmsEventsCategoriesDisplayerRequested);
			// 
			// LinkSMSEventsClasses
			// 
			this.LinkSMSEventsClasses.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsClasses.Displayer = null;
			this.LinkSMSEventsClasses.DisplayerText = null;
			this.LinkSMSEventsClasses.Entity = null;
			this.LinkSMSEventsClasses.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsClasses.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkSMSEventsClasses.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSMSEventsClasses.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSMSEventsClasses.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsClasses.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSMSEventsClasses.Location = new System.Drawing.Point(406, 0);
			this.LinkSMSEventsClasses.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSMSEventsClasses.Name = "LinkSMSEventsClasses";
			this.LinkSMSEventsClasses.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSMSEventsClasses.Size = new System.Drawing.Size(188, 20);
			this.LinkSMSEventsClasses.Status = AvControls.Statuses.Satisfactory;
			this.LinkSMSEventsClasses.TabIndex = 35;
			this.LinkSMSEventsClasses.Text = "Events Classes";
			this.LinkSMSEventsClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSMSEventsClasses.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsClasses.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSmsEventsClassesDisplayerRequested);
			// 
			// LinkSMSEventsTypes
			// 
			this.LinkSMSEventsTypes.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsTypes.Displayer = null;
			this.LinkSMSEventsTypes.DisplayerText = null;
			this.LinkSMSEventsTypes.Entity = null;
			this.LinkSMSEventsTypes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsTypes.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.LinkSMSEventsTypes.ImageBackColor = System.Drawing.Color.Transparent;
			this.LinkSMSEventsTypes.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LinkSMSEventsTypes.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.LinkSMSEventsTypes.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.LinkSMSEventsTypes.Location = new System.Drawing.Point(604, 0);
			this.LinkSMSEventsTypes.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.LinkSMSEventsTypes.Name = "LinkSMSEventsTypes";
			this.LinkSMSEventsTypes.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.LinkSMSEventsTypes.Size = new System.Drawing.Size(188, 20);
			this.LinkSMSEventsTypes.Status = AvControls.Statuses.Satisfactory;
			this.LinkSMSEventsTypes.TabIndex = 36;
			this.LinkSMSEventsTypes.Text = "Events Types";
			this.LinkSMSEventsTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LinkSMSEventsTypes.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.LinkSMSEventsTypes.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSmsEventsTypesDisplayerRequested);
			// 
			// baseDetailButtons
			// 
			this._baseComponentButtons.Aircraft = null;
			this._baseComponentButtons.AutoSize = true;
			this._baseComponentButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._baseComponentButtons.Location = new System.Drawing.Point(400, 0);
			this._baseComponentButtons.Margin = new System.Windows.Forms.Padding(4);
			this._baseComponentButtons.MinimumSize = new System.Drawing.Size(40, 50);
			this._baseComponentButtons.Name = "_baseComponentButtons";
			this._baseComponentButtons.Size = new System.Drawing.Size(634, 556);
			this._baseComponentButtons.TabIndex = 2;
			// 
			// AircraftScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "AircraftScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.ShowTopPanelContainer = false;
			this.Size = new System.Drawing.Size(715, 384);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flowLayoutPanelReferences.ResumeLayout(false);
			this.flowLayoutPanelReferences.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReferences;
		private BaseComponentButtonsControl _baseComponentButtons;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDocuments;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkADStatus;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerGD;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAircraftGeneralData;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAircraftSummary;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerComponents;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAvionxInventory;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentStatusHT;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentStatusOCCM;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkADStatusAF;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkADStatusAP;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkCPCPStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDamageCharts;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDamages;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerDirectives;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerDiscrepancies;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDiscrepancies;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerMP;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDeferredCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkDeferredItems;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEOStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkModifications;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSBStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkOoPStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentTracking;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkComponentChangeReport;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkLandingGearStatus;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkLLPCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkMaintenanceProgram;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkMTOP;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkLDND;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkMaintenanceTasks;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkNonRoutineJobsCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkNonRoutineJobs;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkATLBs;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerPlanning;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkATLBEvent;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRegisterFlight;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkRegisterFlightLight;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkAverageUtilization;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkMonthlyUtilization;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkOil;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkForecast;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkForecastMtop;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkForecastMtopOld;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkForecastKits;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkWorkPackages;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerPurchase;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkEquipmentAndMaterials;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkInitialOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkPurchaseOrders;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkQuotationOrders;
		private ReferenceControls.ReferenceLinkLabelCollectionContainer ContainerSMS;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSMSEvents;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSMSEventsCategories;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSMSEventsClasses;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel LinkSMSEventsTypes;
	}
}
