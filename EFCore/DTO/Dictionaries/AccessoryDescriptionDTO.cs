using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;
using EFCore.Interfaces;

namespace EFCore.DTO.Dictionaries
{
	//AircraftModel
	//[Condition("ModelingObjectTypeId", "7")]
	//ComponentModel
	//[Condition("ModelingObjectTypeId", "5")]
	//Product
	//[Condition("ModelingObjectTypeId", "-1")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AccessoryDescriptionDTO : BaseEntity, IFileDtoContainer
    {
		[DataMember]
	    public string Description { get; set; }

	    [DataMember]
		public string PartNumber { get; set; }

	    [DataMember]
		public int? StandartId { get; set; }

	    [DataMember]
		public string Manufacturer { get; set; }

	    [DataMember]
		public double? CostNew { get; set; }

	    [DataMember]
		public double? CostOverhaul { get; set; }

	    [DataMember]
		public double? CostServiceable { get; set; }

	    [DataMember]
		public int? Measure { get; set; }

	    [DataMember]
		public string Remarks { get; set; }

	    [DataMember]
		public string DefaultProduct { get; set; }

	    [DataMember]
		public int ModelingObjectTypeId { get; set; }

	    [DataMember]
		public int? ModelingObjectSubTypeId { get; set; }

	    [DataMember]
		public string Model { get; set; }

	    [DataMember]
		public string SubModel { get; set; }

	    [DataMember]
		public string FullName { get; set; }

	    [DataMember]
		public string ShortName { get; set; }

	    [DataMember]
		public string Designer { get; set; }

	    [DataMember]
		public string Code { get; set; }

	    [DataMember]
		public int? AtaChapterId { get; set; }

	    [DataMember]
		public short? ComponentClass { get; set; }

	    [DataMember]
		public int? ComponentModel { get; set; }

		[DataMember]
		public int? ComponentType { get; set; }

	    [DataMember]
		public bool IsDangerous { get; set; }

	    [DataMember]
	    public string DescRus { get; set; }

	    [DataMember]
	    public string HTS { get; set; }

		[DataMember]
		[Include]
	    public ATAChapterDTO ATAChapter { get; set; }

	    [DataMember]
		[Child]
	    public GoodStandartDTO GoodStandart { get; set; }

	    [DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1005)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

	    [DataMember]
	    [Child(FilterType.Equal, "ParentTypeId", 1005)]
	    public ICollection<KitSuppliersRelationDTO> SupplierRelations { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<DamageChartDTO> DamageChartDtos { get; set; }
		[DataMember]
		public ICollection<LifeLimitCategorieDTO> LifeLimitCategorieDtos { get; set; }
	    [DataMember]
		public ICollection<DefferedCategorieDTO> DefferedCategorieDtos { get; set; }
	    [DataMember]
		public ICollection<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
	    [DataMember]
		public ICollection<AircraftDTO> AircraftDtos { get; set; }
	    [DataMember]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
	    [DataMember]
		public ICollection<VehicleDTO> VehicleDtos { get; set; }
	    [DataMember]
		public ICollection<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }
	    [DataMember]
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
	    [DataMember]
		public ICollection<SpecialistLicenseDTO> SpecialistLicenseDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
	    [DataMember]
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }

	    #endregion
	}
}
