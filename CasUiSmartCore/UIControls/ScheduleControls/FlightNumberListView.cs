using System;
using System.Collections.Generic;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ScheduleControls
{
	///<summary>
	/// список для отображения событий системы безопасности полетов
	///</summary>
	public partial class FlightNumberListView : BaseGridViewControl<IFlightNumberParams>
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
			EnableCustomSorting = false;
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
			AddColumn("Flight №", (int)(radGridView1.Width * 0.2f));
			AddColumn("Period", (int)(radGridView1.Width * 0.6f));
			AddColumn("Day of the Week", (int)(radGridView1.Width * 0.30f));
			AddColumn("Departure", (int)(radGridView1.Width * 0.4f));
			AddColumn("Departure Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Arrival", (int)(radGridView1.Width * 0.4f));
			AddColumn("Arrival Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Flight Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.4f));
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

		#region protected override List<CustomCell> GetListViewSubItems(IFlightNumberParams item)

		protected override List<CustomCell> GetListViewSubItems(IFlightNumberParams item)
		{
			var subItems = new List<CustomCell>();

			if (item is FlightNumber)
			{
				var flightNumber = item as FlightNumber;
				var author = GlobalObjects.CasEnvironment.GetCorrector(flightNumber);
				
				subItems.Add(CreateRow(flightNumber.FlightNo.ToString(), Tag = flightNumber.FlightNo ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow(flightNumber.Description, flightNumber.Description ));
				subItems.Add(CreateRow(flightNumber.Remarks, flightNumber.Remarks ));
				subItems.Add(CreateRow(flightNumber.HiddenRemarks, flightNumber.HiddenRemarks ));
				subItems.Add(CreateRow(author, author ));
			}
			else
			{
				var flightNumberPeriod = item as FlightNumberPeriod;
				var author = GlobalObjects.CasEnvironment.GetCorrector(flightNumberPeriod);
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

				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow(period, period ));
				subItems.Add(CreateRow(days, days ));
				subItems.Add(CreateRow(flightNumberPeriod.FlightNum.StationFrom.ToString(), flightNumberPeriod.FlightNum.StationFrom ));
				subItems.Add(CreateRow(departure.ToString("HH:mm"), departure ));
				subItems.Add(CreateRow(flightNumberPeriod.FlightNum.StationTo.ToString(), flightNumberPeriod.FlightNum.StationTo ));
				subItems.Add(CreateRow(arrival.ToString("HH:mm"), arrival ));
				subItems.Add(CreateRow(flightTime, flightTime ));
				subItems.Add(CreateRow(aircrafts, aircrafts ));
				subItems.Add(CreateRow(distance, flightNumberPeriod.FlightNum.Distance ));
				subItems.Add(CreateRow(flightNumberPeriod.FlightNum.FlightAircraftCode.ToString(), flightNumberPeriod.FlightNum.FlightAircraftCode ));
				subItems.Add(CreateRow(flightNumberPeriod.FlightNum.FlightType.ToString(), flightNumberPeriod.FlightNum.FlightType ));
				subItems.Add(CreateRow(flightNumberPeriod.FlightNum.FlightCategory.ToString(), flightNumberPeriod.FlightNum.FlightCategory ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow(author, author ));
			}

			return subItems;
		}

		#endregion


		#region Overrides of BaseGridViewControl<IFlightNumberParams>

		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortDirection = SortDirection.Asc;
			if (SortDirection == SortDirection.Desc)
				SortDirection = SortDirection.Asc;
			else
				SortDirection = SortDirection.Desc;

			var resultList = new List<IFlightNumberParams>();
			var list = radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new GridViewDataRowInfoComparer(ColumnIndex, Convert.ToInt32(SortDirection)));
			//добавление остальных подзадач
			foreach (GridViewRowInfo item in list)
			{
				if (item.Tag is FlightNumber)
				{
					resultList.Add(item.Tag as FlightNumber);

					var component = (FlightNumber)item.Tag;
					var items = list
						.Where(lvi =>
							lvi.Tag is FlightNumberPeriod &&
							((FlightNumberPeriod)lvi.Tag).FlightNumberId == component.ItemId).Select(i => i.Tag);
					resultList.AddRange(items.OfType<FlightNumberPeriod>());
				}
			}

			SetItemsArray(resultList.ToArray());
		}

		#endregion

		#region protected override void SortItems(int columnIndex)

		//protected override void SortItems(int columnIndex)
		//{
		//	itemsListView.Items.Clear();
		//	itemsListView.Items.AddRange(ListViewItemList.ToArray());
		//}

		#endregion

		#endregion
	}
}
