using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Reasons", Schema = "Dictionaries")]
	
	public class ReasonDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("Category"), MaxLength(50)]
		public string Category { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightsDelay { get; set; }
		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightsCancel { get; set; }
		[JsonIgnore]
		public ICollection<FlightPlanOpsRecordsDTO> DelayFlightPlanOpsRecordsDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightPlanOpsRecordsDTO> ReasonFlightPlanOpsRecordsDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightPlanOpsRecordsDTO> CancelFlightPlanOpsRecordsDtos { get; set; }

	    #endregion
	}
}
