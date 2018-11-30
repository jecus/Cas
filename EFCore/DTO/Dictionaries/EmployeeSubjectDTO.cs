using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//EmployeeSubject
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class EmployeeSubjectDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }

	    [DataMember]
		public int? LicenceTypeId { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<SpecialistTrainingDTO> SpecialistTrainingDtos { get; set; }

		#endregion
	}
}
