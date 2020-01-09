using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using TempUIExtentions;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class ComponentComplianceControl : ComplianceControl
    {
        #region Fields

        private Component _currentComponent;
        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;

        #endregion

        #region Properties

        ///<summary>
        ///</summary>
        public Component CurrentComponent
        {
            set
            {
                _currentComponent = value;
                UpdateInformation();
            }
        }

        #endregion

        #region Constructors

        #region public DetailComplianceControl()
        
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ
        ///</summary>
        public ComponentComplianceControl()
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

            try
            {
	            Invoke(new Action(() => listViewCompliance.Items.Clear()));
            }
            catch (Exception)
            {
	           
            }

            if (_currentComponent == null)
            {
                e.Cancel = true;
                return;
            }
			var parentAircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentComponent);
			var lastRecords = new List<AbstractRecord>();
            var nextPerformances = new List<NextPerformance>();

			var allWorkPackagesIncludedTask = new CommonCollection<WorkPackage>();
			var openPubWorkPackagesIncludedTask = new CommonCollection<WorkPackage>();
			var closedWorkPackages = new CommonCollection<WorkPackage>();
			var taskThatIncludeInWorkPackage = new List<IDirective>();

			lastRecords.AddRange(_currentComponent.TransferRecords.ToArray());
            lastRecords.AddRange(_currentComponent.ChangeLLPCategoryRecords.ToArray());
            lastRecords.AddRange(_currentComponent.ActualStateRecords.ToArray());

            //Объекты для в котороые будет извлекаться информация 
            //из записеи о перемещении
            var lastDestination = "";
            //прогнозируемый ресурс
            //если известна родительская деталь данной директивы,
            //то ее текущая наработка и средняя утилизация 
            //используются в качестве ресурсов прогноза
            //для расчета всех просроченных выполнений
            var forecastData = new ForecastData(DateTime.Now,
                                                GlobalObjects.AverageUtilizationCore.GetAverageUtillization(_currentComponent),
                                                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentComponent));

			foreach (var directive in _currentComponent.ComponentDirectives )
	        {
				if (directive.IsAffect().GetValueOrDefault(true))
		        {
			        //расчет след. выполнений директивы.
			        //если известен ресурс прогноза, то будут расчитаны все просрочнные выполнения
			        //если неизвестне, то только первое
			        GlobalObjects.PerformanceCalculator.GetNextPerformance(directive, forecastData);
			        nextPerformances.AddRange(directive.NextPerformances);
			        lastRecords.AddRange(directive.PerformanceRecords.ToArray());

			        if (backgroundWorker.CancellationPending)
			        {
				        e.Cancel = true;
				        return;
			        }
					taskThatIncludeInWorkPackage.Add(directive);
		        }
		        else
		        {
			        var bindedItems = GlobalObjects.BindedItemsCore.GetBindedItemsFor(parentAircraft.ItemId, directive);
					foreach (var bindedItem in bindedItems)
					{
						if (bindedItem is MaintenanceDirective)
						{
							var mpd = (MaintenanceDirective)bindedItem;
							//прогнозируемый ресурс
							//если известна родительская деталь данной директивы,
							//то ее текущая наработка и средняя утилизация 
							//используются в качестве ресурсов прогноза
							//для расчета всех просроченных выполнений						
							//расчет след. выполнений директивы.
							//если известен ресурс прогноза, то будут расчитаны все просрочнные выполнения
							//если неизвестне, то только первое
							GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd, forecastData);
							nextPerformances.AddRange(mpd.NextPerformances);
							lastRecords.AddRange(mpd.PerformanceRecords.ToArray());

							taskThatIncludeInWorkPackage.Add(mpd);
						}
					}
				}
	        }

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if (_openPubWorkPackages == null)
				_openPubWorkPackages = new CommonCollection<WorkPackage>();
			_openPubWorkPackages.Clear();

			//загрузка рабочих пакетов для определения
			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft, WorkPackageStatus.Opened));
			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft, WorkPackageStatus.Published));

			allWorkPackagesIncludedTask.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(parentAircraft,  WorkPackageStatus.All, taskThatIncludeInWorkPackage));

			#region Добавление в список просроченных выполнений

			//и сравнение их с открытыми и опубликованными рабочими пакетами
			openPubWorkPackagesIncludedTask.AddRange(
				allWorkPackagesIncludedTask.Where(wp => wp.Status == WorkPackageStatus.Opened ||
														wp.Status == WorkPackageStatus.Published));
			//сбор всех записей рабочих пакетов для удобства фильтрации
			var openPubWpRecords =
				openPubWorkPackagesIncludedTask.SelectMany(wp => wp.WorkPakageRecords).ToList();
			//LINQ запрос для сортировки записей по дате
			var sortNextRecords = (from record in nextPerformances
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
				var parentDirective = sortNextRecords[i].Parent;
				//номер выполнения
				int parentCountPerf;
				if (parentDirective.LastPerformance != null)
				{
					parentCountPerf = parentDirective.LastPerformance.PerformanceNum <= 0
						? 1
						: parentDirective.LastPerformance.PerformanceNum;
				}
				else parentCountPerf = 0;
				parentCountPerf += parentDirective.NextPerformances.IndexOf(sortNextRecords[i]);
				parentCountPerf += 1;

				var wpr = openPubWpRecords.FirstOrDefault(r => r.PerformanceNumFromStart == parentCountPerf
															&& r.WorkPackageItemType == parentDirective.SmartCoreObjectType.ItemId
															&& r.DirectiveId == parentDirective.ItemId);
				if (wpr != null)
				{
					var wp = openPubWorkPackagesIncludedTask.GetItemById(wpr.WorkPakageId);
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
						if (sortNextRecords[j].Parent == parentDirective)
						{
							sortNextRecords[j].BlockedByPackage = wp;
							Invoke(new Action<int, Color>(SetItemColor), j, Color.FromArgb(Highlight.GrayLight.Color));
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
			var sortLastRecords = (from record in lastRecords
								   orderby record.RecordDate ascending
								   select record).ToList();

			var items = new List<KeyValuePair<AbstractRecord, string[]>>();

			for (int i = 0; i < sortLastRecords.Count; i++)
			{
				if (backgroundWorker.CancellationPending)
				{
					allWorkPackagesIncludedTask.Clear();
					openPubWorkPackagesIncludedTask.Clear();
					closedWorkPackages.Clear();

					e.Cancel = true;
					return;
				}

				string[] subs;
				if (sortLastRecords[i] is DirectiveRecord)
				{
					var directiveRecord = (DirectiveRecord)sortLastRecords[i];
					subs = new[]
					{

								directiveRecord.WorkType,
								UsefulMethods.NormalizeDate(directiveRecord.RecordDate),
								directiveRecord.OnLifelength != null
									? directiveRecord.OnLifelength.ToString()
									: "",
								directiveRecord.Remarks
							};
				}
				else if (sortLastRecords[i] is TransferRecord)
				{
					TransferRecord transferRecord = (TransferRecord)sortLastRecords[i];

					string currentDestination, destinationObject;
					DestinationHelper.GetDestination(transferRecord, out currentDestination, out destinationObject);

					subs = new[]
					{
								lastDestination != ""
									? "Transfered " + destinationObject + " from " + lastDestination + " to " + currentDestination
									: "Transfered " + destinationObject + " to " + currentDestination,
								UsefulMethods.NormalizeDate(transferRecord.TransferDate),
								transferRecord.OnLifelength.ToString(),
								transferRecord.Remarks,
							};
					lastDestination = currentDestination;
				}
				else if (sortLastRecords[i] is ComponentLLPCategoryChangeRecord)
				{
					ComponentLLPCategoryChangeRecord llpRecord = (ComponentLLPCategoryChangeRecord)sortLastRecords[i];
					LLPLifeLimitCategory toCategory = llpRecord.ToCategory;
					subs = new[]
					{
								"Changed to " + toCategory,
								UsefulMethods.NormalizeDate(llpRecord.RecordDate),
								llpRecord.OnLifelength.ToString(),
								llpRecord.Remarks,
							};
				}
				else if (sortLastRecords[i] is ActualStateRecord)
				{
					ActualStateRecord actualStateRecord = (ActualStateRecord)sortLastRecords[i];
					subs = new[]
					{
								"Actual state:",
								UsefulMethods.NormalizeDate(actualStateRecord.RecordDate.Date),
								actualStateRecord.OnLifelength != null
									? actualStateRecord.OnLifelength.ToString()
									: "",
								actualStateRecord.Remarks,
							};
				}
				else
				{
					subs = new[]
					{
								"Unknown record ",
								UsefulMethods.NormalizeDate(sortLastRecords[i].RecordDate),
								sortLastRecords[i].OnLifelength.ToString(),
								sortLastRecords[i].Remarks,
							};
				}
				items.Add(new KeyValuePair<AbstractRecord, string[]>(sortLastRecords[i], subs));
			}

			#endregion

			for (int i = items.Count - 1; i >= 0; i--)
			{
				WorkPackage workPackage = null;
				if (items[i].Key is AbstractPerformanceRecord)
				{
					var apr = items[i].Key as AbstractPerformanceRecord;
					workPackage = closedWorkPackages.FirstOrDefault(wp => wp.ItemId == apr.DirectivePackageId);
				}
				Invoke(new Action<AbstractRecord, string[], WorkPackage>(AddListViewItem), items[i].Key, items[i].Value, workPackage);
			}

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
                    ToolStripMenuItem item = new ToolStripMenuItem(workPackage.Title);
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

        #region private void AddPerformance()
        private void AddPerformance()
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                return;
            }

            ActualStateDialog actualStateDialog;
            DirectiveComplianceDialog detailDirectiveDlg;
            ComponentChangeLLPCategoryRecordForm changeLLPCategoryDlg;
            ComponentLLPCategoryChangeRecord componentLLPCategoryChangeRecord;

            ActualStateRecord actualStateRecord;
            Component component;
            DirectiveRecord record;
            ComponentDirective directive;

            if (listViewCompliance.SelectedItems[0].Tag is NextPerformance)
            {
                var np = (NextPerformance)listViewCompliance.SelectedItems[0].Tag;
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
	            detailDirectiveDlg = new DirectiveComplianceDialog(np.Parent, np)
	            {
		            Text = "Add new compliance for " + np.WorkType
	            };
	            detailDirectiveDlg.ShowDialog();
                if (detailDirectiveDlg.DialogResult == DialogResult.OK) 
                    InvokeComplianceAdded(null);
            }
            else if (listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
                //if (record.DirectivePackage != null)
                //{
                //    MessageBox.Show("Perform of the task:" + listViewCompliance.SelectedItems[0].Text +
                //                    "\nadded by Work Package:" +
                //                    "\n" + record.DirectivePackage.Title +
                //                    "\nTo remove a performance of task, you need to exclude task from this work package," +
                //                    "\nor delete the work package ",
                //                    (string)new GlobalTermsProvider()["SystemName"],
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Warning,
                //                    MessageBoxDefaultButton.Button1);
                //    return;
                //}
                
                directive = (ComponentDirective)record.Parent;
                detailDirectiveDlg = new DirectiveComplianceDialog(directive, record);
                detailDirectiveDlg.Text = "Edit exist compliance for " + directive.DirectiveType;
                detailDirectiveDlg.ShowDialog();
                if (detailDirectiveDlg.DialogResult == DialogResult.OK) 
                    InvokeComplianceAdded(null);
            }
            else if (listViewCompliance.SelectedItems[0].Tag is ComponentLLPCategoryChangeRecord)
            {
                componentLLPCategoryChangeRecord = (ComponentLLPCategoryChangeRecord)listViewCompliance.SelectedItems[0].Tag;
                component = componentLLPCategoryChangeRecord.ParentComponent;
	            if (component == null)
		            component = _currentComponent;
                changeLLPCategoryDlg = new ComponentChangeLLPCategoryRecordForm(component, componentLLPCategoryChangeRecord);
                changeLLPCategoryDlg.Text = "Edit exist Change LLP Category record";
                changeLLPCategoryDlg.ShowDialog();
                if (changeLLPCategoryDlg.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);
            }
            else if (listViewCompliance.SelectedItems[0].Tag is ActualStateRecord)
            {
                actualStateRecord = (ActualStateRecord)listViewCompliance.SelectedItems[0].Tag;
                actualStateDialog = new ActualStateDialog(actualStateRecord);
                actualStateDialog.Text = "Edit exist Actual state record";
                actualStateDialog.ShowDialog();
                if (actualStateDialog.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);
            }
            else return;
        }
        #endregion

        #region private void AddToWorkPackageItemClick(object sender, EventArgs e)

        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
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

                    if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(nextPerformances, wp.ItemId, parentAircraft, out message))
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
                        refArgs.DisplayerText = $"{_currentComponent.GetParentAircraftRegNumber()}.{wp.Title}";
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

        #region public object[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив технических записей (DirectiveRecord)
        /// </summary>
        /// <returns>Массив технических записей (DirectiveRecord)</returns>
        public object[] GetItemsArray()
        {
            return (from ListViewItem item in listViewCompliance.Items select item.Tag).ToArray();
        }
        #endregion

        #region public void UpdateInformation()
        /// <summary>
        /// Обновление информации ЭУ
        /// </summary>
        public void UpdateInformation()
        {
            if(_contextMenuStrip == null)
                InitToolStripMenuItems();

            backgroundWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            AddPerformance();
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)return;

            if(listViewCompliance.SelectedItems[0].Tag is DirectiveRecord)
            {
                DirectiveRecord record = (DirectiveRecord)listViewCompliance.SelectedItems[0].Tag;
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

                switch (MessageBox.Show(@"Delete this compliance " + record.RecordType + " ?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.PerformanceCore.Delete(record);
                        InvokeComplianceAdded(null);
                        break;
                    case DialogResult.No:
                        break;
                } 
            }
            else if (listViewCompliance.SelectedItems[0].Tag is ActualStateRecord)
            {
                ActualStateRecord record = (ActualStateRecord)listViewCompliance.SelectedItems[0].Tag;

                switch (MessageBox.Show(@"Delete this actual state record ?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.ComponentCore.DeleteActualStateRecord(record);
                        InvokeComplianceAdded(null);
                        break;
                    case DialogResult.No:
                        break;
                }

            }
            else if (listViewCompliance.SelectedItems[0].Tag is ComponentLLPCategoryChangeRecord)
            {
                ComponentLLPCategoryChangeRecord record = (ComponentLLPCategoryChangeRecord)listViewCompliance.SelectedItems[0].Tag;

	            if (record.ParentComponent == null)
		            record.ParentComponent = _currentComponent;

                switch (MessageBox.Show(@"Delete this LLP category change record ?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Yes:
                        GlobalObjects.ComponentCore.DeleteLLPCategoryChangeRecord(record);
                        InvokeComplianceAdded(null);
                        break;
                    case DialogResult.No:
                        break;
                }

            }
        }
        #endregion

        #region private void ButtonEdit_Click(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            AddPerformance();
        }

        #endregion

        #region private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        private void ButtonRegisterActualStateClick(object sender, EventArgs e)
        {
            ActualStateDialog actualStateDialog = new ActualStateDialog(_currentComponent) { Text = "Add new Actual state record" };
            actualStateDialog.ShowDialog();
            if (actualStateDialog.DialogResult == DialogResult.OK) InvokeComplianceAdded(null);
        }
        #endregion

        #region private void ListViewComplainceDoubleClick(object sender, EventArgs e)

        private void ListViewComplainceDoubleClick(object sender, EventArgs e)
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
				else if (listViewCompliance.SelectedItems[0].Tag is ComponentLLPCategoryChangeRecord)
                {
	                if (_currentComponent.ParentBaseComponent != null)
	                {
		                var llpFromBaseComponent = _currentComponent.ParentBaseComponent.ChangeLLPCategoryRecords.GetLast();
		                if (llpFromBaseComponent != null)
		                {
			                var llpRecord = listViewCompliance.SelectedItems[0].Tag as ComponentLLPCategoryChangeRecord;
			                if (llpRecord.ToCategory == llpFromBaseComponent.ToCategory &&
			                    llpRecord.RecordDate == llpFromBaseComponent.RecordDate)
			                {
				                ButtonDelete.Enabled = false;
			                }

		                }
	                }
                }
            }
        }
        #endregion

        #region private void InsertListViewItem(int index, AbstractRecord record, WorkPackage workPackage)
        private void AddListViewItem(AbstractRecord record, string[] subs, WorkPackage workPackage)
        {
            Color foreColor = Color.Black;
            if (record is ActualStateRecord)
                foreColor = Color.FromArgb(0, 122, 122, 122);

            ListViewItem newItem = new ListViewItem(subs)
            {
                Group = listViewCompliance.Groups[1],
                Tag = record,
                ForeColor = foreColor
            };

            if (record is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)record;
                if (workPackage != null)
                {
                    //запись о выполнении блокируется найденым пакетом
                    apr.DirectivePackage = workPackage;
                    newItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                    newItem.ToolTipText =
                        "Perform of the task:" + apr.Parent +
                        "\nadded by Work Package:" +
                        "\n" + apr.DirectivePackage.Title +
                        "\nTo remove a performance of task, you need to exclude task from this work package," +
                        "\nor delete the work package ";
                }
                else if (apr is DirectiveRecord)
                {
                    DirectiveRecord dr = apr as DirectiveRecord;
                    if (dr.MaintenanceDirectiveRecordId > 0)
                    {
                        DirectiveRecord mdr = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<DirectiveRecordDTO,DirectiveRecord>(dr.MaintenanceDirectiveRecordId);
                        if (mdr != null && mdr.ParentType == SmartCoreType.MaintenanceDirective)
                        {
                            MaintenanceDirective md = GlobalObjects.MaintenanceCore.GetMaintenanceDirective(mdr.ParentId);
                            if (md != null)
                            {
                                newItem.ToolTipText =
                                    "Perform of the task:" + dr.WorkType +
                                    "\nadded by MPD Item:" +
                                    "\n" + md.TaskNumberCheck;
                            }
                        }
                    }
                }
            }
            //listViewCompliance.Items.Insert(index, newItem);
            listViewCompliance.Items.Add(newItem);
        }
        #endregion

        #endregion
    }
}