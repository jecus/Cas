using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("ModuleRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class ModuleRecordDTO : BaseEntity
	{
		
		[Column("AircraftWorkerCategoryId")]
		public int? AircraftWorkerCategoryId { get; set; }

		
		[Column("KnowledgeModuleId")]
		public int? KnowledgeModuleId { get; set; }

		
		[Column("KnowledgeLevel")]
		public int? KnowledgeLevel { get; set; }

		
		[Include]
		public AircraftWorkerCategoryDTO AircraftWorkerCategory { get; set; }

		
		[Include]
		public KnowledgeModuleDTO KnowledgeModule { get; set; }
	}
}