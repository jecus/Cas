using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("KnowledgeModules", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class KnowledgeModuleDTO : BaseEntity
	{
		
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("Description"), MaxLength(2048)]
		public string Description { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }

		#endregion
	}
}