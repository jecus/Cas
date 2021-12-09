using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;

namespace Entity.Models.DTO.General
{
	[Table("EngineTimeInRegimeRecords", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

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