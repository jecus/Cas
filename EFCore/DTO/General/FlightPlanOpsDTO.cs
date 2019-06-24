using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("FlightPlanOps", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsDTO : BaseEntity
	{
		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("DateFrom")]
		public DateTime? DateFrom { get; set; }

		[DataMember]
		[Column("DateTo")]
		public DateTime? DateTo { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }

		#endregion
	}
}