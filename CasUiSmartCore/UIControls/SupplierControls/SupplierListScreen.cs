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
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.SupplierControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class SupplierListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<Supplier> _initialDirectiveArray = new CommonCollection<Supplier>();
		private ICommonCollection<Supplier> _resultDirectiveArray = new CommonCollection<Supplier>();

		private CommonCollection<WorkPackage> _openPubWorkPackages = new CommonCollection<WorkPackage>();

		private Forecast _currentForecast;

		private SupplierListView _directivesViewer;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(Supplier));

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;

		private ContextMenuStrip _buttonPrintMenuStrip;
		private ToolStripMenuItem _itemPrintReportListOfApprovedSuppliers;
		private ToolStripMenuItem _itemPrintReportContacts;

		private ListOfApprovedSuppliersBuilder _listOfApprovedSuppliersBuilder;

		#endregion

		#region Constructors

		#region private SupplierListScreenNew()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private SupplierListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public SupplierListScreenNew(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>
		public SupplierListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;

			InitToolStripPrintMenuItems();
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
			_resultDirectiveArray.Clear();
			_openPubWorkPackages.Clear();

			_initialDirectiveArray = null;
			_resultDirectiveArray = null;
			_openPubWorkPackages = null;

			if (_currentForecast != null)
			{
				_currentForecast.Dispose();
				_currentForecast = null;
			}

			if (_currentForecast != null) _currentForecast.Clear();
			_currentForecast = null;

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null)
			{
				foreach (var ttmi in _toolStripMenuItemHighlight.Items)
				{
					ttmi.Click -= HighlightItemClick;
				}
				_toolStripMenuItemHighlight.Items.Clear();
				_toolStripMenuItemHighlight.Dispose();
			}
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			
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

			#region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			try
			{
				_initialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>(loadChild:true));
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

			#region Калькуляция состояния директив

			AnimatedThreadWorker.ReportProgress(40, "calculation of directives");

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

			#region Сравнение с рабочими пакетами

			AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

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
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
			_toolStripMenuItemHighlight.Items.Clear();

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
			if(_directivesViewer.SelectedItems.Count == 0)
				return;

			Supplier item = _directivesViewer.SelectedItems[0];

			SupplierForm form = new SupplierForm(item);

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;
			List<Supplier> directives = _directivesViewer.SelectedItems.ToList();

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].Name + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);
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
			_directivesViewer = new SupplierListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				new RadMenuSeparatorItem(),
				_toolStripMenuItemHighlight);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripPrintMenuItems()

		private void InitToolStripPrintMenuItems()
		{
			_buttonPrintMenuStrip = new ContextMenuStrip();
			_itemPrintReportListOfApprovedSuppliers = new ToolStripMenuItem { Text = "List of Approved Suppliers" };
			_itemPrintReportContacts = new ToolStripMenuItem { Text = "Contacts" };

			_buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_itemPrintReportListOfApprovedSuppliers, _itemPrintReportContacts,
			});

			ButtonPrintMenuStrip = _buttonPrintMenuStrip;
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

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == _itemPrintReportContacts)
			{
				_listOfApprovedSuppliersBuilder = new ListOfApprovedSuppliersBuilder(CurrentOperator, _directivesViewer.GetItemsArray(), "F SK 003A R0 30.08.2016", "CONTACTS");
				_listOfApprovedSuppliersBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Contacts";
				e.RequestedEntity = new ReportScreen(_listOfApprovedSuppliersBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "SupplierListScreen (Contacts)");
			}
			else if (sender == _itemPrintReportListOfApprovedSuppliers)
			{
				_listOfApprovedSuppliersBuilder = new ListOfApprovedSuppliersBuilder(CurrentOperator, _directivesViewer.GetItemsArray().Where(s => s.SupplierClass == SupplierClass.Vendor ||
																																				   s.SupplierClass == SupplierClass.Manufacturer), "F SK 003 R0 30.08.2016", "LIST OF APPROVED SUPPLIERS");
				_listOfApprovedSuppliersBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Approved of Supplier";
				e.RequestedEntity = new ReportScreen(_listOfApprovedSuppliersBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "SupplierListScreen (List of Approved Suppliers)");
			}

		   
		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.Cancel = true;

			SupplierForm form = new SupplierForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if(form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Supplier> initialCollection, ICommonCollection<Supplier> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Supplier pd in initialCollection)
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
