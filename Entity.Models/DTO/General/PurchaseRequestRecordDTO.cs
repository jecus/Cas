using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace Entity.Models.DTO.General
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

		[Column("CostType")]
		public short CostType { get; set; }

		[Column("Processed")]
		public bool? Processed { get; set; }

		[Column("AdditionalInformationJSON")]
		public string AdditionalInformationJSON { get; set; }

		[Column("TransferInformationJSON")]
		public string TransferInformationJSON { get; set; }

		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}