using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("EngineTimeInRegimeRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class EngineTimeInRegimeDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int FlightId { get; set; }

		[DataMember]
		[Column("EngineId")]
		public int? EngineId { get; set; }

		[DataMember]
		[Column("FlightRegimeId")]
		public int? FlightRegimeId { get; set; }

		[DataMember]
		[Column("TimeInRegime")]
		public int? TimeInRegime { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("GroundAir")]
		public short? GroundAir { get; set; }
	}
}