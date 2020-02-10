using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AvControls;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MaintananceProgram.CheckNew;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Relation;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.MaintananceProgram
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class MaintenanceDirectiveListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<MaintenanceDirective> _initialDirectiveArray = new CommonCollection<MaintenanceDirective>();
		private ICommonCollection<MaintenanceDirective> _resultDirectiveArray = new CommonCollection<MaintenanceDirective>();

		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private Forecast _currentForecast;
		private BaseComponent _currentBaseComponent;

		private MaintenanceDirectiveListView _directivesViewer;

		private CommonFilterCollection _initialFilter;
		private CommonFilterCollection _additionalFilter = new CommonFilterCollection(typeof(MaintenanceDirective));

#if KAC
		private MaintenanceDirectivesReportBuilderKAC _maintenanceDirectiveFullReportBuilder = new MaintenanceDirectivesReportBuilderKAC();
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private MaintenanceDirectivesFullReportBuilder _maintenanceDirectiveFullReportBuilder = new MaintenanceDirectivesFullReportBuilder();
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
		private MaintenanceDirectivesAMReportBuilder _amReportBuilder = new MaintenanceDirectivesAMReportBuilder();
		private MaintenanceDirectivesAMSupplimentalReportBuilder _amSuppReportBuilder = new MaintenanceDirectivesAMSupplimentalReportBuilder();
#endif
		private MaintenanceDirectivesReportBuilder _maintenanceDirectiveReportBuilder;
		private MaintenanceDirectivesFullReportBuilderLitAVia _maintenanceDirectiveReportBuilderLitAVia;

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportMP;
		private ToolStripMenuItem itemPrintReportMPLimit;
		private ToolStripMenuItem itemPrintReportAMP;
		private ToolStripMenuItem itemPrintWorkscope;
		private ToolStripMenuItem itemPrintMPSTR;
		private ToolStripMenuItem itemPrintMPSYS;
		private ToolStripMenuItem itemPrintMPZonal;
		private ToolStripMenuItem itemPrintMPAWL;
		private ToolStripMenuItem itemPrintMPLine;
		private ToolStripMenuItem itemPrintMPSSIP;
		private ToolStripMenuItem itemPrintLitAvia;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemComposeWorkPackage;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemShowTaskCard;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuSeparatorItem _toolStripSeparator4;
		private RadMenuItem _toolStripMenuItemsWorkPackages;
		private RadMenuItem _toolStripMenuItemsWShowWP;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;

		#endregion

		#region Constructors

		#region private MaintenanceDirectiveListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private MaintenanceDirectiveListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public MaintenanceDirectiveListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters = null)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		///<param name="initialFilters"></param>
		public MaintenanceDirectiveListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters = null)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = currentAircraft.RegistrationNumber + ". MPD Status";
			//_filterSelection = new PrimaryDirectiveFilterSelectionForm(primaryDirectiveType, null);
			_maintenanceDirectiveReportBuilder = new MaintenanceDirectivesReportBuilder();

			if (initialFilters != null)
			{
				if (_initialFilter == null)
					_initialFilter = new CommonFilterCollection(typeof(MaintenanceDirective), initialFilters);
				else
				{
					_initialFilter.Filters.Clear();
					_initialFilter.Filters.AddRange(initialFilters);
				}
			}

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportMP = new ToolStripMenuItem { Text = "MP" };
			itemPrintReportMPLimit = new ToolStripMenuItem { Text = "MP Limit" };
			itemPrintReportAMP = new ToolStripMenuItem { Text = "AMP STATUS" };
			itemPrintWorkscope = new ToolStripMenuItem { Text = "WORK SCOPE"};
			itemPrintMPSTR = new ToolStripMenuItem { Text = "MP STR" };
			itemPrintMPSYS = new ToolStripMenuItem { Text = "MP SYS" };
			itemPrintMPZonal = new ToolStripMenuItem { Text = "MP Zonal" };
			itemPrintMPAWL = new ToolStripMenuItem { Text = "MP AWL + CMR + FIS" };
			itemPrintMPLine = new ToolStripMenuItem { Text = "MP Operator" };
			itemPrintMPSSIP = new ToolStripMenuItem { Text = "MP SSIP" };
			itemPrintLitAvia = new ToolStripMenuItem { Text = "SS LA" };


			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportMP, itemPrintReportMPLimit, itemPrintReportAMP, itemPrintWorkscope,
				itemPrintMPSYS, itemPrintMPSTR, itemPrintMPZonal, itemPrintMPAWL, itemPrintMPLine, itemPrintMPSSIP, itemPrintLitAvia  });

			ButtonPrintMenuStrip = buttonPrintMenuStrip;

			#endregion

			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		/// <summary>
		/// Производит очистку ресурсов страницы
		/// </summary>
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

			AnimatedThreadWorker.Dispose();

			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
			_openPubWorkPackages.Clear();
			_openPubQuotations.Clear();

			_initialDirectiveArray = null;
			_resultDirectiveArray = null;
			_openPubWorkPackages = null;
			_openPubQuotations = null;

			if (_currentForecast != null)
			{
				_currentForecast.Dispose();
				_currentForecast = null;
			}

			if (_initialFilter != null)
			{
				_initialFilter.Filters.Clear();
				_initialFilter = null;
			}

			if (_additionalFilter != null)
			{
				_additionalFilter.Filters.Clear();
				_additionalFilter = null;
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemComposeWorkPackage != null) _toolStripMenuItemComposeWorkPackage.Dispose();
			if (_toolStripMenuItemHighlight != null)
			{
				foreach (RadMenuItem ttmi in _toolStripMenuItemHighlight.Items)
				{
					ttmi.Click -= HighlightItemClick;
				}
				_toolStripMenuItemHighlight.Items.Clear();
				_toolStripMenuItemHighlight.Dispose();
			}
			if (_toolStripMenuItemShowTaskCard != null) _toolStripMenuItemShowTaskCard.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
			if (_toolStripSeparator4 != null) _toolStripSeparator4.Dispose();
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}
				_toolStripMenuItemsWorkPackages.Items.Clear();
				_toolStripMenuItemsWorkPackages.Dispose();
			}

			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (RadMenuItem item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}

				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (WorkPackage workPackage in _openPubWorkPackages)
				{
					RadMenuItem item = new RadMenuItem($"{workPackage.Title} {workPackage.Number}");
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.Items.Add(item);
				}
			}

			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			GlobalObjects.ComponentCore.ReloadActualStateRecordForBaseComponents(CurrentAircraft.ItemId);

			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			#region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			var maintenanceDirectives = new List<MaintenanceDirective>();
			try
			{
				if (_currentForecast == null)
					maintenanceDirectives.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft, _initialFilter));
				else
				{
					GlobalObjects.AnalystCore.GetMaintenanceDirectives(_currentForecast, _initialFilter);
					maintenanceDirectives.AddRange(_currentForecast.MaintenanceDirectives);
				}

				AnimatedThreadWorker.ReportProgress(20, "calculation directives");

				var bindedItemsDict = GlobalObjects.BindedItemsCore.GetBindedItemsFor(CurrentAircraft.ItemId,
									  maintenanceDirectives.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend).Cast<IBindedItem>());

				CalculateMaintenanceDirectives(maintenanceDirectives, bindedItemsDict);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while loading directives", ex);
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			#region Сравнение с рабочими пакетами

			AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if(_openPubWorkPackages == null)
				_openPubWorkPackages = new CommonCollection<WorkPackage>();
			_openPubWorkPackages.Clear();
			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));
			//сбор всех записей рабочих пакетов для удобства фильтрации
			List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
			foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
				openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

			foreach (MaintenanceDirective task in _initialDirectiveArray)
			{
				if (task.NextPerformances.Count <= 0)
					continue;
				//Проход по всем след. выполнениям чека и записям в рабочих пакетах
				//для поиска перекрывающихся выполнений
				List<NextPerformance> performances = task.NextPerformances;
				foreach (NextPerformance np in performances)
				{
					//поиск записи в рабочих пакетах по данному чеку
					//чей номер группы выполнения (по записи) совпадает с расчитанным
					WorkPackageRecord wpr =
						openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
														  r.WorkPackageItemType == task.SmartCoreObjectType.ItemId &&
														  r.DirectiveId == task.ItemId);
					if (wpr != null)
						np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.WorkPakageId);
				}
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			#region Загрузка Котировочных ордеров

			AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if (_openPubQuotations == null) _openPubQuotations = new CommonCollection<RequestForQuotation>();

			_openPubQuotations.Clear();
			_openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(CurrentAircraft, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemComposeWorkPackage = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemsWShowWP = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripMenuItemShowTaskCard = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripSeparator4 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			//
			// toolStripMenuItemComposeWorkPackage
			//
			_toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
			_toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWShowWP
			//
			_toolStripMenuItemsWShowWP.Text = "Show a work package Title";
			_toolStripMenuItemsWShowWP.Click += _toolStripMenuItemsWShowWP_Click;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to Work package";
			
			_toolStripMenuItemsWorkPackages.Items.Clear();
			_toolStripMenuItemHighlight.Items.Clear();

			// 
			// _toolStripMenuItemShowTaskCard
			// 
			_toolStripMenuItemShowTaskCard.Text = "Show Task Card";
			_toolStripMenuItemShowTaskCard.Click += ToolStripMenuItemShowTaskCardClick;
			
			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				RadMenuItem item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}
		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				Highlight highLight = (Highlight)((RadMenuItem)sender).Tag;
				_directivesViewer.SelectedItems[i].Highlight = highLight;
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ButtonCreateWorkPakageClick(object sender, EventArgs e)

		private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			if (MessageBox.Show("Create and save a Work Package?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				List<NextPerformance> wpItems =
					_directivesViewer.SelectedItems.Where(i => i.NextPerformances != null && i.NextPerformances.Count > 0)
												   .Select(i => i.NextPerformances[0])
												   .ToList();
				try
				{
					string message;
					WorkPackage wp = GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, CurrentAircraft, out message);
					if (wp == null)
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					//Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
					_openPubWorkPackages.Add(wp);
					//Создание пункта в меню открытых рабочих пакетов
					RadMenuItem item = new RadMenuItem(wp.Title);
					item.Click += AddToWorkPackageItemClick;
					item.Tag = wp;
					_toolStripMenuItemsWorkPackages.Items.Add(item);

					foreach (NextPerformance nextPerformance in wpItems)
					{
						nextPerformance.BlockedByPackage = wp;
						_directivesViewer.UpdateItemColor();
					}
					ReferenceEventArgs refArgs = new ReferenceEventArgs
													 {
														 TypeOfReflection = ReflectionTypes.DisplayInNew,
														 DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title,
														 RequestedEntity = new WorkPackageScreen(wp)
													 };
					InvokeDisplayerRequested(refArgs);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Work Package", ex);
				}
			}
		}
		#endregion

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			WorkPackage wp = (WorkPackage)((RadMenuItem)sender).Tag;

			if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				List<NextPerformance> wpItems =
					_directivesViewer.SelectedItems.Where(i => i.NextPerformances != null && i.NextPerformances.Count > 0)
												   .Select(i => i.NextPerformances[0])
												   .ToList();
				try
				{
					string message;

					if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, CurrentAircraft, out message))
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					foreach (NextPerformance nextPerformance in wpItems)
					{
						nextPerformance.BlockedByPackage = wp;
						_directivesViewer.UpdateItemColor();
					}

					if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
										 MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
										== DialogResult.Yes)
					{
						ReferenceEventArgs refArgs = new ReferenceEventArgs();
						refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
						refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
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

		private void _toolStripMenuItemsWShowWP_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			var res = $"{_directivesViewer.SelectedItem.NextPerformance.BlockedByPackage.Title} {_directivesViewer.SelectedItem.NextPerformance.BlockedByPackage.Number}";
			MessageBox.Show(res, "",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			CommonCollection<MaintenanceDirective> selected = new CommonCollection<MaintenanceDirective>();
			foreach (MaintenanceDirective o in _directivesViewer.SelectedItems)
			{
				selected.CompareAndAdd(o);
			}

			foreach (MaintenanceDirective t in selected)
			{
				var refE = new ReferenceEventArgs();
				var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(t);
				refE.SetParameters(dp);
				InvokeDisplayerRequested(refE);
			}

			selected.Clear();
		}

		#endregion

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null || 
				_directivesViewer.SelectedItems.Count == 0) return;
			MaintenanceDirective mpd = _directivesViewer.SelectedItems[0];
			if (mpd == null || mpd.TaskCardNumberFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				return;
			}

			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(mpd.TaskCardNumberFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					$"Error while Open Attached File for {mpd}, id {mpd.ItemId}. \nFileId {mpd.TaskCardNumberFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;
			List<MaintenanceDirective> directives = _directivesViewer.SelectedItems.ToList();

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].TaskNumberCheck + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);
				foreach (var directive in directives)
				{
					foreach (var relation in directive.ItemRelations)
					{
						GlobalObjects.CasEnvironment.NewKeeper.Delete(relation, true);
					}
				}
				_directivesViewer.radGridView1.EndUpdate();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new MaintenanceDirectiveListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemShowTaskCard,
				new RadMenuSeparatorItem(),
				_toolStripMenuItemHighlight,
				_toolStripSeparator2,
				_toolStripMenuItemComposeWorkPackage,
				_toolStripMenuItemsWorkPackages,
				_toolStripMenuItemsWShowWP);

			_directivesViewer.ConfigurePaste = list =>
			{
				foreach (var directive in list)
				{
					directive.ParentAircraft = CurrentAircraft;
					directive.ParentBaseComponent = CurrentParent is BaseComponent ? (BaseComponent)CurrentParent : GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft)CurrentParent).AircraftFrameId);
				}
			};

			_directivesViewer.MenuOpeningAction = () =>
			{
				_toolStripMenuItemsWShowWP.Enabled = false;
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemShowTaskCard.Enabled = false;
					_toolStripMenuItemHighlight.Enabled = false;
					_toolStripMenuItemComposeWorkPackage.Enabled = false;
					_toolStripMenuItemsWorkPackages.Enabled = false;
					_toolStripMenuItemsWShowWP.Enabled = false;
				}
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;

					MaintenanceDirective mpd = _directivesViewer.SelectedItems[0];
					if (mpd != null && mpd.TaskCardNumberFile != null)
						_toolStripMenuItemShowTaskCard.Enabled = true;
					else _toolStripMenuItemShowTaskCard.Enabled = false;
					if (mpd.NextPerformanceIsBlocked)
						_toolStripMenuItemsWShowWP.Enabled = true;
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuItemShowTaskCard.Enabled = true;
					_toolStripMenuItemHighlight.Enabled = true;
					_toolStripMenuItemComposeWorkPackage.Enabled = true;
					_toolStripMenuItemsWorkPackages.Enabled = true;
				}
			};
			
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			headerControl.ShowSaveButton = false;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			if (CurrentAircraft != null)
				e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + ReportText + " Report";
			else
			{
				e.DisplayerText = ReportText + " Report";
				e.Cancel = true;
				return;
			}
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == itemPrintReportAMP)
			{
				_maintenanceDirectiveFullReportBuilder.ReportedAircraft = CurrentAircraft;
				_maintenanceDirectiveFullReportBuilder.FilterSelection = _additionalFilter;
				_maintenanceDirectiveFullReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
				_maintenanceDirectiveFullReportBuilder.Forecast = _currentForecast;
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "Maintenance Status report";
				e.RequestedEntity = new ReportScreen(_maintenanceDirectiveFullReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (AMP STATUS)");
			}
			else if (sender == itemPrintReportMP)
			{
				MaintenanceDirective[] items =
					_directivesViewer.GetItemsArray()
						.Where(mpd => !mpd.IsClosed && mpd.NextPerformances.Count > 0)
						.ToArray();

				if(items.Length == 0)
				{
					MessageBox.Show("In selected Items not open or repetitive items",
									(string) new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, 
									MessageBoxIcon.Exclamation, 
									MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
				_maintenanceDirectiveReportBuilder.ReportedAircraft = CurrentAircraft;
				_maintenanceDirectiveReportBuilder.FilterSelection = _additionalFilter;
				_maintenanceDirectiveReportBuilder.AddDirectives(items);
				_maintenanceDirectiveReportBuilder.Forecast = _currentForecast;
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "Maintenance Program";
				e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP)");
			}
			else if (sender == itemPrintReportMPLimit)
			{
				_maintenanceDirectiveReportBuilderLitAVia = new MaintenanceDirectivesFullReportBuilderLitAVia(true);
				_maintenanceDirectiveReportBuilderLitAVia.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				_maintenanceDirectiveReportBuilderLitAVia.ReportedAircraft = CurrentAircraft;
				_maintenanceDirectiveReportBuilderLitAVia.AddDirectives(_resultDirectiveArray.OrderBy(i => i.TaskNumberCheck));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP Limit";
				e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilderLitAVia);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP Limit)");
			}
			else if (sender == itemPrintWorkscope)
			{
				_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
				_workscopeReportBuilder.FilterSelection = _additionalFilter;
				_workscopeReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
				_workscopeReportBuilder.Forecast = _currentForecast;
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "WORK SCOPE";
				e.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (WORK SCOPE)");
			}
			else if (sender == itemPrintMPSYS)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.IsAWL = false;
				_amReportBuilder.ReportTitle = "SECTION 1 - SYSTEMS AND POWERPLANT MAINTENANCE PROGRAM";
				_amReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.SystemsAndPowerPlants.ItemId ||
																							i.Program.ItemId == MaintenanceDirectiveProgramType.SystemsMaintenance.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP SYS";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP SYS)");
			}
			else if (sender == itemPrintMPSTR)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.IsAWL = false;
				_amReportBuilder.ReportTitle = "SECTION 2 - STRUCTURAL MAINTENANCE PROGRAM";
				_amReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.StructuresMaintenance.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP STR";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP STR)");
			}
			else if (sender == itemPrintMPZonal)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.ReportTitle = "SECTION 3 - ZONAL INSPECTION PROGRAM";
				_amReportBuilder.IsAWL = false;
				_amReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.ZonalInspection.ItemId ||
																							i.Program.ItemId == MaintenanceDirectiveProgramType.StructuralInspection.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP Zonal";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP Zonal)");
			}
			else if (sender == itemPrintMPAWL)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.IsAWL = true;
				_amReportBuilder.ReportTitle = "SECTION 4 - AIRWORTHINESS LIMITATIONS (AWLs) AND CERTIFICATION MAINTENANCE REQUIREMENTS (CMRs)";
				_amReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.AWLandCMR.ItemId 
																							|| i.Program.ItemId == MaintenanceDirectiveProgramType.CertificationMaintenanceRequirement.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP AWL + CMR";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP AWL + CMR + FIS)");
			}
			else if (sender == itemPrintMPLine)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.ReportTitle = "SECTION 5 – OPERATOR TASKS";
				_amReportBuilder.IsAWL = false;
				_amReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.LineMaintenance.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP Operator";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP Operator)");
			}
			else if (sender == itemPrintMPSSIP)
			{
				_amSuppReportBuilder.ReportedAircraft = CurrentAircraft;
				_amSuppReportBuilder.ReportTitle = "SECTION 9 - SUPPLEMENTAL STRUCTURE INSPECTIONS (SSI)";
				_amSuppReportBuilder.AddDirectives(_initialDirectiveArray.Where(i => i.Program.ItemId == MaintenanceDirectiveProgramType.SupplementalStructuralInspectionProgram.ItemId));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP SSIP";
				e.RequestedEntity = new ReportScreen(_amSuppReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (MP SSIP)");
			}
			else if (sender == itemPrintLitAvia)
			{
				_maintenanceDirectiveReportBuilderLitAVia = new MaintenanceDirectivesFullReportBuilderLitAVia();
				_maintenanceDirectiveReportBuilderLitAVia.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				_maintenanceDirectiveReportBuilderLitAVia.ReportedAircraft = CurrentAircraft;
				_maintenanceDirectiveReportBuilderLitAVia.AddDirectives(_resultDirectiveArray.OrderBy(i => i.TaskNumberCheck));
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "SS LA";
				e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilderLitAVia);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MaintenanceDirectiveListScreen (SS LA)");
			}
			else
			{
				e.Cancel = true;
			}
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = _directivesViewer.GetItemsArray().Cast<BaseEntityObject>().Where(o => o.ItemId <= 0).ToList();

			try
			{
				foreach (BaseEntityObject entityObject in unsaved)
				{
					GlobalObjects.CasEnvironment.Keeper.SaveAll(entityObject, true);
				}

				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				headerControl.ShowSaveButton = unsaved.Count(i => i.ItemId <= 0) > 0;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save directive from directives list", ex);
			}

		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentAircraft != null
				? CurrentAircraft.RegistrationNumber
				: CurrentStore != null ? CurrentStore.Name : "";
			e.DisplayerText += ".MPD.New Directive";
			e.RequestedEntity = new MaintenanceDirectiveScreen(CurrentAircraft);
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_additionalFilter, _initialDirectiveArray);

			if(form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var mpdIds = _resultDirectiveArray.Select(mpd => mpd.ItemId).ToList();

			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = $"{CurrentAircraft.RegistrationNumber} .Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft, mpdIds);
		}

		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
			List<BaseComponent> aircraftBaseComponents;
			if (_currentForecast != null) _currentForecast.ForecastDatas.Clear();

			switch ((string)sender)
			{
				case "No Forecast":
					{
						_currentForecast = null;
						labelDateAsOf.Visible = false;
					}
					break;
				case "Today":
					{
						if (CurrentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today };
							//поиск деталей данного самолета 
							aircraftBaseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId).ToList();
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								var forecastData =
									new ForecastData(DateTime.Today,
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							ForecastData main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today };
							var forecastData =
									new ForecastData(DateTime.Today,
													 _currentBaseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
							_currentForecast.ForecastDatas.Add(forecastData);
							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(forecastData.ForecastDate) +
								 " Component TSN/CSN: " + forecastData.ForecastLifelength +
								 "\nAvg. utlz: " + forecastData.AverageUtilization;
						}
					}
					break;
				case "This week":
					{
						if (CurrentAircraft != null)
						{
							_currentForecast = new Forecast
							{
								Aircraft = CurrentAircraft,
								ForecastDate = DateTime.Today.AddDays(7)
							};
							//поиск деталей данного самолета 
							aircraftBaseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId).ToList();
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								var forecastData =
									new ForecastData(DateTime.Today.AddDays(7),
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							var main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddDays(7) };
							ForecastData forecastData =
									new ForecastData(DateTime.Today.AddDays(7),
													 _currentBaseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
							_currentForecast.ForecastDatas.Add(forecastData);
							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(forecastData.ForecastDate) +
								 " Component TSN/CSN: " + forecastData.ForecastLifelength +
								 "\nAvg. utlz: " + forecastData.AverageUtilization;
						}
					}
					break;
				case "Two weeks":
					{
						if (CurrentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddDays(14) };
							//поиск деталей данного самолета 
							aircraftBaseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId).ToList();
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								var forecastData =
									new ForecastData(DateTime.Today.AddDays(14),
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							var main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddDays(14) };
							var forecastData =
									new ForecastData(DateTime.Today.AddDays(14),
													 _currentBaseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
							_currentForecast.ForecastDatas.Add(forecastData);
							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(forecastData.ForecastDate) +
								 " Component TSN/CSN: " + forecastData.ForecastLifelength +
								 "\nAvg. utlz: " + forecastData.AverageUtilization;
						}
					}
					break;
				case "Month":
					{
						if (CurrentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddMonths(1) };
							//поиск деталей данного самолета 
							aircraftBaseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId).ToList();
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								var forecastData =
									new ForecastData(DateTime.Today.AddMonths(1),
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							var main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddMonths(1) };
							var forecastData =
									new ForecastData(DateTime.Today.AddMonths(1),
													 _currentBaseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
							_currentForecast.ForecastDatas.Add(forecastData);
							labelDateAsOf.Visible = true;
							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(forecastData.ForecastDate) +
								 " Component TSN/CSN: " + forecastData.ForecastLifelength +
								 "\nAvg. utlz: " + forecastData.AverageUtilization;
						}
					}
					break;
				case "Custom":
					{
						if (CurrentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft };
							//поиск деталей данного самолета 
							aircraftBaseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId).ToList();
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								var forecastData =
									new ForecastData(DateTime.Today,
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = CurrentAircraft };
							var forecastData =
									new ForecastData(DateTime.Today,
													 _currentBaseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
							_currentForecast.ForecastDatas.Add(forecastData);
						}
						else return;  

						ForecastData main = _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0];
						ForecastCustomsWriteData form = new ForecastCustomsWriteData(_currentForecast);
						ForecastCustomsAdvancedForm advancedForm = new ForecastCustomsAdvancedForm(_currentForecast);

						form.ShowDialog();

						if (form.DialogResult != DialogResult.OK && form.CallAdvanced)
							advancedForm.ShowDialog();

						if (form.DialogResult == DialogResult.OK || advancedForm.DialogResult == DialogResult.OK)
						{
							if (main.SelectedForecastType == ForecastType.ForecastByDate)
							{
								if (CurrentAircraft != null)
									labelDateAsOf.Text =
										"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
										 " Aircraft TSN/CSN: " + main.ForecastLifelength +
										 "\nAvg. utlz: " + main.AverageUtilization;
								else
									labelDateAsOf.Text =
										"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
										 " Component TSN/CSN: " + main.ForecastLifelength +
										 "\nAvg. utlz: " + main.AverageUtilization;
							}
							else if (main.SelectedForecastType == ForecastType.ForecastByPeriod)
							{
								labelDateAsOf.Text =
										"Forecast Period From: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.LowerLimit) +
										" To: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
										"\nAvg. utlz: " + main.AverageUtilization;
							}
							else if (main.SelectedForecastType == ForecastType.ForecastByCheck)
							{
								if (main.NextPerformanceByDate)
								{
									labelDateAsOf.Text = "Forecast: " + main.NextPerformanceString;
								}
								else
								{
									labelDateAsOf.Text =
										$"Forecast: {main.CheckName}. {main.NextPerformance}";
								}
							}
						}
						else return;
					}
					break;
			}
			//UpdateDirectives();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<MaintenanceDirective> initialCollection, ICommonCollection<MaintenanceDirective> resultCollection)
		{
		   if (_additionalFilter == null || _additionalFilter.All(i => i.Values.Length == 0))
		   {
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
		   }

		   resultCollection.Clear();

			foreach (MaintenanceDirective pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
				//}
				if (_additionalFilter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _additionalFilter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _additionalFilter)
					{
						if(filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		public void CalculateMaintenanceDirectives(IList<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)
		{
			foreach (var mpd in maintenanceDirectives)
			{
				if (_currentForecast == null)
				{
					//GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd);
					GlobalObjects.MTOPCalculator.CalculateDirectiveNew(mpd);
				}

				if (bindedItemsDict.ContainsKey(mpd))
				{
					var bindedItems = bindedItemsDict[mpd];
					foreach (var bindedItem in bindedItems)
					{
						if (bindedItem is ComponentDirective)
						{
							GlobalObjects.MTOPCalculator.CalculateDirectiveNew(bindedItem as ComponentDirective);

							var firstNextPerformance =
								bindedItemsDict[mpd].SelectMany(t => t.NextPerformances).OrderBy(n => n.NextPerformanceDate).FirstOrDefault();

							if (firstNextPerformance == null)
								continue;
							mpd.BindedItemNextPerformance = firstNextPerformance;
							mpd.BindedItemNextPerformanceSource = firstNextPerformance.NextPerformanceSource ?? Lifelength.Null;
							mpd.BindedItemRemains = firstNextPerformance.Remains ?? Lifelength.Null;
							mpd.BindedItemNextPerformanceDate = firstNextPerformance.NextPerformanceDate;
							mpd.BindedItemCondition = firstNextPerformance.Condition ?? ConditionState.NotEstimated;
						}
					}
				}

				_initialDirectiveArray.Add(mpd);
			}

			
		}

		private void ExportMpd_Click(object sender, EventArgs eventArgs)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportMpdWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportMpdWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load MPD");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportMpd(_resultDirectiveArray.ToList());
		}

		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_exportProvider.SaveTo(sfd.FileName);
				MessageBox.Show("File was success saved!");
			}

			_exportProvider.Dispose();
		}

		#endregion

		private void ButtonAPUCalc_Click(object sender, EventArgs e)
		{
			var form = new MaintenanceDirectiveAPUCalculationForm(_initialDirectiveArray.ToList());
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		private void buttonMaintCheck_Click(object sender, EventArgs e)
		{
			var form = new MaintenanceCheckFormNew(CurrentAircraft, _resultDirectiveArray);
			form.ShowDialog();
			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
		}

		private void buttonExtension_Click(object sender, EventArgs e)
		{
			var form = new MaintenanceCheckExtensionForm(CurrentAircraft, _resultDirectiveArray);
			form.ShowDialog();
			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
		}
	}
}
