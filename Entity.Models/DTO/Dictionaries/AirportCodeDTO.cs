using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("AirportsCodes", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class AirportCodeDTO : BaseEntity, IBaseDictionary
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
		[JsonIgnore]
		public ICollection<FlightNumberDTO> From { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberDTO> To { get; set; }
		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightsFrom { get; set; }
		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightsTo { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberAirportRelationDTO> AirportRelationDtos { get; set; }

	    #endregion
	}
}
