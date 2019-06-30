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
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.WorkPakage
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class WorkPackageListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<WorkPackage> _initialDirectiveArray = new CommonCollection<WorkPackage>();
		private CommonCollection<WorkPackage> _resultDirectiveArray = new CommonCollection<WorkPackage>();

		private WorkPackageListView _directivesViewer;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(WorkPackage));

#if KAC
		private WorkscopeReportBuilderKAC _workscopeReportBuilder = new WorkscopeReportBuilderKAC();
#else
		private WorkscopeReportBuilder _workscopeReportBuilder = new WorkscopeReportBuilder();
		private MaintenanceReportBuilder _maintenanceReportBuilder = new MaintenanceReportBuilder();
#endif

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemEditProvider;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemPrintWP;
		private RadMenuItem _toolStripMenuItemPrintWorkscope;
		private RadMenuItem _toolStripMenuItemPrintMaintenanceReport;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private List<RadMenuItem> _toolStripMenuItemsWorkPackages;
		private RadMenuItem _toolStripMenuItemHighlight;

		#endregion

		#region Constructors

		#region public WorkPackageListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public WorkPackageListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public WorkPackageListScreen(Aircraft currentAircraft)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public WorkPackageListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			CurrentAircraft = currentAircraft;
			StatusTitle = currentAircraft.RegistrationNumber + " " + "Work packages";

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

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;

			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (var item in _toolStripMenuItemsWorkPackages)
					item.Dispose();
			}

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			if (_toolStripMenuItemPublish != null) _toolStripMenuItemPublish.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			if (_toolStripMenuItemPrintWP != null) _toolStripMenuItemPrintWP.Dispose();
			if (_toolStripMenuItemPrintWorkscope != null) _toolStripMenuItemPrintWorkscope.Dispose();
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();

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

			AnimatedThreadWorker.ReportProgress(0, "load Work Packages");

			_initialDirectiveArray.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(CurrentAircraft).ToArray());

			var airports = GlobalObjects.CasEnvironment.GetDictionary<AirportsCodes>();
			var flightNum = GlobalObjects.CasEnvironment.GetDictionary<FlightNum>();
			foreach (var wp in _initialDirectiveArray)
			{
				wp.PerfAfter.AirportFrom = (AirportsCodes) airports.GetItemById(wp.PerfAfter.AirportFromId);
				wp.PerfAfter.AirportTo = (AirportsCodes)airports.GetItemById(wp.PerfAfter.AirportToId);
				wp.PerfAfter.FlightNum = (FlightNum)flightNum.GetItemById(wp.PerfAfter.FlightNumId);
			}

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

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

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new List<RadMenuItem>();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemEditProvider = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripMenuItemPrintWP = new RadMenuItem();
			_toolStripMenuItemPrintWorkscope = new RadMenuItem();
			_toolStripMenuItemPrintMaintenanceReport = new RadMenuItem();
			_toolStripMenuItemOpen = new RadMenuItem();
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
			// toolStripMenuItemView
			// 
			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
			// 
			// _toolStripMenuItemEditProvider
			// 
			_toolStripMenuItemEditProvider.Text = "Overview Providers";
			_toolStripMenuItemEditProvider.Click += ToolStripMenuItemEditProviderClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			// 
			// toolStripMenuItemPrintWP
			// 
			_toolStripMenuItemPrintWP.Text = "Overview the work package";
			_toolStripMenuItemPrintWP.Click += ToolStripMenuItemDeletePrintWP;
			// 
			// toolStripMenuItemPrintWorkscope
			// 
			_toolStripMenuItemPrintWorkscope.Text = "Overview the work scope";
			_toolStripMenuItemPrintWorkscope.Click += ToolStripMenuItemDeletePrintWorkscope;
			// 
			// toolStripMenuItemPrintWorkscope
			// 
			_toolStripMenuItemPrintMaintenanceReport.Text = "Overview the maintenance report";
			_toolStripMenuItemPrintMaintenanceReport.Click += _toolStripMenuItemPrintMaintenanceReport_Click;
			;

			_contextMenuStrip.Items.Clear();
			_toolStripMenuItemsWorkPackages.Clear();
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (var highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				var item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}

			_contextMenuStrip.Items.AddRange(new RadItem[]
			{
				_toolStripMenuItemPublish,
				_toolStripMenuItemClose,
				_toolStripSeparator1,
				_toolStripMenuItemEdit,
				_toolStripMenuItemEditProvider,
				_toolStripMenuItemOpen,
				_toolStripMenuItemDelete,
				_toolStripSeparator1,
				_toolStripMenuItemPrintWP,
				_toolStripMenuItemPrintWorkscope,
				_toolStripMenuItemPrintMaintenanceReport,
				_toolStripSeparator2,
				_toolStripMenuItemHighlight
			});
		}

		private void ToolStripMenuItemEditProviderClick(object sender, EventArgs e)
		{
			var form = new WpProviderForm(_directivesViewer.SelectedItem);

			if (form.ShowDialog() == DialogResult.OK)
			{
				GlobalObjects.CasEnvironment.NewKeeper.Save(_directivesViewer.SelectedItem);
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void _toolStripMenuItemPrintMaintenanceReport_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPrintMaintenanceReport_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			_maintenanceReportBuilder.ReportedAircraft = CurrentAircraft;

			var wp = _directivesViewer.SelectedItem;
			GlobalObjects.WorkPackageCore.LoadWorkPackageItems(wp);
			_maintenanceReportBuilder.ReportedWorkPackage = wp;

			var refE = new ReferenceEventArgs();
			refE.DisplayerText = "Maintenance Report";
			refE.RequestedEntity = new ReportScreen(_maintenanceReportBuilder);
			refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			InvokeDisplayerRequested(refE);
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

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (var i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				var highLight = (Highlight)((RadMenuItem)sender).Tag;
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
			foreach (var o in _directivesViewer.SelectedItems)
			{
				var refE = new ReferenceEventArgs();
				refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refE.DisplayerText = CurrentAircraft != null ? CurrentAircraft.RegistrationNumber + "." + o.Title : o.Title;
				refE.RequestedEntity = new WorkPackageScreen(o);
				InvokeDisplayerRequested(refE);
			}
		}

		#endregion

		#region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				var form = new WorkPackageEditorForm(_directivesViewer.SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
					AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		{
			foreach (var item in _directivesViewer.SelectedItems)
			{
				var wp = item;
				if (wp.Status != WorkPackageStatus.Closed)
					GlobalObjects.WorkPackageCore.Publish(item, DateTime.Now, "");
				else
				{
					switch (MessageBox.Show(@"This work package is already closed," +
											 "\nif you want to republish it," +
											 "\nrecordings created during its execution will be erased." + "\n\n Republish " + wp.Title + " work package?", (string)new GlobalTermsProvider()["SystemName"],
										MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
										MessageBoxDefaultButton.Button2))
					{
						case DialogResult.Yes:
							GlobalObjects.WorkPackageCore.Publish(item, DateTime.Now, "");
							break;
						case DialogResult.No:
							//arguments.Cancel = true;
							break;
					}
				}
			}

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		{
			DeleteWorkPackage();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		/// <summary>
		/// Запрашивает распечатку рабочего пакета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemDeletePrintWP(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			var wp = _directivesViewer.SelectedItem;
			if (wp.WorkPackageItemsLoaded == false)
				GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(wp);

			var form = new SelectWPPrintTasksForm(wp);
			form.ShowDialog();
		}

		#endregion

		#region private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeletePrintWorkscope(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			var wp = _directivesViewer.SelectedItem;
			if (wp.WorkPackageItemsLoaded == false)
				GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(wp);

			var form = new SelectWorkscopePrintTasksForm(wp);
			if (form.ShowDialog() != DialogResult.OK)
				return;

			var refE = new ReferenceEventArgs();

			_workscopeReportBuilder.ReportedAircraft = CurrentAircraft;
			_workscopeReportBuilder.WorkPackage = wp;
			_workscopeReportBuilder.AddDirectives(form.SelectedItems);
			refE.DisplayerText = CurrentAircraft.RegistrationNumber + "." + wp.Title + "." + "Workscope";
			refE.RequestedEntity = new ReportScreen(_workscopeReportBuilder);
			refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			InvokeDisplayerRequested(refE);
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			var dlgResult = DialogResult.No;

			foreach (var item in _directivesViewer.SelectedItems)
			{
				if (item.Status == WorkPackageStatus.Closed)
				{
					MessageBox.Show("Work package " + item.Title + " is already closed.",
									(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					continue;
				}

				if (item.WorkPackageItemsLoaded == false)
					GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(item);

				var blockedRecords =
				item.WorkPakageRecords
				.Where(rec => rec.Task != null &&
							  rec.Task.NextPerformances != null &&
							  rec.Task.NextPerformances.Count > 0 &&
							  rec.Task.NextPerformances.Where(np => np.BlockedByPackage != null &&
																	np.BlockedByPackage.ItemId != item.ItemId).Count() > 0);
				if (item.CanClose == false || blockedRecords.Count() > 0)
				{
					var message = "This work package can not be closed";
					foreach (var blockedRecord in blockedRecords)
					{
						var np = blockedRecord.Task.NextPerformances.First(n => n.BlockedByPackage != null);
						message += string.Format("\nTask: {0} blocked by work package {1}",
													blockedRecord.Task,
													np.BlockedByPackage);
					}
					if (item.MaxClosingDate < item.MinClosingDate)
					{
						message += string.Format("\nMin Closing Date: {0} better than Max Closing Date: {1}",
													item.MinClosingDate,
													item.MaxClosingDate);
					}
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					continue;
				}

				var form = new WorkPackageClosingFormNew(item);
				form.ShowDialog();
				if (form.DialogResult == DialogResult.OK)
				{
					dlgResult = DialogResult.OK;
				}
			}

			//Если хотя бы одно окно возвратило DialogResult.OK
			//производится перезагрузка элементов
			if (dlgResult == DialogResult.OK)
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
			DeleteWorkPackage();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new WorkPackageListView();
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
				_toolStripMenuItemEditProvider.Enabled = false;
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuItemEditProvider.Enabled = true;
					_toolStripMenuItemPrintMaintenanceReport.Enabled = _directivesViewer.SelectedItem.Status == WorkPackageStatus.Closed;
				}
			};

			
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DeleteWorkPackage()

		private void DeleteWorkPackage()
		{
			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0) return;

			var confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete Work package " + _directivesViewer.SelectedItems[0].Title + "?"
						: "Do you really want to delete selected Work packages? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();

				foreach (var item in _directivesViewer.SelectedItems)
				{
					try
					{
						GlobalObjects.CasEnvironment.Manipulator.Delete(item);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while deleting data", ex);
						return;
					}
				}
				_directivesViewer.radGridView1.EndUpdate();

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
			var form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
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
		private void FilterItems(IEnumerable<WorkPackage> initialCollection, ICommonCollection<WorkPackage> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
				//}
				if (_filter.FilterTypeAnd)
				{
					var acceptable = true;
					foreach (var filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					var acceptable = true;
					foreach (var filter in _filter)
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

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count > 0)
			{
				buttonDeleteSelected.Enabled = true;
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				buttonDeleteSelected.Enabled = false;
			}
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
			IEnumerable<WorkPackage> list = _directivesViewer.GetItemsArray();
			var reportBuilder = new WorkPackageListReportBuilder { ReportedAircraft = CurrentAircraft };
			reportBuilder.AddDirectives(list.ToArray());

			e.DisplayerText = "Work Package List";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new ReportScreen(reportBuilder);
			GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "WorkPackageListScreen (Work Package List)");
		}
		#endregion

		#region private void ButtonReleaseToService(object sender, EventArgs e)

		private void ButtonReleaseToService(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			var wp = _directivesViewer.SelectedItem;
			GlobalObjects.WorkPackageCore.LoadWorkPackageItems(wp);

			//ConcatenatePdfDocuments(wp);

			var form = new SelectWPPrintTasksForm(wp);
			form.ShowDialog();
			//e.Cancel = true;
		}

		#endregion

		#region private void ForecastMenuClick(object sender, EventArgs e)
		private void ForecastMenuClick(object sender, EventArgs e)
		{
		}
		#endregion

		#endregion
	}
}
