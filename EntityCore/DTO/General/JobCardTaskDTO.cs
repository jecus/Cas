using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("JobCardTasks", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class JobCardTaskDTO : BaseEntity
	{
		[DataMember]
		[Column("JobCardId")]
		public int? JobCardId { get; set; }

		[DataMember]
		[Column("ParentTaskId")]
		public int? ParentTaskId { get; set; }

		[DataMember]
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("Man")]
		public int? Man { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Cost")]
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