using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ModuleRecordDTO : BaseEntity
	{
		[DataMember]
		public int? AircraftWorkerCategoryId { get; set; }

		[DataMember]
		public int? KnowledgeModuleId { get; set; }

		[DataMember]
		public int? KnowledgeLevel { get; set; }

		[DataMember]
		[Include]
		public AircraftWorkerCategoryDTO AircraftWorkerCategory { get; set; }

		[DataMember]
		[Include]
		public KnowledgeModuleDTO KnowledgeModule { get; set; }
	}
}