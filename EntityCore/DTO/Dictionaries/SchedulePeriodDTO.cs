using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.Dictionaries
{
	[Table("SchedulePeriods", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class SchedulePeriodDTO : BaseEntity
	{
		
		[Column("Schedule"), Required]
		public int Schedule { get; set; }

	    
		[Column("DateFrom")]
		public DateTime? DateFrom { get; set; }

	    
	    [Column("DateTo")]
		public DateTime? DateTo { get; set; }
    }
}
