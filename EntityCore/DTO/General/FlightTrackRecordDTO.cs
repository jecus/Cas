using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("FlightTripRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightTrackRecordDTO : BaseEntity
	{
		
		[Column("FlightTripId")]
		public int? FlightTripId { get; set; }

		
		[Column("FlightPeriodId")]
		public int? FlightPeriodId { get; set; }

		#region Navigation Property

		
		public FlightTrackDTO FlightTrack { get; set; }

		#endregion
	}
}