using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class SmsEventTypeDTO : BaseEntity
	{
		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public string Description { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

		#endregion
	}
}