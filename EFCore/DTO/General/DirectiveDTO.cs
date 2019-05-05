using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public bool IsApplicability { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		public byte[] ThldTypeCond { get; set; }

		[DataMember]
		public string Applicability { get; set; }

		[DataMember]
		public int? ATAChapterId { get; set; }

		[DataMember]
		public int? DirectiveType { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string EngineeringOrders { get; set; }

		[DataMember]
		public int? EngineeringOrderFileID { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public int? Highlight { get; set; }

		[DataMember]
		public string Paragraph { get; set; }

		[DataMember]
		public string KitRequired { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public short? ADType { get; set; }

		[DataMember]
		public int? WorkType { get; set; }

		[DataMember]
		public string ServiceBulletinNo { get; set; }

		[DataMember]
		public string StcNo { get; set; }

		[DataMember]
		public int? ServiceBulletinFileID { get; set; }

		[DataMember]
		public int? ADFileID { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public int? AircraftFlight { get; set; }

		[DataMember]
		public short NDTType { get; set; }

		[DataMember]
		public short DirectiveOrder { get; set; }

		[DataMember]
		public int? ComponentId { get; set; }

		[DataMember]
		public string DeferredExtention { get; set; }

		[DataMember]
		public string DeferredMelCdlItem { get; set; }

		[DataMember]
		public string DeferredLogBookRef { get; set; }

		[DataMember]
		public int DeferredCategoryId { get; set; }
		[DataMember]
		public string Number { get; set; }
		[DataMember]
		public string Location { get; set; }
		[DataMember]
		public bool IsTemporary { get; set; }
		[DataMember]
		public double DamageLenght { get; set; }
		[DataMember]
		public double DamageWidth { get; set; }
		[DataMember]
		public double DamageDepth { get; set; }
		[DataMember]
		public double DamageLenghtLimit { get; set; }
		[DataMember]
		public double DamageWidthLimit { get; set; }
		[DataMember]
		public double DamageDepthLimit { get; set; }
		[DataMember]
		public int DamageMeasure { get; set; }
		[DataMember]
		public int DamageType { get; set; }
		[DataMember]
		public int DamageClass { get; set; }

		[DataMember]
		public int? SupersedesId { get; set; }

		[DataMember]
		public int? SupersededId { get; set; }

		[DataMember]
		public string CorrectiveAction { get; set; }
		[DataMember]
		public string InspectionDocumentsNo { get; set; }
		[DataMember]
		[Include]
		public DefferedCategorieDTO DeferredCategory { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[DataMember]
		[Include]
		public ComponentDTO BaseComponent { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<DamageDocumentDTO> DamageDocs {get; set; }

}
}