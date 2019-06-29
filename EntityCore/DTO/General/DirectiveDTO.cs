using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("Directives", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class DirectiveDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		
		[Column("IsApplicability")]
		public bool IsApplicability { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("Threshold"), MaxLength(1000)]
		public byte[] Threshold { get; set; }

		
		[Column("ThldTypeCond"), MaxLength(100)]
		public byte[] ThldTypeCond { get; set; }

		
		[Column("Applicability")]
		public string Applicability { get; set; }

		
		[Column("ATAChapter")]
		public int? ATAChapterId { get; set; }

		
		[Column("DirectiveType")]
		public int? DirectiveType { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("EngineeringOrders"), MaxLength(256)]
		public string EngineeringOrders { get; set; }

		
		[Column("EngineeringOrderFileID")]
		public int? EngineeringOrderFileID { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("Highlight")]
		public int? Highlight { get; set; }

		
		[Column("Paragraph"), MaxLength(256)]
		public string Paragraph { get; set; }

		
		[Column("KitRequired"), MaxLength(256)]
		public string KitRequired { get; set; }

		
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		
		[Column("ADType")]
		public short? ADType { get; set; }

		
		[Column("WorkType")]
		public int? WorkType { get; set; }

		
		[Column("ServiceBulletinNo"), MaxLength(256)]
		public string ServiceBulletinNo { get; set; }

		
		[Column("StcNo"), MaxLength(256)]
		public string StcNo { get; set; }

		
		[Column("ServiceBulletinFileID")]
		public int? ServiceBulletinFileID { get; set; }

		
		[Column("ADFileID")]
		public int? ADFileID { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("AircraftFlight")]
		public int? AircraftFlight { get; set; }

		
		[Column("NDTType")]
		public short NDTType { get; set; }

		
		[Column("DirectiveOrder")]
		public short DirectiveOrder { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		
		[Column("DefferedExtention")]
		public string DeferredExtention { get; set; }

		
		[Column("DefferedMelCdlItem")]
		public string DeferredMelCdlItem { get; set; }

		
		[Column("DefferedLogBookRef")]
		public string DeferredLogBookRef { get; set; }

		
		[Column("DefferedCategory")]
		public int? DeferredCategoryId { get; set; }

		
		[Column("Number")]
		public string Number { get; set; }

		
		[Column("Location")]
		public string Location { get; set; }

		
		[Column("IsTemporary")]
		public bool IsTemporary { get; set; }

		
		[Column("DamageLenght")]
		public double DamageLenght { get; set; }

		
		[Column("DamageWidth")]
		public double DamageWidth { get; set; }

		
		[Column("DamageDepth")]
		public double DamageDepth { get; set; }

		
		[Column("DamageLenghtLimit")]
		public double DamageLenghtLimit { get; set; }

		
		[Column("DamageWidthLimit")]
		public double DamageWidthLimit { get; set; }

		
		[Column("DamageDepthLimit")]
		public double DamageDepthLimit { get; set; }

		
		[Column("DamageMeasure")]
		public int DamageMeasure { get; set; }

		
		[Column("DamageType")]
		public int DamageType { get; set; }

		
		[Column("DamageClass")]
		public int DamageClass { get; set; }

		
		[Column("SupersedesId")]
		public int? SupersedesId { get; set; }

		
		[Column("SupersededId")]
		public int? SupersededId { get; set; }

		
		[Column("Zone"), MaxLength(256)]
		public string Zone { get; set; }

		
		[Column("Access")]
		public string Access { get; set; }

		
		[Column("Workarea"), MaxLength(256)]
		public string Workarea { get; set; }

		
		[Column("CorrectiveAction")]
		public string CorrectiveAction { get; set; }

		
		[Column("InspectionDocumentsNo")]
		public string InspectionDocumentsNo { get; set; }

		
		[Include]
		public DefferedCategorieDTO DeferredCategory { get; set; }

		
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		
		[Include]
		public ComponentDTO BaseComponent { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		
		[Child]
		public ICollection<DamageDocumentDTO> DamageDocs {get; set; }

}
}