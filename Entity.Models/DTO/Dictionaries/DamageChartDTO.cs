using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.General;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("DamageCharts", Schema = "Dictionaries")]
	[Condition("IsDeleted", 0)]

	public class DamageChartDTO : BaseEntity, IFileDtoContainer, IBaseDictionary
	{
		[Column("ItemID")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override int ItemId { get; set; }

		[Column("ChartName"), MaxLength(50)]
		public string ChartName { get; set; }

		
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1180)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Include]
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }

	}
}
