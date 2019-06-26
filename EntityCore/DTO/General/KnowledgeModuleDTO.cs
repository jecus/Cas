using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
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

		
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }

		#endregion
	}
}