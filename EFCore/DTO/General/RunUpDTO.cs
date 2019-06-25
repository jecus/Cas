using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("Runups", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class RunUpDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int FlightId { get; set; }

		[DataMember]
		[Column("StartTime")]
		public int? StartTime { get; set; }

		[DataMember]
		[Column("RunUpType")]
		public short? RunUpType { get; set; }

		[DataMember]
		[Column("RunUpPhase")]
		public short? RunUpPhase { get; set; }

		[DataMember]
		[Column("RunUpCondition")]
		public short? RunUpCondition { get; set; }

		[DataMember]
		[Column("EndTime")]
		public int? EndTime { get; set; }

		[DataMember]
		[Column("EndPhase")]
		public short? EndPhase { get; set; }

		[DataMember]
		[Column("ShutDownReasonId")]
		public int? ShutDownReasonId { get; set; }

		[DataMember]
		[Column("ShutDownType")]
		public short? ShutDownType { get; set; }

		[DataMember]
		[Column("LandTime")]
		public int? LandTime { get; set; }

		[DataMember]
		[Column("AirTime")]
		public int? AirTime { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("OnLifelength"), MaxLength(21)]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		[Column("BaseComponentId")]
		public int? BaseComponentId { get; set; }
	}
}