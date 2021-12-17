using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using Telerik.WinControls.UI;


namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class MonthlyUtilizationListScreen : ScreenControl
	{
		#region Fields

		private AircraftFlightCollection _initialDirectiveArray = new AircraftFlightCollection();
		private AircraftFlightCollection _resultDirectiveArray = new AircraftFlightCollection();

		private List<MaintenanceCheck> _maintenanceChecks = new List<MaintenanceCheck>();
		private List<WorkPackage> _workPackages = new List<WorkPackage>();

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(IMounthlyUtilizationFilter));

		private MouthlyUtilizationListView _directivesViewer;

		private ContextMenuStrip buttonPrintMenuStrip;
		private ToolStripMenuItem itemPrintReportMonthlyUtilization;
		private ToolStripMenuItem itemPrintReportOperationTime;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator2;

		#endregion

		#region Constructors

		#region private MonthlyUtilizationListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private MonthlyUtilizationListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public MonthlyUtilizationListScreen(Aircraft aircraft)  : this()
		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="aircraft">Самолет, соержащий полеты</param>
		public MonthlyUtilizationListScreen(Aircraft aircraft)
			: this()
		{
			if (aircraft == null)
				throw new ArgumentNullException("aircraft", "Cannot display null-aircraft");

			CurrentAircraft = aircraft;
			StatusTitle = CurrentAircraft + " " + "Fligths";

			#region ButtonPrintContextMenu

			buttonPrintMenuStrip = new ContextMenuStrip();
			itemPrintReportMonthlyUtilization = new ToolStripMenuItem { Text = "Monthly Utilization" };
			itemPrintReportOperationTime = new ToolStripMenuItem { Text = "Operation Time" };
			buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportMonthlyUtilization, itemPrintReportOperationTime });

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

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;

			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
			if (_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
			
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;

			//вычисление периода в днях
			var periodDays = (dateTimePickerDateTo.Value - dateTimePickerDateFrom.Value).Days;
			//вычисление сред. кол-ва часов в день
			var totalHoursClear = GlobalObjects.CasEnvironment.Calculator.GetTotalHours(_resultDirectiveArray);
			var avgHoursPerDay = totalHoursClear / periodDays;
			//вычисление сред. кол-ва циклов в день
			var totalCycleClear = GlobalObjects.CasEnvironment.Calculator.GetTotalCycles(_resultDirectiveArray);
			var avgCyclesPerDay = (double)totalCycleClear / periodDays;
			//плановая утилизация
			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(CurrentAircraft.AircraftFrameId);
			var plan = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame); ;
			//вычисление фактической утилизации
			AverageUtilization factPerPeriod;
			if (plan.SelectedInterval == UtilizationInterval.Dayly)
			{
				factPerPeriod = new AverageUtilization(avgCyclesPerDay, avgHoursPerDay,
													   UtilizationInterval.Dayly);
			}
			else
			{
				factPerPeriod = new AverageUtilization(avgCyclesPerDay * 30, avgHoursPerDay * 30,
													   UtilizationInterval.Monthly);
			}

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

			labelAvgUtilization.Text = "Avg. Utilz. Plan:" + plan.CustomToString() + " Avg. Utilz. Fact per period: " + factPerPeriod;

			_directivesViewer.SetItemsArray(_resultDirectiveArray.OrderBy(i => i.TakeOffTime).ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Fligths");

			GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(CurrentAircraft.ItemId);

			var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(CurrentAircraft.ItemId);
			_initialDirectiveArray.AddRange(flights.Where(t => t.FlightDate >= dateTimePickerDateFrom.Value &&
													t.FlightDate <= dateTimePickerDateTo.Value));
			_maintenanceChecks = new List<MaintenanceCheck>(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MaintenanceCheckDTO, MaintenanceCheck>(new List<Filter>()
			{
				new Filter("ParentAircraft",CurrentAircraft.ItemId),
				new Filter("Grouping", true)
			}, true));
			AnimatedThreadWorker.ReportProgress(40, "filter Fligths");

			AnimatedThreadWorker.ReportProgress(70, "filter Fligths");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

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
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			// 
			// _toolStripMenuItemOpen
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			_toolStripMenuItemOpen.Enabled = false;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
			_toolStripMenuItemHighlight.Items.Clear();
			foreach (Highlight highlight in Highlight.HighlightList)
			{
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

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			foreach (AircraftFlight o in _directivesViewer.SelectedItems)
			{
				ReferenceEventArgs refE = new ReferenceEventArgs
				{
					TypeOfReflection = ReflectionTypes.DisplayInNew,
					DisplayerText = CurrentAircraft.RegistrationNumber + ". " + o,
					RequestedEntity = new FlightScreen(o)
				};
				InvokeDisplayerRequested(refE);
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null)
				return;
			DialogResult confirmResult = MessageBox.Show(_directivesViewer.SelectedItem != null
						? "Do you really want to delete aircraft flight " + _directivesViewer.SelectedItem.FlightNumber + "?"
						: "Do you really want to delete selected aircraft flights? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (confirmResult == DialogResult.Yes)
			{
				try
				{
					List<AircraftFlight> selectedItems = new List<AircraftFlight>(_directivesViewer.SelectedItems);
					_directivesViewer.radGridView1.BeginUpdate();
					GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

					GlobalObjects.CasEnvironment.Calculator.ResetMath(CurrentAircraft);

					_directivesViewer.radGridView1.EndUpdate();
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			var col = new CommonCollection<ATLB>(GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(CurrentAircraft.ItemId));
			_directivesViewer = new MouthlyUtilizationListView(CurrentAircraft, col);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator1,
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

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			headerControl.PrintButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
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
				var f = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(CurrentAircraft.ItemId);
				if (f != null)
				{
					dateTimePickerDateFrom.Value = f.FlightDate.Month == 1
						? new DateTime(f.FlightDate.Year - 1, 12, 1)
						: new DateTime(f.FlightDate.Year, f.FlightDate.Month - 1, 1);
				}
				else
				{
					dateTimePickerDateFrom.Value = DateTime.Now.Month == 1
						? new DateTime(DateTime.Now.Year - 1, 12, 1)
						: new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
				}
			}
			else
			{
				dateTimePickerDateFrom.Value = DateTime.Now.Month == 1
					? new DateTime(DateTime.Now.Year - 1, 12, 1)
					: new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
			}

			AnimatedThreadWorker.RunWorkerAsync();
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
			if (CurrentAircraft != null)
				e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + ReportText + " Report";
			else
			{
				e.DisplayerText = ReportText + " Report";
				e.Cancel = true;
				return;
			}
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == itemPrintReportMonthlyUtilization)
			{
#if KAC
				MonthlyUtilizationBuilderKAC reportBuilder =
					new MonthlyUtilizationBuilderKAC(CurrentAircraft,
												  dateTimePickerDateFrom.Value,
												  dateTimePickerDateTo.Value,
												  _initialDirectiveArray.TotalHoursClear,
												  _initialDirectiveArray.TotalCyclesClear);
#else
				MonthlyUtilizationBuilder reportBuilder =
					new MonthlyUtilizationBuilder(CurrentAircraft,
												  dateTimePickerDateFrom.Value,
												  dateTimePickerDateTo.Value,
												  GlobalObjects.CasEnvironment.Calculator.GetTotalHours(_initialDirectiveArray),
												  GlobalObjects.CasEnvironment.Calculator.GetTotalCycles(_initialDirectiveArray));
#endif
				reportBuilder.Flights = _initialDirectiveArray.OrderByDescending(f => f.FlightDate.AddMinutes(f.FlightTime.TotalMinutes)).ToList();
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = CurrentAircraft.RegistrationNumber + " Monthly Utilization Report";
				e.RequestedEntity = new ReportScreen(reportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MonthlyUtilizationListScreen (Monthly Utilization)");
			}
			else if (sender == itemPrintReportOperationTime)
			{
				_workPackages = GlobalObjects.WorkPackageCore.GetWorkPackagesLite(CurrentAircraft, WorkPackageStatus.Closed, _maintenanceChecks.Select(m => (IDirective)m).ToList());

				var records =
					_maintenanceChecks.SelectMany(mc => mc.PerformanceRecords)
									  .Where(pr => pr.RecordDate.Date >= dateTimePickerDateFrom.Value.Date &&
												   pr.RecordDate.Date <= dateTimePickerDateTo.Value.Date)
									  .ToList();

				var lastCCheckRecord =
				 _maintenanceChecks.SelectMany(mc => mc.PerformanceRecords)
									  .Where(pr => pr.RecordDate.Date <= dateTimePickerDateTo.Value.Date)
									  .OrderByDescending(pr => pr.RecordDate)
									  .FirstOrDefault();

				var maintenanceCheckRecordGroups = new List<MaintenanceCheckRecordGroup>();

				foreach (MaintenanceCheckRecord record in records)
				{
					//Поиск коллекции групп, в которую входят группы с нужными критериями
					//по плану, группировка и основному ресурсу
					if (record.ParentCheck.Grouping)
					{
						MaintenanceCheckRecordGroup recordGroup = maintenanceCheckRecordGroups
									.FirstOrDefault(g => g.Schedule == record.ParentCheck.Schedule &&
														 g.Grouping == record.ParentCheck.Grouping &&
														 g.Resource == record.ParentCheck.Resource &&
														 g.GroupComplianceNum == record.NumGroup);
						if (recordGroup != null)
						{
							//Коллекция найдена
							//Поиск в ней группы чеков с нужным типом
							recordGroup.Records.Add(record);
						}
						else
						{
							//Коллекции с нужными критериями нет
							//Созадние и добавление
							recordGroup =
								new MaintenanceCheckRecordGroup(record.ParentCheck.Schedule, record.ParentCheck.Grouping,
																 record.ParentCheck.Resource, record.NumGroup);
							recordGroup.Records.Add(record);
							maintenanceCheckRecordGroups.Add(recordGroup);
						}
					}
					else
					{
						MaintenanceCheckRecordGroup recordGroup =
								new MaintenanceCheckRecordGroup(record.ParentCheck.Schedule, record.ParentCheck.Grouping,
																record.ParentCheck.Resource);
						recordGroup.Records.Add(record);
						maintenanceCheckRecordGroups.Add(recordGroup);
					}
				}

				OperationTimeReportBuilder reportBuilder =
					new OperationTimeReportBuilder(CurrentAircraft,
												   maintenanceCheckRecordGroups,
												   GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId),
												   lastCCheckRecord,
												   _workPackages,
												   dateTimePickerDateFrom.Value.Date,
												   dateTimePickerDateTo.Value.Date);

				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = CurrentAircraft.RegistrationNumber + " Operation Time Report";
				e.RequestedEntity = new ReportScreen(reportBuilder);
				GlobalObjects.AuditRepository.WriteReportAsync(GlobalObjects.CasEnvironment.IdentityUser, "MonthlyUtilizationListScreen (Operation Time)");
			}
			else
			{
				e.Cancel = true;
			}

		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//Aircraft a = CurrentAircraft;

			//if (a == null) return;
			//e.RequestedEntity = new FlightScreen(_currentATLB, a);
			//e.DisplayerText = a.RegistrationNumber + ". New Flight";
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
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

		#region private void FilterItems(IEnumerable<Discrepancy> initialCollection, ICommonCollection<Discrepancy> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(CommonCollection<AircraftFlight> initialCollection, CommonCollection<AircraftFlight> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				foreach (var flight in initialCollection)
					resultCollection.Add(flight);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
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
