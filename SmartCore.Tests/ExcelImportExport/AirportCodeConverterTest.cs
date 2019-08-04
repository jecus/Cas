using System.Diagnostics;
using System.Linq;
using EntityCore.DTO.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Management;

namespace SmartCore.Tests.ExcelImportExport
{
	[TestClass]
	public class AirportCodeConverterTest
	{

		[TestMethod]
		public void ConvertAirportCodesForFlights()
		{
			var env = GetEnviroment();

			var flights = env.NewLoader.GetObjectListAll<AircraftFlightDTO,AircraftFlight>();
			var codes = env.GetDictionary<AirportsCodes>().ToArray().Cast<AirportsCodes>();

			foreach (var flight in flights)
			{
				AirportsCodes from = AirportsCodes.Unknown;
				AirportsCodes to = AirportsCodes.Unknown;

				var stationFrom = flight.StationFrom.Trim();
				var stationTo = flight.StationTo.Trim();

				if (stationFrom.Length <= 3)
					from = codes.FirstOrDefault(c => c.ShortName.ToUpper() == stationFrom.ToUpper());
				else if(stationFrom.Length > 3)
					from = codes.FirstOrDefault(c => c.Icao.ToUpper() == stationFrom.ToUpper());

				if (stationTo.Length <= 3)
					to = codes.FirstOrDefault(c => c.ShortName.ToUpper() == stationTo.ToUpper());
				else if (stationTo.Length > 3)
					to = codes.FirstOrDefault(c => c.Icao.ToUpper() == stationTo.ToUpper());

				if (to != null)
					flight.StationToId = to;
				else
				{
					flight.StationToId = AirportsCodes.Unknown;
					Trace.WriteLine(flight.StationTo);
				}
				if (from != null)
					flight.StationFromId = from;
				else
				{
					flight.StationFromId = AirportsCodes.Unknown;
					Trace.WriteLine(flight.StationFrom);
				}



				env.NewKeeper.Save(flight);
			}
		}

		[TestMethod]
		public void ConvertFlightsNumForFlights()
		{
			var env = GetEnviroment();
			var flights = env.NewLoader.GetObjectListAll<AircraftFlightDTO,AircraftFlight>().OrderBy(x => x.FlightNo);
			var flightNums = env.GetDictionary<FlightNum>().Cast<FlightNum>().ToList();

			foreach (var flight in flights)
			{
				var flightNum = flightNums.FirstOrDefault(x => x.FullName == flight.FlightNo);
				if (flightNum == null)
				{
					var newFlightNum = new FlightNum { FullName = flight.FlightNo };
					env.NewKeeper.Save(newFlightNum);
					flightNums.Add(newFlightNum);

					flight.FlightNumber = newFlightNum;
				}
				else
				{
					flight.FlightNumber = flightNum;
				}

				env.NewKeeper.Save(flight);
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "casadmin", "casadmin001", "ScatDB");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}