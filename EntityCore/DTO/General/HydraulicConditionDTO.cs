using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("HydraulicConditions", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class HydraulicConditionDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int? FlightId { get; set; }

		[DataMember]
		[Column("Remain")]
		public double? Remain { get; set; }

		[DataMember]
		[Column("Added")]
		public double? Added { get; set; }

		[DataMember]
		[Column("OnBoard")]
		public double? OnBoard { get; set; }

		[DataMember]
		[Column("Spent")]
		public double? Spent { get; set; }

		[DataMember]
		[Column("RemainAfter")]
		public double? RemainAfter { get; set; }

		[DataMember]
		[Column("HydraulicSystem"), MaxLength(128)]
		public string HydraulicSystem { get; set; }
	}
}