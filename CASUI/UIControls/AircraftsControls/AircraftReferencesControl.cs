using System;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Элемент управления для отображения коллекции ссылок для ВС и его отчетов
    /// </summary>
    public class AircraftReferencesControl:RichReferenceContainer
    {

        #region Fields

        private readonly AircraftType aircraftType;

        private Panel panelADStatus;
        private ReferenceStatusImageLinkLabel linkADStatus;
        private ReferenceLinkLabel linkADStatusAF;
        private ReferenceLinkLabel linkADStatusAP;
        private ReferenceStatusImageLinkLabel linkAgingProgram;
        private ReferenceStatusImageLinkLabel linkAircraftGeneralData;
        private ReferenceStatusImageLinkLabel linkAircraftTechnicalLogBook;
        private ReferenceStatusImageLinkLabel linkAverageUtilization;
        private ReferenceStatusImageLinkLabel linkAvionicsInventory;
        private ReferenceStatusImageLinkLabel linkCPCPStatus;
        private Panel panelComponentStatus;
        private ReferenceStatusImageLinkLabel linkComponentStatus;
        private ReferenceLinkLabel linkComponentStatusHT;
        private ReferenceLinkLabel linkComponentStatusOCCM;
        private ReferenceStatusImageLinkLabel linkComponentChange;
        private ReferenceStatusImageLinkLabel linkDamages;
        private ReferenceStatusImageLinkLabel linkDeferredItems;
        private ReferenceStatusImageLinkLabel linkEngineeringOrders;
        private ReferenceStatusImageLinkLabel linkForecastReport;
        private ReferenceStatusImageLinkLabel linkLandingGearStatus;
        private ReferenceStatusImageLinkLabel linkListOfModificationsPerformed;
        private ReferenceStatusImageLinkLabel linkListOfWorkPackages;
        private ReferenceStatusImageLinkLabel linkMaintenanceStatus;
        private ReferenceStatusImageLinkLabel linkMonthlyUtilization;
        private ReferenceStatusImageLinkLabel linkOutOffPhaseItems;
        private ReferenceStatusImageLinkLabel linkRepairStatus;
        private ReferenceStatusImageLinkLabel linkSBStatus;
        //private ReferenceStatusImageLinkLabel linkSSIDStatus;

        private FlowLayoutPanel flowLayoutPanelContainer;
        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения коллекции ссылок для ВС и его отчетов
        /// </summary>
        public AircraftReferencesControl(AircraftType aircraftType)
        {
            this.aircraftType = aircraftType;
            InitializeComponent();
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkADStatus
        {
            get { return linkADStatus.Status; }
            set { linkADStatus.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkAgingProgram
        {
            get { return linkAgingProgram.Status; }
            set { linkAgingProgram.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkAircraftGeneralData
        {
            get { return linkAircraftGeneralData.Status; }
            set { linkAircraftGeneralData.Status = value; }
        }

        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkAvionicsInventory
        {
            get { return linkAvionicsInventory.Status; }
            set { linkAvionicsInventory.Status = value; }
        }

        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkCPCPStatus
        {
            get { return linkCPCPStatus.Status; }
            set { linkCPCPStatus.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkComponentStatus
        {
            get { return linkComponentStatus.Status; }
            set { linkComponentStatus.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkComponentChange
        {
            get { return linkComponentChange.Status; }
            set { linkComponentChange.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkDeferredItems
        {
            get { return linkDeferredItems.Status; }
            set { linkDeferredItems.Status = value; }
        }

        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkDamages
        {
            get { return linkDamages.Status; }
            set { linkDamages.Status = value; }
        }
        /*
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkDiscrepancies
        {
            get { return linkDiscrepancies.Status; }
            set { linkDiscrepancies.Status = value; }
        }*/
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkEngineeringOrders
        {
            get { return linkEngineeringOrders.Status; }
            set { linkEngineeringOrders.Status = value; }
        }

        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkLandingGearStatus
        {
            get { return linkLandingGearStatus.Status; }
            set { linkLandingGearStatus.Status = value; }
        }

        
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkMaintenanceStatus
        {
            get { return linkMaintenanceStatus.Status; }
            set { linkMaintenanceStatus.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkListOfModificationsPerformed
        {
            get { return linkListOfModificationsPerformed.Status; }
            set { linkListOfModificationsPerformed.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkOutOffPhaseItems
        {
            get { return linkOutOffPhaseItems.Status; }
            set { linkOutOffPhaseItems.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkRepairStatus
        {
            get { return linkRepairStatus.Status; }
            set { linkRepairStatus.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkSBStatus
        {
            get { return linkSBStatus.Status; }
            set { linkSBStatus.Status = value; }
        }
/*
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkSSIDStatus
        {
            get { return linkSSIDStatus.Status; }
            set { linkSSIDStatus.Status = value; }
        }
*/

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelADStatus = new Panel();
            linkADStatus = new ReferenceStatusImageLinkLabel();
            linkADStatusAF = new ReferenceLinkLabel();
            linkADStatusAP = new ReferenceLinkLabel();
            linkAgingProgram = new ReferenceStatusImageLinkLabel();
            linkAircraftGeneralData = new ReferenceStatusImageLinkLabel();
            linkAircraftTechnicalLogBook = new ReferenceStatusImageLinkLabel();
            linkAverageUtilization = new ReferenceStatusImageLinkLabel();
            linkAvionicsInventory = new ReferenceStatusImageLinkLabel();
            linkCPCPStatus = new ReferenceStatusImageLinkLabel();
            panelComponentStatus = new Panel();
            linkComponentStatus = new ReferenceStatusImageLinkLabel();
            linkComponentStatusHT = new ReferenceLinkLabel();
            linkComponentStatusOCCM = new ReferenceLinkLabel();
            linkComponentChange = new ReferenceStatusImageLinkLabel();
            linkDamages = new ReferenceStatusImageLinkLabel();
            linkDeferredItems = new ReferenceStatusImageLinkLabel();
            linkEngineeringOrders = new ReferenceStatusImageLinkLabel();
            linkForecastReport = new ReferenceStatusImageLinkLabel();
            linkLandingGearStatus = new ReferenceStatusImageLinkLabel();
            linkListOfModificationsPerformed = new ReferenceStatusImageLinkLabel();
            linkListOfWorkPackages = new ReferenceStatusImageLinkLabel();
            linkMaintenanceStatus = new ReferenceStatusImageLinkLabel();
            linkMonthlyUtilization = new ReferenceStatusImageLinkLabel();
            linkOutOffPhaseItems = new ReferenceStatusImageLinkLabel();
            linkRepairStatus = new ReferenceStatusImageLinkLabel();
            linkSBStatus = new ReferenceStatusImageLinkLabel();
            //linkSSIDStatus = new ReferenceStatusImageLinkLabel();

            flowLayoutPanelContainer = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelContainer
            // 
            flowLayoutPanelContainer.AutoSize = true;
            flowLayoutPanelContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelContainer.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelContainer.Dock = DockStyle.Top;
            flowLayoutPanelContainer.Location = new Point(208, 43);
            flowLayoutPanelContainer.Name = "flowLayoutPanelContainer";
            flowLayoutPanelContainer.TabIndex = 1;
            //
            // panelADStatus
            //
            panelADStatus = new Panel();
            panelADStatus.Size = new Size(300, 26);
            panelADStatus.Margin = new Padding(2, 1, 1, 1);
            panelADStatus.Controls.Add(linkADStatus);
            panelADStatus.Controls.Add(linkADStatusAF);
            panelADStatus.Controls.Add(linkADStatusAP);
            //
            // linkADStatus
            //
            linkADStatus.Text = directiveTypeCollection.ADDirectiveType.CommonName;
            linkADStatus.Size = new Size(125, 26);
            linkADStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkADStatus.DisplayerRequested += linkADStatus_DisplayerRequested;
            linkADStatus.Status = Statuses.Satisfactory;
            linkADStatus.Enabled = true;
            Css.ImageLink.Adjust(linkADStatus);
            //
            // linkADStatusAF
            //
            linkADStatusAF.Text = "AF";
            linkADStatusAF.Margin = new Padding(1);
            linkADStatusAF.Location = new Point(linkADStatus.Right, 9);
            linkADStatusAF.Size = new Size(30, 25);
            linkADStatusAF.ReflectionType = ReflectionTypes.DisplayInNew;
            linkADStatusAF.DisplayerRequested += linkADStatusAF_DisplayerRequested;
            Css.SimpleLink.Adjust(linkADStatusAF);
            //
            // linkADStatusAP
            //
            linkADStatusAP.Text = "AP";
            linkADStatusAP.Margin = new Padding(1);
            linkADStatusAP.Location = new Point(linkADStatusAF.Right, 9);
            linkADStatusAP.Size = new Size(30, 25);
            linkADStatusAP.ReflectionType = ReflectionTypes.DisplayInNew;
            linkADStatusAP.DisplayerRequested += linkADStatusAP_DisplayerRequested;
            Css.SimpleLink.Adjust(linkADStatusAP);
            //
            // linkAircraftGeneralData
            //
            linkAircraftGeneralData.Text = "Aircraft General Data";
            linkAircraftGeneralData.Enabled = true;
            linkAircraftGeneralData.Status = Statuses.NotActive;
            linkAircraftGeneralData.Margin = new Padding(1);
            linkAircraftGeneralData.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAircraftGeneralData.DisplayerRequested += linkAircraftGeneralData_DisplayerRequested;
            Css.ImageLink.Adjust(linkAircraftGeneralData);
            //
            // linkAircraftTechnicalLogBook
            //
            linkAircraftTechnicalLogBook.Width = 300;
            linkAircraftTechnicalLogBook.Text = "Aircraft Technical Log Book";
            linkAircraftTechnicalLogBook.Status = Statuses.NotActive;
            linkAircraftTechnicalLogBook.Enabled = true;
            linkAircraftTechnicalLogBook.Margin = new Padding(1);
            linkAircraftTechnicalLogBook.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAircraftTechnicalLogBook.DisplayerRequested += linkAircraftTechnicalLogBook_DisplayerRequested;
            Css.ImageLink.Adjust(linkAircraftTechnicalLogBook);
            //
            // linkAverageUtilization
            //
            linkAverageUtilization.Width = 300;
            linkAverageUtilization.Text = "Average Utilization";
            linkAverageUtilization.Status = Statuses.NotActive;
            linkAverageUtilization.Enabled = true;
            linkAverageUtilization.Margin = new Padding(1);
            linkAverageUtilization.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAverageUtilization.DisplayerRequested += linkAverageUtilization_DisplayerRequested;
            Css.ImageLink.Adjust(linkAverageUtilization);
            //
            // linkAvionicsInventory
            //
            linkAvionicsInventory.Width = 300;
            linkAvionicsInventory.Text = "Avionics Inventory";
            linkAvionicsInventory.Status = Statuses.NotActive;
            linkAvionicsInventory.Enabled = true;
            linkAvionicsInventory.Margin = new Padding(1);
            linkAvionicsInventory.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAvionicsInventory.DisplayerRequested += linkAvionicsInventory_DisplayerRequested;
            Css.ImageLink.Adjust(linkAvionicsInventory);
            //
            // panelComponentStatus
            //
            panelComponentStatus = new Panel();
            panelComponentStatus.Size = new Size(300, 26);
            panelComponentStatus.Margin = new Padding(2, 1, 1, 1);
            panelComponentStatus.Controls.Add(linkComponentStatus);
            panelComponentStatus.Controls.Add(linkComponentStatusHT);
            panelComponentStatus.Controls.Add(linkComponentStatusOCCM);
            //
            // linkComponentStatus
            //
            linkComponentStatus.Text = "Component Status";
            linkComponentStatus.Enabled = true;
            linkComponentStatus.Size = new Size(180, 26);
            //linkComponentStatus.Margin = new Padding(1);
            linkComponentStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkComponentStatus.DisplayerRequested += linkComponentStatus_DisplayerRequested;
            linkComponentStatus.Status = Statuses.Satisfactory;
            Css.ImageLink.Adjust(linkComponentStatus);
            //
            // linkComponentStatusHT
            //
            linkComponentStatusHT.Text = "HT";
            linkComponentStatusHT.Margin = new Padding(1);
            linkComponentStatusHT.Location = new Point(linkComponentStatus.Right, 9);
            linkComponentStatusHT.Size = new Size(30, 25);
            linkComponentStatusHT.ReflectionType = ReflectionTypes.DisplayInNew;
            linkComponentStatusHT.DisplayerRequested += linkComponentStatusHT_DisplayerRequested;
            Css.SimpleLink.Adjust(linkComponentStatusHT);
            //
            // linkComponentStatusOCCM
            //
            linkComponentStatusOCCM.Text = "OCCM";
            linkComponentStatusOCCM.Margin = new Padding(1);
            linkComponentStatusOCCM.Location = new Point(linkComponentStatusHT.Right, 9);
            linkComponentStatusOCCM.Size = new Size(50, 25);
            linkComponentStatusOCCM.ReflectionType = ReflectionTypes.DisplayInNew;
            linkComponentStatusOCCM.DisplayerRequested += linkComponentStatusOCCM_DisplayerRequested;
            Css.SimpleLink.Adjust(linkComponentStatusOCCM);
            //
            // linkComponentChange
            //
            linkComponentChange.Width = 400;
            linkComponentChange.Text = "Component Change Report";
            linkComponentChange.Margin = new Padding(5);
            linkComponentChange.Enabled = true;
            linkComponentChange.Margin = new Padding(1);
            linkComponentChange.Status = Statuses.Satisfactory;
            linkComponentChange.ReflectionType = ReflectionTypes.DisplayInNew;
            linkComponentChange.DisplayerRequested += linkComponentChange_DisplayerRequested;
            Css.ImageLink.Adjust(linkComponentChange);
            //
            // linkEngineeringOrders
            //
            linkEngineeringOrders.Text = directiveTypeCollection.EngineeringOrdersDirectiveType.CommonName;
            linkEngineeringOrders.Margin = new Padding(5);
            linkEngineeringOrders.Enabled = true;
            linkEngineeringOrders.Margin = new Padding(1);
            linkEngineeringOrders.Status = Statuses.Satisfactory;
            linkEngineeringOrders.ReflectionType = ReflectionTypes.DisplayInNew;
            linkEngineeringOrders.DisplayerRequested += linkEngineeringOrders_DisplayerRequested;
            Css.ImageLink.Adjust(linkEngineeringOrders);
            //
            // linkForecastReport
            //
            linkForecastReport.Text = "Forecast Report";
            linkForecastReport.Margin = new Padding(5);
            linkForecastReport.Enabled = true;
            linkForecastReport.Margin = new Padding(1);
            linkForecastReport.Status = Statuses.NotActive;
            Css.ImageLink.Adjust(linkForecastReport);
            linkForecastReport.ReflectionType = ReflectionTypes.DisplayInNew;
            linkForecastReport.DisplayerRequested += linkForecastReport_DisplayerRequested;
            //
            // linkLandingGearStatus
            //
            linkLandingGearStatus.Text = "Landing Gear Status";
            linkLandingGearStatus.Enabled = true;
            linkLandingGearStatus.Status = Statuses.NotActive;
            linkLandingGearStatus.Margin = new Padding(1);
            linkLandingGearStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLandingGearStatus.DisplayerRequested += linkLandingGearStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkLandingGearStatus);
            //
            // linkListOfModificationsPerformed
            //
            linkListOfModificationsPerformed.Width = 300;
            linkListOfModificationsPerformed.Text = "List of Modifications Performed";
            linkListOfModificationsPerformed.Margin = new Padding(5);
            linkListOfModificationsPerformed.Enabled = true;
            linkListOfModificationsPerformed.Margin = new Padding(1);
            linkListOfModificationsPerformed.ReflectionType = ReflectionTypes.DisplayInNew;
            linkListOfModificationsPerformed.Status = Statuses.NotActive;
            linkListOfModificationsPerformed.DisplayerRequested += linkListOfModificationsPerformed_DisplayerRequested;
            Css.ImageLink.Adjust(linkListOfModificationsPerformed);
            //
            // linkListOfWorkPackages
            //
            linkListOfWorkPackages.Width = 300;
            linkListOfWorkPackages.Text = "List of Work Packages";
            linkListOfWorkPackages.Margin = new Padding(5);
            linkListOfWorkPackages.Enabled = true;
            linkListOfWorkPackages.Margin = new Padding(1);
            linkListOfWorkPackages.ReflectionType = ReflectionTypes.DisplayInNew;
            linkListOfWorkPackages.Status = Statuses.NotActive;
            linkListOfWorkPackages.DisplayerRequested += linkListOfWorkPackages_DisplayerRequested;
            Css.ImageLink.Adjust(linkListOfWorkPackages);
            //
            // linkSBStatus
            //
            linkSBStatus.Text = directiveTypeCollection.SBDirectiveType.CommonName;
            linkSBStatus.Enabled = true;
            linkSBStatus.Margin = new Padding(1);
            linkSBStatus.Status = Statuses.Satisfactory;
            linkSBStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkSBStatus.DisplayerRequested += linkSBStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkSBStatus);
            //
            // linkAgingProgram
            //
            linkAgingProgram.Text = directiveTypeCollection.AgineProgramDirectiveType.CommonName;
            linkAgingProgram.Margin = new Padding(5);
            linkAgingProgram.Enabled = true;
            linkAgingProgram.Margin = new Padding(1);
            linkAgingProgram.Status = Statuses.Satisfactory;
            linkAgingProgram.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAgingProgram.DisplayerRequested += linkAgingProgram_DisplayerRequested;
            Css.ImageLink.Adjust(linkAgingProgram);
            //
            // linkCPCPStatus
            //
            linkCPCPStatus.Text = directiveTypeCollection.CPCPDirectiveType.CommonName;
            linkCPCPStatus.Margin = new Padding(5);
            linkCPCPStatus.Enabled = true;
            linkCPCPStatus.Status = Statuses.Satisfactory;
            linkCPCPStatus.Margin = new Padding(1);
            linkCPCPStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkCPCPStatus.DisplayerRequested += linkCPCPStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkCPCPStatus);
            //
            // linkDeferredItems
            //
            linkDeferredItems.Text = directiveTypeCollection.DeferredItemsDirectiveType.CommonName;
            linkDeferredItems.Margin = new Padding(5);
            linkDeferredItems.Enabled = true;
            linkDeferredItems.Status = Statuses.Satisfactory;
            linkDeferredItems.Margin = new Padding(1);
            linkDeferredItems.ReflectionType = ReflectionTypes.DisplayInNew;
            linkDeferredItems.DisplayerRequested += linkDeferedItems_DisplayerRequested;
            Css.ImageLink.Adjust(linkDeferredItems);
            //
            // linkDamages
            //
            linkDamages.Width = 300;
            linkDamages.Text = "Damages Requiring Inspection";
            linkDamages.Margin = new Padding(5);
            linkDamages.Enabled = true;
            linkDamages.Status = Statuses.Satisfactory;
            linkDamages.Margin = new Padding(1);
            linkDamages.ReflectionType = ReflectionTypes.DisplayInNew;
            linkDamages.DisplayerRequested += linkDamages_DisplayerRequested;
            Css.ImageLink.Adjust(linkDamages);
            //
            // linkOutOffPhaseItems
            //
            linkOutOffPhaseItems.Width = 300;
            linkOutOffPhaseItems.Text = directiveTypeCollection.OutOffPhaseDirectiveType.CommonName;
            linkOutOffPhaseItems.Margin = new Padding(5);
            linkOutOffPhaseItems.Enabled = true;
            linkOutOffPhaseItems.Status = Statuses.Satisfactory;
            linkOutOffPhaseItems.Margin = new Padding(1);
            linkOutOffPhaseItems.ReflectionType = ReflectionTypes.DisplayInNew;
            linkOutOffPhaseItems.DisplayerRequested += linkOutOfPhaseItems_DisplayerRequested;
            Css.ImageLink.Adjust(linkOutOffPhaseItems);
            //
            // linkMaintenanceStatus
            //
            linkMaintenanceStatus.Text = "Maintenance Program";
            linkMaintenanceStatus.Margin = new Padding(5);
            linkMaintenanceStatus.Enabled = true;
            linkMaintenanceStatus.Status = Statuses.Satisfactory;
            linkMaintenanceStatus.Margin = new Padding(1);
            linkMaintenanceStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkMaintenanceStatus.DisplayerRequested += linkMaintenanceStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkMaintenanceStatus);
            //
            // linkMonthlyUtilization
            //
            linkMonthlyUtilization.Text = "Monthly Utilization";
            linkMonthlyUtilization.Margin = new Padding(5);
            linkMonthlyUtilization.Enabled = true;
            linkMonthlyUtilization.Status = Statuses.Satisfactory;
            linkMonthlyUtilization.Margin = new Padding(1);
            linkMonthlyUtilization.ReflectionType = ReflectionTypes.DisplayInNew;
            linkMonthlyUtilization.DisplayerRequested += linkMonthlyUtilization_DisplayerRequested;
            Css.ImageLink.Adjust(linkMonthlyUtilization);
            //
            // linkRepairStatus
            //
            linkRepairStatus.Text = directiveTypeCollection.RepairDirectiveType.CommonName;
            linkRepairStatus.Margin = new Padding(5);
            linkRepairStatus.Enabled = true;
            linkRepairStatus.Status = Statuses.Satisfactory;
            linkRepairStatus.Margin = new Padding(1);
            linkRepairStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkRepairStatus.DisplayerRequested += linkRepairStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkRepairStatus);
/*            //
            // linkSSIDStatus
            //
            linkSSIDStatus.Text = directiveTypeCollection.SSIDDirectiveType.CommonName;
            linkSSIDStatus.Margin = new Padding(5);
            linkSSIDStatus.Enabled = true;
            linkSSIDStatus.Status = Statuses.Satisfactory;
            linkSSIDStatus.Margin = new Padding(1);
            linkSSIDStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkSSIDStatus.DisplayerRequested += linkSSIDStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkSSIDStatus);*/

            flowLayoutPanelContainer.Controls.Add(panelADStatus);
            //if (!(aircraftType == AircraftType.Soviet))
                //flowLayoutPanelContainer.Controls.Add(linkAgingProgram);
            flowLayoutPanelContainer.Controls.Add(linkAircraftGeneralData);
            flowLayoutPanelContainer.Controls.Add(linkAircraftTechnicalLogBook);
            flowLayoutPanelContainer.Controls.Add(linkAverageUtilization);
            flowLayoutPanelContainer.Controls.Add(linkAvionicsInventory);
            flowLayoutPanelContainer.Controls.Add(panelComponentStatus);
            if (!(aircraftType == AircraftType.Soviet))
            {
                flowLayoutPanelContainer.Controls.Add(linkCPCPStatus);
                flowLayoutPanelContainer.Controls.Add(linkDeferredItems);
            }
            flowLayoutPanelContainer.Controls.Add(linkComponentChange);
            flowLayoutPanelContainer.Controls.Add(linkDamages);
            flowLayoutPanelContainer.Controls.Add(linkEngineeringOrders);
            flowLayoutPanelContainer.Controls.Add(linkForecastReport);
            flowLayoutPanelContainer.Controls.Add(linkLandingGearStatus);
            flowLayoutPanelContainer.Controls.Add(linkListOfModificationsPerformed);
            flowLayoutPanelContainer.Controls.Add(linkListOfWorkPackages);
            flowLayoutPanelContainer.Controls.Add(linkMaintenanceStatus);
            flowLayoutPanelContainer.Controls.Add(linkMonthlyUtilization);
            if (!(aircraftType == AircraftType.Soviet))
                flowLayoutPanelContainer.Controls.Add(linkOutOffPhaseItems);
            //flowLayoutPanelContainer.Controls.Add(linkRepairStatus);
            flowLayoutPanelContainer.Controls.Add(linkSBStatus);
            //if (!(aircraftType == AircraftType.Soviet))
                //flowLayoutPanelContainer.Controls.Add(linkSSIDStatus);
            // 
            // AircraftReferencesControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            MainControl = flowLayoutPanelContainer;
            Name = "AircraftReferencesControl";
            Size = new Size(411, 146);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkADStatusDisplayerRequested != null) LinkADStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkADStatusAF_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatusAF_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkADStatusAFDisplayerRequested != null) LinkADStatusAFDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkADStatusAP_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatusAP_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkADStatusAPDisplayerRequested != null) LinkADStatusAPDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAverageUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAverageUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAverageUtilizationDisplayerRequested != null)
                LinkAverageUtilizationDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAvionicsInventory_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAvionicsInventory_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAvionicsInventoryDisplayerRequested != null)
                LinkAvionicsInventoryDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentStatusDisplayerRequested != null) LinkComponentStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkComponentStatusHT_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatusHT_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentStatusHTDisplayerRequested != null)
                LinkComponentStatusHTDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkComponentStatusOCCM_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatusOCCM_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentStatusOCCMDisplayerRequested != null)
                LinkComponentStatusOCCMDisplayerRequested(sender, e);
        }

        #endregion
        
        #region private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAircraftGeneralDataDisplayerRequested != null) 
                LinkAircraftGeneralDataDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAircraftTechnicalLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAircraftTechnicalLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        { 
            if (LinkAircraftTechnicalLogBookDisplayerRequested != null)
                LinkAircraftTechnicalLogBookDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkLandingGearStatusDisplayerRequested != null)
                LinkLandingGearStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkListOfModificationsPerformed_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkListOfModificationsPerformed_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkListOfModificationsPerformedDisplayerRequested != null)
                LinkListOfModificationsPerformedDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkListOfWorkPackages_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkListOfWorkPackages_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.Cancel = true;
            if (LinkListOfWorkPackagesDisplayerRequested != null)
              LinkListOfWorkPackagesDisplayerRequested(sender, e);
        }

        #endregion


        #region private void linkMaintenanceStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMaintenanceStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkMaintenanceProgramDisplayerRequested != null) 
                LinkMaintenanceProgramDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkMonthlyUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMonthlyUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkMonthlyUtilizationDisplayerRequested != null)
                LinkMonthlyUtilizationDisplayerRequested(sender, e);
        }

        #endregion
        
/*        #region private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkSSIDStatusDisplayerRequested != null) LinkSSIDStatusDisplayerRequested(sender, e);
        }

        #endregion*/

        #region private void linkRepairStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkRepairStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkRepairStatusDisplayerRequested != null) LinkRepairStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkOutOffPhaseItems_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkOutOfPhaseItems_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkOutOfPhaseItemsDisplayerRequested != null) LinkOutOfPhaseItemsDisplayerRequested(sender, e);
        }

        #endregion
        
        #region private void linkDeferredItems_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDeferedItems_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkDeferredItemsDisplayerRequested != null) LinkDeferredItemsDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkDamages_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDamages_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkDamagesDisplayerRequested != null) 
                LinkDamagesDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkCPCPStatusDisplayerRequested != null) LinkCPCPStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAgingProgramDisplayerRequested != null) LinkAgingProgramDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkSBStatusDisplayerRequested != null) LinkSBStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkEngineeringOrdersDisplayerRequested != null) LinkEngineeringOrdersDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkForecastReport_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkForecastReport_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkForecastReportDisplayerRequested != null) LinkForecastReportDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkComponentChange_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentChange_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentChangeDisplayerRequested != null) LinkComponentChangeDisplayerRequested(sender, e);
        }

        #endregion

        #region protected override void OnEnabledChanged(EventArgs e)

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            linkADStatus.Enabled = Enabled;
            linkAgingProgram.Enabled = Enabled;
            linkAircraftGeneralData.Enabled = Enabled;
            linkAircraftTechnicalLogBook.Enabled = Enabled;
            linkCPCPStatus.Enabled = Enabled;
            linkComponentStatus.Enabled = Enabled;
            linkDeferredItems.Enabled = Enabled;
            linkEngineeringOrders.Enabled = Enabled;
            linkComponentChange.Enabled = Enabled;
            linkMaintenanceStatus.Enabled = Enabled;
            linkListOfModificationsPerformed.Enabled = Enabled; 
            linkOutOffPhaseItems.Enabled = Enabled;
            linkRepairStatus.Enabled = Enabled; 
            linkSBStatus.Enabled = Enabled;
            //linkSSIDStatus.Enabled = Enabled;
            
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> LinkADStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AD Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkADStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkADStatusAFDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AD Status AF
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkADStatusAFDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkADStatusAPDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AD Status AF
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkADStatusAPDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAgingProgramDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Aging Program
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAgingProgramDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAircraftGeneralDataDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Aircraft General Data
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAircraftGeneralDataDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAircraftTechnicalLogBookDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Aircraft Technical Log Book
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAircraftTechnicalLogBookDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAirworthinessCertificateDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Airworthiness Certificate
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAirworthinessCertificateDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkATSFormDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке ATS Form
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkATSFormDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAverageUtilizationDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AverageUtilization
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAverageUtilizationDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAvionicsInventoryDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Avionics Inventory
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAvionicsInventoryDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Component Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkComponentStatusHTDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Component Status HD
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentStatusHTDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkComponentStatusOCCMDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Component Status OCCM
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentStatusOCCMDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке CPCP Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkDamagesDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Damages
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkDamagesDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkDeferredItemsDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Defered Items
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkDeferredItemsDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkEngineeringOrdersDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Engineering Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkEngineeringOrdersDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkComponentChangeDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Engineering Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentChangeDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkForecastReportDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Forecast Report
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkForecastReportDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkLandingGearStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Landing Gear Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkLandingGearStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkListOfModificationsPerformedDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке List of Modifications Performed
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkListOfModificationsPerformedDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkListOfWorkPackagesDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке List of Work Packages
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkListOfWorkPackagesDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkLogBookDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке LogBook
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkLogBookDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkMaintenanceProgramDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Maintenance Program
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkMaintenanceProgramDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkMonthlyUtilizationDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Monthly Utilization
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkMonthlyUtilizationDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkOutOfPhaseItemsDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Out Of Phase Requirements
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkOutOfPhaseItemsDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkRepairStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Repair Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkRepairStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SB Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        #endregion

/*        #region public event EventHandler<ReferenceEventArgs> LinkSSIDStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SSID Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSSIDStatusDisplayerRequested;

        #endregion*/

        #endregion

    }
}