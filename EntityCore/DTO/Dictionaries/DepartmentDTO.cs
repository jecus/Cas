using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Departments", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class DepartmentDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }


		#region Navigation Property

	    
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    
		public ICollection<SpecializationDTO> SpecializationDtos { get; set; }
	    
		public ICollection<NomenclatureDTO> NomenclatureDtos { get; set; }

		
		public ICollection<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		#endregion
	}
}
