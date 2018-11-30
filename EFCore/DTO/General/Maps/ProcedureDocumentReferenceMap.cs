using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class ProcedureDocumentReferenceMap : EntityTypeConfiguration<ProcedureDocumentReferenceDTO>
	{
		public ProcedureDocumentReferenceMap()
		{
			ToTable("dbo.ProcedureDocumentReferences");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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