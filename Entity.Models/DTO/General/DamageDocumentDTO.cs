﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("DamageDocuments", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class DamageDocumentDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("DirectiveId")]
		public int? DirectiveId { get; set; }

		
		[Column("DamageChartId")]
		public int? DamageChartId { get; set; }

		
		[Column("DamageLocation"), MaxLength(256)]
		public string DamageLocation { get; set; }

		
		[Column("DocumentType")]
		public short? DocumentType { get; set; }

		
		[Column("DamageChart2DImageName"), MaxLength(256)]
		public string DamageChart2DImageName { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1185)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Child]
		public ICollection<DamageSectorDTO> DamageSectors { get; set; }



		[JsonIgnore]
		public DirectiveDTO Directive { get; set; }
	}
}