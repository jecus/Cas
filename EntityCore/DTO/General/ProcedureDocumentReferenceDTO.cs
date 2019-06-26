using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("ProcedureDocumentReferences", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ProcedureDocumentReferenceDTO : BaseEntity
	{
		
		[Column("ProcedureId")]
		public int? ProcedureId { get; set; }

		
		[Column("DocumentId")]
		public int? DocumentId { get; set; }

		
		[Include]
		public ProcedureDTO Procedure { get; set; }

		
		[Child]
		public DocumentDTO Document { get; set; }

		#region Navigation Property

		
		public ProcedureDTO ProcedureDto { get; set; }

		#endregion
	}
}