using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("SupplierDocuments", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SupplierDocumentDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("Name"), MaxLength(200)]
		public string Name { get; set; }

		
		[Column("DocumentType"), MaxLength(200)]
		public string DocumentType { get; set; }

		
		[Column("FileId")]
		public int? FileId { get; set; }


		
		[Child(FilterType.Equal, "ParentTypeId", 2050)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}