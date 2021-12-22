using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("DocumentSubType", Schema = "Dictionaries")]
	[Condition("IsDeleted", 0)]

	public class CAADocumentSubTypeDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("DocumentTypeId")]
		public int DocumentTypeId { get; set; }

		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAADocumentDTO> DocumentDtos { get; set; }

		#endregion
	}
}
