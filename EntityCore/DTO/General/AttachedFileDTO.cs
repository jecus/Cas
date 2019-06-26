using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.DTO.General
{
	[Table("Files", Schema = "dbo")]
	
	public class AttachedFileDTO : BaseEntity
	{
		
		[Column("FileName"), MaxLength(256)]
		public string FileName { get; set; }

		
		[Column("FileData")]
		public byte[] FileData { get; set; }

		
		[Column("FileSize")]
		public long? FileSize { get; set; }

		
		[Column("StoreInDatabase"), Required]
		public bool StoreInDatabase { get; set; }

		
		[Column("FilePath"), MaxLength(256)]
		public string FilePath { get; set; }


		#region Navigation Property

		
		public ICollection<ItemFileLinkDTO> ItemFileLinkDto { get; set; }

		#endregion
	}
}