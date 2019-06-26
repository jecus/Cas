using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Reasons", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	public class ReasonDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    [DataMember]
	    [Column("Category"), MaxLength(50)]
		public string Category { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightsDelay { get; set; }
		[DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightsCancel { get; set; }
		[DataMember]
		public ICollection<FlightPlanOpsRecordsDTO> DelayFlightPlanOpsRecordsDtos { get; set; }
		[DataMember]
		public ICollection<FlightPlanOpsRecordsDTO> ReasonFlightPlanOpsRecordsDtos { get; set; }
		[DataMember]
		public ICollection<FlightPlanOpsRecordsDTO> CancelFlightPlanOpsRecordsDtos { get; set; }

	    #endregion
	}
}
