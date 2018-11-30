using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeFlightListView : BaseListViewControl<AircraftFlight>
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
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Aircraft" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Occupation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Direction" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Flight time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Block time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Per Days (Flight)" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Per Days (Block)" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Night Time" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());

		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

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

			var subItem = new ListViewItem.ListViewSubItem { Text = dateString, Tag = date };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = aircraft, Tag = item.Aircraft };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialization.ToString(), Tag = item.Specialization };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = route, Tag = route };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = flightTimeString, Tag = item.FlightTime };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = UsefulMethods.TimeToString(item.BlockTime), Tag = item.BlockTime };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = perDaysFlight.ToHoursMinutesAndCyclesFormat("", ""), Tag = perDaysFlight };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = perDaysBlock.ToHoursMinutesAndCyclesFormat("", ""), Tag = perDaysBlock };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.NightTime.ToString(), Tag = item.NightTime };
			subItems.Add(subItem);

			return subItems.ToArray();
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
