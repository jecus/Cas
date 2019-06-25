using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("PurchaseRequestsRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class PurchaseRequestRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentPackageId")]
		public int? ParentPackageId { get; set; }

		[DataMember]
		[Column("PackageItemId")]
		public int? PackageItemId { get; set; }

		[DataMember]
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		[DataMember]
		[Column("CurrencyId")]
		public int CurrencyId { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Quantity")]
		public double? Quantity { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("CostCondition")]
		public short? CostCondition { get; set; }

		[DataMember]
		[Column("Processed")]
		public bool? Processed { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}