using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO.General;

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

		
		public ICollection<AircraftFlightDTO> AircraftFlightsDelay { get; set; }
		
		public ICollection<AircraftFlightDTO> AircraftFlightsCancel { get; set; }
		
		public ICollection<FlightPlanOpsRecordsDTO> DelayFlightPlanOpsRecordsDtos { get; set; }
		
		public ICollection<FlightPlanOpsRecordsDTO> ReasonFlightPlanOpsRecordsDtos { get; set; }
		
		public ICollection<FlightPlanOpsRecordsDTO> CancelFlightPlanOpsRecordsDtos { get; set; }

	    #endregion
	}
}
