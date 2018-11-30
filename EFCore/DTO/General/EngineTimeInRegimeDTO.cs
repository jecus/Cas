using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class EngineTimeInRegimeDTO : BaseEntity
	{
		[DataMember]
		public int FlightId { get; set; }

		[DataMember]
		public int? EngineId { get; set; }

		[DataMember]
		public int? FlightRegimeId { get; set; }

		[DataMember]
		public int? TimeInRegime { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public short? GroundAir { get; set; }
	}
}