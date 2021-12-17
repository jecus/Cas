using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ScheduleControls.Trip;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ScheduleControls
{
	///<summary>
	/// Экран для отображения записей о неснижаемом запасе
	///</summary>
	[ToolboxItem(false)]
	public partial class FlightNumberListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<FlightNumber> _initialFlightsArray = new CommonCollection<FlightNumber>();
		private CommonCollection<FlightNumber> _resultFlightsArray = new CommonCollection<FlightNumber>();

		private CommonCollection<FlightNumberPeriod> _initialPeriodArray = new CommonCollection<FlightNumberPeriod>();
		private CommonCollection<FlightNumberPeriod> _resultPeriodArray = new CommonCollection<FlightNumberPeriod>();

		private List<IFlightNumberParams> _result = new List<IFlightNumberParams>();

		private FlightNumberListView _directivesViewer;
		private CommonFilterCollection _filter;

		private bool firstLoad;
		private bool filterPeriod;

		private FlightNumberScreenType _screenType;

		private RadMenuItem _toolStripMenuItemCreateTrip;

		#endregion

		#region Constructors

		#region public FlightNumberListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public FlightNumberListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public FlightNumberListScreen(Store currentStore, PropertyInfo beginGroup = null) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список неснижаемого запаса на складе
		///</summary>
		///<param name="currentOperator">Склад, которому принадлежат записи о неснижаемом запасе</param>
		///<param name="screenType"></param>
		public FlightNumberListScreen(Operator currentOperator, FlightNumberScreenType screenType) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Flights";
			statusControl.ShowStatus = false;
			labelTitle.Visible = false;
			_screenType = screenType;

			_filter = new CommonFilterCollection(typeof(IFlightFilterParams));
			firstLoad = true;

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;

			if (firstLoad)
			{
				if (_initialPeriodArray.Count > 0)
				{
					dateTimePickerDateFrom.Value = _initialPeriodArray.Min(f => f.DepartureDate);
					dateTimePickerDateTo.Value = _initialPeriodArray.Max(f => f.ArrivalDate);
				}
				else
				{
					dateTimePickerDateFrom.Value = DateTimeExtend.GetCASMinDateTime();
					dateTimePickerDateTo.Value = DateTime.Today;
				}
			}

			firstLoad = false;
			filterPeriod = false;

			foreach (var flightNumber in _resultFlightsArray.OrderBy(f => f.FlightNo.FullName))
			{
				var periods = _resultPeriodArray.Where(f => f.FlightNumberId == flightNumber.ItemId);
				if (periods.Any())
				{
					_result.Add(flightNumber);
					foreach (var period in periods)
					{
						_result.Add(period);
					}
				}	
			}

			var res = new List<IFlightNumberParams>();
			foreach (var item in _result)
			{
				if (item is FlightNumber)
				{
					res.Add(item as FlightNumber);

					var component = (FlightNumber)item;
					var items = _result
						.Where(lvi =>
							lvi is FlightNumberPeriod &&
							((FlightNumberPeriod)lvi).FlightNumberId == component.ItemId).Select(i => i);
					res.AddRange(items.OfType<FlightNumberPeriod>());
				}
			}

			_directivesViewer.SetItemsArray(res.ToArray());
			_directivesViewer.Focus();

			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов

			_initialFlightsArray.Clear();
			_resultFlightsArray.Clear();
			_result.Clear();
			_resultPeriodArray.Clear();
			_initialPeriodArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			try
			{
				var flightTypes = new List<int>();
				if (_screenType == FlightNumberScreenType.Schedule)
					flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId == FlightType.Schedule.ItemId).Select(i => i.ItemId));
				else flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId != FlightType.Schedule.ItemId).Select(i => i.ItemId));

				CommonFilter<int> filter;
				if(isAllRadioButton.Checked)
					filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, FilterType.In, new []{0,1, -1});
				else if(isWinterRadioButton.Checked)
					filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 0);
				else filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 1);

				
				_initialFlightsArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<FlightNumberDTO, FlightNumber>(new Filter("FlightType", flightTypes), true));
				
				var ids = _initialFlightsArray.Select(f => f.ItemId);

				var periods = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<FlightNumberPeriodDTO, FlightNumberPeriod>(new Filter("FlightNumberId", ids), true);
				
				if (filterPeriod)
				{
					_initialPeriodArray.AddRange(periods.Where(t => t.DepartureDate >= dateTimePickerDateFrom.Value &&
																	t.ArrivalDate <= dateTimePickerDateTo.Value));
				}
				else _initialPeriodArray.AddRange(periods);

				foreach (var period in _initialPeriodArray)
					period.FlightNum = _initialFlightsArray.FirstOrDefault(f => f.ItemId == period.FlightNumberId);
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			AnimatedThreadWorker.ReportProgress(40, "Calculate records");

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(70, "filter records");

			FilterItems(_initialFlightsArray, _resultFlightsArray);
			FilterItems(_initialPeriodArray, _resultPeriodArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
			#endregion
		}
		#endregion

		#region protected override void InitListView(PropertyInfo beginGroup = null)

		private void InitListView()
		{
			_directivesViewer = new FlightNumberListView(_screenType)
			{
				TabIndex = 2, Location = new Point(panel1.Left, panel1.Top), Dock = DockStyle.Fill
			};

			_directivesViewer.AddMenuItems(_toolStripMenuItemCreateTrip);

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

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemCreateTrip = new RadMenuItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemCreateTrip.Text = "Create Trip";
			_toolStripMenuItemCreateTrip.Click += ToolStripMenuItemCreateTripClick;
		}

		#endregion

		#region private void ToolStripMenuItemCreateTripClick(object sender, EventArgs e)

		private void ToolStripMenuItemCreateTripClick(object sender, EventArgs e)
		{
			if (!_directivesViewer.SelectedItems.All(p => p is FlightNumberPeriod))
			{
				MessageBox.Show("Please select only perods!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				return;
			}

			var form = new TrackForm(_directivesViewer.SelectedItems);
			form.ShowDialog();
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
			var unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				string errorMessage = "";

				foreach (var flightNumber in unsaved)
				{
					if(flightNumber is FlightNumber)
						GlobalObjects.AircraftFlightsCore.Save(flightNumber as FlightNumber);
				}

				if (string.IsNullOrEmpty(errorMessage))
				{
					MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					headerControl.ShowSaveButton = false;
				}
				else
				{
					MessageBox.Show(errorMessage, "Message warning", MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					headerControl.ShowSaveButton = true;
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialFlightsArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
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
			_resultFlightsArray.Clear();
			_resultPeriodArray.Clear();
			_result.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialFlightsArray, _resultFlightsArray);
			FilterItems(_initialPeriodArray, _resultPeriodArray);

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
		private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)
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

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightNumberPeriod> initialCollection, ICommonCollection<FlightNumberPeriod> resultCollection)
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

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			string typeName = typeof(FlightNumber).Name;

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + _directivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = aircraftHeaderControl1.Operator.Name;
			e.DisplayerText += ".Flight.New Flight";
			e.RequestedEntity = new FlightNumberScreen(new FlightNumber
			{
				DistanceMeasure = Measure.Kilometres,
			}, _screenType);
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			filterPeriod = true;

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void LinkTripDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkTripDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Track";
			e.RequestedEntity = new FlightTrackListScreen(CurrentOperator, _screenType);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		}

		#endregion

		#region private void RadioButtonOnClick(object sender, EventArgs eventArgs)

		private void RadioButtonOnClick(object sender, EventArgs eventArgs)
		{
			firstLoad = true;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion
		
		#endregion

	}
}
