using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO;
using Newtonsoft.Json;
using AircraftFlightDTO = Entity.Models.DTO.General.AircraftFlightDTO;
using FlightPlanOpsRecordsDTO = Entity.Models.DTO.General.FlightPlanOpsRecordsDTO;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("Reasons", Schema = "Dictionaries")]
	
	public class ReasonDTO : BaseEntity, IBaseDictionary
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
