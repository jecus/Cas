using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceCheckMap : EntityTypeConfiguration<MaintenanceCheckDTO>
	{
		public MaintenanceCheckMap()
		{
			ToTable("dbo.Cas3MaintenanceCheck");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.Interval)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Interval");

			Property(i => i.Notify)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.ParentAircraft)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentAircraft");

			Property(i => i.CheckTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckTypeId");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Schedule)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Schedule");

			Property(i => i.Resource)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Resource");

			Property(i => i.Grouping)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Grouping");

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