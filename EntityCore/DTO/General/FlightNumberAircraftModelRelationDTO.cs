using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("FlightNumberAircraftModelRelations", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightNumberAircraftModelRelationDTO : BaseEntity
	{
		
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		
		[Child]
		public AccessoryDescriptionDTO AircraftModel { get;  set; }

		
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }
	}
}