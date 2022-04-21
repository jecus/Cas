using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("Education", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class EducationDTO : BaseEntity, IBaseDictionary
	{

		
		[Column("OperatorId")]
		public int OperatorId { get; set; }
		
		[Column("TaskId")]
		public int TaskId { get; set; }
		
		[Column("OccupationId")]
		public int OccupationId { get; set; }
		
		[Column("PriorityId")]
		public int PriorityId { get; set; }
		
		[Include]
		public CAASpecializationDTO Occupation { get; set; }
		
		[Include]
		public TaskDTO Task { get; set; }
		

	}
}
