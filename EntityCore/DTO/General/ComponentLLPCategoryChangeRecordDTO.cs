using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("ComponentLLPCategoryChangeRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class ComponentLLPCategoryChangeRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("ToCategoryId")]
		public int? ToCategoryId { get; set; }

		[DataMember]
		[Column("OnLifeLength"), MaxLength(50)]
		public byte[] OnLifeLength { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(250)]
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