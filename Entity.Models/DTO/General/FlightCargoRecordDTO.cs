using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("FlightCargoRecords", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

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