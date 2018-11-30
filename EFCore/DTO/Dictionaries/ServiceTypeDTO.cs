using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ServiceTypeDTO : BaseEntity
    {

	    [DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
