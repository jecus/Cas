using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("MaintenanceProgramChangeRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class MaintenanceProgramChangeRecordDTO : BaseEntity
	{
		
		[Column("ParentAircraftId")]
		public int? ParentAircraftId { get; set; }

		
		[Column("MSG")]
		public short? MSG { get; set; }

		
		[Column("MaintenanceCheckRecordId")]
		public int? MaintenanceCheckRecordId { get; set; }

		
		[Column("CalculatedPerformanceSource"), MaxLength(21)]
		public byte[] CalculatedPerformanceSource { get; set; }

		
		[Column("PerformanceNum")]
		public int? PerformanceNum { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("OnLifelength"), MaxLength(21)]
		public byte[] OnLifelength { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }



		#region Navigation Property

		[JsonIgnore]
		public AircraftDTO ParentAircraftDto { get; set; }

		#endregion
	}
}