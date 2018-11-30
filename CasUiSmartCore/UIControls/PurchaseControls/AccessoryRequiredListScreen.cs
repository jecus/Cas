using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.KitControls;
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

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    //TODO:(Evgenii Babak) проверить правильность название скрина
    [ToolboxItem(false)]
    public partial class AccessoryRequiredListScreen : ScreenControl
    {

		#region Fields

		private List<int> MpdIds = new List<int>();
		private AccessoryRequiredListView _directivesViewer;
        //private ForecastData _currentForecastData;
        private Forecast _currentForecast;
        private ICommonCollection<AccessoryRequired> _initialDirectiveArray = new CommonCollection<AccessoryRequired>();
        private ICommonCollection<AccessoryRequired> _resultDirectiveArray = new CommonCollection<AccessoryRequired>();

        private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

        private CommonFilterCollection _filter = new CommonFilterCollection(typeof(AccessoryRequired));

        private ForecastKitsReportBuilder _forecastKitsReportBulder;

        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportSchedule;
        private ToolStripMenuItem itemPrintReportMaintenancePlan;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemComposeQuotation;
        private ToolStripMenuItem _toolStripMenuItemQuotations;
        private ToolStripMenuItem _toolStripMenuItemOpen;
		private ToolStripMenuItem _toolStripMenuShowTaskCard;
		private ToolStripMenuItem _toolStripMenuShowKits;
		private WorkPackage _currentWorkPackage;

		#endregion

		#region Properties
		/// <summary>
		/// Контейнер директив
		/// </summary>
		private object DirectiveSource
		{
			get
			{
				if (_currentWorkPackage != null)
					return _currentWorkPackage;
				return CurrentAircraft;
			}
		}

		#endregion

		#region Constructors

		#region public AccessoryRequiredListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private AccessoryRequiredListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public AccessoryRequiredListScreen(Aircraft currentAircraft) : this()

	    /// <summary>
	    ///  Создаёт экземпляр элемента управления, отображающего список директив
	    /// </summary>
	    /// <param name="currentAircraft">ВС, которому принадлежат директивы</param>
	    /// <param name="forecast"></param>
	    public AccessoryRequiredListScreen(Aircraft currentAircraft, Forecast forecast = null)
            : this()
        {
            if (currentAircraft == null) 
                throw new ArgumentNullException("currentAircraft");
	        _currentForecast = forecast;
            CurrentAircraft = currentAircraft;
            StatusTitle = "Kit Forecast";

            #region ButtonPrintContextMenu

            buttonPrintMenuStrip = new ContextMenuStrip();
            //itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
            itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Equipment and Materials" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { /*itemPrintReportSchedule,*/ itemPrintReportMaintenancePlan });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;

            #endregion

            InitToolStripMenuItems();
            InitListView();
        }
		#endregion

		#region public AccessoryRequiredListScreen(Aircraft currentAircraft) : this()

		/// <summary>
		///  Создаёт экземпляр элемента управления, отображающего список директив
		/// </summary>
		/// <param name="currentAircraft">ВС, которому принадлежат директивы</param>
		/// <param name="forecast"></param>
		public AccessoryRequiredListScreen(Aircraft currentAircraft, List<int> mpdIds, Forecast forecast = null)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			_currentForecast = forecast;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Kit Forecast";
			MpdIds = mpdIds;

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			//itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
			itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Equipment and Materials" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { /*itemPrintReportSchedule,*/ itemPrintReportMaintenancePlan });

			ButtonPrintMenuStrip = buttonPrintMenuStrip;

			#endregion

			InitToolStripMenuItems();
			InitListView();
		}
		#endregion

		#region public AccessoryRequiredListScreen(WorkPackage currentWorkPackage)
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentWorkPackage">Рабочий пакет, которому принадлежат директивы</param>
		public AccessoryRequiredListScreen(WorkPackage currentWorkPackage)
			: this()
		{
			if (currentWorkPackage == null)
				throw new ArgumentNullException("currentWorkPackage");

			_currentWorkPackage = currentWorkPackage;

			if (_currentWorkPackage.Aircraft == null)
				throw new ArgumentNullException("Aircraft is null");

			CurrentAircraft = _currentWorkPackage.Aircraft;
			StatusTitle = "Kit Forecast";

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			//itemPrintReportSchedule = new ToolStripMenuItem { Text = "Scheduled" };
			itemPrintReportMaintenancePlan = new ToolStripMenuItem { Text = "Equipment and Materials" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { /*itemPrintReportSchedule,*/ itemPrintReportMaintenancePlan });

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
		/// Производит выгруску ресурсов страницы
		/// </summary>
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

            _openPubQuotations.Clear();
            _openPubQuotations = null;

            if (_toolStripMenuItemComposeQuotation != null) _toolStripMenuItemComposeQuotation.Dispose();
            if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if (_toolStripMenuItemQuotations != null)
            {
                foreach (ToolStripMenuItem item in _toolStripMenuItemQuotations.DropDownItems)
                {
                    item.Click -= AddToQuotationOrderItemClick;
                }
                _toolStripMenuItemQuotations.DropDownItems.Clear();
                _toolStripMenuItemQuotations.Dispose();
            }
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

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

            _directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _initialDirectiveArray.Clear();

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            try
            {

                if (_currentForecast == null)
                {
                    AnimatedThreadWorker.ReportProgress(0, "load items");

	                if (DirectiveSource is Aircraft)
	                {
		                var aircraft = DirectiveSource as Aircraft;
						var aircraftModelId = aircraft.Model?.ItemId ?? -1;
		                if (MpdIds.Count > 0)
			                _initialDirectiveArray.AddRange(GlobalObjects.KitsCore.GetMpdKits(aircraft.ItemId, MpdIds).ToArray());
		                else _initialDirectiveArray.AddRange(GlobalObjects.KitsCore.GetAllAircraftKits(aircraft.ItemId, aircraftModelId).ToArray());
					} 
	                else
		                _initialDirectiveArray.AddRange(GlobalObjects.KitsCore.GetAllWorkPackageKits(((WorkPackage)DirectiveSource).ItemId).ToArray());

	                if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(20, "calculation of items");


                    IDirective[] directives =
                        _initialDirectiveArray.Where(i => i.ParentObject is IDirective)
                                              .Select(i => i.ParentObject as IDirective)
                                              .Distinct()
                                              .ToArray();
                    double step = 75.0 / directives.Count();

                    for(int i = 0; i < directives.Length; i ++)
                    {
                        if (AnimatedThreadWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        AnimatedThreadWorker.ReportProgress(20 + (int)(step * i), "calculation of items");

                        GlobalObjects.PerformanceCalculator.GetNextPerformance(directives[i]);
                    }
                }
                else
                {
                    _currentForecast.Kits.Clear();

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
                    _initialDirectiveArray.AddRange(_currentForecast.Kits.ToArray());
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
            }

            AnimatedThreadWorker.ReportProgress(95, "Filter kits");

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

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemComposeQuotation = new ToolStripMenuItem();
            _toolStripMenuItemQuotations = new ToolStripMenuItem();
            _toolStripMenuItemOpen = new ToolStripMenuItem();
			_toolStripMenuShowTaskCard = new ToolStripMenuItem();
			_toolStripMenuShowKits = new ToolStripMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);

            _toolStripMenuItemOpen.Text = "Open Kit Task";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuShowKits
			// 
			_toolStripMenuShowKits.Text = "Show Kits";
			_toolStripMenuShowKits.Click += ToolStripMenuShowKits_Click;
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
			// toolStripMenuItemComposeWorkPackage
			//
			_toolStripMenuItemQuotations.Text = "Add to Quotation Order";

            _contextMenuStrip.Items.Clear();
            _contextMenuStrip.Opening += ContextMenuStripOpen;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    _toolStripMenuItemComposeQuotation,
                                                    _toolStripMenuItemQuotations,
                                                    _toolStripMenuItemOpen,
													_toolStripMenuShowTaskCard,
													_toolStripMenuShowKits
												});
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

				var o = _directivesViewer.SelectedItems[0].ParentObject;

				_toolStripMenuShowTaskCard.Enabled = GetItemEnabled(o);
			}
            _toolStripMenuItemComposeQuotation.Enabled = true;
        }

		#endregion

		#region private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)

		private void ToolStripMenuShowTaskCard_Click(object sender, EventArgs e)
	    {
		    if (_directivesViewer.SelectedItems == null ||
		        _directivesViewer.SelectedItems.Count == 0) return;
		    var o = _directivesViewer.SelectedItems[0].ParentObject;

		    AttachedFile attachedFile = null;


			if (o is NextPerformance)
			{
				var np = o as NextPerformance;
				attachedFile = GetItemFile(np.Parent);
			}
			else if (o is AbstractPerformanceRecord)
			{
				var apr = o as AbstractPerformanceRecord;
				attachedFile = GetItemFile(apr.Parent);
			}
			else attachedFile = GetItemFile(o);

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

		#region private void CreateQuotationOrder()

		private void CreateQuotationOrder()
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

		private void ToolStripMenuShowKits_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			   _directivesViewer.SelectedItems.Count == 0) return;
			var o = _directivesViewer.SelectedItems[0];

			var kitForm = new KitForm(o);
			kitForm.ShowDialog();
		}


		#region private void InitListView()

		private void InitListView()
        {
            _directivesViewer = new AccessoryRequiredListView
                                    {
                                        ContextMenuStrip = _contextMenuStrip,
                                        TabIndex = 2,
                                        Location = new Point(panel1.Left, panel1.Top),
                                        Dock = DockStyle.Fill
                                    };
            //события 
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

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

            if (sender == itemPrintReportMaintenancePlan)
            {
				if(_currentWorkPackage != null)
					_forecastKitsReportBulder = new ForecastKitsReportBuilder(_currentWorkPackage, _directivesViewer.GetItemsArray());
				else if(CurrentAircraft != null)
					_forecastKitsReportBulder = new ForecastKitsReportBuilder(CurrentAircraft, _directivesViewer.GetItemsArray());
				else throw new ArgumentNullException("Work package or aircraft should be not null");
				_forecastKitsReportBulder.FilterSelection = _filter;
                _forecastKitsReportBulder.Forecast = _currentForecast;
                e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Forecast Kits report";
                e.RequestedEntity = new ReportScreen(_forecastKitsReportBulder);
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
                if (aircraftBaseComponents.Count != 0 && _currentForecast != null) 
                    _currentForecast.ForecastDatas.Clear();
            }
            else
                _currentForecast.ForecastDatas[0].ForecastLifelength = new Lifelength(0, 0, 0);

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
                        _currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today };
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
                        _currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddDays(7) };
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
                        _currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddDays(14) };
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
                        _currentForecast = new Forecast { Aircraft = CurrentAircraft, ForecastDate = DateTime.Today.AddMonths(1) };
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
                        _currentForecast = new Forecast { Aircraft = CurrentAircraft };
                        if (aircraftBaseComponents != null)
                        {
                            //составление нового массива данных по прогнозам
                            foreach (BaseComponent baseDetail in aircraftBaseComponents)
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
