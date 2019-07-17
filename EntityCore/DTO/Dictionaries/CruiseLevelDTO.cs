using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("CruiseLevels", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CruiseLevelDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		
		[Column("Meter")]
		public int? Meter { get; set; }

		
		[Column("Feet")]
		public int? Feet { get; set; }

		
		[Column("IVFR"), MaxLength(128)]
		public string IVFR { get; set; }

		
		[Column("Track"), MaxLength(128)]
		public string Track { get; set; }



		#region Navigation Property

		[JsonIgnore]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
