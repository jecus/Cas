using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int DirectiveType { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public int? Highlight { get; set; }

		[DataMember]
		public string KitRequired { get; set; }

		[DataMember]
		public int? FaaFormFileID { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public int? MPDTaskTypeId { get; set; }

		[DataMember]
		public short NDTType { get; set; }

		[DataMember]
		public int ComponentId { get; set; }

		[DataMember]
		public string ZoneArea { get; set; }

		[DataMember]
		public string AccessDirective { get; set; }

		[DataMember]
		public string AAM { get; set; }

		[DataMember]
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