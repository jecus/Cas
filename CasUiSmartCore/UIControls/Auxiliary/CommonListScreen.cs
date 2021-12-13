﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Auxiliary
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CommonListScreen : ScreenControl
	{
		#region Fields

		protected Type ViewedType;
		protected CommonGridViewControl DirectivesViewer;

		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
		protected CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

		private Forecast _currentForecast;
		protected ICommonCollection InitialDirectiveArray;
		protected ICommonCollection ResultDirectiveArray;
		
		private Aircraft _currentAircraft;
		private BaseComponent _currentBaseComponent;
		private readonly Store _currentStore;
		private CommonFilterCollection _filter;

		protected RadMenuItem _toolStripMenuItemOpen;
		protected RadMenuItem _toolStripMenuItemShowTaskCard;
		protected RadMenuSeparatorItem _toolStripSeparatorOpenOperation;
		protected RadMenuItem _toolStripMenuItemHighlight;
		protected RadMenuSeparatorItem _toolStripSeparatorHighlightOperation;
        protected RadMenuItem _toolStripMenuItemComposeWorkPackage;
		protected RadMenuItem _toolStripMenuItemsWorkPackages;
		protected RadMenuSeparatorItem _toolStripSeparatorWorkPackageOperation;

		private bool _showOpenOperationContextMenu = true;
		private bool _showHighlightOperationContextMenu = true;
		private bool _showEditOperationContextMenu = true;
		private bool _showWorkPackageOperationContextMenu = true;
		private bool _showQuotationOperationContextMenu = true;

		#endregion

		#region Properties

		public bool ShowOpenOperationContextMenu
		{
			get { return _showOpenOperationContextMenu; }
			set { _showOpenOperationContextMenu = value; }
		}

		public bool ShowHighlightOperationContextMenu
		{
			get { return _showHighlightOperationContextMenu; }
			set { _showHighlightOperationContextMenu = value; }
		}

		public bool ShowEditOperationContextMenu
		{
			get { return _showEditOperationContextMenu; }
			set { _showEditOperationContextMenu = value; }
		}

		public bool ShowWorkPackageOperationContextMenu
		{
			get { return _showWorkPackageOperationContextMenu; }
			set { _showWorkPackageOperationContextMenu = value; }
		}

		public bool ShowQuotationOperationContextMenu
		{
			get { return _showQuotationOperationContextMenu; }
			set { _showQuotationOperationContextMenu = value; }
		}

		#endregion

		#region Constructors

		#region protected CommonListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		protected CommonListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public CommonListScreen(Type viewedType): this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список объектов
		///</summary>
		///<param name="viewedType">Тип, объекты которого будут отображаться в списке</param>
		///<param name="beginGroup"></param>
		public CommonListScreen(Type viewedType, PropertyInfo beginGroup = null)
			: this()
		{
			if (viewedType == null)
				throw new ArgumentNullException("viewedType");

			ViewedType = viewedType;
			aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];
			StatusTitle = ViewedType.Name;
			_currentForecast = new Forecast {Aircraft = CurrentAircraft};
			_filter = new CommonFilterCollection(viewedType);

			PreInitToolStripMenuItems();
			InitToolStripMenuItems();
			PostInitToolStripMenuItems();

			InitListView(beginGroup);
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

			if(InitialDirectiveArray != null)
				InitialDirectiveArray.Clear();
			InitialDirectiveArray = null;

			if (ResultDirectiveArray != null)
				ResultDirectiveArray.Clear();
			ResultDirectiveArray = null;

			if(_currentForecast != null)
				_currentForecast.Dispose();
			_currentForecast = null;

			if(_openPubWorkPackages != null)
				_openPubWorkPackages.Clear();
			_openPubWorkPackages=null;

			_openPubQuotations.Clear();
			_openPubQuotations = null;
			
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (var item in _toolStripMenuItemsWorkPackages.Items)
					item.Click -= AddToWorkPackageItemClick;
				_toolStripMenuItemsWorkPackages.Items.Clear();
				_toolStripMenuItemsWorkPackages.Dispose();
			}

			if (DirectivesViewer != null) DirectivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Cancelled)
				return;
			if (_currentAircraft != null)
			{
				aircraftHeaderControl1.Aircraft = _currentAircraft;
			}
			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}
			if (_currentBaseComponent != null)
			{
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
				var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentBaseComponent.ParentStoreId);
				if (parentAircraft != null)
					aircraftHeaderControl1.Aircraft = parentAircraft;
				if (parentStore != null)
					aircraftHeaderControl1.Store = parentStore;
			}
			if (_currentStore != null)
			{
				aircraftHeaderControl1.Store = _currentStore;
			}
			DirectivesViewer.SetItemsArray(ResultDirectiveArray.OfType<BaseEntityObject>());


			headerControl.PrintButtonEnabled = DirectivesViewer.ItemsCount != 0;
			buttonDeleteSelected.Enabled = DirectivesViewer.SelectedItem != null;
			if (ViewedType.IsSubclassOf(typeof(StaticDictionary)))
			{
				buttonAddNew.Enabled = false;
				buttonDeleteSelected.Enabled = false;
			}

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (var item in _toolStripMenuItemsWorkPackages.Items)
					item.Click -= AddToWorkPackageItemClick;

				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (WorkPackage workPackage in _openPubWorkPackages)
				{
					var item = new RadMenuItem(workPackage.Title);
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.Items.Add(item);
				}
			}
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов
			InitialDirectiveArray.Clear();
			
			if(ResultDirectiveArray != null)
				ResultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			if(ViewedType.IsSubclassOf(typeof(StaticDictionary)))
			{
				PropertyInfo p = ViewedType.GetProperty("Items");

				ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
				StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

				InitialDirectiveArray.AddRange((IDictionaryCollection)p.GetValue(instance, null));
				InitialDirectiveArray.RemoveById(-1);
			}
			else
			{
				//TODO:(Evgenii Babak) нужен Helper
				if (ViewedType.Name == typeof(NonRoutineJob).Name)
					InitialDirectiveArray.AddRange(GlobalObjects.NonRoutineJobCore.GetNonRoutineJobs().ToArray());
				else
					InitialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectCollection(ViewedType, loadChild:true));
			}

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(InitialDirectiveArray, ResultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			if (_showWorkPackageOperationContextMenu)
			{
				AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

				//загрузка рабочих пакетов для определения 
				//перекрытых ими выполнений задач
				if (_openPubWorkPackages == null)
					_openPubWorkPackages = new CommonCollection<WorkPackage>();
				_openPubWorkPackages.Clear();
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
				_openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));
			}

			#region Загрузка Котировочных ордеров

			AnimatedThreadWorker.ReportProgress(95, "Load Quotations");

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if (_openPubQuotations == null)
				_openPubQuotations = new CommonCollection<RequestForQuotation>();

			_openPubQuotations.Clear();
			_openPubQuotations.AddRange(GlobalObjects.PurchaseCore.
				GetRequestForQuotation(CurrentOperator, new[]{WorkPackageStatus.Opened, WorkPackageStatus.Published}));

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
			#endregion
			
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		protected void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			ResultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(InitialDirectiveArray, ResultDirectiveArray);

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

		#region  protected virtual void PreInitToolStripMenuItems()

		protected virtual void PreInitToolStripMenuItems()
		{
		}

		#endregion

		#region protected virtual void PostInitToolStripMenuItems()

		protected virtual void PostInitToolStripMenuItems()
		{

		}

		#endregion

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			#region OpenOperation

			if (_showOpenOperationContextMenu)
			{
				_toolStripMenuItemOpen = new RadMenuItem();
				_toolStripMenuItemShowTaskCard = new RadMenuItem();
				_toolStripSeparatorOpenOperation = new RadMenuSeparatorItem();

				// 
				// toolStripMenuItemView
				// 
				_toolStripMenuItemOpen.Text = "Open";
				_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
				// 
				// _toolStripMenuItemShowTaskCard
				// 
				_toolStripMenuItemShowTaskCard.Text = "Show Task Card";
				_toolStripMenuItemShowTaskCard.Click += ToolStripMenuItemShowTaskCardClick;
			}

			#endregion

			#region HighLightOperation

			if (_showHighlightOperationContextMenu)
			{
				_toolStripMenuItemHighlight = new RadMenuItem();
				_toolStripSeparatorHighlightOperation = new RadMenuSeparatorItem();

				// 
				// toolStripMenuItemHighlight
				// 
				_toolStripMenuItemHighlight.Text = "Highlight";
				foreach (var highlight in Highlight.HighlightList)
				{
					if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
						continue;
					var item = new RadMenuItem(highlight.FullName);
					item.Click += HighlightItemClick;
					item.Tag = highlight;
					_toolStripMenuItemHighlight.Items.Add(item);
				}

				
			}

			#endregion

			#region WorkPackageOperation

			if (_showWorkPackageOperationContextMenu)
			{
				_toolStripMenuItemComposeWorkPackage = new RadMenuItem();
				_toolStripMenuItemsWorkPackages = new RadMenuItem();
				_toolStripSeparatorWorkPackageOperation = new RadMenuSeparatorItem();

				//
				// toolStripMenuItemComposeWorkPackage
				//
				_toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
				_toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
				//
				// _toolStripMenuItemsWorkPackages
				//
				_toolStripMenuItemsWorkPackages.Text = "Add to Work package";
			}

			#endregion
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			OpenItem();
		}

		#endregion

		#region  protected virtual void Open()

		protected virtual void OpenItem()
		{

		}

		#endregion

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			ShowTaskCard();
		}

		#endregion

		#region protected virtual void ShowTaskCard()

		protected virtual void ShowTaskCard()
		{

		}

		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			DirectivesViewer.radGridView1.RowFormatting -= DirectivesViewer.RadGridView1_RowFormatting;

			for (int i = 0; i < DirectivesViewer.SelectedItems.Count; i++)
			{
				var highLight = (Highlight) ((RadMenuItem) sender).Tag;
				foreach (GridViewCellInfo cell in DirectivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}

			//DirectivesViewer.radGridView1.RowFormatting += DirectivesViewer.RadGridView1_RowFormatting;
		}

		#endregion
		
		#region private void ButtonCreateWorkPakageClick(object sender, EventArgs e)

		private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
		{
			if (DirectivesViewer.SelectedItems.Count <= 0) return;
			CreateWorkPakage();
		}
		#endregion

		#region protected virtual void CreateWorkPakage()

		protected virtual void CreateWorkPakage()
		{

		}

		#endregion

		#region protected  void AddToWorkPackage(WorkPackage wp)

		protected void AddWorkPackageToContextMenu(WorkPackage wp)
		{
			var item = new RadMenuItem(wp.Title);
			item.Click += AddToWorkPackageItemClick;
			item.Tag = wp;
			_toolStripMenuItemsWorkPackages.Items.Add(item);
		}

		#endregion

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
		{
			if (DirectivesViewer.SelectedItems.Count <= 0) return;
			var wp = (WorkPackage)((RadMenuItem)sender).Tag;
			AddToWorkPackage(wp);
		}

		#endregion

		#region protected virtual void AddToWorkPackage(WorkPackage wp)

		protected virtual void AddToWorkPackage(WorkPackage wp)
		{

		}

		#endregion

		#region protected virtual void InitListView(PropertyInfo beginGroup = null)

		protected virtual void InitListView(PropertyInfo beginGroup = null)
		{
			DirectivesViewer = new CommonGridViewControl()
									{
										ViewedType = ViewedType,
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			
			DirectivesViewer.MenuOpeningAction = () =>
			{
				if (DirectivesViewer.SelectedItems.Count <= 0)
					return;
				if (_showWorkPackageOperationContextMenu)
				{
					if (DirectivesViewer.SelectedItems.Count == 1)
						_toolStripMenuItemComposeWorkPackage.Enabled = true;
				}
				
				if (_showOpenOperationContextMenu && DirectivesViewer.SelectedItem is NonRoutineJob)
				{
					var nrj = DirectivesViewer.SelectedItem as NonRoutineJob;
					if (nrj.AttachedFile == null)
						_toolStripMenuItemShowTaskCard.Enabled = false;
					else _toolStripMenuItemShowTaskCard.Enabled = true;
				}
			};

			DirectivesViewer.AddMenuItems(new RadMenuItemBase[]{_toolStripMenuItemOpen,
				_toolStripMenuItemShowTaskCard,
				_toolStripSeparatorOpenOperation,
				_toolStripMenuItemHighlight,
				_toolStripSeparatorHighlightOperation,
				_toolStripMenuItemComposeWorkPackage,
				_toolStripMenuItemsWorkPackages});

			DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			panel1.Controls.Add(DirectivesViewer);
		}

		#endregion

		#region protected void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		protected void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (DirectivesViewer.SelectedItems.Count > 0)
			{
				buttonDeleteSelected.Enabled = !ViewedType.IsSubclassOf(typeof(StaticDictionary));
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				buttonDeleteSelected.Enabled = false;
			}
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (_currentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);

				//очистка массива данных по прогнозам
				_currentForecast.ForecastDatas.Clear();
				//поиск деталей данного самолета 
				var aircraftBaseDetails = 
					new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
				//составление нового массива данных по прогнозам
				foreach (BaseComponent baseDetail in aircraftBaseDetails)
				{
					//определение ресурсов прогноза для каждой базовой детали
					ForecastData forecastData = 
						new ForecastData(DateTime.Today,
										 baseDetail,
										 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
					//дабавление в массив
					_currentForecast.ForecastDatas.Add(forecastData);
				}
			}
			if (_currentBaseComponent != null)
			{
				labelTitle.Text = "Date as of: " +
				   SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Component TSN/CSN: " +
				   GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent);

				//очистка массива данных по прогнозам
				_currentForecast.ForecastDatas.Clear();
				//определение ресурсов прогноза для каждой базовой детали
				ForecastData forecastData =
					new ForecastData(DateTime.Today,
									 _currentBaseComponent,
									 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent));
				//дабавление в массив
				_currentForecast.ForecastDatas.Add(forecastData);
			}
			if (_currentStore != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Store: " +
					_currentStore.Name;
			}

			try
			{
				if (InitialDirectiveArray != null) InitialDirectiveArray.Clear();
				if (ResultDirectiveArray != null) ResultDirectiveArray.Clear();
				Type genericType = typeof(CommonCollection<>);
				Type genericList = genericType.MakeGenericType(ViewedType);
				InitialDirectiveArray = (ICommonCollection)Activator.CreateInstance(genericList);
				ResultDirectiveArray = (ICommonCollection)Activator.CreateInstance(genericList);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building collection", ex);
			}
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

		#region protected virtual HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		/// <summary>
		/// Реагирует на нажатие кнопки печати отчета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			if (DirectivesViewer.ItemsCount == 0)
			{
				MessageBox.Show("0 directives");
			}
			e.DisplayerText = "Request For Quotation Report";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new ReportScreen(new ForecastListReportBuilder(_currentForecast.ForecastDatas[0]));
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = DirectivesViewer.GetItemsArray().Cast<BaseEntityObject>().Where(o => o.ItemId <= 0).ToList();

			try
			{
				foreach (BaseEntityObject entityObject in unsaved)
				{
					GlobalObjects.CasEnvironment.Keeper.SaveAll(entityObject,true);
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

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
			List<BaseComponent> aircraftBaseDetails = null; 
			if (CurrentAircraft != null)
			{
				//поиск деталей данного самолета 
				aircraftBaseDetails = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
				//очистка массива данных по прогнозам
				if(aircraftBaseDetails.Count != 0)_currentForecast.ForecastDatas.Clear();
			}
			else
				_currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

			switch ((string)sender)
			{
				case "No Forecast":
					{
					}
					break;
				case "Today":
					{
						if (aircraftBaseDetails != null)
						{
							//составление нового массива данных по прогнозам
							foreach (BaseComponent baseDetail in aircraftBaseDetails)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today,
													 baseDetail,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							ForecastData main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
					}
					break;
				case "This week":
					{
						if (aircraftBaseDetails != null)
						{
							//составление нового массива данных по прогнозам
							foreach (BaseComponent baseDetail in aircraftBaseDetails)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddDays(7),
													 baseDetail,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							ForecastData main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
					}
					break;
				case "Two weeks":
					{
						if (aircraftBaseDetails != null)
						{
							//составление нового массива данных по прогнозам
							foreach (BaseComponent baseDetail in aircraftBaseDetails)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddDays(14),
													 baseDetail,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							ForecastData main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
					}
					break;
				case "Month":
					{
						if (aircraftBaseDetails != null)
						{
							//составление нового массива данных по прогнозам
							foreach (BaseComponent baseDetail in aircraftBaseDetails)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today.AddMonths(1),
													 baseDetail,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
							ForecastData main = _currentForecast.GetForecastDataFrame() ??
												_currentForecast.ForecastDatas[0];

							labelDateAsOf.Text =
								"Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
								 " Aircraft TSN/CSN: " + main.ForecastLifelength +
								 "\nAvg. utlz: " + main.AverageUtilization;
						}
					}
					break;
				case "Custom":
					{
						if (aircraftBaseDetails != null)
						{
							//составление нового массива данных по прогнозам
							foreach (BaseComponent baseDetail in aircraftBaseDetails)
							{
								//определение ресурсов прогноза для каждой базовой детали
								ForecastData forecastData =
									new ForecastData(DateTime.Today,
													 baseDetail,
													 GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
								//дабавление в массив
								_currentForecast.ForecastDatas.Add(forecastData);
							}
						}
						ForecastData main = _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0];
						ForecastCustomsWriteData form = new ForecastCustomsWriteData(_currentForecast);
						ForecastCustomsAdvancedForm advancedForm = new ForecastCustomsAdvancedForm(_currentForecast);
							
						form.ShowDialog();

						if (form.DialogResult != DialogResult.OK && form.CallAdvanced)
							advancedForm.ShowDialog();

						if (form.DialogResult == DialogResult.OK || advancedForm.DialogResult == DialogResult.OK)
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
						else return;
					}
					break;
			}

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region #region protected virtual ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		protected virtual void ButtonExportDisplayerRequested(object sender, ReferenceEventArgs e)
		{

		}

		#endregion

		#region protected virtual ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		/// <summary>
		/// Реагирует на нажатие кнопки добавления нового элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			try
			{
				Form form;

				if (ViewedType.Name == typeof(AircraftWorkerCategory).Name)
				{
					form = new AircraftWorkerCategoryForm(new AircraftWorkerCategory());
				}
				//else if (ViewedType.Name == typeof(DetailModel).Name || ViewedType.Name == typeof(AircraftModel).Name)
				//{
				//    ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
				//    BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
				//    form = new CommonEditorForm(item);
				//}
				else if(ViewedType.Name == typeof(Product).Name)
				{
					form = new ProductForm(new Product());   
				}
				else if (ViewedType.Name == typeof(ComponentModel).Name)
				{
					form = new ModelForm(new ComponentModel());
				}
				else if (ViewedType.Name == typeof(GoodStandart).Name)
				{
					form = new GoodStandardForm(new GoodStandart());
				}
				else
				{
					ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					form = new CommonEditorForm(item);
				}

				if (form.ShowDialog(this) == DialogResult.OK)
				{
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
					AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building new object", ex);
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, InitialDirectiveArray);

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
			if (DirectivesViewer.SelectedItems == null ||
				DirectivesViewer.SelectedItems.Count == 0) return;

			string typeName = ViewedType.Name;

			DialogResult confirmResult =
				MessageBox.Show(DirectivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + DirectivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				DirectivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(DirectivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				DirectivesViewer.radGridView1.EndUpdate();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region protected void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		protected void FilterItems(ICommonCollection initialCollection, ICommonCollection resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (BaseEntityObject pd in initialCollection)
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
	}
}
