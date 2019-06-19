using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsRecordListScreen : ScreenControl
	{
		#region Fileds

		private CommonCollection<FlightPlanOpsRecords> _initialFlightOpsRecordArray = new CommonCollection<FlightPlanOpsRecords>();
		private CommonCollection<FlightPlanOpsRecords> _resultFlightOpsRecordArray = new CommonCollection<FlightPlanOpsRecords>();

		private List<int> aircrafts = new List<int>();

		private readonly FlightPlanOps _currentPlanOps;
		private readonly bool _calculated;
		private FlightPlanOpsRecordListView _directivesViewer;

		private CommonFilterCollection _filter;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemAddAircraft;
		private RadMenuItem _toolStripMenuItemOpenFlight;

		#endregion

		#region Constructor

		public FlightPlanOpsRecordListScreen()
		{
			InitializeComponent();
		}

		public FlightPlanOpsRecordListScreen(Operator currentOperator, FlightPlanOps currentPlanOps, bool calculated = false) :this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_currentPlanOps = currentPlanOps;
			_calculated = calculated;
			aircraftHeaderControl1.Operator = currentOperator;
			statusControl.ShowStatus = false;


			_filter = new CommonFilterCollection(typeof(IFlightPlanOpsRecordsFilterParams));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultFlightOpsRecordArray.Where(i => i.FlightTrackRecord != null).ToArray());
			_directivesViewer.Focus();

			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
		}

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialFlightOpsRecordArray.Clear();
			_resultFlightOpsRecordArray.Clear();
			aircrafts.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			try
			{
				_initialFlightOpsRecordArray.AddRange(GlobalObjects.PlanOpsCalculator.LoadOpsRecordsByPlanOpsId(_currentPlanOps.ItemId));
				var calculatedItem = GlobalObjects.PlanOpsCalculator.CalculateTripForPeriod(_currentPlanOps);


				if (_initialFlightOpsRecordArray.Count <= 0)
				{
					_initialFlightOpsRecordArray.AddRange(calculatedItem);
					foreach (var rec in calculatedItem)
						GlobalObjects.CasEnvironment.NewKeeper.Save(rec);
				}
				else
				{
					foreach (var rec in calculatedItem.Where(i => _initialFlightOpsRecordArray.All(q => q.FlightTrackRecordId != i.FlightTrackRecordId)))
					{
						GlobalObjects.CasEnvironment.NewKeeper.Save(rec);
						_initialFlightOpsRecordArray.Add(rec);
					}
				}

				AnimatedThreadWorker.ReportProgress(50, "load Aircraft Flights");

				if (_calculated)
				{
					aircrafts.AddRange(_initialFlightOpsRecordArray.Select(i => i.AircraftId).Distinct());
					aircrafts.AddRange(_initialFlightOpsRecordArray.Select(i => i.AircraftExchangeId).Distinct());
					foreach (var aircraft in aircrafts.Distinct())
						GlobalObjects.AircraftFlightsCore.LoadAircraftFlightsLight(aircraft);
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(70, "filter records");

			FilterItems(_initialFlightOpsRecordArray, _resultFlightOpsRecordArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion


			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#region protected override void InitListView()

		private void InitListView()
		{
			_directivesViewer = new FlightPlanOpsRecordListView(_calculated, AnimatedThreadWorker);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.CustomMenu = _contextMenuStrip;

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;

				if (_directivesViewer.SelectedItems.Count == 1)
					_toolStripMenuItemOpenFlight.Enabled = _directivesViewer.SelectedItem.ParentFlight != null;
				else _toolStripMenuItemOpenFlight.Enabled = false;

				_toolStripMenuItemAddAircraft.Enabled = _directivesViewer.SelectedItems.Count > 0;
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			_directivesViewer.ClearFields();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialFlightOpsRecordArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				_directivesViewer.ClearFields();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultFlightOpsRecordArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialFlightOpsRecordArray, _resultFlightOpsRecordArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightPlanOpsRecords> initialCollection, ICommonCollection<FlightPlanOpsRecords> resultCollection)
		{
			if (_filter == null || _filter.Count == 0)
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
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

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemAddAircraft = new RadMenuItem();
			_toolStripMenuItemOpenFlight = new RadMenuItem();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemAddAircraft.Text = "Add Aircraft";
			_toolStripMenuItemAddAircraft.Click += _toolStripMenuItemAddAircraft_Click;
			// 
			// _toolStripMenuItemOpenFlight
			// 
			_toolStripMenuItemOpenFlight.Text = "Open Flight";
			_toolStripMenuItemOpenFlight.Click += _toolStripMenuItemOpenFlight_Click;

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(
				_toolStripMenuItemOpenFlight,
				new RadMenuSeparatorItem(), 
				_toolStripMenuItemAddAircraft
			);
		}

		private void _toolStripMenuItemOpenFlight_Click(object sender, EventArgs e)
		{
			var flight = _directivesViewer.SelectedItem.ParentFlight;
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_directivesViewer.SelectedItem.ParentFlight.AircraftId);
			var refE = new ReferenceEventArgs
			{
				TypeOfReflection = ReflectionTypes.DisplayInNew,
				DisplayerText = aircraft.RegistrationNumber + ". " + flight,
				RequestedEntity = new FlightScreen(flight)
			};
			InvokeDisplayerRequested(refE);
		}
		
		#endregion

		#region private void _toolStripMenuItemAddAircraft_Click(object sender, EventArgs e)

		private void _toolStripMenuItemAddAircraft_Click(object sender, EventArgs e)
		{
			var form = new AddAircraftPlanOpsForm(_directivesViewer.SelectedItems);
			if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		private void LinkUnSheduleDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "UnSchedule Flights";
			e.RequestedEntity = new FlightNumberListScreen(CurrentOperator, FlightNumberScreenType.UnSchedule);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		}

		private void LinkSheduleDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Schedule Flights";
			e.RequestedEntity = new FlightNumberListScreen(CurrentOperator, FlightNumberScreenType.Schedule);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		}
	}
}
