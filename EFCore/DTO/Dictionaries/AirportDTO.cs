using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.Dictionaries
{
	[Table("NonRoutineJobs", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AirportDTO : BaseEntity
	{
		[DataMember]
		[Column("ShortName"), MaxLength(256)]
		public string ShortName { get; set; }

		[DataMember]
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		[DataMember]
		[Column("Locality")]
		public int? LocalityId { get; set; }

		[DataMember]
		[Column("Altitude")]
		public int? Altitude { get; set; }

		[DataMember]
		[Column("TimeBeginning")]
		public int? TimeBeginning { get; set; }

		[DataMember]
		[Column("TimeEnd")]
		public int? TimeEnd { get; set; }
	}
	
}
