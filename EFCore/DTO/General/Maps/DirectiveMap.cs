using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DirectiveMap : BaseMap<DirectiveDTO>
	{
		public DirectiveMap() : base()
		{
			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ATAChapterId);

			HasRequired(i => i.DeferredCategory)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.DeferredCategoryId);

			HasRequired(i => i.BaseComponent)
				.WithMany(i => i.DirectiveDtos)
				.HasForeignKey(i => i.ComponentId);

			HasMany(i => i.Files).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);
			HasMany(i => i.DamageDocs).WithRequired(i => i.Directive).HasForeignKey(i => i.DirectiveId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentID);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);

			HasMany(i => i.Kits).WithRequired(i => i.Directive).HasForeignKey(i => i.ParentId);


		}
	}
}