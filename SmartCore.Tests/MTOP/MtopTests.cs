using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.ForecastControls;
using EntityCore.DTO.General;
using EntityCore.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Calculations.MTOP.Interfaces;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MTOP;
using SmartCore.Management;

namespace SmartCore.Tests.MTOP
{
	[TestClass]
	public class MtopTests
	{
		[TestMethod]
		public void TestMpd()
		{
			var env = GetEnviroment();
			var aircraftCore = new AircraftsCore(env.Loader, env.NewKeeper, env.NewLoader);
			var mtopCalc = new MTOPCalculator(env.Calculator, aircraftCore);
			var itemsRelationsDataAccess = new ItemsRelationsDataAccess(env);
			var compontntService = new ComponentCore(env, env.Loader, env.NewLoader, env.NewKeeper, aircraftCore, itemsRelationsDataAccess);
			var directiveService = new DirectiveCore(env.NewKeeper, env.NewLoader, env.Keeper, env.Loader, itemsRelationsDataAccess);
			var aircraftFlightService = new AircraftFlightCore(env, env.Loader, env.NewLoader, directiveService, env.Manipulator, compontntService, env.NewKeeper, aircraftCore);
			var calculator = new Calculator(env, compontntService, aircraftFlightService, aircraftCore);

			env.Calculator = calculator;

			aircraftCore.LoadAllAircrafts();
			var aircraft = aircraftCore.GetAircraftById(2348);

			var _currentForecast = new Forecast { Aircraft = aircraft };
			var form = new ForecastCustomsMTOPTest(aircraft, _currentForecast, env);
			if (form.ShowDialog() == DialogResult.OK)
			{
				//Берем утилизацию с Frame
				var frame = env.BaseComponents.FirstOrDefault(i => i.ParentAircraftId == aircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
				var avg = _currentForecast.ForecastDatas[0].AverageUtilization;

				var checks = env.NewLoader.GetObjectListAll<MTOPCheckDTO, MTOPCheck>(new Filter("ParentAircraftId", 0), true).ToList();
				var lastCompliance = checks.Where(i => !i.IsZeroPhase).SelectMany(i => i.PerformanceRecords).OrderByDescending(i => i.RecordDate).FirstOrDefault();

				
				mtopCalc.CalculateMtopChecks(checks, avg);

				var _groupLifelengths = mtopCalc.CalculateGroupNew(checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList());

				mtopCalc.CalculateNextPerformance(checks.Where(i => !i.IsZeroPhase).ToList(), frame.StartDate, _groupLifelengths, aircraft, avg, lastCompliance);
				mtopCalc.CalculateNextPerformance(checks.Where(i => !i.IsZeroPhase).ToList(), frame.StartDate, _groupLifelengths, aircraft, avg, lastCompliance, true);

				mtopCalc.CalculatePhaseWithPerformance(new IMtopCalc[]{}, checks.Where(i => !i.Thresh.IsNullOrZero() && !i.IsZeroPhase).ToList(), avg, _currentForecast.ForecastDatas[0].LowerLimit, _currentForecast.ForecastDatas[0].ForecastDate);
			}
		}

		private CasEnvironment GetEnviroment()
		{
			var cas = new CasEnvironment();
			cas.ApiProvider = new ApiProvider("http://91.213.233.139:45619");
			cas.Connect("91.213.233.139:45619", "casadmin", "casadmin001", "ScatDB");
			DbTypes.CasEnvironment = cas;
			cas.NewLoader.FirstLoad();

			return cas;
		}
	}
}