using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("FlightPlanOps", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsDTO : BaseEntity
	{
		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("DateFrom")]
		public DateTime? DateFrom { get; set; }

		
		[Column("DateTo")]
		public DateTime? DateTo { get; set; }

		#region Navigation Property

		
		public ICollection<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }

		#endregion
	}
}