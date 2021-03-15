using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Management;

namespace SmartCore.Tests
{
	[TestClass]
	public class AircraftFlightCoreTests
	{

		[TestMethod]
		public void CheckQueryAircraftFlight()
		{
			var enviroment = GetEnviroment();
			enviroment.NewLoader.FirstLoad();
			var aircraftCore = new AircraftsCore(enviroment.Loader, enviroment.NewKeeper, enviroment.NewLoader);
			aircraftCore.LoadAllAircrafts();
			var itemsRelationsDataAccess = new ItemsRelationsDataAccess(enviroment);
			var componentCore = new ComponentCore(enviroment, enviroment.Loader, enviroment.NewLoader, enviroment.NewKeeper, aircraftCore, itemsRelationsDataAccess);
			var aircraftFlightCore = new AircraftFlightCore(enviroment, enviroment.Loader, enviroment.NewLoader, null, null, componentCore, null, aircraftCore);
			aircraftFlightCore.LoadAircraftFlights(2316);
			//aircraftFlightCore.LoadAllFlights();
		}


		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139", "castester", "castester1", "CASTest");
			DbTypes.CasEnvironment = cas;

			return cas;
		}
	}
}