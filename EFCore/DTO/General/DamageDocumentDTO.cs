using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("DamageDocuments", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DamageDocumentDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("DirectiveId")]
		public int? DirectiveId { get; set; }

		[DataMember]
		[Column("DamageChartId")]
		public int? DamageChartId { get; set; }

		[DataMember]
		[Column("DamageLocation"), MaxLength(256)]
		public string DamageLocation { get; set; }

		[DataMember]
		[Column("DocumentType")]
		public short? DocumentType { get; set; }

		[DataMember]
		[Column("DamageChart2DImageName"), MaxLength(256)]
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