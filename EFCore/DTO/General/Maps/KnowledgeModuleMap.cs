using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class KnowledgeModuleMap : BaseMap<KnowledgeModuleDTO>
	{
		public KnowledgeModuleMap() : base()
		{
			ToTable("dbo.KnowledgeModules");

			Property(i => i.Number)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Number");

			Property(i => i.Title)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.Description)
				.HasMaxLength(2048)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");
		}
	}
}