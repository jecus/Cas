using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class DamageSectorDTO : BaseEntity
	{
		[DataMember]
		public int? DamageChartColumn { get; set; }

		[DataMember]
		public int? DamageChartRow { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? DamageDocumentId { get; set; }

		#region Navigation Property

		[DataMember]
		public DamageDocumentDTO DamageDocument { get; set; }

		#endregion
	}
}