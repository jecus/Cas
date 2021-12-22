using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("ProcedureDocumentReferences", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAAProcedureDocumentReferenceDTO : BaseEntity
	{
		
		[Column("ProcedureId")]
		public int? ProcedureId { get; set; }

		
		[Column("DocumentId")]
		public int? DocumentId { get; set; }

		
		//[Include]
		//public CAAProcedureDTO Procedure { get; set; }

		
		[Child]
		public CAADocumentDTO Document { get; set; }

		#region Navigation Property



		#endregion
	}
}