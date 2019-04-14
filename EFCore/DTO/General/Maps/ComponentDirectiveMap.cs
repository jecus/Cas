using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentDirectiveMap : BaseMap<ComponentDirectiveDTO>
	{
		public ComponentDirectiveMap() : base()
		{
			ToTable("dbo.ComponentDirectives");

			Property(i => i.DirectiveType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveType");

			Property(i => i.Threshold)
				.HasMaxLength(200)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.Highlight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Highlight");

			Property(i => i.KitRequired)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitRequired");

			Property(i => i.FaaFormFileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FaaFormFileID");

			Property(i => i.HiddenRemarks)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.MPDTaskTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MPDTaskTypeId");

			Property(i => i.NDTType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NDTType");

			Property(i => i.ComponentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");

			Property(i => i.ZoneArea)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ZoneArea");

			Property(i => i.AccessDirective)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccessDirective");

			Property(i => i.AAM)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AAM");

			Property(i => i.CMM)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CMM");

			HasMany(i => i.Files).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentID);

			HasMany(i => i.Kits).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.ComponentDirective).HasForeignKey(i => i.ParentId);
		}
	}
}