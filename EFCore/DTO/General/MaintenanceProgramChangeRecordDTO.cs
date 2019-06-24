using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("MaintenanceProgramChangeRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceProgramChangeRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentAircraftId")]
		public int? ParentAircraftId { get; set; }

		[DataMember]
		[Column("MSG")]
		public short? MSG { get; set; }

		[DataMember]
		[Column("MaintenanceCheckRecordId")]
		public int? MaintenanceCheckRecordId { get; set; }

		[DataMember]
		[Column("CalculatedPerformanceSource"), MaxLength(21)]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		[Column("PerformanceNum")]
		public int? PerformanceNum { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("OnLifelength"), MaxLength(21)]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }



		#region Navigation Property

		[DataMember]
		public AircraftDTO ParentAircraftDto { get; set; }

		#endregion
	}
}