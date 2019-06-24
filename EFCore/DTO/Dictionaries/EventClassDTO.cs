using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[Table("EventClasses", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class EventClassDTO : BaseEntity
	{
		[DataMember]
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

	    [DataMember]
	    [Column("People")]
		public int? People { get; set; }

		[DataMember]
		[Column("Failure")]
		public int? Failure { get; set; }

		[DataMember]
		[Column("Regularity")]
		public int? Regularity { get; set; }

		[DataMember]
		[Column("Property")]
		public int? Property { get; set; }

		[DataMember]
		[Column("Environmental")]
		public int? Environmental { get; set; }

		[DataMember]
		[Column("Reputation")]
		public int? Reputation { get; set; }

		[DataMember]
		[Column("Weight")]
		public int? Weight { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

	    #endregion

	}
}
