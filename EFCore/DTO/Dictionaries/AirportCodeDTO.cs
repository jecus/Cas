using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//AirportsCodes
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AirportCodeDTO : BaseEntity
	{
		[DataMember]
		public string Iata { get; set; }

		[DataMember]
		public string Icao { get; set; }

		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public string Country { get; set; }

		[DataMember]
		public string Iso { get; set; }


		#region Navigation Property
		[DataMember]
		public ICollection<FlightNumberDTO> From { get; set; }
		[DataMember]
		public ICollection<FlightNumberDTO> To { get; set; }
		[DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightsFrom { get; set; }
		[DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightsTo { get; set; }
		[DataMember]
		public ICollection<FlightNumberAirportRelationDTO> AirportRelationDtos { get; set; }

	    #endregion
	}
}
