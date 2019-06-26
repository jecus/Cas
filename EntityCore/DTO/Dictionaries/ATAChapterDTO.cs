using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("ATAChapter", Schema = "Dictionaries")]
	
	public class ATAChapterDTO : BaseEntity
	{
		
		[Column("ShortName"), MaxLength(100), Required]
		public string ShortName { get; set; }

	    
	    [Column("FullName"), MaxLength(100), Required]
		public string FullName { get; set; }

		#region Navigation Property

		
		public ICollection<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		
		public ICollection<NonRoutineJobDTO> NonRoutineJobDtos { get; set; }
		
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }
		
		public ICollection<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

	    #endregion
    }
}
