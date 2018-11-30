using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;
using EFCore.Interfaces;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	public class DamageChartDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public string ChartName { get; set; }

		[DataMember]
		public int? AircraftModelId { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1180)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }

    }
}
