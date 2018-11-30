using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//LocationType
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LocationsTypeDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }

		[DataMember]
		public int DepartmentId { get; set; }

		[DataMember]
		[Include]
		public DepartmentDTO Department { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<LocationDTO> LocationDtos { get; set; }
		[DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
