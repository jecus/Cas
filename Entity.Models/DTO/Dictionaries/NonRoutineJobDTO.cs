using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("NonRoutineJobs", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class NonRoutineJobDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("ATAChapterId")]
		public int? ATAChapterId { get; set; }

	    
	    [Column("Title"), MaxLength(50)]
		public string Title { get; set; }

	    
	    [Column("Description")]
		public string Description { get; set; }

	    
	    [Column("ManHours")]
		public double? ManHours { get; set; }

	    
	    [Column("Cost")]
		public double? Cost { get; set; }

	    
		[Column("KitRequired"), MaxLength(50)]
		public string KitRequired { get; set; }

		#region Relation

		
		[Include]
	    public ATAChapterDTO ATAChapter { get; set; }

	    #endregion
	}
}
