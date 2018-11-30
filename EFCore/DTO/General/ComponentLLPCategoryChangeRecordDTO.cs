using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class ComponentLLPCategoryChangeRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int ParentId { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? ToCategoryId { get; set; }

		[DataMember]
		public byte[] OnLifeLength { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		[Include]
		public LifeLimitCategorieDTO ToCategory { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1200)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}