using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[Table("CruiseLevels", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class CruiseLevelDTO : BaseEntity
	{
		[DataMember]
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		[DataMember]
		[Column("Meter")]
		public int? Meter { get; set; }

		[DataMember]
		[Column("Feet")]
		public int? Feet { get; set; }

		[DataMember]
		[Column("IVFR"), MaxLength(128)]
		public string IVFR { get; set; }

		[DataMember]
		[Column("Track"), MaxLength(128)]
		public string Track { get; set; }



		#region Navigation Property

	    [DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
