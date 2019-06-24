using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentMap : BaseMap<ComponentDTO>
	{
		public ComponentMap() : base()
		{
			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ATAChapterId);

			HasRequired(i => i.Model)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ModelId);

			HasRequired(i => i.Location)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.LocationId);

			HasRequired(i => i.FromSupplier)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.FromSupplierId);

			HasMany(i => i.SupplierRelations).WithRequired(i => i.Component).HasForeignKey(i => i.KitId);

			HasMany(i => i.Files).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.LLPData).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.Kits).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.ActualStateRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.TransferRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentID);

			HasMany(i => i.ComponentDirectives).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.ChangeLLPCategoryRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);
		}
	}
}