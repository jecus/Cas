using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFCore.DTO.General;
using EFCore.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Filters;
using SmartCore.Management;

namespace SmartCore.Tests.MongoTest
{
	[TestClass]
	public class MongoTest
	{
		[TestMethod]
		public async Task CreateFlight()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var itemRelationCore = new ItemsRelationsDataAccess(env);
			var directiveCore = new DirectiveCore(env.NewKeeper, env.NewLoader, env.Keeper, env.Loader, itemRelationCore);
			var componentCore = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemRelationCore);
			var aircraftFlightCore = new AircraftFlightCore(env, env.Loader, env.NewLoader, directiveCore, env.Manipulator, componentCore, env.NewKeeper, aircraftCore);

			var context = new MongoContext("mongodb://localhost:27017/CasFlights");
			aircraftCore.LoadAllAircrafts();
			var aircrafts = aircraftCore.GetAllAircrafts();
			foreach (var aircraft in aircrafts)
			{
				Trace.WriteLine(aircraft);

				var atldIds = env.NewLoader.GetSelectColumnOnly<ATLBDTO>(new[] { new Filter("AircraftID", aircraft.ItemId) }, "ItemId");

				if (atldIds.Count == 0)
					return;

				Stopwatch s1 = new Stopwatch();
				s1.Start();
				var flights = env.Loader.GetObjectList<AircraftFlight>(new ICommonFilter[]
				{
					new CommonFilter<int>(AircraftFlight.ATLBIdProperty, FilterType.In, atldIds.ToArray()),
				});
				s1.Stop();
				Trace.WriteLine($"SQL:{s1.Elapsed} / Count:{flights.Count}");

				Stopwatch s = new Stopwatch();
				s.Start();
				var fl = context.Flights.Find(i => atldIds.Contains(i.ATLBID)).ToList();
				s.Stop();

				Trace.WriteLine($"SQL:{s.Elapsed} / Count:{fl.Count}");

				Trace.WriteLine("");
			}

			

			
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.Connect("91.213.233.139:45617", "casadmin", "casadmin001", "ScatDB");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}