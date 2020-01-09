using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenancePerformanceControl : UserControl
    {
        #region Fields
        
        private MaintenanceCheckCollection _checkItems;
        private Aircraft _currentAircraft;

        #endregion

        #region Properties
        public MaintenanceCheckCollection CheckItems
        {
            get { return _checkItems; }
            set
            {
                if (_checkItems != null && _checkItems != value)
                {
                    _checkItems.CollectionChanged -= LimitationItemsCollectionChanged;
                    foreach (MaintenanceCheck checkItem in _checkItems)
                    {
                        checkItem.PropertyChanged -= LiminationItemPropertyChanged;
                    }
                }
                if (_checkItems != value)
                {
                    _checkItems = value;

                    if (_checkItems != null)
                    {
                        _checkItems.CollectionChanged += LimitationItemsCollectionChanged;
                        foreach (MaintenanceCheck liminationItem in value)
                        {
                            liminationItem.PropertyChanged += LiminationItemPropertyChanged;
                        }
                    }
                }
            }
        }

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public MaintenancePerformanceControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Collection changet methods

        void LimitationItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e == null)
                return;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (MaintenanceCheck newItem in e.NewItems)
                {
                    newItem.PropertyChanged += LiminationItemPropertyChanged;
                    AddLimitationItem(newItem);
                }
            }
            else
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (MaintenanceCheck oldItem in e.OldItems)
                    {
                        oldItem.PropertyChanged -= LiminationItemPropertyChanged;
                        RemoveLimitationItem(oldItem);
                    }
                }
        }

        void LiminationItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                UpdateLimitationItem((MaintenanceCheck)sender);
            }
        }

        void AddLimitationItem(MaintenanceCheck item)
        {
            if (item.IsDeleted == false)
            {
                directivesListView.Items.Add(GetListViewItem(item));
            }
        }
        void RemoveLimitationItem(MaintenanceCheck item)
        {
            foreach (ListViewItem item1 in directivesListView.Items)
            {
                if (item1.Tag == item)
                {
                    directivesListView.Items.Remove(item1);
                    break;
                }
            }
        }

        void UpdateLimitationItem(MaintenanceCheck item)
        {
            foreach (ListViewItem item1 in directivesListView.Items)
            {
                if (item1.Tag == item)
                {
                    ListViewItem listViewItem = GetListViewItem(item);
                    item1.Group = listViewItem.Group;

                    item1.Text = listViewItem.Text;
                    item1.SubItems[0] = listViewItem.SubItems[0];
                    item1.SubItems[1] = listViewItem.SubItems[1];
                    item1.SubItems[2] = listViewItem.SubItems[2];
                    item1.SubItems[3] = listViewItem.SubItems[3];
                    item1.SubItems[4] = listViewItem.SubItems[4];
                    item1.SubItems[5] = listViewItem.SubItems[5];
                    item1.SubItems[6] = listViewItem.SubItems[6];
                    item1.SubItems[7] = listViewItem.SubItems[7];
                }
            }
        }

        #endregion

        #region Fill

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

        #region Metods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            directivesListView.Items.Clear();
            directivesListView.Groups.Clear();

            ////прогнозируемый ресурс
            //Lifelength current = GlobalObjects.CasEnvironment.Calculator.GetLifelength(_currentAircraft);
            //IEnumerable<MaintenanceCheck> groupingChecks = _checkItems.Where(c => c.Grouping);
            //int? offsetMinutes =
            //    groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Minutes))
            //                  .OrderBy(r => r)
            //                  .LastOrDefault();
            //int? offsetCycles =
            //    groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Cycles))
            //                  .OrderBy(r => r)
            //                  .LastOrDefault();
            //int? offsetDays =
            //    groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Calendar))
            //                  .OrderBy(r => r)
            //                  .LastOrDefault();
            //Lifelength offset = new Lifelength(offsetDays, offsetCycles, offsetMinutes);
            //Double approxDays = Convert.ToDouble(Analyst.GetApproximateDays(offset, _currentAircraft.Frame.AverageUtilization));
            //ForecastData forecastData = new ForecastData(DateTime.Now.AddDays(approxDays), 
            //                                             _currentAircraft.Frame.AverageUtilization,
            //                                             current);
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformanceGroup(_checkItems, _currentAircraft.Schedule, forecastData);

            foreach (MaintenanceCheck item in _checkItems)
            {
                if (item.IsDeleted == false)
                {
                    directivesListView.Items.Add(GetListViewItem(item));
                }
            }
        }
        #endregion

        #region private ListViewItem GetListViewItem(MaintenanceCheck check)

        private ListViewItem GetListViewItem(MaintenanceCheck check)
        {
            ListViewItem listViewItem = new ListViewItem { Tag = check, Text = check.Name };

            if (check.Grouping)
            {
                MaintenanceNextPerformance np = check.NextPerformances.FirstOrDefault() as MaintenanceNextPerformance;
                MaintenanceProgramChangeRecord mpcr = np != null && np.PerformanceDate != null
                                                          ? _currentAircraft.MaintenanceProgramChangeRecords.
                                                                GetLastKnownRecord(Convert.ToDateTime(np.PerformanceDate))
                                                          : null;

                if (mpcr != null && mpcr.MSG >= MSG.MSG3)
                {
                    string lastPerformanceDate = "N/A";
                    string lastPerformanceSource = "N/A";
                    string lastPerformaceGroup = "N/A";
                    string lastCheckName = "N/A";
                    string nextPerformanceDate = "N/A";
                    string nextPerformanceSource = "N/A";
                    string nextPerformaceGroup = "N/A";
                    string nextCheckName = "N/A";
                    string remains = "N/A";
                    
                    MaintenanceNextPerformance mnp = check.GetNextPergormanceGroupWhereCheckIsSenior();
                    if (mnp != null)
                    {
                        nextPerformanceDate = UsefulMethods.NormalizeDate(Convert.ToDateTime(mnp.PerformanceDate));
                        nextPerformanceSource = mnp.PerformanceSource.ToString();
                        nextPerformaceGroup = mnp.PerformanceGroupNum + "/" + mnp.PerformanceNum;
                        nextCheckName = mnp.PerformanceGroup.GetGroupName();
                        remains = mnp.Remains.ToString();
                    }
                    if (check.LastPerformance != null)
                    {
                        MaintenanceCheckRecord mcr = _checkItems.GetLastCheckRecordWhereCheckIsSenior(check);
                        if (mcr != null)
                        {
                            lastPerformanceDate = UsefulMethods.NormalizeDate(mcr.RecordDate);
                            lastPerformanceSource = mcr.OnLifelength.ToString();
                            lastPerformaceGroup = mcr.NumGroup + "/" + mcr.PerformanceNum;
                            lastCheckName =
                                _currentAircraft != null && _currentAircraft.MaintenanceProgramCheckNaming
                                        ? (!string.IsNullOrEmpty(mcr.ComplianceCheckName)
                                               ? mcr.ComplianceCheckName
                                               : check.Name)
                                        : check.Name;
                        }
                    }

                    listViewItem.SubItems.Add(lastPerformanceDate);
                    listViewItem.SubItems.Add(lastPerformanceSource);
                    listViewItem.SubItems.Add(lastPerformaceGroup);
                    listViewItem.SubItems.Add(lastCheckName);
                    listViewItem.SubItems.Add(nextPerformanceDate);
                    listViewItem.SubItems.Add(nextPerformanceSource);
                    listViewItem.SubItems.Add(nextPerformaceGroup);
                    listViewItem.SubItems.Add(nextCheckName);
                    listViewItem.SubItems.Add(remains);
                }
                else
                {
                    if (check.LastPerformance == null)
                    {
                        listViewItem.SubItems.Add("N/A");
                        listViewItem.SubItems.Add("N/A");
                        listViewItem.SubItems.Add("N/A");
                        listViewItem.SubItems.Add("N/A");
                        listViewItem.SubItems.Add(np != null && np.PerformanceDate != null ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceSource.ToString() : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceGroupNum + "/" + np.PerformanceNum : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceGroup.GetGroupName() : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.Remains.ToString() : "N/A");
                    }
                    else
                    {
                        string lastCheckName =
                                _currentAircraft != null && _currentAircraft.MaintenanceProgramCheckNaming
                                    ? (!string.IsNullOrEmpty(check.LastPerformance.ComplianceCheckName)
                                           ? check.LastPerformance.ComplianceCheckName
                                           : check.Name)
                                    : check.Name;
                        listViewItem.SubItems.Add(UsefulMethods.NormalizeDate(check.LastPerformance.RecordDate));
                        listViewItem.SubItems.Add(check.LastPerformance.OnLifelength.ToString());
                        listViewItem.SubItems.Add(check.LastPerformance.NumGroup + "/" + check.LastPerformance.PerformanceNum);
                        listViewItem.SubItems.Add(lastCheckName);
                        listViewItem.SubItems.Add(np != null && np.PerformanceDate != null ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceSource.ToString() : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceGroupNum + "/" + np.PerformanceNum : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.PerformanceGroup.GetGroupName() : "N/A");
                        listViewItem.SubItems.Add(np != null ? np.Remains.ToString() : "N/A");
                    }  
                }
                if (np != null && np.Condition == ConditionState.Overdue)
                    listViewItem.BackColor = Color.FromArgb(255, 170, 170);
                else if (np != null && np.Condition == ConditionState.Notify)
                    listViewItem.BackColor = Color.FromArgb(255, 255, 170);
                else if (np == null || np.Condition == ConditionState.NotEstimated)
                    listViewItem.BackColor = Color.FromArgb(170, 170, 255); 
            }
            else
            {
                NextPerformance np = check.NextPerformances.FirstOrDefault();
                if (check.LastPerformance == null)
                {
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add(np != null && np.PerformanceDate != null ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) : "N/A");
                    listViewItem.SubItems.Add(np != null ? np.PerformanceSource.ToString() : "N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add(np != null ? np.Remains.ToString() : "N/A");
                }
                else
                {
                    listViewItem.SubItems.Add(UsefulMethods.NormalizeDate(check.LastPerformance.RecordDate));
                    listViewItem.SubItems.Add(check.LastPerformance.OnLifelength.ToString());
                    listViewItem.SubItems.Add(check.LastPerformance.NumGroup.ToString());
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add(np != null && np.PerformanceDate != null ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) : "N/A");
                    listViewItem.SubItems.Add(np != null ? np.PerformanceSource.ToString() : "N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add("N/A");
                    listViewItem.SubItems.Add(np != null ? np.Remains.ToString() : "N/A");
                }
                if (np != null && np.Condition == ConditionState.Overdue)
                    listViewItem.BackColor = Color.FromArgb(255, 170, 170);
                else if (np != null && np.Condition == ConditionState.Notify)
                    listViewItem.BackColor = Color.FromArgb(255, 255, 170);
                else if (np == null || np.Condition == ConditionState.NotEstimated)
                    listViewItem.BackColor = Color.FromArgb(170, 170, 255);   
            }


            listViewItem.Group = GetGroup(check);
            return listViewItem;
        }
        #endregion

        #region private ListViewGroup GetGroup(MaintenanceCheck item)

        private ListViewGroup GetGroup(MaintenanceCheck item)
        {
            string type = item.Schedule ? " (Schedule) " : " (Store) ";
            string resource = item.Resource.ToString();
            string grouping = item.Grouping ? " (Group)" : "";
            foreach (ListViewGroup group in directivesListView.Groups)
            {
                if (group.Header == item.CheckType.FullName + type + resource + grouping)
                {
                    return group;
                }
            }

            string key =
	            $"{(item.Schedule ? "1" : "2")}{((int) item.Resource)}{(item.Grouping ? "1" : "2")}{item.CheckType.Priority}";
            ListViewGroup listViewGroup = new ListViewGroup(key, item.CheckType.FullName + type + resource + grouping);
            directivesListView.Groups.Add(listViewGroup);
            return listViewGroup;
        }
        #endregion

        #endregion
    }
}
