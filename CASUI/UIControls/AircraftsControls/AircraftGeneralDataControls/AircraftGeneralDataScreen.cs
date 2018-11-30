using System;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.ReferenceControls;
using CASReports.Builders;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Отображает общую информацию о ВС
    /// </summary>
    public class AircraftGeneralDataScreen : PictureBox
    {

        #region Fields

        /// <summary>
        /// Текущее ВС
        /// </summary>
        protected Aircraft currentAircraft;
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly FooterControl footerControl = new FooterControl();
        private readonly AircraftHeaderControl aircraftHeaderControl;
        private readonly Panel mainPanel = new Panel();
        private readonly Icons icons = new Icons();
        private DispatcheredMultitabControl dispatcheredMultitabControl;
        private AnimatedThreadWorker animatedThreadWorker;


        private readonly ExtendableRichContainer aircraftContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer powerPlantsContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer APUContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer performanceDataContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer landingGearsContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer maintenanceStatusContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer interiorConfigurationContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer otherContainer = new ExtendableRichContainer();

        /// <summary>
        /// </summary>
        protected readonly AircraftControl aircraftControl;
        /// <summary>
        /// </summary>
        protected readonly PowerPlantsControl powerPlantsControl;
        /// <summary>
        /// </summary>
        protected readonly APUControl APUControl;
        /// <summary>
        /// </summary>
        protected readonly PerformanceDataControl performanceDataControl;
        /// <summary>
        /// </summary>
        protected readonly LandingGearsControl landingGearsControl;
        /// <summary>
        /// </summary>
        protected readonly MaintenanceStatusSummaryControl maintenanceStatusControl;
        /// <summary>
        /// </summary>
        protected readonly InteriorConfigurationControl interiorConfigurationControl;

        protected readonly OtherControl otherControl;

       
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        public AircraftGeneralDataScreen(Aircraft currentAircraft)
        {
            ((DispatcheredAircraftGeneralDataScreen)this).InitComplition += AircraftGeneralDataScreen_InitComplition;
            this.currentAircraft = currentAircraft;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
            aircraftHeaderControl = new AircraftHeaderControl(currentAircraft, true, true);
            //
            // aircraftControl
            //
            aircraftControl = new AircraftControl(currentAircraft, DateTime.Now);
            //
            // powerPlantsControl
            //
            powerPlantsControl = new PowerPlantsControl(currentAircraft, DateTime.Now);
            //
            // APUControl
            //
            APUControl = new APUControl(currentAircraft.Apu, DateTime.Now);
            //
            // performanceDataControl
            //
            performanceDataControl = new PerformanceDataControl(currentAircraft);
            //
            // landingGearsControl
            //
            landingGearsControl = new LandingGearsControl(currentAircraft, DateTime.Now);
            //
            // maintenanceStatusControl
            //
            maintenanceStatusControl = new MaintenanceStatusSummaryControl(currentAircraft);
            maintenanceStatusControl.LinkLabelText = "View Maintenance Status";
            maintenanceStatusControl.LinkLabelDisplayerText = currentAircraft.RegistrationNumber + ". Maintenance Status";
            maintenanceStatusControl.LinkLabelRequestedEntity = new DispatcheredMaintenanceStatusControl(currentAircraft.MaintenanceDirective);
            maintenanceStatusControl.DisplayDateAsOFAndTSNCSN = false;
            maintenanceStatusControl.DisplayLimitations();
            //maintenanceStatusControl.DisplayLimitations(currentAircraft.MaintenanceDirective.Limitations);
            //
            // interiorConfigurationControl
            //
            interiorConfigurationControl = new InteriorConfigurationControl(currentAircraft);
            //
            // otherControl
            //
            otherControl = new OtherControl(currentAircraft);
/*            //
            // maintenancePanel
            //
            maintenancePanel.AutoSize = true;
            maintenancePanel.Controls.Add(maintenanceStatusControl);
            maintenancePanel.Controls.Add(maintenanceLink);
            //
            // maintenanceLink
            //
            maintenanceLink.AutoSize = true;
            maintenanceLink.Font = Css.SimpleLink.Fonts.Font;
            maintenanceLink.LinkColor = Css.SimpleLink.Colors.LinkColor;
            maintenanceLink.Location = new Point(maintenanceStatusControl.Left, maintenanceStatusControl.Bottom + 10);
            maintenanceLink.ReflectionType = ReflectionTypes.DisplayInNew;
            maintenanceLink.Text = "View Maintenance Status";
            maintenanceLink.DisplayerRequested += maintenanceLink_DisplayerRequested;*/
            //
            // aircraftContainer
            //
            aircraftContainer.Caption = "A. Aircraft";
            aircraftContainer.UpperLeftIcon = icons.GrayArrow;
            aircraftContainer.MainControl = aircraftControl;
            aircraftContainer.Dock = DockStyle.Top;
            aircraftContainer.TabIndex = 0;
            //
            // powerPlantsContainer
            //
            powerPlantsContainer.Caption = "B. Power Plants";
            powerPlantsContainer.UpperLeftIcon = icons.GrayArrow;
            powerPlantsContainer.MainControl = powerPlantsControl;
            powerPlantsContainer.Dock = DockStyle.Top;
            powerPlantsContainer.Extended = false;
            powerPlantsContainer.TabIndex = 1;
            //
            // APUContainer
            //
            APUContainer.Caption = "C. Auxiliary Power Unit";
            APUContainer.UpperLeftIcon = icons.GrayArrow;
            if (currentAircraft.Apu != null) APUContainer.MainControl = APUControl;
            APUContainer.Dock = DockStyle.Top;
            APUContainer.Extended = false;
            APUContainer.TabIndex = 2;
            //
            // performanceDataContainer
            //
            performanceDataContainer.Caption = "D. Performance Data";
            performanceDataContainer.UpperLeftIcon = icons.GrayArrow;
            performanceDataContainer.MainControl = performanceDataControl;
            performanceDataContainer.Dock = DockStyle.Top;
            performanceDataContainer.Extended = false;
            performanceDataContainer.TabIndex = 3;
            //
            // landingGearsContainer
            //
            landingGearsContainer.Caption = "E. Landing Gears";
            landingGearsContainer.UpperLeftIcon = icons.GrayArrow;
            landingGearsContainer.MainControl = landingGearsControl;
            landingGearsContainer.Dock = DockStyle.Top;
            landingGearsContainer.Extended = false;
            landingGearsContainer.TabIndex = 4;
            //
            // maintenanceStatusContainer
            //
            maintenanceStatusContainer.Caption = "F. Maintenance Status";
            maintenanceStatusContainer.UpperLeftIcon = icons.GrayArrow;
            //maintenanceStatusContainer.MainControl = maintenancePanel;
            maintenanceStatusContainer.MainControl = maintenanceStatusControl;
            maintenanceStatusContainer.Dock = DockStyle.Top;
            maintenanceStatusContainer.Extended = false;
            maintenanceStatusContainer.TabIndex = 5;
            //
            // interiorConfigurationContainer
            //
            interiorConfigurationContainer.Caption = "G. Interior Configuration";
            interiorConfigurationContainer.UpperLeftIcon = icons.GrayArrow;
            interiorConfigurationContainer.MainControl = interiorConfigurationControl;
            interiorConfigurationContainer.Dock = DockStyle.Top;
            interiorConfigurationContainer.Extended = false;
            interiorConfigurationContainer.TabIndex = 6;
            //
            // otherContainer
            //
            otherContainer.Caption = "H. Other";
            otherContainer.UpperLeftIcon = icons.GrayArrow;
            otherContainer.MainControl = otherControl;
            otherContainer.Dock = DockStyle.Top;
            otherContainer.Extended = false;
            otherContainer.TabIndex = 7;
            //
            // headerControl
            //
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ActionControl.ButtonEdit.TextMain = "Save";
            headerControl.ActionControl.ButtonEdit.Icon = icons.Save;
            headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ActionControl.ButtonEdit.DisplayerRequested += ButtonSave_Click;
            headerControl.ActionControl.ButtonReload.Click += ButtonReload_Click;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ActionControl.ShowEditButton = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            headerControl.TabIndex = 0;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "aircraft_general_data";
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 2;

            mainPanel.Controls.Add(otherContainer);
            mainPanel.Controls.Add(interiorConfigurationContainer);
            mainPanel.Controls.Add(maintenanceStatusContainer);
            mainPanel.Controls.Add(landingGearsContainer);
            mainPanel.Controls.Add(performanceDataContainer);
            if (currentAircraft.Apu != null) 
                mainPanel.Controls.Add(APUContainer);
            mainPanel.Controls.Add(powerPlantsContainer);
            mainPanel.Controls.Add(aircraftContainer);
            
            
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion

        #region Properties

        #region public Aircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает текущее ВС
        /// </summary>
        public Aircraft Aircraft
        {
            get
            {
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                UpdateScreen();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
        {
            if (animatedThreadWorker == null)
            {
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundReload, this);
                animatedThreadWorker.State = "Reloading Aircraft General Data";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker.StartThread();
            }

        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            UpdateScreen();
        }

        #endregion

        #region private void BackgroundReload()

        private void BackgroundReload()
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

        #region private void UpdateScreen()

        /// <summary>
        /// Обновляет информацию о текущем ВС
        /// </summary>
        private void UpdateScreen()
        {
            aircraftControl.Aircraft = currentAircraft;
            powerPlantsControl.Aircraft = currentAircraft;
            APUControl.BaseDetail = currentAircraft.Apu;
            if (currentAircraft.Apu != null)
                APUContainer.MainControl = APUControl;
            performanceDataControl.Aircraft = currentAircraft;
            landingGearsControl.UpdateControl();
            maintenanceStatusControl.DisplayLimitations();
            interiorConfigurationControl.Aircraft = currentAircraft;
            otherControl.UpdateControl();
            headerControl.ActionControl.ShowEditButton = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
        }

        #endregion

        #region protected void Save()

        /// <summary>
        /// Сохраняет данные текущего ВС
        /// </summary>
        protected void Save()
        {
            if (aircraftControl.GetChangeStatus() || powerPlantsControl.GetChangeStatus() || APUControl.GetChangeStatus() || performanceDataControl.GetChangeStatus() || landingGearsControl.GetChangeStatus() || interiorConfigurationControl.GetChangeStatus() || otherControl.GetChangeStatus())
            {
                aircraftControl.SaveData();
                powerPlantsControl.SaveData();
                APUControl.SaveData();
                performanceDataControl.SaveData();
                landingGearsControl.SaveData();
                interiorConfigurationControl.SaveData();
                otherControl.SaveData();
                try
                {

                    currentAircraft.Save(true);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                    return;
                }

                powerPlantsControl.UpdateControl();
                landingGearsControl.UpdateControl();
            }
        }

        #endregion

        #region protected void SetPageEnable(bool isEnable)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnable"></param>
        protected void SetPageEnable(bool isEnable)
        {
            mainPanel.Enabled = isEnable;
            footerControl.Enabled = isEnable;
            headerControl.Enabled = isEnable;
        }
        #endregion


        #region private void ButtonReload_Click(object sender, System.EventArgs e)

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            if (aircraftControl.GetChangeStatus() || powerPlantsControl.GetChangeStatus() || APUControl.GetChangeStatus() || performanceDataControl.GetChangeStatus() || landingGearsControl.GetChangeStatus() || interiorConfigurationControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ReloadElements();
                }
            }
            else
            {
                ReloadElements();
            }
        }

        #endregion

        #region private void ButtonSave_Click(object sender, ReferenceEventArgs e)

        private void ButtonSave_Click(object sender, ReferenceEventArgs e)
        {
            Save();
            e.Cancel = true;
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            AircraftGeneralDataReportBuilder reportBuilder = new AircraftGeneralDataReportBuilder(currentAircraft,DateTime.Now);
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Aircraft General Data Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredAircraftGeneralDataReport(currentAircraft, reportBuilder, DateTime.Now);
        }

        #endregion

        #region private void AircraftGeneralDataScreen_InitComplition(object sender, EventArgs e)

        private void AircraftGeneralDataScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
        }

        #endregion

        #endregion

        
    }
}