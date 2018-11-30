using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class AttachedFileDTO : BaseEntity
	{
		[DataMember]
		public string FileName { get; set; }

		[DataMember]
		public byte[] FileData { get; set; }

		[DataMember]
		public long? FileSize { get; set; }

		[DataMember]
		public bool StoreInDatabase { get; set; }

		[DataMember]
		public string FilePath { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<ItemFileLinkDTO> ItemFileLinkDto { get; set; }

		#endregion
	}
}