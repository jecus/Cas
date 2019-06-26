using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("TripName", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class TripNameDTO : BaseEntity
	{
		
		[Column("TripName"), MaxLength(256)]
		public string TripName { get; set; }

		#region Navigation Property

	    
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }

		#endregion
	}
}
