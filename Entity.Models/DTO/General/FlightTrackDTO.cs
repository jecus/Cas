using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using TripNameDTO = Entity.Models.DTO.Dictionaries.TripNameDTO;

namespace Entity.Models.DTO.General
{
	[Table("FlightTrips", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightTrackDTO : BaseEntity
	{
		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }

		
		[Column("DayOfWeek")]
		public int? DayOfWeek { get; set; }

		
		[Column("TripName")]
		public int? TripNameId { get; set; }

		
		[Column("SupplierID")]
		public int? SupplierID { get; set; }

		
		[Include]
		public TripNameDTO TripName { get; set; }

		
		[Child]
		public SupplierDTO Supplier { get; set; }

		
		[Child]
		public ICollection<FlightTrackRecordDTO> FlightTripRecord { get; set; }
	}
}