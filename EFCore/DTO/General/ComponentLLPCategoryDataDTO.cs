using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("ComponentLLPCategoryData", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class ComponentLLPCategoryDataDTO : BaseEntity
	{
		[DataMember]
		[Column("LLPCategoryId"), Required]
		public int LLPCategoryId { get; set; }

		[DataMember]
		[Column("LLPLifeLength"), MaxLength(50)]
		public byte[] LLPLifeLength { get; set; }

		[DataMember]
		[Column("LLPLifeLimit"), MaxLength(50)]
		public byte[] LLPLifeLimit { get; set; }

		[DataMember]
		[Column("Notify"), MaxLength(50)]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("ComponentId"), Required]
		public int ComponentId { get; set; }

		[DataMember]
		[Column("LLPLifeLengthCurrent"), MaxLength(50)]
		public byte[] LLPLifeLengthCurrent { get; set; }

		[DataMember]
		[Column("LLPLifeLengthForDate"), MaxLength(50)]
		public byte[] LLPLifeLengthForDate { get; set; }

		[DataMember]
		[Column("Date")]
		public DateTime? Date { get; set; }


		[DataMember]
		[Include]
		public LifeLimitCategorieDTO ParentCategory { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}