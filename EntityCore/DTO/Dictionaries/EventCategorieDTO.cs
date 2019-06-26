using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("EventCategories", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
    public class EventCategorieDTO : BaseEntity
	{
		[DataMember]
		[Column("Weight")]
		public int? Weight { get; set; }

	    [DataMember]
	    [Column("MinCompareOp")]
		public int? MinCompareOp { get; set; }

		[DataMember]
		[Column("EventCountMinPeriod")]
		public int? EventCountMinPeriod { get; set; }

		[DataMember]
		[Column("MinReportPeriod"), MaxLength(21)]
		public byte[] MinReportPeriod { get; set; }

		[DataMember]
		[Column("MaxCompareOp")]
		public int? MaxCompareOp { get; set; }

		[DataMember]
		[Column("EventCountMaxPeriod")]
		public int? EventCountMaxPeriod { get; set; }

		[DataMember]
		[Column("MaxReportPeriod"), MaxLength(21)]
		public byte[] MaxReportPeriod { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
