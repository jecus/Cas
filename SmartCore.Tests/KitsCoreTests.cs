using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.Kits;
using SmartCore.Management;

namespace SmartCore.Tests
{
	[TestClass]
	public class KitsCoreTests
	{

		[TestMethod]
		public void TestQuery()
		{
			var enviroment = GetEnviroment();
			enviroment.NewLoader.FirstLoad();
			var aircraftCore = new AircraftsCore(enviroment.Loader, enviroment.NewKeeper, enviroment.NewLoader);
			aircraftCore.LoadAllAircrafts();
			var componentCore = new ComponentCore(enviroment, enviroment.Loader, enviroment.NewLoader, enviroment.NewKeeper, aircraftCore, null);
			var nrjDA = new NonRoutineJobDataAccess(enviroment.Loader, enviroment.Keeper);
			var kitsCore = new KitsCore(enviroment, enviroment.Loader, enviroment.NewKeeper, componentCore, nrjDA);

			kitsCore.GetAllAircraftKits(2316, 326);
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