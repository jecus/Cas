using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class PurchaseRequestRecordDTO : BaseEntity
	{
		[DataMember]
		public int? ParentPackageId { get; set; }

		[DataMember]
		public int? PackageItemId { get; set; }

		[DataMember]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public double? Quantity { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public short? CostCondition { get; set; }

		[DataMember]
		public bool? Processed { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}