using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;
using DocumentDTO = Entity.Models.DTO.General.DocumentDTO;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("DocumentSubType", Schema = "Dictionaries")]
	[Condition("IsDeleted", 0)]

	public class DocumentSubTypeDTO : BaseEntity, IBaseDictionary
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
