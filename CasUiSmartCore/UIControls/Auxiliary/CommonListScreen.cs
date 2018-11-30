using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.PersonnelControls;
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
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class CommonListScreen : ScreenControl
    {
        #region Fields

        protected Type ViewedType;
        protected CommonListViewControl DirectivesViewer;

        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
	    protected CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

		private Forecast _currentForecast;
        protected ICommonCollection InitialDirectiveArray;
        protected ICommonCollection ResultDirectiveArray;
        
        private Aircraft _currentAircraft;
        private BaseComponent _currentBaseComponent;
        private readonly Store _currentStore;
        private CommonFilterCollection _filter;

		protected ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemOpen;
		private ToolStripMenuItem _toolStripMenuItemShowTaskCard;
	    private ToolStripSeparator _toolStripSeparatorOpenOperation;
		private ToolStripMenuItem _toolStripMenuItemHighlight;
		private ToolStripSeparator _toolStripSeparatorHighlightOperation;
		private ToolStripMenuItem _createQuotationOrderStripMenuItem;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
		private ToolStripSeparator _toolStripSeparatorQuotationtOperation;
		private ToolStripMenuItem _toolStripMenuItemComposeWorkPackage;
		private ToolStripMenuItem _toolStripMenuItemsWorkPackages;
		private ToolStripSeparator _toolStripSeparatorWorkPackageOperation;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemDelete;

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


            if (_createQuotationOrderStripMenuItem != null) _createQuotationOrderStripMenuItem.Dispose();
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.DropDownItems.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
					item.Click -= AddToWorkPackageItemClick;
				_toolStripMenuItemsWorkPackages.DropDownItems.Clear();
				_toolStripMenuItemsWorkPackages.Dispose();
			}

			if (DirectivesViewer != null) DirectivesViewer.DisposeView();

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
            DirectivesViewer.SetItemsArray(ResultDirectiveArray);


            headerControl.PrintButtonEnabled = DirectivesViewer.ItemListView.Items.Count != 0;
            buttonDeleteSelected.Enabled = DirectivesViewer.SelectedItem != null;
            if (ViewedType.IsSubclassOf(typeof(StaticDictionary)))
            {
                buttonAddNew.Enabled = false;
                buttonDeleteSelected.Enabled = false;
            }

            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }

                _toolStripMenuItemQuotations.DropDownItems.Clear();

                foreach (RequestForQuotation quotation in _openPubQuotations)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(quotation.Title);
                    item.Click += AddToQuotationOrderItemClick;
                    item.Tag = quotation;
                    _toolStripMenuItemQuotations.DropDownItems.Add(item);
                }
            }
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
					item.Click -= AddToWorkPackageItemClick;

				_toolStripMenuItemsWorkPackages.DropDownItems.Clear();

				foreach (WorkPackage workPackage in _openPubWorkPackages)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(workPackage.Title);
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
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
            _contextMenuStrip = new ContextMenuStrip();
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			#region OpenOperation

			if (_showOpenOperationContextMenu)
			{
				_toolStripMenuItemOpen = new ToolStripMenuItem();
				_toolStripMenuItemShowTaskCard = new ToolStripMenuItem();
				_toolStripSeparatorOpenOperation = new ToolStripSeparator();

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

				_contextMenuStrip.Items.Add(_toolStripMenuItemOpen);
				_contextMenuStrip.Items.Add(_toolStripMenuItemShowTaskCard);
				_contextMenuStrip.Items.Add(_toolStripSeparatorOpenOperation);
			}

			#endregion

			#region HighLightOperation

			if (_showHighlightOperationContextMenu)
			{
				_toolStripMenuItemHighlight = new ToolStripMenuItem();
				_toolStripSeparatorHighlightOperation = new ToolStripSeparator();

				// 
				// toolStripMenuItemHighlight
				// 
				_toolStripMenuItemHighlight.Text = "Highlight";
				foreach (var highlight in Highlight.HighlightList)
				{
					if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
						continue;
					var item = new ToolStripMenuItem(highlight.FullName);
					item.Click += HighlightItemClick;
					item.Tag = highlight;
					_toolStripMenuItemHighlight.DropDownItems.Add(item);
				}

				_contextMenuStrip.Items.Add(_toolStripMenuItemHighlight);
				_contextMenuStrip.Items.Add(_toolStripSeparatorHighlightOperation);
			}

			#endregion

			#region QuotationOperation

			if (_showQuotationOperationContextMenu)
			{
				_createQuotationOrderStripMenuItem = new ToolStripMenuItem();
				_toolStripMenuItemQuotations = new ToolStripMenuItem();
				_toolStripSeparatorQuotationtOperation = new ToolStripSeparator();

				// 
				// toolStripMenuItemView
				// 
				_createQuotationOrderStripMenuItem.Text = "Compose Quotation";
				_createQuotationOrderStripMenuItem.Click += ToolStripMenuItemComposeQuotationClick;
				//
				// toolStripMenuItemComposeWorkPackage
				//
				_toolStripMenuItemQuotations.Text = "Add to Quotation Order";

				_contextMenuStrip.Items.Add(_createQuotationOrderStripMenuItem);
				_contextMenuStrip.Items.Add(_toolStripMenuItemQuotations);
				_contextMenuStrip.Items.Add(_toolStripSeparatorQuotationtOperation);
			}

			#endregion

			#region WorkPackageOperation

			if (_showWorkPackageOperationContextMenu)
			{
				_toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
				_toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
				_toolStripSeparatorWorkPackageOperation = new ToolStripSeparator();

				//
				// toolStripMenuItemComposeWorkPackage
				//
				_toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
				_toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
				//
				// _toolStripMenuItemsWorkPackages
				//
				_toolStripMenuItemsWorkPackages.Text = "Add to Work package";

				_contextMenuStrip.Items.Add(_toolStripMenuItemComposeWorkPackage);
				_contextMenuStrip.Items.Add(_toolStripMenuItemsWorkPackages);
				_contextMenuStrip.Items.Add(_toolStripSeparatorWorkPackageOperation);
			}

			#endregion

			#region OperationContex

			if (_showEditOperationContextMenu)
			{
				_toolStripMenuItemCopy = new ToolStripMenuItem();
				_toolStripMenuItemPaste = new ToolStripMenuItem();
				_toolStripMenuItemDelete = new ToolStripMenuItem();

				// 
				// toolStripMenuItemCopy
				// 
				_toolStripMenuItemCopy.Text = "Copy";
				_toolStripMenuItemCopy.Click += CopyItemsClick;

				// 
				// toolStripMenuItemPaste
				// 
				_toolStripMenuItemPaste.Text = "Paste";
				_toolStripMenuItemPaste.Click += PasteItemsClick;

				// 
				// toolStripMenuItemDelete
				// 
				_toolStripMenuItemDelete.Text = "Delete";
				_toolStripMenuItemDelete.Click += ButtonDeleteClick;

				_contextMenuStrip.Items.Add(_toolStripMenuItemCopy);
				_contextMenuStrip.Items.Add(_toolStripMenuItemPaste);
				_contextMenuStrip.Items.Add(_toolStripMenuItemDelete);
			}

			#endregion

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
            if (DirectivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
	        if (_showWorkPackageOperationContextMenu)
	        {
				if (DirectivesViewer.SelectedItems.Count == 1)
					_toolStripMenuItemComposeWorkPackage.Enabled = true;
			}
	        if (_showQuotationOperationContextMenu)
				_createQuotationOrderStripMenuItem.Enabled = true;

	        if (_showOpenOperationContextMenu && DirectivesViewer.SelectedItem is NonRoutineJob)
	        {
		        var nrj = DirectivesViewer.SelectedItem as NonRoutineJob;
		        if (nrj.AttachedFile == null)
			        _toolStripMenuItemShowTaskCard.Enabled = false;
				else _toolStripMenuItemShowTaskCard.Enabled = true;
			}  
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
		    for (int i = 0; i < DirectivesViewer.SelectedItems.Count; i++)
		    {
			    Highlight highLight = (Highlight) ((ToolStripMenuItem) sender).Tag;
			    DirectivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
		    }
	    }

	    #endregion

		#region private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeQuotationOrder(DirectivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentOperator, this);
        }

        #endregion

		#region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

		private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (DirectivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, DirectivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
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
			ToolStripMenuItem item = new ToolStripMenuItem(wp.Title);
			item.Click += AddToWorkPackageItemClick;
			item.Tag = wp;
			_toolStripMenuItemsWorkPackages.DropDownItems.Add(item);
		}

		#endregion

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
	    {
		    if (DirectivesViewer.SelectedItems.Count <= 0) return;
		    var wp = (WorkPackage)((ToolStripMenuItem)sender).Tag;
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
            DirectivesViewer = new CommonListViewControl(beginGroup)
                                    {
                                        ViewedType = ViewedType,
                                        ContextMenuStrip = _contextMenuStrip,
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            //события 
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
            if (DirectivesViewer.ItemListView.Items.Count == 0)
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
                DirectivesViewer.ItemListView.BeginUpdate();
                foreach (BaseEntityObject directive in DirectivesViewer.SelectedItems)
                {
                    try
                    {
						//TODO:(Evgenii Babak)  Не удалять по одному объекту, а передавать список выделенных элементов. Пересмотреть подход!!!!!
						//TODO:(Evgenii Babak) нужен Helper
						if (ViewedType.Name == typeof (NonRoutineJob).Name)
	                    {
							GlobalObjects.NonRoutineJobCore.Delete(directive as NonRoutineJob);
	                    }
	                    else
	                    {
							GlobalObjects.CasEnvironment.Manipulator.Delete(directive);
						}
	                    
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
                DirectivesViewer.ItemListView.EndUpdate();

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
            if (_filter == null || _filter.Count == 0)
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

        #region private void PasteItemsClick(object sender, EventArgs e)

        private void PasteItemsClick(object sender, EventArgs e)
        {
            GetFromClipboard();
        }

        #endregion

        #region  private void CopyItemsClick(object sender, EventArgs e)

        private void CopyItemsClick(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        #endregion

        #region  private void CopyToClipboard()

        private void CopyToClipboard()
        {
            try
            {
                if (DirectivesViewer.SelectedItems == null || DirectivesViewer.SelectedItems.Count == 0)
                    return;

                // регистрация формата данных либо получаем его, если он уже зарегистрирован
                DataFormats.Format format = DataFormats.GetFormat(ViewedType.MakeArrayType().FullName);

                var selecteditems = DirectivesViewer.SelectedItems.ToArray();
                var array = Array.CreateInstance(ViewedType, DirectivesViewer.SelectedItems.Count);

				for (int i = 0; i < selecteditems.Length; i++)
				{
					//TODO:Временное решение(Создать ComponentModelListScreen)
					if (selecteditems[i] is ComponentModel)
					{
						var cm = selecteditems[i] as ComponentModel;
						array.SetValue(cm.GetCopyUnsaved(), i);
					}
					else if (selecteditems[i] is AircraftModel)
					{
						var am = selecteditems[i] as AircraftModel;
						array.SetValue(am.GetCopyUnsaved(), i);
					}
					else
						array.SetValue(selecteditems[i].GetCopyUnsaved(), i);
                }
                //todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
                using (MemoryStream mem = new MemoryStream())
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    try
                    {
                        bin.Serialize(mem, array);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Объект не может быть сериализован. \n" + ex);
                        return;
                    }
                }

                // копирование в буфер обмена
                IDataObject dataObj = new DataObject();
                dataObj.SetData(format.Name, false, array);
                Clipboard.SetDataObject(dataObj, false);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while copying object.", ex);
            }
        }

        #endregion

        #region  private void GetFromClipboard()

        private void GetFromClipboard()
        {
            try
            {
                Type genericType = typeof (CommonCollection<>);
                Type genericList = genericType.MakeGenericType(ViewedType);

                string format = ViewedType.MakeArrayType().FullName;

                if (string.IsNullOrEmpty(format))
                    return;
                if (!Clipboard.ContainsData(format))
                    return;


                var pds = (Array) Clipboard.GetData(format);
                if (pds == null)
                    return;


                var itemsforInsert = (ICommonCollection) Activator.CreateInstance(genericList);

                for (int i = 0; i < pds.Length; i++)
                {
                    InitialDirectiveArray.Add((IBaseEntityObject) pds.GetValue(i));
                    ResultDirectiveArray.Add((IBaseEntityObject) pds.GetValue(i));
                    itemsforInsert.Add((IBaseEntityObject) pds.GetValue(i));
                }


                if (itemsforInsert.Count > 0)
                {
                    DirectivesViewer.InsertItems(itemsforInsert);
                    headerControl.ShowSaveButton = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Объект не может быть сериализован. \n" + ex);

                headerControl.ShowSaveButton = false;
            }
            finally
            {
                Clipboard.Clear();
            }
        }

        #endregion

        #endregion
    }
}
