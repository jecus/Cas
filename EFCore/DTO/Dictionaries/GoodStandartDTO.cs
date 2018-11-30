using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//GoodStandart
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class GoodStandartDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string PartNumber { get; set; }

		[DataMember]
		public string Description { get; set; }

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
		public int? DefaultProductId { get; set; }

		[DataMember]
		public int? ComponentType { get; set; }

		[DataMember]
		public int? ComponentClass { get; set; }



		#region Navigation Property

	    [DataMember]
		public ICollection<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
	    [DataMember]
		public ICollection<AccessoryRequiredDTO> AccessoryRequiredDtos { get; set; }
	    [DataMember]
		public ICollection<StockComponentInfoDTO> StockComponentInfoDtos { get; set; }

	    #endregion
	}
}
