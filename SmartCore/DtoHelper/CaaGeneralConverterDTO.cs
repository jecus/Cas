using System.Collections.Generic;
using System.Linq;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.PEL;
using SmartCore.CAA.RoutineAudits;
using SmartCore.CAA.StandartManual;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.DtoHelper
{
    public static  class CaaGeneralConverterDTO
	{
        public static AuditCheck ConvertCAA(this AuditCheckDTO audit)
        {
            return new AuditCheck
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                AuditId =  audit.AuditId,
                CheckListId =  audit.CheckListId,
                SettingsJSON = audit.SettingsJSON,
            };
        }

        public static AuditCheckDTO ConvertCAA(this AuditCheck audit)
        {
            return new AuditCheckDTO
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                AuditId =  audit.AuditId,
				CheckListId =  audit.CheckListId,
				SettingsJSON = audit.SettingsJSON,
            };
        }


        public static AuditCheckRecord ConvertCAA(this AuditCheckRecordDTO audit)
        {
            return new AuditCheckRecord
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                CheckListRecordId =  audit.CheckListRecordId,
				AuditRecordId = audit.AuditRecordId,
                IsChecked =  audit.IsChecked,
            };
        }

        public static AuditCheckRecordDTO ConvertCAA(this AuditCheckRecord audit)
        {
            return new AuditCheckRecordDTO
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
				CheckListRecordId =  audit.CheckListRecordId,
                AuditRecordId = audit.AuditRecordId,

				IsChecked =  audit.IsChecked,
			};
        }


		public static CAAAudit ConvertCAA(this CAAAuditDTO audit)
        {
            return new CAAAudit
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                AuditNumber =  audit.AuditNumber,
				OperatorId = audit.OperatorId,
                SettingsJSON = audit.SettingsJSON,
			};
        }

        public static CAAAuditDTO ConvertCAA(this CAAAudit audit)
        {
            return new CAAAuditDTO
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
				AuditNumber =  audit.AuditNumber,
                OperatorId = audit.OperatorId,
				SettingsJSON = audit.SettingsJSON,
			};
        }

        public static CAAAuditRecord ConvertCAA(this CAAAuditRecordDTO audit)
        {
            return new CAAAuditRecord
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                AuditId = audit.AuditId,
				RoutineAuditId = audit.RoutineAuditId
            };
        }

        public static CAAAuditRecordDTO ConvertCAA(this CAAAuditRecord audit)
        {
            return new CAAAuditRecordDTO
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
				AuditId = audit.AuditId,
                RoutineAuditId = audit.RoutineAuditId
			};
        }




		public static RoutineAuditRecord ConvertCAA(this RoutineAuditRecordDTO audit)
        {
            return new RoutineAuditRecord
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                CheckListId = audit.CheckListId,
                RoutineAuditId = audit.RoutineAuditId,
            };
        }

        public static RoutineAuditRecordDTO ConvertCAA(this RoutineAuditRecord audit)
        {
            return new RoutineAuditRecordDTO
			{
				ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                CheckListId = audit.CheckListId,
                RoutineAuditId = audit.RoutineAuditId,
			};
        }

		public static RoutineAudit ConvertCAA(this RoutineAuditDTO audit)
        {
            return new RoutineAudit
			{
                ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                CorrectorId = audit.CorrectorId,
                Remark = audit.Remark,
                Title = audit.Title,
                OperatorId = audit.OperatorId,
				SettingsJSON =  audit.SettingsJSON,
                Description = audit.Description,
            };
        }

        public static RoutineAuditDTO ConvertCAA(this RoutineAudit audit)
        {
            return new RoutineAuditDTO
			{
				ItemId = audit.ItemId,
                IsDeleted = audit.IsDeleted,
                Updated = audit.Updated,
                Title = audit.Title,
                OperatorId = audit.OperatorId,
				CorrectorId = audit.CorrectorId,
                Remark = audit.Remark,
				SettingsJSON =  audit.SettingsJSON,
				Description = audit.Description,
            };
        }

		public static RootCause ConvertCAA(this RootCauseDTO cause)
        {
            return new RootCause
			{
                ItemId = cause.ItemId,
                IsDeleted = cause.IsDeleted,
                Updated = cause.Updated,
                CorrectorId = cause.CorrectorId,
                Remark = cause.Remark,
                OperatorId = cause.OperatorId,
				CategoryName = cause.CategoryName,
                CategoryNumber = cause.CategoryNumber,

			};
        }

        public static RootCauseDTO ConvertCAA(this RootCause cause)
        {
            return new RootCauseDTO
			{
                ItemId = cause.ItemId,
                IsDeleted = cause.IsDeleted,
                Updated = cause.Updated,
                CorrectorId = cause.CorrectorId,
                Remark = cause.Remark,
                OperatorId = cause.OperatorId,
				CategoryName = cause.CategoryName,
                CategoryNumber = cause.CategoryNumber,
            };
        }

		public static CAAAccessoryDescriptionDTO ConvertCAA(this Product product)
		{
			return new CAAAccessoryDescriptionDTO
			{
				ItemId = product.ItemId,
				IsDeleted = product.IsDeleted,
				Updated = product.Updated,
				CorrectorId = product.CorrectorId,
				Model = product.Name,
				PartNumber = product.PartNumber,
				AltPartNumber = product.AltPartNumber,
				AtaChapterId = product.ATAChapter?.ItemId,
				Description = product.Description,
				StandartId = product.Standart?.ItemId,
				Manufacturer = product.Manufacturer,
				CostNew = product.CostNew,
				CostOverhaul = product.CostOverhaul,
				ModelingObjectTypeId = -1,
				CostServiceable = product.CostServiceable,
				Measure = product.Measure?.ItemId,
				Remarks = product.Remarks,
				Code = product.Code,
				ComponentClass = (short?)product.GoodsClass?.ItemId,
				IsDangerous = product.IsDangerous,
				DescRus = product.DescRus,
				HTS = product.HTS,
				Reference = product.Reference,
				IsEffectivity = product.IsEffectivity,
				IsForbidden = product.IsForbidden,
				EngineRef = product.EngineRef,
				Limitation = product.Limitation,
				Reason = product.Reason,
            };
		}

		public static Product ConvertToProductCAA(this CAAAccessoryDescriptionDTO productDto)
		{
			var product = new Product
			{
				ItemId = productDto.ItemId,
				IsDeleted = productDto.IsDeleted,
				Updated = productDto.Updated,
				CorrectorId = productDto.CorrectorId,
				Name = productDto.Model,
				PartNumber = productDto.PartNumber,
				AltPartNumber = productDto.AltPartNumber,
				ATAChapter = productDto.ATAChapter?.ConvertCAA(),
				Description = productDto.Description,
				Standart = productDto.GoodStandart?.ConvertCAA(),
				Manufacturer = productDto.Manufacturer,
				CostNew = productDto.CostNew ?? default(double),
				CostOverhaul = productDto.CostOverhaul ?? default(double),
				CostServiceable = productDto.CostServiceable ?? default(double),
				Measure = productDto.Measure.HasValue ? Measure.Items.GetItemById(productDto.Measure.Value) : Measure.Unknown,
				Remarks = productDto.Remarks,
				Code = productDto.Code,
				GoodsClass = productDto.ComponentClass.HasValue ? GoodsClass.Items.GetItemById(productDto.ComponentClass.Value) : GoodsClass.Unknown,
				IsDangerous = productDto.IsDangerous,
				DescRus = productDto.DescRus,
				HTS = productDto.HTS,
				Reference = productDto.Reference,
				IsEffectivity = productDto.IsEffectivity,
				IsForbidden = productDto.IsForbidden,
				EngineRef = productDto.EngineRef,
				Limitation = productDto.Limitation,
				Reason = productDto.Reason,
				ProductType = productDto.ModelingObjectTypeId == -1 ? ProductType.EquipmentandMaterial : ProductType.ComponentModel
			};


			return product;

		}

		public static CAAAircraftEquipmentDTO ConvertCAA(this AircraftEquipments aireq)
        {
            return new CAAAircraftEquipmentDTO
            {
                ItemId = aireq.ItemId,
                IsDeleted = aireq.IsDeleted,
                Updated = aireq.Updated,
                CorrectorId = aireq.CorrectorId,
                Description = aireq.Description,
                AircraftId = aireq.AircraftId,
                AircraftOtherParameterId = aireq.AircraftOtherParameter?.ItemId,
                AircraftEquipmetType = (int)aireq.AircraftEquipmetType,
                //AircraftOtherParameter = aireq.AircraftOtherParameter?.ConvertCAA()
            };
        }

        public static AircraftEquipments ConvertCAA(this CAAAircraftEquipmentDTO aireqdto)
        {
            return new AircraftEquipments
            {
                ItemId = aireqdto.ItemId,
                IsDeleted = aireqdto.IsDeleted,
                Updated = aireqdto.Updated,
                CorrectorId = aireqdto.CorrectorId,
                Description = aireqdto.Description,
                AircraftId = aireqdto.AircraftId,
                AircraftOtherParameter = aireqdto.AircraftOtherParameter?.ConvertCAA(),
                AircraftEquipmetType = (AircraftEquipmetType)aireqdto.AircraftEquipmetType
            };
        }

		public static CAAAircraftOtherParameterDTO ConvertCAA(this AircraftOtherParameters parameters)
        {
            return new CAAAircraftOtherParameterDTO
            {
                ItemId = parameters.ItemId,
                IsDeleted = parameters.IsDeleted,
                Updated = parameters.Updated,
                CorrectorId = parameters.CorrectorId,
                FullName = parameters.FullName,
                Name = parameters.ShortName
            };
        }

        public static AircraftOtherParameters ConvertCAA(this CAAAircraftOtherParameterDTO parametersDto)
        {
            return new AircraftOtherParameters
            {
                ItemId = parametersDto.ItemId,
                IsDeleted = parametersDto.IsDeleted,
                Updated = parametersDto.Updated,
                CorrectorId = parametersDto.CorrectorId,
                FullName = parametersDto.FullName,
                ShortName = parametersDto.Name
            };
        }

		public static CAAAircraftDTO ConvertCAA(this Aircraft aircraft)
		{
			return new CAAAircraftDTO
			{
				ItemId = aircraft.ItemId,
				IsDeleted = aircraft.IsDeleted,
				Updated = aircraft.Updated,
				CorrectorId = aircraft.CorrectorId,
				AircraftFrameId = aircraft.AircraftFrameId,
				OperatorID = aircraft.OperatorId,
				APUFH = aircraft.APUFH,
				AircraftTypeID = aircraft.AircraftTypeId,
				ModelId = aircraft.Model?.ItemId,
				TypeCertificateNumber = aircraft.TypeCertificateNumber,
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
				SeatingEconomy = (short?)aircraft.SeatingEconomy,
				SeatingBusiness = (short?)aircraft.SeatingBusiness,
				SeatingFirst = (short?)aircraft.SeatingFirst,
				Oven = aircraft.Oven,
				Boiler = aircraft.Boiler,
				AirStairDoors = aircraft.AirStairsDoors,
				Tanks = aircraft.Tanks,
				AircraftAddress24Bit = aircraft.AircraftAddress24Bit,
				ELTIdHexCode = aircraft.ELTIdHexCode,
				DeliveryDate = aircraft.DeliveryDate,
				AcceptanceDate = aircraft.AcceptanceDate,
				Schedule = aircraft.Schedule,
				MSG = (short)aircraft.MSG,
				CheckNaming = aircraft.MaintenanceProgramCheckNaming,
				NoiceCategory = aircraft.NoiceCategory,
				FADEC = aircraft.FADEC,
				LandingCategory = aircraft.LandingCategory,
				EFIS = aircraft.EFIS,
				Brakes = (short)aircraft.Brakes,
				Winglets = aircraft.Winglets,
				ApuUtizationPerFlightinMinutes = aircraft.ApuUtizationPerFlightinMinutes,
			};
		}

		public static Aircraft ConvertCAA(this CAAAircraftDTO aircraftDto)
		{
			var value = new Aircraft
			{
				ItemId = aircraftDto.ItemId,
				AircraftFrameId = aircraftDto.AircraftFrameId,
				IsDeleted = aircraftDto.IsDeleted,
				Updated = aircraftDto.Updated,
				CorrectorId = aircraftDto.CorrectorId,
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
				Model = aircraftDto.Model?.ConvertToAircraftModelCAA()
			};

			if (aircraftDto.MaintenanceProgramChangeRecords != null)
				value.MaintenanceProgramChangeRecords.AddRange(aircraftDto.MaintenanceProgramChangeRecords.Select(i => i.ConvertCAA()));

			return value;
		}

        public static CAAMaintenanceProgramChangeRecordDTO ConvertCAA(this MaintenanceProgramChangeRecord record)
        {
            return new CAAMaintenanceProgramChangeRecordDTO
            {
                ItemId = record.ItemId,
                IsDeleted = record.IsDeleted,
                Updated = record.Updated,
                CorrectorId = record.CorrectorId,
                ParentAircraftId = record.ParentAircraftId,
                MSG = (short?)record.MSG,
                MaintenanceCheckRecordId = record.MaintenanceCheckRecordId,
                CalculatedPerformanceSource = record.CalculatedPerformanceSource?.ConvertToByteArray(),
                PerformanceNum = record.PerformanceNum,
                RecordDate = record.RecordDate,
                OnLifelength = record.OnLifelength?.ConvertToByteArray(),
                Remarks = record.Remarks
            };
        }

        public static MaintenanceProgramChangeRecord ConvertCAA(this CAAMaintenanceProgramChangeRecordDTO record)
        {
            return new MaintenanceProgramChangeRecord
            {
                ItemId = record.ItemId,
                IsDeleted = record.IsDeleted,
                Updated = record.Updated,
                CorrectorId = record.CorrectorId,
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

		public static SpecialistMedicalRecord ConvertCAA(this CAASpecialistMedicalRecordDTO medicalRecordDto)
        {
            return new SpecialistMedicalRecord
            {
                ItemId = medicalRecordDto.ItemId,
                IsDeleted = medicalRecordDto.IsDeleted,
                Updated = medicalRecordDto.Updated,
                CorrectorId = medicalRecordDto.CorrectorId,
                Remarks = medicalRecordDto.Remarks,
                ClassNumber = medicalRecordDto.ClassId ?? default(int),
                SpecialistId = medicalRecordDto.SpecialistId ?? default(int),
                RepeatLifelength = Lifelength.ConvertFromByteArray(medicalRecordDto.Repeat),
                NotifyLifelength = Lifelength.ConvertFromByteArray(medicalRecordDto.Notify),
                IssueDate = medicalRecordDto.IssueDate
            };
        }

        public static CAASpecialistMedicalRecordDTO ConvertCAA(this SpecialistMedicalRecord medicalRecord)
        {
            return new CAASpecialistMedicalRecordDTO()
            {
                ItemId = medicalRecord.ItemId,
                IsDeleted = medicalRecord.IsDeleted,
                Updated = medicalRecord.Updated,
                CorrectorId = medicalRecord.CorrectorId,
                Repeat = medicalRecord.RepeatLifelength?.ConvertToByteArray(),
                Notify = medicalRecord.NotifyLifelength?.ConvertToByteArray(),
                Remarks = medicalRecord.Remarks,
                SpecialistId = medicalRecord.SpecialistId,
                ClassId = medicalRecord.ClassNumber,
                IssueDate = medicalRecord.IssueDate
            };
        }

		public static CAASpecialistDTO ConvertCAA(this Specialist specialist)
		{
			return new CAASpecialistDTO
			{
				ItemId = specialist.ItemId,
				IsDeleted = specialist.IsDeleted,
				Updated = specialist.Updated,
				CorrectorId = specialist.CorrectorId,
				FirstName = specialist.FirstName,
				ShortName = specialist.ShortName,
				SpecializationID = specialist.Specialization?.ItemId ?? -1,
				LastName = specialist.LastName,
				Gender = (short?)specialist.Gender,
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
				Education = (short)(specialist.Education?.ItemId ?? -1),
				Location = (short)(specialist.Facility?.ItemId ?? -1),
				Status = (short)specialist.Status,
				Position = (short)specialist.Position,
				Sign = specialist.Sign,
				FamilyStatus = (short)(specialist.FamilyStatus?.ItemId ?? -1),
				Citizenship = (short)(specialist.Citizenship?.ItemId ?? -1),
				PersonnelCategoryId = specialist.PersonnelCategory?.ItemId ?? -1,
				ClassNumber = specialist.ClassNumber,
				ClassIssueDate = specialist.ClassIssueDate,
				GradeNumber = specialist.GradeNumber,
				GradeIssueDate = specialist.GradeIssueDate,
				Additional = specialist.Additional,
				Combination = specialist.Combination,
                IsCAA = specialist.IsCAA,
                OperatorId = specialist.OperatorId,
				Licenses = specialist.Licenses?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseDTO>,
				SpecialistTrainings = specialist.SpecialistTrainings?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistTrainingDTO>,
				LicenseDetails = specialist.LicenseDetails?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseDetailDTO>,
				LicenseRemark = specialist.LicenseRemark?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseRemarkDTO>,
				EmployeeDocuments = specialist.EmployeeDocuments?.Select(i => i.ConvertCAA()) as ICollection<CAADocumentDTO>,
				CategoriesRecords = specialist.CategoriesRecords?.Select(i => i.ConvertCAA()) as ICollection<CAACategoryRecordDTO>,
				Files = specialist.Files?.Select(i => i.ConvertCAA()) as ICollection<CAAItemFileLinkDTO>
			};
		}

		public static Specialist ConvertCAA(this CAASpecialistDTO specialist)
		{
			var value = new Specialist
			{
                ItemId = specialist.ItemId,
				IsDeleted = specialist.IsDeleted,
				Updated = specialist.Updated,
				CorrectorId = specialist.CorrectorId,
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
				AGWCategory = specialist.AGWCategory?.ConvertCAA(),
				Facility = specialist.Facility?.ConvertCAA(),
				Specialization = specialist.Specialization?.ConvertCAA(),
				IsCAA = specialist.IsCAA,
				OperatorId = specialist.OperatorId
			};

			if (specialist.Licenses != null)
				value.Licenses.AddRange(specialist.Licenses.Select(i => i.ConvertCAA()));

			if (specialist.SpecialistTrainings != null)
				value.SpecialistTrainings.AddRange(specialist.SpecialistTrainings.Select(i => i.ConvertCAA()));

			if (specialist.LicenseDetails != null)
				value.LicenseDetails.AddRange(specialist.LicenseDetails.Select(i => i.ConvertCAA()));

			if (specialist.LicenseRemark != null)
				value.LicenseRemark.AddRange(specialist.LicenseRemark.Select(i => i.ConvertCAA()));

			if (specialist.EmployeeDocuments != null)
				value.EmployeeDocuments.AddRange(specialist.EmployeeDocuments.Select(i => i.ConvertCAA()));

			if (specialist.CategoriesRecords != null)
				value.CategoriesRecords.AddRange(specialist.CategoriesRecords.Select(i => i.ConvertCAA()));

			if (specialist.Files != null)
				value.Files.AddRange(specialist.Files.Select(i => i.ConvertCAA()));

			return value;
		}

		public static CAASpecialistTrainingDTO ConvertCAA(this SpecialistTraining specialistTraining)
		{
			return new CAASpecialistTrainingDTO
			{
				ItemId = specialistTraining.ItemId,
				IsDeleted = specialistTraining.IsDeleted,
				Updated = specialistTraining.Updated,
				CorrectorId = specialistTraining.CorrectorId,
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
				Files = specialistTraining.Files?.Select(i => i.ConvertCAA()) as ICollection<CAAItemFileLinkDTO>
			};
		}

		public static SpecialistTraining ConvertCAA(this CAASpecialistTrainingDTO specialistTraining)
		{
			var value = new SpecialistTraining
			{
				ItemId = specialistTraining.ItemId,
				IsDeleted = specialistTraining.IsDeleted,
				Updated = specialistTraining.Updated,
				CorrectorId = specialistTraining.CorrectorId,
				SpecialistId = specialistTraining.SpecialistId ?? -1,
				TrainingType = specialistTraining.TrainingId.HasValue ? TrainingType.GetDirectiveTypeById(specialistTraining.TrainingId.Value) : TrainingType.Unknown,
				ManHours = specialistTraining.ManHours ?? default(double),
				Cost = specialistTraining.Cost ?? default(double),
				Remarks = specialistTraining.Remarks,
				HiddenRemark = specialistTraining.HiddenRemark,
				Description = specialistTraining.Description,
				Threshold = new TrainingThreshold(specialistTraining.Threshold),
				IsClosed = specialistTraining.IsClosed ?? default(bool),
				AircraftTypeID = specialistTraining.AircraftTypeID ?? -1,
				AircraftType = specialistTraining.AircraftType?.ConvertToAircraftModelCAA(),
				EmployeeSubject = specialistTraining.EmployeeSubject?.ConvertCAA(),
				Supplier = specialistTraining.Supplier?.ConvertCAA(),
			};

			if (specialistTraining.Files != null)
				value.Files.AddRange(specialistTraining.Files.Select(i => i.ConvertCAA()));

			return value;
		}

		public static CAASpecialistLicenseDTO ConvertCAA(this SpecialistLicense license)
		{
			return new CAASpecialistLicenseDTO
			{
				ItemId = license.ItemId,
				IsDeleted = license.IsDeleted,
				Updated = license.Updated,
				CorrectorId = license.CorrectorId,
				Confirmation = license.Confirmation,
				LicenseTypeID = license.EmployeeLicenceType?.ItemId ?? -1,
				AircraftTypeID = license.AircraftTypeID,
				SpecialistId = license.SpecialistId,
				Notify = license.NotifyLifelength?.ConvertToByteArray(),
				IssueDate = license.IssueDate,
				ValidToDate = license.ValidToDate,
				CaaLicense = license.CaaLicense?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistCAADTO>,
				LicenseDetails = license.LicenseDetails?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseDetailDTO>,
				LicenseRatings = license.LicenseRatings?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseRatingDTO>,
				SpecialistInstrumentRatings = license.SpecialistInstrumentRatings?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistInstrumentRatingDTO>,
				LicenseRemark = license.LicenseRemark?.Select(i => i.ConvertCAA()) as ICollection<CAASpecialistLicenseRemarkDTO>
			};
		}

		public static SpecialistLicense ConvertCAA(this CAASpecialistLicenseDTO license)
		{
			var value = new SpecialistLicense
			{
				ItemId = license.ItemId,
				IsDeleted = license.IsDeleted,
				Updated = license.Updated,
				CorrectorId = license.CorrectorId,
				Confirmation = license.Confirmation,
				EmployeeLicenceType = EmployeeLicenceType.Items.GetItemById(license.LicenseTypeID),
				AircraftTypeID = license.AircraftTypeID ?? -1,
				SpecialistId = license.SpecialistId ?? -1,
				NotifyLifelength = Lifelength.ConvertFromByteArray(license.Notify),
				IssueDate = license.IssueDate ?? DateTimeExtend.GetCASMinDateTime(),
				ValidToDate = license.ValidToDate ?? DateTimeExtend.GetCASMinDateTime(),
				AircraftType = license.AircraftType?.ConvertToAircraftModelCAA()
			};

			if (license.CaaLicense != null)
				value.CaaLicense.AddRange(license.CaaLicense.Select(i => i.ConvertCAA()));

			if (license.LicenseDetails != null)
				value.LicenseDetails.AddRange(license.LicenseDetails.Select(i => i.ConvertCAA()));

			if (license.LicenseRatings != null)
				value.LicenseRatings.AddRange(license.LicenseRatings.Select(i => i.ConvertCAA()));

			if (license.SpecialistInstrumentRatings != null)
				value.SpecialistInstrumentRatings.AddRange(license.SpecialistInstrumentRatings.Select(i => i.ConvertCAA()));

			if (license.LicenseRemark != null)
				value.LicenseRemark.AddRange(license.LicenseRemark.Select(i => i.ConvertCAA()));

			return value;
		}

		public static CAASpecialistLicenseRemarkDTO ConvertCAA(this SpecialistLicenseRemark licenseRemark)
		{
			return new CAASpecialistLicenseRemarkDTO
			{
				ItemId = licenseRemark.ItemId,
				IsDeleted = licenseRemark.IsDeleted,
				Updated = licenseRemark.Updated,
				CorrectorId = licenseRemark.CorrectorId,
				IssueDate = licenseRemark.IssueDate,
				RightsId = licenseRemark.Rights?.ItemId ?? -1,
				RestrictionId = licenseRemark.LicenseRestriction?.ItemId ?? -1,
				SpecialistLicenseId = licenseRemark.SpecialistLicenseId,
				SpecialistId = licenseRemark.SpecialistId,
			};
		}

		public static SpecialistLicenseRemark ConvertCAA(this CAASpecialistLicenseRemarkDTO licenseRemark)
		{
			return new SpecialistLicenseRemark
			{
				ItemId = licenseRemark.ItemId,
				IsDeleted = licenseRemark.IsDeleted,
				Updated = licenseRemark.Updated,
				CorrectorId = licenseRemark.CorrectorId,
				IssueDate = licenseRemark.IssueDate,
				SpecialistLicenseId = licenseRemark.SpecialistLicenseId ?? -1,
				SpecialistId = licenseRemark.SpecialistId ?? -1,
				Rights = licenseRemark.Rights?.ConvertCAA(),
				LicenseRestriction = licenseRemark.LicenseRestriction?.ConvertCAA()
			};
		}

		public static CAASpecialistInstrumentRatingDTO ConvertCAA(this SpecialistInstrumentRating instrumentRating)
		{
			return new CAASpecialistInstrumentRatingDTO
			{
				ItemId = instrumentRating.ItemId,
				IsDeleted = instrumentRating.IsDeleted,
				Updated = instrumentRating.Updated,
				CorrectorId = instrumentRating.CorrectorId,
				IssueDate = instrumentRating.IssueDate,
				SpecialistLicenseId = instrumentRating.SpecialistLicenseId,
				IcaoId = instrumentRating.Icao?.ItemId ?? -1,
				MC = instrumentRating.MC,
				MV = instrumentRating.MV,
				RVR = instrumentRating.RVR,
				TORVR = instrumentRating.TORVR
			};
		}

		public static SpecialistInstrumentRating ConvertCAA(this CAASpecialistInstrumentRatingDTO instrumentRating)
		{
			return new SpecialistInstrumentRating
			{
				ItemId = instrumentRating.ItemId,
				IsDeleted = instrumentRating.IsDeleted,
				Updated = instrumentRating.Updated,
				CorrectorId = instrumentRating.CorrectorId,
				IssueDate = instrumentRating.IssueDate,
				SpecialistLicenseId = instrumentRating.SpecialistLicenseId ?? -1,
				Icao = LicenseIcao.GetItemById(instrumentRating.IcaoId),
				MC = instrumentRating.MC,
				MV = instrumentRating.MV,
				RVR = instrumentRating.RVR,
				TORVR = instrumentRating.TORVR
			};
		}

		public static CAASpecialistLicenseRatingDTO ConvertCAA(this SpecialistLicenseRating licenseRating)
		{
			return new CAASpecialistLicenseRatingDTO
			{
				ItemId = licenseRating.ItemId,
				IsDeleted = licenseRating.IsDeleted,
				Updated = licenseRating.Updated,
				CorrectorId = licenseRating.CorrectorId,
				SpecialistLicenseId = licenseRating.SpecialistLicenseId,
				IssueDate = licenseRating.IssueDate,
				RightsId = licenseRating.Rights?.ItemId ?? -1,
				FunctionId = licenseRating.LicenseFunction?.ItemId ?? -1
			};
		}

		public static SpecialistLicenseRating ConvertCAA(this CAASpecialistLicenseRatingDTO licenseRating)
		{
			return new SpecialistLicenseRating
			{
				ItemId = licenseRating.ItemId,
				IsDeleted = licenseRating.IsDeleted,
				Updated = licenseRating.Updated,
				CorrectorId = licenseRating.CorrectorId,
				SpecialistLicenseId = licenseRating.SpecialistLicenseId ?? -1,
				IssueDate = licenseRating.IssueDate,
				Rights = LicenseRights.Items.GetItemById(licenseRating.RightsId),
				LicenseFunction = LicenseFunction.GetItemById(licenseRating.FunctionId)
			};
		}

		public static CAASpecialistLicenseDetailDTO ConvertCAA(this SpecialistLicenseDetail licenseDetail)
		{
			return new CAASpecialistLicenseDetailDTO
			{
				ItemId = licenseDetail.ItemId,
				IsDeleted = licenseDetail.IsDeleted,
				Updated = licenseDetail.Updated,
				CorrectorId = licenseDetail.CorrectorId,
				Description = licenseDetail.Description,
				IssueDate = licenseDetail.IssueDate,
				SpecialistLicenseId = licenseDetail.SpecialistLicenseId,
				SpecialistId = licenseDetail.SpecialistId
			};
		}

		public static SpecialistLicenseDetail ConvertCAA(this CAASpecialistLicenseDetailDTO licenseDetail)
		{
			return new SpecialistLicenseDetail
			{
				ItemId = licenseDetail.ItemId,
				IsDeleted = licenseDetail.IsDeleted,
				Updated = licenseDetail.Updated,
				CorrectorId = licenseDetail.CorrectorId,
				Description = licenseDetail.Description,
				IssueDate = licenseDetail.IssueDate,
				SpecialistLicenseId = licenseDetail.SpecialistLicenseId ?? -1,
				SpecialistId = licenseDetail.SpecialistId ?? -1
			};
		}

		public static CAASpecialistCAADTO ConvertCAA(this SpecialistCAA specialistCaa)
		{
			return new CAASpecialistCAADTO
			{
				ItemId = specialistCaa.ItemId,
				IsDeleted = specialistCaa.IsDeleted,
				Updated = specialistCaa.Updated,
				CorrectorId = specialistCaa.CorrectorId,
				NumberCAA = specialistCaa.CAANumber,
				CAAId = specialistCaa.Caa?.ItemId ?? -1,
				CAAType = (int)specialistCaa.CaaType,
				ValidTo = specialistCaa.ValidToDate,
				SpecialistLicenseId = specialistCaa.SpecialistLicenseId,
				Notify = specialistCaa.NotifyLifelength?.ConvertToByteArray(),
				IssueDate = specialistCaa.IssueDate
			};
		}

		public static SpecialistCAA ConvertCAA(this CAASpecialistCAADTO specialistCaa)
		{
			return new SpecialistCAA
			{
				ItemId = specialistCaa.ItemId,
				IsDeleted = specialistCaa.IsDeleted,
				Updated = specialistCaa.Updated,
				CorrectorId = specialistCaa.CorrectorId,
				CAANumber = specialistCaa.NumberCAA,
				Caa = Citizenship.Items.GetItemById(specialistCaa.CAAId),
				CaaType = (CaaType)specialistCaa.CAAType,
				ValidToDate = specialistCaa.ValidTo,
				SpecialistLicenseId = specialistCaa.SpecialistLicenseId ?? -1,
				NotifyLifelength = Lifelength.ConvertFromByteArray(specialistCaa.Notify),
				IssueDate = specialistCaa.IssueDate ?? DateTimeExtend.GetCASMinDateTime()
			};
		}


		public static CAADocumentDTO ConvertCAA(this Document document)
		{
			return new CAADocumentDTO
			{
				ItemId = document.ItemId,
				IsDeleted = document.IsDeleted,
				Updated = document.Updated,
				CorrectorId = document.CorrectorId,
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
				ProlongationWayId = (int?)document.ProlongationWay,
				ServiceTypeId = document.ServiceType?.ItemId,
				ResponsibleOccupationId = document.ResponsibleOccupation?.ItemId ?? -1,
				Remarks = document.Remarks,
				LocationId = document.Location?.ItemId ?? -1,
				SupplierId = document.Supplier?.ItemId ?? -1,
				ParentAircraftId = document.ParentAircraftId,
				IdNumber = document.IdNumber,
				Author = document.Author,
				OperatorId = document.OperatorId
			};
		}

		public static Document ConvertCAA(this CAADocumentDTO document)
		{
			var doc = new Document
			{
				ItemId = document.ItemId,
				IsDeleted = document.IsDeleted,
				Updated = document.Updated,
				CorrectorId = document.CorrectorId,
				ParentId = document.ParentID ?? -1,
				ParentTypeId = document.ParentTypeId,
				DocTypeId = document.DocTypeId,
				DocumentSubType = document.DocumentSubType?.ConvertCAA(),
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
				ProlongationWay = document.ProlongationWayId.HasValue ? (ProlongationWay)document.ProlongationWayId.Value : ProlongationWay.Unknown,
				Aboard = document.Aboard,
				Privy = document.Privy,
                Author = document.Author,
				IssueNumber = document.IssueNumber,
				Remarks = document.Remarks,
                OperatorId = document.OperatorId,
				ParentAircraftId = document.ParentAircraftId ?? default(int),
				IdNumber = document.IdNumber,
				Supplier = document.Supplier?.ConvertCAA(),
				ResponsibleOccupation = document.ResponsibleOccupation?.ConvertCAA(),
				Nomenсlature = document.Nomenсlature?.ConvertCAA(),
				ServiceType = document.ServiceType?.ConvertCAA(),
				Location = document.Location?.ConvertCAA()
			};

			var department = document.Department?.ConvertCAA();
			if (department != null)
				doc.Department = department.IsDeleted ? Department.Unknown : department;
			else doc.Department = Department.Unknown;

			return doc;
		}

		public static CAASupplierDTO ConvertCAA(this Supplier supplier)
		{
			return new CAASupplierDTO
			{
				ItemId = supplier.ItemId,
				IsDeleted = supplier.IsDeleted,
				Updated = supplier.Updated,
				CorrectorId = supplier.CorrectorId,
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
				SupplierDocs = supplier.SupplierDocs?.Select(i => i.ConvertCAA()) as ICollection<CAADocumentDTO>
			};
		}

		public static Supplier ConvertCAA(this CAASupplierDTO supplier)
		{

			var value = new Supplier
			{
				ItemId = supplier.ItemId,
				IsDeleted = supplier.IsDeleted,
				Updated = supplier.Updated,
				CorrectorId = supplier.CorrectorId,
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

				value.SupplierDocs.AddRange(supplier.SupplierDocs.Select(i => i.ConvertCAA()));

			return value;
		}

		public static CAACategoryRecordDTO ConvertCAA(this CategoryRecord record)
		{
			return new CAACategoryRecordDTO
			{

				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				Updated = record.Updated,
				CorrectorId = record.CorrectorId,
				AircraftWorkerCategoryId = record.AircraftWorkerCategory?.ItemId,
				AircraftTypeId = record.AircraftModel?.ItemId,
				ParentId = record.ParentId,
				ParentTypeId = record.ParentType?.ItemId,
				AircraftModel = record.AircraftModel?.ConvertCAA(),
				//AircraftWorkerCategory = record.AircraftWorkerCategory?.ConvertCAA()
			};
		}

		public static CategoryRecord ConvertCAA(this CAACategoryRecordDTO record)
		{
			return new CategoryRecord
			{

				ItemId = record.ItemId,
				IsDeleted = record.IsDeleted,
				Updated = record.Updated,
				CorrectorId = record.CorrectorId,
				//AircraftWorkerCategory = record.AircraftWorkerCategory?.ConvertCAA(),
				ParentId = record.ParentId ?? default(int),
				ParentType = record.ParentTypeId.HasValue ? SmartCoreType.Items.GetItemById(record.ParentTypeId.Value) : SmartCoreType.Unknown,
				AircraftModel = record.AircraftModel?.ConvertToAircraftModelCAA()
			};
		}

        public static CAAItemFileLinkDTO ConvertCAA(this ItemFileLink link)
        {
            return new CAAItemFileLinkDTO
            {
                ItemId = link.ItemId,
                IsDeleted = link.IsDeleted,
                Updated = link.Updated,
                CorrectorId = link.CorrectorId,
                ParentId = link.ParentId,
                ParentTypeId = link.ParentTypeId,
                LinkType = link.LinkType,
                FileId = link.File?.ItemId,
            };
        }

        public static ItemFileLink ConvertCAA(this CAAItemFileLinkDTO link)
        {
            return new ItemFileLink
            {
                ItemId = link.ItemId,
                IsDeleted = link.IsDeleted,
                Updated = link.Updated,
                CorrectorId = link.CorrectorId,
                ParentId = link.ParentId ?? -1,
                ParentTypeId = link.ParentTypeId,
                LinkType = link.LinkType,
                FileId = link.FileId,
                File = link.File?.ConvertCAA()
            };
        }


        public static CAAAttachedFileDTO ConvertCAA(this AttachedFile file)
        {

            return new CAAAttachedFileDTO
			{
                ItemId = file.ItemId,
                IsDeleted = file.IsDeleted,
                Updated = file.Updated,
                CorrectorId = file.CorrectorId,
                FileName = file.FileName,
                FileData = file.FileData,
                FileSize = file.FileSize
            };
        }

        public static AttachedFile ConvertCAA(this CAAAttachedFileDTO file)
        {
            return new AttachedFile
            {
                ItemId = file.ItemId,
                IsDeleted = file.IsDeleted,
                Updated = file.Updated,
                CorrectorId = file.CorrectorId,
                FileName = file.FileName,
                FileData = file.FileData,
                FileSize = (int?)(file.FileSize ?? default(int))
            };
        }

		public static CAAAccessoryDescriptionDTO ConvertCAA(this AircraftModel aircraftModel)
		{
			return new CAAAccessoryDescriptionDTO
			{
				ItemId = aircraftModel.ItemId,
				IsDeleted = aircraftModel.IsDeleted,
				Updated = aircraftModel.Updated,
				CorrectorId = aircraftModel.CorrectorId,
				Model = aircraftModel.Name,
				PartNumber = aircraftModel.PartNumber,
				AltPartNumber = aircraftModel.AltPartNumber,
				AtaChapterId = aircraftModel.ATAChapter?.ItemId,
				//GoodStandart = aircraftModel.Standart?.ConvertCAA(),
				Description = aircraftModel.Description,
				StandartId = aircraftModel.Standart?.ItemId,
				Manufacturer = aircraftModel.Manufacturer,
				CostNew = aircraftModel.CostNew,
				CostOverhaul = aircraftModel.CostOverhaul,
				CostServiceable = aircraftModel.CostServiceable,
				Measure = aircraftModel.Measure?.ItemId,
				Remarks = aircraftModel.Remarks,
				ModelingObjectTypeId = aircraftModel.ModelingObjectType?.ItemId ?? -1,
				ModelingObjectSubTypeId = aircraftModel.ManufactureReg?.ItemId,
				SubModel = aircraftModel.Series,
				FullName = aircraftModel.FullName,
				ShortName = aircraftModel.ShortName,
				Designer = aircraftModel.Designer,
				Code = aircraftModel.Code,
				ComponentClass = (short?)aircraftModel.GoodsClass?.ItemId,
				IsDangerous = aircraftModel.IsDangerous,
            };
		}

		public static AircraftModel ConvertToAircraftModelCAA(this CAAAccessoryDescriptionDTO aircraftModelDto)
		{
			var value = new AircraftModel
			{
				ItemId = aircraftModelDto.ItemId,
				IsDeleted = aircraftModelDto.IsDeleted,
				Updated = aircraftModelDto.Updated,
				CorrectorId = aircraftModelDto.CorrectorId,
				Name = aircraftModelDto.Model,
				PartNumber = aircraftModelDto.PartNumber,
				AltPartNumber = aircraftModelDto.AltPartNumber,
				ATAChapter = aircraftModelDto.ATAChapter?.ConvertCAA(),
				Description = aircraftModelDto.Description,
				Standart = aircraftModelDto.GoodStandart?.ConvertCAA(),
				Manufacturer = aircraftModelDto.Manufacturer,
				CostNew = aircraftModelDto.CostNew ?? default(double),
				CostOverhaul = aircraftModelDto.CostOverhaul ?? default(double),
				CostServiceable = aircraftModelDto.CostServiceable ?? default(double),
				Measure = aircraftModelDto.Measure.HasValue ? Measure.Items.GetItemById(aircraftModelDto.Measure.Value) : Measure.Unknown,
				Remarks = aircraftModelDto.Remarks,
				ManufactureReg = aircraftModelDto.ModelingObjectSubTypeId.HasValue ? ManufactureRegion.Items.GetItemById(aircraftModelDto.ModelingObjectSubTypeId.Value) : ManufactureRegion.Unknown,
				Series = aircraftModelDto.SubModel,
				FullName = aircraftModelDto.FullName,
				ShortName = aircraftModelDto.ShortName,
				Designer = aircraftModelDto.Designer,
				Code = aircraftModelDto.Code,
				GoodsClass = aircraftModelDto.ComponentClass.HasValue ? GoodsClass.Items.GetItemById(aircraftModelDto.ComponentClass.Value) : GoodsClass.Unknown,
				IsDangerous = aircraftModelDto.IsDangerous
			};

			return value;
		}

		public static AllOperatorsDTO ConvertCAA(this AllOperators oper)
		{
			return new AllOperatorsDTO
			{
				ItemId = oper.ItemId,
				IsDeleted = oper.IsDeleted,
				Updated = oper.Updated,
				CorrectorId = oper.CorrectorId,
				FullName = oper.FullName,
				ShortName = oper.ShortName,
				ICAOCode = oper.ICAOCode,
				Address = oper.Address,
				Phone = oper.Phone,
				Fax = oper.Fax,
				Web = oper.Web,
				Email = oper.Email,
				LogoType = oper.LogoTypeImageByteView,
				LogoTypeWhite = oper.LogoTypeWhite,
				LogotypeReportLarge = oper.LogotypeReportLarge,
				LogotypeReportVeryLarge = oper.LogotypeReportVeryLarge,
				Settings = new AllOperatorSettings()
				{
					IsCommertial = oper.IsCommertial,
					IsAEMS = oper.IsAEMS,
					IsAerodromOperator = oper.IsAerodromOperator,
					IsAMO = oper.IsAMO,
					IsTraningOperation = oper.IsTraningOperation,
					IsFuel = oper.IsFuel,
					IsATC = oper.IsATC,
					TypeOperation = oper.TypeOperation,
					SpecialOperation = oper.SpecialOperation,
					Fleet = oper.Fleet,
                    Privilages = oper.Privilages,
					Ratings = oper.Ratings,
                    IATACode = oper.IATACode,
                    Description = oper.Description,
                    IsAirOperator = oper.IsAirOperator,
                    IsCAMO = oper.IsCAMO,
                    IsCAO = oper.IsCAO,
				},
			};
		}

		public static AllOperators ConvertCAA(this AllOperatorsDTO operdto)
		{
			return new AllOperators()
			{
				ItemId = operdto.ItemId,
				IsDeleted = operdto.IsDeleted,
				Updated = operdto.Updated,
				CorrectorId = operdto.CorrectorId,
				FullName = operdto.FullName,
				ShortName = operdto.ShortName,
				ICAOCode = operdto.ICAOCode,
				Address = operdto.Address,
				Phone = operdto.Phone,
				Fax = operdto.Fax,
				Web = operdto.Web,
				Email = operdto.Email,
				LogoTypeImageByteView = operdto.LogoType,
				LogoTypeWhite = operdto.LogoTypeWhite,
				LogotypeReportLarge = operdto.LogotypeReportLarge,
				LogotypeReportVeryLarge = operdto.LogotypeReportVeryLarge,
				IsCommertial = operdto.Settings.IsCommertial,
				IsAEMS = operdto.Settings.IsAEMS,
				IsAerodromOperator = operdto.Settings.IsAerodromOperator,
				IsAMO = operdto.Settings.IsAMO,
				IsTraningOperation = operdto.Settings.IsTraningOperation,
				IsFuel = operdto.Settings.IsFuel,
				IsATC = operdto.Settings.IsATC,
				TypeOperation = operdto.Settings.TypeOperation,
				SpecialOperation = operdto.Settings.SpecialOperation,
				Fleet = operdto.Settings.Fleet,
                Privilages = operdto.Settings.Privilages,
				Ratings = operdto.Settings.Ratings,
                IATACode = operdto.Settings.IATACode,
                Description = operdto.Settings.Description,
                IsAirOperator = operdto.Settings.IsAirOperator,
                IsCAMO = operdto.Settings.IsCAMO,
                IsCAO = operdto.Settings.IsCAO,

			};
		}

        public static FindingLevelsDTO ConvertCAA(this FindingLevels levels)
        {
            return new FindingLevelsDTO()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectiveAction = levels.CorrectiveAction?.ConvertToByteArray(),
                CorrectorId = levels.CorrectorId,
                FinalAction = levels.FinalAction?.ConvertToByteArray(),
                LevelClass = levels.LevelClass,
                LevelName = levels.LevelName,
				OperatorId = levels.OperatorId,
				LevelColor = levels.LevelColor,
                Remark = levels.Remark,
                ProgramTypeId = levels.ProgramType?.ItemId ?? -1,
                Updated = levels.Updated
            };
        }

        public static FindingLevels ConvertCAA(this FindingLevelsDTO levels)
        {
            return new FindingLevels()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                OperatorId = levels.OperatorId,
				CorrectiveAction = Lifelength.ConvertFromByteArray(levels.CorrectiveAction),
                CorrectorId = levels.CorrectorId,
                FinalAction = Lifelength.ConvertFromByteArray(levels.FinalAction),
                LevelClass = levels.LevelClass,
                LevelName = levels.LevelName,
                LevelColor = levels.LevelColor,
                Remark = levels.Remark,
                ProgramType = ProgramType.GetItemById(levels.ProgramTypeId) ?? ProgramType.Unknown,
                Updated = levels.Updated
            };
        }

        public static CheckLists ConvertCAA(this CheckListDTO levels)
        {
            var res =  new CheckLists()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectorId = levels.CorrectorId,
                Updated = levels.Updated,
				Source = levels.Source,
				EditionId = levels.EditionId,
				OperatorId = levels.OperatorId,
				SettingsJSON =  levels.SettingsJSON
            };

            if (levels.CheckListRecords != null)
                res.CheckListRecords.AddRange(levels.CheckListRecords.Select(i => i.ConvertCAA()));

            return res;
        }

        public static CheckListDTO ConvertCAA(this CheckLists levels)
        {
            var res = new CheckListDTO()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectorId = levels.CorrectorId,
                Updated = levels.Updated,
                Source = levels.Source,
                EditionId = levels.EditionId,
                OperatorId = levels.OperatorId,
				SettingsJSON =  levels.SettingsJSON
			};

            if (levels.CheckListRecords != null)
            {
                res.CheckListRecords = new List<CheckListRecordDTO>();

				foreach (var rec in levels.CheckListRecords)
                    res.CheckListRecords.Add(rec.ConvertCAA());
            }
                

            return res;
        }
        
        
        
        public static StandartManual ConvertCAA(this StandartManualDTO levels)
        {
	        var res =  new StandartManual()
	        {
		        ItemId = levels.ItemId,
		        IsDeleted = levels.IsDeleted,
		        CorrectorId = levels.CorrectorId,
		        Updated = levels.Updated,
		        Source = levels.Source,
		        OperatorId = levels.OperatorId,
		        SettingsJSON =  levels.SettingsJSON
	        };
	        
	        return res;
        }

        public static StandartManualDTO ConvertCAA(this StandartManual levels)
        {
	        var res = new StandartManualDTO()
	        {
		        ItemId = levels.ItemId,
		        IsDeleted = levels.IsDeleted,
		        CorrectorId = levels.CorrectorId,
		        Updated = levels.Updated,
		        Source = levels.Source,
		        OperatorId = levels.OperatorId,
		        SettingsJSON =  levels.SettingsJSON
	        };
	        return res;
        }
        
        


        public static CheckListRevision ConvertCAA(this CheckListRevisionDTO levels)
        {
            var res = new CheckListRevision()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectorId = levels.CorrectorId,
                Updated = levels.Updated,
                OperatorId = levels.OperatorId,
                EffDate = levels.EffDate,
                Date = levels.Date,
                EditionId = levels.EditionId,
				Number = levels.Number,
				Status = (EditionRevisionStatus)levels.Status,
                Type = (RevisionType)levels.Type,
                SettingsJSON = levels.SettingsJSON,
            };


            return res;
        }

        public static CheckListRevisionDTO ConvertCAA(this CheckListRevision levels)
        {
            var res = new CheckListRevisionDTO()
            {
				ItemId = levels.ItemId,
				IsDeleted = levels.IsDeleted,
				CorrectorId = levels.CorrectorId,
				Updated = levels.Updated,
                EffDate = levels.EffDate,
                Date = levels.Date,
                EditionId = levels.EditionId,
                Status = (byte)levels.Status,
				OperatorId = levels.OperatorId,
				Number = levels.Number,
				Type = (byte)levels.Type,
				SettingsJSON = levels.SettingsJSON,
			};

            return res;
        }

        public static CheckListRevisionRecord ConvertCAA(this CheckListRevisionRecordDTO levels)
        {
            var res = new CheckListRevisionRecord()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectorId = levels.CorrectorId,
                Updated = levels.Updated,
                
				CheckListId = levels.CheckListId,
                ParentId = levels.ParentId,
                
                SettingsJSON = levels.SettingsJSON,
            };


            return res;
        }

        public static CheckListRevisionRecordDTO ConvertCAA(this CheckListRevisionRecord levels)
        {
            var res = new CheckListRevisionRecordDTO()
            {
                ItemId = levels.ItemId,
                IsDeleted = levels.IsDeleted,
                CorrectorId = levels.CorrectorId,
                Updated = levels.Updated,
                ParentId = levels.ParentId,
				
                CheckListId = levels.CheckListId,
                SettingsJSON = levels.SettingsJSON,
            };

            return res;
        }





		public static CheckListRecords ConvertCAA(this CheckListRecordDTO recordDto)
        {
            return new CheckListRecords()
            {
                ItemId = recordDto.ItemId,
                IsDeleted = recordDto.IsDeleted,
                CorrectorId = recordDto.CorrectorId,
                Updated = recordDto.Updated,
				Remark = recordDto.Remark,
				CheckListId = recordDto.CheckListId,
				OptionNumber = Option.GetItemById(recordDto.OptionNumber),
				Option = OptionType.GetItemById(recordDto.Option)

            };
        }

        public static CheckListRecordDTO ConvertCAA(this CheckListRecords recordDto)
        {
            return new CheckListRecordDTO()
            {
                ItemId = recordDto.ItemId,
                IsDeleted = recordDto.IsDeleted,
                CorrectorId = recordDto.CorrectorId,
                Updated = recordDto.Updated,
                Remark = recordDto.Remark,
                CheckListId = recordDto.CheckListId,
                OptionNumber = recordDto.OptionNumber.ItemId,
                Option = recordDto.Option.ItemId
            };
        }
        
        
        
        public static AuditPelRecord ConvertCAA(this AuditPelRecordDTO recordDto)
        {
	        return new AuditPelRecord()
	        {
		        ItemId = recordDto.ItemId,
		        IsDeleted = recordDto.IsDeleted,
		        CorrectorId = recordDto.CorrectorId,
		        Updated = recordDto.Updated,
		        CheckListId = recordDto.CheckListId,
		        SpecialistId = recordDto.SpecialistId,
		        AuditRecordId = recordDto.AuditRecordId,
		        SettingsJSON = recordDto.SettingsJSON,

	        };
        }

        public static AuditPelRecordDTO ConvertCAA(this AuditPelRecord recordDto)
        {
	        return new AuditPelRecordDTO()
	        {
		        ItemId = recordDto.ItemId,
		        IsDeleted = recordDto.IsDeleted,
		        CorrectorId = recordDto.CorrectorId,
		        Updated = recordDto.Updated,
		        CheckListId = recordDto.CheckListId,
		        SpecialistId = recordDto.SpecialistId,
		        AuditRecordId = recordDto.AuditRecordId,
		        SettingsJSON = recordDto.SettingsJSON,

	        };
        }


        public static CAAUser ConvertCAA(this CAAUserDTO oper)
        {
            return new CAAUser
			{
                ItemId = oper.ItemId,
                IsDeleted = oper.IsDeleted,
                Updated = oper.Updated,
                CorrectorId = oper.CorrectorId,
				Name = oper.Name,
                Login = oper.Login,
                Password = oper.Password,
                UserType = oper.CAAUserType,
                Surname = oper.Surname,
                PersonnelId = oper.PersonnelId,
                UiType = oper.UiType,
			};
        }


		public static CAAUserDTO ConvertCAA(this CAAUser oper)
        {
            return new CAAUserDTO
			{
                ItemId = oper.ItemId,
                IsDeleted = oper.IsDeleted,
                Updated = oper.Updated,
                CorrectorId = oper.CorrectorId,
                Name = oper.Name,
                Login = oper.Login,
				Password = oper.Password,
				CAAUserType = oper.UserType,
                Surname = oper.Surname,
                UiType = oper.UiType,
				PersonnelId = oper.PersonnelId
            };
        }

        public static Operator ConvertCAA(this CAAOperatorDTO operdto)
        {
            return new Operator()
            {
                ItemId = operdto.ItemId,
                IsDeleted = operdto.IsDeleted,
                Updated = operdto.Updated,
                CorrectorId = operdto.CorrectorId,
                Name = operdto.Name,
                LogoTypeImageByteView = operdto.LogoTypeWhite,
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


	}
}
