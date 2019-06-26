using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using EntityCore.Interfaces;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AccessoryDescriptions", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AccessoryDescriptionDTO : BaseEntity, IFileDtoContainer
    {
		[DataMember]
		[Column("Description")]
	    public string Description { get; set; }

	    [DataMember]
	    [Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		[DataMember]
		[Column("AltPartNumber"), MaxLength(256)]
		public string AltPartNumber { get; set; }

		[DataMember]
		[Column("Standart")]
		public int? StandartId { get; set; }

		[DataMember]
		[Column("Manufacturer"), MaxLength(256)]
		public string Manufacturer { get; set; }

		[DataMember]
		[Column("CostNew")]
		public double? CostNew { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		[DataMember]
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("DefaultProduct"), MaxLength(256)]
		public string DefaultProduct { get; set; }

		[DataMember]
		[Column("ModelingObjectTypeId"), Required]
		public int ModelingObjectTypeId { get; set; }

		[DataMember]
		[Column("ModelingObjectSubTypeId")]
		public int? ModelingObjectSubTypeId { get; set; }

		[DataMember]
		[Column("Model"), MaxLength(256)]
		public string Model { get; set; }

		[DataMember]
		[Column("SubModel"), MaxLength(256)]
		public string SubModel { get; set; }

		[DataMember]
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		[DataMember]
		[Column("ShortName"), MaxLength(256)]
		public string ShortName { get; set; }

		[DataMember]
		[Column("Designer"), MaxLength(256)]
		public string Designer { get; set; }

		[DataMember]
		[Column("Code"), MaxLength(256)]
		public string Code { get; set; }

		[DataMember]
		[Column("AtaChapter")]
		public int? AtaChapterId { get; set; }

		[DataMember]
		[Column("ComponentClass")]
		public short? ComponentClass { get; set; }

		[DataMember]
		[Column("ComponentModel")]
		public int? ComponentModel { get; set; }

		[DataMember]
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		[DataMember]
		[Column("IsDangerous"), Required]
		public bool IsDangerous { get; set; }

		[DataMember]
		[Column("DescRus")]
		public string DescRus { get; set; }

		[DataMember]
		[Column("HTS")]
		public string HTS { get; set; }

		[DataMember]
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

        [DataMember]
        [Column("IsEffectivity")]
		public string IsEffectivity { get; set; }

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
