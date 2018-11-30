using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class ComponentOilConditionDTO : BaseEntity
	{
		[DataMember]
		public int? FlightId { get; set; }

		[DataMember]
		public double? OilAdded { get; set; }

		[DataMember]
		public double? OnBoard { get; set; }

		[DataMember]
		public double? Remain { get; set; }

		[DataMember]
		public double? Spent { get; set; }

		[DataMember]
		public double? RemainAfter { get; set; }

		[DataMember]
		public int? ComponentId { get; set; }
	}
}