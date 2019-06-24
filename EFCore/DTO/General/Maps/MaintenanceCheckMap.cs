using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceCheckMap : BaseMap<MaintenanceCheckDTO>
	{
		public MaintenanceCheckMap() : base()
		{
			HasRequired(i => i.CheckType)
				.WithMany(i => i.MaintenanceCheckDtos)
				.HasForeignKey(i => i.CheckTypeId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentID);
			HasMany(i => i.CategoriesRecords).WithRequired(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.Kits).WithRequired(i => i.MaintenanceCheckDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.BindMpds).WithRequired(i => i.MaintenanceCheckDto).HasForeignKey(i => i.MaintenanceCheckId);

		}
	}
}