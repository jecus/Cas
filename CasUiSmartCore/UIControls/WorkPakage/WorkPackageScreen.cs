using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.PurchaseControls;
using CASReports.Builders;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using Telerik.WinControls.UI;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.WorkPakage
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class WorkPackageScreen : ScreenControl
	{
		#region Fields

		private readonly WorkPackage _currentWorkPackage;

		private AircraftFlight _aircraftFlight;

		private ICommonCollection<BaseEntityObject> _initialItemsArray = new CommonCollection<BaseEntityObject>();
		private ICommonCollection<BaseEntityObject> _resultItemsArray = new CommonCollection<BaseEntityObject>();

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(IWorkPackageItemFilterParams));
		/// <summary>
		/// Рабочие пакеты, имеющие те же задачи, что и текущий
		/// </summary>
		private CommonCollection<WorkPackage> _relatedWorkPackages = new CommonCollection<WorkPackage>();
		private WorkPackageView _directivesViewer;
		private ForecastKitsReportBuilder _forecastKitsReportBulder;
		private ComponentsReportBuilder _componentsReportBulder;
		private MaintenanceReportBuilder _maintenanceReportBuilder;
		private WOBuilderScat _builderScat;
#if KAC
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemBindingTasks;
		private RadMenuItem _toolStripMenuItemDeleteRecord;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private List<RadMenuItem> _toolStripMenuItemsWorkPackages;
		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem _itemPrintWorkScope;
		private ToolStripMenuItem _itemPrintOverviewWp;
		private ToolStripMenuItem _itemPrintOverviewWO;
		private ToolStripMenuItem _itemPrintEquipmentAndMaterials;
		private ToolStripMenuItem _itemPrintComponents;
		private ToolStripMenuItem _itemPrintMaintenanceReport;
		private RadMenuItem _toolStripMenuShowTaskCard;
		private RadMenuItem _toolStripMenuShowKits;
		#endregion

		#region Constructors

		#region private WorkPackageScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private WorkPackageScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public WorkPackageScreen(Aircraft currentAircraft)
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="workPackage"></param>
		public WorkPackageScreen(WorkPackage workPackage)
			: this()
		{
			if (workPackage == null)
				throw new ArgumentNullException("workPackage");
			Aircraft a = GlobalObjects.AircraftsCore.GetAircraftById(workPackage.ParentId);
			if (a == null)
				throw new ArgumentNullException("workpackage","parnt aircraft must be not null");
			CurrentAircraft = a;
			StatusTitle = a.RegistrationNumber + " " + "Work packages";

			_currentWorkPackage = workPackage;

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();

			_itemPrintWorkScope = new ToolStripMenuItem { Text = "Work Scope" };
			_itemPrintOverviewWp = new ToolStripMenuItem { Text = "Overview the work package" };
			_itemPrintOverviewWO = new ToolStripMenuItem { Text = "Overview the work order" };
			_itemPrintEquipmentAndMaterials = new ToolStripMenuItem { Text = "Equipment and Materials" };
			_itemPrintComponents = new ToolStripMenuItem { Text = "Components" };
			_itemPrintMaintenanceReport = new ToolStripMenuItem { Text = "Overview the maintenance report" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintComponents, _itemPrintWorkScope, _itemPrintOverviewWp, _itemPrintOverviewWO, _itemPrintEquipmentAndMaterials, _itemPrintMaintenanceReport });

			ButtonPrintMenuStrip = buttonPrintMenuStrip;

			#endregion

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

			_initialItemsArray.Clear();
			_initialItemsArray = null;

			_resultItemsArray.Clear();
			_resultItemsArray = null;

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages)
					item.Dispose();
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			if (_toolStripMenuItemDeleteRecord != null) _toolStripMenuItemDeleteRecord.Dispose();
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();

			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Cancelled)
				return;

			labelDateAsOf.Text = "WP Status: " + _currentWorkPackage.Status;

			_statusImageLinkLabelFlight.Enabled = _aircraftFlight != null;

			switch (_currentWorkPackage.Status)
			{
				case WorkPackageStatus.Published:
					{
						buttonAddNonRoutineJob.Enabled = false;
						buttonPublish.Enabled = false;
						buttonClose.Enabled = true;
						if (_currentWorkPackage.CanClose == false)
						{
							buttonClose.ShowToolTip = true;
							buttonClose.ToolTipText = "This work package can not be closed";
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
						if(_currentWorkPackage.CanPublish == false)
						{
							buttonPublish.ShowToolTip = true;
							buttonPublish.ToolTipText = "This work package can not be republished";
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
						if (_currentWorkPackage.CanClose == false)
						{
							buttonClose.ShowToolTip = true;
							buttonClose.ToolTipText = "This work package can not be closed";
						}
						else
						{
							buttonClose.ShowToolTip = false;
							buttonClose.ToolTipText = "";
						}
						break;
					}
			}
			_directivesViewer.SetItemsArray(_resultItemsArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialItemsArray.Clear();
			_relatedWorkPackages.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Work Package");
			
			//GlobalObjects.CasEnvironment.Loader.LoadWorkPackageItems(_currentWorkPackage);
			GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(_currentWorkPackage);
			if (_currentWorkPackage.MaxClosingDate < _currentWorkPackage.MinClosingDate)
				_currentWorkPackage.CanClose = false;
			var wpItems = new List<BaseEntityObject>();
			foreach (WorkPackageRecord record in _currentWorkPackage.WorkPakageRecords) 
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

			if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
			{
				AnimatedThreadWorker.ReportProgress(10, "load related Work Packages");
			   
				//_relatedWorkPackages.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(CurrentAircraft,
				//                                                                 WorkPackageStatus.Opened,
				//                                                                 true,
				//                                                                 wpItems));
				//_relatedWorkPackages.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(CurrentAircraft,
				//                                                                                 WorkPackageStatus.Published,
				//                                                                                 true,
				//                                                                                 wpItems));

				//сбор всех записей рабочих пакетов для удобства фильтрации
				//List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
				//foreach (WorkPackage openWorkPackage in _relatedWorkPackages)
				//    openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

				foreach (WorkPackageRecord record in _currentWorkPackage.WorkPakageRecords.Where(i => i.Task != null))
				{
					AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "calculation of directives");

					if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
					{
						MaintenanceCheck mc = (MaintenanceCheck) record.Task;
						MaintenanceNextPerformance mnp = 
							mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
						if(mnp != null)
							_initialItemsArray.Add(mnp);
					}
					else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
					{
						_initialItemsArray.Add((BaseEntityObject)record.Task);
					}
					else if (record.Task.SmartCoreObjectType == SmartCoreType.Component)
					{
						if (record.Task.NextPerformances.Count > 0)
							_initialItemsArray.Add(record.Task.NextPerformances[0]);
						else _initialItemsArray.Add((BaseEntityObject)record.Task);
					}
					else
					{
						//if (GlobalObjects.CasEnvironment.Calculator.GetPerformance(record.Task, record.PerformanceNumFromStart))
						//    _initialItemsArray.Add(record.Task.NextPerformances[0]);
						//else _initialItemsArray.Add((BaseEntityObject)record.Task);
						if (record.Task.NextPerformances.Count > 0)
							_initialItemsArray.Add(record.Task.NextPerformances[0]);
						else _initialItemsArray.Add((BaseEntityObject)record.Task);
					}

					//WorkPackageRecord workPackageRecord =
					//        openWPRecords.FirstOrDefault(wpr => wpr.WorkPakageId != record.WorkPakageId
					//                                            && wpr.WorkPackageItemType == record.WorkPackageItemType
					//                                            && wpr.DirectiveId == record.DirectiveId
					//                                            && wpr.PerformanceNumFromStart <= record.PerformanceNumFromStart);
					//if (workPackageRecord != null)
					//{
					//    //у одной из задач данного рабочего пакета,
					//    //есть выполнение с меньшим порядковым номером 
					//    //в другом открытом рабочем пакете
					//    //поэтому данный рабочий пакет закрыть нельзя
					//    _currentWorkPackage.CanClose = false;
					//    if (record.Task.NextPerformances.Count > 0)
					//    {
					//        record.Task.NextPerformances[0].BlockedByWP
					//            = _relatedWorkPackages.GetItemById(workPackageRecord.WorkPakageId);
					//    }
					//}
				}
			}
			else
			{
				//При закоытом Рабочем пакете, в список попадают записи о выполении
				//сделанные в рамках данного рабочего пакета
				AnimatedThreadWorker.ReportProgress(10, "load related Work Packages");
				//_relatedWorkPackages.AddRange(GlobalObjects.CasEnvironment.Loader.GetWorkPackages(CurrentAircraft,
				//                                                                 WorkPackageStatus.Closed,
				//                                                                 true,
				//                                                                 wpItems));
				//сбор всех записей рабочих пакетов для удобства фильтрации
				//List<WorkPackageRecord> closeWPRecords = new List<WorkPackageRecord>();
				//foreach (WorkPackage workPackage in _relatedWorkPackages)
				//    closeWPRecords.AddRange(workPackage.WorkPakageRecords);
				AbstractPerformanceRecord apr;

				var q = _currentWorkPackage.WorkPakageRecords.Where(i => i.Task == null);
				foreach (var workPackageRecord in q)
				{
					var a = workPackageRecord.ItemId;

				}


				foreach (WorkPackageRecord record in _currentWorkPackage.WorkPakageRecords)
				{
					AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "check records");   



					if (record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
					{
						AnimatedThreadWorker.ReportProgress((int)(currentProc += delay), "calculation of Maintenance checks");
						//GlobalObjects.CasEnvironment.Calculator.GetNextPerformance((MaintenanceCheck)record.Task, maintenanceChecks,
						//                                                           out next, out remains, out condition,
						//                                                           CurrentAircraft.AverageUtilization);
						//_initialItemsArray.Add((BaseEntityObject)record.Task);
						apr = record.Task.PerformanceRecords
									.Cast<AbstractPerformanceRecord>()
									.FirstOrDefault(pr => pr.DirectivePackageId == _currentWorkPackage.ItemId);

						if (apr != null)
							_initialItemsArray.Add(apr);
						else
						{
							MaintenanceCheck mc = (MaintenanceCheck)record.Task;
							if(mc.NextPerformances.OfType<MaintenanceNextPerformance>().Any(np => np.PerformanceGroupNum == record.PerformanceNumFromStart))
							{
								MaintenanceNextPerformance mnp =
								mc.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(record.PerformanceNumFromStart);
								if (mnp != null)
									_initialItemsArray.Add(mnp);
							}
							else _initialItemsArray.Add((BaseEntityObject)record.Task);
						}
					}
					else if (record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
					{
						_initialItemsArray.Add((BaseEntityObject)record.Task);
					}
					else
					{
						apr = record.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>().
														FirstOrDefault(pr => pr.DirectivePackageId == _currentWorkPackage.ItemId);

						if (apr != null)
							_initialItemsArray.Add(apr);
						else
						{
							if (record.Task.NextPerformances.Count > 0)
								_initialItemsArray.Add(record.Task.NextPerformances[0]);
							else _initialItemsArray.Add((BaseEntityObject)record.Task);
						}
					}

					//if (closeWPRecords.FirstOrDefault(wpr => wpr.WorkPakageId != record.WorkPakageId
					//                                        && wpr.WorkPackageItemType == record.WorkPackageItemType
					//                                        && wpr.DirectiveId == record.DirectiveId
					//                                        && wpr.PerformanceNumFromStart > record.PerformanceNumFromStart) != null)
					//{
					//    //у одной из задач данного рабочего пакета,
					//    //есть выполнение с большим порядковым номером 
					//    //в другом закрытом рабочем пакете
					//    _currentWorkPackage.CanPublish = false;
					//    _currentWorkPackage.BlockPublishReason =
					//        "From one of the task of this work package," +
					//        "\nhave the execution of a large atomic number" +
					//        "\nin other enclosed work package";

					//}
					if(_currentWorkPackage.WorkPakageRecords
						.Where(wpr=>wpr.Task != null && wpr.Task is Component)
						.Select(wpr=>wpr.Task as Component)
						.Any(d => d.TransferRecords.Any(tr => tr.DirectivePackageId == _currentWorkPackage.ItemId && tr.DODR)))
					{
						//Поиск записи в рабочем пакете по деталям(базовым деталям)
						//в записях о перемещении которых есть запись сделанная в рамках данного 
						//рабочего пакета, и подтвержденная на стороне получателя
						//Если такие записи есть, то рабочий пакет перепубликовать нельзя
						_currentWorkPackage.CanPublish = false;
						if (_currentWorkPackage.BlockPublishReason != "")
							_currentWorkPackage.BlockPublishReason += "\n";
						_currentWorkPackage.BlockPublishReason = 
							"This work package has in its task of moving component," + 
							"\nwhich was confirmed on the destination side";
					}
				}   
			}

			var discrepancy = GlobalObjects.CasEnvironment.NewLoader.GetObject<DiscrepancyDTO,Discrepancy>(new Filter("WorkPackageId", _currentWorkPackage.ItemId));
			if (discrepancy != null)
				_aircraftFlight = GlobalObjects.AircraftFlightsCore.GetAircraftFlightById(CurrentAircraft.ItemId, discrepancy.FlightId);
			
			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(95, "filter directives");

			FilterItems(_initialItemsArray, _resultItemsArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "calculation over");
		}
		#endregion

		#region private void CloseWorkPackage()
		private void CloseWorkPackage()
		{
			IEnumerable<WorkPackageRecord> blockedRecords = 
				_currentWorkPackage.WorkPakageRecords
				.Where(rec => rec.Task != null && 
							  rec.Task.NextPerformances != null && 
							  rec.Task.NextPerformances.Count > 0 && 
							  rec.Task.NextPerformances.Where(np => np.BlockedByPackage != null && 
																	np.BlockedByPackage.ItemId != _currentWorkPackage.ItemId).Count() > 0);
			if (_currentWorkPackage.CanClose == false || blockedRecords.Count() > 0)
			{
				string message = "This work package can not be closed";
				foreach (WorkPackageRecord blockedRecord in blockedRecords)
				{
					NextPerformance np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByPackage != null);
					message += string.Format("\nTask: {0} blocked by work package {1}",
												blockedRecord.Task,
												np.BlockedByPackage);
				}
				if(_currentWorkPackage.MaxClosingDate < _currentWorkPackage.MinClosingDate)
				{
					message += string.Format("\nMin Closing Date: {0} better than Max Closing Date: {1}",
												_currentWorkPackage.MinClosingDate,
												_currentWorkPackage.MaxClosingDate); 
				}
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			WorkPackageClosingFormNew form = new WorkPackageClosingFormNew(_currentWorkPackage);
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

			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new List<RadMenuItem>();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripMenuItemBindingTasks = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemDeleteRecord = new RadMenuItem();
			_toolStripMenuShowTaskCard = new RadMenuItem();
			_toolStripMenuShowKits = new RadMenuItem();
		// 
		// contextMenuStrip
		// 
		_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuShowTaskCard.Text = "Show Task Card";
			_toolStripMenuShowTaskCard.Click += ToolStripMenuShowTaskCard_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuShowKits
			// 
			_toolStripMenuShowKits.Text = "Show Kits";
			_toolStripMenuShowKits.Click += ToolStripMenuShowKits_Click;
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
			// _toolStripMenuItemBindingTasks
			// 
			_toolStripMenuItemBindingTasks.Text = "Tasks";
			_toolStripMenuItemBindingTasks.Click += ToolStripMenuItemBindTasksClick;
			// 
			// _toolStripMenuItemDeleteRecord
			// 
			_toolStripMenuItemDeleteRecord.Text = "Delete Performance Record";
			_toolStripMenuItemDeleteRecord.Click += ToolStripMenuItemDeletePerformanceRecordClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";

			_contextMenuStrip.Items.Clear();
			_toolStripMenuItemsWorkPackages.Clear();
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				RadMenuItem item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
			_contextMenuStrip.Items.AddRange(_toolStripMenuItemOpen,
				_toolStripMenuItemClose,
				_toolStripMenuShowTaskCard,
				_toolStripMenuShowKits,
				_toolStripMenuItemDelete,
				_toolStripSeparator1,
				_toolStripMenuItemBindingTasks,
				_toolStripSeparator1,
				_toolStripMenuItemHighlight);
		}

		#endregion
		
		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				Highlight highLight = (Highlight) ((ToolStripMenuItem) sender).Tag;
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)return;
			foreach (BaseEntityObject selectedItem in _directivesViewer.SelectedItems)
			{
				try
				{
					var dp = ScreenAndFormManager.GetEditScreenOrForm(selectedItem);
					if (dp.DisplayerType == DisplayerType.Screen)
					{
						var refe = new ReferenceEventArgs();
						refe.SetParameters(dp);
						InvokeDisplayerRequested(refe);
					}
					else
					{
						if (dp.Form.ShowDialog() == DialogResult.OK)
						{
							if (dp.Form is NonRoutineJobForm)
								AnimatedThreadWorker.RunWorkerAsync();
						}
					}
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while opening record", ex);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)

		private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;
			var selectedItem = _directivesViewer.SelectedItems[0];

			IBaseEntityObject obj;
			if (selectedItem is NextPerformance)
				obj = (selectedItem as NextPerformance).Parent;
			else if (selectedItem is AbstractPerformanceRecord)
				obj = (selectedItem as AbstractPerformanceRecord).Parent;
			else obj = selectedItem;

			var attachedFile = GetItemFile(obj);
			
			if (attachedFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string) new GlobalTermsProvider()["SystemName"],
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
					MessageBox.Show(message, (string) new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", selectedItem, selectedItem.ItemId, attachedFile.ItemId);
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void ToolStripMenuShowKits_Click(object sender, EventArgs e)

		private void ToolStripMenuShowKits_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;
			var selectedItem = _directivesViewer.SelectedItems[0];

			IBaseEntityObject obj;
			if (selectedItem is NextPerformance)
				obj = (selectedItem as NextPerformance).Parent;
			else if (selectedItem is AbstractPerformanceRecord)
				obj = (selectedItem as AbstractPerformanceRecord).Parent;
			else obj = selectedItem;

			var kitRequired = GetIKitRequired(obj);

			var kitForm = new KitForm(kitRequired);
			kitForm.ShowDialog();
		}

		#endregion

		#region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		{
		   ButtonDeleteClick();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePerformanceRecordClick(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeletePerformanceRecordClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			//List<AbstractPerformanceRecord> selectedItems = new List<AbstractPerformanceRecord>();
			//foreach (BaseEntityObject o in _directivesViewer.SelectedItems)
			//{
			//    if (o is MaintenanceNextPerformance)
			//    {
			//        MaintenanceNextPerformance mnp = (MaintenanceNextPerformance)o;
			//        selectedItems.AddRange(mnp.PerformanceGroup.Checks.ToArray());
			//        continue;
			//    }
			//    if (o is NextPerformance)
			//    {
			//        selectedItems.Add(((NextPerformance)o).Parent);
			//        continue;
			//    }

			//    IBaseEntityObject parent;
			//    if (o is AbstractPerformanceRecord)
			//    {
			//        parent = ((AbstractPerformanceRecord)o).Parent;
			//    }
			//    else parent = o;

			//    if (parent is Directive)
			//    {
			//        Directive d = (Directive)parent;
			//        List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete directive " + d.WorkType + " from work package" +
			//                            "\nthis directive is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is BaseDetail)
			//    {
			//        BaseDetail d = (BaseDetail)parent;
			//        List<TransferRecord> records = new List<TransferRecord>(d.TransferRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete base detail " + d.Description + " from work package" +
			//                            "\nthis base detail is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is Detail)
			//    {
			//        Detail d = (Detail)parent;
			//        List<TransferRecord> records = new List<TransferRecord>(d.TransferRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete base detail " + d.Description + " from work package" +
			//                            "\nthis detail is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is DetailDirective)
			//    {
			//        DetailDirective d = (DetailDirective)parent;
			//        List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete detail directive " + d.DirectiveType + " from work package" +
			//                            "\nthis detail directive is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is MaintenanceCheck)
			//    {
			//        MaintenanceCheck d = (MaintenanceCheck)parent;
			//        List<MaintenanceCheckRecord> records = new List<MaintenanceCheckRecord>(d.PerformanceRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete maintenance check " + d.Name + " from work package" +
			//                            "\nthis maintenance check is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is MaintenanceDirective)
			//    {
			//        MaintenanceDirective d = (MaintenanceDirective)parent;
			//        List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
			//        if (records.Where(r => r.WorkPackageId == _currentWorkPackage.ItemId).Count() > 0)
			//        {
			//            MessageBox.Show("Can not delete maintenance directive " + d.MPDTaskNumber + " from work package" +
			//                            "\nthis maintenance directive is already closed by this work package", "Error", MessageBoxButtons.OK);
			//        }
			//        else selectedItems.Add(parent);
			//    }
			//    else if (parent is NonRoutineJob)
			//    {
			//        if (_currentWorkPackage.Status == WorkPackageStatus.Closed)
			//            MessageBox.Show("Can not delete Non-Routine Job " + ((NonRoutineJob)parent).Title + " from work package" +
			//                            "\nbecause this work package is already closed", "Error", MessageBoxButtons.OK);
			//        else selectedItems.Add(parent);
			//    }
			//}

			//if (selectedItems.Count == 0) return;

			//DialogResult confirmResult =
			//    MessageBox.Show(
			//        selectedItems.Count == 1
			//            ? "Do you really want to delete Item ?"
			//            : "Do you really want to delete selected Items? ", "Confirm delete operation",
			//        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			//if (confirmResult == DialogResult.Yes)
			//{
			//    _directivesViewer.ItemListView.BeginUpdate();
			//    foreach (IBaseEntityObject t in selectedItems)
			//    {
			//        try
			//        {
			//            GlobalObjects.CasEnvironment.Manipulator.DeleteFromWorkPackage(t, _currentWorkPackage);
			//        }
			//        catch (Exception ex)
			//        {
			//            Program.Provider.Logger.Log("Error while deleting data", ex);
			//            return;
			//        }
			//    }
			//    _directivesViewer.ItemListView.EndUpdate();
			//    AnimatedThreadWorker.RunWorkerAsync();
			//}
			//else
			//{
			//    MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
			//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			CloseWorkPackage();
		}

		#endregion

		#region private void ToolStripMenuItemBindTasksClick(object sender, EventArgs e)

		private void ToolStripMenuItemBindTasksClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null || 
				_directivesViewer.SelectedItems.Count == 0 ||
				_directivesViewer.SelectedItems.Count > 1) return;

			if (_directivesViewer.SelectedItem is NextPerformance)
			{
				NextPerformance np = _directivesViewer.SelectedItem as NextPerformance;
				if (np.Parent == null || !(np.Parent is MaintenanceCheck)) return;
				MaintenanceCheckBindTaskInWPForm bindTaskForm = 
					new MaintenanceCheckBindTaskInWPForm(np.Parent as MaintenanceCheck, _currentWorkPackage.MaintenanceChecks, _currentWorkPackage);
				bindTaskForm.ShowDialog(this);
			}
			else if (_directivesViewer.SelectedItem is AbstractPerformanceRecord)
			{
				AbstractPerformanceRecord apr = _directivesViewer.SelectedItem as AbstractPerformanceRecord;
				if (apr.Parent == null || !(apr.Parent is MaintenanceCheck)) return;
				MaintenanceCheckBindTaskInWPForm bindTaskForm =
					new MaintenanceCheckBindTaskInWPForm(apr.Parent as MaintenanceCheck, _currentWorkPackage.MaintenanceChecks, _currentWorkPackage);
				bindTaskForm.ShowDialog(this);
			}
			else
			{
				if (!(_directivesViewer.SelectedItem is MaintenanceCheck)) return;
				MaintenanceCheckBindTaskInWPForm bindTaskForm =
					new MaintenanceCheckBindTaskInWPForm(_directivesViewer.SelectedItem as MaintenanceCheck, _currentWorkPackage.MaintenanceChecks, _currentWorkPackage);
				bindTaskForm.ShowDialog(this);
			}
		}

		#endregion

		#region private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		{
			var form = new NonRoutineJobForm(new WorkPackageRecord(_currentWorkPackage.ItemId, -1, -1), _currentWorkPackage);

			if (form.ShowDialog() == DialogResult.OK) 
				AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonPublishClick(object sender, EventArgs e)

		private void ButtonPublishClick(object sender, EventArgs e)
		{
			if (_currentWorkPackage.CanPublish == false)
			{
				string message = "This work package can not be published";
				if (_currentWorkPackage.BlockPublishReason != "")
					message += "\n" + _currentWorkPackage.BlockPublishReason;

				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
				GlobalObjects.WorkPackageCore.Publish(_currentWorkPackage, DateTime.Now, "");
			else
			{
				switch (MessageBox.Show(@"This work package is already closed," +
										"\nif you want to republish it," +
										"\nrecordings created during its execution will be erased." + "\n\n Republish " +
										_currentWorkPackage.Title + " work package?", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button2))
				{
					case DialogResult.Yes:
						GlobalObjects.WorkPackageCore.Publish(_currentWorkPackage, DateTime.Now, "");
						break;
					case DialogResult.No:
						//arguments.Cancel = true;
						break;
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
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
				
				if (parent is Directive)
				{
					Directive d = (Directive)parent;
					List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete directive " + d.WorkType + " from work package" +
										"\nthis directive is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is BaseComponent)
				{
					var d = (BaseComponent)parent;
					var records = new List<TransferRecord>(d.TransferRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete base component " + d.Description + " from work package" +
										"\nthis base component is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is Component)
				{
					Component d = (Component)parent;
					List<TransferRecord> records = new List<TransferRecord>(d.TransferRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete base component " + d.Description + " from work package" +
										"\nthis component is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is ComponentDirective)
				{
					ComponentDirective d = (ComponentDirective)parent;
					List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete component directive " + d.DirectiveType + " from work package" +
										"\nthis component directive is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is MaintenanceCheck)
				{
					MaintenanceCheck d = (MaintenanceCheck)parent;
					List<MaintenanceCheckRecord> records = new List<MaintenanceCheckRecord>(d.PerformanceRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete maintenance check " + d.Name + " from work package" +
										"\nthis maintenance check is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is MaintenanceDirective)
				{
					MaintenanceDirective d = (MaintenanceDirective)parent;
					List<DirectiveRecord> records = new List<DirectiveRecord>(d.PerformanceRecords.ToArray());
					if (records.Any(r => r.DirectivePackageId == _currentWorkPackage.ItemId))
					{
						MessageBox.Show("Can not delete maintenance directive " + d.MPDTaskNumber + " from work package" +
										"\nthis maintenance directive is already closed by this work package", "Error", MessageBoxButtons.OK);
					}
					else selectedItems.Add(parent);
				}
				else if (parent is NonRoutineJob)
				{
					if (_currentWorkPackage.Status == WorkPackageStatus.Closed)
						MessageBox.Show("Can not delete Non-Routine Job " + ((NonRoutineJob)parent).Title + " from work package" +
										"\nbecause this work package is already closed", "Error", MessageBoxButtons.OK);
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
				_directivesViewer.radGridView1.BeginUpdate();

				GlobalObjects.WorkPackageCore.DeleteFromWorkPackage(_currentWorkPackage.ItemId, selectedItems);

				_directivesViewer.radGridView1.EndUpdate();
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
			var form = new WorkPackageEditorForm(_currentWorkPackage);
			form.ShowDialog();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new WorkPackageView(_currentWorkPackage);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.CustomMenu = _contextMenuStrip;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			
			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;

					var selectedItem = _directivesViewer.SelectedItems[0];
					IBaseEntityObject obj;
					if (selectedItem is NextPerformance)
						obj = (selectedItem as NextPerformance).Parent;
					else if (selectedItem is AbstractPerformanceRecord)
						obj = (selectedItem as AbstractPerformanceRecord).Parent;
					else obj = selectedItem;

					var k = GetIKitRequired(obj);
					_toolStripMenuShowKits.Enabled = k != null && k.Kits.Count > 0;
					_toolStripMenuShowTaskCard.Enabled = GetItemFile(obj) != null;

				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			_toolStripMenuItemHighlight.Enabled = _directivesViewer.SelectedItems.Count > 0;
			_toolStripMenuItemOpen.Enabled = _directivesViewer.SelectedItems.Count > 0;
			_toolStripMenuItemClose.Enabled = _directivesViewer.SelectedItems.Count > 0;
			foreach (RadMenuItem t in _toolStripMenuItemsWorkPackages)
				t.Enabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
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
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == _itemPrintWorkScope)
			{
				var form = new SelectWorkscopePrintTasksForm(_currentWorkPackage);
				if (form.ShowDialog() != DialogResult.OK)
				{
					e.Cancel = true;
					return;
				}

				_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
				_workscopeReportBuilder.WorkPackage = _currentWorkPackage;
				_workscopeReportBuilder.AddDirectives(form.SelectedItems);
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + _currentWorkPackage.Title + "." + "Workscope";
				e.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Work Scope)");
			}
			else if (sender == _itemPrintOverviewWp)
			{
				var form = new SelectWPPrintTasksForm(_currentWorkPackage);
				form.ShowDialog();
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Overview the work package)");
			}
			else if (sender == _itemPrintOverviewWO)
			{
				var form = new SelectWPPrintTasksForm(_currentWorkPackage, true);
				form.ShowDialog();
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Overview the work order)");
			}
			else if (sender == _itemPrintEquipmentAndMaterials)
			{
				_forecastKitsReportBulder = new ForecastKitsReportBuilder(_currentWorkPackage, _currentWorkPackage.Kits);
				_forecastKitsReportBulder.FilterSelection = null;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Forecast Kits report";
				e.RequestedEntity = new ReportScreen(_forecastKitsReportBulder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Equipment and Materials)");
			}
			else if (sender == _itemPrintComponents)
			{
				var items = new List<IBaseEntityObject>();
				items.AddRange(_currentWorkPackage.BaseComponents.ToArray());
				items.AddRange(_currentWorkPackage.ComponentDirectives.ToArray());
				items.AddRange(_currentWorkPackage.Components.ToArray());

				_componentsReportBulder = new ComponentsReportBuilder(_currentWorkPackage, items);
				_componentsReportBulder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Components Report";
				e.RequestedEntity = new ReportScreen(_componentsReportBulder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Components)");
			}
			else if (sender == _itemPrintMaintenanceReport)
			{
				_maintenanceReportBuilder = new MaintenanceReportBuilder();
				_maintenanceReportBuilder.ReportedAircraft = CurrentAircraft;

				_maintenanceReportBuilder.ReportedWorkPackage = _currentWorkPackage;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Maintenance Report";
				e.RequestedEntity = new ReportScreen(_maintenanceReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageScreen (Overview the maintenance report)");
			}
			else throw new NotSupportedException("this type of report not supported");
		}
		#endregion

		#region private void ButtonFilter_Click(object sender, System.EventArgs e)

		private void ButtonFilter_Click(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, _initialItemsArray) { Text = "Forecast Filter Form" };

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultItemsArray.Clear();

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialItemsArray, _resultItemsArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<NextPerformance> initialCollection, ICommonCollection<NextPerformance> resultCollection)
		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(ICommonCollection<BaseEntityObject> initialCollection, ICommonCollection<BaseEntityObject> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				//if (pd.Parent != null && pd.Parent is MaintenanceCheck && ((MaintenanceCheck)pd.Parent).Name == "C02")
				//{
				//    pd.ToString();
				//}
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText =
				$"{_currentWorkPackage.Aircraft.RegistrationNumber} {_currentWorkPackage.Title}.Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(_currentWorkPackage);
		}

		#endregion

		#region private AttachedFile GetItemFile(IBaseEntityObject obj)

		private AttachedFile GetItemFile(IBaseEntityObject obj)
		{
			if (obj is Directive)
				return ((Directive) obj).EngineeringOrderFile;
			if (obj is MaintenanceDirective)
				return ((MaintenanceDirective) obj).TaskCardNumberFile;
			if (obj is NonRoutineJob)
				return ((NonRoutineJob) obj).AttachedFile;
			if (obj is ComponentDirective)
				return ((ComponentDirective) obj).MaintenanceDirective?.TaskCardNumberFile;

			return null;
		}

		#endregion

		#region private IKitRequired GetIKitRequired(IBaseEntityObject obj)

		private IKitRequired GetIKitRequired(IBaseEntityObject obj)
		{
			return obj as IKitRequired;
		}

		#endregion

		#region private void LinkWorkPackageEmployeeDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkWorkPackageEmployeeDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new WorkPackageEmployeeForm(_currentWorkPackage);
			form.ShowDialog();
		}

		#endregion


		private void _statusImageLinkLabelFlight_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			var refE = new ReferenceEventArgs();
			refE.DisplayerText = $"{CurrentAircraft.RegistrationNumber} {_aircraftFlight}";
			refE.RequestedEntity = new FlightScreen(_aircraftFlight);
			refE.TypeOfReflection = ReflectionTypes.DisplayInNew;

			InvokeDisplayerRequested(refE);
		}

		#endregion


	}
}
