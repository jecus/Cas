using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SupplierDocumentMap : BaseMap<SupplierDocumentDTO>
	{
		public SupplierDocumentMap() : base()
		{
			ToTable("dbo.SupplierDocuments");

			Property(i => i.SupplierId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.Name)
				.HasMaxLength(200)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.DocumentType)
				.HasMaxLength(200)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DocumentType");

			Property(i => i.FileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileId");

			HasMany(i => i.Files).WithRequired(i => i.SupplierDocument).HasForeignKey(i => i.ParentId);
		}
	}
}