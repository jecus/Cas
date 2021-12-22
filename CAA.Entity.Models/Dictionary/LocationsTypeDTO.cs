using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("LocationsType", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAALocationsTypeDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		
		[Include]
		public CAADepartmentDTO Department { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAALocationDTO> LocationDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAASpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
