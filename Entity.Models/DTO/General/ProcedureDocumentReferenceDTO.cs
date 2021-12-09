using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public ProcedureDTO ProcedureDto { get; set; }

		#endregion
	}
}