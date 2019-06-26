using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("LifeLimitCategories", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LifeLimitCategorieDTO : BaseEntity
	{
		[DataMember]
		[Column("CategoryType"), MaxLength(4)]
		public string CategoryType { get; set; }

	    [DataMember]
	    [Column("CategoryName"), MaxLength(50)]
		public string CategoryName { get; set; }

	    [DataMember]
	    [Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

	    [DataMember]
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<ComponentLLPCategoryChangeRecordDTO> CategoryChangeRecordDto { get; set; }
	    [DataMember]
		public ICollection<ComponentLLPCategoryDataDTO> CategoryDataDtos { get; set; }

	    #endregion
	}
}
