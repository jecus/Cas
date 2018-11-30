using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.Dictionaries
{
	//NonRoutineJobDTO
	//[Condition("IsDeleted", "0")]
	//NonRoutineJob
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class NonRoutineJobDTO : BaseEntity
	{
		[DataMember]
		public int? ATAChapterId { get; set; }

	    [DataMember]
		public string Title { get; set; }

	    [DataMember]
		public string Description { get; set; }

	    [DataMember]
		public double? ManHours { get; set; }

	    [DataMember]
		public double? Cost { get; set; }

	    [DataMember]
		public string KitRequired { get; set; }

		#region Relation

		[DataMember]
		[Include]
	    public ATAChapterDTO ATAChapter { get; set; }

	    #endregion
	}
}
