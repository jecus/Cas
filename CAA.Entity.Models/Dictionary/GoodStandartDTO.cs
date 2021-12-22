using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("GoodStandarts", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAAGoodStandartDTO : BaseEntity, IBaseDictionary
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
		public ICollection<CAAAccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }

        #endregion
	}
}
