using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ScheduleControls.PlanOPS;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.AircraftStatus
{
	public partial class AircraftScreenListView : BaseListViewControl<FlightPlanOpsRecords>
	{
		#region Fields

		private readonly AnimatedThreadWorker _animatedThreadWorker;

		#endregion

		#region Constructor

		public AircraftScreenListView()
		{
			InitializeComponent();
		}

		public AircraftScreenListView(AnimatedThreadWorker animatedThreadWorker) : this()
		{
			_animatedThreadWorker = animatedThreadWorker;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Aircraft" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Delay" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.16f), Text = "Cancellation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.13f), Text = "Flight №" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Flight Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Direction" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Downtime" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(FlightPlanOpsRecords item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var aircraft = $"{item.CurrentAircraft.RegistrationNumber} {item.CurrentAircraft.Model.ShortName}";
			var reasonDelay = item.DelayReason?.ToString() ?? "";
			var reasonCansellation = item.CancelReason?.ToString() ?? "";
			var direction = $"{item.ParentFlight.StationFromId.ShortName} - {item.ParentFlight.StationToId.ShortName}";
			var status = item.Status != OpsStatus.Unknown ? item.Status.ToString() : "";
			var downTimeString = "";

			var time = DateTime.Now.Subtract(item.ParentFlight.FlightDate.AddMinutes(item.ParentFlight.LDGTime));

			if (time.TotalHours > 0)
			{
				var date = new DateTime(time.Ticks);

				if (date.Year > 1)
					downTimeString += $"{date.Year - 1}Y ";
				if (date.Month > 1)
					downTimeString += $"{date.Month - 1 }MO ";
				if (date.Day > 1)
					downTimeString += $"{date.Day - 1}d ";
				if (date.Hour > 0)
					downTimeString += $"{date.Hour}h ";
				if (date.Year < 1 && date.Month < 1 && date.Day < 1)
					downTimeString = date.ToString("HH:mm");
			}
			
			var subItem = new ListViewItem.ListViewSubItem { Text = aircraft, Tag = item.CurrentAircraft.ToString() };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = status, Tag = item.Status };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = reasonDelay, Tag = reasonDelay };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = reasonCansellation, Tag = reasonCansellation };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.ParentFlight.FlightNumber.ToString(), Tag = item.ParentFlight.FlightNumber };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.ParentFlight.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = item.ParentFlight.FlightDate };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = direction, Tag = direction };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = downTimeString, Tag = downTimeString };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks };
			subItems.Add(subItem);

			return subItems.ToArray();
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
	}
}
