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
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.MaintananceProgram
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class MaintenanceCheckBindTaskInWPForm : Form
    {

        #region Fields

        private CommonCollection<MaintenanceCheckBindTaskRecord> _records = new CommonCollection<MaintenanceCheckBindTaskRecord>();
        private CommonCollection<BaseEntityObject> _recordsTasks = new CommonCollection<BaseEntityObject>();
        private CommonCollection<MaintenanceDirective> _mpdForSelect = new CommonCollection<MaintenanceDirective>();
        private readonly MaintenanceCheck _maintenanceCheck;
        private IEnumerable<MaintenanceCheck> _allWpChecks;
        private WorkPackage _workPackage;
        private Aircraft _currentAircraft;

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Constructors

        #region private MaintenanceCheckBindTaskForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        private MaintenanceCheckBindTaskInWPForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceCheckBindTaskForm(MaintenanceCheck maintenanceCheck) : this()

        /// <summary>
        /// Создает форму для привязки задач к выполнению чека программы обслуживания
        /// </summary>
        public MaintenanceCheckBindTaskInWPForm(MaintenanceCheck maintenanceCheck, 
                                            IEnumerable<MaintenanceCheck> allWpChecks, 
                                            WorkPackage workPackage)
            : this()
        {
            if (maintenanceCheck == null)
                throw new ArgumentNullException("maintenanceCheck", "must be not null");
            if (workPackage == null)
                throw new ArgumentNullException("workPackage", "must be not null");
            _maintenanceCheck = maintenanceCheck;
            _currentAircraft = maintenanceCheck.ParentAircraft;
            _workPackage = workPackage;
            
            if (allWpChecks != null && allWpChecks.Count() > 0)
                _allWpChecks = allWpChecks;
            else _allWpChecks = new List<MaintenanceCheck> { maintenanceCheck };

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
            listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
            listViewBindedTasks.SetItemsArray(_recordsTasks.ToArray());
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

            if(_records == null)
                _records = new CommonCollection<MaintenanceCheckBindTaskRecord>();
            _records.Clear();

            if (_recordsTasks == null)
                _recordsTasks = new CommonCollection<BaseEntityObject>();
            _recordsTasks.Clear();

            if (_mpdForSelect == null)
                _mpdForSelect = new CommonCollection<MaintenanceDirective>();
            _mpdForSelect.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");

            var preResult = new List<MaintenanceCheckBindTaskRecord>();
            try
            {
                preResult.AddRange(GlobalObjects.WorkPackageCore.GetMaintenanceBingTasksRecords(_workPackage.ItemId));
                _records.AddRange(preResult.Where(r=>r.CheckId == _maintenanceCheck.ItemId));
                _recordsTasks.AddRange(_records.Where(r => r.Task != null && r.Task is BaseEntityObject).Select(r => r.Task as BaseEntityObject));
                if(_maintenanceCheck.Grouping)
                {
                    MaintenanceNextPerformance mnp = _maintenanceCheck.GetNextPergormanceGroupWhereCheckIsSenior();
                    if(mnp != null && mnp.PerformanceGroup != null && mnp.PerformanceGroup.Checks.Count > 0)
                    {
                        _recordsTasks.AddRange(mnp.PerformanceGroup.Checks.SelectMany(mc => mc.BindMpds).ToArray());    
                    }
                    else _recordsTasks.AddRange(_maintenanceCheck.BindMpds.ToArray());
                }
                else _recordsTasks.AddRange(_maintenanceCheck.BindMpds.ToArray());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Maintenance check bing tasks records", ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(50, "calculation of Maintenance Directives");

            try
            {
                _mpdForSelect.AddRange(_workPackage.MaintenanceDirectives);
                _mpdForSelect.AddRange(_workPackage.ComponentDirectives.Where(dd => dd.MaintenanceDirective != null)
                                                                    .Select(dd => dd.MaintenanceDirective).Distinct());
                foreach (MaintenanceCheckBindTaskRecord record in preResult.Where(record => record.TaskType == SmartCoreType.MaintenanceDirective && 
                                                                                            _mpdForSelect.FirstOrDefault(m => m.ItemId == record.TaskId) != null))
                {
                    _mpdForSelect.RemoveById(record.TaskId);
                }
                foreach (MaintenanceDirective mpd in _allWpChecks.SelectMany(mc => mc.BindMpds))
                    _mpdForSelect.RemoveById(mpd.ItemId); 

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load directives for select", ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(75, "calculate directives for select");

            //try
            //{
            //    _mpdForSelect.AddRange(GlobalObjects.CasEnvironment.Loader.GetMaintenanceDirectives(_maintenanceCheck.ParentAircraft));
            //}
            //catch (Exception ex)
            //{
            //    Program.Provider.Logger.Log("Error while calculate directives for select", ex);
            //}

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

            foreach (var selectedItem in listViewTasksForSelect.SelectedItems)
            {
                IDirective dir = selectedItem as IDirective;
                if (dir == null)
                    continue;
                
                var record = new MaintenanceCheckBindTaskRecord
                {
                    TaskType = dir.SmartCoreObjectType,
                    TaskId = dir.ItemId,
                    Task = dir,
                    WorkPackageId = _workPackage.ItemId,
                    CheckId = _maintenanceCheck.ItemId,
                    ParentCheck = _maintenanceCheck
                };

                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Save(record);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while save bind task record", ex);
                }

                _mpdForSelect.RemoveById(dir.ItemId);
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
                MaintenanceCheckBindTaskRecord record = 
                    _records.FirstOrDefault(r => r.TaskId == selectedItem.ItemId &&
                                                 r.TaskType == selectedItem.SmartCoreObjectType);

                if (record == null)
                    continue;

                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(record);
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
        }
        #endregion

        #region private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonDelete.Enabled = listViewBindedTasks.SelectedItems.Count > 0;
        }
        #endregion

        #endregion
    }

}