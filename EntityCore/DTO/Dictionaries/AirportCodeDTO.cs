using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AirportsCodes", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class AirportCodeDTO : BaseEntity
	{
		
		[Column("Iata"), MaxLength(256)]
		public string Iata { get; set; }

		
		[Column("Icao"), MaxLength(256)]
		public string Icao { get; set; }

		
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		
		[Column("City"), MaxLength(256)]
		public string City { get; set; }

		
		[Column("Country"), MaxLength(256)]
		public string Country { get; set; }

		
		[Column("Iso"), MaxLength(256)]
		public string Iso { get; set; }


		#region Navigation Property
		
		public ICollection<FlightNumberDTO> From { get; set; }
		
		public ICollection<FlightNumberDTO> To { get; set; }
		
		public ICollection<AircraftFlightDTO> AircraftFlightsFrom { get; set; }
		
		public ICollection<AircraftFlightDTO> AircraftFlightsTo { get; set; }
		
		public ICollection<FlightNumberAirportRelationDTO> AirportRelationDtos { get; set; }

	    #endregion
	}
}
