using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("Files", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class AttachedFileDTO : BaseEntity
	{
		[DataMember]
		[Column("FileName"), MaxLength(256)]
		public string FileName { get; set; }

		[DataMember]
		[Column("FileData")]
		public byte[] FileData { get; set; }

		[DataMember]
		[Column("FileSize")]
		public long? FileSize { get; set; }

		[DataMember]
		[Column("StoreInDatabase"), Required]
		public bool StoreInDatabase { get; set; }

		[DataMember]
		[Column("FilePath"), MaxLength(256)]
		public string FilePath { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<ItemFileLinkDTO> ItemFileLinkDto { get; set; }

		#endregion
	}
}