using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Locations", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LocationDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }

	    
	    [Column("LocationsTypeId")]
		public int? LocationsTypeId { get; set; }

	    
		[Child]
	    public LocationsTypeDTO LocationsType { get; set; }


		#region Navigation Property

	    
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
	    
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion

	}
}
