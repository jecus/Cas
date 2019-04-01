using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
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
				Model = aircraftModel.Name,
				PartNumber = aircraftModel.PartNumber,
				AtaChapterId = aircraftModel.ATAChapter?.ItemId,
				//ATAChapter = aircraftModel.ATAChapter?.Convert(),
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
				Name = aircraftModelDto.Model,
				PartNumber = aircraftModelDto.PartNumber,
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
				Model = componentModel.Name,
				PartNumber = componentModel.PartNumber,
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
				HTS = componentModel.HTS,
				ComponentClass = (short?) componentModel.GoodsClass?.ItemId,
				IsDangerous = componentModel.IsDangerous,
				SupplierRelations = componentModel.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
			};
		}

		public static ComponentModel ConvertToComponentModel(this AccessoryDescriptionDTO componentModelDto)
		{
			var componentModel = new ComponentModel
			{
				ItemId = componentModelDto.ItemId,
				IsDeleted = componentModelDto.IsDeleted,
				Name = componentModelDto.Model,
				PartNumber = componentModelDto.PartNumber,
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
				DescRus = componentModelDto.DescRus,
				HTS = componentModelDto.HTS,
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
				Model = product.Name,
				PartNumber = product.PartNumber,
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
				SupplierRelations = product.SupplierRelations?.Select(i => i.Convert()) as ICollection<KitSuppliersRelationDTO>,
			};
		}

		public static Product ConvertToProduct(this AccessoryDescriptionDTO productDto)
		{
			var product =  new Product
			{
				ItemId = productDto.ItemId,
				IsDeleted = productDto.IsDeleted,
				Name = productDto.Model,
				PartNumber = productDto.PartNumber,
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
				ChartName = damagechart.ChartName,
				AircraftModelId = damagechart.AircraftModel?.ItemId,
				AccessoryDescription = damagechart.AircraftModel?.Convert()
			};
		}

		public static DamageChart Convert(this DamageChartDTO damagechartDto)
		{
			return new DamageChart
			{
				ItemId = damagechartDto.ItemId,
				IsDeleted = damagechartDto.IsDeleted,
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
				Name = department.ShortName,
				FullName = department.FullName
			};
		}

		public static Department Convert(this DepartmentDTO departmentDto)
		{
			return new Department
			{
				ItemId = departmentDto.ItemId,
				IsDeleted = departmentDto.IsDeleted,
				ShortName = departmentDto.Name,
				FullName = departmentDto.FullName
			};
		}

		public static DocumentSubTypeDTO Convert(this DocumentSubType documentsubtype)
		{
			return new DocumentSubTypeDTO
			{
				ItemId = documentsubtype.ItemId,
				IsDeleted = documentsubtype.IsDeleted,
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
				FlightNumber = flightnum.FullName
			};
		}

		public static FlightNum Convert(this FlightNumDTO flightnumDto)
		{
			return new FlightNum
			{
				ItemId = flightnumDto.ItemId,
				IsDeleted = flightnumDto.IsDeleted,
				FullName = flightnumDto.FlightNumber ?? ""
			};
		}

		public static LicenseRemarkRightDTO Convert(this LicenseRemarkRights licenseremarkright)
		{
			return new LicenseRemarkRightDTO
			{
				ItemId = licenseremarkright.ItemId,
				IsDeleted = licenseremarkright.IsDeleted,
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
				TripName = tripname.FullName
			};
		}

		public static TripName Convert(this TripNameDTO tripnameDto)
		{
			return new TripName
			{
				ItemId = tripnameDto.ItemId,
				IsDeleted = tripnameDto.IsDeleted,
				FullName = tripnameDto.TripName
			};
		}
	}
}
