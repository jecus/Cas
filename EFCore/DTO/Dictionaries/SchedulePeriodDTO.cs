using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.Dictionaries
{
	[Table("SchedulePeriods", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SchedulePeriodDTO : BaseEntity
	{
		[DataMember]
		[Column("Schedule"), Required]
		public int Schedule { get; set; }

	    [DataMember]
		[Column("DateFrom")]
		public DateTime? DateFrom { get; set; }

	    [DataMember]
	    [Column("DateTo")]
		public DateTime? DateTo { get; set; }
    }
}
