using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("EventCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
    public class EventCategorieDTO : BaseEntity
	{
		
		[Column("Weight")]
		public int? Weight { get; set; }

	    
	    [Column("MinCompareOp")]
		public int? MinCompareOp { get; set; }

		
		[Column("EventCountMinPeriod")]
		public int? EventCountMinPeriod { get; set; }

		
		[Column("MinReportPeriod"), MaxLength(21)]
		public byte[] MinReportPeriod { get; set; }

		
		[Column("MaxCompareOp")]
		public int? MaxCompareOp { get; set; }

		
		[Column("EventCountMaxPeriod")]
		public int? EventCountMaxPeriod { get; set; }

		
		[Column("MaxReportPeriod"), MaxLength(21)]
		public byte[] MaxReportPeriod { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<EventDTO> EventDtos { get; set; }
		[JsonIgnore]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
