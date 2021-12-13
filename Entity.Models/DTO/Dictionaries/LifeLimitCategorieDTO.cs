using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("LifeLimitCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LifeLimitCategorieDTO : BaseEntity, IBaseDictionary
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

		[JsonIgnore]
		public ICollection<ComponentLLPCategoryChangeRecordDTO> CategoryChangeRecordDto { get; set; }
		[JsonIgnore]
		public ICollection<ComponentLLPCategoryDataDTO> CategoryDataDtos { get; set; }

	    #endregion
	}
}
