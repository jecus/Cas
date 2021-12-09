using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;

namespace Entity.Models.DTO.General
{
	[Table("LandingGearCondition", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class LandingGearConditionDTO : BaseEntity
	{
		
		[Column("FlightID")]
		public int FlightID { get; set; }

		
		[Column("LandingGearID")]
		public int LandingGearID { get; set; }

		
		[Column("TirePressure1")]
		public double? TirePressure1 { get; set; }

		
		[Column("TirePressure2")]
		public double? TirePressure2 { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	}
}