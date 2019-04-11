using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsRecordListView : BaseListViewControl<FlightPlanOpsRecords>
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
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "Flight №" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Aircraft" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Aircraft Exchange" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Delay" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cancellation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Exchange" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Day of the Week" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "Direction" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "(S)DEP - ARR" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "(S)Flight Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "(D)DEP - ARR" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "(D)Flight Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "DEP Delay" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "ARR Estimated" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "ARR Delay" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "(F)DEP - ARR" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.06f), Text = "(F)Flight Time" };
			ColumnHeaderList.Add(columnHeader);

			if (_calculated)
			{
				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Aircraft TTSN/TCSN" };
				ColumnHeaderList.Add(columnHeader);

				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit WP" };
				ColumnHeaderList.Add(columnHeader);

				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit WP Remain" };
				ColumnHeaderList.Add(columnHeader);

				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit WP Remain 10%" };
				ColumnHeaderList.Add(columnHeader);

				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit DIR" };
				ColumnHeaderList.Add(columnHeader);

				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit DIR Remain" };
				ColumnHeaderList.Add(columnHeader);

			}

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Limit Flight" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Discrepancies" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Cargo" };
			ColumnHeaderList.Add(columnHeader);
			//
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Station" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "MRO" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Flight Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Flight Cat" };
			ColumnHeaderList.Add(columnHeader);


			//
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Hidden Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(FlightPlanOpsRecords item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var ll = Lifelength.Null;

			var llColor = itemsListView.ForeColor;

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
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

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

			var subItem = new ListViewItem.ListViewSubItem { Text = flightNum.ToString(), Tag = flightNum };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = aircraft, Tag = item.Aircraft };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = aircraftExchange, Tag = item.AircraftExchange };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = status, Tag = item.Status };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = reasonDelay, Tag = reasonDelay };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = reasonCansellation, Tag = reasonCansellation };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = reason, Tag = reason };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = days, Tag = days };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = direction, Tag = direction };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = depArrS, Tag = depArrS };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = flightTimeS, Tag = flightTimeS };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = depArrD, Tag = depArrD };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = flightTimeD, Tag = flightTimeD };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = depDelayString, Tag = depDelayString };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = arrEstimatedString, Tag = arrEstimatedString };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = arrDelayString, Tag = arrDelayString };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = depArrF, Tag = depArrF };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = flightTimeF, Tag = flightTimeF };
			subItems.Add(subItem);

			if (_calculated)
			{
				subItem = new ListViewItem.ListViewSubItem { ForeColor = llColor, Text = ll.ToHoursMinutesAndCyclesFormat("", ""), Tag = ll };
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
			}

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

			subItem = new ListViewItem.ListViewSubItem { Text = flType, Tag = flType };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = flCat, Tag = flCat };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.HiddenRemarks, Tag = item.HiddenRemarks };
			subItems.Add(subItem);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();

			if (columnIndex == 1)
			{
				foreach (var items in ListViewItemList.Where(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft != null)
																.GroupBy(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft))
				{
					string temp;

					foreach (var item in items)
					{
						if (item.Tag is FlightPlanOpsRecords)
						{
							var rec = item.Tag as FlightPlanOpsRecords;
							var flTrack = rec.FlightTrackRecord;

							string date;
							if (rec.FlightTrackRecord.FlightType == FlightType.Schedule)
								date = rec.Date.ToString("dd-MMMM-yyyy");
							else date = rec.FlightTrackRecord.FlightNumberPeriod.DepartureDate.ToString("dd-MMMM-yyyy");

							temp = $"{date} {flTrack.DayOfWeek.ShortName} - {flTrack.DayOfWeek.FullName} {flTrack.TripName} ({flTrack.Schedule}) {items.Key}";
							itemsListView.Groups.Add(temp, temp);
							item.Group = itemsListView.Groups[temp];
						}
					}
				}
			}
			else
			{
				foreach (ListViewItem item in ListViewItemList.OrderBy(i => ((FlightPlanOpsRecords)i.Tag).Date)
					.ThenBy(i => (i.Tag as FlightPlanOpsRecords)?.FlightTrack.TripName)
					.ThenBy(i => ((FlightPlanOpsRecords)i.Tag).PeriodFrom))
				{
					string temp;

					if (item.Tag is FlightPlanOpsRecords)
					{
						var rec = item.Tag as FlightPlanOpsRecords;
						var flTrack = rec.FlightTrackRecord;
						var total = new TimeSpan();

						foreach (var record in ListViewItemList.Where(i => (i.Tag as FlightPlanOpsRecords).FlightTrack.ItemId == rec.FlightTrack.ItemId).Select(i => i.Tag))
						{
							var period = record as FlightPlanOpsRecords;

							var flightDifference = UsefulMethods.GetDifference(new TimeSpan(0, period.FlightTrackRecord.FlightNumberPeriod.PeriodTo, 0), new TimeSpan(0, period.FlightTrackRecord.FlightNumberPeriod.PeriodFrom, 0));
							total = total.Add(flightDifference);
						}

						string date;
						if (rec.FlightTrackRecord.FlightType == FlightType.Schedule)
							date = rec.Date.ToString("dd-MMMM-yyyy");
						else date = rec.FlightTrackRecord.FlightNumberPeriod.DepartureDate.ToString("dd-MMMM-yyyy");

						temp = $"{date} {flTrack.DayOfWeek.ShortName} - {flTrack.DayOfWeek.FullName} {flTrack.TripName} ({flTrack.FlightTypeString}) ({flTrack.Schedule}) | Total: {UsefulMethods.TimeToString(total)}";
						itemsListView.Groups.Add(temp, temp);
						item.Group = itemsListView.Groups[temp];
					}
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

			if (columnIndex == 1)
				itemsListView.Items.AddRange(ListViewItemList.Where(i => ((FlightPlanOpsRecords)i.Tag).CurrentAircraft != null).ToArray());
			else itemsListView.Items.AddRange(ListViewItemList.ToArray());

			OldColumnIndex = columnIndex;
			SetItemsColor();
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
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
		protected override void SetItemColor(ListViewItem listViewItem, FlightPlanOpsRecords item)
		{
			Color itemForeColor = Color.Gray;

			listViewItem.BackColor = UsefulMethods.GetColor(item);
			Color listViewForeColor = ItemListView.ForeColor;

			if (listViewItem.SubItems.OfType<ListViewItem.ListViewSubItem>().Count(lvsi => lvsi.ForeColor.ToArgb() != listViewForeColor.ToArgb()) == 0)
				listViewItem.ForeColor = itemForeColor;
			else
			{
				listViewItem.UseItemStyleForSubItems = false;
				foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
				{
					if (subItem.ForeColor.ToArgb() == listViewForeColor.ToArgb())
						subItem.ForeColor = itemForeColor;
				}
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
