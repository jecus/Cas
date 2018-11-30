using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class AuditScreen : ScreenControl
    {
        #region Fields

        private readonly Audit _currentDirective;

        private CommonCollection<BaseEntityObject> _itemsArray = new CommonCollection<BaseEntityObject>();
        /// <summary>
        /// Рабочие пакеты, имеющие те же задачи, что и текущий
        /// </summary>
        private CommonCollection<Audit> _relatedWorkPackages = new CommonCollection<Audit>();
        private AuditView _directivesViewer;

#if  KAC
        private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
        private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemOpen;
        private ToolStripMenuItem _toolStripMenuItemClose;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripSeparator _toolStripSeparator1;
        private List<ToolStripMenuItem> _toolStripMenuItemsWorkPackages;

        #endregion

        #region Constructors

        #region private AuditScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private AuditScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public AuditScreen(Audit audit)
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="audit"></param>
        public AuditScreen(Audit audit)
            : this()
        {
            if (audit == null)
                throw new ArgumentNullException("audit");
           
            CurrentOperator = audit.Operator;

            _currentDirective = audit;

            //InitializeComponent();
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

            _itemsArray.Clear();
            _itemsArray = null;

            if (_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages)
                    item.Dispose();
            }

            if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
            if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                return;

            labelDateAsOf.Text = "Audit Status: " + _currentDirective.Status;

            switch (_currentDirective.Status)
            {
                case WorkPackageStatus.Published:
                    {
                        buttonAddNonRoutineJob.Enabled = false;
                        buttonPublish.Enabled = false;
                        buttonClose.Enabled = true;
                        if (_currentDirective.CanClose == false)
                        {
                            buttonClose.ShowToolTip = true;
                            buttonClose.ToolTipText = "This audit can not be closed";
                        }
                        else
                        {
                            buttonClose.ShowToolTip = false;
                            buttonClose.ToolTipText = "";
                        }
                        break;
                    }
                case WorkPackageStatus.Closed:
                    {
                        buttonAddNonRoutineJob.Enabled = false;
                        buttonPublish.Enabled = true;
                        if(_currentDirective.CanPublish == false)
                        {
                            buttonPublish.ShowToolTip = true;
                            buttonPublish.ToolTipText = "This audit can not be republished";
                        }
                        else
                        {
                            buttonPublish.ShowToolTip = false;
                            buttonPublish.ToolTipText = "";   
                        }
                        break;
                    }
                default:
                    {
                        buttonAddNonRoutineJob.Enabled = true;
                        buttonPublish.Enabled = true;
                        buttonClose.Enabled = true;
                        if (_currentDirective.CanClose == false)
                        {
                            buttonClose.ShowToolTip = true;
                            buttonClose.ToolTipText = "This audit can not be closed";
                        }
                        else
                        {
                            buttonClose.ShowToolTip = false;
                            buttonClose.ToolTipText = "";
                        }
                        break;
                    }
            }
            _directivesViewer.SetItemsArray(_itemsArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _itemsArray.Clear();
            _relatedWorkPackages.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load Audit");
            
            //GlobalObjects.CasEnvironment.Loader.LoadWorkPackageItems(_currentWorkPackage);
            GlobalObjects.AuditCore.GetAuditItemsWithCalculate(_currentDirective);
            if (_currentDirective.MaxClosingDate < _currentDirective.MinClosingDate)
                _currentDirective.CanClose = false;
            CommonCollection<BaseEntityObject> wpItems = new CommonCollection<BaseEntityObject>();
            foreach (AuditRecord record in _currentDirective.AuditRecords) 
                wpItems.Add((BaseEntityObject)record.Task);   

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            double currentProc = 20;
            int countDirectives = wpItems.Count;
            if (countDirectives == 0)countDirectives = 1;
            double delay = (100 - currentProc) / countDirectives;

            if (_currentDirective.Status != WorkPackageStatus.Closed)
            {
                AnimatedThreadWorker.ReportProgress(10, "load related Audit");
               
                foreach (AuditRecord record in _currentDirective.AuditRecords)
                {
                    AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "calculation of directives");

                    if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
                    {
                        MaintenanceCheck mc = (MaintenanceCheck) record.Task;
                        MaintenanceNextPerformance mnp = 
                            mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
                        if(mnp != null)
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
                AnimatedThreadWorker.ReportProgress(10, "load related Audits");
                _relatedWorkPackages.AddRange(GlobalObjects.AuditCore.GetAudits(CurrentOperator,
                                                                                 WorkPackageStatus.Closed,
                                                                                 true,
                                                                                 wpItems));
                //сбор всех записей рабочих пакетов для удобства фильтрации
                AbstractPerformanceRecord apr;
                foreach (AuditRecord record in _currentDirective.AuditRecords)
                {
                    AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "check records");
                    
                    apr = record.Task.PerformanceRecords
                        .Cast<AbstractPerformanceRecord>()
                        .FirstOrDefault(pr => pr.DirectivePackageId == _currentDirective.ItemId);
                    if (apr != null)
                        _itemsArray.Add(apr);
                    else
                    {
                        if (record.Task.NextPerformances.Count > 0)
                            _itemsArray.Add(record.Task.NextPerformances[0]);
                        else _itemsArray.Add((BaseEntityObject)record.Task);
                    }
                }   
            }

            AnimatedThreadWorker.ReportProgress(100, "calculation over");
        }
        #endregion

        #region private void CloseWorkPackage()
        private void CloseWorkPackage()
        {
            IEnumerable<AuditRecord> blockedRecords = 
                _currentDirective.AuditRecords
                .Where(rec => rec.Task != null && 
                              rec.Task.NextPerformances != null && 
                              rec.Task.NextPerformances.Count > 0 && 
                              rec.Task.NextPerformances.Any(np => np.BlockedByPackage != null && 
                                                                  np.BlockedByPackage.ItemId != _currentDirective.ItemId));

            if (_currentDirective.CanClose == false || blockedRecords.Any())
            {
                string message = "This audit can not be closed";
                foreach (AuditRecord blockedRecord in blockedRecords)
                {
                    NextPerformance np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByPackage != null);
                    message += string.Format("\nTask: {0} blocked by audit {1}",
                                                blockedRecord.Task,
                                                np.BlockedByPackage);
                }
                if(_currentDirective.MaxClosingDate < _currentDirective.MinClosingDate)
                {
                    message += string.Format("\nMin Closing Date: {0} better than Max Closing Date: {1}",
                                                _currentDirective.MinClosingDate,
                                                _currentDirective.MaxClosingDate); 
                }
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuditClosingFormNew form = new AuditClosingFormNew(_currentDirective);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                AnimatedThreadWorker.RunWorkerAsync();
            }    
        }
        #endregion

        #region private void InitToolStripMenuItems()

        private void InitToolStripMenuItems()
        {

            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemClose = new ToolStripMenuItem();
            _toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();
            _toolStripMenuItemDelete = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripMenuItemOpen = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemOpen.Text = "Open";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
            // 
            // toolStripMenuItemClose
            // 
            _toolStripMenuItemClose.Text = "Close";
            _toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
            // 
            // toolStripMenuItemDelete
            // 
            _toolStripMenuItemDelete.Text = "Delete from Work package";
            _toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            // 
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";

            _contextMenuStrip.Items.Clear();
            _toolStripMenuItemsWorkPackages.Clear();
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
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    _toolStripMenuItemClose,
                                                    _toolStripMenuItemOpen,
                                                    _toolStripMenuItemDelete,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemHighlight,
                                                });
            _contextMenuStrip.Opening += ContextMenuStripOpen;
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
            if (_directivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
            if (_directivesViewer.SelectedItems.Count == 1)
            {
                _toolStripMenuItemOpen.Enabled = true;
            }
        }

        #endregion

        #region private void HighlightItemClick(object sender, EventArgs e)

        private void HighlightItemClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
            {
                Highlight highLight = (Highlight) ((ToolStripMenuItem) sender).Tag;
                _directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
            }
        }

        #endregion

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
            if(_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)return;
            foreach (BaseEntityObject selectedItem in _directivesViewer.SelectedItems)
            {
                if (selectedItem is Procedure)
                {
                    ReferenceEventArgs refE = new ReferenceEventArgs();
                    refE.DisplayerText = ((Procedure)selectedItem).Title;
                    refE.RequestedEntity = new ProcedureScreen((Procedure)selectedItem);
                    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    InvokeDisplayerRequested(refE);
                }
            }
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        //Удаляет рабочий пакет
        private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
        {
           ButtonDeleteClick();
        }

        #endregion

        #region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

        private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
        {
            CloseWorkPackage();
        }

        #endregion

        #region private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
        private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
        {
            //NonRoutineJobForm form = new NonRoutineJobForm(new AuditRecord(_currentDirective.ItemId, -1, -1));

            //if (form.ShowDialog() == DialogResult.OK) 
            //    AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ButtonPublishClick(object sender, EventArgs e)

        private void ButtonPublishClick(object sender, EventArgs e)
        {
            if (_currentDirective.CanPublish == false)
            {
                string message = "This Audit can not be published";
                if (_currentDirective.BlockPublishReason != "")
                    message += "\n" + _currentDirective.BlockPublishReason;

                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentDirective.Status != WorkPackageStatus.Closed)
                GlobalObjects.AuditCore.Publish(_currentDirective, DateTime.Now, "");
            else
            {
                switch (MessageBox.Show(@"This Audit is already closed," +
                                        "\nif you want to republish it," +
                                        "\nrecordings created during its execution will be erased." + "\n\n Republish " +
                                        _currentDirective.Title + " Audit?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.AuditCore.Publish(_currentDirective, DateTime.Now, "");
                        break;
                    case DialogResult.No:
                        //arguments.Cancel = true;
                        break;
                }
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        #region private void ButtonReleaseToService(object sender, EventArgs e)

        private void ButtonReleaseToService(object sender, EventArgs e)
        {
            //SelectWPPrintTasksForm form = new SelectWPPrintTasksForm(_currentDirective);
            //form.ShowDialog();
        }

        #endregion

        #region void ButtonCloseClick(object sender, EventArgs e)

        void ButtonCloseClick(object sender, EventArgs e)
        {
            CloseWorkPackage();
        }

        #endregion

        #region private void ButtonDeleteClick()

        private void ButtonDeleteClick()
        {
            if (_directivesViewer.SelectedItems == null) return;

            List<IBaseEntityObject> selectedItems = new List<IBaseEntityObject>();
            foreach (BaseEntityObject o in _directivesViewer.SelectedItems)
            {
                if (o is MaintenanceNextPerformance)
                {
                    MaintenanceNextPerformance mnp = (MaintenanceNextPerformance) o;
                    selectedItems.AddRange(mnp.PerformanceGroup.Checks.ToArray());
                    continue;
                }
                if (o is NextPerformance)
                {
                    selectedItems.Add(((NextPerformance)o).Parent); 
                    continue;
                }

                IBaseEntityObject parent;
                if (o is AbstractPerformanceRecord)
                {
                    parent = ((AbstractPerformanceRecord) o).Parent;
                }
                else parent = o;
                
                if (parent is Procedure)
                {
                    Procedure d = (Procedure)parent;
                    List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
                    if (records.Any(r => r.DirectivePackageId == _currentDirective.ItemId))
                    {
                        MessageBox.Show("Can not delete directive " + d.ProcedureType + " from Audit" +
                                        "\nthis directive is already closed by this Audit", "Error", MessageBoxButtons.OK);
                    }
                    else selectedItems.Add(parent);
                }
            }

            if (selectedItems.Count == 0) return;

            DialogResult confirmResult =
                MessageBox.Show(
                    selectedItems.Count == 1
                        ? "Do you really want to delete Item ?"
                        : "Do you really want to delete selected Items? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                _directivesViewer.ItemListView.BeginUpdate();
                foreach (IBaseEntityObject t in selectedItems)
                {
                    try
                    {
                        GlobalObjects.AuditCore.DeleteFromAudit(t, _currentDirective);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
                _directivesViewer.ItemListView.EndUpdate();
                AnimatedThreadWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)

        private void ButtonEditClick(object sender, EventArgs e)
        {
            CommonEditorForm form = new CommonEditorForm(_currentDirective);
            form.ShowDialog();
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new AuditView(_currentDirective);
            _directivesViewer.TabIndex = 2;
            _directivesViewer.ContextMenuStrip = _contextMenuStrip;
            _directivesViewer.Location = new Point(panel1.Left, panel1.Top);
            _directivesViewer.Dock = DockStyle.Fill;
            Controls.Add(_directivesViewer);
            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            _toolStripMenuItemHighlight.Enabled = _directivesViewer.SelectedItems.Count > 0;
            _toolStripMenuItemOpen.Enabled = _directivesViewer.SelectedItems.Count > 0;
            _toolStripMenuItemClose.Enabled = _directivesViewer.SelectedItems.Count > 0;
            foreach (ToolStripMenuItem t in _toolStripMenuItemsWorkPackages)
                t.Enabled = _directivesViewer.SelectedItems.Count > 0;
        }

        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        private void UpdateInformation()
        {
            if (CurrentOperator != null)
            {
                labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
            }
            else
            {
                labelTitle.Text = "";
                labelTitle.Status = Statuses.NotActive;
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //WorkPackageReportBuilder reportBuilder = new WorkPackageReportBuilder
            //{
            //    ReportedAircraft = CurrentAircraft,
            //    ReportedWorkPackage = _currentWorkPackage
            //};
            //e.DisplayerText = "Work Package";
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //e.RequestedEntity = new ReportScreen(reportBuilder);
           
            //SelectWorkscopePrintTasksForm form = new SelectWorkscopePrintTasksForm(_currentDirective);
            //if(form.ShowDialog()!= DialogResult.OK)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
            //_workscopeReportBuilder.WorkPackage = _currentDirective;
            //_workscopeReportBuilder.AddDirectives(form.SelectedItems);
            //e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + _currentDirective.Title + "." + "Workscope";
            //e.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.Cancel = true;
        }
        #endregion

        #region private void ForecastMenuClick(object sender, EventArgs e)
        private void ForecastMenuClick(object sender, EventArgs e)
        {
        }
        #endregion

        #endregion
    }
}
