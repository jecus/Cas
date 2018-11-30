using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Queries;

namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	public partial class TrackForm : Form
	{
		#region Fields
		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		private List<IFlightNumberParams> _resultArray = new List<IFlightNumberParams>();
		private List<IFlightNumberParams> _selectedItems = new List<IFlightNumberParams>();
		private List<IFlightNumberParams> _addedItems = new List<IFlightNumberParams>();

		private CommonCollection<FlightNumber> _initialFlightsArray = new CommonCollection<FlightNumber>();
		private CommonCollection<FlightNumber> _resultFlightsArray = new CommonCollection<FlightNumber>();

		private CommonCollection<FlightNumberPeriod> _initialPeriodArray = new CommonCollection<FlightNumberPeriod>();
		private CommonCollection<FlightNumberPeriod> _resultPeriodArray = new CommonCollection<FlightNumberPeriod>();

		private CommonCollection<Supplier> _supplierArray = new CommonCollection<Supplier>();

		private CommonFilterCollection _filter;

		private FlightTrack _flightTrack;
		private bool _saveRecords;

		#endregion

		#region Constructor

		public TrackForm()
		{
			InitializeComponent();
		}

		public TrackForm(FlightTrack selectedTrack) : this()
		{
			_flightTrack = selectedTrack;

			UpdateInformation();

			_filter = new CommonFilterCollection(typeof(IFlightFilterParams));

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		public TrackForm(List<IFlightNumberParams> selectedTrips) : this()
		{
			_selectedItems = selectedTrips;
			_flightTrack = new FlightTrack();

			_saveRecords = true;

			UpdateInformation();

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		public TrackForm(FlightTrackRecord selectedItem): this()
		{
			_flightTrack = selectedItem.FlightTrack;
			UpdateInformation();

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBoxCustomer.Items.Clear();
			comboBoxCustomer.Items.AddRange(_supplierArray.ToArray());
			comboBoxCustomer.Items.Add(Supplier.Unknown);

			comboBoxCustomer.SelectedItem = _flightTrack.Supplier;

			foreach (var flightNumber in _resultFlightsArray.OrderBy(f => f.FlightNo.FullName))
			{
				var periods = _resultPeriodArray.Where(f => f.FlightNumberId == flightNumber.ItemId);
				if (periods.Any())
				{
					_resultArray.Add(flightNumber);
					foreach (var period in periods)
					{
						_resultArray.Add(period);
					}
				}
			}

			flightNumberListViewAll.SetItemsArray(_resultArray.ToArray());
			flightNumberListView2.SetItemsArray(_addedItems.ToArray());
		}

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_resultArray.Clear();
			_addedItems.Clear();
			_initialFlightsArray.Clear();
			_resultFlightsArray.Clear();
			_initialPeriodArray.Clear();
			_resultPeriodArray.Clear();

			try
			{
				var flightTypes = new List<int>();
				if (radioButtonSchedule.Checked)
					flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId == FlightType.Schedule.ItemId).Select(i => i.ItemId));
				else flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId != FlightType.Schedule.ItemId).Select(i => i.ItemId));

				CommonFilter<int> filter;
				if (radioButtonWinter.Checked)
					filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 0);
				else filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 1);

				//Выбираем все полеты(ItemId) фильтруя по FlightType
				var query = BaseQueries.GetSelectQueryColumnOnly<FlightNumber>(BaseEntityObject.ItemIdProperty, new ICommonFilter[]
				{
					new CommonFilter<int>(FlightNumber.FlightTypeProperty, FilterType.In, flightTypes.ToArray()),
				});
				//Загрузка всех периодов фильтруя по зимнему или летнему периоду
				_initialPeriodArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<FlightNumberPeriod>(new ICommonFilter[]
				{
					filter,
					new CommonFilter<string>(FlightNumberPeriod.FlightNumberIdProperty, FilterType.In, new []{query})

				}, true).ToArray());

				var ids = _initialPeriodArray.Select(f => f.FlightNumberId);

				if(ids.Any())
					_initialFlightsArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<FlightNumber>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true, true).ToArray());

				foreach (var period in _initialPeriodArray)
					period.FlightNum = _initialFlightsArray.FirstOrDefault(f => f.ItemId == period.FlightNumberId);

				foreach (var selectedItem in _selectedItems.GroupBy(g => g.FlightNum))
				{
					_addedItems.Add(selectedItem.Key);
					foreach (var param in selectedItem)
						_addedItems.Add(param);
				}

				_supplierArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<Supplier>(new CommonFilter<SupplierClass>(Supplier.SupplierClassProperty, SupplierClass.Customer)));

				var tripRecords = GlobalObjects.FlightTrackCore.GetFlightTrackRecordsByFlightTripId(_flightTrack.ItemId, true);
				foreach (var record in tripRecords)
				{
					if(!_addedItems.Contains(record.FlightNumberPeriod.FlightNum))
						_addedItems.Add(record.FlightNumberPeriod.FlightNum);
					_addedItems.Add(record.FlightNumberPeriod);
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}


			#region Фильтрация директив

			_animatedThreadWorker.ReportProgress(70, "filter records");

			FilterItems(_initialFlightsArray, _resultFlightsArray);
			FilterItems(_initialPeriodArray, _resultPeriodArray);

			if (_animatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			_animatedThreadWorker.ReportProgress(100, "Complete");
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			comboBoxDayOfWeek.Items.Clear();
			comboBoxDayOfWeek.Items.AddRange(DayofWeek.Items.OrderBy(o => o.ShortName).ToArray());
			comboBoxDayOfWeek.SelectedItem = _flightTrack.DayOfWeek;

			lookupComboboxTrip.Type = typeof(TripName);
			lookupComboboxTrip.SelectedItem = _flightTrack.TripName;

			textBoxRemarks.Text = _flightTrack.Remarks;

			radioButtonWinter.Checked = true;
			radioButtonSchedule.Checked = true;

			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_flightTrack.TripName = lookupComboboxTrip.SelectedItem as TripName;
			_flightTrack.Remarks = textBoxRemarks.Text;
			_flightTrack.DayOfWeek = comboBoxDayOfWeek.SelectedItem as DayofWeek;
			_flightTrack.Supplier = comboBoxCustomer.SelectedItem as Supplier;
		}

		#endregion

		#region private bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		private bool GetChangeStatus()
		{
			// Проверяем, изменены ли поля WestAircraft
			return _flightTrack.TripName != lookupComboboxTrip.SelectedItem as TripName ||
			_flightTrack.Remarks != textBoxRemarks.Text ||
			_flightTrack.DayOfWeek != comboBoxDayOfWeek.SelectedItem as DayofWeek ||
			_flightTrack.Supplier != comboBoxCustomer.SelectedItem as Supplier;
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxDayOfWeek.SelectedItem == null)
			{
				if (message != "")
					message += "\n";
				message += "Not set Day Of Week";
				return false;
			}
			if (lookupComboboxTrip.SelectedItem == null)
			{
				if (message != "")
					message += "\n";
				message += "Not set Trip Name";
				return false;
			}

			return true;
		}

		#endregion

		#region private void buttonAdd_Click(object sender, EventArgs e)

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (flightNumberListViewAll.SelectedItems.Count == 0)
				return;

			if(!flightNumberListViewAll.SelectedItems.All(p => p is FlightNumberPeriod))
			{
				MessageBox.Show("Please select only perods!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				return;
			}

			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				if (_flightTrack.ItemId <= 0 || GetChangeStatus())
				{
					ApplyChanges();
					GlobalObjects.CasEnvironment.NewKeeper.Save(_flightTrack);
				}
					
				foreach (var item in flightNumberListViewAll.SelectedItems.Cast<FlightNumberPeriod>().GroupBy(g => g.FlightNum))
				{
					foreach (var period in item)
					{
						if (_addedItems.Contains(period))
						{
							MessageBox.Show($"Item {period} alredy added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
							return;
						}

						if (_addedItems.Where(i => i is FlightNumberPeriod).Cast<FlightNumberPeriod>().Any(i => i.Schedule != period.Schedule))
						{
							MessageBox.Show($"You can not add {period.Schedule} schedule! Please select another period with difference schedule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
							return;
						}

						string flType = "";
						if (_addedItems.Count > 0)
						{
							if (_addedItems.Where(i => i is FlightNumberPeriod).Cast<FlightNumberPeriod>().All(i => i.FlightType == FlightType.Schedule))
								flType = "Shedule";
							else if (_addedItems.Where(i => i is FlightNumberPeriod).Cast<FlightNumberPeriod>().All(i => i.FlightType != FlightType.Schedule))
								flType = "UnShedule";

							if (period.FlightType.RecoredType != flType)
							{
								MessageBox.Show($"You can not add period with Fl.Type : {period.FlightType}! Please select another period with difference Fl.Type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
								return;
							}
						}
						
						

						var flightTripRecord = new FlightTrackRecord
						{
							FlightNumberPeriod = period,
							FlightTrack = _flightTrack,
							FlightPeriodId = period.ItemId,
							FlightTripId = _flightTrack.ItemId
						};
						GlobalObjects.CasEnvironment.NewKeeper.Save(flightTripRecord);
						_flightTrack.FlightTripRecord.Add(flightTripRecord);
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save FlightTrip", ex);
			}

			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void buttonDelete_Click(object sender, EventArgs e)

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (flightNumberListView2.SelectedItems.Count == 0)
				return;

			foreach (var item in flightNumberListView2.SelectedItems)
			{
				try
				{
					var period = _flightTrack.FlightTripRecord.FirstOrDefault(x => x.FlightPeriodId == item.ItemId);
					if (period != null)
						GlobalObjects.CasEnvironment.NewKeeper.Delete(period);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while remove Trip", ex);
				}
			}

			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				if (GetChangeStatus())
				{
					ApplyChanges();
					GlobalObjects.CasEnvironment.Keeper.SaveAll(_flightTrack);
				}
				
				//Сделанно специально при открытии с FlightScreen(сохраняем записи) в остальных случаях код не валиден
				if (_saveRecords)
				{
					foreach (var item in _selectedItems.Where(i => i is FlightNumberPeriod))
					{
						var p = item as FlightNumberPeriod;

						var flightTripRecord = new FlightTrackRecord
						{
							FlightNumberPeriod = p,
							FlightTrack = _flightTrack,
							FlightPeriodId = p.ItemId,
							FlightTripId = _flightTrack.ItemId
						};
						GlobalObjects.CasEnvironment.NewKeeper.Save(flightTripRecord);
						_flightTrack.FlightTripRecord.Add(flightTripRecord);
					}
				}
				_saveRecords = false;

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save FlightTrip", ex);
			}

		}

		#endregion

		#region private void TripForm_FormClosing(object sender, FormClosingEventArgs e)

		private void TripForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(_addedItems.Count == 0)
				GlobalObjects.CasEnvironment.Manipulator.Delete(_flightTrack);
		}

		#endregion

		#region private void RadioButtonOnClick(object sender, EventArgs e)

		private void RadioButtonOnClick(object sender, EventArgs e)
		{
			_filter = new CommonFilterCollection(typeof(IFlightFilterParams));
			_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonFilter_Click(object sender, EventArgs e)

		private void ButtonFilter_Click(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialFlightsArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
				_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				_animatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)
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

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightNumberPeriod> initialCollection, ICommonCollection<FlightNumberPeriod> resultCollection)
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

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultFlightsArray.Clear();
			_resultPeriodArray.Clear();
			_resultArray.Clear();

			#region Фильтрация директив
			_animatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialFlightsArray, _resultFlightsArray);
			FilterItems(_initialPeriodArray, _resultPeriodArray);

			if (_animatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			_animatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion
	}
}
