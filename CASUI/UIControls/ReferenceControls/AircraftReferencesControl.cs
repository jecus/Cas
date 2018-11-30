using System;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.Directives;
using LTR.UI.Appearance;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;

namespace LTR.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Описание элемент отображения коллекции ссылок для ВС и его отчетов
    /// </summary>
    public class AircraftReferencesControl:RichReferenceContainer
    {

        #region Fields

        private ReferenceStatusImageLinkLabel linkADStatus;
        private ReferenceStatusImageLinkLabel linkAgingProgram;
        private ReferenceStatusImageLinkLabel linkAircraftGeneralData;
        //private ReferenceStatusImageLinkLabel linkAirworthinessCertificate;
        //private ReferenceStatusImageLinkLabel linkATSForm;
        private ReferenceStatusImageLinkLabel linkCPCPStatus;
        private ReferenceStatusImageLinkLabel linkComponentStatus;
        private ReferenceStatusImageLinkLabel linkDeferredItems;
        private ReferenceStatusImageLinkLabel linkDiscrepancies;
        private ReferenceStatusImageLinkLabel linkEngineeringOrders;
        private ReferenceStatusImageLinkLabel linkLogBook;
        //private ReferenceStatusImageLinkLabel linkMaintenanceStatus;
        private ReferenceStatusImageLinkLabel linkModificationStatus;
        private ReferenceStatusImageLinkLabel linkOutOffPhaseItems;
        private ReferenceStatusImageLinkLabel linkRepairStatus;
        private ReferenceStatusImageLinkLabel linkSBStatus;
        private ReferenceStatusImageLinkLabel linkSSIDStatus;

        private FlowLayoutPanel flowLayoutPanelContainer;
        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;

        #endregion

        #region Constructor

        /// <summary>
        /// элемент отображения коллекции ссылок для ВС и его отчетов
        /// </summary>
        public AircraftReferencesControl()
        {
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
        /*
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkAirworthinessCertificate
        {
            get { return linkAirworthinessCertificate.Status; }
            set { linkAirworthinessCertificate.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkATSForm
        {
            get { return linkATSForm.Status; }
            set { linkATSForm.Status = value; }
        }*/
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
        public Statuses LinkDeferredItems
        {
            get { return linkDeferredItems.Status; }
            set { linkDeferredItems.Status = value; }
        }
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkDiscrepancies
        {
            get { return linkDiscrepancies.Status; }
            set { linkDiscrepancies.Status = value; }
        }
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
        public Statuses LinkLogBook
        {
            get { return linkLogBook.Status; }
            set { linkLogBook.Status = value; }
        }
        /*
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkMaintenanceStatus
        {
            get { return linkMaintenanceStatus.Status; }
            set { linkMaintenanceStatus.Status = value; }
        }*/
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkModificationStatus
        {
            get { return linkModificationStatus.Status; }
            set { linkModificationStatus.Status = value; }
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
        /// <summary>
        /// Статус ссылки
        /// </summary>
        public Statuses LinkSSIDStatus
        {
            get { return linkSSIDStatus.Status; }
            set { linkSSIDStatus.Status = value; }
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            linkADStatus = new ReferenceStatusImageLinkLabel();
            linkAgingProgram = new ReferenceStatusImageLinkLabel();
            linkAircraftGeneralData = new ReferenceStatusImageLinkLabel();
            //linkAirworthinessCertificate = new ReferenceStatusImageLinkLabel();
            //linkATSForm = new ReferenceStatusImageLinkLabel();
            linkCPCPStatus = new ReferenceStatusImageLinkLabel();
            linkComponentStatus = new ReferenceStatusImageLinkLabel();
            linkDeferredItems = new ReferenceStatusImageLinkLabel();
            linkDiscrepancies = new ReferenceStatusImageLinkLabel();
            linkEngineeringOrders = new ReferenceStatusImageLinkLabel();
            linkLogBook = new ReferenceStatusImageLinkLabel();
            //linkMaintenanceStatus = new ReferenceStatusImageLinkLabel();
            linkModificationStatus = new ReferenceStatusImageLinkLabel();
            linkOutOffPhaseItems = new ReferenceStatusImageLinkLabel();
            linkRepairStatus = new ReferenceStatusImageLinkLabel();
            linkSBStatus = new ReferenceStatusImageLinkLabel();
            linkSSIDStatus = new ReferenceStatusImageLinkLabel();

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
            flowLayoutPanelContainer.Size = new Size(200, 100);
            flowLayoutPanelContainer.TabIndex = 1;
            //
            // linkComponentStatus
            //
            linkComponentStatus.Text = "Component Status";
            linkComponentStatus.Margin = new Padding(5);
            linkComponentStatus.Enabled = true;
            linkComponentStatus.Margin = new Padding(1);
            linkComponentStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkComponentStatus.DisplayerRequested += linkComponentStatus_DisplayerRequested;
            linkComponentStatus.Status = Statuses.Satisfactory;
            Css.ImageLink.Adjust(linkComponentStatus);
            //
            // linkADStatus
            //
            linkADStatus.Text = directiveTypeCollection.ADDirectiveType.CommonName;
            linkADStatus.Margin = new Padding(5);
            linkADStatus.Enabled = true;
            linkADStatus.Margin = new Padding(1);
            linkADStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkADStatus.DisplayerRequested += linkADStatus_DisplayerRequested;
            linkADStatus.Status = Statuses.Satisfactory;
            Css.ImageLink.Adjust(linkADStatus);
            //
            // linkDiscrepancies
            //
            linkDiscrepancies.Text = "Discrepancies";
            linkDiscrepancies.Margin = new Padding(5);
            linkDiscrepancies.Enabled = true;
            linkDiscrepancies.Margin = new Padding(1);
            linkDiscrepancies.Status = Statuses.Satisfactory;
            Css.ImageLink.Adjust(linkDiscrepancies);
            linkDiscrepancies.ReflectionType = ReflectionTypes.DisplayInNew;
            linkDiscrepancies.DisplayerRequested += linkDiscrepancies_DisplayerRequested;
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
            // linkLogBook
            //
            linkLogBook.Text = "Log Book";
            linkLogBook.Margin = new Padding(5);
            linkLogBook.Enabled = true;
            linkLogBook.Margin = new Padding(1);
            linkLogBook.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLogBook.Status = Statuses.NotActive;
            linkLogBook.DisplayerRequested += linkLogBook_DisplayerRequested;
            Css.ImageLink.Adjust(linkLogBook);
            //
            // linkSBStatus
            //
            linkSBStatus.Text = directiveTypeCollection.SBDirectiveType.CommonName;
            linkSBStatus.Margin = new Padding(5);
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
            // linkAircraftGeneralData
            //
            linkAircraftGeneralData.Text = "Aircraft General Data";
            linkAircraftGeneralData.Margin = new Padding(5);
            linkAircraftGeneralData.Enabled = true;
            linkAircraftGeneralData.Status = Statuses.NotActive;
            linkAircraftGeneralData.Margin = new Padding(1);
            linkAircraftGeneralData.ReflectionType = ReflectionTypes.DisplayInNew;
            linkAircraftGeneralData.DisplayerRequested += linkAircraftGeneralData_DisplayerRequested;
            Css.ImageLink.Adjust(linkAircraftGeneralData);
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
            // linkModificationStatus
            //
            linkModificationStatus.Text = directiveTypeCollection.ModificationDirectiveType.CommonName;
            linkModificationStatus.Margin = new Padding(5);
            linkModificationStatus.Enabled = true;
            linkModificationStatus.Status = Statuses.Satisfactory;
            linkModificationStatus.Margin = new Padding(1);
            linkModificationStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkModificationStatus.DisplayerRequested += linkModificationStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkModificationStatus);
            //
            // linkOutOffPhaseItems
            //
            linkOutOffPhaseItems.Text = directiveTypeCollection.OutOffPhaseDirectiveType.CommonName;
            linkOutOffPhaseItems.Margin = new Padding(5);
            linkOutOffPhaseItems.Enabled = true;
            linkOutOffPhaseItems.Status = Statuses.Satisfactory;
            linkOutOffPhaseItems.Margin = new Padding(1);
            linkOutOffPhaseItems.ReflectionType = ReflectionTypes.DisplayInNew;
            linkOutOffPhaseItems.DisplayerRequested += linkOutOfPhaseItems_DisplayerRequested;
            Css.ImageLink.Adjust(linkOutOffPhaseItems);
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
            //
            // linkSSIDStatus
            //
            linkSSIDStatus.Text = directiveTypeCollection.SSIDDirectiveType.CommonName;
            linkSSIDStatus.Margin = new Padding(5);
            linkSSIDStatus.Enabled = true;
            linkSSIDStatus.Status = Statuses.Satisfactory;
            linkSSIDStatus.Margin = new Padding(1);
            linkSSIDStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkSSIDStatus.DisplayerRequested += linkSSIDStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkSSIDStatus);

            flowLayoutPanelContainer.Controls.Add(linkADStatus);
            flowLayoutPanelContainer.Controls.Add(linkAgingProgram);
            flowLayoutPanelContainer.Controls.Add(linkAircraftGeneralData);
            //flowLayoutPanelContainer.Controls.Add(linkAirworthinessCertificate);
            //flowLayoutPanelContainer.Controls.Add(linkATSForm);
            flowLayoutPanelContainer.Controls.Add(linkComponentStatus);
            flowLayoutPanelContainer.Controls.Add(linkCPCPStatus);
            flowLayoutPanelContainer.Controls.Add(linkDeferredItems);
            flowLayoutPanelContainer.Controls.Add(linkDiscrepancies);
            flowLayoutPanelContainer.Controls.Add(linkEngineeringOrders);
            flowLayoutPanelContainer.Controls.Add(linkLogBook);
            //flowLayoutPanelContainer.Controls.Add(linkMaintenanceStatus);
            flowLayoutPanelContainer.Controls.Add(linkModificationStatus);
            flowLayoutPanelContainer.Controls.Add(linkOutOffPhaseItems);
            flowLayoutPanelContainer.Controls.Add(linkRepairStatus);
            flowLayoutPanelContainer.Controls.Add(linkSBStatus);
            flowLayoutPanelContainer.Controls.Add(linkSSIDStatus);
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
        
        #region private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentStatusDisplayerRequested != null) LinkComponentStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAircraftGeneralDataDisplayerRequested != null) LinkAircraftGeneralDataDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkLogBookDisplayerRequested != null) LinkLogBookDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkADStatusDisplayerRequested != null) LinkADStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkSSIDStatusDisplayerRequested != null) LinkSSIDStatusDisplayerRequested(sender, e);
        }

        #endregion

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

        #region private void linkModificationStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkModificationStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkModificationStatusDisplayerRequested != null) LinkModificationStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkDeferredItems_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDeferedItems_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkDeferredItemsDisplayerRequested != null) LinkDeferredItemsDisplayerRequested(sender, e);
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

        #region private void linkDiscrepancies_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDiscrepancies_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkDiscrepanciesDisplayerRequested != null) LinkDiscrepanciesDisplayerRequested(sender, e);
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> LinkADStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке ADStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkADStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAgingProgramDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AgingProgram
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAgingProgramDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAircraftGeneralDataDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AircraftGeneralData
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAircraftGeneralDataDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkAirworthinessCertificateDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке AirworthinessCertificate
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkAirworthinessCertificateDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkATSFormDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке linkATSForm
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkATSFormDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке CPCPStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkDeferredItemsDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке DeferedItems
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkDeferredItemsDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkDiscrepanciesDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Discrepancies
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkDiscrepanciesDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkEngineeringOrdersDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке EngineeringOrders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkEngineeringOrdersDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkLogBookDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке LogBook
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkLogBookDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkMaintenanceStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке MaintenanceStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkMaintenanceStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkModificationStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке ModificationStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkModificationStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkOutOfPhaseItemsDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке OutOfPhaseItems
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkOutOfPhaseItemsDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkRepairStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке RepairStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkRepairStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SBStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkSSIDStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SSIDStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSSIDStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SSIDStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        #endregion


        #endregion

    }
}
