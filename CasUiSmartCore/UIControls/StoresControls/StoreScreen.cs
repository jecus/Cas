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
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentChangeReport;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using CASReports.Builders;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Filters;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class StoreScreen : ScreenControl
    {
        #region Fields

        private bool _firstLoad;
	    private bool _calculateWpItems;

        private Forecast _currentForecast;

		private CommonFilterCollection _additionalfilter = new CommonFilterCollection(typeof(IStoreFilterParam));
		private ICommonCollection<BaseEntityObject> _preResultDirectiveArray = new CommonCollection<BaseEntityObject>();
		private ICommonCollection<BaseEntityObject> _resultDirectiveArray = new CommonCollection<BaseEntityObject>();

		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private CommonCollection<StockComponentInfo> _shouldBeOnStock = new CommonCollection<StockComponentInfo>();
        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
        private ComponentCollection _removedComponents = new ComponentCollection();
        private ComponentCollection _waitRemoveConfirmComponents = new ComponentCollection();
        private ComponentCollection _installedComponents = new ComponentCollection();
        private TransferRecordCollection _removedTransfers = new TransferRecordCollection();
        private TransferRecordCollection _installedTransfers = new TransferRecordCollection();
        private TransferRecordCollection _waitRemoveConfirmTransfers = new TransferRecordCollection();

        private StoreComponentsListView _directivesViewer;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemComposeInitialOrder;
        private ToolStripMenuItem _toolStripMenuItemComposeQuotationOrder;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
        private ToolStripMenuItem _toolStripMenuItemMoveTo;
        private ToolStripMenuItem _toolStripMenuItemOpen;
        private ToolStripMenuItem _toolStripMenuItemAdd;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripMenuItem _toolStripMenuItemLlpDiskSheetStatus;
        private ToolStripMenuItem _toolStripMenuItemEngineeringOrders;
        private ToolStripMenuItem _toolStripMenuItemSbStatus;
        private ToolStripMenuItem _toolStripMenuItemAdStatus;
        private ToolStripMenuItem _toolStripMenuItemDiscrepancies;
        private ToolStripMenuItem _toolStripMenuItemLogBook;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripMenuItem _toolStripMenuItemShouldBeOnStock;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemPrint;
		private ToolStripMenuItem _toolStripMenuItemPrintServisibleTag;
		private ToolStripMenuItem _toolStripMenuItemPrintUnServisibleTag;
		private ToolStripMenuItem _toolStripMenuItemPrintInspectionTag;
		private ToolStripMenuItem _toolStripMenuItemPrintCalibrationTag;
		private ToolStripMenuItem _toolStripMenuItemPrintCondemnedTag;
		private ToolStripMenuItem _toolStripMenuItemPrintIdentificationTag;
		private ToolStripMenuItem _toolStripMenuItemPrintToolTag;
		private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripSeparator _toolStripSeparator3;
        private ToolStripSeparator _toolStripSeparator4;

		private ContextMenuStrip _buttonPrintMenuStrip;
		private ToolStripMenuItem _itemPrintReportStore;
		private ToolStripMenuItem _itemPrintReportInventoryFile;
		private ToolStripMenuItem _itemPrintReportAvailableComponents;
		private ToolStripMenuItem _itemPrintReportEquipmentToolRegister;


		private TransferedComponentForm _transferedComponentForm;
	    private WorkPackage _selectedWorkPackage;
        #endregion
        
        #region Constructors

        #region public StoreScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public StoreScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public StoreScreen(Store store):this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="store">Текущий склад</param>
        public StoreScreen(Store store):this()
        {
            if (store == null)
                throw new ArgumentNullException("store", "Cannot display null-currentStore");
            CurrentStore = store;

			InitToolStripPrintMenuItems();
			InitToolStripMenuItems();
            InitListView();

            if (_removedComponents.Count > 0 || _waitRemoveConfirmComponents.Count > 0
                || _installedComponents.Count > 0)
            {
                _buttonTransferDetails.Enabled = true;
                _transferedComponentForm = new TransferedComponentForm(_removedComponents.ToArray(),
                                                                 _removedTransfers.ToArray(),
                                                                 _waitRemoveConfirmComponents.ToArray(),
                                                                 _waitRemoveConfirmTransfers.ToArray(),
                                                                 _installedComponents.ToArray(),
                                                                 _installedTransfers.ToArray(),
                                                                 CurrentStore.SmartCoreObjectType);
               
                _transferedComponentForm.Closed += TransferedComponentFormClosed;
                _transferedComponentForm.ButtonAddClick += TransferedComponentFormButtonAddClick;
                _transferedComponentForm.ButtonDeleteClick += TransferedComponentFormButtonDeleteClick;
                _transferedComponentForm.ButtonCancelClick += TransferedComponentFormButtonCancelClick;

                _transferedComponentForm.Show(this);
            } 
        }

        #endregion

        #region public StoreScreen(Operator currentOperator) : this()

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов всех складов эксплуатанта
        /// </summary>
        /// <param name="currentOperator">Эксплуатант</param>
        public StoreScreen(Operator currentOperator) : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;
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

			_preResultDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
            _removedComponents.Clear();
            _waitRemoveConfirmComponents.Clear();
            _installedComponents.Clear();
            _removedTransfers.Clear();
            _waitRemoveConfirmTransfers.Clear();
            _installedTransfers.Clear();
            _openPubQuotations.Clear();

			_preResultDirectiveArray = null;
	        _resultDirectiveArray = null;
            _removedComponents = null;
            _waitRemoveConfirmComponents = null;
            _installedComponents = null;
            _removedTransfers = null;
            _waitRemoveConfirmTransfers = null;
            _installedTransfers = null;
            _openPubQuotations = null;

            if (_currentForecast != null)
            {
                _currentForecast.Dispose();
                _currentForecast = null;
            }

            if (_currentForecast != null) _currentForecast.Clear();
            _currentForecast = null;

            if (_toolStripMenuItemComposeInitialOrder != null) _toolStripMenuItemComposeInitialOrder.Dispose();
            if (_toolStripMenuItemComposeQuotationOrder != null) _toolStripMenuItemComposeQuotationOrder.Dispose();
            if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if (_toolStripMenuItemAdd != null) _toolStripMenuItemAdd.Dispose();
            if (_toolStripMenuItemMoveTo != null) _toolStripMenuItemMoveTo.Dispose();
            if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
            if (_toolStripMenuItemPrint != null) _toolStripMenuItemPrint.Dispose();
            if (_toolStripMenuItemShouldBeOnStock != null) _toolStripMenuItemShouldBeOnStock.Dispose();
            if (_toolStripMenuItemAdStatus != null) _toolStripMenuItemAdStatus.Dispose();
            if (_toolStripMenuItemEngineeringOrders != null) _toolStripMenuItemEngineeringOrders.Dispose();
            if (_toolStripMenuItemDiscrepancies != null) _toolStripMenuItemDiscrepancies.Dispose();
            if (_toolStripMenuItemSbStatus != null) _toolStripMenuItemSbStatus.Dispose();
            if (_toolStripMenuItemLlpDiskSheetStatus != null) _toolStripMenuItemLlpDiskSheetStatus.Dispose();
            if (_toolStripMenuItemLogBook != null) _toolStripMenuItemLogBook.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
            if (_toolStripSeparator3 != null) _toolStripSeparator3.Dispose();
            if (_toolStripSeparator4 != null) _toolStripSeparator4.Dispose();
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
            if (_toolStripMenuItemHighlight != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemHighlight.DropDownItems) item.Dispose();
                
                _toolStripMenuItemHighlight.Dispose();
            }

            if (_transferedComponentForm != null)
            {
                _transferedComponentForm.ButtonAddClick -= TransferedComponentFormButtonAddClick;
                _transferedComponentForm.ButtonCancelClick -= TransferedComponentFormButtonCancelClick;
                _transferedComponentForm.ButtonDeleteClick -= TransferedComponentFormButtonDeleteClick;
                _transferedComponentForm.Closed -= TransferedComponentFormClosed;

                _transferedComponentForm.Close();
                _transferedComponentForm.Dispose();
            }
            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
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

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

	        foreach (var workPackage in _openPubWorkPackages)
	        {
		        workPackage.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(workPackage.ParentId);
	        }

			comboBoxWorkPackage.Items.Clear();
			comboBoxWorkPackage.DisplayMember = "ComboBoxMember";
			comboBoxWorkPackage.Items.AddRange(_openPubWorkPackages.Where(i => i.Aircraft != null).OrderBy(i => i.Aircraft).ToArray());

	        if (_calculateWpItems)
	        {
				_directivesViewer.ItemListView.Columns[18].Width = 100;
				_directivesViewer.ItemListView.Columns[19].Width = 100;
		        buttonMoveTo.Enabled = true;
		        _itemPrintReportAvailableComponents.Enabled = true;
	        }
	        else
	        {
		        comboBoxWorkPackage.SelectedItem = null;
		        comboBoxWorkPackage.Text = "";
				_directivesViewer.ItemListView.Columns[18].Width = 0;
				_directivesViewer.ItemListView.Columns[19].Width = 0;
				buttonMoveTo.Enabled = false;
				_itemPrintReportAvailableComponents.Enabled = false;
			}
			
			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());

            if (_removedComponents.Count > 0
               || _waitRemoveConfirmComponents.Count > 0
               || _installedComponents.Count > 0)
                _buttonTransferDetails.Enabled = true;
            else _buttonTransferDetails.Enabled = false;

            //так делается для того, чот бы форма перемещенных деталей
            //отобразилась сама только при первом открытии экрана
            if (_firstLoad == false)
                TransferedDetailFormShow();
            _firstLoad = true;

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

            headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;

            if(_shouldBeOnStock.Count(s=>s.ShouldBeOnStock == 0) > 0)
                _statusImageLinkLabel1.Status = Statuses.NotActive;
            if (_shouldBeOnStock.Count(s => s.ShouldBeOnStock == s.Current) > 0)
                _statusImageLinkLabel1.Status = Statuses.Notify;
            if (_shouldBeOnStock.Count(s => s.ShouldBeOnStock > s.Current) > 0)
                _statusImageLinkLabel1.Status = Statuses.NotSatisfactory;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            AnimatedThreadWorker.ReportProgress(0, "load components");

	        _calculateWpItems = false;

			ComponentCollection resultCollection = new ComponentCollection();
			_preResultDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
            _removedComponents.Clear();
            _removedTransfers.Clear();
            _waitRemoveConfirmComponents.Clear();
            _waitRemoveConfirmTransfers.Clear();
            _installedComponents.Clear();
            _installedTransfers.Clear();
			_openPubWorkPackages.Clear();

			#region Загрузка элементов

			#region Заргрузка данных по общему запасу

			_shouldBeOnStock.Clear();
            _shouldBeOnStock.AddRange(
                
	        GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<StockComponentInfoDTO, StockComponentInfo>(new Filter("StoreID", CurrentStore.ItemId), true));

			#endregion

			#region Загрузка всех компонентов склада

			//извлечение и собрание всех компоннтов самолета
			//(деталей и базовых деталей) в одну коллекцию
			ComponentCollection componentCollection = new ComponentCollection();
            BaseComponentCollection baseComponentCollection;

            if (CurrentStore != null)
            {
                baseComponentCollection =
                    new BaseComponentCollection(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                componentCollection.AddRange(GlobalObjects.ComponentCore.GetStoreComponents(CurrentStore).ToArray());
            }
            else
            {
                baseComponentCollection = new BaseComponentCollection();
                foreach (var store in GlobalObjects.CasEnvironment.Stores)
                {
                    baseComponentCollection.AddRange(GlobalObjects.ComponentCore.GetStoreBaseComponents(store.ItemId));
                }
            }

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
                GlobalObjects.CasEnvironment.BaseComponents.GetLastInstalledComponentsOn(CurrentStore);
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
            var removedBaseComponentTransfers =
                GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom(CurrentStore,
                                                                               SmartCoreType.BaseComponent).ToArray();
            foreach (TransferRecord record in removedBaseComponentTransfers)
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

            //////////////////////////////////////////////////////
            //     проверка на установленные компоненты         //
            //////////////////////////////////////////////////////
            var lastInstalledDetails = componentCollection.GetLastInstalledComponentsOn(CurrentStore);
            foreach (var component in lastInstalledDetails)
            {
                _installedComponents.Add(component);
                _installedTransfers.Add(component.TransferRecords.GetLast());

                //удаление данного компонента из коллекции
                //т.к. его отображать не нужно
                componentCollection.Remove(component);
            }
            //////////////////////////////////////////////////////
            //     добавление компонентов базовых агрегатов     //
            //////////////////////////////////////////////////////
            //if(baseComponentCollection.Count > 0)
                //componentCollection.AddRange(GlobalObjects.ComponentCore.GetComponents(baseComponentCollection.ToList()).ToArray());
            //////////////////////////////////////////////////////
            //        проверка на удаленные компоненты          //
            //////////////////////////////////////////////////////

            //извлечение из базы данных всех записей о перемещении
            //компонентов с данного базового агрегата
            TransferRecord[] records =
                GlobalObjects.TransferRecordCore.GetLastTransferRecordsFrom(CurrentStore).ToArray();

            foreach (TransferRecord record in records)
            {
                //загрузка и БД детали, которой пренадлежит данная запись о перемещении
                Component component = GlobalObjects.ComponentCore.GetComponentById(record.ParentId);

                if (component == null)
                    continue;

                if (record.DODR)
                {
                    //если перемещение подтверждено, то деталь записывается в "перемещенные"
                    //окна "TransferedDetails"
                    if (_removedComponents.CompareAndAdd(component)) _removedTransfers.Add(record);
                }
                else
                {
                    //если перемещение не подтверждено, то деталь записывается в 
                    //"ожидабщие подтверждения" окна "TransferedDetails"
                    if (_waitRemoveConfirmComponents.CompareAndAdd(component)) _waitRemoveConfirmTransfers.Add(record);
                }
            }

            #endregion

            #region Калькуляция общего запаса компонентов

            AnimatedThreadWorker.ReportProgress(40, "calculation of stock");

            GlobalObjects.StockCalculator.CalculateStock(resultCollection.ToArray(), _shouldBeOnStock);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            if (_currentForecast == null)
            {
                resultCollection.AddRange(baseComponentCollection.ToArray());
                resultCollection.AddRange(componentCollection.ToArray());

                #region Калькуляция состояния компонентов

                AnimatedThreadWorker.ReportProgress(60, "calculation of components");

                foreach (Component detail in resultCollection)
                {
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(detail);
					_preResultDirectiveArray.Add(detail);

                    foreach (var componentDirective in detail.ComponentDirectives)
                    {
                        GlobalObjects.PerformanceCalculator.GetNextPerformance(componentDirective);
						_preResultDirectiveArray.Add(componentDirective);
                    }
                }

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion
            }
            else
            {
                AnimatedThreadWorker.ReportProgress(60, "calculation components");

                //извлечение и собрание всех компоннтов самолета
                //(деталей и базовых деталей) в одну коллекцию
                //List<MaintenanceType> types = new List<MaintenanceType>(_maintenanceTypes);

                if (CurrentStore != null)
                {
                    #region Калькуляция компонентов
                    //////////////////////////////////////////////////////
                    //   проверка на установленные базовые компоненты   //
                    //////////////////////////////////////////////////////
                    foreach (var baseComponent in lastInstalledBaseDetails)
                    {
                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        _currentForecast.ForecastDatas.Remove(_currentForecast.GetForecastDataByBaseComponentId(baseComponent.ItemId));
                    }

                    GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectives(_currentForecast);
                    resultCollection.AddRange(_currentForecast.BaseComponents.ToArray());

                    GlobalObjects.AnalystCore.GetComponentsAndComponentDirectives(_currentForecast);
                    ComponentCollection forecastComponentCollection = new ComponentCollection(_currentForecast.Components.ToArray());
                    //////////////////////////////////////////////////////
                    //     проверка на установленные компоненты         //
                    //////////////////////////////////////////////////////
                    lastInstalledDetails = forecastComponentCollection.GetLastInstalledComponentsOn(CurrentStore);
                    foreach (Component detail in lastInstalledDetails)
                    {
                        //удаление данного компонента из коллекции
                        //т.к. его отображать не нужно
                        forecastComponentCollection.Remove(detail);
                    }

                    foreach (var baseComponent in lastInstalledBaseDetails)
                    {
                        IEnumerable<Component> baseComponents =
                            forecastComponentCollection.Where(
                                component => component.TransferRecords.GetLast().DestinationObjectId == baseComponent.ItemId
                                          && component.TransferRecords.GetLast().DestinationObjectType == baseComponent.SmartCoreObjectType
                                          && component.TransferRecords.GetLast().DODR == false).ToArray();
                        foreach (var component in baseComponents) 
                            forecastComponentCollection.Remove(component);
                    }
                    resultCollection.AddRange(forecastComponentCollection.ToArray());

                    #endregion
                }

                #region Слияние компонентов в одну коллекцию

                AnimatedThreadWorker.ReportProgress(40, "calculation of components");

                foreach (var component in resultCollection)
                {
					_preResultDirectiveArray.Add(component);
                    foreach (ComponentDirective detailDirective in component.ComponentDirectives)
						_preResultDirectiveArray.Add(detailDirective);
                }

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion
            }

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            componentCollection.Clear();

			AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

			#region Калькуляция кол-ва компонентов

			AnimatedThreadWorker.ReportProgress(60, "calculation of stock");

            GlobalObjects.StockCalculator.CalculateStock(resultCollection.ToArray(), CurrentStore);

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
            _openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(CurrentStore, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "calculation over");
            #endregion

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
                                                                     CurrentStore.SmartCoreObjectType);
                    _transferedComponentForm.Show();
                    _transferedComponentForm.Closed += TransferedComponentFormClosed;
                    _transferedComponentForm.ButtonAddClick += TransferedComponentFormButtonAddClick;
                    _transferedComponentForm.ButtonDeleteClick += TransferedComponentFormButtonDeleteClick;
                    _transferedComponentForm.ButtonCancelClick += TransferedComponentFormButtonCancelClick;
                }
            }
        }
        #endregion

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemComposeInitialOrder = new ToolStripMenuItem();
            _toolStripMenuItemComposeQuotationOrder = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
            _toolStripMenuItemOpen = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripMenuItemAdd = new ToolStripMenuItem();
            _toolStripMenuItemDelete = new ToolStripMenuItem();
            _toolStripSeparator3 = new ToolStripSeparator();
            _toolStripSeparator4 = new ToolStripSeparator();
            _toolStripMenuItemMoveTo = new ToolStripMenuItem();
            _toolStripSeparator2 = new ToolStripSeparator();
            _toolStripMenuItemAdStatus = new ToolStripMenuItem();
            _toolStripMenuItemEngineeringOrders = new ToolStripMenuItem();
            _toolStripMenuItemDiscrepancies = new ToolStripMenuItem();
            _toolStripMenuItemSbStatus = new ToolStripMenuItem();
            _toolStripMenuItemLlpDiskSheetStatus = new ToolStripMenuItem();
            _toolStripMenuItemLogBook = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
			_toolStripMenuItemPrint = new ToolStripMenuItem();
			_toolStripMenuItemPrintServisibleTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintUnServisibleTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintInspectionTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintIdentificationTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintToolTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintCalibrationTag = new ToolStripMenuItem();
			_toolStripMenuItemPrintCondemnedTag = new ToolStripMenuItem();
			_toolStripMenuItemShouldBeOnStock = new ToolStripMenuItem();
			_toolStripMenuItemCopy = new ToolStripMenuItem();
			_toolStripMenuItemPaste = new ToolStripMenuItem();

			_toolStripMenuItemHighlight.DropDownItems.Clear();
            foreach (Highlight highlight in Highlight.HighlightList)
            {
                ToolStripMenuItem item = new ToolStripMenuItem { Text = highlight.FullName, Tag = highlight };
                item.Click += ToolStripMenuItemHighlightClick;
                _toolStripMenuItemHighlight.DropDownItems.Add(item);
            }
            //
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemComposeQuotationOrder.Text = "Compose quotation order";
            _toolStripMenuItemComposeQuotationOrder.Click += ToolStripMenuItemComposeQuotationClick;
            //
            // _toolStripMenuItemComposeInitialOrder
            //
            _toolStripMenuItemComposeInitialOrder.Text = "Compose Initial order";
            _toolStripMenuItemComposeInitialOrder.Click += ToolStripMenuItemComposeInitialClick;
            // 
            // toolStripMenuItemTitle
            // 
            _toolStripMenuItemOpen.Size = new Size(178, 22);
            _toolStripMenuItemOpen.Text = "Edit";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemEditClick;
            // 
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";
            _toolStripMenuItemHighlight.Click += ToolStripMenuItemHighlightClick;
			// 
			// _toolStripMenuItemPrintServisibleTag
			// 
			_toolStripMenuItemPrintServisibleTag.Text = "Servisible Tag";
			_toolStripMenuItemPrintServisibleTag.Click += _toolStripMenuItemPrintServisibleTag_Click;
			// 
			// _toolStripMenuItemPrintUnServisibleTag
			// 
			_toolStripMenuItemPrintUnServisibleTag.Text = "Unservisible Tag";
			_toolStripMenuItemPrintUnServisibleTag.Click += _toolStripMenuItemPrintUnServisibleTag_Click;
			// 
			// _toolStripMenuItemPrintInspectionTag
			// 
			_toolStripMenuItemPrintInspectionTag.Text = "Inspection Tag";
			_toolStripMenuItemPrintInspectionTag.Click += _toolStripMenuItemPrintInspectionTag_Click;
			// 
			// _toolStripMenuItemPrintInspectionTag
			// 
			_toolStripMenuItemPrintCalibrationTag.Text = "Calibration Tag";
			_toolStripMenuItemPrintCalibrationTag.Click += _toolStripMenuItemPrintCalibrationTag_Click;
			// 
			// _toolStripMenuItemPrintCondemnedTag
			// 
			_toolStripMenuItemPrintCondemnedTag.Text = "Condemned Tag";
			_toolStripMenuItemPrintCondemnedTag.Click += _toolStripMenuItemPrintCondemnedTag_Click;
			// 
			// _toolStripMenuItemPrintCondemnedTag
			// 
			_toolStripMenuItemPrintIdentificationTag.Text = "Identification Tag";
			_toolStripMenuItemPrintIdentificationTag.Click += _toolStripMenuItemPrintIdentificationTag_Click;
			// 
			// _toolStripMenuItemPrintToolTag
			// 
			_toolStripMenuItemPrintToolTag.Text = "TOOL/GSE Unservisible Tag";
			_toolStripMenuItemPrintToolTag.Click += _toolStripMenuItemPrintToolTag_Click;
			// 
			// _toolStripMenuItemPrint
			// 
			_toolStripMenuItemPrint.Text = "Print";
	        _toolStripMenuItemPrint.DropDownItems.AddRange(new ToolStripItem[]
	        {
				_toolStripMenuItemPrintServisibleTag, _toolStripMenuItemPrintUnServisibleTag,
				_toolStripMenuItemPrintInspectionTag, _toolStripMenuItemPrintCalibrationTag,
				_toolStripMenuItemPrintCondemnedTag,_toolStripMenuItemPrintIdentificationTag,
				_toolStripMenuItemPrintToolTag
			});
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemShouldBeOnStock.Text = "Should be on Stock";
			_toolStripMenuItemShouldBeOnStock.Click += _toolStripMenuItemShouldBeOnStock_Click;
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
			// toolStripSeparator1
			// 
			_toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemAdd
            // 
            _toolStripMenuItemAdd.Size = new Size(178, 22);
            _toolStripMenuItemAdd.Text = "Add Component";
            _toolStripMenuItemAdd.Click += ToolStripMenuItemAddClick;
            // 
            // toolStripMenuItemDelete
            // 
            _toolStripMenuItemDelete.Size = new Size(178, 22);
            _toolStripMenuItemDelete.Text = "Delete";
            _toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            // 
            // toolStripSeparator2
            // 
            _toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemInstallToAnAircraft
            // 
            _toolStripMenuItemMoveTo.Size = new Size(178, 22);
            _toolStripMenuItemMoveTo.Text = "Move To...";
            _toolStripMenuItemMoveTo.Click += ToolStripMenuItemInstallToAnAircraftClick;
            // 
            // toolStripSeparator3
            // 
            _toolStripSeparator3.Name = "toolStripSeparator3";
            _toolStripSeparator3.Size = new Size(175, 6);
            // 
            // toolStripMenuItemADStatus
            // 
            _toolStripMenuItemAdStatus.Size = new Size(178, 22);
            _toolStripMenuItemAdStatus.Text = "AD Status";
            _toolStripMenuItemAdStatus.Click += ToolStripMenuItemADStatusClick;
            // 
            // toolStripMenuItemEngineeringOrders
            // 
            _toolStripMenuItemEngineeringOrders.Size = new Size(178, 22);
            _toolStripMenuItemEngineeringOrders.Text = "Engineering Orders";
            _toolStripMenuItemEngineeringOrders.Click += ToolStripMenuItemEngineeringOrdersClick;
            // 
            // toolStripMenuItemDiscrepancies
            // 
            _toolStripMenuItemDiscrepancies.Size = new Size(178, 22);
            _toolStripMenuItemDiscrepancies.Text = "Discrepancies";
            _toolStripMenuItemDiscrepancies.Click += ToolStripMenuItemDiscrepanciesClick;
            // 
            // toolStripMenuItemLLPDiskSheetStatus
            // 
            _toolStripMenuItemLlpDiskSheetStatus.Size = new Size(178, 22);
            _toolStripMenuItemLlpDiskSheetStatus.Text = "LLP Disk Sheet Status";
            _toolStripMenuItemLlpDiskSheetStatus.Click += toolStripMenuItemLLPDiskSheetStatus_Click;
            // 
            // toolStripMenuItemSBStatus
            // 
            _toolStripMenuItemSbStatus.Size = new Size(178, 22);
            _toolStripMenuItemSbStatus.Text = "SB Status";
            _toolStripMenuItemSbStatus.Click += ToolStripMenuItemSBStatusClick;
            // 
            // toolStripMenuItemSBStatus
            // 
            _toolStripMenuItemLogBook.Size = new Size(178, 22);
            _toolStripMenuItemLogBook.Text = "Log Book";
            _toolStripMenuItemLogBook.Click += toolStripMenuItemLogBook_Click;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemQuotations.Text = "Add to Quotation Order";
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     _toolStripMenuItemOpen,
                                                     _toolStripSeparator1,
                                                     _toolStripMenuItemHighlight,
                                                     _toolStripSeparator2,
                                                     _toolStripMenuItemComposeInitialOrder,
                                                     _toolStripMenuItemComposeQuotationOrder,
                                                     _toolStripMenuItemQuotations,
                                                     _toolStripMenuItemMoveTo,
                                                     _toolStripMenuItemShouldBeOnStock,
                                                     new ToolStripSeparator(), 
													 _toolStripMenuItemPrint,
													 _toolStripSeparator4,
                                                     _toolStripMenuItemAdd,
                                                     _toolStripMenuItemDelete,
													 new ToolStripSeparator(),
													 _toolStripMenuItemCopy,
													 _toolStripMenuItemPaste
                                                 });
            _contextMenuStrip.Size = new Size(179, 176);
            _contextMenuStrip.Opening += ContextMenuStripOpen;

        }

		#endregion

		#region private void _toolStripMenuItemPrintServisibleTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintServisibleTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new ServisibleTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "SERVICIBLE TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
	    }

		#endregion

		#region private void _toolStripMenuItemPrintUnServisibleTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintUnServisibleTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new UnServisibleTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "UNSERVICIBLE TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
	    }

		#endregion

		#region private void _toolStripMenuItemPrintInspectionTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintInspectionTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new InspectionTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "INSPECTION TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
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

		#region private void _toolStripMenuItemPrintCondemnedTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintCondemnedTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new CondemnedTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "CONDENMED TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
	    }

		#endregion

		#region private void _toolStripMenuItemPrintIdentificationTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintIdentificationTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new IdentificationTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "IDENTIFICATION TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
	    }

		#endregion

		#region private void _toolStripMenuItemPrintToolTag_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintToolTag_Click(object sender, EventArgs e)
	    {
		    var component = _directivesViewer.SelectedItem as Component;

		    var refE = new ReferenceEventArgs();
		    var report = new ToolTagReportBuilder(CurrentOperator, component);
		    refE.DisplayerText = "TOOL/GSE UNSERVICIBLE TAG";
		    refE.RequestedEntity = new ReportScreen(report);
		    refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		    InvokeDisplayerRequested(refE);
	    }

	    #endregion

		#region  private void PasteItemsClick(object sender, EventArgs e)

		private void PasteItemsClick(object sender, EventArgs e)
		{
			GetFromClipboard();
		}

		#endregion

		#region private void CopyItemsClick(object sender, EventArgs e)

		private void CopyItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard();

		}

		#endregion

		#region private void _toolStripMenuItemShouldBeOnStock_Click(object sender, EventArgs e)

		private void _toolStripMenuItemShouldBeOnStock_Click(object sender, EventArgs e)
	    {
		    if (_directivesViewer.SelectedItem == null)
			    return;

		    var component = _directivesViewer.SelectedItem as Component;

		    if (_shouldBeOnStock.FirstOrDefault(i => i.GoodsClass == component.Model.GoodsClass &&
		                                             i.PartNumber.Replace(" ", "").ToLower() == component.PartNumber.Replace(" ", "").ToLower()) != null)
		    {
			    MessageBox.Show("Stock detail info with this part number: " + component.PartNumber +
			                    "\nand goods class: " + component.Model.GoodsClass +
			                    "\nis already exist.");
		    }
		    else
		    {
			    var newStockComponentInfo = new StockComponentInfo
			    {
				    AccessoryDescription = component.Model,
				    Description = component.Description,
				    PartNumber = component.PartNumber,
				    StoreId = CurrentStore.ItemId
			    };

			    var form = new StockComponentInfoForm(newStockComponentInfo, true);

			    if (form.ShowDialog() == DialogResult.OK)
				    AnimatedThreadWorker.RunWorkerAsync();
		    }
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
		        _toolStripMenuItemMoveTo.Enabled = true;
		        _toolStripMenuItemOpen.Enabled = true;
		        _toolStripMenuItemHighlight.Enabled = true;
		        _toolStripMenuItemShouldBeOnStock.Enabled = true;
		        if (_directivesViewer.SelectedItem is Component)
		        {
			        var component = _directivesViewer.SelectedItem as Component;
			        var isTool =
				        component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.GroundEquipment) ||
				        component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools);

			        _toolStripMenuItemPrintCondemnedTag.Enabled = true;
			        _toolStripMenuItemPrintIdentificationTag.Enabled = true;
			        _toolStripMenuItemPrintServisibleTag.Enabled = component.State == ComponentStorePosition.Serviceable;
			        _toolStripMenuItemPrintUnServisibleTag.Enabled = component.State == ComponentStorePosition.Unserviceable;
			        _toolStripMenuItemPrintToolTag.Enabled = component.State == ComponentStorePosition.Unserviceable && isTool;
			        _toolStripMenuItemPrintInspectionTag.Enabled =
				        component.ComponentDirectives.Any(c => c.DirectiveType == ComponentRecordType.Inspection);
			        _toolStripMenuItemPrintCalibrationTag.Enabled =
				        component.ComponentDirectives.Any(c => c.DirectiveType == ComponentRecordType.Calibration);
		        }
		        else
		        {
					_toolStripMenuItemPrintServisibleTag.Enabled = false;
					_toolStripMenuItemPrintUnServisibleTag.Enabled = false;
					_toolStripMenuItemPrintInspectionTag.Enabled = false;
					_toolStripMenuItemPrintCondemnedTag.Enabled = false;
					_toolStripMenuItemPrintCalibrationTag.Enabled = false;
					_toolStripMenuItemPrintIdentificationTag.Enabled = false;
					_toolStripMenuItemPrintToolTag.Enabled = false;
				}
			}
	        else
	        {
				_toolStripMenuItemPrintServisibleTag.Enabled = false;
				_toolStripMenuItemPrintUnServisibleTag.Enabled = false;
				_toolStripMenuItemPrintInspectionTag.Enabled = false;
				_toolStripMenuItemPrintCondemnedTag.Enabled = false;
				_toolStripMenuItemPrintCalibrationTag.Enabled = false;
		        _toolStripMenuItemPrintIdentificationTag.Enabled = false;
				_toolStripMenuItemPrintToolTag.Enabled = false;
				_toolStripMenuItemShouldBeOnStock.Enabled = false;
			}
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            if (CurrentStore != null)
            {
                _directivesViewer = new StoreComponentsListView
                                    {
                                        ContextMenuStrip = _contextMenuStrip,
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill,
                                        //ItemsListView = {ContextMenuStrip = _contextMenuStrip}
                                    };
            }
            else
            {
                _directivesViewer = new StoreComponentsListView
                                        {
                    TabIndex = 2,
                    Location = new Point(panel1.Left, panel1.Top),
                    Dock = DockStyle.Fill,
                    //ItemsListView = { ContextMenuStrip = _contextMenuStrip }
                };    
            }

            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
            buttonDeleteSelected.Enabled = _buttonMoveToAircraft.Enabled = _directivesViewer.SelectedItems.Count > 0; 
        }

        #endregion

        #region private void DeleteCommand()
        private void DeleteCommand()
        {
            if (_directivesViewer.SelectedItems == null)
                return;

            CommonCollection<IDirective> directives = new CommonCollection<IDirective>();
            foreach (BaseCoreObject o in _directivesViewer.SelectedItems)
            {
                IDirective dir;
                if (o is NextPerformance)
                    dir = ((NextPerformance)o).Parent;
                else dir = o as IDirective;

                if (dir != null && !directives.Contains(dir))
                    directives.Add(dir);
            }

            if(directives.Count <= 0)
                return;

            DialogResult confirmResult =
                MessageBox.Show(
                    directives.Count == 1
                        ? "Do you really want to delete " +
                            (directives[0] is Component
                            ? "component " + ((Component)directives[0]).SerialNumber
                            : "component directive " + ((ComponentDirective)directives[0]).DirectiveType) +
                          "?"
                        : "Do you really want to delete selected elements? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _directivesViewer.ItemListView.BeginUpdate();
                    foreach (IDirective t in directives)
                    {
                        if (t is BaseComponent)
                            GlobalObjects.ComponentCore.DeleteBaseComponent((BaseComponent)t);
                        else if (t is Component)
                            GlobalObjects.ComponentCore.DeleteComponent((Component)t);
                        else if (t is ComponentDirective)
                            GlobalObjects.ComponentCore.DeleteComponentDirective((ComponentDirective)t);
                    }
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
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteCommand();
        }
        #endregion

        #region private void ButtonApplyFilterClick(object sender, EventArgs e)

        private void ButtonApplyFilterClick(object sender, EventArgs e)
        {
			var form = new CommonFilterForm(_additionalfilter, _preResultDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoCalculate;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
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


		#region private void ButtonAddConsumablePartAndKit(object sender, EventArgs e)

		private void ButtonAddConsumablePartAndKit(object sender, EventArgs e)
        {
            if (CurrentStore != null)
            {
				ConsumablePartAndKitForm form = new ConsumablePartAndKitForm(CurrentStore);
				if (form.ShowDialog() == DialogResult.OK) AnimatedThreadWorker.RunWorkerAsync();
			}
            else
                MessageBox.Show("Функционал пока не реализован" + Environment.NewLine + "Работает в отдельном складе");         
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

        #region private void HeaderControlButtonEditClick(object sender, EventArgs e)
        private void HeaderControlButtonEditClick(object sender, EventArgs e)
        {
            CommonEditorForm dlg = new CommonEditorForm(CurrentStore);
            if (dlg.ShowDialog() != DialogResult.OK) return;
        }
		#endregion

		#region private void HeaderControl_SaveButtonClick(object sender, System.EventArgs e)

		private void HeaderControl_SaveButtonClick(object sender, EventArgs e)
	    {
		    var unsaved = _directivesViewer.GetItemsArray().Cast<BaseEntityObject>().Where(c => c.ItemId < 0).ToList();

		    try
		    {
			    foreach (var unsavedItem in unsaved)
			    {
				    if (unsavedItem is Component)
				    {
					    var component = unsavedItem as Component;
					    if (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
					        component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools))
					    {
						    GlobalObjects.ComponentCore.Save(component);
						    foreach (var transferRecord in component.TransferRecords)
						    {
							    transferRecord.ParentId = component.ItemId;
							    GlobalObjects.CasEnvironment.NewKeeper.Save(transferRecord);
						    }
					    }
					    else
					    {
						    GlobalObjects.CasEnvironment.Keeper.SaveAll(unsavedItem, true);
					    }	
				    }
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

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if(CurrentStore == null) return;
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

	        if (sender == _itemPrintReportStore)
	        {
				var reportBuilder = new StoreBuilder();
				if (GlobalObjects.CasEnvironment.Stores.Count == 1)
					reportBuilder.AddAdditionalInformation(CurrentStore.Operator.LogoTypeWhite, CurrentStore.ItemId.ToString(), CurrentStore.Name);
				else
					reportBuilder.AddAdditionalInformation(CurrentStore.Operator.LogoTypeWhite, CurrentStore.Operator.Name + " Stock General Report", CurrentStore.Name);
				e.DisplayerText = "Store " + CurrentStore.ItemId + ". Report";
				reportBuilder.AddDetails(_directivesViewer.GetItemsArray());

				e.RequestedEntity = new ReportScreen(reportBuilder);
			}
			else if (sender == _itemPrintReportInventoryFile)
	        {
		        var r = new StoreInventoryFileReportBuilder(CurrentOperator, _resultDirectiveArray.OfType<Component>());
		        r.ReportTitle = "INVENTORY FILE";
				r.FormName = $"F SK 035A R0 {DateTime.Today:dd MM yyyy}";
				r.FilterSelection = _additionalfilter;
				e.DisplayerText = $"Inventory file";
				e.RequestedEntity = new ReportScreen(r);
	        }
			else if (sender == _itemPrintReportEquipmentToolRegister)
	        {
				var r = new StoreInventoryFileReportBuilder(CurrentOperator, _resultDirectiveArray.OfType<Component>());
				r.ReportTitle = "EQUIPMENT/TOOl REGISTER";
		        r.FormName = "F SK 035 R0 30 Aug 2016";
				r.FilterSelection = _additionalfilter;
				e.DisplayerText = $"Equipment/tool register";
				e.RequestedEntity = new ReportScreen(r);
			}
			else if (sender == _itemPrintReportAvailableComponents)
	        {
				var r = new AvailableComponentsBuilder(CurrentOperator, _resultDirectiveArray.OfType<Component>(), _selectedWorkPackage);
				r.FilterSelection = _additionalfilter;
				e.DisplayerText = $"Available Components";
				e.RequestedEntity = new ReportScreen(r);
			}
		}
		#endregion

		#region private void InitToolStripPrintMenuItems()

		private void InitToolStripPrintMenuItems()
	    {
		    _buttonPrintMenuStrip = new ContextMenuStrip();
		    _itemPrintReportStore = new ToolStripMenuItem { Text = "Stock General Report" };
		    _itemPrintReportInventoryFile = new ToolStripMenuItem { Text = "Inventory File" };
			_itemPrintReportAvailableComponents = new ToolStripMenuItem { Text = "Available Components" };
			_itemPrintReportEquipmentToolRegister = new ToolStripMenuItem { Text = "Equipment Tool Register" };

		    _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[]
		    {
			    _itemPrintReportStore, _itemPrintReportInventoryFile,_itemPrintReportEquipmentToolRegister, _itemPrintReportAvailableComponents
			});

		    ButtonPrintMenuStrip = _buttonPrintMenuStrip;

	    }

	    #endregion

		#region private void TransferedDetailFormClosed(object sender, EventArgs e)
		private void TransferedComponentFormClosed(object sender, EventArgs e)
        {
            _transferedComponentForm = null;
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

        #region private void ForecastMenuClick(object sender, EventArgs e)
        private void ForecastMenuClick(object sender, EventArgs e)
        {
            List<BaseComponent> storeBaseComponents;
            if (_currentForecast != null) _currentForecast.ForecastDatas.Clear();
			//TODO:(Evgenii Babak) много BL
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
                        if (CurrentStore != null)
                        {
                            _currentForecast = new Forecast( CurrentStore, DateTime.Today );
                            //поиск деталей данного самолета 
                            storeBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                            //составление нового массива данных по прогноза
                            foreach (var baseComponent in storeBaseComponents)
                            {
                                //определение ресурсов прогноза для каждой базовой детали
                                ForecastData forecastData =
                                    new ForecastData(DateTime.Today,
                                                     baseComponent,
                                                     GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
                                //дабавление в массив
                                _currentForecast.ForecastDatas.Add(forecastData);
                            }
                            ForecastData main = _currentForecast.ForecastDataForNonLifelenght;

                            labelDateAsOf.Visible = true;
                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "This week":
                    {
                        if (CurrentStore != null)
                        {
                            _currentForecast = new Forecast( CurrentStore, DateTime.Today.AddDays(7) );
                            //поиск деталей данного самолета 
                            storeBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                            //составление нового массива данных по прогноза
                            foreach (var baseComponent in storeBaseComponents)
                            {
                                //определение ресурсов прогноза для каждой базовой детали
                                ForecastData forecastData =
                                    new ForecastData(DateTime.Today.AddDays(7),
                                                     baseComponent,
                                                     GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
                                //дабавление в массив
                                _currentForecast.ForecastDatas.Add(forecastData);
                            }
                            ForecastData main = _currentForecast.ForecastDataForNonLifelenght;

                            labelDateAsOf.Visible = true;
                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Two weeks":
                    {
                        if (CurrentStore != null)
                        {
                            _currentForecast = new Forecast( CurrentStore, DateTime.Today.AddDays(14));
                            //поиск деталей данного самолета 
                            storeBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                            //составление нового массива данных по прогноза
                            foreach (var baseComponent in storeBaseComponents)
                            {
                                //определение ресурсов прогноза для каждой базовой детали
                                var forecastData =
                                    new ForecastData(DateTime.Today.AddDays(14),
                                                     baseComponent,
                                                     GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent));
                                //дабавление в массив
                                _currentForecast.ForecastDatas.Add(forecastData);
                            }
                            ForecastData main = _currentForecast.ForecastDataForNonLifelenght;

                            labelDateAsOf.Visible = true;
                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Month":
                    {
                        if (CurrentStore != null)
                        {
                            _currentForecast = new Forecast(CurrentStore, DateTime.Today.AddMonths(1) );
                            //поиск деталей данного самолета 
                            storeBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                            //составление нового массива данных по прогноза
                            foreach (var baseDetail in storeBaseComponents)
                            {
                                //определение ресурсов прогноза для каждой базовой детали
                                var forecastData =
                                    new ForecastData(DateTime.Today.AddMonths(1),
                                                     baseDetail,
                                                     GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
                                //дабавление в массив
                                _currentForecast.ForecastDatas.Add(forecastData);
                            }
                            ForecastData main = _currentForecast.ForecastDataForNonLifelenght;

                            labelDateAsOf.Visible = true;
                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Custom":
                    {
                        if (CurrentStore != null)
                        {
                            _currentForecast = new Forecast(CurrentStore, DateTime.Today );
							//поиск деталей данного самолета 
							storeBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetStoreBaseComponents(CurrentStore.ItemId));
                            //составление нового массива данных по прогноза
                            foreach (var baseComponent in storeBaseComponents)
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
                        else return;

                        ForecastData main = _currentForecast.ForecastDataForNonLifelenght;
                        ForecastCustomsWriteData form = new ForecastCustomsWriteData(_currentForecast);
                        ForecastCustomsAdvancedForm advancedForm = new ForecastCustomsAdvancedForm(_currentForecast);

                        form.ShowDialog();

                        if (form.DialogResult != DialogResult.OK && form.CallAdvanced)
                            advancedForm.ShowDialog();

                        if (form.DialogResult == DialogResult.OK || advancedForm.DialogResult == DialogResult.OK)
                        {
                            if (main.SelectedForecastType == ForecastType.ForecastByDate)
                            {
                                labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
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
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void OnViewEditScreen()

        private void OnViewEditScreen()
        {
            var components = new CommonCollection<Component>();
            foreach (var o in _directivesViewer.SelectedItems)
            {
                IDirective dir;
                if (o is NextPerformance)
                    dir = ((NextPerformance)o).Parent;
                else dir = o as IDirective;

                if (dir == null)continue;
                if (dir is ComponentDirective && !components.Contains(((ComponentDirective)dir).ParentComponent))
                    components.Add(((ComponentDirective)dir).ParentComponent);
                else if (dir is Component && !components.Contains((Component)dir))
                    components.Add((Component)dir);
            }

            if (components.Count <= 0)
                return;
            foreach (var component in components)
            {
                var requestedEntity = new ComponentScreenNew(component);
                string displayerText;
                if (CurrentStore != null)
                    displayerText = CurrentStore.Name + ". Component SN " + component.SerialNumber;
                else displayerText = "Component SN " + component.SerialNumber;
                InvokeDisplayerRequested(new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, displayerText));
            }
        }

        #endregion

        #region private void ButtonAddDetailDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDetailDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentStore != null)
            {
                e.RequestedEntity = new ComponentAddingScreen(CurrentStore);
                e.DisplayerText = CurrentStore.Name + ". New Component";
            }
            else
            {
                if (GlobalObjects.CasEnvironment.Stores.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
                e.RequestedEntity = new ComponentAddingScreen(GlobalObjects.CasEnvironment.Stores[0]);
                e.DisplayerText = GlobalObjects.CasEnvironment.Stores[0].ItemId + ". New Component";
            }
        }

        #endregion

        #region private void MoveToCommand()

        private void MoveToCommand()
        {
            if (_directivesViewer.SelectedItems.Count == 0)
                return;

            if (GlobalObjects.AircraftsCore.GetAircraftsCount() == 0 &&
                GlobalObjects.CasEnvironment.Stores.Count == 0)
            {
                MessageBox.Show("You dont remove this component because you dont have a aircrafts", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var components = new CommonCollection<Component>();
			foreach (var o in _directivesViewer.SelectedItems)
			{
				IDirective dir;
				if (o is NextPerformance)
					dir = ((NextPerformance)o).Parent;
				else dir = o as IDirective;

				if (dir == null) continue;
				if (dir is ComponentDirective && !components.Contains(((ComponentDirective)dir).ParentComponent))
					components.Add(((ComponentDirective)dir).ParentComponent);
				else if (dir is Component && !components.Contains((Component)dir))
					components.Add((Component)dir);
			}

            if (components.Count <= 0)
                return;

            var dlg = new MoveComponentForm(components.ToArray(), CurrentStore);
            dlg.Text = "Move " +
                (components.Count > 1
                ? "components"
                : "component " + components[0].Description)
                + " to aircraft";

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

        #region private void ButtonMoveToAircraftClick(object sender, EventArgs e)

        private void ButtonMoveToAircraftClick(object sender, EventArgs e)
        {
            MoveToCommand();   
        }

        #endregion

        #region private void ButtonTransferedDetailsClick(object sender, EventArgs e)

        private void ButtonTransferedDetailsClick(object sender, EventArgs e)
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
                                                                     CurrentStore.SmartCoreObjectType);
                    _transferedComponentForm.Show();
                    _transferedComponentForm.Closed += TransferedComponentFormClosed;
                    _transferedComponentForm.ButtonAddClick += TransferedComponentFormButtonAddClick;
                    _transferedComponentForm.ButtonDeleteClick += TransferedComponentFormButtonDeleteClick;
                    _transferedComponentForm.ButtonCancelClick += TransferedComponentFormButtonCancelClick;
                }
            }
        }

        #endregion

        #region private void LinkShoulBeOnStockDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkShoulBeOnStockDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentStore != null)
            {
                e.DisplayerText = CurrentStore.Name + ". Should be on stock";
                e.RequestedEntity = new ShouldBeOnStockListScreen(CurrentStore);
            }
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;    
        }

        #endregion

        #region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

        private void ToolStripMenuItemEditClick(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region private void ToolStripMenuItemHighlightClick(object sender, EventArgs e)

        private void ToolStripMenuItemHighlightClick(object sender, EventArgs e)
        {
            foreach (IBaseCoreObject t in _directivesViewer.SelectedItems)
            {
                if (t is BaseComponent)
                {
                    ((BaseComponent)t).Highlight = (Highlight)((ToolStripMenuItem)sender).Tag;
                    GlobalObjects.ComponentCore.Save((BaseComponent) t);
                }
                else if (t is Component)
                {
                    ((Component)t).Highlight = (Highlight)((ToolStripMenuItem)sender).Tag;
                    GlobalObjects.ComponentCore.Save((Component)t);
                }
            }
        }

        #endregion

        #region private void ToolStripMenuItemAddClick(object sender, EventArgs e)

        private void ToolStripMenuItemAddClick(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            
            ButtonAddDetailDisplayerRequested(this, arguments);
            
            InvokeDisplayerRequested(arguments);
        }

        #endregion

        #region private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)

        private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        #endregion

        #region private void ToolStripMenuItemInstallToAnAircraftClick(object sender, EventArgs e)

        private void ToolStripMenuItemInstallToAnAircraftClick(object sender, EventArgs e)
        {
            MoveToCommand();
        }

        #endregion

        #region private void ToolStripMenuItemADStatusClick(object sender, EventArgs e)

        private void ToolStripMenuItemADStatusClick(object sender, EventArgs e)
        {
            if (!(_directivesViewer.SelectedItem is BaseComponent))
                return;
            BaseComponent baseComponent = (BaseComponent)_directivesViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs
            {
                RequestedEntity = new PrimeDirectiveListScreen(baseComponent, DirectiveType.AirworthenessDirectives),
                TypeOfReflection = ReflectionTypes.DisplayInNew,
                DisplayerText = baseComponent + ". " + DirectiveType.AirworthenessDirectives.CommonName
            };
            InvokeDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemEngineeringOrders_Click(object sender, EventArgs e)

        private void ToolStripMenuItemEngineeringOrdersClick(object sender, EventArgs e)
        {
            if (!(_directivesViewer.SelectedItem is BaseComponent))
                return;
            BaseComponent baseComponent = (BaseComponent)_directivesViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs
                                          {
                                              RequestedEntity = new PrimeDirectiveListScreen(baseComponent, DirectiveType.EngineeringOrders),
                                              TypeOfReflection = ReflectionTypes.DisplayInNew,
                                              DisplayerText = baseComponent + ". " + DirectiveType.EngineeringOrders.CommonName
                                          };
            InvokeDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemDiscrepancies_Click(object sender, EventArgs e)

        private void ToolStripMenuItemDiscrepanciesClick(object sender, EventArgs e)
        {
            if (!(_directivesViewer.SelectedItem is BaseComponent))
                return;
            BaseComponent baseComponent = (BaseComponent)_directivesViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.RequestedEntity = new ForecastListScreen(baseComponent, DirectiveType.All);
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            args.DisplayerText = baseComponent + ". Forecast";
            InvokeDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemLLPDiskSheetStatus_Click(object sender, EventArgs e)

        private void toolStripMenuItemLLPDiskSheetStatus_Click(object sender, EventArgs e)
        {
            //if (!(_directivesViewer.SelectedItem is BaseDetail))
            //    return;
            //BaseDetail baseDetail = (BaseDetail)_directivesViewer.SelectedItem;
            //ReferenceEventArgs args = new ReferenceEventArgs();
            //args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". LLP Disk Sheet Status";
            ////DetailCollectionFilter filter = new DetailCollectionFilter(new DetailFilter[] { new EngineLLPFilter(baseDetail) });
            //LLPStatusReportBuilder reportBuilder = new LLPStatusReportBuilder(baseDetail);

            //DispatcheredComponentStatusScreen dispatcheredComponentStatusScreen = new DispatcheredComponentStatusScreen(baseDetail, reportBuilder, MaintenanceType.Items.ToArray());
            //dispatcheredComponentStatusScreen.StatusText = baseDetail + ". LLP Disk Sheet Status";
            ////dispatcheredComponentStatusScreen.Status = (Statuses)baseDetail.ConditionState;
            //args.RequestedEntity = dispatcheredComponentStatusScreen;
            //OnDisplayerRequested(args);
        }

        #endregion

        #region private void ToolStripMenuItemSBStatusClick(object sender, EventArgs e)

        private void ToolStripMenuItemSBStatusClick(object sender, EventArgs e)
        {
            if (!(_directivesViewer.SelectedItem is BaseComponent))
                return;
            BaseComponent baseComponent = (BaseComponent)_directivesViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs
            {
                RequestedEntity = new PrimeDirectiveListScreen(baseComponent, DirectiveType.SB),
                TypeOfReflection = ReflectionTypes.DisplayInNew,
                DisplayerText = baseComponent + ". " + DirectiveType.SB.CommonName
            };
            InvokeDisplayerRequested(args);
        }

        #endregion

        #region private void toolStripMenuItemLogBook_Click(object sender, EventArgs e)

        private void toolStripMenuItemLogBook_Click(object sender, EventArgs e)
        {
/*
            if (!(storeDetailsViewer.SelectedItem is BaseDetail))
                return;
            BaseDetail baseDetail = (BaseDetail)storeDetailsViewer.SelectedItem;
            ReferenceEventArgs args = new ReferenceEventArgs();
            if (baseDetail is AircraftFrame)
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". Log Book";    
            else
                args.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". Log Book";
            args.RequestedEntity = new DispatcheredBaseDetailLogBookScreen(baseDetail);
            OnDisplayerRequested(args);
*/
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

        #region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

        private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((ToolStripMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

        #endregion

        #region private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        /// <summary>
        /// Создает Первоначальный ордер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemComposeInitialClick(object sender, EventArgs e)
        {
            PurchaseManager.ComposeInitialOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
        }

		#endregion

		#region protected override void OnSizeChanged(EventArgs e)

		/////<summary>
		/////Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		/////</summary>
		/////
		/////<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		//protected override void OnSizeChanged(EventArgs e)
		//{
		//    base.OnSizeChanged(e);

		//    if (buttonDeleteSelected == null) return;
		//    buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
		//   _buttonAddDetail.Location = new Point(buttonDeleteSelected.Left - _buttonAddDetail.Width - 5, 0);
		//   _buttonAddConsumablePartAndKit.Location = new Point(_buttonAddDetail.Left - _buttonAddConsumablePartAndKit.Width - 5, 0);
		//   _buttonTransferDetails.Location = new Point(_buttonAddConsumablePartAndKit.Left - _buttonTransferDetails.Width - 5, 0);
		//   _buttonMoveToAircraft.Location = new Point(_buttonTransferDetails.Left - _buttonAddDetail.Width - 5, 0);
		//   _buttonApplyFilter.Location = new Point(_buttonAddConsumablePartAndKit.Left - _buttonApplyFilter.Width - 5, 0);

		//    if (_directivesViewer != null)
		//    {
		//        _directivesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
		//        _directivesViewer.Size =
		//            new Size(Width,
		//                     Height - headerControl.Height - headerControl.Height - panelTopContainer.Height);
		//    }
		//}

		#endregion

		#region private void _statusImageLinkLabel2_DisplayerRequested(object sender, ReferenceEventArgs e)

		private void _statusImageLinkLabel2_DisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    if (CurrentStore != null)
		    {
			    e.DisplayerText = CurrentStore.Name + ". Should be on stock";
			    e.RequestedEntity = new CommonListScreen(typeof(Locations));
		    }
		    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
	    }

		#endregion

		#region private void _statusImageLinkLabel3_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void _statusImageLinkLabel3_DisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    if (CurrentStore != null)
		    {
			    e.DisplayerText = CurrentStore.Name + ". Tracking";
			    e.RequestedEntity = new ComponentTrackingListScreen(CurrentStore);
		    }
		    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
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
				foreach (var selecteditem in _directivesViewer.SelectedItems)
				{
					if (!(selecteditem is Component))
						continue;

					if ((selecteditem as Component).IsBaseComponent)
					{
						_showMsg = true;
						continue;
					}

					pds.Add(((Component)selecteditem).GetCopyUnsaved());
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
				foreach (var component in pds)
				{
					component.ParentStoreId = CurrentStore.ItemId;

					GlobalObjects.PerformanceCalculator.GetNextPerformance(component);
					_preResultDirectiveArray.Add(component);
					_resultDirectiveArray.Add(component);

					component.PartNumber += " Copy";
					objectsToPaste.Add(component);

					foreach (ComponentDirective componentDirective in component.ComponentDirectives)
					{
						_resultDirectiveArray.Add(componentDirective);
						objectsToPaste.Add(componentDirective);
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

		#region private void ButtonCalculateClick(object sender, EventArgs e)

		private void ButtonCalculateClick(object sender, EventArgs e)
		{
			if (comboBoxWorkPackage.SelectedItem == null)
				return;

			_selectedWorkPackage = comboBoxWorkPackage.SelectedItem as WorkPackage;
			_calculateWpItems = true;

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoCalculate;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void AnimatedThreadWorkerDoCalculate(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoCalculate(object sender, DoWorkEventArgs e)
		{
			var components = _resultDirectiveArray.OfType<Component>().Where(c => c.Product != null).ToList();

			_resultDirectiveArray.Clear();
			_preResultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Work Package kits");

			var equipmentAndMaterial = GlobalObjects.KitsCore.GetAllWorkPackageKits(_selectedWorkPackage.ItemId);

			AnimatedThreadWorker.ReportProgress(10, "load Component Models");

			var componentModels = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AccessoryDescriptionDTO, ComponentModel>(new Filter("ModelingObjectTypeId", 5));

			AnimatedThreadWorker.ReportProgress(20, "Calculate Work Package kits");

			var products = equipmentAndMaterial.Where(p => p.Product != null).GroupBy(g => g.Product);

			foreach (var product in products)
			{
				double quantity = 0;

				if (product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools) 
					|| product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
					quantity = product.Max(p => p.Quantity);
				else if (product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
				{
					foreach (AbstractAccessory accessoryRequired in product)
						quantity += accessoryRequired.Quantity < 1 ? 1 : (int)accessoryRequired.Quantity;
				}
				else
				{
					foreach (AbstractAccessory accessoryRequired in product)
						quantity += accessoryRequired.Quantity;
				}

				var component = components.FirstOrDefault(c => c.Product.PartNumber == product.Key.PartNumber && c.Product.Name == product.Key.Name && c.State == ComponentStorePosition.Serviceable);
				if (component != null)
					component.NeedWpQuantity = quantity;
				else
				{
					component = new Component
					{
						ATAChapter = product.Key.ATAChapter,
						PartNumber = product.Key.PartNumber,
						Description = product.Key.Description,
						GoodsClass = product.Key.GoodsClass,
						SerialNumber = product.Key.SerialNumber,
						BatchNumber = product.Key.BatchNumber,
						NeedWpQuantity = quantity,
						Code = product.Key.Code,
						Product = product.Key,
						ParentStoreId = CurrentStore.ItemId,
						Model = componentModels.FirstOrDefault(c => c.PartNumber == product.Key.PartNumber && c.FullName == product.Key.Name)
					};

					component.TransferRecords.Add(new TransferRecord
					{
						DestinationObject = SmartCoreType.Store,
						DestinationObjectId = SmartCoreType.Store.ItemId,
						FromStore = CurrentStore,
						FromStoreId = CurrentStore.ItemId,
						State = ComponentStorePosition.Serviceable,
						TransferDate = DateTime.Today
					});
				}


				_preResultDirectiveArray.Add(component);
			}


			AnimatedThreadWorker.ReportProgress(60, "Load Work Package Items");
			var workPackageRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<WorkPackageRecordDTO, WorkPackageRecord>(new Filter("WorkPakageId", _selectedWorkPackage.ItemId));
			var detWprs = workPackageRecords.Where(w => w.WorkPackageItemType == SmartCoreType.Component.ItemId).ToList();
			var wpComponents = new List<Component>();

			if (detWprs.Count > 0)
			{
				var componentIds = detWprs.Select(d => d.DirectiveId).ToArray();
				wpComponents.AddRange(GlobalObjects.ComponentCore.GetComponentByIds(componentIds));
			}

			var detDirWprs = workPackageRecords.Where(w => w.WorkPackageItemType == SmartCoreType.ComponentDirective.ItemId).ToList();
			if (detDirWprs.Count > 0)
			{
				var componentDirectivesIds = detDirWprs.Select(wpr => wpr.DirectiveId).ToArray();
				var componentDirectives = GlobalObjects.ComponentCore.GetComponentDirectives(componentDirectivesIds, true).Where(d => 
				d.DirectiveType == ComponentRecordType.BenchCheck || d.DirectiveType == ComponentRecordType.Discard ||
				d.DirectiveType == ComponentRecordType.Inspection || d.DirectiveType == ComponentRecordType.Overhaul ||
				d.DirectiveType == ComponentRecordType.Remove || d.DirectiveType == ComponentRecordType.Repair ||
				d.DirectiveType == ComponentRecordType.Replace || d.DirectiveType == ComponentRecordType.Restore ||
				d.DirectiveType == ComponentRecordType.Scrap || d.DirectiveType == ComponentRecordType.ShopVisit ||
				d.DirectiveType == ComponentRecordType.WorkshopCheck);

				wpComponents.AddRange(componentDirectives.Select(d => d.ParentComponent));

			}

			var res = wpComponents.GroupBy(c => c.Description);
			foreach (var product in res)
			{
				var groupedComponent = product.FirstOrDefault();

				double quantity = 0;

				if (groupedComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools)
					|| groupedComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
					quantity = product.Max(p => p.Quantity);
				else if (groupedComponent.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
				{
					foreach (AbstractAccessory accessoryRequired in product)
						quantity += accessoryRequired.Quantity < 1 ? 1 : (int)accessoryRequired.Quantity;
				}
				else
				{
					foreach (AbstractAccessory accessoryRequired in product)
						quantity += accessoryRequired.Quantity;
				}

				var component = components.FirstOrDefault(c => c.PartNumber == groupedComponent.PartNumber && c.State == ComponentStorePosition.Serviceable);
				if (component != null)
					component.NeedWpQuantity = quantity;
				else
				{
					component = new Component
					{
						ATAChapter = groupedComponent.ATAChapter,
						PartNumber = groupedComponent.PartNumber,
						Description = groupedComponent.Description,
						GoodsClass = groupedComponent.GoodsClass,
						SerialNumber = groupedComponent.SerialNumber,
						BatchNumber = groupedComponent.BatchNumber,
						NeedWpQuantity = quantity,
						Code = groupedComponent.Code,
						ParentStoreId = CurrentStore.ItemId,
						Model = componentModels.FirstOrDefault(c => c.PartNumber == groupedComponent.Model?.PartNumber && c.FullName == groupedComponent.Model?.Name)
					};

					component.TransferRecords.Add(new TransferRecord
					{
						DestinationObject = SmartCoreType.Store,
						DestinationObjectId = SmartCoreType.Store.ItemId,
						FromStore = CurrentStore,
						FromStoreId = CurrentStore.ItemId,
						State = ComponentStorePosition.Serviceable,
						TransferDate = DateTime.Today
					});
				}


				_preResultDirectiveArray.Add(component);
			}



			AdditionalFilterItems(_preResultDirectiveArray, _resultDirectiveArray);

			AnimatedThreadWorker.ReportProgress(100, "Calculate complete");
		}

		#endregion

		private void ButtonMoveToClick(object sender, EventArgs e)
		{
			if (!_calculateWpItems)
				return;

			var components = new ComponentCollection();
			components.AddRange(_resultDirectiveArray.OfType<Component>().Where(c => c.NeedWpQuantity <= c.Quantity));

			if (components.Count == 0)
			{
				MessageBox.Show("There are no components in the Store", "Exclamation",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}


			var dlg = new MoveComponentForm(components.ToArray(), CurrentStore, _selectedWorkPackage);
			dlg.Text = "Move " +
				(components.Count > 1
				? "components"
				: "component " + components[0].Description)
				+ " to aircraft";

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
	}
}
