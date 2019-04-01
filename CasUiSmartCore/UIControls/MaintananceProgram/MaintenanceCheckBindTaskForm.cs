using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class MaintenanceCheckBindTaskForm : Form
    {

        #region Fields

        private CommonCollection<MaintenanceDirective> _bindedDirectives = new CommonCollection<MaintenanceDirective>();
        private IEnumerable<MaintenanceDirective> _mpdForSelect;
        private IEnumerable<MaintenanceDirective> _allDirectives;
        private readonly MaintenanceCheck _maintenanceCheck;
        private Aircraft _currentAircraft;
        private List<Lifelength> _maintenanceDirectivesIntervals = new List<Lifelength>();

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Constructors

        #region private MaintenanceCheckBindTaskForm()

        /// <summary>
        /// Создает форму для создания жесткой связи между чеками программы обслуживания и задачами программы обслуживания
        /// </summary>
        private MaintenanceCheckBindTaskForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceCheckBindTaskForm(MaintenanceCheck maintenanceCheck) : this()

        /// <summary>
        /// Создает форму для привязки задач к выполнению чека программы обслуживания
        /// </summary>
        public MaintenanceCheckBindTaskForm(MaintenanceCheck maintenanceCheck, IEnumerable<MaintenanceDirective> allDirectives)
            : this()
        {
            if (maintenanceCheck == null)
                throw new ArgumentNullException("maintenanceCheck", "must be not null");
            if (allDirectives == null)
                throw new ArgumentNullException("allDirectives", "must be not null");

            _maintenanceCheck = maintenanceCheck;
            _currentAircraft = maintenanceCheck.ParentAircraft;
            _allDirectives = allDirectives;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            checkedListBoxItems.Items.Clear();

            GetMaintenanceDirectivesIntervals();

            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

            listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
            listViewBindedTasks.SetItemsArray((IEnumerable<BaseEntityObject>) _bindedDirectives);
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_maintenanceCheck == null || _currentAircraft == null)
            {
                e.Cancel = true;
                return;
            }

            if (_bindedDirectives == null)
                _bindedDirectives = new CommonCollection<MaintenanceDirective>();
            _bindedDirectives.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");

            _bindedDirectives.AddRange(_maintenanceCheck.BindMpds.ToArray());
            _mpdForSelect = _allDirectives.Where(mpd => mpd.MaintenanceCheck == null);

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void ButtonCloseClick(object sender, EventArgs e)

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            if(listViewTasksForSelect.SelectedItems.Count == 0)
                return;

            foreach (BaseEntityObject selectedItem in listViewTasksForSelect.SelectedItems)
            {
                MaintenanceDirective dir = selectedItem as MaintenanceDirective;
                if (dir == null)
                    continue;

                try
                {
                    dir.MaintenanceCheck = _maintenanceCheck;

                    GlobalObjects.CasEnvironment.NewKeeper.Save(dir, false);
                   
                    _maintenanceCheck.BindMpds.Add(dir);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while save bind task record", ex);
                }
            }

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewBindedTasks.SelectedItems.Count == 0)
                return;

            foreach (BaseEntityObject selectedItem in listViewBindedTasks.SelectedItems)
            {
                MaintenanceDirective dir = selectedItem as MaintenanceDirective;
                if (dir == null)
                    continue;

                try
                {
                    dir.MaintenanceCheck = null;

                    GlobalObjects.CasEnvironment.NewKeeper.Save(dir, false);

                    _maintenanceCheck.BindMpds.RemoveById(dir.ItemId);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while delete bind task record", ex);
                }
            }

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        #region private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        {
            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonAdd.Enabled = listViewTasksForSelect.SelectedItems.Count > 0;
            avButtonViewJobCard.Enabled = listViewBindedTasks.SelectedItems.Count > 0 ||
                                          listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #region private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonDelete.Enabled = listViewBindedTasks.SelectedItems.Count > 0;
            avButtonViewJobCard.Enabled = listViewBindedTasks.SelectedItems.Count > 0 ||
                                          listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #region private void GetMaintenanceDirectivesIntervals()
        private void GetMaintenanceDirectivesIntervals()
        {
            if (_mpdForSelect == null)
                return;
            if (_maintenanceDirectivesIntervals != null)
                _maintenanceDirectivesIntervals.Clear();

            IEnumerable<Lifelength> tempIntervals =
                _mpdForSelect
                    .Where(mpd => !mpd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                    .Select(mpd => mpd.Threshold.FirstPerformanceSinceNew)
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

            _maintenanceDirectivesIntervals = new List<Lifelength> {  Lifelength.Null };
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHours);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupCycles);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursCycles);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupCyclesDays);
            _maintenanceDirectivesIntervals.AddRange(intervalsGroupAll);

            foreach (Lifelength firstPerformance in _maintenanceDirectivesIntervals)
            {
                Action<Lifelength> addLast = s => checkedListBoxItems.Items.Add(s, true);
                if (InvokeRequired)
                {
                    Invoke(addLast, firstPerformance);
                }
                else addLast.Invoke(firstPerformance);
            }

        }
        #endregion

        #region private void ViewJobCard(AttachedFile file)
        private void ViewJobCard(MaintenanceDirective selectedMpd, AttachedFile attachedFile)
        {
	        if (attachedFile == null)
	        {
				MessageBox.Show("Not set Job Card File", (string)new GlobalTermsProvider()["SystemName"],
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
                                                                   && mpd.Threshold.FirstPerformanceSinceNew.Equals(interval))));
            listViewTasksForSelect.SetItemsArray(mpdWithInterval.ToArray());
        }
        #endregion

        #endregion
    }

}