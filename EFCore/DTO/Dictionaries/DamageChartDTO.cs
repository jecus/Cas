using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;
using EFCore.Interfaces;

namespace EFCore.DTO.Dictionaries
{
	[Table("DamageCharts", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	public class DamageChartDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("ChartName"), MaxLength(50)]
		public string ChartName { get; set; }

		[DataMember]
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1180)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }

    }
}
