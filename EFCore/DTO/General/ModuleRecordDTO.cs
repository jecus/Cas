using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("ModuleRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ModuleRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("AircraftWorkerCategoryId")]
		public int? AircraftWorkerCategoryId { get; set; }

		[DataMember]
		[Column("KnowledgeModuleId")]
		public int? KnowledgeModuleId { get; set; }

		[DataMember]
		[Column("KnowledgeLevel")]
		public int? KnowledgeLevel { get; set; }

		[DataMember]
		[Include]
		public AircraftWorkerCategoryDTO AircraftWorkerCategory { get; set; }

		[DataMember]
		[Include]
		public KnowledgeModuleDTO KnowledgeModule { get; set; }
	}
}