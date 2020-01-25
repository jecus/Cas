using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AvControls;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;
using TempUIExtentions;
using Point = System.Drawing.Point;

namespace CAS.UI.UIControls.DirectivesControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class PrimeDirectiveListScreen : ScreenControl
	{
		#region Fields

		private readonly ADType _adType;
		private DirectiveType _currentPrimaryDirectiveType;
		private ICommonCollection<Directive> _initialDirectiveArray = new DirectiveCollection();
		private ICommonCollection<Directive> _resultDirectiveArray = new CommonCollection<Directive>();
		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private Aircraft _currentAircraft;
		private BaseComponent _currentBaseComponent;
		private Forecast _currentForecast;

		private PrimeDirectiveListView _directivesViewer;

		private CommonFilterCollection _filter;

		private DirectivesReportBuilder _builder;
		private DirectivesReportBuilderLitAVIA _builderLitAVIA;
		private DirectivesReportBuilderLitAVIAEng _builderLitAviaEng;
		private DirectivesAMReportBuilder _amReportBuilder = new DirectivesAMReportBuilder();

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportAD;
		private ToolStripMenuItem itemPrintReportAMP;
		private ToolStripMenuItem itemPrintReportADLitAVIA;
		private ToolStripMenuItem itemPrintReportADLitAVIAEng;


		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemComposeWorkPackage;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemShowADFile;
		private RadMenuItem _toolStripMenuItemShowSBFile;
		private RadMenuItem _toolStripMenuItemShowEOFile;
		private RadMenuItem _toolStripMenuItemsWShowWP;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuSeparatorItem _toolStripSeparator4;
		private RadMenuItem _toolStripMenuItemsWorkPackages;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;
		private RadMenuItem _toolStripMenuItemChangeToAd;

		#endregion

		#region Properties
		/// <summary>
		/// Контейнер директив
		/// </summary>
		private object DirectiveSource
		{
			get
			{
				if (_currentBaseComponent != null)
					return _currentBaseComponent;
				return CurrentAircraft;
			}
		}

		#endregion

		#region Constructors

		#region public PrimeDirectiveListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public PrimeDirectiveListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PrimeDirectiveListScreen(BaseDetail baseDetail,PrimaryDirectiveType primaryDirectiveType, ADType adType = ADType.None) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="baseComponentазовый агрегат, которому принадлежат директивы</param>
		///<param name="primaryDirectiveType"></param>
		///<param name="adType"></param>
		public PrimeDirectiveListScreen(BaseComponent baseComponent,DirectiveType primaryDirectiveType, ADType adType = ADType.None)
			: this()
		{
			if (baseComponent == null)
				throw new ArgumentNullException("baseComponent", "Cannot display null-baseDetail");

			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			var parentStore = GlobalObjects.StoreCore.GetStoreById(baseComponent.ParentStoreId);

			if (parentAircraft != null)
				CurrentAircraft = parentAircraft;
			else CurrentStore = parentStore;
			StatusTitle = baseComponent + " " + primaryDirectiveType.CommonName;

			_currentBaseComponent = baseComponent;
			_currentPrimaryDirectiveType = primaryDirectiveType;
			_adType = adType;
			_builderLitAVIA = new DirectivesReportBuilderLitAVIA();
			_builderLitAviaEng = new DirectivesReportBuilderLitAVIAEng();
			PrimeDirectiveListView directiveList;
			if (primaryDirectiveType == DirectiveType.DamagesRequiring)
			{
				directiveList = new DamageDirectiveListView();
				_filter = new CommonFilterCollection(typeof(DamageItem));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else if (primaryDirectiveType == DirectiveType.DeferredItems)
			{
				directiveList = new DefferedDirectiveListView();
				_filter = new CommonFilterCollection(typeof(DeferredItem));
				_builder = new DeferredListReportBuilder();
			}
			else if (primaryDirectiveType == DirectiveType.ModificationStatus)
			{
				directiveList = new PrimeDirectiveListView(primaryDirectiveType);
				buttonDeleteSelected.Visible = false;
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else if (primaryDirectiveType == DirectiveType.OutOfPhase)
			{
				directiveList = new OutOfPhaseDirectiveListView();
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else
			{
				directiveList = new PrimeDirectiveListView(primaryDirectiveType);
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
				
				if (primaryDirectiveType == DirectiveType.SB)
					_builder.ReportTitle = "SB Status";
				else if (primaryDirectiveType == DirectiveType.AirworthenessDirectives)
					_builder.ReportTitle = adType == ADType.None ? "AD Status" : adType == ADType.Airframe ? "Airframe AD Status" : "Appliance AD \nStatus";
				else _builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
#else
				_builder = new DirectivesReportBuilder();
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
#endif
			}
#if !DEBUG
			buttonImportExcel.Visible = false;
			pictureBoxS3.Visible = false;
#endif
			InitToolStripMenuItems();
			InitPrintToolStripMenuItems();
			InitListView(directiveList);
		}

		#endregion

		#region public PrimeDirectiveListScreen(Aircraft currentAircraft, PrimaryDirectiveType primaryDirectiveType, ADType adType = ADType.None)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		///<param name="primaryDirectiveType"></param>
		///<param name="adType"></param>
		public PrimeDirectiveListScreen(Aircraft currentAircraft, DirectiveType primaryDirectiveType, ADType adType = ADType.None) : this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = currentAircraft.RegistrationNumber + " " + primaryDirectiveType.CommonName;

			_currentAircraft = currentAircraft;
			_currentPrimaryDirectiveType = primaryDirectiveType;
			_adType = adType;

			PrimeDirectiveListView directiveList;
			if (primaryDirectiveType == DirectiveType.DamagesRequiring)
			{
				directiveList = new DamageDirectiveListView();
				_filter = new CommonFilterCollection(typeof(DamageItem));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else if (primaryDirectiveType == DirectiveType.DeferredItems)
			{
				directiveList = new DefferedDirectiveListView();
				_filter = new CommonFilterCollection(typeof(DeferredItem));
				_builder = new DeferredListReportBuilder();
			}
			else if (primaryDirectiveType == DirectiveType.ModificationStatus)
			{
				directiveList = new PrimeDirectiveListView(primaryDirectiveType);
				buttonAddNew.Visible = false;
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else if (primaryDirectiveType == DirectiveType.OutOfPhase)
			{
				directiveList = new OutOfPhaseDirectiveListView();
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
#else
				_builder = new DirectivesReportBuilder();
#endif
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
			}
			else
			{
				directiveList = new PrimeDirectiveListView(primaryDirectiveType);
				_filter = new CommonFilterCollection(typeof(Directive));
#if KAC
				_builder = new DirectivesReportBuilderKAC();
				if(primaryDirectiveType == DirectiveType.SB)
					_builder.ReportTitle = "SB Status";
				else if(primaryDirectiveType == DirectiveType.AirworthenessDirectives)
					_builder.ReportTitle = adType == ADType.None ? "AD Status" : adType == ADType.Airframe ? "Airframe AD Status" : "Appliance AD \nStatus";
				else _builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
#else
				_builder = new DirectivesReportBuilder();
				_builder.ReportTitle = _currentPrimaryDirectiveType.CommonName;
#endif
			}
#if !DEBUG
			buttonImportExcel.Visible = false;
			pictureBoxS3.Visible = false;
#endif
			InitToolStripMenuItems();
			InitPrintToolStripMenuItems();
			InitListView(directiveList);
		}

		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

			AnimatedThreadWorker.Dispose();

			_resultDirectiveArray.Clear();
			_resultDirectiveArray = null;

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;

			_openPubWorkPackages.Clear();
			_openPubWorkPackages = null;

			_openPubQuotations.Clear();
			_openPubQuotations = null;

			if (_currentForecast != null)
			{
				_currentForecast.Dispose();
				_currentForecast = null;
			}

			if (_currentForecast != null) _currentForecast.Clear();
			_currentForecast = null;

			if (_toolStripMenuItemShowADFile != null) _toolStripMenuItemShowADFile.Dispose();
			if (_toolStripMenuItemShowSBFile != null) _toolStripMenuItemShowSBFile.Dispose();
			if (_toolStripMenuItemShowEOFile != null) _toolStripMenuItemShowEOFile.Dispose();
			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemComposeWorkPackage != null) _toolStripMenuItemComposeWorkPackage.Dispose();
			if (_toolStripMenuItemsWShowWP != null) _toolStripMenuItemsWShowWP.Dispose();
			if (_toolStripMenuItemHighlight != null)
			{
				foreach (RadMenuItem ttmi in _toolStripMenuItemHighlight.Items)
				{
					ttmi.Click -= HighlightItemClick;
				}
				_toolStripMenuItemHighlight.Items.Clear();
				_toolStripMenuItemHighlight.Dispose();
			}
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
			if (_currentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircraft);
			}
			else if (_currentBaseComponent != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Component TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent);
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

			var resultList = new List<Directive>();
			var list = _directivesViewer.radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new DirectiveGridViewDataRowInfoComparer(0, -1));

			foreach (var item in list)
				resultList.Add(item.Tag as Directive);

			_directivesViewer.SetItemsArray(resultList.ToArray());

			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
			_openPubWorkPackages.Clear();
			_openPubQuotations.Clear();


			AnimatedThreadWorker.ReportProgress(0, "load directives");

			try
			{
				if (_currentForecast == null)
				{
					if (DirectiveSource is BaseComponent)
					{
						BaseComponent bd = (BaseComponent) DirectiveSource;

						GlobalObjects.ComponentCore.ReloadActualStateRecordForBaseComponents(bd.ParentAircraftId);

						if (_currentPrimaryDirectiveType == DirectiveType.DamagesRequiring)
							_initialDirectiveArray = GlobalObjects.DirectiveCore.GetDamageItems(bd);
						else if (_currentPrimaryDirectiveType == DirectiveType.DeferredItems)
							_initialDirectiveArray = GlobalObjects.DirectiveCore.GetDeferredItems(bd);
						else _initialDirectiveArray = GlobalObjects.DirectiveCore.GetDirectives(bd, _currentPrimaryDirectiveType);
					}
					else
					{
						Aircraft a = (Aircraft) DirectiveSource;

						GlobalObjects.ComponentCore.ReloadActualStateRecordForBaseComponents(a.ItemId);

						if (_currentPrimaryDirectiveType == DirectiveType.DamagesRequiring)
							_initialDirectiveArray = GlobalObjects.DirectiveCore.GetDamageItems(null, a);
						else if (_currentPrimaryDirectiveType == DirectiveType.DeferredItems)
							_initialDirectiveArray = GlobalObjects.DirectiveCore.GetDeferredItems(null, a);
						else _initialDirectiveArray = GlobalObjects.DirectiveCore.GetDirectives(a, _currentPrimaryDirectiveType);
					}
				}
				else
				{
					AnimatedThreadWorker.ReportProgress(20, "calculation directives");

					GlobalObjects.AnalystCore.GetDirectives(_currentForecast, _currentPrimaryDirectiveType);
					DirectiveCollection dirC = _currentForecast.DirectiveCollections[_currentPrimaryDirectiveType];
					foreach (Directive directive in dirC)
						_initialDirectiveArray.Add(directive);
				}


				var ids = _initialDirectiveArray.Select(i => i.ItemId);
				var sbFiles = GlobalObjects.DirectiveCore.GetFilesName(ids, FileLinkType.EOFile);
				foreach (var file in sbFiles)
				{
					var find = _initialDirectiveArray.FirstOrDefault(i => i.ItemId == file.Key);
					if (find != null)
						find.EOFileName = file.Value;
				}

			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while loading directives", ex);
			}
			AnimatedThreadWorker.ReportProgress(40, "filter directives");
			if (_adType != ADType.None)
			{
				List<Directive> forDeleting =
					 _initialDirectiveArray.Where(primaryDirective => primaryDirective.ADType != _adType).ToList();

				foreach (Directive directive in forDeleting)
					_initialDirectiveArray.Remove(_initialDirectiveArray.GetItemById(directive.ItemId));
			}

			#region Калькуляция состояния директив

			AnimatedThreadWorker.ReportProgress(60, "calculation of directives");

			//foreach (Directive pd in _initialDirectiveArray)
			//{
			//	GlobalObjects.PerformanceCalculator.GetNextPerformance(pd);
			//}

			foreach (Directive pd in _initialDirectiveArray)
				GlobalObjects.MTOPCalculator.CalculateDirectiveNew(pd);

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}


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

			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
			_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));

			//сбор всех записей рабочих пакетов для удобства фильтрации
			List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
			foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
				openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

			foreach (Directive task in _resultDirectiveArray)
			{
				if (task == null || task.NextPerformances == null || task.NextPerformances.Count <= 0)
					continue;
				//Проход по всем след. выполнениям чека и записям в рабочих пакетах
				//для поиска перекрывающихся выполнений
				List<NextPerformance> performances = task.NextPerformances;
				foreach (NextPerformance np in performances)
				{
					//поиск записи в рабочих пакетах по данному чеку
					//чей номер группы выполнения (по записи) совпадает с расчитанным
					WorkPackageRecord wpr =
						openWPRecords.Where(r => r.PerformanceNumFromStart == np.PerformanceNum &&
												 r.WorkPackageItemType == task.SmartCoreObjectType.ItemId &&
												 r.DirectiveId == task.ItemId).FirstOrDefault();
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
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

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
			_toolStripMenuItemChangeToAd = new RadMenuItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemComposeWorkPackage = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemsWShowWP = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripMenuItemShowADFile = new RadMenuItem();
			_toolStripMenuItemShowSBFile = new RadMenuItem();
			_toolStripMenuItemShowEOFile = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripSeparator4 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemChangeToAd.Text = "Change to AD";
			_toolStripMenuItemChangeToAd.Click += _toolStripMenuItemChangeToAd_Click;
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
			// _toolStripMenuItemShowADFile
			// 
			_toolStripMenuItemShowADFile.Text = "Show AD File";
			_toolStripMenuItemShowADFile.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// _toolStripMenuItemShowSBFile
			// 
			_toolStripMenuItemShowSBFile.Text = "Show SB File";
			_toolStripMenuItemShowSBFile.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// _toolStripMenuItemShowEOFile
			// 
			_toolStripMenuItemShowEOFile.Text = "Show EO File";
			_toolStripMenuItemShowEOFile.Click += ToolStripMenuItemShowTaskCardClick;
			//
			// toolStripMenuItemComposeWorkPackage
			//
			_toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
			_toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to Work package";
			//
			// _toolStripMenuItemsWShowWP
			//
			_toolStripMenuItemsWShowWP.Text = "Show a work package Title";
			_toolStripMenuItemsWShowWP.Click += _toolStripMenuItemsWShowWP_Click; ;
			
			_toolStripMenuItemsWorkPackages.Items.Clear();
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
		}

		private void _toolStripMenuItemChangeToAd_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 0)
				return;


			foreach (var directive in _directivesViewer.SelectedItems)
				directive.DirectiveType = DirectiveType.AirworthenessDirectives;
			
			GlobalObjects.CasEnvironment.NewKeeper.BulkUpdate<Directive, DirectiveDTO>(_directivesViewer.SelectedItems.Cast<BaseEntityObject>().ToList());
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void _toolStripMenuItemsWShowWP_Click(object sender, EventArgs e)

		private void _toolStripMenuItemsWShowWP_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			var res = $"{_directivesViewer.SelectedItem.NextPerformance.BlockedByPackage.Title} {_directivesViewer.SelectedItem.NextPerformance.BlockedByPackage.Number}";
			MessageBox.Show(res, "",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region private void InitPrintToolStripMenuItems()

		private void InitPrintToolStripMenuItems()
		{
			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportAD = new ToolStripMenuItem { Text = "AD All" };
			itemPrintReportAMP = new ToolStripMenuItem { Text = "MP AD, SB, STC & REPAIR" };
			itemPrintReportADLitAVIA = new ToolStripMenuItem { Text = "AD LA" };
			itemPrintReportADLitAVIAEng = new ToolStripMenuItem { Text = "AD Eng LA" };


			if(_currentBaseComponent != null && _currentBaseComponent.BaseComponentType == BaseComponentType.Frame)
				buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportAD, itemPrintReportAMP, itemPrintReportADLitAVIA });
			else if (_currentBaseComponent != null && _currentBaseComponent.BaseComponentType == BaseComponentType.Engine)
				buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportAD, itemPrintReportAMP, itemPrintReportADLitAVIAEng });
			else buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportAD, itemPrintReportAMP});

			ButtonPrintMenuStrip = buttonPrintMenuStrip;
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
				List<NextPerformance> wpItems = _directivesViewer.SelectedItems
					.Where(i => i.NextPerformances.Count > 0)
					.Select(i => i.NextPerformance)
					.ToList();

				try
				{
					//TODO:(Evgenii Babak) запрещать создавать WP, если агрегат на складе
					var a = _currentAircraft != null
								? _currentAircraft
								: GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
					string message;
					var wp = GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, a, out message);
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
					ReferenceEventArgs refArgs = new ReferenceEventArgs();
					refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
					refArgs.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + wp.Title : wp.Title;
					refArgs.RequestedEntity = new WorkPackageScreen(wp);
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

			var wp = (WorkPackage)((RadMenuItem)sender).Tag;

			if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				List<NextPerformance> wpItems = _directivesViewer.SelectedItems
					.Where(i => i.NextPerformances.Count > 0 )
					.Select(i => i.NextPerformance)
					.ToList();

				try
				{
					string message;
					var a = _currentAircraft != null
								? _currentAircraft
								: GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
					if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId, a, out message))
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

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			List<Directive> selected = _directivesViewer.SelectedItems;

			foreach (Directive t in selected)
			{
				ReferenceEventArgs refE = new ReferenceEventArgs();
				string regNumber = "";
				if (t.ParentBaseComponent.BaseComponentType.ItemId == 4)
					regNumber = t.ParentBaseComponent.ToString();
				else
				{
					if (t.ParentBaseComponent.ParentAircraftId > 0)
						regNumber = $"{t.ParentBaseComponent.GetParentAircraftRegNumber()}. {t.ParentBaseComponent}"; 
				}
				refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refE.DisplayerText = regNumber + ". " + t.DirectiveType.CommonName + ". " + t.Title;
				refE.RequestedEntity = new DirectiveScreen(t);
				InvokeDisplayerRequested(refE);
			}
		}

		#endregion

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;
			
			BaseEntityObject o = _directivesViewer.SelectedItems[0];
			IBaseEntityObject parent;
			if (o is NextPerformance)
			{
				parent = ((NextPerformance)o).Parent;
			}
			else if (o is AbstractPerformanceRecord)
			{
				parent = ((AbstractPerformanceRecord)o).Parent;
			}
			else parent = o;

			Directive dir = null;
			if (parent is Directive)
			{
				dir = (Directive)parent;
			}

			AttachedFile attachedFile = null;
			if (sender == _toolStripMenuItemShowADFile && dir != null)
				attachedFile = dir.ADNoFile;
			if (sender == _toolStripMenuItemShowSBFile && dir != null)
				attachedFile = dir.ServiceBulletinFile;
			if (sender == _toolStripMenuItemShowEOFile && dir != null)
				attachedFile = dir.EngineeringOrderFile;
			if (attachedFile == null)
			{
				MessageBox.Show("Not set required File", (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				return;
			}
			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(attachedFile, out message);
				if(message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
					return;
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					$"Error while Open Attached File for {dir}, id {dir.ItemId}. \nFileId {attachedFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView(PrimeDirectiveListView directiveListView)
		{
			_directivesViewer = directiveListView;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			if (_currentPrimaryDirectiveType == DirectiveType.SB)
			{
				_directivesViewer.AddMenuItems(
					_toolStripMenuItemChangeToAd,
					new RadMenuSeparatorItem());
			}
			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemShowADFile,
				_toolStripMenuItemShowSBFile,
				_toolStripMenuItemShowEOFile,
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
					directive.ParentBaseComponent =  DirectiveSource is BaseComponent ? (BaseComponent)DirectiveSource : GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft)DirectiveSource).AircraftFrameId);
				}
			};

			_directivesViewer.MenuOpeningAction = () =>
			{
				_toolStripMenuItemsWShowWP.Enabled = false;
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemChangeToAd.Enabled = false;
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemShowADFile.Enabled = false;
					_toolStripMenuItemShowSBFile.Enabled = false;
					_toolStripMenuItemShowEOFile.Enabled = false;
					_toolStripMenuItemHighlight.Enabled = false;
					_toolStripMenuItemComposeWorkPackage.Enabled = false;
					_toolStripMenuItemsWorkPackages.Enabled = false;
					_toolStripMenuItemsWShowWP.Enabled = false;

				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemChangeToAd.Enabled =
						_directivesViewer.SelectedItem.DirectiveType == DirectiveType.SB;

					_toolStripMenuItemOpen.Enabled = true;

					BaseEntityObject o = _directivesViewer.SelectedItems[0];
					IBaseEntityObject parent;
					if (o is NextPerformance)
					{
						parent = ((NextPerformance) o).Parent;
					}
					else if (o is AbstractPerformanceRecord)
					{
						parent = ((AbstractPerformanceRecord) o).Parent;
					}
					else parent = o;

					Directive dir = null;
					if (parent is Directive)
					{
						dir = (Directive) parent;
					}

					if (dir != null)
					{
						_toolStripMenuItemShowEOFile.Enabled = dir.EngineeringOrderFile != null;
						_toolStripMenuItemShowSBFile.Enabled = dir.ServiceBulletinFile != null;
						_toolStripMenuItemShowADFile.Enabled = dir.ADNoFile != null;
						if (dir.NextPerformanceIsBlocked)
							_toolStripMenuItemsWShowWP.Enabled = true;
					}
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
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
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			if (_currentAircraft != null)
				e.DisplayerText = _currentAircraft.RegistrationNumber + ". " + ReportText + " Report";
			else if (_currentBaseComponent != null)
				e.DisplayerText = _currentBaseComponent + ". " + ReportText + " Report";
			else
				e.DisplayerText = ReportText + " Report";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			_builder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			_builder.DirectiveType = _currentPrimaryDirectiveType;


			if (sender == itemPrintReportAMP)
			{
				_amReportBuilder.ReportedAircraft = CurrentAircraft;
				_amReportBuilder.ReportTitle = "SECTION 6 –ADs, SBs, STCs & REPAIRs INSTRUCTIONS FOR CONTINUED AIRWORTHINESS (ICA)";
				_amReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
				e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP AD, SB, STC & REPAIR";
				e.RequestedEntity = new ReportScreen(_amReportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PrimeDirectiveListScreen (MP AD, SB, STC & REPAIR)");
			}
			else if (sender == itemPrintReportADLitAVIA)
			{
				_builderLitAVIA.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				_builderLitAVIA.ReportedAircraft = CurrentAircraft;
				_builderLitAVIA.AddDirectives(_directivesViewer.GetItemsArray());
				e.RequestedEntity = new ReportScreen(_builderLitAVIA);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PrimeDirectiveListScreen (AD LA)");
			}
			else if (sender == itemPrintReportADLitAVIAEng)
			{
				_builderLitAviaEng.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				_builderLitAviaEng.ReportedBaseComponent = _currentBaseComponent;
				_builderLitAviaEng.AddDirectives(_directivesViewer.GetItemsArray());
				e.RequestedEntity = new ReportScreen(_builderLitAviaEng);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PrimeDirectiveListScreen (AD Eng LA)");
			}
			else if (sender == itemPrintReportAD)
			{
				if (_currentAircraft != null)
				{
					_builder.ReportedAircraft = CurrentAircraft;
					_builder.FilterSelection = _filter;
					_builder.AddDirectives(_directivesViewer.GetItemsArray());
					_builder.Forecast = _currentForecast;
					e.RequestedEntity = new ReportScreen(_builder);
					GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PrimeDirectiveListScreen (AD All)");
				}
				else
				{
					if (_currentBaseComponent != null)
					{
						_builder.LifelengthAircraftSinceNew =
							GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
						_builder.ReportedBaseComponent = _currentBaseComponent;
						_builder.FilterSelection = _filter;
						_builder.AddDirectives(_directivesViewer.GetItemsArray());
						_builder.Forecast = _currentForecast;
						e.RequestedEntity = new ReportScreen(_builder);
						GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "PrimeDirectiveListScreen (AD All)");
					}
					else
					{
						e.Cancel = true;
					}
				}
			}
			else
			{
				e.Cancel = true;
			}
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)
		private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)
		{
			List<Directive> unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				foreach (Directive directive in unsaved)
				{
					GlobalObjects.DirectiveCore.Save(directive);
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
			if (_currentBaseComponent != null && _currentBaseComponent.BaseComponentType != BaseComponentType.Frame)
				e.DisplayerText += ". " + _currentBaseComponent;
			e.DisplayerText += ". " + _currentPrimaryDirectiveType.CommonName + ". New Directive";
			if (_currentBaseComponent != null)
			{
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
				if (_currentPrimaryDirectiveType == DirectiveType.OutOfPhase)
					e.RequestedEntity = new OutOfPhaseReferenceScreen(parentAircraft);
				else if (_currentPrimaryDirectiveType == DirectiveType.DamagesRequiring)
					e.RequestedEntity = new DamageDirectiveScreen(parentAircraft);
				else if (_currentPrimaryDirectiveType == DirectiveType.DeferredItems)
					e.RequestedEntity = new DeferredScreen(parentAircraft);
				else
					e.RequestedEntity = new DirectiveScreen(_currentBaseComponent, _currentPrimaryDirectiveType);
			}
			else
			{
				if (_currentPrimaryDirectiveType == DirectiveType.OutOfPhase)
					e.RequestedEntity = new OutOfPhaseReferenceScreen(CurrentAircraft);
				else if (_currentPrimaryDirectiveType == DirectiveType.DamagesRequiring)
					e.RequestedEntity = new DamageDirectiveScreen(CurrentAircraft);
				else if (_currentPrimaryDirectiveType == DirectiveType.DeferredItems)
					e.RequestedEntity = new DeferredScreen(CurrentAircraft);
				else
					e.RequestedEntity = new DirectiveScreen(CurrentAircraft, _currentPrimaryDirectiveType);
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			List<Directive> directives = _directivesViewer.SelectedItems;

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].Title + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);
				
				_directivesViewer.radGridView1.EndUpdate();

				List<Directive> unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

				if (unsaved.Count > 0)
				{
					if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to save data?",
									(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
									MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
					{
						try
						{
							foreach (Directive directive in unsaved)
							{
								GlobalObjects.DirectiveCore.Save(directive);
							}
							headerControl.ShowSaveButton = unsaved.Count(i => i.ItemId <= 0) > 0;
						}
						catch (Exception ex)
						{
							Program.Provider.Logger.Log("Error while save directive from directives list", ex);
						}
					}
				}
				else headerControl.ShowSaveButton = false;

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonImportFromExcelClick(object sender, EventArgs e)

		private void ButtonImportFromExcelClick(object sender, EventArgs e)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportDirectiveWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportDirectiveWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load Directive");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportDirective(_resultDirectiveArray.ToList());
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
						if (_currentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today };
							//поиск деталей данного самолета 
							aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
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
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today };
							ForecastData forecastData =
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
						if (_currentAircraft != null)
						{
							_currentForecast = new Forecast
							{
								Aircraft = _currentAircraft,
								ForecastDate = DateTime.Today.AddDays(7)
							};
							//поиск деталей данного самолета 
							aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddDays(7),
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
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today.AddDays(7) };
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
						if (_currentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today.AddDays(14) };
							//поиск деталей данного самолета 
							aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddDays(14),
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
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today.AddDays(14) };
							ForecastData forecastData =
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
						if (_currentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today.AddMonths(1) };
							//поиск деталей данного самолета 
							aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddMonths(1),
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
							_currentForecast = new Forecast { Aircraft = _currentAircraft, ForecastDate = DateTime.Today.AddMonths(1) };
							ForecastData forecastData =
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
						if (_currentAircraft != null)
						{
							_currentForecast = new Forecast { Aircraft = _currentAircraft };
							//поиск деталей данного самолета 
							aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
							//составление нового массива данных по прогноза
							foreach (var baseComponent in aircraftBaseComponents)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today,
													 baseComponent,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
						}
						else if (_currentBaseComponent != null)
						{
							_currentForecast = new Forecast { Aircraft = _currentAircraft };
							ForecastData forecastData =
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

		#region private void FilterItems(IEnumerable<Directive> initialCollection, ICommonCollection<Directive> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Directive> initialCollection, ICommonCollection<Directive> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Directive pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
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
		
		#endregion

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
