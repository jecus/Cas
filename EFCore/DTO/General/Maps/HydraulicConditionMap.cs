using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class HydraulicConditionMap : EntityTypeConfiguration<HydraulicConditionDTO>
	{
		public HydraulicConditionMap()
		{
			ToTable("dbo.HydraulicConditions");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.Remain)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remain");

			Property(i => i.Added)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Added");

			Property(i => i.OnBoard)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnBoard");

			Property(i => i.Spent)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Spent");

			Property(i => i.RemainAfter)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RemainAfter");

			Property(i => i.HydraulicSystem)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HydraulicSystem");
		}
	}
}