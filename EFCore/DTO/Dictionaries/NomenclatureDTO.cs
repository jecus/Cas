using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class NomenclatureDTO : BaseEntity
	{
		[DataMember]
		public int DepartmentId { get; set; }

	    [DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }

	    [DataMember]
		[Child]
	    public DepartmentDTO Department { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
