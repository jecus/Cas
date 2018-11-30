using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	public class ReasonDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
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
