using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class JobCardTaskDTO : BaseEntity
	{
		[DataMember]
		public int? JobCardId { get; set; }

		[DataMember]
		public int? ParentTaskId { get; set; }

		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? Man { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		[Include]
		public JobCardDTO JobCard { get; set; }

		#region Navigation Property

		[DataMember]
		public JobCardDTO JobCardDto { get; set; }

		#endregion

	}
}