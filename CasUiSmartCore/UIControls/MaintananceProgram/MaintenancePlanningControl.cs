using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Analyst;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenancePlanningControl : UserControl, IReference
    {
        #region Fields
        
        private MaintenanceCheckCollection _checkItems;
        private Aircraft _currentAircraft;
        private List<NextPerformance> _itemsArray = new List<NextPerformance>();
        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
        private MaintenanceCheck _selectedCheck;
        private NextPerformance _selectedPerformance;

        private Forecast _currentForecast;

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripMenuItem _createWorkPakageToolStripMenuItem;
        private ToolStripMenuItem _createQuotationOrderStripMenuItem;
        private ToolStripMenuItem _toolStripMenuItemShowTaskCard;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;
        private ToolStripMenuItem _toolStripMenuItemQuotations;

        #endregion

        #region Properties
        /// <summary>
        /// Чеки программы обслуживания, для которых будет строится планирование
        /// </summary>
        public MaintenanceCheckCollection CheckItems
        {
            get { return _checkItems; }
            set
            {
                if (_checkItems != null && _checkItems != value)
                {
                    _checkItems.CollectionChanged -= ItemsCollectionChanged;
                    foreach (MaintenanceCheck checkItem in _checkItems)
                    {
                        checkItem.PropertyChanged -= ItemPropertyChanged;
                    }
                }
                if (_checkItems != value)
                {
                    _checkItems = value;

                    if (_checkItems != null)
                    {
                        _checkItems.CollectionChanged += ItemsCollectionChanged;
                        foreach (MaintenanceCheck liminationItem in value)
                        {
                            liminationItem.PropertyChanged += ItemPropertyChanged;
                        }
                    }
                }
            }
        }

        #endregion

        #region Implementation of IReference

        private IDisplayer _displayer;

        #region public IDisplayer Displayer
        public IDisplayer Displayer
        {
            get { return _displayer; }
            set
            {
                _displayer = value;
            }
        }
        #endregion

        #region public string DisplayerText { get; set; }

        public string DisplayerText { get; set; }
        #endregion

        #region public IDisplayingEntity Entity{ get; set;}
        public IDisplayingEntity Entity { get; set; }
        #endregion

        #region public ReflectionTypes ReflectionType{ get; set; }

        public ReflectionTypes ReflectionType { get; set; }
        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        ///<summary>
        ///</summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #region private void InvokeDisplayerRequested(ReferenceEventArgs e)
        ///<summary>
        /// Запускает событие об создании новой вкладки
        ///</summary>
        ///<param name="e">экран и параметры новой вкладки</param>
        private void InvokeDisplayerRequested(ReferenceEventArgs e)
        {
            EventHandler<ReferenceEventArgs> handler = DisplayerRequested;
            if (handler != null) handler(this, e);
        }
        #endregion

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public MaintenancePlanningControl()
        {
            InitializeComponent();

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerRunWorkerCompleted;
        }
        #endregion

        #region Metods

        #region protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (_contextMenuStrip == null)
            {
                InitToolStripMenuItems();
                directivesViewer.ContextMenuStrip = _contextMenuStrip;
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
                    ToolStripMenuItem item = new ToolStripMenuItem($"{workPackage.Title} {workPackage.Number}");
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = workPackage;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
                }
            }

            directivesViewer.SetItemsArray(_itemsArray.ToArray());


            //headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
        }
        #endregion

        #region protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "load directives");

            #region Загрузка элементов
            _itemsArray.Clear();
            List<IDirective> directives = new List<IDirective>();

            _animatedThreadWorker.ReportProgress(0, "calculation of Maintenance checks");
            GlobalObjects.AnalystCore.GetMaintenanceCheck(_currentForecast);
            directives.AddRange(_currentForecast.MaintenanceChecks.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }


            _animatedThreadWorker.ReportProgress(8, "calculation of Base details");
            GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectives(_currentForecast);
            directives.AddRange(_currentForecast.BaseComponents.ToArray());
            directives.AddRange(_currentForecast.BaseComponentDirectives.ToArray());
            
            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }                    
            
            _animatedThreadWorker.ReportProgress(16, "calculation of Components");
            GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(_currentForecast);
            directives.AddRange(_currentForecast.Components.ToArray());
            directives.AddRange(_currentForecast.ComponentDirectives.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(25, "calculation of Airworthiness directives");
            GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.AirworthenessDirectives);
            directives.AddRange(_currentForecast.AdStatus.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(41, "calculation of Damages");
            GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.DamagesRequiring);
            directives.AddRange(_currentForecast.Damages.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(49, "calculation of Deffereds");
            GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.DeferredItems);
            directives.AddRange(_currentForecast.DefferedItems.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(57, "calculation of Engineering orders");
            GlobalObjects.AnalystCore.GetEngineeringOrders(_currentForecast);
            directives.AddRange(_currentForecast.EngineeringOrders.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(65, "calculation of Service bulletins");
            GlobalObjects.AnalystCore.GetServiceBulletins(_currentForecast);
            directives.AddRange(_currentForecast.ServiceBulletins.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(74, "calculation of Out of phase");
            GlobalObjects.AnalystCore.GetDirectives(_currentForecast, DirectiveType.OutOfPhase);
            directives.AddRange(_currentForecast.OutOfPhaseItems.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(82, "calculation of Maintenance Directives");
            GlobalObjects.AnalystCore.GetMaintenanceDirectives(_currentForecast);
            directives.AddRange(_currentForecast.MaintenanceDirectives.ToArray());

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            } 
            #endregion

            #region загрузка рабочих пакетов

            _animatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");
                  
            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            if(_openPubWorkPackages == null)
                _openPubWorkPackages = new CommonCollection<WorkPackage>();
            _openPubWorkPackages.Clear();
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(_currentAircraft, WorkPackageStatus.Opened, true));
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(_currentAircraft, WorkPackageStatus.Published, true));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
            foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
                openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

            if(radioButtonByPeriod.Checked)
            {
                foreach (IDirective dir in directives)
                {
                    if (dir is MaintenanceCheck && ((MaintenanceCheck)dir).Grouping)
                    {
                        MaintenanceCheck mc = (MaintenanceCheck)dir;

                        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                        //для поиска перекрывающихся выполнений
                        List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
                        foreach (MaintenanceNextPerformance mnp in performances)
                        {
                            //поиск записи в рабочих пакетах по данному чеку
                            //чей номер группы выполнения (по записи) совпадает с расчитанным
                            WorkPackageRecord wpr =
                                openWPRecords.Where(r => r.PerformanceNumFromStart == mnp.PerformanceGroupNum &&
                                                         r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
                                                         r.DirectiveId == mc.ItemId).FirstOrDefault();
                            if (wpr != null)
                                mnp.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
                            _itemsArray.Add(mnp);
                        }
                    }
                    else
                    {
                        if (dir.NextPerformances.Count <= 0)
                            continue;
                        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                        //для поиска перекрывающихся выполнений
                        List<NextPerformance> performances = dir.NextPerformances;
                        foreach (NextPerformance np in performances)
                        {
                            //поиск записи в рабочих пакетах по данному чеку
                            //чей номер группы выполнения (по записи) совпадает с расчитанным
                            WorkPackageRecord wpr =
                                openWPRecords.Where(r => r.PerformanceNumFromStart == np.PerformanceNum &&
                                                         r.WorkPackageItemType == dir.SmartCoreObjectType.ItemId &&
                                                         r.DirectiveId == dir.ItemId).FirstOrDefault();
                            if (wpr != null)
                                np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
                            //Производится поиск ближайшего выполнения данной задачи к выбранному чеку
                            _itemsArray.Add(np);
                        }
                    }
                }   
            }
            else
            {
                foreach (IDirective dir in directives)
                {
                    NextPerformance nearest = null;
                    double currentOffset = 0;
                    if (dir is MaintenanceCheck && ((MaintenanceCheck)dir).Grouping)
                    {
                        MaintenanceCheck mc = (MaintenanceCheck)dir;

                        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                        //для поиска перекрывающихся выполнений
                        List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
                        foreach (MaintenanceNextPerformance mnp in performances)
                        {
                            //поиск записи в рабочих пакетах по данному чеку
                            //чей номер группы выполнения (по записи) совпадает с расчитанным
                            WorkPackageRecord wpr =
                                openWPRecords.Where(r => r.PerformanceNumFromStart == mnp.PerformanceGroupNum &&
                                                         r.WorkPackageItemType == mc.SmartCoreObjectType.ItemId &&
                                                         r.DirectiveId == mc.ItemId).FirstOrDefault();
                            if (wpr != null)
                                mnp.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
                            //Производится поиск ближайшего выполнения данной задачи к выбранному чеку
                            if (nearest == null)
                            {
                                nearest = mnp;
                                //Расчитывается текущий отступ между тек. ближайшим выполнением 
                                //и датой выполнения выбранного чека
                                currentOffset =
                                    Math.Abs((Convert.ToDateTime(nearest.PerformanceDate).Date -
                                              Convert.ToDateTime(_selectedPerformance.PerformanceDate).Date).TotalDays);
                            }
                            else
                            {
                                //Расчитывается отступ между кандидатом на ближайшее выполнение
                                //и датой выполнения выбранного чека
                                double newOffset =
                                    Math.Abs((Convert.ToDateTime(mnp.PerformanceDate).Date -
                                              Convert.ToDateTime(_selectedPerformance.PerformanceDate).Date).TotalDays);
                                //Если у кандидата отступ меньше чем у тек. ближайшего выполнения
                                //то кандидат становится ближайшим выполнением
                                if (newOffset < currentOffset)
                                {
                                    nearest = mnp;
                                    //Расчитывается текущий отступ между тек. ближайшим выполнением 
                                    //и датой выполнения выбранного чека
                                    currentOffset = newOffset;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dir.NextPerformances.Count <= 0)
                            continue;
                        //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                        //для поиска перекрывающихся выполнений
                        List<NextPerformance> performances = dir.NextPerformances;
                        foreach (NextPerformance np in performances)
                        {
                            //поиск записи в рабочих пакетах по данному чеку
                            //чей номер группы выполнения (по записи) совпадает с расчитанным
                            WorkPackageRecord wpr =
                                openWPRecords.Where(r => r.PerformanceNumFromStart == np.PerformanceNum &&
                                                         r.WorkPackageItemType == dir.SmartCoreObjectType.ItemId &&
                                                         r.DirectiveId == dir.ItemId).FirstOrDefault();
                            if (wpr != null)
                                np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
                            //Производится поиск ближайшего выполнения данной задачи к выбранному чеку
                            if (nearest == null)
                            {
                                nearest = np;
                                //Расчитывается текущий отступ между тек. ближайшим выполнением 
                                //и датой выполнения выбранного чека
                                currentOffset =
                                    Math.Abs((Convert.ToDateTime(nearest.PerformanceDate).Date -
                                              Convert.ToDateTime(_selectedPerformance.PerformanceDate).Date).TotalDays);
                            }
                            else
                            {
                                //Расчитывается отступ между кандидатом на ближайшее выполнение
                                //и датой выполнения выбранного чека
                                double newOffset =
                                    Math.Abs((Convert.ToDateTime(np.PerformanceDate).Date -
                                              Convert.ToDateTime(_selectedPerformance.PerformanceDate).Date).TotalDays);
                                //Если у кандидата отступ меньше чем у тек. ближайшего выполнения
                                //то кандидат становится ближайшим выполнением
                                if (newOffset < currentOffset)
                                {
                                    nearest = np;
                                    //Расчитывается текущий отступ между тек. ближайшим выполнением 
                                    //и датой выполнения выбранного чека
                                    currentOffset = newOffset;
                                }
                            }
                        }
                    }

                    //Если ближайшее выполнение определено, то оно добавляется в коллекцию
                    if (nearest != null)
                    {
                        _itemsArray.Add(nearest);
                    }
                }
            }
            
            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            #endregion

            #region Загрузка Котировочных ордеров

            _animatedThreadWorker.ReportProgress(95, "Load Quotations");

            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

            _openPubQuotations.Clear();
            _openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(_currentAircraft, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            _animatedThreadWorker.ReportProgress(100, "calculation over");

            //Очистка ресурсов

            _animatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region public void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        public void CancelAsync()
        {
            if (_animatedThreadWorker.IsBusy)
                _animatedThreadWorker.CancelAsync();
        }
        #endregion

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            comboBoxCheck.Items.Clear();
            
            comboBoxByDate.DataSource = null;
            comboBoxByDate.Items.Clear();
            if (_currentForecast != null) 
                _currentForecast.Dispose();
            _currentForecast = new Forecast { Aircraft = _currentAircraft };

            if (_checkItems == null || _checkItems.Count <= 0) return;
            //чеки IsDeleted свойство которых равно false
            MaintenanceCheck[] validChecks = _checkItems.GroupingCheckByType(_currentAircraft.Schedule)
                .SelectMany(gc => gc.ToArray())
                .SelectMany(gbt => gbt.Checks)
                .ToArray();
            //След. выполнения чеков
            List<NextPerformance> nextPerformances = new List<NextPerformance>();
            foreach (MaintenanceCheck validCheck in validChecks)
            {
                if(validCheck.Grouping)
                    nextPerformances.AddRange(validCheck.GetPergormanceGroupWhereCheckIsSenior().ToArray()); 
                else nextPerformances.AddRange(validCheck.NextPerformances);
            }
            //Выполнения, сгруппированные по дате
            IEnumerable<IGrouping<DateTime, NextPerformance>> groupByDate =
                nextPerformances.Where(p => p.PerformanceDate != null)
                                .GroupBy(p => Convert.ToDateTime(p.PerformanceDate).Date)
                                .OrderBy(g => g.Key);
            //Строковое представление сгруппированных чеков
            List<KeyValuePair<string, NextPerformance>> strings = new List<KeyValuePair<string, NextPerformance>>();
            foreach (IGrouping<DateTime, NextPerformance> grouping in groupByDate)
            {
                IEnumerable<MaintenanceCheck> mcs = grouping.Select(g => g.Parent as MaintenanceCheck);
                MaintenanceCheck max = mcs.GetMaxCheck();
                if(max == null)
                    continue;
                string result = SmartCore.Auxiliary.Convert.GetDateFormat(grouping.Key) + " ( ";

                //Добавление в название присутствующих на данную дату чеков программы обслуживания
                IEnumerable<NextPerformance> maintenanceCheckPerformances =
                    grouping.Where(np => np.Parent is MaintenanceCheck);
                foreach (NextPerformance maintenanceCheckPerformance in maintenanceCheckPerformances)
                {
                    if (maintenanceCheckPerformance is MaintenanceNextPerformance)
                    {
                        MaintenanceNextPerformance maintenancePerformance = maintenanceCheckPerformance as MaintenanceNextPerformance;
                        if (maintenancePerformance.PerformanceGroup != null)
                            result += maintenancePerformance.PerformanceGroup.GetGroupName() + " ";
                        else if (maintenanceCheckPerformance.Parent is MaintenanceCheck)
                            result += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name + " ";
                    }
                    else if (maintenanceCheckPerformance.Parent is MaintenanceCheck)
                        result += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name + " ";
                }

                //Добавление в название присутствующих на данную дату директив летной годности
                IEnumerable<NextPerformance> adPerformances = grouping.Where(np => np.Parent is Directive);
                if (adPerformances.Any())
                    result += "AD ";

                //Добавление в название присутствующих на данную дату компонентов или задач по ним
                IEnumerable<NextPerformance> componentPerformances =
                    grouping.Where(np => np.Parent != null && (np.Parent is Component || np.Parent is ComponentDirective));
                if (componentPerformances.Any())
                    result += "Comp ";

                //Добавление в название присутствующих на данную дату MPD
                IEnumerable<NextPerformance> mpdPerformances =
                    grouping.Where(np => np.Parent is MaintenanceDirective);
                if (maintenanceCheckPerformances.Count() == 0 && mpdPerformances.Count() > 0)
                    result += "MPD ";

                result += ")";
                strings.Add(new KeyValuePair<string, NextPerformance>( result, max.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null && p.PerformanceDate.Value.Date == grouping.Key)));        
            }

            comboBoxByDate.DisplayMember = "Key";
            comboBoxByDate.ValueMember = "Value";
            comboBoxByDate.DataSource = strings;

            comboBoxCheck.Items.AddRange(validChecks);
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today.AddDays(1);

            MaintenanceCheck mc =
                _checkItems.Where(c => c.CheckType.Priority > 0)
                           .SelectMany(c => c.GetPergormanceGroupWhereCheckIsSenior())
                           .Where(p => p.PerformanceDate != null && p.Parent is MaintenanceCheck)
                           .OrderBy(p => p.PerformanceDate)
                           .Select(p => p.Parent)
                           .Cast<MaintenanceCheck>()
                           .FirstOrDefault();
            comboBoxCheck.SelectedItem = mc ?? _checkItems[0];

            mc = (MaintenanceCheck)comboBoxCheck.SelectedItem;
            NextPerformance mnp = comboBoxPerformance.SelectedItem as NextPerformance;
            double approvals = (double)(numericUpDownApprovals.Value / 100);
            if (comboBoxCheck.SelectedItem != null && mnp != null)
            {
                MaintenanceCheck minCheckSameType =
                    _checkItems.GetMinStepCheck(mc.Schedule, mc.Grouping,
                                                mc.Resource, mc.CheckType);
                List<BaseComponent> aircraftBaseDetails = null;
                if (_currentAircraft != null)
                {
                    //поиск деталей данного самолета 
                    aircraftBaseDetails = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId));
                    //очистка массива данных по прогнозам
                    if (aircraftBaseDetails.Count != 0) _currentForecast.ForecastDatas.Clear();
                }
                else _currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

                if (aircraftBaseDetails != null)
                {
                    //составление нового массива данных по прогнозам
                    foreach (BaseComponent baseDetail in aircraftBaseDetails)
                    {
                        Lifelength current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail);
                        Lifelength performance = new Lifelength(mnp.PerformanceSource) +
                            (minCheckSameType != null ? minCheckSameType.Interval * approvals : mc.Interval * approvals);
                        Lifelength lowerLimit = new Lifelength(mnp.PerformanceSource) -
                            (minCheckSameType != null ? minCheckSameType.Interval * approvals : mc.Interval * approvals);
                        Lifelength offset = performance - current;
                        Lifelength lowerOffset = lowerLimit - current;
                        offset.Resemble(mc.Interval);
                        lowerOffset.Resemble(mc.Interval);

                        Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, baseDetail.AverageUtilization));
                        Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, baseDetail.AverageUtilization));
                        //определение ресурсов прогноза для каждой базовой детали
                        ForecastData forecastData =
                            new ForecastData(DateTime.Today.AddDays(approxDays),
                                             baseDetail,
                                             GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail),
                                             DateTime.Today.AddDays(approxDaysToLower));
                        //дабавление в массив
                        _currentForecast.ForecastDatas.Add(forecastData);
                    }
                }
                _animatedThreadWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region public void Reload(MaintenanceCheckCollection liminationItems, Aircraft currentAircraft)

        /// <summary>
        /// Перезагружает данные с БД
        /// </summary>
        public void Reload(MaintenanceCheckCollection liminationItems, Aircraft currentAircraft)
        {
            CheckItems = liminationItems;
            _currentAircraft = currentAircraft;
            UpdateInformation();
        }

        #endregion

        #region private void ComboBoxCheckSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxCheckSelectedIndexChanged(object sender, EventArgs e)
        {
            //Очистка комбобокса с выполнениями чека
            comboBoxPerformance.Items.Clear();
            comboBoxPerformance.SelectedItem = null;

            MaintenanceCheck mc = comboBoxCheck.SelectedItem as MaintenanceCheck;
            if (mc != null)
            {
                if (mc.Grouping)
                {
                    //Заполнение комбобокса с выполнениями чека
                    //"след. выполнениями" где чека является старшим
                    comboBoxPerformance.Items.AddRange(mc.GetPergormanceGroupWhereCheckIsSenior().ToArray());
                    //comboBoxPerformance.SelectedItem = mc.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault();
                }
                else
                {
                    comboBoxPerformance.Items.AddRange(mc.NextPerformances.ToArray());
                    //comboBoxPerformance.SelectedItem = mc.NextPerformances.FirstOrDefault();
                }
            }
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (radioButtonByPerformance.Checked)
            {
                _selectedCheck = comboBoxCheck.SelectedItem as MaintenanceCheck;
                _selectedPerformance = comboBoxPerformance.SelectedItem as NextPerformance;

                if (_selectedCheck == null)
                {
                    MessageBox.Show("Not Select Maintenance Check", (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxCheck.Focus();
                    return;
                }

                if (_selectedPerformance == null)
                {
                    MessageBox.Show("Not Select Performance", (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxPerformance.Focus();
                    return;
                }

                double approvals = (double)(numericUpDownApprovals.Value / 100);
                MaintenanceCheck minCheckSameType =
                    _checkItems.GetMinStepCheck(_selectedCheck.Schedule, _selectedCheck.Grouping,
                                                _selectedCheck.Resource, _selectedCheck.CheckType);
                List<BaseComponent> aircraftBaseDetails = null;
                if (_currentAircraft != null)
                {
                    //поиск деталей данного самолета 
                    aircraftBaseDetails = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId));
                    //очистка массива данных по прогнозам
                    if (aircraftBaseDetails.Count != 0) _currentForecast.ForecastDatas.Clear();
                }
                else _currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

                if (aircraftBaseDetails != null)
                {
                    //составление нового массива данных по прогнозам
                    foreach (BaseComponent baseDetail in aircraftBaseDetails)
                    {
                        Lifelength current = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(baseDetail);
                        Lifelength performance = new Lifelength(_selectedPerformance.PerformanceSource) +
                                (minCheckSameType != null ? minCheckSameType.Interval * approvals : _selectedCheck.Interval * approvals);
                        Lifelength lowerLimit = new Lifelength(_selectedPerformance.PerformanceSource) -
                                (minCheckSameType != null ? minCheckSameType.Interval * approvals : _selectedCheck.Interval * approvals);
                        Lifelength offset = performance - current;
                        Lifelength lowerOffset = lowerLimit - current;
                        offset.Resemble(_selectedCheck.Interval);
                        lowerOffset.Resemble(_selectedCheck.Interval);

                        Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, baseDetail.AverageUtilization));
                        Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, baseDetail.AverageUtilization));
                        //определение ресурсов прогноза для каждой базовой детали
                        ForecastData forecastData =
                            new ForecastData(DateTime.Today.AddDays(approxDays),
                                             baseDetail,
                                             current,
                                             DateTime.Today.AddDays(approxDaysToLower));
                        //дабавление в массив
                        _currentForecast.ForecastDatas.Add(forecastData);
                    }
                }

                _animatedThreadWorker.RunWorkerAsync();
            }
            if(radioButtonByDate.Checked)
            {
                _selectedPerformance = comboBoxByDate.SelectedValue as NextPerformance;

                if (_selectedPerformance == null)
                {
                    MessageBox.Show("Not Select Performance", (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxByDate.Focus();
                    return;
                }

                _selectedCheck = _selectedPerformance.Parent as MaintenanceCheck;

                if (_selectedCheck == null)
                {
                    MessageBox.Show("Not Select Maintenance Check", (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxByDate.Focus();
                    return;
                }

                double approvals = (double)(numericUpDownApprovals.Value / 100);
                MaintenanceCheck minCheckSameType =
                    _checkItems.GetMinStepCheck(_selectedCheck.Schedule, _selectedCheck.Grouping,
                                                _selectedCheck.Resource, _selectedCheck.CheckType);
                List<BaseComponent> aircraftBaseDetails = null;
                if (_currentAircraft != null)
                {
                    //поиск деталей данного самолета 
                    aircraftBaseDetails = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId));
                    //очистка массива данных по прогнозам
                    if (aircraftBaseDetails.Count != 0) _currentForecast.ForecastDatas.Clear();
                }
                else _currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

                if (aircraftBaseDetails != null)
                {
                    //составление нового массива данных по прогнозам
                    foreach (BaseComponent baseDetail in aircraftBaseDetails)
                    {
                        Lifelength current = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(baseDetail);
                        Lifelength performance = new Lifelength(_selectedPerformance.PerformanceSource) +
                                (minCheckSameType != null ? minCheckSameType.Interval * approvals : _selectedCheck.Interval * approvals);
                        Lifelength lowerLimit = new Lifelength(_selectedPerformance.PerformanceSource) -
                                (minCheckSameType != null ? minCheckSameType.Interval * approvals : _selectedCheck.Interval * approvals);
                        Lifelength offset = performance - current;
                        Lifelength lowerOffset = lowerLimit - current;
                        offset.Resemble(_selectedCheck.Interval);
                        lowerOffset.Resemble(_selectedCheck.Interval);

                        Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, baseDetail.AverageUtilization));
                        Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, baseDetail.AverageUtilization));
                        //определение ресурсов прогноза для каждой базовой детали
                        ForecastData forecastData =
                            new ForecastData(DateTime.Today.AddDays(approxDays),
                                             baseDetail,
                                             current,
                                             DateTime.Today.AddDays(approxDaysToLower));
                        //дабавление в массив
                        _currentForecast.ForecastDatas.Add(forecastData);
                    }
                }
                _animatedThreadWorker.RunWorkerAsync();
            }

            if(radioButtonByPeriod.Checked)
            {
                List<BaseComponent> aircraftBaseDetails = null;
                if (_currentAircraft != null)
                {
                    //поиск деталей данного самолета 
                    aircraftBaseDetails = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId));
                    //очистка массива данных по прогнозам
                    if (aircraftBaseDetails.Count != 0) _currentForecast.ForecastDatas.Clear();
                }
                else _currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

                if (aircraftBaseDetails != null)
                {
                    //составление нового массива данных по прогнозам
                    foreach (BaseComponent baseDetail in aircraftBaseDetails)
                    {
                        //определение ресурсов прогноза для каждой базовой детали
                        ForecastData forecastData =
                            new ForecastData(dateTimePickerTo.Value,
                                             baseDetail,
                                             GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail),
                                             dateTimePickerFrom.Value);
                        //дабавление в массив
                        _currentForecast.ForecastDatas.Add(forecastData);
                    }
                }
                _animatedThreadWorker.RunWorkerAsync();    
            }
        }
        #endregion

        #region Изменение коллекции директив

        #region private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e == null)
                return;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (MaintenanceCheck newItem in e.NewItems)
                {
                    newItem.PropertyChanged += ItemPropertyChanged;
                    AddItem(newItem);
                }
            }
            else
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (MaintenanceCheck oldItem in e.OldItems)
                    {
                        oldItem.PropertyChanged -= ItemPropertyChanged;
                        RemoveItem(oldItem);
                    }
                }
        }
        #endregion

        #region private void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        private void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                return;
            }
        }
        #endregion

        #region private void AddItem(MaintenanceCheck item)
        private void AddItem(MaintenanceCheck item)
        {
            if (item.IsDeleted == false)
            {
                comboBoxCheck.Items.Add(item);
            }
        }
        #endregion

        #region private void RemoveItem(MaintenanceCheck item)
        private void RemoveItem(MaintenanceCheck item)
        {
            comboBoxCheck.Items.Remove(item);
        }
        #endregion

        #endregion

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _createWorkPakageToolStripMenuItem = new ToolStripMenuItem();
            _createQuotationOrderStripMenuItem = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripMenuItemShowTaskCard = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";

            _createWorkPakageToolStripMenuItem.Text = "Create WorkPakage";
            _createWorkPakageToolStripMenuItem.Click += ButtonCreateWorkPakageClick;
            //
            // _toolStripMenuItemsWorkPackages
            //
            _toolStripMenuItemsWorkPackages.Text = "Add to Work package";
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
                                                    _createWorkPakageToolStripMenuItem,
                                                    _toolStripMenuItemsWorkPackages,
                                                    _toolStripSeparator1,
                                                    _createQuotationOrderStripMenuItem,
                                                    _toolStripMenuItemQuotations
                                                });
        }
        #endregion

        #region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
        /// <summary>
        /// Проверка на выделение 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripOpen(object sender, CancelEventArgs e)
        {
            if (directivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
            if (directivesViewer.SelectedItems.Count == 1)
            {
                _createWorkPakageToolStripMenuItem.Enabled = true;

                BaseEntityObject o = directivesViewer.SelectedItems[0];
                IBaseEntityObject parent;
                if (o is NextPerformance)
                {
                    parent = ((NextPerformance)o).Parent;
                }
                else if (o is AbstractPerformanceRecord)
                {
                    parent = ((AbstractPerformanceRecord)o).Parent;
                }
                else parent = o;

                if (parent is Directive)
                {
                    Directive dir = (Directive)parent;
                    _toolStripMenuItemShowTaskCard.Enabled = dir.EngineeringOrderFile != null;  
                }
                else if (parent is BaseComponent)
                {
                    _toolStripMenuItemShowTaskCard.Enabled = false; 
                }
                else if (parent is Component)
                {
                    _toolStripMenuItemShowTaskCard.Enabled = false; 
                }
                else if (parent is ComponentDirective)
                {
                    ComponentDirective dir = (ComponentDirective)parent;
                    _toolStripMenuItemShowTaskCard.Enabled = dir.FaaFormFile != null; 
                }
                else if (parent is MaintenanceCheck)
                {
                    _toolStripMenuItemShowTaskCard.Enabled = false; 
                }
                else if (parent is MaintenanceDirective)
                {
                    MaintenanceDirective mpd = (MaintenanceDirective)parent;
                    _toolStripMenuItemShowTaskCard.Enabled = mpd.TaskCardNumberFile != null;
                }
                else if (parent is NonRoutineJob)
                {
                    NonRoutineJob dir = (NonRoutineJob)parent;
                    _toolStripMenuItemShowTaskCard.Enabled = dir.AttachedFile != null;  
                }
            }
            _createQuotationOrderStripMenuItem.Enabled = true;
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
            PurchaseManager.ComposeQuotationOrder(directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), _currentAircraft, this);   
        }

        #endregion

        #region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

        private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

        private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
        {
            if (directivesViewer.SelectedItems == null ||
                directivesViewer.SelectedItems.Count == 0) return;

            BaseEntityObject o = directivesViewer.SelectedItems[0];
            AttachedFile file = null;
            IBaseEntityObject parent;
            if (o is NextPerformance)
            {
                parent = ((NextPerformance)o).Parent;
            }
            else if (o is AbstractPerformanceRecord)
            {
                parent = ((AbstractPerformanceRecord)o).Parent;
            }
            else parent = o;

            if (parent is Directive)
            {
                var dir = (Directive)parent;
                if (dir.EngineeringOrderFile != null && dir.EngineeringOrderFile.FileData == null)
					dir.EngineeringOrderFile = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<EFCore.DTO.General.AttachedFileDTO, AttachedFile>(dir.EngineeringOrderFile.ItemId, true);
				file = dir.EngineeringOrderFile;
            }
            else if (parent is BaseComponent)
            {
                file = null;
            }
            else if (parent is Component)
            {
                file = null;
            }
            else if (parent is ComponentDirective)
            {
                ComponentDirective dir = (ComponentDirective)parent;
                file = dir.FaaFormFile;
            }
            else if (parent is MaintenanceCheck)
            {
                file = null;
            }
            else if (parent is MaintenanceDirective)
            {
                MaintenanceDirective mpd = (MaintenanceDirective)parent;
                file = mpd.TaskCardNumberFile;
            }
            else if (parent is NonRoutineJob)
            {
                NonRoutineJob dir = (NonRoutineJob)parent;
                file = dir.AttachedFile;
            }

            if (file == null)
            {
                MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                string message;
                GlobalObjects.CasEnvironment.OpenFile(file, out message);
                if (message != "")
                {
                    MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch (Exception ex)
            {
                string errorDescriptionSctring =
                   string.Format("Error while Open Attached File for {0}, \nid {1} \nType {2}. \nFileId {3}", 
                                  parent, 
                                  parent.ItemId, 
                                  parent.SmartCoreObjectType, 
                                  file.ItemId);

                Program.Provider.Logger.Log("Error while Open Attached File", ex);
            }
        }

        #endregion

        #region private void HighlightItemClick(object sender, EventArgs e)

        private void HighlightItemClick(object sender, EventArgs e)
        {
            Highlight highLight = (Highlight)((ToolStripMenuItem)sender).Tag;
            for (int i = 0; i < directivesViewer.SelectedItems.Count; i++)
            {
                directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
            }
        }

        #endregion

        #region private void ButtonCreateWorkPakageClick(object sender, EventArgs e)

        private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
        {
            if (directivesViewer.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("Create and save a Work Package?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<NextPerformance> wpItems = new List<NextPerformance>();
                foreach (BaseEntityObject o in directivesViewer.SelectedItems)
                {
                    if (o is IDirective
                        && ((IDirective)o).NextPerformances != null
                        && ((IDirective)o).NextPerformances.Count > 0)
                    {
                        wpItems.Add(((IDirective) o).NextPerformances[0]);
                    }

                    if(o is NextPerformance)
                    {
                        wpItems.Add((NextPerformance)o);
                    }
                }

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
                    WorkPackage wp =
                        GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, _currentAircraft, out message);
                    if (wp == null)
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
                    _openPubWorkPackages.Add(wp);
                    //Создание пункта в меню открытых рабочих пакетов
                    ToolStripMenuItem item = new ToolStripMenuItem(wp.Title);
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = wp;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);

                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        directivesViewer.UpdateItemColor(nextPerformance);
                    }
                    ReferenceEventArgs refArgs = new ReferenceEventArgs();
                    refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    refArgs.DisplayerText = _currentAircraft != null ? _currentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
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
            if (directivesViewer.SelectedItems.Count <= 0) return;

            WorkPackage wp = (WorkPackage)((ToolStripMenuItem)sender).Tag;

            if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                List<NextPerformance> wpItems = new List<NextPerformance>();
                foreach (BaseEntityObject o in directivesViewer.SelectedItems)
                {
                    if (o is IDirective
                        && ((IDirective)o).NextPerformances != null
                        && ((IDirective)o).NextPerformances.Count > 0)
                    {
                        wpItems.Add(((IDirective)o).NextPerformances[0]);
                    }

                    if (o is NextPerformance)
                    {
                        wpItems.Add((NextPerformance)o);
                    }
                }

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

                    if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, _currentAircraft, out message))
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        directivesViewer.UpdateItemColor(nextPerformance);
                    }

                    if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        ReferenceEventArgs refArgs = new ReferenceEventArgs();
                        refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        refArgs.DisplayerText = _currentAircraft != null ? _currentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
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

        #region private void RadioButtonCheckedChanged(object sender, EventArgs e)

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == null)
                return;

            radioButtonByPerformance.CheckedChanged -= RadioButtonCheckedChanged;
            radioButtonByDate.CheckedChanged -= RadioButtonCheckedChanged;
            radioButtonByPeriod.CheckedChanged -= RadioButtonCheckedChanged;

            if (radioButtonByPerformance == rb && radioButtonByPerformance.Checked)
            {
                radioButtonByDate.Checked = 
                    comboBoxByDate.Enabled = 
                    radioButtonByPeriod.Checked = 
                    dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = false;

                comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled =
                    numericUpDownApprovals.Enabled = true;
            }
            if (radioButtonByDate == rb && radioButtonByDate.Checked)
            {
                radioButtonByPerformance.Checked =
                    comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled = 
                    radioButtonByPeriod.Checked =
                    dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = false;

                comboBoxByDate.Enabled =
                    numericUpDownApprovals.Enabled = true;
            }
            if (radioButtonByPeriod == rb && radioButtonByPeriod.Checked)
            {
                radioButtonByPerformance.Checked =
                    comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled =
                    radioButtonByDate.Checked =
                    comboBoxByDate.Enabled = 
                    numericUpDownApprovals.Enabled = false;

                dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = true;
            }
            
            radioButtonByPerformance.CheckedChanged += RadioButtonCheckedChanged;
            radioButtonByDate.CheckedChanged += RadioButtonCheckedChanged;
            radioButtonByPeriod.CheckedChanged += RadioButtonCheckedChanged;
        }
        #endregion

        #region private void DateTimePickerValueChanged(object sender, EventArgs e)

        private void DateTimePickerValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            if(dtp == null)
                return;

            dateTimePickerFrom.ValueChanged -= DateTimePickerValueChanged;
            dateTimePickerTo.ValueChanged -= DateTimePickerValueChanged;

            if(dateTimePickerFrom == dtp)
            {
                if (dateTimePickerFrom.Value < _currentAircraft.ManufactureDate)
                    dateTimePickerFrom.Value = _currentAircraft.ManufactureDate;
                if (dateTimePickerFrom.Value >= dateTimePickerTo.Value)
                    dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
            }
            if(dateTimePickerTo == dtp)
            {
                if (dateTimePickerTo.Value < _currentAircraft.ManufactureDate)
                    dateTimePickerTo.Value = _currentAircraft.ManufactureDate.AddDays(1);
                if (dateTimePickerTo.Value <= dateTimePickerFrom.Value)
                    dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);   
            }

            dateTimePickerFrom.ValueChanged += DateTimePickerValueChanged;
            dateTimePickerTo.ValueChanged += DateTimePickerValueChanged;
        }

        #endregion

        #endregion
    }
}
