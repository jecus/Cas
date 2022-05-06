using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("EventCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAAEventCategorieDTO : BaseEntity, IBaseDictionary
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
		
				
		[Column("OperatorId")]
		public int OperatorId { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAAEventDTO> EventDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAAEventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

		[Column("FullName")]
		public string FullName { get; set; }

		#endregion

	}
}
