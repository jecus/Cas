using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("EventClasses", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class EventClassDTO : BaseEntity, IBaseDictionary
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


		#region Navigation Property

		[JsonIgnore]
		public ICollection<EventDTO> EventDtos { get; set; }
		[JsonIgnore]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
