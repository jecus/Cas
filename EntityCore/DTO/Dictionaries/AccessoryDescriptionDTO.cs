using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using EntityCore.Interfaces;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AccessoryDescriptions", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class AccessoryDescriptionDTO : BaseEntity, IFileDtoContainer
    {
		
		[Column("Description")]
	    public string Description { get; set; }

	    
	    [Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		
		[Column("AltPartNumber"), MaxLength(256)]
		public string AltPartNumber { get; set; }

		
		[Column("Standart")]
		public int? StandartId { get; set; }

		
		[Column("Manufacturer"), MaxLength(256)]
		public string Manufacturer { get; set; }

		
		[Column("CostNew")]
		public double? CostNew { get; set; }

		
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("DefaultProduct"), MaxLength(256)]
		public string DefaultProduct { get; set; }

		
		[Column("ModelingObjectTypeId"), Required]
		public int ModelingObjectTypeId { get; set; }

		
		[Column("ModelingObjectSubTypeId")]
		public int? ModelingObjectSubTypeId { get; set; }

		
		[Column("Model"), MaxLength(256)]
		public string Model { get; set; }

		
		[Column("SubModel"), MaxLength(256)]
		public string SubModel { get; set; }

		
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		
		[Column("ShortName"), MaxLength(256)]
		public string ShortName { get; set; }

		
		[Column("Designer"), MaxLength(256)]
		public string Designer { get; set; }

		
		[Column("Code"), MaxLength(256)]
		public string Code { get; set; }

		
		[Column("AtaChapter")]
		public int? AtaChapterId { get; set; }

		
		[Column("ComponentClass")]
		public short? ComponentClass { get; set; }

		
		[Column("ComponentModel")]
		public int? ComponentModel { get; set; }

		
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		
		[Column("IsDangerous"), Required]
		public bool IsDangerous { get; set; }

		
		[Column("DescRus")]
		public string DescRus { get; set; }

		
		[Column("HTS")]
		public string HTS { get; set; }

		
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

        
        [Column("IsEffectivity")]
		public string IsEffectivity { get; set; }

        
        [Include]
	    public ATAChapterDTO ATAChapter { get; set; }

	    
		[Child]
	    public GoodStandartDTO GoodStandart { get; set; }

	    
		[Child(FilterType.Equal, "ParentTypeId", 1005)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

	    
	    [Child(FilterType.Equal, "ParentTypeId", 1005)]
	    public ICollection<KitSuppliersRelationDTO> SupplierRelations { get; set; }

		#region Navigation Property

		
		public ICollection<DamageChartDTO> DamageChartDtos { get; set; }
		
		public ICollection<LifeLimitCategorieDTO> LifeLimitCategorieDtos { get; set; }
	    
		public ICollection<DefferedCategorieDTO> DefferedCategorieDtos { get; set; }
	    
		public ICollection<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
	    
		public ICollection<AircraftDTO> AircraftDtos { get; set; }
	    
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
	    
		public ICollection<VehicleDTO> VehicleDtos { get; set; }
	    
		public ICollection<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }
	    
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }
	    
		public ICollection<SpecialistLicenseDTO> SpecialistLicenseDtos { get; set; }
	    
		public ICollection<FlightNumberAircraftModelRelationDTO> FlightNumberAircraftModelRelationDtos { get; set; }
	    
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }

	    #endregion
	}
}
