using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkPackageDTO : BaseEntity,IFileDtoContainer
	{
		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int Status { get; set; }

		[DataMember]
		public string Author { get; set; }

		[DataMember]
		public DateTime OpeningDate { get; set; }

		[DataMember]
		public DateTime? PublishingDate { get; set; }

		[DataMember]
		public DateTime? ClosingDate { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string PublishingRemarks { get; set; }

		[DataMember]
		public string ClosingRemarks { get; set; }

		[DataMember]
		public bool OnceClosed { get; set; }

		[DataMember]
		public string ReleaseCertificateNo { get; set; }

		[DataMember]
		public string CheckType { get; set; }

		[DataMember]
		public string Station { get; set; }

		[DataMember]
		public string MaintenanceReportNo { get; set; }

		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public string Revision { get; set; }

		[DataMember]
		public DateTime? CreateDate { get; set; }

		[DataMember]
		public string PublishedBy { get; set; }

		[DataMember]
		public string ClosedBy { get; set; }

		[DataMember]
		public string EmployeesRemark { get; set; }

		[DataMember]
		public int WpWorkType { get; set; }

		[DataMember]
		public float KMH { get; set; }

		[DataMember]
		public string PerformAfter { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2499)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}