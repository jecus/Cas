using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("DamageSectors", Schema = "dbo")]
	
	public class DamageSectorDTO : BaseEntity
	{
		
		[Column("DamageChartColumn")]
		public int? DamageChartColumn { get; set; }

		
		[Column("DamageChartRow")]
		public int? DamageChartRow { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("DamageDocumentId")]
		public int? DamageDocumentId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public DamageDocumentDTO DamageDocument { get; set; }

		#endregion
	}
}