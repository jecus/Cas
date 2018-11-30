using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProductCostDTO : BaseEntity
	{
		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		public int? KitId { get; set; }

		[DataMember]
		public int ParentId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public double? QtyIn { get; set; }

		[DataMember]
		public double? UnitPrice { get; set; }

		[DataMember]
		public double? TotalPrice { get; set; }

		[DataMember]
		public double? ShipPrice { get; set; }

		[DataMember]
		public double? SubTotal { get; set; }

		[DataMember]
		public double? Tax { get; set; }

		[DataMember]
		public double? Tax1 { get; set; }

		[DataMember]
		public double? Tax2 { get; set; }

		[DataMember]
		public double? Total { get; set; }

		[DataMember]
		public int? CurrencyId { get; set; }
	}
}