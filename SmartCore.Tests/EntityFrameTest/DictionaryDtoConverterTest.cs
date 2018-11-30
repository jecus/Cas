using System;
using EFCore.DTO.Dictionaries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.DtoHelper;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class DictionaryDtoConverterTest
	{
		[TestMethod]
		public void TestAGWCategorieDTOConverter()
		{
			var agw = new AGWCategory
			{
				ItemId = 2,
				IsDeleted = false,
				FullName = "Test",
				Gender = Gender.Male,
				MinAge = 18,
				MaxAge = 40,
				WeightSummer = 40,
				WeightWinter = 50
			};

			//Конвуртаций в DTO
			var dto = agw.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, agw.ItemId);
			Assert.AreEqual(dto.IsDeleted, agw.IsDeleted);
			Assert.AreEqual(dto.Gender, (short)agw.Gender);
			Assert.AreEqual(dto.MinAge, agw.MinAge);
			Assert.AreEqual(dto.MaxAge, agw.MaxAge);
			Assert.AreEqual(dto.WeightSummer, agw.WeightSummer);
			Assert.AreEqual(dto.WeightWinter, agw.WeightWinter);


			//Конвуртаций в BL
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Gender, (short)bl.Gender);
			Assert.AreEqual(dto.MinAge, bl.MinAge);
			Assert.AreEqual(dto.MaxAge, bl.MaxAge);
			Assert.AreEqual(dto.WeightSummer, bl.WeightSummer);
			Assert.AreEqual(dto.WeightWinter, bl.WeightWinter);

		}

		[TestMethod]
		public void TestAccessoryDescriptionDTOConverter()
		{
			var ata = new ATAChapterDTO()
			{
				ItemId = 456,
				IsDeleted = true,
				ShortName = "test",
				FullName = "test"
			};

			var standart = new GoodStandartDTO()
			{
				ItemId = 324,
				IsDeleted = true,
				Name = "testname",
				PartNumber = "testpartnum",
				Description = "testdesc",
				Remarks = "testrem",
				DefaultProductId = 324,
				ComponentType = 123
			};

			var acd = new AccessoryDescriptionDTO()
			{
				ItemId = 3,
				IsDeleted = false,
				Model = "testasd",
				PartNumber = "34",
				ATAChapter = ata,
				AtaChapterId = ata.ItemId,				
				Description = "testdesc",
				GoodStandart = standart,
				StandartId = standart.ItemId,
				Manufacturer = "testmanuf",
				CostNew = 4,
				CostOverhaul = 5,
				CostServiceable = 6,
				Measure = Measure.Centimeters.ItemId,
				Remarks = "8",
				ModelingObjectTypeId = 9,
				ModelingObjectSubTypeId = ManufactureRegion.Western.ItemId,
				SubModel = "11",
				FullName = "testfull",
				ShortName = "testshort",
				Designer = "testdesign",
				Code = "testcode",
				ComponentClass = (short)GoodsClass.Accessories.ItemId,
				IsDangerous = true
			};
			
			var dto = acd.ConvertToAircraftModel();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, acd.ItemId);
			Assert.AreEqual(dto.IsDeleted, acd.IsDeleted);
			Assert.AreEqual(dto.PartNumber, acd.PartNumber);
			Assert.AreEqual(dto.ATAChapter, ata.Convert());
			Assert.AreEqual(dto.Description, acd.Description);
			Assert.AreEqual(dto.Standart, standart.Convert());
			Assert.AreEqual(dto.Manufacturer, acd.Manufacturer);
			Assert.AreEqual(dto.CostNew, acd.CostNew);
			Assert.AreEqual(dto.CostOverhaul, acd.CostOverhaul);
			Assert.AreEqual(dto.CostServiceable, acd.CostServiceable);
			Assert.AreEqual(dto.Measure, Measure.Centimeters);
			Assert.AreEqual(dto.Remarks, acd.Remarks);
			Assert.AreEqual(dto.ManufactureReg, ManufactureRegion.Western);
			Assert.AreEqual(dto.Series, acd.SubModel);
			Assert.AreEqual(dto.Name, acd.Model);
			Assert.AreEqual(dto.FullName, acd.FullName);
			Assert.AreEqual(dto.ShortName, acd.ShortName);
			Assert.AreEqual(dto.Designer, acd.Designer);
			Assert.AreEqual(dto.Code, acd.Code);
			Assert.AreEqual(dto.GoodsClass, GoodsClass.Accessories);
			Assert.AreEqual(dto.IsDangerous, acd.IsDangerous);
			
			var bl = dto.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.PartNumber, bl.PartNumber);
			Assert.AreEqual(dto.ATAChapter.ItemId, bl.AtaChapterId);
			Assert.AreEqual(dto.Description, bl.Description);
			Assert.AreEqual(dto.Standart.ItemId, bl.StandartId);
			Assert.AreEqual(dto.Manufacturer, bl.Manufacturer);
			Assert.AreEqual(dto.CostNew, bl.CostNew);
			Assert.AreEqual(dto.CostOverhaul, bl.CostOverhaul);
			Assert.AreEqual(dto.CostServiceable, bl.CostServiceable);
			Assert.AreEqual(dto.Measure.ItemId, bl.Measure);
			Assert.AreEqual(dto.Remarks, bl.Remarks);
			Assert.AreEqual(dto.ManufactureReg.ItemId, bl.ModelingObjectSubTypeId);
			Assert.AreEqual(dto.Series, bl.SubModel);
			Assert.AreEqual(dto.Name, bl.Model);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.ShortName, bl.ShortName);
			Assert.AreEqual(dto.Designer, bl.Designer);
			Assert.AreEqual(dto.Code, bl.Code);
			Assert.AreEqual((short)dto.GoodsClass.ItemId, bl.ComponentClass);
			Assert.AreEqual(dto.IsDangerous, bl.IsDangerous);
		}

		[TestMethod]
		public void TestAircraftOtherParameterDTOConverter()
		{
			var aop = new AircraftOtherParameters()
			{
				ItemId = 2,
				IsDeleted = false,
				FullName = "Testfull",
				ShortName = "testname"
			};

			var dto = aop.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, aop.ItemId);
			Assert.AreEqual(dto.IsDeleted, aop.IsDeleted);
			Assert.AreEqual(dto.FullName, aop.FullName);
			Assert.AreEqual(dto.Name, aop.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestAirportCodeDTOConverter()
		{
			var arc = new AirportsCodes()
			{
				ItemId = 6,
				IsDeleted = false,
				FullName = "test full name",
				City = "test City",
				Country = "test Country",
				ShortName = "test short",
				Icao = "test icao",
				Iso = "test iso"
			};

			var dto = arc.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, arc.ItemId);
			Assert.AreEqual(dto.IsDeleted, arc.IsDeleted);
			Assert.AreEqual(dto.FullName, arc.FullName);
			Assert.AreEqual(dto.City, arc.City);
			Assert.AreEqual(dto.Country, arc.Country);
			Assert.AreEqual(dto.Iata, arc.ShortName);
			Assert.AreEqual(dto.Icao, arc.Icao);
			Assert.AreEqual(dto.Iso, arc.Iso);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.City, bl.City);
			Assert.AreEqual(dto.Country, bl.Country);
			Assert.AreEqual(dto.Iata, bl.ShortName);
			Assert.AreEqual(dto.Icao, bl.Icao);
			Assert.AreEqual(dto.Iso, bl.Iso);
		}

		[TestMethod]
		public void TestAirportDTOConverter()
		{
			var airp = new Airport()
			{
				ItemId = 87,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "test short name" ,
				Altitude = 54,
				TimeBeginning = 10,
				TimeEnd = 11
			};

			var dto = airp.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, airp.ItemId);
			Assert.AreEqual(dto.IsDeleted, airp.IsDeleted);
			Assert.AreEqual(dto.FullName, airp.FullName);
			Assert.AreEqual(dto.ShortName, airp.ShortName);
			Assert.AreEqual(dto.Altitude, airp.Altitude);
			Assert.AreEqual(dto.TimeBeginning, airp.TimeBeginning);
			Assert.AreEqual(dto.TimeEnd, airp.TimeEnd);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.ShortName, bl.ShortName);
			Assert.AreEqual(dto.Altitude, bl.Altitude);
			Assert.AreEqual(dto.TimeBeginning, bl.TimeBeginning);
			Assert.AreEqual(dto.TimeEnd, bl.TimeEnd);
		}

		[TestMethod]
		public void TestATAChapterDTOConverter()
		{
			var atac = new ATAChapterDTO()
			{
				ItemId = 54,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "test short name"
			};
			var dto = atac.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, atac.ItemId);
			Assert.AreEqual(dto.IsDeleted, atac.IsDeleted);
			Assert.AreEqual(dto.FullName, atac.FullName);
			Assert.AreEqual(dto.ShortName, atac.ShortName);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.ShortName, bl.ShortName);
		}

		[TestMethod]
		public void TestGoodStandartDTOConverter()
		{
			var gdst = new GoodStandart()
			{
				ItemId = 54,
				IsDeleted = false,
				FullName = "test full name",
				PartNumber = "test partum",
				Description = "test desc",
				Remarks = "test rem",
				DefaultProductId = 5,
				GoodsClass = GoodsClass.Accessories

			};
			var dto = gdst.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, gdst.ItemId);
			Assert.AreEqual(dto.IsDeleted, gdst.IsDeleted);
			Assert.AreEqual(dto.Name, gdst.FullName);
			Assert.AreEqual(dto.PartNumber, gdst.PartNumber);
			Assert.AreEqual(dto.Description, gdst.Description);
			Assert.AreEqual(dto.Remarks, gdst.Remarks);
			Assert.AreEqual(dto.DefaultProductId, gdst.DefaultProductId);
			Assert.AreEqual(dto.ComponentType, gdst.GoodsClass.ItemId);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Name, bl.FullName);
			Assert.AreEqual(dto.PartNumber, bl.PartNumber);
			Assert.AreEqual(dto.Description, bl.Description);
			Assert.AreEqual(dto.Remarks, bl.Remarks);
			Assert.AreEqual(dto.DefaultProductId, bl.DefaultProductId);
			Assert.AreEqual(dto.ComponentType, bl.GoodsClass.ItemId);
		}

		[TestMethod]
		public void TestCruiseLevelDTOConverter()
		{
			var crl = new CruiseLevel()
			{
				ItemId = 74,
				IsDeleted = false,
				FullName = "test full name",
				Feet = 5,
				IVFR = "test ivfr",
				Meter = 10,
				Track = "test track"
			};

			var dto = crl.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, crl.ItemId);
			Assert.AreEqual(dto.IsDeleted, crl.IsDeleted);
			Assert.AreEqual(dto.FullName, crl.FullName);
			Assert.AreEqual(dto.Feet, crl.Feet);
			Assert.AreEqual(dto.IVFR, crl.IVFR);
			Assert.AreEqual(dto.Meter, crl.Meter);
			Assert.AreEqual(dto.Track, crl.Track);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Feet, bl.Feet);
			Assert.AreEqual(dto.IVFR, bl.IVFR);
			Assert.AreEqual(dto.Meter, bl.Meter);
			Assert.AreEqual(dto.Track, bl.Track);
		}

		[TestMethod]
		public void TestDamageChartDTOConverter()
		{

			var ata = new ATAChapterDTO()
			{
				ItemId = 456,
				IsDeleted = true,
				ShortName = "test",
				FullName = "test"

			};

			var standart = new GoodStandartDTO()
			{
				ItemId = 324,
				IsDeleted = true,
				Name = "testname",
				PartNumber = "testpartnum",
				Description = "testdesc",
				Remarks = "testrem",
				DefaultProductId = 324,
				ComponentType = 123

			};

			var acd = new AccessoryDescriptionDTO()
			{
				ItemId = 3,
				IsDeleted = false,
				Model = "testasd",
				PartNumber = "34",
				ATAChapter = ata,
				AtaChapterId = ata.ItemId,
				Description = "testdesc",
				GoodStandart = standart,
				StandartId = standart.ItemId,
				Manufacturer = "testmanuf",
				CostNew = 4,
				CostOverhaul = 5,
				CostServiceable = 6,
				Measure = Measure.Centimeters.ItemId,
				Remarks = "8",
				ModelingObjectTypeId = 9,
				ModelingObjectSubTypeId = ManufactureRegion.Western.ItemId,
				SubModel = "11",
				FullName = "testfull",
				ShortName = "testshort",
				Designer = "testdesign",
				Code = "testcode",
				ComponentClass = (short)GoodsClass.Accessories.ItemId,
				IsDangerous = true
			};

			var dmgc = new DamageChart()
			{
				ItemId = 74,
				IsDeleted = false,
				ChartName = "test chart name",
				AircraftModel = acd.ConvertToAircraftModel()
			};

			var dto = dmgc.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, dmgc.ItemId);
			Assert.AreEqual(dto.IsDeleted, dmgc.IsDeleted);
			Assert.AreEqual(dto.ChartName, dmgc.ChartName);
			Assert.AreEqual(dto.AircraftModelId, dmgc.AircraftModel.ItemId);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.ChartName, bl.ChartName);
			Assert.AreEqual(dto.AircraftModelId, bl.AircraftModel.ItemId);
		}

		[TestMethod]
		public void TestDepartmentDTOConverter()
		{
			var dep = new Department()
			{
				ItemId = 74,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "tesy short name"
			};

			var dto = dep.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, dep.ItemId);
			Assert.AreEqual(dto.IsDeleted, dep.IsDeleted);
			Assert.AreEqual(dto.FullName, dep.FullName);
			Assert.AreEqual(dto.Name, dep.ShortName);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestDocumentSubTypeDTOConverter()
		{
			var docsub = new DocumentSubType()
			{
				ItemId = 74,
				IsDeleted = false,
				FullName = "test full name",
				DocumentTypeId = 5
			};

			var dto = docsub.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, docsub.ItemId);
			Assert.AreEqual(dto.IsDeleted, docsub.IsDeleted);
			Assert.AreEqual(dto.Name, docsub.FullName);
			Assert.AreEqual(dto.DocumentTypeId, docsub.DocumentTypeId);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Name, bl.FullName);
			Assert.AreEqual(dto.DocumentTypeId, bl.DocumentTypeId);
		}

		[TestMethod]
		public void TestEmployeeSubjectDTOConverter()
		{
			var docsub = new EmployeeSubject()
			{
				ItemId = 74,
				IsDeleted = false,
				ShortName = "test short",
				FullName = "test feull",
				LicenceTypeId = 5
			};

			var dto = docsub.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, docsub.ItemId);
			Assert.AreEqual(dto.IsDeleted, docsub.IsDeleted);
			Assert.AreEqual(dto.Name, docsub.ShortName);
			Assert.AreEqual(dto.FullName, docsub.FullName);
			Assert.AreEqual(dto.LicenceTypeId, docsub.LicenceTypeId);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Name, bl.ShortName);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.LicenceTypeId, bl.LicenceTypeId);
		}

		[TestMethod]
		public void TestEventCategorieDTOConverter()
		{
			var docsub = new EventCategory()
			{
				ItemId = 74,
				IsDeleted = false,
				Weight = 44,
				MinCompareOperation = LogicOperation.Grather,
				EventCountMinPeriod = 4,
				MaxCompareOperation = LogicOperation.Less,
				EventCountMaxPeriod = 2
			};

			var dto = docsub.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, docsub.ItemId);
			Assert.AreEqual(dto.IsDeleted, docsub.IsDeleted);
			Assert.AreEqual(dto.Weight, docsub.Weight);
			Assert.AreEqual(dto.MinCompareOp, LogicOperation.Grather.ItemId);
			Assert.AreEqual(dto.EventCountMinPeriod, docsub.EventCountMinPeriod);
			Assert.AreEqual(dto.MaxCompareOp, LogicOperation.Less.ItemId);
			Assert.AreEqual(dto.EventCountMaxPeriod, docsub.EventCountMaxPeriod);
			
			var bl = dto.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Weight, bl.Weight);
			Assert.AreEqual(dto.MinCompareOp, bl.MinCompareOperation.ItemId);
			Assert.AreEqual(dto.EventCountMinPeriod, bl.EventCountMinPeriod);
			Assert.AreEqual(dto.MaxCompareOp, bl.MaxCompareOperation.ItemId);
			Assert.AreEqual(dto.EventCountMaxPeriod, bl.EventCountMaxPeriod);
		}

		[TestMethod]
		public void TestEventClassDTOConverter()
		{
			var evnt = new EventClass()
			{
				ItemId = 74,
				IsDeleted = false,
				FullName = "test full name",
				PeopleDamage = HumanDamage.LightInjuries,
				FailureViolationDeviation = FailureViolationDeviation.AccidentSituation,
				Regularity = Regularity.From15To30Minutes,
				PropertyDamage = PropertyDamage.ExtensiveDamage,
				EnvironmentalDamage = EnvironmentalDamage.LightDamage,
				ReputationDamage = ReputationDamage.LightDamage
			};

			var dto = evnt.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, evnt.ItemId);
			Assert.AreEqual(dto.IsDeleted, evnt.IsDeleted);
			Assert.AreEqual(dto.FullName, evnt.FullName);
			Assert.AreEqual(dto.People, HumanDamage.LightInjuries.ItemId);
			Assert.AreEqual(dto.Failure, FailureViolationDeviation.AccidentSituation.ItemId);
			Assert.AreEqual(dto.Regularity, Regularity.From15To30Minutes.ItemId);
			Assert.AreEqual(dto.Property, PropertyDamage.ExtensiveDamage.ItemId);
			Assert.AreEqual(dto.Environmental, EnvironmentalDamage.LightDamage.ItemId);
			Assert.AreEqual(dto.Reputation, ReputationDamage.LightDamage.ItemId);
			
			
			var bl = dto.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.People, bl.PeopleDamage.ItemId);
			Assert.AreEqual(dto.Failure, bl.FailureViolationDeviation.ItemId);
			Assert.AreEqual(dto.Regularity, bl.Regularity.ItemId);
			Assert.AreEqual(dto.Property, bl.PropertyDamage.ItemId);
			Assert.AreEqual(dto.Environmental, bl.EnvironmentalDamage.ItemId);
			Assert.AreEqual(dto.Reputation, bl.ReputationDamage.ItemId);
		}

		[TestMethod]
		public void TestFlightNumDTOConverter()
		{
			var fln = new FlightNum()
			{
				ItemId = 53,
				IsDeleted = false,
				FullName = "test full name"
			};

			var dto = fln.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, fln.ItemId);
			Assert.AreEqual(dto.IsDeleted, fln.IsDeleted);
			Assert.AreEqual(dto.FlightNumber, fln.FullName);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FlightNumber, bl.FullName);
		}

		[TestMethod]
		public void TestLicenseRemarkRightDTOConverter()
		{
			var lrr = new LicenseRemarkRights()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "tesy short name"
			};

			var dto = lrr.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, lrr.ItemId);
			Assert.AreEqual(dto.IsDeleted, lrr.IsDeleted);
			Assert.AreEqual(dto.FullName, lrr.FullName);
			Assert.AreEqual(dto.Name, lrr.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestLifeLimitCategorieDTOConverter()
		{
			var ata = new ATAChapterDTO()
			{
				ItemId = 456,
				IsDeleted = true,
				ShortName = "test",
				FullName = "test"

			};

			var standart = new GoodStandartDTO()
			{
				ItemId = 324,
				IsDeleted = true,
				Name = "testname",
				PartNumber = "testpartnum",
				Description = "testdesc",
				Remarks = "testrem",
				DefaultProductId = 324,
				ComponentType = 123
			};

			var acd = new AccessoryDescriptionDTO()
			{
				ItemId = 3,
				IsDeleted = false,
				Model = "testasd",
				PartNumber = "34",
				ATAChapter = ata,
				AtaChapterId = ata.ItemId,
				Description = "testdesc",
				GoodStandart = standart,
				StandartId = standart.ItemId,
				Manufacturer = "testmanuf",
				CostNew = 4,
				CostOverhaul = 5,
				CostServiceable = 6,
				Measure = Measure.Centimeters.ItemId,
				Remarks = "8",
				ModelingObjectTypeId = 9,
				ModelingObjectSubTypeId = ManufactureRegion.Western.ItemId,
				SubModel = "11",
				FullName = "testfull",
				ShortName = "testshort",
				Designer = "testdesign",
				Code = "testcode",
				ComponentClass = (short)GoodsClass.Accessories.ItemId,
				IsDangerous = true
			};

			var llc = new LLPLifeLimitCategory()
			{
				ItemId = 43,
				IsDeleted = false,
				CategoryType = LLPLifeLimitCategoryType.A,
				Category = "tesy cat name",
				AircraftModel = acd.ConvertToAircraftModel()
			};

			var dto = llc.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, llc.ItemId);
			Assert.AreEqual(dto.IsDeleted, llc.IsDeleted);
			Assert.AreEqual(dto.CategoryType, llc.CategoryType.FullName);
			Assert.AreEqual(dto.CategoryName, llc.Category);
			Assert.AreEqual(dto.AircraftModelId, llc.AircraftModel.ItemId);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.CategoryType, bl.CategoryType.FullName);
			Assert.AreEqual(dto.CategoryName, bl.Category);
			Assert.AreEqual(dto.AircraftModelId, bl.AircraftModel.ItemId);
		}

		[TestMethod]
		public void TesLocationDTOConverter()
		{
			var loctp = new LocationsType()
			{
				ItemId = 23,
				IsDeleted = false,
				FullName = "test full",
				ShortName = "test short"
			};

			var loc = new Locations()
			{
				ItemId = 74,
				IsDeleted = false,
				ShortName = "test short",
				FullName = "test full",
				LocationsType = loctp
				
			};

			var dto = loc.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, loc.ItemId);
			Assert.AreEqual(dto.IsDeleted, loc.IsDeleted);
			Assert.AreEqual(dto.Name, loc.ShortName);
			Assert.AreEqual(dto.FullName, loc.FullName);
			Assert.AreEqual(dto.LocationsTypeId, loc.LocationsType.ItemId);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Name, bl.ShortName);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.LocationsTypeId, bl.LocationsType.ItemId);
		}

		[TestMethod]
		public void TestLocationsTypeDTOConverter()
		{
			var loct = new LocationsType()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "tesy short name"
			};

			var dto = loct.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, loct.ItemId);
			Assert.AreEqual(dto.IsDeleted, loct.IsDeleted);
			Assert.AreEqual(dto.FullName, loct.FullName);
			Assert.AreEqual(dto.Name, loct.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestNomenclatureDTOConverter()
		{
			var dep = new Department()
			{
				ItemId = 41,
				IsDeleted = false,
				FullName = "test full dep",
				ShortName = "tesy short dep"
			};

			var nom = new Nomenclatures()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "tesy short name",
				Department = dep
			};

			var dto = nom.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, nom.ItemId);
			Assert.AreEqual(dto.IsDeleted, nom.IsDeleted);
			Assert.AreEqual(dto.FullName, nom.FullName);
			Assert.AreEqual(dto.Name, nom.ShortName);
			Assert.AreEqual(dto.DepartmentId, nom.Department.ItemId);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
			Assert.AreEqual(dto.DepartmentId, bl.Department.ItemId);
		}

		[TestMethod]
		public void TestNonRoutineJobDTOConverter()
		{
			var ata = new ATAChapterDTO()
			{
				ItemId = 456,
				IsDeleted = true,
				ShortName = "test",
				FullName = "test"
			};

			var nrj = new NonRoutineJobDTO()
			{
				ItemId = 43,
				IsDeleted = false,
				ATAChapter = ata,
				Title = "test title",
				Description = "test desc",
				ManHours = 43,
				Cost = 34,
				KitRequired = "test kit"
			};

			var dto = nrj.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, nrj.ItemId);
			Assert.AreEqual(dto.IsDeleted, nrj.IsDeleted);
			Assert.AreEqual(dto.ATAChapter, ata.Convert());
			Assert.AreEqual(dto.Title, nrj.Title);
			Assert.AreEqual(dto.Description, nrj.Description);
			Assert.AreEqual(dto.ManHours, nrj.ManHours);
			Assert.AreEqual(dto.Cost, nrj.Cost);
			Assert.AreEqual(dto.KitRequired, nrj.KitRequired);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.ATAChapter.ItemId, bl.ATAChapterId);
			Assert.AreEqual(dto.Title, bl.Title);
			Assert.AreEqual(dto.Description, bl.Description);
			Assert.AreEqual(dto.ManHours, bl.ManHours);
			Assert.AreEqual(dto.Cost, bl.Cost);
			Assert.AreEqual(dto.KitRequired, bl.KitRequired);
		}

		[TestMethod]
		public void TestReasonDTOConverter()
		{
			var reas = new Reason()
			{
				ItemId = 43,
				IsDeleted = false,
				Category = "test cat",
				ShortName = "test short name"
			};

			var dto = reas.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, reas.ItemId);
			Assert.AreEqual(dto.IsDeleted, reas.IsDeleted);
			Assert.AreEqual(dto.Category, reas.Category);
			Assert.AreEqual(dto.Name, reas.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.Category, bl.Category);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestLicenseRestrictionDTOConverter()
		{
			var licres = new LicenseRestriction()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full name",
				ShortName = "test short name"
			};

			var dto = licres.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, licres.ItemId);
			Assert.AreEqual(dto.IsDeleted, licres.IsDeleted);
			Assert.AreEqual(dto.FullName, licres.FullName);
			Assert.AreEqual(dto.Name, licres.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestSchedulePeriodsDTOConverter()
		{
			var licres = new SchedulePeriods()
			{
				ItemId = 43,
				IsDeleted = false,
				Schedule = Schedule.Summer,
				To = DateTime.Today,
				From = DateTime.Today
			};

			var dto = licres.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, licres.ItemId);
			Assert.AreEqual(dto.IsDeleted, licres.IsDeleted);
			Assert.AreEqual(dto.Schedule, (int)Schedule.Summer);
			Assert.AreEqual(dto.DateTo, DateTime.Today.Date);
			Assert.AreEqual(dto.DateFrom, DateTime.Today.Date);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(Enum.ToObject(typeof(Schedule),dto.Schedule), bl.Schedule);
			Assert.AreEqual(dto.DateTo, bl.To);
			Assert.AreEqual(dto.DateFrom, bl.From);
		}

		[TestMethod]
		public void TestServiceTypeDTOConverter()
		{
			var reas = new ServiceType()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full",
				ShortName = "test short name"
			};

			var dto = reas.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, reas.ItemId);
			Assert.AreEqual(dto.IsDeleted, reas.IsDeleted);
			Assert.AreEqual(dto.FullName, reas.FullName);
			Assert.AreEqual(dto.Name, reas.ShortName);

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.Name, bl.ShortName);
		}

		[TestMethod]
		public void TestSpecializationDTOConverter()
		{
			var dep = new Department()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full dep",
				ShortName = "tesy short dep"
			};

			var spec = new Specialization()
			{
				ItemId = 23,
				IsDeleted = false,
				ShortName = "test short",
				FullName = "test full",
				Department = dep,
				Level = 4,
				KeyPersonel = false
			};

			var dto = spec.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, spec.ItemId);
			Assert.AreEqual(dto.IsDeleted, spec.IsDeleted);
			Assert.AreEqual(dto.FullName, spec.FullName);
			Assert.AreEqual(dto.ShortName, spec.ShortName);
			Assert.AreEqual(dto.DepartmentId, spec.Department.ItemId);
			Assert.AreEqual(dto.Level, spec.Level);
			Assert.AreEqual(dto.KeyPersonel, spec.KeyPersonel);
			
			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.FullName, bl.FullName);
			Assert.AreEqual(dto.ShortName, bl.ShortName);
			Assert.AreEqual(dto.DepartmentId, bl.Department.ItemId);
			Assert.AreEqual(dto.Level, bl.Level);
			Assert.AreEqual(dto.KeyPersonel, bl.KeyPersonel);
		}

		[TestMethod]
		public void TestTripNameDTOConverter()
		{
			var tpn = new TripName()
			{
				ItemId = 43,
				IsDeleted = false,
				FullName = "test full"
				
			};
			var dto = tpn.Convert();

			Assert.IsNotNull(dto);
			Assert.AreEqual(dto.ItemId, tpn.ItemId);
			Assert.AreEqual(dto.IsDeleted, tpn.IsDeleted);
			Assert.AreEqual(dto.TripName, tpn.FullName);
			

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.TripName, bl.FullName);
		}
	}
}