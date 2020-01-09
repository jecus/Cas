using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;
using SmartCore.Relation;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Fleet
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class MaintenanceDirectiveFleetListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<MaintenanceDirective> _initialDirectiveArray = new CommonCollection<MaintenanceDirective>();
		private ICommonCollection<MaintenanceDirective> _resultDirectiveArray = new CommonCollection<MaintenanceDirective>();

		private MaintenanceDirectiveFleetListView _directivesViewer;

		private CommonFilterCollection _additionalFilter = new CommonFilterCollection(typeof(MaintenanceDirective));
		
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemShowTaskCard;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;

		#endregion

		#region Constructors

		#region private MaintenanceDirectiveFleetListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private MaintenanceDirectiveFleetListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public MaintenanceDirectiveFleetListScreen(Aircraft currentAircraft, IEnumerable<ICommonFilter> initialFilters = null)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		///<param name="initialFilters"></param>
		public MaintenanceDirectiveFleetListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			CurrentOperator = currentOperator;

			statusControl.ShowStatus = false;
			labelTitle.Visible = false;
			
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		/// <summary>
		/// Производит очистку ресурсов страницы
		/// </summary>
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

			AnimatedThreadWorker.Dispose();

			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			_initialDirectiveArray = null;
			_resultDirectiveArray = null;

			if (_additionalFilter != null)
			{
				_additionalFilter.Filters.Clear();
				_additionalFilter = null;
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemShowTaskCard != null) _toolStripMenuItemShowTaskCard.Dispose();
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
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

			if (!string.IsNullOrEmpty(TextBoxFilter.Text))
			{

				#region Загрузка элементов

				AnimatedThreadWorker.ReportProgress(0, "load directives");

				var maintenanceDirectives = new List<MaintenanceDirective>();
				try
				{

					var temp = 
						GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(TextBoxFilter.Text);

					foreach (var directive in temp)
					{
						directive.ParentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent?.ParentAircraftId ?? -1);
						if(directive.ParentAircraft != null)
							maintenanceDirectives.Add(directive);
					}

					AnimatedThreadWorker.ReportProgress(20, "calculation directives");


					foreach (var g in maintenanceDirectives.GroupBy(i => i.ParentAircraft.ItemId))
					{
						var bindedItemsDict = GlobalObjects.BindedItemsCore.GetBindedItemsFor(g.Key,
							maintenanceDirectives
								.Where(m => m.WorkItemsRelationType == WorkItemsRelationType.CalculationDepend)
								.Cast<IBindedItem>());

						CalculateMaintenanceDirectives(maintenanceDirectives.Where(i => i.ParentAircraft.ItemId == g.Key).ToList(), bindedItemsDict);
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

				#region Фильтрация директив

				AnimatedThreadWorker.ReportProgress(70, "filter directives");

				FilterItems(_initialDirectiveArray, _resultDirectiveArray);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				#endregion

				AnimatedThreadWorker.ReportProgress(100, "Complete");
			}
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

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
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemShowTaskCard = new RadMenuItem();
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


		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			CommonCollection<MaintenanceDirective> selected = new CommonCollection<MaintenanceDirective>();
			foreach (MaintenanceDirective o in _directivesViewer.SelectedItems)
			{
				selected.CompareAndAdd(o);
			}

			foreach (MaintenanceDirective t in selected)
			{
				var refE = new ReferenceEventArgs();
				var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(t);
				refE.SetParameters(dp);
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
			MaintenanceDirective mpd = _directivesViewer.SelectedItems[0];
			if (mpd == null || mpd.TaskCardNumberFile == null)
			{
				MessageBox.Show("Not set Task Card File", (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				return;
			}

			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(mpd.TaskCardNumberFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					$"Error while Open Attached File for {mpd}, id {mpd.ItemId}. \nFileId {mpd.TaskCardNumberFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;
			List<MaintenanceDirective> directives = _directivesViewer.SelectedItems.ToList();

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].TaskNumberCheck + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();

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
			_directivesViewer = new MaintenanceDirectiveFleetListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemShowTaskCard);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemShowTaskCard.Enabled = false;
				}
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;

					MaintenanceDirective mpd = _directivesViewer.SelectedItems[0];
					if (mpd != null && mpd.TaskCardNumberFile != null)
						_toolStripMenuItemShowTaskCard.Enabled = true;
					else _toolStripMenuItemShowTaskCard.Enabled = false;
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuItemShowTaskCard.Enabled = true;
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
			headerControl.ShowSaveButton = false;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = _directivesViewer.GetItemsArray().Cast<BaseEntityObject>().Where(o => o.ItemId <= 0).ToList();

			try
			{
				foreach (BaseEntityObject entityObject in unsaved)
				{
					GlobalObjects.CasEnvironment.Keeper.SaveAll(entityObject, true);
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
			CommonFilterForm form = new CommonFilterForm(_additionalFilter, _initialDirectiveArray);

			if(form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonShowEquipmentAndMaterialsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var mpdIds = _resultDirectiveArray.Select(mpd => mpd.ItemId).ToList();

			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = $"{CurrentAircraft.RegistrationNumber} .Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft, mpdIds);
		}

		#endregion

		#region private void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<MaintenanceDirective> initialCollection, ICommonCollection<MaintenanceDirective> resultCollection)
		{
		   if (_additionalFilter == null || _additionalFilter.All(i => i.Values.Length == 0))
		   {
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
		   }

		   resultCollection.Clear();

			foreach (MaintenanceDirective pd in initialCollection)
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

		public void CalculateMaintenanceDirectives(IList<MaintenanceDirective> maintenanceDirectives, Dictionary<IBindedItem, List<IDirective>> bindedItemsDict)
		{
			foreach (var mpd in maintenanceDirectives)
			{
				if (mpd.ItemId == 63278)
					MessageBox.Show("qwe");


				
				GlobalObjects.PerformanceCalculator.GetNextPerformance(mpd);

				if (bindedItemsDict.ContainsKey(mpd))
				{
					var bindedItems = bindedItemsDict[mpd];
					foreach (var bindedItem in bindedItems)
					{
						if (bindedItem is ComponentDirective)
						{
							GlobalObjects.PerformanceCalculator.GetNextPerformance(bindedItem);

							var firstNextPerformance =
								bindedItemsDict[mpd].SelectMany(t => t.NextPerformances).OrderBy(n => n.NextPerformanceDate).FirstOrDefault();

							if (firstNextPerformance == null)
								continue;
							mpd.BindedItemNextPerformance = firstNextPerformance;
							mpd.BindedItemNextPerformanceSource = firstNextPerformance.NextPerformanceSource ?? Lifelength.Null;
							mpd.BindedItemRemains = firstNextPerformance.Remains ?? Lifelength.Null;
							mpd.BindedItemNextPerformanceDate = firstNextPerformance.NextPerformanceDate;
							mpd.BindedItemCondition = firstNextPerformance.Condition ?? ConditionState.NotEstimated;
						}
					}
				}

				_initialDirectiveArray.Add(mpd);
			}

			
		}

		private void ExportMpd_Click(object sender, EventArgs eventArgs)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportMpdWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportMpdWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load MPD");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportMpd(_resultDirectiveArray.ToList());
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

		private void ButtonFilterClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
