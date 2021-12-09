using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;
using Newtonsoft.Json;
using LifeLimitCategorieDTO = Entity.Models.DTO.Dictionaries.LifeLimitCategorieDTO;

namespace Entity.Models.DTO.General
{
	[Table("ComponentLLPCategoryChangeRecords", Schema = "dbo")]
	
	public class ComponentLLPCategoryChangeRecordDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("ToCategoryId")]
		public int? ToCategoryId { get; set; }

		
		[Column("OnLifeLength"), MaxLength(50)]
		public byte[] OnLifeLength { get; set; }

		
		[Column("Remarks"), MaxLength(250)]
		public string Remarks { get; set; }

		
		[Include]
		public LifeLimitCategorieDTO ToCategory { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1200)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}