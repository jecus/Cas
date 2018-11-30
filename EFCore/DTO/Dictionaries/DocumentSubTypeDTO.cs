using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	public class DocumentSubTypeDTO : BaseEntity
	{
		[DataMember]
		public int DocumentTypeId { get; set; }

	    [DataMember]
		public string Name { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
    }
}
