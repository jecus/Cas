using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EngineConditionMap : BaseMap<EngineConditionDTO>
	{
		public EngineConditionMap() : base()
		{
			ToTable("dbo.EngineConditions");

			Property(i => i.FlightID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightID");

			Property(i => i.EngineID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineID");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.TimeGMT)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeGMT");

			Property(i => i.FlightRegime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightRegime");

			Property(i => i.TimeInRegime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeInRegime");

			Property(i => i.Weather)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Weather");

			Property(i => i.PressAlt)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PressAlt");

			Property(i => i.IAS)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IAS");

			Property(i => i.TAT)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TAT");

			Property(i => i.OAT)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OAT");

			Property(i => i.Mach)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Mach");

			Property(i => i.GrossWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GrossWeight");

			Property(i => i.ERP)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ERP");

			Property(i => i.N1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N1");

			Property(i => i.EGT)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EGT");

			Property(i => i.N2)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("N2");

			Property(i => i.OilTemperature)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilTemperature");

			Property(i => i.OilPressure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressure");

			Property(i => i.FuelFlow)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelFlow");

			Property(i => i.FuelBurn)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelBurn");

			Property(i => i.ThrottleLeverAngle)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ThrottleLeverAngle");

			Property(i => i.FuelPress)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FuelPress");

			Property(i => i.OilPressTorque)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilPressTorque");

			Property(i => i.VibroOverload)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload");

			Property(i => i.VibroOverload2)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("VibroOverload2");

			Property(i => i.GroundAir)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GroundAir");

			Property(i => i.OilFlow)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OilFlow");
			
		}
	}
}