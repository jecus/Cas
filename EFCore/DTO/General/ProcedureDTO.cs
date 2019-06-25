using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Windows.Forms.VisualStyles;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("Procedures", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProcedureDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("ProcedureTypeId")]
		public int? ProcedureTypeId { get; set; }

		[DataMember]
		[Column("Applicability"), MaxLength(256)]
		public string Applicability { get; set; }

		[DataMember]
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		[DataMember]
		[Column("AuditedObjectId")]
		public int? AuditedObjectId { get; set; }

		[DataMember]
		[Column("AuditedObjectTypeId")]
		public int? AuditedObjectTypeId { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(3072)]
		public string Description { get; set; }

		[DataMember]
		[Column("CheckList"), MaxLength(256)]
		public string CheckList { get; set; }

		[DataMember]
		[Column("CheckListFileId")]
		public int? CheckListFileId { get; set; }

		[DataMember]
		[Column("ProcedureFileId")]
		public int? ProcedureFileId { get; set; }

		[DataMember]
		[Column("JobCard")]
		public int? JobCardId { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(116)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(512)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("HiddenRemarks"), MaxLength(512)]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Elapsed")]
		public double? Elapsed { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("PrintInWP")]
		public bool? PrintInWP { get; set; }

		[DataMember]
		[Column("ProcedureRatingId")]
		public int? ProcedureRatingId { get; set; }

		[DataMember]
		[Column("Level")]
		public int? Level { get; set; }

		[DataMember]
		[Column("AuditedObject"), MaxLength(256)]
		public string AuditedObject { get; set; }

		[DataMember]
		[Child]
		public JobCardDTO JobCard { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		[DataMember]
		[Child]
		public ICollection<ProcedureDocumentReferenceDTO> DocumentReferences { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1840)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<ProcedureDocumentReferenceDTO> ProcedureDocumentReferenceDtos { get; set; }

		#endregion
	}
}