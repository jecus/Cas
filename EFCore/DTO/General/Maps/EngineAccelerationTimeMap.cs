using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class EngineAccelerationTimeMap : BaseMap<EngineAccelerationTimeDTO>
	{
		public EngineAccelerationTimeMap() : base()
		{
			ToTable("dbo.EngineAccelerationTime");

			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.EngineId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineId");

			Property(i => i.AccelerationTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccelerationTime");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.AccelerationTimeAir)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccelerationTimeAir");
		}
	}
}