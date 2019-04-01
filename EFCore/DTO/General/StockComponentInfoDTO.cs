using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class StockComponentInfoDTO : BaseEntity
	{
		[DataMember]
		public int? StoreID { get; set; }

		[DataMember]
		public string PartNumber { get; set; }

		[DataMember]
		public double Amount { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? AccessoryDescriptionId { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public int? GoodStandartId { get; set; }

		[DataMember]
		public int? ComponentClass { get; set; }

		[DataMember]
		public int? ComponentModel { get; set; }

		[DataMember]
		public int? ComponentType { get; set; }

		[DataMember]
		[Child]
		public GoodStandartDTO Standart { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }
	}
}