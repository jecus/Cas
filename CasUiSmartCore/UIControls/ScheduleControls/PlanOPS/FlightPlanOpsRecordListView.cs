using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsRecordListView : BaseGridViewControl<FlightPlanOpsRecords>
	{
		#region Fields

		private readonly bool _calculated;
		private readonly AnimatedThreadWorker _animatedThreadWorker;
		private Dictionary<int, List<Lifelength>> _tempDict = new Dictionary<int, List<Lifelength>>();

		bool previousHasFlight = true;

		#endregion

		#region public FlightPlanOpsRecordListView()

		public FlightPlanOpsRecordListView()
		{
			InitializeComponent();
		}

		public FlightPlanOpsRecordListView(bool calculated, AnimatedThreadWorker animatedThreadWorker) : this()
		{
			_calculated = calculated;
			_animatedThreadWorker = animatedThreadWorker;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("Flight №", (int)(radGridView1.Width * 0.12f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.16f));
			AddColumn("Aircraft Exchange", (int)(radGridView1.Width * 0.16f));
			AddColumn("Status", (int)(radGridView1.Width * 0.16f));
			AddColumn("Delay", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cancellation", (int)(radGridView1.Width * 0.2f));
			AddColumn("Exchange", (int)(radGridView1.Width * 0.2f));
			AddColumn("Day of the Week", (int)(radGridView1.Width * 0.24f));
			AddColumn("Direction", (int)(radGridView1.Width * 0.12f));
			AddColumn("(S)DEP - ARR", (int)(radGridView1.Width * 0.16f));
			AddColumn("(S)Flight Time", (int)(radGridView1.Width * 0.12f));
			AddColumn("(D)DEP - ARR", (int)(radGridView1.Width * 0.16f));
			AddColumn("(D)Flight Time", (int)(radGridView1.Width * 0.12f));
			AddColumn("DEP Delay", (int)(radGridView1.Width * 0.12f));
			AddColumn("ARR Estimated", (int)(radGridView1.Width * 0.12f));
			AddColumn("ARR Delay", (int)(radGridView1.Width * 0.12f));
			AddColumn("(F)DEP - ARR", (int)(radGridView1.Width * 0.16f));
			AddColumn("(F)Flight Time", (int)(radGridView1.Width * 0.12f));
			
			if (_calculated)
			{
				AddColumn("Aircraft TTSN/TCSN", (int)(radGridView1.Width * 0.16f));
				AddColumn("Limit WP", (int)(radGridView1.Width * 0.16f));
				AddColumn("Limit WP Remain", (int)(radGridView1.Width * 0.16f));
				AddColumn("Limit WP Remain 10%", (int)(radGridView1.Width * 0.16f));
				AddColumn("Limit DIR", (int)(radGridView1.Width * 0.16f));
				AddColumn("Limit DIR Remain", (int)(radGridView1.Width * 0.16f));
			}

			AddColumn("Limit Flight", (int)(radGridView1.Width * 0.16f));
			AddColumn("Discrepancies", (int)(radGridView1.Width * 0.16f));
			AddColumn("Cargo", (int)(radGridView1.Width * 0.16f));
			AddColumn("Station", (int)(radGridView1.Width * 0.16f));
			AddColumn("MRO", (int)(radGridView1.Width * 0.16f));
			AddColumn("Flight Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Flight Cat", (int)(radGridView1.Width * 0.16f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.16f));
			AddColumn("Hidden Remarks", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override List<CustomCell> GetListViewSubItems(FlightPlanOpsRecords item)
		{
			var subItems = new List<CustomCell>();

			var ll = Lifelength.Null;

			var llColor = radGridView1.ForeColor;

			var flightNum = item.FlightTrackRecord.FlightNo;
			var period = item.FlightTrackRecord.FlightNumberPeriod;
			var aircraft = item.Aircraft?.ToString() ?? "";
			var aircraftExchange = item.AircraftExchange?.ToString() ?? "";
			var direction = $"{period.StationFrom.ShortName} - {period.StationTo.ShortName}";
			var reasonDelay = item.DelayReason?.ToString() ?? "";
			var reasonCansellation = item.CancelReason?.ToString() ?? "";
			var reason = item.Reason?.ToString() ?? "";
			var status = item.Status != OpsStatus.Unknown ? item.Status.ToString() : "";

			var depArrS = $"{period.DepartureDate.Date.AddMinutes(period.PeriodFrom):HH:mm} - {period.DepartureDate.Date.AddMinutes(period.PeriodTo):HH:mm}";
			var flightDifferenceS = UsefulMethods.GetDifference(new TimeSpan(0, period.PeriodTo, 0), new TimeSpan(0, period.PeriodFrom, 0));
			var flightTimeS = UsefulMethods.TimeToString(flightDifferenceS);

			var depArrD = "";
			var flightTimeD = "";
			var depDelayString = "";
			var arrDelayString = "";
			var arrEstimatedString = "";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			if (item.IsDispatcherEdit && item.IsDispatcherEditLdg)
			{
				depArrD = $"{period.DepartureDate.Date.AddMinutes(item.PeriodFrom):HH:mm} - {period.DepartureDate.Date.AddMinutes(item.PeriodTo):HH:mm}";
				var flightDifferenceD = UsefulMethods.GetDifference(new TimeSpan(0, item.PeriodTo, 0), new TimeSpan(0, item.PeriodFrom, 0));
				flightTimeD = UsefulMethods.TimeToString(flightDifferenceD);


				if (item.PeriodFrom > period.PeriodFrom)
				{
					var depDelay = UsefulMethods.GetDifference(new TimeSpan(0, item.PeriodFrom, 0),new TimeSpan(0, period.PeriodFrom, 0));
					depDelayString = UsefulMethods.TimeToString(depDelay);

					arrEstimatedString = UsefulMethods.TimeToString(new TimeSpan(0, period.PeriodTo, 0).Add(depDelay));
				}

				if (item.PeriodTo > period.PeriodTo)
				{
					var arrDelay = UsefulMethods.GetDifference(new TimeSpan(0, item.PeriodTo, 0), new TimeSpan(0, period.PeriodTo, 0));
					arrDelayString = UsefulMethods.TimeToString(arrDelay);
				}
			}
			else if (item.IsDispatcherEdit)
			{
				depArrD = $"{period.DepartureDate.Date.AddMinutes(item.PeriodFrom):HH:mm} - --:--";

				if (item.PeriodFrom > period.PeriodFrom)
				{
					var depDelay = UsefulMethods.GetDifference(new TimeSpan(0, item.PeriodFrom, 0), new TimeSpan(0, period.PeriodFrom, 0));
					depDelayString = UsefulMethods.TimeToString(depDelay);

					arrEstimatedString = UsefulMethods.TimeToString(new TimeSpan(0, period.PeriodTo, 0).Add(depDelay));
				}
				else arrEstimatedString = UsefulMethods.TimeToString(period.DepartureDate.Date.AddMinutes(item.PeriodFrom).TimeOfDay.Add(flightDifferenceS));
			}
			else if (item.ParentFlight != null)
			{
				if (item.ParentFlight.TakeOffTime > period.PeriodFrom)
				{
					var depDelay = UsefulMethods.GetDifference(new TimeSpan(0, item.ParentFlight.TakeOffTime, 0), new TimeSpan(0, period.PeriodFrom, 0));
					depDelayString = UsefulMethods.TimeToString(depDelay);
				}
			}
			
			var depArrF = "";
			var flightTimeF = "";
			var flType = item.FlightTrackRecord.FlightType.ToString();
			var flCat = item.FlightTrackRecord.FlightCategory.ToString();

			if (item.ParentFlight != null)
			{
				flCat = item.ParentFlight.FlightCategory.ToString();
				flType = item.FlightType.ToString();

				depArrF = $"{period.DepartureDate.Date.AddMinutes(item.ParentFlight.TakeOffTime):HH:mm} - {period.DepartureDate.Date.AddMinutes(item.ParentFlight.LDGTime):HH:mm}";
				var flightDifferenceF = UsefulMethods.GetDifference(new TimeSpan(0, item.ParentFlight.LDGTime, 0), new TimeSpan(0, item.ParentFlight.TakeOffTime, 0));
				flightTimeF = UsefulMethods.TimeToString(flightDifferenceF);

				if (_calculated)
				{
					if (previousHasFlight)
					{
						previousHasFlight = true;
						ll = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(item.ParentFlight);
					}
					else
					{
						var lastll = _tempDict[item.ParentFlight.AircraftId].Last();
						lastll.Add(new Lifelength(0, 1, (int)flightDifferenceF.TotalMinutes));
						ll = lastll;
						llColor = Color.Orange;

						previousHasFlight = false;
					}

					if (_tempDict.ContainsKey(item.ParentFlight.AircraftId))
						_tempDict[item.ParentFlight.AircraftId].Add(ll);
					else _tempDict.Add(item.ParentFlight.AircraftId, new List<Lifelength>{ll});

					
					_tempDict[item.ParentFlight.AircraftId].Add(ll);
				}
			}
			else
			{
				if (item.AircraftExchangeId > 0 || item.AircraftId > 0)
				{
					var a = item.AircraftExchangeId > 0 ? item.AircraftExchange : item.Aircraft;
					if (_tempDict.ContainsKey(a.ItemId))
					{
						var lastll = _tempDict[a.ItemId].Last();
						lastll.Add(new Lifelength(0, 1, (int)flightDifferenceS.TotalMinutes));
						ll = lastll;

						_tempDict[a.ItemId].Add(ll);
						llColor = Color.Red;
						previousHasFlight = false;
					}
					else
					{
						ll = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(a, item.Date);
						llColor = Color.Red;
						_tempDict.Add(a.ItemId, new List<Lifelength> { ll });
					}
				}
			}

			var days = "";
			if (period.IsMonday)
			{
				if (days != "")
					days += " , ";
				days += "1";
			}
			if (period.IsTuesday)
			{
				if (days != "")
					days += " , ";
				days += "2";
			}
			if (period.IsWednesday)
			{
				if (days != "")
					days += " , ";
				days += "3";
			}
			if (period.IsThursday)
			{
				if (days != "")
					days += " , ";
				days += "4";
			}
			if (period.IsFriday)
			{
				if (days != "")
					days += " , ";
				days += "5";
			}
			if (period.IsSaturday)
			{
				if (days != "")
					days += " , ";
				days += "6";
			}
			if (period.IsSunday)
			{
				if (days != "")
					days += " , ";
				days += "7";
			}

			subItems.Add(CreateRow(flightNum.ToString(), flightNum ));
			subItems.Add(CreateRow(aircraft, item.Aircraft ));
			subItems.Add(CreateRow(aircraftExchange, item.AircraftExchange ));
			subItems.Add(CreateRow(status, item.Status ));
			subItems.Add(CreateRow(reasonDelay, reasonDelay ));
			subItems.Add(CreateRow(reasonCansellation, reasonCansellation ));
			subItems.Add(CreateRow(reason, reason ));
			subItems.Add(CreateRow(days, days ));
			subItems.Add(CreateRow(direction, direction ));
			subItems.Add(CreateRow(depArrS, depArrS ));
			subItems.Add(CreateRow(flightTimeS, flightTimeS ));
			subItems.Add(CreateRow(depArrD, depArrD ));
			subItems.Add(CreateRow(flightTimeD, flightTimeD ));
			subItems.Add(CreateRow(depDelayString, depDelayString ));
			subItems.Add(CreateRow(arrEstimatedString, arrEstimatedString ));
			subItems.Add(CreateRow(arrDelayString, arrDelayString ));
			subItems.Add(CreateRow(depArrF, depArrF ));
			subItems.Add(CreateRow(flightTimeF, flightTimeF ));
			
			if (_calculated)
			{
				subItems.Add(CreateRow(ll.ToHoursMinutesAndCyclesFormat("", ""), ll, llColor ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
			}

			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow(flType, flType ));
			subItems.Add(CreateRow(flCat, flCat ));
			subItems.Add(CreateRow(item.Remarks, item.Remarks ));
			subItems.Add(CreateRow(item.HiddenRemarks, item.HiddenRemarks ));
			subItems.Add(CreateRow(author, author ));

			return subItems;
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();

		//	if (columnIndex == 1)
		//	{
		//		foreach (var items in ListViewItemList.Where(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft != null)
		//														.GroupBy(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft))
		//		{
		//			string temp;

		//			foreach (var item in items)
		//			{
		//				if (item.Tag is FlightPlanOpsRecords)
		//				{
		//					var rec = item.Tag as FlightPlanOpsRecords;
		//					var flTrack = rec.FlightTrackRecord;

		//					string date;
		//					if (rec.FlightTrackRecord.FlightType == FlightType.Schedule)
		//						date = rec.Date.ToString("dd-MMMM-yyyy");
		//					else date = rec.FlightTrackRecord.FlightNumberPeriod.DepartureDate.ToString("dd-MMMM-yyyy");

		//					temp = $"{date} {flTrack.DayOfWeek.ShortName} - {flTrack.DayOfWeek.FullName} {flTrack.TripName} ({flTrack.Schedule}) {items.Key}";
		//					itemsListView.Groups.Add(temp, temp);
		//					item.Group = itemsListView.Groups[temp];
		//				}
		//			}
		//		}
		//	}
		//	else
		//	{
		//		foreach (ListViewItem item in ListViewItemList.OrderBy(i => ((FlightPlanOpsRecords)i.Tag).Date)
		//			.ThenBy(i => (i.Tag as FlightPlanOpsRecords)?.FlightTrack.TripName)
		//			.ThenBy(i => ((FlightPlanOpsRecords)i.Tag).PeriodFrom))
		//		{
		//			string temp;

		//			if (item.Tag is FlightPlanOpsRecords)
		//			{
		//				var rec = item.Tag as FlightPlanOpsRecords;
		//				var flTrack = rec.FlightTrackRecord;
		//				var total = new TimeSpan();

		//				foreach (var record in ListViewItemList.Where(i => (i.Tag as FlightPlanOpsRecords).FlightTrack.ItemId == rec.FlightTrack.ItemId).Select(i => i.Tag))
		//				{
		//					var period = record as FlightPlanOpsRecords;

		//					var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, period.FlightTrackRecord.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, period.FlightTrackRecord.FlightNumberPeriod.PeriodFrom, 0));
		//					total = total.Add(flightDifference);
		//				}

		//				string date;
		//				if (rec.FlightTrackRecord.FlightType == FlightType.Schedule)
		//					date = rec.Date.ToString("dd-MMMM-yyyy");
		//				else date = rec.FlightTrackRecord.FlightNumberPeriod.DepartureDate.ToString("dd-MMMM-yyyy");

		//				temp = $"{date} {flTrack.DayOfWeek.ShortName} - {flTrack.DayOfWeek.FullName} {flTrack.TripName} ({flTrack.FlightTypeString}) ({flTrack.Schedule}) | Total: {UsefulMethods.TimeToString(total)}";
		//				itemsListView.Groups.Add(temp, temp);
		//				item.Group = itemsListView.Groups[temp];
		//			}
		//		}
		//	}
		//}

		#endregion

		#region protected override void SortItems(int columnIndex)

		//protected override void SortItems(int columnIndex)
		//{
		//	if (OldColumnIndex != columnIndex)
		//		SortMultiplier = -1;
		//	if (SortMultiplier == 1)
		//		SortMultiplier = -1;
		//	else
		//		SortMultiplier = 1;
		//	itemsListView.Items.Clear();

		//	SetGroupsToItems(columnIndex);

		//	if (columnIndex == 1)
		//		itemsListView.Items.AddRange(ListViewItemList.Where(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft != null).ToArray());
		//	else itemsListView.Items.AddRange(ListViewItemList.ToArray());

		//	OldColumnIndex = columnIndex;
		//	SetItemsColor();
		//}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var form = new PlanOpsRecordForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
					_animatedThreadWorker.RunWorkerAsync();
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, Directive item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, FlightPlanOpsRecords item)
		{
			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = UsefulMethods.GetColor(item);
			}
		}
		#endregion

		public void ClearFields()
		{
			_tempDict.Clear();
			previousHasFlight = true;
		}
	}
}
