using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.DTO.General
{
	[Table("FlightCargoRecords", Schema = "dbo")]
	
	public class FlightCargoRecordDTO : BaseEntity
	{
		
		[Column("FlightId")]
		public int? FlightId { get; set; }

		
		[Column("CargoCategory")]
		public int? CargoCategory { get; set; }

		
		[Column("Weigth")]
		public double? Weigth { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	}
}