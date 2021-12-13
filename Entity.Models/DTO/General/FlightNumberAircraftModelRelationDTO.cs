using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;


namespace Entity.Models.DTO.General
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