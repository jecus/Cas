using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Relation;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class ForecastListScreenMtopNew : ScreenControl
    {
		#region Fields

	    private Dictionary<int, Lifelength> _groupLifelengths = new Dictionary<int, Lifelength>();
	    private Dictionary<int, Lifelength> _groupLifelengthsForZeroCheck = new Dictionary<int, Lifelength>();

		private bool _isFirstLoad;
		private ForecastMTOPListView _directivesViewer;
        private Forecast _currentForecast;
        private ICommonCollection<NextPerformance> _initialDirectiveArray = new CommonCollection<NextPerformance>();
        private ICommonCollection<NextPerformance> _resultDirectiveArray = new CommonCollection<NextPerformance>();
        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

        private List<int> _reCalculateIds = new List<int>();
        
        private BaseComponent _currentBaseComponent;
        private readonly Store _currentStore;
        private Aircraft _currentAircraft;

        private CommonFilterCollection _filter = new CommonFilterCollection(typeof(NextPerformance));

        private DirectiveType _currentPrimaryDirectiveType;

        private MonthlyPlanReportBuilder _scheduleReportBuilder;
        private MaintenancePlanReportBuilder _maintenancePlanReportBulder;
        private ForecastKitsReportBuilder _forecastKitsReportBuilder;
		private ComponentsReportBuilder _componentsReportBulder;

		private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportSchedule;
        private ToolStripMenuItem itemPrintReportMaintenancePlan;
        private ToolStripMenuItem itemPrintReportEquipmentAndMaterials;
		private ToolStripMenuItem _itemPrintComponents;

		private ContextMenuStrip _contextMenuStrip;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripMenuItem _createWorkPakageToolStripMenuItem;
        private ToolStripMenuItem _createInitialOrderStripMenuItem;
        private ToolStripMenuItem _createQuotationOrderStripMenuItem;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
	    private ToolStripMenuItem _toolStripMenuItemShowTaskCard;
	    private ToolStripMenuItem _toolStripMenuItemTenPercent;
	    private ToolStripMenuItem _toolStripMenuItemCloseDirectives;

		#endregion

		#region Constructors

		#region public ForecastListScreenMtopNew()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public ForecastListScreenMtopNew()
        {
            InitializeComponent();
        }
        #endregion

        #region public ForecastListScreen(List<object> currentContainer, PrimaryDirectiveType directiveType) : this()

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentContainer">ВС, которому принадлежат директивы</param>
        ///<param name="directiveType"></param>
        public ForecastListScreenMtopNew(BaseEntityObject currentContainer, DirectiveType directiveType)
            : this()
        {
            if (currentContainer == null)
                throw new ArgumentNullException("currentContainer");
            if (currentContainer is Aircraft)
            {
                CurrentAircraft = (Aircraft) currentContainer;
                _currentAircraft = (Aircraft)currentContainer;
            }
            else if (currentContainer is Store)
            {
                _currentStore = (Store)currentContainer;
            }
            else
            {
                _currentBaseComponent = (BaseComponent)currentContainer;
                CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			}
            _currentPrimaryDirectiveType = directiveType;
            StatusTitle = "Forecast";
            _currentForecast = new Forecast {Aircraft = CurrentAircraft};
	        _isFirstLoad = true;
			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
            itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Maintenance Plan" };
            itemPrintReportEquipmentAndMaterials = new ToolStripMenuItem { Text = "Equipment and Materials" };
			_itemPrintComponents = new ToolStripMenuItem { Text = "Components" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintComponents, itemPrintReportSchedule, itemPrintReportMaintenancePlan, itemPrintReportEquipmentAndMaterials });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;

            #endregion

            InitToolStripMenuItems();
            InitListView();
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            _initialDirectiveArray.Clear();
            _initialDirectiveArray = null;

            _resultDirectiveArray.Clear();
            _resultDirectiveArray = null;

            _openPubWorkPackages.Clear();

            _initialDirectiveArray = null;
            _openPubWorkPackages = null;

            _openPubQuotations.Clear();
            _openPubQuotations = null;

            if (_currentForecast != null)
            {
                _currentForecast.Dispose();
                _currentForecast = null;
            }

            if (_createInitialOrderStripMenuItem != null) _createInitialOrderStripMenuItem.Dispose();
            if (_createQuotationOrderStripMenuItem != null) _createQuotationOrderStripMenuItem.Dispose();
            if (_createWorkPakageToolStripMenuItem != null) _createWorkPakageToolStripMenuItem.Dispose();
            if (_toolStripMenuItemsWorkPackages != null) _toolStripMenuItemsWorkPackages.Dispose();
            if (_toolStripMenuItemHighlight != null)
            {
                foreach (ToolStripMenuItem ttmi in _toolStripMenuItemHighlight.DropDownItems)
                {
                    ttmi.Click -= HighlightItemClick;
                }
                _toolStripMenuItemHighlight.DropDownItems.Clear();
                _toolStripMenuItemHighlight.Dispose();
            }
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.DropDownItems.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }
            if (_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                {
                    item.Click -= AddToWorkPackageItemClick;
                }
                _toolStripMenuItemsWorkPackages.DropDownItems.Clear();
                _toolStripMenuItemsWorkPackages.Dispose();
            }

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                return;
            if (_currentAircraft != null)
            {
                aircraftHeaderControl1.Aircraft = _currentAircraft;
            }


			if (_isFirstLoad)
			{
				_isFirstLoad = false;
				var form = new ForecastCustomsMTOP(CurrentAircraft, _currentForecast);

				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}

	        if (_currentForecast.ForecastDatas.Count > 0)
	        {
		        var main = _currentForecast.ForecastDatas[0];
		        labelDateAsOf.Text =
			        "Forecast Period From: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.LowerLimit) +
			        " To: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
			        "\nAvg. utlz: " + main.AverageUtilization.CustomToString();
	        }


			if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }

                _toolStripMenuItemQuotations.DropDownItems.Clear();

                foreach (RequestForQuotation quotation in _openPubQuotations)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(quotation.Title);
                    item.Click += AddToQuotationOrderItemClick;
                    item.Tag = quotation;
                    _toolStripMenuItemQuotations.DropDownItems.Add(item);
                }
            }
            if (_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                {
                    item.Click -= AddToWorkPackageItemClick;
                }

                _toolStripMenuItemsWorkPackages.DropDownItems.Clear();

                foreach (WorkPackage workPackage in _openPubWorkPackages)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem($"{workPackage.Number} {workPackage.Title}");
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = workPackage;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
                }
            }
            _directivesViewer.SetItemsArray(_resultDirectiveArray.OrderBy(i => i.PerformanceDate).ToArray());


            headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
	        var initialZeroMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
	        var initialMaintenanceDirectives = new CommonCollection<MaintenanceDirective>();
	        _groupLifelengths.Clear();
	        _groupLifelengthsForZeroCheck.Clear();

			if (!_isFirstLoad)
	        {
		        #region Загрузка элементов

		        _initialDirectiveArray.Clear();
		        List<IDirective> directives = new List<IDirective>();

		        #region --загрузка элементов--)

		        if (_currentAircraft != null)
		        {
			        if (_currentPrimaryDirectiveType == DirectiveType.All)
			        {
				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        //AnimatedThreadWorker.ReportProgress(0, "calculation of Maintenance checks");
				        //GlobalObjects.AnalystCore.GetMaintenanceCheck(_currentForecast);
				        //directives.AddRange(_currentForecast.MaintenanceChecks.ToArray());

				        //if (AnimatedThreadWorker.CancellationPending)
				        //{
					       // e.Cancel = true;
					       // return;
				        //}

				        AnimatedThreadWorker.ReportProgress(0, "calculation of Base details");
				        GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectives(_currentForecast);
				        directives.AddRange(_currentForecast.BaseComponents.ToArray());
				        directives.AddRange(_currentForecast.BaseComponentDirectives.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(18, "calculation of Components");
				        GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(_currentForecast);
				        directives.AddRange(_currentForecast.Components.ToArray());
				        directives.AddRange(_currentForecast.ComponentDirectives.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(27, "calculation of Airworthiness directives");
				        GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.AirworthenessDirectives);
				        directives.AddRange(_currentForecast.AdStatus.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(36, "calculation of Damages");
				        GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.DamagesRequiring);
				        directives.AddRange(_currentForecast.Damages.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(45, "calculation of Deffereds");
				        GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.DeferredItems);
				        directives.AddRange(_currentForecast.DefferedItems.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(54, "calculation of Engineering orders");
				        GlobalObjects.AnalystCore.GetEngineeringOrders(_currentForecast);
				        //directives.AddRange(_currentForecast.EngineeringOrders.ToArray());
				        foreach (Directive engineeringOrder in _currentForecast.EngineeringOrders
					        .Where(engineeringOrder =>
						        directives.FirstOrDefault(d => d is Directive && d.ItemId == engineeringOrder.ItemId) == null))
				        {
					        directives.Add(engineeringOrder);
				        }

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(63, "calculation of Service bulletins");
				        GlobalObjects.AnalystCore.GetServiceBulletins(_currentForecast);
				        //directives.AddRange(_currentForecast.ServiceBulletins.ToArray());
				        foreach (Directive serviceBulletin in _currentForecast.ServiceBulletins
					        .Where(serviceBulletin =>
						        directives.FirstOrDefault(d => d is Directive && d.ItemId == serviceBulletin.ItemId) == null))
				        {
					        directives.Add(serviceBulletin);
				        }

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(72, "calculation of Out of phase");
				        GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.OutOfPhase);
				        directives.AddRange(_currentForecast.OutOfPhaseItems.ToArray());

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(81, "calculation of Maintenance Directives");

						////////////////////////////////////////////////////////////////

						var checks = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MTOPCheckDTO, MTOPCheck>(new Filter("ParentAircraftId", CurrentAircraft.ItemId), true).ToList();
						
						foreach (var check in checks)
						{
							foreach (var record in check.PerformanceRecords)
								record.Parent = check;
						}

						if (AnimatedThreadWorker.CancellationPending)
						{
							e.Cancel = true;
							return;
						}

						AnimatedThreadWorker.ReportProgress(10, "load MPDs");

						initialMaintenanceDirectives.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft));

				        foreach (var id in _reCalculateIds)
				        {
					        var mpd = initialMaintenanceDirectives.FirstOrDefault(i => i.ItemId == id);
					        if (mpd != null)
						        mpd.RecalculateTenPercent = true;
				        }


						var bindedItemsDict = GlobalObjects.BindedItemsCore.GetBindedItemsFor(CurrentAircraft.ItemId,
							initialMaintenanceDirectives.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend));

						CalculateMaintenanceDirectives(initialMaintenanceDirectives.ToList(), bindedItemsDict);

						if (AnimatedThreadWorker.CancellationPending)
						{
							e.Cancel = true;
							return;
						}


						AnimatedThreadWorker.ReportProgress(50, "calculation");


						if (checks.Count > 0)
						{
							//Берем утилизацию с Frame
							var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
								i.ParentAircraftId == CurrentAircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
							var avg = _currentForecast.ForecastDatas[0].AverageUtilization;

							var lastCompliance = checks.SelectMany(i => i.PerformanceRecords).OrderByDescending(i => i.RecordDate)
								.FirstOrDefault();


							if (_currentForecast.IsAllPhase)
							{
								GlobalObjects.MTOPCalculator.CalculateMtopChecks(checks, avg);

								_groupLifelengths = GlobalObjects.MTOPCalculator.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList());

								GlobalObjects.MTOPCalculator.CalculateNextPerformance(checks.Where(i => !i.IsZeroPhase).ToList(),
									frame.StartDate, _groupLifelengths, CurrentAircraft, avg, lastCompliance);
								GlobalObjects.MTOPCalculator.CalculateNextPerformance(checks.Where(i => !i.IsZeroPhase).ToList(),
									frame.StartDate, _groupLifelengths, CurrentAircraft, avg, lastCompliance, true);

								GlobalObjects.MTOPCalculator.CalculatePhaseWithPerformance(initialMaintenanceDirectives, checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList(), avg, _currentForecast.ForecastDatas[0].LowerLimit, _currentForecast.ForecastDatas[0].ForecastDate);


								var maintenanceZeroChecks = checks.Where(i => i.IsZeroPhase).ToList();

								var lowerZeroCheck = maintenanceZeroChecks.Where(i => !i.Thresh.IsNullOrZero()).OrderBy(i => i.Thresh)
									.FirstOrDefault();
								if (lowerZeroCheck != null)
								{
									GlobalObjects.MTOPCalculator.CalculateMtopChecks(maintenanceZeroChecks, avg);

									_groupLifelengthsForZeroCheck = GlobalObjects.MTOPCalculator.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && i.IsZeroPhase).ToList());

									GlobalObjects.MTOPCalculator.CalculateNextPerformance(maintenanceZeroChecks, frame.StartDate,
										_groupLifelengthsForZeroCheck, CurrentAircraft, avg, lastCompliance);
									GlobalObjects.MTOPCalculator.CalculateNextPerformance(maintenanceZeroChecks, frame.StartDate,
										_groupLifelengthsForZeroCheck, CurrentAircraft, avg, lastCompliance, true);

									initialZeroMaintenanceDirectives.AddRange(initialMaintenanceDirectives
										.Where(i => i.MTOPPhase?.FirstPhase == 0).ToArray());

									GlobalObjects.MTOPCalculator.CalculatePhaseWithPerformance(initialZeroMaintenanceDirectives, maintenanceZeroChecks, avg, _currentForecast.ForecastDatas[0].LowerLimit, _currentForecast.ForecastDatas[0].ForecastDate, true);

								}

								foreach (var d in initialZeroMaintenanceDirectives)
									initialMaintenanceDirectives.Remove(d);
							}
							else
							{
								var maintenanceZeroChecks = checks.Where(i => i.IsZeroPhase).ToList();
								var lowerZeroCheck = maintenanceZeroChecks.Where(i => !i.Thresh.IsNullOrZero()).OrderBy(i => i.Thresh).FirstOrDefault();


								if (lowerZeroCheck != null)
								{
									GlobalObjects.MTOPCalculator.CalculateMtopChecks(maintenanceZeroChecks, avg);

									_groupLifelengthsForZeroCheck = GlobalObjects.MTOPCalculator.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && i.IsZeroPhase).ToList());

									GlobalObjects.MTOPCalculator.CalculateNextPerformance(maintenanceZeroChecks, frame.StartDate,
										_groupLifelengthsForZeroCheck, CurrentAircraft, avg, lastCompliance);
									GlobalObjects.MTOPCalculator.CalculateNextPerformance(maintenanceZeroChecks, frame.StartDate,
										_groupLifelengthsForZeroCheck, CurrentAircraft, avg, lastCompliance,true);

									GlobalObjects.MTOPCalculator.CalculatePhaseWithPerformance(initialMaintenanceDirectives, maintenanceZeroChecks, avg, _currentForecast.ForecastDatas[0].LowerLimit, _currentForecast.ForecastDatas[0].ForecastDate, true);
								}
							}

						}

						////////////////////////////////////////////////////////////////

						directives.AddRange(initialMaintenanceDirectives);
						directives.AddRange(initialZeroMaintenanceDirectives);

				        if (AnimatedThreadWorker.CancellationPending)
				        {
					        e.Cancel = true;
					        return;
				        }

				        AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");
			        }
			        else if (_currentPrimaryDirectiveType != DirectiveType.Unknown)
			        {
				        GlobalObjects.AnalystCore.GetDirectives(_currentForecast, _currentPrimaryDirectiveType);
				        directives.AddRange(_currentForecast.DirectiveCollections[_currentPrimaryDirectiveType].ToArray());
			        }
			        else
			        {
				        throw new ArgumentException(@"1016: ");
			        }
		        }

		        #endregion

		        //загрузка рабочих пакетов для определения 
		        //перекрытых ими выполнений задач
		        if (_openPubWorkPackages == null)
			        _openPubWorkPackages = new CommonCollection<WorkPackage>();
		        _openPubWorkPackages.Clear();
		        _openPubWorkPackages.AddRange(
			        GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
		        _openPubWorkPackages.AddRange(
			        GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));
		        //сбор всех записей рабочих пакетов для удобства фильтрации
		        List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
		        foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
			        openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

				foreach (IDirective dir in directives)
		        {
			        //if (dir is MaintenanceCheck)
			        //{
				       // MaintenanceCheck mc = (MaintenanceCheck) dir;
				       // if (mc.Grouping)
				       // {
					      //  //определение первого выполнения в котором данный чек
					      //  //является главным
					      //  _initialDirectiveArray.Add(mc.GetPergormanceGroupWhereCheckIsSenior().First());

					      //  //Проход по всем след. выполнениям чека и записям в рабочих пакетах
					      //  //для поиска перекрывающихся выполнений
					      //  List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
					      //  foreach (MaintenanceNextPerformance mnp in performances)
					      //  {
						     //   //поиск записи в рабочих пакетах по данному чеку
						     //   //чей номер группы выполнения (по записи) совпадает с расчитанным
						     //   WorkPackageRecord wpr =
							    //    openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == mnp.PerformanceGroupNum &&
							    //                                      r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
							    //                                      r.DirectiveId == mc.ItemId);
						     //   if (wpr != null)
							    //    mnp.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
					      //  }
				       // }
				       // else
				       // {
					      //  //определение первого выполнения в котором данный чек
					      //  //является главным
					      //  _initialDirectiveArray.Add(mc.NextPerformances.First());
					      //  //Проход по всем след. выполнениям чека и записям в рабочих пакетах
					      //  //для поиска перекрывающихся выполнений
					      //  List<NextPerformance> performances = dir.NextPerformances;
					      //  foreach (NextPerformance np in performances)
					      //  {
						     //   //поиск записи в рабочих пакетах по данному чеку
						     //   //чей номер группы выполнения (по записи) совпадает с расчитанным
						     //   WorkPackageRecord wpr =
							    //    openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
							    //                                      r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
							    //                                      r.DirectiveId == mc.ItemId);
						     //   if (wpr != null)
							    //    np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
					      //  }
				       // }
			        //}
			        if (dir is Component)
			        {
				        if (dir.NextPerformances.Count <= 0)
					        continue;

				        Component component = (Component) dir;
				        _initialDirectiveArray.Add(component.NextPerformances.First());

				        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
				        //для поиска перекрывающихся выполнений
				        List<NextPerformance> performances = component.NextPerformances;
				        foreach (NextPerformance np in performances)
				        {
					        //поиск записи в рабочих пакетах по данному чеку
					        //чей номер группы выполнения (по записи) совпадает с расчитанным
					        WorkPackageRecord wpr =
						        openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
						                                          r.WorkPackageItemType == component.SmartCoreObjectType.ItemId &&
						                                          r.DirectiveId == component.ItemId);
					        if (wpr != null)
						        np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
				        }
			        }
			        else if(dir is MaintenanceDirective)
			        {
				        MaintenanceDirective directive = (MaintenanceDirective)dir;

				        if (directive.MtopNextPerformances.Count <= 0)
					        continue;
				        _initialDirectiveArray.Add(directive.MtopNextPerformances.First());


				        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
				        //для поиска перекрывающихся выполнений
				        List<NextPerformance> performances = directive.MtopNextPerformances;
				        foreach (NextPerformance np in performances)
				        {
					        //поиск записи в рабочих пакетах по данному чеку
					        //чей номер группы выполнения (по записи) совпадает с расчитанным
					        WorkPackageRecord wpr =
						        openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
						                                          r.WorkPackageItemType == directive.SmartCoreObjectType.ItemId &&
						                                          r.DirectiveId == directive.ItemId);

					        if (wpr != null)
						        np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
						}
					}
			        else
			        {
				        if (dir.NextPerformances.Count <= 0)
					        continue;
				        _initialDirectiveArray.Add(dir.NextPerformances.First());

				        BaseEntityObject baseObject = (BaseEntityObject) dir;
				        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
				        //для поиска перекрывающихся выполнений
				        List<NextPerformance> performances = dir.NextPerformances;
				        foreach (NextPerformance np in performances)
				        {
					        //поиск записи в рабочих пакетах по данному чеку
					        //чей номер группы выполнения (по записи) совпадает с расчитанным
					        WorkPackageRecord wpr =
						        openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
						                                          r.WorkPackageItemType == baseObject.SmartCoreObjectType.ItemId &&
						                                          r.DirectiveId == baseObject.ItemId);
					        if (wpr != null)
						        np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
				        }
			        }
		        }

		        if (AnimatedThreadWorker.CancellationPending)
		        {
			        e.Cancel = true;
			        return;
		        }

		        #region Фильтрация директив

		        AnimatedThreadWorker.ReportProgress(95, "filter directives");

		        FilterItems(_initialDirectiveArray, _resultDirectiveArray);

		        if (AnimatedThreadWorker.CancellationPending)
		        {
			        e.Cancel = true;
			        return;
		        }

		        #endregion

		        #region Загрузка Котировочных ордеров

		        AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

		        //загрузка рабочих пакетов для определения 
		        //перекрытых ими выполнений задач
		        if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

		        BaseEntityObject parent = CurrentAircraft ?? (BaseEntityObject) CurrentOperator;
		        _openPubQuotations.Clear();
		        _openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(parent,
			        new[] {WorkPackageStatus.Opened, WorkPackageStatus.Published}));

		        if (AnimatedThreadWorker.CancellationPending)
		        {
			        e.Cancel = true;
			        return;
		        }

		        #endregion

		        AnimatedThreadWorker.ReportProgress(100, "calculation over");

		        #endregion
	        }

        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
        {
            _resultDirectiveArray.Clear();

            #region Фильтрация директив

            AnimatedThreadWorker.ReportProgress(50, "filter directives");

            FilterItems(_initialDirectiveArray, _resultDirectiveArray);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _createWorkPakageToolStripMenuItem = new ToolStripMenuItem();
            _createInitialOrderStripMenuItem = new ToolStripMenuItem();
            _createQuotationOrderStripMenuItem = new ToolStripMenuItem();
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
	        _toolStripMenuItemShowTaskCard = new ToolStripMenuItem();
	        _toolStripMenuItemTenPercent = new ToolStripMenuItem();
	        _toolStripMenuItemCloseDirectives = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";

            _createWorkPakageToolStripMenuItem.Text = "Create work package";
            _createWorkPakageToolStripMenuItem.Click += ButtonCreateWorkPakageClick;
            //
            // _toolStripMenuItemsWorkPackages
            //
            _toolStripMenuItemsWorkPackages.Text = "Add to work package";
            // 
            // createInitialOrderStripMenuItem
            // 
            _createInitialOrderStripMenuItem.Text = "Compose new Initial Order";
            _createInitialOrderStripMenuItem.Click += ToolStripMenuItemComposeInitialClick;
            // 
            // toolStripMenuItemView
            // 
            _createQuotationOrderStripMenuItem.Text = "Compose Quotation";
            _createQuotationOrderStripMenuItem.Click += ToolStripMenuItemComposeQuotationClick;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemQuotations.Text = "Add to Quotation Order";
	        // 
	        // _toolStripMenuItemShowTaskCard
	        // 
	        _toolStripMenuItemShowTaskCard.Text = "Show Task Card";
	        _toolStripMenuItemShowTaskCard.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// _toolStripMenuItemTenPercent
			// 
	        _toolStripMenuItemTenPercent.Text = "Recalculate with 10%";
	        _toolStripMenuItemTenPercent.Click += ToolStripMenuItemTenPercent;
			// 
			// _toolStripMenuItemCloseDirectives
			// 
	        _toolStripMenuItemCloseDirectives.Text = "Close Directives";
	        _toolStripMenuItemCloseDirectives.Click += ToolStripMenuItemCloseDirectives;


			_contextMenuStrip.Items.Clear();
            _toolStripMenuItemsWorkPackages.DropDownItems.Clear();
            _toolStripMenuItemQuotations.DropDownItems.Clear();
            _toolStripMenuItemHighlight.DropDownItems.Clear();

            foreach (Highlight highlight in Highlight.HighlightList)
            {
                if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem(highlight.FullName);
                item.Click += HighlightItemClick;
                item.Tag = highlight;
                _toolStripMenuItemHighlight.DropDownItems.Add(item);
            }

            _contextMenuStrip.Opening += ContextMenuStripOpen;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
	                                                _toolStripMenuItemShowTaskCard,
	                                                new ToolStripSeparator(),
													_toolStripMenuItemHighlight,
                                                    new ToolStripSeparator(),
	                                                _toolStripMenuItemTenPercent,
	                                                new ToolStripSeparator(),
	                                                _toolStripMenuItemCloseDirectives,
	                                                new ToolStripSeparator(),
													_createWorkPakageToolStripMenuItem,
                                                    _toolStripMenuItemsWorkPackages,
                                                    _toolStripSeparator1,
                                                    _createInitialOrderStripMenuItem,
                                                    _createQuotationOrderStripMenuItem,
                                                    _toolStripMenuItemQuotations,
                                                });
        }

		#endregion


		private void ToolStripMenuItemCloseDirectives(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 0) return;


			var complainceForm = new DirectiveComplianceDialog(_directivesViewer.SelectedItems.FirstOrDefault().Parent, _directivesViewer.SelectedItems, _currentForecast.ForecastDatas[0].AverageUtilization);
			if(complainceForm.ShowDialog(this) == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		private void ToolStripMenuItemTenPercent(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;

			foreach (var performance in _directivesViewer.SelectedItems.Where(i => i.Parent is MaintenanceDirective))
				_reCalculateIds.Add(performance.Parent.ItemId);

			AnimatedThreadWorker.RunWorkerAsync();

		}

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;

			if (_directivesViewer.SelectedItems[0].Parent is MaintenanceDirective)
			{
				var mpd = _directivesViewer.SelectedItems[0].Parent as MaintenanceDirective;
				if (mpd == null || mpd.TaskCardNumberFile == null)
				{
					MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
					return;
				}

				try
				{
					string message;
					GlobalObjects.CasEnvironment.OpenFile(mpd.TaskCardNumberFile, out message);
					if (message != "")
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
							MessageBoxDefaultButton.Button1);
					}
				}
				catch (Exception ex)
				{
					string errorDescriptionSctring =
						string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", mpd, mpd.ItemId, mpd.TaskCardNumberFile.ItemId);
					Program.Provider.Logger.Log(errorDescriptionSctring, ex);
				}
			}
		}

		#region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
		/// <summary>
		/// Проверка на выделение 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
		{
			_toolStripMenuItemCloseDirectives.Enabled = _directivesViewer.SelectedItems.Count > 0 && _directivesViewer.SelectedItems.All(i => i.Parent is MaintenanceDirective) ;

			if (_directivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
            if (_directivesViewer.SelectedItems.Count == 1)
            {
                _createWorkPakageToolStripMenuItem.Enabled = true;
	            if (_directivesViewer.SelectedItem.Parent is MaintenanceDirective)
	            {
		            var mpd = _directivesViewer.SelectedItem.Parent as MaintenanceDirective;
		            _toolStripMenuItemTenPercent.Enabled = !mpd.RecalculateTenPercent;
	            }
            }
            _createInitialOrderStripMenuItem.Enabled = true;
            _createQuotationOrderStripMenuItem.Enabled = true;
        }

        #endregion

        #region private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        /// <summary>
        /// Публикует рабочий пакет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeInitialOrder(_directivesViewer.SelectedItems.ToArray(), CurrentParent, this);
        }

        #endregion

        #region private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        /// <summary>
        /// Публикует рабочий пакет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeQuotationOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

        #endregion

        #region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

        private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new ForecastMTOPListView
			{
                                        ContextMenuStrip = _contextMenuStrip,
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count > 0)
            {
                _buttonComposeWorkPackage.Enabled = true;
                headerControl.EditButtonEnabled = true;
            }
            else
            {
                headerControl.EditButtonEnabled = false;
                _buttonComposeWorkPackage.Enabled = false;
            }
        }

        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentAircraft != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);

                //очистка массива данных по прогнозам
                _currentForecast.ForecastDatas.Clear();
                //поиск деталей данного самолета 
                var aircraftBaseDetails = 
                    new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
                //составление нового массива данных по прогнозам
                foreach (var baseComponent in aircraftBaseDetails)
                {
                    //определение ресурсов прогноза для каждой базовой детали
                    var forecastData = 
                        new ForecastData(DateTime.Today,
                                         baseComponent,
                                         GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
                    //дабавление в массив
                    _currentForecast.ForecastDatas.Add(forecastData);
                }
            }
            if (_currentBaseComponent != null)
            {
                labelTitle.Text = "Date as of: " +
                   SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Component TSN/CSN: " +
                   GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent);

                //очистка массива данных по прогнозам
                _currentForecast.ForecastDatas.Clear();
                //определение ресурсов прогноза для каждой базовой детали
                ForecastData forecastData =
                    new ForecastData(DateTime.Today,
                                     _currentBaseComponent,
                                     GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
                //дабавление в массив
                _currentForecast.ForecastDatas.Add(forecastData);
            }
            if (_currentStore != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Store: " +
                    _currentStore.Name;
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HighlightItemClick(object sender, EventArgs e)

        private void HighlightItemClick(object sender, EventArgs e)
        {
            Highlight highLight = (Highlight)((ToolStripMenuItem)sender).Tag;
            for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
            {
                _directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
            }
        }

        #endregion

        #region private void ButtonApplyFilterClick(object sender, EventArgs e)

        private void ButtonApplyFilterClick(object sender, EventArgs e)
        {
            CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray){Text = "Forecast Filter Form"};

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
                AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

                AnimatedThreadWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region private void ButtonCreateWorkPakageClick(object sender, EventArgs e)

        private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("Create and save a Work Package?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<NextPerformance> wpItems = _directivesViewer.SelectedItems.ToList();
                List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
                foreach (NextPerformance wpItem in wpItems)
                {
                    if(wpItem is MaintenanceNextPerformance)
                    {
                        MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
                        if(mnp.PerformanceGroup.Checks.Count > 0)
                        {
                            foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
                            {
                                foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                              mpd.MaintenanceCheck.ItemId == mc.ItemId))
                                {
                                    NextPerformance performance =
                                        mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                                 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                        mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
                                                                                p.PerformanceDate < wpItem.PerformanceDate) ??
                                        mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                                 p.PerformanceDate > wpItem.PerformanceDate);

                                    if (performance == null) continue;
                                    if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                        bindedDirectivesPerformances.Add(performance);
                                }   
                            }
                        }
                        else if (wpItem.Parent is MaintenanceCheck)
                        {
                            MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
                            foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                    .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                                  mpd.MaintenanceCheck.ItemId == mc.ItemId))
                            {
                                NextPerformance performance =
                                    mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                             p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                    mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
                                                                            p.PerformanceDate < wpItem.PerformanceDate) ??
                                    mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                             p.PerformanceDate > wpItem.PerformanceDate);

                                if (performance == null) continue;
                                if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                    bindedDirectivesPerformances.Add(performance);
                            }
                        }
                    }
                    else if(wpItem.Parent is MaintenanceCheck)
                    {
                        MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
                        foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                              mpd.MaintenanceCheck.ItemId == mc.ItemId))
                        {
                            NextPerformance performance =
                                mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                         p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null && 
                                                                        p.PerformanceDate < wpItem.PerformanceDate) ??
                                mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null && 
                                                                         p.PerformanceDate > wpItem.PerformanceDate);

                            if (performance == null) continue;
                            if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                 bindedDirectivesPerformances.Add(performance);
                        }
                    }
                }
                wpItems.AddRange(bindedDirectivesPerformances);

                try
                {
                    string message;
                    WorkPackage wp = 
                        GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, _currentAircraft, out message);
                    if(wp == null)
                    {
                         MessageBox.Show(message,(string)new GlobalTermsProvider()["SystemName"],
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);  
                         return;
                    }
                    //Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
                    _openPubWorkPackages.Add(wp);
                    //Создание пункта в меню открытых рабочих пакетов
                    ToolStripMenuItem item = new ToolStripMenuItem($"{wp.Title} {wp.Number}");
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = wp;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);

                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        _directivesViewer.UpdateItemColor(nextPerformance);
                    }
                    ReferenceEventArgs refArgs = new ReferenceEventArgs();
                    refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
                    refArgs.RequestedEntity = new WorkPackageScreen(wp);
                    InvokeDisplayerRequested(refArgs);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("error while create Work Package", ex);
                }
            }
        }
        #endregion

        #region private void AddToWorkPackageItemClick(object sender, EventArgs e)

        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            WorkPackage wp = (WorkPackage)((ToolStripMenuItem)sender).Tag;

            if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                List<NextPerformance> wpItems = _directivesViewer.SelectedItems.ToList();
                List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
                foreach (NextPerformance wpItem in wpItems)
                {
                    if (wpItem is MaintenanceNextPerformance)
                    {
                        MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
                        if (mnp.PerformanceGroup.Checks.Count > 0)
                        {
                            foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
                            {
                                foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                              mpd.MaintenanceCheck.ItemId == mc.ItemId))
                                {
                                    NextPerformance performance =
                                        mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                                 p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                        mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
                                                                                p.PerformanceDate < wpItem.PerformanceDate) ??
                                        mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                                 p.PerformanceDate > wpItem.PerformanceDate);

                                    if (performance == null) continue;
                                    if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                        bindedDirectivesPerformances.Add(performance);
                                }
                            }
                        }
                        else if (wpItem.Parent is MaintenanceCheck)
                        {
                            MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
                            foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                    .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                                  mpd.MaintenanceCheck.ItemId == mc.ItemId))
                            {
                                NextPerformance performance =
                                    mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                             p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                    mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
                                                                            p.PerformanceDate < wpItem.PerformanceDate) ??
                                    mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                             p.PerformanceDate > wpItem.PerformanceDate);

                                if (performance == null) continue;
                                if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                    bindedDirectivesPerformances.Add(performance);
                            }
                        }
                    }
                    else if (wpItem.Parent is MaintenanceCheck)
                    {
                        MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
                        foreach (MaintenanceDirective mpd in _currentForecast.MaintenanceDirectives
                                                                .Where(mpd => mpd.MaintenanceCheck != null &&
                                                                              mpd.MaintenanceCheck.ItemId == mc.ItemId))
                        {
                            NextPerformance performance =
                                mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                         p.PerformanceDate.Value.Date == wpItem.PerformanceDate.Value.Date) ??
                                mpd.NextPerformances.LastOrDefault(p => p.PerformanceDate != null &&
                                                                        p.PerformanceDate < wpItem.PerformanceDate) ??
                                mpd.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null &&
                                                                         p.PerformanceDate > wpItem.PerformanceDate);

                            if (performance == null) continue;
                            if (wpItems.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                bindedDirectivesPerformances.Add(performance);
                        }
                    }
                }
                wpItems.AddRange(bindedDirectivesPerformances);

                try
                {
                    string message;

                    if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, CurrentAircraft, out message))
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        _directivesViewer.UpdateItemColor(nextPerformance);
                    }

                    if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        ReferenceEventArgs refArgs = new ReferenceEventArgs();
                        refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
                        refArgs.RequestedEntity = new WorkPackageScreen(wp);
                        InvokeDisplayerRequested(refArgs);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("error while create Work Package", ex);
                }
            }
        }

        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            if(!AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;

		    if (sender == itemPrintReportSchedule)
            {
                _scheduleReportBuilder = new MonthlyPlanReportBuilder(CurrentAircraft, _directivesViewer.GetItemsArray());
	            _scheduleReportBuilder.Forecast = _currentForecast;
	            _scheduleReportBuilder.FilterSelection = _filter;
                e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Scheduled report";
                e.RequestedEntity = new ReportScreen(_scheduleReportBuilder);
            }
            else if (sender == itemPrintReportMaintenancePlan)
            {
                _maintenancePlanReportBulder = new MaintenancePlanReportBuilder(CurrentAircraft, _directivesViewer.GetItemsArray());
	            _maintenancePlanReportBulder.Forecast = _currentForecast;
				_maintenancePlanReportBulder.FilterSelection = _filter;
                e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Maintenance Plan report";
                e.RequestedEntity = new ReportScreen(_maintenancePlanReportBulder);
            }
            else if (sender == itemPrintReportEquipmentAndMaterials)
            {
                List<AbstractAccessory> aircraftKits =
                    _directivesViewer.GetItemsArray()
                    .Select(i => (i).Parent)
                    .Where(i => i is IKitRequired)
                    .SelectMany(i => ((IKitRequired)i).Kits)
                    .Cast<AbstractAccessory>()
                    .ToList();

                _forecastKitsReportBuilder = new ForecastKitsReportBuilder(CurrentAircraft, aircraftKits);
                _forecastKitsReportBuilder.Forecast = _currentForecast;
				_forecastKitsReportBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Equipment and Materials";
                e.RequestedEntity = new ReportScreen(_forecastKitsReportBuilder);
            }
			else if (sender == _itemPrintComponents)
			{
				var items = new List<IBaseEntityObject>();
				items.AddRange(_resultDirectiveArray.Where(i=>i.Parent is BaseComponent).Select(i => i.Parent).ToArray());
				items.AddRange(_resultDirectiveArray.Where(i => i.Parent is Component).Select(i => i.Parent).ToArray());
				items.AddRange(_resultDirectiveArray.Where(i => i.Parent is ComponentDirective).Select(i => i.Parent).ToArray());

				_componentsReportBulder = new ComponentsReportBuilder(_currentAircraft, items);
				_componentsReportBulder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Components Report";
				e.RequestedEntity = new ReportScreen(_componentsReportBulder);
			}
			else
            {
                e.Cancel = true;
            }

            //if (_directivesViewer.ItemListView.Items.Count == 0)
            //{
            //    MessageBox.Show("0 directives");
            //}
            //e.DisplayerText = "Forecast list Report";
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //e.RequestedEntity = new ReportScreen(new ForecastListReportBuilder(_currentAirFleetForecast[0].ForecastDatas[0]));
        }
        #endregion

        #region private void ForecastMenuClick(object sender, EventArgs e)
        private void ForecastMenuClick(object sender, EventArgs e)
        {
            CancelAsync();

			var form = new ForecastCustomsMTOP(CurrentAircraft, _currentForecast);

	        if (form.ShowDialog() == DialogResult.OK)
	        {
		        _reCalculateIds.Clear();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
		        AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
		        AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

		        AnimatedThreadWorker.RunWorkerAsync();
			}
        }
        #endregion

        #region private void FilterItems(IEnumerable<NextPerformance> initialCollection, ICommonCollection<NextPerformance> resultCollection)
        ///<summary>
        ///</summary>
        ///<param name="initialCollection"></param>
        ///<param name="resultCollection"></param>
        private void FilterItems(IEnumerable<NextPerformance> initialCollection, ICommonCollection<NextPerformance> resultCollection)
        {
            if (_filter == null || _filter.Count == 0)
            {
                resultCollection.Clear();
                resultCollection.AddRange(initialCollection);
                return;
            }

            resultCollection.Clear();

            foreach (NextPerformance pd in initialCollection)
            {
                //if (pd.Parent != null && pd.Parent is MaintenanceCheck && ((MaintenanceCheck)pd.Parent).Name == "C02")
                //{
                //    pd.ToString();
                //}
                if (_filter.FilterTypeAnd)
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _filter)
                    {
                        acceptable = filter.Acceptable(pd); if (!acceptable) break;
                    }
                    if (acceptable) resultCollection.Add(pd);
                }
                else
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _filter)
                    {
                        if (filter.Values == null || filter.Values.Length == 0)
                            continue;
                        acceptable = filter.Acceptable(pd); if (acceptable) break;
                    }
                    if (acceptable) resultCollection.Add(pd);
                }
            }
        }
		#endregion

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    e.DisplayerText =
			    $"{CurrentAircraft.RegistrationNumber} .Equipment and Materials";
		    e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft, _currentForecast);
	    }

		#endregion

		#region private void CalculateMaintenanceDirectives(List<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)

	    private void CalculateMaintenanceDirectives(List<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)
	    {
		    foreach (var mpd in maintenanceDirectives)
		    {

			    GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd);

			    if (bindedItemsDict.ContainsKey(mpd))
			    {
				    var bindedItems = bindedItemsDict[mpd];
				    foreach (var bindedItem in bindedItems)
				    {
					    if (bindedItem is ComponentDirective)
					    {
						    GlobalObjects.PerformanceCalculator.GetNextPerformance(bindedItem);

						    var firstNextPerformance =
							    bindedItemsDict[mpd].SelectMany(t => t.NextPerformances).OrderBy(n => n.NextPerformanceDate).FirstOrDefault();

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

	    #endregion

		#endregion
	}
}
