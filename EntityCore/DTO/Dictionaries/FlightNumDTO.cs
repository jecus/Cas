using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("FlightNum", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightNumber"), MaxLength(256)]
		public string FlightNumber { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<AircraftFlightDTO> AircraftFlightDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberDTO> FlightNumberDtos { get; set; }

		#endregion
	}
}
