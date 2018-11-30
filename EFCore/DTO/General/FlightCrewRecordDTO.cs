using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class FlightCrewRecordDTO : BaseEntity
	{
		[DataMember]
		public int FlightID { get; set; }

		[DataMember]
		public int? SpecialistID { get; set; }

		[DataMember]
		public int? SpecializationID { get; set; }

		[DataMember]
		public int? IDNo { get; set; }

		[DataMember]
		public string Limitations { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		[Child]
		public SpecialistDTO Specialist { get; set; }

		[DataMember]
		[Include]
		public SpecializationDTO Specialization { get; set; }
	}
}