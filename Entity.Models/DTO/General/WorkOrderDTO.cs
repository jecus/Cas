using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("WorkOrders", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkOrderDTO : BaseEntity
	{
		
		[Column("PreparedByDate")]
		public DateTime? PreparedByDate { get; set; }

		
		[Column("PreparedById")]
		public int? PreparedById { get; set; }

		
		[Column("CheckedByDate")]
		public DateTime? CheckedByDate { get; set; }

		
		[Column("CheckedById")]
		public int? CheckedById { get; set; }

		
		[Column("ApprovedByDate")]
		public DateTime? ApprovedByDate { get; set; }

		
		[Column("ApprovedById")]
		public int? ApprovedById { get; set; }

		
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }

		
		[Column("JobCardHeader"), MaxLength(256)]
		public string JobCardHeader { get; set; }

		
		[Column("WorkOrderFooter"), MaxLength(256)]
		public string WorkOrderFooter { get; set; }

		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("Status")]
		public short? Status { get; set; }

		
		[Column("CreateDate")]
		public DateTime? CreateDate { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? PublishingDate { get; set; }

		
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		
		[Column("PublishedBy"), MaxLength(256)]
		public string PublishedBy { get; set; }

		
		[Column("ClosedBy"), MaxLength(256)]
		public string ClosedBy { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("PublishingRemarks"), MaxLength(256)]
		public string PublishingRemarks { get; set; }

		
		[Column("ClosingRemarks"), MaxLength(256)]
		public string ClosingRemarks { get; set; }

		
		[Include]
		public SpecialistDTO PreparedBy { get; set; }

		
		[Include]
		public SpecialistDTO CheckedBy { get; set; }

		
		[Include]
		public SpecialistDTO ApprovedBy { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1450)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		
		[Child]
		public ICollection<WorkOrderRecordDTO> PackageRecords { get; set; }
	}
}