using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("WorkOrders", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkOrderDTO : BaseEntity
	{
		[DataMember]
		[Column("PreparedByDate")]
		public DateTime? PreparedByDate { get; set; }

		[DataMember]
		[Column("PreparedById")]
		public int? PreparedById { get; set; }

		[DataMember]
		[Column("CheckedByDate")]
		public DateTime? CheckedByDate { get; set; }

		[DataMember]
		[Column("CheckedById")]
		public int? CheckedById { get; set; }

		[DataMember]
		[Column("ApprovedByDate")]
		public DateTime? ApprovedByDate { get; set; }

		[DataMember]
		[Column("ApprovedById")]
		public int? ApprovedById { get; set; }

		[DataMember]
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }

		[DataMember]
		[Column("JobCardHeader"), MaxLength(256)]
		public string JobCardHeader { get; set; }

		[DataMember]
		[Column("WorkOrderFooter"), MaxLength(256)]
		public string WorkOrderFooter { get; set; }

		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		[DataMember]
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("Status")]
		public short? Status { get; set; }

		[DataMember]
		[Column("CreateDate")]
		public DateTime? CreateDate { get; set; }

		[DataMember]
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		[DataMember]
		[Column("OpeningDate")]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		[Column("PublishedBy"), MaxLength(256)]
		public string PublishedBy { get; set; }

		[DataMember]
		[Column("ClosedBy"), MaxLength(256)]
		public string ClosedBy { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("PublishingRemarks"), MaxLength(256)]
		public string PublishingRemarks { get; set; }

		[DataMember]
		[Column("ClosingRemarks"), MaxLength(256)]
		public string ClosingRemarks { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO PreparedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO CheckedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO ApprovedBy { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1450)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<WorkOrderRecordDTO> PackageRecords { get; set; }
	}
}