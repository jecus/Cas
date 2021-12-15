using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		
		[Column("StoreInDatabase")]
		public bool StoreInDatabase { get; set; }

		
		[Column("FilePath"), MaxLength(256)]
		public string FilePath { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<ItemFileLinkDTO> ItemFileLinkDto { get; set; }

		#endregion
	}
}