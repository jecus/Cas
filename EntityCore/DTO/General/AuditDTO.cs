using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("Audits", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AuditDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("Status")]
		public short? Status { get; set; }

		
		[Column("CreateDate")]
		public DateTime? CreateDate { get; set; }

		
		[Column("OpeningDate")]
		public DateTime? OpeningDate { get; set; }

		
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

		
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

		
		[Column("OnceClosed")]
		public bool? OnceClosed { get; set; }

		
		[Column("ReleaseCertificateNo"), MaxLength(256)]
		public string ReleaseCertificateNo { get; set; }

		
		[Column("Revision"), MaxLength(256)]
		public string Revision { get; set; }

		
		[Column("CheckType"), MaxLength(256)]
		public string CheckType { get; set; }

		
		[Column("Station"), MaxLength(256)]
		public string Station { get; set; }

		
		[Column("MaintenanceReportNo"), MaxLength(256)]
		public string MaintenanceReportNo { get; set; }



		
		[Child(FilterType.Equal, "ParentTypeId", 1080)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Child]
		public ICollection<AuditRecordDTO> AuditRecords { get; set; }
	}
}