using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("DirectivesRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class DirectiveRecordDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("NumGroup")]
		public int? NumGroup { get; set; }

		
		[Column("RecordTypeID")]
		public int RecordTypeID { get; set; }

		
		[Column("ParentID")]
		public int? ParentID { get; set; }

		
		[Column("ParentTypeId")]
		public int ParentTypeId { get; set; }

		
		[Column("Remarks"), MaxLength(1024)]
		public string Remarks { get; set; }

		
		[Column("RecordDate")]
		public DateTime RecordDate { get; set; }

		
		[Column("OnLifelength"), MaxLength(50)]
		public byte[] OnLifelength { get; set; }

		
		[Column("Unused"), MaxLength(50)]
		public byte[] Unused { get; set; }

		
		[Column("Overused"), MaxLength(50)]
		public byte[] Overused { get; set; }

		
		[Column("WorkPackageID")]
		public int? WorkPackageID { get; set; }

		
		[Column("Dispatched")]
		public DateTime? Dispatched { get; set; }

		
		[Column("Completed")]
		public bool? Completed { get; set; }

		
		[Column("Reference"), MaxLength(50)]
		public string Reference { get; set; }

		
		[Column("ODR")]
		public bool? ODR { get; set; }

		
		[Column("MaintenanceOrganization"), MaxLength(50)]
		public string MaintenanceOrganization { get; set; }

		
		[Column("MaintenanceDirectiveRecordId")]
		public int? MaintenanceDirectiveRecordId { get; set; }

		
		[Column("MaintenanceCheckRecordId")]
		public int? MaintenanceCheckRecordId { get; set; }

		
		[Column("PerformanceNum")]
		public int? PerformanceNum { get; set; }

		
		[Column("IsControlPoint")]
		public bool IsControlPoint { get; set; }

		
		[Column("CalculatedPerformanceSource"), MaxLength(21)]
		public byte[] CalculatedPerformanceSource { get; set; }

		
		[Column("ComplianceCheckName"), MaxLength(128)]
		public string ComplianceCheckName { get; set; }



		
		[Child(FilterType.Equal, "ParentTypeId", 1260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		//[Child(FilterType.Equal, "ParentTypeId", 1680)]
		//public ICollection<ItemFileLinkDTO> FilesForMaintenanceCheckRecord { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[JsonIgnore]
		public DirectiveDTO Directive { get; set; }
		[JsonIgnore]
		public ProcedureDTO Procedure { get; set; }
		[JsonIgnore]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[JsonIgnore]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}