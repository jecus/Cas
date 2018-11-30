using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class EventClassDTO : BaseEntity
	{
		[DataMember]
		public string FullName { get; set; }

	    [DataMember]
		public int? People { get; set; }

		[DataMember]
		public int? Failure { get; set; }

		[DataMember]
		public int? Regularity { get; set; }

		[DataMember]
		public int? Property { get; set; }

		[DataMember]
		public int? Environmental { get; set; }

		[DataMember]
		public int? Reputation { get; set; }

		[DataMember]
		public int? Weight { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
