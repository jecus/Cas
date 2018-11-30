using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecializationDTO : BaseEntity
	{
		[DataMember]
		public string FullName { get; set; }

	    [DataMember]
		public string ShortName { get; set; }

	    [DataMember]
		public int DepartmentId { get; set; }

	    [DataMember]
		public int Level { get; set; }

	    [DataMember]
		public bool KeyPersonel { get; set; }


	    [DataMember]
		[Include]
	    public DepartmentDTO Department { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    [DataMember]
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
	    [DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
