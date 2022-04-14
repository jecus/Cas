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
		[Column("Code"), MaxLength(50)]
		public string Code { get; set; }
		
		[Column("CodeName"), MaxLength(256)]
		public string CodeName { get; set; }
		
		[Column("SubTaskCode"), MaxLength(256)]
		public string SubTaskCode { get; set; }
		
		[Column("Description")]
		public string Description { get; set; }
		
		[Column("LevelId")]
		public int LevelId { get; set; }
		
		[Column("OperatorId")]
		public int OperatorId { get; set; }
		
		[Column("ShortName"), MaxLength(50)]
		public string ShortName { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }
		
		[Column("OccupationId")]
		public int OccupationId { get; set; }
		
		[Column("DepartmentId")]
		public int DepartmentId { get; set; }
		
		[Include]
		public CAASpecializationDTO Occupation { get; set; }
		
		
		[Include]
		public CAADepartmentDTO Department { get; set; }

	}
}
