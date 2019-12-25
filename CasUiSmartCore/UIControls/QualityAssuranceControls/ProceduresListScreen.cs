using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ForecastControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Quality;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class ProceduresListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<Procedure> _initialDirectiveArray = new CommonCollection<Procedure>();
		private CommonCollection<Procedure> _forecastDirectiveArray = new CommonCollection<Procedure>();
		private CommonCollection<Procedure> _resultDirectiveArray = new CommonCollection<Procedure>();

		private CommonCollection<Audit> _openPubWorkPackages = new CommonCollection<Audit>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private Forecast _currentForecast;

		private ProceduresListView _directivesViewer;

		private CommonFilterCollection _initialFilter;
		private CommonFilterCollection _additionalFilter = new CommonFilterCollection(typeof(Procedure));

#if KAC
		private MaintenanceDirectivesReportBuilderKAC _maintenanceDirectiveFullReportBuilder = new MaintenanceDirectivesReportBuilderKAC();
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private MaintenanceDirectivesFullReportBuilder _maintenanceDirectiveFullReportBuilder = new MaintenanceDirectivesFullReportBuilder();
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
#endif
		private MaintenanceDirectivesReportBuilder _maintenanceDirectiveReportBuilder;

		private ToolStripMenuItem itemPrintReportMP;
		private ToolStripMenuItem itemPrintReportAMP;
		private ToolStripMenuItem itemPrintWorkscope;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemComposeWorkPackage;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemShowTaskCard;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuSeparatorItem _toolStripSeparator4;
		private RadMenuItem _toolStripMenuItemsWorkPackages;

		#endregion

		#region Constructors

		#region private ProceduresListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private ProceduresListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ProceduresListScreen((Operator currentOperator, IEnumerable<ICommonFilter> initialFilters = null)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		///<param name="initialFilters"></param>
		public ProceduresListScreen(Operator currentOperator, IEnumerable<ICommonFilter> initialFilters = null)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = currentOperator.Name + ". Procedures Status";
			//_filterSelection = new PrimaryDirectiveFilterSelectionForm(primaryDirectiveType, null);
			_maintenanceDirectiveReportBuilder = new MaintenanceDirectivesReportBuilder();

			if (initialFilters != null)
			{
				if (_initialFilter == null)
					_initialFilter = new CommonFilterCollection(typeof(Procedure), initialFilters);
				else
				{
					_initialFilter.Filters.Clear();
					_initialFilter.Filters.AddRange(initialFilters);
				}
			}

			#region ButtonPrintContextMenu

			ContextMenuStrip buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportMP = new ToolStripMenuItem { Text = "MP" };
			itemPrintReportAMP = new ToolStripMenuItem { Text = "AMP STATUS" };
			itemPrintWorkscope = new ToolStripMenuItem { Text = "WORK SCOPE"};
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportMP, itemPrintReportAMP, itemPrintWorkscope });

			ButtonPrintMenuStrip = buttonPrintMenuStrip;

			#endregion

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

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

			AnimatedThreadWorker.Dispose();

			_initialDirectiveArray.Clear();
			_forecastDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
			_openPubWorkPackages.Clear();
			_openPubQuotations.Clear();

			_initialDirectiveArray = null;
			_forecastDirectiveArray = null;
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
				foreach (var ttmi in _toolStripMenuItemHighlight.Items)
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
				foreach (var item in _toolStripMenuItemsWorkPackages.Items)
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (aircraftHeaderControl1.Operator != null)
			{
				labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
			}
			else
			{
				labelTitle.Text = "";
				labelTitle.Status = Statuses.NotActive;
			}
			
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (var item in _toolStripMenuItemsWorkPackages.Items)
				{
					item.Click -= AddToWorkPackageItemClick;
				}

				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (Audit workPackage in _openPubWorkPackages)
				{
					var item = new RadMenuItem(workPackage.Title);
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_forecastDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			#region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");
			try
			{
				_initialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<Procedure>(_initialFilter == null ?  null : _initialFilter.ToArray(), true));

				AnimatedThreadWorker.ReportProgress(20, "calculation of directives");

				if (_currentForecast == null)
				{
					foreach (Procedure pd in _initialDirectiveArray)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(pd);
					}


					#region Фильтрация директив

					AnimatedThreadWorker.ReportProgress(70, "filter directives");

					FilterItems(_initialDirectiveArray, _resultDirectiveArray);

					if (AnimatedThreadWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					#endregion

				}
				else
				{
					GlobalObjects.AnalystCore.GetForecast(_initialDirectiveArray, 
																	 _forecastDirectiveArray, 
																	 _currentForecast);
					#region Фильтрация директив

					AnimatedThreadWorker.ReportProgress(70, "filter directives");

					FilterItems(_forecastDirectiveArray, _resultDirectiveArray);

					if (AnimatedThreadWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					#endregion
				}
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

			#region Сравнение с рабочими пакетами

			AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if(_openPubWorkPackages == null)
				_openPubWorkPackages = new CommonCollection<Audit>();
			_openPubWorkPackages.Clear();
			_openPubWorkPackages.AddRange(GlobalObjects.AuditCore.GetAuditsLite(CurrentOperator, WorkPackageStatus.Opened));
			_openPubWorkPackages.AddRange(GlobalObjects.AuditCore.GetAuditsLite(CurrentOperator, WorkPackageStatus.Published));
			//сбор всех записей рабочих пакетов для удобства фильтрации
			List<AuditRecord> openWPRecords = new List<AuditRecord>();
			foreach (Audit openWorkPackage in _openPubWorkPackages)
				openWPRecords.AddRange(openWorkPackage.AuditRecords);

			foreach (Procedure task in _initialDirectiveArray)
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
					AuditRecord wpr =
						openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
														  r.AuditItemTypeId == task.SmartCoreObjectType.ItemId &&
														  r.DirectiveId == task.ItemId);
					if (wpr != null)
						np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.AuditId);
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
			_openPubQuotations.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(CurrentOperator, new[] { WorkPackageStatus.Opened, WorkPackageStatus.Published }));

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoForecastWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoForecastWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");
			try
			{
				AnimatedThreadWorker.ReportProgress(20, "calculation of directives");

				if (_currentForecast == null)
				{
					foreach (Procedure pd in _initialDirectiveArray)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(pd);
					}

					AnimatedThreadWorker.ReportProgress(70, "filter directives");

					FilterItems(_initialDirectiveArray, _resultDirectiveArray);

					if (AnimatedThreadWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
				}
				else
				{
					GlobalObjects.AnalystCore.GetForecast(_initialDirectiveArray,
																	 _forecastDirectiveArray,
																	 _currentForecast);

					AnimatedThreadWorker.ReportProgress(70, "filter directives");

					FilterItems(_forecastDirectiveArray, _resultDirectiveArray);

					if (AnimatedThreadWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
				}
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

			#region Сравнение с рабочими пакетами

			AnimatedThreadWorker.ReportProgress(90, "comparison with the Audits");

			//загрузка рабочих пакетов для определения 
			//перекрытых ими выполнений задач
			if (_openPubWorkPackages == null)
				_openPubWorkPackages = new CommonCollection<Audit>();
			//сбор всех записей рабочих пакетов для удобства фильтрации
			List<AuditRecord> openWPRecords = new List<AuditRecord>();
			foreach (Audit openWorkPackage in _openPubWorkPackages)
				openWPRecords.AddRange(openWorkPackage.AuditRecords);

			foreach (Procedure task in _initialDirectiveArray)
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
					AuditRecord wpr =
						openWPRecords.FirstOrDefault(r => r.PerformanceNumFromStart == np.PerformanceNum &&
														  r.AuditItemTypeId == task.SmartCoreObjectType.ItemId &&
														  r.DirectiveId == task.ItemId);
					if (wpr != null)
						np.BlockedByPackage = _openPubWorkPackages.GetItemById(wpr.AuditId);
				}
			}

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
			
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			if (_currentForecast == null)
			{
				FilterItems(_initialDirectiveArray, _resultDirectiveArray);
			}
			else
			{
				FilterItems(_forecastDirectiveArray, _resultDirectiveArray);
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

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
			_toolStripMenuItemComposeWorkPackage.Text = "Compose a Audit";
			_toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
			//
			// _toolStripMenuItemsWorkPackages
			//
			_toolStripMenuItemsWorkPackages.Text = "Add to Audit";
			
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
				var item = new RadMenuItem(highlight.FullName);
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

			if (MessageBox.Show("Create and save a Audit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				List<NextPerformance> wpItems =
					_directivesViewer.SelectedItems.Where(i => i.NextPerformances != null && i.NextPerformances.Count > 0)
												   .Select(i => i.NextPerformances[0])
												   .ToList();
				try
				{
					string message;
					var audit = GlobalObjects.AuditCore.AddAudit(wpItems, CurrentOperator, out message);
					if (audit == null)
					{
						MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					//Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
					_openPubWorkPackages.Add(audit);
					//Создание пункта в меню открытых рабочих пакетов
					var item = new RadMenuItem(audit.Title);
					item.Click += AddToWorkPackageItemClick;
					item.Tag = audit;
					_toolStripMenuItemsWorkPackages.Items.Add(item);

					foreach (NextPerformance nextPerformance in wpItems)
					{
						nextPerformance.BlockedByPackage = audit;
						_directivesViewer.UpdateItemColor();
					}
					ReferenceEventArgs refArgs = new ReferenceEventArgs
													 {
														 TypeOfReflection = ReflectionTypes.DisplayInNew,
														 DisplayerText = audit.Title,
														 RequestedEntity = new AuditScreen(audit)
													 };
					InvokeDisplayerRequested(refArgs);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Audit", ex);
				}
			}
		}
		#endregion

		#region private void AddToWorkPackageItemClick(object sender, EventArgs e)

		private void AddToWorkPackageItemClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0) return;

			Audit wp = (Audit)((RadMenuItem)sender).Tag;

			if (MessageBox.Show("Add item to Audit: " + wp.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				List<NextPerformance> wpItems =
					_directivesViewer.SelectedItems.Where(i => i.NextPerformances != null && i.NextPerformances.Count > 0)
												   .Select(i => i.NextPerformances[0])
												   .ToList();
				try
				{
					string message;

					if (!GlobalObjects.AuditCore.AddToAudit(wpItems, wp.ItemId, CurrentOperator, out message))
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

					if (MessageBox.Show("Items added successfully. Open Audit?", (string)new GlobalTermsProvider()["SystemName"],
										 MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
										== DialogResult.Yes)
					{
						ReferenceEventArgs refArgs = new ReferenceEventArgs();
						refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
						refArgs.DisplayerText = wp.Title;
						refArgs.RequestedEntity = new AuditScreen(wp);
						InvokeDisplayerRequested(refArgs);
					}
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("error while create Audit", ex);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			CommonCollection<Procedure> selected = new CommonCollection<Procedure>();
			foreach (Procedure o in _directivesViewer.SelectedItems)
			{
				selected.CompareAndAdd(o);
			}

			foreach (Procedure t in selected)
			{
				ReferenceEventArgs refE = new ReferenceEventArgs();
				string regNumber = t.Title;
				refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refE.DisplayerText = regNumber;
				refE.RequestedEntity = new ProcedureScreen(t);
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
			Procedure mpd = _directivesViewer.SelectedItems[0];
			if (mpd == null || mpd.ProcedureFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				return;
			}


			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(mpd.ProcedureFile, out message);
				if (message != "")
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
					string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", mpd, mpd.ItemId, mpd.ProcedureFile.ItemId);
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;
			List<Procedure> directives = _directivesViewer.SelectedItems.ToList();

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].Title + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoForecastWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new ProceduresListView();
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
				_toolStripMenuItemsWorkPackages);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;

					Procedure mpd = _directivesViewer.SelectedItems[0];
					if (mpd != null && mpd.ProcedureFile != null)
						_toolStripMenuItemShowTaskCard.Enabled = true;
					else _toolStripMenuItemShowTaskCard.Enabled = false;
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
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoForecastWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.Cancel = true;
			//if (CurrentAircraft != null)
			//    e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + ReportText + " Report";
			//else
			//{
			//    e.DisplayerText = ReportText + " Report";
			//    e.Cancel = true;
			//    return;
			//}
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			//if (sender == itemPrintReportAMP)
			//{
			//    _maintenanceDirectiveFullReportBuilder.ReportedAircraft = CurrentAircraft;
			//    _maintenanceDirectiveFullReportBuilder.FilterSelection = _additionalFilter;
			//    _maintenanceDirectiveFullReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
			//    _maintenanceDirectiveFullReportBuilder.Forecast = _currentForecast;
			//    e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "Maintenance Status report";
			//    e.RequestedEntity = new ReportScreen(_maintenanceDirectiveFullReportBuilder);
			//}
			//else if (sender == itemPrintReportMP)
			//{
			//    Procedure[] items =
			//        _directivesViewer.GetItemsArray()
			//            .Where(mpd => !mpd.IsClosed && mpd.NextPerformances.Count > 0)
			//            .ToArray();

			//    if(items.Length == 0)
			//    {
			//        MessageBox.Show("In selected Items not open or repetitive items",
			//                        (string) new GlobalTermsProvider()["SystemName"],
			//                        MessageBoxButtons.OK, 
			//                        MessageBoxIcon.Exclamation, 
			//                        MessageBoxDefaultButton.Button1);
			//        e.Cancel = true;
			//        return;
			//    }
			//    _maintenanceDirectiveReportBuilder.ReportedAircraft = CurrentAircraft;
			//    _maintenanceDirectiveReportBuilder.FilterSelection = _additionalFilter;
			//    _maintenanceDirectiveReportBuilder.AddDirectives(items);
			//    _maintenanceDirectiveReportBuilder.Forecast = _currentForecast;
			//    e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "Maintenance Program";
			//    e.RequestedEntity = new ReportScreen(_maintenanceDirectiveReportBuilder);    
			//}
			//else if (sender == itemPrintWorkscope)
			//{
			//    _workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
			//    _workscopeReportBuilder.FilterSelection = _additionalFilter;
			//    _workscopeReportBuilder.AddDirectives(_directivesViewer.GetItemsArray());
			//    _workscopeReportBuilder.Forecast = _currentForecast;
			//    e.DisplayerText = CurrentAircraft.RegistrationNumber + "." + "WORK SCOPE";
			//    e.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
			//}
			//else
			//{
			//    e.Cancel = true;
			//}
		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "New Procedure";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new ProcedureScreen(aircraftHeaderControl1.Operator);
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_additionalFilter, _initialDirectiveArray);

			if(form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoForecastWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
			List<BaseComponent> storeBaseDetails;
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
						if (aircraftHeaderControl1.Operator != null)
						{
							_currentForecast = new Forecast(aircraftHeaderControl1.Operator, DateTime.Today);
							////поиск деталей данного самолета 
							//storeBaseDetails = new List<BaseDetail>(GlobalObjects.CasEnvironment.GetBaseDetails(CurrentStore));
							////составление нового массива данных по прогноза
							//foreach (BaseDetail baseDetail in storeBaseDetails)
							//{
							//    //определение ресурсов прогноза для каждой базовой детали
							//    ForecastData forecastData =
							//        new ForecastData(DateTime.Today,
							//                         baseDetail,
							//                         GlobalObjects.CasEnvironment.Calculator.GetLifelength(baseDetail));
							//    //дабавление в массив
							//    _currentForecast.ForecastDatas.Add(forecastData);
							//}
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
						if (aircraftHeaderControl1.Operator != null)
						{
							_currentForecast = new Forecast(aircraftHeaderControl1.Operator, DateTime.Today.AddDays(7));
							////поиск деталей данного самолета 
							//storeBaseDetails = new List<BaseDetail>(GlobalObjects.CasEnvironment.GetBaseDetails(CurrentStore));
							////составление нового массива данных по прогноза
							//foreach (BaseDetail baseDetail in storeBaseDetails)
							//{
							//    //определение ресурсов прогноза для каждой базовой детали
							//    ForecastData forecastData =
							//        new ForecastData(DateTime.Today.AddDays(7),
							//                         baseDetail,
							//                         GlobalObjects.CasEnvironment.Calculator.GetLifelength(baseDetail));
							//    //дабавление в массив
							//    _currentForecast.ForecastDatas.Add(forecastData);
							//}
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
						if (aircraftHeaderControl1.Operator != null)
						{
							_currentForecast = new Forecast(aircraftHeaderControl1.Operator, DateTime.Today.AddDays(14));
							////поиск деталей данного самолета 
							//storeBaseDetails = new List<BaseDetail>(GlobalObjects.CasEnvironment.GetBaseDetails(CurrentStore));
							////составление нового массива данных по прогноза
							//foreach (BaseDetail baseDetail in storeBaseDetails)
							//{
							//    //определение ресурсов прогноза для каждой базовой детали
							//    ForecastData forecastData =
							//        new ForecastData(DateTime.Today.AddDays(14),
							//                         baseDetail,
							//                         GlobalObjects.CasEnvironment.Calculator.GetLifelength(baseDetail));
							//    //дабавление в массив
							//    _currentForecast.ForecastDatas.Add(forecastData);
							//}
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
						if (aircraftHeaderControl1.Operator != null)
						{
							_currentForecast = new Forecast(aircraftHeaderControl1.Operator, DateTime.Today.AddMonths(1));
							////поиск деталей данного самолета 
							//storeBaseDetails = new List<BaseDetail>(GlobalObjects.CasEnvironment.GetBaseDetails(CurrentStore));
							////составление нового массива данных по прогноза
							//foreach (BaseDetail baseDetail in storeBaseDetails)
							//{
							//    //определение ресурсов прогноза для каждой базовой детали
							//    ForecastData forecastData =
							//        new ForecastData(DateTime.Today.AddMonths(1),
							//                         baseDetail,
							//                         GlobalObjects.CasEnvironment.Calculator.GetLifelength(baseDetail));
							//    //дабавление в массив
							//    _currentForecast.ForecastDatas.Add(forecastData);
							//}
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
						if (aircraftHeaderControl1.Operator != null)
						{
							_currentForecast = new Forecast(aircraftHeaderControl1.Operator, DateTime.Today);
							////поиск деталей данного самолета 
							//storeBaseDetails = new List<BaseDetail>(GlobalObjects.CasEnvironment.GetBaseDetails(CurrentStore));
							////составление нового массива данных по прогноза
							//foreach (BaseDetail baseDetail in storeBaseDetails)
							//{
							//    //определение ресурсов прогноза для каждой базовой детали
							//    ForecastData forecastData =
							//        new ForecastData(DateTime.Today,
							//                         baseDetail,
							//                         GlobalObjects.CasEnvironment.Calculator.GetLifelength(baseDetail));
							//    //дабавление в массив
							//    _currentForecast.ForecastDatas.Add(forecastData);
							//}
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

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoForecastWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoForecastWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Procedure> initialCollection, ICommonCollection<Procedure> resultCollection)
		{
			if (_additionalFilter == null || _additionalFilter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Procedure pd in initialCollection)
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

		#endregion
	}
}
