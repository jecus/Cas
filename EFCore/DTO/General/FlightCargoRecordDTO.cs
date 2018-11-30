using System;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class FlightCargoRecordDTO : BaseEntity
	{
		[DataMember]
		public int? FlightId { get; set; }

		[DataMember]
		public int? CargoCategory { get; set; }

		[DataMember]
		public double? Weigth { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }
	}
}