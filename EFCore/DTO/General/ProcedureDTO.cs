using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProcedureDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public int? ProcedureTypeId { get; set; }

		[DataMember]
		public string Applicability { get; set; }

		[DataMember]
		public int? OperatorId { get; set; }

		[DataMember]
		public int? AuditedObjectId { get; set; }

		[DataMember]
		public int? AuditedObjectTypeId { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string CheckList { get; set; }

		[DataMember]
		public int? CheckListFileId { get; set; }

		[DataMember]
		public int? ProcedureFileId { get; set; }

		[DataMember]
		public int? JobCardId { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public double? Elapsed { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public bool? PrintInWP { get; set; }

		[DataMember]
		public int? ProcedureRatingId { get; set; }

		[DataMember]
		public int? Level { get; set; }

		[DataMember]
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