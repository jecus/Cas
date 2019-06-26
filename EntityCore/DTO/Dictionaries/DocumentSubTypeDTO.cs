using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("DocumentSubType", Schema = "Dictionaries")]
	
	public class DocumentSubTypeDTO : BaseEntity
	{
		
		[Column("DocumentTypeId"), Required]
		public int DocumentTypeId { get; set; }

	    
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		#region Navigation Property

	    
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
    }
}
