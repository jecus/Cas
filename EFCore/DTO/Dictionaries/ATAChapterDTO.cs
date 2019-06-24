using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[Table("ATAChapter", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	public class ATAChapterDTO : BaseEntity
	{
		[DataMember]
		[Column("ShortName"), MaxLength(100), Required]
		public string ShortName { get; set; }

	    [DataMember]
	    [Column("FullName"), MaxLength(100), Required]
		public string FullName { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<AccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }
		[DataMember]
		public ICollection<NonRoutineJobDTO> NonRoutineJobDtos { get; set; }
		[DataMember]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
		[DataMember]
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }
		[DataMember]
		public ICollection<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		[DataMember]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

	    #endregion
    }
}
