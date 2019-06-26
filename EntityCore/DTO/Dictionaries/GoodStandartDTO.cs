using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("GoodStandarts", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class GoodStandartDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(256)]
		public string Name { get; set; }

	    [DataMember]
	    [Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

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
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("DefaultProductId")]
		public int? DefaultProductId { get; set; }

		[DataMember]
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		[DataMember]
		[Column("ComponentClass")]
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
