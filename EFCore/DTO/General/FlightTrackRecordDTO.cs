using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightTrackRecordDTO : BaseEntity
	{
		[DataMember]
		public int FlightTripId { get; set; }

		[DataMember]
		public int? FlightPeriodId { get; set; }

		#region Navigation Property

		[DataMember]
		public FlightTrackDTO FlightTrack { get; set; }

		#endregion
	}
}