using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using AirportCodeDTO = Entity.Models.DTO.Dictionaries.AirportCodeDTO;

namespace Entity.Models.DTO.General
{
	[Table("FlightNumberAirportRelations", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightNumberAirportRelationDTO : BaseEntity
	{
		
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		
		[Column("AirportId")]
		public int? AirportId { get; set; }

		
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }

		
		[Include]
		public AirportCodeDTO Airport { get; set; }
	}
}