using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AirportsCodes", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AirportCodeDTO : BaseEntity
	{
		[DataMember]
		[Column("Iata"), MaxLength(256)]
		public string Iata { get; set; }

		[DataMember]
		[Column("Icao"), MaxLength(256)]
		public string Icao { get; set; }

		[DataMember]
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		[DataMember]
		[Column("City"), MaxLength(256)]
		public string City { get; set; }

		[DataMember]
		[Column("Country"), MaxLength(256)]
		public string Country { get; set; }

		[DataMember]
		[Column("Iso"), MaxLength(256)]
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
