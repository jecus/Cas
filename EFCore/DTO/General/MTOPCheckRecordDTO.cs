using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MTOPCheckRecordDTO : BaseEntity
	{
		[DataMember]
		public string CheckName { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? GroupName { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public bool IsControlPoint { get; set; }

		[DataMember]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		public byte[] AverageUtilization { get; set; }

		#region Navigation Property

		[DataMember]
		public MTOPCheckDTO MtopCheckDto { get; set; }

		#endregion
	}
}