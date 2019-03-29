using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceGeneralDateControl : UserControl, IReference
    {

        #region Fields

        private List<ListViewGroup> _listViewGroups = new List<ListViewGroup>();
        private Aircraft _currentAircraft;
        private List<MaintenanceDirective> _mpdForSelect;
        private List<MaintenanceDirective> _allDirectives = new List<MaintenanceDirective>();
        private List<Lifelength> _maintenanceDirectivesIntervals = new List<Lifelength>();

        private MaintenanceCheckCollection _maintenanceChecks;
        
        #endregion

        #region Properties

        public MaintenanceCheckCollection CheckItems
        {
            get { return _maintenanceChecks; }
            set
            {
                if (_maintenanceChecks != null && _maintenanceChecks != value)
                {
                    _maintenanceChecks.CollectionChanged -= LimitationItemsCollectionChanged;
                    foreach (MaintenanceCheck checkItem in _maintenanceChecks)
                    {
                        checkItem.PropertyChanged -= LiminationItemPropertyChanged;
                    }
                }
                if (_maintenanceChecks != value)
                {
                    _maintenanceChecks = value;

                    if (_maintenanceChecks != null)
                    {
                        _maintenanceChecks.CollectionChanged += LimitationItemsCollectionChanged;
                        foreach (MaintenanceCheck liminationItem in value)
                        {
                            liminationItem.PropertyChanged += LiminationItemPropertyChanged;
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

        #region Collection changet methods

        void LimitationItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e == null)
                return;
            if (e.Action==NotifyCollectionChangedAction.Add)
            {
                foreach (MaintenanceCheck newItem in e.NewItems)
                {
                    newItem.PropertyChanged += LiminationItemPropertyChanged;
                    AddCheckItem(newItem);
                }
            }
            else
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (MaintenanceCheck oldItem in e.OldItems)
                {
                    oldItem.PropertyChanged -= LiminationItemPropertyChanged;
                    RemoveCheckItem(oldItem);
                }
            }
        }

        void LiminationItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender!=null)
            {
                UpdateCheckItem((MaintenanceCheck)sender);
            }
        }

        #endregion

        #region Initialize
        ///<summary>
        ///</summary>
        public MaintenanceGeneralDateControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Metods

        #region public void UpdateInformation(MaintenanceCheckCollection liminationItems, Aircraft aircraft, List<MaintenanceDirective> maintenanceDirectives)

        /// <summary>
        /// Перезагружает данные с БД
        /// </summary>
        public void UpdateInformation(MaintenanceCheckCollection liminationItems, Aircraft aircraft, List<MaintenanceDirective> maintenanceDirectives)
        {
            _currentAircraft = aircraft;

            comboBoxCheckNaming.SelectedIndexChanged -= ComboBoxCheckNamingSelectedIndexChanged;
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            comboBoxSchedule.SelectedIndexChanged -= ComboBoxScheduleSelectedIndexChanged;

            comboBoxCheckNaming.SelectedIndex = _currentAircraft.MaintenanceProgramCheckNaming ? 1 : 0;
            comboBoxSchedule.SelectedIndex = _currentAircraft.Schedule ? 0 : 1;
            checkedListBoxItems.Items.Clear();
            listViewBindedTasks.ItemListView.Items.Clear();
            listViewTasksForSelect.ItemListView.Items.Clear();

            CheckItems = liminationItems;
            _allDirectives = maintenanceDirectives;
            _mpdForSelect = _allDirectives.Where(mpd => mpd.MaintenanceCheck == null).ToList();
            listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
            
            FillCheck();
            GetMaintenanceDirectivesIntervals();
            ListViewMaintenanceChecksSelectedIndexChanged(null, null);

            comboBoxCheckNaming.SelectedIndexChanged += ComboBoxCheckNamingSelectedIndexChanged;
            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;
            comboBoxSchedule.SelectedIndexChanged += ComboBoxScheduleSelectedIndexChanged;
        }
        #endregion

        #region private void GetMaintenanceDirectivesIntervals()
        private void GetMaintenanceDirectivesIntervals()
        {
            if (_allDirectives == null)
                return;
            if (_maintenanceDirectivesIntervals != null)
                _maintenanceDirectivesIntervals.Clear();

            IEnumerable<Lifelength> tempIntervals =
                _allDirectives
                    .Where(mpd => !mpd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                    .Select(mpd => mpd.Threshold.FirstPerformanceSinceNew)
					.Concat(_allDirectives.Where(mpd => !mpd.Threshold.RepeatInterval.IsNullOrZero())
					.Select(mpd => mpd.Threshold.RepeatInterval))
                    .Distinct()
                    .OrderBy(l => l)
                    .ToList();
            //Интервалы, содержащие только часы
            IEnumerable<Lifelength> intervalsGroupHours =
                tempIntervals.Where(i => i.Hours != null
                                      && i.Cycles == null
                                      && i.Days == null);
            //Интервалы, содержащие только циклы
            IEnumerable<Lifelength> intervalsGroupCycles =
                tempIntervals.Where(i => i.Hours == null
                                      && i.Cycles != null
                                      && i.Days == null);
            //Интервалы, содержащие только дни
            IEnumerable<Lifelength> intervalsGroupDays =
                tempIntervals.Where(i => i.Hours == null
                                      && i.Cycles == null
                                      && i.Days != null);
            //Интервалы, содержащие часы/циклы
            IEnumerable<Lifelength> intervalsGroupHoursCycles =
                tempIntervals.Where(i => i.Hours != null
                                      && i.Cycles != null
                                      && i.Days == null);
            //Интервалы, содержащие часы/дни
            IEnumerable<Lifelength> intervalsGroupHoursDays =
                tempIntervals.Where(i => i.Hours != null
                                      && i.Cycles == null
                                      && i.Days != null);
            //Интервалы, содержащие только циклы/дни
            IEnumerable<Lifelength> intervalsGroupCyclesDays =
                tempIntervals.Where(i => i.Hours == null
                                      && i.Cycles != null
                                      && i.Days != null);
            //Интервалы, содержащие часы/циклы/дни
            IEnumerable<Lifelength> intervalsGroupAll =
                tempIntervals.Where(i => i.Hours != null
                                      && i.Cycles != null
                                      && i.Days != null);
            
            _maintenanceDirectivesIntervals = new List<Lifelength>();
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHours);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupCycles);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursCycles);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupCyclesDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupAll);

            Action addNotApplicable = () => checkedListBoxItems.Items.Add(Lifelength.Null, true);
            if (InvokeRequired)
                Invoke(addNotApplicable);
            else addNotApplicable.Invoke();

            foreach (Lifelength firstPerformance in _maintenanceDirectivesIntervals)
            {
                if (firstPerformance.IsNullOrZero())
                    continue;

                Action<Lifelength> addLast = s => checkedListBoxItems.Items.Add(s, true);
                if (InvokeRequired)
                {
                    Invoke(addLast, firstPerformance);
                }
                else addLast.Invoke(firstPerformance);
            }

        }
        #endregion

        #region Fill

        #region Check

        private void FillCheck()
        {
            _listViewGroups.Clear();
            listViewMaintenanceChecks.Items.Clear(); 
            listViewMaintenanceChecks.Groups.Clear();

            foreach (MaintenanceCheck item in _maintenanceChecks)
            {
                if (item.IsDeleted == false)
                {
                    listViewMaintenanceChecks.Items.Add(GetListViewItem(item));
                }
            }

            _listViewGroups.Sort(new Comparison<ListViewGroup>((x, y) => string.Compare(x.Name, y.Name)));
            listViewMaintenanceChecks.Groups.Clear();
            listViewMaintenanceChecks.Groups.AddRange(_listViewGroups.ToArray());
        }

        void AddCheckItem(MaintenanceCheck item)
        {
            if (item.IsDeleted==false)
            {
                listViewMaintenanceChecks.Items.Add(GetListViewItem(item));
            } 
        }

        void RemoveCheckItem(MaintenanceCheck item)
        {
            foreach (ListViewItem item1 in listViewMaintenanceChecks.Items)
            {
                if (item1.Tag == item)
                {
                    listViewMaintenanceChecks.Items.Remove(item1);
                    break;
                }
            }
        }

        void UpdateCheckItem(MaintenanceCheck item)
        {
            foreach (ListViewItem item1 in listViewMaintenanceChecks.Items)
            {
                if (item1.Tag==item)
                {
                    ListViewItem listViewItem = GetListViewItem(item);
                    item1.Group = listViewItem.Group;

                    item1.Text = listViewItem.Text;
                    item1.SubItems[0] = listViewItem.SubItems[0];
                    item1.SubItems[1] = listViewItem.SubItems[1];
                    item1.SubItems[2] = listViewItem.SubItems[2];
                    item1.SubItems[3] = listViewItem.SubItems[3];
                    item1.SubItems[4] = listViewItem.SubItems[4];
                }
            }

            _listViewGroups.Sort(new Comparison<ListViewGroup>((x,y)=> string.Compare(x.Name,y.Name)));
            listViewMaintenanceChecks.Groups.Clear();
            listViewMaintenanceChecks.Groups.AddRange(_listViewGroups.ToArray());
        }

        ListViewItem GetListViewItem(MaintenanceCheck item)
        {
            ListViewItem listViewItem = new ListViewItem { Tag = item, Text = item.Name };
            listViewItem.SubItems.Add(item.Interval.ToRepeatIntervalsFormat());
            listViewItem.SubItems.Add(item.Notify.ToRepeatIntervalsFormat());
            listViewItem.SubItems.Add(item.Cost.ToString());
            listViewItem.SubItems.Add(item.ManHours.ToString());
            listViewItem.SubItems.Add(item.Kits.Count + " kits");
            listViewItem.Group = GetGroup(item);
            return listViewItem;
        }

        #region private ListViewGroup GetGroup(MaintenanceCheck item)

        private ListViewGroup GetGroup(MaintenanceCheck item)
        {
            string type = item.Schedule ? " (Schedule) " : " (Store) ";
            string resource = item.Resource.ToString();
            string grouping = item.Grouping ? " (Group)" : "";
            foreach (ListViewGroup group in listViewMaintenanceChecks.Groups)
            {
                if (group.Header == item.CheckType.FullName + type + resource + grouping)
                {
                    return group;
                }
            }

            string key = string.Format("{0}{1}{2}{3}", item.Schedule ? "1" : "2",
                                                       ((int)item.Resource),
                                                       item.Grouping ? "1" : "2",
                                                       item.CheckType.Priority);
            ListViewGroup listViewGroup = new ListViewGroup(key, item.CheckType.FullName + type + resource + grouping); 
            listViewMaintenanceChecks.Groups.Add(listViewGroup);
            _listViewGroups.Add(listViewGroup);
            return listViewGroup;
        }
        #endregion

        #endregion

        #endregion

        #region Maintenance Checks

        #region private void AddCheck()
        private void AddCheck()
        {
            MaintenanceCheck cas3MaintenanceLiminationItem = 
                new MaintenanceCheck { ParentAircraft = _currentAircraft, ParentAircraftId = _currentAircraft.ItemId };
            
            MaintenanceCheckEdit temp = new MaintenanceCheckEdit(cas3MaintenanceLiminationItem);
            
            temp.ShowDialog(this);
            
            if (cas3MaintenanceLiminationItem.ItemId!=-1)
            {
                _maintenanceChecks.Add(cas3MaintenanceLiminationItem);
            }
        }
        #endregion

        #region private void EditCheck()
        /// <summary>
        /// 
        /// </summary>
        private void EditCheck()
        {
            MaintenanceCheck mc;
            if (listViewMaintenanceChecks.SelectedItems.Count > 0)
                mc = (MaintenanceCheck)listViewMaintenanceChecks.SelectedItems[0].Tag;
            else
            {
                return;
            }

            MaintenanceCheckEdit temp = new MaintenanceCheckEdit(mc);
            temp.ShowDialog(this);
        }
        #endregion

        #region private void DeleteCheck()
        /// <summary>
        /// Удаляет выбранный чек
        /// </summary>
        private void DeleteCheck()
        {
            object item;
            if (listViewMaintenanceChecks.SelectedItems.Count > 0)
                item = listViewMaintenanceChecks.SelectedItems[0].Tag;
            else
            {
                return;
            }

            if (MessageBox.Show("Do you really want to delete selected item?", "", MessageBoxButtons.YesNo) ==
                DialogResult.No)
            {
                return;
            }

            GlobalObjects.CasEnvironment.Manipulator.Delete((MaintenanceCheck) item);
            _maintenanceChecks.Remove(((MaintenanceCheck) item));
        }
        #endregion

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
           AddCheck();
        }
        
        private void EditToolStripMenuItemClick(object sender, EventArgs e)
        {
            EditCheck();
        } 
        
        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            DeleteCheck();
        }

        private void AvButtonAddClick(object sender, EventArgs e)
        {
            AddCheck();
        }

        private void AvButtonEditClick(object sender, EventArgs e)
        {
            EditCheck();
        }

        private void AvButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteCheck();
        }

        private void ContextMenuStripLimitationOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewMaintenanceChecks.SelectedItems.Count == 0)
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }
        
        #endregion

        #region private void AddJobCard()
        private void AddJobCard()
        {
            if (listViewMaintenanceChecks.SelectedItems.Count==0)
            {
                MessageBox.Show("Indicate Maintenance Check", 
                                (string)new GlobalTermsProvider()["SystemName"], 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                return;
            }
            if (listViewTasksForSelect.SelectedItems.Count == 0)
            {
                MessageBox.Show("Indicate Tasks for bind to Check",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            MaintenanceCheck maintenanceCheck = (MaintenanceCheck)listViewMaintenanceChecks.SelectedItems[0].Tag;

            foreach (BaseEntityObject selectedItem in listViewTasksForSelect.SelectedItems)
            {
                MaintenanceDirective dir = selectedItem as MaintenanceDirective;
                if (dir == null)
                    continue;

                try
                {
                    dir.MaintenanceCheck = maintenanceCheck;

                    GlobalObjects.CasEnvironment.NewKeeper.Save(dir, false);

                    maintenanceCheck.BindMpds.Add(dir);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while save bind task record", ex);
                }
            }

            listViewBindedTasks.SetItemsArray(_allDirectives.Where(mpd => maintenanceCheck.Equals(mpd.MaintenanceCheck)).ToArray());

            _mpdForSelect = _allDirectives.Where(mpd => mpd.MaintenanceCheck == null).ToList();

            listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
        }

        #endregion

        #region private void EditBindedDirective()
        private void EditBindedDirective()
        {
            if (listViewBindedTasks.SelectedItems.Count == 0 && listViewTasksForSelect.SelectedItems.Count == 0)
            {
                MessageBox.Show("Indicate MPD Item(s)", 
                                (string)new GlobalTermsProvider()["SystemName"], 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                return;
            }

            List<MaintenanceDirective> selectedMpds =
                listViewBindedTasks.SelectedItems.OfType<MaintenanceDirective>().ToList();
            selectedMpds.AddRange(listViewTasksForSelect.SelectedItems.OfType<MaintenanceDirective>());

            foreach (MaintenanceDirective directive in selectedMpds)
            {
                try
                {
                    var refe = new ReferenceEventArgs();
	                var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(directive);
					refe.SetParameters(dp);
                    InvokeDisplayerRequested(refe);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("error while open MPD Item", ex);
                }  
            }
        }
		#endregion

		#region private void ViewJobCard(AttachedFile file)
		private void ViewJobCard(MaintenanceDirective selectedMpd, AttachedFile attachedFile)
        {
			if (attachedFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				return;
			}

			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(attachedFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
									MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				var errorDescriptionSctring = $"Error while Open Attached File for {selectedMpd}, id {selectedMpd.ItemId}. \nFileId {attachedFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}
        #endregion

        #region  private void AvButtonAddJobCardClick(object sender, EventArgs e)
        private void AvButtonAddJobCardClick(object sender, EventArgs e)
        {
             AddJobCard();
        }
        #endregion

        #region private void AvButtonEditJobCardClick(object sender, EventArgs e)
        private void AvButtonEditJobCardClick(object sender, EventArgs e)
        {
            EditBindedDirective();
        }
        #endregion

        #region private void AvButtonViewJobCardClick(object sender, EventArgs e)
        private void AvButtonViewJobCardClick(object sender, EventArgs e)
        {
            if (listViewTasksForSelect.SelectedItems.OfType<MaintenanceDirective>().Count() != 0)
            {
                var mpd = listViewTasksForSelect.SelectedItems.OfType<MaintenanceDirective>().First();
                ViewJobCard(mpd, mpd.TaskCardNumberFile);
            }
            else if (listViewBindedTasks.SelectedItems.OfType<MaintenanceDirective>().Count() != 0)
            {
                var mpd = listViewBindedTasks.SelectedItems.OfType<MaintenanceDirective>().First();
                ViewJobCard(mpd, mpd.TaskCardNumberFile);
            }
        }
        #endregion

        #region private void ComboBoxCheckNamingSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxCheckNamingSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentAircraft.MaintenanceProgramCheckNaming = comboBoxCheckNaming.SelectedIndex > 0;
            GlobalObjects.CasEnvironment.NewKeeper.Save(_currentAircraft);
        }

        #endregion

        #region private void ComboBoxScheduleSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxScheduleSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentAircraft.Schedule = comboBoxSchedule.SelectedIndex == 0;
            GlobalObjects.CasEnvironment.NewKeeper.Save(_currentAircraft);
        }

        #endregion

        #region private void ListViewMaintenanceChecksSelectedIndexChanged(object sender, EventArgs e)

        private void ListViewMaintenanceChecksSelectedIndexChanged(object sender, EventArgs e)
        {
            avButtonViewJobCard.Enabled = false;
            avButtonEditJobCard.Enabled = false;

            MaintenanceCheck mc = null;

            if (listViewMaintenanceChecks.SelectedItems.Count == 0)
            {
                avButtonEditCheck.Enabled = false;
                avButtonDeleteCheck.Enabled = false;
                avButtonAddJobCard.Enabled = false;
            }
            else
            {
                avButtonEditCheck.Enabled = true;
                avButtonDeleteCheck.Enabled = true;
                avButtonAddJobCard.Enabled = true;

                mc = listViewMaintenanceChecks.SelectedItems[0].Tag as MaintenanceCheck;
            }

            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
                checkedListBoxItems.SetItemChecked(i, true);
            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

            List<MaintenanceDirective> mpdWithBindedCheck = new List<MaintenanceDirective>();
            if (mc != null)
                mpdWithBindedCheck.AddRange(_allDirectives.Where(mpd => mc.Equals(mpd.MaintenanceCheck)));
            listViewBindedTasks.SetItemsArray(mpdWithBindedCheck.ToArray());
        }
        #endregion

        #region private void ListViewMaintenanceChecksMouseDoubleClick(object sender, MouseEventArgs e)

        private void ListViewMaintenanceChecksMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewMaintenanceChecks.SelectedItems.Count == 0)
                return;
            EditCheck();
        }
        #endregion

        #region private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;

            for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
            {
                checkedListBoxItems.SetItemChecked(i, checkBoxSelectAll.Checked);
            }

            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

            CheckedListBoxItemsSelectedIndexChanged(null, EventArgs.Empty);
        }
        #endregion

        #region private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)
        private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxItems.CheckedItems.Count == 0)
            {
                listViewTasksForSelect.ItemListView.Items.Clear();
            }

            IEnumerable<Lifelength> intervals =
                checkedListBoxItems.CheckedItems.OfType<Lifelength>();
            List<MaintenanceDirective> mpdWithInterval = new List<MaintenanceDirective>();
            mpdWithInterval
                .AddRange(_mpdForSelect
                              .Where(mpd => intervals.Any(interval => mpd.Threshold.FirstPerformanceSinceNew != null
                                                                   && mpd.Threshold.FirstPerformanceSinceNew.Equals(interval)
																   || mpd.Threshold.RepeatInterval.Equals(interval))));
            listViewTasksForSelect.SetItemsArray(mpdWithInterval.ToArray());
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewMaintenanceChecks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Indicate Maintenance Check",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (listViewBindedTasks.SelectedItems.Count == 0)
                return;

            MaintenanceCheck maintenanceCheck = (MaintenanceCheck)listViewMaintenanceChecks.SelectedItems[0].Tag;

            foreach (BaseEntityObject selectedItem in listViewBindedTasks.SelectedItems)
            {
                MaintenanceDirective dir = selectedItem as MaintenanceDirective;
                if (dir == null)
                    continue;

                try
                {
                    dir.MaintenanceCheck = null;

                    GlobalObjects.CasEnvironment.NewKeeper.Save(dir, false);

                    maintenanceCheck.BindMpds.RemoveById(dir.ItemId);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while delete bind task record", ex);
                }
            }

            listViewBindedTasks.SetItemsArray(_allDirectives.Where(mpd => maintenanceCheck.Equals(mpd.MaintenanceCheck)).ToArray());

            _mpdForSelect = _allDirectives.Where(mpd => mpd.MaintenanceCheck == null).ToList();

            listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
        }
        #endregion

        #region private void ListViewBindedTasksSelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void ListViewBindedTasksSelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
        {
            buttonDelete.Enabled = listViewBindedTasks.SelectedItems.Count > 0;
            avButtonViewJobCard.Enabled = listViewBindedTasks.SelectedItems.Count > 0 ||
                                          listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #region private void ListViewTasksForSelectSelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void ListViewTasksForSelectSelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
        {
            avButtonAddJobCard.Enabled = listViewTasksForSelect.SelectedItems.Count > 0;
            avButtonViewJobCard.Enabled = listViewBindedTasks.SelectedItems.Count > 0 ||
                                          listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #endregion

    }
}
