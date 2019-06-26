using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("EventClasses", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class EventClassDTO : BaseEntity
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

		
		public ICollection<EventDTO> EventDtos { get; set; }
		
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
