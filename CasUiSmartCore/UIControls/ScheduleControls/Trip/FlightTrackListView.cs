using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	public partial class FlightTrackListView : BaseListViewControl<FlightTrackRecord>
	{
		#region Fields

		private readonly FlightNumberScreenType _screenType;

		#endregion

		#region Constructor

		public FlightTrackListView()
		{
			InitializeComponent();
		}

		public FlightTrackListView(FlightNumberScreenType screenType) : this()
		{
			_screenType = screenType;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var regNumber = GlobalObjects.CasEnvironment.Operators[0].Name + ".Flights. " + SelectedItem.FlightNumberPeriod.FlightNum.FlightNo;
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = regNumber;
				e.RequestedEntity = new FlightNumberScreen(SelectedItem.FlightNumberPeriod.FlightNum, _screenType);
			}
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight №" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Aircraft Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Day of Week" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Departure" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Departure Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Arrival" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Arrival Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Distance" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "AC Code" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "FL Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "FL Cat." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "HiddenRemarks" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(FlightTrackRecord item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var aircrafts = "";
			var flightNo = item.FlightNumberPeriod?.FlightNo.ToString();

			var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, item.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, item.FlightNumberPeriod.PeriodFrom, 0));
			var flightTime = UsefulMethods.TimeToString(flightDifference);

			var departure = item.FlightNumberPeriod.DepartureDate.Date.AddMinutes(item.FlightNumberPeriod.PeriodFrom);
			var arrival = item.FlightNumberPeriod.DepartureDate.Date.AddMinutes(item.FlightNumberPeriod.PeriodTo);

			var distance = $"{item.FlightNumberPeriod.FlightNum.Distance} {item.FlightNumberPeriod.FlightNum.DistanceMeasure}";

			foreach (var model in item.FlightNumberPeriod.FlightNum.AircraftModels)
				aircrafts += $"{model.AircraftModel} ";

			var days = "";
			if (item.FlightNumberPeriod.IsMonday)
			{
				if (days != "")
					days += " , ";
				days += "1";
			}
			if (item.FlightNumberPeriod.IsTuesday)
			{
				if (days != "")
					days += " , ";
				days += "2";
			}
			if (item.FlightNumberPeriod.IsWednesday)
			{
				if (days != "")
					days += " , ";
				days += "3";
			}
			if (item.FlightNumberPeriod.IsThursday)
			{
				if (days != "")
					days += " , ";
				days += "4";
			}
			if (item.FlightNumberPeriod.IsFriday)
			{
				if (days != "")
					days += " , ";
				days += "5";
			}
			if (item.FlightNumberPeriod.IsSaturday)
			{
				if (days != "")
					days += " , ";
				days += "6";
			}
			if (item.FlightNumberPeriod.IsSunday)
			{
				if (days != "")
					days += " , ";
				days += "7";
			}

			if (item.FlightType != FlightType.Schedule)
				days += $" ({item.FlightNumberPeriod.DepartureDate:dd-MMMM-yyyy})";


			var subItem = new ListViewItem.ListViewSubItem { Text = flightNo, Tag = flightNo };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = aircrafts, Tag = aircrafts };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = days, Tag = days };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.StationFrom.ToString(), Tag = item.FlightNumberPeriod.FlightNum.StationFrom };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = departure.ToString("HH:mm"), Tag = departure };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.StationTo.ToString(), Tag = item.FlightNumberPeriod.FlightNum.StationTo };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = arrival.ToString("HH:mm"), Tag = arrival };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = flightTime, Tag = flightTime };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = distance, Tag = item.FlightNumberPeriod.FlightNum.Distance };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.FlightAircraftCode.ToString(), Tag = item.FlightNumberPeriod.FlightNum.FlightAircraftCode };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.FlightType.ToString(), Tag = item.FlightNumberPeriod.FlightNum.FlightType };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.FlightCategory.ToString(), Tag = item.FlightNumberPeriod.FlightNum.FlightCategory };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.Description, Tag = item.FlightNumberPeriod.FlightNum.Description };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.Remarks, Tag = item.FlightNumberPeriod.FlightNum.Remarks };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumberPeriod.FlightNum.HiddenRemarks, Tag = item.FlightNumberPeriod.FlightNum.HiddenRemarks };
			subItems.Add(subItem);

			return subItems.ToArray();
		}
		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in ListViewItemList)
			{
				string temp;

				if (item.Tag is FlightTrackRecord)
				{
					var rec = item.Tag as FlightTrackRecord;
					var total = new TimeSpan();

					foreach (var record in rec.FlightTrack.FlightTripRecord.Where(i => i.FlightNumberPeriod != null))
					{
						var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, record.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, record.FlightNumberPeriod.PeriodFrom, 0));
						total = total.Add(flightDifference);
					}

					temp = $"{rec.FlightTrack.DayOfWeek.ShortName} - {rec.FlightTrack.DayOfWeek.FullName} {rec.FlightTrack.TripName} ({rec.FlightTypeString}) ({rec.Schedule}) | Total: {UsefulMethods.TimeToString(total)}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

		#endregion

		#region protected override void SortItems(int columnIndex)

		protected override void SortItems(int columnIndex)
		{
			if (OldColumnIndex != columnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;
			itemsListView.Items.Clear();
			SetGroupsToItems(columnIndex);
			itemsListView.Items.AddRange(ListViewItemList.ToArray());
			OldColumnIndex = columnIndex;
			SetItemsColor();
		}

		#endregion
	}
}
