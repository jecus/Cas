using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("FlightNumberCrewRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberCrewRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightNumberId")]
		public int? FlightNumberId { get; set; }

		[DataMember]
		[Column("SpecializationId")]
		public int? SpecializationId { get; set; }

		[DataMember]
		[Column("Count")]
		public int? Count { get; set; }

		[DataMember]
		[Include]
		public FlightNumberDTO FlightNumber { get; set; }

		[DataMember]
		[Include]
		public SpecializationDTO Specialization { get; set; }

	}
}