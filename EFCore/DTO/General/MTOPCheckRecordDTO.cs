using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("MTOPCheckRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MTOPCheckRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("CheckName"), MaxLength(150)]
		public string CheckName { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("GroupName")]
		public int? GroupName { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("IsControlPoint"), Required]
		public bool IsControlPoint { get; set; }

		[DataMember]
		[Column("CalculatedPerformanceSource")]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		[Column("AverageUtilization"), MaxLength(50)]
		public byte[] AverageUtilization { get; set; }

		#region Navigation Property

		[DataMember]
		public MTOPCheckDTO MtopCheckDto { get; set; }

		#endregion
	}
}