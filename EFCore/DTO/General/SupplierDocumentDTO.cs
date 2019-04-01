using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SupplierDocumentDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string DocumentType { get; set; }

		[DataMember]
		public int? FileId { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2050)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}