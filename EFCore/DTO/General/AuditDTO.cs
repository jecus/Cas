using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("Audits", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AuditDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

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
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

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
		[Column("OnceClosed")]
		public bool? OnceClosed { get; set; }

		[DataMember]
		[Column("ReleaseCertificateNo"), MaxLength(256)]
		public string ReleaseCertificateNo { get; set; }

		[DataMember]
		[Column("Revision"), MaxLength(256)]
		public string Revision { get; set; }

		[DataMember]
		[Column("CheckType"), MaxLength(256)]
		public string CheckType { get; set; }

		[DataMember]
		[Column("Station"), MaxLength(256)]
		public string Station { get; set; }

		[DataMember]
		[Column("MaintenanceReportNo"), MaxLength(256)]
		public string MaintenanceReportNo { get; set; }



		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1080)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child]
		public ICollection<AuditRecordDTO> AuditRecords { get; set; }
	}
}