using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("DirectivesRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DirectiveRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("NumGroup")]
		public int? NumGroup { get; set; }

		[DataMember]
		[Column("RecordTypeID"), Required]
		public int RecordTypeID { get; set; }

		[DataMember]
		[Column("ParentID"), Required]
		public int? ParentID { get; set; }

		[DataMember]
		[Column("ParentTypeId"), Required]
		public int ParentTypeId { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(1024)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("RecordDate"), Required]
		public DateTime RecordDate { get; set; }

		[DataMember]
		[Column("OnLifelength"), MaxLength(50)]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		[Column("Unused"), MaxLength(50)]
		public byte[] Unused { get; set; }

		[DataMember]
		[Column("Overused"), MaxLength(50)]
		public byte[] Overused { get; set; }

		[DataMember]
		[Column("WorkPackageID")]
		public int? WorkPackageID { get; set; }

		[DataMember]
		[Column("Dispatched")]
		public DateTime? Dispatched { get; set; }

		[DataMember]
		[Column("Completed")]
		public bool? Completed { get; set; }

		[DataMember]
		[Column("Reference"), MaxLength(50)]
		public string Reference { get; set; }

		[DataMember]
		[Column("ODR")]
		public bool? ODR { get; set; }

		[DataMember]
		[Column("MaintenanceOrganization"), MaxLength(50)]
		public string MaintenanceOrganization { get; set; }

		[DataMember]
		[Column("MaintenanceDirectiveRecordId")]
		public int? MaintenanceDirectiveRecordId { get; set; }

		[DataMember]
		[Column("MaintenanceCheckRecordId")]
		public int? MaintenanceCheckRecordId { get; set; }

		[DataMember]
		[Column("PerformanceNum")]
		public int? PerformanceNum { get; set; }

		[DataMember]
		[Column("IsControlPoint"), Required]
		public bool IsControlPoint { get; set; }

		[DataMember]
		[Column("CalculatedPerformanceSource"), MaxLength(21)]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		[Column("ComplianceCheckName"), MaxLength(128)]
		public string ComplianceCheckName { get; set; }



		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1680)]
		public ICollection<ItemFileLinkDTO> FilesForMaintenanceCheckRecord { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[DataMember]
		public DirectiveDTO Directive { get; set; }
		[DataMember]
		public ProcedureDTO Procedure { get; set; }
		[DataMember]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[DataMember]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}