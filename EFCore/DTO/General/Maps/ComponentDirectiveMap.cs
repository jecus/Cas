using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentDirectiveMap : BaseMap<ComponentDirectiveDTO>
	{
		public ComponentDirectiveMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentID);

			HasMany(i => i.Kits).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);
		}
	}
}