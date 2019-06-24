using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("EngineAccelerationTime", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class EngineAccelerationTimeDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int? FlightId { get; set; }

		[DataMember]
		[Column("EngineId")]
		public int? EngineId { get; set; }

		[DataMember]
		[Column("AccelerationTime")]
		public int? AccelerationTime { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("AccelerationTimeAir")]
		public int? AccelerationTimeAir { get; set; }
	}
}