using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ModuleRecordMap : BaseMap<ModuleRecordDTO>
	{
		public ModuleRecordMap() : base()
		{
			ToTable("dbo.ModuleRecords");

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