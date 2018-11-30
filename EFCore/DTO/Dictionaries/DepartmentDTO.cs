using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//Department
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DepartmentDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    [DataMember]
		public ICollection<SpecializationDTO> SpecializationDtos { get; set; }
	    [DataMember]
		public ICollection<NomenclatureDTO> NomenclatureDtos { get; set; }

		[DataMember]
		public ICollection<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		#endregion
	}
}
