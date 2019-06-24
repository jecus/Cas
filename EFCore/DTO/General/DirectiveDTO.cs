using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("Directives", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("IsApplicability")]
		public bool IsApplicability { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(1000)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("ThldTypeCond"), MaxLength(100)]
		public byte[] ThldTypeCond { get; set; }

		[DataMember]
		[Column("Applicability")]
		public string Applicability { get; set; }

		[DataMember]
		[Column("ATAChapter")]
		public int? ATAChapterId { get; set; }

		[DataMember]
		[Column("DirectiveType")]
		public int? DirectiveType { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("EngineeringOrders"), MaxLength(256)]
		public string EngineeringOrders { get; set; }

		[DataMember]
		[Column("EngineeringOrderFileID")]
		public int? EngineeringOrderFileID { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("Highlight")]
		public int? Highlight { get; set; }

		[DataMember]
		[Column("Paragraph"), MaxLength(256)]
		public string Paragraph { get; set; }

		[DataMember]
		[Column("KitRequired"), MaxLength(256)]
		public string KitRequired { get; set; }

		[DataMember]
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("ADType")]
		public short? ADType { get; set; }

		[DataMember]
		[Column("WorkType")]
		public int? WorkType { get; set; }

		[DataMember]
		[Column("ServiceBulletinNo"), MaxLength(256)]
		public string ServiceBulletinNo { get; set; }

		[DataMember]
		[Column("StcNo"), MaxLength(256)]
		public string StcNo { get; set; }

		[DataMember]
		[Column("ServiceBulletinFileID")]
		public int? ServiceBulletinFileID { get; set; }

		[DataMember]
		[Column("ADFileID")]
		public int? ADFileID { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("AircraftFlight")]
		public int? AircraftFlight { get; set; }

		[DataMember]
		[Column("NDTType"), Required]
		public short NDTType { get; set; }

		[DataMember]
		[Column("DirectiveOrder"), Required]
		public short DirectiveOrder { get; set; }

		[DataMember]
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		[DataMember]
		[Column("DefferedExtention")]
		public string DeferredExtention { get; set; }

		[DataMember]
		[Column("DefferedMelCdlItem")]
		public string DeferredMelCdlItem { get; set; }

		[DataMember]
		[Column("DefferedLogBookRef")]
		public string DeferredLogBookRef { get; set; }

		[DataMember]
		[Column("DefferedCategory")]
		public int DeferredCategoryId { get; set; }

		[DataMember]
		[Column("Number")]
		public string Number { get; set; }

		[DataMember]
		[Column("Location")]
		public string Location { get; set; }

		[DataMember]
		[Column("IsTemporary")]
		public bool IsTemporary { get; set; }

		[DataMember]
		[Column("DamageLenght")]
		public double DamageLenght { get; set; }

		[DataMember]
		[Column("DamageWidth")]
		public double DamageWidth { get; set; }

		[DataMember]
		[Column("DamageDepth")]
		public double DamageDepth { get; set; }

		[DataMember]
		[Column("DamageLenghtLimit")]
		public double DamageLenghtLimit { get; set; }

		[DataMember]
		[Column("DamageWidthLimit")]
		public double DamageWidthLimit { get; set; }

		[DataMember]
		[Column("DamageDepthLimit")]
		public double DamageDepthLimit { get; set; }

		[DataMember]
		[Column("DamageMeasure")]
		public int DamageMeasure { get; set; }

		[DataMember]
		[Column("DamageType")]
		public int DamageType { get; set; }

		[DataMember]
		[Column("DamageClass")]
		public int DamageClass { get; set; }

		[DataMember]
		[Column("SupersedesId")]
		public int? SupersedesId { get; set; }

		[DataMember]
		[Column("SupersededId")]
		public int? SupersededId { get; set; }

		[DataMember]
		[Column("Zone"), MaxLength(256)]
		public string Zone { get; set; }

		[DataMember]
		[Column("Access")]
		public string Access { get; set; }

		[DataMember]
		[Column("Workarea"), MaxLength(256)]
		public string Workarea { get; set; }

		[DataMember]
		[Column("CorrectiveAction")]
		public string CorrectiveAction { get; set; }

		[DataMember]
		[Column("InspectionDocumentsNo")]
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