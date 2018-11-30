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
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DirectiveComplianceControl : ComplianceControl
    {
        #region Fields

        private Directive _currentDirective;
        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;

        #endregion

        #region Properties
        ///<summary>
        /// Задает директиву, для которой выводятся выполнения
        ///</summary>
        public Directive CurrentDirective
        {
            set
            {
                _currentDirective = value;
                UpdateInformation();
            }
        }

        #endregion

        #region Constructors

        #region public DirectiveComplianceControl()

        ///<summary>
        ///</summary>
        public DirectiveComplianceControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(50);

            Invoke(new Action(() => listViewCompliance.Items.Clear()));

            if (_currentDirective == null)
            {
                e.Cancel = true;
                return;
            }

            List<AbstractRecord> lastRecords = new List<AbstractRecord>();
            List<NextPerformance> nextPerformances = new List<NextPerformance>();

            //прогнозируемый ресурс
            //если известна родительская деталь данной директивы,
            //то ее текущая наработка и средняя утилизация 
            //используются в качестве ресурсов прогноза
            //для расчета всех просроченных выполнений
            ForecastData forecastData = null;
            Aircraft parentAircraft = null;

            if (_currentDirective.ParentBaseComponent != null)
            {
                //если известна родительская деталь данной директивы,
                //то ее текущая наработка и средняя утилизация 
                //используются в качестве ресурсов прогноза
                //для расчета всех просроченных выполнений
                forecastData = new ForecastData(DateTime.Now,
                                                _currentDirective.ParentBaseComponent.AverageUtilization,
                                                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentDirective.ParentBaseComponent));
                parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
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
            if (_openPubWorkPackages == null)
                _openPubWorkPackages = new CommonCollection<WorkPackage>();
            _openPubWorkPackages.Clear();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft, WorkPackageStatus.Opened));

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft, WorkPackageStatus.Published));

            CommonCollection<WorkPackage> allWorkPackagesIncludedTask = new CommonCollection<WorkPackage>();
            CommonCollection<WorkPackage> openPubWorkPackagesIncludedTask = new CommonCollection<WorkPackage>();
            CommonCollection<WorkPackage> closedWorkPackages = new CommonCollection<WorkPackage>();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

	        allWorkPackagesIncludedTask.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft,
                                                                                                   WorkPackageStatus.All,
																								   new IDirective[] { _currentDirective }));
            

            #region Добавление в список просроченных выполнений
            //и сравнение их с открытыми и опубликованными рабочими пакетами
            openPubWorkPackagesIncludedTask.AddRange(allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Opened 
                                                                                          || wp.Status == WorkPackageStatus.Published));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<WorkPackageRecord> openPubWpRecords = openPubWorkPackagesIncludedTask.SelectMany(wp => wp.WorkPakageRecords).ToList();
            //LINQ запрос для сортировки записей по дате
            List<NextPerformance> sortNextRecords = (from record in nextPerformances
                                                     orderby GetDate(record) descending 
                                                     select record).ToList();
            for (int i = 0; i < sortNextRecords.Count; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    allWorkPackagesIncludedTask.Clear();
                    openPubWorkPackagesIncludedTask.Clear();
                    closedWorkPackages.Clear();

                    e.Cancel = true;
                    return;
                }

                //поиск записи в рабочих пакетах по данному чеку
                //чей номер группы выполнения (по записи) совпадает с расчитанным
                Directive directive = (Directive)sortNextRecords[i].Parent;
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

                WorkPackageRecord wpr =
                    openPubWpRecords.Where(r => r.PerformanceNumFromStart == parentCountPerf
                                             && r.WorkPackageItemType == directive.SmartCoreObjectType.ItemId
                                             && r.DirectiveId == directive.ItemId).FirstOrDefault();
                if (wpr != null)
                {
                    WorkPackage wp = openPubWorkPackagesIncludedTask.GetItemById(wpr.WorkPakageId);
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
            List<AbstractRecord> sortLastRecords = (from record in lastRecords
                                                    orderby record.RecordDate descending 
                                                    select record).ToList();
            ////////////////////////////////////////////

            foreach (AbstractRecord t in sortLastRecords)
            {
                if (backgroundWorker.CancellationPending)
                {
                    allWorkPackagesIncludedTask.Clear();
                    openPubWorkPackagesIncludedTask.Clear();
                    closedWorkPackages.Clear();

                    e.Cancel = true;
                    return;
                }

                DirectiveRecord directiveRecord = (DirectiveRecord)t;
                WorkPackage workPackage =
                    closedWorkPackages.Where(wp => wp.ItemId == directiveRecord.DirectivePackageId).FirstOrDefault();
                Invoke(new Action<AbstractPerformanceRecord, WorkPackage>(AddListViewItem),
                       new object[] { t, workPackage });
            }
            #endregion

            allWorkPackagesIncludedTask.Clear();
            openPubWorkPackagesIncludedTask.Clear();
            closedWorkPackages.Clear();

            backgroundWorker.ReportProgress(100);
        }
        #endregion

        #region protected override void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)

        protected override void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarLoad.Value = e.ProgressPercentage;
        }
        #endregion

        #region protected override void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

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

                foreach (WorkPackage workPackage in _openPubWorkPackages)
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
            _toolStripMenuItemsWorkPackages.Text = "Add to Work package";

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
            return _currentDirective.PerformanceRecords.ToArray();
        }
        #endregion

        #region protected override void AddListViewItem(NextPerformance np)
        protected override void AddListViewItem(NextPerformance np)
        {
            Directive d = np.Parent as Directive;
            string[] subs =
                new[]
                    {
                        np.WorkType + (d == null ? "" : " §:" + d.Paragraph),
                        np.PerformanceDate != null 
                            ? UsefulMethods.NormalizeDate((DateTime)np.PerformanceDate) 
                            : "N/A",
                        np.PerformanceSource.ToString(),
                            "",
                    };

            ListViewItem newItem = new ListViewItem(subs)
            {
                BackColor = UsefulMethods.GetColor(np),
                Group = listViewCompliance.Groups[0],
                Tag = np,
            };
            listViewCompliance.Items.Add(newItem);
        }
        #endregion

        #region private void AddListViewItem(AbstractPerformanceRecord apr, WorkPackage workPackage)
        private void AddListViewItem(AbstractPerformanceRecord apr, WorkPackage workPackage)
        {
            DirectiveRecord directiveRecord = (DirectiveRecord)apr;

            string workTypeString = "";
            if (directiveRecord.Parent is Directive)
            {
                Directive parentDirective = (Directive)directiveRecord.Parent;
                workTypeString = parentDirective.WorkType + " §:" + parentDirective.Paragraph;
            }
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
            if (workPackage != null)
            {
                //запись о выполнении блокируется найденым пакетом
                apr.DirectivePackage = workPackage;
                newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                newItem.ToolTipText =
                    "Perform of the task:" + workTypeString +
                    "\nadded by Work Package:" +
                    "\n" + directiveRecord.DirectivePackage.Title +
                    "\nTo remove a performance of task, you need to exclude task from this work package," +
                    "\nor delete the work package ";
            }
            listViewCompliance.Items.Add(newItem);
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
            Directive directive;
            NextPerformance np;

            if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
            {
                np = (NextPerformance)listViewCompliance.SelectedItems[0].Tag;
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
                directive = (Directive)np.Parent;
                dlg = new DirectiveComplianceDialog(directive, np)
                {
                    Text = "Add new compliance for " + directive.WorkType
                };
            }
            else if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
                directive = (Directive)record.Parent;
                dlg = new DirectiveComplianceDialog(directive, record)
                {
                    Text = "Edit exist compliance for " + directive.WorkType
                };
            }
            else return;

            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);    
        }
        #endregion

        #region private void AddToWorkPackageItemClick(object sender, EventArgs e)

        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			if (listViewCompliance.SelectedItems.Count <= 0 ||
				 parentAircraft == null) return;

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
																				  parentAircraft, 
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
                        ReferenceEventArgs refArgs = new ReferenceEventArgs
                        {
                            TypeOfReflection = ReflectionTypes.DisplayInNew,
                            DisplayerText =  $"{_currentDirective.ParentBaseComponent.GetParentAircraftRegNumber()}. {wp.Title}",
							RequestedEntity = new WorkPackageScreen(wp)
                        };
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
                                "\nadded by Work Package:" +
                                "\n" + record.DirectivePackage.Title +
                                "\nTo remove a performance of task, you need to exclude task from this work package," +
                                "\nor delete the work package ",
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

        #region private void ButtonEdit_Click(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0 || listViewCompliance.SelectedItems[0].Tag is Directive)
            {
                return;
            }

            DirectiveComplianceDialog dlg;
            DirectiveRecord record;
            Directive directive;
            if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
                directive = (Directive)record.Parent;
                dlg = new DirectiveComplianceDialog(directive, record)
                          {
                              Text = "Edit exist compliance for " + directive.WorkType
                          };
            }
            else return;

            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);
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
