using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//CruiseLevel
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class CruiseLevelDTO : BaseEntity
	{
		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public int? Meter { get; set; }

		[DataMember]
		public int? Feet { get; set; }

		[DataMember]
		public string IVFR { get; set; }

		[DataMember]
		public string Track { get; set; }



		#region Navigation Property

	    [DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
