using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class PreConfirmComponentsListScreen : ScreenControl
    {
        #region Fields

        private bool _firstLoad;

        private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();
        private readonly Aircraft _currentAircraft;
        private readonly BaseComponent _currentBaseComponent;
        private Forecast _currentForecast;

        private ComponentsListView _directivesViewer;

        private readonly bool _llpMark;
        //private DetailCollectionFilter _initialFilter;

        private CommonFilterCollection _initialFilter;
        private CommonFilterCollection _additionalfilter = new CommonFilterCollection(typeof(IComponentFilterParams));
        private ComponentCollection _initialDirectiveArray = new ComponentCollection();
        private ICommonCollection<BaseEntityObject> _preResultDirectiveArray = new CommonCollection<BaseEntityObject>();
        private ICommonCollection<BaseEntityObject> _resultDirectiveArray = new CommonCollection<BaseEntityObject>();




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
        private PreConfirmComponentsListScreen()
        {
            InitializeComponent();
        }
		#endregion

		#region public DetailsListScreen(BaseDetail currentBaseDetail) : this()

		public PreConfirmComponentsListScreen(BaseComponent currentBaseComponent) : this()
        {
            if (currentBaseComponent == null)
                throw new ArgumentNullException("_currentBaseComponent", "Cannot display null-baseDetail");
            _currentBaseComponent = currentBaseComponent;

			if(_currentBaseComponent.ParentAircraftId > 0)
				CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
	        if (_currentBaseComponent.ParentStoreId > 0)
				CurrentStore = GlobalObjects.StoreCore.GetStoreById(_currentBaseComponent.ParentStoreId);

			StatusTitle = _currentBaseComponent + " " + "Components";
           

            InitListView();
        }

        #endregion

        #region public DetailsListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters)  : this()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">ВС, содержащее агрегаты</param>
        ///<param name="initialFilters"></param>
        public PreConfirmComponentsListScreen(Aircraft currentAircraft)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            
            _currentAircraft = currentAircraft;

            CurrentAircraft = currentAircraft;
            StatusTitle = currentAircraft + " " + "Component Status";

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
            _openPubWorkPackages.Clear();
            _openPubQuotations.Clear();
            //_deferredCategories.Clear();

            _resultDirectiveArray = null;
            _preResultDirectiveArray = null;
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


            _directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
            _directivesViewer.Focus();

           
            _firstLoad = true;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _initialDirectiveArray.Clear();
            _resultDirectiveArray.Clear();
	        _preResultDirectiveArray.Clear();

			var transfer = new List<TransferRecord>();
			transfer.AddRange(GlobalObjects.TransferRecordCore.GetPreTransferRecordsFrom(_currentBaseComponent));

	        var preResult = new List<Component>();
			preResult.AddRange(transfer.Select(i => i.ParentComponent).ToList());

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

            foreach (Component detail in _initialDirectiveArray)
            {
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

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems == null)
                return;

            DialogResult confirmResult =
                MessageBox.Show(
                    _directivesViewer.SelectedItem != null
                        ? "Do you really want to confirm " +
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
                    _directivesViewer.radGridView1.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        if (_directivesViewer.SelectedItems[i] is Component)
                        {
	                        var component = (Component) _directivesViewer.SelectedItems[i];
	                        var tr = component.TransferRecords.GetLast();
							tr.PreConfirmTransfer = false;
							GlobalObjects.CasEnvironment.NewKeeper.Save(tr);
                        }
                    }
                    _directivesViewer.radGridView1.EndUpdate();

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

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
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


        #endregion

       
    }
}
