using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsDTO : BaseEntity
	{
		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public DateTime? DateFrom { get; set; }

		[DataMember]
		public DateTime? DateTo { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }

		#endregion
	}
}