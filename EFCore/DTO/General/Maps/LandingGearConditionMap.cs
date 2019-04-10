using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class LandingGearConditionMap : BaseMap<LandingGearConditionDTO>
	{
		public LandingGearConditionMap() : base()
		{
			ToTable("LandingGearCondition");

			Property(i => i.FlightID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightID");

			Property(i => i.LandingGearID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LandingGearID");

			Property(i => i.TirePressure1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TirePressure1");

			Property(i => i.TirePressure2)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TirePressure2");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");
		}
	}
}