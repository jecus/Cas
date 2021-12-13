using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;


namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public FlightTrackDTO FlightTrack { get; set; }

		#endregion
	}
}