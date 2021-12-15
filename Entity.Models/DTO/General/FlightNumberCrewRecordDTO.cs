using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Models.DTO.Dictionaries;


namespace Entity.Models.DTO.General
{
	[Table("FlightNumberCrewRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightNumberCrewRecordDTO : BaseEntity
	{
		
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		
		[Column("SpecializationId")]
		public int? SpecializationId { get; set; }

		
		[Column("Count")]
		public int? Count { get; set; }

		
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }

		
		[Include]
		public SpecializationDTO Specialization { get; set; }

	}
}