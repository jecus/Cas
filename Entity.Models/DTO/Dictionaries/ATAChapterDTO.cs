using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;


namespace Entity.Models.DTO.Dictionaries
{
	[Table("ATAChapter", Schema = "Dictionaries")]
	[Condition("IsDeleted", 0)]

	public class ATAChapterDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("ShortName"), MaxLength(100)]
		public string ShortName { get; set; }

		
		[Column("FullName"), MaxLength(100)]
		public string FullName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		[JsonIgnore]
		public ICollection<NonRoutineJobDTO> NonRoutineJobDtos { get; set; }
		[JsonIgnore]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		[JsonIgnore]
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }
		[JsonIgnore]
		public ICollection<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		[JsonIgnore]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		[JsonIgnore]
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

		#endregion
	}
}
