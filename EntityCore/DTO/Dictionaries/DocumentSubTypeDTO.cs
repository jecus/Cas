using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("DocumentSubType", Schema = "Dictionaries")]
	
	public class DocumentSubTypeDTO : BaseEntity
	{
		
		[Column("DocumentTypeId")]
		public int DocumentTypeId { get; set; }

	    
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
    }
}
