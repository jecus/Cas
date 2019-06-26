using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("OilConditions", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class ComponentOilConditionDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int? FlightId { get; set; }

		[DataMember]
		[Column("OilAdded")]
		public double? OilAdded { get; set; }

		[DataMember]
		[Column("OnBoard")]
		public double? OnBoard { get; set; }

		[DataMember]
		[Column("Remain")]
		public double? Remain { get; set; }

		[DataMember]
		[Column("Spent")]
		public double? Spent { get; set; }

		[DataMember]
		[Column("RemainAfter")]
		public double? RemainAfter { get; set; }

		[DataMember]
		[Column("ComponentId")]
		public int? ComponentId { get; set; }
	}
}