using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class ComponentLLPCategoryDataDTO : BaseEntity
	{
		[DataMember]
		public int LLPCategoryId { get; set; }

		[DataMember]
		public byte[] LLPLifeLength { get; set; }

		[DataMember]
		public byte[] LLPLifeLimit { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public int ComponentId { get; set; }

		[DataMember]
		public byte[] LLPLifeLengthCurrent { get; set; }

		[DataMember]
		public byte[] LLPLifeLengthForDate { get; set; }

		[DataMember]
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