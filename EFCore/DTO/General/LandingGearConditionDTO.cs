using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class LandingGearConditionDTO : BaseEntity
	{
		[DataMember]
		public int FlightID { get; set; }

		[DataMember]
		public int LandingGearID { get; set; }

		[DataMember]
		public double? TirePressure1 { get; set; }

		[DataMember]
		public double? TirePressure2 { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }
	}
}