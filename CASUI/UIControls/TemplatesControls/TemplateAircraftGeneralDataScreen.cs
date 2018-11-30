using System;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Отображает общую информацию о шаблонном ВС
    /// </summary>
    public class TemplateAircraftGeneralDataScreen : UserControl
    {

        #region Fields

        /// <summary>
        /// Текущее ВС
        /// </summary>
        protected TemplateAircraft currentAircraft;
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly FooterControl footerControl = new FooterControl();
        private readonly TemplateAircraftHeaderControl aircraftHeaderControl;
        private readonly Panel mainPanel = new Panel();
        private readonly Icons icons = new Icons();


        private readonly ExtendableRichContainer aircraftContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer powerPlantsContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer APUContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer performanceDataContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer landingGearsContainer = new ExtendableRichContainer();
        //private readonly ExtendableRichContainer maintenanceStatusContainer = new ExtendableRichContainer();
        private readonly ExtendableRichContainer interiorConfigurationContainer = new ExtendableRichContainer();

        /// <summary>
        /// </summary>
        protected readonly TemplateAircraftControl aircraftControl;
        /// <summary>
        /// </summary>
        protected readonly TemplatePowerPlantsControl powerPlantsControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateAPUControl APUControl;
        /// <summary>
        /// </summary>
        protected readonly TemplatePerformanceDataControl performanceDataControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateLandingGearsControl landingGearsControl;
        ///// <summary>
        ///// </summary>
        //protected readonly MaintenanceStatusControl maintenanceStatusControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateInteriorConfigurationControl interiorConfigurationControl;

        private TemplateLandingGearsFilter filter;
        private TemplateDetailCollectionFilter collectionFilter;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонном ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        public TemplateAircraftGeneralDataScreen(TemplateAircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
            aircraftHeaderControl = new TemplateAircraftHeaderControl(currentAircraft, true, true);
            //
            // aircraftControl
            //
            aircraftControl = new TemplateAircraftControl(currentAircraft);
            //
            // powerPlantsControl
            //
            powerPlantsControl = new TemplatePowerPlantsControl(currentAircraft);
            //
            // APUControl
            //
            APUControl = new TemplateAPUControl(currentAircraft.Apu);
            //
            // performanceDataControl
            //
            performanceDataControl = new TemplatePerformanceDataControl(currentAircraft);
            //
            // landingGearsControl
            //
            filter = new TemplateLandingGearsFilter(true, true, true);
            collectionFilter = new TemplateDetailCollectionFilter(currentAircraft.ContainedDetails, new TemplateDetailFilter[]{filter});
            landingGearsControl = new TemplateLandingGearsControl(collectionFilter.GatherDetails());
            /*      //
            // maintenanceStatusControl
            //
            maintenanceStatusControl = new MaintenanceStatusControl();*/
            //
            // interiorConfigurationControl
            //
            interiorConfigurationControl = new TemplateInteriorConfigurationControl(currentAircraft);
            //
            // aircraftContainer
            //
            aircraftContainer.Caption = "A. Aircraft";
            aircraftContainer.UpperLeftIcon = icons.GrayArrow;
            aircraftContainer.MainControl = aircraftControl;
            aircraftContainer.Dock = DockStyle.Top;
            aircraftContainer.TabIndex = 1;
            //
            // powerPlantsContainer
            //
            powerPlantsContainer.Caption = "B. Power Plants";
            powerPlantsContainer.UpperLeftIcon = icons.GrayArrow;
            powerPlantsContainer.MainControl = powerPlantsControl;
            powerPlantsContainer.Dock = DockStyle.Top;
            powerPlantsContainer.Extended = false;
            powerPlantsContainer.TabIndex = 2;
            //
            // APUContainer
            //
            APUContainer.Caption = "C. Auxiliary Power Unit";
            APUContainer.UpperLeftIcon = icons.GrayArrow;
            APUContainer.MainControl = APUControl;
            APUContainer.Dock = DockStyle.Top;
            APUContainer.Extended = false;
            APUContainer.TabIndex = 3;
            //
            // performanceDataContainer
            //
            performanceDataContainer.Caption = "D. Performance Data";
            performanceDataContainer.UpperLeftIcon = icons.GrayArrow;
            performanceDataContainer.MainControl = performanceDataControl;
            performanceDataContainer.Dock = DockStyle.Top;
            performanceDataContainer.Extended = false;
            performanceDataContainer.TabIndex = 4;
            //
            // landingGearsContainer
            //
            landingGearsContainer.Caption = "E. Landing Gears";
            landingGearsContainer.UpperLeftIcon = icons.GrayArrow;
            landingGearsContainer.MainControl = landingGearsControl;
            landingGearsContainer.Dock = DockStyle.Top;
            landingGearsContainer.Extended = false;
            landingGearsContainer.TabIndex = 5;
            /*    //
            // maintenanceStatusContainer
            //
            maintenanceStatusContainer.Caption = "F. Maintenance Status";
            maintenanceStatusContainer.UpperLeftIcon = icons.GrayArrow;
            maintenanceStatusContainer.MainControl = maintenanceStatusControl;
            maintenanceStatusContainer.Dock = DockStyle.Top;
            maintenanceStatusContainer.Extended = false;
            maintenanceStatusContainer.TabIndex = 6;*/
            //
            // interiorConfigurationContainer
            //
            interiorConfigurationContainer.Caption = "G. Interior Configuration";
            interiorConfigurationContainer.UpperLeftIcon = icons.GrayArrow;
            interiorConfigurationContainer.MainControl = interiorConfigurationControl;
            interiorConfigurationContainer.Dock = DockStyle.Top;
            interiorConfigurationContainer.Extended = false;
            interiorConfigurationContainer.TabIndex = 7;
            //
            // headerControl
            //
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ActionControl.ButtonEdit.TextMain = "Save";
            headerControl.ActionControl.ButtonEdit.Icon = icons.Save;
            headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ActionControl.ButtonEdit.DisplayerRequested += ButtonSave_Click;
            headerControl.ActionControl.ButtonReload.Click += ButtonReload_Click;
            headerControl.ContextActionControl.ShowPrintButton = false;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ActionControl.ShowEditButton = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            headerControl.TabIndex = 0;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            
            mainPanel.Controls.Add(interiorConfigurationContainer);
            //mainPanel.Controls.Add(maintenanceStatusContainer);
            mainPanel.Controls.Add(landingGearsContainer);
            mainPanel.Controls.Add(performanceDataContainer);
            if (currentAircraft.Apu != null) 
                mainPanel.Controls.Add(APUContainer);
            if (currentAircraft.Engines.Length > 0)
                mainPanel.Controls.Add(powerPlantsContainer);
            mainPanel.Controls.Add(aircraftContainer);
            
            
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion

        #region Properties

        #region public TemplateAircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает текущее шаблонное ВС
        /// </summary>
        public TemplateAircraft Aircraft
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

        #region private void ButtonReload_Click(object sender, System.EventArgs e)

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            if (aircraftControl.GetChangeStatus() || powerPlantsControl.GetChangeStatus() || APUControl.GetChangeStatus() || performanceDataControl.GetChangeStatus() || landingGearsControl.GetChangeStatus() || interiorConfigurationControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    UpdateScreen();
                }
            }
            else
            {
                UpdateScreen();        
            }
        }

        #endregion

        #region private void ButtonSave_Click(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия кнопки "Save"
        /// </summary>
        private void ButtonSave_Click(object sender, ReferenceEventArgs e)
        {
            Save();
            e.Cancel = true;
        }

        #endregion

        #region protected void Save()

        /// <summary>
        /// Сохраняет данные текущего шаблонного ВС
        /// </summary>
        protected bool Save()
        {
            if (aircraftControl.GetChangeStatus() || (currentAircraft.Engines.Length > 0 && powerPlantsControl.GetChangeStatus()) || (currentAircraft.Apu != null && APUControl.GetChangeStatus()) || performanceDataControl.GetChangeStatus() || landingGearsControl.GetChangeStatus() || interiorConfigurationControl.GetChangeStatus())
            {
                //if (!aircraftControl.CheckAmount() || 
                if((currentAircraft.Engines.Length > 0 && !powerPlantsControl.CheckAmount()) || (currentAircraft.Apu != null && !APUControl.CheckAmount()) || !landingGearsControl.CheckAmount())
                    return false;
                aircraftControl.SaveData();
                if (currentAircraft.Engines.Length > 0)
                    powerPlantsControl.SaveData();
                if (currentAircraft.Apu != null)
                    APUControl.SaveData();
                performanceDataControl.SaveData();
                landingGearsControl.SaveData();
                interiorConfigurationControl.SaveData();
                try
                {
                    currentAircraft.Save(true);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex); return false;
                }
                powerPlantsControl.UpdateControl();
                landingGearsControl.UpdateControl();
            }
            return true;
        }

        #endregion
        
        #region private void UpdateScreen()

        /// <summary>
        /// Обновляет информацию о текущем шаблонном ВС
        /// </summary>
        private void UpdateScreen() 
        {
            try
            {
                currentAircraft.Reload(true);
                aircraftControl.Aircraft = currentAircraft;
                powerPlantsControl.Aircraft = currentAircraft;
                APUControl.BaseDetail = currentAircraft.Apu;
                APUContainer.MainControl = APUControl;
                performanceDataControl.Aircraft = currentAircraft;
                filter = new TemplateLandingGearsFilter(true, true, true);
                collectionFilter =
                    new TemplateDetailCollectionFilter(currentAircraft.ContainedDetails, new TemplateDetailFilter[] { filter });
                landingGearsControl.Details = collectionFilter.GatherDetails();
                interiorConfigurationControl.Aircraft = currentAircraft;

                headerControl.ActionControl.ShowEditButton =
                    currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
            }

        }

        #endregion

        #endregion

        
    }
}