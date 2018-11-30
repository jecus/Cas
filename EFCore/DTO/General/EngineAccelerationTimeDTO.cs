using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class EngineAccelerationTimeDTO : BaseEntity
	{
		[DataMember]
		public int? FlightId { get; set; }

		[DataMember]
		public int? EngineId { get; set; }

		[DataMember]
		public int? AccelerationTime { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? AccelerationTimeAir { get; set; }
	}
}