using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ModuleRecordMap : BaseMap<ModuleRecordDTO>
	{
		public ModuleRecordMap() : base()
		{
			HasRequired(i => i.AircraftWorkerCategory)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);

			HasRequired(i => i.KnowledgeModule)
				.WithMany(i => i.ModuleRecordDtos)
				.HasForeignKey(i => i.KnowledgeModuleId);
		}
	}
}