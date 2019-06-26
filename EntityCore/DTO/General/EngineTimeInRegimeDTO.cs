using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("EngineTimeInRegimeRecords", Schema = "dbo")]
	
	public class EngineTimeInRegimeDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int FlightId { get; set; }

		
		[Column("EngineId")]
		public int? EngineId { get; set; }

		
		[Column("FlightRegimeId")]
		public int? FlightRegimeId { get; set; }

		
		[Column("TimeInRegime")]
		public int? TimeInRegime { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("GroundAir")]
		public short? GroundAir { get; set; }
	}
}