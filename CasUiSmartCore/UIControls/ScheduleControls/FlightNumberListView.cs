using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.ScheduleControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class FlightNumberListView : BaseListViewControl<IFlightNumberParams>
	{
		#region Fields

		private readonly FlightNumberScreenType _screenType;

		#endregion

		#region public FlightNumberListView()

		/// <summary>
		/// </summary>
		/// <param name="screenType"></param>
		public FlightNumberListView()
        {
            InitializeComponent();
        }

		public FlightNumberListView(FlightNumberScreenType screenType) : this()
		{
			_screenType = screenType;
		}
		#endregion

		#region Methods

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
				var regNumber = GlobalObjects.CasEnvironment.Operators[0].Name + ".Flights. " + SelectedItem.FlightNum.FlightNo;
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        e.DisplayerText = regNumber;
		        e.RequestedEntity = new FlightNumberScreen(SelectedItem.FlightNum, _screenType);
            }
        }
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight №" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Period" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Day of the Week" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Departure" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Departure Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Arrival" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Arrival Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Aircraft" };
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

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			if (item is FlightNumber)
			{
				var flightNumber = item as FlightNumber;

				var subItem = new ListViewItem.ListViewSubItem {Text = flightNumber.FlightNo.ToString(), Tag = flightNumber.FlightNo};
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem {Text = "", Tag = ""};
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem {Text = "", Tag = ""};
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumber.Description, Tag = flightNumber.Description };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumber.Remarks, Tag = flightNumber.Remarks };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumber.HiddenRemarks, Tag = flightNumber.HiddenRemarks };
				subItems.Add(subItem);
			}
			else
			{
				var flightNumberPeriod = item as FlightNumberPeriod;

				string period;
				if (flightNumberPeriod.FlightType == FlightType.Schedule)
					period = $"{flightNumberPeriod.DepartureDate:dd-MMMM-yyyy} - {flightNumberPeriod.ArrivalDate:dd-MMMM-yyyy}";
				else period = $"{flightNumberPeriod.DepartureDate:dd-MMMM-yyyy}";

				var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0 ,flightNumberPeriod.PeriodTo, 0), new TimeSpan(0, flightNumberPeriod.PeriodFrom, 0));
				var flightTime = UsefulMethods.TimeToString(flightDifference);

				var aircrafts = "";

				foreach (var model in flightNumberPeriod.FlightNum.AircraftModels)
				{
					aircrafts += $"{model.AircraftModel} ";
				}

				var days = "";
				if (flightNumberPeriod.IsMonday)
				{
					if (days != "")
						days += " , ";
					days += "1";
				}
				if (flightNumberPeriod.IsTuesday)
				{
					if (days != "")
						days += " , ";
					days += "2";
				}
				if (flightNumberPeriod.IsWednesday)
				{
					if (days != "")
						days += " , ";
					days += "3";
				}
				if (flightNumberPeriod.IsThursday)
				{
					if (days != "")
						days += " , ";
					days += "4";
				}
				if (flightNumberPeriod.IsFriday)
				{
					if (days != "")
						days += " , ";
					days += "5";
				}
				if (flightNumberPeriod.IsSaturday)
				{
					if (days != "")
						days += " , ";
					days += "6";
				}
				if (flightNumberPeriod.IsSunday)
				{
					if (days != "")
						days += " , ";
					days += "7";
				}

				var departure = flightNumberPeriod.DepartureDate.Date.AddMinutes(flightNumberPeriod.PeriodFrom);
				var arrival = flightNumberPeriod.DepartureDate.Date.AddMinutes(flightNumberPeriod.PeriodTo);

				var distance = $"{flightNumberPeriod.FlightNum.Distance} {flightNumberPeriod.FlightNum.DistanceMeasure}";

				var subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = period, Tag = period };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = days, Tag = days };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumberPeriod.FlightNum.StationFrom.ToString(), Tag = flightNumberPeriod.FlightNum.StationFrom };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = departure.ToString("HH:mm"), Tag = departure };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumberPeriod.FlightNum.StationTo.ToString(), Tag = flightNumberPeriod.FlightNum.StationTo };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = arrival.ToString("HH:mm"), Tag = arrival };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightTime, Tag = flightTime };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = aircrafts, Tag = aircrafts };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = distance, Tag = flightNumberPeriod.FlightNum.Distance };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumberPeriod.FlightNum.FlightAircraftCode.ToString(), Tag = flightNumberPeriod.FlightNum.FlightAircraftCode };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumberPeriod.FlightNum.FlightType.ToString(), Tag = flightNumberPeriod.FlightNum.FlightType };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = flightNumberPeriod.FlightNum.FlightCategory.ToString(), Tag = flightNumberPeriod.FlightNum.FlightCategory };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);
			}

			return subItems.ToArray();
		}

		#endregion

		#region protected override void SortItems(int columnIndex)

		protected override void SortItems(int columnIndex)
		{
			itemsListView.Items.Clear();
			itemsListView.Items.AddRange(ListViewItemList.ToArray());
		}

		#endregion

		#endregion
    }
}
