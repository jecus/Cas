using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DamageDocumentMap : BaseMap<DamageDocumentDTO>
	{
		public DamageDocumentMap() : base()
		{
			ToTable("dbo.DamageDocuments");

			Property(i => i.DirectiveId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveId");

			Property(i => i.DamageChartId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageChartId");

			Property(i => i.DamageLocation)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageLocation");

			Property(i => i.DocumentType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DocumentType");

			Property(i => i.DamageChart2DImageName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageChart2DImageName");

			HasMany(i => i.Files).WithRequired(i => i.DamageDocument).HasForeignKey(i => i.ParentId);

			HasMany(i => i.DamageSectors).WithRequired(i => i.DamageDocument).HasForeignKey(i => i.DamageDocumentId);
		}
	}
}