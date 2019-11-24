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
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.Fleet
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class ComponentsFleetListScreen : ScreenControl
	{
		#region Fields

		private bool _firstLoad;

		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();
		private CommonCollection<RequestForQuotation> _openPubQuotations = new CommonCollection<RequestForQuotation>();

		private ComponentsFleetListView _directivesViewer;

		private CommonFilterCollection _initialFilter;
		private CommonFilterCollection _additionalfilter = new CommonFilterCollection(typeof(IComponentFilterParams));
		private ComponentCollection _initialDirectiveArray = new ComponentCollection();
		private ICommonCollection<BaseEntityObject> _preResultDirectiveArray = new CommonCollection<BaseEntityObject>();
		private ICommonCollection<BaseEntityObject> _resultDirectiveArray = new CommonCollection<BaseEntityObject>();

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;

		#endregion

		#region Properties
		/// <summary>
		/// Контейнер директив
		/// </summary>
		private BaseEntityObject DirectiveSource
		{
			get
			{
				return aircraftHeaderControl1.Operator;
			}
		}

		#endregion

		#region Constructors

		#region private DetailsListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private ComponentsFleetListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public DetailsListScreen(Operator currentOperator, IEnumerable<ICommonFilter> initialFilters)  : this()

		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="currentOperator">Оператор, содержащее агрегаты</param>
		///<param name="initialFilters"></param>
		public ComponentsFleetListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");

			aircraftHeaderControl1.Operator = currentOperator;
			headerControl.ShowForecastButton = false;
			labelTitle.Visible = false;

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
			_openPubWorkPackages.Clear();
			_openPubQuotations.Clear();
			//_deferredCategories.Clear();

			_resultDirectiveArray = null;
			_preResultDirectiveArray = null;
			_openPubWorkPackages = null;
			_openPubQuotations = null;
			//_deferredCategories = null;


			if (_initialFilter != null)
			{
				_initialFilter.Filters.Clear();
				_initialFilter = null;
			}


			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
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

			var res = new List<BaseEntityObject>();
			foreach (var item in _resultDirectiveArray)
			{
				if (item is Component)
				{
					var c = item as Component;
					var a = GlobalObjects.AircraftsCore.GetAircraftById(c.ParentBaseComponent?.ParentAircraftId ?? -1);

					if(a == null)
						continue;

					res.Add(item);

					var component = item as Component;
					var items = _resultDirectiveArray.Where(lvi =>
						lvi is ComponentDirective &&
						((ComponentDirective)lvi).ComponentId == component.ItemId);
					res.AddRange(items);
				}
			}

			_directivesViewer.SetItemsArray(res.ToArray());
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_preResultDirectiveArray.Clear();
			_resultDirectiveArray.Clear();

			if (!string.IsNullOrEmpty(TextBoxFilter.Text))
			{

				ComponentCollection preResult = new ComponentCollection();
				ComponentCollection componentCollection = new ComponentCollection();

				var temp = GlobalObjects.ComponentCore.GetComponentsAll(TextBoxFilter.Text).ToArray();

				foreach (var component in temp)
				{
					var a = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentBaseComponent?.ParentAircraftId ?? -1);
					if(a != null)
						componentCollection.Add(component);
				}

				var ids = new List<int>();

				foreach (var component in componentCollection)
				{
					var lastTr = component.TransferRecords.GetLast();

					if(lastTr?.DestinationObjectType == SmartCoreType.BaseComponent)
						component.ParentBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(lastTr.DestinationObjectId);

					foreach (var componentDirective in component.ComponentDirectives)
					{
						foreach (var items in componentDirective.ItemRelations.Where(i =>
							i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId ||
							i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
						{
							ids.Add(componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId);
						}
					}
				}


				var mpd = GlobalObjects.MaintenanceCore.GetMaintenanceDirectiveList(ids);
				foreach (var component in componentCollection)
				{
					foreach (var componentDirective in component.ComponentDirectives)
					{
						foreach (var items in componentDirective.ItemRelations.Where(i =>
							i.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId ||
							i.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
						{
							var id = componentDirective.IsFirst == true ? items.SecondItemId : items.FirstItemId;
							componentDirective.MaintenanceDirective = mpd.FirstOrDefault(i => i.ItemId == id);
						}
					}
				}


				AnimatedThreadWorker.ReportProgress(50, "filter components");

				InitialFilterItems(componentCollection, _initialDirectiveArray);

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
						new CommonFilter<int>(ComponentLLPCategoryData.ComponentIdProperty,
							SmartCore.Filters.FilterType.In, _initialDirectiveArray.Select(i => i.ItemId).ToArray()),
					});

				var llpchangeRec = GlobalObjects.CasEnvironment.Loader
					.GetObjectList<ComponentLLPCategoryChangeRecord>(new ICommonFilter[]
					{
						new CommonFilter<int>(ComponentLLPCategoryChangeRecord.ParentIdProperty,
							SmartCore.Filters.FilterType.In, _initialDirectiveArray.Select(i => i.ItemId).ToArray()),
					});

				foreach (Component detail in _initialDirectiveArray)
				{
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

				AnimatedThreadWorker.ReportProgress(100, "Complete");
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
			_toolStripSeparator1 = new RadMenuSeparatorItem();
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
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ButtonDeleteClick;



			_contextMenuStrip.Items.Clear();


			_contextMenuStrip.Items.AddRange(_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemDelete);

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
				try
				{
					_directivesViewer.radGridView1.BeginUpdate();
					GlobalObjects.CasEnvironment.NewKeeper.Delete(_directivesViewer.SelectedItems.Where(i => i is Component).OfType<BaseEntityObject>().ToList(), true);
					GlobalObjects.CasEnvironment.NewKeeper.Delete(_directivesViewer.SelectedItems.Where(i => i is ComponentDirective).OfType<BaseEntityObject>().ToList(), true);
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
			_directivesViewer = new ComponentsFleetListView();
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
				if (_directivesViewer.SelectedItems.Count == 0)
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemDelete.Enabled = false;
				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
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


		#region Export Component Status

		private void ButtonExportComponent_Click(object sender, EventArgs e)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportComponentWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportComponentWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load Components");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportComponent(_resultDirectiveArray.ToList());
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
