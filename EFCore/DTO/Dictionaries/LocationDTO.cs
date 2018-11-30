using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LocationDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

	    [DataMember]
		public string FullName { get; set; }

	    [DataMember]
		public int LocationsTypeId { get; set; }

	    [DataMember]
		[Child]
	    public LocationsTypeDTO LocationsType { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion

	}
}
