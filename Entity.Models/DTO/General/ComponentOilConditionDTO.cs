using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("OilConditions", Schema = "dbo")]
	[Condition("IsDeleted", 0)]
	public class ComponentOilConditionDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int? FlightId { get; set; }

		
		[Column("OilAdded")]
		public double? OilAdded { get; set; }

		
		[Column("OnBoard")]
		public double? OnBoard { get; set; }

		
		[Column("Remain")]
		public double? Remain { get; set; }

		
		[Column("Spent")]
		public double? Spent { get; set; }

		
		[Column("RemainAfter")]
		public double? RemainAfter { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }
	}
}