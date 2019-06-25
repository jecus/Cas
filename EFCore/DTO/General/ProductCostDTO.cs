using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("ProductCost", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProductCostDTO : BaseEntity
	{
		[DataMember]
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		[DataMember]
		[Column("KitId")]
		public int? KitId { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int ParentId { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("QtyIn")]
		public double? QtyIn { get; set; }

		[DataMember]
		[Column("UnitPrice")]
		public double? UnitPrice { get; set; }

		[DataMember]
		[Column("TotalPrice")]
		public double? TotalPrice { get; set; }

		[DataMember]
		[Column("ShipPrice")]
		public double? ShipPrice { get; set; }

		[DataMember]
		[Column("SubTotal")]
		public double? SubTotal { get; set; }

		[DataMember]
		[Column("Tax")]
		public double? Tax { get; set; }

		[DataMember]
		[Column("Tax1")]
		public double? Tax1 { get; set; }

		[DataMember]
		[Column("Tax2")]
		public double? Tax2 { get; set; }

		[DataMember]
		[Column("Total")]
		public double? Total { get; set; }

		[DataMember]
		[Column("CurrencyId")]
		public int? CurrencyId { get; set; }
	}
}