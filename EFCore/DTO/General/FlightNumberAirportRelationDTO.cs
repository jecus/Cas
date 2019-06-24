using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("FlightNumberAirportRelations", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberAirportRelationDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		[DataMember]
		[Column("AirportId")]
		public int? AirportId { get; set; }

		[DataMember]
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }

		[DataMember]
		[Include]
		public AirportCodeDTO Airport { get; set; }
	}
}