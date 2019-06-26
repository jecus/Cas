using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("LocationsType", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LocationsTypeDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }

		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		
		[Include]
		public DepartmentDTO Department { get; set; }

		#region Navigation Property

		
		public ICollection<LocationDTO> LocationDtos { get; set; }
		
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
