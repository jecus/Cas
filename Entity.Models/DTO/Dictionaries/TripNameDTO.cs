using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("TripName", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class TripNameDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("TripName"), MaxLength(256)]
		public string TripName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }

		#endregion
	}
}
