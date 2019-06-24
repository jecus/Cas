using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceDirectiveMap : BaseMap<MaintenanceDirectiveDTO>
	{
		public MaintenanceDirectiveMap() : base()
		{
			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);


			HasRequired(i => i.BaseComponent)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.ComponentId);


			HasRequired(i => i.MaintenanceCheck)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.MaintenanceCheckId);

			HasRequired(i => i.JobCard)
				.WithMany(i => i.MaintenanceDirectiveDtos)
				.HasForeignKey(i => i.JobCardId);

			HasMany(i => i.Files).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PerformanceRecords).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentID);
			HasMany(i => i.CategoriesRecords).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);
			HasMany(i => i.Kits).WithRequired(i => i.MaintenanceDirective).HasForeignKey(i => i.ParentId);

		}
	}
}