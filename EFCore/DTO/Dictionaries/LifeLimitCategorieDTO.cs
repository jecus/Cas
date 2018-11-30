using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LifeLimitCategorieDTO : BaseEntity
	{
		[DataMember]
		public string CategoryType { get; set; }

	    [DataMember]
		public string CategoryName { get; set; }

	    [DataMember]
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
