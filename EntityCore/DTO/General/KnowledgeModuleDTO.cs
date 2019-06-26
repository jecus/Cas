using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("KnowledgeModules", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class KnowledgeModuleDTO : BaseEntity
	{
		[DataMember]
		[Column("Number"), MaxLength(256)]
		public string Number { get; set; }

		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(2048)]
		public string Description { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }

		#endregion
	}
}