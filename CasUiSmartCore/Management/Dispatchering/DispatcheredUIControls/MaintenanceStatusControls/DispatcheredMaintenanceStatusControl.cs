using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CASReports.Builders;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Класс, описывающий элемент отображения Maintenance Status а
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredMaintenanceStatusControl : Control, IDisplayingEntity
    {

        #region Fields

        private HeaderControl headerControl;
        private AircraftHeaderControl aircraftHeaderControl;
        private FooterControl footerControl;
        private Panel mainPanel;
        private FlowLayoutPanel containedPanel;

        private ExtendableRichContainer extendableRichContainerCompliance;
        private ExtendableRichContainer extendableRichContainerLimitations;
        private ExtendableRichContainer extendableRichContainerSummary;
        
        private MaintenanceStatusSummaryControl summaryControl;
        private MaintenanceStatusLimitationsControl limitationsControl;
        private MaintenanceStatusComplianceControl complianceControl;
        
        private readonly Aircraft aircraft;
        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент упарвления для отображения Maintenance Status
        /// </summary>
        /// <param name="directive">Директива MaitenanceDirective</param>
        public DispatcheredMaintenanceStatusControl(MaintenanceDirective directive)
        {
            aircraft = (Aircraft)directive.Parent;
            InitializeComponent();
            DisplayData(aircraft);
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;

            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            footerControl = new FooterControl();
            mainPanel = new Panel();
            containedPanel = new FlowLayoutPanel();
            extendableRichContainerLimitations = new ExtendableRichContainer();
            extendableRichContainerSummary = new ExtendableRichContainer();
            extendableRichContainerCompliance = new ExtendableRichContainer();
            summaryControl = new MaintenanceStatusSummaryControl(aircraft);
            limitationsControl = new MaintenanceStatusLimitationsControl(aircraft.MaintenanceDirective);
            complianceControl = new MaintenanceStatusComplianceControl(aircraft);
            complianceControl.Visible = false;
            
            complianceControl.ItemsChanged += complianceControl_ItemsChanged;
            // 
            // headerControl
            // 
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ActionControl.EditDisplayerRequested += ActionControl_EditDisplayerRequested;
            headerControl.ActionControl.ReloadRised += ActionControl_ReloadRised;
            headerControl.ActionControl.ButtonEdit.TextMain = "Save";
            headerControl.ActionControl.ButtonEdit.Icon = icons.Save;
            headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ActionControl.ButtonEdit.Enabled = aircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "aircraft_maintenance_program_title";
            headerControl.TabIndex = 0;
            // 
            // aircraftHeaderControl
            // 
            aircraftHeaderControl.Aircraft = aircraft;
            aircraftHeaderControl.AircraftClickable = true;
            aircraftHeaderControl.OperatorClickable = true;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            // 
            // extendableRichContainerSummary
            // 
            extendableRichContainerSummary.Caption = "Summary";
            extendableRichContainerSummary.Extended = true;
            extendableRichContainerSummary.MainControl = summaryControl;
            extendableRichContainerSummary.UpperLeftIcon = icons.GrayArrow;
            extendableRichContainerSummary.TabIndex = 0;
            // 
            // extendableRichContainerLimitations
            // 
            extendableRichContainerLimitations.Caption = "Maintenance Program";
            extendableRichContainerLimitations.Extended = false;
            extendableRichContainerLimitations.MainControl = limitationsControl;
            extendableRichContainerLimitations.TabIndex = 1;
            extendableRichContainerLimitations.UpperLeftIcon = icons.GrayArrow;
            // 
            // extendableRichContainerCompliance
            // 
            extendableRichContainerCompliance.Caption = "Compliance";
            extendableRichContainerCompliance.Dock = DockStyle.Top;
            extendableRichContainerCompliance.Extended = false;
            extendableRichContainerCompliance.Extending += extendableRichContainerCompliance_Extending;
            extendableRichContainerCompliance.UpperLeftIcon = icons.GrayArrow;
            extendableRichContainerCompliance.TabIndex = 4;
            // 
            // containedPanel
            // 
            containedPanel.AutoSize = true;
            containedPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            containedPanel.FlowDirection = FlowDirection.TopDown;
            containedPanel.Controls.Add(extendableRichContainerSummary);
            containedPanel.Controls.Add(extendableRichContainerLimitations);
            containedPanel.Controls.Add(extendableRichContainerCompliance);
            containedPanel.Controls.Add(complianceControl);
            containedPanel.TabIndex = 1;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(containedPanel);

            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion


        #region private void extendableRichContainerCompliance_Extending(object sender, EventArgs e)

        private void extendableRichContainerCompliance_Extending(object sender, EventArgs e)
        {
            complianceControl.Visible = !complianceControl.Visible;
        }

        #endregion

        #region private void complianceControl_ItemsChanged(bool noRecords)

        private void complianceControl_ItemsChanged(bool noRecords)
        {
            headerControl.ContextActionControl.ButtonPrint.Enabled = !noRecords;
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            MaintenanceStatusReportBuilder report =
                new MaintenanceStatusReportBuilder(aircraft, complianceControl.DisplayedItems,
                                                   complianceControl.SelectionSince, complianceControl.SelectionTill);
            e.DisplayerText = aircraft.RegistrationNumber + ". Maintenance status report";
            e.RequestedEntity = new DispatcheredMaintenanceStatusReport(report.CreateMaintenanceReport(), report);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void ActionControl_ReloadRised(object sender, EventArgs e)

        private void ActionControl_ReloadRised(object sender, EventArgs e)
        {
            Reload();
        }

        #endregion

        #region private void Reload()

        private void Reload()
        {
            if (aircraft.MaintenanceDirective.Modified)
            {
                DialogResult result =
                    MessageBox.Show("Unsaved data will be lost. Continue anyway?",
                                    (string) new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes) return;
            }
            try
            {
            aircraft.ReloadMaintenanceDirective();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            DisplayData(aircraft);
        }

        #endregion

        #region private void ActionControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ActionControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            SaveData();
        }

        #endregion

        #region private void SaveData()

        private void SaveData()
        {
            limitationsControl.SaveData(aircraft.MaintenanceDirective.Limitations);
            aircraft.MaintenanceDirective.Save();
            DisplayData(aircraft);
        }

        #endregion

        #region private void DisplayData(Aircraft parentAircraft)

        private void DisplayData(Aircraft parentAircraft)
        {
            limitationsControl.ReadOnly = !DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            //limitationsControl.DisplayLimitations(parentAircraft.MaintenanceDirective.Limitations);
            limitationsControl.DisplayLimitations();
            summaryControl.DisplayLimitations();
            complianceControl.DisplayItems(parentAircraft);

        }

        #endregion

        #endregion

        #region IDisplayingEntity Members

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return null; }
            set { }
        }

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredMaintenanceStatusControl))
            {
                return false;
            }
            DispatcheredMaintenanceStatusControl objControl = (DispatcheredMaintenanceStatusControl) obj;
            return (aircraft.Equals(objControl.aircraft));
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());
        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (limitationsControl.InfoViewerMaxResource.Modified || limitationsControl.InfoViewerNotification.Modified)
            {
                DialogResult result =
                    MessageBox.Show("Do you want to save changes?",
                                    (string) new TermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                    SaveData();
                if (result == DialogResult.Cancel)
                    arguments.Cancel = true;
            }
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
        }

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion

        #endregion
    }
}