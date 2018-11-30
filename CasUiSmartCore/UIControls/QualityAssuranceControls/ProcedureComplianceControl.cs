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
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Packages;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    ///</summary>
    public partial class ProcedureComplianceControl : ComplianceControl
    {
        #region Fields

        private Procedure _currentDirective;
        private CommonCollection<Audit> _openPubAudits = new CommonCollection<Audit>();

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;

        #endregion

        #region Properties
        ///<summary>
        /// Задает директиву, для которой выводятся выполнения
        ///</summary>
        public Procedure CurrentDirective
        {
            set
            {
                _currentDirective = value;
                UpdateInformation();
            }
        }

        #endregion

        #region Constructors

        #region public ProcedureComplianceControl()

        ///<summary>
        ///</summary>
        public ProcedureComplianceControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// Выполняет работу с записями о выполнении задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(50);

            Invoke(new Action(() => listViewCompliance.Items.Clear()));

            if (_currentDirective == null)
            {
                e.Cancel = true;
                return;
            }

            List<AbstractPerformanceRecord> lastRecords = new List<AbstractPerformanceRecord>();
            List<NextPerformance> nextPerformances = new List<NextPerformance>();

            if (_openPubAudits == null)
                _openPubAudits = new CommonCollection<Audit>();
            _openPubAudits.Clear();
            //_openPubAudits.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(_currentDirective.ParentBaseDetail.ParentAircraft, WorkPackageStatus.Opened, true));
            //_openPubAudits.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(_currentDirective.ParentBaseDetail.ParentAircraft, WorkPackageStatus.Published, true));

            _openPubAudits.AddRange(GlobalObjects.AuditCore.GetAuditsLite(_currentDirective.ParentOperator, WorkPackageStatus.Opened));
            _openPubAudits.AddRange(GlobalObjects.AuditCore.GetAuditsLite(_currentDirective.ParentOperator, WorkPackageStatus.Published));

            CommonCollection<Audit> allWorkPackagesIncludedTask = new CommonCollection<Audit>();
            CommonCollection<Audit> openPubWorkPackages = new CommonCollection<Audit>();
            CommonCollection<Audit> closedWorkPackages = new CommonCollection<Audit>();

            //Поиск и заполнение просроченных директив и записей о перемещении
            //Объекты для в которые будет извлекаться информация 
            //из записеи о перемещении

            //прогнозируемый ресурс
            ForecastData forecastData = null;
            Aircraft parentAircraft = null;
            if (_currentDirective.ParentOperator != null)
            {
                ////если известна родительская деталь данной директивы,
                ////то ее текущая наработка и средняя утилизация 
                ////используются в качестве ресурсов прогноза
                ////для расчета всех просроченных выполнений
                //forecastData = new ForecastData(DateTime.Now,
                //    _currentDirective.ParentBaseDetail.AverageUtilization,
                //    GlobalObjects.CasEnvironment.Calculator.GetLifelength(_currentDirective.ParentBaseDetail));
                //parentAircraft = _currentDirective.ParentBaseDetail.ParentAircraft;
            }

            //расчет след. выполнений директивы.
            //если известен ресурс прогноза, то будут расчитаны все просрочнные выполнения
            //если неизвестне, то только первое
            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective, forecastData);
            nextPerformances.AddRange(_currentDirective.NextPerformances);
            lastRecords.AddRange(_currentDirective.PerformanceRecords.ToArray());
            ////////////////////////////////////////////
            //загрузка рабочих пакетов для определения 
            //перекрытых ими выполнений задач
            //_openPubWorkPackages.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(parentAircraft, WorkPackageStatus.Opened, true));
            //_openPubWorkPackages.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(parentAircraft, WorkPackageStatus.Published, true));

            CommonCollection<Procedure> includedTasks = new CommonCollection<Procedure>(new[] { _currentDirective });
            allWorkPackagesIncludedTask.AddRange(GlobalObjects.AuditCore.GetAuditsLite(_currentDirective.ParentOperator,
                                                                                                   WorkPackageStatus.All,
                                                                                                   includedTasks));
            includedTasks.Clear();

            #region Добавление в список просроченных выполнений
            //и сравнение их с открытыми и опубликованными рабочими пакетами
            openPubWorkPackages.AddRange(allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Opened ||
                                                                               wp.Status == WorkPackageStatus.Published));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<AuditRecord> openPubWpRecords = openPubWorkPackages.SelectMany(wp => wp.AuditRecords).ToList();
            //LINQ запрос для сортировки записей по дате
            List<NextPerformance> sortNextRecords = (from record in nextPerformances
                                                     orderby GetDate(record) descending
                                                     select record).ToList();

            for (int i = 0; i < sortNextRecords.Count; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    allWorkPackagesIncludedTask.Clear();
                    openPubWorkPackages.Clear();
                    closedWorkPackages.Clear();

                    e.Cancel = true;
                    return;
                }

                //поиск записи в рабочих пакетах по данному чеку
                //чей номер группы выполнения (по записи) совпадает с расчитанным
                Procedure directive = (Procedure)sortNextRecords[i].Parent;
                //номер выполнения
                int parentCountPerf;
                if (directive.LastPerformance != null)
                {
                    parentCountPerf = directive.LastPerformance.PerformanceNum <= 0
                        ? 1
                        : directive.LastPerformance.PerformanceNum;
                }
                else parentCountPerf = 0;
                parentCountPerf += directive.NextPerformances.IndexOf(sortNextRecords[i]);
                parentCountPerf += 1;

                AuditRecord wpr =
                    openPubWpRecords.FirstOrDefault(r => r.PerformanceNumFromStart == parentCountPerf
                                                         && r.AuditItemTypeId == directive.SmartCoreObjectType.ItemId
                                                         && r.DirectiveId == directive.ItemId);
                if (wpr != null)
                {
                    Audit wp = openPubWorkPackages.GetItemById(wpr.AuditId);
                    //запись о выполнении блокируется найденым пакетом
                    sortNextRecords[i].BlockedByPackage = wp;
                    //последующие записи о выполнении так же должны быть заблокированы
                    for (int j = i - 1; j >= 0; j--)
                    {
                        //блокировать нужно все рабочие записи, или до первой записи,
                        //заблокированной другим рабочим пакетом
                        if (sortNextRecords[j].BlockedByPackage != null ||
                            sortNextRecords[j].Condition != ConditionState.Overdue)
                            break;
                        if (sortNextRecords[j].Parent == directive)
                        {
                            sortNextRecords[j].BlockedByPackage = wp;
                            Invoke(new Action<int, Color>(SetItemColor), new object[] { j, Color.FromArgb(Highlight.GrayLight.Color) });
                        }
                    }
                }
                Invoke(new Action<NextPerformance>(AddListViewItem), sortNextRecords[i]);
            }
            #endregion

            #region Добавление в список записей о произведенных выполнениях
            //и сравнение их с закрытыми рабочими пакетами
            closedWorkPackages.AddRange(allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Closed));

            //LINQ запрос для сортировки записей по дате
            List<AbstractPerformanceRecord> sortLastRecords = (from record in lastRecords
                                                               orderby record.RecordDate descending
                                                               select record).ToList();
            ////////////////////////////////////////////

            for (int i = 0; i < sortLastRecords.Count(); i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    allWorkPackagesIncludedTask.Clear();
                    openPubWorkPackages.Clear();
                    closedWorkPackages.Clear();

                    e.Cancel = true;
                    return;
                }

                DirectiveRecord directiveRecord = (DirectiveRecord)sortLastRecords[i];
                Audit workPackage = closedWorkPackages.FirstOrDefault(wp => wp.ItemId == directiveRecord.DirectivePackageId);
                if (workPackage != null)
                {
                    Invoke(new Action<AbstractPerformanceRecord, Audit, MaintenanceCheckRecord>(AddListViewItem),
                           new object[] { sortLastRecords[i], workPackage, null });
                }
                else if (directiveRecord.MaintenanceCheckRecordId > 0)
                {
                    MaintenanceCheckRecord mcr =
                        GlobalObjects.CasEnvironment.NewLoader.GetObject<DirectiveRecordDTO,MaintenanceCheckRecord>(new Filter("ItemId", directiveRecord.MaintenanceCheckRecordId));

                    if (mcr != null)
                        mcr.ParentCheck = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<MaintenanceCheckDTO,MaintenanceCheck>(mcr.ParentId);

                    Invoke(new Action<AbstractPerformanceRecord, Audit, MaintenanceCheckRecord>(AddListViewItem),
                           new object[] { sortLastRecords[i], workPackage, mcr });
                }
                else
                {
                    Invoke(new Action<AbstractPerformanceRecord, Audit>(AddListViewItem),
                       new object[] { sortLastRecords[i], workPackage });
                }
            }
            #endregion

            allWorkPackagesIncludedTask.Clear();
            openPubWorkPackages.Clear();
            closedWorkPackages.Clear();

            backgroundWorker.ReportProgress(100);
        }
        #endregion

        #region protected override void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        /// <summary>
        /// Докладывает о ходе процесса работы над записями о выполнении задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarLoad.Value = e.ProgressPercentage;
        }
        #endregion

        #region protected override void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        /// <summary>
        /// Выполняет действия по окончании работы с записями о выполнении задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                {
                    item.Click -= AddToWorkPackageItemClick;
                    item.Tag = null;
                }

                _toolStripMenuItemsWorkPackages.DropDownItems.Clear();

                foreach (Audit workPackage in _openPubAudits)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem($"{workPackage.Title} {workPackage.Number}");
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = workPackage;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
                }
            }

            ButtonAdd.Enabled = false;
        }
        #endregion

        #region private void InitToolStripMenuItems()

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            //
            // _toolStripMenuItemsWorkPackages
            //
            _toolStripMenuItemsWorkPackages.Text = "Add to Audit";

            _contextMenuStrip.Items.Clear();
            _toolStripMenuItemsWorkPackages.DropDownItems.Clear();

            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
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
            if (listViewCompliance.SelectedItems.Count <= 0)
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

        #region public DirectiveRecord[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив технических записей (DirectiveRecord)
        /// </summary>
        /// <returns>Массив технических записей (DirectiveRecord)</returns>
        public DirectiveRecord[] GetItemsArray()
        {
            List<DirectiveRecord> directiveRecords = new List<DirectiveRecord>();
            directiveRecords.AddRange(_currentDirective.PerformanceRecords.ToArray());
            return directiveRecords.ToArray();
        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Обновление информации ЭУ
        /// </summary>
        private void UpdateInformation()
        {
            if (_contextMenuStrip == null)
                InitToolStripMenuItems();

            backgroundWorker.RunWorkerAsync();
            //UpdateItems();

            //ButtonAdd.Enabled = false;
        }
        #endregion

        #region protected override void AddListViewItem(NextPerformance np)
        protected override void AddListViewItem(NextPerformance np)
        {
            string[] subs = 
                new[]  
                { 
                    np.WorkType,
                    np.PerformanceDate != null 
                        ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) 
                        : "N/A",
                    np.PerformanceSource.ToString(),
                    "",
                };

            ListViewItem newItem = new ListViewItem(subs)
            {
                Group = listViewCompliance.Groups[0],
                Tag = np,
            };

            listViewCompliance.Items.Add(newItem);   
        }
        #endregion

        #region private void AddListViewItem(AbstractPerformanceRecord apr, IDirectivePackage directivePackage, MaintenanceCheckRecord mcr)
        private void AddListViewItem(AbstractPerformanceRecord apr, IDirectivePackage directivePackage, 
                                     MaintenanceCheckRecord mcr)
        {
            DirectiveRecord directiveRecord = (DirectiveRecord)apr;
            Procedure parentDirective = (Procedure)directiveRecord.Parent;
            string[] subs = new[]  {
                                               parentDirective.ProcedureType.ToString(),
                                               UsefulMethods.NormalizeDate(directiveRecord.RecordDate),
                                               directiveRecord.OnLifelength != null
                                                   ? directiveRecord.OnLifelength.ToString()
                                                   : "",
                                               directiveRecord.Remarks,
                                   };

            ListViewItem newItem = new ListViewItem(subs)
            {
                Group = listViewCompliance.Groups[1],
                Tag = directiveRecord
            };
            if (directivePackage != null)
            {
                //запись о выполнении блокируется найденым пакетом
                apr.DirectivePackage = directivePackage;
                newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                newItem.ToolTipText =
                    "Perform of the task:" + parentDirective.ProcedureType +
                    "\nadded by Audit:" +
                    "\n" + directiveRecord.DirectivePackage.Title +
                    "\nTo remove a performance of task, you need to exclude task from this audit," +
                    "\nor delete the audit ";
            }
            else if (directiveRecord.MaintenanceCheckRecordId > 0 && mcr != null && mcr.ParentCheck != null)
            {
                MaintenanceCheck mc = mcr.ParentCheck;
                directiveRecord.MaintenanceCheck = mc;
                newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                newItem.ToolTipText =
                    "Perform of the task:" + parentDirective.ProcedureType +
                    "\nadded by Maintenance Check:" +
                    "\n" + mc.Name +
                    "\nTo remove a performance of task, you need to delete performance of maintenance check";
            }
            listViewCompliance.Items.Add(newItem);
        }
        #endregion

        #region private void AddListViewItem(AbstractPerformanceRecord apr, IDirectivePackage directivePackage)
        private void AddListViewItem(AbstractPerformanceRecord apr, IDirectivePackage directivePackage)
        {
            DirectiveRecord directiveRecord = (DirectiveRecord)apr;

            string workTypeString = "";
            StaticDictionary workType;
            if (directiveRecord.Parent is Procedure)
            {
                Procedure parentDirective = (Procedure)directiveRecord.Parent;
                workType = parentDirective.ProcedureType;
                workTypeString = parentDirective.ProcedureType.ToString();
            }
            else if (directiveRecord.Parent is ComponentDirective)
            {
                ComponentDirective parentDirective = (ComponentDirective)directiveRecord.Parent;
                workType = parentDirective.DirectiveType;
                workTypeString = parentDirective.DirectiveType + " of " + parentDirective.ParentComponent.Description;
            }
            else workType = MaintenanceDirectiveTaskType.Unknown;
            string[] subs = new[]  {
                                       workTypeString,
                                       UsefulMethods.NormalizeDate(directiveRecord.RecordDate),
                                       directiveRecord.OnLifelength != null
                                           ? directiveRecord.OnLifelength.ToString()
                                           : "",
                                       directiveRecord.Remarks,
                                   };
            ListViewItem newItem = new ListViewItem(subs)
            {
                Group = listViewCompliance.Groups[1],
                Tag = directiveRecord
            };
            if (directivePackage != null)
            {
                //запись о выполнении блокируется найденым пакетом
                apr.DirectivePackage = directivePackage;
                newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                newItem.ToolTipText =
                    "Perform of the task:" + workType +
                    "\nadded by Audit:" +
                    "\n" + directiveRecord.DirectivePackage.Title +
                    "\nTo remove a performance of task, you need to exclude task from this Audit," +
                    "\nor delete the Audit ";
            }
            listViewCompliance.Items.Add(newItem);
        }
        #endregion

        #region private void AddPerformance()
        private void AddPerformance()
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                return;
            }

            DirectiveComplianceDialog dlg;
            DirectiveRecord record;
            NextPerformance np;

            if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
            {
                //if (_currentDirective.MaintenanceCheck != null)
                //{
                //    MessageBox.Show("This MPD is binded to maintenance check '" + _currentDirective.MaintenanceCheck.Name + "'." +
                //                    "\nPerformance for this item introduced by performance of maintenance check.",
                //                    (string)new GlobalTermsProvider()["SystemName"],
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Warning,
                //                    MessageBoxDefaultButton.Button1);
                //    return;
                //}

                np = (NextPerformance)listViewCompliance.SelectedItems[0].Tag;

                if (np.Condition != ConditionState.Overdue || np.PerformanceDate > DateTime.Now)
                {
                    MessageBox.Show("You can not enter a record for not delayed performance",
                                    (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                    return;
                }
                if (np.BlockedByPackage != null)
                {
                    MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                                    "\nblocked by Package:" +
                                    "\n" + np.BlockedByPackage.Title,
                                    (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                    return;
                }
                dlg = new DirectiveComplianceDialog(np.Parent, np){ Text = "Add new compliance for " + np.WorkType };
                dlg.ShowDialog();

                if (dlg.DialogResult == DialogResult.OK)
                    InvokeComplianceAdded(null);
            }
            else if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
                IDirective directive = record.Parent;

                if (directive is Procedure)
                {
                    Procedure parentDirective = (Procedure)directive;
                    dlg = new DirectiveComplianceDialog(record.Parent, record)
                    {
                        Text = "Edit exist compliance for " + parentDirective.ProcedureType
                    };
                    dlg.ShowDialog();

                    if (dlg.DialogResult == DialogResult.OK)
                        InvokeComplianceAdded(null);
                }
                else if (directive is ComponentDirective)
                {
                    ComponentDirective parentDirective = (ComponentDirective)directive;
                    dlg = new DirectiveComplianceDialog(record.Parent, record)
                    {
                        Text = "Edit exist compliance for " + parentDirective.DirectiveType + " of " + parentDirective.ParentComponent.Description
                    };
                    dlg.ShowDialog();

                    if (dlg.DialogResult == DialogResult.OK)
                        InvokeComplianceAdded(null);
                }
            }
            else return;  
        }
        #endregion

        #region private void AddToWorkPackageItemClick(object sender, EventArgs e)

        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count <= 0 ||
                _currentDirective.ParentOperator == null) return;

            Audit wp = (Audit)((ToolStripMenuItem)sender).Tag;

            if (MessageBox.Show("Add item to Audit: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                List<NextPerformance> nextPerformances =
                    listViewCompliance.SelectedItems
                    .Cast<ListViewItem>()
                    .Where(lvi => lvi.Tag is NextPerformance)
                    .Select(lvi => lvi.Tag as NextPerformance)
                    .ToList();
                if (nextPerformances.Count == 0)
                {
                    MessageBox.Show("Not select next compliance to adding", (string)new GlobalTermsProvider()["SystemName"],
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    string message;

                    if (!GlobalObjects.AuditCore.AddToAudit(nextPerformances, wp.ItemId,
														    _currentDirective.ParentOperator, out message))
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

                    if (MessageBox.Show("Items added successfully. Open audit?", (string)new GlobalTermsProvider()["SystemName"],
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                                        == DialogResult.Yes)
                    {
                        ReferenceEventArgs refArgs = new ReferenceEventArgs();
                        refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        refArgs.DisplayerText = wp.Title;
                        refArgs.RequestedEntity = new AuditScreen(wp);
                        InvokeDisplayerRequested(refArgs);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("error while create Audit", ex);
                }
            }
        }

        #endregion

        #region private void ButtonAdd_Click(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            AddPerformance();
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0 ||
                !(listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)) return;

            DirectiveRecord record = (DirectiveRecord) listViewCompliance.SelectedItems[0].Tag;
            if (record.DirectivePackage != null)
            {
                MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                                "\nadded by Audit:" +
                                "\n" + record.DirectivePackage.Title +
                                "\nTo remove a DirectivePackage of task, you need to exclude task from this Audit" +
                                "\nor delete the Audit ",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            if(record.MaintenanceCheck != null)
            {
                MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                                "\nadded by Maintenance check:" +
                                "\n" + record.MaintenanceCheck.Name +
                                "\nTo remove a performance of task, you need to exclude perform of task from perform of maintenance check," +
                                "\nor delete the perform of maintenance check ",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                return;    
            }

            switch (MessageBox.Show(@"Delete this compliance " + record.RecordType +" ?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
            {
                case DialogResult.Yes:
                    GlobalObjects.PerformanceCore.Delete(record); 
                    InvokeComplianceAdded(null);
                    break;
                case DialogResult.No:
                    //arguments.Cancel = true;
                    break;
            }
        }
        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0 || listViewCompliance.SelectedItems[0].Tag is Procedure)
            {
                return;
            }

            DirectiveComplianceDialog dlg;
            DirectiveRecord record;

            if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
                IDirective directive = record.Parent;

                if (directive is Procedure)
                {
                    Procedure parentDirective = (Procedure)directive;
                    dlg = new DirectiveComplianceDialog(record.Parent, record)
                    {
                        Text = "Edit exist compliance for " + parentDirective.ProcedureType
                    };
                    dlg.ShowDialog();

                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        InvokeComplianceAdded(null);
                    }
                }
                else if (directive is ComponentDirective)
                {
                    ComponentDirective parentDirective = (ComponentDirective)directive;
                    dlg = new DirectiveComplianceDialog(record.Parent, record)
                    {
                        Text = "Edit exist compliance for " + parentDirective.DirectiveType + " of " + parentDirective.ParentComponent.Description
                    };
                    dlg.ShowDialog();

                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        InvokeComplianceAdded(null);
                    }
                }
            }
            else return;
        }

        #endregion
        
        #region private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)

        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddPerformance();
        }

        #endregion

        #region private void ListViewComplainceClick(object sender, EventArgs e)
        private void ListViewComplainceClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                ButtonEdit.Enabled = false;
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
            }
            else
            {
                if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
                {
                    ButtonEdit.Enabled = false;
                    ButtonDelete.Enabled = false;
                    ButtonAdd.Enabled = true;
                }
                else if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
                {
                    ButtonEdit.Enabled = true;
                    ButtonAdd.Enabled = false;
                    ButtonDelete.Enabled = true;
                }
            }
        }
        #endregion

        #endregion

        #region Events

        #endregion
    }
}
