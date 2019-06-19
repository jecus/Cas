using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.PurchaseControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class ForecastKitsListScreen : ScreenControl
    {
        #region Fields

        private ForecastKitsListView _directivesViewer;
        //private ForecastData _currentForecastData;
        private Forecast _currentForecast = new Forecast();
        private ICommonCollection<AccessoryRequired> _initialDirectiveArray = new CommonCollection<AccessoryRequired>();
        private ICommonCollection<AccessoryRequired> _resultDirectiveArray = new CommonCollection<AccessoryRequired>();

        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

        private CommonFilterCollection _filter = new CommonFilterCollection(typeof(AccessoryRequired));

        private ForecastKitsReportBuilder _forecastKitsReportBulder;

        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportSchedule;
        private ToolStripMenuItem itemPrintReportMaintenancePlan;

        private RadDropDownMenu _contextMenuStrip;
        private RadMenuItem _toolStripMenuItemComposeQuotation;
        private RadMenuItem _toolStripMenuItemQuotations;
        private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuShowTaskCard;
		private RadMenuItem _toolStripMenuShowKits;
		#endregion

		#region Constructors

		#region public ForecastKitsListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private ForecastKitsListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public ForecastKitsListScreen(Aircraft currentAircraft) : this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
        public ForecastKitsListScreen(Aircraft currentAircraft)
            : this()
        {
            if (currentAircraft == null) 
                throw new ArgumentNullException("currentAircraft");
            CurrentAircraft = currentAircraft;
            StatusTitle = "Kit Forecast";

            _currentForecast = new Forecast { Aircraft = CurrentAircraft};

            #region ButtonPrintContextMenu

            buttonPrintMenuStrip = new ContextMenuStrip();
            //itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
            itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Equipment and Materials" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { /*itemPrintReportSchedule,*/ itemPrintReportMaintenancePlan });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;

            #endregion

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

            if(_initialDirectiveArray != null)
                _initialDirectiveArray.Clear();
            _initialDirectiveArray = null;

            if(_resultDirectiveArray != null)
                _resultDirectiveArray.Clear();
            _resultDirectiveArray = null;

            _currentForecast.Dispose();
            _currentForecast = null;

            _openPubQuotations.Clear();
            _openPubQuotations = null;

            if (_toolStripMenuItemComposeQuotation != null) _toolStripMenuItemComposeQuotation.Dispose();
            if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (RadMenuItem item in _toolStripMenuItemQuotations.Items)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.Items.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.Dispose();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (_toolStripMenuItemQuotations != null)
            {
                foreach (RadMenuItem item in _toolStripMenuItemQuotations.Items)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }

                _toolStripMenuItemQuotations.Items.Clear();

                foreach (RequestForQuotation quotation in _openPubQuotations)
                {
                    var item = new RadMenuItem(quotation.Title);
                    item.Click += AddToQuotationOrderItemClick;
                    item.Tag = quotation;
                    _toolStripMenuItemQuotations.Items.Add(item);
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
            _currentForecast.Kits.Clear();

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                AnimatedThreadWorker.ReportProgress(0, "calc. Maint. Checks kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetMaintenanceChecksKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(9, "calc. Maint. Directives kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetMaintenanceDirectivesKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(19, "calc. Base details kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetBaseComponentsAndComponentDirectivesKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(29, "calc. Components kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetComponentsAndComponentDirectivesKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(39, "calc. AD kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetDirectivesKits(_currentForecast, DirectiveType.AirworthenessDirectives));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(49, "calc. Damages kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetDirectivesKits(_currentForecast, DirectiveType.DamagesRequiring));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(59, "calc. Deffered kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetDirectivesKits(_currentForecast, DirectiveType.DeferredItems));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(69, "calc. Engineering orders kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetEngineeringOrdersKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(79, "calc. Service bulletins kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetServiceBulletinsKits(_currentForecast));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(89, "calc. Out of phase kits");
                _currentForecast.Kits.AddRange(GlobalObjects.AnalystCore.GetDirectivesKits(_currentForecast, DirectiveType.OutOfPhase));

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                AnimatedThreadWorker.ReportProgress(90, "Filter kits");
                
                _initialDirectiveArray.Clear();
                _initialDirectiveArray.AddRange(_currentForecast.Kits.ToArray());

                FilterItems(_initialDirectiveArray, _resultDirectiveArray);

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

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
            }

            AnimatedThreadWorker.ReportProgress(100, "calc. kits over");
            
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

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new RadDropDownMenu();
            _toolStripMenuItemComposeQuotation = new RadMenuItem();
            _toolStripMenuItemOpen = new RadMenuItem();
            _toolStripMenuItemQuotations = new RadMenuItem();
			_toolStripMenuShowTaskCard = new RadMenuItem();
			_toolStripMenuShowKits = new RadMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);

            _toolStripMenuItemOpen.Text = "Open Kit Task";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemComposeQuotation.Text = "Compose Quotation";
            _toolStripMenuItemComposeQuotation.Click += ToolStripMenuItemComposeQuotationClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuShowTaskCard.Text = "Show Task Card";
			_toolStripMenuShowTaskCard.Click += ToolStripMenuShowTaskCard_Click;
			// 
			// toolStripMenuShowKits
			// 
			_toolStripMenuShowKits.Text = "Show Kits";
			_toolStripMenuShowKits.Click += ToolStripMenuShowKits_Click;
			//
			// toolStripMenuItemComposeWorkPackage
			//
			_toolStripMenuItemQuotations.Text = "Add to Quotation Order";

            _contextMenuStrip.Items.Clear();
            
            _contextMenuStrip.Items.AddRange(
                _toolStripMenuItemComposeQuotation,
                _toolStripMenuItemQuotations,
				_toolStripMenuShowTaskCard,
				_toolStripMenuShowKits,
				new RadMenuSeparatorItem(),
                _toolStripMenuItemOpen
            );
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
            
        }

        #endregion

        #region private void CreateQuotationOrder()

        private void CreateQuotationOrder()
        {
            PurchaseManager.ComposeQuotationOrder(_directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), CurrentParent, this);
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
            CreateQuotationOrder();
        }

        #endregion

        #region private void AddToQuotationOrderItemClick(object sender, EventArgs e)

        private void AddToQuotationOrderItemClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0) return;

            RequestForQuotation wp = (RequestForQuotation)((RadMenuItem)sender).Tag;

            PurchaseManager.AddToQuotationOrder(wp, _directivesViewer.SelectedItems.OfType<IBaseCoreObject>().ToArray(), this);
        }

		#endregion

		#region private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)

		private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)
	    {
		    if (_directivesViewer.SelectedItems == null ||
		        _directivesViewer.SelectedItems.Count == 0) return;
		    var o = _directivesViewer.SelectedItems[0].ParentObject;

		    var attachedFile = GetItemFile(o);

		    if (o != null && attachedFile == null)
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
				    string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", o, o.ItemId, attachedFile.ItemId);
			    Program.Provider.Logger.Log(errorDescriptionSctring, ex);
		    }
	    }

		#endregion

		#region private void ToolStripMenuShowKits_Click(object sender, EventArgs e)

		private void ToolStripMenuShowKits_Click(object sender, EventArgs e)
	    {
		    if (_directivesViewer.SelectedItems == null ||
		        _directivesViewer.SelectedItems.Count == 0) return;
		    var o = _directivesViewer.SelectedItems[0];

		    var kitForm = new KitForm(o);
		    kitForm.ShowDialog();
	    }

	    #endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count == 0) return;

            IKitRequired parent = _directivesViewer.SelectedItem.ParentObject;

	        try
	        {
		        var dp = ScreenAndFormManager.GetEditScreenOrForm((BaseEntityObject)parent);
		        if (dp.DisplayerType == DisplayerType.Screen)
		        {
			        var refe = new ReferenceEventArgs();
			        refe.SetParameters(dp);
			        InvokeDisplayerRequested(refe);
		        }
		        else
			        dp.Form.ShowDialog();
	        }
	        catch (Exception ex)
	        {
				Program.Provider.Logger.Log("Error while opening record", ex);
			}
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new ForecastKitsListView
                                    {
                                        CustomMenu = _contextMenuStrip,
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            _directivesViewer.MenuOpeningAction = () =>
            {
	            if (_directivesViewer.SelectedItems.Count <= 0)
		            return;
	            if (_directivesViewer.SelectedItems.Count == 1)
	            {
		            _toolStripMenuItemOpen.Enabled = true;

		            var o = _directivesViewer.SelectedItems[0].ParentObject;

		            if (o is NextPerformance)
		            {
			            var np = o as NextPerformance;
			            _toolStripMenuShowTaskCard.Enabled = GetItemEnabled(np.Parent);
		            }
		            else if (o is AbstractPerformanceRecord)
		            {
			            var apr = o as AbstractPerformanceRecord;
			            _toolStripMenuShowTaskCard.Enabled = GetItemEnabled(apr.Parent);
		            }
		            else _toolStripMenuShowTaskCard.Enabled = GetItemEnabled(o);
	            }

	            _toolStripMenuItemComposeQuotation.Enabled = true;
            };

			panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count > 0)
            {
                buttonComposeQuotation.Enabled = true;
                headerControl.EditButtonEnabled = true;
            }
            else
            {
                headerControl.EditButtonEnabled = false;
                buttonComposeQuotation.Enabled = false;
            }
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

                //очистка массива данных по прогнозам
                _currentForecast.ForecastDatas.Clear();
                //поиск деталей данного самолета 
                var aircraftBaseDetails =
                    new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
                //составление нового массива данных по прогнозам
                foreach (var baseDetail in aircraftBaseDetails)
                {
                    //определение ресурсов прогноза для каждой базовой детали
                    var forecastData =
                        new ForecastData(DateTime.Today,
                                         baseDetail,
                                         GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail));
                    //дабавление в массив
                    _currentForecast.ForecastDatas.Add(forecastData);
                }
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void FilterItems(IEnumerable<AccessoryRequired> initialCollection, ICommonCollection<AccessoryRequired> resultCollection)
        ///<summary>
        ///</summary>
        ///<param name="initialCollection"></param>
        ///<param name="resultCollection"></param>
        private void FilterItems(IEnumerable<AccessoryRequired> initialCollection, ICommonCollection<AccessoryRequired> resultCollection)
        {
            if (_filter == null || _filter.Count == 0)
            {
                resultCollection.Clear();
                resultCollection.AddRange(initialCollection);
                return;
            }

            resultCollection.Clear();

            foreach (AccessoryRequired pd in initialCollection)
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

        #region private void ButtonComposeQuotationClick(object sender, EventArgs e)

        private void ButtonComposeQuotationClick(object sender, EventArgs e)
        {
            CreateQuotationOrder();
        }
        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            if (!AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;

            //if (sender == itemPrintReportSchedule)
            //{
            //    _scheduleReportBuilder = new MonthlyPlanReportBuilder(aircraftHeaderControl1.Operator, _directivesViewer.GetItemsArray());

            //    //_scheduleReportBuilder.ReportedAircraft = CurrentAircraft;
            //    //_scheduleReportBuilder.FilterSelection = _filter;
            //    //_scheduleReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
            //    //_scheduleReportBuilder.Forecast = _currentForecast;
            //    e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Scheduled report";
            //    e.RequestedEntity = new ReportScreen(_scheduleReportBuilder);
            //}
            //else 
                if (sender == itemPrintReportMaintenancePlan)
            {
                _forecastKitsReportBulder = new ForecastKitsReportBuilder(CurrentAircraft, _directivesViewer.GetItemsArray());
                _forecastKitsReportBulder.FilterSelection = _filter;
                _forecastKitsReportBulder.Forecast = _currentForecast;
                e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Forecast Kits report";
                e.RequestedEntity = new ReportScreen(_forecastKitsReportBulder);
                GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "ForecastKitsListScreen (Equipment and Materials)");
			}
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region private void ButtonApplyFilterClick(object sender, EventArgs e)

        private void ButtonApplyFilterClick(object sender, EventArgs e)
        {
            CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray) { Text = "Accessory Required Filter Form" };

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
            CancelAsync();

            List<BaseComponent> aircraftBaseComponents = null;
            if (CurrentAircraft != null)
            {
                //поиск деталей данного самолета 
                aircraftBaseComponents = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
                //очистка массива данных по прогнозам
                if (aircraftBaseComponents.Count != 0) _currentForecast.ForecastDatas.Clear();
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
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
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

                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 " Aircraft TSN/CSN: " + main.ForecastLifelength +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "This week":
                    {
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
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

                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 " Aircraft TSN/CSN: " + main.ForecastLifelength +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Two weeks":
                    {
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
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

                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 " Aircraft TSN/CSN: " + main.ForecastLifelength +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Month":
                    {
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
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

                            labelDateAsOf.Text =
                                "Forecast date: " + SmartCore.Auxiliary.Convert.GetDateFormat(main.ForecastDate) +
                                 " Aircraft TSN/CSN: " + main.ForecastLifelength +
                                 "\nAvg. utlz: " + main.AverageUtilization;
                        }
                    }
                    break;
                case "Custom":
                    {
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
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
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
        }
		#endregion

		#region private bool GetItemEnabled(IBaseEntityObject obj)

		private bool GetItemEnabled(IBaseEntityObject obj)
		{
			return GetItemFile(obj) != null;
		}

		#endregion

		#region private AttachedFile GetItemFile(IBaseEntityObject obj)

		private AttachedFile GetItemFile(IBaseEntityObject obj)
		{
			if (obj is Directive)
				return ((Directive)obj).EngineeringOrderFile;
			if (obj is MaintenanceDirective)
				return ((MaintenanceDirective)obj).TaskCardNumberFile;
			if (obj is NonRoutineJob)
				return ((NonRoutineJob)obj).AttachedFile;

			return null;
		}

		#endregion

		#endregion
	}
}
