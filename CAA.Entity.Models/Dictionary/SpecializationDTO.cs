using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("Specializations", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecializationDTO : BaseEntity, IBaseDictionary, IOperatable
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

	    
	    [Column("ShortName"), MaxLength(128)]
		public string ShortName { get; set; }

	    
	    [Column("DepartmentId")]
		public int? DepartmentId { get; set; }

	    
	    [Column("Level")]
		public int Level { get; set; }

	    
	    [Column("KeyPersonel")]
		public bool KeyPersonel { get; set; }


	    
		[Include]
	    public CAADepartmentDTO Department { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAADocumentDTO> DocumentDtos { get; set; }
        [JsonIgnore]
		public ICollection<CAASpecialistDTO> SpecialistDtos { get; set; }
		
		[JsonIgnore]
		public ICollection<EducationDTO> EducationDtos { get; set; }

		#endregion

        [Column("OperatorId")]
		public int OperatorId { get; set; }
    }
}
