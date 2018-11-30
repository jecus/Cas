using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Analyst;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CAS.UI.UIControls.AircraftsControls
{
    ///<summary>
    ///</summary>
    public partial class AircraftSummaryScreen : ScreenControl
    {
        private MaintenanceCheckCollection _preResult;
        private List<Document> _aircraftDocs = new List<Document>();

        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportGeneralData;
        private ToolStripMenuItem _itemPrintReportTechnicalCondition;

        #region Constructors

        #region private AircraftSummaryScreen()
        ///<summary>
        ///</summary>
        private AircraftSummaryScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public AircraftSummaryScreen(Aircraft currentAircraft)  : this()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="currentAircraft">Директива</param>
        public AircraftSummaryScreen(Aircraft currentAircraft)
            : this()
        {
            CurrentAircraft = currentAircraft;

            #region ButtonPrintContextMenu

            _buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportGeneralData = new ToolStripMenuItem { Text = "Aircraft General Data" };
            _itemPrintReportTechnicalCondition = new ToolStripMenuItem { Text = "Technical Condition" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportGeneralData, _itemPrintReportTechnicalCondition });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;

            #endregion
        }

        #endregion

        #endregion

        #region Methods

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            AnimatedThreadWorker.Dispose();

            if (_itemPrintReportGeneralData != null) _itemPrintReportGeneralData.Dispose();
            if (_itemPrintReportTechnicalCondition != null) _itemPrintReportTechnicalCondition.Dispose();
            if (_buttonPrintMenuStrip != null) _buttonPrintMenuStrip.Dispose();


            if(_preResult != null)
            {
                _preResult.Clear();
                _preResult = null;
            }
            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            statusControl.Aircraft = CurrentAircraft;
            statusControl.ConditionState = ConditionState.Satisfactory;

            extendableRichContainerAircraft.Caption = "Aircraft " + CurrentAircraft.Model + " Reg.№:" + CurrentAircraft.RegistrationNumber
                              + " S/N:" + CurrentAircraft.SerialNumber
                              + " L/N:" + CurrentAircraft.LineNumber
                              + " V/N:" + CurrentAircraft.VariableNumber;
            aircraftSummaryControl1.UpdateInformation(_preResult, _aircraftDocs, CurrentAircraft, CurrentAircraft.Schedule);
            //powerPlantsControl1.Aircraft = CurrentAircraft;
            powerPlantsControl1.UpdateControl(CurrentAircraft, BaseComponentType.Engine);

            propellersControl1.UpdateControl(CurrentAircraft, BaseComponentType.Propeller);
            if (propellersControl1.ControlsCount == 0)
                extendableRichContainerPropellers.Visible = false;
            //landingGearsControl1.Aircraft = CurrentAircraft;
            landingGearsControl1.UpdateControl(CurrentAircraft, BaseComponentType.LandingGear);

            BaseComponent apu = GlobalObjects.ComponentCore.GetAircraftApu(CurrentAircraft.ItemId);

            if (apu != null)
            {
                _baseComponentEditorControlApu.CurrentComponent = apu;

                string baseDetailTypeString = apu.BaseComponentType.ToString();
                string baseDetailModelString = apu.Model != null
                                                   ? " " + apu.Model
                                                   : "";
                extendableRichContainerAPU.Caption = baseDetailTypeString + baseDetailModelString + " P/N:" + apu.PartNumber
                                  + " S/N:" + apu.SerialNumber
                                  + " M/P:" + apu.MaintenanceControlProcess.ShortName
                                  + " Pos:" + apu.TransferRecords.GetLast().Position;
            }
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            if (_preResult == null)
                _preResult = new MaintenanceCheckCollection();
            _preResult.Clear();
            _aircraftDocs.Clear();
            try
            {
                _preResult.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceCheck(CurrentAircraft));
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading directives", ex);
            }

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            AnimatedThreadWorker.ReportProgress(20, "load directives");

            List<Document> aircraftDocs = GlobalObjects.DocumentCore.GetDocuments(CurrentAircraft, DocumentType.Certificate);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            #endregion

            #region Калькуляция состояния директив

            AnimatedThreadWorker.ReportProgress(40, "calculation of directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //прогнозируемый ресурс
            var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
            var groupingChecks = _preResult.Where(c => c.Grouping);
            int? offsetMinutes =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Minutes))
                              .OrderBy(r => r)
                              .LastOrDefault();
            int? offsetCycles =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Cycles))
                              .OrderBy(r => r)
                              .LastOrDefault();
            int? offsetDays =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Calendar))
                              .OrderBy(r => r)
                              .LastOrDefault();
            var offset = new Lifelength(offsetDays, offsetCycles, offsetMinutes);
	        var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(CurrentAircraft.AircraftFrameId);
            var approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, aircraftFrame.AverageUtilization));
            var forecastData = new ForecastData(DateTime.Now.AddDays(approxDays),
														 aircraftFrame.AverageUtilization,
                                                         current);
            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(_preResult, CurrentAircraft.Schedule, forecastData);

            var cs = ConditionState.NotEstimated;
            foreach (MaintenanceCheck check in _preResult)
            {
                if (check.Condition == ConditionState.Satisfactory && cs == ConditionState.NotEstimated) cs = check.Condition;
                if (check.Condition == ConditionState.Notify && cs != ConditionState.Notify) cs = check.Condition;
                if (check.Condition == ConditionState.Overdue)
                {
                    cs = check.Condition;
                    break;
                }
            }
            e.Result = cs;

            AnimatedThreadWorker.ReportProgress(55, "calculation of documents");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            foreach (Document aircraftDoc in aircraftDocs)
            {
                GlobalObjects.PerformanceCalculator.GetNextPerformance(aircraftDoc);

                if(!aircraftDoc.IsClosed && 
                    aircraftDoc.IssueValidTo && 
                    aircraftDoc.Condition != ConditionState.NotEstimated)
                    _aircraftDocs.Add(aircraftDoc);
            }

            #endregion

            #region Фильтрация директив
            AnimatedThreadWorker.ReportProgress(70, "filter directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Сравнение с рабочими пакетами

            AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region public override void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public override void OnInitCompletion(object sender)
        {
            AnimatedThreadWorker.RunWorkerAsync();

            base.OnInitCompletion(sender);
        }
        #endregion

        #region private bool ValidateData()

        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!powerPlantsControl1.ValidateData(out message) ||
                !propellersControl1.ValidateData(out message) ||
                !landingGearsControl1.ValidateData(out message))
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
            return aircraftSummaryControl1.GetChangeStatus() 
                   || powerPlantsControl1.GetChangeStatus()
                   || propellersControl1.GetChangeStatus()
                   || landingGearsControl1.GetChangeStatus();
        }

        #endregion

        #region private void ExtendableRichContainerAircraftExtending(object sender, EventArgs e)

        private void ExtendableRichContainerAircraftExtending(object sender, EventArgs e)
        {
            aircraftSummaryControl1.Visible = !aircraftSummaryControl1.Visible;
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
            _baseComponentEditorControlApu.Visible = !_baseComponentEditorControlApu.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerLgExtending(object sender, EventArgs e)
        private void ExtendableRichContainerLgExtending(object sender, EventArgs e)
        {
            landingGearsControl1.Visible = !landingGearsControl1.Visible;
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
            CancelAsync();
            AnimatedThreadWorker.RunWorkerAsync();
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
                aircraftSummaryControl1.SaveData();
                powerPlantsControl1.SaveData();
                propellersControl1.SaveData();
                landingGearsControl1.SaveData();

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
            }
        }

        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
            if (sender == _itemPrintReportGeneralData)
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
            else if (sender == _itemPrintReportTechnicalCondition)
            {
				var maintenanceChecks = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MaintenanceCheckDTO, MaintenanceCheck> (new List<Filter>
				{
					new Filter("ParentAircraft",CurrentAircraft.ItemId),
					new Filter("Schedule", true)
				}, true);
				
				var workPackages = GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Closed, maintenanceChecks.Select(m => (IDirective)m).ToList());

                MaintenanceCheck minCCheck = 
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "C" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                     .OrderBy(mc => mc.Interval.GetSubresource(LifelengthSubResource.Hours))
                                     .FirstOrDefault();

                MaintenanceCheckRecord lastCCheckRecord =
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "C" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .Where(pr => pr.RecordDate.Date <= DateTime.Now)
                                      .OrderByDescending(pr => pr.RecordDate)
                                      .FirstOrDefault();

                MaintenanceCheckRecord lastACheckRecord =
                    maintenanceChecks.Where(mc => mc.CheckType.ShortName == "A" &&
                                                  mc.Schedule &&
                                                  mc.Grouping &&
                                                  mc.Resource == LifelengthSubResource.Hours)
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .Where(pr => pr.RecordDate.Date <= DateTime.Now)
                                      .OrderByDescending(pr => pr.RecordDate)
                                      .FirstOrDefault();
                if (lastACheckRecord.NumGroup == lastCCheckRecord.NumGroup)
                    lastACheckRecord = null;

                List<MaintenanceCheckRecord> dCheckRecords =
                     maintenanceChecks.Where(mc => mc.CheckType.ShortName == "D")
                                      .SelectMany(mc => mc.PerformanceRecords)
                                      .ToList();

                List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

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
