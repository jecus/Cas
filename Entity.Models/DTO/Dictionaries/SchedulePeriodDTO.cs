using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("SchedulePeriods", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class SchedulePeriodDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Schedule")]
		public int Schedule { get; set; }

		
		[Column("DateFrom")]
		public DateTime? DateFrom { get; set; }

		
		[Column("DateTo")]
		public DateTime? DateTo { get; set; }
	}
}
