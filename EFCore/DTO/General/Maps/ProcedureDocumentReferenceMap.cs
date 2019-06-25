using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ProcedureDocumentReferenceMap : BaseMap<ProcedureDocumentReferenceDTO>
	{
		public ProcedureDocumentReferenceMap() : base()
		{
			HasRequired(i => i.Procedure)
				.WithMany(i => i.ProcedureDocumentReferenceDtos)
				.HasForeignKey(i => i.ProcedureId);

			HasRequired(i => i.Document)
				.WithMany(i => i.ProcedureDocumentReferenceDtos)
				.HasForeignKey(i => i.DocumentId);
		}
	}
}