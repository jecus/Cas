using System;
using System.IO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCore.Calculations;
using SmartCore.DtoHelper;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Tests.EntityFrameTest
{
	[TestClass]
	public class GeneralDtoConverterTest
	{
		[TestMethod]
		public void TestAccessoryRequiredDTOConverter()
		{
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

			var acd = new AccessoryDescriptionDTO
			{
				ItemId = 3,
				IsDeleted = false,
				Model = "testasd",
				PartNumber = "34",
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

			var dto = new AccessoryRequiredDTO
			{
				ItemId = 1,
				IsDeleted = true,
				ParentId = 2,
				ParentTypeId = 3,
				AircraftModelId = 4,
				PartNumber = "qwe",
				Description = "test",
				Manufacturer = "test",
				Measure = Measure.Centimeters.ItemId,
				Quantity = 12,
				CostNew = 1,
				CostServiceable = 3,
				CostOverhaul = 4,
				Remarks = "test",
				AccessoryDescriptionId = acd.ItemId,
				GoodStandartId = standart.ItemId,
				Standart = standart,
				Product = acd
			};

			var bl = dto.Convert();


			Assert.IsNotNull(bl);
			Assert.AreEqual(dto.ItemId, bl.ItemId);
			Assert.AreEqual(dto.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(dto.ParentId, bl.ParentId);
			Assert.AreEqual(dto.ParentTypeId, bl.ParentTypeId);
			Assert.AreEqual(dto.AircraftModelId, bl.AircraftModelId);
			Assert.AreEqual(Measure.Centimeters, bl.Measure);
			Assert.AreEqual(dto.Quantity, bl.Quantity);
			Assert.IsNotNull(bl.Standart);
			Assert.IsNotNull(bl.Product);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.ParentId, bl.ParentId);
			Assert.AreEqual(convertBackToDTO.ParentTypeId, bl.ParentTypeId);
			Assert.AreEqual(convertBackToDTO.AircraftModelId, bl.AircraftModelId);
			Assert.AreEqual(convertBackToDTO.Measure, bl.Measure.ItemId);
			Assert.AreEqual(convertBackToDTO.Quantity, bl.Quantity);
			Assert.AreEqual(convertBackToDTO.CostServiceable, bl.CostServiceable);
			Assert.AreEqual(convertBackToDTO.CostOverhaul, bl.CostOverhaul);
			Assert.AreEqual(convertBackToDTO.GoodStandartId, bl.Standart.ItemId);
			Assert.AreEqual(convertBackToDTO.AccessoryDescriptionId, bl.Product.ItemId);
			Assert.IsNotNull(convertBackToDTO.Standart);
			Assert.IsNotNull(convertBackToDTO.Product);

		}

		[TestMethod]
		public void TestActualStateRecordDTOConverter()
		{
			var dto =  new ActualStateRecordDTO
			{
				ItemId = 1,
				IsDeleted = true,
				FlightRegimeId = FlightRegime.Nominal.ItemId,
				Remarks = "Test",
				OnLifelength = new Lifelength(200, 2, 2).ConvertToByteArray(),
				RecordDate = DateTime.Today,
				WorkRegimeTypeId = SmartCoreType.BaseComponent.ItemId,
				ComponentId = 10
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.WorkRegime, FlightRegime.Nominal);
			Assert.AreEqual(bl.Remarks, dto.Remarks);
			Assert.IsTrue(bl.OnLifelength.IsEqual(Lifelength.ConvertFromByteArray(dto.OnLifelength)));
			Assert.AreEqual(bl.RecordDate, dto.RecordDate);
			Assert.AreEqual(bl.WorkRegimeType, SmartCoreType.BaseComponent);
			Assert.AreEqual(bl.ComponentId, dto.ComponentId);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.FlightRegimeId, bl.WorkRegime.ItemId);
			Assert.AreEqual(convertBackToDTO.Remarks, bl.Remarks);
			Assert.IsNotNull(convertBackToDTO.OnLifelength);
			Assert.IsTrue(convertBackToDTO.OnLifelength.Length > 0);
			Assert.AreEqual(convertBackToDTO.RecordDate, bl.RecordDate);
			Assert.AreEqual(convertBackToDTO.WorkRegimeTypeId, bl.WorkRegimeType.ItemId);
			Assert.AreEqual(convertBackToDTO.ComponentId, bl.ComponentId);
		}

		[TestMethod]
		public void TestAttachedFileDTOConverter()
		{
			var file = CreateFile();

			var dto = new AttachedFileDTO
			{
				ItemId = 10,
				IsDeleted = false,
				FileName = "test",
				FileData = file,
				FileSize = file.Length,
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.FileName, dto.FileName);
			Assert.IsNotNull(bl.FileData);
			Assert.IsTrue(bl.FileData.Length == file.Length);
			Assert.AreEqual(bl.FileSize, dto.FileSize);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.FileName, bl.FileName);
			Assert.IsNotNull(convertBackToDTO.FileData);
			Assert.IsTrue(convertBackToDTO.FileData.Length == file.Length);
			Assert.AreEqual(convertBackToDTO.FileSize, bl.FileSize);
		}

		[TestMethod]
		public void TestItemFileLinkDTOConverter()
		{
			var file = CreateFile();

			var attachedFile = new AttachedFileDTO
			{
				ItemId = 10,
				IsDeleted = false,
				FileName = "test",
				FileData = file,
				FileSize = file.Length,
			};

			var dto = new ItemFileLinkDTO
			{
				ItemId = 1,
				IsDeleted = true,
				ParentId = 1,
				ParentTypeId = 2,
				LinkType = 1,
				FileId = attachedFile.ItemId,
				File = attachedFile
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.ParentId, dto.ParentId);
			Assert.AreEqual(bl.ParentTypeId, dto.ParentTypeId);
			Assert.AreEqual(bl.LinkType, dto.LinkType);
			Assert.IsNotNull(bl.File);
			Assert.AreEqual(bl.File.ItemId, dto.FileId);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.ParentId, bl.ParentId);
			Assert.AreEqual(convertBackToDTO.ParentTypeId, bl.ParentTypeId);
			Assert.AreEqual(convertBackToDTO.LinkType, bl.LinkType);
			Assert.IsNotNull(convertBackToDTO.File);
			Assert.AreEqual(convertBackToDTO.FileId, bl.File.ItemId);
		}


		private byte[] CreateFile()
		{
			using (var ms = new MemoryStream())
			{
				var tw = new StreamWriter(ms);
				tw.Write("blabla");
				tw.Flush();
				ms.Position = 0;
				return ms.ToArray();
			}
		}

		[TestMethod]
		public void TestAircraftDTOConverter()
		{
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

			var acd = new AccessoryDescriptionDTO
			{
				ItemId = 3,
				IsDeleted = false,
				Model = "testasd",
				PartNumber = "34",
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

			var dto = new AircraftDTO
			{
				ItemId = 1,
				IsDeleted = true,
				OperatorID = 8,
				AircraftTypeID = 9,
				ModelId = acd.ItemId,
				TypeCertificateNumber = "11",
				ManufactureDate = DateTime.Today,
				RegistrationNumber = "12",
				SerialNumber = "13",
				VariableNumber = "14",
				LineNumber = "15",
				Owner = "16",
				BasicEmptyWeight = 17,
				BasicEmptyWeightCargoConfig = 18,
				CargoCapacityContainer = "19",
				Cruise = "20",
				CruiseFuelFlow = "21",
				FuelCapacity = "22",
				MaxCruiseAltitude = "23",
				MaxLandingWeight = 24,
				MaxPayloadWeight = 25,
				MaxTakeOffCrossWeight = 26,
				MaxTaxiWeight = 27,
				MaxZeroFuelWeight = 28,
				OperationalEmptyWeight = 29,
				CockpitSeating = "30,",
				Galleys = "31",
				Lavatory = "32",
				SeatingEconomy = 33,
				SeatingBusiness = 34,
				SeatingFirst = 35,
				Oven = "36",
				Boiler = "37",
				AirStairDoors = "38",
				Tanks = 39,
				AircraftAddress24Bit = "40",
				ELTIdHexCode = "41,",
				DeliveryDate = DateTime.Today,
				AcceptanceDate = DateTime.Today,
				Schedule = true,
				MSG = 42,
				CheckNaming = true,
				NoiceCategory = 43,
				FADEC = true,
				LandingCategory = 44,
				EFIS = false,
				Brakes = 45,
				Winglets = false,
				ApuUtizationPerFlightinMinutes = 46
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.OperatorId, dto.OperatorID);
			Assert.AreEqual(bl.AircraftTypeId, dto.AircraftTypeID);
			Assert.AreEqual(bl.Model, dto.Model.ItemId);
			Assert.AreEqual(bl.TypeCertificateNumber, dto.TypeCertificateNumber);
			Assert.AreEqual(bl.ManufactureDate, dto.ManufactureDate.Date);
			Assert.AreEqual(bl.RegistrationNumber, dto.RegistrationNumber);
			Assert.AreEqual(bl.SerialNumber, dto.SerialNumber);
			Assert.AreEqual(bl.VariableNumber, dto.VariableNumber);
			Assert.AreEqual(bl.LineNumber, dto.LineNumber);
			Assert.AreEqual(bl.Owner, dto.Owner);
			Assert.AreEqual(bl.BasicEmptyWeight, dto.BasicEmptyWeight);
			Assert.AreEqual(bl.BasicEmptyWeightCargoConfig, dto.BasicEmptyWeightCargoConfig);
			Assert.AreEqual(bl.CargoCapacityContainer, dto.CargoCapacityContainer);
			Assert.AreEqual(bl.Cruise, dto.Cruise);
			Assert.AreEqual(bl.CruiseFuelFlow, dto.CruiseFuelFlow);
			Assert.AreEqual(bl.FuelCapacity, dto.FuelCapacity);
			Assert.AreEqual(bl.MaxCruiseAltitude, dto.MaxCruiseAltitude);
			Assert.AreEqual(bl.MaxLandingWeight, dto.MaxLandingWeight);
			Assert.AreEqual(bl.MaxPayloadWeight, dto.MaxPayloadWeight);
			Assert.AreEqual(bl.MaxTakeOffCrossWeight, dto.MaxTakeOffCrossWeight);
			Assert.AreEqual(bl.MaxTaxiWeight, dto.MaxTaxiWeight);
			Assert.AreEqual(bl.MaxZeroFuelWeight, dto.MaxZeroFuelWeight);
			Assert.AreEqual(bl.OperationalEmptyWeight, dto.OperationalEmptyWeight);
			Assert.AreEqual(bl.CockpitSeating, dto.CockpitSeating);
			Assert.AreEqual(bl.Galleys, dto.Galleys);
			Assert.AreEqual(bl.Lavatory, dto.Lavatory);
			Assert.AreEqual(bl.SeatingEconomy, dto.SeatingEconomy);
			Assert.AreEqual(bl.SeatingBusiness, dto.SeatingBusiness);
			Assert.AreEqual(bl.SeatingFirst, dto.SeatingFirst);
			Assert.AreEqual(bl.Oven, dto.Oven);
			Assert.AreEqual(bl.Boiler, dto.Boiler);
			Assert.AreEqual(bl.AirStairsDoors, dto.AirStairDoors);
			Assert.AreEqual(bl.Tanks, dto.Tanks);
			Assert.AreEqual(bl.AircraftAddress24Bit, dto.AircraftAddress24Bit);
			Assert.AreEqual(bl.ELTIdHexCode, dto.ELTIdHexCode);
			Assert.AreEqual(bl.DeliveryDate, dto.DeliveryDate);
			Assert.AreEqual(bl.AcceptanceDate, dto.AcceptanceDate);
			Assert.AreEqual(bl.Schedule, dto.Schedule);
			Assert.AreEqual(bl.MSG, dto.MSG);
			Assert.AreEqual(bl.MaintenanceProgramCheckNaming, dto.CheckNaming);
			Assert.AreEqual(bl.NoiceCategory, dto.NoiceCategory);
			Assert.AreEqual(bl.FADEC, dto.FADEC);
			Assert.AreEqual(bl.LandingCategory, dto.LandingCategory);
			Assert.AreEqual(bl.EFIS, dto.EFIS);
			Assert.AreEqual(bl.Brakes, dto.Brakes);
			Assert.AreEqual(bl.Winglets, dto.Winglets);
			Assert.AreEqual(bl.ApuUtizationPerFlightinMinutes, dto.ApuUtizationPerFlightinMinutes);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, bl.ItemId);
			Assert.AreEqual(bl.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(bl.OperatorId, bl.OperatorId);
			Assert.AreEqual(bl.AircraftTypeId, bl.AircraftTypeId);
			Assert.AreEqual(bl.Model, bl.Model.ItemId);
			Assert.AreEqual(bl.TypeCertificateNumber, bl.TypeCertificateNumber);
			Assert.AreEqual(bl.ManufactureDate, bl.ManufactureDate.Date);
			Assert.AreEqual(bl.RegistrationNumber, bl.RegistrationNumber);
			Assert.AreEqual(bl.SerialNumber, bl.SerialNumber);
			Assert.AreEqual(bl.VariableNumber, bl.VariableNumber);
			Assert.AreEqual(bl.LineNumber, bl.LineNumber);
			Assert.AreEqual(bl.Owner, bl.Owner);
			Assert.AreEqual(bl.BasicEmptyWeight, bl.BasicEmptyWeight);
			Assert.AreEqual(bl.BasicEmptyWeightCargoConfig, bl.BasicEmptyWeightCargoConfig);
			Assert.AreEqual(bl.CargoCapacityContainer, bl.CargoCapacityContainer);
			Assert.AreEqual(bl.Cruise, bl.Cruise);
			Assert.AreEqual(bl.CruiseFuelFlow, bl.CruiseFuelFlow);
			Assert.AreEqual(bl.FuelCapacity, bl.FuelCapacity);
			Assert.AreEqual(bl.MaxCruiseAltitude, bl.MaxCruiseAltitude);
			Assert.AreEqual(bl.MaxLandingWeight, bl.MaxLandingWeight);
			Assert.AreEqual(bl.MaxPayloadWeight, bl.MaxPayloadWeight);
			Assert.AreEqual(bl.MaxTakeOffCrossWeight, bl.MaxTakeOffCrossWeight);
			Assert.AreEqual(bl.MaxTaxiWeight, bl.MaxTaxiWeight);
			Assert.AreEqual(bl.MaxZeroFuelWeight, bl.MaxZeroFuelWeight);
			Assert.AreEqual(bl.OperationalEmptyWeight, bl.OperationalEmptyWeight);
			Assert.AreEqual(bl.CockpitSeating, bl.CockpitSeating);
			Assert.AreEqual(bl.Galleys, bl.Galleys);
			Assert.AreEqual(bl.Lavatory, bl.Lavatory);
			Assert.AreEqual(bl.SeatingEconomy, bl.SeatingEconomy);
			Assert.AreEqual(bl.SeatingBusiness, bl.SeatingBusiness);
			Assert.AreEqual(bl.SeatingFirst, bl.SeatingFirst);
			Assert.AreEqual(bl.Oven, bl.Oven);
			Assert.AreEqual(bl.Boiler, bl.Boiler);
			Assert.AreEqual(bl.AirStairsDoors, bl.AirStairsDoors);
			Assert.AreEqual(bl.Tanks, bl.Tanks);
			Assert.AreEqual(bl.AircraftAddress24Bit, bl.AircraftAddress24Bit);
			Assert.AreEqual(bl.ELTIdHexCode, bl.ELTIdHexCode);
			Assert.AreEqual(bl.DeliveryDate, bl.DeliveryDate);
			Assert.AreEqual(bl.AcceptanceDate, bl.AcceptanceDate);
			Assert.AreEqual(bl.Schedule, bl.Schedule);
			Assert.AreEqual(bl.MSG, bl.MSG);
			Assert.AreEqual(bl.MaintenanceProgramCheckNaming, bl.MaintenanceProgramCheckNaming);
			Assert.AreEqual(bl.NoiceCategory, bl.NoiceCategory);
			Assert.AreEqual(bl.FADEC, bl.FADEC);
			Assert.AreEqual(bl.LandingCategory, bl.LandingCategory);
			Assert.AreEqual(bl.EFIS, bl.EFIS);
			Assert.AreEqual(bl.Brakes, bl.Brakes);
			Assert.AreEqual(bl.Winglets, bl.Winglets);
			Assert.AreEqual(bl.ApuUtizationPerFlightinMinutes, bl.ApuUtizationPerFlightinMinutes);

		}

		[TestMethod]
		public void TestAircraftEquipmentDTOConverter()
		{
			var aop = new AircraftOtherParameterDTO
			{
				Name = "TestETqwe",
				FullName = "testETasd"
			};

			var dto = new AircraftEquipmentDTO
			{
				ItemId = 12,
				IsDeleted = true,
				Description = "test desc",
				AircraftId = 4,
				AircraftOtherParameter = aop,
				AircraftOtherParameterId = aop.ItemId,
				AircraftEquipmetType = (int)AircraftEquipmetType.Equipmet
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.Description, dto.Description);
			Assert.AreEqual(bl.AircraftId, dto.AircraftId);
			Assert.AreEqual(bl.AircraftOtherParameter, dto.AircraftOtherParameter.Convert());
			Assert.AreEqual(Enum.ToObject(typeof(AircraftEquipmetType), dto.AircraftEquipmetType), bl.AircraftEquipmetType);



			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.Description, bl.Description);
			Assert.AreEqual(convertBackToDTO.AircraftId, bl.AircraftId);
			Assert.AreEqual(convertBackToDTO.AircraftOtherParameterId, bl.AircraftOtherParameter.ItemId);
			Assert.AreEqual(convertBackToDTO.AircraftEquipmetType, (int) AircraftEquipmetType.Equipmet);

		}

		[TestMethod]
		public void TestAircraftFlightDTOConverter()
		{
			var dto = new AircraftFlightDTO
			{
				ItemId = 1,
				IsDeleted = true,
				ATLBID = 2,
				AircraftId = 3,
				FlightNo = "4",
				Remarks = "5",
				FlightDate = DateTime.Today,
				StationFrom = "6",
				StationTo = "7",
				DelayTime = 8,
				DelayReasonId = 9,
				OutTime = 10,
				InTime = 11,
				TakeOffTime = 12,
				LDGTime = 13,
				NightTime = 14,
				CRSID = 15,
				Tanks = "16",
				Fluids = "17",
				EnginesGeneralCondition = "18",
				Highlight = 19,
				Correct = true,
				Reference = "20",
				Cycles = 21,
				PageNo = "22",
				FlightType = 23,
				LevelId = 24,
				Distance = 25,
				DistanceMeasure = 26,
				TakeOffWeight = 27,
				AlignmentBefore = 28,
				AlignmentAfter = 29,
				FlightCategory = 30,
				AtlbRecordType = 31,
				FlightAircraftCode = 32,
				CancelReasonId = 33,
				StationFromId = 34,
				StationToId = 35,
				FlightNumberId = 36,
				
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.ATLBId, dto.ATLBID);
			Assert.AreEqual(bl.Aircraft, dto.AircraftId);
			Assert.AreEqual(bl.FlightNo, dto.FlightNo);
			Assert.AreEqual(bl.Remarks, dto.Remarks);
			Assert.AreEqual(bl.FlightDate, dto.FlightDate);
			Assert.AreEqual(bl.StationFrom, dto.StationFrom);
			Assert.AreEqual(bl.StationTo, dto.StationTo);
			Assert.AreEqual(bl.DelayTime, dto.DelayTime);
			Assert.AreEqual(bl.DelayReason, dto.DelayReasonId);
			Assert.AreEqual(bl.OutTime, dto.OutTime);
			Assert.AreEqual(bl.InTime, dto.InTime);
			Assert.AreEqual(bl.TakeOffTime, dto.TakeOffTime);
			Assert.AreEqual(bl.LDGTime, dto.LDGTime);
			Assert.AreEqual(bl.NightTime, dto.NightTime);
			Assert.AreEqual(bl.CrsId, dto.CRSID);
			Assert.AreEqual(bl.Tanks, dto.Tanks);
			Assert.AreEqual(bl.Fluids, dto.Fluids);
			Assert.AreEqual(bl.EnginesGeneralCondition, dto.EnginesGeneralCondition);
			Assert.AreEqual(bl.Highlight, dto.Highlight);
			Assert.AreEqual(bl.Correct, dto.Correct);
			Assert.AreEqual(bl.Reference, dto.Reference);
			Assert.AreEqual(bl.Cycles, dto.Cycles);
			Assert.AreEqual(bl.PageNo, dto.PageNo);
			Assert.AreEqual(bl.FlightType, dto.FlightType);
			Assert.AreEqual(bl.Level, dto.LevelId);
			Assert.AreEqual(bl.Distance, dto.Distance);
			Assert.AreEqual(bl.DistanceMeasure, dto.DistanceMeasure);
			Assert.AreEqual(bl.TakeOffWeight, dto.TakeOffWeight);
			Assert.AreEqual(bl.AlignmentBefore, dto.AlignmentBefore);
			Assert.AreEqual(bl.AlignmentAfter, dto.AlignmentAfter);
			Assert.AreEqual(bl.FlightCategory, dto.FlightCategory);
			Assert.AreEqual(bl.AtlbRecordType, dto.AtlbRecordType);
			Assert.AreEqual(bl.FlightAircraftCode, dto.FlightAircraftCode);
			Assert.AreEqual(bl.CancelReason, dto.CancelReasonId);
			Assert.AreEqual(bl.StationFrom, dto.StationFromId);
			Assert.AreEqual(bl.StationTo, dto.StationToId);
			Assert.AreEqual(bl.FlightNumber, dto.FlightNumberId);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.ATLBID, bl.ATLBId);
			Assert.AreEqual(convertBackToDTO.AircraftId, bl.Aircraft.ItemId);
			Assert.AreEqual(convertBackToDTO.FlightNo, bl.FlightNo);
			Assert.AreEqual(convertBackToDTO.Remarks, bl.Remarks);
			Assert.AreEqual(convertBackToDTO.FlightDate, bl.FlightDate);
			Assert.AreEqual(convertBackToDTO.StationFrom, bl.StationFrom);
			Assert.AreEqual(convertBackToDTO.StationTo, bl.StationTo);
			Assert.AreEqual(convertBackToDTO.DelayTime, bl.DelayTime);
			Assert.AreEqual(convertBackToDTO.DelayReasonId, bl.DelayReason.ItemId);
			Assert.AreEqual(convertBackToDTO.OutTime, bl.OutTime);
			Assert.AreEqual(convertBackToDTO.InTime, bl.InTime);
			Assert.AreEqual(convertBackToDTO.TakeOffTime, bl.TakeOffTime);
			Assert.AreEqual(convertBackToDTO.LDGTime, bl.LDGTime);
			Assert.AreEqual(convertBackToDTO.NightTime, bl.NightTime);
			Assert.AreEqual(convertBackToDTO.CRSID, bl.CrsId);
			Assert.AreEqual(convertBackToDTO.Tanks, bl.Tanks);
			Assert.AreEqual(convertBackToDTO.Fluids, bl.Fluids);
			Assert.AreEqual(convertBackToDTO.EnginesGeneralCondition, bl.EnginesGeneralCondition);
			Assert.AreEqual(convertBackToDTO.Highlight, bl.Highlight);
			Assert.AreEqual(convertBackToDTO.Correct, bl.Correct);
			Assert.AreEqual(convertBackToDTO.Reference, bl.Reference);
			Assert.AreEqual(convertBackToDTO.Cycles, bl.Cycles);
			Assert.AreEqual(convertBackToDTO.PageNo, bl.PageNo);
			Assert.AreEqual(convertBackToDTO.FlightType, bl.FlightType);
			Assert.AreEqual(convertBackToDTO.LevelId, bl.Level.ItemId);
			Assert.AreEqual(convertBackToDTO.Distance, bl.Distance);
			Assert.AreEqual(convertBackToDTO.DistanceMeasure, bl.DistanceMeasure);
			Assert.AreEqual(convertBackToDTO.TakeOffWeight, bl.TakeOffWeight);
			Assert.AreEqual(convertBackToDTO.AlignmentBefore, bl.AlignmentBefore);
			Assert.AreEqual(convertBackToDTO.AlignmentAfter, bl.AlignmentAfter);
			Assert.AreEqual(convertBackToDTO.FlightCategory, bl.FlightCategory);
			Assert.AreEqual(convertBackToDTO.AtlbRecordType, bl.AtlbRecordType);
			Assert.AreEqual(convertBackToDTO.FlightAircraftCode, bl.FlightAircraftCode);
			Assert.AreEqual(convertBackToDTO.CancelReasonId, bl.CancelReason.ItemId);
			Assert.AreEqual(convertBackToDTO.StationFrom, bl.StationFromId.ItemId);
			Assert.AreEqual(convertBackToDTO.StationTo, bl.StationToId.ItemId);
			Assert.AreEqual(convertBackToDTO.FlightNumberId, bl.FlightNumber.ItemId);
		}

		[TestMethod]
		public void TestAircraftWorkerCategoryDTOConverter()
		{
			var dto = new AircraftWorkerCategoryDTO
			{
				ItemId = 1,
				IsDeleted = true,
				Category = "test cat"
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.Category, dto.Category);
			
			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.Category, bl.Category);
		}

		[TestMethod]
		public void TestATLBDTOConverter()
		{
			var dto = new ATLBDTO
			{
				ItemId = 1,
				IsDeleted = true,
				//AircraftID = 2,
				ATLBNo = "test atlbno",
				StartPageNo = 6,
				OpeningDate = DateTime.Today,
				Remarks = "test rem",
				Revision = "test rev",
				PageFlightCount = 8,
				AtlbStatus = 10
			};

			var bl = dto.Convert();

			Assert.IsNotNull(bl);
			Assert.AreEqual(bl.ItemId, dto.ItemId);
			Assert.AreEqual(bl.IsDeleted, dto.IsDeleted);
			Assert.AreEqual(bl.ATLBNo, dto.ATLBNo);
			Assert.AreEqual(bl.StartPageNo, dto.StartPageNo);
			Assert.AreEqual(bl.OpeningDate, dto.OpeningDate);
			Assert.AreEqual(bl.Remarks, dto.Remarks);
			Assert.AreEqual(bl.Revision, dto.Revision);
			Assert.AreEqual(bl.PageFlightCount, dto.PageFlightCount);
			Assert.AreEqual(bl.AtlbStatus, dto.AtlbStatus);

			var convertBackToDTO = bl.Convert();

			Assert.IsNotNull(convertBackToDTO);
			Assert.AreEqual(convertBackToDTO.ItemId, bl.ItemId);
			Assert.AreEqual(convertBackToDTO.IsDeleted, bl.IsDeleted);
			Assert.AreEqual(convertBackToDTO.ATLBNo, bl.ATLBNo);
			Assert.AreEqual(convertBackToDTO.StartPageNo, bl.StartPageNo);
			Assert.AreEqual(convertBackToDTO.OpeningDate, bl.OpeningDate);
			Assert.AreEqual(convertBackToDTO.Remarks, bl.Remarks);
			Assert.AreEqual(convertBackToDTO.Revision, bl.Revision);
			Assert.AreEqual(convertBackToDTO.PageFlightCount, bl.PageFlightCount);
			Assert.AreEqual(convertBackToDTO.AtlbStatus, bl.AtlbStatus);
		}
	}
}