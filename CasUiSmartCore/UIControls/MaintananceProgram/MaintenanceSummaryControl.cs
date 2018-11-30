using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Convert = System.Convert;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceSummaryControl : UserControl
    {
        #region Fields

        private MaintenanceCheckCollection _checkItems;
        private IEnumerable<MaintenanceCheckComplianceGroup> _complianceGroupCollection;

        #endregion
        
        #region Properties

        #region public MaintenanceCheckCollection CheckItems
        /// <summary>
        /// Current CheckItems
        /// </summary> 
        public MaintenanceCheckCollection CheckItems
        {
            get { return _checkItems; }
            set
            {
                if (_checkItems != null && _checkItems != value)
                {
                    _checkItems.CollectionChanged -= CheckItemsCollectionChanged;
                    foreach (MaintenanceCheck checkItem in _checkItems)
                    {
                        checkItem.PropertyChanged -= CheckItemPropertyChanged;    
                    }
                }
                if (_checkItems != value)
                {
                    _checkItems = value;
                    if(_checkItems != null)
                    {
                        _checkItems.CollectionChanged += CheckItemsCollectionChanged;
                        foreach (MaintenanceCheck liminationItem in value)
                        {
                            liminationItem.PropertyChanged += CheckItemPropertyChanged;
                        }    
                    }
                }
            }
        }
        #endregion

        #region private Lifelength TsnCsn { get; set; }
        private Lifelength TsnCsn { get; set; }
        #endregion

        #region private BackgroundWorker BW
        private BackgroundWorker BackGroundWorker = new BackgroundWorker();
        #endregion

        #region private Dictionary<string, string> BT { get; set; }
        /// <summary>
        /// хранит текст полученный в другом потоке
        /// </summary>
        private Dictionary<string, string> BT { get; set; }
        #endregion

        #region private bool Schedule { get; set; }
        private bool Schedule { get; set; }
        #endregion

        #endregion

        #region Constructors

        #region public MaintenanceSummaryControlNew()
        ///<summary>
        ///</summary>
        public MaintenanceSummaryControl()
        {
            InitializeComponent();

            //labelLastCheckName.Text = "N/A";
            //labelLastComplianceDate.Text = "N/A";
            //labelLastComplianceLL.Text = "N/A";
            //labelNextCheckName.Text = "N/A";
            //labelNextComplianceDate.Text = "N/A";
            //labelNextComplianceLL.Text = "N/A";
            //labelRamainLL.Text = "N/A";

            BackGroundWorker.DoWork += BwDoWork;
            BackGroundWorker.RunWorkerCompleted += BwRunWorkerCompleted;
            BT = new Dictionary<string, string>();
            BT.Add("NextCheckName", "N/A");
            BT.Add("NextComplianceDate", "N/A");
            BT.Add("NextComplianceLL", "N/A");
            BT.Add("LastCheckName", "N/A");
            BT.Add("LastComplianceDate", "N/A");
            BT.Add("LastComplianceLL", "N/A");
            BT.Add("RemainLL", "N/A");
        }
        #endregion

        #endregion

        #region Metods

        #region void CheckItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        void CheckItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!BackGroundWorker.IsBusy)
            {
                BackGroundWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region void CheckItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        void CheckItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LastCompliance")
            {
                if (!BackGroundWorker.IsBusy)
                {
                    BackGroundWorker.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region void BwDoWork(object sender, DoWorkEventArgs e)
        void BwDoWork(object sender, DoWorkEventArgs e)
        {
            BT["LastCheckName"] = "N/A";
            BT["LastComplianceDate"] = "N/A";
            BT["LastComplianceLL"] = "N/A";
            BT["NextCheckName"] = "N/A";
            BT["NextComplianceDate"] = "N/A";
            BT["NextComplianceLL"] = "N/A";
            BT["RemainLL"] = "N/A";

            FindLastCheck();
            FindNextCheck();
        }
        #endregion

        #region void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //tableLayoutPanel1.Visible = false;
            //tableLayoutPanel1.Refresh();
            //labelLastCheckName.Text = BT["LastCheckName"];
            //labelLastComplianceDate.Text = BT["LastComplianceDate"];
            //labelLastComplianceLL.Text = BT["LastComplianceLL"];
            //labelNextCheckName.Text = BT["NextCheckName"];
            //labelNextComplianceDate.Text = BT["NextComplianceDate"];
            //labelNextComplianceLL.Text = BT["NextComplianceLL"];
            //labelRamainLL.Text = BT["RemainLL"];
            //tableLayoutPanel1.Visible = true;
        }
        #endregion

        #region public void UpdateInformation(MaintenanceCheckCollection checkItems, Aircraft aircraft, bool schedule)

        ///<summary>
        ///</summary>
        ///<param name="checkItems"></param>
        ///<param name="aircraft"></param>
        ///<param name="schedule"></param>
        public void UpdateInformation(MaintenanceCheckCollection checkItems, 
                                      Aircraft aircraft, 
                                      bool schedule)
        {
            CheckItems = checkItems;
            Schedule = schedule;
            _complianceGroupCollection = CheckItems.GetNextComplianceCheckGroups(Schedule).OrderBy(GetNextComplianceDate);
            TsnCsn = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);

            listViewLastCheck.Items.Clear();
            listViewNextCheck.Items.Clear();

            if (CheckItems.Count == 0)
                return;

            if(!BackGroundWorker.IsBusy)
                BackGroundWorker.RunWorkerAsync();
            List<MaintenanceCheck> orderedBySchedule = 
                checkItems.OrderBy(c => c.Schedule)
                          .OrderByDescending(c => c.Grouping)
                          .OrderBy(c => c.Resource)
                          .ToList();

            List<MaintenanceCheckGroupByType> checkGroups = new List<MaintenanceCheckGroupByType>();
            foreach (MaintenanceCheck check in orderedBySchedule)
            {
                MaintenanceCheckGroupByType group = checkGroups
                    .FirstOrDefault(g => g.Schedule == check.Schedule &&
                                         g.Grouping == check.Grouping &&
                                         g.Resource == check.Resource);
                if (group != null)
                {
                    group.Checks.Add(check);
                }
                else
                {
                    group = new MaintenanceCheckGroupByType(check.Schedule)
                                {
                                    Grouping = check.Grouping,
                                    Resource = check.Resource
                                };
                    group.Checks.Add(check);
                    checkGroups.Add(group);
                }
            }

            List<MaintenanceProgramControl> mpcs =
                flowLayoutPanel1.Controls.OfType<MaintenanceProgramControl>().ToList();
            for (int j = 0; j < mpcs.Count; j++)
            {
                if(j >= checkGroups.Count)
                {
                    //Если кол-во контролов превышает кол-во групп чеков
                    //то необходимо убрать лишние контролы
                    flowLayoutPanel1.Controls.Remove(mpcs[j]);
                    continue;
                }

                mpcs[j].SetParameters(checkGroups[j].Checks, 
                                      checkGroups[j].Schedule, 
                                      checkGroups[j].Grouping, 
                                      checkGroups[j].Resource);
            }

            for (int j = mpcs.Count; j < checkGroups.Count; j++)
            {
                MaintenanceProgramControl mpc = 
                    new MaintenanceProgramControl(checkGroups[j].Checks,
                                                  checkGroups[j].Schedule,
                                                  checkGroups[j].Grouping,
                                                  checkGroups[j].Resource) {Extended = false};
                flowLayoutPanel1.Controls.Add(mpc);
                flowLayoutPanel1.Controls.SetChildIndex(mpc, j);
            }
           
            mpcs = flowLayoutPanel1.Controls.OfType<MaintenanceProgramControl>().ToList();
            if (mpcs.Count == 1)
                mpcs[0].EnableExtendedControl = false;
            else if (mpcs.Count >= 1)
                mpcs[0].EnableExtendedControl = true;

            maintenancePerformanceControl1.Reload(checkItems, aircraft);
        }
        #endregion

        #region private DateTime GetNextComplianceDate(MaintenanceCheckComplianceGroup complianceGroup)

        private DateTime GetNextComplianceDate(MaintenanceCheckComplianceGroup complianceGroup)
        {
            if ((complianceGroup.GetMaxIntervalCheck()) == null)
                return DateTimeExtend.GetCASMinDateTime();
            complianceGroup.Sort();

            DateTime nextDate = DateTimeExtend.GetCASMinDateTime();
            if (complianceGroup.Grouping)
            {
                MaintenanceCheck lastOrMinCheck =
                    complianceGroup.GetLastComplianceChecks().FirstOrDefault() != null
                        ? complianceGroup.GetLastComplianceChecks().First()
                        : complianceGroup.GetMinIntervalCheck();
                if (lastOrMinCheck.Interval.Days != null && lastOrMinCheck.Interval.Days > 0)
                {
                    nextDate = lastOrMinCheck.NextPerformances.Count != 0 && lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                            ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                                            : lastOrMinCheck.LastPerformance != null
                                                  ? lastOrMinCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days))
                                                  : lastOrMinCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days));
                }
                else
                {

                    nextDate = lastOrMinCheck.NextPerformances.Count != 0 &&
                               lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                        ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                        : DateTimeExtend.GetCASMinDateTime();
                }

            }
            else
            {
                foreach (MaintenanceCheck maintenanceCheck in complianceGroup.Checks)
                {
                    if (maintenanceCheck.Interval.Days != null && maintenanceCheck.Interval.Days > 0)
                    {
                        nextDate =
                            maintenanceCheck.NextPerformances.Count != 0 && maintenanceCheck.NextPerformances[0].PerformanceDate != null
                                            ? maintenanceCheck.NextPerformances[0].PerformanceDate.Value
                                            : maintenanceCheck.LastPerformance != null
                                                  ? maintenanceCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days))
                                                  : maintenanceCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days));
                    }
                    else
                    {
                        nextDate = maintenanceCheck.NextPerformanceDate != null 
                            ? maintenanceCheck.NextPerformanceDate.Value 
                            : DateTimeExtend.GetCASMinDateTime();
                    }
                }
            }

            return nextDate;
        }
        #endregion

        #region private void FindLastCheck()
        private void FindLastCheck()
        {
            MaintenanceCheckGroupCollection[] groupByType = 
                CheckItems.GroupingCheckByType(Schedule)
                    .OrderByDescending(g => g.GetLastComplianceDate())
                    .ToArray();

            MaintenanceCheckGroupCollection checkGroupCollectionOrdered =
                new MaintenanceCheckGroupCollection(groupByType.SelectMany(gbt => gbt.ToArray())
                                                               .OrderByDescending(gbt => gbt.LastComplianceGroupDate));
            foreach (MaintenanceCheckGroupByType checkGroupByType in checkGroupCollectionOrdered)
            {
                string lastCheck = "", lastComplianceDate = "", lastComplianceLl = "";
                DateTime last = DateTimeExtend.GetCASMinDateTime();
                if(checkGroupByType.Grouping)
                {
                    //Вычисление последней даты выполнения чеков данного типа
                    //A, B или C
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == Schedule))
                    {
                        if (checkItem.LastPerformance != null && last < checkItem.LastPerformance.RecordDate)
                            last = checkItem.LastPerformance.RecordDate;
                    }
                    //Если чеки с данным типом (A, B или C) еще не выполнялись
                    //то производится переход на след. тип. чека
                    if (last <= DateTimeExtend.GetCASMinDateTime() || 
                        last <= checkGroupCollectionOrdered.GetLastComplianceDateOfCheckWithHigherType(checkGroupByType.Schedule,
                                                                                                       checkGroupByType.Resource, 
                                                                                                       checkGroupByType.Grouping, 
                                                                                                       checkGroupByType.CheckType))
                        continue;
                    //lastGroupComplianceDates[checkGroupByType.Resource] = last;
                    //Если чеки с данным типом выполнялись
                    //то собирается група из чеков данного типа (A, B или C), 
                    //чья дата выполнения равна найденой
                    MaintenanceCheckComplianceGroup lastComplianceGroup = new MaintenanceCheckComplianceGroup(Schedule);
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == Schedule))
                        if (checkItem.LastPerformance != null && last == checkItem.LastPerformance.RecordDate)
                        {
                            lastComplianceGroup.Checks.Add(checkItem);
                            if (lastComplianceGroup.CheckCycle < checkGroupByType.CheckCycle)
                                lastComplianceGroup.CheckCycle = checkGroupByType.CheckCycle;
                            if (lastComplianceGroup.GroupComplianceNum < checkItem.LastPerformance.NumGroup)
                                lastComplianceGroup.GroupComplianceNum = checkItem.LastPerformance.NumGroup;
                        }
                    MaintenanceCheck maxIntervalCheckInGroup;
                    //Поиск старшего чека данного типа в собранной группе
                    //Если его нет, переход к след. типу чеков
                    if ((maxIntervalCheckInGroup = lastComplianceGroup.GetMaxIntervalCheck()) == null)
                        continue;
                    //Упорядочивание собранной группы
                    lastComplianceGroup.Sort();

                    string prefix = lastComplianceGroup.GetComplianceGroupName();
                    lastComplianceDate = UsefulMethods.NormalizeDate(last);
                    lastComplianceLl = maxIntervalCheckInGroup.LastPerformance.OnLifelength.ToString();

                    //название чеков
                    lastCheck = prefix;
                    if (maxIntervalCheckInGroup.ParentAircraft != null &&
                        maxIntervalCheckInGroup.ParentAircraft.MSG < MSG.MSG3)
                    {
                        lastCheck += " (";
                        lastCheck += lastComplianceGroup.Checks.Aggregate(lastCheck, (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                        lastCheck += ") ";
                    }

                    Action<string, string, string> addLast = AddLastCheckItem;
                    if (InvokeRequired)
                    {
                        Invoke(addLast, lastCheck, lastComplianceDate, lastComplianceLl);
                    }
                    else addLast.Invoke(lastCheck, lastComplianceDate, lastComplianceLl);    
                }
                else
                {
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == Schedule))
                    {
                        if (checkItem.LastPerformance != null)
                        {
                            lastComplianceDate = UsefulMethods.NormalizeDate(checkItem.LastPerformance.RecordDate);
                            lastComplianceLl = checkItem.LastPerformance.OnLifelength.ToString();

                            //название чеков
                            lastCheck = checkItem.Name;
                        }

                        Action<string, string, string> addLast = AddLastCheckItem;
                        if (InvokeRequired)
                        {
                            Invoke(addLast, lastCheck, lastComplianceDate, lastComplianceLl);
                        }
                        else addLast.Invoke(lastCheck, lastComplianceDate, lastComplianceLl);
                    }    
                }
            }
        }
        #endregion

        #region  private void AddLastCheckItem(string name, string date, string lifelenght)
        private void AddLastCheckItem(string name, string date, string lifelenght)
        {
            List<ListViewItem.ListViewSubItem> subs = new List<ListViewItem.ListViewSubItem>();
            subs.Add(new ListViewItem.ListViewSubItem { Text = name == "" ? "N/A" : name, });
            subs.Add(new ListViewItem.ListViewSubItem { Text = date == "" ? "N/A" : date, });
            subs.Add(new ListViewItem.ListViewSubItem { Text = lifelenght == "" ? "N/A" : lifelenght, });
            listViewLastCheck.Items.Add(new ListViewItem(subs.ToArray(), null));
        }
        #endregion

        #region private void FindNextCheck()
        private void FindNextCheck()
        {
            //вычисление самого последнего выполненного чека, вне зависимости от типа
            //последний выполненый чек по типу может нессответствовать текущему типу программы 
            //в случае переключения
            MaintenanceCheck lastComplianceCheck = CheckItems.Where(c => c.LastPerformance != null).OrderByDescending(c => c.LastPerformance.RecordDate).FirstOrDefault();
            if (lastComplianceCheck != null && lastComplianceCheck.Schedule != Schedule && Schedule)
            {
                //тип программмы Maintenance был переключен, переключение с Unschedule на Schedule
                //вычисление самого последнего выполненного чека, заданного типа
                MaintenanceCheck lastComplianceScheduleTypeCheck =
                     CheckItems.Where(c => c.LastPerformance != null && c.Schedule == Schedule).OrderByDescending(c => c.LastPerformance.RecordDate).FirstOrDefault();

                MaintenanceCheckGroupByType group = new List<MaintenanceCheck>(CheckItems).GetNextCheckBySourceDifference(lastComplianceScheduleTypeCheck, TsnCsn.Days);
                //название чеков
                MaintenanceCheck maxIntervalCheckInGroup = group.GetMaxIntervalCheck();
                string tNext = maxIntervalCheckInGroup.Name + " (";
                tNext += group.Checks.Aggregate(tNext, (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                tNext += ") ";
                string tNextDate = UsefulMethods.NormalizeDate(group.GroupComplianceDate);

                group.GroupComplianceLifelength.Cycles = group.GroupComplianceLifelength.Hours = null;
                string tNextLl = group.GroupComplianceLifelength.ToRepeatIntervalsFormat();
                
                group.GroupComplianceLifelength.Substract(TsnCsn);
                group.GroupComplianceLifelength.Cycles = group.GroupComplianceLifelength.Hours = null;
                string tRemainLl = Convert.ToInt32(group.GroupComplianceLifelength.Days).ToString();

                Action<string, string, string, string> addLast = AddNextCheckItem;
                if (InvokeRequired)
                {
                    Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                }
                else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
            }
            else
            {
                if(_complianceGroupCollection == null)
                    _complianceGroupCollection = CheckItems.GetNextComplianceCheckGroups(Schedule).OrderBy(GetNextComplianceDate);

                foreach (MaintenanceCheckComplianceGroup complianceGroup in _complianceGroupCollection)
                {
                    string tNext, tNextDate, tNextLl, tRemainLl;
                    MaintenanceCheck maxIntervalCheckInGroup;
                    if ((maxIntervalCheckInGroup = complianceGroup.GetMaxIntervalCheck()) == null)
                        continue;
                    complianceGroup.Sort();

                    string prefix = complianceGroup.GetGroupName();

                    if (complianceGroup.Grouping)
                    {
                        MaintenanceCheck lastOrMinCheck =
                            complianceGroup.GetLastComplianceChecks().FirstOrDefault() != null
                                ? complianceGroup.GetLastComplianceChecks().First()
                                : complianceGroup.GetMinIntervalCheck();
                        
                            
                        //дата следующего выполнения группы чеков
                        if (lastOrMinCheck.Interval.Days != null && lastOrMinCheck.Interval.Days > 0)
                        {
                            DateTime nextDate = lastOrMinCheck.NextPerformances.Count != 0 && lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                                    ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                                                    : lastOrMinCheck.LastPerformance != null
                                                          ? lastOrMinCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days))
                                                          : lastOrMinCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days));

                            tNextDate = UsefulMethods.NormalizeDate(nextDate);

                            if (lastOrMinCheck.NextPerformances.Count != 0 &&
                                lastOrMinCheck.NextPerformances[0].Remains != null)
                            {
                                //Остаток до выполнения
                                Lifelength remains = lastOrMinCheck.NextPerformances[0].Remains;
                                tRemainLl = remains.IsNullOrZero() ? "N/A" : remains.ToString(); 
                            }
                            else
                            {
                                tRemainLl = " N/A ";
                            }
                        }
                        else
                        {

                            tNextDate = lastOrMinCheck.NextPerformances.Count != 0 &&
                                         lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                ? " approx. " + UsefulMethods.NormalizeDate(lastOrMinCheck.NextPerformances[0].PerformanceDate.Value)
                                : " N/A ";

                            if (lastOrMinCheck.NextPerformances.Count != 0 &&
                                lastOrMinCheck.NextPerformances[0].Remains != null)
                            {
                                //Остаток до выполнения
                                Lifelength remains = lastOrMinCheck.NextPerformances[0].Remains;
                                tRemainLl = remains.IsNullOrZero() ? "N/A" : remains.ToString();
                            }
                            else tRemainLl = " N/A ";
                        }
                        //ресурс, на котором надо поризвести выполнение
                        //след выполнение
                        Lifelength next =
                            lastOrMinCheck.NextPerformances.Count != 0
                                ? lastOrMinCheck.NextPerformances[0].PerformanceSource
                                : Lifelength.Null;
                        next.Resemble(maxIntervalCheckInGroup.Interval);
                        tNextLl = next.IsNullOrZero() ? "N/A" : next.ToString();
                        //название чеков
                        tNext = prefix;
                        if (lastOrMinCheck.ParentAircraft != null &&
                            lastOrMinCheck.ParentAircraft.MSG < MSG.MSG3)
                        {
                            tNext +=" (";
                            tNext = complianceGroup.Checks.Aggregate(tNext, (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                            tNext += ") ";
                        }

                        Action<string, string, string, string> addLast = AddNextCheckItem;
                        if (InvokeRequired)
                        {
                            Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                        }
                        else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
                    }
                    else
                    {
                        foreach (MaintenanceCheck maintenanceCheck in complianceGroup.Checks)
                        {
                            DateTime nextDate;
                            if (maintenanceCheck.Interval.Days != null && maintenanceCheck.Interval.Days > 0)
                            {
                                nextDate =
                                    maintenanceCheck.NextPerformances.Count != 0 && maintenanceCheck.NextPerformances[0].PerformanceDate != null
                                                    ? maintenanceCheck.NextPerformances[0].PerformanceDate.Value
                                                    : maintenanceCheck.LastPerformance != null
                                                          ? maintenanceCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days))
                                                          : maintenanceCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days));

                                tNextDate = "\n" + UsefulMethods.NormalizeDate(nextDate);

                                if (maintenanceCheck.NextPerformances.Count != 0 &&
                                    maintenanceCheck.NextPerformances[0].Remains != null)
                                {
                                    //Остаток до выполнения
                                    Lifelength remains = maintenanceCheck.NextPerformances[0].Remains;
                                    tRemainLl = "\n" + (remains.IsNullOrZero() ? "N/A" : remains.ToString());
                                }
                                else
                                {
                                    tRemainLl = "\n N/A ";
                                }
                            }
                            else
                            {
                                if (maintenanceCheck.NextPerformanceDate != null)
                                {
                                    nextDate = maintenanceCheck.NextPerformanceDate.Value;
                                    tNextDate = "\n approx. " + UsefulMethods.NormalizeDate(nextDate);
                                }
                                else
                                {
                                    tNextDate = "\n (N/A) ";
                                }

                                if (maintenanceCheck.NextPerformances.Count != 0 &&
                                    maintenanceCheck.NextPerformances[0].Remains != null)
                                {
                                    //Остаток до выполнения
                                    Lifelength remains = maintenanceCheck.NextPerformances[0].Remains;
                                    tRemainLl = "\n" + (remains.IsNullOrZero() ? "N/A" : remains.ToString());
                                }
                                else tRemainLl = "\n (N/A) ";
                            }
                            //след выполнение
                            Lifelength next =
                                maintenanceCheck.NextPerformances.Count != 0
                                    ? maintenanceCheck.NextPerformances[0].PerformanceSource
                                    : Lifelength.Null;
                            tNextLl = "\n" + (next.IsNullOrZero() ? "N/A" : next.ToString());

                            //название чеков
                            tNext = "\n" + maintenanceCheck.Name + " ";

                            Action<string, string, string, string> addLast = AddNextCheckItem;
                            if (InvokeRequired)
                            {
                                Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                            }
                            else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
                        }
                    }
                }
            }
        }
        #endregion

        #region private void AddNextCheckItem(string name, string date, string lifelenght, string remains)
        private void AddNextCheckItem(string name, string date, string lifelenght, string remains)
        {
            List<ListViewItem.ListViewSubItem> subs = new List<ListViewItem.ListViewSubItem>();
            subs.Add(new ListViewItem.ListViewSubItem { Text = name == "" ? "N/A" : name, });
            subs.Add(new ListViewItem.ListViewSubItem { Text = date == "" ? "N/A" : date, });
            subs.Add(new ListViewItem.ListViewSubItem { Text = lifelenght == "" ? "N/A" : lifelenght, });
            subs.Add(new ListViewItem.ListViewSubItem { Text = remains == "" ? "N/A" : remains, });
            listViewNextCheck.Items.Add(new ListViewItem(subs.ToArray(), null));
        }
        #endregion

        #endregion
    }
}
