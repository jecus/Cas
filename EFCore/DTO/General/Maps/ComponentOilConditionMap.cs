using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentOilConditionMap : BaseMap<ComponentOilConditionDTO>
	{
		public ComponentOilConditionMap() : base()
		{
			ToTable("dbo.OilConditions");

			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.OilAdded)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilAdded");

			Property(i => i.OnBoard)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnBoard");

			Property(i => i.Remain)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remain");

			Property(i => i.Spent)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Spent");

			Property(i => i.RemainAfter)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RemainAfter");

			Property(i => i.ComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");
			
		}
	}
}