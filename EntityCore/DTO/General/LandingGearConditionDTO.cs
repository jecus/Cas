using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("LandingGearCondition", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class LandingGearConditionDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightID"), Required]
		public int FlightID { get; set; }

		[DataMember]
		[Column("LandingGearID"), Required]
		public int LandingGearID { get; set; }

		[DataMember]
		[Column("TirePressure1")]
		public double? TirePressure1 { get; set; }

		[DataMember]
		[Column("TirePressure2")]
		public double? TirePressure2 { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	}
}