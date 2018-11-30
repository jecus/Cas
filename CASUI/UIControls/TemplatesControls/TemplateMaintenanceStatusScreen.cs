using System;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения информации Maintenance Status в  шаблонах
    /// </summary>
    public class TemplateMaintenanceStatusScreen : Control
    {

        #region Fields

        private HeaderControl headerControl;
        private TemplateAircraftHeaderControl aircraftHeaderControl;
        private FooterControl footerControl;
        private Panel mainPanel;
        private FlowLayoutPanel containedPanel;

        private ExtendableRichContainer extendableRichContainerLimitations;
        protected TemplateMaintenanceLimitationsControl limitationsControl;
        
        
        private readonly TemplateAircraft aircraft;
        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации Maintenance Status в  шаблонах
        /// </summary>
        /// <param name="aircraft">Шаблонное ВС</param>
        public TemplateMaintenanceStatusScreen(TemplateAircraft aircraft)
        {
            this.aircraft = aircraft;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            headerControl = new HeaderControl();
            aircraftHeaderControl = new TemplateAircraftHeaderControl(aircraft);
            footerControl = new FooterControl();
            mainPanel = new Panel();
            containedPanel = new FlowLayoutPanel();
            extendableRichContainerLimitations = new ExtendableRichContainer();
            limitationsControl = new TemplateMaintenanceLimitationsControl(aircraft.MaintenanceDirective);
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
            // extendableRichContainerLimitations
            // 
            extendableRichContainerLimitations.Caption = "Maintenance Program";
            //extendableRichContainerLimitations.Extended = false;
            extendableRichContainerLimitations.MainControl = limitationsControl;
            extendableRichContainerLimitations.TabIndex = 1;
            extendableRichContainerLimitations.UpperLeftIcon = icons.GrayArrow;
            // 
            // containedPanel
            // 
            containedPanel.AutoSize = true;
            containedPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            containedPanel.FlowDirection = FlowDirection.TopDown;
            containedPanel.Controls.Add(extendableRichContainerLimitations);
            containedPanel.TabIndex = 1;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(containedPanel);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            /*MaintenanceStatusReportBuilder report =
                new MaintenanceStatusReportBuilder(aircraft, complianceControl.DisplayedItems,
                                                   complianceControl.SelectionSince, complianceControl.SelectionTill);
            e.DisplayerText = aircraft.RegistrationNumber + ". Maintenance status report";
            e.RequestedEntity = new DispatcheredMaintenanceStatusReport(report.CreateMaintenanceReport(), report);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;*/
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
                if (result != DialogResult.Yes) 
                    return;
            }
            try
            {
                aircraft.MaintenanceDirective.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

            UpdateInformation();
        }

        #endregion

        #region private void ActionControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ActionControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            SaveData();
        }

        #endregion

        #region protected void SaveData()

        protected void SaveData()
        {
            limitationsControl.SaveData();
            aircraft.MaintenanceDirective.Save(true);
            UpdateInformation();
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            limitationsControl.ReadOnly = !TemplateBaseDetailDirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            limitationsControl.UpdateInformation();
            
        }

        #endregion

        #endregion
    }
}
