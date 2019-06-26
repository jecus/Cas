using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("TripName", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class TripNameDTO : BaseEntity
	{
		[DataMember]
		[Column("TripName"), MaxLength(256)]
		public string TripName { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }

		#endregion
	}
}
