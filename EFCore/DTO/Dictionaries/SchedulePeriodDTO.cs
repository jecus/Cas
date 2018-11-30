using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.Dictionaries
{
	//ShedulePeriods
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SchedulePeriodDTO : BaseEntity
	{
		[DataMember]
		public int Schedule { get; set; }

	    [DataMember]
		public DateTime? DateFrom { get; set; }

	    [DataMember]
		public DateTime? DateTo { get; set; }
    }
}
