using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.Interfaces;

namespace Entity.Models.DTO.General
{
	[Table("WorkPackages", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkPackageDTO : BaseEntity,IFileDtoContainer
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("Title")]
		public string Title { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("Status")]
		public int Status { get; set; }

		
		[Column("Author"), MaxLength(256)]
		public string Author { get; set; }

		
		[Column("OpeningDate")]
		public DateTime OpeningDate { get; set; }

		
		[Column("PublishingDate")]
		public DateTime? PublishingDate { get; set; }

		
		[Column("ClosingDate")]
		public DateTime? ClosingDate { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("PublishingRemarks"), MaxLength(256)]
		public string PublishingRemarks { get; set; }

		
		[Column("ClosingRemarks"), MaxLength(256)]
		public string ClosingRemarks { get; set; }

		
		[Column("OnceClosed")]
		public bool OnceClosed { get; set; }

		
		[Column("ReleaseCertificateNo"), MaxLength(256)]
		public string ReleaseCertificateNo { get; set; }

		
		[Column("CheckType"), MaxLength(256)]
		public string CheckType { get; set; }

		
		[Column("Station"), MaxLength(256)]
		public string Station { get; set; }

		
		[Column("MaintenanceReportNo"), MaxLength(256)]
		public string MaintenanceReportNo { get; set; }

		
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		
		[Column("Revision"), MaxLength(256)]
		public string Revision { get; set; }

		
		[Column("CreateDate")]
		public DateTime? CreateDate { get; set; }

		
		[Column("PublishedBy"), MaxLength(256)]
		public string PublishedBy { get; set; }

		
		[Column("ClosedBy"), MaxLength(256)]
		public string ClosedBy { get; set; }

		
		[Column("EmployeesRemark")]
		public string EmployeesRemark { get; set; }

		
		[Column("WpWorkType")]
		public int WpWorkType { get; set; }

		
		[Column("KMH")]
		public double KMH { get; set; }

		
		[Column("PerformAfter")]
		public string PerformAfter { get; set; }

		
		[Column("ProviderJSON")]
		public string ProviderJSON { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2499)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}