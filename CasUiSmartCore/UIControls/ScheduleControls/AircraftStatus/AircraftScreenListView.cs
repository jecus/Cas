using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.ScheduleControls.PlanOPS;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.AircraftStatus
{
	public partial class AircraftScreenListView : BaseGridViewControl<FlightPlanOpsRecords>
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
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.4f));
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Delay", (int)(radGridView1.Width * 0.30f));
			AddColumn("Cancellation", (int)(radGridView1.Width * 0.32f));
			AddColumn("Flight №", (int)(radGridView1.Width * 0.26f));
			AddColumn("Flight Date", (int)(radGridView1.Width * 0.30f));
			AddColumn("Direction", (int)(radGridView1.Width * 0.24f));
			AddColumn("Downtime", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override List<CustomCell> GetListViewSubItems(FlightPlanOpsRecords item)
		{
			var subItems = new List<CustomCell>();

			var aircraft = $"{item.CurrentAircraft.RegistrationNumber} {item.CurrentAircraft.Model.ShortName}";
			var reasonDelay = item.DelayReason?.ToString() ?? "";
			var reasonCansellation = item.CancelReason?.ToString() ?? "";
			var direction = $"{item.ParentFlight.StationFromId.ShortName} - {item.ParentFlight.StationToId.ShortName}";
			var status = item.Status != OpsStatus.Unknown ? item.Status.ToString() : "";
			var downTimeString = "";

			var time = DateTime.Now.Subtract(item.ParentFlight.FlightDate.AddMinutes(item.ParentFlight.LDGTime));

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

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
			
			subItems.Add(CreateRow(aircraft, item.CurrentAircraft.ToString()));
			subItems.Add(CreateRow(status, item.Status));
			subItems.Add(CreateRow(reasonDelay, reasonDelay));
			subItems.Add(CreateRow(reasonCansellation, reasonCansellation));
			subItems.Add(CreateRow(item.ParentFlight.FlightNumber.ToString(), item.ParentFlight.FlightNumber));
			subItems.Add(CreateRow(item.ParentFlight.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), item.ParentFlight.FlightDate));
			subItems.Add(CreateRow(direction, direction));
			subItems.Add(CreateRow(downTimeString, downTimeString));
			subItems.Add(CreateRow(item.Remarks, item.Remarks));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

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
	}
}
