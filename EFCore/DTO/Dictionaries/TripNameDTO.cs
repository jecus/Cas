using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class TripNameDTO : BaseEntity
	{
		[DataMember]
		public string TripName { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<FlightTrackDTO> FlightTrackDtos { get; set; }

		#endregion
	}
}
