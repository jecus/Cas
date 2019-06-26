using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("ServiceTypes", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class ServiceTypeDTO : BaseEntity
    {

	    
		[Column("Name"), MaxLength(50), Required]
		public string Name { get; set; }

	    
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		#region Navigation Property

	    
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
