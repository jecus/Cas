using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("LocationsType", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LocationsTypeDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		
		[Include]
		public DepartmentDTO Department { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<LocationDTO> LocationDtos { get; set; }
		[JsonIgnore]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
