using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//EventCategory
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
    public class EventCategorieDTO : BaseEntity
	{
		[DataMember]
		public int? Weight { get; set; }

	    [DataMember]
		public int? MinCompareOp { get; set; }

		[DataMember]
		public int? EventCountMinPeriod { get; set; }

		[DataMember]
		public byte[] MinReportPeriod { get; set; }

		[DataMember]
		public int? MaxCompareOp { get; set; }

		[DataMember]
		public int? EventCountMaxPeriod { get; set; }

		[DataMember]
		public byte[] MaxReportPeriod { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
