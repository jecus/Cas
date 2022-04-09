using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("EventClasses", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAAEventClassDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

	    
	    [Column("People")]
		public int? People { get; set; }

		
		[Column("Failure")]
		public int? Failure { get; set; }

		
		[Column("Regularity")]
		public int? Regularity { get; set; }

		
		[Column("Property")]
		public int? Property { get; set; }

		
		[Column("Environmental")]
		public int? Environmental { get; set; }

		
		[Column("Reputation")]
		public int? Reputation { get; set; }

		
		[Column("Weight")]
		public int? Weight { get; set; }
		
				
		[Column("OperatorId")]
		public int OperatorId { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAAEventDTO> EventDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAAEventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
