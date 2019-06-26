using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("LifeLimitCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LifeLimitCategorieDTO : BaseEntity
	{
		
		[Column("CategoryType"), MaxLength(4)]
		public string CategoryType { get; set; }

	    
	    [Column("CategoryName"), MaxLength(50)]
		public string CategoryName { get; set; }

	    
	    [Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

	    
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }


		#region Navigation Property

	    
		public ICollection<ComponentLLPCategoryChangeRecordDTO> CategoryChangeRecordDto { get; set; }
	    
		public ICollection<ComponentLLPCategoryDataDTO> CategoryDataDtos { get; set; }

	    #endregion
	}
}
