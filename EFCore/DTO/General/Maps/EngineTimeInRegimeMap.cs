using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EngineTimeInRegimeMap : BaseMap<EngineTimeInRegimeDTO>
	{
		public EngineTimeInRegimeMap() : base()
		{
			ToTable("dbo.EngineTimeInRegimeRecords");

			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.EngineId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineId");

			Property(i => i.FlightRegimeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightRegimeId");

			Property(i => i.TimeInRegime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeInRegime");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.GroundAir)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GroundAir");
		}
	}
}