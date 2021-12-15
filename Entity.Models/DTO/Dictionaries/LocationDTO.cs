using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("Locations", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class LocationDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

	    
	    [Column("LocationsTypeId")]
		public int? LocationsTypeId { get; set; }

	    
		[Child]
	    public LocationsTypeDTO LocationsType { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		[JsonIgnore]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion

	}
}
