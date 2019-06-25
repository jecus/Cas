using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("ComponentDirectives", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("DirectiveType"), Required]
		public int DirectiveType { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(200)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("Highlight")]
		public int? Highlight { get; set; }

		[DataMember]
		[Column("KitRequired"), MaxLength(50)]
		public string KitRequired { get; set; }

		[DataMember]
		[Column("FaaFormFileID")]
		public int? FaaFormFileID { get; set; }

		[DataMember]
		[Column("HiddenRemarks"), MaxLength(128)]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("MPDTaskTypeId")]
		public int? MPDTaskTypeId { get; set; }

		[DataMember]
		[Column("NDTType"), Required]
		public short NDTType { get; set; }

		[DataMember]
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		[DataMember]
		[Column("ZoneArea"), MaxLength(256)]
		public string ZoneArea { get; set; }

		[DataMember]
		[Column("AccessDirective"), MaxLength(256)]
		public string AccessDirective { get; set; }

		[DataMember]
		[Column("AAM"), MaxLength(256)]
		public string AAM { get; set; }

		[DataMember]
		[Column("CMM"), MaxLength(256)]
		public string CMM { get; set; }


		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }


		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}