using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class PurchaseOrderDTO : BaseEntity
	{
		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? ParentID { get; set; }

		[DataMember]
		public int? ParentQuotationId { get; set; }

		[DataMember]
		public int? Status { get; set; }

		[DataMember]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		public string Author { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1860)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}