using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("StockComponentInfos", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class StockComponentInfoDTO : BaseEntity
	{
		[DataMember]
		[Column("StoreID")]
		public int? StoreID { get; set; }

		[DataMember]
		[Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		[DataMember]
		[Column("Amount"), Required]
		public double Amount { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("AccessoryDescriptionId")]
		public int? AccessoryDescriptionId { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("GoodStandartId")]
		public int? GoodStandartId { get; set; }

		[DataMember]
		[Column("ComponentClass")]
		public int? ComponentClass { get; set; }

		[DataMember]
		[Column("ComponentModel")]
		public int? ComponentModel { get; set; }

		[DataMember]
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		[DataMember]
		[Child]
		public GoodStandartDTO Standart { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }
	}
}