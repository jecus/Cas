using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("ProcedureDocumentReferences", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ProcedureDocumentReferenceDTO : BaseEntity
	{
		[DataMember]
		[Column("ProcedureId")]
		public int? ProcedureId { get; set; }

		[DataMember]
		[Column("DocumentId")]
		public int? DocumentId { get; set; }

		[DataMember]
		[Include]
		public ProcedureDTO Procedure { get; set; }

		[DataMember]
		[Child]
		public DocumentDTO Document { get; set; }

		#region Navigation Property

		[DataMember]
		public ProcedureDTO ProcedureDto { get; set; }

		#endregion
	}
}