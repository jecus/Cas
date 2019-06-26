using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("FlightCrews", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class FlightCrewRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightID"), Required]
		public int FlightID { get; set; }

		[DataMember]
		[Column("SpecialistID")]
		public int? SpecialistID { get; set; }

		[DataMember]
		[Column("SpecializationID")]
		public int? SpecializationID { get; set; }

		[DataMember]
		[Column("IDNo")]
		public int? IDNo { get; set; }

		[DataMember]
		[Column("Limitations")]
		public string Limitations { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Child]
		public SpecialistDTO Specialist { get; set; }

		[DataMember]
		[Include]
		public SpecializationDTO Specialization { get; set; }
	}
}