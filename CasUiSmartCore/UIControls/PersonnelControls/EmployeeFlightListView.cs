using System;
using System.Collections.Generic;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeFlightListView : BaseGridViewControl<AircraftFlight>
	{
		#region Properties

		private CommonCollection<AircraftFlight> _flights;
		public CommonCollection<AircraftFlight> Flights
		{
			get { return _flights ?? (_flights = new AircraftFlightCollection()); }
			set { _flights = value; }
		}

		#endregion

		#region Constructor

		public EmployeeFlightListView()
		{
			InitializeComponent();
			SortMultiplier = 1;
			OldColumnIndex = 0;
		}

		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Date", (int)(radGridView1.Width * 0.16f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.34f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.34f));
			AddColumn("Direction", (int)(radGridView1.Width * 0.10f));
			AddColumn("Flight time", (int)(radGridView1.Width * 0.30f));
			AddColumn("Block time", (int)(radGridView1.Width * 0.16f));
			AddColumn("Per Days (Flight)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Per Days (Block)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Night Time", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

		protected override List<CustomCell> GetListViewSubItems(AircraftFlight item)
		{
			var subItems = new List<CustomCell>();

			var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var date = item.FlightDate.Date.AddMinutes(item.OutTime);
			var aircraft = $"{item.Aircraft} {item.Aircraft.Model.ShortName}";

			var route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
			var flightTimeString = UsefulMethods.TimeToString(new TimeSpan(0, 0, item.FlightTimeTotalMinutes, 0)) + " (" +
			                       UsefulMethods.TimePeriodToString(new TimeSpan(0, 0, item.TakeOffTime, 0),
				                       new TimeSpan(0, 0, item.LDGTime, 0)) + ")";

			var perDaysFlight = Lifelength.Zero;
			var perDaysBlock = Lifelength.Zero;
			var flights = Flights.Where(f => f.FlightDate.Date.AddMinutes(f.TakeOffTime) <=
			                                 item.FlightDate.Date.AddMinutes(item.TakeOffTime)).ToList();
			foreach (var aircraftFlight in flights)
			{
				perDaysFlight.Add(aircraftFlight.FlightTimeLifelength);
				perDaysBlock.Add(aircraftFlight.BlockTimeLifelenght);
			}

			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			
			return new List<CustomCell>
			{
				CreateRow(dateString, Tag = date),
				CreateRow(aircraft, item.Aircraft),
				CreateRow(item.Specialization.ToString(), item.Specialization),
				CreateRow(route, route),
				CreateRow(flightTimeString, item.FlightTime),
				CreateRow(UsefulMethods.TimeToString(item.BlockTime), item.BlockTime),
				CreateRow(perDaysFlight.ToHoursMinutesAndCyclesFormat("", ""), perDaysFlight),
				CreateRow(perDaysBlock.ToHoursMinutesAndCyclesFormat("", ""), perDaysBlock),
				CreateRow(item.NightTime.ToString(), item.NightTime),
				CreateRow(author, author)
			};
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.RequestedEntity = new FlightScreen(SelectedItem);
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(SelectedItem.AircraftId);
				e.DisplayerText = parentAircraft.RegistrationNumber + ". " + SelectedItem;
			}
		}
		#endregion
	}
}
