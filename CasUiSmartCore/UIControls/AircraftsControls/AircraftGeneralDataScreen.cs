using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.AircraftsControls
{
    ///<summary>
    ///</summary>
    public partial class AircraftGeneralDataScreen : ScreenControl
    {
        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportGeneralData;
        private ToolStripMenuItem itemPrintReportTechnicalCondition;

        #region Constructors

        #region private AircraftGeneralDataScreen()
        ///<summary>
        ///</summary>
        private AircraftGeneralDataScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public AircraftGeneralDataScreen(Aircraft currentAircraft)  : this()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="currentAircraft">Директива</param>
        public AircraftGeneralDataScreen(Aircraft currentAircraft) : this()
        {
            CurrentAircraft = currentAircraft;

            #region ButtonPrintContextMenu

            buttonPrintMenuStrip = new ContextMenuStrip();
            itemPrintReportGeneralData = new ToolStripMenuItem { Text = "Aircraft General Data" };
            itemPrintReportTechnicalCondition = new ToolStripMenuItem { Text = "Technical Condition" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportGeneralData, itemPrintReportTechnicalCondition });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;

            #endregion

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region void UpdateInformation()
        void UpdateInformation()
        {
            statusControl.Aircraft = CurrentAircraft;
            statusControl.ConditionState = ConditionState.Satisfactory;

            aircraftControl1.CurrentAircraft = CurrentAircraft;
            //powerPlantsControl1.Aircraft = CurrentAircraft;
            powerPlantsControl1.UpdateControl(CurrentAircraft, BaseComponentType.Engine);
            propellersControl1.UpdateControl(CurrentAircraft, BaseComponentType.Propeller);
            performanceDataControl1.Aircraft = CurrentAircraft;
            //landingGearsControl1.Aircraft = CurrentAircraft;
            landingGearsControl1.UpdateControl(CurrentAircraft, BaseComponentType.LandingGear);
            interiorConfigurationControl1.Aircraft = CurrentAircraft;
			apusControl.UpdateControl(CurrentAircraft, BaseComponentType.Apu);
	        aircraftOtherControl1.UpdateControl(CurrentAircraft, AircraftEquipmetType.TapeOfOperationApproval);
			aircraftOtherControl2.UpdateControl(CurrentAircraft, AircraftEquipmetType.Equipmet);

		}
        #endregion

        #region private bool ValidateData()

        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!apusControl.ValidateData(out message) ||
                !powerPlantsControl1.ValidateData(out message) ||
                !propellersControl1.ValidateData(out message) ||
                !landingGearsControl1.ValidateData(out message)||
				!aircraftControl1.ValidateData(out message))
				return false;
            return true;
        }

        #endregion

        #region private bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            // Проверяем, изменены ли поля WestAircraft
            return aircraftControl1.GetChangeStatus() 
                   || powerPlantsControl1.GetChangeStatus()
                   || propellersControl1.GetChangeStatus()
                   || performanceDataControl1.GetChangeStatus()
                   || landingGearsControl1.GetChangeStatus()
				   || apusControl.GetChangeStatus()
                   || interiorConfigurationControl1.GetChangeStatus()
				   || aircraftOtherControl1.GetChangeStatus()
				   || aircraftOtherControl2.GetChangeStatus();
        }

        #endregion

        #region private void ExtendableRichContainerAircraftExtending(object sender, EventArgs e)

        private void ExtendableRichContainerAircraftExtending(object sender, EventArgs e)
        {
            aircraftControl1.Visible = !aircraftControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPpExtending(object sender, EventArgs e)
        private void ExtendableRichContainerPpExtending(object sender, EventArgs e)
        {
            powerPlantsControl1.Visible = !powerPlantsControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPropellersExtending(object sender, EventArgs e)
        private void ExtendableRichContainerPropellersExtending(object sender, EventArgs e)
        {
            propellersControl1.Visible = !propellersControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerApuExtending(object sender, EventArgs e)
        private void ExtendableRichContainerApuExtending(object sender, EventArgs e)
        {
            apusControl.Visible = !apusControl.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPdExtending(object sender, EventArgs e)
        private void ExtendableRichContainerPdExtending(object sender, EventArgs e)
        {
            performanceDataControl1.Visible = !performanceDataControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerLgExtending(object sender, EventArgs e)
        private void ExtendableRichContainerLgExtending(object sender, EventArgs e)
        {
            landingGearsControl1.Visible = !landingGearsControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerIcExtending(object sender, EventArgs e)
        private void ExtendableRichContainerIcExtending(object sender, EventArgs e)
        {
            interiorConfigurationControl1.Visible = !interiorConfigurationControl1.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerOtherExtending(object sender, EventArgs e)
        private void ExtendableRichContainerOtherExtending(object sender, EventArgs e)
        {
            flowLayoutPanelOther.Visible = !flowLayoutPanelOther.Visible;
		}
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                MessageBox.Show(message + "\nAbort operation",(string)new GlobalTermsProvider()["SystemName"],
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            if (GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }
            
            UpdateInformation();
        }
        #endregion

        #region private void HeaderControlButtonSaveClick(object sender, EventArgs e)

        private void HeaderControlButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            if (GetChangeStatus())
            {
                aircraftControl1.SaveData();
                powerPlantsControl1.SaveData();
                propellersControl1.SaveData();
                apusControl.SaveData();
                performanceDataControl1.SaveData();
                landingGearsControl1.SaveData();
                interiorConfigurationControl1.SaveData();
				aircraftOtherControl1.SaveData();
				aircraftOtherControl2.SaveData();

                try
                {
                    //currentAircraft.Save(true);
                    GlobalObjects.CasEnvironment.NewKeeper.Save(CurrentAircraft);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                    return;
                }

                MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

                //powerPlantsControl1.UpdateControl();
                powerPlantsControl1.UpdateControl(CurrentAircraft, BaseComponentType.Engine);
                //landingGearsControl1.UpdateControl();
                propellersControl1.UpdateControl(CurrentAircraft, BaseComponentType.Propeller);
                landingGearsControl1.UpdateControl(CurrentAircraft, BaseComponentType.LandingGear);
				aircraftOtherControl1.UpdateControl(CurrentAircraft, AircraftEquipmetType.TapeOfOperationApproval);
				aircraftOtherControl2.UpdateControl(CurrentAircraft, AircraftEquipmetType.Equipmet);
			}
			else
			{
				MessageBox.Show("No changes. Nothing to save", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
            if (sender == itemPrintReportGeneralData)
            {
                AircraftGeneralDataReportBuilder builder = new AircraftGeneralDataReportBuilder();
                string caption = CurrentAircraft.RegistrationNumber + "." + "General data report";
                builder.ReportedAircraft = CurrentAircraft;
                builder.LifelengthAircraftSinceNew =
                            GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
            }
            else if (sender == itemPrintReportTechnicalCondition)
            {
	            var maintenanceChecks = GlobalObjects.MaintenanceCore.GetMaintenanceCheck(CurrentAircraft, true);
                var workPackages = GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Closed, maintenanceChecks.Select(m => (IDirective)m).ToList());

                var minCCheck = 
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "C" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                     .OrderBy(mc => mc.Interval.GetSubresource(LifelengthSubResource.Hours))
                                     .FirstOrDefault();

				var lastCCheckRecord =
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "C" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .Where(pr => pr.RecordDate.Date <= DateTime.Now)
                                      .OrderByDescending(pr => pr.RecordDate)
                                      .FirstOrDefault();

				var lastACheckRecord =
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "A" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .Where(pr => pr.RecordDate.Date <= DateTime.Now)
                                      .OrderByDescending(pr => pr.RecordDate)
                                      .FirstOrDefault();

				if(lastCCheckRecord != null)
	            {
					if (lastACheckRecord.NumGroup == lastCCheckRecord.NumGroup)
						lastACheckRecord = null;
				}             

                var dCheckRecords =
                     maintenanceChecks.Where(mc => mc.CheckType.ShortName == "D")
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .ToList();

                var maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

                foreach (MaintenanceCheckRecord record in dCheckRecords)
                {
                    //Поиск коллекции групп, в которую входят группы с нужными критериями
                    //по плану, группировка и основному ресурсу
                    if (record.ParentCheck.Grouping)
                    {
                        MaintenanceCheckRecordGroup recordGroup = maintenanceCheckRecordGroups
                                    .FirstOrDefault(g => g.Schedule == record.ParentCheck.Schedule &&
                                                         g.Grouping == record.ParentCheck.Grouping &&
                                                         g.Resource == record.ParentCheck.Resource &&
                                                         g.GroupComplianceNum == record.NumGroup);
                        if (recordGroup != null)
                        {
                            //Коллекция найдена
                            //Поиск в ней группы чеков с нужным типом
                            recordGroup.Records.Add(record);
                        }
                        else
                        {
                            //Коллекции с нужными критериями нет
                            //Созадние и добавление
                            recordGroup =
                                new MaintenanceCheckRecordGroup(record.ParentCheck.Schedule, record.ParentCheck.Grouping,
                                                                 record.ParentCheck.Resource, record.NumGroup);
                            recordGroup.Records.Add(record);
                            maintenanceCheckRecordGroups.Add(recordGroup);
                        }
                    }
                    else
                    {
                        MaintenanceCheckRecordGroup recordGroup =
                                new MaintenanceCheckRecordGroup(record.ParentCheck.Schedule, record.ParentCheck.Grouping,
                                                                record.ParentCheck.Resource);
                        recordGroup.Records.Add(record);
                        maintenanceCheckRecordGroups.Add(recordGroup);
                    }
                }

                AircraftTechnicalConditionReportBuilder reportBuilder =
                    new AircraftTechnicalConditionReportBuilder(CurrentAircraft,
                                                                minCCheck,
                                                                GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId),
                                                                lastACheckRecord,
                                                                lastCCheckRecord,
                                                                workPackages,
                                                                maintenanceCheckRecordGroups.Count);

                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = CurrentAircraft.RegistrationNumber + " Operation Time Report";
                e.RequestedEntity = new ReportScreen(reportBuilder);
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #endregion
    }
}
