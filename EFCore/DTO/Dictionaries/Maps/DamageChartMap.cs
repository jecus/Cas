using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DamageChartMap : EntityTypeConfiguration<DamageChartDTO>
	{
		public DamageChartMap()
		{
			ToTable("Dictionaries.DamageCharts");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId).HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ChartName)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ChartName");

			Property(i => i.AircraftModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftModelId");

			
			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.DamageChartDtos)
				.HasForeignKey(i => i.AircraftModelId);

			HasMany(i => i.Files).WithRequired(i => i.DamageChart).HasForeignKey(i => i.ParentId);
		}
	}
}