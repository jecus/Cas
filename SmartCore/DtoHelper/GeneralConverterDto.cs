using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartCore.DtoHelper
{
	public static class GeneralConverterDto
	{
		public static AccessoryRequiredDTO Convert(this AccessoryRequired required)
		{
			return new AccessoryRequiredDTO
			{
				ItemId = required.ItemId,
				IsDeleted = required.IsDeleted,
				ParentId = required.ParentId,
				ParentTypeId = required.ParentTypeId,
				AircraftModelId = required.AircraftModelId,
				PartNumber = required.PartNumber,
				Description = required.Description,
				Manufacturer = required.Manufacturer,
				Measure = required.Measure?.ItemId,
				Quantity = required.Quantity,
				CostNew = required.CostNew,
				CostServiceable = required.CostServiceable,
				CostOverhaul = required.CostOverhaul,
				Remarks = required.Remarks,
				AccessoryDescriptionId = required.Product?.ItemId,
				GoodStandartId = required.Standart?.ItemId,
			};
		}

		public static AccessoryRequired Convert(this AccessoryRequiredDTO required)
		{
			return new AccessoryRequired
			{
				ItemId = required.ItemId,
				IsDeleted = required.IsDeleted,
				ParentId = required.ParentId,
				ParentTypeId = required.ParentTypeId ?? default(int),
				AircraftModelId = required.AircraftModelId ?? default(int),
				Measure = required.Measure.HasValue ? Measure.Items.GetItemById(required.Measure.Value) : Measure.Unknown,
				Quantity = required.Quantity ?? default(double),
				Remarks = required.Remarks,
				Product = required.Product?.ConvertToProduct(),
				Standart = required.Standart?.Convert()
			};
		}

		public static ActualStateRecordDTO Convert(this ActualStateRecord record)
		{
			return new ActualStateRecordDTO
			{
				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				FlightRegimeId = record.WorkRegime?.ItemId ?? -1,
				Remarks = record.Remarks,
				OnLifelength = record.OnLifelength?.ConvertToByteArray(),
				RecordDate = record.RecordDate,
				WorkRegimeTypeId = record.WorkRegimeType?.ItemId ?? -1,
				ComponentId = record.ComponentId
			};
		}

		public static ActualStateRecord Convert(this ActualStateRecordDTO record)
		{
			return new ActualStateRecord
			{
				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				WorkRegime = FlightRegime.Items.GetItemById(record.FlightRegimeId),
				Remarks = record.Remarks,
				OnLifelength = Lifelength.ConvertFromByteArray(record.OnLifelength),
				RecordDate = record.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				WorkRegimeType = SmartCoreType.Items.GetItemById(record.WorkRegimeTypeId ?? -1),
				ComponentId = record.ComponentId,
			};
		}

		public static AircraftDTO Convert(this Aircraft aircraft)
		{
			return new AircraftDTO
			{
				ItemId = aircraft.ItemId,
				IsDeleted = aircraft.IsDeleted,
				AircraftFrameId = aircraft.AircraftFrameId,
				OperatorID = aircraft.OperatorId,
				APUFH = aircraft.APUFH,
				AircraftTypeID = aircraft.AircraftTypeId,
				ModelId = aircraft.Model?.ItemId,
				TypeCertificateNumber= aircraft.TypeCertificateNumber,
				ManufactureDate = aircraft.ManufactureDate,
				RegistrationNumber = aircraft.RegistrationNumber,
				SerialNumber = aircraft.SerialNumber,
				VariableNumber = aircraft.VariableNumber,
				LineNumber = aircraft.LineNumber,
				Owner = aircraft.Owner,
				BasicEmptyWeight = aircraft.BasicEmptyWeight,
				BasicEmptyWeightCargoConfig = aircraft.BasicEmptyWeightCargoConfig,
				CargoCapacityContainer = aircraft.CargoCapacityContainer,
				Cruise = aircraft.Cruise,
				CruiseFuelFlow = aircraft.CruiseFuelFlow,
				FuelCapacity = aircraft.FuelCapacity,
				MaxCruiseAltitude = aircraft.MaxCruiseAltitude,
				MaxLandingWeight = aircraft.MaxLandingWeight,
				MaxPayloadWeight = aircraft.MaxLandingWeight,
				MaxTakeOffCrossWeight = aircraft.MaxTakeOffCrossWeight,
				MaxTaxiWeight = aircraft.MaxTaxiWeight,
				MaxZeroFuelWeight = aircraft.MaxZeroFuelWeight,
				OperationalEmptyWeight = aircraft.OperationalEmptyWeight,
				CockpitSeating = aircraft.CockpitSeating,
				Galleys = aircraft.Galleys,
				Lavatory = aircraft.Lavatory,
				SeatingEconomy = (short?) aircraft.SeatingEconomy,
				SeatingBusiness = (short?) aircraft.SeatingBusiness,
				SeatingFirst = (short?) aircraft.SeatingFirst,
				Oven = aircraft.Oven,
				Boiler = aircraft.Boiler,
				AirStairDoors = aircraft.AirStairsDoors,
				Tanks = aircraft.Tanks,
				AircraftAddress24Bit = aircraft.AircraftAddress24Bit,
				ELTIdHexCode = aircraft.ELTIdHexCode,
				DeliveryDate = aircraft.DeliveryDate,
				AcceptanceDate = aircraft.AcceptanceDate,
				Schedule = aircraft.Schedule,
				MSG = (short) aircraft.MSG,
				CheckNaming = aircraft.MaintenanceProgramCheckNaming,
				NoiceCategory = aircraft.NoiceCategory,
				FADEC = aircraft.FADEC,
				LandingCategory = aircraft.LandingCategory,
				EFIS = aircraft.EFIS,
				Brakes = (short) aircraft.Brakes,
				Winglets = aircraft.Winglets,
				ApuUtizationPerFlightinMinutes = aircraft.ApuUtizationPerFlightinMinutes,
			};
		}

		public static Aircraft Convert(this AircraftDTO aircraftDto)
		{
			var value =  new Aircraft
			{
				ItemId = aircraftDto.ItemId,
				AircraftFrameId = aircraftDto.AircraftFrameId,
				IsDeleted = aircraftDto.IsDeleted,
				APUFH = aircraftDto.APUFH,
				OperatorId = aircraftDto.OperatorID,
				AircraftTypeId = aircraftDto.AircraftTypeID,
				TypeCertificateNumber = aircraftDto.TypeCertificateNumber,
				ManufactureDate = aircraftDto.ManufactureDate,
				RegistrationNumber = aircraftDto.RegistrationNumber,
				SerialNumber = aircraftDto.SerialNumber,
				VariableNumber = aircraftDto.VariableNumber,
				LineNumber = aircraftDto.LineNumber,
				Owner = aircraftDto.Owner,
				BasicEmptyWeight = aircraftDto.BasicEmptyWeight ?? default(double),
				BasicEmptyWeightCargoConfig = aircraftDto.BasicEmptyWeightCargoConfig ?? default(double),
				CargoCapacityContainer = aircraftDto.CargoCapacityContainer,
				Cruise = aircraftDto.Cruise,
				CruiseFuelFlow = aircraftDto.CruiseFuelFlow,
				FuelCapacity = aircraftDto.FuelCapacity,
				MaxCruiseAltitude = aircraftDto.MaxCruiseAltitude,
				MaxLandingWeight = aircraftDto.MaxLandingWeight ?? default(double),
				MaxPayloadWeight = aircraftDto.MaxPayloadWeight ?? default(double),
				MaxTakeOffCrossWeight = aircraftDto.MaxTakeOffCrossWeight ?? default(double),
				MaxTaxiWeight = aircraftDto.MaxTaxiWeight ?? default(double),
				MaxZeroFuelWeight = aircraftDto.MaxZeroFuelWeight ?? default(double),
				OperationalEmptyWeight = aircraftDto.OperationalEmptyWeight ?? default(double),
				CockpitSeating = aircraftDto.CockpitSeating,
				Galleys = aircraftDto.Galleys,
				Lavatory = aircraftDto.Lavatory,
				SeatingEconomy = aircraftDto.SeatingEconomy ?? default(int),
				SeatingBusiness = aircraftDto.SeatingBusiness ?? default(int),
				SeatingFirst = aircraftDto.SeatingFirst ?? default(int),
				Oven = aircraftDto.Oven,
				Boiler = aircraftDto.Boiler,
				AirStairsDoors = aircraftDto.AirStairDoors,
				Tanks = aircraftDto.Tanks ?? default(int),
				AircraftAddress24Bit = aircraftDto.AircraftAddress24Bit,
				ELTIdHexCode = aircraftDto.ELTIdHexCode,
				DeliveryDate = aircraftDto.DeliveryDate,
				AcceptanceDate = aircraftDto.AcceptanceDate,
				Schedule = aircraftDto.Schedule,
				MSG = (MSG)aircraftDto.MSG,
				MaintenanceProgramCheckNaming = aircraftDto.CheckNaming,
				NoiceCategory = aircraftDto.NoiceCategory,
				FADEC = aircraftDto.FADEC,
				LandingCategory = aircraftDto.LandingCategory,
				EFIS = aircraftDto.EFIS,
				Brakes = (Brakes)aircraftDto.Brakes,
				Winglets = aircraftDto.Winglets,
				ApuUtizationPerFlightinMinutes = aircraftDto.ApuUtizationPerFlightinMinutes,
				Model = aircraftDto.Model?.ConvertToAircraftModel()
			};

			if (aircraftDto.MaintenanceProgramChangeRecords != null)
				value.MaintenanceProgramChangeRecords.AddRange(aircraftDto.MaintenanceProgramChangeRecords.Select(i => i.Convert()));
			
			return value;
		}

		public static EngineConditionDTO Convert(this EngineCondition condition)
		{
			return new EngineConditionDTO
			{
				ItemId = condition.ItemId,
				IsDeleted = condition.IsDeleted,
				FlightID = condition.FlightId,
				EngineID = condition.EngineId,
				RecordDate = condition.RecordDate,
				TimeGMT = (int?)condition.TimeGMT.Ticks,
				TimeInRegime = condition.TimeInRegime,
				Weather = (short?) condition.Weather,
				PressAlt = condition.PressALT,
				IAS = condition.IAS,
				TAT = condition.TAT,
				OAT = condition.OAT,
				Mach = condition.Mach,
				GrossWeight = condition.GrossWeight,
				ERP = condition.ERP,
				N1 = condition.N1,
				EGT = condition.EGT,
				N2 = condition.N2,
				OilTemperature = condition.OilTemperature,
				OilPressure = condition.OilPressure,
				FuelFlow = condition.FuelFlow,
				FuelBurn = condition.FuelBurn,
				ThrottleLeverAngle = condition.ThrottleLeverAngle,
				FuelPress = condition.FuelPress,
				OilPressTorque = condition.OilPressTorque,
				VibroOverload = condition.VibroOverload,
				VibroOverload2 = condition.VibroOverload2,
				GroundAir = (short?) condition.GroundAir,
				OilFlow = condition.OilFlow
			};
		}

		public static EngineCondition Convert(this EngineConditionDTO conditionDto)
		{
			return new EngineCondition
			{
				ItemId = conditionDto.ItemId,
				IsDeleted = conditionDto.IsDeleted,
				FlightId = conditionDto.FlightID,
				EngineId = conditionDto.EngineID,
				RecordDate = conditionDto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				TimeGMT = new TimeSpan(conditionDto.TimeGMT ?? default(int)),
				TimeInRegime = conditionDto.TimeInRegime ?? default(short),
				Weather = conditionDto.Weather.HasValue ? (WeatherCondition) conditionDto.Weather.Value : WeatherCondition.Unknown,
				PressALT = conditionDto.PressAlt ?? default(int),
				IAS = conditionDto.IAS ?? default(double),
				TAT = conditionDto.TAT ?? default(double),
				OAT = conditionDto.OAT ?? default(double),
				Mach = conditionDto.Mach ?? default(double),
				GrossWeight = conditionDto.GrossWeight ?? default(double),
				ERP = conditionDto.ERP ?? default(double),
				N1 = conditionDto.N1 ?? default(double),
				EGT = conditionDto.EGT ?? default(double),
				N2 = conditionDto.N2 ?? default(double),
				OilTemperature = conditionDto.OilTemperature ?? default(double),
				OilPressure = conditionDto.OilPressure ?? default(double),
				FuelFlow = conditionDto.FuelFlow ?? default(double),
				FuelBurn = conditionDto.FuelBurn ?? default(double),
				ThrottleLeverAngle = conditionDto.ThrottleLeverAngle ?? default(int),
				FuelPress = conditionDto.FuelPress ?? default(double),
				OilPressTorque = conditionDto.OilPressTorque ?? default(double),
				VibroOverload = conditionDto.VibroOverload ?? default(double),
				VibroOverload2 = conditionDto.VibroOverload2 ?? default(double),
				GroundAir = conditionDto.GroundAir.HasValue ? (GroundAir) conditionDto.GroundAir.Value : GroundAir.Air,
				OilFlow = conditionDto.OilFlow ?? default(double)
			};
		}

		public static MaintenanceProgramChangeRecordDTO Convert(this MaintenanceProgramChangeRecord record)
		{
			return new MaintenanceProgramChangeRecordDTO
			{
				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				ParentAircraftId = record.ParentAircraftId,
				MSG = (short?) record.MSG,
				MaintenanceCheckRecordId = record.MaintenanceCheckRecordId,
				CalculatedPerformanceSource = record.CalculatedPerformanceSource?.ConvertToByteArray(),
				PerformanceNum = record.PerformanceNum,
				RecordDate = record.RecordDate,
				OnLifelength = record.OnLifelength?.ConvertToByteArray(),
				Remarks = record.Remarks
			};
		}

		public static MaintenanceProgramChangeRecord Convert(this MaintenanceProgramChangeRecordDTO record)
		{
			return new MaintenanceProgramChangeRecord
			{
				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				ParentAircraftId = record.ParentAircraftId ?? default(int),
				MSG = record.MSG.HasValue ? (MSG)record.MSG.Value : MSG.Unknown,
				MaintenanceCheckRecordId = record.MaintenanceCheckRecordId ?? default(int),
				CalculatedPerformanceSource = Lifelength.ConvertFromByteArray(record.CalculatedPerformanceSource),
				PerformanceNum = record.PerformanceNum ?? default(int),
				RecordDate = record.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				OnLifelength = Lifelength.ConvertFromByteArray(record.OnLifelength),
				Remarks = record.Remarks
			};
		}

		public static JobCardDTO Convert(this JobCard card)
		{
			return new JobCardDTO
			{
				ItemId = card.ItemId,
				IsDeleted = card.IsDeleted,
				ParentId = card.ParentId,
				WorkArea = card.WorkArea,
				ManHours = card.ManHours,
				Cost = card.Cost,
				ParentTypeId = card.ParentType?.ItemId,
				Form = card.Form,
				FormRevision = card.FormRevision,
				FormDate = card.FormDate,
				PreparedByDate = card.PreparedByDate,
				PreparedById = card.PreparedBy?.ItemId,
				CheckedByDate = card.CheckedByDate,
				CheckedById = card.CheckedBy?.ItemId,
				ApprovedByDate = card.ApprovedByDate,
				ApprovedById = card.ApprovedBy?.ItemId,
				JobCardNumber = card.JobCardNumber,
				JobCardHeader = card.JobCardHeader,
				JobCardDate = card.JobCardDate,
				JobCardRevision = card.JobCardRevision,
				JobCardRevisionDate = card.JobCardRevisionDate,
				Title = card.Title,
				Description = card.Description,
				AtaChapterId = card.AtaChapter?.ItemId,
				Zone = card.Zone,
				Access = card.Access,
				Station = card.Station,
				MRO = card.MRO,
				MaintenanceManualRevision = card.MaintenanceManualRevision,
				MaintenanceManualRevisionDate = card.MaintenanceManualRevisionDate,
				Qualification = card.Qualification?.Convert(),
				QualificationId = card.Qualification?.ItemId,
				Man = card.Man,
				JobCardFooter = card.JobCardFooter,
				Phase = card.Phase,
				Applicability = card.Applicability,
				RefDocType = card.MaintenanceManual?.ItemId,
				DirectiveTypeId = card.WorkType?.ItemId,
				Kits = card.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,
				JobCardTasks = card.JobCardTasks?.Select(i => i.Convert()) as ICollection<JobCardTaskDTO>
			};
		}

		public static JobCard Convert(this JobCardDTO card)
		{
			var value = new JobCard
			{
				ItemId = card.ItemId,
				IsDeleted = card.IsDeleted,
				ParentId = card.ParentId,
				WorkArea = card.WorkArea,
				ManHours = card.ManHours ?? default(double),
				Cost = card.Cost ?? default(double),
				ParentType = card.ParentTypeId.HasValue ? SmartCoreType.GetSmartCoreTypeById(card.ParentTypeId.Value) : SmartCoreType.Unknown,
				Form = card.Form,
				FormRevision = card.FormRevision,
				FormDate = card.FormDate ?? DateTimeExtend.GetCASMinDateTime(),
				PreparedByDate = card.PreparedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				CheckedByDate = card.CheckedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				ApprovedByDate = card.ApprovedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				JobCardNumber = card.JobCardNumber,
				JobCardHeader = card.JobCardHeader,
				JobCardDate = card.JobCardDate ?? DateTimeExtend.GetCASMinDateTime(),
				JobCardRevision = card.JobCardRevision,
				JobCardRevisionDate = card.JobCardRevisionDate ?? DateTimeExtend.GetCASMinDateTime(),
				Title = card.Title,
				Description = card.Description,
				Zone = card.Zone,
				Access = card.Access,
				Station = card.Station,
				MRO = card.MRO,
				MaintenanceManualRevision = card.MaintenanceManualRevision,
				MaintenanceManualRevisionDate = card.MaintenanceManualRevisionDate ?? DateTimeExtend.GetCASMinDateTime(),
				Qualification = card.Qualification?.Convert(),
				Man = card.Man ?? default(int),
				JobCardFooter = card.JobCardFooter,
				Phase = card.Phase,
				Applicability = card.Applicability,
				MaintenanceManual = card.RefDocType.HasValue ? RefDocType.GetItemById(card.RefDocType.Value) : RefDocType.Unknown,
				WorkType = card.DirectiveTypeId.HasValue ? MaintenanceDirectiveTaskType.GetItemById(card.DirectiveTypeId.Value) : MaintenanceDirectiveTaskType.Unknown,
				PreparedBy = card.PreparedBy?.Convert(),
				CheckedBy = card.CheckedBy?.Convert(),
				ApprovedBy = card.ApprovedBy?.Convert(),
				AtaChapter = card.AtaChapter?.Convert()
			};

			if (card.Kits != null)
			{
				foreach (var dto in card.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}
			}

			if (card.JobCardTasks != null)
				value.JobCardTasks.AddRange(card.JobCardTasks.Select(i => i.Convert()));

			return value;
		}

		public static JobCardTaskDTO Convert(this JobCardTask cardTask)
		{
			return new JobCardTaskDTO
			{
				ItemId = cardTask.ItemId,
				IsDeleted = cardTask.IsDeleted,
				JobCardId = cardTask.JobCard?.ItemId,
				ParentTaskId = cardTask.ParentTaskId,
				Number = cardTask.Number,
				Description = cardTask.Description,
				Man = cardTask.Man,
				ManHours = cardTask.ManHours,
				Cost = cardTask.Cost,
			};
		}

		public static JobCardTask Convert(this JobCardTaskDTO cardTask)
		{
			return new JobCardTask
			{
				ItemId = cardTask.ItemId,
				IsDeleted = cardTask.IsDeleted,
				ParentTaskId = cardTask.ParentTaskId ?? default(int),
				Number = cardTask.Number,
				Description = cardTask.Description,
				Man = cardTask.Man ?? default(int),
				ManHours = cardTask.ManHours ?? default(double),
				Cost = cardTask.Cost ?? default(double),
				JobCard = cardTask.JobCard?.Convert()
			};
		}

		public static SpecialistDTO Convert(this Specialist specialist)
		{
			return new SpecialistDTO
			{
				ItemId = specialist.ItemId,
				IsDeleted = specialist.IsDeleted,
				FirstName = specialist.FirstName,
				ShortName = specialist.ShortName,
				SpecializationID = specialist.Specialization?.ItemId ?? -1,
				LastName = specialist.LastName,
				Gender = (short?) specialist.Gender,
				AGWCategoryId = specialist.AGWCategory?.ItemId,
				DateOfBirth = specialist.DateOfBirth,
				Nationality = specialist.Nationality,
				Address = specialist.Address,
				Photo = specialist.Photo,
				PhoneMobile = specialist.PhoneMobile,
				Phone = specialist.Phone,
				Email = specialist.Email,
				Skype = specialist.Skype,
				Information = specialist.Information,
				Education = (short) (specialist.Education?.ItemId ?? -1),
				Location = (short) (specialist.Facility?.ItemId ?? -1),
				Status = (short) specialist.Status,
				Position = (short) specialist.Position,
				Sign = specialist.Sign,
				FamilyStatus = (short) (specialist.FamilyStatus?.ItemId ?? -1),
				Citizenship = (short) (specialist.Citizenship?.ItemId ?? -1),
				PersonnelCategoryId = specialist.PersonnelCategory?.ItemId ?? -1,
				ClassNumber = specialist.ClassNumber,
				ClassIssueDate = specialist.ClassIssueDate,
				GradeNumber = specialist.GradeNumber,
				GradeIssueDate = specialist.GradeIssueDate,
				Additional = specialist.Additional,
				Combination = specialist.Combination,
				Licenses = specialist.Licenses?.Select(i => i.Convert()) as ICollection<SpecialistLicenseDTO>,
				SpecialistTrainings = specialist.SpecialistTrainings?.Select(i => i.Convert()) as ICollection<SpecialistTrainingDTO>,
				LicenseDetails = specialist.LicenseDetails?.Select(i => i.Convert()) as ICollection<SpecialistLicenseDetailDTO>,
				LicenseRemark = specialist.LicenseRemark?.Select(i => i.Convert()) as ICollection<SpecialistLicenseRemarkDTO>,
				EmployeeDocuments = specialist.EmployeeDocuments?.Select(i => i.Convert()) as ICollection<DocumentDTO>,
				CategoriesRecords = specialist.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Files = specialist.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static Specialist Convert(this SpecialistDTO specialist)
		{
			var value = new Specialist
			{
				ItemId = specialist.ItemId,
				IsDeleted = specialist.IsDeleted,
				FirstName = specialist.FirstName,
				LastName = specialist.LastName,
				ShortName = specialist.ShortName,
				Gender = specialist.Gender.HasValue ? (Gender)specialist.Gender.Value : Gender.NotApplicable,
				DateOfBirth = specialist.DateOfBirth ?? DateTimeExtend.GetCASMinDateTime(),
				Nationality = specialist.Nationality,
				Address = specialist.Address,
				Photo = specialist.Photo,
				PhoneMobile = specialist.PhoneMobile,
				Phone = specialist.Phone,
				Email = specialist.Email,
				Skype = specialist.Skype,
				Information = specialist.Information,
				Education = Education.GetItemById(specialist.Education),
				Status = (SpecialistStatus)specialist.Status,
				Position = (SpecialistPosition)specialist.Position,
				Sign = specialist.Sign,
				FamilyStatus = FamilyStatus.GetItemById(specialist.FamilyStatus),
				Citizenship = Citizenship.GetItemById(specialist.Citizenship),
				PersonnelCategory = PersonnelCategory.GetItemById(specialist.PersonnelCategoryId),
				ClassNumber = specialist.ClassNumber,
				ClassIssueDate = specialist.ClassIssueDate ?? DateTimeExtend.GetCASMinDateTime(),
				GradeNumber = specialist.GradeNumber,
				GradeIssueDate = specialist.GradeIssueDate ?? DateTimeExtend.GetCASMinDateTime(),
				Additional = specialist.Additional,
				Combination = specialist.Combination ?? "",
				AGWCategory = specialist.AGWCategory?.Convert(),
				Facility = specialist.Facility?.Convert(),
				Specialization = specialist.Specialization?.Convert()
			};

			if (specialist.Licenses != null)
				value.Licenses.AddRange(specialist.Licenses.Select(i => i.Convert()));

			if (specialist.SpecialistTrainings != null)
				value.SpecialistTrainings.AddRange(specialist.SpecialistTrainings.Select(i => i.Convert()));

			if (specialist.LicenseDetails != null)
				value.LicenseDetails.AddRange(specialist.LicenseDetails.Select(i => i.Convert()));

			if (specialist.LicenseRemark != null)
				value.LicenseRemark.AddRange(specialist.LicenseRemark.Select(i => i.Convert()));

			if (specialist.EmployeeDocuments != null)
				value.EmployeeDocuments.AddRange(specialist.EmployeeDocuments.Select(i => i.Convert()));

			if (specialist.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(specialist.CategoriesRecords.Select(i => i.Convert()));

			if (specialist.Files != null)
				value.Files.AddRange(specialist.Files.Select(i => i.Convert()));

			return value;
		}

		public static SpecialistTrainingDTO Convert(this SpecialistTraining specialistTraining)
		{
			return new SpecialistTrainingDTO
			{
				ItemId = specialistTraining.ItemId,
				IsDeleted = specialistTraining.IsDeleted,
				SpecialistId = specialistTraining.SpecialistId,
				TrainingId = specialistTraining.TrainingType?.ItemId,
				SupplierId = specialistTraining.Supplier?.ItemId,
				ManHours = specialistTraining.ManHours,
				Cost = specialistTraining.Cost,
				Remarks = specialistTraining.Remarks,
				HiddenRemark = specialistTraining.HiddenRemark,
				Description = specialistTraining.Description,
				Threshold = specialistTraining.Threshold?.ToBinary(),
				IsClosed = specialistTraining.IsClosed,
				AircraftTypeID = specialistTraining.AircraftTypeID,
				EmployeeSubjectID = specialistTraining.EmployeeSubject?.ItemId ?? -1,
				Files = specialistTraining.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static SpecialistTraining Convert(this SpecialistTrainingDTO specialistTraining)
		{
			var value = new SpecialistTraining
			{
				ItemId = specialistTraining.ItemId,
				IsDeleted = specialistTraining.IsDeleted,
				SpecialistId = specialistTraining.SpecialistId,
				TrainingType = specialistTraining.TrainingId.HasValue ? TrainingType.GetDirectiveTypeById(specialistTraining.TrainingId.Value) : TrainingType.Unknown,
				ManHours = specialistTraining.ManHours ?? default(double),
				Cost = specialistTraining.Cost ?? default(double),
				Remarks = specialistTraining.Remarks,
				HiddenRemark = specialistTraining.HiddenRemark,
				Description = specialistTraining.Description,
				Threshold = new TrainingThreshold(specialistTraining.Threshold),
				IsClosed = specialistTraining.IsClosed ?? default(bool),
				AircraftTypeID = specialistTraining.AircraftTypeID,
				AircraftType = specialistTraining.AircraftType?.ConvertToAircraftModel(),
				EmployeeSubject = specialistTraining.EmployeeSubject?.Convert(),
				Supplier = specialistTraining.Supplier?.Convert(),
			};

			if (specialistTraining.Files != null)
				value.Files.AddRange(specialistTraining.Files.Select(i => i.Convert()));

			return value;
		}

		public static SpecialistLicenseDTO Convert(this SpecialistLicense license)
		{
			return new SpecialistLicenseDTO
			{
				ItemId = license.ItemId,
				IsDeleted = license.IsDeleted,
				Confirmation = license.Confirmation,
				LicenseTypeID = license.EmployeeLicenceType?.ItemId ?? -1,
				AircraftTypeID = license.AircraftTypeID,
				SpecialistId = license.SpecialistId,
				Notify = license.NotifyLifelength?.ConvertToByteArray(),
				IssueDate = license.IssueDate,
				ValidToDate = license.ValidToDate,
				CaaLicense = license.CaaLicense?.Select(i => i.Convert()) as ICollection<SpecialistCAADTO>,
				LicenseDetails = license.LicenseDetails?.Select(i => i.Convert()) as ICollection<SpecialistLicenseDetailDTO>,
				LicenseRatings = license.LicenseRatings?.Select(i => i.Convert()) as ICollection<SpecialistLicenseRatingDTO>,
				SpecialistInstrumentRatings = license.SpecialistInstrumentRatings?.Select(i => i.Convert()) as ICollection<SpecialistInstrumentRatingDTO>,
				LicenseRemark = license.LicenseRemark?.Select(i => i.Convert()) as ICollection<SpecialistLicenseRemarkDTO>
			};
		}

		public static SpecialistLicense Convert(this SpecialistLicenseDTO license)
		{
			var value = new SpecialistLicense
			{
				ItemId = license.ItemId,
				IsDeleted = license.IsDeleted,
				Confirmation = license.Confirmation,
				EmployeeLicenceType = EmployeeLicenceType.Items.GetItemById(license.LicenseTypeID),
				AircraftTypeID = license.AircraftTypeID,
				SpecialistId = license.SpecialistId,
				NotifyLifelength = Lifelength.ConvertFromByteArray(license.Notify),
				IssueDate = license.IssueDate ?? DateTimeExtend.GetCASMinDateTime(),
				ValidToDate = license.ValidToDate ?? DateTimeExtend.GetCASMinDateTime(),
				AircraftType = license.AircraftType?.ConvertToAircraftModel()
			};

			if (license.CaaLicense != null)
				value.CaaLicense.AddRange(license.CaaLicense.Select(i => i.Convert()));

			if (license.LicenseDetails != null)
				value.LicenseDetails.AddRange(license.LicenseDetails.Select(i => i.Convert()));

			if (license.LicenseRatings != null)
				value.LicenseRatings.AddRange(license.LicenseRatings.Select(i => i.Convert()));

			if (license.SpecialistInstrumentRatings != null)
				value.SpecialistInstrumentRatings.AddRange(license.SpecialistInstrumentRatings.Select(i => i.Convert()));

			if (license.LicenseRemark != null)
				value.LicenseRemark.AddRange(license.LicenseRemark.Select(i => i.Convert()));

			return value;
		}

		public static SpecialistLicenseRemarkDTO Convert(this SpecialistLicenseRemark licenseRemark)
		{
			return new SpecialistLicenseRemarkDTO
			{
				ItemId = licenseRemark.ItemId,
				IsDeleted = licenseRemark.IsDeleted,
				IssueDate = licenseRemark.IssueDate,
				RightsId = licenseRemark.Rights?.ItemId ?? -1,
				RestrictionId = licenseRemark.LicenseRestriction?.ItemId ?? -1,
				SpecialistLicenseId = licenseRemark.SpecialistLicenseId,
				SpecialistId = licenseRemark.SpecialistId,
			};
		}

		public static SpecialistLicenseRemark Convert(this SpecialistLicenseRemarkDTO licenseRemark)
		{
			return new SpecialistLicenseRemark
			{
				ItemId = licenseRemark.ItemId,
				IsDeleted = licenseRemark.IsDeleted,
				IssueDate = licenseRemark.IssueDate,
				SpecialistLicenseId = licenseRemark.SpecialistLicenseId,
				SpecialistId = licenseRemark.SpecialistId,
				Rights = licenseRemark.Rights?.Convert(),
				LicenseRestriction = licenseRemark.LicenseRestriction?.Convert()
			};
		}

		public static SpecialistInstrumentRatingDTO Convert(this SpecialistInstrumentRating instrumentRating)
		{
			return new SpecialistInstrumentRatingDTO
			{
				ItemId = instrumentRating.ItemId,
				IsDeleted = instrumentRating.IsDeleted,
				IssueDate = instrumentRating.IssueDate,
				SpecialistLicenseId = instrumentRating.SpecialistLicenseId,
				IcaoId = instrumentRating.Icao?.ItemId ?? -1,
				MC = instrumentRating.MC,
				MV = instrumentRating.MV,
				RVR = instrumentRating.RVR,
				TORVR = instrumentRating.TORVR
			};
		}

		public static SpecialistInstrumentRating Convert(this SpecialistInstrumentRatingDTO instrumentRating)
		{
			return new SpecialistInstrumentRating
			{
				ItemId = instrumentRating.ItemId,
				IsDeleted = instrumentRating.IsDeleted,
				IssueDate = instrumentRating.IssueDate,
				SpecialistLicenseId = instrumentRating.SpecialistLicenseId,
				Icao = LicenseIcao.GetItemById(instrumentRating.IcaoId),
				MC = instrumentRating.MC,
				MV = instrumentRating.MV,
				RVR = instrumentRating.RVR,
				TORVR = instrumentRating.TORVR
			};
		}

		public static SpecialistLicenseRatingDTO Convert(this SpecialistLicenseRating licenseRating)
		{
			return new SpecialistLicenseRatingDTO
			{
				ItemId = licenseRating.ItemId,
				IsDeleted = licenseRating.IsDeleted,
				SpecialistLicenseId = licenseRating.SpecialistLicenseId,
				IssueDate = licenseRating.IssueDate,
				RightsId = licenseRating.Rights?.ItemId ?? -1,
				FunctionId = licenseRating.LicenseFunction?.ItemId ?? -1
			};
		}

		public static SpecialistLicenseRating Convert(this SpecialistLicenseRatingDTO licenseRating)
		{
			return new SpecialistLicenseRating
			{
				ItemId = licenseRating.ItemId,
				IsDeleted = licenseRating.IsDeleted,
				SpecialistLicenseId = licenseRating.SpecialistLicenseId,
				IssueDate = licenseRating.IssueDate,
				Rights = LicenseRights.Items.GetItemById(licenseRating.RightsId),
				LicenseFunction = LicenseFunction.GetItemById(licenseRating.FunctionId)
			};
		}

		public static SpecialistLicenseDetailDTO Convert(this SpecialistLicenseDetail licenseDetail)
		{
			return new SpecialistLicenseDetailDTO
			{
				ItemId = licenseDetail.ItemId,
				IsDeleted = licenseDetail.IsDeleted,
				Description = licenseDetail.Description,
				IssueDate = licenseDetail.IssueDate,
				SpecialistLicenseId = licenseDetail.SpecialistLicenseId,
				SpecialistId = licenseDetail.SpecialistId
			};
		}

		public static SpecialistLicenseDetail Convert(this SpecialistLicenseDetailDTO licenseDetail)
		{
			return new SpecialistLicenseDetail
			{
				ItemId = licenseDetail.ItemId,
				IsDeleted = licenseDetail.IsDeleted,
				Description = licenseDetail.Description,
				IssueDate = licenseDetail.IssueDate,
				SpecialistLicenseId = licenseDetail.SpecialistLicenseId,
				SpecialistId = licenseDetail.SpecialistId
			};
		}

		public static SpecialistCAADTO Convert(this SpecialistCAA specialistCaa)
		{
			return new SpecialistCAADTO
			{
				ItemId = specialistCaa.ItemId,
				IsDeleted = specialistCaa.IsDeleted,
				NumberCAA = specialistCaa.CAANumber,
				CAAId = specialistCaa.Caa?.ItemId ?? -1,
				CAAType = (int) specialistCaa.CaaType,
				ValidTo = specialistCaa.ValidToDate,
				SpecialistLicenseId = specialistCaa.SpecialistLicenseId,
				Notify = specialistCaa.NotifyLifelength?.ConvertToByteArray(),
				IssueDate = specialistCaa.IssueDate
			};
		}

		public static SpecialistCAA Convert(this SpecialistCAADTO specialistCaa)
		{
			return new SpecialistCAA
			{
				ItemId = specialistCaa.ItemId,
				IsDeleted = specialistCaa.IsDeleted,
				CAANumber = specialistCaa.NumberCAA,
				Caa = Citizenship.Items.GetItemById(specialistCaa.CAAId),
				CaaType = (CaaType) specialistCaa.CAAType,
				ValidToDate = specialistCaa.ValidTo,
				SpecialistLicenseId = specialistCaa.SpecialistLicenseId,
				NotifyLifelength = Lifelength.ConvertFromByteArray(specialistCaa.Notify),
				IssueDate = specialistCaa.IssueDate ?? DateTimeExtend.GetCASMinDateTime()
			};
		}

		public static DocumentDTO Convert(this Document document)
		{
			return new DocumentDTO
			{
				ItemId = document.ItemId,
				IsDeleted = document.IsDeleted,
				ParentID = document.ParentId,
				ParentTypeId = document.ParentTypeId,
				DocTypeId = document.DocTypeId,
				SubTypeId = document.DocumentSubType?.ItemId ?? -1,
				Description = document.Description,
				IssueDateValidFrom = document.IssueDateValidFrom,
				IssueValidTo = document.IssueValidTo,
				IssueDateValidTo = document.IssueDateValidTo,
				IssueNotify = document.IssueNotify,
				ContractNumber = document.ContractNumber,
				Revision = document.Revision,
				RevNumber = document.RevisionNumder,
				RevisionDateFrom = document.RevisionDateFrom,
				IsClosed = document.IsClosed,
				DepartmentId = document.Department?.ItemId,
				RevisionValidTo = document.RevisionValidTo,
				RevisionDateValidTo = document.RevisionDateValidTo,
				RevisionNotify = document.RevisionNotify,
				Aboard = document.Aboard,
				Privy = document.Privy,
				IssueNumber = document.IssueNumber,
				NomenсlatureId = document.Nomenсlature?.ItemId,
				ProlongationWayId = (int?) document.ProlongationWay,
				ServiceTypeId = document.ServiceType?.ItemId,
				ResponsibleOccupationId = document.ResponsibleOccupation?.ItemId ?? -1,
				Remarks = document.Remarks,
				LocationId = document.Location?.ItemId ?? -1,
				SupplierId = document.Supplier?.ItemId ?? -1,
				ParentAircraftId = document.ParentAircraftId,
                IdNumber = document.IdNumber
            };
		}

		public static Document Convert(this DocumentDTO document)
		{
			var doc = new Document
			{
				ItemId = document.ItemId,
				IsDeleted = document.IsDeleted,
				ParentId = document.ParentID,
				ParentTypeId = document.ParentTypeId,
				DocTypeId = document.DocTypeId,
				DocumentSubType = document.DocumentSubType?.Convert(),
				Description = document.Description,
				IssueDateValidFrom = document.IssueDateValidFrom,
				IssueValidTo = document.IssueValidTo ?? default(bool),
				IssueDateValidTo = document.IssueDateValidTo,
				IssueNotify = document.IssueNotify ?? default(int),
				ContractNumber = document.ContractNumber,
				Revision = document.Revision ?? default(bool),
				RevisionNumder = document.RevNumber,
				RevisionDateFrom = document.RevisionDateFrom ?? DateTimeExtend.GetCASMinDateTime(),
				IsClosed = document.IsClosed ?? default(bool),
				RevisionValidTo = document.RevisionValidTo ?? default(bool),
				RevisionDateValidTo = document.RevisionDateValidTo ?? DateTimeExtend.GetCASMinDateTime(),
				RevisionNotify = document.RevisionNotify ?? default(int),
				ProlongationWay = document.ProlongationWayId.HasValue ? (ProlongationWay) document.ProlongationWayId.Value : ProlongationWay.Unknown,
				Aboard = document.Aboard,
				Privy = document.Privy,
				IssueNumber = document.IssueNumber,
				Remarks = document.Remarks,
				ParentAircraftId = document.ParentAircraftId ?? default(int),
                IdNumber = document.IdNumber,
                Supplier = document.Supplier?.Convert(),
				ResponsibleOccupation = document.ResponsibleOccupation?.Convert(),
				Nomenсlature = document.Nomenсlature?.Convert(),
				ServiceType = document.ServiceType?.Convert(),
				Location = document.Location?.Convert()
			};

			var department = document.Department?.Convert();
			if (department != null)
				doc.Department = department.IsDeleted ? Department.Unknown : department;
			else doc.Department = Department.Unknown;

			return doc;
		}

		public static SupplierDTO Convert(this Supplier supplier)
		{
			return new SupplierDTO
			{
				ItemId = supplier.ItemId,
				IsDeleted = supplier.IsDeleted,
				Name = supplier.Name,
				ShortName = supplier.ShortName,
				AirCode = supplier.AirCode,
				VendorCode = supplier.VendorCode,
				Phone = supplier.Phone,
				Fax = supplier.Fax,
				Address = supplier.Address,
				ContactPerson = supplier.ContactPerson,
				Email = supplier.Email,
				WebSite = supplier.WebSite,
				Products = supplier.Products,
				Approved = supplier.Approved,
				Remarks = supplier.Remarks,
				SupplierClassId = supplier.SupplierClass?.ItemId ?? -1,
				Subject = supplier.Subject,
				SupplierDocs = supplier.SupplierDocs?.Select(i => i.Convert()) as ICollection<DocumentDTO>
			};
		}

		public static Supplier Convert(this SupplierDTO supplier)
		{

			var value = new Supplier
			{
				ItemId = supplier.ItemId,
				IsDeleted = supplier.IsDeleted,

				Name = supplier.Name,
				ShortName = supplier.ShortName,
				AirCode = supplier.AirCode,
				VendorCode = supplier.VendorCode,
				Phone = supplier.Phone,

				Fax = supplier.Fax,
				Address = supplier.Address,

				ContactPerson = supplier.ContactPerson,
				Email = supplier.Email,
				WebSite = supplier.WebSite,
				Products = supplier.Products,
				Approved = supplier.Approved ?? default(bool),
				Remarks = supplier.Remarks,
				SupplierClass = SupplierClass.Items.GetItemById(supplier.SupplierClassId),

				Subject = supplier.Subject
			};

			if (supplier.SupplierDocs != null)

				value.SupplierDocs.AddRange(supplier.SupplierDocs.Select(i => i.Convert()));

			return value;
		}

		public static CategoryRecordDTO Convert(this CategoryRecord record)
		{
			return new CategoryRecordDTO
			{

				ItemId = record.ItemId,

				IsDeleted = record.IsDeleted,
				AircraftWorkerCategoryId = record.AircraftWorkerCategory?.ItemId,
				AircraftTypeId = record.AircraftModel?.ItemId,
				ParentId = record.ParentId,
				ParentTypeId = record.ParentType?.ItemId,
				AircraftModel = record.AircraftModel?.Convert(),
				AircraftWorkerCategory = record.AircraftWorkerCategory?.Convert()
			};
		}


		public static CategoryRecord Convert(this CategoryRecordDTO record)
		{
			return new CategoryRecord
			{

				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,

				AircraftWorkerCategory = record.AircraftWorkerCategory?.Convert(),

				ParentId = record.ParentId ?? default(int),
				ParentType = record.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(record.ParentTypeId.Value) : SmartCoreType.Unknown,
				AircraftModel = record.AircraftModel?.ConvertToAircraftModel()
			};
		}

		public static AircraftWorkerCategoryDTO Convert(this AircraftWorkerCategory category)

		{
			return new AircraftWorkerCategoryDTO
			{
				ItemId = category.ItemId,
				IsDeleted = category.IsDeleted,
				Category = category.Category
			};

		}

		public static AircraftWorkerCategory Convert(this AircraftWorkerCategoryDTO category)
		{
			return new AircraftWorkerCategory
			{
				ItemId = category.ItemId,
				IsDeleted = category.IsDeleted,
				Category = category.Category
			};

		}


		public static ItemFileLinkDTO Convert(this ItemFileLink link)

		{
			return new ItemFileLinkDTO

			{
				ItemId = link.ItemId, 
				IsDeleted = link.IsDeleted,
				ParentId = link.ParentId,
				ParentTypeId = link.ParentTypeId,
				LinkType = link.LinkType,
				FileId = link.File?.ItemId,
			};
		}

		public static ItemFileLink Convert(this ItemFileLinkDTO link)
		{
			return new ItemFileLink
			{
				ItemId = link.ItemId,
				IsDeleted = link.IsDeleted,

				ParentId = link.ParentId,
				ParentTypeId = link.ParentTypeId,

				LinkType = link.LinkType,
				File = link.File?.Convert()
			};
		}


		public static AttachedFileDTO Convert(this AttachedFile file)
		{

			return new AttachedFileDTO
			{

				ItemId = file.ItemId,
				IsDeleted = file.IsDeleted,
				FileName = file.FileName,
				FileData = file.FileData,
				FileSize = file.FileSize
			};
		}

		public static AttachedFile Convert(this AttachedFileDTO file)
		{
			return new AttachedFile
			{
				ItemId = file.ItemId,
				IsDeleted = file.IsDeleted,
				FileName = file.FileName,
				FileData = file.FileData,
				FileSize = (int?) (file.FileSize ?? default(int))
			};
		}

		public static AuditDTO Convert(this Audit audit)
		{
			return new AuditDTO
			{
				ItemId = audit.ItemId,
				IsDeleted = audit.IsDeleted,

				ParentId = audit.ParentId,
				Number = audit.Number,
				Title = audit.Title,
				Description = audit.Description,
				Status = (short?)audit.Status,
				CreateDate = audit.CreateDate,
				OpeningDate = audit.OpeningDate,
				PublishingDate = audit.PublishingDate,
				ClosingDate = audit.ClosingDate,

				Author = audit.Author,
				PublishedBy = audit.PublishedBy,
				ClosedBy = audit.ClosedBy,

				Remarks = audit.Remarks,
				PublishingRemarks = audit.PublishingRemarks,

				ClosingRemarks = audit.ClosingRemarks,
				OnceClosed = audit.OnceClosed,
				ReleaseCertificateNo = audit.ReleaseCertificateNo,

				Revision = audit.Revision,
				CheckType = audit.CheckType,
				Station = audit.Station,
				MaintenanceReportNo = audit.MaintenanceRepairOrzanization,
				Files = audit.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				AuditRecords = audit.AuditRecords?.Select(i => i.Convert()) as ICollection<AuditRecordDTO>
			};
		}


		public static Audit Convert(this AuditDTO auditdto)
		{
			var value = new Audit
			{
				ItemId = auditdto.ItemId,
				IsDeleted = auditdto.IsDeleted,
				ParentId = auditdto.ParentId ?? default(int),
				Number = auditdto.Number,
				Title = auditdto.Title,
				Description = auditdto.Description,
				Status = auditdto.Status.HasValue ? (WorkPackageStatus)auditdto.Status.Value : WorkPackageStatus.All,
				CreateDate = auditdto.CreateDate ?? DateTimeExtend.GetCASMinDateTime(),
				OpeningDate = auditdto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishingDate = auditdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = auditdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				Author = auditdto.Author,
				PublishedBy = auditdto.PublishedBy,
				ClosedBy = auditdto.ClosedBy,
				Remarks = auditdto.Remarks,
				PublishingRemarks = auditdto.PublishingRemarks,
				ClosingRemarks = auditdto.ClosingRemarks,
				OnceClosed = auditdto.OnceClosed ?? default(bool),
				ReleaseCertificateNo = auditdto.ReleaseCertificateNo,
				Revision = auditdto.Revision,
				CheckType = auditdto.CheckType,
				Station = auditdto.Station,
				MaintenanceRepairOrzanization = auditdto.MaintenanceReportNo
			};

			if (auditdto.Files != null)
				value.Files.AddRange(auditdto.Files.Select(i => i.Convert()));


			if (auditdto.AuditRecords != null)
				value.AuditRecords.AddRange(auditdto.AuditRecords.Select(i => i.Convert()));


			return value;
		}

		public static AuditRecordDTO Convert(this AuditRecord auditrec)
		{
			return new AuditRecordDTO
			{
				ItemId = auditrec.ItemId,
				IsDeleted = auditrec.IsDeleted,
				AuditId = auditrec.AuditId,
				DirectivesId = auditrec.DirectiveId,
				AuditItemTypeId = auditrec.AuditItemTypeId,
				PerfNumFromStart = auditrec.PerformanceNumFromStart,

				PerfNumFromRecord = auditrec.PerformanceNumFromRecord,
				FromRecordId = auditrec.FromRecordId,
				JobCardNumber = auditrec.JobCardNumber
			};
		}

		public static AuditRecord Convert(this AuditRecordDTO auditrecdto)
		{
			return new AuditRecord()
			{
				ItemId = auditrecdto.ItemId,
				IsDeleted = auditrecdto.IsDeleted,
				AuditId = auditrecdto.AuditId,

				DirectiveId = auditrecdto.DirectivesId ?? default(int),
				AuditItemTypeId = auditrecdto.AuditItemTypeId ?? default(int),
				PerformanceNumFromStart = auditrecdto.PerfNumFromStart ?? default(int),
				PerformanceNumFromRecord = auditrecdto.PerfNumFromRecord ?? default(int),
				FromRecordId = auditrecdto.FromRecordId ?? default(int),
				JobCardNumber = auditrecdto.JobCardNumber

			};

		}

		public static AircraftEquipmentDTO Convert(this AircraftEquipments aireq)
		{

			return new AircraftEquipmentDTO
			{
				ItemId = aireq.ItemId,
				IsDeleted = aireq.IsDeleted,
				Description = aireq.Description,
				AircraftId = aireq.AircraftId,
				AircraftOtherParameterId = aireq.AircraftOtherParameter?.ItemId,
				AircraftEquipmetType = (int)aireq.AircraftEquipmetType,
				AircraftOtherParameter = aireq.AircraftOtherParameter?.Convert()
			};
		}

		public static AircraftEquipments Convert(this AircraftEquipmentDTO aireqdto)
		{
			return new AircraftEquipments
			{
				ItemId = aireqdto.ItemId,
				IsDeleted = aireqdto.IsDeleted,

				Description = aireqdto.Description,
				AircraftId = aireqdto.AircraftId,
				AircraftOtherParameter = aireqdto.AircraftOtherParameter?.Convert(),
				AircraftEquipmetType = (AircraftEquipmetType)aireqdto.AircraftEquipmetType
			};
		}

		public static AircraftFlightDTO Convert(this AircraftFlight arcf)
		{

			return new AircraftFlightDTO
			{
				ItemId = arcf.ItemId,
				IsDeleted = arcf.IsDeleted,
				ATLBID = arcf.ATLBId,
				AircraftId = arcf.AircraftId,
				FlightNo = arcf.FlightNo,
				Remarks = arcf.Remarks,
				FlightDate = arcf.FlightDate,
				StationFrom = arcf.StationFrom,
				StationTo = arcf.StationTo,

				DelayTime = arcf.DelayTime,

				DelayReasonId = arcf.DelayReason?.ItemId,
				OutTime = arcf.OutTime,
				InTime = arcf.InTime,
				TakeOffTime = arcf.TakeOffTime,
				LDGTime = arcf.LDGTime,
				NightTime = arcf.NightTime,

				CRSID = arcf.CrsId,
				Tanks = arcf.Tanks,
				Fluids = arcf.Fluids,
				EnginesGeneralCondition = arcf.EnginesGeneralCondition,
				Highlight = arcf.Highlight?.ItemId,
				Correct = arcf.Correct,
				Reference = arcf.Reference,

				Cycles = arcf.Cycles,
				PageNo = arcf.PageNo,

				FlightType = (short?)arcf.FlightType?.ItemId,
				LevelId = arcf.Level?.ItemId,
				Distance = arcf.Distance,

				DistanceMeasure = arcf.DistanceMeasure?.ItemId,
				TakeOffWeight = arcf.TakeOffWeight,

				AlignmentBefore = arcf.AlignmentBefore,
				AlignmentAfter = arcf.AlignmentAfter,
				FlightCategory = (short?)arcf.FlightCategory,
				AtlbRecordType = (short)arcf.AtlbRecordType,
				FlightAircraftCode = (short?)arcf.FlightAircraftCode,
				CancelReasonId = arcf.CancelReason?.ItemId,
				StationFromId = arcf.StationFromId?.ItemId ?? -1,
				StationToId = arcf.StationToId?.ItemId ?? -1,
				FlightNumberId = arcf.FlightNumber?.ItemId ?? -1,
				Files = arcf.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static AircraftFlight Convert(this AircraftFlightDTO arcfdto)
		{
			var value = new AircraftFlight
			{

				ItemId = arcfdto.ItemId,
				IsDeleted = arcfdto.IsDeleted,
				ATLBId = arcfdto.ATLBID,
				AircraftId = arcfdto.AircraftId ?? default(int),

				FlightNo = arcfdto.FlightNo,
				Remarks = arcfdto.Remarks,
				FlightDate = arcfdto.FlightDate ?? DateTimeExtend.GetCASMinDateTime(),
				StationFrom = arcfdto.StationFrom,
				StationTo = arcfdto.StationTo,
				DelayTime = arcfdto.DelayTime ?? default(short),
				DelayReason = arcfdto.DelayReason?.Convert(),

				OutTime = arcfdto.OutTime ?? default(int),
				InTime = arcfdto.InTime ?? default(int),
				TakeOffTime = arcfdto.TakeOffTime ?? default(int),
				LDGTime = arcfdto.LDGTime ?? default(int),
				NightTime = arcfdto.NightTime ?? default(int),

				CrsId = arcfdto.CRSID ?? default(int),
				Tanks = arcfdto.Tanks,
				Fluids = arcfdto.Fluids,
				EnginesGeneralCondition = arcfdto.EnginesGeneralCondition,
				Highlight = arcfdto.Highlight.HasValue ? Highlight.GetHighlightById(arcfdto.Highlight.Value) : Highlight.White,
				Correct = arcfdto.Correct,

				Reference = arcfdto.Reference,

				Cycles = arcfdto.Cycles,
				PageNo = arcfdto.PageNo,
				FlightType = FlightType.Items.GetItemById(arcfdto.FlightType ?? default(short)),
				Level = arcfdto.Level?.Convert(),
				Distance = arcfdto.Distance?? default(int),
				DistanceMeasure = Measure.Items.GetItemById(arcfdto.DistanceMeasure ?? default(short)),
				TakeOffWeight = arcfdto.TakeOffWeight?? default(double),
				AlignmentBefore = arcfdto.AlignmentBefore ?? default(double),
				AlignmentAfter = arcfdto.AlignmentAfter ?? default(double),
				FlightCategory = arcfdto.FlightCategory.HasValue ? (FlightCategory)arcfdto.FlightCategory.Value : FlightCategory.Unknown,
				AtlbRecordType = (AtlbRecordType)arcfdto.AtlbRecordType,
				FlightAircraftCode = arcfdto.FlightAircraftCode.HasValue ? (FlightAircraftCode)arcfdto.FlightAircraftCode.Value : FlightAircraftCode.Unknown,
				CancelReason = arcfdto.CancelReason?.Convert(),
				StationFromId = arcfdto.StationFromDto?.Convert(),
				StationToId = arcfdto.StationToDto?.Convert(),
				FlightNumber = arcfdto.FlightNumber?.Convert(),

			};

			if (arcfdto.Files != null)
				value.Files.AddRange(arcfdto.Files.Select(i => i.Convert()));


			return value;
		}


		public static ATLBDTO Convert(this ATLB atl)

		{
			return new ATLBDTO
			{
				ItemId = atl.ItemId,
				IsDeleted = atl.IsDeleted,

				AircraftID = atl.ParentAircraftId,
				ATLBNo = atl.ATLBNo,
				StartPageNo = atl.StartPageNo,
				OpeningDate = atl.OpeningDate,
				Remarks = atl.Remarks,
				Revision = atl.Revision,

				PageFlightCount = atl.PageFlightCount,
				AtlbStatus = (int)atl.AtlbStatus,

				Files = atl.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};

		}


		public static ATLB Convert(this ATLBDTO atldto)
		{

			var value = new ATLB
			{
				ItemId = atldto.ItemId,
				IsDeleted = atldto.IsDeleted,

				ParentAircraftId = atldto.AircraftID ?? default(int),
				ATLBNo = atldto.ATLBNo,
				StartPageNo = atldto.StartPageNo ?? default(int),
				OpeningDate = atldto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),

				Remarks = atldto.Remarks,

				Revision = atldto.Revision,
				PageFlightCount = atldto.PageFlightCount ?? default(int),
				AtlbStatus = (AtlbStatus)atldto.AtlbStatus
			};

			if (atldto.Files != null)
				value.Files.AddRange(atldto.Files.Select(i => i.Convert()));

			return value;
		}

		
		public static CertificateOfReleaseToServiceDTO Convert(this CertificateOfReleaseToService corts)
		{

			return new CertificateOfReleaseToServiceDTO
			{
				ItemId = corts.ItemId,
				IsDeleted = corts.IsDeleted,
				Station = corts.Station ,
				RecordDate = corts.RecordDate,

				CheckPerformed = corts.CheckPerformed,
				Reference = corts.Reference,
				AuthorizationB1Id= corts.AuthorizationB1?.ItemId,
				AuthorizationB2Id = corts.AuthorizationB2?.ItemId
			};
		}


		public static CertificateOfReleaseToService Convert(this CertificateOfReleaseToServiceDTO cortsdto)

		{
			return new CertificateOfReleaseToService
			{
				ItemId = cortsdto.ItemId,
				IsDeleted = cortsdto.IsDeleted,
				Station = cortsdto.Station,
				RecordDate = cortsdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				CheckPerformed = cortsdto.CheckPerformed,
				Reference = cortsdto.Reference,

				AuthorizationB1 = cortsdto.AuthorizationB1?.Convert(),
				AuthorizationB2 = cortsdto.AuthorizationB2?.Convert()
			};
		}

		public static ComponentDirectiveDTO Convert(this ComponentDirective comdir)
		{
			return new ComponentDirectiveDTO

			{
				ItemId = comdir.ItemId,
				IsDeleted = comdir.IsDeleted,
				DirectiveType = comdir.DirectiveTypeId,
				Threshold = comdir.Threshold?.ToBinary(),
				ManHours = comdir.ManHours,
				Remarks = comdir.Remarks,
				Cost = comdir.Cost,
				Highlight = comdir.Highlight?.ItemId,
				KitRequired = comdir.KitRequired,
				HiddenRemarks = comdir.HiddenRemarks,
				IsClosed = comdir.IsClosed,
				MPDTaskTypeId = comdir.MPDTaskType?.ItemId,
				NDTType = (short)(comdir.NDTType?.ItemId ?? -1),
				ComponentId = comdir.ComponentId,

				ZoneArea = comdir.ZoneArea,
				AccessDirective = comdir.AccessDirective,

				AAM = comdir.AAM,
				CMM = comdir.CMM,
				Files = comdir.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PerformanceRecords = comdir.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = comdir.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = comdir.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>
			};
		}


		public static ComponentDirective Convert(this ComponentDirectiveDTO comdirdto)
		{
			var value = new ComponentDirective()
			{
				ItemId = comdirdto.ItemId,
				IsDeleted = comdirdto.IsDeleted,
				DirectiveTypeId = comdirdto.DirectiveType,

				//TODO:Разобраться почему private set
				Threshold = new ComponentDirectiveThreshold(comdirdto.Threshold),

				ManHours = comdirdto.ManHours ?? default(double),
				Remarks = comdirdto.Remarks,
				Cost = comdirdto.Cost ?? default(double),

				Highlight = comdirdto.Highlight.HasValue ? Highlight.GetHighlightById(comdirdto.Highlight.Value) : Highlight.White,
				KitRequired = comdirdto.KitRequired,
				HiddenRemarks = comdirdto.HiddenRemarks,
				IsClosed = comdirdto.IsClosed ?? default(bool),
				MPDTaskType = MaintenanceDirectiveTaskType.Items.GetItemById(comdirdto.MPDTaskTypeId ?? default(int)),
				NDTType = NDTType.Items.GetItemById(comdirdto.NDTType),
				ComponentId = comdirdto.ComponentId,
				ZoneArea = comdirdto.ZoneArea,
				AccessDirective = comdirdto.AccessDirective,
				AAM = comdirdto.AAM,
				CMM = comdirdto.CMM
			};


			if (comdirdto.Files != null)
				value.Files.AddRange(comdirdto.Files.Select(i => i.Convert()));

			if (comdirdto.PerformanceRecords != null)
			{
				foreach (var dto in comdirdto.PerformanceRecords)

				{
					var record = dto.Convert();
					record.Parent = value;

					value.PerformanceRecords.Add(record);
				}
			}

			if (comdirdto.CategoriesRecords != null)
			{
				foreach (var dto in comdirdto.CategoriesRecords)
				{

					var record = dto.Convert();
					record.Parent = value;
					value.CategoriesRecords.Add(record);
				}
			}


			if (comdirdto.Kits != null)
			{
				foreach (var dto in comdirdto.Kits)
				{
					var record = dto.Convert();
					record.ParentObject = value;

					value.Kits.Add(record);
				}
			}


			return value;
		}

		public static ComponentDTO Convert(this Entities.General.Accessory.Component comp)

		{
			return new ComponentDTO
			{
				ItemId = comp.ItemId,
				IsDeleted = comp.IsDeleted,
				StartDate = comp.StartDate,
				ATAChapterId = comp.ATAChapter?.ItemId,
				PartNumber = comp.PartNumber,
				Description = comp.Description,
				SerialNumber = comp.SerialNumber,

				BatchNumber = comp.BatchNumber,
				IdNumber = comp.IdNumber,

				MaintenanceType = comp.MaintenanceControlProcess?.ItemId ?? -1,
				Remarks = comp.Remarks,
				ModelId = comp.Model?.ItemId,
				Manufacturer = comp.Manufacturer,
				ManufactureDate = comp.ManufactureDate,
				DeliveryDate = comp.DeliveryDate,
				Lifelength = comp.Lifelength?.ConvertToByteArray(),

				LLPMark = comp.LLPMark,
				LLPCategories = comp.LLPCategories,
				LandingGear = (short)comp.LandingGear,
				AvionicsInventory = (short)comp.AvionicsInventory,
				ALTPN = comp.ALTPartNumber,
				MTOGW = comp.MTOGW,

				HushKit = comp.HushKit,
				Cost = comp.Cost,
				CostServiceable = comp.CostServiceable,
				CostOverhaul = comp.CostOverhaul,
				Measure = comp.Measure?.ItemId,

				Quantity = comp.Quantity,
				ManHours = comp.ManHours,
				Warranty = comp.Warranty?.ConvertToByteArray(),
				WarrantyNotify = comp.WarrantyNotify?.ConvertToByteArray(),
				Serviceable = comp.Serviceable,
				ShelfLife = comp.ShelfLife,
				ExpirationDate = comp.ExpirationDate,
				NotificationDate = comp.NotificationDate,

				Highlight = comp.Highlight?.ItemId,
				MPDItem = comp.MPDItem,
				HiddenRemarks = comp.HiddenRemarks,
				Supplier = comp.Suppliers?.ToString(),
				LifeLimit = comp.LifeLimit?.ConvertToByteArray(),

				LifeLimitNotify = comp.LifeLimitNotify?.ConvertToByteArray(),
				KitRequired = comp.KitRequired,

				StartLifelength = comp.StartLifelength?.ConvertToByteArray(),
				Code = comp.Code,

				Status = (short?)comp.Status?.ItemId,
				IsBaseComponent = comp.IsBaseComponent,

				LocationId = comp.Location?.ItemId ?? -1,

				Incoming = comp.Incoming,

				Discrepancy = comp.Discrepancy,
				IsPool = comp.IsPOOL,
				IsDangerous = comp.IsDangerous,

				QuantityInput = comp.QuantityIn,
				FromSupplierId = comp.FromSupplier?.ItemId ?? -1,
				FromSupplierReciveDate = comp.FromSupplierReciveDate,
				LLPData = comp.LLPData?.Select(i => i.Convert()) as ICollection<ComponentLLPCategoryDataDTO>,
				CategoriesRecords = comp.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				SupplierRelations = comp.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
				Files = comp.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				Kits = comp.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,
				ActualStateRecords = comp.ActualStateRecords?.Select(i => i.Convert()) as ICollection<ActualStateRecordDTO>,
				TransferRecords = comp.TransferRecords?.Select(i => i.Convert()) as ICollection<TransferRecordDTO>,
				ComponentDirectives = comp.ComponentDirectives?.Select(i => i.Convert()) as ICollection<ComponentDirectiveDTO>,
				ChangeLLPCategoryRecords = comp.ChangeLLPCategoryRecords?.Select(i => i.Convert()) as ICollection<ComponentLLPCategoryChangeRecordDTO>
			};
		}


		public static Entities.General.Accessory.Component Convert(this ComponentDTO compdto)
		{
			var value = new Entities.General.Accessory.Component
			{
				ItemId = compdto.ItemId,

				IsDeleted = compdto.IsDeleted,
				StartDate = compdto.StartDate ?? DateTimeExtend.GetCASMinDateTime(),

				ATAChapter = compdto.ATAChapter?.Convert(),
				PartNumber = compdto.PartNumber,
				Description = compdto.Description,
				SerialNumber = compdto.SerialNumber,
				BatchNumber = compdto.BatchNumber,

				IdNumber = compdto.IdNumber,
				MaintenanceControlProcess = MaintenanceControlProcess.Items.GetItemById(compdto.MaintenanceType),
				Remarks = compdto.Remarks,
				Model = compdto.Model?.ConvertToComponentModel(),
				Manufacturer = compdto.Manufacturer,

				ManufactureDate = compdto.ManufactureDate ?? DateTimeExtend.GetCASMinDateTime(),
				DeliveryDate = compdto.DeliveryDate ?? DateTimeExtend.GetCASMinDateTime(),
				Lifelength = Lifelength.ConvertFromByteArray(compdto.Lifelength),
				LLPMark = compdto.LLPMark,
				LLPCategories = compdto.LLPCategories,
				LandingGear = (LandingGearMarkType)compdto.LandingGear,
				AvionicsInventory = (AvionicsInventoryMarkType)compdto.AvionicsInventory,
				ALTPartNumber = compdto.ALTPN,
				MTOGW = compdto.MTOGW,
				HushKit = compdto.HushKit,
				Cost = compdto.Cost ?? default(double),
				CostServiceable = compdto.CostServiceable ?? default(double),
				CostOverhaul = compdto.CostOverhaul ?? default(double),
				Measure = Measure.Items.GetItemById(compdto.Measure ?? default(int)),
				Quantity = compdto.Quantity,
				ManHours = compdto.ManHours ?? default(double),
				Warranty = Lifelength.ConvertFromByteArray(compdto.Warranty),
				WarrantyNotify = Lifelength.ConvertFromByteArray(compdto.WarrantyNotify),
				Serviceable = compdto.Serviceable ?? default(bool),
				ShelfLife = compdto.ShelfLife,
				ExpirationDate = compdto.ExpirationDate,
				NotificationDate = compdto.NotificationDate,
				Highlight = Highlight.GetHighlightById(compdto.Highlight),

				MPDItem = compdto.MPDItem,
				HiddenRemarks = compdto.HiddenRemarks,

				LifeLimit = Lifelength.ConvertFromByteArray(compdto.LifeLimit),
				LifeLimitNotify = Lifelength.ConvertFromByteArray(compdto.LifeLimitNotify),
				KitRequired = compdto.KitRequired,

				StartLifelength = Lifelength.ConvertFromByteArray(compdto.StartLifelength),
				Code = compdto.Code,

				IsBaseComponent = compdto.IsBaseComponent,
				Location = compdto.Location?.Convert(),

				Incoming = compdto.Incoming,
				Discrepancy = compdto.Discrepancy,
				IsPOOL = compdto.IsPool,
				IsDangerous = compdto.IsDangerous,
				QuantityIn = compdto.QuantityInput ?? default(double),
				FromSupplier = compdto.FromSupplier?.Convert(),
				FromSupplierReciveDate = compdto.FromSupplierReciveDate ?? DateTimeExtend.GetCASMinDateTime()
			};

			if (compdto.LLPData != null)
				value.LLPData.AddRange(compdto.LLPData.Select(i => i.Convert()));

			if (compdto.CategoriesRecords != null)

			{
				foreach (var dto in compdto.CategoriesRecords)
				{
					var record = dto.Convert();
					record.Parent = value;

					value.CategoriesRecords.Add(record);
				}
			}


			if (compdto.SupplierRelations != null)
				value.SupplierRelations.AddRange(compdto.SupplierRelations.Select(i => i.Convert()));

			if (compdto.Files != null)
				value.Files.AddRange(compdto.Files.Select(i => i.Convert()));

			if (compdto.Kits != null)
			{

				foreach (var dto in compdto.Kits)

				{

					var record = dto.Convert();

					record.ParentObject = value;
					value.Kits.Add(record);
				}
			}


			if (compdto.ActualStateRecords != null)
			{

				foreach (var dto in compdto.ActualStateRecords)
				{
					var record = dto.Convert();

					record.ParentComponent = value;
					value.ActualStateRecords.Add(record);

				}
			}


			if (compdto.TransferRecords != null)
			{

				foreach (var dto in compdto.TransferRecords)
				{
					var record = dto.Convert();
					record.ParentComponent = value;
					value.TransferRecords.Add(record);
				}
			}


			if (compdto.ComponentDirectives != null)

			{
				foreach (var dto in compdto.ComponentDirectives)
				{
					var directive = dto.Convert();
					directive.ParentComponent = value;
					value.ComponentDirectives.Add(directive);
				}
			}

			if (compdto.ChangeLLPCategoryRecords != null)
			{
				foreach (var dto in compdto.ChangeLLPCategoryRecords)
				{
					var directive = dto.Convert();
					directive.ParentComponent = value;
					value.ChangeLLPCategoryRecords.Add(directive);

				}
			}

			return value;
		}


		public static ComponentDTO Convert(this BaseComponent comp)
		{
			return new ComponentDTO
			{
				ItemId = comp.ItemId,
				IsDeleted = comp.IsDeleted,
				StartDate = comp.StartDate,
				BaseComponentTypeId = comp.BaseComponentTypeId,

				ComponentCount = comp.ComponentCount,
				AverageUtilization = comp.AverageUtilization?.ConvertToByteArray(),
				Acceleration = comp.AccelerationGround,
				AccelerationAir = comp.AccelerationAir,
				Thrust = comp.Thrust,
				ATAChapterId = comp.ATAChapter?.ItemId,
				PartNumber = comp.PartNumber,
				Description = comp.Description,
				SerialNumber = comp.SerialNumber,
				BatchNumber = comp.BatchNumber,

				IdNumber = comp.IdNumber,
				MaintenanceType = comp.MaintenanceControlProcess?.ItemId ?? -1,
				Remarks = comp.Remarks,
				ModelId = comp.Model?.ItemId,
				Manufacturer = comp.Manufacturer,
				ManufactureDate = comp.ManufactureDate,
				DeliveryDate = comp.DeliveryDate,
				Lifelength = comp.Lifelength?.ConvertToByteArray(),
				LLPMark = comp.LLPMark,
				LLPCategories = comp.LLPCategories,

				LandingGear = (short)comp.LandingGear,
				AvionicsInventory = (short)comp.AvionicsInventory,
				ALTPN = comp.ALTPartNumber,
				MTOGW = comp.MTOGW,
				HushKit = comp.HushKit,
				Cost = comp.Cost,
				CostServiceable = comp.CostServiceable,

				CostOverhaul = comp.CostOverhaul,

				Measure = comp.Measure?.ItemId,
				Quantity = comp.Quantity,
				ManHours = comp.ManHours,
				Warranty = comp.Warranty?.ConvertToByteArray(),
				WarrantyNotify = comp.WarrantyNotify?.ConvertToByteArray(),
				Serviceable = comp.Serviceable,
				ShelfLife = comp.ShelfLife,
				ExpirationDate = comp.ExpirationDate,
				NotificationDate = comp.NotificationDate,
				Highlight = comp.Highlight?.ItemId,
				MPDItem = comp.MPDItem,
				HiddenRemarks = comp.HiddenRemarks,
				Supplier = comp.Suppliers?.ToString(),
				LifeLimit = comp.LifeLimit?.ConvertToByteArray(),
				LifeLimitNotify = comp.LifeLimitNotify?.ConvertToByteArray(),
				KitRequired = comp.KitRequired,

				StartLifelength = comp.StartLifelength?.ConvertToByteArray(),
				Code = comp.Code,
				Status = (short?)comp.Status?.ItemId,
				IsBaseComponent = comp.IsBaseComponent,
				LocationId = comp.Location?.ItemId ?? -1,

				Incoming = comp.Incoming,
				Discrepancy = comp.Discrepancy,
				IsPool = comp.IsPOOL,

				IsDangerous = comp.IsDangerous,
				QuantityInput = comp.QuantityIn,
				FromSupplierId = comp.FromSupplier?.ItemId ?? -1,

				FromSupplierReciveDate = comp.FromSupplierReciveDate,
				LLPData = comp.LLPData?.Select(i => i.Convert()) as ICollection<ComponentLLPCategoryDataDTO>,
				CategoriesRecords = comp.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				SupplierRelations = comp.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
				Files = comp.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				Kits = comp.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,
				ActualStateRecords = comp.ActualStateRecords?.Select(i => i.Convert()) as ICollection<ActualStateRecordDTO>,

				TransferRecords = comp.TransferRecords?.Select(i => i.Convert()) as ICollection<TransferRecordDTO>,
				ComponentDirectives = comp.ComponentDirectives?.Select(i => i.Convert()) as ICollection<ComponentDirectiveDTO>,
				ChangeLLPCategoryRecords = comp.ChangeLLPCategoryRecords?.Select(i => i.Convert()) as ICollection<ComponentLLPCategoryChangeRecordDTO>
			};
		}

		public static BaseComponent ConvertToBaseComponent(this ComponentDTO compdto)
		{
			var value = new BaseComponent
			{
				ItemId = compdto.ItemId,
				IsDeleted = compdto.IsDeleted,
				StartDate = compdto.StartDate ?? DateTimeExtend.GetCASMinDateTime(),
				BaseComponentTypeId = compdto.BaseComponentTypeId,
				ComponentCount = compdto.ComponentCount,
				AverageUtilization = AverageUtilization.ConvertFromByteArray(compdto.AverageUtilization),
				AccelerationGround = compdto.Acceleration ?? default(int),
				AccelerationAir = compdto.AccelerationAir ?? default(int),

				Thrust = compdto.Thrust,
				ATAChapter = compdto.ATAChapter?.Convert(),

				PartNumber = compdto.PartNumber,
				Description = compdto.Description,
				SerialNumber = compdto.SerialNumber,
				BatchNumber = compdto.BatchNumber,
				IdNumber = compdto.IdNumber,

				MaintenanceControlProcess = MaintenanceControlProcess.Items.GetItemById(compdto.MaintenanceType),
				Remarks = compdto.Remarks,
				Model = compdto.Model?.ConvertToComponentModel(),
				Manufacturer = compdto.Manufacturer,
				ManufactureDate = compdto.ManufactureDate ?? DateTimeExtend.GetCASMinDateTime(),
				DeliveryDate = compdto.DeliveryDate ?? DateTimeExtend.GetCASMinDateTime(),
				Lifelength = Lifelength.ConvertFromByteArray(compdto.Lifelength),
				LLPMark = compdto.LLPMark,
				LLPCategories = compdto.LLPCategories,
				LandingGear = (LandingGearMarkType)compdto.LandingGear,
				AvionicsInventory = (AvionicsInventoryMarkType)compdto.AvionicsInventory,
				ALTPartNumber = compdto.ALTPN,
				MTOGW = compdto.MTOGW,

				HushKit = compdto.HushKit,
				Cost = compdto.Cost ?? default(double),
				CostServiceable = compdto.CostServiceable ?? default(double),
				CostOverhaul = compdto.CostOverhaul ?? default(double),
				Measure = Measure.Items.GetItemById(compdto.Measure ?? default(int)),
				Quantity = compdto.Quantity,
				ManHours = compdto.ManHours ?? default(double),
				Warranty = Lifelength.ConvertFromByteArray(compdto.Warranty),
				WarrantyNotify = Lifelength.ConvertFromByteArray(compdto.WarrantyNotify),
				Serviceable = compdto.Serviceable ?? default(bool),
				ShelfLife = compdto.ShelfLife,
				ExpirationDate = compdto.ExpirationDate,
				NotificationDate = compdto.NotificationDate,
				Highlight = Highlight.GetHighlightById(compdto.Highlight),

				MPDItem = compdto.MPDItem,
				HiddenRemarks = compdto.HiddenRemarks,

				LifeLimit = Lifelength.ConvertFromByteArray(compdto.LifeLimit),
				LifeLimitNotify = Lifelength.ConvertFromByteArray(compdto.LifeLimitNotify),
				KitRequired = compdto.KitRequired,
				StartLifelength = Lifelength.ConvertFromByteArray(compdto.StartLifelength),
				Code = compdto.Code,

				IsBaseComponent = compdto.IsBaseComponent,
				Location = compdto.Location?.Convert(),

				Incoming = compdto.Incoming,
				Discrepancy = compdto.Discrepancy,
				IsPOOL = compdto.IsPool,
				IsDangerous = compdto.IsDangerous,

				QuantityIn = compdto.QuantityInput ?? default(double),
				FromSupplier = compdto.FromSupplier?.Convert(),
				FromSupplierReciveDate = compdto.FromSupplierReciveDate ?? DateTimeExtend.GetCASMinDateTime()

			};

			if (compdto.LLPData != null)
				value.LLPData.AddRange(compdto.LLPData.Select(i => i.Convert()));

			if (compdto.CategoriesRecords != null)
			{
				foreach (var dto in compdto.CategoriesRecords)
				{
					var record = dto.Convert();

					record.Parent = value;
					value.CategoriesRecords.Add(record);
				}
			}


			if (compdto.SupplierRelations != null)

				value.SupplierRelations.AddRange(compdto.SupplierRelations.Select(i => i.Convert()));

			if (compdto.Files != null)
				value.Files.AddRange(compdto.Files.Select(i => i.Convert()));


			if (compdto.Kits != null)
			{
				foreach (var dto in compdto.Kits)

				{
					var record = dto.Convert();

					record.ParentObject = value;
					value.Kits.Add(record);

				}

			}

			if (compdto.ActualStateRecords != null)
			{
				foreach (var dto in compdto.ActualStateRecords)
				{

					var record = dto.Convert();
					record.ParentComponent = value;
					value.ActualStateRecords.Add(record);

				}
			}

			if (compdto.TransferRecords != null)
			{
				foreach (var dto in compdto.TransferRecords)
				{
					var record = dto.Convert();
					record.ParentComponent = value;
					value.TransferRecords.Add(record);
				}
			}

			if (compdto.ComponentDirectives != null)
			{
				foreach (var dto in compdto.ComponentDirectives)
				{
					var directive = dto.Convert();
					directive.ParentComponent = value;
					value.ComponentDirectives.Add(directive);
				}
			}

			if (compdto.ChangeLLPCategoryRecords != null)

			{

				foreach (var dto in compdto.ChangeLLPCategoryRecords)
				{
					var directive = dto.Convert();
					directive.ParentComponent = value;
					value.ChangeLLPCategoryRecords.Add(directive);

				}
			}

			return value;
		}

		public static ComponentLLPCategoryChangeRecordDTO Convert(this ComponentLLPCategoryChangeRecord cllpcr)
		{
			return new ComponentLLPCategoryChangeRecordDTO
			{
				ItemId = cllpcr.ItemId,
				IsDeleted = cllpcr.IsDeleted,
				ParentId = cllpcr.ParentId,
				RecordDate = cllpcr.RecordDate,
				ToCategoryId = cllpcr.ToCategory?.ItemId,
				OnLifeLength = cllpcr.OnLifelength?.ConvertToByteArray(),
				Remarks = cllpcr.Remarks,
				Files = cllpcr.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static ComponentLLPCategoryChangeRecord Convert(this ComponentLLPCategoryChangeRecordDTO cllpcrdto)
		{
			var value = new ComponentLLPCategoryChangeRecord()
			{

				ItemId = cllpcrdto.ItemId,

				IsDeleted = cllpcrdto.IsDeleted,
				ParentId = cllpcrdto.ParentId,

				RecordDate = cllpcrdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),

				ToCategory = cllpcrdto.ToCategory?.Convert(),
				OnLifelength = Lifelength.ConvertFromByteArray(cllpcrdto.OnLifeLength),
				Remarks = cllpcrdto.Remarks
			};

			if (cllpcrdto.Files != null)

				value.Files.AddRange(cllpcrdto.Files.Select(i => i.Convert()));


			return value;
		}


		public static ComponentLLPCategoryDataDTO Convert(this ComponentLLPCategoryData cllpcd)

		{
			return new ComponentLLPCategoryDataDTO
			{

				ItemId = cllpcd.ItemId,
				IsDeleted = cllpcd.IsDeleted,
				LLPCategoryId = cllpcd.ParentCategory?.ItemId ?? -1,
				LLPLifeLength = cllpcd.LLPLifelength?.ConvertToByteArray(),
				Notify = cllpcd.Notify?.ConvertToByteArray(),
				ComponentId = cllpcd.ComponentId,
				LLPLifeLimit =  cllpcd.LLPLifeLimit?.ConvertToByteArray(),
				LLPLifeLengthCurrent = cllpcd.LLPLifelengthCurrent?.ConvertToByteArray(),
				LLPLifeLengthForDate = cllpcd.LLPLifeLengthForDate?.ConvertToByteArray(),
				Date = cllpcd.FromDate,
			};
		}



		public static ComponentLLPCategoryData Convert(this ComponentLLPCategoryDataDTO cllpcddto)
		{
			return new ComponentLLPCategoryData()
			{
				ItemId = cllpcddto.ItemId,

				IsDeleted = cllpcddto.IsDeleted,
				ParentCategory = cllpcddto.ParentCategory?.Convert(),
				LLPLifelength = Lifelength.ConvertFromByteArray(cllpcddto.LLPLifeLength),
				Notify = Lifelength.ConvertFromByteArray(cllpcddto.LLPLifeLength),
				ComponentId = cllpcddto.ComponentId,
				LLPLifeLimit = Lifelength.ConvertFromByteArray(cllpcddto.LLPLifeLimit),
				LLPLifelengthCurrent = Lifelength.ConvertFromByteArray(cllpcddto.LLPLifeLengthCurrent),
				LLPLifeLengthForDate = Lifelength.ConvertFromByteArray(cllpcddto.LLPLifeLengthForDate),
				FromDate = cllpcddto.Date ?? DateTimeExtend.GetCASMinDateTime()
			};
		}


		public static ComponentOilConditionDTO Convert(this ComponentOilCondition coc)

		{

			return new ComponentOilConditionDTO
			{
				ItemId = coc.ItemId,

				IsDeleted = coc.IsDeleted,
				FlightId = coc.FlightId,
				OilAdded = coc.OilAdded,
				OnBoard = coc.OnBoard,
				Remain = coc.Remain,
				Spent = coc.Spent,
				RemainAfter = coc.RemainAfter,
				ComponentId = coc.ComponentId
			};
		}

		public static ComponentOilCondition Convert(this ComponentOilConditionDTO cocdto)
		{
			return new ComponentOilCondition
			{
				ItemId = cocdto.ItemId,
				IsDeleted = cocdto.IsDeleted,
				FlightId = cocdto.FlightId ?? default(int),
				OilAdded = cocdto.OilAdded ?? default(double),
				OnBoard = cocdto.OnBoard ?? default(double),
				Remain = cocdto.Remain ?? default(double),

				Spent = cocdto.Spent ?? default(double),
				RemainAfter = cocdto.RemainAfter ?? default(double),
				ComponentId = cocdto.ComponentId ?? default(int)

			};

		}

		public static ComponentWorkInRegimeParamDTO Convert(this ComponentWorkInRegimeParams cwirp)
		{

			return new ComponentWorkInRegimeParamDTO
			{
				ItemId = cwirp.ItemId,
				IsDeleted = cwirp.IsDeleted,
				FlightRegime = cwirp.FlightRegime?.ItemId,
				TimeInRegimeMax = (int?)cwirp.TimeInRegimeMax.Ticks,
				EPRMin = cwirp.EPRMin,
				EPRMax = cwirp.EPRMax,
				N1Min = cwirp.N1Min,
				N1Max = cwirp.N1Max,
				EGTMin = cwirp.EGTMin,
				EGTMax = cwirp.EGTMax,
				EGTMeasure = cwirp.EGTMeasure?.ItemId,
				N2Min = cwirp.N2Min,
				N2Max = cwirp.N2Max,
				OilTemperatureMin = cwirp.OilTemperatureMin,
				OilTemperatureMax = cwirp.OilTemperatureMax,
				OilTemperatureMeasure = cwirp.OilTemperatureMeasure?.ItemId,
				FuelPressMin = cwirp.FuelPressMin,
				FuelPressMax = cwirp.FuelPressMax,
				FuelPresseMeasure = cwirp.FuelPressMeasure?.ItemId,
				OilPressTorqueMin = cwirp.OilPressTorqueMin,
				OilPressTorqueMax = cwirp.OilPressTorqueMax,
				OilPressTorqueMeasure = cwirp.OilPressTorqueMeasure?.ItemId,
				FuelFlowMin = cwirp.FuelFlowMin,
				FuelFlowMax = cwirp.FuelFlowMax,
				FuelFlowMeasure = cwirp.FuelFlowMeasure?.ItemId,
				FuelBurnMin = cwirp.FuelBurnMin,
				FuelBurnMax = cwirp.FuelBurnMax,

				FuelBurnMeasure = cwirp.FuelBurnMeasure?.ItemId,
				VibroOverloadMin = cwirp.VibroOverloadMin,
				VibroOverloadMax = cwirp.VibroOverloadMax,
				VibroOverload2Min = cwirp.VibroOverload2Min,
				VibroOverload2Max = cwirp.VibroOverload2Max,

				GroundAir = (short?)cwirp.GroundAir,

				PersentTime = cwirp.PersentTime,
				ResorceProvider = cwirp.ResorceProvider?.ItemId,
				ResorceProviderId = cwirp.ResorceProviderId,
				TLAMin = cwirp.TLAMin,
				TLAMax = cwirp.TLAMax,

				TLAMinEnabled = cwirp.TLAMinEnabled,

				TLAMaxEnabled = cwirp.TLAMaxEnabled,

				EPRMinEnabled = cwirp.EPRMinEnabled,
				EPRMaxEnabled = cwirp.EPRMaxEnabled,
				N1MinEnabled = cwirp.N1MinEnabled,

				N1MaxEnabled = cwirp.N1MaxEnabled,
				EGTMinEnabled = cwirp.EGTMinEnabled,
				EGTMaxEnabled = cwirp.EGTMaxEnabled,
				N2MinEnabled = cwirp.N2MinEnabled,
				N2MaxEnabled = cwirp.N2MaxEnabled,

				OilTemperatureMinEnabled = cwirp.OilTemperatureMinEnabled,
				OilTemperatureMaxEnabled = cwirp.OilTemperatureMaxEnabled,
				OilPressureMinEnabled = cwirp.OilPressureMinEnabled,
				OilPressureMaxEnabled = cwirp.OilPressureMaxEnabled,
				OilFlowMin = cwirp.OilFlowMin,

				OilFlowMax = cwirp.OilFlowMax,
				OilFlowMinEnabled = cwirp.OilFlowMinEnabled,
				OilFlowMaxEnabled = cwirp.OilFlowMaxEnabled,
				OilFlowMeasure = cwirp.OilFlowMeasure?.ItemId,

				FuelPressMinEnabled = cwirp.FuelPressMinEnabled,
				FuelPressMaxEnabled = cwirp.FuelPressMaxEnabled,
				OilPressTorqueMinEnabled = cwirp.OilPressTorqueMinEnabled,
				OilPressTorqueMaxEnabled = cwirp.OilPressTorqueMaxEnabled,

				FuelFlowMinEnabled = cwirp.FuelFlowMinEnabled,
				FuelFlowMaxEnabled = cwirp.FuelFlowMaxEnabled,
				FuelBurnMinEnabled = cwirp.FuelBurnMinEnabled,
				FuelBurnMaxEnabled = cwirp.FuelBurnMaxEnabled,
				VibroOverloadMinEnabled = cwirp.VibroOverloadMinEnabled,
				VibroOverloadMaxEnabled = cwirp.VibroOverloadMaxEnabled,
				VibroOverload2MinEnabled = cwirp.VibroOverload2MinEnabled,

				VibroOverload2MaxEnabled = cwirp.VibroOverload2MaxEnabled,
				Remarks = cwirp.Remarks,

				TLARecomended = cwirp.TLARecomended,

				TLARecomendedEnabled = cwirp.TLARecomendedEnabled,

				EPRRecomended = cwirp.EPRRecomended,
				EPRRecomendedEnabled = cwirp.EPRRecomendedEnabled,
				N1Recomended = cwirp.N1Recomended,
				N1RecomendedEnabled = cwirp.N1RecomendedEnabled,
				EGTRecomended = cwirp.EGTRecomended,
				EGTRecomendedEnabled = cwirp.EGTRecomendedEnabled,
				N2Recomended = cwirp.N2Recomended,
				N2RecomendedEnabled = cwirp.N2RecomendedEnabled,
				OilTemperatureRecomended = cwirp.OilTemperatureRecomended,
				OilTemperatureRecomendedEnabled = cwirp.OilTemperatureRecomendedEnabled,
				OilPressureRecomended = cwirp.OilPressureRecomended,
				OilPressureRecomendedEnabled = cwirp.OilPressureRecomendedEnabled,
				OilFlowRecomended = cwirp.OilFlowRecomended,
				OilFlowRecomendedEnabled = cwirp.OilFlowRecomendedEnabled,
				FuelPressRecomended = cwirp.FuelPressRecomended,
				FuelPressRecomendedEnabled = cwirp.FuelPressRecomendedEnabled,
				OilPressTorqueRecomended = cwirp.OilPressTorqueRecomended,
				OilPressTorqueRecomendedEnabled = cwirp.OilPressTorqueRecomendedEnabled,
				FuelFlowRecomended = cwirp.FuelFlowRecomended,
				FuelFlowRecomendedEnabled = cwirp.FuelFlowRecomendedEnabled,
				FuelBurnRecomended = cwirp.FuelBurnRecomended,
				FuelBurnRecomendedEnabled = cwirp.FuelBurnRecomendedEnabled,
				VibroOverloadRecomended = cwirp.VibroOverloadRecomended,
				VibroOverloadRecomendedEnabled = cwirp.VibroOverloadRecomendedEnabled,
				VibroOverload2Recomended = cwirp.VibroOverload2Recomended,
				VibroOverload2RecomendedEnabled = cwirp.VibroOverload2RecomendedEnabled,
				ComponentId = cwirp.ComponentId
			};

		}

		public static ComponentWorkInRegimeParams Convert(this ComponentWorkInRegimeParamDTO cwirpdto)
		{
			return new ComponentWorkInRegimeParams

			{
				ItemId = cwirpdto.ItemId,
				IsDeleted = cwirpdto.IsDeleted,
				FlightRegime = cwirpdto.FlightRegime.HasValue ? FlightRegime.Items.GetItemById(cwirpdto.FlightRegime.Value) : FlightRegime.UNK,
				TimeInRegimeMax = new TimeSpan(cwirpdto.TimeInRegimeMax ?? default(int)),

				EPRMin = cwirpdto.EPRMin ?? default(double),
				EPRMax = cwirpdto.EPRMax ?? default(double),
				N1Min = cwirpdto.N1Min ?? default(double),

				N1Max = cwirpdto.N1Max ?? default(double),

				EGTMin = cwirpdto.EGTMin ?? default(double),
				EGTMax = cwirpdto.EGTMax ?? default(double),
				EGTMeasure = cwirpdto.EGTMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.EGTMeasure.Value) : Measure.Unknown,

				N2Min = cwirpdto.N2Min ?? default(double),
				N2Max = cwirpdto.N2Max ?? default(double),
				OilTemperatureMin = cwirpdto.OilTemperatureMin ?? default(double),

				OilTemperatureMax = cwirpdto.OilTemperatureMax ?? default(double),

				OilTemperatureMeasure = cwirpdto.OilTemperatureMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.OilTemperatureMeasure.Value) : Measure.Unknown,
				FuelPressMin = cwirpdto.FuelPressMin ?? default(double),
				FuelPressMax = cwirpdto.FuelPressMax ?? default(double),

				FuelPressMeasure = cwirpdto.FuelPresseMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.FuelPresseMeasure.Value) : Measure.Unknown,
				OilPressTorqueMin = cwirpdto.OilPressTorqueMin ?? default(double),

				OilPressTorqueMax = cwirpdto.OilPressTorqueMax ?? default(double),
				OilPressTorqueMeasure = cwirpdto.OilPressTorqueMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.OilPressTorqueMeasure.Value) : Measure.Unknown,
				FuelFlowMin = cwirpdto.FuelFlowMin ?? default(double),
				FuelFlowMax = cwirpdto.FuelFlowMax ?? default(double),
				FuelFlowMeasure = cwirpdto.FuelFlowMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.FuelFlowMeasure.Value) : Measure.Unknown,
				FuelBurnMin = cwirpdto.FuelBurnMin ?? default(double),
				FuelBurnMax = cwirpdto.FuelBurnMax ?? default(double),
				FuelBurnMeasure = cwirpdto.FuelBurnMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.FuelBurnMeasure.Value) : Measure.Unknown,
				VibroOverloadMin = cwirpdto.VibroOverloadMin ?? default(double),
				VibroOverloadMax = cwirpdto.VibroOverloadMax ?? default(double),
				VibroOverload2Min = cwirpdto.VibroOverload2Min ?? default(double),
				VibroOverload2Max = cwirpdto.VibroOverload2Max ?? default(double),
				GroundAir = cwirpdto.GroundAir.HasValue ? (GroundAir)cwirpdto.GroundAir.Value : GroundAir.Air,
				PersentTime = cwirpdto.PersentTime ?? default(double),
				ResorceProvider = cwirpdto.ResorceProvider.HasValue ? SmartCoreType.Items.GetItemById(cwirpdto.ResorceProvider.Value) : SmartCoreType.Unknown,
				ResorceProviderId = cwirpdto.ResorceProviderId ?? default(int),

				TLAMin = cwirpdto.TLAMin ?? default(double),
				TLAMax = cwirpdto.TLAMax ?? default(double),
				TLAMinEnabled = cwirpdto.TLAMinEnabled ?? default(bool),
				TLAMaxEnabled = cwirpdto.TLAMaxEnabled ?? default(bool),
				EPRMinEnabled = cwirpdto.EPRMinEnabled ?? default(bool),
				EPRMaxEnabled = cwirpdto.EPRMaxEnabled ?? default(bool),
				N1MinEnabled = cwirpdto.N1MinEnabled ?? default(bool),
				N1MaxEnabled = cwirpdto.N1MaxEnabled ?? default(bool),
				EGTMinEnabled = cwirpdto.EGTMinEnabled ?? default(bool),
				EGTMaxEnabled = cwirpdto.EGTMaxEnabled ?? default(bool),
				N2MinEnabled = cwirpdto.N2MinEnabled ?? default(bool),
				N2MaxEnabled = cwirpdto.N2MaxEnabled ?? default(bool),
				OilTemperatureMinEnabled = cwirpdto.OilTemperatureMinEnabled ?? default(bool),
				OilTemperatureMaxEnabled = cwirpdto.OilTemperatureMaxEnabled ?? default(bool),
				OilPressureMinEnabled = cwirpdto.OilPressureMinEnabled ?? default(bool),
				OilPressureMaxEnabled = cwirpdto.OilPressureMaxEnabled ?? default(bool),
				OilFlowMin = cwirpdto.OilFlowMin ?? default(double),

				OilFlowMax = cwirpdto.OilFlowMax ?? default(double),
				OilFlowMinEnabled = cwirpdto.OilFlowMinEnabled ?? default(bool),
				OilFlowMaxEnabled = cwirpdto.OilFlowMaxEnabled ?? default(bool),
				OilFlowMeasure = cwirpdto.OilFlowMeasure.HasValue ? Measure.Items.GetItemById(cwirpdto.OilFlowMeasure.Value) : Measure.Unknown,
				FuelPressMinEnabled = cwirpdto.FuelPressMinEnabled ?? default(bool),
				FuelPressMaxEnabled = cwirpdto.FuelPressMaxEnabled ?? default(bool),
				OilPressTorqueMinEnabled = cwirpdto.OilPressTorqueMinEnabled ?? default(bool),
				OilPressTorqueMaxEnabled = cwirpdto.OilPressTorqueMaxEnabled ?? default(bool),
				FuelFlowMinEnabled = cwirpdto.FuelFlowMinEnabled ?? default(bool),
				FuelFlowMaxEnabled = cwirpdto.FuelFlowMaxEnabled ?? default(bool),
				FuelBurnMinEnabled = cwirpdto.FuelBurnMinEnabled ?? default(bool),
				FuelBurnMaxEnabled = cwirpdto.FuelBurnMaxEnabled ?? default(bool),
				VibroOverloadMinEnabled = cwirpdto.VibroOverloadMinEnabled ?? default(bool),
				VibroOverloadMaxEnabled = cwirpdto.VibroOverloadMaxEnabled ?? default(bool),
				VibroOverload2MinEnabled = cwirpdto.VibroOverload2MinEnabled ?? default(bool),
				VibroOverload2MaxEnabled = cwirpdto.VibroOverload2MaxEnabled ?? default(bool),
				Remarks = cwirpdto.Remarks,
				TLARecomended = cwirpdto.TLARecomended ?? default(double),

				TLARecomendedEnabled = cwirpdto.TLARecomendedEnabled ?? default(bool),
				EPRRecomended = cwirpdto.EPRRecomended ?? default(double),
				EPRRecomendedEnabled = cwirpdto.EPRRecomendedEnabled ?? default(bool),
				N1Recomended = cwirpdto.N1Recomended ?? default(double),
				N1RecomendedEnabled = cwirpdto.N1RecomendedEnabled ?? default(bool),
				EGTRecomended = cwirpdto.EGTRecomended ?? default(double),
				EGTRecomendedEnabled = cwirpdto.EGTRecomendedEnabled ?? default(bool),
				N2Recomended = cwirpdto.N2Recomended ?? default(double),
				N2RecomendedEnabled = cwirpdto.N2RecomendedEnabled ?? default(bool),
				OilTemperatureRecomended = cwirpdto.OilTemperatureRecomended ?? default(double),
				OilTemperatureRecomendedEnabled = cwirpdto.OilTemperatureRecomendedEnabled ?? default(bool),
				OilPressureRecomended = cwirpdto.OilPressureRecomended ?? default(double),
				OilPressureRecomendedEnabled = cwirpdto.OilPressureRecomendedEnabled ?? default(bool),
				OilFlowRecomended = cwirpdto.OilFlowRecomended ?? default(double),
				OilFlowRecomendedEnabled = cwirpdto.OilFlowRecomendedEnabled ?? default(bool),
				FuelPressRecomended = cwirpdto.FuelPressRecomended ?? default(double),
				FuelPressRecomendedEnabled = cwirpdto.FuelPressRecomendedEnabled ?? default(bool),
				OilPressTorqueRecomended = cwirpdto.OilPressTorqueRecomended ?? default(double),
				OilPressTorqueRecomendedEnabled = cwirpdto.OilPressTorqueRecomendedEnabled ?? default(bool),
				FuelFlowRecomended = cwirpdto.FuelFlowRecomended ?? default(double),
				FuelFlowRecomendedEnabled = cwirpdto.FuelFlowRecomendedEnabled ?? default(bool),
				FuelBurnRecomended = cwirpdto.FuelBurnRecomended ?? default(double),
				FuelBurnRecomendedEnabled = cwirpdto.FuelBurnRecomendedEnabled ?? default(bool),
				VibroOverloadRecomended = cwirpdto.VibroOverloadRecomended ?? default(double),
				VibroOverloadRecomendedEnabled = cwirpdto.VibroOverloadRecomendedEnabled ?? default(bool),
				VibroOverload2Recomended = cwirpdto.VibroOverload2Recomended ?? default(double),
				VibroOverload2RecomendedEnabled = cwirpdto.VibroOverload2RecomendedEnabled ?? default(bool),
				ComponentId = cwirpdto.ComponentId ?? default(int)
			};
		}


		public static DamageDocumentDTO Convert(this DamageDocument dmgdoc)
		{
			return new DamageDocumentDTO

			{
				ItemId = dmgdoc.ItemId,
				IsDeleted = dmgdoc.IsDeleted,
				DirectiveId = dmgdoc.ParentDirectiveId,

				DamageChartId = dmgdoc.DamageChartId,
				DamageLocation = dmgdoc.Location,
				DocumentType = dmgdoc.DocumentTypeId,
				DamageChart2DImageName = dmgdoc.DamageChart2DImageName,
				Files = dmgdoc.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				DamageSectors = dmgdoc.DamageSectors?.Select(i => i.Convert()) as ICollection<DamageSectorDTO>
			};
		}

		public static DamageDocument Convert(this DamageDocumentDTO dmgdocdto)
		{
			var value = new DamageDocument()
			{
				ItemId = dmgdocdto.ItemId,
				IsDeleted = dmgdocdto.IsDeleted,
				ParentDirectiveId = dmgdocdto.DirectiveId ?? default(int),
				DamageChartId = dmgdocdto.DamageChartId ?? default(int),
				Location = dmgdocdto.DamageLocation,
				DocumentTypeId = dmgdocdto.DocumentType ?? default(short),
				DamageChart2DImageName = dmgdocdto.DamageChart2DImageName
			};


			if (dmgdocdto.Files != null)
				value.Files.AddRange(dmgdocdto.Files.Select(i => i.Convert()));

			if (dmgdocdto.DamageSectors != null)
				value.DamageSectors.AddRange(dmgdocdto.DamageSectors.Select(i => i.Convert()));

			return value;
		}


		public static DamageSectorDTO Convert(this DamageSector dmgsec)
		{
			return new DamageSectorDTO

			{

				ItemId = dmgsec.ItemId,
				IsDeleted = dmgsec.IsDeleted,

				DamageChartColumn = dmgsec.DamageChartColumn,

				DamageChartRow = dmgsec.DamageChartRow,

				Remarks = dmgsec.Remarks,
				DamageDocumentId = dmgsec.DamageDocument?.ItemId
			};
		}

		public static DamageSector Convert(this DamageSectorDTO dmgsecdto)
		{
			return new DamageSector()
			{
				ItemId = dmgsecdto.ItemId,

				IsDeleted = dmgsecdto.IsDeleted,
				DamageChartColumn = dmgsecdto.DamageChartColumn ?? default(int),

				DamageChartRow = dmgsecdto.DamageChartRow ?? default(int),
				Remarks = dmgsecdto.Remarks,
				DamageDocument = dmgsecdto.DamageDocument?.Convert()
			};
		}


		public static DirectiveDTO Convert(this Directive direc)
		{

			return new DirectiveDTO
			{
				ItemId = direc.ItemId,
				Title = direc.Title,
				IsDeleted = direc.IsDeleted,
				IsApplicability = direc.IsApplicability,
				ManHours = direc.ManHours,
				Remarks = direc.Remarks,
				Threshold = direc.Threshold?.ToBinary(),
				ThldTypeCond = direc.ThrldTypeCond,

				Applicability = direc.Applicability,

				DirectiveType = direc.DirectiveType?.ItemId,
				Description = direc.Description,
				EngineeringOrders = direc.EngineeringOrders,
				EngineeringOrderFileID = direc.EngineeringOrderFile?.ItemId,
				Cost = direc.Cost,
				Highlight = direc.Highlight?.ItemId,
				Paragraph = direc.Paragraph,
				KitRequired = direc.KitRequired,
				HiddenRemarks = direc.HiddenRemarks,
				ADType = (short?)direc.ADType,

				WorkType = direc.WorkType?.ItemId,

				ServiceBulletinNo = direc.ServiceBulletinNo,
				StcNo = direc.StcNo,
				ServiceBulletinFileID = direc.ServiceBulletinFile?.ItemId,
				ADFileID = direc.ADNoFile?.ItemId,

				IsClosed = direc.IsClosed,
				AircraftFlight = direc.AircraftFlightId,
				NDTType = (short)(direc.NDTType?.ItemId ?? -1),
				ComponentId = direc.ParentBaseComponent?.ItemId,
				ATAChapterId = direc.ATAChapter?.ItemId ?? -1,
				Files = direc.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PerformanceRecords = direc.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = direc.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = direc.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>
			};
		}

		public static Directive Convert(this DirectiveDTO direcdto)
		{
			var value = new Directive()
			{
				ItemId = direcdto.ItemId,
				IsDeleted = direcdto.IsDeleted,
				IsApplicability = direcdto.IsApplicability,

				Title = direcdto.Title,
				ManHours = direcdto.ManHours ?? default(double),
				Remarks = direcdto.Remarks,

				Threshold = DirectiveThreshold.ConvertFromByteArray(direcdto.Threshold),
				ThrldTypeCond = direcdto.ThldTypeCond,
				Applicability = direcdto.Applicability,
				DirectiveType = direcdto.DirectiveType.HasValue ? DirectiveType.Items.GetItemById(direcdto.DirectiveType.Value) : DirectiveType.Unknown,
				Description = direcdto.Description,

				EngineeringOrders = direcdto.EngineeringOrders,
				Cost = direcdto.Cost ?? default(double),

				Highlight = direcdto.Highlight.HasValue ? Highlight.GetHighlightById(direcdto.Highlight.Value) : Highlight.White,
				Paragraph = direcdto.Paragraph,
				KitRequired = direcdto.KitRequired,
				HiddenRemarks = direcdto.HiddenRemarks,
				ADType = direcdto.ADType.HasValue ? (ADType)direcdto.ADType.Value : ADType.None,
				WorkType = direcdto.WorkType.HasValue ? DirectiveWorkType.Items.GetItemById(direcdto.WorkType.Value) : DirectiveWorkType.Unknown ,
				ServiceBulletinNo = direcdto.ServiceBulletinNo,
				StcNo = direcdto.StcNo,
				IsClosed = direcdto.IsClosed ??default(bool),
				AircraftFlightId = direcdto.AircraftFlight ?? default(int) ,
				NDTType = NDTType.GetItemById(direcdto.NDTType),
				ParentBaseComponent = direcdto.BaseComponent?.ConvertToBaseComponent(),
				ATAChapter = direcdto.ATAChapter?.Convert()
			};

			if (direcdto.Files != null)
				value.Files.AddRange(direcdto.Files.Select(i => i.Convert()));

			if (direcdto.PerformanceRecords != null)
			{
				foreach (var dto in direcdto.PerformanceRecords)
				{

					var record = dto.Convert();
					record.Parent = value;
					value.PerformanceRecords.Add(record);
				}

			}

			if (direcdto.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(direcdto.CategoriesRecords.Select(i => i.Convert()));

			if (direcdto.Kits != null)

			{
				foreach (var dto in direcdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);

				}
			}


			return value;
		}


		public static DirectiveDTO Convert(this DeferredItem direc)
		{
			return new DirectiveDTO

			{

				ItemId = direc.ItemId,
				IsDeleted = direc.IsDeleted,
				Title = direc.Title,
				IsApplicability = direc.IsApplicability,
				ManHours = direc.ManHours,
				Remarks = direc.Remarks,
				Threshold = direc.Threshold?.ToBinary(),
				ThldTypeCond = direc.ThrldTypeCond,
				Applicability = direc.Applicability,
				DirectiveType = direc.DirectiveType?.ItemId,
				Description = direc.Description,
				EngineeringOrders = direc.EngineeringOrders,
				EngineeringOrderFileID = direc.EngineeringOrderFile?.ItemId,
				Cost = direc.Cost,
				Highlight = direc.Highlight?.ItemId,
				Paragraph = direc.Paragraph,
				KitRequired = direc.KitRequired,
				HiddenRemarks = direc.HiddenRemarks,

				ADType = (short?)direc.ADType,
				WorkType = direc.WorkType?.ItemId,

				ServiceBulletinNo = direc.ServiceBulletinNo,
				StcNo = direc.StcNo,
				ServiceBulletinFileID = direc.ServiceBulletinFile?.ItemId,
				ADFileID = direc.ADNoFile?.ItemId,
				IsClosed = direc.IsClosed,
				DeferredExtention = direc.DeferredExtention,
				DeferredMelCdlItem = direc.DeferredMelCdlItem,

				DeferredLogBookRef = direc.DeferredLogBookRef,

				DeferredCategoryId = direc.DeferredCategory?.ItemId ?? -1,
				AircraftFlight = direc.AircraftFlightId,

				NDTType = (short)(direc.NDTType?.ItemId ?? -1),
				ComponentId = direc.ParentBaseComponent?.ItemId,

				ATAChapterId = direc.ATAChapter?.ItemId ?? -1,
				Files = direc.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PerformanceRecords = direc.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = direc.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = direc.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>
			};
		}

		public static DeferredItem ConvertToDeffered(this DirectiveDTO direcdto)
		{
			var value = new DeferredItem()
			{
				ItemId = direcdto.ItemId,
				IsDeleted = direcdto.IsDeleted,
				IsApplicability = direcdto.IsApplicability,

				Title = direcdto.Title,
				ManHours = direcdto.ManHours ?? default(double),
				Remarks = direcdto.Remarks,
				Threshold = DirectiveThreshold.ConvertFromByteArray(direcdto.Threshold),
				ThrldTypeCond = direcdto.ThldTypeCond,
				Applicability = direcdto.Applicability,
				DirectiveType = direcdto.DirectiveType.HasValue ? DirectiveType.Items.GetItemById(direcdto.DirectiveType.Value) : DirectiveType.Unknown,
				Description = direcdto.Description,
				EngineeringOrders = direcdto.EngineeringOrders,
				Cost = direcdto.Cost ?? default(double),
				Highlight = direcdto.Highlight.HasValue ? Highlight.GetHighlightById(direcdto.Highlight.Value) : Highlight.White,
				Paragraph = direcdto.Paragraph,
				KitRequired = direcdto.KitRequired,
				HiddenRemarks = direcdto.HiddenRemarks,
				ADType = direcdto.ADType.HasValue ? (ADType)direcdto.ADType.Value : ADType.None,
				WorkType = direcdto.WorkType.HasValue ? DirectiveWorkType.Items.GetItemById(direcdto.WorkType.Value) : DirectiveWorkType.Unknown,
				ServiceBulletinNo = direcdto.ServiceBulletinNo,
				StcNo = direcdto.StcNo,
				DeferredExtention = direcdto.DeferredExtention,
				DeferredMelCdlItem = direcdto.DeferredMelCdlItem,
				DeferredLogBookRef = direcdto.DeferredLogBookRef,
				DeferredCategory = direcdto.DeferredCategory?.Convert(),
				IsClosed = direcdto.IsClosed ?? default(bool),
				AircraftFlightId = direcdto.AircraftFlight ?? default(int),
				NDTType = NDTType.GetItemById(direcdto.NDTType),
				ParentBaseComponent = direcdto.BaseComponent?.ConvertToBaseComponent(),
				ATAChapter = direcdto.ATAChapter?.Convert()
			};

			if (direcdto.Files != null)
				value.Files.AddRange(direcdto.Files.Select(i => i.Convert()));

			if (direcdto.PerformanceRecords != null)

			{
				foreach (var dto in direcdto.PerformanceRecords)
				{
					var record = dto.Convert();
					record.Parent = value;
					value.PerformanceRecords.Add(record);

				}

			}

			if (direcdto.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(direcdto.CategoriesRecords.Select(i => i.Convert()));

			if (direcdto.Kits != null)
			{
				foreach (var dto in direcdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;

					value.Kits.Add(directive);
				}
			}

			return value;
		}

		public static DirectiveDTO Convert(this DamageItem direc)
		{
			return new DirectiveDTO
			{
				ItemId = direc.ItemId,
				IsDeleted = direc.IsDeleted,
				Title = direc.Title,
				IsApplicability = direc.IsApplicability,
				Number = direc.Number,
				Location = direc.Location,
				IsTemporary = direc.IsTemporary,
				DamageLenght = direc.DamageLenght,
				DamageWidth = direc.DamageWidth,
				DamageDepth = direc.DamageDepth,
				DamageLenghtLimit = direc.DamageLenghtLimit,
				DamageWidthLimit = direc.DamageWidthLimit,
				DamageDepthLimit = direc.DamageDepthLimit,
				DamageMeasure = direc.DamageMeasure?.ItemId ?? -1,
				ManHours = direc.ManHours,
				Remarks = direc.Remarks,
				Threshold = direc.Threshold?.ToBinary(),
				ThldTypeCond = direc.ThrldTypeCond,

				Applicability = direc.Applicability,
				DirectiveType = direc.DirectiveType?.ItemId,
				DamageType = (int) direc.DamageType,
				DamageClass = (int) direc.DamageClass,
				CorrectiveAction = direc.CorrectiveAction,
				InspectionDocumentsNo = direc.InspectionDocumentsNo,
				Description = direc.Description,

				EngineeringOrders = direc.EngineeringOrders,
				EngineeringOrderFileID = direc.EngineeringOrderFile?.ItemId,
				Cost = direc.Cost,
				Highlight = direc.Highlight?.ItemId,
				Paragraph = direc.Paragraph,
				KitRequired = direc.KitRequired,
				HiddenRemarks = direc.HiddenRemarks,

				ADType = (short?)direc.ADType,
				WorkType = direc.WorkType?.ItemId,
				ServiceBulletinNo = direc.ServiceBulletinNo,
				StcNo = direc.StcNo,

				ServiceBulletinFileID = direc.ServiceBulletinFile?.ItemId,
				ADFileID = direc.ADNoFile?.ItemId,

				IsClosed = direc.IsClosed,
				AircraftFlight = direc.AircraftFlightId,
				NDTType = (short)(direc.NDTType?.ItemId ?? -1),
				ComponentId = direc.ParentBaseComponent?.ItemId,
				ATAChapterId = direc.ATAChapter?.ItemId ?? -1,
				Files = direc.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				DamageDocs = direc.DamageDocs?.Select(i => i.Convert()) as ICollection<DamageDocumentDTO>,
				PerformanceRecords = direc.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = direc.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = direc.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>

			};
		}

		public static DamageItem ConvertToDamage(this DirectiveDTO direcdto)
		{
			var value = new DamageItem()
			{
				ItemId = direcdto.ItemId,

				IsDeleted = direcdto.IsDeleted,
				Number = direcdto.Number,
				Location = direcdto.Location,
				IsTemporary = direcdto.IsTemporary,
				DamageLenght = direcdto.DamageLenght,

				DamageWidth = direcdto.DamageWidth,
				DamageDepth = direcdto.DamageDepth,
				DamageLenghtLimit = direcdto.DamageLenghtLimit,
				DamageWidthLimit = direcdto.DamageWidthLimit,
				DamageDepthLimit = direcdto.DamageDepthLimit,

				DamageMeasure = Measure.Items.GetItemById(direcdto.DamageMeasure),
				DamageType = (DamageType) direcdto.DamageType,

				DamageClass = (DamageClass) direcdto.DamageClass,
				CorrectiveAction = direcdto.CorrectiveAction,
				InspectionDocumentsNo = direcdto.InspectionDocumentsNo,
				IsApplicability = direcdto.IsApplicability,

				Title = direcdto.Title,
				ManHours = direcdto.ManHours ?? default(double),
				Remarks = direcdto.Remarks,
				Threshold = DirectiveThreshold.ConvertFromByteArray(direcdto.Threshold),
				ThrldTypeCond = direcdto.ThldTypeCond,

				Applicability = direcdto.Applicability,
				DirectiveType = direcdto.DirectiveType.HasValue ? DirectiveType.Items.GetItemById(direcdto.DirectiveType.Value) : DirectiveType.Unknown,

				Description = direcdto.Description,

				EngineeringOrders = direcdto.EngineeringOrders,
				Cost = direcdto.Cost ?? default(double),
				Highlight = direcdto.Highlight.HasValue ? Highlight.GetHighlightById(direcdto.Highlight.Value) : Highlight.White,
				Paragraph = direcdto.Paragraph,
				KitRequired = direcdto.KitRequired,
				HiddenRemarks = direcdto.HiddenRemarks,
				ADType = direcdto.ADType.HasValue ? (ADType)direcdto.ADType.Value : ADType.None,
				WorkType = direcdto.WorkType.HasValue ? DirectiveWorkType.Items.GetItemById(direcdto.WorkType.Value) : DirectiveWorkType.Unknown,
				ServiceBulletinNo = direcdto.ServiceBulletinNo,
				StcNo = direcdto.StcNo,
				IsClosed = direcdto.IsClosed ?? default(bool),

				AircraftFlightId = direcdto.AircraftFlight ?? default(int),
				NDTType = NDTType.GetItemById(direcdto.NDTType),
				ParentBaseComponent = direcdto.BaseComponent?.ConvertToBaseComponent(),
				ATAChapter = direcdto.ATAChapter?.Convert()

			};


			if (direcdto.Files != null)
				value.Files.AddRange(direcdto.Files.Select(i => i.Convert()));


			if (direcdto.DamageDocs != null)
				value.DamageDocs.AddRange(direcdto.DamageDocs.Select(i => i.Convert()));


			if (direcdto.PerformanceRecords != null)
			{
				foreach (var dto in direcdto.PerformanceRecords)
				{
					var record = dto.Convert();

					record.Parent = value;
					value.PerformanceRecords.Add(record);
				}
			}


			if (direcdto.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(direcdto.CategoriesRecords.Select(i => i.Convert()));

			if (direcdto.Kits != null)
			{
				foreach (var dto in direcdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}
			}

			return value;

		}




		public static DirectiveRecord Convert(this DirectiveRecordDTO dirrecdto)
		{
			var value = new DirectiveRecord()
			{
				ItemId = dirrecdto.ItemId,
				IsDeleted = dirrecdto.IsDeleted,
				PerformanceNum = dirrecdto.NumGroup ?? default(int),
				RecordTypeId = dirrecdto.RecordTypeID,
				ParentId = dirrecdto.ParentID,
				ParentType = SmartCoreType.Items.GetItemById(dirrecdto.ParentTypeId),
				Remarks = dirrecdto.Remarks,
				RecordDate = dirrecdto.RecordDate,
				OnLifelength = Lifelength.ConvertFromByteArray(dirrecdto.OnLifelength),
				Unused = Lifelength.ConvertFromByteArray(dirrecdto.Unused),

				Overused = Lifelength.ConvertFromByteArray(dirrecdto.Overused),
				DirectivePackageId = dirrecdto.WorkPackageID ?? default(int),
				Dispatched = dirrecdto.Dispatched ??DateTimeExtend.GetCASMinDateTime(),
				Completed = dirrecdto.Completed ?? default(bool),
				Reference = dirrecdto.Reference,
				ODR = dirrecdto.ODR ?? default(bool),
				MaintenanceOrganization = dirrecdto.MaintenanceOrganization,
				MaintenanceDirectiveRecordId = dirrecdto.MaintenanceDirectiveRecordId ?? default(int),
				MaintenanceCheckRecordId = dirrecdto.MaintenanceCheckRecordId ?? default(int)
			};


			if (dirrecdto.Files != null)
				value.Files.AddRange(dirrecdto.Files.Select(i => i.Convert()));

			return value;
		}

		public static DirectiveRecordDTO Convert(this DirectiveRecord dirrec)
		{
			return new DirectiveRecordDTO

			{
				ItemId = dirrec.ItemId,
				IsDeleted = dirrec.IsDeleted,
				NumGroup = dirrec.PerformanceNum,
				RecordTypeID = dirrec.RecordTypeId,

				ParentID = dirrec.ParentId,

				ParentTypeId = dirrec.ParentType?.ItemId ?? -1,
				Remarks = dirrec.Remarks,
				RecordDate = dirrec.RecordDate,
				OnLifelength = dirrec.OnLifelength?.ConvertToByteArray(),
				Unused = dirrec.Unused?.ConvertToByteArray(),
				Overused = dirrec.Overused?.ConvertToByteArray(),

				WorkPackageID = dirrec.DirectivePackageId,
				Dispatched = dirrec.Dispatched,
				Completed = dirrec.Completed,
				Reference = dirrec.Reference,

				ODR = dirrec.ODR,
				MaintenanceOrganization = dirrec.MaintenanceOrganization,
				MaintenanceDirectiveRecordId = dirrec.MaintenanceDirectiveRecordId,
				MaintenanceCheckRecordId = dirrec.MaintenanceCheckRecordId,
				Files = dirrec.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}


		public static MaintenanceCheckRecord ConvertToMaintenanceCheckRecord(this DirectiveRecordDTO dirrecdto)
		{
			var value = new MaintenanceCheckRecord
			{
				ItemId = dirrecdto.ItemId,
				IsDeleted = dirrecdto.IsDeleted,
				IsControlPoint = dirrecdto.IsControlPoint,
				CalculatedPerformanceSource = Lifelength.ConvertFromByteArray(dirrecdto.CalculatedPerformanceSource),
				ComplianceCheckName = dirrecdto.ComplianceCheckName,
				PerformanceNum = dirrecdto.NumGroup ?? default(int),
				ParentId = dirrecdto.ParentID,
				ParentType = SmartCoreType.Items.GetItemById(dirrecdto.ParentTypeId),
				Remarks = dirrecdto.Remarks,
				RecordDate = dirrecdto.RecordDate,
				OnLifelength = Lifelength.ConvertFromByteArray(dirrecdto.OnLifelength),
				DirectivePackageId = dirrecdto.WorkPackageID ?? default(int)
			};

			if (dirrecdto.Files != null)

				value.Files.AddRange(dirrecdto.Files.Select(i => i.Convert()));

			return value;
		}

		public static DirectiveRecordDTO Convert(this MaintenanceCheckRecord dirrecdto)
		{

			return new DirectiveRecordDTO
			{
				ItemId = dirrecdto.ItemId,
				IsDeleted = dirrecdto.IsDeleted,
				IsControlPoint = dirrecdto.IsControlPoint,
				CalculatedPerformanceSource = dirrecdto.CalculatedPerformanceSource?.ConvertToByteArray(),
				ComplianceCheckName = dirrecdto.ComplianceCheckName,
				PerformanceNum = dirrecdto.NumGroup,
				ParentID = dirrecdto.ParentId,
				ParentTypeId = dirrecdto.ParentType?.ItemId ?? -1,
				Remarks = dirrecdto.Remarks,
				RecordDate = dirrecdto.RecordDate,

				OnLifelength = dirrecdto.OnLifelength?.ConvertToByteArray(),

				WorkPackageID = dirrecdto.DirectivePackageId,
				FilesForMaintenanceCheckRecord = (ICollection<ItemFileLinkDTO>) dirrecdto.Files?.Select(i => i.Convert())//TODO:Файлы юзаюстя разные с DirectiveRecord

			};
		}


		public static DiscrepancyDTO Convert(this Discrepancy disc)
		{

			return new DiscrepancyDTO
			{

				ItemId = disc.ItemId,
				IsDeleted = disc.IsDeleted,
				FlightID = disc.FlightId,
				FilledBy = disc.FilledBy,
				Description = disc.Description,
				PilotRemarks = disc.PilotRemarks,

				ATAChapterID = disc.ATAChapter?.ItemId ?? -1,

				DirectiveId = disc.DirectiveId,
				Num = disc.Num,
				Remarks = disc.Remark,
				EngineRemarks = disc.EngineRemarks,
				EngineShutUp = disc.EngineShutUp,
				BaseComponentId = disc.BaseComponentId,
				FDR = disc.FDR,

				AuthId = disc.Auth?.ItemId ?? -1,

				Messages = disc.Messages,
				WorkPackageId = disc.WorkPackageId,
				IsReliability = disc.IsReliability,
				Status = (int)disc.Status,
				IsOccurrence = disc.IsOccurrence,

				Substruction = disc.Substruction,
				TimeDelay = disc.TimeDelay,

				ConsequenceType = disc.ConsequenceType?.ItemId ?? -1,
				DeffectConfirm = disc.DeffectConfirm?.ItemId ?? -1,

				DeffeсtPhase = disc.DeffeсtPhase?.ItemId ?? -1,
				DeffeсtCategory = disc.DeffeсtCategory?.ItemId ?? -1,
				ActionType = disc.ActionType?.ItemId ?? -1,
				InterruptionType = disc.InterruptionType?.ItemId ?? -1,
				ConsequenceOps = disc.ConsequenceOps?.ItemId ?? -1,
				Occurrence = disc.Occurrence?.ItemId ?? -1,

				ConsequenceFault = disc.ConsequenceFault?.ItemId ?? -1
			};
		}

		public static Discrepancy Convert(this DiscrepancyDTO discdto)
		{
			return new Discrepancy()

			{
				ItemId = discdto.ItemId,

				IsDeleted = discdto.IsDeleted,
				FlightId = discdto.FlightID,
				IsReliability = discdto.IsReliability,
				IsOccurrence = discdto.IsOccurrence,
				Substruction = discdto.Substruction,
				FilledBy = discdto.FilledBy,
				BaseComponentId = discdto.BaseComponentId,
				Description = discdto.Description,
				Remark = discdto.Remarks,
				EngineRemarks = discdto.EngineRemarks,
				EngineShutUp = discdto.EngineShutUp,
				FDR = discdto.FDR,
				Status = (CorrectiveActionStatus)discdto.Status,
				Messages = discdto.Messages,
				Auth = discdto.Auth?.Convert(),
				PilotRemarks = discdto.PilotRemarks,
				ATAChapter = discdto.ATAChapter?.Convert(),
				DirectiveId = discdto.DirectiveId,

				Num = discdto.Num ?? default(int),

				WorkPackageId = discdto.WorkPackageId ?? default(int),

				TimeDelay = discdto.TimeDelay,

				Occurrence = OccurrenceType.GetItemById(discdto.Occurrence),
				DeffectConfirm = DeffectConfirm.GetItemById(discdto.DeffectConfirm),
				InterruptionType = InterruptionType.GetItemById(discdto.InterruptionType),

				DeffeсtPhase = DeffeсtPhase.GetItemById(discdto.DeffeсtPhase),
				DeffeсtCategory = DeffeсtCategory.GetItemById(discdto.DeffeсtCategory),

				ActionType = ActionType.GetItemById(discdto.ActionType),
				ConsequenceOps = ConsequenceOPS.GetItemById(discdto.ConsequenceOps),
				ConsequenceFault = ConsequenceFaults.GetItemById(discdto.ConsequenceFault),
				ConsequenceType = IncidentType.GetItemById(discdto.ConsequenceType)

			};
		}


		
		public static EngineAccelerationTimeDTO Convert(this EngineAccelerationTime engacctime)
		{
			return new EngineAccelerationTimeDTO
			{

				ItemId = engacctime.ItemId,
				IsDeleted = engacctime.IsDeleted,
				FlightId = engacctime.FlightId,
				EngineId = engacctime.BaseComponentId,
				AccelerationTime = engacctime.AccelerationTime,

				RecordDate = engacctime.RecordDate,
				AccelerationTimeAir = engacctime.AccelerationTimeAir
			};
		}

		public static EngineAccelerationTime Convert(this EngineAccelerationTimeDTO engacctimedto)
		{
			return new EngineAccelerationTime()
			{
				ItemId = engacctimedto.ItemId,
				IsDeleted = engacctimedto.IsDeleted,
				FlightId = engacctimedto.FlightId ?? default(int),
				BaseComponentId = engacctimedto.EngineId ?? default(int),
				AccelerationTime = engacctimedto.AccelerationTime ?? default(int),
				RecordDate = engacctimedto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				AccelerationTimeAir = engacctimedto.AccelerationTimeAir ?? default(int)
			};
		}


		public static EngineTimeInRegimeDTO Convert(this EngineTimeInRegime engtimeinregime)
		{
			return new EngineTimeInRegimeDTO
			{
				ItemId = engtimeinregime.ItemId,
				IsDeleted = engtimeinregime.IsDeleted,
				FlightId = engtimeinregime.FlightId,
				EngineId = engtimeinregime.BaseComponentId,

				FlightRegimeId = engtimeinregime.FlightRegime?.ItemId,
				TimeInRegime = (int?)engtimeinregime.TimeInRegime.Ticks,
				RecordDate = engtimeinregime.RecordDate,
				GroundAir = (short?)engtimeinregime.GroundAir
			};
		}


		public static EngineTimeInRegime Convert(this EngineTimeInRegimeDTO engtimeinregimedto)
		{

			return new EngineTimeInRegime()
			{
				ItemId = engtimeinregimedto.ItemId,
				IsDeleted = engtimeinregimedto.IsDeleted,
				FlightId = engtimeinregimedto.FlightId,
				BaseComponentId = engtimeinregimedto.EngineId ?? default(int),
				FlightRegime = engtimeinregimedto.FlightRegimeId.HasValue ? FlightRegime.Items.GetItemById(engtimeinregimedto.FlightRegimeId.Value) : FlightRegime.UNK,
				TimeInRegime = new TimeSpan(engtimeinregimedto.TimeInRegime ?? default(int)),
				RecordDate = engtimeinregimedto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				GroundAir = engtimeinregimedto.GroundAir.HasValue ? (GroundAir)engtimeinregimedto.GroundAir.Value : GroundAir.Air
			};
		}

		public static EventConditionDTO Convert(this EventCondition evtcond)

		{
			return new EventConditionDTO
			{
				ItemId = evtcond.ItemId,
				IsDeleted = evtcond.IsDeleted,
				EventConditionTypeId = evtcond.EventConditionType?.ItemId,

				ValueId = (int?)evtcond.Value,
				ParentId = evtcond.ParentId,
				ParentTypeId = evtcond.ParentType?.ItemId
			};
		}

		public static EventCondition Convert(this EventConditionDTO evtconddto)
		{
			return new EventCondition()
			{
				ItemId = evtconddto.ItemId,
				IsDeleted = evtconddto.IsDeleted,
				EventConditionType = evtconddto.EventConditionTypeId.HasValue ? SmartCoreType.Items.GetItemById(evtconddto.EventConditionTypeId.Value) : SmartCoreType.Unknown,
				Value = evtconddto.ValueId,

				ParentId = evtconddto.ParentId ?? default(int),
				ParentType = evtconddto.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(evtconddto.ParentTypeId.Value) : SmartCoreType.Unknown
			};
		}

		public static EventDTO Convert(this Event evnt)
		{
			return new EventDTO
			{
				ItemId = evnt.ItemId,
				IsDeleted = evnt.IsDeleted,
				EventTypeId = evnt.EventType?.ItemId,
				EventCategoryId = evnt.EventCategory?.ItemId,

				EventClassId = evnt.EventClass?.ItemId,
				IncidentTypeId = evnt.IncidentType?.ItemId,
				RecordDate = evnt.RecordDate,
				ParentTypeId = evnt.ParentType?.ItemId,
				ParentId = evnt.ParentId,
				Remarks = evnt.Remarks,
				Description = evnt.Description,
				EventStatusId = evnt.EventStatus?.ItemId,
				AircraftId = evnt.AircraftId,
				EventConditions = evnt.EventConditions?.Select(i => i.Convert()) as ICollection<EventConditionDTO>
			};
		}

		public static Event Convert(this EventDTO evntdto)
		{

			var value = new Event()
			{
				ItemId = evntdto.ItemId,
				IsDeleted = evntdto.IsDeleted,
				EventType = evntdto.EventType?.Convert(),
				EventCategory = evntdto.EventCategory?.Convert(),
				EventClass = evntdto.EventClass?.Convert(),
				IncidentType = evntdto.IncidentTypeId.HasValue ? IncidentType.Items.GetItemById(evntdto.IncidentTypeId.Value) : IncidentType.UNK,
				RecordDate = evntdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				ParentType = evntdto.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(evntdto.ParentTypeId.Value) : SmartCoreType.Unknown,
				ParentId = evntdto.ParentId ?? default(int),

				Remarks = evntdto.Remarks,
				Description = evntdto.Description,
				EventStatus = evntdto.EventStatusId.HasValue ? SmsEventStatus.Items.GetItemById(evntdto.EventStatusId.Value) : SmsEventStatus.UNK,

				AircraftId = evntdto.AircraftId ?? default(int)
			};

			if (evntdto.EventConditions != null)
				value.EventConditions.AddRange(evntdto.EventConditions.Select(i => i.Convert()));

			return value;

		}

		public static EventTypeRiskLevelChangeRecordDTO Convert(this EventTypeRiskLevelChangeRecord evtrisklvl)
		{
			return new EventTypeRiskLevelChangeRecordDTO
			{
				ItemId = evtrisklvl.ItemId,
				IsDeleted = evtrisklvl.IsDeleted,
				EventCategoryId = evtrisklvl.EventCategory?.ItemId,
				EventClassId = evtrisklvl.EventClass?.ItemId,
				IncidentTypeId = evtrisklvl.IncidentType?.ItemId,
				RecordDate = evtrisklvl.RecordDate,

				Remarks = evtrisklvl.Remarks,
				ParentId = evtrisklvl.ParentEventType?.ItemId,
			};

		}

		public static EventTypeRiskLevelChangeRecord Convert(this EventTypeRiskLevelChangeRecordDTO evtrisklvldto)
		{
			return new EventTypeRiskLevelChangeRecord()
			{
				ItemId = evtrisklvldto.ItemId,
				IsDeleted = evtrisklvldto.IsDeleted,
				EventCategory = evtrisklvldto.EventCategory?.Convert(),
				EventClass = evtrisklvldto.EventClass?.Convert(),

				IncidentType = evtrisklvldto.IncidentTypeId.HasValue ? IncidentType.Items.GetItemById(evtrisklvldto.IncidentTypeId.Value) : IncidentType.UNK,

				RecordDate = evtrisklvldto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				Remarks = evtrisklvldto.Remarks,
				ParentEventType = evtrisklvldto.ParentEventType?.Convert()

			};
		}

		public static FlightCargoRecordDTO Convert(this FlightCargoRecord cargorec)
		{
			return new FlightCargoRecordDTO
			{
				ItemId = cargorec.ItemId,
				IsDeleted = cargorec.IsDeleted,

				FlightId = cargorec.FlightId,

				CargoCategory = cargorec.CargoCategory?.ItemId,

				Weigth = cargorec.Weigth,
				Measure = cargorec.Measure?.ItemId,
				RecordDate = cargorec.RecordDate,
			};
		}

		public static FlightCargoRecord Convert(this FlightCargoRecordDTO cargorecdto)
		{
			return new FlightCargoRecord()
			{

				ItemId = cargorecdto.ItemId,
				IsDeleted = cargorecdto.IsDeleted,
				FlightId = cargorecdto.FlightId ?? default(int),
				CargoCategory = cargorecdto.CargoCategory.HasValue ? CargoCategory.Items.GetItemById(cargorecdto.CargoCategory.Value) : CargoCategory.UNK,
				Weigth = cargorecdto.Weigth ?? default(double),
				Measure = cargorecdto.Measure.HasValue ? Measure.Items.GetItemById(cargorecdto.Measure.Value) : Measure.Unknown,
				RecordDate = cargorecdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime()
			};

		}


		public static FlightCrewRecordDTO Convert(this FlightCrewRecord crewrec)
		{

			return new FlightCrewRecordDTO
			{

				ItemId = crewrec.ItemId,
				IsDeleted = crewrec.IsDeleted,

				FlightID = crewrec.FlightId,
				SpecialistID = crewrec.Specialist?.ItemId,
				SpecializationID = crewrec.Specialization?.ItemId,
				IDNo = crewrec.IdNo,
				Limitations = crewrec.Limitations,
				Remarks = crewrec.Remarks,
			};
		}

		public static FlightCrewRecord Convert(this FlightCrewRecordDTO crewrecdto)
		{
			return new FlightCrewRecord()
			{
				ItemId = crewrecdto.ItemId,
				IsDeleted = crewrecdto.IsDeleted,
				FlightId = crewrecdto.FlightID,
				Specialist = crewrecdto.Specialist?.Convert(),
				Specialization = crewrecdto.Specialization?.Convert(),
				IdNo = crewrecdto.IDNo ?? default(int),
				Limitations = crewrecdto.Limitations,
				Remarks = crewrecdto.Remarks
			};
		}


		public static FlightNumberAircraftModelRelationDTO Convert(this FlightNumberAircraftModelRelation airmodrel)
		{
			return new FlightNumberAircraftModelRelationDTO
			{
				ItemId = airmodrel.ItemId,
				IsDeleted = airmodrel.IsDeleted,
				AircraftModelId = airmodrel.AircraftModel?.ItemId,

				FlightNumberId = airmodrel.FlightNumber?.ItemId,
			};
		}


		public static FlightNumberAircraftModelRelation Convert(this FlightNumberAircraftModelRelationDTO airmodreldto)
		{
			return new FlightNumberAircraftModelRelation()
			{
				ItemId = airmodreldto.ItemId,
				IsDeleted = airmodreldto.IsDeleted,
				AircraftModel = airmodreldto.AircraftModel?.ConvertToAircraftModel(),

				FlightNumber = airmodreldto.FlightNumber?.Convert()

			};
		}


		public static FlightNumberAirportRelationDTO Convert(this FlightNumberAirportRelation airprelation)
		{
			return new FlightNumberAirportRelationDTO
			{

				ItemId = airprelation.ItemId,
				IsDeleted = airprelation.IsDeleted,
				FlightNumberId = airprelation.FlightNumber?.ItemId,
				AirportId = airprelation.Airport?.ItemId,
			};
		}

		public static FlightNumberAirportRelation Convert(this FlightNumberAirportRelationDTO airprelationdto)
		{

			return new FlightNumberAirportRelation()
			{
				ItemId = airprelationdto.ItemId,
				IsDeleted = airprelationdto.IsDeleted,
				FlightNumber = airprelationdto.FlightNumber?.Convert(),
				Airport = airprelationdto.Airport?.Convert()
			};

		}


		public static FlightNumberCrewRecordDTO Convert(this FlightNumberCrewRecord flightcrewrec)
		{
			return new FlightNumberCrewRecordDTO
			{
				ItemId = flightcrewrec.ItemId,

				IsDeleted = flightcrewrec.IsDeleted,
				FlightNumberId = flightcrewrec.FlightNumber?.ItemId,
				SpecializationId = flightcrewrec.Specialization?.ItemId,
				Count = flightcrewrec.Count,
			};
		}

		public static FlightNumberCrewRecord Convert(this FlightNumberCrewRecordDTO flightcrewrecdto)

		{
			return new FlightNumberCrewRecord()
			{
				ItemId = flightcrewrecdto.ItemId,
				IsDeleted = flightcrewrecdto.IsDeleted,
				FlightNumber = flightcrewrecdto.FlightNumber?.Convert(),
				Specialization = flightcrewrecdto.Specialization?.Convert(),
				Count = flightcrewrecdto.Count ?? default(int)
			};
		}


		public static FlightNumberDTO Convert(this FlightNumber flightnum)
		{

			return new FlightNumberDTO
			{

				ItemId = flightnum.ItemId,
				IsDeleted = flightnum.IsDeleted,
				FlightNoId = flightnum.FlightNo?.ItemId ?? -1,
				Remarks = flightnum.Description,
				HiddenRemarks = flightnum.HiddenRemarks,
				MaxFuelAmount = flightnum.MaxFuelAmount,
				MinFuelAmount = flightnum.MinFuelAmount,
				MaxPayload = flightnum.MaxPayload,
				MaxCargoWeight = flightnum.MaxCargoWeight,
				MaxTakeOffWeight = flightnum.MaxTakeOffWeight,
				MaxLandWeight = flightnum.MaxLandWeight,
				FlightAircraftCode = (int?)flightnum.FlightAircraftCode,

				FlightType = flightnum.FlightType.ItemId,
				FlightCategory = (int?)flightnum.FlightCategory,
				Distance = flightnum.Distance,
				DistanceMeasure = flightnum.DistanceMeasure?.ItemId,
				StationFromId = flightnum.StationFrom?.ItemId,
				StationToId = flightnum.StationTo?.ItemId,
				MinLevelId = flightnum.MinLevel?.ItemId,

				MaxPassengerAmount = flightnum.MaxPassengerAmount,
				Threshold = flightnum.Threshold?.ToBinary(),
				IsClosed = flightnum.IsClosed
			};
		}

		public static FlightNumber Convert(this FlightNumberDTO flightnumdto)

		{
			return new FlightNumber
			{

				ItemId = flightnumdto.ItemId,
				IsDeleted = flightnumdto.IsDeleted,

				FlightNo = flightnumdto.FlightNo?.Convert(),
				Remarks = flightnumdto.Description,
				HiddenRemarks = flightnumdto.HiddenRemarks,
				MaxFuelAmount = flightnumdto.MaxFuelAmount ?? default(double),
				MinFuelAmount = flightnumdto.MinFuelAmount ?? default(double),
				MaxPayload = flightnumdto.MaxPayload ?? default(double),

				MaxCargoWeight = flightnumdto.MaxCargoWeight ?? default(double),

				MaxTakeOffWeight = flightnumdto.MaxTakeOffWeight ?? default(double),
				MaxLandWeight = flightnumdto.MaxLandWeight ?? default(double),
				FlightAircraftCode = flightnumdto.FlightAircraftCode.HasValue ? (FlightAircraftCode)flightnumdto.FlightAircraftCode.Value : FlightAircraftCode.Unknown,

				FlightType = FlightType.Items.GetItemById(flightnumdto.FlightType),

				FlightCategory = flightnumdto.FlightCategory.HasValue ? (FlightCategory) flightnumdto.FlightCategory.Value : FlightCategory.Unknown,
				Distance = flightnumdto.Distance ?? default(int),

				DistanceMeasure = flightnumdto.DistanceMeasure.HasValue ? Measure.Items.GetItemById(flightnumdto.DistanceMeasure.Value) : Measure.Unknown,
				StationFrom = flightnumdto.StationFrom?.Convert(),
				StationTo = flightnumdto.StationTo?.Convert(),
				MinLevel = flightnumdto.MinLevel?.Convert(),
				MaxPassengerAmount = flightnumdto.MaxPassengerAmount ?? default(int),
				Threshold = MaintenanceDirectiveThreshold.ConvertFromByteArray(flightnumdto.Threshold),
				IsClosed = flightnumdto.IsClosed ?? default(bool),
			};
		}

		public static FlightNumberPeriodDTO Convert(this FlightNumberPeriod numperiod)
		{
			return new FlightNumberPeriodDTO
			{
				ItemId = numperiod.ItemId,
				IsDeleted = numperiod.IsDeleted,
				FlightNumberId = numperiod.FlightNumberId,
				PeriodFrom = numperiod.PeriodFrom,
				PeriodTo = numperiod.PeriodTo,
				IsMonday = numperiod.IsMonday,
				IsThursday = numperiod.IsThursday,
				IsWednesday = numperiod.IsWednesday,

				IsTuesday = numperiod.IsTuesday,
				IsFriday = numperiod.IsFriday,
				IsSaturday = numperiod.IsSaturday,

				IsSunday = numperiod.IsSunday,
				DepartureDate = numperiod.DepartureDate,
				ArrivalDate = numperiod.ArrivalDate,
				Schedule = (int)numperiod.Schedule

			};
		}

		public static FlightNumberPeriod Convert(this FlightNumberPeriodDTO numperioddto)
		{
			return new FlightNumberPeriod()
			{

				ItemId = numperioddto.ItemId,
				IsDeleted = numperioddto.IsDeleted,
				FlightNumberId = numperioddto.FlightNumberId,
				PeriodFrom = numperioddto.PeriodFrom ?? default(int),
				PeriodTo = numperioddto.PeriodTo ?? default(int),
				IsMonday = numperioddto.IsMonday ?? default(bool),
				IsThursday = numperioddto.IsThursday ?? default(bool),
				IsWednesday = numperioddto.IsWednesday ?? default(bool),
				IsTuesday = numperioddto.IsTuesday ?? default(bool),

				IsFriday = numperioddto.IsFriday ?? default(bool),
				IsSaturday = numperioddto.IsSaturday ?? default(bool),
				IsSunday = numperioddto.IsSunday ?? default(bool),
				DepartureDate = numperioddto.DepartureDate ?? DateTimeExtend.GetCASMinDateTime(),
				ArrivalDate = numperioddto.ArrivalDate ?? DateTimeExtend.GetCASMinDateTime(),
				Schedule = (Schedule)numperioddto.Schedule
			};
		}


		public static FlightPassengerRecordDTO Convert(this FlightPassengerRecord passengerrec)
		{
			return new FlightPassengerRecordDTO
			{
				ItemId = passengerrec.ItemId,
				IsDeleted = passengerrec.IsDeleted,
				FlightId = passengerrec.FlightId,
				PassengerCategoryId = passengerrec.PassengerCategory?.ItemId,

				CountEconomy = passengerrec.CountEconomy,
				CountBusiness = passengerrec.CountBusiness,

				CountFirst = passengerrec.CountFirst,

				RecordDate = passengerrec.RecordDate,
			};

		}

		public static FlightPassengerRecord Convert(this FlightPassengerRecordDTO passengerrecdto)

		{
			return new FlightPassengerRecord()
			{
				ItemId = passengerrecdto.ItemId,
				IsDeleted = passengerrecdto.IsDeleted,
				FlightId = passengerrecdto.FlightId ?? default(int),
				PassengerCategory = passengerrecdto.PassengerCategory?.Convert(),
				CountEconomy = passengerrecdto.CountEconomy ?? default(short),
				CountBusiness = passengerrecdto.CountBusiness ?? default(short),

				CountFirst = passengerrecdto.CountFirst ?? default(short),
				RecordDate = passengerrecdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime()
			};
		}

		public static FlightPlanOpsDTO Convert(this FlightPlanOps planops)
		{
			return new FlightPlanOpsDTO
			{

				ItemId = planops.ItemId,
				IsDeleted = planops.IsDeleted,
				Remarks = planops.Remarks,

				DateFrom = planops.From,
				DateTo = planops.To,
			};
		}

		public static FlightPlanOps Convert(this FlightPlanOpsDTO planopsdto)
		{
			return new FlightPlanOps()
			{
				ItemId = planopsdto.ItemId,
				IsDeleted = planopsdto.IsDeleted,
				Remarks = planopsdto.Remarks,
				To = planopsdto.DateTo ?? DateTimeExtend.GetCASMinDateTime(),
				From = planopsdto.DateFrom ?? DateTimeExtend.GetCASMinDateTime()
			};
		}


		public static FlightPlanOpsRecordsDTO Convert(this FlightPlanOpsRecords planopsrec)
		{
			return new FlightPlanOpsRecordsDTO
			{
				ItemId = planopsrec.ItemId,
				IsDeleted = planopsrec.IsDeleted,
				FlightPlanOpsId = planopsrec.ParentFlightPlanOps?.ItemId,
				AircraftId = planopsrec.AircraftId,

				AircraftExchangeId = planopsrec.AircraftExchangeId,
				DelayReasonId = planopsrec.DelayReason?.ItemId,
				CancelReasonId = planopsrec.CancelReason?.ItemId,
				ReasonId = planopsrec.Reason?.ItemId,
				FlightTrackRecordId = planopsrec.FlightTrackRecordId,
				PeriodFrom = planopsrec.PeriodFrom,
				PeriodTo = planopsrec.PeriodTo,
				PlanDate = planopsrec.Date,
				ParentFlightId = planopsrec.ParentFlightId,

				Remarks = planopsrec.Remarks,
				HiddenRemarks = planopsrec.HiddenRemarks,
				IsDispatcherEdit = planopsrec.IsDispatcherEdit,
				IsDispatcherEditLdg = planopsrec.IsDispatcherEditLdg,
				StatusId = planopsrec.Status?.ItemId ?? -1,
			};
		}

		public static FlightPlanOpsRecords Convert(this FlightPlanOpsRecordsDTO planopsrecdto)
		{
			return new FlightPlanOpsRecords()
			{

				ItemId = planopsrecdto.ItemId,
				IsDeleted = planopsrecdto.IsDeleted,
				ParentFlightPlanOps = planopsrecdto.ParentFlightPlanOps?.Convert(),
				AircraftId = planopsrecdto.AircraftId ?? default(int),
				AircraftExchangeId = planopsrecdto.AircraftExchangeId ?? default(int),
				DelayReason = planopsrecdto.DelayReason?.Convert(),
				CancelReason = planopsrecdto.CancelReason?.Convert(),
				Reason = planopsrecdto.Reason?.Convert(),
				FlightTrackRecordId = planopsrecdto.FlightTrackRecordId ?? default(int),
				PeriodFrom = planopsrecdto.PeriodFrom ?? default(int),

				PeriodTo = planopsrecdto.PeriodTo ?? default(int),
				Date = planopsrecdto.PlanDate ?? DateTimeExtend.GetCASMinDateTime(),

				ParentFlightId = planopsrecdto.ParentFlightId ?? default(int),
				Remarks = planopsrecdto.Remarks,
				HiddenRemarks = planopsrecdto.HiddenRemarks,

				IsDispatcherEdit = planopsrecdto.IsDispatcherEdit ?? default(bool),
				IsDispatcherEditLdg = planopsrecdto.IsDispatcherEditLdg ?? default(bool),
				Status = OpsStatus.Items.GetItemById(planopsrecdto.StatusId)
			};
		}

		public static FlightTrackDTO Convert(this FlightTrack fltrack)
		{

			return new FlightTrackDTO
			{
				ItemId = fltrack.ItemId,
				IsDeleted = fltrack.IsDeleted,
				Remarks = fltrack.Remarks,
				DayOfWeek = fltrack.DayOfWeek?.ItemId,
				TripNameId = fltrack.TripName?.ItemId,
				SupplierID = fltrack.Supplier?.ItemId ?? -1,
				FlightTripRecord = fltrack.FlightTripRecord?.Select(i => i.Convert()) as ICollection<FlightTrackRecordDTO>
			};

		}

		public static FlightTrack Convert(this FlightTrackDTO fltrackdto)
		{
			var value = new FlightTrack()
			{
				ItemId = fltrackdto.ItemId,
				IsDeleted = fltrackdto.IsDeleted,

				Remarks = fltrackdto.Remarks,
				DayOfWeek = fltrackdto.DayOfWeek.HasValue ? DayofWeek.Items.GetItemById(fltrackdto.DayOfWeek.Value) : DayofWeek.Unknown,
				TripName = fltrackdto.TripName?.Convert(),
				Supplier = fltrackdto.Supplier?.Convert()
			};

			if (fltrackdto.FlightTripRecord != null)
				value.FlightTripRecord.AddRange(fltrackdto.FlightTripRecord.Select(i => i.Convert()));

			return value;

		}

		public static FlightTrackRecordDTO Convert(this FlightTrackRecord trackrec)
		{

			return new FlightTrackRecordDTO
			{
				ItemId = trackrec.ItemId,
				IsDeleted = trackrec.IsDeleted,
				FlightTripId = trackrec.FlightTripId,
				FlightPeriodId = trackrec.FlightPeriodId
			};

		}

		public static FlightTrackRecord Convert(this FlightTrackRecordDTO trackrecdto)
		{
			return new FlightTrackRecord()
			{

				ItemId = trackrecdto.ItemId,
				IsDeleted = trackrecdto.IsDeleted,

				FlightTripId = trackrecdto.FlightTripId,
				FlightPeriodId = trackrecdto.FlightPeriodId ?? default(int)

			};
		}

		public static HangarDTO Convert(this Hangar hangar)

		{
			return new HangarDTO
			{

				ItemId = hangar.ItemId,
				IsDeleted = hangar.IsDeleted,
				StoreName = hangar.Name,
				Location = hangar.Location,
				OperatorId = hangar.OperatorId,
				Remarks = hangar.Remarks
			};
		}

		public static Hangar Convert(this HangarDTO hangardto)
		{
			return new Hangar()
			{

				ItemId = hangardto.ItemId,
				IsDeleted = hangardto.IsDeleted,
				Name = hangardto.StoreName,
				Location = hangardto.Location,

				OperatorId = hangardto.OperatorId ?? default(int),
				Remarks = hangardto.Remarks
			};

		}

		public static HydraulicConditionDTO Convert(this HydraulicCondition hydrcondition)
		{
			return new HydraulicConditionDTO
			{
				ItemId = hydrcondition.ItemId,
				IsDeleted = hydrcondition.IsDeleted,
				FlightId = hydrcondition.FlightId,

				Remain = hydrcondition.Remain,
				Added = hydrcondition.OilAdded,
				OnBoard = hydrcondition.OnBoard,
				Spent = hydrcondition.Spent,
				RemainAfter = hydrcondition.RemainAfter,
				HydraulicSystem = hydrcondition.HydraulicSystem

			};
		}

		public static HydraulicCondition Convert(this HydraulicConditionDTO hydrconditiondto)
		{
			return new HydraulicCondition()

			{
				ItemId = hydrconditiondto.ItemId,
				IsDeleted = hydrconditiondto.IsDeleted,
				FlightId = hydrconditiondto.FlightId ?? default(int),
				Remain = hydrconditiondto.Remain ?? default(double),
				OilAdded = hydrconditiondto.Added ?? default(double),
				OnBoard = hydrconditiondto.OnBoard ?? default(double),
				Spent = hydrconditiondto.Spent ?? default(double),
				RemainAfter = hydrconditiondto.RemainAfter ?? default(double),
				HydraulicSystem = hydrconditiondto.HydraulicSystem
			};
		}

		public static InitialOrderDTO Convert(this InitialOrder initorder)
		{
			return new InitialOrderDTO
			{
				ItemId = initorder.ItemId,
				IsDeleted = initorder.IsDeleted,
				Title = initorder.Title,
				PublishedById = initorder.PublishedById,
				ClosedById = initorder.ClosedById,
				Description = initorder.Description,
				Author = initorder.Author,
				ParentId = initorder.ParentId,
				ParentTypeId = initorder.ParentType?.ItemId,
				Status = (short?)initorder.Status,
				OpeningDate = initorder.OpeningDate,
				PublishingDate = initorder.PublishingDate,
				ClosingDate = initorder.ClosingDate,
				Remarks = initorder.Remarks,
				PublishedByUser = initorder.PublishedByUser,
				CloseByUser = initorder.CloseByUser,
				Number = initorder.Number,
				Files = initorder.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PackageRecords = initorder.PackageRecords?.Select(i => i.Convert()) as ICollection<InitialOrderRecordDTO>
			};
		}


		public static InitialOrder Convert(this InitialOrderDTO initorderdto)
		{
			var value = new InitialOrder()
			{
				ItemId = initorderdto.ItemId,
				IsDeleted = initorderdto.IsDeleted,
				Title = initorderdto.Title,
				Description = initorderdto.Description,
				Author = initorderdto.Author,
				ParentId = initorderdto.ParentId ?? default(int),
				ParentType = initorderdto.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(initorderdto.ParentTypeId.Value) : SmartCoreType.Unknown,
				Status = initorderdto.Status.HasValue ? (WorkPackageStatus)initorderdto.Status.Value : WorkPackageStatus.All,
				OpeningDate = initorderdto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishingDate = initorderdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = initorderdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				Remarks = initorderdto.Remarks,
				PublishedById = initorderdto.PublishedById,
				ClosedById = initorderdto.ClosedById,
				PublishedByUser = initorderdto.PublishedByUser,
				CloseByUser = initorderdto.CloseByUser,
				Number = initorderdto.Number,
			};

			if (initorderdto.Files != null)
				value.Files.AddRange(initorderdto.Files.Select(i => i.Convert()));


			if (initorderdto.PackageRecords != null)
				value.PackageRecords.AddRange(initorderdto.PackageRecords.Select(i => i.Convert()));


			return value;
		}


		public static InitialOrderRecordDTO Convert(this InitialOrderRecord orderrec)
		{
			return new InitialOrderRecordDTO
			{
				ItemId = orderrec.ItemId,
				IsDeleted = orderrec.IsDeleted,
				InitialReason = orderrec.InitialReason?.ItemId,
				Priority = orderrec.Priority.ItemId,
				DestinationObjectID = orderrec.DestinationObjectId,
				DestinationObjectType = orderrec.DestinationObjectType?.ItemId,
				Measure = orderrec.Measure?.ItemId,
				Quantity = orderrec.Quantity,
				DefferedCategory = orderrec.DeferredCategory?.ItemId,
				EffectiveDate = orderrec.EffectiveDate,
				LifeLimit = orderrec.LifeLimit?.ConvertToByteArray(),
				LifeLimitNotify = orderrec.LifeLimitNotify?.ConvertToByteArray(),
				Processed = orderrec.Processed,
				ParentPackageId = orderrec.ParentPackageId,
				PackageItemId = orderrec.PackageItemId,
				PackageItemTypeId = orderrec.PackageItemType?.ItemId,
				CostCondition = (short?)orderrec.CostCondition,
				ProductId = orderrec.ProductId,
				ProductType = orderrec.ProductType?.ItemId,
				PerfNumFromStart = orderrec.PerformanceNumFromStart,
				PerfNumFromRecord = orderrec.PerformanceNumFromRecord,
				FromRecordId = orderrec.FromRecordId,
				IsClosed = orderrec.IsClosed,
				IsSchedule = orderrec.IsSchedule,
				Remarks = orderrec.Remarks
			};
		}

		public static InitialOrderRecord Convert(this InitialOrderRecordDTO orderrecdto)

		{
			return new InitialOrderRecord()
			{
				ItemId = orderrecdto.ItemId,
				IsDeleted = orderrecdto.IsDeleted,
				Priority = Priority.GetItemById(orderrecdto.Priority),
				InitialReason = orderrecdto.InitialReason.HasValue ? InitialReason.Items.GetItemById(orderrecdto.InitialReason.Value) : InitialReason.Unknown,
				DestinationObjectId = orderrecdto.DestinationObjectID ?? default(int),
				DestinationObjectType = orderrecdto.DestinationObjectType.HasValue ? SmartCoreType.Items.GetItemById(orderrecdto.DestinationObjectType.Value) : SmartCoreType.Unknown,
				Measure = orderrecdto.Measure.HasValue ? Measure.Items.GetItemById(orderrecdto.Measure.Value) : Measure.Unknown,
				Quantity = orderrecdto.Quantity ?? default(double),
				DeferredCategory = orderrecdto.DeferredCategory?.Convert(),
				EffectiveDate = orderrecdto.EffectiveDate ?? DateTimeExtend.GetCASMinDateTime(),
				LifeLimit = Lifelength.ConvertFromByteArray(orderrecdto.LifeLimit),
				LifeLimitNotify = Lifelength.ConvertFromByteArray(orderrecdto.LifeLimitNotify),
				Processed = orderrecdto.Processed ?? default(bool),
				ParentPackageId = orderrecdto.ParentPackageId ?? default(int),
				PackageItemId = orderrecdto.PackageItemId ?? default(int),
				PackageItemType = orderrecdto.PackageItemTypeId.HasValue ? SmartCoreType.Items.GetItemById(orderrecdto.PackageItemTypeId.Value) : SmartCoreType.Unknown,
				CostCondition = orderrecdto.CostCondition.HasValue ? (ComponentStatus)orderrecdto.CostCondition.Value : ComponentStatus.Unknown,
				ProductId = orderrecdto.ProductId ?? default(int),
				ProductType = orderrecdto.ProductType.HasValue ? SmartCoreType.Items.GetItemById(orderrecdto.ProductType.Value) : SmartCoreType.Unknown,
				PerformanceNumFromStart = orderrecdto.PerfNumFromStart ?? default(int),
				PerformanceNumFromRecord = orderrecdto.PerfNumFromRecord ?? default(int),
				Remarks = orderrecdto.Remarks,
				FromRecordId = orderrecdto.FromRecordId ?? default(int),
				IsClosed = orderrecdto.IsClosed ?? default(bool),
				IsSchedule = orderrecdto.IsSchedule ?? default(bool)
			};

		}


		public static ItemsRelationDTO Convert(this ItemsRelation itemsrel)

		{
			return new ItemsRelationDTO
			{
				ItemId = itemsrel.ItemId,
				IsDeleted = itemsrel.IsDeleted,

				FirstItemId = itemsrel.FirstItemId,
				FirtsItemTypeId = itemsrel.FirtsItemTypeId,
				SecondItemId = itemsrel.SecondItemId,

				SecondItemTypeId = itemsrel.SecondItemTypeId,
				RelationTypeId = (int)itemsrel.RelationTypeId
			};

		}

		public static ItemsRelation Convert(this ItemsRelationDTO itemsreldto)
		{
			return new ItemsRelation()
			{

				ItemId = itemsreldto.ItemId,
				IsDeleted = itemsreldto.IsDeleted,
				FirstItemId = itemsreldto.FirstItemId,
				FirtsItemTypeId = itemsreldto.FirtsItemTypeId,
				SecondItemId = itemsreldto.SecondItemId,
				SecondItemTypeId = itemsreldto.SecondItemTypeId,
				RelationTypeId = (WorkItemsRelationType)itemsreldto.RelationTypeId
			};
		}

		
		public static KitSuppliersRelationDTO Convert(this KitSuppliersRelation supprelation)
		{
			return new KitSuppliersRelationDTO
			{
				ItemId = supprelation.ItemId,
				IsDeleted = supprelation.IsDeleted,
				KitId = supprelation.KitId,
				SupplierId = supprelation.SupplierId,
				ParentTypeId = supprelation.ParentTypeId,
				CostNew = supprelation.CostNew,

				CostOverhaul = supprelation.CostOverhaul,
				CostServiceable = supprelation.CostServiceable,

			};
		}

		public static KitSuppliersRelation Convert(this KitSuppliersRelationDTO supprelationdto)
		{
			return new KitSuppliersRelation()
			{
				ItemId = supprelationdto.ItemId,
				IsDeleted = supprelationdto.IsDeleted,
				KitId = supprelationdto.KitId,
				ParentTypeId = supprelationdto.ParentTypeId ?? default(int),
				CostNew = supprelationdto.CostNew ?? default(double),
				CostOverhaul = supprelationdto.CostOverhaul ?? default(double),
				SupplierID = supprelationdto.SupplierId ?? default(int),
				CostServiceable = supprelationdto.CostServiceable ?? default(double),
				Supplier = supprelationdto.Supplier?.Convert()
			};
		}

		public static KnowledgeModuleDTO Convert(this KnowledgeModule knowmod)
		{
			return new KnowledgeModuleDTO
			{
				ItemId = knowmod.ItemId,
				IsDeleted = knowmod.IsDeleted,
				Number = knowmod.Number,

				Title = knowmod.Title,
				Description = knowmod.Description

			};

		}

		public static KnowledgeModule Convert(this KnowledgeModuleDTO knowmoddto)
		{
			return new KnowledgeModule()
			{
				ItemId = knowmoddto.ItemId,
				IsDeleted = knowmoddto.IsDeleted,
				Number = knowmoddto.Number,
				Title = knowmoddto.Title,

				Description = knowmoddto.Description
			};
		}

		public static LandingGearConditionDTO Convert(this LandingGearCondition gearcondition)
		{
			return new LandingGearConditionDTO
			{
				ItemId = gearcondition.ItemId,
				IsDeleted = gearcondition.IsDeleted,
				FlightID = gearcondition.FlightId,

				LandingGearID = gearcondition.LandingGearId,
				TirePressure1 = gearcondition.TirePressure1,
				TirePressure2 = gearcondition.TirePressure2,

				RecordDate = gearcondition.RecordDate
			};
		}

		public static LandingGearCondition Convert(this LandingGearConditionDTO gearconditiondto)
		{
			return new LandingGearCondition()

			{
				ItemId = gearconditiondto.ItemId,
				IsDeleted = gearconditiondto.IsDeleted,
				FlightId = gearconditiondto.FlightID,
				LandingGearId = gearconditiondto.LandingGearID,
				TirePressure1 = gearconditiondto.TirePressure1 ?? default(double),
				TirePressure2 = gearconditiondto.TirePressure2 ?? default(double),
				RecordDate = gearconditiondto.RecordDate ?? DateTimeExtend.GetCASMinDateTime()
			};
		}


		public static MaintenanceCheckBindTaskRecordDTO Convert(this MaintenanceCheckBindTaskRecord maincbtrec)
		{
			return new MaintenanceCheckBindTaskRecordDTO
			{
				ItemId = maincbtrec.ItemId,
				IsDeleted = maincbtrec.IsDeleted,
				CheckId = maincbtrec.CheckId,
				CheckPerformaceNum = maincbtrec.CheckPerformaceNum,
				CheckPerformaceGroupNum = maincbtrec.CheckPerformaceGroupNum,

				TaskId = maincbtrec.TaskId,
				TaskTypeId = maincbtrec.TaskType?.ItemId,
				TaskPerfNumFromStart = maincbtrec.TaskPerformanceNumFromStart,
				TaskPerfNumFromRecord = maincbtrec.TaskPerformanceNumFromRecord,
				TaskFromRecordId = maincbtrec.TaskFromRecordId,
				WorkPackageId = maincbtrec.WorkPackageId

			};
		}

		public static MaintenanceCheckBindTaskRecord Convert(this MaintenanceCheckBindTaskRecordDTO maincbtrecdto)
		{
			return new MaintenanceCheckBindTaskRecord()

			{
				ItemId = maincbtrecdto.ItemId,

				IsDeleted = maincbtrecdto.IsDeleted,
				CheckId = maincbtrecdto.CheckId ?? default(int),

				CheckPerformaceNum = maincbtrecdto.CheckPerformaceNum ?? default(int),
				CheckPerformaceGroupNum = maincbtrecdto.CheckPerformaceGroupNum ?? default(int),
				TaskId = maincbtrecdto.TaskId ?? default(int),
				TaskType = maincbtrecdto.TaskTypeId.HasValue ? SmartCoreType.Items.GetItemById(maincbtrecdto.TaskTypeId.Value) : SmartCoreType.Unknown,
				TaskPerformanceNumFromStart = maincbtrecdto.TaskPerfNumFromStart ?? default(int),

				TaskPerformanceNumFromRecord = maincbtrecdto.TaskPerfNumFromRecord ?? default(int),
				TaskFromRecordId = maincbtrecdto.TaskFromRecordId ?? default(int),
				WorkPackageId = maincbtrecdto.WorkPackageId ?? default(int)
			};

		}

		public static MaintenanceCheckDTO Convert(this MaintenanceCheck maincheck)
		{
			return new MaintenanceCheckDTO

			{
				ItemId = maincheck.ItemId,
				IsDeleted = maincheck.IsDeleted,

				Name = maincheck.Name,
				Interval = maincheck.Interval?.ConvertToByteArray(),
				Notify = maincheck.Notify?.ConvertToByteArray(),
				ParentAircraft = maincheck.ParentAircraftId,
				CheckTypeId = maincheck.CheckType?.ItemId ?? -1,
				Cost = maincheck.Cost,
				ManHours = maincheck.ManHours,
				Schedule = maincheck.Schedule,

				Resource = (short)maincheck.Resource,
				Grouping = maincheck.Grouping,
				PerformanceRecords = maincheck.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = maincheck.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = maincheck.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,
				BindMpds = maincheck.BindMpds?.Select(i => i.Convert()) as ICollection<MaintenanceDirectiveDTO>
			};
		}


		public static MaintenanceCheck Convert(this MaintenanceCheckDTO maincheckdto)

		{
			var value = new MaintenanceCheck()
			{
				ItemId = maincheckdto.ItemId,
				IsDeleted = maincheckdto.IsDeleted,
				Name = maincheckdto.Name,

				Interval = Lifelength.ConvertFromByteArray(maincheckdto.Interval),
				Notify = Lifelength.ConvertFromByteArray(maincheckdto.Notify),
				ParentAircraftId = maincheckdto.ParentAircraft,
				CheckType = maincheckdto.CheckType?.Convert(),
				Cost = maincheckdto.Cost ?? default(double),
				ManHours = maincheckdto.ManHours ?? default(double),
				Schedule = maincheckdto.Schedule ?? default(bool),
				Resource = (LifelengthSubResource)maincheckdto.Resource,
				Grouping = maincheckdto.Grouping
			};

			if (maincheckdto.PerformanceRecords != null)
			{
				foreach (var record in maincheckdto.PerformanceRecords)
					value.PerformanceRecords.Add(record.ConvertToMaintenanceCheckRecord());
			}

			if (maincheckdto.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(maincheckdto.CategoriesRecords.Select(i => i.Convert()));

			if (maincheckdto.Kits != null)
			{
				foreach (var dto in maincheckdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}
			}



			if (maincheckdto.BindMpds != null)
				value.BindMpds.AddRange(maincheckdto.BindMpds.Select(i => i.Convert()));

			return value;
		}

		public static MaintenanceCheckTypeDTO Convert(this MaintenanceCheckType mainchecktype)

		{
			return new MaintenanceCheckTypeDTO
			{
				ItemId = mainchecktype.ItemId,
				IsDeleted = mainchecktype.IsDeleted,
				Name = mainchecktype.FullName,
				Priority = mainchecktype.Priority,

				ShortName = mainchecktype.ShortName,
			};

		}


		public static MaintenanceCheckType Convert(this MaintenanceCheckTypeDTO mainchecktypedto)
		{
			return new MaintenanceCheckType()
			{
				ItemId = mainchecktypedto.ItemId,
				IsDeleted = mainchecktypedto.IsDeleted,
				FullName = mainchecktypedto.Name,
				Priority = mainchecktypedto.Priority ?? default(int),

				ShortName = mainchecktypedto.ShortName
			};
		}


		public static ModuleRecordDTO Convert(this ModuleRecord modulerec)
		{

			return new ModuleRecordDTO
			{
				ItemId = modulerec.ItemId,
				IsDeleted = modulerec.IsDeleted,

				AircraftWorkerCategoryId = modulerec.AircraftWorkerCategory?.ItemId,

				KnowledgeModuleId = modulerec.KnowledgeModule?.ItemId,
				KnowledgeLevel = modulerec.KnowledgeLevel,
			};
		}

		public static ModuleRecord Convert(this ModuleRecordDTO modulerecdto)
		{
			return new ModuleRecord()
			{
				ItemId = modulerecdto.ItemId,
				IsDeleted = modulerecdto.IsDeleted,
				AircraftWorkerCategory = modulerecdto.AircraftWorkerCategory?.Convert(),
				KnowledgeModule = modulerecdto.KnowledgeModule?.Convert(),
				KnowledgeLevel = modulerecdto.KnowledgeLevel ?? default(int)
			};

		}

		public static MTOPCheckDTO Convert(this MTOPCheck mtop)
		{
			return new MTOPCheckDTO
			{
				ItemId = mtop.ItemId,
				IsDeleted = mtop.IsDeleted,
				Name = mtop.Name,
				ParentAircraftId = mtop.ParentAircraftId,
				IsZeroPhase = mtop.IsZeroPhase,
				CheckTypeId = mtop.CheckType?.ItemId ?? -1,
				Thresh = mtop.Thresh?.ConvertToByteArray(),

				Repeat = mtop.Repeat?.ConvertToByteArray(),

				Notify = mtop.Notify?.ConvertToByteArray(),
				PerformanceRecords = mtop.PerformanceRecords?.Select(i => i.Convert()) as ICollection<MTOPCheckRecordDTO>
			};

		}

		public static MTOPCheck Convert(this MTOPCheckDTO mtopdto)
		{
			var value = new MTOPCheck()

			{
				ItemId = mtopdto.ItemId,
				IsDeleted = mtopdto.IsDeleted,
				Name = mtopdto.Name,

				IsZeroPhase = mtopdto.IsZeroPhase,
				ParentAircraftId = mtopdto.ParentAircraftId,
				CheckType = mtopdto.CheckType?.Convert(),

				Thresh = Lifelength.ConvertFromByteArray(mtopdto.Thresh),
				Repeat = Lifelength.ConvertFromByteArray(mtopdto.Repeat),
				Notify = Lifelength.ConvertFromByteArray(mtopdto.Notify)
			};

			if (mtopdto.PerformanceRecords != null)
				value.PerformanceRecords.AddRange(mtopdto.PerformanceRecords.Select(i => i.Convert()));

			return value;
		}

		public static MTOPCheckRecordDTO Convert(this MTOPCheckRecord mtopcheckrec)
		{
			return new MTOPCheckRecordDTO
			{
				ItemId = mtopcheckrec.ItemId,

				IsDeleted = mtopcheckrec.IsDeleted,
				CheckName = mtopcheckrec.CheckName,

				Remarks = mtopcheckrec.Remarks,
				RecordDate = mtopcheckrec.RecordDate,
				GroupName = mtopcheckrec.GroupName,
				ParentId = mtopcheckrec.ParentId,
				IsControlPoint = mtopcheckrec.IsControlPoint,
				CalculatedPerformanceSource = mtopcheckrec.CalculatedPerformanceSource?.ConvertToByteArray(),
				AverageUtilization = mtopcheckrec.AverageUtilization?.ConvertToByteArray()
			};

		}

		public static MTOPCheckRecord Convert(this MTOPCheckRecordDTO mtopcheckrecdto)
		{

			return new MTOPCheckRecord()
			{
				ItemId = mtopcheckrecdto.ItemId,
				IsDeleted = mtopcheckrecdto.IsDeleted,
				CheckName = mtopcheckrecdto.CheckName,
				Remarks = mtopcheckrecdto.Remarks,
				RecordDate = mtopcheckrecdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				GroupName = mtopcheckrecdto.GroupName ?? default(int),
				ParentId = mtopcheckrecdto.ParentId ?? default(int),
				IsControlPoint = mtopcheckrecdto.IsControlPoint,
				CalculatedPerformanceSource = Lifelength.ConvertFromByteArray(mtopcheckrecdto.CalculatedPerformanceSource),
				AverageUtilization = AverageUtilization.ConvertFromByteArray(mtopcheckrecdto.AverageUtilization)
			};

		}

		public static ProcedureDocumentReferenceDTO Convert(this ProcedureDocumentReference docreference)
		{
			return new ProcedureDocumentReferenceDTO
			{

				ItemId = docreference.ItemId,

				IsDeleted = docreference.IsDeleted,
				ProcedureId = docreference.Procedure?.ItemId,
				DocumentId = docreference.Document?.ItemId,
			};
		}

		public static ProcedureDocumentReference Convert(this ProcedureDocumentReferenceDTO docreferencedto)
		{
			return new ProcedureDocumentReference()
			{
				ItemId = docreferencedto.ItemId,
				IsDeleted = docreferencedto.IsDeleted,
				Procedure = docreferencedto.Procedure?.Convert(),
				Document = docreferencedto.Document?.Convert()
			};
		}


		public static ProcedureDTO Convert(this Procedure procedure)
		{

			return new ProcedureDTO
			{

				ItemId = procedure.ItemId,
				IsDeleted = procedure.IsDeleted,
				Title = procedure.Title,
				ProcedureTypeId = procedure.ProcedureType?.ItemId,
				Applicability = procedure.Applicability,
				OperatorId = procedure.ParentOperator?.ItemId,
				AuditedObjectId = procedure.AuditedObjectId,
				AuditedObjectTypeId = procedure.AuditedObjectType?.ItemId,
				Description = procedure.Description,

				CheckList = procedure.CheckList,
				CheckListFileId = procedure.CheckListFile?.ItemId,
				ProcedureFileId = procedure.ProcedureFile?.ItemId,
				JobCardId = procedure.JobCard?.ItemId,
				Threshold = procedure.Threshold?.ToBinary(),
				Remarks = procedure.Remarks,
				HiddenRemarks = procedure.HiddenRemarks,
				IsClosed = procedure.IsClosed,
				ManHours = procedure.ManHours,
				Elapsed = procedure.Elapsed,
				Cost = procedure.Cost,
				PrintInWP = procedure.PrintInWorkPackage,
				ProcedureRatingId = procedure.ProcedureRating?.ItemId,
				Level = procedure.Level,
				AuditedObject = procedure.AuditedObject,
				PerformanceRecords = procedure.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,

				Files = procedure.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,

				Kits = procedure.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,
				DocumentReferences = procedure.DocumentReferences?.Select(i => i.Convert()) as ICollection<ProcedureDocumentReferenceDTO>
			};
		}

		public static Procedure Convert(this ProcedureDTO proceduredto)
		{
			var value = new Procedure()
			{
				ItemId = proceduredto.ItemId,
				IsDeleted = proceduredto.IsDeleted,

				Title = proceduredto.Title,
				ProcedureType = proceduredto.ProcedureTypeId.HasValue ? ProcedureType.Items.GetItemById(proceduredto.ProcedureTypeId.Value) : ProcedureType.Unknown,
				Applicability = proceduredto.Applicability,
				AuditedObjectId = proceduredto.AuditedObjectId ?? default(int),
				AuditedObjectType = proceduredto.AuditedObjectTypeId.HasValue ? SmartCoreType.Items.GetItemById(proceduredto.AuditedObjectTypeId.Value) : SmartCoreType.Unknown,
				Description = proceduredto.Description,

				CheckList = proceduredto.CheckList,

				JobCard = proceduredto.JobCard?.Convert(),
				Threshold = MaintenanceDirectiveThreshold.ConvertFromByteArray(proceduredto.Threshold),
				Remarks = proceduredto.Remarks,
				HiddenRemarks = proceduredto.HiddenRemarks,
				IsClosed = proceduredto.IsClosed ?? default(bool),

				ManHours = proceduredto.ManHours ?? default(double),
				Elapsed = proceduredto.Elapsed ?? default(double),
				Cost = proceduredto.Cost ?? default(double),

				PrintInWorkPackage = proceduredto.PrintInWP ?? default(bool),
				ProcedureRating = proceduredto.ProcedureRatingId.HasValue ? ProcedureRating.Items.GetItemById(proceduredto.ProcedureRatingId.Value) : ProcedureRating.Unknown,

				Level = proceduredto.Level ?? default(int),

				AuditedObject = proceduredto.AuditedObject
			};

			if (proceduredto.PerformanceRecords != null)
			{
				foreach (var dto in proceduredto.PerformanceRecords)
				{
					var record = dto.Convert();
					record.Parent = value;
					value.PerformanceRecords.Add(record);

				}

			}

			if (proceduredto.Files != null)

				value.Files.AddRange(proceduredto.Files.Select(i => i.Convert()));

			if (proceduredto.Kits != null)
			{
				foreach (var dto in proceduredto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;

					value.Kits.Add(directive);
				}

			}

			if (proceduredto.DocumentReferences != null)

				value.DocumentReferences.AddRange(proceduredto.DocumentReferences.Select(i => i.Convert()));

			return value;

		}

		public static ProductCostDTO Convert(this ProductCost prodcost)
		{
			return new ProductCostDTO
			{
				ItemId = prodcost.ItemId,
				IsDeleted = prodcost.IsDeleted,
				SupplierId = prodcost.SupplierId,
				KitId = prodcost.KitId,
				ParentId = prodcost.ParentId,
				ParentTypeId = prodcost.ParentTypeId,
				QtyIn = prodcost.QtyIn,

				UnitPrice = prodcost.UnitPrice,
				TotalPrice = prodcost.TotalPrice,
				ShipPrice = prodcost.ShipPrice,
				SubTotal = prodcost.SubTotal,
				Tax = prodcost.Tax,
				Tax1 = prodcost.Tax1,

				Tax2 = prodcost.Tax2,
				Total = prodcost.Total,
				CurrencyId = prodcost.Currency?.ItemId
			};
		}


		public static ProductCost Convert(this ProductCostDTO prodcostdto)

		{
			return new ProductCost()
			{

				ItemId = prodcostdto.ItemId,
				IsDeleted = prodcostdto.IsDeleted,

				SupplierId = prodcostdto.SupplierId ?? default(int),
				KitId = prodcostdto.KitId ?? default(int),
				ParentId = prodcostdto.ParentId,
				ParentTypeId = prodcostdto.ParentTypeId ?? default(int),
				QtyIn = prodcostdto.QtyIn ?? default(double),
				UnitPrice = prodcostdto.UnitPrice ?? default(double),
				TotalPrice = prodcostdto.TotalPrice ?? default(double),
				ShipPrice = prodcostdto.ShipPrice ?? default(double),
				SubTotal = prodcostdto.SubTotal ?? default(double),
				Tax = prodcostdto.Tax ?? default(double),
				Tax1 = prodcostdto.Tax1 ?? default(double),
				Tax2 = prodcostdto.Tax2 ?? default(double),

				Total = prodcostdto.Total ?? default(double),
				Currency = prodcostdto.CurrencyId.HasValue ? Сurrency.Items.GetItemById(prodcostdto.CurrencyId.Value) : Сurrency.UNK
			};
		}

		public static PurchaseOrderDTO Convert(this PurchaseOrder purchase)
		{
			return new PurchaseOrderDTO
			{
				ItemId = purchase.ItemId,
				IsDeleted = purchase.IsDeleted,
				Title = purchase.Title,
				Description = purchase.Description,
				ParentID = purchase.ParentId,
				ParentQuotationId = purchase.ParentQuotationId,
				Status = (int)purchase.Status,
				OpeningDate = purchase.OpeningDate,
				PublishingDate = purchase.PublishingDate,
				ClosingDate = purchase.ClosingDate,
				Author = purchase.Author,
				Remarks = purchase.Remarks,
				ParentTypeId = purchase.ParentType?.ItemId,
				SupplierId = purchase.Supplier?.ItemId,

				Files = purchase.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static PurchaseOrder Convert(this PurchaseOrderDTO purchasedto)

		{
			var value = new PurchaseOrder()
			{
				ItemId = purchasedto.ItemId,
				IsDeleted = purchasedto.IsDeleted,
				Title = purchasedto.Title,
				Description = purchasedto.Description,
				ParentId = purchasedto.ParentID ?? default(int),
				ParentQuotationId = purchasedto.ParentQuotationId ?? default(int),

				Status = purchasedto.Status.HasValue ? (WorkPackageStatus)purchasedto.Status.Value : WorkPackageStatus.All,
				OpeningDate = purchasedto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishingDate = purchasedto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = purchasedto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				Author = purchasedto.Author,
				Remarks = purchasedto.Remarks,
				ParentType = purchasedto.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(purchasedto.ParentTypeId.Value) : SmartCoreType.Unknown,
				Supplier = purchasedto.Supplier?.Convert()
			};

			if (purchasedto.Files != null)
				value.Files.AddRange(purchasedto.Files.Select(i => i.Convert()));

			return value;
		}

		public static PurchaseRequestRecordDTO Convert(this PurchaseRequestRecord purchaserec)
		{
			return new PurchaseRequestRecordDTO

			{
				ItemId = purchaserec.ItemId,
				IsDeleted = purchaserec.IsDeleted,
				ParentPackageId = purchaserec.ParentPackageId,

				PackageItemId = purchaserec.PackageItemId,

				PackageItemTypeId = purchaserec.PackageItemType?.ItemId,
				SupplierId = purchaserec.Supplier?.ItemId,
				Remarks = purchaserec.Remarks,
				Quantity = purchaserec.Quantity,
				Measure = purchaserec.Measure?.ItemId,
				Cost = purchaserec.Cost,
				CostCondition = (short?)purchaserec.CostCondition,
				Processed = purchaserec.Processed,
				Files = purchaserec.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}

		public static PurchaseRequestRecord Convert(this PurchaseRequestRecordDTO purchaserecdto)
		{
			var value = new PurchaseRequestRecord()
			{
				ItemId = purchaserecdto.ItemId,
				IsDeleted = purchaserecdto.IsDeleted,
				ParentPackageId = purchaserecdto.ParentPackageId ?? default(int),
				PackageItemId = purchaserecdto.PackageItemId ?? default(int),
				PackageItemType = purchaserecdto.PackageItemTypeId.HasValue ? SmartCoreType.Items.GetItemById(purchaserecdto.PackageItemTypeId.Value) : SmartCoreType.Unknown,
				Supplier = purchaserecdto.Supplier?.Convert(),

				Remarks = purchaserecdto.Remarks,
				Quantity = purchaserecdto.Quantity ?? default(double),
				Measure = purchaserecdto.Measure.HasValue ? Measure.Items.GetItemById(purchaserecdto.Measure.Value) : Measure.Unknown,
				Cost = purchaserecdto.Cost ?? default(double),
				CostCondition = purchaserecdto.CostCondition.HasValue ? (ComponentStatus)purchaserecdto.CostCondition.Value : ComponentStatus.Unknown,
				Processed = purchaserecdto.Processed ?? default(bool)
			};

			if (purchaserecdto.Files != null)
				value.Files.AddRange(purchaserecdto.Files.Select(i => i.Convert()));

			return value;
		}


		public static RequestDTO Convert(this Request request)
		{
			return new RequestDTO
			{
				ItemId = request.ItemId,
				IsDeleted = request.IsDeleted,
				PreparedByDate = request.PreparedByDate,
				PreparedById = request.PreparedBy?.ItemId,
				CheckedByDate = request.CheckedByDate,
				CheckedById = request.CheckedBy?.ItemId,
				ApprovedByDate = request.ApprovedByDate,
				ApprovedById = request.ApprovedBy?.ItemId,
				RequestdHeader = request.RequestHeader,
				RequestFooter = request.RequestFooter,
				Number = request.Number,
				Title = request.Title,
				Description = request.Description,
				ParentId = request.ParentId,
				Status = (short)request.Status,
				CreateDate = request.CreateDate,
				OpeningDate = request.OpeningDate,
				PublishingDate = request.PublishingDate,
				ClosingDate = request.ClosingDate,
				FileId = request.AttachedFile?.ItemId,
				PublishedBy = request.PublishedBy,
				ClosedBy = request.ClosedBy,
				Remarks = request.Remarks,
				PublishingRemarks = request.PublishingRemarks,
				ClosingRemarks = request.ClosingRemarks,
				Kits = request.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,

				PackageRecords = request.PackageRecords?.Select(i => i.Convert()) as ICollection<RequestRecordDTO>
			};
		}

		public static Request Convert(this RequestDTO requestdto)
		{
			var value = new Request()
			{
				ItemId = requestdto.ItemId,

				IsDeleted = requestdto.IsDeleted,
				PreparedByDate = requestdto.PreparedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				PreparedBy = requestdto.PreparedBy?.Convert(),
				CheckedByDate = requestdto.CheckedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				CheckedBy = requestdto.CheckedBy?.Convert(),
				ApprovedByDate = requestdto.ApprovedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				ApprovedBy = requestdto.ApprovedBy?.Convert(),
				RequestHeader = requestdto.RequestdHeader,
				RequestFooter = requestdto.RequestFooter,
				Number = requestdto.Number,
				Title = requestdto.Title,
				Description = requestdto.Description,
				ParentId = requestdto.ParentId ?? default(int),
				Status = requestdto.Status.HasValue ? (WorkPackageStatus)requestdto.Status.Value : WorkPackageStatus.All,
				CreateDate = requestdto.CreateDate ?? DateTimeExtend.GetCASMinDateTime(),
				OpeningDate = requestdto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishingDate = requestdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = requestdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishedBy = requestdto.PublishedBy,
				ClosedBy = requestdto.ClosedBy,
				Remarks = requestdto.Remarks,

				PublishingRemarks = requestdto.PublishingRemarks,
				ClosingRemarks = requestdto.ClosingRemarks

			};

			if (requestdto.Kits != null)
			{
				foreach (var dto in requestdto.Kits)
				{

					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}

			}

			if (requestdto.PackageRecords != null)
				value.PackageRecords.AddRange(requestdto.PackageRecords.Select(i => i.Convert()));

			return value;
		}


		public static RequestForQuotationDTO Convert(this RequestForQuotation reqquotation)
		{
			return new RequestForQuotationDTO
			{

				ItemId = reqquotation.ItemId,
				IsDeleted = reqquotation.IsDeleted,
				PublishedById = reqquotation.PublishedById,
				ClosedById = reqquotation.ClosedById,
				Title = reqquotation.Title,
				Description = reqquotation.Description,
				ParentId = reqquotation.ParentId,
				Status = (short)reqquotation.Status,
				OpeningDate = reqquotation.OpeningDate,
				PublishingDate = reqquotation.PublishingDate,
				ClosingDate = reqquotation.ClosingDate,
				Author = reqquotation.Author,
				Remarks = reqquotation.Remarks,
				PublishedByUser = reqquotation.PublishedByUser,
				CloseByUser = reqquotation.CloseByUser,
				ParentTypeId = reqquotation.ParentType?.ItemId,
				Number = reqquotation.Number,
				Files = reqquotation.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PackageRecords = reqquotation.PackageRecords?.Select(i => i.Convert()) as ICollection<RequestForQuotationRecordDTO>
			};
		}

		public static RequestForQuotation Convert(this RequestForQuotationDTO reqquotationdto)
		{
			var value = new RequestForQuotation()
			{
				ItemId = reqquotationdto.ItemId,
				IsDeleted = reqquotationdto.IsDeleted,
				Title = reqquotationdto.Title,
				PublishedById = reqquotationdto.PublishedById,
				ClosedById = reqquotationdto.ClosedById,
				Description = reqquotationdto.Description,
				ParentId = reqquotationdto.ParentId ?? default(int),
				Status = reqquotationdto.Status.HasValue ? (WorkPackageStatus)reqquotationdto.Status.Value : WorkPackageStatus.All,
				OpeningDate = reqquotationdto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishingDate = reqquotationdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = reqquotationdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				Author = reqquotationdto.Author,
				Remarks = reqquotationdto.Remarks,
				PublishedByUser = reqquotationdto.PublishedByUser,
				CloseByUser = reqquotationdto.CloseByUser,
				Number = reqquotationdto.Number,
				ParentType = reqquotationdto.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(reqquotationdto.ParentTypeId.Value) : SmartCoreType.Unknown,
			};

			if (reqquotationdto.Files != null)
				value.Files.AddRange(reqquotationdto.Files.Select(i => i.Convert()));

			if (reqquotationdto.PackageRecords != null)

				value.PackageRecords.AddRange(reqquotationdto.PackageRecords.Select(i => i.Convert()));


			return value;
		}

		public static RequestForQuotationRecordDTO Convert(this RequestForQuotationRecord quotationrecord)
		{
			return new RequestForQuotationRecordDTO
			{
				ItemId = quotationrecord.ItemId,
				IsDeleted = quotationrecord.IsDeleted,
				ParentPackageId = quotationrecord.ParentPackageId,
				PackageItemId = quotationrecord.PackageItemId,
				CostCondition = (short)quotationrecord.CostCondition,
				Processed = quotationrecord.Processed,
				PackageItemTypeId = quotationrecord.PackageItemType?.ItemId,
				Quantity = quotationrecord.Quantity,
				Measure = quotationrecord.Measure?.ItemId,
				CostNew = quotationrecord.CostNew,
				CostOverhaul = quotationrecord.CostOverhaul,
				CostServiceable = quotationrecord.CostServiceable,
				Priority = quotationrecord.Priority.ItemId,
				DestinationObjectId = quotationrecord.DestinationObjectId,
				DefferedCategoryId = quotationrecord.DeferredCategory.ItemId,
				InitialReason = quotationrecord.InitialReason.ItemId,
				DestinationObjectType = quotationrecord.DestinationObjectType.ItemId,
				LifeLimit = quotationrecord.LifeLimit?.ConvertToByteArray(),
				LifeLimitNotify = quotationrecord.LifeLimitNotify?.ConvertToByteArray(),
				SettingJSON = quotationrecord.SettingJSON,
				Remarks = quotationrecord.Remarks
			};
		}

		public static RequestForQuotationRecord Convert(this RequestForQuotationRecordDTO quotationrecorddto)
		{
			return new RequestForQuotationRecord()
			{
				ItemId = quotationrecorddto.ItemId,
				IsDeleted = quotationrecorddto.IsDeleted,
				ParentPackageId = quotationrecorddto.ParentPackageId,
				PackageItemId = quotationrecorddto.PackageItemId,
				CostCondition = (ComponentStatus)quotationrecorddto.CostCondition,
				Processed = quotationrecorddto.Processed,
				PackageItemType = quotationrecorddto.PackageItemTypeId.HasValue ? SmartCoreType.Items.GetItemById(quotationrecorddto.PackageItemTypeId.Value) : SmartCoreType.Unknown,
				Quantity = quotationrecorddto.Quantity ?? default(double),
				Measure = quotationrecorddto.Measure.HasValue ? Measure.Items.GetItemById(quotationrecorddto.Measure.Value) : Measure.Unknown,
				CostNew = quotationrecorddto.CostNew ?? default(double),
				CostOverhaul = quotationrecorddto.CostOverhaul ?? default(double),
				CostServiceable = quotationrecorddto.CostServiceable ?? default(double),
				Priority = Priority.GetItemById(quotationrecorddto.Priority),
				DestinationObjectId = quotationrecorddto.DestinationObjectId,
				DeferredCategory = quotationrecorddto.DefferedCategory?.Convert(),
				InitialReason = InitialReason.GetItemById(quotationrecorddto.InitialReason),
				DestinationObjectType = SmartCoreType.GetSmartCoreTypeById(quotationrecorddto.DestinationObjectType),
				LifeLimit = Lifelength.ConvertFromByteArray(quotationrecorddto.LifeLimit),
				LifeLimitNotify = Lifelength.ConvertFromByteArray(quotationrecorddto.LifeLimitNotify),
				SettingJSON = quotationrecorddto.SettingJSON,
				Remarks = quotationrecorddto.Remarks
			};
		}

		public static RequestRecordDTO Convert(this RequestRecord requestrec)
		{
			return new RequestRecordDTO

			{
				ItemId = requestrec.ItemId,
				IsDeleted = requestrec.IsDeleted,
				ParentId = requestrec.ParentId,
				DirectivesId = requestrec.DirectiveId,
				PackageItemTypeId = requestrec.PackageItemType?.ItemId
			};
		}


		public static RequestRecord Convert(this RequestRecordDTO requestrecdto)
		{

			return new RequestRecord()
			{
				ItemId = requestrecdto.ItemId,

				IsDeleted = requestrecdto.IsDeleted,
				ParentId = requestrecdto.ParentId ?? default(int),
				DirectiveId = requestrecdto.DirectivesId ?? default(int),
				PackageItemType = requestrecdto.PackageItemTypeId.HasValue ? SmartCoreType.Items.GetItemById(requestrecdto.PackageItemTypeId.Value) : SmartCoreType.Unknown
			};
		}

		public static RunUpDTO Convert(this RunUp runup)
		{
			return new RunUpDTO
			{
				ItemId = runup.ItemId,
				IsDeleted = runup.IsDeleted,
				FlightId = runup.FlightId,
				StartTime = runup.StartTime.TotalMinutes as int?,
				RunUpType = (short)runup.RunUpType,
				RunUpPhase = (short)runup.RunUpPhase,
				RunUpCondition = (short)runup.RunUpCondition,
				EndTime = runup.EndTime.TotalMinutes as int?,

				EndPhase = (short)runup.EndPhase,
				ShutDownReasonId = runup.ShutDownReasonId,
				ShutDownType = (short)runup.ShutDownType,
				LandTime = runup.LandTime.TotalMinutes as int?,

				AirTime = runup.AirTime.TotalMinutes as int?,

				RecordDate = runup.RecordDate,

				OnLifelength = runup.OnLifelength?.ConvertToByteArray(),

				BaseComponentId = runup.BaseComponentId
			};
		}

		public static RunUp Convert(this RunUpDTO runupdto)
		{

			return new RunUp()
			{
				ItemId = runupdto.ItemId,
				IsDeleted = runupdto.IsDeleted,
				FlightId = runupdto.FlightId,
				StartTime = new TimeSpan(0, runupdto.StartTime ?? 0, 0),
				RunUpType = runupdto.RunUpType.HasValue ? (RunUpType)runupdto.RunUpType.Value : RunUpType.Unknown,

				RunUpPhase = runupdto.RunUpPhase.HasValue ? (DetectionPhase)runupdto.RunUpPhase.Value : DetectionPhase.Unknown,

				RunUpCondition = runupdto.RunUpCondition.HasValue ? (RunUpCondition)runupdto.RunUpCondition.Value : RunUpCondition.Unknown,
				EndTime = new TimeSpan(0, runupdto.EndTime ?? 0, 0),
				EndPhase = runupdto.EndPhase.HasValue ? (DetectionPhase)runupdto.EndPhase.Value : DetectionPhase.Unknown,

				ShutDownReasonId = runupdto.ShutDownReasonId ?? default(int),
				ShutDownType = runupdto.ShutDownType.HasValue ? (ShutDownType)runupdto.ShutDownType.Value : ShutDownType.Unknown,

				LandTime = new TimeSpan(0, runupdto.LandTime ?? 0, 0),

				AirTime = new TimeSpan(0, runupdto.AirTime ?? 0, 0),
				RecordDate = runupdto.RecordDate ?? DateTimeExtend.GetCASMinDateTime(),
				OnLifelength = Lifelength.ConvertFromByteArray(runupdto.OnLifelength),
				BaseComponentId = runupdto.BaseComponentId ?? default(int)
			};
		}

		public static SmsEventTypeDTO Convert(this SmsEventType smsevent)
		{
			return new SmsEventTypeDTO
			{
				ItemId = smsevent.ItemId,
				IsDeleted = smsevent.IsDeleted,
				FullName = smsevent.FullName,
				Description = smsevent.Description
			};

		}

		public static SmsEventType Convert(this SmsEventTypeDTO smseventdto)
		{
			return new SmsEventType()
			{
				ItemId = smseventdto.ItemId,
				IsDeleted = smseventdto.IsDeleted,
				FullName = smseventdto.FullName,
				Description = smseventdto.Description
			};
		}
		

		public static StockComponentInfoDTO Convert(this StockComponentInfo info)
		{

			return new StockComponentInfoDTO
			{
				ItemId = info.ItemId,
				IsDeleted = info.IsDeleted,
				StoreID = info.StoreId,
				PartNumber = info.PartNumber,
				Description = info.Description,
				AccessoryDescriptionId = info.AccessoryDescription?.ItemId,
				Measure = info.Measure?.ItemId,
				GoodStandartId = info.Standart?.ItemId,
				ComponentClass = info.GoodsClass?.ItemId,

			};
		}

		public static StockComponentInfo Convert(this StockComponentInfoDTO infodto)

		{
			return new StockComponentInfo
			{
				ItemId = infodto.ItemId,
				IsDeleted = infodto.IsDeleted,
				StoreId = infodto.StoreID ?? default(int),

				PartNumber = infodto.PartNumber,
				Description = infodto.Description,
				AccessoryDescription = infodto.AccessoryDescription?.ConvertToProduct(),
				Measure = infodto.Measure.HasValue ? Measure.Items.GetItemById(infodto.Measure.Value) : Measure.Unknown,
				Standart = infodto.Standart?.Convert(),
				GoodsClass = infodto.ComponentClass.HasValue ? GoodsClass.Items.GetItemById(infodto.ComponentClass.Value) : GoodsClass.Unknown

			};
		}

		public static StoreDTO Convert(this Store store)
		{
			return new StoreDTO
			{
				ItemId = store.ItemId,
				IsDeleted = store.IsDeleted,

				OperatorID = store.OperatorId,

				StoreName = store.Name,
				Adress = store.Adress,
				Contact = store.Contact,
				Email = store.Email,
				Phone = store.Phone,
				Location = store.Location,
				Remarks = store.Remarks,
				Code = store.Code
			};
		}


		public static Store Convert(this StoreDTO storedto)
		{
			return new Store()
			{
				ItemId = storedto.ItemId,
				IsDeleted = storedto.IsDeleted,
				Adress = storedto.Adress,
				Contact = storedto.Contact,
				Email = storedto.Email,
				Phone = storedto.Phone,
				OperatorId = storedto.OperatorID,
				Name = storedto.StoreName,
				Location = storedto.Location,
				Remarks = storedto.Remarks,
				Code = storedto.Code
			};
		}

		public static SupplierDocumentDTO Convert(this SupplierDocument supplierdoc)
		{
			return new SupplierDocumentDTO
			{
				ItemId = supplierdoc.ItemId,
				IsDeleted = supplierdoc.IsDeleted,
				SupplierId = supplierdoc.SupplierId,
				Name = supplierdoc.Name,
				DocumentType = supplierdoc.DocumentType,
				Files = supplierdoc.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>
			};
		}


		public static SupplierDocument Convert(this SupplierDocumentDTO supplierdocdto)
		{

			var value = new SupplierDocument()
			{
				ItemId = supplierdocdto.ItemId,
				IsDeleted = supplierdocdto.IsDeleted,
				SupplierId = supplierdocdto.SupplierId ?? default(int),
				Name = supplierdocdto.Name,
				DocumentType = supplierdocdto.DocumentType,

				FileId = supplierdocdto.FileId ?? default(int)

			};

			if (supplierdocdto.Files != null)
				value.Files.AddRange(supplierdocdto.Files.Select(i => i.Convert()));


			return value;

		}

		public static TransferRecordDTO Convert(this TransferRecord transrec)
		{
			return new TransferRecordDTO
			{
				ItemId = transrec.ItemId,
				IsDeleted = transrec.IsDeleted,
				PreConfirmTransfer = transrec.PreConfirmTransfer,
				ParentID = transrec.ParentId,
				ParentType = transrec.ParentType?.ItemId,
				FromAircraftID = transrec.FromAircraftId,
				FromStoreID = transrec.FromStoreId,
				DestinationObjectID = transrec.DestinationObjectId,

				DestinationObjectType = transrec.DestinationObjectType?.ItemId,
				ConsumableId = transrec.ConsumableId,
				TransferDate = transrec.StartTransferDate,
				DestConfirmTransferDate = transrec.TransferDate,
				WorkPackageID = transrec.DirectivePackageId,
				PerformanceNum = transrec.PerformanceNum,

				Remarks = transrec.Remarks,
				Reference = transrec.Reference,
				PODR = transrec.PODR,

				DODR = transrec.DODR,
				Position = transrec.Position,
				FromBaseComponentID = transrec.FromBaseComponentId,
				Description = transrec.Description,

				ReasonId = transrec.Reason?.ItemId ?? -1,
				State = transrec.State?.ItemId,

				ReplaceComponentId = transrec.ReplaceComponentId,
				IsReplaceComponentRemoved = transrec.IsReplaceComponentRemoved,
				ReceivedSpecialistId = transrec.ReceivedSpecialist?.ItemId,
				ReleasedSpecialistId = transrec.ReleasedSpecialist?.ItemId,
				FromSupplierId = transrec.FromSupplierId,

				SupplierReceiptDate = transrec.SupplierReceiptDate,
				SupplierNotify = transrec.SupplierNotify?.ConvertToByteArray(),
				FromSpecialistId = transrec.FromSpecialistId,
				Files = transrec.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>

			};
		}

		public static TransferRecord Convert(this TransferRecordDTO transrecdto)
		{
			var value = new TransferRecord()
			{

				ItemId = transrecdto.ItemId,
				IsDeleted = transrecdto.IsDeleted,
				ParentId = transrecdto.ParentID,
				ParentType = transrecdto.ParentType.HasValue ? SmartCoreType.Items.GetItemById(transrecdto.ParentType.Value) : SmartCoreType.Unknown,
				FromAircraftId = transrecdto.FromAircraftID,
				FromStoreId = transrecdto.FromStoreID,

				DestinationObjectId = transrecdto.DestinationObjectID ?? default(int),
				DestinationObjectType = transrecdto.DestinationObjectType.HasValue ? SmartCoreType.Items.GetItemById(transrecdto.DestinationObjectType.Value) : SmartCoreType.Unknown,
				ConsumableId = transrecdto.ConsumableId ?? default(int),
				TransferDate = transrecdto.DestConfirmTransferDate ?? DateTimeExtend.GetCASMinDateTime(),
				StartTransferDate = transrecdto.TransferDate ?? DateTimeExtend.GetCASMinDateTime(),
				DirectivePackageId = transrecdto.WorkPackageID ?? default(int),
				PerformanceNum = transrecdto.PerformanceNum,
				Remarks = transrecdto.Remarks,
				Reference = transrecdto.Reference,
				PODR = transrecdto.PODR ?? default(bool),
				DODR = transrecdto.DODR ?? default(bool),
				PreConfirmTransfer = transrecdto.PreConfirmTransfer ?? default(bool),
				Position = transrecdto.Position,
				FromBaseComponentId = transrecdto.FromBaseComponentID,
				Description = transrecdto.Description,
				Reason = InitialReason.Items.GetItemById(transrecdto.ReasonId) ?? InitialReason.Unknown,
				State = transrecdto.State.HasValue ? ComponentStorePosition.Items.GetItemById(transrecdto.State.Value) : ComponentStorePosition.UNK,

				ReplaceComponentId = transrecdto.ReplaceComponentId,
				IsReplaceComponentRemoved = transrecdto.IsReplaceComponentRemoved,
				ReceivedSpecialist = transrecdto.ReceivedSpecialist?.Convert(),
				ReleasedSpecialist = transrecdto.ReleasedSpecialist?.Convert(),
				FromSupplierId = transrecdto.FromSupplierId,
				SupplierReceiptDate = transrecdto.SupplierReceiptDate ?? DateTimeExtend.GetCASMinDateTime(),
				SupplierNotify = Lifelength.ConvertFromByteArray(transrecdto.SupplierNotify),

				FromSpecialistId = transrecdto.FromSpecialistId

			};

			if (transrecdto.Files != null)
				value.Files.AddRange(transrecdto.Files.Select(i => i.Convert()));


			return value;
		}

		public static VehicleDTO Convert(this Vehicle vehicle)
		{
			return new VehicleDTO
			{
				ItemId = vehicle.ItemId,
				IsDeleted = vehicle.IsDeleted,
				OperatorId = vehicle.OperatorId,
				RegistrationNumber = vehicle.RegistrationNumber,
				ModelId = vehicle.Model?.ItemId,
				ManufactureDate = vehicle.ManufactureDate,
				Owner = vehicle.Owner,
				CockpitSeating = vehicle.CockpitSeating,
				DeliveryDate = vehicle.DeliveryDate,
				AcceptanceDate = vehicle.AcceptanceDate,
				Schedule = vehicle.Schedule,
			};

		}


		public static Vehicle Convert(this VehicleDTO vehicledto)
		{
			return new Vehicle()
			{
				ItemId = vehicledto.ItemId,
				IsDeleted = vehicledto.IsDeleted,
				OperatorId = vehicledto.OperatorId ?? default(int),
				RegistrationNumber = vehicledto.RegistrationNumber,

				Model = vehicledto.Model?.ConvertToAircraftModel(),
				ManufactureDate = vehicledto.ManufactureDate ?? DateTimeExtend.GetCASMinDateTime(),
				Owner = vehicledto.Owner,
				CockpitSeating = vehicledto.CockpitSeating,
				DeliveryDate = vehicledto.DeliveryDate ?? DateTimeExtend.GetCASMinDateTime(),
				AcceptanceDate = vehicledto.AcceptanceDate ?? DateTimeExtend.GetCASMinDateTime(),
				Schedule = vehicledto.Schedule ?? default(bool)
			};
		}

		public static WorkOrderDTO Convert(this WorkOrder work)

		{
			return new WorkOrderDTO
			{
				ItemId = work.ItemId,
				IsDeleted = work.IsDeleted,
				PreparedByDate = work.PreparedByDate,
				PreparedById = work.PreparedBy?.ItemId,
				CheckedByDate = work.CheckedByDate,
				CheckedById = work.CheckedBy?.ItemId,
				ApprovedByDate = work.ApprovedByDate,
				ApprovedById = work.ApprovedBy?.ItemId,
				JobCardNumber = work.JobCardNumber,
				JobCardHeader = work.JobCardHeader,
				WorkOrderFooter = work.WorkOrderFooter,

				Title = work.Title,

				Description = work.Description,
				Number = work.Number,
				ParentId = work.ParentId,
				Status = (short?)work.Status,
				CreateDate = work.CreateDate,
				OpeningDate = work.OpeningDate,
				PublishingDate = work.PublishingDate,
				ClosingDate = work.ClosingDate,
				PublishedBy = work.PublishedBy,
				ClosedBy = work.ClosedBy,
				Remarks = work.Remarks,
				PublishingRemarks = work.PublishingRemarks,
				ClosingRemarks = work.ClosingRemarks,
				Kits = work.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>,

				PackageRecords = work.Kits?.Select(i => i.Convert()) as ICollection<WorkOrderRecordDTO>
			};

		}

		public static WorkOrder Convert(this WorkOrderDTO workdto)

		{
			var value = new WorkOrder()
			{
				ItemId = workdto.ItemId,
				IsDeleted = workdto.IsDeleted,
				PreparedByDate = workdto.PreparedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				PreparedBy = workdto.PreparedBy?.Convert(),
				CheckedByDate = workdto.CheckedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				CheckedBy = workdto.CheckedBy?.Convert(),
				ApprovedByDate = workdto.ApprovedByDate ?? DateTimeExtend.GetCASMinDateTime(),
				ApprovedBy = workdto.ApprovedBy?.Convert(),
				JobCardNumber = workdto.JobCardNumber,
				JobCardHeader = workdto.JobCardHeader,
				WorkOrderFooter = workdto.WorkOrderFooter,
				Title = workdto.Title,
				Description = workdto.Description,
				Number = workdto.Number,
				ParentId = workdto.ParentId ?? default(int),
				Status = workdto.Status.HasValue ? (WorkPackageStatus)workdto.Status.Value : WorkPackageStatus.All,

				CreateDate = workdto.CreateDate ?? DateTimeExtend.GetCASMinDateTime(),
				OpeningDate = workdto.OpeningDate ?? DateTimeExtend.GetCASMinDateTime(),

				PublishingDate = workdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = workdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishedBy = workdto.PublishedBy,
				ClosedBy = workdto.ClosedBy,
				Remarks = workdto.Remarks,
				PublishingRemarks = workdto.PublishingRemarks,
				ClosingRemarks = workdto.ClosingRemarks
			};

			if (workdto.Kits != null)
			{

				foreach (var dto in workdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}

			}

			if (workdto.PackageRecords != null)
				value.PackageRecords.AddRange(workdto.PackageRecords.Select(i => i.Convert()));

			return value;
		}

		public static WorkOrderRecordDTO Convert(this WorkOrderRecord workorder)

		{
			return new WorkOrderRecordDTO
			{
				ItemId = workorder.ItemId,
				IsDeleted = workorder.IsDeleted,
				ParentId = workorder.ParentId,
				DirectivesId = workorder.DirectiveId,
				PackageItemTypeId = workorder.PackageItemType?.ItemId
			};
		}

		public static WorkOrderRecord Convert(this WorkOrderRecordDTO workorderdto)
		{

			return new WorkOrderRecord()
			{

				ItemId = workorderdto.ItemId,
				IsDeleted = workorderdto.IsDeleted,

				ParentId = workorderdto.ParentId ?? default(int),
				DirectiveId = workorderdto.DirectivesId ?? default(int),
				PackageItemType = workorderdto.PackageItemTypeId.HasValue ? SmartCoreType.Items.GetItemById(workorderdto.PackageItemTypeId.Value) : SmartCoreType.Unknown
			};
		}

		public static WorkPackageDTO Convert(this WorkPackage workpack)
		{
			return new WorkPackageDTO
			{
				ItemId = workpack.ItemId,
				IsDeleted = workpack.IsDeleted,
				ParentId = workpack.ParentId,

				Title = workpack.Title,
				Description = workpack.Description,
				Status = (int)workpack.Status,
				Author = workpack.Author,
				OpeningDate = workpack.OpeningDate,
				PublishingDate = workpack.PublishingDate,
				ClosingDate = workpack.ClosingDate,
				Remarks = workpack.Remarks,
				PublishingRemarks = workpack.PublishingRemarks,
				ClosingRemarks = workpack.ClosingRemarks,
				OnceClosed = workpack.OnceClosed,

				ReleaseCertificateNo = workpack.ReleaseCertificateNo,
				CheckType = workpack.CheckType,
				Station = workpack.Station,
				MaintenanceReportNo = workpack.MaintenanceRepairOrzanization,
				Number = workpack.Number,
				Revision = workpack.Revision,
				CreateDate = workpack.CreateDate,
				PublishedBy = workpack.PublishedBy,

				ClosedBy = workpack.ClosedBy,
				EmployeesRemark = workpack.EmployeesRemark,
				Files = workpack.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>

			};
		}


		public static WorkPackage Convert(this WorkPackageDTO workpackdto)
		{
			var value = new WorkPackage()
			{
				ItemId = workpackdto.ItemId,
				IsDeleted = workpackdto.IsDeleted,
				ParentId = workpackdto.ParentId ?? default(int),
				Title = workpackdto.Title,
				Description = workpackdto.Description,
				Status = (WorkPackageStatus)workpackdto.Status,
				Author = workpackdto.Author,

				OpeningDate = workpackdto.OpeningDate,
				PublishingDate = workpackdto.PublishingDate ?? DateTimeExtend.GetCASMinDateTime(),
				ClosingDate = workpackdto.ClosingDate ?? DateTimeExtend.GetCASMinDateTime(),
				Remarks = workpackdto.Remarks,
				PublishingRemarks = workpackdto.PublishingRemarks,
				ClosingRemarks = workpackdto.ClosingRemarks,
				OnceClosed = workpackdto.OnceClosed,
				ReleaseCertificateNo = workpackdto.ReleaseCertificateNo,
				CheckType = workpackdto.CheckType,
				Station = workpackdto.Station,
				MaintenanceRepairOrzanization = workpackdto.MaintenanceReportNo,

				Number = workpackdto.Number,
				Revision = workpackdto.Revision,
				CreateDate = workpackdto.CreateDate ?? DateTimeExtend.GetCASMinDateTime(),
				PublishedBy = workpackdto.PublishedBy,
				ClosedBy = workpackdto.ClosedBy,
				EmployeesRemark = workpackdto.EmployeesRemark
			};

			if (workpackdto.Files != null)
				value.Files.AddRange(workpackdto.Files.Select(i => i.Convert()));

			return value;
		}

		public static WorkPackageRecordDTO Convert(this WorkPackageRecord workpackrec)
		{
			return new WorkPackageRecordDTO
			{
				ItemId = workpackrec.ItemId,
				IsDeleted = workpackrec.IsDeleted,
				WorkPakageId = workpackrec.WorkPakageId,
				DirectivesId = workpackrec.DirectiveId,
				WorkPackageItemType = workpackrec.WorkPackageItemType,
				PerfNumFromStart = workpackrec.PerformanceNumFromStart,
				PerfNumFromRecord = workpackrec.PerformanceNumFromRecord,
				FromRecordId = workpackrec.FromRecordId,
				Group = workpackrec.Group,
				ParentCheckId = workpackrec.ParentCheckId,
				JobCardNumber = workpackrec.JobCardNumber
			};
		}

		public static WorkPackageRecord Convert(this WorkPackageRecordDTO workpackrecdto)
		{
			return new WorkPackageRecord()
			{
				ItemId = workpackrecdto.ItemId,
				IsDeleted = workpackrecdto.IsDeleted,
				WorkPakageId = workpackrecdto.WorkPakageId,
				DirectiveId = workpackrecdto.DirectivesId ?? default(int),
				WorkPackageItemType = workpackrecdto.WorkPackageItemType ?? default(int),
				PerformanceNumFromStart = workpackrecdto.PerfNumFromStart ?? default(int),
				PerformanceNumFromRecord = workpackrecdto.PerfNumFromRecord ?? default(int),
				FromRecordId = workpackrecdto.FromRecordId ?? default(int),
		ParentCheckId = workpackrecdto.ParentCheckId ?? default(int),
		Group = workpackrecdto.Group ?? default(int),
				JobCardNumber = workpackrecdto.JobCardNumber
			};
		}

		public static WorkPackageSpecialistsDTO Convert(this WorkPackageSpecialists workspec)
		{
			return new WorkPackageSpecialistsDTO
			{
				ItemId = workspec.ItemId,
				IsDeleted = workspec.IsDeleted,
				WorkPackageId = workspec.WorkPackageId,
				SpecialistId = workspec.SpecialistId
			};
		}

		public static WorkPackageSpecialists Convert(this WorkPackageSpecialistsDTO workspecdto)
		{
			return new WorkPackageSpecialists()
			{
				ItemId = workspecdto.ItemId,
				IsDeleted = workspecdto.IsDeleted,
				WorkPackageId = workspecdto.WorkPackageId,
				SpecialistId = workspecdto.SpecialistId
			};
		}

		public static WorkShopDTO Convert(this WorkShop workshop)
		{
			return new WorkShopDTO
			{
				ItemId = workshop.ItemId,
				IsDeleted = workshop.IsDeleted,
				StoreName = workshop.Name,
				Location = workshop.Location,
				OperatorId = workshop.OperatorId,
				Remarks = workshop.Remarks
			};
		}

		public static WorkShop Convert(this WorkShopDTO workshopdto)
		{
			return new WorkShop()
			{
				ItemId = workshopdto.ItemId,
				IsDeleted = workshopdto.IsDeleted,
				Name = workshopdto.StoreName,
				Location = workshopdto.Location,
				OperatorId = workshopdto.OperatorId ?? default(int),
				Remarks = workshopdto.Remarks
			};
		}

		public static MaintenanceDirectiveDTO Convert(this MaintenanceDirective maindirec)
		{
			return new MaintenanceDirectiveDTO
			{
				ItemId = maindirec.ItemId,
				IsDeleted = maindirec.IsDeleted,
				IsApplicability = maindirec.IsApplicability,
				IsOperatorTask = maindirec.IsOperatorTask,
				ProgramIndicator = maindirec.ProgramIndicator?.ItemId ?? -1,
				TaskNumberCheck = maindirec.TaskNumberCheck,
				DirectiveTypeId = maindirec.WorkType?.ItemId,
				MPDTaskNumber = maindirec.MPDTaskNumber,
				MPDNumber = maindirec.MPDNumber,
				MaintenanceManual = maindirec.MaintenanceManual,
				Zone = maindirec.Zone,
				Access = maindirec.Access,
				Applicability = maindirec.Applicability,
				ATAChapterId = maindirec.ATAChapter?.ItemId,
				Description = maindirec.Description,
				EngineeringOrders = maindirec.EngineeringOrders,
				ServiceBulletinNo = maindirec.ServiceBulletinNo,
				Threshold = maindirec.Threshold?.ToBinary(),
				Remarks = maindirec.Remarks,
				HiddenRemarks = maindirec.HiddenRemarks,
				IsClosed = maindirec.IsClosed,
				ManHours = maindirec.ManHours,
				Cost = maindirec.Cost,
				Elapsed = maindirec.Elapsed,
				MRB = maindirec.MRB,
				TaskCardNumber = maindirec.TaskCardNumber,
				Program = maindirec.Program?.ItemId,
				CriticalSystem = maindirec.CriticalSystem?.ItemId,
				MaintenanceCheckId = maindirec.MaintenanceCheck?.ItemId,
				PrintInWP = maindirec.PrintInWorkPackage,
				JobCardId = maindirec.JobCard?.ItemId,
				NDTType = (short)(maindirec.NDTType?.ItemId ?? -1),
				KitsApplicable = maindirec.KitsApplicable,
				ComponentId = maindirec.ParentBaseComponent?.ItemId,
				ForComponentId = maindirec.ForComponentId,
				MpdRef = maindirec.MpdRef,
				MpdRevisionNum = maindirec.MpdRevisionNum,
				MpdOldTaskCard = maindirec.MpdOldTaskCard,
				Workarea = maindirec.Workarea,
				MpdRevisionDate = maindirec.MpdRevisionDate,
				Category = maindirec.Category?.ItemId ?? -1,
				Skill = maindirec.Skill?.ItemId ?? -1,
				ScheduleItem = maindirec.ScheduleItem,
				ScheduleRef = maindirec.ScheduleRef,
				ScheduleRevisionNum = maindirec.ScheduleRevisionNum,
				ScheduleRevisionDate = maindirec.ScheduleRevisionDate,
				Files = maindirec.Files?.Select(i => i.Convert()) as ICollection<ItemFileLinkDTO>,
				PerformanceRecords = maindirec.PerformanceRecords?.Select(i => i.Convert()) as ICollection<DirectiveRecordDTO>,
				CategoriesRecords = maindirec.CategoriesRecords?.Select(i => i.Convert()) as ICollection<CategoryRecordDTO>,
				Kits = maindirec.Kits?.Select(i => i.Convert()) as ICollection<AccessoryRequiredDTO>
			};
		}

		public static MaintenanceDirective Convert(this MaintenanceDirectiveDTO maindirecdto)
		{
			var value = new MaintenanceDirective()
			{
				ItemId = maindirecdto.ItemId,
				IsDeleted = maindirecdto.IsDeleted,
				IsApplicability = maindirecdto.IsApplicability,
				ProgramIndicator = MaintenanceDirectiveProgramIndicator.GetItemById(maindirecdto.ProgramIndicator),
				IsOperatorTask = maindirecdto.IsOperatorTask,
				TaskNumberCheck = maindirecdto.TaskNumberCheck,
				WorkType = maindirecdto.DirectiveTypeId.HasValue ? MaintenanceDirectiveTaskType.Items.GetItemById(maindirecdto.DirectiveTypeId.Value) : MaintenanceDirectiveTaskType.Unknown,
				MPDTaskNumber = maindirecdto.MPDTaskNumber,
				MPDNumber = maindirecdto.MPDNumber,
				MaintenanceManual = maindirecdto.MaintenanceManual,
				Zone = maindirecdto.Zone,
				Access = maindirecdto.Access,
				Applicability = maindirecdto.Applicability,
				ATAChapter = maindirecdto.ATAChapter?.Convert(),
				Description = maindirecdto.Description,
				EngineeringOrders = maindirecdto.EngineeringOrders,
				ServiceBulletinNo = maindirecdto.ServiceBulletinNo,
				Threshold = MaintenanceDirectiveThreshold.ConvertFromByteArray(maindirecdto.Threshold),
				Remarks = maindirecdto.Remarks,
				HiddenRemarks = maindirecdto.HiddenRemarks,
				IsClosed = maindirecdto.IsClosed ?? default(bool),
				ManHours = maindirecdto.ManHours ?? default(double),
				Cost = maindirecdto.Cost ?? default(double),
				Elapsed = maindirecdto.Elapsed ?? default(double),
				MRB = maindirecdto.MRB,
				TaskCardNumber = maindirecdto.TaskCardNumber,
				Program = maindirecdto.Program.HasValue ? MaintenanceDirectiveProgramType.Items.GetItemById(maindirecdto.Program.Value) : MaintenanceDirectiveProgramType.Unknown,
				CriticalSystem = maindirecdto.CriticalSystem.HasValue ? CriticalSystemList.Items.GetItemById(maindirecdto.CriticalSystem.Value) : CriticalSystemList.Unknown,
				//MaintenanceCheck = maindirecdto.MaintenanceCheck?.Convert(),
				PrintInWorkPackage = maindirecdto.PrintInWP,
				JobCard = maindirecdto.JobCard?.Convert(),
				NDTType = NDTType.Items.GetItemById(maindirecdto.NDTType),
				KitsApplicable = maindirecdto.KitsApplicable,
				ParentBaseComponent = maindirecdto.BaseComponent?.ConvertToBaseComponent(),
				ForComponentId = maindirecdto.ForComponentId ?? default(int),
				MpdRef = maindirecdto.MpdRef,
				MpdRevisionNum = maindirecdto.MpdRevisionNum,
				MpdOldTaskCard = maindirecdto.MpdOldTaskCard,
				Workarea = maindirecdto.Workarea,
				MpdRevisionDate = maindirecdto.MpdRevisionDate ?? DateTimeExtend.GetCASMinDateTime(),
				Category = MpdCategory.Items.GetItemById(maindirecdto.Category),
				Skill = Skill.Items.GetItemById(maindirecdto.Skill),
				ScheduleItem = maindirecdto.ScheduleItem,
				ScheduleRef = maindirecdto.ScheduleRef,
				ScheduleRevisionNum = maindirecdto.ScheduleRevisionNum,
				ScheduleRevisionDate = maindirecdto.ScheduleRevisionDate ?? DateTimeExtend.GetCASMinDateTime()
			};

			if (maindirecdto.Files != null)
				value.Files.AddRange(maindirecdto.Files.Select(i => i.Convert()));

			if (maindirecdto.PerformanceRecords != null)
			{
				foreach (var dto in maindirecdto.PerformanceRecords)
				{
					var record = dto.Convert();
					record.Parent = value;
					value.PerformanceRecords.Add(record);
				}
			}

			if (maindirecdto.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(maindirecdto.CategoriesRecords.Select(i => i.Convert()));

			if (maindirecdto.Kits != null)
			{
				foreach (var dto in maindirecdto.Kits)
				{
					var directive = dto.Convert();
					directive.ParentObject = value;
					value.Kits.Add(directive);
				}
			}

			return value;
		}

		public static OperatorDTO Convert(this Operator oper)
		{
			return new OperatorDTO
			{
				ItemId = oper.ItemId,
				IsDeleted = oper.IsDeleted,
				Name = oper.Name,
				LogoType = oper.LogoType,
				ICAOCode = oper.ICAOCode,
				Address = oper.Address,
				Phone = oper.Phone,
				Fax = oper.Fax,
				LogoTypeWhite = oper.LogoTypeWhite,
				Email = oper.Email,
				LogotypeReportLarge = oper.LogotypeReportLarge,
				LogotypeReportVeryLarge = oper.LogotypeReportVeryLarge
			};
		}

		public static Operator Convert(this OperatorDTO operdto)
		{
			return new Operator()
			{
				ItemId = operdto.ItemId,
				IsDeleted = operdto.IsDeleted,
				Name = operdto.Name,
				LogoTypeImageByteView = operdto.LogoType,
				LogoType = operdto.LogoType,
				ICAOCode = operdto.ICAOCode,
				Address = operdto.Address,
				Phone = operdto.Phone,
				Fax = operdto.Fax,
				LogoTypeWhite = operdto.LogoTypeWhite,
				Email = operdto.Email,
				LogotypeReportLarge = operdto.LogotypeReportLarge,
				LogotypeReportVeryLarge = operdto.LogotypeReportVeryLarge
			};
		}

		public static CorrectiveActionDTO Convert(this CorrectiveAction coract)
		{
			return new CorrectiveActionDTO()
			{
				ItemId = coract.ItemId,
				IsDeleted = coract.IsDeleted,
				DiscrepancyID = coract.DiscrepancyId,
				Description = coract.Description,
				ShortDescription = coract.ShortDescription,
				ADDNo = coract.AddNo,
				IsClosed = coract.IsClosed,
				PartNumberOff = coract.PartNumberOff,
				SerialNumberOff = coract.SerialNumberOff,
				PartNumberOn = coract.PartNumberOn,
				SerialNumberOn = coract.SerialNumberOn,
				
				CRSID = coract.CRSID
			};
		}

		public static CorrectiveAction Convert(this CorrectiveActionDTO coractdto)
		{
			return new CorrectiveAction()
			{
				ItemId = coractdto.ItemId,
				IsDeleted = coractdto.IsDeleted,
				DiscrepancyId = coractdto.DiscrepancyID,
				Description = coractdto.Description,
				ShortDescription = coractdto.ShortDescription,
				AddNo = coractdto.ADDNo,
				IsClosed = coractdto.IsClosed,
				PartNumberOff = coractdto.PartNumberOff,
				SerialNumberOff = coractdto.SerialNumberOff,
				PartNumberOn = coractdto.PartNumberOn,
				SerialNumberOn = coractdto.SerialNumberOn,
				CRSID = coractdto.CRSID
			};
		}

		public static SpecialistMedicalRecord Convert(this SpecialistMedicalRecordDTO medicalRecordDto)
		{
			return new SpecialistMedicalRecord
			{
				ItemId = medicalRecordDto.ItemId,
				IsDeleted = medicalRecordDto.IsDeleted,
				Remarks = medicalRecordDto.Remarks,
				ClassNumber = medicalRecordDto.ClassId ?? default(int),
				SpecialistId = medicalRecordDto.SpecialistId ?? default(int),
				RepeatLifelength = Lifelength.ConvertFromByteArray(medicalRecordDto.Repeat),
				NotifyLifelength = Lifelength.ConvertFromByteArray(medicalRecordDto.Notify),
				IssueDate = medicalRecordDto.IssueDate
			};
		}

		public static SpecialistMedicalRecordDTO Convert(this SpecialistMedicalRecord medicalRecord)
		{
			return new SpecialistMedicalRecordDTO()
			{
				ItemId = medicalRecord.ItemId,
				IsDeleted = medicalRecord.IsDeleted,
				Repeat = medicalRecord.RepeatLifelength?.ConvertToByteArray(),
				Notify = medicalRecord.NotifyLifelength?.ConvertToByteArray(),
				Remarks = medicalRecord.Remarks,
				SpecialistId = medicalRecord.SpecialistId,
				ClassId = medicalRecord.ClassNumber,
				IssueDate = medicalRecord.IssueDate
			};
		}

		public static QuotationCost Convert(this QuotationCostDTO quotDto)
		{
			return new QuotationCost
			{
				ItemId = quotDto.ItemId,
				IsDeleted = quotDto.IsDeleted,
				Cost = quotDto.CostNew,
				ProductId = quotDto.ProductId,
				SupplierId = quotDto.SupplierId,
				QuotationId = quotDto.QuotationId,
				Currency = Сurrency.GetItemById(quotDto.CurrencyId),
				CostOverhaul = quotDto.CurrencyId,
				CostServisible = quotDto.CostServisible
			};
		}

		public static QuotationCostDTO Convert(this QuotationCost quot)
		{
			return new QuotationCostDTO()
			{
				ItemId = quot.ItemId,
				IsDeleted = quot.IsDeleted,
				CostNew = quot.Cost,
				ProductId = quot.ProductId,
				SupplierId = quot.SupplierId,
				QuotationId = quot.QuotationId,
				CurrencyId = quot.Currency.ItemId,
				CostOverhaul = quot.CostOverhaul,
				CostServisible = quot.CostServisible
			};
		}

	}
}