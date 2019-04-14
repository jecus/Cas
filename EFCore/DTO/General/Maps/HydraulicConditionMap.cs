using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class HydraulicConditionMap : BaseMap<HydraulicConditionDTO>
	{
		public HydraulicConditionMap() : base()
		{
			ToTable("dbo.HydraulicConditions");

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