using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.Dictionary
{
	[Table("EmployeeSubjects", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAAEmployeeSubjectDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

	    
	    [Column("LicenceTypeId")]
		public int? LicenceTypeId { get; set; }

		#region Navigation Property

		
		public ICollection<CAASpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }

		#endregion
	}
}
