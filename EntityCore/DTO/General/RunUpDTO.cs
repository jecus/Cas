using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Runups", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class RunUpDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int FlightId { get; set; }

		
		[Column("StartTime")]
		public int? StartTime { get; set; }

		
		[Column("RunUpType")]
		public short? RunUpType { get; set; }

		
		[Column("RunUpPhase")]
		public short? RunUpPhase { get; set; }

		
		[Column("RunUpCondition")]
		public short? RunUpCondition { get; set; }

		
		[Column("EndTime")]
		public int? EndTime { get; set; }

		
		[Column("EndPhase")]
		public short? EndPhase { get; set; }

		
		[Column("ShutDownReasonId")]
		public int? ShutDownReasonId { get; set; }

		
		[Column("ShutDownType")]
		public short? ShutDownType { get; set; }

		
		[Column("LandTime")]
		public int? LandTime { get; set; }

		
		[Column("AirTime")]
		public int? AirTime { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("OnLifelength"), MaxLength(21)]
		public byte[] OnLifelength { get; set; }

		
		[Column("BaseComponentId")]
		public int? BaseComponentId { get; set; }
	}
}