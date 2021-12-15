using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("EventCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class EventCategorieDTO : BaseEntity, IBaseDictionary
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
