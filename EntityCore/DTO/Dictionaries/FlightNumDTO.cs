using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("FlightNum", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class FlightNumDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("FlightNumber"), MaxLength(256)]
		public string FlightNumber { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
