using System;
using System.Collections.Generic;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	public partial class FlightTrackListView : BaseGridViewControl<FlightTrackRecord>
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
			AddColumn("Flight №", (int)(radGridView1.Width * 0.2f));
			AddColumn("Aircraft Type", (int)(radGridView1.Width * 0.2f));
			AddDateColumn("Day of Week", (int)(radGridView1.Width * 0.2f));
			AddColumn("Departure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Departure Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Arrival", (int)(radGridView1.Width * 0.2f));
			AddColumn("Arrival Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Flight Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Distance", (int)(radGridView1.Width * 0.30f));
			AddColumn("AC Code", (int)(radGridView1.Width * 0.2f));
			AddColumn("FL Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("FL Cat.", (int)(radGridView1.Width * 0.30f));
			AddColumn("Description", (int)(radGridView1.Width * 0.4f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.4f));
			AddColumn("HiddenRemarks", (int)(radGridView1.Width * 0.4f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(FlightTrackRecord item)

		protected override List<CustomCell> GetListViewSubItems(FlightTrackRecord item)
		{
			var aircrafts = "";
			var flightNo = item.FlightNumberPeriod?.FlightNo.ToString();

			var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, item.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, item.FlightNumberPeriod.PeriodFrom, 0));
			var flightTime = UsefulMethods.TimeToString(flightDifference);

			var departure = item.FlightNumberPeriod.DepartureDate.Date.AddMinutes(item.FlightNumberPeriod.PeriodFrom);
			var arrival = item.FlightNumberPeriod.DepartureDate.Date.AddMinutes(item.FlightNumberPeriod.PeriodTo);
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
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

			return new List<CustomCell>
			{
				CreateRow(flightNo, flightNo),
				CreateRow(aircrafts, aircrafts),
				CreateRow(days, days),
				CreateRow(item.FlightNumberPeriod.FlightNum.StationFrom.ToString(), item.FlightNumberPeriod.FlightNum.StationFrom),
				CreateRow(departure.ToString("HH:mm"), departure),
				CreateRow(item.FlightNumberPeriod.FlightNum.StationTo.ToString(), item.FlightNumberPeriod.FlightNum.StationTo),
				CreateRow(arrival.ToString("HH:mm"), arrival),
				CreateRow(flightTime, flightTime),
				CreateRow(distance, item.FlightNumberPeriod.FlightNum.Distance),
				CreateRow(item.FlightNumberPeriod.FlightNum.FlightAircraftCode.ToString(), item.FlightNumberPeriod.FlightNum.FlightAircraftCode),
				CreateRow(item.FlightNumberPeriod.FlightNum.FlightType.ToString(), item.FlightNumberPeriod.FlightNum.FlightType),
				CreateRow(item.FlightNumberPeriod.FlightNum.FlightCategory.ToString(), item.FlightNumberPeriod.FlightNum.FlightCategory),
				CreateRow(item.FlightNumberPeriod.FlightNum.Description, item.FlightNumberPeriod.FlightNum.Description),
				CreateRow(item.FlightNumberPeriod.FlightNum.Remarks, item.FlightNumberPeriod.FlightNum.Remarks),
				CreateRow(item.FlightNumberPeriod.FlightNum.HiddenRemarks, item.FlightNumberPeriod.FlightNum.HiddenRemarks),
				CreateRow(author, Tag = author)
			};
		}
		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();
		//	foreach (ListViewItem item in ListViewItemList)
		//	{
		//		string temp;

		//		if (item.Tag is FlightTrackRecord)
		//		{
		//			var rec = item.Tag as FlightTrackRecord;
		//			var total = new TimeSpan();

		//			foreach (var record in rec.FlightTrack.FlightTripRecord.Where(i => i.FlightNumberPeriod != null))
		//			{
		//				var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, record.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, record.FlightNumberPeriod.PeriodFrom, 0));
		//				total = total.Add(flightDifference);
		//			}

		//			temp = $"{rec.FlightTrack.DayOfWeek.ShortName} - {rec.FlightTrack.DayOfWeek.FullName} {rec.FlightTrack.TripName} ({rec.FlightTypeString}) ({rec.Schedule}) | Total: {UsefulMethods.TimeToString(total)}";
		//			itemsListView.Groups.Add(temp, temp);
		//			item.Group = itemsListView.Groups[temp];
		//		}
		//	}
		//}

		#endregion

		#region protected override void SortItems(int columnIndex)

		//protected override void SortItems(int columnIndex)
		//{
		//	if (OldColumnIndex != columnIndex)
		//		SortDirection = -1;
		//	if (SortDirection == 1)
		//		SortDirection = -1;
		//	else
		//		SortDirection = 1;
		//	itemsListView.Items.Clear();
		//	SetGroupsToItems(columnIndex);
		//	itemsListView.Items.AddRange(ListViewItemList.ToArray());
		//	OldColumnIndex = columnIndex;
		//	SetItemsColor();
		//}

		#endregion
	}
}
