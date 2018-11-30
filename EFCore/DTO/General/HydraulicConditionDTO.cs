using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class HydraulicConditionDTO : BaseEntity
	{
		[DataMember]
		public int? FlightId { get; set; }

		[DataMember]
		public double? Remain { get; set; }

		[DataMember]
		public double? Added { get; set; }

		[DataMember]
		public double? OnBoard { get; set; }

		[DataMember]
		public double? Spent { get; set; }

		[DataMember]
		public double? RemainAfter { get; set; }

		[DataMember]
		public string HydraulicSystem { get; set; }
	}
}