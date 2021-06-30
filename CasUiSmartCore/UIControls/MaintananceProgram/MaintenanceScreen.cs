using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using SmartCore.Analyst;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// Экран для отображения полной информации о состоянии ВС
    ///</summary>
    public partial class  MaintenanceScreen : ScreenControl
    {
        #region Fields

        private MaintenanceCheckCollection _preResult;
        /// <summary>
        /// Список чеков текущего ВС
        /// </summary>
        private MaintenanceCheckCollection _checkItems;

        private List<MaintenanceDirective> _maintenanceDirectives;

        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportStatusSchedule;
        private ToolStripMenuItem itemPrintReportStatusUnschedule;
        private ToolStripMenuItem itemPrintReportProgramSchedule;
        private ToolStripMenuItem itemPrintReportProgramUnschedule;
        private ToolStripMenuItem itemPrintReportRecords;
        private ToolStripMenuItem itemPrintReportHistory;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #region private MaintenanceScreenNew()
        /// <summary>
        ///  Конструктор по умолчанию
        /// </summary>
        private MaintenanceScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public MaintenanceScreenNew(Aircraft parentAircraft) : this()
        /// <summary>
        /// 
        /// </summary>
        public MaintenanceScreen(Aircraft parentAircraft)
            : this()
        {
            if(parentAircraft == null)
                throw new ArgumentNullException("parentAircraft","must be not null");
            CurrentAircraft = parentAircraft;

            #region ButtonPrintContextMenu

            buttonPrintMenuStrip = new ContextMenuStrip();
            itemPrintReportStatusSchedule = new ToolStripMenuItem { Text = "Status Schedule" };
            itemPrintReportStatusUnschedule = new ToolStripMenuItem { Text = "Status Store" };
            itemPrintReportProgramSchedule = new ToolStripMenuItem { Text = "Program Schedule" };
            itemPrintReportProgramUnschedule = new ToolStripMenuItem { Text = "Program Store" };
            itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] 
                                                    { itemPrintReportStatusSchedule,
                                                      itemPrintReportStatusUnschedule,
                                                      itemPrintReportProgramSchedule,
                                                      itemPrintReportProgramUnschedule, 
                                                      itemPrintReportRecords, 
                                                      itemPrintReportHistory });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;
            #endregion

        }
        #endregion

        #endregion

        #region Metods

        #region protected override void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        protected override void CancelAsync()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();

            if (maintenancePerformanceControl1 != null)
            {
                maintenancePerformanceControl1.CancelAsync();
            }

            if (complianceControl != null)
            {
                complianceControl.CalcelAsync();
            }
        }
        #endregion

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            if (buttonPrintMenuStrip != null) buttonPrintMenuStrip.Dispose();
            if (itemPrintReportStatusSchedule != null) itemPrintReportStatusSchedule.Dispose();
            if (itemPrintReportStatusUnschedule != null) itemPrintReportStatusUnschedule.Dispose();
            if (itemPrintReportProgramSchedule != null) itemPrintReportProgramSchedule.Dispose();
            if (itemPrintReportProgramUnschedule != null) itemPrintReportProgramUnschedule.Dispose();
            if (itemPrintReportRecords != null) itemPrintReportRecords.Dispose();
            if (itemPrintReportHistory != null) itemPrintReportHistory.Dispose();

            if (maintenancePerformanceControl1 != null)
            {
                maintenancePerformanceControl1.CancelAsync();
            }

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (_preResult == null)
                return;
            if(_checkItems == null)
                _checkItems = new MaintenanceCheckCollection();
            _checkItems.Clear();
            _checkItems.AddRange(_preResult.ToArray());
            _preResult.Clear();

            statusControl.Aircraft = CurrentAircraft;
            statusControl.ConditionState = e.Result as ConditionState ?? ConditionState.NotEstimated;

            maintenanceSummaryControl1.UpdateInformation(_checkItems, CurrentAircraft, CurrentAircraft.Schedule);
            //обновление главной информацию по директиве
            maintenanceLimitationControl1.UpdateInformation(_checkItems, CurrentAircraft, _maintenanceDirectives);
            //обновление информации подзадач директивы
            maintenancePerformanceControl1.Reload(_checkItems, CurrentAircraft);
            //обновление информации об выполнении директивы
            complianceControl.Reload(_checkItems, CurrentAircraft, CurrentAircraft.Schedule);
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            if(_preResult == null)
                _preResult = new MaintenanceCheckCollection();
            _preResult.Clear();
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

            if (_maintenanceDirectives != null)
                _maintenanceDirectives.Clear();
            try
            {
                _maintenanceDirectives = GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft);
				var bindedItems = GlobalObjects.BindedItemsCore.GetBindedItemsFor(CurrentAircraft.ItemId,
						_maintenanceDirectives.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend).Cast<IBindedItem>());

				foreach (var mpd in _maintenanceDirectives)
                {
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd);

					if (bindedItems.ContainsKey(mpd))
					{
						var directives = bindedItems[mpd];
						foreach (var componentDirective in directives)
						{
							if (componentDirective is ComponentDirective)
							{
								GlobalObjects.PerformanceCalculator.GetNextPerformance(componentDirective);

								var firstNextPerformance =
									bindedItems[mpd].SelectMany(t => t.NextPerformances).OrderBy(n => n.NextPerformanceDate).FirstOrDefault();

								if (firstNextPerformance == null)
									continue;
								mpd.BindedItemNextPerformance = firstNextPerformance;
								mpd.BindedItemNextPerformanceSource = firstNextPerformance.NextPerformanceSource ?? Lifelength.Null;
								mpd.BindedItemRemains = firstNextPerformance.Remains ?? Lifelength.Null;
								mpd.BindedItemNextPerformanceDate = firstNextPerformance.NextPerformanceDate;
								mpd.BindedItemCondition = firstNextPerformance.Condition ?? ConditionState.NotEstimated;
							}
						}
					}

				}
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

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            maintenanceSummaryControl1.CheckItems = null;
            //обновление главной информацию по директиве
            maintenanceLimitationControl1.CheckItems = null;
            //обновление информации подзадач директивы
            maintenancePerformanceControl1.CheckItems = null;

            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if(sender == itemPrintReportStatusSchedule || sender == itemPrintReportStatusUnschedule)
            {
                MaintenanceStatusReportBuilder builder = new MaintenanceStatusReportBuilder();
                string caption = CurrentAircraft.RegistrationNumber + "." + "Maintenance Status report";  
                builder.ReportedAircraft = CurrentAircraft; 
                builder.LifelengthAircraftSinceNew =
                            GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                if (sender == itemPrintReportStatusSchedule)
                {
                    builder.FilterSelection = true;//(Schedule)
                    builder.ReportedDirectives = new MaintenanceCheckCollection(_checkItems.Where(c=>c.Schedule).ToList());
                    GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Status Schedule)");
				}
                if (sender == itemPrintReportStatusUnschedule)
                {
                    builder.FilterSelection = false;//(Unschedule)
                    builder.ReportedDirectives = new MaintenanceCheckCollection(_checkItems.Where(c => c.Schedule == false).ToList());
                    GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Status Store)");
				}
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
                
			}
            if(sender == itemPrintReportProgramSchedule || sender == itemPrintReportProgramUnschedule)
            {
                MaintenanceProgramReportBuilder builder = new MaintenanceProgramReportBuilder();
                string caption = CurrentAircraft.RegistrationNumber + "." + "Maintenance Program report";
                builder.ReportedAircraft = CurrentAircraft;
                builder.LifelengthAircraftSinceNew =
                            GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                if (sender == itemPrintReportProgramSchedule)
                {
                    builder.FilterSelection = true;//(Schedule)
                    builder.ReportedDirectives = new MaintenanceCheckCollection(_checkItems.Where(c => c.Schedule).ToList());
                    GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Program Schedule)");
				}
                if (sender == itemPrintReportProgramUnschedule)
                {
                    builder.FilterSelection = false;//(Unschedule)
                    builder.ReportedDirectives = new MaintenanceCheckCollection(_checkItems.Where(c => c.Schedule == false).ToList());
                    GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Program Store)");
				}
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
				
			}
            if (sender == itemPrintReportRecords)
            {
                MaintenanceRecordReportBuilder builder = new MaintenanceRecordReportBuilder();
                string caption = CurrentAircraft.RegistrationNumber + "." + "Maintenance Record report";
                builder.ReportedAircraft = CurrentAircraft;
                builder.LifelengthAircraftSinceNew =
                            GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                builder.FilterSelection = true;//(Schedule)
                builder.ReportedDirectives = new MaintenanceCheckCollection(_checkItems.ToList());
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
                GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Records)");
			}
            if (sender == itemPrintReportHistory)
            {
                List<MaintenanceCheckRecord> records = new List<MaintenanceCheckRecord>(complianceControl.GetItemsArray());
                MaintenanceHistoryReportBuilder builder = new MaintenanceHistoryReportBuilder();
                string caption = CurrentAircraft.RegistrationNumber + "." + "Maintenance History report";
                builder.ReportedAircraft = CurrentAircraft;
                builder.LifelengthAircraftSinceNew =
                            GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                builder.FilterSelection = true;//(Schedule)
                builder.ReportedDirectives = records;
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
                GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceScreen (Compliance history)");
			}
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending1(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending1(object sender, EventArgs e)
        {
            maintenancePerformanceControl1.Visible = !maintenancePerformanceControl1.Visible;
            
            if (maintenancePerformanceControl1.Visible)
            {
                flowLayoutPanel1.ScrollControlIntoView(extendableRichContainerPerformance);
                extendableRichContainerPerformance.Focus();
            }
            else
            {
                if (maintenanceLimitationControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainer1);
                    maintenanceLimitationControl1.Focus();
                }
                else if (maintenanceSummaryControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainerSummary);
                    maintenanceSummaryControl1.Focus();
                }
            }
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            maintenanceSummaryControl1.Visible = !maintenanceSummaryControl1.Visible;

            if (maintenanceSummaryControl1.Visible)
            {
                flowLayoutPanel1.ScrollControlIntoView(extendableRichContainerSummary);
                maintenanceSummaryControl1.Focus();
            }
            else
            {
                if (maintenanceLimitationControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainer1);
                    maintenanceLimitationControl1.Focus();
                }
                else if (maintenancePerformanceControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainerPerformance);
                    extendableRichContainerPerformance.Focus();
                }
            }
        }
        #endregion

        #region private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        {
            maintenanceLimitationControl1.Visible = !maintenanceLimitationControl1.Visible;

            if (maintenanceLimitationControl1.Visible)
            {
                flowLayoutPanel1.ScrollControlIntoView(extendableRichContainer1);
                maintenanceLimitationControl1.Focus();
            }
            else
            {
                if (maintenanceLimitationControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainer1);
                    maintenanceLimitationControl1.Focus();
                }
                else if (maintenancePerformanceControl1.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(extendableRichContainerPerformance);
                    extendableRichContainerPerformance.Focus();
                }
            }
        }
        #endregion

        #region private void MaintenanceCompliance1ComplianceAdded(object sender, EventArgs e)
        private void MaintenanceCompliance1ComplianceAdded(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #endregion
    }
}
