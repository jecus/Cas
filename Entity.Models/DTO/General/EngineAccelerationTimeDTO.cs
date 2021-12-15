using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("EngineAccelerationTime", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class EngineAccelerationTimeDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int? FlightId { get; set; }

		
		[Column("EngineId")]
		public int? EngineId { get; set; }

		
		[Column("AccelerationTime")]
		public int? AccelerationTime { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("AccelerationTimeAir")]
		public int? AccelerationTimeAir { get; set; }
	}
}