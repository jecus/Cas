using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ProcedureDocumentReferenceMap : BaseMap<ProcedureDocumentReferenceDTO>
	{
		public ProcedureDocumentReferenceMap() : base()
		{
			ToTable("dbo.ProcedureDocumentReferences");

			Property(i => i.ProcedureId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProcedureId");

			Property(i => i.DocumentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DocumentId");

			HasRequired(i => i.Procedure)
				.WithMany(i => i.ProcedureDocumentReferenceDtos)
				.HasForeignKey(i => i.ProcedureId);

			HasRequired(i => i.Document)
				.WithMany(i => i.ProcedureDocumentReferenceDtos)
				.HasForeignKey(i => i.DocumentId);
		}
	}
}