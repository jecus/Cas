using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("DamageSectors", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class DamageSectorDTO : BaseEntity
	{
		[DataMember]
		[Column("DamageChartColumn")]
		public int? DamageChartColumn { get; set; }

		[DataMember]
		[Column("DamageChartRow")]
		public int? DamageChartRow { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("DamageDocumentId")]
		public int? DamageDocumentId { get; set; }

		#region Navigation Property

		[DataMember]
		public DamageDocumentDTO DamageDocument { get; set; }

		#endregion
	}
}