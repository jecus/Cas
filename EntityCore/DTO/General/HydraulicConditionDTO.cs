using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("HydraulicConditions", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class HydraulicConditionDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int? FlightId { get; set; }

		
		[Column("Remain")]
		public double? Remain { get; set; }

		
		[Column("Added")]
		public double? Added { get; set; }

		
		[Column("OnBoard")]
		public double? OnBoard { get; set; }

		
		[Column("Spent")]
		public double? Spent { get; set; }

		
		[Column("RemainAfter")]
		public double? RemainAfter { get; set; }

		
		[Column("HydraulicSystem"), MaxLength(128)]
		public string HydraulicSystem { get; set; }
	}
}