using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.General;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("EmployeeSubjects", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class EmployeeSubjectDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

	    
	    [Column("LicenceTypeId")]
		public int? LicenceTypeId { get; set; }

		#region Navigation Property

		
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }

		#endregion
	}
}
