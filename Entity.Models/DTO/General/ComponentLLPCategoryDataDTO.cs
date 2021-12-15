using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("ComponentLLPCategoryData", Schema = "dbo")]
	
	public class ComponentLLPCategoryDataDTO : BaseEntity
	{
		
		[Column("LLPCategoryId")]
		public int? LLPCategoryId { get; set; }

		
		[Column("LLPLifeLength"), MaxLength(50)]
		public byte[] LLPLifeLength { get; set; }

		
		[Column("LLPLifeLimit"), MaxLength(50)]
		public byte[] LLPLifeLimit { get; set; }

		
		[Column("Notify"), MaxLength(50)]
		public byte[] Notify { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		
		[Column("LLPLifeLengthCurrent"), MaxLength(50)]
		public byte[] LLPLifeLengthCurrent { get; set; }

		
		[Column("LLPLifeLengthForDate"), MaxLength(50)]
		public byte[] LLPLifeLengthForDate { get; set; }

		
		[Column("Date")]
		public DateTime? Date { get; set; }


		
		[Include]
		public LifeLimitCategorieDTO ParentCategory { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}