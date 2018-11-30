using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class KnowledgeModuleDTO : BaseEntity
	{
		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }

		#endregion
	}
}