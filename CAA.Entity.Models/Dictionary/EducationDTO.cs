using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("Education", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class EducationDTO : BaseEntity, IBaseDictionary
	{

		
		[Column("OperatorId")]
		public int OperatorId { get; set; }
		
		[Column("TaskId")]
		public int TaskId { get; set; }
		
		[Column("OccupationId")]
		public int OccupationId { get; set; }
		
		[Include]
		public CAASpecializationDTO Occupation { get; set; }
		
		[Include]
		public TaskDTO Task { get; set; }
		

	}
}
