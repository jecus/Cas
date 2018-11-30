using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.ReferenceControls;
using Controls;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения коллекции ссылок для шаблонного ВС и его отчетов
    /// </summary>
    public class TemplateAircraftReferencesControl:RichReferenceContainer
    {

        #region Fields

        private ReferenceStatusImageLinkLabel linkADStatus;
        private ReferenceStatusImageLinkLabel linkAgingProgram;
        private ReferenceStatusImageLinkLabel linkAircraftGeneralData;
        private ReferenceStatusImageLinkLabel linkCPCPStatus;
        private ReferenceStatusImageLinkLabel linkComponentStatus;
        private ReferenceStatusImageLinkLabel linkLandingGearStatus;
        private ReferenceStatusImageLinkLabel linkMaintenanceStatus;
        private ReferenceStatusImageLinkLabel linkSBStatus;

        private FlowLayoutPanel flowLayoutPanelContainer;
        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения коллекции ссылок для шаблонного ВС и его отчетов
        /// </summary>
        public TemplateAircraftReferencesControl()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            linkADStatus = new ReferenceStatusImageLinkLabel();
            linkAgingProgram = new ReferenceStatusImageLinkLabel();
            linkAircraftGeneralData = new ReferenceStatusImageLinkLabel();
            linkCPCPStatus = new ReferenceStatusImageLinkLabel();
            linkComponentStatus = new ReferenceStatusImageLinkLabel();
            linkLandingGearStatus = new ReferenceStatusImageLinkLabel();
            linkMaintenanceStatus = new ReferenceStatusImageLinkLabel();
            linkSBStatus = new ReferenceStatusImageLinkLabel();

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
            linkComponentStatus.Status = Statuses.NotActive;
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
            linkADStatus.Status = Statuses.NotActive;
            Css.ImageLink.Adjust(linkADStatus);
            //
            // linkSBStatus
            //
            linkSBStatus.Text = directiveTypeCollection.SBDirectiveType.CommonName;
            linkSBStatus.Margin = new Padding(5);
            linkSBStatus.Enabled = true;
            linkSBStatus.Margin = new Padding(1);
            linkSBStatus.Status = Statuses.NotActive;
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
            linkAgingProgram.Status = Statuses.NotActive;
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
            linkCPCPStatus.Status = Statuses.NotActive;
            linkCPCPStatus.Margin = new Padding(1);
            linkCPCPStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkCPCPStatus.DisplayerRequested += linkCPCPStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkCPCPStatus);
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
            // linkMaintenanceStatus
            //
            linkMaintenanceStatus.Text = "Maintenance Status";
            linkMaintenanceStatus.Margin = new Padding(5);
            linkMaintenanceStatus.Enabled = true;
            linkMaintenanceStatus.Status = Statuses.NotActive;
            linkMaintenanceStatus.Margin = new Padding(1);
            linkMaintenanceStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkMaintenanceStatus.DisplayerRequested += linkRepairStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkMaintenanceStatus);
            
            flowLayoutPanelContainer.Controls.Add(linkADStatus);
            flowLayoutPanelContainer.Controls.Add(linkAgingProgram);
            flowLayoutPanelContainer.Controls.Add(linkAircraftGeneralData);
            flowLayoutPanelContainer.Controls.Add(linkComponentStatus);
            flowLayoutPanelContainer.Controls.Add(linkCPCPStatus);
            flowLayoutPanelContainer.Controls.Add(linkLandingGearStatus);
            flowLayoutPanelContainer.Controls.Add(linkMaintenanceStatus);
            flowLayoutPanelContainer.Controls.Add(linkSBStatus);
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

        #region private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAgingProgramDisplayerRequested != null) LinkAgingProgramDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkAircraftGeneralDataDisplayerRequested != null) LinkAircraftGeneralDataDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkComponentStatusDisplayerRequested != null) LinkComponentStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkCPCPStatusDisplayerRequested != null) LinkCPCPStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkLandingGearStatusDisplayerRequested != null)
                LinkLandingGearStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkMaintenanceStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkRepairStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkMaintenanceStatusDisplayerRequested != null) LinkMaintenanceStatusDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkSBStatusDisplayerRequested != null) LinkSBStatusDisplayerRequested(sender, e);
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

        #region public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SSIDStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkComponentStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке CPCPStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkCPCPStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkLandingGearStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Landing Gear Status
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkLandingGearStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkMaintenanceProgramDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке MaintenanceStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkMaintenanceStatusDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке SBStatus
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSBStatusDisplayerRequested;

        #endregion

        #endregion

    }
}