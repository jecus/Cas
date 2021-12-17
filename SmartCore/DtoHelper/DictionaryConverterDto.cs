using System.Collections.Generic;
using System.Linq;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;

namespace SmartCore.DtoHelper
{
	public static class DictionaryConverterDto
	{
		public static AGWCategorieDTO Convert(this AGWCategory agwCategory)
		{
			return new AGWCategorieDTO
			{
				ItemId = agwCategory.ItemId,
				IsDeleted = agwCategory.IsDeleted,
				Updated = agwCategory.Updated,
				CorrectorId = agwCategory.CorrectorId,
				FullName = agwCategory.FullName,
				Gender = (short) agwCategory.Gender,
				MinAge = agwCategory.MinAge,
				MaxAge = agwCategory.MaxAge,
				WeightSummer = agwCategory.WeightSummer,
				WeightWinter = agwCategory.WeightWinter
			};
		}

		public static AGWCategory Convert(this AGWCategorieDTO agwCategorieDto)
		{
			return new AGWCategory
			{
				ItemId = agwCategorieDto.ItemId,
				IsDeleted = agwCategorieDto.IsDeleted,
				Updated = agwCategorieDto.Updated,
				CorrectorId = agwCategorieDto.CorrectorId,
				FullName = agwCategorieDto.FullName,
				Gender = agwCategorieDto.Gender != null ? (Gender) agwCategorieDto.Gender : Gender.NotApplicable,
				MinAge = agwCategorieDto.MinAge ?? default(int),
				MaxAge = agwCategorieDto.MaxAge ?? default(int),
				WeightSummer = agwCategorieDto.WeightSummer ?? default(int),
				WeightWinter = agwCategorieDto.WeightWinter ?? default(int)
			};
		}


		public static AccessoryDescriptionDTO Convert(this AircraftModel aircraftModel)
		{
			return new AccessoryDescriptionDTO
			{
				ItemId = aircraftModel.ItemId,
				IsDeleted = aircraftModel.IsDeleted,
				Updated = aircraftModel.Updated,
				CorrectorId = aircraftModel.CorrectorId,
				Model = aircraftModel.Name,
				PartNumber = aircraftModel.PartNumber,
				AltPartNumber = aircraftModel.AltPartNumber,
				AtaChapterId = aircraftModel.ATAChapter?.ItemId,
				GoodStandart = aircraftModel.Standart?.Convert(),
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
				ComponentClass = (short?) aircraftModel.GoodsClass?.ItemId,
				IsDangerous = aircraftModel.IsDangerous,
				SupplierRelations = aircraftModel.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
			};
		}

		public static AircraftModel ConvertToAircraftModel(this AccessoryDescriptionDTO aircraftModelDto)
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
				ATAChapter = aircraftModelDto.ATAChapter?.Convert(),
				Description = aircraftModelDto.Description,
				Standart = aircraftModelDto.GoodStandart?.Convert(),
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

			if (aircraftModelDto.SupplierRelations != null)
				value.SupplierRelations.AddRange(aircraftModelDto.SupplierRelations.Select(i => i.Convert()));

			return value;
		}


		public static AircraftOtherParameterDTO Convert(this AircraftOtherParameters parameters)
		{
			return new AircraftOtherParameterDTO
			{
				ItemId = parameters.ItemId,
				IsDeleted = parameters.IsDeleted,
				Updated = parameters.Updated,
				CorrectorId = parameters.CorrectorId,
				FullName = parameters.FullName,
				Name = parameters.ShortName
			};
		}

		public static AircraftOtherParameters Convert(this AircraftOtherParameterDTO parametersDto)
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


		public static AirportCodeDTO Convert(this AirportsCodes code)
		{
			return new AirportCodeDTO
			{
				ItemId = code.ItemId,
				IsDeleted = code.IsDeleted,
				Updated = code.Updated,
				CorrectorId = code.CorrectorId,
				FullName = code.FullName,
				City = code.City,
				Country = code.Country,
				Iata = code.ShortName,
				Icao = code.Icao,
				Iso = code.Iso
			};
		}

		public static AirportsCodes Convert(this AirportCodeDTO codeDto)
		{
			return new AirportsCodes
			{
				ItemId = codeDto.ItemId,
				IsDeleted = codeDto.IsDeleted,
				Updated = codeDto.Updated,
				CorrectorId = codeDto.CorrectorId,
				FullName = codeDto.FullName,
				City = codeDto.City,
				Country = codeDto.Country,
				ShortName = codeDto.Iata,
				Icao = codeDto.Icao,
				Iso = codeDto.Iso
			};
		}


		public static AirportDTO Convert(this Airport airport)
		{
			return new AirportDTO
			{
				ItemId = airport.ItemId,
				IsDeleted = airport.IsDeleted,
				Updated = airport.Updated,
				CorrectorId = airport.CorrectorId,
				ShortName = airport.ShortName,
				FullName = airport.FullName,
				Altitude = airport.Altitude,
				TimeBeginning = airport.TimeBeginning,
				TimeEnd = airport.TimeEnd
			};
		}

		public static Airport Convert(this AirportDTO airportDto)
		{
			return new Airport
			{
				ItemId = airportDto.ItemId,
				IsDeleted = airportDto.IsDeleted,
				Updated = airportDto.Updated,
				CorrectorId = airportDto.CorrectorId,
				ShortName = airportDto.ShortName,
				FullName = airportDto.FullName,
				Altitude = airportDto.Altitude ?? default(int),
				TimeBeginning = airportDto.TimeBeginning ?? default(int),
				TimeEnd = airportDto.TimeEnd ?? default(int)
			};
		}


		public static AccessoryDescriptionDTO Convert(this ComponentModel componentModel)
		{
			return new AccessoryDescriptionDTO
			{
				ItemId = componentModel.ItemId,
				IsDeleted = componentModel.IsDeleted,
				Updated = componentModel.Updated,
				CorrectorId = componentModel.CorrectorId,
				Model = componentModel.Name,
				PartNumber = componentModel.PartNumber,
				AltPartNumber = componentModel.AltPartNumber,
				AtaChapterId = componentModel.ATAChapter?.ItemId,
				Description = componentModel.Description,
				StandartId = componentModel.Standart?.ItemId,
				Manufacturer = componentModel.Manufacturer,
				CostNew = componentModel.CostNew,
				CostOverhaul = componentModel.CostOverhaul,
				CostServiceable = componentModel.CostServiceable,
				Measure = componentModel.Measure?.ItemId,
				Remarks = componentModel.Remarks,
				ModelingObjectTypeId = componentModel.ModelingObjectType?.ItemId ?? -1,
				ModelingObjectSubTypeId = componentModel.ManufactureReg?.ItemId,
				SubModel = componentModel.Series,
				FullName = componentModel.FullName,
				ShortName = componentModel.ShortName,
				Designer = componentModel.Designer,
				Code = componentModel.Code,
				DescRus = componentModel.DescRus,
				IsEffectivity = componentModel.IsEffectivity,
				IsForbidden = componentModel.IsForbidden,
				HTS = componentModel.HTS,
				ComponentClass = (short?) componentModel.GoodsClass?.ItemId,
				IsDangerous = componentModel.IsDangerous,
				EngineRef = componentModel.EngineRef,
				Limitation = componentModel.Limitation,
				Reason = componentModel.Reason,
				SupplierRelations = componentModel.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
			};
		}

		public static ComponentModel ConvertToComponentModel(this AccessoryDescriptionDTO componentModelDto)
		{
			var componentModel = new ComponentModel
			{
				ItemId = componentModelDto.ItemId,
				IsDeleted = componentModelDto.IsDeleted,
				Updated = componentModelDto.Updated,
				CorrectorId = componentModelDto.CorrectorId,
				Name = componentModelDto.Model,
				PartNumber = componentModelDto.PartNumber,
				AltPartNumber = componentModelDto.AltPartNumber,
				ATAChapter = componentModelDto.ATAChapter?.Convert(),
				Description = componentModelDto.Description,
				Standart = componentModelDto.GoodStandart?.Convert(),
				Manufacturer = componentModelDto.Manufacturer,
				CostNew = componentModelDto.CostNew ?? default(double),
				CostOverhaul = componentModelDto.CostOverhaul ?? default(double),
				CostServiceable = componentModelDto.CostServiceable ?? default(double),
				Measure = componentModelDto.Measure.HasValue ? Measure.Items.GetItemById(componentModelDto.Measure.Value) : Measure.Unknown,
				Remarks = componentModelDto.Remarks,
				ManufactureReg = componentModelDto.ModelingObjectSubTypeId.HasValue ? ManufactureRegion.Items.GetItemById(componentModelDto.ModelingObjectSubTypeId.Value) : ManufactureRegion.Unknown,
				Series = componentModelDto.SubModel,
				FullName = componentModelDto.FullName,
				ShortName = componentModelDto.ShortName,
				Designer = componentModelDto.Designer,
				Code = componentModelDto.Code,
				GoodsClass = componentModelDto.ComponentClass.HasValue ? GoodsClass.Items.GetItemById(componentModelDto.ComponentClass.Value) : GoodsClass.Unknown,
				IsDangerous = componentModelDto.IsDangerous,
				IsEffectivity = componentModelDto.IsEffectivity,
				IsForbidden = componentModelDto.IsForbidden,
				DescRus = componentModelDto.DescRus,
				HTS = componentModelDto.HTS,
				EngineRef = componentModelDto.EngineRef,
				Limitation = componentModelDto.Limitation,
				Reason = componentModelDto.Reason
			};

			if (componentModelDto.SupplierRelations != null)
				componentModel.SupplierRelations.AddRange(componentModelDto.SupplierRelations.Select(i => i.Convert()));

			return componentModel;
		}


		public static AccessoryDescriptionDTO Convert(this Product product)
		{
			return new AccessoryDescriptionDTO
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
				ComponentClass = (short?) product.GoodsClass?.ItemId,
				IsDangerous = product.IsDangerous,
				DescRus = product.DescRus,
				HTS = product.HTS,
				Reference = product.Reference,
				IsEffectivity = product.IsEffectivity,
				IsForbidden = product.IsForbidden,
				EngineRef = product.EngineRef,
				Limitation = product.Limitation,
				Reason = product.Reason,
				SupplierRelations = product.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
			};
		}

		public static Product ConvertToProduct(this AccessoryDescriptionDTO productDto)
		{
			var product =  new Product
			{
				ItemId = productDto.ItemId,
				IsDeleted = productDto.IsDeleted,
				Updated = productDto.Updated,
				CorrectorId = productDto.CorrectorId,
				Name = productDto.Model,
				PartNumber = productDto.PartNumber,
				AltPartNumber = productDto.AltPartNumber,
				ATAChapter = productDto.ATAChapter?.Convert(),
				Description = productDto.Description,
				Standart = productDto.GoodStandart?.Convert(),
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
				ProductType = productDto.ModelingObjectTypeId == -1 ? ProductType.EquipmentandMaterial: ProductType.ComponentModel
			};

			if (productDto.SupplierRelations != null)
				product.SupplierRelations.AddRange(productDto.SupplierRelations.Select(i => i.Convert()));

			return product;

		}


		public static ATAChapterDTO Convert(this AtaChapter ataChapter)
		{
			return new ATAChapterDTO
			{
				ItemId = ataChapter.ItemId,
				IsDeleted = ataChapter.IsDeleted,
				Updated = ataChapter.Updated,
				CorrectorId = ataChapter.CorrectorId,
				FullName = ataChapter.FullName,
				ShortName = ataChapter.ShortName
			};
		}

		public static AtaChapter Convert(this ATAChapterDTO ataChapterDto)
		{
			return new AtaChapter
			{
				ItemId = ataChapterDto.ItemId,
				IsDeleted = ataChapterDto.IsDeleted,
				Updated = ataChapterDto.Updated,
				CorrectorId = ataChapterDto.CorrectorId,
				FullName = ataChapterDto.FullName,
				ShortName = ataChapterDto.ShortName
			};
		}


		public static GoodStandartDTO Convert(this GoodStandart standart)
		{
			return new GoodStandartDTO
			{
				ItemId = standart.ItemId,
				IsDeleted = standart.IsDeleted,
				Updated = standart.Updated,
				CorrectorId = standart.CorrectorId,
				Name = standart.FullName,
				PartNumber = standart.PartNumber,
				Description = standart.Description,
				Remarks = standart.Remarks,
				DefaultProductId = standart.DefaultProductId,
				ComponentType = standart.GoodsClass?.ItemId
			};
		}

		public static GoodStandart Convert(this GoodStandartDTO standartDto)
		{
			return new GoodStandart
			{
				ItemId = standartDto.ItemId,
				IsDeleted = standartDto.IsDeleted,
				Updated = standartDto.Updated,
				CorrectorId = standartDto.CorrectorId,
				FullName = standartDto.Name,
				PartNumber = standartDto.PartNumber,
				Description = standartDto.Description,
				Remarks = standartDto.Remarks,
				DefaultProductId = standartDto.DefaultProductId ?? default(int),
				GoodsClass = standartDto.ComponentType.HasValue ? GoodsClass.Items.GetItemById(standartDto.ComponentType.Value) : GoodsClass.Unknown
			};
		}


		public static CruiseLevelDTO Convert(this CruiseLevel cruiseLevel)
		{
			return new CruiseLevelDTO
			{
				ItemId = cruiseLevel.ItemId,
				IsDeleted = cruiseLevel.IsDeleted,
				Updated = cruiseLevel.Updated,
				CorrectorId = cruiseLevel.CorrectorId,
				FullName = cruiseLevel.FullName,
				Feet = cruiseLevel.Feet,
				IVFR = cruiseLevel.IVFR,
				Meter = cruiseLevel.Meter,
				Track = cruiseLevel.Track
			};
		}

		public static CruiseLevel Convert(this CruiseLevelDTO cruiseLevelDto)
		{
			return new CruiseLevel
			{
				ItemId = cruiseLevelDto.ItemId,
				IsDeleted = cruiseLevelDto.IsDeleted,
				Updated = cruiseLevelDto.Updated,
				CorrectorId = cruiseLevelDto.CorrectorId,
				FullName = cruiseLevelDto.FullName,
				Feet = cruiseLevelDto.Feet ?? default(int),
				IVFR = cruiseLevelDto.IVFR,
				Meter = cruiseLevelDto.Meter ?? default(int),
				Track = cruiseLevelDto.Track
			};
		}

		public static DamageChartDTO Convert(this DamageChart damagechart)
		{
			return new DamageChartDTO
			{
				ItemId = damagechart.ItemId,
				IsDeleted = damagechart.IsDeleted,
				Updated = damagechart.Updated,
				CorrectorId = damagechart.CorrectorId,
				ChartName = damagechart.ChartName,
				AircraftModelId = damagechart.AircraftModel?.ItemId
			};
		}

		public static DamageChart Convert(this DamageChartDTO damagechartDto)
		{
			return new DamageChart
			{
				ItemId = damagechartDto.ItemId,
				IsDeleted = damagechartDto.IsDeleted,
				Updated = damagechartDto.Updated,
				CorrectorId = damagechartDto.CorrectorId,
				ChartName = damagechartDto.ChartName,
				AircraftModel = ConvertToAircraftModel(damagechartDto.AccessoryDescription),
			};
		}

		public static DefferedCategorieDTO Convert(this DeferredCategory defferedcategorie)
		{
			return new DefferedCategorieDTO
			{
				ItemId = defferedcategorie.ItemId,
				IsDeleted = defferedcategorie.IsDeleted,
				Updated = defferedcategorie.Updated,
				CorrectorId = defferedcategorie.CorrectorId,
				CategoryName = defferedcategorie.FullName,
				AircraftModelId = defferedcategorie.AircraftModel?.ItemId,
				Threshold = defferedcategorie.Threshold?.ToBinary()
			};
		}

		public static DeferredCategory Convert(this DefferedCategorieDTO ddefferedcategorieDto)
		{
			return new DeferredCategory
			{
				ItemId = ddefferedcategorieDto.ItemId,
				IsDeleted = ddefferedcategorieDto.IsDeleted,
				Updated = ddefferedcategorieDto.Updated,
				CorrectorId = ddefferedcategorieDto.CorrectorId,
				FullName = ddefferedcategorieDto.CategoryName,
				AircraftModel = ddefferedcategorieDto.AccessoryDescription?.ConvertToAircraftModel(),
				//TODO:Разобраться почему private set
				//Threshold = DirectiveThreshold.ConvertFromByteArray(ddefferedcategorieDto.Threshold)
			};
		}

		public static DepartmentDTO Convert(this Department department)
		{
			return new DepartmentDTO
			{
				ItemId = department.ItemId,
				IsDeleted = department.IsDeleted,
				Updated = department.Updated,
				CorrectorId = department.CorrectorId,
				Name = department.ShortName,
				FullName = department.FullName,
				Address = department.Address,
				Phone = department.Phone,
				Fax = department.Fax,
				Email = department.Email,
				Website = department.Website
			};
		}

		public static Department Convert(this DepartmentDTO departmentDto)
		{
			return new Department
			{
				ItemId = departmentDto.ItemId,
				IsDeleted = departmentDto.IsDeleted,
				Updated = departmentDto.Updated,
				CorrectorId = departmentDto.CorrectorId,
				ShortName = departmentDto.Name,
				FullName = departmentDto.FullName,
				Address = departmentDto.Address,
				Phone = departmentDto.Phone,
				Fax = departmentDto.Fax,
				Email = departmentDto.Email,
				Website = departmentDto.Website
			};
		}

		public static DocumentSubTypeDTO Convert(this DocumentSubType documentsubtype)
		{
			return new DocumentSubTypeDTO
			{
				ItemId = documentsubtype.ItemId,
				IsDeleted = documentsubtype.IsDeleted,
				Updated = documentsubtype.Updated,
				CorrectorId = documentsubtype.CorrectorId,
				Name = documentsubtype.FullName,
				DocumentTypeId = documentsubtype.DocumentTypeId,
			};
		}

		public static DocumentSubType Convert(this DocumentSubTypeDTO documentsubtypeDto)
		{
			return new DocumentSubType
			{
				ItemId = documentsubtypeDto.ItemId,
				IsDeleted = documentsubtypeDto.IsDeleted,
				Updated = documentsubtypeDto.Updated,
				CorrectorId = documentsubtypeDto.CorrectorId,
				FullName = documentsubtypeDto.Name,
				DocumentTypeId = documentsubtypeDto.DocumentTypeId
			};
		}

		public static EmployeeSubjectDTO Convert(this EmployeeSubject employeesubject)
		{
			return new EmployeeSubjectDTO
			{
				ItemId = employeesubject.ItemId,
				IsDeleted = employeesubject.IsDeleted,
				Updated = employeesubject.Updated,
				CorrectorId = employeesubject.CorrectorId,
				Name = employeesubject.ShortName,
				FullName = employeesubject.FullName,
				LicenceTypeId = employeesubject.LicenceTypeId
			};
		}

		public static EmployeeSubject Convert(this EmployeeSubjectDTO employeesubjectDto)
		{
			return new EmployeeSubject
			{
				ItemId = employeesubjectDto.ItemId,
				IsDeleted = employeesubjectDto.IsDeleted,
				Updated = employeesubjectDto.Updated,
				CorrectorId = employeesubjectDto.CorrectorId,
				ShortName = employeesubjectDto.Name,
				FullName = employeesubjectDto.FullName,
				LicenceTypeId = employeesubjectDto.LicenceTypeId ?? default(int)
			};
		}

		public static EventCategorieDTO Convert(this EventCategory eventcategorie)
		{
			return new EventCategorieDTO
			{
				ItemId = eventcategorie.ItemId,
				IsDeleted = eventcategorie.IsDeleted,
				Updated = eventcategorie.Updated,
				CorrectorId = eventcategorie.CorrectorId,
				Weight = eventcategorie.Weight,
				MinCompareOp = eventcategorie.MinCompareOperation?.ItemId,
				EventCountMinPeriod = eventcategorie.EventCountMinPeriod,
				MinReportPeriod = eventcategorie.MinReportPeriod?.ConvertToByteArray(),
				MaxCompareOp = eventcategorie.MaxCompareOperation?.ItemId,
				EventCountMaxPeriod = eventcategorie.EventCountMaxPeriod,
				MaxReportPeriod = eventcategorie.MinReportPeriod?.ConvertToByteArray()
			};
		}

		public static EventCategory Convert(this EventCategorieDTO eventcategorieDto)
		{
			return new EventCategory
			{
				ItemId = eventcategorieDto.ItemId,
				IsDeleted = eventcategorieDto.IsDeleted,
				Updated = eventcategorieDto.Updated,
				CorrectorId = eventcategorieDto.CorrectorId,
				Weight = eventcategorieDto.Weight ?? default(int),
				MinCompareOperation = eventcategorieDto.MinCompareOp.HasValue ? LogicOperation.Items.GetItemById(eventcategorieDto.MinCompareOp.Value) : LogicOperation.Unknown,
				EventCountMinPeriod = eventcategorieDto.EventCountMinPeriod ?? default(int),
				MinReportPeriod = Lifelength.ConvertFromByteArray(eventcategorieDto.MinReportPeriod),
				MaxCompareOperation = eventcategorieDto.MaxCompareOp.HasValue ? LogicOperation.Items.GetItemById(eventcategorieDto.MaxCompareOp.Value) : LogicOperation.Unknown,
				EventCountMaxPeriod = eventcategorieDto.EventCountMaxPeriod ?? default(int),
				MaxReportPeriod = Lifelength.ConvertFromByteArray(eventcategorieDto.MaxReportPeriod),
				FullName = EventCategory.Items.FirstOrDefault(i => i.ItemId == eventcategorieDto.ItemId)?.FullName,
				ShortName = EventCategory.Items.FirstOrDefault(i => i.ItemId == eventcategorieDto.ItemId)?.ShortName
			};
		}

		public static EventClassDTO Convert(this EventClass eventclass)
		{
			return new EventClassDTO
			{
				ItemId = eventclass.ItemId,
				IsDeleted = eventclass.IsDeleted,
				Updated = eventclass.Updated,
				CorrectorId = eventclass.CorrectorId,
				FullName = eventclass.FullName,
				People = eventclass.PeopleDamage?.ItemId,
				Failure = eventclass.FailureViolationDeviation?.ItemId,
				Regularity = eventclass.Regularity?.ItemId,
				Property = eventclass.PropertyDamage?.ItemId,
				Environmental = eventclass.EnvironmentalDamage?.ItemId,
				Reputation = eventclass.ReputationDamage?.ItemId,
				Weight = eventclass.Weight
			};
		}

		public static EventClass Convert(this EventClassDTO eventclassDto)
		{
			return new EventClass
			{
				ItemId = eventclassDto.ItemId,
				IsDeleted = eventclassDto.IsDeleted,
				Updated = eventclassDto.Updated,
				CorrectorId = eventclassDto.CorrectorId,
				FullName = eventclassDto.FullName,
				PeopleDamage = eventclassDto.People.HasValue ? HumanDamage.Items.GetItemById(eventclassDto.People.Value) : HumanDamage.UNK,
				FailureViolationDeviation = eventclassDto.Failure.HasValue ? FailureViolationDeviation.Items.GetItemById(eventclassDto.Failure.Value) : FailureViolationDeviation.UNK,
				Regularity = eventclassDto.Regularity.HasValue ? Regularity.Items.GetItemById(eventclassDto.Regularity.Value) : Regularity.UNK,
				PropertyDamage = eventclassDto.Property.HasValue ? PropertyDamage.Items.GetItemById(eventclassDto.Property.Value) : PropertyDamage.UNK,
				EnvironmentalDamage = eventclassDto.Environmental.HasValue ? EnvironmentalDamage.Items.GetItemById(eventclassDto.Environmental.Value) : EnvironmentalDamage.UNK,
				ReputationDamage = eventclassDto.Reputation.HasValue ? ReputationDamage.Items.GetItemById(eventclassDto.Reputation.Value) : ReputationDamage.UNK
			};
		}

		public static FlightNumDTO Convert(this FlightNum flightnum)
		{
			return new FlightNumDTO
			{
				ItemId = flightnum.ItemId,
				IsDeleted = flightnum.IsDeleted,
				Updated = flightnum.Updated,
				CorrectorId = flightnum.CorrectorId,
				FlightNumber = flightnum.FullName
			};
		}

		public static FlightNum Convert(this FlightNumDTO flightnumDto)
		{
			return new FlightNum
			{
				ItemId = flightnumDto.ItemId,
				IsDeleted = flightnumDto.IsDeleted,
				Updated = flightnumDto.Updated,
				CorrectorId = flightnumDto.CorrectorId,
				FullName = flightnumDto.FlightNumber ?? ""
			};
		}

		public static LicenseRemarkRightDTO Convert(this LicenseRemarkRights licenseremarkright)
		{
			return new LicenseRemarkRightDTO
			{
				ItemId = licenseremarkright.ItemId,
				IsDeleted = licenseremarkright.IsDeleted,
				Updated = licenseremarkright.Updated,
				CorrectorId = licenseremarkright.CorrectorId,
				Name = licenseremarkright.ShortName,
				FullName = licenseremarkright.FullName
			};
		}

		public static LicenseRemarkRights Convert(this LicenseRemarkRightDTO licenseremarkrightDto)
		{
			return new LicenseRemarkRights
			{
				ItemId = licenseremarkrightDto.ItemId,
				IsDeleted = licenseremarkrightDto.IsDeleted,
				Updated = licenseremarkrightDto.Updated,
				CorrectorId = licenseremarkrightDto.CorrectorId,
				ShortName = licenseremarkrightDto.Name,
				FullName = licenseremarkrightDto.FullName
			};
		}
		public static LifeLimitCategorieDTO Convert(this LLPLifeLimitCategory lifelimitcategorie)
		{
			return new LifeLimitCategorieDTO
			{
				ItemId = lifelimitcategorie.ItemId,
				IsDeleted = lifelimitcategorie.IsDeleted,
				Updated = lifelimitcategorie.Updated,
				CorrectorId = lifelimitcategorie.CorrectorId,
				CategoryType = lifelimitcategorie.CategoryType.ItemId.ToString(), 
				CategoryName = lifelimitcategorie.Category,
				AircraftModelId = lifelimitcategorie.AircraftModel?.ItemId,
				AccessoryDescription = lifelimitcategorie.AircraftModel?.Convert()
			};
		}

		public static LLPLifeLimitCategory Convert(this LifeLimitCategorieDTO lifelimitcategorieDto)
		{
			//Todo: Колхоз в базе поменять надо на проде
			if (lifelimitcategorieDto.CategoryType == "A")
				lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.A.ItemId.ToString();
			else if (lifelimitcategorieDto.CategoryType == "B")
				lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.B.ItemId.ToString();
			else if (lifelimitcategorieDto.CategoryType == "C")
				lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.C.ItemId.ToString();
			else if (lifelimitcategorieDto.CategoryType == "D")
				lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.D.ItemId.ToString();

			if(lifelimitcategorieDto.CategoryType == "-1")
			{
				if (lifelimitcategorieDto.CategoryName == "A")
					lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.A.ItemId.ToString();
				else if (lifelimitcategorieDto.CategoryName == "B" || lifelimitcategorieDto.CategoryName =="3B1")
					lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.B.ItemId.ToString();
				else if (lifelimitcategorieDto.CategoryName == "C")
					lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.C.ItemId.ToString();
				else if (lifelimitcategorieDto.CategoryName == "D")
					lifelimitcategorieDto.CategoryType = LLPLifeLimitCategoryType.D.ItemId.ToString();
			}

			return new LLPLifeLimitCategory()
			{
				ItemId = lifelimitcategorieDto.ItemId,
				IsDeleted = lifelimitcategorieDto.IsDeleted,
				Updated = lifelimitcategorieDto.Updated,
				CorrectorId = lifelimitcategorieDto.CorrectorId,
				CategoryType = LLPLifeLimitCategoryType.Items.GetItemById(int.Parse(lifelimitcategorieDto.CategoryType)) != null ? (LLPLifeLimitCategoryType)LLPLifeLimitCategoryType.Items.GetItemById(int.Parse(lifelimitcategorieDto.CategoryType)) : LLPLifeLimitCategoryType.Unknown,
				Category = lifelimitcategorieDto.CategoryName,
				AircraftModel = lifelimitcategorieDto.AccessoryDescription?.ConvertToAircraftModel(),
			};
		}

		public static LocationDTO Convert(this Locations location)
		{
			return new LocationDTO
			{
				ItemId = location.ItemId,
				IsDeleted = location.IsDeleted,
				Updated = location.Updated,
				CorrectorId = location.CorrectorId,
				Name = location.ShortName,
				FullName = location.FullName,
				LocationsTypeId = location.LocationsType?.ItemId ?? default(int),
				LocationsType = location.LocationsType?.Convert()
			};
		}

		public static Locations Convert(this LocationDTO locationDto)
		{
			return new Locations
			{
				ItemId = locationDto.ItemId,
				IsDeleted = locationDto.IsDeleted,
				Updated = locationDto.Updated,
				CorrectorId = locationDto.CorrectorId,
				ShortName = locationDto.Name,
				FullName = locationDto.FullName,
				LocationsType = locationDto.LocationsType?.Convert()
			};
		}

		public static LocationsType Convert(this LocationsTypeDTO locationsTypeDto)
		{
			var loc =  new LocationsType
			{
				ItemId = locationsTypeDto.ItemId,
				IsDeleted = locationsTypeDto.IsDeleted,
				Updated = locationsTypeDto.Updated,
				CorrectorId = locationsTypeDto.CorrectorId,
				FullName = locationsTypeDto.FullName,
				ShortName = locationsTypeDto.Name,
			};

			var department = locationsTypeDto.Department?.Convert();
			if (department != null)
				loc.Department = department.IsDeleted ? Department.Unknown : department;
			else loc.Department = Department.Unknown;

			return loc;
		}

		public static LocationsTypeDTO Convert(this LocationsType locationsType)
		{
			return new LocationsTypeDTO
			{
				ItemId = locationsType.ItemId,
				IsDeleted = locationsType.IsDeleted,
				Updated = locationsType.Updated,
				CorrectorId = locationsType.CorrectorId,
				FullName = locationsType.FullName,
				Name = locationsType.ShortName,
				DepartmentId = locationsType.Department?.ItemId ?? -1
			};
		}


		public static NomenclatureDTO Convert(this Nomenclatures nomenclature)
		{
			return new NomenclatureDTO
			{
				ItemId = nomenclature.ItemId,
				IsDeleted = nomenclature.IsDeleted,
				Updated = nomenclature.Updated,
				CorrectorId = nomenclature.CorrectorId,
				Name = nomenclature.ShortName,
				FullName = nomenclature.FullName,
				DepartmentId = nomenclature.Department?.ItemId ?? -1,
				Department = nomenclature.Department?.Convert()
			};
		}

		public static Nomenclatures Convert(this NomenclatureDTO nomenclatureDto)
		{
			var nom =  new Nomenclatures
			{
				ItemId = nomenclatureDto.ItemId,
				IsDeleted = nomenclatureDto.IsDeleted,
				Updated = nomenclatureDto.Updated,
				CorrectorId = nomenclatureDto.CorrectorId,
				ShortName = nomenclatureDto.Name,
				FullName = nomenclatureDto.FullName,
			};

			var department = nomenclatureDto.Department?.Convert();
			if (department != null)
				nom.Department = department.IsDeleted ? Department.Unknown : department;
			else nom.Department = Department.Unknown;

			return nom;
		}

		public static NonRoutineJobDTO Convert(this NonRoutineJob nonrutinejob)
		{
			return new NonRoutineJobDTO
			{
				ItemId = nonrutinejob.ItemId,
				IsDeleted = nonrutinejob.IsDeleted,
				Updated = nonrutinejob.Updated,
				CorrectorId = nonrutinejob.CorrectorId,
				ATAChapterId = nonrutinejob.ATAChapter?.ItemId,
				Title = nonrutinejob.Title,
				Description = nonrutinejob.Description,
				ManHours = nonrutinejob.ManHours,
				Cost = nonrutinejob.Cost,
				KitRequired = nonrutinejob.KitRequired,
			};
		}

		public static NonRoutineJob Convert(this NonRoutineJobDTO nonrutinejobDto)
		{
			return new NonRoutineJob
			{
				ItemId = nonrutinejobDto.ItemId,
				IsDeleted = nonrutinejobDto.IsDeleted,
				Updated = nonrutinejobDto.Updated,
				CorrectorId = nonrutinejobDto.CorrectorId,
				ATAChapter = nonrutinejobDto.ATAChapter?.Convert(),
				Title = nonrutinejobDto.Title,
				Description = nonrutinejobDto.Description,
				ManHours = nonrutinejobDto.ManHours ?? default(double),
				Cost = nonrutinejobDto.Cost ?? default(double),
				KitRequired = nonrutinejobDto.KitRequired
			};
		}

		public static ReasonDTO Convert(this Reason reason)
		{
			return new ReasonDTO
			{
				ItemId = reason.ItemId,
				IsDeleted = reason.IsDeleted,
				Updated = reason.Updated,
				CorrectorId = reason.CorrectorId,
				Name = reason.FullName,
				Category = reason.Category
			};
		}

		public static Reason Convert(this ReasonDTO reasonDto)
		{
			return new Reason
			{
				ItemId = reasonDto.ItemId,
				IsDeleted = reasonDto.IsDeleted,
				Updated = reasonDto.Updated,
				CorrectorId = reasonDto.CorrectorId,
				FullName = reasonDto.Name,
				Category = reasonDto.Category
			};
		}

		public static RestrictionDTO Convert(this LicenseRestriction licenserestriction)
		{
			return new RestrictionDTO
			{
				ItemId = licenserestriction.ItemId,
				IsDeleted = licenserestriction.IsDeleted,
				Updated = licenserestriction.Updated,
				CorrectorId = licenserestriction.CorrectorId,
				Name = licenserestriction.ShortName,
				FullName = licenserestriction.FullName
			};
		}

		public static LicenseRestriction Convert(this RestrictionDTO licenserestrictionDto)
		{
			return new LicenseRestriction
			{
				ItemId = licenserestrictionDto.ItemId,
				IsDeleted = licenserestrictionDto.IsDeleted,
				Updated = licenserestrictionDto.Updated,
				CorrectorId = licenserestrictionDto.CorrectorId,
				ShortName = licenserestrictionDto.Name,
				FullName = licenserestrictionDto.FullName
			};
		}

		public static SchedulePeriodDTO Convert(this SchedulePeriods scheduleperiod)
		{
			return new SchedulePeriodDTO
			{
				ItemId = scheduleperiod.ItemId,
				IsDeleted = scheduleperiod.IsDeleted,
				Updated = scheduleperiod.Updated,
				CorrectorId = scheduleperiod.CorrectorId,
				Schedule = (int)scheduleperiod.Schedule,
				DateTo = scheduleperiod.To,
				DateFrom = scheduleperiod.From
			};
		}

		public static SchedulePeriods Convert(this SchedulePeriodDTO scheduleperiodDto)
		{
			return new SchedulePeriods
			{
				ItemId = scheduleperiodDto.ItemId,
				IsDeleted = scheduleperiodDto.IsDeleted,
				Updated = scheduleperiodDto.Updated,
				CorrectorId = scheduleperiodDto.CorrectorId,
				Schedule = (Schedule) scheduleperiodDto.Schedule,
				To = scheduleperiodDto.DateTo ?? DateTimeExtend.GetCASMinDateTime(),
				From = scheduleperiodDto.DateFrom ?? DateTimeExtend.GetCASMinDateTime()
			};
		}

		public static ServiceTypeDTO Convert(this ServiceType servicetype)
		{
			return new ServiceTypeDTO
			{
				ItemId = servicetype.ItemId,
				IsDeleted = servicetype.IsDeleted,
				Updated = servicetype.Updated,
				CorrectorId = servicetype.CorrectorId,
				Name = servicetype.ShortName,
				FullName = servicetype.FullName
			};
		}

		public static ServiceType Convert(this ServiceTypeDTO servicetypeDto)
		{
			return new ServiceType
			{
				ItemId = servicetypeDto.ItemId,
				IsDeleted = servicetypeDto.IsDeleted,
				Updated = servicetypeDto.Updated,
				CorrectorId = servicetypeDto.CorrectorId,
				ShortName = servicetypeDto.Name,
				FullName = servicetypeDto.FullName
			};
		}

		public static SpecializationDTO Convert(this Specialization specialization)
		{
			return new SpecializationDTO
			{
				ItemId = specialization.ItemId,
				IsDeleted = specialization.IsDeleted,
				Updated = specialization.Updated,
				CorrectorId = specialization.CorrectorId,
				ShortName = specialization.ShortName,
				FullName = specialization.FullName,
				DepartmentId = specialization.Department?.ItemId ?? -1,
				Level = specialization.Level,
				KeyPersonel = specialization.KeyPersonel,
				Department = specialization.Department?.Convert()
			};
		}

		public static Specialization Convert(this SpecializationDTO specializationDto)
		{
			var spec =  new Specialization
			{
				ItemId = specializationDto.ItemId,
				IsDeleted = specializationDto.IsDeleted,
				Updated = specializationDto.Updated,
				CorrectorId = specializationDto.CorrectorId,
				ShortName = specializationDto.ShortName,
				FullName = specializationDto.FullName,
				Level = specializationDto.Level,
				KeyPersonel = specializationDto.KeyPersonel
			};


			var department = specializationDto.Department?.Convert();
			if (department != null)
				spec.Department = department.IsDeleted ? Department.Unknown : department;
			else spec.Department = Department.Unknown;

			return spec;
		}

		public static TripNameDTO Convert(this TripName tripname)
		{
			return new TripNameDTO
			{
				ItemId = tripname.ItemId,
				IsDeleted = tripname.IsDeleted,
				Updated = tripname.Updated,
				CorrectorId = tripname.CorrectorId,
				TripName = tripname.FullName
			};
		}

		public static TripName Convert(this TripNameDTO tripnameDto)
		{
			return new TripName
			{
				ItemId = tripnameDto.ItemId,
				IsDeleted = tripnameDto.IsDeleted,
				Updated = tripnameDto.Updated,
				CorrectorId = tripnameDto.CorrectorId,
				FullName = tripnameDto.TripName
			};
		}
	}
}
