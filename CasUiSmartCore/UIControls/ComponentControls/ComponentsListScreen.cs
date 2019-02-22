using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AvControls;
using AvControls.AvMultitabControl.Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
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
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;
using FilterType = EFCore.Attributte.FilterType;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class ComponentsListScreen : ScreenControl
    {
        #region Fields

        private bool _firstLoad;

        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
        //private CommonCollection<DeferredCategory> _deferredCategories = new CommonCollection<DeferredCategory>(); 
        private readonly Aircraft _currentAircraft;
        private readonly BaseComponent _currentBaseComponent;
        private Forecast _currentForecast;

        private ComponentsListView _directivesViewer;

        private readonly MaintenanceControlProcess[] _maintenanceTypes;
        private readonly bool _llpMark;
        private readonly BaseComponentType[] _baseComponentTypes;
        //private DetailCollectionFilter _initialFilter;

        private CommonFilterCollection _initialFilter;
        private CommonFilterCollection _additionalfilter = new CommonFilterCollection(typeof(IComponentFilterParams));
        private ComponentCollection _initialDirectiveArray = new ComponentCollection();
        private ICommonCollection<BaseEntityObject> _preResultDirectiveArray = new CommonCollection<BaseEntityObject>();
        private ICommonCollection<BaseEntityObject> _resultDirectiveArray = new CommonCollection<BaseEntityObject>();

#if KAC
        private ComponentListReportBuilderKAC _builder = new ComponentListReportBuilderKAC();
#else
        private ComponentListReportBuilder _builder = new ComponentListReportBuilder();
#endif
	    private MaintenanceDirectivesComponentFullReportBuilderLitAVia _maintenanceDirectiveReportBuilderLitAVia = new MaintenanceDirectivesComponentFullReportBuilderLitAVia();
		private ComponentCollection _removedComponents = new ComponentCollection();
        private ComponentCollection _waitRemoveConfirmComponents = new ComponentCollection();
        private ComponentCollection _installedComponents = new ComponentCollection();
        private TransferRecordCollection _removedTransfers = new TransferRecordCollection();
        private TransferRecordCollection _installedTransfers = new TransferRecordCollection();
        private TransferRecordCollection _waitRemoveConfirmTransfers = new TransferRecordCollection();
        ///<summary>
        /// Форма, показывающая перемещенные детали
        ///</summary>
        private TransferedComponentForm _transferedComponentForm;
	    private ComponentAMReportBuilder _amReportBuilder = new ComponentAMReportBuilder();
	    private ComponentAMLLPReportBuilder _amLLPReportBuilder = new ComponentAMLLPReportBuilder();

		private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportComponents;
        private ToolStripMenuItem _itemPrintReportLLP;
	    private ToolStripMenuItem itemPrintReportMP;
	    private ToolStripMenuItem itemPrintReportMPLLP;
	    private ToolStripMenuItem itemPrintLitAvia;

		private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemOpen;
        private ToolStripMenuItem _toolStripMenuItemMoveToStore;
        private ToolStripMenuItem _toolStripMenuItemComposeWorkPackage;
        private ToolStripMenuItem _toolStripMenuItemComposeInitialOrder;
        private ToolStripMenuItem _toolStripMenuItemComposeQuotationOrder;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripSeparator _toolStripSeparator4;
        private ToolStripMenuItem _toolStripMenuItemsWorkPackages;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
        private ToolStripMenuItem _toolStripMenuItemCopy;
        private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemPrint;
		private ToolStripMenuItem _toolStripMenuItemPrintCalibrationTag;

		#endregion

		#region Properties
		/// <summary>
		/// Контейнер директив
		/// </summary>
		private BaseEntityObject DirectiveSource
        {
            get
            {
                if (_currentBaseComponent != null)
                    return _currentBaseComponent;
                if (CurrentAircraft != null)
                    return CurrentAircraft;
                return aircraftHeaderControl1.Operator;
            }
        }

        #endregion

        #region Constructors

        #region private DetailsListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private ComponentsListScreen()
        {
            InitializeComponent();
        }
		#endregion

		#region public DetailsListScreen(BaseDetail currentBaseDetail, DetailCollectionFilter filter) : this()

		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="currentBaseComponent"> агрегат, содержащий агрегаты</param>
		///<param name="maintenanceTypes"></param>
		///<param name="llpMark"></param>
		public ComponentsListScreen(BaseComponent currentBaseComponent,MaintenanceControlProcess[] maintenanceTypes, bool llpMark) : this()
        {
            if (currentBaseComponent == null)
                throw new ArgumentNullException("_currentBaseComponent", "Cannot display null-baseDetail");
            _currentBaseComponent = currentBaseComponent;
            _maintenanceTypes = maintenanceTypes;
            _llpMark = llpMark;

			if(_currentBaseComponent.ParentAircraftId > 0)
				CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
	        if (_currentBaseComponent.ParentStoreId > 0)
				CurrentStore = GlobalObjects.StoreCore.GetStoreById(_currentBaseComponent.ParentStoreId);

			StatusTitle = _currentBaseComponent + " " + "Components";

			InitPrintToolStripMenuItems();
			InitToolStripMenuItems();
            InitListView();
        }

        #endregion

        #region public DetailsListScreen(Aircraft currentAircraft, MaintenanceType[] maintenanceTypes, DetailType[] baseDetailTypes):this()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">ВС, содержащее агрегаты</param>
        ///<param name="maintenanceTypes"></param>
        ///<param name="baseComponentTypes"></param>
        public ComponentsListScreen(Aircraft currentAircraft, MaintenanceControlProcess[] maintenanceTypes, BaseComponentType[] baseComponentTypes)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            
            _currentAircraft = currentAircraft;
            _maintenanceTypes = maintenanceTypes;
            _baseComponentTypes = baseComponentTypes;

			//В ComponentStatusAll не отображаем кнопку для вызова TranferForm
	        buttonTransferDetails.Visible = false;
	        pictureBox3.Visible = false;
	        pictureBox4.Visible = false;
	        buttonPreTransferFilter.Visible = false;
			_firstLoad = true;

            CurrentAircraft = currentAircraft;
            StatusTitle = currentAircraft + " " + "Component Status";

	        InitPrintToolStripMenuItems();
			InitToolStripMenuItems();
            InitListView();
        }

        #endregion

        #region public DetailsListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters)  : this()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">ВС, содержащее агрегаты</param>
        ///<param name="initialFilters"></param>
        public ComponentsListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            
            _currentAircraft = currentAircraft;
            _maintenanceTypes = MaintenanceControlProcess.Items.ToArray();
            _baseComponentTypes = BaseComponentType.Items.ToArray();
            if(initialFilters != null)
            {
                if(_initialFilter == null)
                    _initialFilter = new CommonFilterCollection(typeof(Component), initialFilters);
                else
                {
                    _initialFilter.Filters.Clear();
                    _initialFilter.Filters.AddRange(initialFilters);
                }
            }

	        pictureBox4.Visible = false;
	        buttonPreTransferFilter.Visible = false;

			CurrentAircraft = currentAircraft;
            StatusTitle = currentAircraft + " " + "Component Status";

	        InitPrintToolStripMenuItems();

			InitToolStripMenuItems();
            InitListView();
        }

        #endregion

        #region public DetailsListScreen(Operator currentOperator, IEnumerable<ICommonFilter> initialFilters)  : this()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentOperator">Оператор, содержащее агрегаты</param>
        ///<param name="initialFilters"></param>
        public ComponentsListScreen(Operator currentOperator, IEnumerable<ICommonFilter> initialFilters)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");

            aircraftHeaderControl1.Operator = currentOperator;
            _maintenanceTypes = MaintenanceControlProcess.Items.ToArray();
            _baseComponentTypes = BaseComponentType.Items.ToArray();
            headerControl.ShowForecastButton = false;

            if (initialFilters != null)
            {
                if (_initialFilter == null)
                    _initialFilter = new CommonFilterCollection(typeof(Component), initialFilters);
                else
                {
                    _initialFilter.Filters.Clear();
                    _initialFilter.Filters.AddRange(initialFilters);
                }
            }

	        pictureBox4.Visible = false;
	        buttonPreTransferFilter.Visible = false;

			StatusTitle = currentOperator + " " + "Ground Equipment";
	        InitPrintToolStripMenuItems();
			InitToolStripMenuItems();
            InitListView();
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

            _resultDirectiveArray.Clear();
            _preResultDirectiveArray.Clear();
            _removedComponents.Clear();
            _waitRemoveConfirmComponents.Clear();
            _installedComponents.Clear();
            _removedTransfers.Clear();
            _waitRemoveConfirmTransfers.Clear();
            _installedTransfers.Clear();
            _openPubWorkPackages.Clear();
            _openPubQuotations.Clear();
            //_deferredCategories.Clear();

            _resultDirectiveArray = null;
            _preResultDirectiveArray = null;
            _removedComponents = null;
            _waitRemoveConfirmComponents = null;
            _installedComponents = null;
            _removedTransfers = null;
            _waitRemoveConfirmTransfers = null;
            _installedTransfers = null;
            _openPubWorkPackages = null;
            _openPubQuotations = null;
            //_deferredCategories = null;

            if(_currentForecast != null)
            {
                _currentForecast.Dispose();
                _currentForecast = null;
            }

            if(_initialFilter != null)
            {
                _initialFilter.Filters.Clear();
                _initialFilter = null;
            }

            if(_currentForecast != null) _currentForecast.Clear(); 
            _currentForecast = null;

            if(_itemPrintReportLLP != null) _itemPrintReportLLP.Dispose();
            if(_itemPrintReportComponents != null) _itemPrintReportComponents.Dispose();
            if(_buttonPrintMenuStrip != null) _buttonPrintMenuStrip.Dispose();

            if(_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if(_toolStripMenuItemMoveToStore != null) _toolStripMenuItemMoveToStore.Dispose();
            if(_toolStripMenuItemComposeWorkPackage != null) _toolStripMenuItemComposeWorkPackage.Dispose();
            if(_toolStripMenuItemComposeQuotationOrder != null) _toolStripMenuItemComposeQuotationOrder.Dispose();

            if (_toolStripMenuItemComposeInitialOrder != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemComposeInitialOrder.DropDownItems)
                {
                    item.Click -= ToolStripMenuItemComposeInitialClick;
                }
                _toolStripMenuItemComposeInitialOrder.DropDownItems.Clear();
                _toolStripMenuItemComposeInitialOrder.Dispose();
            }

            if(_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if(_toolStripMenuItemHighlight != null)
            {
                foreach (ToolStripMenuItem ttmi in _toolStripMenuItemHighlight.DropDownItems)
                {
                    ttmi.Click -= HighlightItemClick;
                }
                _toolStripMenuItemHighlight.DropDownItems.Clear();
                _toolStripMenuItemHighlight.Dispose();
            }
            if(_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if(_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
            if(_toolStripSeparator4 != null) _toolStripSeparator4.Dispose();
            if(_contextMenuStrip != null) _contextMenuStrip.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.DropDownItems.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }
            if(_toolStripMenuItemsWorkPackages != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                {
                    item.Click -= AddToWorkPackageItemClick;
                }
                _toolStripMenuItemsWorkPackages.DropDownItems.Clear();
                _toolStripMenuItemsWorkPackages.Dispose();
            }

            if (_transferedComponentForm != null) _transferedComponentForm.Close();
            if (_directivesViewer != null) _directivesViewer.DisposeView();

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
                {
                    item.Click -= AddToWorkPackageItemClick;
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
            if (_toolStripMenuItemComposeInitialOrder != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemComposeInitialOrder.DropDownItems)
                {
                    item.Click -= ToolStripMenuItemComposeInitialClick;
                }

                _toolStripMenuItemComposeInitialOrder.DropDownItems.Clear();
                _toolStripMenuItemComposeInitialOrder.Click -= ToolStripMenuItemComposeInitialClick;

                //if (_deferredCategories.Count > 0)
                //{
                //    foreach (DeferredCategory deferredCategory in _deferredCategories)
                //    {
                //        ToolStripMenuItem item = new ToolStripMenuItem(deferredCategory + " " + deferredCategory.Threshold.FirstPerformanceSinceEffectiveDate);
                //        item.Click += ToolStripMenuItemComposeInitialClick;
                //        item.Tag = deferredCategory;
                //        _toolStripMenuItemComposeInitialOrder.DropDownItems.Add(item);
                //    }
                //}
                //else _toolStripMenuItemComposeInitialOrder.Click += ToolStripMenuItemComposeInitialClick;
                _toolStripMenuItemComposeInitialOrder.Click += ToolStripMenuItemComposeInitialClick;
            }

            _directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();

            if (_removedComponents.Count > 0
                || _waitRemoveConfirmComponents.Count > 0
                || _installedComponents.Count > 0)
                buttonTransferDetails.Enabled = true;
            else buttonTransferDetails.Enabled = false;
            
            //так делается для того, чот бы форма перемещенных деталей
            //отобразилась сама только при первом открытии экрана
            if (_firstLoad == false)
                TransferedDetailFormShow();
            _firstLoad = true;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _initialDirectiveArray.Clear();
            _preResultDirectiveArray.Clear();
            _resultDirectiveArray.Clear();
            
            ComponentCollection preResult = new ComponentCollection();

            AnimatedThreadWorker.ReportProgress(0, "load components");
			//TODO:(Evgenii Babak) этим должна заниматься BL
            if (_currentForecast == null)
            {
                _removedComponents.Clear();
                _removedTransfers.Clear();
                _waitRemoveConfirmComponents.Clear();
                _waitRemoveConfirmTransfers.Clear();
                _installedComponents.Clear();
                _installedTransfers.Clear();
                //извлечение и собрание всех компоннтов самолета
                //(деталей и базовых деталей) в одну коллекцию
                ComponentCollection componentCollection = new ComponentCollection();
                BaseComponentCollection baseComponentCollection;
                List<MaintenanceControlProcess> types = new List<MaintenanceControlProcess>(_maintenanceTypes);

                if (DirectiveSource is BaseComponent)
                {
                    if (((BaseComponent)DirectiveSource).BaseComponentType == BaseComponentType.Engine && _llpMark)
                        componentCollection.AddRange(GlobalObjects.ComponentCore.GetComponents((BaseComponent)DirectiveSource, _llpMark).ToArray());
                    else componentCollection.AddRange(GlobalObjects.ComponentCore.GetComponents((BaseComponent)DirectiveSource).ToArray());
					//////////////////////////////////////////////////////
					//     проверка на установленные компоненты         //
					//////////////////////////////////////////////////////
					var lastInstalledComponents =
                        componentCollection.GetLastInstalledComponentsOn((BaseComponent)DirectiveSource);
                    foreach (Component detail in lastInstalledComponents)
                    {
                        _installedComponents.Add(detail);
                        _installedTransfers.Add(detail.TransferRecords.GetLast());

                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        componentCollection.Remove(detail);
                    }

                    //////////////////////////////////////////////////////
                    //        проверка на удаленные компоненты          //
                    //////////////////////////////////////////////////////
                    //извлечение из базы данных всех записей о перемещении
                    //компонентов с данного базового агрегата
                    TransferRecord[] records =
                            GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom((BaseComponent)DirectiveSource).ToArray();

                    foreach (TransferRecord record in records)
                    {
                        //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                        if(record.ParentComponent == null)
                            continue;
                        if (record.DODR)
                        {
                            //если перемещение подтверждено, то деталь записывается в "перемещенные"
                            //окна "TransferedDetails"
                            if (_removedComponents.CompareAndAdd(record.ParentComponent)) _removedTransfers.Add(record);
                        }
                        else
                        {
                            //если перемещение не подтверждено, то деталь записывается в 
                            //"ожидающие подтверждения" окна "TransferedDetails"
                            if (_waitRemoveConfirmComponents.CompareAndAdd(record.ParentComponent)) _waitRemoveConfirmTransfers.Add(record);
                        }
                    }
                    
                    foreach (Component detail in componentCollection)
                        if (types.Contains(detail.MaintenanceControlProcess)) preResult.Add(detail);

	                if (((BaseComponent) DirectiveSource).BaseComponentType == BaseComponentType.Frame && CurrentAircraft != null)
	                {
		                baseComponentCollection = new BaseComponentCollection(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
						baseComponentCollection.Remove((BaseComponent)DirectiveSource);


		                var baseComponentIds = baseComponentCollection.Select(i => i.ItemId);
		                var baseComponentDirectives = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<ComponentDirectiveDTO, ComponentDirective>(
			                new Filter("ComponentId", baseComponentIds), true);

		                foreach (var baseComponent in baseComponentCollection)
		                {
							baseComponent.ComponentDirectives.Clear();
			                foreach (var directive in baseComponentDirectives.Where(i => i.ComponentId == baseComponent.ItemId))
			                {
				                directive.ParentComponent = baseComponent;
								baseComponent.ComponentDirectives.Add(directive);
							}

						}


						var lastInstalledBaseDetails = GlobalObjects.CasEnvironment.BaseComponents.GetLastInstalledComponentsOn(CurrentAircraft);
		                foreach (BaseComponent baseDetail in lastInstalledBaseDetails)
		                {
			                _installedComponents.Add(baseDetail);
			                _installedTransfers.Add(baseDetail.TransferRecords.GetLast());

			                baseComponentCollection.Remove(baseDetail);
		                }

		                var removedBaseDetailTransfers = GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom(CurrentAircraft).ToArray();
		                foreach (TransferRecord record in removedBaseDetailTransfers)
		                {
			                //загрузка и БД детали, которой пренадлежит данная запись о перемещении
			                BaseComponent bd = GlobalObjects.ComponentCore.GetBaseComponentById(record.ParentId);

			                if (record.DODR)
			                {
				                //если перемещение подтверждено, то деталь записывается в "перемещенные"
				                //окна "TransferedDetails"
				                if (_removedComponents.CompareAndAdd(bd)) _removedTransfers.Add(record);
			                }
			                else
			                {
				                //если перемещение не подтверждено, то деталь записывается в 
				                //"ожидабщие подтверждения" окна "TransferedDetails"
				                if (_waitRemoveConfirmComponents.CompareAndAdd(bd)) _waitRemoveConfirmTransfers.Add(record);
			                }
		                }

						foreach (BaseComponent baseDetail in baseComponentCollection)
			                if (types.Contains(baseDetail.MaintenanceControlProcess))preResult.Add(baseDetail);
					}
                }

                if (DirectiveSource is Aircraft)
                {
                    List<BaseComponentType> baseDetailTypes = new List<BaseComponentType>(_baseComponentTypes);
                    //для начала нужно извлечь все базовые агрегаты самолета
                    //они хранятся в ядре и загружаютя при первом старте программы
                    if (baseDetailTypes.Count != 0)
                    {
                        var preCollection = new BaseComponentCollection(GlobalObjects.ComponentCore.GetAicraftBaseComponents(((Aircraft)DirectiveSource).ItemId));
                        baseComponentCollection = new BaseComponentCollection();
                        foreach (BaseComponent baseDetail in preCollection)
                        {
                            if (baseDetailTypes.Contains(baseDetail.BaseComponentType)) baseComponentCollection.Add(baseDetail);
                        }
                    }
                    else
                    {
                        baseComponentCollection =
                        new BaseComponentCollection(GlobalObjects.ComponentCore.GetAicraftBaseComponents(((Aircraft)DirectiveSource).ItemId));
                    }
                    //////////////////////////////////////////////////////
                    //   проверка на установленные базовые компоненты   //
                    //////////////////////////////////////////////////////
                    var lastInstalledBaseDetails = GlobalObjects.CasEnvironment.BaseComponents.GetLastInstalledComponentsOn((Aircraft)DirectiveSource);
                    foreach (BaseComponent baseDetail in lastInstalledBaseDetails)
                    {
                        _installedComponents.Add(baseDetail);
                        _installedTransfers.Add(baseDetail.TransferRecords.GetLast());

                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        baseComponentCollection.Remove(baseDetail);
                    }

                    //////////////////////////////////////////////////////
                    //     проверка на удаленные базовые компоненты     //
                    //////////////////////////////////////////////////////
                    TransferRecord[] removedBaseDetailTransfers =
                         GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom((Aircraft)DirectiveSource).ToArray();
                    foreach (TransferRecord record in removedBaseDetailTransfers)
                    {
                        //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                        BaseComponent bd = GlobalObjects.ComponentCore.GetBaseComponentById(record.ParentId);

                        if (record.DODR)
                        {
                            //если перемещение подтверждено, то деталь записывается в "перемещенные"
                            //окна "TransferedDetails"
                            if (_removedComponents.CompareAndAdd(bd)) _removedTransfers.Add(record);
                        }
                        else
                        {
                            //если перемещение не подтверждено, то деталь записывается в 
                            //"ожидабщие подтверждения" окна "TransferedDetails"
                            if (_waitRemoveConfirmComponents.CompareAndAdd(bd)) _waitRemoveConfirmTransfers.Add(record);
                        }
                    }


                    if (baseComponentCollection.Count == 0) return;

                    foreach (BaseComponent baseDetail in baseComponentCollection)
                    {
                        if (types.Contains(baseDetail.MaintenanceControlProcess))
                        {
                            preResult.Add(baseDetail);
                        }
                    }

                    componentCollection.Clear();
                    componentCollection.AddRange((GlobalObjects.ComponentCore.GetComponents(baseComponentCollection.ToList())).ToArray());
                    //группировка деталей по родительской базовой детали
                    IDictionary<BaseComponent, ComponentCollection> groupedDetails = new Dictionary<BaseComponent, ComponentCollection>();
                    foreach (BaseComponent baseDetail in baseComponentCollection)
                    {
                        groupedDetails.Add(baseDetail, new ComponentCollection(componentCollection.Where(d=>d.ParentBaseComponent == baseDetail).ToArray()));//TODO:(Evgenii Babak) заменить на использование ComponentCore 
					}
                    
                    foreach (KeyValuePair<BaseComponent, ComponentCollection> groupedDetail in groupedDetails)
                    {
                        //////////////////////////////////////////////////////
                        //     проверка на установленные компоненты         //
                        //////////////////////////////////////////////////////
                        Component[] lastInstalledComponents =
                            groupedDetail.Value.GetLastInstalledComponentsOn(groupedDetail.Key);
                        foreach (Component detail in lastInstalledComponents)
                        {
                            _installedComponents.Add(detail);
                            _installedTransfers.Add(detail.TransferRecords.GetLast());

                            //удаление данного компонента из коллекции
                            //т.к. его отображать не нужно
                            groupedDetail.Value.Remove(detail);
                        }

                        //////////////////////////////////////////////////////
                        //        проверка на удаленные компоненты          //
                        //////////////////////////////////////////////////////
                        //извлечение из базы данных всех записей о перемещении
                        //компонентов с данного базового агрегата
                        TransferRecord[] records =
                                GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom(groupedDetail.Key).ToArray();

                        foreach (TransferRecord record in records)
                        {
                            //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                            if (record.ParentComponent == null)
                                continue;
                            if (record.DODR)
                            {
                                //если перемещение подтверждено, то деталь записывается в "перемещенные"
                                //окна "TransferedDetails"
                                if (_removedComponents.CompareAndAdd(record.ParentComponent)) _removedTransfers.Add(record);
                            }
                            else
                            {
                                //если перемещение не подтверждено, то деталь записывается в 
                                //"ожидабщие подтверждения" окна "TransferedDetails"
                                if (_waitRemoveConfirmComponents.CompareAndAdd(record.ParentComponent)) _waitRemoveConfirmTransfers.Add(record);
                            }
                        }
                        foreach (Component detail in groupedDetail.Value)
                        {
                            if (types.Contains(detail.MaintenanceControlProcess)) preResult.Add(detail);
                        }
                    }
                }

                if (DirectiveSource is Operator)
                {
                    Operator op = (Operator) DirectiveSource;

                    baseComponentCollection =
                            new BaseComponentCollection(GlobalObjects.ComponentCore.GetOperatorBaseComponents(op.ItemId));
                    componentCollection.AddRange(GlobalObjects.ComponentCore.GetOperatorComponents(op).ToArray());

                    //////////////////////////////////////////////////////
                    //   проверка на компоненты ожидающие перемещения   //
                    //////////////////////////////////////////////////////
                    //Detail[] waitRemovedDetails =
                    //detailCollection.GetWaitRemoveConfirmDetails(currentStore);
                    //foreach (Detail detail in waitRemovedDetails)
                    //{
                    //    _waitRemoveConfirmDetails.Add(detail);
                    //    _waitRemoveConfirmTransfers.Add(detail.TransferRecords.Last);
                    //}
                    //////////////////////////////////////////////////////
                    //   проверка на установленные базовые компоненты   //
                    //////////////////////////////////////////////////////
                    IEnumerable<BaseComponent> lastInstalledBaseDetails =
                        GlobalObjects.CasEnvironment.BaseComponents.GetLastInstalledComponentsOn(op);
                    foreach (BaseComponent baseDetail in lastInstalledBaseDetails)
                    {
                        _installedComponents.Add(baseDetail);
                        _installedTransfers.Add(baseDetail.TransferRecords.GetLast());

                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        baseComponentCollection.Remove(baseDetail);
                    }

                    //////////////////////////////////////////////////////
                    //     проверка на удаленные базовые компоненты     //
                    //////////////////////////////////////////////////////
                    //TransferRecord[] removedBaseDetailTransfers =
                    //    GlobalObjects.CasEnvironment.Loader.GetLastTransferRecordsFrom(CurrentStore,
                    //                                                                   SmartCoreType.BaseDetail).ToArray();
                    //foreach (TransferRecord record in removedBaseDetailTransfers)
                    //{
                    //    //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                    //    BaseDetail bd = GlobalObjects.CasEnvironment.BaseDetails.GetItemById(record.ParentId);

                    //    if (record.DODR)
                    //    {
                    //        //если перемещение подтверждено, то деталь записывается в "перемещенные"
                    //        //окна "TransferedDetails"
                    //        if (_removedDetails.CompareAndAdd(bd)) _removedTransfers.Add(record);
                    //    }
                    //    else
                    //    {
                    //        //если перемещение не подтверждено, то деталь записывается в 
                    //        //"ожидабщие подтверждения" окна "TransferedDetails"
                    //        if (_waitRemoveConfirmDetails.CompareAndAdd(bd)) _waitRemoveConfirmTransfers.Add(record);
                    //    }
                    //}

                    //////////////////////////////////////////////////////
                    //     проверка на установленные компоненты         //
                    //////////////////////////////////////////////////////
                    IEnumerable<Component> lastInstalledDetails =
                        componentCollection.GetLastInstalledComponentsOn(op);
                    foreach (Component detail in lastInstalledDetails)
                    {
                        _installedComponents.Add(detail);
                        _installedTransfers.Add(detail.TransferRecords.GetLast());

                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        componentCollection.Remove(detail);
                    }
                    //////////////////////////////////////////////////////
                    //     добавление компонентов базовых агрегатов     //
                    //////////////////////////////////////////////////////
                    if (baseComponentCollection.Count > 0)
                        componentCollection.AddRange(GlobalObjects.ComponentCore.GetComponents(baseComponentCollection.ToList()).ToArray());
                    //////////////////////////////////////////////////////
                    //        проверка на удаленные компоненты          //
                    //////////////////////////////////////////////////////

                    ////извлечение из базы данных всех записей о перемещении
                    ////компонентов с данного базового агрегата
                    //TransferRecord[] records =
                    //    GlobalObjects.CasEnvironment.Loader.GetLastTransferRecordsFrom(CurrentStore).ToArray();

                    //foreach (TransferRecord record in records)
                    //{
                    //    //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                    //    Detail detail = GlobalObjects.CasEnvironment.Loader.GetDetailById(record.ParentId);

                    //    if (detail == null)
                    //        continue;

                    //    if (record.DODR)
                    //    {
                    //        //если перемещение подтверждено, то деталь записывается в "перемещенные"
                    //        //окна "TransferedDetails"
                    //        if (_removedDetails.CompareAndAdd(detail)) _removedTransfers.Add(record);
                    //    }
                    //    else
                    //    {
                    //        //если перемещение не подтверждено, то деталь записывается в 
                    //        //"ожидабщие подтверждения" окна "TransferedDetails"
                    //        if (_waitRemoveConfirmDetails.CompareAndAdd(detail)) _waitRemoveConfirmTransfers.Add(record);
                    //    }
                    //}

                    foreach (Component detail in componentCollection)
                    {
                        if (types.Contains(detail.MaintenanceControlProcess)) 
                            preResult.Add(detail);
                    }
                }


	            var ids = new List<int>();

	            foreach (var component in componentCollection)
	            {
		            foreach (var componentDirective in component.ComponentDirectives)
		            {
			            foreach (var items in componentDirective.ItemRelations.Where(i => i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId || i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
			            {
				            ids.Add(componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId);
			            }
		            }
	            }


	            var mpd = GlobalObjects.MaintenanceCore.GetMaintenanceDirectiveList(ids, CurrentAircraft.ItemId);
	            foreach (var component in componentCollection)
	            {
		            foreach (var componentDirective in component.ComponentDirectives)
		            {
			            foreach (var items in componentDirective.ItemRelations.Where(i => i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId || i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
			            {
				            var id = componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId;
				            componentDirective.MaintenanceDirective = mpd.FirstOrDefault(i => i.ItemId == id);
			            }
		            }
	            }


			}
            else
            {
                AnimatedThreadWorker.ReportProgress(20, "calculation components");

                //извлечение и собрание всех компоннтов самолета
                //(деталей и базовых деталей) в одну коллекцию
                List<MaintenanceControlProcess> types = new List<MaintenanceControlProcess>(_maintenanceTypes);

                if (DirectiveSource is BaseComponent)
                {
                    GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(_currentForecast);
                    preResult.AddRange(_currentForecast.Components.Where(detail => types.Contains(detail.MaintenanceControlProcess)));
                    preResult.AddRange(
                        _currentForecast.ComponentDirectives
                            .Where(cd => cd.ParentComponent != null &&
                                         types.Contains(cd.ParentComponent.MaintenanceControlProcess) &&
                                         !preResult.ContainsById(cd.ParentComponent.ItemId))
                            .Select(cd => cd.ParentComponent));
                }

                if (DirectiveSource is Aircraft)
                {
                    List<BaseComponentType> baseDetailTypes = new List<BaseComponentType>(_baseComponentTypes);

                    //фильтрование по типам базовых деталей
                    if (baseDetailTypes.Count != 0) _currentForecast.FilterByComponentType(baseDetailTypes);

                    //////////////////////////////////////////////////////
                    //   проверка на установленные базовые компоненты   //
                    //////////////////////////////////////////////////////
                    IEnumerable<BaseComponent> lastInstalledBaseDetails =
                        GlobalObjects.CasEnvironment.BaseComponents.GetLastInstalledComponentsOn((Aircraft)DirectiveSource);
                    foreach (BaseComponent baseDetail in lastInstalledBaseDetails)
                    {
                        _installedComponents.Add(baseDetail);
                        _installedTransfers.Add(baseDetail.TransferRecords.GetLast());

                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        _currentForecast.ForecastDatas.Remove(_currentForecast.GetForecastDataByBaseComponentId(baseDetail.ItemId));
                    }

                    GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectives(_currentForecast);
                    preResult.AddRange(_currentForecast.BaseComponents.Where(baseDetail => types.Contains(baseDetail.MaintenanceControlProcess)).ToArray());
                    preResult.AddRange(
                        _currentForecast.BaseComponentDirectives
                            .Where(cd => cd.ParentComponent != null &&
                                         types.Contains(cd.ParentComponent.MaintenanceControlProcess) &&
                                         !preResult.ContainsById(cd.ParentComponent.ItemId))
                            .Select(cd => cd.ParentComponent));

                    GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(_currentForecast);
                    preResult.AddRange(_currentForecast.Components.Where(detail => types.Contains(detail.MaintenanceControlProcess)).ToArray());
                    preResult.AddRange(
                        _currentForecast.ComponentDirectives
                            .Where(cd => cd.ParentComponent != null &&
                                         types.Contains(cd.ParentComponent.MaintenanceControlProcess) &&
                                         !preResult.ContainsById(cd.ParentComponent.ItemId))
                            .Select(cd => cd.ParentComponent));
                }

            }

            AnimatedThreadWorker.ReportProgress(50, "filter components");

            InitialFilterItems(preResult, _initialDirectiveArray);

            preResult.Clear();
          
            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            #region Калькуляция состояния компонентов

            AnimatedThreadWorker.ReportProgress(70, "calculation of components");

            var lldData = GlobalObjects.CasEnvironment.Loader
	            .GetObjectList<ComponentLLPCategoryData>(new ICommonFilter[]
	            {
					new CommonFilter<int>(ComponentLLPCategoryData.ComponentIdProperty, SmartCore.Filters.FilterType.In, _initialDirectiveArray.Select(i => i.ItemId).ToArray()), 
	            });

            var llpchangeRec = GlobalObjects.CasEnvironment.Loader
	            .GetObjectList<ComponentLLPCategoryChangeRecord>(new ICommonFilter[]
	            {
		            new CommonFilter<int>(ComponentLLPCategoryChangeRecord.ParentIdProperty, SmartCore.Filters.FilterType.In, _initialDirectiveArray.Select(i => i.ItemId).ToArray()),
	            });

			foreach (Component detail in _initialDirectiveArray)
            {
				if(_currentBaseComponent != null)
					detail.ParentAircraftId = _currentBaseComponent.ParentAircraftId;

				detail.LLPData.Clear();
				detail.LLPData.AddRange(lldData.Where(i => i.ComponentId == detail.ItemId));

				detail.ChangeLLPCategoryRecords.Clear();
				detail.ChangeLLPCategoryRecords.AddRange(llpchangeRec.Where(i => i.ParentId == detail.ItemId));

				GlobalObjects.PerformanceCalculator.GetNextPerformance(detail);
                _preResultDirectiveArray.Add(detail);

                foreach (ComponentDirective detailDirective in detail.ComponentDirectives)
                {
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(detailDirective);
                    _preResultDirectiveArray.Add(detailDirective);   
                }
            }

            AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

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
            if(_openPubWorkPackages == null) _openPubWorkPackages = new CommonCollection<WorkPackage>();
            
            _openPubWorkPackages.Clear();
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Opened));
            _openPubWorkPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Published));
            //сбор всех записей рабочих пакетов для удобства фильтрации
            List<WorkPackageRecord> openWPRecords = new List<WorkPackageRecord>();
            foreach (WorkPackage openWorkPackage in _openPubWorkPackages)
                openWPRecords.AddRange(openWorkPackage.WorkPakageRecords);

            foreach (IDirective dir in _resultDirectiveArray)
            {
                if (dir.NextPerformances == null || dir.NextPerformances.Count <= 0)
                    continue;
                BaseEntityObject baseObject = (BaseEntityObject)dir;
                //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                //для поиска перекрывающихся выполнений
                List<NextPerformance> performances = dir.NextPerformances;
                foreach (NextPerformance np in performances)
                {
                    //поиск записи в рабочих пакетах по данному чеку
                    //чей номер группы выполнения (по записи) совпадает с расчитанным
                    WorkPackageRecord wpr =
                        openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum 
                                                          && r.WorkPackageItemType == baseObject.SmartCoreObjectType.ItemId 
                                                          && r.DirectiveId == baseObject.ItemId);
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

			//TODO:(Evgenii Babak) требуется пересмотреть подход для Initial Order - ов со склада
            //if (_deferredCategories == null) _deferredCategories = new CommonCollection<DeferredCategory>();

            //_deferredCategories.Clear();
            //_deferredCategories.AddRange(
            //    GlobalObjects.CasEnvironment.Loader.
            //    GetObjectListAll<DeferredCategory>
            //    (new ICommonFilter[] { new CommonFilter<AircraftModel>(DeferredCategory.AircraftModelProperty, CurrentAircraft.Model) }));
            

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
        {
            _resultDirectiveArray.Clear();

            #region Фильтрация директив
            AnimatedThreadWorker.ReportProgress(50, "filter directives");
            
            AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

			var component = new List<Component>();

			if (_resultDirectiveArray.All(c => c is ComponentDirective))
			{
				foreach (ComponentDirective cd in _resultDirectiveArray)
				{
					component.Add(cd.ParentComponent);
				}
			}

			_resultDirectiveArray.AddRange(component.ToArray());

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
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemOpen = new ToolStripMenuItem();
            _toolStripMenuItemMoveToStore = new ToolStripMenuItem();
            _toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            _toolStripMenuItemsWorkPackages = new ToolStripMenuItem();
            _toolStripMenuItemComposeQuotationOrder = new ToolStripMenuItem();
            _toolStripMenuItemComposeInitialOrder = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
            _toolStripMenuItemDelete = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripSeparator2 = new ToolStripSeparator();
            _toolStripSeparator4 = new ToolStripSeparator();
            _toolStripMenuItemCopy=new ToolStripMenuItem();
            _toolStripMenuItemPaste=new ToolStripMenuItem();
			_toolStripMenuItemPrint = new ToolStripMenuItem();
			_toolStripMenuItemPrintCalibrationTag = new ToolStripMenuItem();
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
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";
            // 
            // toolStripMenuItemMoveToStore
            // 
            _toolStripMenuItemMoveToStore.Text = "Move to Store";
            _toolStripMenuItemMoveToStore.Click += ButtonRemoveToStoreClick;
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
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemComposeQuotationOrder.Text = "Compose quotation order";
            _toolStripMenuItemComposeQuotationOrder.Click += ToolStripMenuItemComposeQuotationClick;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemQuotations.Text = "Add to Quotation Order";
            //
            // _toolStripMenuItemComposeInitialOrder
            //
            _toolStripMenuItemComposeInitialOrder.Text = "Compose a Initial Order";
            // 
            // toolStripMenuItemDelete
            // 
            _toolStripMenuItemDelete.Text = "Delete";
            _toolStripMenuItemDelete.Click += ButtonDeleteClick;

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
			// _toolStripMenuItemPrintInspectionTag
			// 
			_toolStripMenuItemPrintCalibrationTag.Text = "Calibration Tag";
			_toolStripMenuItemPrintCalibrationTag.Click += _toolStripMenuItemPrintCalibrationTag_Click;
			// 
			// _toolStripMenuItemPrint
			// 
			_toolStripMenuItemPrint.Text = "Print";
			_toolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[]
			{
				_toolStripMenuItemPrintCalibrationTag,
			});

			_contextMenuStrip.Items.Clear();
            _toolStripMenuItemsWorkPackages.DropDownItems.Clear();
            _toolStripMenuItemQuotations.DropDownItems.Clear();
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
                                                    _toolStripMenuItemOpen,
                                                    new ToolStripSeparator(),
                                                    _toolStripMenuItemHighlight,
                                                    _toolStripSeparator2,
                                                    _toolStripMenuItemMoveToStore,
                                                    new ToolStripSeparator(),
													 _toolStripMenuItemPrint,
													 new ToolStripSeparator(),
													_toolStripMenuItemComposeWorkPackage,
                                                    _toolStripMenuItemsWorkPackages,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemComposeInitialOrder,
                                                    _toolStripMenuItemComposeQuotationOrder,
                                                    _toolStripMenuItemQuotations,
													_toolStripSeparator4, 
                                                    _toolStripMenuItemCopy,
                                                    _toolStripMenuItemPaste,
                                                     _toolStripMenuItemDelete

                                                });
            _contextMenuStrip.Opening += ContextMenuStripOpen;
        }

		#endregion

	    private void InitPrintToolStripMenuItems()
	    {
		    _buttonPrintMenuStrip = new ContextMenuStrip();
		    _itemPrintReportComponents = new ToolStripMenuItem { Text = "Components" };
		    _itemPrintReportLLP = new ToolStripMenuItem { Text = "LLP" };
		    itemPrintReportMPLLP = new ToolStripMenuItem { Text = "MP LLP" };
		    itemPrintReportMP = new ToolStripMenuItem { Text = "MP HT" };
		    itemPrintLitAvia = new ToolStripMenuItem { Text = "SS Comp LA" };

			if (_currentBaseComponent != null && _currentBaseComponent.BaseComponentType == BaseComponentType.Engine && _currentBaseComponent.LLPCategories)
		    {
			    _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportComponents, _itemPrintReportLLP, itemPrintReportMPLLP, itemPrintLitAvia });
		    }
		    else
		    {
			    _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportComponents, itemPrintReportMP, itemPrintLitAvia });
			}

		    ButtonPrintMenuStrip = _buttonPrintMenuStrip;
		}

		#region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
		/// <summary>
		/// Проверка на выделение 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
        {
	        if (_directivesViewer.SelectedItems.Count == 0)
	        {
				_toolStripMenuItemOpen.Enabled = false;
				_toolStripMenuItemHighlight.Enabled = false;
				_toolStripMenuItemMoveToStore.Enabled = false;
				_toolStripMenuItemComposeWorkPackage.Enabled = false;
				_toolStripMenuItemsWorkPackages.Enabled = false;
				_toolStripMenuItemComposeInitialOrder.Enabled = false;
				_toolStripMenuItemComposeQuotationOrder.Enabled = false;
				_toolStripMenuItemQuotations.Enabled = false;
				_toolStripMenuItemDelete.Enabled = false;
			}

            if (_directivesViewer.SelectedItems.Count == 1)
            {
				
				_toolStripMenuItemOpen.Enabled = true;
                _toolStripMenuItemMoveToStore.Enabled = true;

	            if (_directivesViewer.SelectedItem is Component)
	            {
					var component = _directivesViewer.SelectedItem as Component;
					_toolStripMenuItemPrintCalibrationTag.Enabled =
						 component.ComponentDirectives.Any(c => c.DirectiveType.ItemId == ComponentRecordType.Calibration.ItemId);
				}
	            else
	            {
					_toolStripMenuItemPrintCalibrationTag.Enabled = false;
				}
				
			}

            if (_directivesViewer.SelectedItems.Count > 0)
            {
                _toolStripMenuItemCopy.Enabled = _directivesViewer.SelectedItems.Any(selecteItem => selecteItem is Component && ((Component)selecteItem).IsBaseComponent == false);
				_toolStripMenuItemOpen.Enabled = true;
				_toolStripMenuItemHighlight.Enabled = true;
				_toolStripMenuItemMoveToStore.Enabled = true;
				_toolStripMenuItemComposeWorkPackage.Enabled = true;
				_toolStripMenuItemsWorkPackages.Enabled = true;
				_toolStripMenuItemComposeInitialOrder.Enabled = true;
				_toolStripMenuItemComposeQuotationOrder.Enabled = true;
				_toolStripMenuItemQuotations.Enabled = true;
				_toolStripMenuItemDelete.Enabled = true;
			}
        }

		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
            {
                Highlight highLight = (Highlight)((ToolStripMenuItem)sender).Tag;

                if (_directivesViewer.SelectedItems[i] is Component)
                {
                    ((Component)_directivesViewer.SelectedItems[i]).Highlight = highLight;
                    _directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
                }
                if (_directivesViewer.SelectedItems[i] is ComponentDirective)
                {
                    ((ComponentDirective)_directivesViewer.SelectedItems[i]).Highlight = highLight;
                    _directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
                }
            }
        }

        #endregion

        #region private void ButtonRemoveToStoreClick(object sender, EventArgs e)

        private void ButtonRemoveToStoreClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count == 0)
                return;
            if (GlobalObjects.AircraftsCore.GetAircraftsCount() == 0)
            {
                MessageBox.Show("You dont remove this component because you dont have a aircrafts", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Component> elements = _directivesViewer.SelectedItems.OfType<Component>().ToList();

            if (elements.Count == 0)
            {
                MessageBox.Show("You can not remove detail directives", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MoveComponentForm dlg = new MoveComponentForm(elements.ToArray(), _currentAircraft)
                                     {
                                         Text = "remove " +
                                                (elements.Count > 1
                                                     ? "components"
                                                     : "component " + elements[0].Description)
                                                + "from aircraft"
                                     };

            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
                AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

                AnimatedThreadWorker.RunWorkerAsync();
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
                    .Where(o => o is IDirective 
                                && ((IDirective) o).NextPerformances != null
                                && ((IDirective) o).NextPerformances.Count > 0)
                    .Select(o => ((IDirective) o).NextPerformances[0]).ToList();
                try
                {
                    string message;
                    WorkPackage wp =
                        GlobalObjects.WorkPackageCore.AddWorkPakage(wpItems, _currentAircraft, out message);
                    if (wp == null)
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
                    _openPubWorkPackages.Add(wp);
                    //Создание пункта в меню открытых рабочих пакетов
                    ToolStripMenuItem item = new ToolStripMenuItem(wp.Title);
                    item.Click += AddToWorkPackageItemClick;
                    item.Tag = wp;
                    _toolStripMenuItemsWorkPackages.DropDownItems.Add(item);

                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        _directivesViewer.UpdateItemColor(nextPerformance.Parent as BaseEntityObject);
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

            WorkPackage wp = (WorkPackage)((ToolStripMenuItem)sender).Tag;

            if (MessageBox.Show("Add item to Work Package: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                DialogResult.Yes)
            {
                List<NextPerformance> wpItems = _directivesViewer.SelectedItems
                    .Where(o => o is IDirective
                                && ((IDirective)o).NextPerformances != null
                                && ((IDirective)o).NextPerformances.Count > 0)
                    .Select(o => ((IDirective)o).NextPerformances[0]).ToList();
                try
                {
                    string message;
                    
                    if (!GlobalObjects.WorkPackageCore.AddToWorkPakage(wpItems, wp.ItemId,
	                    _currentAircraft ?? GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId), out message))
                    {
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    foreach (NextPerformance nextPerformance in wpItems)
                    {
                        nextPerformance.BlockedByPackage = wp;
                        _directivesViewer.UpdateItemColor(nextPerformance.Parent as BaseEntityObject);
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

        #region private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        /// <summary>
        /// Создает закупочный ордер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeQuotationClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeQuotationOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

        #endregion

        #region private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        /// <summary>
        /// Создает закупочный ордер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        {
            //DeferredCategory dc = ((ToolStripMenuItem)sender).Tag as DeferredCategory ?? DeferredCategory.Unknown;

            //PurchaseManager.ComposeInitialOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, dc, this);
            PurchaseManager.ComposeInitialOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

		#endregion

		#region private void _toolStripMenuItemPrintCalibrationTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintCalibrationTag_Click(object sender, EventArgs e)
		{
			var component = _directivesViewer.SelectedItem as Component;

			var refE = new ReferenceEventArgs();
			var report = new CalibrationTagReportBuilder(CurrentOperator, component);
			refE.DisplayerText = "CALIBRATION TAG";
			refE.RequestedEntity = new ReportScreen(report);
			refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			InvokeDisplayerRequested(refE);
		}

		#endregion

		#region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

		private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
            ComponentCollection selected = new ComponentCollection();
            foreach (BaseEntityObject o in _directivesViewer.SelectedItems)
            {
                if (o is ComponentDirective)
                    selected.CompareAndAdd(((ComponentDirective)o).ParentComponent);
                if (o is Component)
                    selected.CompareAndAdd((Component)o);
            }

            foreach (Component t in selected)
            {
                var refE = new ReferenceEventArgs();
	            DisplayerParams dp = null;
                string regNumber = "";
                if (t is BaseComponent)
                {
                    if (((BaseComponent)t).BaseComponentType.ItemId == 4)
                        regNumber = t.ToString();
                    else
                    {
	                    dp = ScreenAndFormManager.GetBaseComponentScreen((BaseComponent)t);
                    }
                }
                else
                {
	                dp = ScreenAndFormManager.GetComponentScreen(t);
                }
                refE.SetParameters(dp);
                InvokeDisplayerRequested(refE);
            }
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems == null)
                return;

            bool exclamation = _directivesViewer.SelectedItems.OfType<BaseComponent>().Any();
            if (exclamation)
            {
                MessageBox.Show(
                    "You can not remove Base Detail from here.",
                    new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult confirmResult =
                MessageBox.Show(
                    _directivesViewer.SelectedItem != null
                        ? "Do you really want to delete " +
                            (_directivesViewer.SelectedItem is Component
                            ? "component " + ((Component)_directivesViewer.SelectedItem).SerialNumber
                            : "detail directive " + ((ComponentDirective)_directivesViewer.SelectedItem).DirectiveType) +
                          "?"
                        : "Do you really want to delete selected elements? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;

                try
                {
                    _directivesViewer.ItemListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        if (_directivesViewer.SelectedItems[i] is Component)
                        {
                            GlobalObjects.ComponentCore.DeleteComponent((Component)_directivesViewer.SelectedItems[i]);
                        }
                        if (_directivesViewer.SelectedItems[i] is ComponentDirective)
                        {
                            GlobalObjects.ComponentCore.DeleteComponentDirective((ComponentDirective)_directivesViewer.SelectedItems[i]);
                        }
                    }
                    //parent.Remove(selectedItems[i]);
                    _directivesViewer.ItemListView.EndUpdate();

					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
					AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

					AnimatedThreadWorker.RunWorkerAsync();

				}
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }
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
            _directivesViewer = _currentBaseComponent != null 
                ? new ComponentsListView(_currentBaseComponent) 
                : new ComponentsListView(_currentAircraft != null ? GlobalObjects.ComponentCore.GetBaseComponentById(_currentAircraft.AircraftFrameId) : null);
            _directivesViewer.TabIndex = 2;
            _directivesViewer.ContextMenuStrip = _contextMenuStrip;
            _directivesViewer.Location = new Point(panel1.Left, panel1.Top);
            _directivesViewer.Dock = DockStyle.Fill;
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            Controls.Add(_directivesViewer);
            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
        }

        #endregion

        #region private void TransferedDetailFormShow()
        private void TransferedDetailFormShow()
        {
            if (_transferedComponentForm != null) _transferedComponentForm.Show();
            else
            {
                if (_removedComponents.Count > 0 || _waitRemoveConfirmComponents.Count > 0
                || _installedComponents.Count > 0)
                {
                    _transferedComponentForm = new TransferedComponentForm(_removedComponents.ToArray(),
                                                                     _removedTransfers.ToArray(),
                                                                     _waitRemoveConfirmComponents.ToArray(),
                                                                     _waitRemoveConfirmTransfers.ToArray(),
                                                                     _installedComponents.ToArray(),
                                                                     _installedTransfers.ToArray(),
                                                                     DirectiveSource.SmartCoreObjectType);
                    _transferedComponentForm.Show();
                    _transferedComponentForm.Closed += TransferedComponentFormClosed;
                    _transferedComponentForm.ButtonAddClick += TransferedComponentFormButtonAddClick;
                    _transferedComponentForm.ButtonDeleteClick += TransferedComponentFormButtonDeleteClick;
                    _transferedComponentForm.ButtonCancelClick += TransferedComponentFormButtonCancelClick;
                }
            }
        }
        #endregion

        #region private void TransferedDetailFormClosed(object sender, EventArgs e)
        private void TransferedComponentFormClosed(object sender, EventArgs e)
        {
            _transferedComponentForm = null;
        }
        #endregion

        #region private void TransferedDetailFormButtonAddClick(object sender, EventArgs e)

        private void TransferedComponentFormButtonAddClick(object sender, EventArgs e)
        {
            _transferedComponentForm.Close();

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void TransferedDetailFormButtonDeleteClick(object sender, EventArgs e)

        private void TransferedComponentFormButtonDeleteClick(object sender, EventArgs e)
        {
            _transferedComponentForm.Close();

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        #region private void TransferedDetailFormButtonCancelClick(object sender, EventArgs e)
        private void TransferedComponentFormButtonCancelClick(object sender, EventArgs e)
        {
            _transferedComponentForm.Close();

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region Для скрытия формы

        #region protected override void ScreenChanget(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие смены скрина в данной вкладке
        /// </summary>
        protected override void ScreenChanget(object sender, EventArgs e)
        {
            if (Displayer.Entity == this && _transferedComponentForm != null)
            {
                //если в данной вкладке отображается данный скрин(DetailListScreen)
                //и окно перемещенных компонентов создано, то это окно надо открыть
                _transferedComponentForm.Show();
            }

            if (Displayer.Entity != this && _transferedComponentForm != null)
            {
                //если в данной вкладке отображается не данный скрин( не DetailListScreen )
                //и окно перемещенных компонентов создано, то это окно надо скрыть
                _transferedComponentForm.Hide();
            }
        }
        #endregion

        #region protected override void CancelClosingWindow(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие отмены закрытия программы
        /// </summary>
        protected override void CancelClosingWindow(object sender, EventArgs e)
        {
            if (Displayer.Entity == this && _transferedComponentForm != null)
            {
                //если в данной вкладке отображается данный скрин(DetailListScreen)
                //и окно перемещенных компонентов создано, то это окно надо открыть
                _transferedComponentForm.Show();
            }
        }
        #endregion

        #region protected override void ClosingWindow(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие нажатия кнопки закрытия программы
        /// </summary>
        protected override void ClosingWindow(object sender, EventArgs e)
        {
            if (_transferedComponentForm != null)
            {
                //если в данной вкладке отображается не данный скрин( не DetailListScreen )
                //и окно перемещенных компонентов создано, то это окно надо скрыть
                _transferedComponentForm.Hide();
            }
        }
        #endregion

        #region protected override void ParentControlSelected(object sender, AvMultitabControlEventArgs e)
        /// <summary>
        /// Метод обрабатывает событие смены текущей вкладки в MultiTabControl-е
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ParentControlSelected(object sender, AvMultitabControlEventArgs e)
        {
            if (Displayer.ParentControl.SelectedTab == Displayer && _transferedComponentForm != null && Displayer.Entity == this)
            {
                //если в данной вкладке отображается данный скрин(DetailListScreen)
                //и окно перемещенных компонентов создано, то это окно надо открыть
                _transferedComponentForm.Show();
            }

            if (Displayer.ParentControl.SelectedTab != Displayer && _transferedComponentForm != null)
            {
                //если в данной вкладке отображается не данный скрин( не DetailListScreen )
                //и окно перемещенных компонентов создано, то это окно надо скрыть
                _transferedComponentForm.Hide();
            }
        }
		#endregion

		#endregion

		#region private void ButtonPreTransferFilter_Click(object sender, System.EventArgs e)

		private void ButtonPreTransferFilter_Click(object sender, EventArgs e)
	    {
		    var refE = new ReferenceEventArgs();
		    refE.DisplayerText = "Transfer";

		    if(_currentBaseComponent != null)
			    refE.RequestedEntity = new PreConfirmComponentsListScreen(_currentBaseComponent);
		    else refE.RequestedEntity = new PreConfirmComponentsListScreen(CurrentAircraft);

		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;

		    InvokeDisplayerRequested(refE);
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
                e.DisplayerText = _currentAircraft.RegistrationNumber + ". " + _builder.ReportTitle + " Report";
            else if (_currentBaseComponent != null)
                e.DisplayerText = _currentBaseComponent + ". " + _builder.ReportTitle + " Report";
            else
                e.DisplayerText = _builder.ReportTitle + " Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;

            _builder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            if (_currentAircraft != null)
            {
	            if (sender == itemPrintReportMP)
	            {
		            _amReportBuilder.ReportedAircraft = CurrentAircraft;
		            _amReportBuilder.ReportTitle = "SECTION 8 – TIME CONTROLLED ITEMS";

		            var comp = _directivesViewer.GetItemsArray().Where(i => i is Component).Cast<Component>().Where(i =>
			            i.MaintenanceControlProcess.ItemId == MaintenanceControlProcess.HT.ItemId);

		            var ids = new List<int>();

		            foreach (var component in comp)
		            {
			            foreach (var componentDirective in component.ComponentDirectives)
			            {
				            foreach (var items in componentDirective.ItemRelations.Where(i => i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId || i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
				            {
					            ids.Add(componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId);
				            }
			            }
		            }


		            var mpd = GlobalObjects.MaintenanceCore.GetMaintenanceDirectiveList(ids, CurrentAircraft.ItemId);
					foreach (var component in comp)
					{
						foreach (var componentDirective in component.ComponentDirectives)
						{
							foreach (var items in componentDirective.ItemRelations.Where(i => i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId || i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
							{
								var id = componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId;
								componentDirective.MaintenanceDirective = mpd.FirstOrDefault(i => i.ItemId == id);
							}
						}
					}

					_amReportBuilder.AddDirectives(comp);
		            e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP HT";
		            e.RequestedEntity = new ReportScreen(_amReportBuilder);
	            }
	            else if (sender == itemPrintLitAvia)
	            {
		            var comp = _directivesViewer.GetItemsArray().Where(i => i is Component).Cast<Component>().Where(i =>
			            i.MaintenanceControlProcess.ItemId == MaintenanceControlProcess.HT.ItemId);

		            var mpds = new List<MaintenanceDirective>();
					foreach (var component in comp)
		            {
			            foreach (var directive in component.ComponentDirectives)
			            {
							if(directive.MaintenanceDirective == null)
								continue;

				            directive.MaintenanceDirective.CompnentSN = component.SerialNumber;
				            directive.MaintenanceDirective.CompnentPN = component.PartNumber;
							mpds.Add(directive.MaintenanceDirective);
						}
		            }

					_maintenanceDirectiveReportBuilderLitAVia.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
		            _maintenanceDirectiveReportBuilderLitAVia.ReportedAircraft = CurrentAircraft;
		            _maintenanceDirectiveReportBuilderLitAVia.AddDirectives(mpds);
		            e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "SS Comp LA";
		            e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilderLitAVia);
				}

				else if (sender == _itemPrintReportComponents)
	            {
		            _builder.FilterSelection = _additionalfilter;
		            _builder.ReportedAircraft = CurrentAircraft;
		            _builder.AddDirectives(_directivesViewer.GetItemsArray());
		            _builder.Forecast = _currentForecast;
		            e.RequestedEntity = new ReportScreen(_builder);
				}
	            else
	            {
		            e.Cancel = true;
	            }


			}
            else
            {
                if (_currentBaseComponent != null)
                {
                    String selection = "";
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
                        selection = _currentBaseComponent.TransferRecords.GetLast().Position;
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.Engine)
                        selection = BaseComponentType.Engine + " " + _currentBaseComponent.TransferRecords.GetLast().Position;
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.Apu)
                        selection = BaseComponentType.Apu.ToString();


	                if (sender == itemPrintLitAvia)
	                {
		                var comp = _directivesViewer.GetItemsArray().Where(i => i is Component).Cast<Component>().Where(i =>
			                i.MaintenanceControlProcess.ItemId == MaintenanceControlProcess.HT.ItemId);

						var mpds = new List<MaintenanceDirective>();
		                foreach (var component in comp)
		                {
			                foreach (var directive in component.ComponentDirectives)
			                {
				                if (directive.MaintenanceDirective == null)
					                continue;

				                directive.MaintenanceDirective.CompnentSN = component.SerialNumber;
				                directive.MaintenanceDirective.CompnentPN = component.PartNumber;
				                mpds.Add(directive.MaintenanceDirective);
			                }
		                }

						_maintenanceDirectiveReportBuilderLitAVia.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
		                _maintenanceDirectiveReportBuilderLitAVia.ReportedAircraft = CurrentAircraft;
		                _maintenanceDirectiveReportBuilderLitAVia.AddDirectives(mpds);
		                e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "SS Comp LA";
		                e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilderLitAVia);
	                }
					else if (sender == itemPrintReportMPLLP)
                    {
	                    _amLLPReportBuilder.ReportedAircraft = CurrentAircraft;
	                    _amLLPReportBuilder.ReportTitle = "SECTION 8 – TIME CONTROLLED ITEMS";

	                    var components = _directivesViewer.GetItemsArray().Where(i => i is Component).Cast<Component>().ToList();
						components.Sort();

						_amLLPReportBuilder.AddDirectives(components);
	                    e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "MP LLP";
	                    e.RequestedEntity = new ReportScreen(_amLLPReportBuilder);

                    }

					else if (_llpMark)
                    {
#if KAC
                        ComponentLLPReportBuilderKAC llpBuilder = new ComponentLLPReportBuilderKAC
                        {
                            FilterSelection = selection,
                            ReportedBaseDetail = _currentBaseDetail,
                            Forecast = _currentForecast
                        };
#else 
                        ComponentLLPReportBuilder llpBuilder = new ComponentLLPReportBuilder
                                            {
                                                FilterSelection = selection,
                                                ReportedBaseComponent = _currentBaseComponent,
                                                Forecast = _currentForecast
                                            };
#endif
                        llpBuilder.AddDirectives(_directivesViewer.GetItemsArray().Cast<Component>().OrderBy(i => Convert.ToInt32(i.Position)).ToArray());
                        e.RequestedEntity = new ReportScreen(llpBuilder);
                    }
                    else
                    {
                        if (sender == _itemPrintReportLLP)
                        {
#if KAC
                            ComponentLLPReportBuilderKAC llpBuilder = new ComponentLLPReportBuilderKAC
                            {
                                FilterSelection = selection,
                                ReportedBaseDetail = _currentBaseDetail,
                                Forecast = _currentForecast
                            };
#else
                            ComponentLLPReportBuilder llpBuilder = new ComponentLLPReportBuilder
                                                                       {
                                                                           FilterSelection = selection,
                                                                           ReportedBaseComponent = _currentBaseComponent,
                                                                           Forecast = _currentForecast
                                                                       };
#endif
                            llpBuilder.AddDirectives(_directivesViewer.GetItemsArray().OfType<Component>().Where(d => d.LLPMark).ToArray());
                            e.RequestedEntity = new ReportScreen(llpBuilder);
                        }
						else
                        {
                            if(_currentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
                            {
                                LandingGearLLPStatusBuilder lgllpBuilder = new LandingGearLLPStatusBuilder
                                {
                                    ReportTitle = _currentBaseComponent.Position + " Life Limited Parts Status",
                                    FilterSelection = selection,
                                    ReportedBaseComponent =  _currentBaseComponent,
                                    Forecast = _currentForecast
                                };
                                lgllpBuilder.AddDirectives(_directivesViewer.GetItemsArray());
                                e.RequestedEntity = new ReportScreen(lgllpBuilder);
                            }
                            else
                            {
                                _builder.LifelengthAircraftSinceNew =
                                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                                _builder.FilterSelection = _additionalfilter;
                                _builder.ReportedBaseComponent = _currentBaseComponent;
                                if (_currentBaseComponent.BaseComponentType != BaseComponentType.Engine)
                                    _builder.AddDirectives(_directivesViewer.GetItemsArray());
                                else _builder.AddDirectives(_directivesViewer.GetItemsArray().OfType<Component>().Where(d => d.LLPMark == false).ToArray());
                                _builder.Forecast = _currentForecast;
                                e.RequestedEntity = new ReportScreen(_builder);   
                            }
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            } 
        }
        #endregion

        #region private void HeaderControlSaveButtonClick(object sender, EventArgs e)

        private void HeaderControlSaveButtonClick(object sender, EventArgs e)
        {
            var unsavedItems =
                _directivesViewer.GetItemsArray().Where(o => o.ItemId <= 0 && o is Component).Cast<Component>().ToList();

            try
            {
                foreach (var unsavedItem in unsavedItems)
                {
                    GlobalObjects.CasEnvironment.Keeper.SaveAll(unsavedItem, true);
                    //foreach (DetailDirective detailDirective in unsavedItem.DetailDirectives)
                    //{
                    //    GlobalObjects.CasEnvironment.Keeper.SaveAll(detailDirective);
                    //}
                }

                MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                headerControl.ShowSaveButton = false;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save directive from directives list", ex);
            }
        }

        #endregion

        #region private void ButtonTransferedDetailsClick(object sender, EventArgs e)

        private void ButtonTransferedDetailsClick(object sender, EventArgs e)
        {
            TransferedDetailFormShow();
        }

        #endregion

        #region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (DirectiveSource is Aircraft)
                e.RequestedEntity = new ComponentAddingScreen(DirectiveSource as Aircraft);
            else if (DirectiveSource is BaseComponent)
                e.RequestedEntity = new ComponentAddingScreen(DirectiveSource as BaseComponent);
            else if (DirectiveSource is Store)
                e.RequestedEntity = new ComponentAddingScreen(DirectiveSource as Store);
            else if (DirectiveSource is Operator)
                e.RequestedEntity = new ComponentAddingScreen(DirectiveSource as Operator);

            if (_currentAircraft != null)
                e.DisplayerText = _currentAircraft.RegistrationNumber + ". New Component";
            else if (_currentBaseComponent != null)
                e.DisplayerText = _currentBaseComponent.SerialNumber + ". New Component";
            else if (CurrentStore != null)
                e.DisplayerText = CurrentStore.Name + ". New Component";
            else if (aircraftHeaderControl1.Operator != null)
                e.DisplayerText = aircraftHeaderControl1.Operator.Name + ". New Component";
        }

        #endregion

        #region private void ButtonApplyFilterClick(object sender, EventArgs e)

        private void ButtonApplyFilterClick(object sender, EventArgs e)
        {
            CommonFilterForm form = new CommonFilterForm(_additionalfilter, _preResultDirectiveArray);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
                AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

                AnimatedThreadWorker.RunWorkerAsync();
            }
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
                                        string.Format("Forecast: {0}. {1}",
                                                       main.CheckName,
                                                       main.NextPerformance);
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

        #region private void InitialFilterItems(IEnumerable<PrimaryDirective> initialCollection, ICommonCollection<PrimaryDirective> resultCollection)

        ///<summary>
        ///</summary>
        ///<param name="initialCollection"></param>
        ///<param name="resultCollection"></param>
        private void InitialFilterItems(IEnumerable<Component> initialCollection, ICommonCollection<Component> resultCollection)
        {
            if (_initialFilter == null || _initialFilter.Count == 0)
            {
                resultCollection.Clear();
                resultCollection.AddRange(initialCollection);
                return;
            }

            resultCollection.Clear();

            foreach (Component pd in initialCollection)
            {
                //if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
                //{
                //    pd.MaintenanceCheck.ToString();
                //}
                if (_initialFilter.FilterTypeAnd)
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _initialFilter)
                    {
                        acceptable = filter.Acceptable(pd); if (!acceptable) break;
                    }
                    if (acceptable) resultCollection.Add(pd);
                }
                else
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _initialFilter)
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

        #region private void AdditionalFilterItems(IEnumerable<BaseEntityObject> initialCollection, ICommonCollection<BaseEntityObject> resultCollection)

        ///<summary>
        ///</summary>
        ///<param name="initialCollection"></param>
        ///<param name="resultCollection"></param>
        private void AdditionalFilterItems(IEnumerable<BaseEntityObject> initialCollection, ICommonCollection<BaseEntityObject> resultCollection)
        {
            if (_additionalfilter == null || _additionalfilter.Count == 0)
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
                if (_additionalfilter.FilterTypeAnd)
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _additionalfilter)
                    {
                        acceptable = filter.Acceptable(pd); if (!acceptable) break;
                    }
                    if (acceptable) resultCollection.Add(pd);
                }
                else
                {
                    bool acceptable = true;
                    foreach (ICommonFilter filter in _additionalfilter)
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

        #region  private void PasteItemsClick(object sender, EventArgs e)

        private void PasteItemsClick(object sender, EventArgs e)
        {
            GetFromClipboard();
        }

        #endregion

        #region private void CopyItemsClick(object sender, EventArgs e

        private void CopyItemsClick(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        #endregion

        #region private void CopyToClipboard()
        private void CopyToClipboard()
        {
            // регистрация формата данных либо получаем его, если он уже зарегистрирован
            try
            {

                bool _showMsg = false;
                DataFormats.Format format = DataFormats.GetFormat(typeof(Component[]).FullName);

                if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)
                    return;

                List<Component> pds = new List<Component>();
	            int detailId = -1;
                foreach (var selecteditem in _directivesViewer.SelectedItems)
                {
                    if (!(selecteditem is Component))
                        continue;

                    if ((selecteditem as Component).IsBaseComponent)
                    {
                        _showMsg = true;
                        continue;
                    }

                    pds.Add(((Component)selecteditem).GetCopyUnsaved(detailId));
	                detailId--;
                }

                if (_showMsg)
                    MessageBox.Show("Engines, LandGear's Frame, APU, Propeller's couldn't be copied", "Warning", MessageBoxButtons.OK);

                if (pds.Count <= 0)
                    return;

                //todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
                using (MemoryStream mem = new MemoryStream())
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    try
                    {
                        bin.Serialize(mem, pds);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Объект не может быть сериализован. \n" + ex);
                        return;
                    }
                }
                // копирование в буфер обмена
                IDataObject dataObj = new DataObject();
                dataObj.SetData(format.Name, false, pds.ToArray());
                Clipboard.SetDataObject(dataObj, false);

                pds.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while copying new object(s). \n" + ex);
                Program.Provider.Logger.Log(ex);
            }
        }
        #endregion

        #region private void GetFromClipboard()

        private void GetFromClipboard()
        {
            try
            {
                string format = typeof(Component[]).FullName;

                if (string.IsNullOrEmpty(format))
                    return;
                if (!Clipboard.ContainsData(format))
                    return;
                var pds = (Component[])Clipboard.GetData(format);
                if (pds == null)
                    return;

                var objectsToPaste = new List<BaseEntityObject>();
                var bd = DirectiveSource is BaseComponent ? (BaseComponent)DirectiveSource : GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft)DirectiveSource).AircraftFrameId);
                foreach (var component in pds)
                {
                    component.ParentBaseComponent = bd;
                    component.ParentAircraftId = CurrentAircraft.ItemId;

                    var tr = component.TransferRecords.Last();
                    tr.DestinationObject = bd;
                    tr.DestinationObjectId = bd.ItemId;
                    tr.DestinationObjectType = bd.SmartCoreObjectType;

	                if (!component.LLPMark && !component.LLPCategories)
						GlobalObjects.PerformanceCalculator.GetNextPerformance(component);

	                if (component.LLPCategories)
	                {
						component.ChangeLLPCategoryRecords.Clear();

		                foreach (var llp in component.LLPData)
		                {
			                llp.LLPTemp = null;
			                llp.LLPCurrent = null;
			                llp.Remain = null;
		                }

	                }


                    _initialDirectiveArray.Add(component);
                    _resultDirectiveArray.Add(component);

                    component.PartNumber += " Copy";
                    objectsToPaste.Add(component);

                    foreach (ComponentDirective componentDirective in component.ComponentDirectives)
                    {
	                    componentDirective.PerformanceRecords.Clear();
	                    GlobalObjects.PerformanceCalculator.GetNextPerformance(componentDirective);
                        _resultDirectiveArray.Add(componentDirective);
                        objectsToPaste.Add(componentDirective);
                    }

	                if (component.TransferRecords.Count > 0)
	                {
		                var first = component.TransferRecords.OrderBy(i => i.TransferDate).First(i => i.DestinationObjectType == SmartCoreType.BaseComponent);
		                component.TransferRecords.Clear();
						component.TransferRecords.Add(first);
					}
                }

                if (objectsToPaste.Count > 0)
                {
                    _directivesViewer.InsertItems(objectsToPaste.ToArray());
                    headerControl.ShowSaveButton = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting new object(s). \n" + ex);
                headerControl.ShowSaveButton = false;
                Program.Provider.Logger.Log(ex);
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
