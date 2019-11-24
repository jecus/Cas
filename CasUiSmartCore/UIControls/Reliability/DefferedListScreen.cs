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
using CAS.UI.UIControls.Auxiliary.Importing;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.Reliability;
using CASReports.Builders;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;
using TempUIExtentions;
using Point = System.Drawing.Point;
using RadMenuItem = Telerik.WinControls.UI.RadMenuItem;

namespace CAS.UI.UIControls.DirectivesControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class DefferedListScreen : ScreenControl
	{
		#region Fields

		private readonly ADType _adType;
		private DirectiveType _currentPrimaryDirectiveType;
		private ICommonCollection<Directive> _initialDirectiveArray = new DirectiveCollection();
		private ICommonCollection<Directive> _resultDirectiveArray = new CommonCollection<Directive>();
		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private Forecast _currentForecast;

		private DefferedListView _directivesViewer;

		private CommonFilterCollection _filter;

		private DirectivesReportBuilder _builder;
		private DirectivesAMReportBuilder _amReportBuilder = new DirectivesAMReportBuilder();

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportAD;
		private ToolStripMenuItem itemPrintReportAMP;


		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuItem _toolStripMenuItemShowADFile;
		private RadMenuItem _toolStripMenuItemShowSBFile;
		private RadMenuItem _toolStripMenuItemShowEOFile;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuSeparatorItem _toolStripSeparator4;

		#endregion

		#region Constructors

		#region public DefferedListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public DefferedListScreen()
		{
			InitializeComponent();
		}
		#endregion


		#region public DefferedListScreen(Aircraft currentAircraft, PrimaryDirectiveType primaryDirectiveType, ADType adType = ADType.None)

		/// <summary>
		///  Создаёт экземпляр элемента управления, отображающего список директив
		/// </summary>
		/// <param name="adType"></param>
		public DefferedListScreen(Operator @operator, ADType adType = ADType.None) : this()
		{
			if (@operator == null)
				throw new ArgumentNullException("@operator");

			var primaryDirectiveType = DirectiveType.DeferredItems;


			CurrentOperator = @operator;
			StatusTitle = @operator.Name + " " + primaryDirectiveType.CommonName;

			_currentPrimaryDirectiveType = primaryDirectiveType;
			_adType = adType;


			var directiveList = new DefferedListView();
			_filter = new CommonFilterCollection(typeof(DeferredItem));
			_builder = new DeferredListReportBuilder();

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
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
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
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
			
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			labelTitle.Text = "";
			labelTitle.Status = Statuses.NotActive;

			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			try
			{
				if (_currentForecast == null)
				{

					var aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts();
					foreach (var aircraft in aircrafts)
					{
						_initialDirectiveArray.AddRange(GlobalObjects.DirectiveCore.GetDeferredItems(null, aircraft));
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

			foreach (Directive pd in _initialDirectiveArray)
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
			if (_openPubWorkPackages == null)
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
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripMenuItemShowADFile = new RadMenuItem();
			_toolStripMenuItemShowSBFile = new RadMenuItem();
			_toolStripMenuItemShowEOFile = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripSeparator4 = new RadMenuSeparatorItem();
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
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ButtonDeleteClick;

			_contextMenuStrip.Items.Clear();
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
			_contextMenuStrip.Items.AddRange(_toolStripMenuItemOpen,
													_toolStripMenuItemShowADFile,
													_toolStripMenuItemShowSBFile,
													_toolStripMenuItemShowEOFile,
													new RadMenuSeparatorItem(),
													_toolStripMenuItemHighlight,
													_toolStripSeparator2,
													_toolStripSeparator1,
													_toolStripSeparator4,
													_toolStripMenuItemDelete
												);
		}
		#endregion

		#region private void InitPrintToolStripMenuItems()

		private void InitPrintToolStripMenuItems()
		{
			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportAD = new ToolStripMenuItem { Text = "AD All" };
			itemPrintReportAMP = new ToolStripMenuItem { Text = "MP AD, SB, STC & REPAIR" };

			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportAD, itemPrintReportAMP });

			ButtonPrintMenuStrip = buttonPrintMenuStrip;
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
					string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", dir, dir.ItemId, attachedFile.ItemId);
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView(DefferedListView directiveListView)
		{
			_directivesViewer = directiveListView;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.CustomMenu = _contextMenuStrip;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemShowADFile.Enabled = false;
					_toolStripMenuItemShowSBFile.Enabled = false;
					_toolStripMenuItemShowEOFile.Enabled = false;
					_toolStripMenuItemHighlight.Enabled = false;
					_toolStripMenuItemDelete.Enabled = false;

				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
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
					}
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuItemHighlight.Enabled = true;
					_toolStripMenuItemDelete.Enabled = true;
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
			var form = new CommonExcelImportForm(typeof(Directive));
			form.ShowDialog(this);
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
	}
}
