using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberAircraftModelRelationDTO : BaseEntity
	{
		[DataMember]
		public int? AircraftModelId { get; set; }

		[DataMember]
		public int? FlightNumberId { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO AircraftModel { get;  set; }

		[DataMember]
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }
	}
}