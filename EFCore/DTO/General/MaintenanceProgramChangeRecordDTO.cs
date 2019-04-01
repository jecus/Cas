using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceProgramChangeRecordDTO : BaseEntity
	{
		[DataMember]
		public int? ParentAircraftId { get; set; }

		[DataMember]
		public short? MSG { get; set; }

		[DataMember]
		public int? MaintenanceCheckRecordId { get; set; }

		[DataMember]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		public int? PerformanceNum { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		public string Remarks { get; set; }



		#region Navigation Property

		[DataMember]
		public AircraftDTO ParentAircraftDto { get; set; }

		#endregion
	}
}