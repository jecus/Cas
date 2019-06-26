using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.Dictionaries
{
	[Table("NonRoutineJobs", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class NonRoutineJobDTO : BaseEntity
	{
		[DataMember]
		[Column("ATAChapterId")]
		public int? ATAChapterId { get; set; }

	    [DataMember]
	    [Column("Title"), MaxLength(50)]
		public string Title { get; set; }

	    [DataMember]
	    [Column("Description")]
		public string Description { get; set; }

	    [DataMember]
	    [Column("ManHours")]
		public double? ManHours { get; set; }

	    [DataMember]
	    [Column("Cost")]
		public double? Cost { get; set; }

	    [DataMember]
		[Column("KitRequired"), MaxLength(50)]
		public string KitRequired { get; set; }

		#region Relation

		[DataMember]
		[Include]
	    public ATAChapterDTO ATAChapter { get; set; }

	    #endregion
	}
}
