using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumDTO : BaseEntity
	{
		[DataMember]
		public string FlightNumber { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
