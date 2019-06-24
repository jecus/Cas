using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("FlightNumberAircraftModelRelations", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberAircraftModelRelationDTO : BaseEntity
	{
		[DataMember]
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		[DataMember]
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO AircraftModel { get;  set; }

		[DataMember]
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }
	}
}