using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("GoodStandarts", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class GoodStandartDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(256)]
		public string Name { get; set; }

	    
	    [Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("CostNew")]
		public double? CostNew { get; set; }

		
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("DefaultProductId")]
		public int? DefaultProductId { get; set; }

		
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		
		[Column("ComponentClass")]
		public int? ComponentClass { get; set; }



		#region Navigation Property

		[JsonIgnore]
		public ICollection<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		[JsonIgnore]
		public ICollection<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
		[JsonIgnore]
		public ICollection<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }

	    #endregion
	}
}
