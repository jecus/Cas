using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("SupplierDocuments", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SupplierDocumentDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		[DataMember]
		[Column("Name"), MaxLength(200)]
		public string Name { get; set; }

		[DataMember]
		[Column("DocumentType"), MaxLength(200)]
		public string DocumentType { get; set; }

		[DataMember]
		[Column("FileId")]
		public int? FileId { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2050)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}