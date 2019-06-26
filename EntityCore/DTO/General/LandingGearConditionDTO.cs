using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("LandingGearCondition", Schema = "dbo")]
	
	public class LandingGearConditionDTO : BaseEntity
	{
		
		[Column("FlightID"), Required]
		public int FlightID { get; set; }

		
		[Column("LandingGearID"), Required]
		public int LandingGearID { get; set; }

		
		[Column("TirePressure1")]
		public double? TirePressure1 { get; set; }

		
		[Column("TirePressure2")]
		public double? TirePressure2 { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	}
}