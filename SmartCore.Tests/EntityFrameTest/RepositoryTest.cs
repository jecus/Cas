using System.Collections.Generic;
using System.Diagnostics;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using EFCore.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.DtoHelper;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Commercial;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.SMS;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Files;
using SmartCore.Purchase;
using SmartCore.Relation;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class RepositoryTest
	{
		[TestMethod]
		public void AircraftFlightTest()
		{
			var context = new DataContext();
			var repo = new Repository<ComponentDTO>(new DataContext());
			var component = repo.GetObject(new List<Filter>
			{
				new Filter("ItemId", 76523),
				new Filter("IsBaseComponent", false)
			}, true, false, true);

			foreach (var componentComponentDirective in component.ComponentDirectives)
			{
				Trace.WriteLine(componentComponentDirective.PerformanceRecords.Count);
			}
			Trace.WriteLine(component);
			//var repo = new Repository<AircraftFlightDTO>(new DataContext());

			//var watch = new Stopwatch();

			//watch.Start();
			//var query = repo.GetObjectList(loadChild:true);
			//watch.Stop();

			//Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			//watch.Reset();

			//watch.Start();
			//var list = new List<AircraftFlight>();
			//foreach (var flightDto in query)
			//{
			//	list.Add(flightDto.Convert());
			//}
			//watch.Stop();

			//Trace.WriteLine(watch.Elapsed.TotalSeconds);
			//watch.Reset();

			//Trace.WriteLine(list.Count);
			//Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AGWCategoryTest()
		{
			var repo = new Repository<AGWCategorieDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AGWCategory>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftModelTest()
		{
			var repo = new Repository<AccessoryDescriptionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AircraftModel>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.ConvertToAircraftModel());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftOtherParametersTest()
		{
			var repo = new Repository<AircraftOtherParameterDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AircraftOtherParameters>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AirportsCodesTest()
		{
			var repo = new Repository<AirportCodeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AirportsCodes>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AirportTest()
		{
			var repo = new Repository<AirportDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Airport>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentModelTest()
		{
			var repo = new Repository<AccessoryDescriptionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentModel>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.ConvertToComponentModel());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ProductTest()
		{
			var repo = new Repository<AccessoryDescriptionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Product>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.ConvertToProduct());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AtaChapterTest()
		{
			var repo = new Repository<ATAChapterDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AtaChapter>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void GoodStandartTest()
		{
			var repo = new Repository<GoodStandartDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<GoodStandart>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void CruiseLevelTest()
		{
			var repo = new Repository<CruiseLevelDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<CruiseLevel>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DamageChartTest()
		{
			var repo = new Repository<DamageChartDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DamageChart>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DeferredCategoryTest()
		{
			var repo = new Repository<DefferedCategorieDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DeferredCategory>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DepartmentTest()
		{
			var repo = new Repository<DepartmentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Department>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DocumentSubTypeTest()
		{
			var repo = new Repository<DocumentSubTypeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DocumentSubType>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EmployeeSubjectTest()
		{
			var repo = new Repository<EmployeeSubjectDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EmployeeSubject>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EventCategoryTest()
		{
			var repo = new Repository<EventCategorieDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EventCategory>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EventClassTest()
		{
			var repo = new Repository<EventClassDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EventClass>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumTest()
		{
			var repo = new Repository<FlightNumDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNum>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void LicenseRemarkRightsTest()
		{
			var repo = new Repository<LicenseRemarkRightDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<LicenseRemarkRights>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
		
		[TestMethod]
		public void LLPLifeLimitCategoryTest()
		{
			var repo = new Repository<LifeLimitCategorieDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<LLPLifeLimitCategory>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void LocationsTest()
		{
			var repo = new Repository<LocationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Locations>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void LocationsTypeTest()
		{
			var repo = new Repository<LocationsTypeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<LocationsType>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void NomenclaturesTest()
		{
			var repo = new Repository<NomenclatureDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Nomenclatures>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void NonRoutineJobTest()
		{
			var repo = new Repository<NonRoutineJobDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<NonRoutineJob>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ReasonTest()
		{
			var repo = new Repository<ReasonDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Reason>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void LicenseRestrictionTest()
		{
			var repo = new Repository<RestrictionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<LicenseRestriction>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SchedulePeriodsTest()
		{
			var repo = new Repository<SchedulePeriodDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SchedulePeriods>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ServiceTypeTest()
		{
			var repo = new Repository<ServiceTypeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ServiceType>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecializationTest()
		{
			var repo = new Repository<SpecializationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Specialization>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void TripNameTest()
		{
			var repo = new Repository<TripNameDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<TripName>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}
			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
	}

	[TestClass]
	public class GeneralRepositoryTest
	{
		[TestMethod]
		public void AccessoryRequiredTest()
		{
			var repo = new Repository<AccessoryRequiredDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AccessoryRequired>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ActualStateRecordTest()
		{
			var repo = new Repository<ActualStateRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ActualStateRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftTest()
		{
			var repo = new Repository<AircraftDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Aircraft>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EngineConditionTest()
		{
			var repo = new Repository<EngineConditionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EngineCondition>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceProgramChangeRecordTest()
		{
			var repo = new Repository<MaintenanceProgramChangeRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceProgramChangeRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void JobCardTest()
		{
			var repo = new Repository<JobCardDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<JobCard>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void JobCardTaskTest()
		{
			var repo = new Repository<JobCardTaskDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<JobCardTask>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
		
		[TestMethod]
		public void SpecialistTest()
		{
			var repo = new Repository<SpecialistDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Specialist>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistTrainingTest()
		{
			var repo = new Repository<SpecialistTrainingDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistTraining>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistLicenseTest()
		{
			var repo = new Repository<SpecialistLicenseDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistLicense>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistLicenseRemarkTest()
		{
			var repo = new Repository<SpecialistLicenseRemarkDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistLicenseRemark>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistInstrumentRatingTest()
		{
			var repo = new Repository<SpecialistInstrumentRatingDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistInstrumentRating>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistLicenseRatingTest()
		{
			var repo = new Repository<SpecialistLicenseRatingDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistLicenseRating>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistLicenseDetailTest()
		{
			var repo = new Repository<SpecialistLicenseDetailDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistLicenseDetail>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SpecialistCAATest()
		{
			var repo = new Repository<SpecialistCAADTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SpecialistCAA>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
		
		[TestMethod]
		public void DocumentTest()
		{
			var repo = new Repository<DocumentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Document>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SupplierTest()
		{
			var repo = new Repository<SupplierDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Supplier>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void CategoryRecordTest()
		{
			var repo = new Repository<CategoryRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<CategoryRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftWorkerCategoryTest()
		{
			var repo = new Repository<AircraftWorkerCategoryDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AircraftWorkerCategory>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
		//An error occurred while reading from the store provider's data reader. See the inner exception for details.
		//Время ожидания выполнения истекло. Время ожидания истекло до завершения операции, или сервер не отвечает.
		[TestMethod]
		public void ItemFileLinkTest()
		{
			var repo = new Repository<ItemFileLinkDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ItemFileLink>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}
		//Выдано исключение типа "System.OutOfMemoryException"..
		//в System.Data.SqlClient.TdsParserStateObject.TryReadPlpBytes(Byte[]& buff, Int32 offst, Int32 len, Int32& totalBytesRead)
		[TestMethod]
		public void AttachedFileTest()
		{
			var repo = new Repository<AttachedFileDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AttachedFile>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AuditTest()
		{
			var repo = new Repository<AuditDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Audit>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AuditRecordTest()
		{
			var repo = new Repository<AuditRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AuditRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftEquipmentsTest()
		{
			var repo = new Repository<AircraftEquipmentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AircraftEquipments>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void AircraftFlightTest()
		{
			var repo = new Repository<AircraftFlightDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<AircraftFlight>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ATLBTest()
		{
			var repo = new Repository<ATLBDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ATLB>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void CertificateOfReleaseToServiceTest()
		{
			var repo = new Repository<CertificateOfReleaseToServiceDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<CertificateOfReleaseToService>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentDirectiveTest()
		{
			var repo = new Repository<ComponentDirectiveDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentDirective>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentTest()
		{
			var repo = new Repository<ComponentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Entities.General.Accessory.Component>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void BaseComponentTest()
		{
			var repo = new Repository<ComponentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<BaseComponent>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.ConvertToBaseComponent());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentLLPCategoryChangeRecordTest()
		{
			var repo = new Repository<ComponentLLPCategoryChangeRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentLLPCategoryChangeRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentLLPCategoryDataTest()
		{
			var repo = new Repository<ComponentLLPCategoryDataDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentLLPCategoryData>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentOilConditionTest()
		{
			var repo = new Repository<ComponentOilConditionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentOilCondition>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ComponentWorkInRegimeParamsTest()
		{
			var repo = new Repository<ComponentWorkInRegimeParamDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ComponentWorkInRegimeParams>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DamageDocumentTest()
		{
			var repo = new Repository<DamageDocumentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DamageDocument>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DamageSectorTest()
		{
			var repo = new Repository<DamageSectorDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DamageSector>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DirectiveTest()
		{
			var repo = new Repository<DirectiveDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Directive>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DirectiveRecordTest()
		{
			var repo = new Repository<DirectiveRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<DirectiveRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceCheckRecordTest()
		{
			var repo = new Repository<DirectiveRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceCheckRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.ConvertToMaintenanceCheckRecord());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void DiscrepancyTest()
		{
			var repo = new Repository<DiscrepancyDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Discrepancy>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EngineAccelerationTimeTest()
		{
			var repo = new Repository<EngineAccelerationTimeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EngineAccelerationTime>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EngineTimeInRegimeTest()
		{
			var repo = new Repository<EngineTimeInRegimeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EngineTimeInRegime>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EventConditionTest()
		{
			var repo = new Repository<EventConditionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EventCondition>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EventTest()
		{
			var repo = new Repository<EventDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Event>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void EventTypeRiskLevelChangeRecordTest()
		{
			var repo = new Repository<EventTypeRiskLevelChangeRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<EventTypeRiskLevelChangeRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightCargoRecordTest()
		{
			var repo = new Repository<FlightCargoRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightCargoRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightCrewRecordTest()
		{
			var repo = new Repository<FlightCrewRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightCrewRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumberAircraftModelRelationTest()
		{
			var repo = new Repository<FlightNumberAircraftModelRelationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNumberAircraftModelRelation>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumberAirportRelationTest()
		{
			var repo = new Repository<FlightNumberAirportRelationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNumberAirportRelation>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumberCrewRecordTest()
		{
			var repo = new Repository<FlightNumberCrewRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNumberCrewRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumberTest()
		{
			var repo = new Repository<FlightNumberDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNumber>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightNumberPeriodTest()
		{
			var repo = new Repository<FlightNumberPeriodDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightNumberPeriod>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightPassengerRecordTest()
		{
			var repo = new Repository<FlightPassengerRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightPassengerRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightPlanOpsTest()
		{
			var repo = new Repository<FlightPlanOpsDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightPlanOps>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightPlanOpsRecordsTest()
		{
			var repo = new Repository<FlightPlanOpsRecordsDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightPlanOpsRecords>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightTrackTest()
		{
			var repo = new Repository<FlightTrackDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightTrack>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void FlightTrackRecordTest()
		{
			var repo = new Repository<FlightTrackRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<FlightTrackRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void HangarTest()
		{
			var repo = new Repository<HangarDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Hangar>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void HydraulicConditionTest()
		{
			var repo = new Repository<HydraulicConditionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<HydraulicCondition>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void InitialOrderTest()
		{
			var repo = new Repository<InitialOrderDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<InitialOrder>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void InitialOrderRecordTest()
		{
			var repo = new Repository<InitialOrderRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<InitialOrderRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ItemsRelationTest()
		{
			var repo = new Repository<ItemsRelationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ItemsRelation>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void KitSuppliersRelationTest()
		{
			var repo = new Repository<KitSuppliersRelationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<KitSuppliersRelation>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void KnowledgeModuleTest()
		{
			var repo = new Repository<KnowledgeModuleDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<KnowledgeModule>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void LandingGearConditionTest()
		{
			var repo = new Repository<LandingGearConditionDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<LandingGearCondition>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceCheckBindTaskRecordTest()
		{
			var repo = new Repository<MaintenanceCheckBindTaskRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceCheckBindTaskRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceCheckTest()
		{
			var repo = new Repository<MaintenanceCheckDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceCheck>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceCheckTypeTest()
		{
			var repo = new Repository<MaintenanceCheckTypeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceCheckType>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ModuleRecordTest()
		{
			var repo = new Repository<ModuleRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ModuleRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MTOPCheckTest()
		{
			var repo = new Repository<MTOPCheckDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MTOPCheck>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MTOPCheckRecordTest()
		{
			var repo = new Repository<MTOPCheckRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MTOPCheckRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ProcedureDocumentReferenceTest()
		{
			var repo = new Repository<ProcedureDocumentReferenceDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ProcedureDocumentReference>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ProcedureTest()
		{
			var repo = new Repository<ProcedureDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Procedure>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void ProductCostTest()
		{
			var repo = new Repository<ProductCostDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<ProductCost>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void PurchaseOrderTest()
		{
			var repo = new Repository<PurchaseOrderDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<PurchaseOrder>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void PurchaseRequestRecordTest()
		{
			var repo = new Repository<PurchaseRequestRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<PurchaseRequestRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void RequestTest()
		{
			var repo = new Repository<RequestDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Request>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void RequestForQuotationTest()
		{
			var repo = new Repository<RequestForQuotationDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<RequestForQuotation>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void RequestForQuotationRecordTest()
		{
			var repo = new Repository<RequestForQuotationRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<RequestForQuotationRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void RequestRecordTest()
		{
			var repo = new Repository<RequestRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<RequestRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void RunUpTest()
		{
			var repo = new Repository<RunUpDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<RunUp>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SmsEventTypeTest()
		{
			var repo = new Repository<SmsEventTypeDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SmsEventType>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void StockComponentInfoTest()
		{
			var repo = new Repository<StockComponentInfoDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<StockComponentInfo>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void StoreTest()
		{
			var repo = new Repository<StoreDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Store>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void SupplierDocumentTest()
		{
			var repo = new Repository<SupplierDocumentDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<SupplierDocument>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void TransferRecordTest()
		{
			var repo = new Repository<TransferRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<TransferRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void VehicleTest()
		{
			var repo = new Repository<VehicleDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Vehicle>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkOrderTest()
		{
			var repo = new Repository<WorkOrderDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkOrder>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkOrderRecordTest()
		{
			var repo = new Repository<WorkOrderRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkOrderRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkPackageTest()
		{
			var repo = new Repository<WorkPackageDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkPackage>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkPackageRecordTest()
		{
			var repo = new Repository<WorkPackageRecordDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkPackageRecord>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkPackageSpecialistsTest()
		{
			var repo = new Repository<WorkPackageSpecialistsDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkPackageSpecialists>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void WorkShopTest()
		{
			var repo = new Repository<WorkShopDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<WorkShop>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void MaintenanceDirectiveTest()
		{
			var repo = new Repository<MaintenanceDirectiveDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<MaintenanceDirective>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

		[TestMethod]
		public void OperatorTest()
		{
			var repo = new Repository<OperatorDTO>(new DataContext());

			var watch = new Stopwatch();

			watch.Start();
			var query = repo.GetObjectList(loadChild: true);
			watch.Stop();

			Trace.WriteLine($"Загрузка : {watch.Elapsed.TotalSeconds}");
			watch.Reset();

			watch.Start();
			var list = new List<Operator>();
			foreach (var flightDto in query)
			{
				list.Add(flightDto.Convert());
			}

			watch.Stop();

			Trace.WriteLine(watch.Elapsed.TotalSeconds);
			watch.Reset();

			Trace.WriteLine(list.Count);
			Trace.WriteLine(query.Count);
		}

	}
}