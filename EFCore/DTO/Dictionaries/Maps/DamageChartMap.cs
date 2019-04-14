using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DamageChartMap : BaseMap<DamageChartDTO>
	{
		public DamageChartMap() : base()
		{
			ToTable("Dictionaries.DamageCharts");

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