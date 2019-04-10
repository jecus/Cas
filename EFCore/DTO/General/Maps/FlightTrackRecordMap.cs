using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightTrackRecordMap : BaseMap<FlightTrackRecordDTO>
	{
		public FlightTrackRecordMap() : base()
		{
			ToTable("dbo.FlightTripRecords");

			Property(i => i.FlightTripId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightTripId");

			Property(i => i.FlightPeriodId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightPeriodId");
		}
	}
}