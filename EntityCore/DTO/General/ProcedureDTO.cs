using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.Interfaces;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("Procedures", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ProcedureDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("ProcedureTypeId")]
		public int? ProcedureTypeId { get; set; }

		
		[Column("Applicability"), MaxLength(256)]
		public string Applicability { get; set; }

		
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		
		[Column("AuditedObjectId")]
		public int? AuditedObjectId { get; set; }

		
		[Column("AuditedObjectTypeId")]
		public int? AuditedObjectTypeId { get; set; }

		
		[Column("Description"), MaxLength(3072)]
		public string Description { get; set; }

		
		[Column("CheckList"), MaxLength(256)]
		public string CheckList { get; set; }

		
		[Column("CheckListFileId")]
		public int? CheckListFileId { get; set; }

		
		[Column("ProcedureFileId")]
		public int? ProcedureFileId { get; set; }

		
		[Column("JobCard")]
		public int? JobCardId { get; set; }

		
		[Column("Threshold"), MaxLength(116)]
		public byte[] Threshold { get; set; }

		
		[Column("Remarks"), MaxLength(512)]
		public string Remarks { get; set; }

		
		[Column("HiddenRemarks"), MaxLength(512)]
		public string HiddenRemarks { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Elapsed")]
		public double? Elapsed { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("PrintInWP")]
		public bool? PrintInWP { get; set; }

		
		[Column("ProcedureRatingId")]
		public int? ProcedureRatingId { get; set; }

		
		[Column("Level")]
		public int? Level { get; set; }

		
		[Column("AuditedObject"), MaxLength(256)]
		public string AuditedObject { get; set; }

		
		[Child]
		public JobCardDTO JobCard { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		
		[Child]
		public ICollection<ProcedureDocumentReferenceDTO> DocumentReferences { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<ProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }

		#endregion
	}
}