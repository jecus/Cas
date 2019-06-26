using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("JobCardTasks", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class JobCardTaskDTO : BaseEntity
	{
		
		[Column("JobCardId")]
		public int? JobCardId { get; set; }

		
		[Column("ParentTaskId")]
		public int? ParentTaskId { get; set; }

		
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("Man")]
		public int? Man { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Include]
		public JobCardDTO JobCard { get; set; }

		#region Navigation Property

		
		public JobCardDTO JobCardDto { get; set; }

		#endregion

	}
}