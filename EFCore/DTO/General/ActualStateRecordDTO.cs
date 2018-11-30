using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ActualStateRecordDTO : BaseEntity
	{
		[DataMember]
		public int FlightRegimeId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? WorkRegimeTypeId { get; set; }

		[DataMember]
		public int ComponentId { get; set; }


		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}