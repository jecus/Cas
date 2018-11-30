using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Convert = System.Convert;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceCompliance : ComplianceControl
    {
        private Aircraft _currentAircraft;
        private List<MaintenanceCheckRecord> _allCompliance;
        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemBindingTasks;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;

        #region Properties

        #region public MaintenanceCheckCollection CheckItems { get; set; }
        /// <summary>
        /// Список MaintenanceLimination на текущий Aircraft
        /// </summary>

        public MaintenanceCheckCollection CheckItems { get; set; }
        
        #endregion

        #region  private bool Schedule { get; set; }

        private bool Schedule { get; set; }
        #endregion

        #endregion

        #region Constructors

        #region public MaintenanceComplianceNew()
        ///<summary>
        ///</summary>
        public MaintenanceCompliance()
        {
            InitializeComponent();
        }
        #endregion

        #endregion
        
        #region Methods

        #region private void InitToolStripMenuItems()

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemBindingTasks = new ToolStripMenuItem();
            _toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemBindingTasks.Text = "Tasks";
            _toolStripMenuItemBindingTasks.Click += ToolStripMenuItemOpenClick;
            //
            // _toolStripMenuItemsWorkPackages
            //
            _toolStripMenuItemsWorkPackages.Text = "Add to Work package";

            _contextMenuStrip.Items.Clear();
            _toolStripMenuItemsWorkPackages.DropDownItems.Clear();

            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    _toolStripMenuItemBindingTasks,
                                                    _toolStripMenuItemsWorkPackages,
                                                });
            _contextMenuStrip.Opening += ContextMenuStripOpen;

            listViewCompliance.ContextMenuStrip = _contextMenuStrip;
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
            if (listViewCompliance.SelectedItems.Count <= 0 || 
                listViewCompliance.SelectedItems.Count > 1 ||
                !(listViewCompliance.SelectedItems[0].Tag is NextPerformance))
                e.Cancel = true;

            if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
            {
                _toolStripMenuItemsWorkPackages.Enabled = true;
            }
            else
            {
                _toolStripMenuItemsWorkPackages.Enabled = false;
            }
        }

        #endregion

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
            //if (listViewCompliance.SelectedItems.Count <= 0 ||
            //    listViewCompliance.SelectedItems.Count > 1 ||
            //    !(listViewCompliance.SelectedItems[0].Tag is NextPerformance))
            //    return;

            //NextPerformance np = listViewCompliance.SelectedItems[0].Tag as NextPerformance;
            //if (np.Parent == null) return;
            //MaintenanceCheckBindTaskForm bindTaskForm = new MaintenanceCheckBindTaskForm(np.Parent as MaintenanceCheck, np);
            //bindTaskForm.ShowDialog(this);
        }

        #endregion

        #region public void Reload(MaintenanceCheckCollection checkItems, Aircraft curentAircraft, bool schedule)
        ///<summary>
        ///</summary>
        public void Reload(MaintenanceCheckCollection checkItems, Aircraft curentAircraft, bool schedule)
        {
            _currentAircraft = curentAircraft;
            CheckItems = checkItems;
            Schedule = schedule;
            _allCompliance = new List<MaintenanceCheckRecord>();

            listViewCompliance.Items.Clear();

            foreach (MaintenanceCheck check in checkItems)
            {
                if (check.PerformanceRecords != null)
                {
                    foreach (MaintenanceCheckRecord item in check.PerformanceRecords)
                    {
                        item.ParentCheck = check;
                        _allCompliance.Add(item);
                    }
                }
            }

            UpdateInformation();
        }
        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if(_contextMenuStrip == null)
                InitToolStripMenuItems();

            listViewCompliance.Items.Clear();

            if (CheckItems == null) return;

            var lastRecords = new List<MaintenanceCheckRecord>();
            var nextPerformances = new List<NextPerformance>();
            //Поиск и заполнение просроченных директив и записей о перемещении
            //Объекты для в которые будет извлекаться информация 
            //из записеи о перемещении

            string[] subs;
            ListViewItem newItem;

	        var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_currentAircraft.AircraftFrameId);
            //прогнозируемый ресурс
            var forecastData = new ForecastData(DateTime.Now, aircraftFrame.AverageUtilization,
                                                         GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircraft));
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformanceGroup(CheckItems, _currentAircraft.Schedule, forecastData);

            foreach (MaintenanceCheck check in CheckItems)
            {
                if (check.Grouping)
                {
                    foreach (MaintenanceNextPerformance mnp in check.GetPergormanceGroupWhereCheckIsSenior())
                    {
                        //Добавляются все выполнения, дата которых меньше нынешней
                        //плюс еще одно выполнение дата которого выше нынешней
                        nextPerformances.Add(mnp);
                        
                        if(mnp.PerformanceDate != null && mnp.PerformanceDate > DateTime.Now)
                            break;
                    }
                }
                else
                {
                    foreach (NextPerformance mnp in check.NextPerformances)
                    {
                        //Добавляются все выполнения, дата которых меньше нынешней
                        //плюс еще одно выполнение дата которого выше нынешней
                        nextPerformances.Add(mnp);

                        if (mnp.PerformanceDate != null && mnp.PerformanceDate > DateTime.Now)
                            break;
                    }
                }
                
                lastRecords.AddRange(check.PerformanceRecords.ToArray());

                foreach (MaintenanceDirective mpd in check.BindMpds)
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd, forecastData);  
            }
            ////////////////////////////////////////////
            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            if (_openPubWorkPackages == null)
                _openPubWorkPackages = new CommonCollection<WorkPackage>();
            _openPubWorkPackages.Clear();
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(_currentAircraft, WorkPackageStatus.Opened));
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(_currentAircraft, WorkPackageStatus.Published));

            var allWorkPackagesIncludedTask = new CommonCollection<WorkPackage>();
            var openPubWorkPackages = new CommonCollection<WorkPackage>();
            var closedWorkPackages = new CommonCollection<WorkPackage>();
            allWorkPackagesIncludedTask.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(_currentAircraft,
                                                                                                    WorkPackageStatus.All,
                                                                                                    CheckItems.Select(m => (IDirective)m).ToList()));

            #region Добавление в список просроченных выполнений
            //и сравнение их с открытыми и опубликованными рабочими пакетами
            openPubWorkPackages.AddRange(allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Opened ||
                                                                               wp.Status == WorkPackageStatus.Published));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<WorkPackageRecord> openPubWPRecords = new List<WorkPackageRecord>();
            foreach (WorkPackage openWorkPackage in openPubWorkPackages)
                openPubWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

            //LINQ запрос для сортировки записей по дате
            List<NextPerformance> sortNextRecords = (from record in nextPerformances
                                                     orderby record.GetPerformanceDateOrDefault() descending
                                                     select record).ToList();

            for (int i = 0; i < sortNextRecords.Count; i++)
            {
                //поиск записи в рабочих пакетах по данному чеку
                //чей номер группы выполнения (по записи) совпадает с расчитанным
                MaintenanceCheck check = (MaintenanceCheck)sortNextRecords[i].Parent;

                //if (check.Name == "5C")
                //{
                    
                //}
                //номер выполнения
                int parentCountPerf;
                if (check.LastPerformance != null)
                {
                    parentCountPerf = check.LastPerformance.NumGroup <= 0
                        ? 1
                        : check.LastPerformance.NumGroup;
                }
                else parentCountPerf = 0;

                if(check.Grouping)
                {
                    MaintenanceNextPerformance mnp = sortNextRecords[i] as MaintenanceNextPerformance;
                    if (mnp != null)
                    {
                        parentCountPerf = mnp.PerformanceGroupNum;
                    }
                    else
                    {
                        parentCountPerf += check.NextPerformances.IndexOf(sortNextRecords[i]);
                        parentCountPerf += 1;       
                    }  
                }
                else
                {
                    parentCountPerf += check.NextPerformances.IndexOf(sortNextRecords[i]);
                    parentCountPerf += 1;   
                }

                WorkPackageRecord wpr =
                    openPubWPRecords.Where(r => r.PerformanceNumFromStart == parentCountPerf &&
                                             r.WorkPackageItemType == check.SmartCoreObjectType.ItemId &&
                                             r.DirectiveId == check.ItemId).FirstOrDefault();
                if (wpr != null)
                {
                    WorkPackage wp = openPubWorkPackages.GetItemById(wpr.WorkPakageId);
                    //запись о выполнении блокируется найденым пакетом
                    sortNextRecords[i].BlockedByPackage = wp;
                    //последующие записи о выполнении так же должны быть заблокированы
                    for (int j = i - 1; j >= 0; j--)
                    {
                        //блокировать нужно все рабочие записи, или до первой записи,
                        //заблокированной другим рабочим пакетом
                        if (sortNextRecords[j].BlockedByPackage != null && 
                            sortNextRecords[j].Parent == check ||
                            sortNextRecords[j].Condition != ConditionState.Overdue )
                            break;
                        if (sortNextRecords[j].Parent == check)
                        {
                            sortNextRecords[j].BlockedByPackage = wp;
                            listViewCompliance.Items[j].BackColor = Color.FromArgb(Highlight.GrayLight.Color);
                        }
                    }
                }
            
                string type = check.Schedule ? " (Schedule) " : " (Store) ";
                string resource = check.Resource.ToString();
                string grouping = check.Grouping ? " (Group)" : "";
                string stringNumGr = (sortNextRecords[i] is MaintenanceNextPerformance 
                    ? ((MaintenanceNextPerformance)sortNextRecords[i]).PerformanceGroupNum.ToString()
                    : "N/A") + type + resource + grouping;
                
                subs = new[]  { 
                                stringNumGr,
                                sortNextRecords[i].Title,
                                sortNextRecords[i].PerformanceDate != null 
                                       ? UsefulMethods.NormalizeDate((DateTime)sortNextRecords[i].PerformanceDate) 
                                       : "N/A",
                                sortNextRecords[i].PerformanceSource.ToString(),
                                "",
                              };
                newItem = new ListViewItem(subs)
                {
                    Group = listViewCompliance.Groups["next"],
                    Tag = sortNextRecords[i],
                    BackColor = UsefulMethods.GetColor(sortNextRecords[i])
                };

                listViewCompliance.Items.Add(newItem);
            }
            #endregion

            #region Добавление в список записей о произведенных выполнениях
            //и сравнение их с закрытыми рабочими пакетами
            closedWorkPackages.AddRange(allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Closed));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<WorkPackageRecord> closedWPRecords = new List<WorkPackageRecord>();
            foreach (WorkPackage closedWorkPackage in closedWorkPackages)
                closedWPRecords.AddRange(closedWorkPackage.WorkPakageRecords);

            List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

            foreach(MaintenanceCheckRecord record in lastRecords)
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
                            new MaintenanceCheckRecordGroup( record.ParentCheck.Schedule, record.ParentCheck.Grouping,
                                                             record.ParentCheck.Resource, record.NumGroup );
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

            List<object> tempRecords = new List<object>();
            tempRecords.AddRange(maintenanceCheckRecordGroups.ToArray());
            tempRecords.AddRange(_currentAircraft.MaintenanceProgramChangeRecords.ToArray());

            List<object> sortLastRecords = 
                tempRecords.OrderByDescending(tr => (tr is MaintenanceCheckRecordGroup 
                                                        ? ((MaintenanceCheckRecordGroup)tr).LastGroupComplianceDate 
                                                        : tr is AbstractRecord
                                                            ? ((AbstractRecord)tr).RecordDate
                                                            : DateTimeExtend.GetCASMinDateTime()))
                           .ToList();
            foreach (object t in sortLastRecords)
            {
                if(t is MaintenanceCheckRecordGroup)
                {
                    MaintenanceCheckRecordGroup mcrg = (MaintenanceCheckRecordGroup) t;
                    MaintenanceCheckRecord directiveRecord = mcrg.Records.First();
                    MaintenanceCheck parentDirective = (MaintenanceCheck)directiveRecord.Parent;
                    newItem = GetListViewItem(mcrg);

                    WorkPackage workPackage =
                        closedWorkPackages.Where(wp => wp.ItemId == directiveRecord.DirectivePackageId).FirstOrDefault();
                    if (workPackage != null)
                    {
                        //запись о выполнении блокируется найденым пакетом
                        directiveRecord.DirectivePackage = workPackage;
                        newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                        newItem.ToolTipText =
                            "Perform of the task:" + parentDirective.Name +
                            "\nadded by Work Package:" +
                            "\n" + directiveRecord.DirectivePackage.Title +
                            "\nTo remove a performance of task, you need to exclude task from this work package," +
                            "\nor delete the work package ";
                    }
                    listViewCompliance.Items.Add(newItem);    
                }
                else if(t is MaintenanceProgramChangeRecord)
                {
                    MaintenanceProgramChangeRecord mpcr = (MaintenanceProgramChangeRecord)t;
                    subs = new[]  
                              { 
                                "N/A",
                                "Changet to " + mpcr.MSG,
                                UsefulMethods.NormalizeDate(mpcr.RecordDate),
                                mpcr.OnLifelength.ToString(),
                                "",
                              };
                    newItem = new ListViewItem(subs)
                    {
                        Group = listViewCompliance.Groups["last"],
                        Tag = mpcr,
                        BackColor = Color.FromArgb(Highlight.GrayLight.Color)
                    };

                    listViewCompliance.Items.Add(newItem);  
                }
            }
            #endregion

            if (_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                {
                    item.Click -= AddToWorkPackageItemClick;
                }

                _toolStripMenuItemsWorkPackages.DropDownItems.Clear();

                foreach (WorkPackage workPackage in _openPubWorkPackages)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(workPackage.Title);
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = workPackage;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
                }
            }

            ButtonAdd.Enabled = false;
        }
        #endregion

        #region private ListViewItem GetListViewItem(IEnumerable<MaintenanceCheckRecord> grouping)

        private ListViewItem GetListViewItem(MaintenanceCheckRecordGroup grouping)
        {
            string name = "N/A";
            string type = "N/A";
            string resource = "N/A";
            string group = "N/A";
            string num = "N/A";
            string recordDate = "N/A";
            string performanceSource = "N/A";
            string remarksString = "N/A";
            Color backColor = Color.White;

            if (grouping.Records.Count > 0)
            {
                grouping.Sort();
                
                MaintenanceCheckRecord mcr = grouping.LastOrDefault();
                MaintenanceCheck mc = grouping.GetMaxIntervalCheck();
                
                type = mc.Schedule ? " (Schedule) " : " (Store) ";
                resource = mc.Resource.ToString();
                group = mc.Grouping ? " (Group)" : "";
                backColor = mc.Schedule ? Color.White : Color.Gainsboro;

                if(mcr != null)
                {
                    num = mc.Grouping ? mcr.NumGroup.ToString() : "N/A";
                    name = _currentAircraft != null && _currentAircraft.MaintenanceProgramCheckNaming
                                        ? (!string.IsNullOrEmpty(grouping.First().ComplianceCheckName)
                                               ? mcr.ComplianceCheckName
                                               : mc.Name)
                                        : mc.Name;
                    recordDate = UsefulMethods.NormalizeDate(mcr.RecordDate);
                    performanceSource = mcr.OnLifelength.ToRepeatIntervalsFormat();
                    remarksString = mcr.Remarks;

                    if(mc.Grouping)
                    {
                        MaintenanceProgramChangeRecord mpcr = mc.ParentAircraft != null
                            ? mc.ParentAircraft.MaintenanceProgramChangeRecords.
                              GetLastKnownRecord(Convert.ToDateTime(mcr.RecordDate))
                            : null;
                        if (mpcr == null || mpcr.MSG < MSG.MSG3)
                        {
                            var complianceItems = from compliance in grouping
                                                  orderby compliance.OnLifelength.Hours descending
                                                  select compliance;
                            name += " (" + complianceItems.Aggregate("", (current, compliance) => current + (compliance.ParentCheck.Name + " ")) + ")";
                        }    
                    }
                }
            }

            ListViewItem listViewItem = new ListViewItem(num + type + resource + group)
                                            {
                                                Tag = grouping.ToList(),
                                                Group = listViewCompliance.Groups["last"],
                                                BackColor = backColor
                                            };

            listViewItem.SubItems.Add(name);
            listViewItem.SubItems.Add(recordDate);
            listViewItem.SubItems.Add(performanceSource);
            listViewItem.SubItems.Add(remarksString);
            return listViewItem;
        }
        #endregion

        #region public MaintenanceCheckRecord[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив технических записей (DirectiveRecord)
        /// </summary>
        /// <returns>Массив технических записей (DirectiveRecord)</returns>
        public MaintenanceCheckRecord[] GetItemsArray()
        {
            return _allCompliance.ToArray();
        }
        #endregion

        #region private void Edit()
        private void Edit()
        {
            DialogResult dlgResult = DialogResult.None;
            if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["overdue"])
            {
                MaintenanceComplainceForm complainceForm = 
                    new MaintenanceComplainceForm(_currentAircraft, (MaintenanceCheckGroupByType)listViewCompliance.SelectedItems[0].Tag);
                dlgResult = complainceForm.ShowDialog(this);
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["next"])
            {
                if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
                {
                    NextPerformance np = (NextPerformance)listViewCompliance.SelectedItems[0].Tag;
                    //if (np.Condition != ConditionState.Overdue || np.PerformanceDate > DateTime.Now)
                    //{
                    //    MessageBox.Show("You can not enter a record for not delayed performance",
                    //                    (string)new GlobalTermsProvider()["SystemName"],
                    //                    MessageBoxButtons.OK,
                    //                    MessageBoxIcon.Warning,
                    //                    MessageBoxDefaultButton.Button1);
                    //    return;
                    //}
                    if (np.BlockedByPackage != null)
                    {
                        MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                                        "\nblocked by Work Package:" +
                                        "\n" + np.BlockedByPackage.Title,
                                        (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                if(listViewCompliance.SelectedItems[0].Tag is MaintenanceNextPerformance)
                {
                    MaintenanceNextPerformance mnp = listViewCompliance.SelectedItems[0].Tag as MaintenanceNextPerformance;
                    if (mnp.PerformanceGroup == null) return;
                    MaintenanceCheckGroupByType pg = mnp.PerformanceGroup;
                    MaintenanceComplainceForm complainceForm = new MaintenanceComplainceForm(_currentAircraft, pg);
                    dlgResult = complainceForm.ShowDialog(this);    
                }
                else if(listViewCompliance.SelectedItems[0].Tag is NextPerformance)
                {
                    NextPerformance np = listViewCompliance.SelectedItems[0].Tag as NextPerformance;
                    if (np.Parent == null) return;
                    MaintenanceComplainceForm complainceForm = new MaintenanceComplainceForm(_currentAircraft, np);
                    dlgResult = complainceForm.ShowDialog(this);      
                }
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["last"])
            {
                if (listViewCompliance.SelectedItems[0].Tag is List<MaintenanceCheckRecord>)
                {
                    MaintenanceComplainceForm complainceForm = 
                        new MaintenanceComplainceForm(_currentAircraft,(List<MaintenanceCheckRecord>)listViewCompliance.SelectedItems[0].Tag);
                    dlgResult = complainceForm.ShowDialog(this);
                }
                else if (listViewCompliance.SelectedItems[0].Tag is MaintenanceProgramChangeRecord)
                {
                    List<MaintenanceCheckRecord> records =
                CheckItems.Where(c => c.Grouping)
                          .SelectMany(c => c.PerformanceRecords)
                          .ToList();
                    List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

                    foreach (MaintenanceCheckRecord record in records)
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
                    MaintenanceProgramChangeDialog complainceForm =
                        new MaintenanceProgramChangeDialog((MaintenanceProgramChangeRecord) listViewCompliance.SelectedItems[0].Tag,
                                                           maintenanceCheckRecordGroups);
                    dlgResult = complainceForm.ShowDialog(this);
                }
                //MaintenanceComplainceForm complainceForm = new MaintenanceComplainceForm
                //{
                //    PerformanceRecords = ((List<MaintenanceCheckRecord>)
                //                     listViewCompliance.SelectedItems[0].Tag),
                //    CurrentAircraft = this.CurentAircraft,
                //    NumGroup = ((List<MaintenanceCheckRecord>)
                //        listViewCompliance.SelectedItems[0].Tag)[0].NumGroup
                //};
                // dlgResult = complainceForm.ShowDialog(this);
            }
            if(dlgResult == DialogResult.OK) InvokeComplianceAdded(null);
        }
        #endregion

        #region private void AddToWorkPackageItemClick(object sender, EventArgs e)

        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count <= 0 ||
                _currentAircraft == null) return;

            WorkPackage wp = (WorkPackage)((ToolStripMenuItem)sender).Tag;

            if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                List<NextPerformance> nextPerformances =
                    listViewCompliance.SelectedItems
                    .Cast<ListViewItem>()
                    .Where(lvi => lvi.Tag is NextPerformance)
                    .Select(lvi => lvi.Tag as NextPerformance)
                    .ToList();
                List<NextPerformance> bindedDirectivesPerformances = new List<NextPerformance>();
                foreach (NextPerformance wpItem in nextPerformances)
                {
                    if (wpItem is MaintenanceNextPerformance)
                    {
                        MaintenanceNextPerformance mnp = wpItem as MaintenanceNextPerformance;
                        if(mnp.PerformanceGroup.Checks.Count > 0)
                        {
                            foreach (MaintenanceCheck mc in mnp.PerformanceGroup.Checks)
                            {
                                foreach (MaintenanceDirective mpd in mc.BindMpds.Where(mpd => mpd.MaintenanceCheck != null &&
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
                                    if (nextPerformances.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                        bindedDirectivesPerformances.Add(performance);
                                }    
                            }     
                        }
                        else if (mnp.Parent is MaintenanceCheck)
                        {
                            MaintenanceCheck mc = mnp.Parent as MaintenanceCheck;
                            foreach (MaintenanceDirective mpd in mc.BindMpds.Where(mpd => mpd.MaintenanceCheck != null &&
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
                                if (nextPerformances.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                    bindedDirectivesPerformances.Add(performance);
                            }
                        }
                    }
                    else if (wpItem.Parent is MaintenanceCheck)
                    {
                        MaintenanceCheck mc = wpItem.Parent as MaintenanceCheck;
                        foreach (MaintenanceDirective mpd in mc.BindMpds.Where(mpd => mpd.MaintenanceCheck != null &&
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
                            if (nextPerformances.Count(wpi => wpi.Parent != null && wpi.Parent == mpd) == 0)
                                bindedDirectivesPerformances.Add(performance);
                        }
                    }
                }
                nextPerformances.AddRange(bindedDirectivesPerformances);

                if (nextPerformances.Count == 0)
                {
                    MessageBox.Show("Not select next compliance to adding", (string)new GlobalTermsProvider()["SystemName"],
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    string message;

                    if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(nextPerformances,
                                                                                  wp.ItemId,
                                                                                  _currentAircraft,
                                                                                  out message))
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (NextPerformance np in nextPerformances)
                    {
                        np.BlockedByPackage = wp;
                        UpdateItemColor(np);
                    }

                    if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        ReferenceEventArgs refArgs = new ReferenceEventArgs();
                        refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        refArgs.DisplayerText = _currentAircraft + "." + wp.Title;
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

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                return;
            }

            Edit();
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            Edit();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0 ||
                listViewCompliance.SelectedItems[0].Group != listViewCompliance.Groups["last"] ||
                (!(listViewCompliance.SelectedItems[0].Tag is List<MaintenanceCheckRecord>) &&
                 !(listViewCompliance.SelectedItems[0].Tag is MaintenanceProgramChangeRecord))) return;

            if(listViewCompliance.SelectedItems[0].Tag is List<MaintenanceCheckRecord>)
            {
                List<MaintenanceCheckRecord> records = (List<MaintenanceCheckRecord>)listViewCompliance.SelectedItems[0].Tag;
                if (records.Any(r => r.DirectivePackage != null))
                {
                    MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                                    "\nadded by Work Package:" +
                                    "\n" + records.First(r => r.DirectivePackage != null).DirectivePackage.Title +
                                    "\nTo remove a performance of task, you need to exclude task from this work package," +
                                    "\nor delete the work package ",
                                    (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                    return;
                }
                switch (MessageBox.Show(@"Delete this compliance " + " ?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        foreach (MaintenanceCheckRecord record in records)
                        {
                            GlobalObjects.MaintenanceCore.Delete(record);
                        }
                        InvokeComplianceAdded(null);
                        break;
                    case DialogResult.No:
                        //arguments.Cancel = true;
                        break;
                }   
            }
            else if (listViewCompliance.SelectedItems[0].Tag is MaintenanceProgramChangeRecord)
            {
                MaintenanceProgramChangeRecord record = (MaintenanceProgramChangeRecord)listViewCompliance.SelectedItems[0].Tag;
                switch (MessageBox.Show(@"Delete this Maintenance program change record ?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.CasEnvironment.Manipulator.Delete(record);
                        InvokeComplianceAdded(null);
                        break;
                    case DialogResult.No:
                        //arguments.Cancel = true;
                        break;
                } 
            }
        }
        #endregion

        #region private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        {
            List<MaintenanceCheckRecord> records = 
                CheckItems.Where(c => c.Grouping)
                          .SelectMany(c => c.PerformanceRecords)
                          .ToList();
            List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

            foreach (MaintenanceCheckRecord record in records)
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

            MaintenanceProgramChangeDialog actualStateDialog =
                new MaintenanceProgramChangeDialog(_currentAircraft, maintenanceCheckRecordGroups) 
                { Text = "Add new Maintenance program change record" };

            actualStateDialog.ShowDialog();
            if (actualStateDialog.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);
        }
        #endregion

        #region private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                return;
            }

            Edit();
        }
        #endregion

        #region private void ListViewComplianceClick(object sender, EventArgs e)
        private void ListViewComplianceClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = false;
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["overdue"])
            {
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = true;    
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["next"])
            {
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = true;
            }
            else if (listViewCompliance.SelectedItems[0].Group == listViewCompliance.Groups["last"])
            {
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = true;
                ButtonEdit.Enabled = true;
            }
        }
        #endregion

        #endregion
    }
}
