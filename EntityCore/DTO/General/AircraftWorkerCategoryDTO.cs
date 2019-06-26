using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("AircraftWorkerCategories", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AircraftWorkerCategoryDTO : BaseEntity
	{
		
		[Column("Category"), MaxLength(128)]
		public string Category { get; set; }

		#region Navigation Property

		
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

		#endregion
	}
}