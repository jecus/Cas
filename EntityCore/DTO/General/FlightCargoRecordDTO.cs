using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("FlightCargoRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class FlightCargoRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightId")]
		public int? FlightId { get; set; }

		[DataMember]
		[Column("CargoCategory")]
		public int? CargoCategory { get; set; }

		[DataMember]
		[Column("Weigth")]
		public double? Weigth { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	}
}