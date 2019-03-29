using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class RunUpDTO : BaseEntity
	{
		[DataMember]
		public int FlightId { get; set; }

		[DataMember]
		public int? StartTime { get; set; }

		[DataMember]
		public short? RunUpType { get; set; }

		[DataMember]
		public short? RunUpPhase { get; set; }

		[DataMember]
		public short? RunUpCondition { get; set; }

		[DataMember]
		public int? EndTime { get; set; }

		[DataMember]
		public short? EndPhase { get; set; }

		[DataMember]
		public int? ShutDownReasonId { get; set; }

		[DataMember]
		public short? ShutDownType { get; set; }

		[DataMember]
		public int? LandTime { get; set; }

		[DataMember]
		public int? AirTime { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		public int? BaseComponentId { get; set; }
	}
}