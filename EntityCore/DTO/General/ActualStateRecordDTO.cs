using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("ActualStateRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ActualStateRecordDTO : BaseEntity
	{
		
		[Column("FlightRegimeId"), Required]
		public int FlightRegimeId { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("OnLifelength")]
		public byte[] OnLifelength { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("WorkRegimeTypeId")]
		public int? WorkRegimeTypeId { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }


		#region Navigation Property

		
		public ComponentDTO Component { get; set; }

		#endregion
	}
}