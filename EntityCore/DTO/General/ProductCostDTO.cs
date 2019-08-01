using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("ProductCost", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ProductCostDTO : BaseEntity
	{
		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("KitId")]
		public int? KitId { get; set; }

		
		[Column("ParentId")]
		public int ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("QtyIn")]
		public double? QtyIn { get; set; }

		
		[Column("UnitPrice")]
		public double? UnitPrice { get; set; }

		
		[Column("TotalPrice")]
		public double? TotalPrice { get; set; }

		
		[Column("ShipPrice")]
		public double? ShipPrice { get; set; }

		
		[Column("SubTotal")]
		public double? SubTotal { get; set; }

		
		[Column("Tax")]
		public double? Tax { get; set; }

		
		[Column("Tax1")]
		public double? Tax1 { get; set; }

		
		[Column("Tax2")]
		public double? Tax2 { get; set; }

		
		[Column("Total")]
		public double? Total { get; set; }

		
		[Column("CurrencyId")]
		public int? CurrencyId { get; set; }
	}
}