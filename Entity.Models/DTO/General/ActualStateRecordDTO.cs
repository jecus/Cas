using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("ActualStateRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ActualStateRecordDTO : BaseEntity
	{
		
		[Column("FlightRegimeId")]
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

		[JsonIgnore]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}