using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public ICollection<FlightPlanOpsRecordsDTO> FlightPlanOpsRecordsDtos { get; set; }

		#endregion
	}
}