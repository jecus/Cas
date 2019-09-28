using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("PurchaseRequestsRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class PurchaseRequestRecordDTO : BaseEntity
	{
		
		[Column("ParentPackageId")]
		public int? ParentPackageId { get; set; }

		
		[Column("PackageItemId")]
		public int? PackageItemId { get; set; }

		
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("CurrencyId")]
		public int CurrencyId { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("Quantity")]
		public double? Quantity { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("CostCondition")]
		public short? CostCondition { get; set; }

		
		[Column("Processed")]
		public bool? Processed { get; set; }

		[Column("DesignationId")]
		public int DesignationId { get; set; }

		[Column("PayTermId")]
		public int PayTermId { get; set; }

		[Column("IncoTermId")]
		public int IncoTermId { get; set; }

		[Column("ShipCompanyId")]
		public int ShipCompanyId { get; set; }

		[Column("ShipTo")]
		public string ShipTo { get; set; }

		[Column("CargoVolume")]
		public string CargoVolume { get; set; }

		[Column("BruttoWeight")]
		public string BruttoWeight { get; set; }

		[Column("NettoWeight")]
		public string NettoWeight { get; set; }


		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}