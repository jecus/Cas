using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DamageDocumentDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int? DirectiveId { get; set; }

		[DataMember]
		public int? DamageChartId { get; set; }

		[DataMember]
		public string DamageLocation { get; set; }

		[DataMember]
		public short? DocumentType { get; set; }

		[DataMember]
		public string DamageChart2DImageName { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1185)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child]
		public ICollection<DamageSectorDTO> DamageSectors { get; set; }



		[DataMember]
		public DirectiveDTO Directive { get; set; }
	}
}