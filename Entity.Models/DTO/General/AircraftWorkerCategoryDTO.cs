using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("AircraftWorkerCategories", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AircraftWorkerCategoryDTO : BaseEntity
	{
		
		[Column("Category"), MaxLength(128)]
		public string Category { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

		#endregion
	}
}