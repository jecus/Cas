using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("FlightTripRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightTrackRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightTripId")]
		public int? FlightTripId { get; set; }

		[DataMember]
		[Column("FlightPeriodId")]
		public int? FlightPeriodId { get; set; }

		#region Navigation Property

		[DataMember]
		public FlightTrackDTO FlightTrack { get; set; }

		#endregion
	}
}