using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftTechnicalLogBookControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DiscrepanciesControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MonthlyUtilizationsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CASReports;
using CASReports.Builders;
using Controls;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;

using Controls.AvMultitabControl.Auxiliary;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Отображает Воздушное судно
    /// </summary>
    [ToolboxItem(true)]
    public class AircraftScreen : UserControl, IReference
    {

        #region Fields

        private DispatcheredMultitabControl dispatcheredMultitabControl;

        private AnimatedThreadWorker animatedThreadWorker;

        private AircraftHeaderControl aircraftHeader;
        private AircraftInfoReference aircraftInfoReference;
        private AircraftReferencesControl aircraftReferencesControl1;
        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;
        /// <summary>
        /// Текущее ВС
        /// </summary>
        protected Aircraft currentAircraft;
        private BaseDetailControl aircraftFrameControl;
        private BaseDetailControl[] enginesControls = new DispatcheredAircraftBaseDetailInfoControl[0];
        private BaseDetailControl apuControl;
        private LandingGearsButtonsControl landingGearsButtons;
        private FlowLayoutPanel flowLayoutPanelBaseDetailsContainer;
        private FooterControl footerControl;
        private HeaderControl headerControl;
        private Panel mainPanel;
        private readonly ReferenceStatusImageLinkLabel linkLandingGearStatus = new ReferenceStatusImageLinkLabel();
        private TableLayoutPanel tableLayoutPanelReferences;
        private readonly Icons icons = new Icons();
        private RichReferenceButton buttonDeleteAircraft;
        private bool permissionForDelete;
        
        private const int LANDING_GEAR_STATUS_LINK_MARGIN = 17;
        private const int REFERENCES_WIDTH = 400;
        private const int REFERENCES_HEIGHT = 800;
        private const int LANDING_GEAR_INTERVAL = 50;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создаёт экземпляр элемента управления, отображающего воздушное судно
        /// </summary>
        ///<param name="currentAircraft">Воздушное судно для отображения</param>
        ///<exception cref="ArgumentNullException"></exception>
        public AircraftScreen(Aircraft currentAircraft)
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "Cannot display null-aircraft");
            ((DispatcheredAircraftScreen)this).InitComplition += AircraftScreen_InitComplition;
            this.currentAircraft = currentAircraft;
            HookEvents();
            InitializeComponent();

            UpdateHeader();
            UpdateAircraft(false);
        }
        
        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        /// <summary>
        /// Semiautomatically generated code
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelReferences = new TableLayoutPanel();
            mainPanel = new Panel();
            flowLayoutPanelBaseDetailsContainer = new FlowLayoutPanel();
            aircraftReferencesControl1 = new AircraftReferencesControl(currentAircraft.Type);
            aircraftInfoReference = new AircraftInfoReference(currentAircraft);
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl(currentAircraft, true, false);
            buttonDeleteAircraft = new RichReferenceButton();
            aircraftFrameControl = new BaseDetailControl(currentAircraft.AircraftFrame);
            landingGearsButtons = new LandingGearsButtonsControl(currentAircraft);
            permissionForDelete = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Remove);
            // 
            // tableLayoutPanelReferences
            // 
            tableLayoutPanelReferences.AutoSize = true;
            tableLayoutPanelReferences.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelReferences.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelReferences.Controls.Add(aircraftReferencesControl1, 0, 0);
            tableLayoutPanelReferences.Controls.Add(aircraftInfoReference, 0, 1);
            tableLayoutPanelReferences.Location = new Point(0, 0);
            tableLayoutPanelReferences.RowStyles.Add(new RowStyle());
            tableLayoutPanelReferences.RowStyles.Add(new RowStyle());
            tableLayoutPanelReferences.MinimumSize = new Size(REFERENCES_WIDTH, REFERENCES_HEIGHT);
            tableLayoutPanelReferences.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(flowLayoutPanelBaseDetailsContainer);
            mainPanel.Controls.Add(tableLayoutPanelReferences);
            mainPanel.Controls.Add(landingGearsButtons);
            mainPanel.Controls.Add(linkLandingGearStatus);
            mainPanel.Controls.Add(buttonDeleteAircraft);
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.SizeChanged += mainPanel_SizeChanged;
            // 
            // flowLayoutPanelBaseDetailsContainer
            // 
            flowLayoutPanelBaseDetailsContainer.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelBaseDetailsContainer.AutoScroll = true;
            flowLayoutPanelBaseDetailsContainer.AutoSize = true;
            flowLayoutPanelBaseDetailsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelBaseDetailsContainer.Location = new Point(REFERENCES_WIDTH, 0);
            flowLayoutPanelBaseDetailsContainer.Padding = new Padding(0, 27, 0, 0);
            flowLayoutPanelBaseDetailsContainer.TabIndex = 1;
            flowLayoutPanelBaseDetailsContainer.SizeChanged += flowLayoutPanelContentContainer_SizeChanged;
            flowLayoutPanelBaseDetailsContainer.Controls.Add(aircraftFrameControl);
            // 
            // aircraftReferencesControl1
            // 
            aircraftReferencesControl1.AutoSize = true;
            aircraftReferencesControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftReferencesControl1.BackColor = Css.CommonAppearance.Colors.BackColor;
            aircraftReferencesControl1.Caption = "Aircraft references";
            aircraftReferencesControl1.DescriptionTextColor = Color.DimGray;
            aircraftReferencesControl1.Dock = DockStyle.Top;
            aircraftReferencesControl1.Margin = new Padding(30, 30, 3, 3);
            aircraftReferencesControl1.MinimumSize = new Size(50, 50);
            aircraftReferencesControl1.Size = new Size(362, 528);
            aircraftReferencesControl1.TabIndex = 0;
            aircraftReferencesControl1.UpperLeftIcon = icons.GrayArrow;
            aircraftReferencesControl1.LinkADStatusDisplayerRequested += linkADStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkADStatusAFDisplayerRequested += aircraftReferencesControl1_LinkADStatusAFDisplayerRequested;
            aircraftReferencesControl1.LinkADStatusAPDisplayerRequested += aircraftReferencesControl1_LinkADStatusAPDisplayerRequested;
            aircraftReferencesControl1.LinkAgingProgramDisplayerRequested += linkAgingProgram_DisplayerRequested;
            aircraftReferencesControl1.LinkAircraftGeneralDataDisplayerRequested += LinkAircraftGeneralData_DisplayerRequested;
            aircraftReferencesControl1.LinkAircraftTechnicalLogBookDisplayerRequested += LinkAircraftTechnicalLogBook_DisplayerRequested;
            aircraftReferencesControl1.LinkAverageUtilizationDisplayerRequested += LinkAverageUtilization_DisplayerRequested;
            aircraftReferencesControl1.LinkAvionicsInventoryDisplayerRequested += LinkAvionicsInventory_DisplayerRequested;
            aircraftReferencesControl1.LinkComponentStatusDisplayerRequested += LinkComponentStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkComponentStatusHTDisplayerRequested += LinkComponentStatusHT_DisplayerRequested;
            aircraftReferencesControl1.LinkComponentStatusOCCMDisplayerRequested += LinkComponentStatusOCCM_DisplayerRequested;
            aircraftReferencesControl1.LinkComponentChangeDisplayerRequested += LinkComponentChange_DisplayerRequested;
            aircraftReferencesControl1.LinkCPCPStatusDisplayerRequested += linkCPCPStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkDeferredItemsDisplayerRequested += linkDeferredItems_DisplayerRequested;
            aircraftReferencesControl1.LinkDamagesDisplayerRequested += LinkDamages_DisplayerRequested;
            aircraftReferencesControl1.LinkOutOfPhaseItemsDisplayerRequested += linkOutOfPhaseItems_DisplayerRequested;
            aircraftReferencesControl1.LinkSBStatusDisplayerRequested += linkSBStatus_DisplayerRequested;
            //aircraftReferencesControl1.LinkSSIDStatusDisplayerRequested += linkSSIDStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkEngineeringOrdersDisplayerRequested += linkEngineeringOrders_DisplayerRequested;
            aircraftReferencesControl1.LinkForecastReportDisplayerRequested += LinkForecastReport_DisplayerRequested;
            aircraftReferencesControl1.LinkLandingGearStatusDisplayerRequested += LinkLandingGearStatus_DisplayerRequested;
            aircraftReferencesControl1.LinkListOfModificationsPerformedDisplayerRequested += linkListOfModificationsPerformed_DisplayerRequested;
            aircraftReferencesControl1.LinkMonthlyUtilizationDisplayerRequested += LinkMonthlyUtilization_DisplayerRequested;
            aircraftReferencesControl1.LinkListOfWorkPackagesDisplayerRequested += aircraftReferencesControl1_LinkListOfWorkPackagesDisplayerRequested;
            aircraftReferencesControl1.LinkLogBookDisplayerRequested += LinkLogBook_DisplayerRequested;
            aircraftReferencesControl1.LinkMaintenanceProgramDisplayerRequested += linkMaintenanceStatusDisplayerRequested;
            aircraftReferencesControl1.LinkRepairStatusDisplayerRequested += linkRepairStatus_DisplayerRequested;
            // 
            // aircraftInfoReference
            // 
            aircraftInfoReference.AutoSize = true;
            aircraftInfoReference.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftInfoReference.BackColor = Css.CommonAppearance.Colors.BackColor;
            aircraftInfoReference.Caption = "Aircraft information";
            aircraftInfoReference.DescriptionTextColor = Color.DimGray;
            aircraftInfoReference.Dock = DockStyle.Left;
            aircraftInfoReference.Margin = new Padding(30, 0, 30, 3);
            aircraftInfoReference.MinimumSize = new Size(50, 50);
            aircraftInfoReference.Size = new Size(335, 50);
            aircraftInfoReference.TabIndex = 1;
            aircraftInfoReference.UpperLeftIcon = icons.GrayArrow;
            aircraftInfoReference.Visible = false;
            // 
            // footerControl
            // 
            footerControl.TabIndex = 2;
            // 
            // headerControl
            // 
            headerControl.Controls.Add(aircraftHeader);
         
            headerControl.EditDisplayerText = "Edit Aircraft";
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.EditDisplayerRequested += LinkAircraftGeneralData_DisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "aircraft_operation";
            // 
            // buttonDeleteAircraft
            // 
            buttonDeleteAircraft.BackColor = Color.Transparent;
            buttonDeleteAircraft.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteAircraft.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteAircraft.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteAircraft.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteAircraft.Icon = icons.Delete;
            buttonDeleteAircraft.IconNotEnabled = icons.DeleteGray;
            buttonDeleteAircraft.IconLayout = ImageLayout.Center;
            buttonDeleteAircraft.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteAircraft.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteAircraft.Size = new Size(140, 50);
            buttonDeleteAircraft.TabIndex = 16;
            buttonDeleteAircraft.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteAircraft.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteAircraft.TextMain = "Delete";
            buttonDeleteAircraft.TextSecondary = "aircraft";
            buttonDeleteAircraft.DisplayerRequested += buttonDeleteAircraft_DisplayerRequested;
            buttonDeleteAircraft.Visible = permissionForDelete;
            //
            // linkLandingGearStatus
            //
            Css.ImageLink.Adjust(linkLandingGearStatus);
            linkLandingGearStatus.Margin = new Padding(1);
            linkLandingGearStatus.Size = new Size(300, 30);
            linkLandingGearStatus.Text = "View Landing Gear Status";
            linkLandingGearStatus.TextAlign = ContentAlignment.MiddleLeft;
            linkLandingGearStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLandingGearStatus.DisplayerRequested += LinkLandingGearStatus_DisplayerRequested;
            //
            // aircraftFrameControl
            //
            aircraftFrameControl.TabIndex = 0;
            //
            // landingGearsButtons
            //
            landingGearsButtons.LocationChanged += landingGearsButtons_LocationChanged;
            landingGearsButtons.SizeChanged += landingGearsButtons_SizeChanged;
            // 
            // AircraftScreen
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);

        }

        #endregion

        #region private void UpdateAircraft()

        private void UpdateAircraft()
        {
            UpdateAircraft(true);
        }

        #endregion

        #region private void UpdateAircraft(bool reloadAircraft)

        private void UpdateAircraft(bool reloadAircraft)
        {
            if (reloadAircraft)
            {
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker = new AnimatedThreadWorker(BackGroundAircraftReloading, this);
                animatedThreadWorker.State = "Reloading " + currentAircraft.RegistrationNumber;
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                animatedThreadWorker.StartThread();
                return;
            }
            FinishedUpdatingAricraft();
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            FinishedUpdatingAricraft();
        }

        #endregion

        #region private void BackGroundAircraftReloading()

        private void BackGroundAircraftReloading()
        {
            try
            {

            currentAircraft.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

        }

        #endregion

        #region private void FinishedUpdatingAricraft()

        private void FinishedUpdatingAricraft()
        {
            UnHookBaseDetailEvents();
            UpdateHeader();
            aircraftInfoReference.UpdateData();
            AdjustConditions();

            if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(apuControl))
                flowLayoutPanelBaseDetailsContainer.Controls.Remove(apuControl);
            for (int i = 0; i < enginesControls.Length; i++)
            {
                if (flowLayoutPanelBaseDetailsContainer.Controls.Contains(enginesControls[i]))
                    flowLayoutPanelBaseDetailsContainer.Controls.Remove(enginesControls[i]);
            }

            aircraftFrameControl.UpdateInformation();
            List<Engine> engines = new List<Engine>();
            engines.AddRange(currentAircraft.Engines);
            engines.Sort(new EnginePositionSerialNumberComparerDesc());
            enginesControls = new BaseDetailControl[engines.Count];
            flowLayoutPanelBaseDetailsContainer.AutoSize = false;
            for (int i = 0; i < engines.Count; i++)
            {
                if (engines[i] != null)
                {
                    enginesControls[i] = new BaseDetailControl(engines[i]);
                    enginesControls[i].UpdateFromStatus(engines[i].ConditionState);
                    enginesControls[i].TabIndex = engines.Count - i;
                    enginesControls[i].Tag = engines[i];
                    flowLayoutPanelBaseDetailsContainer.Controls.Add(enginesControls[i]);
                }
            }
            if (currentAircraft.Apu != null)
            {
                apuControl = new BaseDetailControl(currentAircraft.Apu);
                apuControl.UpdateFromStatus(currentAircraft.Apu.ConditionState);
                apuControl.Height = 50;
                apuControl.TabIndex = enginesControls.Length + 1;
                flowLayoutPanelBaseDetailsContainer.Controls.Add(apuControl);
            }
            flowLayoutPanelBaseDetailsContainer.AutoSize = true;
            landingGearsButtons.UpdateInformation();
            HookBaseDetailEvents();
        }

        #endregion

        #region private void AdjustConditions()

        private void AdjustConditions()
        {
            BaseDetailDirective[] directives = currentAircraft.ContainedDirectives;
            Statuses adStatus = Statuses.Satisfactory;
            Statuses cpcpStatus = Statuses.Satisfactory;
            Statuses agingProgramStatus = Statuses.Satisfactory;
            Statuses DIStatus = Statuses.Satisfactory;
            Statuses damagesStatus = Statuses.Satisfactory;
            Statuses OOPIStatus = Statuses.Satisfactory;
            Statuses modficationStatus = Statuses.Satisfactory;
            Statuses eoStatus = Statuses.Satisfactory;
            Statuses repairStatus = Statuses.Satisfactory;
            Statuses sbStatus = Statuses.Satisfactory;
            Statuses ssidStatus = Statuses.Satisfactory;
            for (int i = 0; i < directives.Length; i++)
            {
                BaseDetailDirective directive = directives[i];
                int typeId = directive.DirectiveType.ID;

                if (typeId == (int)DirectiveTypeID.ADDirectiveTypeID)
                {
                    ProcessStatus(directive, ref adStatus);
                    continue;
                }

                if (typeId == (int)DirectiveTypeID.CPCPDirectiveTypeID)
                {
                    ProcessStatus(directive, ref cpcpStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.EngeneeringOrdersDirectiveTypeID)
                {
                    ProcessStatus(directive, ref eoStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.DamageRequiringInspectionTypeID)
                {
                    ProcessStatus(directive, ref damagesStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.DeferredItemsDirectiveTypeID)
                {
                    ProcessStatus(directive, ref DIStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.AgingProgramDirectiveTypeID)
                {
                    ProcessStatus(directive, ref agingProgramStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.ModificationDirectiveTypeID)
                {
                    ProcessStatus(directive, ref modficationStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.OutOffPhaseDirectiveTypeID)
                {
                    ProcessStatus(directive, ref OOPIStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.RepairDirectiveTypeID)
                {
                    ProcessStatus(directive, ref repairStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.SBDirectiveTypeID)
                {
                    ProcessStatus(directive, ref sbStatus);
                    continue;
                }
                if (typeId == (int)DirectiveTypeID.SSIDDirectiveTypeID)
                {
                    ProcessStatus(directive, ref ssidStatus);
                    continue;
                }
            }
            aircraftReferencesControl1.LinkADStatus = adStatus;
            aircraftReferencesControl1.LinkAgingProgram = agingProgramStatus;
            aircraftReferencesControl1.LinkComponentStatus = GetStatus(currentAircraft.ContainedDetails);
            aircraftReferencesControl1.LinkCPCPStatus = cpcpStatus;
            aircraftReferencesControl1.LinkDeferredItems = DIStatus;
            aircraftReferencesControl1.LinkDamages = damagesStatus;
            aircraftReferencesControl1.LinkEngineeringOrders = eoStatus;
            DetailCollectionFilter avionicsInventoryFilter = new DetailCollectionFilter(currentAircraft.ContainedDetails, new DetailFilter[] { new AvionicsInventoryFilter(true, true, true) });
            aircraftReferencesControl1.LinkAvionicsInventory = GetStatus(avionicsInventoryFilter.GatherDetails());
            DetailCollectionFilter filter = new DetailCollectionFilter(currentAircraft.ContainedDetails, new DetailFilter[] { new LandingGearsFilter(true, true, true, true) });
            aircraftReferencesControl1.LinkLandingGearStatus = linkLandingGearStatus.Status = GetStatus(filter.GatherDetails());
            DirectiveConditionState maintenanceState = currentAircraft.MaintenanceDirectiveCondition;
            if (maintenanceState == DirectiveConditionState.NotSatisfactory) aircraftReferencesControl1.LinkMaintenanceStatus = Statuses.NotSatisfactory;
            if (maintenanceState == DirectiveConditionState.Satisfactory) aircraftReferencesControl1.LinkMaintenanceStatus = Statuses.Satisfactory;
            if (maintenanceState == DirectiveConditionState.Notify) aircraftReferencesControl1.LinkMaintenanceStatus = Statuses.Notify;
            aircraftReferencesControl1.LinkOutOffPhaseItems = OOPIStatus;
            aircraftReferencesControl1.LinkRepairStatus = repairStatus;
            aircraftReferencesControl1.LinkSBStatus = sbStatus;
            //aircraftReferencesControl1.LinkSSIDStatus = ssidStatus;
            //AdjustComponentStatus();
        }

        #endregion

        #region private Statuses GetStatus(Detail[] details)

        private Statuses GetStatus(Detail[] details)
        {

            Statuses status = Statuses.Satisfactory;
            for (int i = 0; i < details.Length; i++)
            {
                Detail detail = details[i];
                if (detail.ConditionState == DirectiveConditionState.NotSatisfactory)
                {
                    status = Statuses.NotSatisfactory;
                    break;
                }
                if (detail.ConditionState == DirectiveConditionState.Notify)
                    status = Statuses.Notify;
            }
            return status;
        }

        #endregion

        #region private static void ProcessStatus(BaseDetailDirective directive, ref Statuses status)

        private static void ProcessStatus(BaseDetailDirective directive, ref Statuses status)
        {
            if (directive.Condition == DirectiveConditionState.NotSatisfactory)
                status = Statuses.NotSatisfactory;
            if (directive.Condition == DirectiveConditionState.Notify && status == Statuses.Satisfactory)
                status = Statuses.Notify;
        }

        #endregion
        
        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeader.Aircraft = currentAircraft;
            if (currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update))
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "Edit";
                headerControl.ActionControl.ButtonEdit.Icon = icons.Edit;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.EditGray;
            }
            else
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "View";
                headerControl.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }
        }

        #endregion

        
        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            flowLayoutPanelBaseDetailsContainer.Visible = false;
            UpdateAircraft();
            flowLayoutPanelBaseDetailsContainer.Visible = true;
        }

        #endregion

        #region private void buttonDeleteAircraft_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteAircraft_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current aircraft?", "Confirm deleting " + currentAircraft.RegistrationNumber, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {

                    currentAircraft.Operator.AircraftCollection.Remove(currentAircraft);
                    MessageBox.Show("Aircraft was deleted successfully", (string)new TermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion
        


        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
       
        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredADStatusView(currentAircraft);
        }

        #endregion

        #region private void aircraftReferencesControl1_LinkADStatusAFDisplayerRequested(object sender, ReferenceEventArgs e)

        private void aircraftReferencesControl1_LinkADStatusAFDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredADStatusView(currentAircraft, new DirectiveCollectionFilter(new DirectiveFilter[]{new DirectiveADTypeFilter(ADType.Airframe)}));
        }

        #endregion

        #region private void aircraftReferencesControl1_LinkADStatusAPDisplayerRequested(object sender, ReferenceEventArgs e)

        private void aircraftReferencesControl1_LinkADStatusAPDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredADStatusView(currentAircraft, new DirectiveCollectionFilter(new DirectiveFilter[] { new DirectiveADTypeFilter(ADType.Appliance)}));
        }

        #endregion

        #region private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkAgingProgram_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.AgineProgramDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredAgingProgramView(currentAircraft);
        }

        #endregion

        #region private void LinkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Aircraft General Data";
            e.RequestedEntity = new DispatcheredAircraftGeneralDataScreen(currentAircraft);
        }

        #endregion

        #region private void LinkAircraftTechnicalLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkAircraftTechnicalLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". List of Aircraft Technical Log Books";
            e.RequestedEntity = new DispatcheredATLBsScreen(currentAircraft);
        }

        #endregion

        #region private void LinkAverageUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkAverageUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            AverageUtilizationForm form = new AverageUtilizationForm(currentAircraft);
            form.ShowDialog();
            e.Cancel = true;
        }

        #endregion

        #region private void LinkAvionicsInventory_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkAvionicsInventory_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Component Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new AvionicsInventoryFilter(true, true, true) }), new AvionicsInventoryStatusReportBuilder());
        }

        #endregion


        #region private void LinkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkComponentStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Component Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new MaintananceFilter(false, false, false, true) }), new ComponentStatusReportBuilder(null));
        }

        #endregion

        #region private void LinkComponentStatusHT_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkComponentStatusHT_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Component Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new MaintananceFilter(false, false, false, true) }), new ComponentStatusReportBuilder(MaintenanceTypeCollection.Instance.HardTimeType));
        }

        #endregion

        #region private void LinkComponentStatusOCCM_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkComponentStatusOCCM_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Component Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new MaintananceFilter(true, false, true, false) }), new ComponentStatusOCCMReportBuilder());
        }

        #endregion

        #region private void LinkComponentChange_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkComponentChange_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + " Component Change Status";
            e.RequestedEntity = new DispatcheredComponentChangeScreen(currentAircraft);//,new DirectiveCollectionFilter(currentAircraft.ContainedDirectives,new DirectiveFilter[1] {new EngeneeringOrderFilter()}));
        }

        #endregion

        #region private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkCPCPStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.CPCPDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredCPCPDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void linkDeferredItems_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDeferredItems_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.DeferredItemsDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredDeferredItemsView(currentAircraft);
        }

        #endregion

        #region private void LinkDamages_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDamages_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.DamageRequiringInspectionDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredDamageDirectiveListScreen(currentAircraft);
        }

        #endregion

        #region private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.EngineeringOrdersDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredEngeneeringOrdersDirectiveListScreen(currentAircraft.AircraftFrame);//,new DirectiveCollectionFilter(currentAircraft.ContainedDirectives,new DirectiveFilter[1] {new EngeneeringOrderFilter()}));
        }

        #endregion

        #region private void LinkForecastReport_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkForecastReport_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDiscrepanciesScreen(currentAircraft);
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Forecast Report";
        }

        #endregion

        #region private void linkListOfModificationsPerformed_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkListOfModificationsPerformed_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". List of Modifications Performed";
            e.RequestedEntity = new DispatcheredModificationsPerformedListScreen(currentAircraft);
        }

        #endregion

        #region private void aircraftReferencesControl1_LinkListOfWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)

        private void aircraftReferencesControl1_LinkListOfWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". List of Work Packages";
            e.RequestedEntity = new DispatcheredWorkPackagesListScreen(currentAircraft);
            //e.Cancel = true;
        }

        #endregion

        #region private void LinkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
/*
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Log Book";
            e.RequestedEntity = new DispatcheredBaseDetailLogBookScreen(currentAircraft.AircraftFrame);
*/
        }

        #endregion

        #region private void linkMaintenanceStatusDisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMaintenanceStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Maintenance Program";
            e.RequestedEntity = new DispatcheredMaintenanceStatusControl(currentAircraft.MaintenanceDirective);
        }

        #endregion
        
        #region private void LinkMonthlyUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkMonthlyUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Monthly Utilization";
            e.RequestedEntity = new DispatcheredMonthlyUtilizationScreen(currentAircraft);
        }

        #endregion

        #region private void linkOutOfPhaseItems_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkOutOfPhaseItems_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.OutOffPhaseDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredOutOffPhaseView(currentAircraft);
        }

        #endregion

        #region private void linkRepairStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkRepairStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.RepairDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredRepairView(currentAircraft);
        }

        #endregion

        #region private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredSBStatusView(currentAircraft);
        }

        #endregion

/*        #region private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSSIDStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + directiveTypeCollection.SSIDDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredSSIDStatusView(currentAircraft);
        }

        #endregion*/

        #region private void LinkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Landing Gear Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new AllDetailFilter() }), new DetailCollectionFilter(new DetailFilter[] { new LandingGearsFilter(true, true, true, true) }), new LandingGearStatusReportBuilder(currentAircraft));
        }

        #endregion
        

        #region private void HookEvents()

        private void HookEvents()
        {
            currentAircraft.Saved += currentAircraft_Saved;
            currentAircraft.BaseDetailRemoved += currentAircraft_BaseDetailRemoved;
            currentAircraft.BaseDetailAdded += currentAircraft_BaseDetailAdded;
        }

        #endregion

        #region private void UnHookEvents()

        private void UnHookEvents()
        {
            currentAircraft.Saved -= currentAircraft_Saved;
            currentAircraft.BaseDetailRemoved -= currentAircraft_BaseDetailRemoved;
            currentAircraft.BaseDetailAdded -= currentAircraft_BaseDetailAdded;
        }

        #endregion

        #region private void HookBaseDetailEvents()

        private void HookBaseDetailEvents()
        {
            for (int i = 0; i < currentAircraft.BaseDetails.Length; i++ )
                currentAircraft.BaseDetails[i].Saved += AircraftScreen_Saved;
        }

        #endregion

        #region private void UnHookBaseDetailEvents()

        private void UnHookBaseDetailEvents()
        {
            for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                currentAircraft.BaseDetails[i].Saved -= AircraftScreen_Saved;
        }

        #endregion

        #region private void AircraftScreen_Saved(object sender, EventArgs e)

        private void AircraftScreen_Saved(object sender, EventArgs e)
        {
            BaseDetail baseDetail = (BaseDetail) sender;
            if (baseDetail is AircraftFrame)
                aircraftFrameControl.UpdateInformation();
            else if (baseDetail is Engine)
            {
                for (int i = 0; i < enginesControls.Length; i++)
                {
                    if (baseDetail.ID == ((Engine)enginesControls[i].Tag).ID)
                    {
                        enginesControls[i].UpdateInformation();
                        break;
                    }
                }
            }
            else if (baseDetail is APU)
                apuControl.UpdateInformation();
            else if (baseDetail is GearAssembly)
                landingGearsButtons.UpdateInformation();
        }

        #endregion

        #region private void currentAircraft_Saved(object sender, EventArgs e)

        private void currentAircraft_Saved(object sender, EventArgs e)
        {
            aircraftInfoReference.UpdateData();
            if (DisplayerRequested != null)
                DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, currentAircraft.RegistrationNumber));
        }

        #endregion

        #region private void currentAircraft_BaseDetailAdded(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_BaseDetailAdded(object sender, CollectionChangeEventArgs e)
        {
            UpdateAircraft(false);
        }

        #endregion

        #region private void currentAircraft_BaseDetailRemoved(object sender, CollectionChangeEventArgs e)

        private void currentAircraft_BaseDetailRemoved(object sender, CollectionChangeEventArgs e)
        {
            UpdateAircraft(false);
        }

        #endregion

        #region private void AircraftScreen_InitComplition(object sender, EventArgs e)

        private void AircraftScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookBaseDetailEvents();
                UnHookEvents();
            }
        }

        #endregion


        #region protected void SetEnabledToControls(bool isEnabled)

        protected void SetEnabledToControls(bool isEnabled)
        {
            headerControl.ActionControl.ButtonReload.Enabled = isEnabled;
            headerControl.ActionControl.ButtonEdit.Enabled = isEnabled;
            buttonDeleteAircraft.Enabled = isEnabled && permissionForDelete;
            aircraftReferencesControl1.Enabled = isEnabled;
            aircraftInfoReference.Enabled = isEnabled;
            if (aircraftFrameControl != null)
                aircraftFrameControl.Enabled = isEnabled;
            for (int i = 0; i < enginesControls.Length; i++)
            {
                if (enginesControls[i] != null) enginesControls[i].Enabled = isEnabled;
            }
            if (apuControl != null)
                apuControl.Enabled = isEnabled;
            if (landingGearsButtons != null)
                landingGearsButtons.Enabled = isEnabled;
            linkLandingGearStatus.Enabled = isEnabled;
            headerControl.ContextActionControl.ButtonClose.Enabled = isEnabled;
        }

        #endregion


        #region private void mainPanel_SizeChanged(object sender, EventArgs e)

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanelBaseDetailsContainer.MinimumSize = new Size(Width - REFERENCES_WIDTH - 20, 0);
            flowLayoutPanelBaseDetailsContainer.MaximumSize = new Size(Width - REFERENCES_WIDTH - 20, 900);
            buttonDeleteAircraft.Location = new Point(mainPanel.Right - buttonDeleteAircraft.Width, mainPanel.Bottom - buttonDeleteAircraft.Height - 60);
        }

        #endregion

        #region private void flowLayoutPanelBaseDetailsContainer_SizeChanged(object sender, EventArgs e)

        private void flowLayoutPanelContentContainer_SizeChanged(object sender, EventArgs e)
        {
            landingGearsButtons.Location = new Point(flowLayoutPanelBaseDetailsContainer.Left, flowLayoutPanelBaseDetailsContainer.Bottom + LANDING_GEAR_INTERVAL);
        }

        #endregion
        
        #region private void landingGearsButtons_LocationChanged(object sender, EventArgs e)

        private void landingGearsButtons_LocationChanged(object sender, EventArgs e)
        {
            linkLandingGearStatus.Location = new Point(landingGearsButtons.Left + LANDING_GEAR_STATUS_LINK_MARGIN, landingGearsButtons.Bottom);
        }

        #endregion
        
        #region private void landingGearsButtons_SizeChanged(object sender, EventArgs e)

        private void landingGearsButtons_SizeChanged(object sender, EventArgs e)
        {
            linkLandingGearStatus.Location = new Point(landingGearsButtons.Left + LANDING_GEAR_STATUS_LINK_MARGIN, landingGearsButtons.Bottom);
        }

        #endregion

        #endregion

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }
}