using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class ModuleRecordMap : EntityTypeConfiguration<ModuleRecordDTO>
	{
		public ModuleRecordMap()
		{
			ToTable("dbo.ModuleRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.AircraftWorkerCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftWorkerCategoryId");

			Property(i => i.KnowledgeModuleId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KnowledgeModuleId");

			Property(i => i.KnowledgeLevel)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KnowledgeLevel");


			HasRequired(i => i.AircraftWorkerCategory)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);

			HasRequired(i => i.KnowledgeModule)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.KnowledgeModuleId);
		}
	}
}