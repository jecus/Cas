using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("ActualStateRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ActualStateRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightRegimeId"), Required]
		public int FlightRegimeId { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("OnLifelength")]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("WorkRegimeTypeId")]
		public int? WorkRegimeTypeId { get; set; }

		[DataMember]
		[Column("ComponentId"), Required]
		public int ComponentId { get; set; }


		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}