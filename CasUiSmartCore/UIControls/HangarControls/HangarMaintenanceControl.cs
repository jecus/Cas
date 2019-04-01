using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.HangarControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HangarMaintenanceControl : EditObjectControl
    {
        private CommonCollection<WorkPackage> _resultDirectiveArray = new CommonCollection<WorkPackage>();
        private CommonCollection<BaseEntityObject> _itemsArray = new CommonCollection<BaseEntityObject>();
        private WorkPackage _selectedWorkPackage;

        #region public bool EnableExtendedControl
        ///<summary>
        /// Возвращает или задает значение видна ли панель расширения
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false)
                {
                    extendableRichContainer.Extended = true;

                    //panelMain.Visible = true;
                    //panelRelease.Visible = true;
                    //panelDeferredInfo.Visible = _showDeferredInfoPanel;
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли елемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return panelMain.Visible; }
            set
            {
                extendableRichContainer.Extended = value;
                panelMain.Visible = value;
            }
        }
        #endregion

        #region public HangarMaintenanceControl()
        /// <summary>
        /// 
        /// </summary>
        public HangarMaintenanceControl()
        {
            InitializeComponent();
        }
        #endregion

        #region private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (_selectedWorkPackage == null)
            {
                e.Cancel = true;
                return;
            }

            _itemsArray.Clear();

            backgroundWorker.ReportProgress(0, "Load Work Package");

            if (!_selectedWorkPackage.WorkPackageItemsLoaded)
                GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(_selectedWorkPackage);

            if (_selectedWorkPackage.MaxClosingDate < _selectedWorkPackage.MinClosingDate)
                _selectedWorkPackage.CanClose = false;
            CommonCollection<BaseEntityObject> wpItems = new CommonCollection<BaseEntityObject>();
            foreach (WorkPackageRecord record in _selectedWorkPackage.WorkPakageRecords)
                wpItems.Add((BaseEntityObject)record.Task);

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            double currentProc = 20;
            int countDirectives = wpItems.Count;
            if (countDirectives == 0) countDirectives = 1;
            double delay = (100 - currentProc) / countDirectives;

            if (_selectedWorkPackage.Status != WorkPackageStatus.Closed)
            {
                backgroundWorker.ReportProgress(10, "load related Work Packages");

                foreach (WorkPackageRecord record in _selectedWorkPackage.WorkPakageRecords)
                {
                    backgroundWorker.ReportProgress((int)(currentProc += delay), "calculation of directives");

                    if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
                    {
                        MaintenanceCheck mc = (MaintenanceCheck)record.Task;
                        MaintenanceNextPerformance mnp =
                            mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
                        if (mnp != null)
                            _itemsArray.Add(mnp);
                    }
                    else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
                    {
                        _itemsArray.Add((BaseEntityObject)record.Task);
                    }
                    else if (record.Task.SmartCoreObjectType == SmartCoreType.Component)
                    {
                        if (record.Task.NextPerformances.Count > 0)
                            _itemsArray.Add(record.Task.NextPerformances[0]);
                        else _itemsArray.Add((BaseEntityObject)record.Task);
                    }
                    else
                    {
                        if (record.Task.NextPerformances.Count > 0)
                            _itemsArray.Add(record.Task.NextPerformances[0]);
                        else _itemsArray.Add((BaseEntityObject)record.Task);
                    }
                }
            }
            else
            {
                //При закоытом Рабочем пакете, в список попадают записи о выполении
                //сделанные в рамках данного рабочего пакета
                backgroundWorker.ReportProgress(10, "load related Work Packages");

                AbstractPerformanceRecord apr;
                foreach (WorkPackageRecord record in _selectedWorkPackage.WorkPakageRecords)
                {
                    backgroundWorker.ReportProgress((int)(currentProc += delay), "check records");
                    if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
                    {
                        backgroundWorker.ReportProgress((int)(currentProc += delay), "calculation of Maintenance checks");
                        apr = record.Task.PerformanceRecords
                                    .Cast<AbstractPerformanceRecord>()
                                    .FirstOrDefault(pr => pr.DirectivePackageId == _selectedWorkPackage.ItemId);

                        if (apr != null)
                            _itemsArray.Add(apr);
                        else
                        {
                            MaintenanceCheck mc = (MaintenanceCheck)record.Task;
                            if (mc.NextPerformances.OfType<MaintenanceNextPerformance>().Any(np => np.PerformanceGroupNum == record.PerformanceNumFromStart))
                            {
                                MaintenanceNextPerformance mnp =
                                mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
                                if (mnp != null)
                                    _itemsArray.Add(mnp);
                            }
                            else _itemsArray.Add((BaseEntityObject)record.Task);
                        }
                    }
                    else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
                    {
                        _itemsArray.Add((BaseEntityObject)record.Task);
                    }
                    else
                    {
                        apr = record.Task.PerformanceRecords
                            .Cast<AbstractPerformanceRecord>()
                            .FirstOrDefault(pr => pr.DirectivePackageId == _selectedWorkPackage.ItemId);

                        if (apr != null)
                            _itemsArray.Add(apr);
                        else
                        {
                            if (record.Task.NextPerformances.Count > 0)
                                _itemsArray.Add(record.Task.NextPerformances[0]);
                            else _itemsArray.Add((BaseEntityObject)record.Task);
                        }
                    }

                    if (_selectedWorkPackage.WorkPakageRecords.Where(wpr => wpr.Task != null && wpr.Task is Component)
                        .Select(wpr => wpr.Task as Component)
                        .Any(d => d.TransferRecords.Any(tr => tr.DirectivePackageId == _selectedWorkPackage.ItemId && tr.DODR)))
                    {
                        //Поиск записи в рабочем пакете по деталям(базовым деталям)
                        //в записях о перемещении которых есть запись сделанная в рамках данного 
                        //рабочего пакета, и подтвержденная на стороне получателя
                        //Если такие записи есть, то рабочий пакет перепубликовать нельзя
                        _selectedWorkPackage.CanPublish = false;
                        if (_selectedWorkPackage.BlockPublishReason != "")
                            _selectedWorkPackage.BlockPublishReason += "\n";
                        _selectedWorkPackage.BlockPublishReason =
                            "This work package has in its task of moving component," +
                            "\nwhich was confirmed on the destination side";
                    }
                }
            }

            backgroundWorker.ReportProgress(100, "calculation over");
        }

        #endregion

        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProcess.Text = e.ProgressPercentage + "% " + e.UserState;
        }

        #region private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ClearControls();
            BuildControls();
        }
        #endregion

        #region private void DoAsyncWork()

        private void DoAsyncWork()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region public void CancelAsyncWork()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsyncWork()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();

                WaitCancelForm wcf = new WaitCancelForm(backgroundWorker)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                wcf.ShowDialog();

                while (backgroundWorker.IsBusy)
                {
                    Thread.Sleep(500);
                }
            }
        }
        #endregion

        #region private void AvButtonReloadClick(object sender, EventArgs e)
        private void AvButtonReloadClick(object sender, EventArgs e)
        {
            WorkPackage wp = comboBoxWorkPackage.SelectedItem as WorkPackage;

            if (wp != null)
            {
                wp.WorkPackageItemsLoaded = false;
            }

            DoAsyncWork();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            CancelAsyncWork();

            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region public override void FillControls()
        public override void FillControls()
        {
            hangarWorkPackageView.ViewedType = typeof (BaseEntityObject);
            
            _resultDirectiveArray.Clear();
            _resultDirectiveArray.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(null, WorkPackageStatus.Published).ToArray());

            comboBoxWorkPackage.Items.Clear();

            IEnumerable<IGrouping<Aircraft, WorkPackage>> wpGroupByAircraft =
                _resultDirectiveArray.GroupBy(wp => wp.Aircraft);

            foreach (IGrouping<Aircraft, WorkPackage> groupByAircraft in wpGroupByAircraft)
            {
                foreach (WorkPackage workPackage in groupByAircraft)
                {
                    comboBoxWorkPackage.Items.Add(workPackage);
                }
            }

            textBoxCustomer.Text = GlobalObjects.CasEnvironment.Operators[0].Name;

            extendableRichContainer.Caption = "Select Work Package:";
        }
        #endregion

        #region private void BuildControls()
        private void BuildControls()
        {
            WorkPackage wp = comboBoxWorkPackage.SelectedItem as WorkPackage;
            string caption = wp != null
                ? (wp.Aircraft != null ? wp.Aircraft.RegistrationNumber + " " + wp.Number : wp.Number)
                : "Select Work Package";
            extendableRichContainer.labelCaption.Text = caption;
            labelProcess.Text = "";

            hangarWorkPackageView.SetItemsArray(_itemsArray.ToArray());
            hangarWorkPackageView.Focus();
        }
        #endregion

        #region private void ClearControls()
        private void ClearControls()
        {
            hangarWorkPackageView.ClearItems();
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            panelMain.Visible = !panelMain.Visible;
        }
        #endregion

        #region private void ComboBoxWorkPackageSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxWorkPackageSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedWorkPackage = comboBoxWorkPackage.SelectedItem as WorkPackage;
            hangarWorkPackageView.WorkPackage = _selectedWorkPackage;

            DoAsyncWork();
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion
    }
}
