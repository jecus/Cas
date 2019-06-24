using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("Components", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentDTO : BaseEntity,IFileDtoContainer
	{
		[DataMember]
		[Column("ComponentCount"), Required]
		public int ComponentCount { get; set; }

		[DataMember]
		[Column("AverageUtilization"), MaxLength(50)]
		public byte[] AverageUtilization { get; set; }

		[DataMember]
		[Column("Acceleration")]
		public int? Acceleration { get; set; }

		[DataMember]
		[Column("AccelerationAir")]
		public int? AccelerationAir { get; set; }

		[DataMember]
		[Column("JobCardsID"), Required]
		public int JobCardsID { get; set; }

		[DataMember]
		[Column("EOFileId")]
		public int? EOFileId { get; set; }

		[DataMember]
		[Column("OldId")]
		public int? OldId { get; set; }

		[DataMember]
		[Column("Thrust"), MaxLength(128)]
		public string Thrust { get; set; }

		[DataMember]
		[Column("BaseComponentTypeId"), Required]
		public int BaseComponentTypeId { get; set; }

		[DataMember]
		[Column("ComponentType"), Required]
		public int ComponentType { get; set; }

		[DataMember]
		[Column("ComponentLabel")]
		public int? ComponentLabel { get; set; }

		[DataMember]
		[Column("QuantityIn")]
		public int? QuantityIn { get; set; }

		[DataMember]
		[Column("ATAChapter")]
		public int? ATAChapterId { get; set; }

		[DataMember]
		[Column("PartNumber"), MaxLength(128)]
		public string PartNumber { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(250)]
		public string Description { get; set; }

		[DataMember]
		[Column("SerialNumber"), MaxLength(128)]
		public string SerialNumber { get; set; }

		[DataMember]
		[Column("BatchNumber"), MaxLength(128)]
		public string BatchNumber { get; set; }

		[DataMember]
		[Column("IdNumber"), MaxLength(128)]
		public string IdNumber { get; set; }

		[DataMember]
		[Column("MaintenanceType"), Required]
		public int MaintenanceType { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Model")]
		public int? ModelId { get; set; }

		[DataMember]
		[Column("Manufacturer"), MaxLength(128)]
		public string Manufacturer { get; set; }

		[DataMember]
		[Column("ManufactureDate")]
		public DateTime? ManufactureDate { get; set; }

		[DataMember]
		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		[Column("Lifelength"), MaxLength(21)]
		public byte[] Lifelength { get; set; }

		[DataMember]
		[Column("LLPMark"), Required]
		public bool LLPMark { get; set; }

		[DataMember]
		[Column("LLPCategories"), Required]
		public bool LLPCategories { get; set; }

		[DataMember]
		[Column("LandingGear"), Required]
		public short LandingGear { get; set; }

		[DataMember]
		[Column("AvionicsInventory"), Required]
		public short AvionicsInventory { get; set; }

		[DataMember]
		[Column("ALTPN"), MaxLength(128)]
		public string ALTPN { get; set; }

		[DataMember]
		[Column("MTOGW"), MaxLength(128)]
		public string MTOGW { get; set; }

		[DataMember]
		[Column("HushKit"), MaxLength(128)]
		public string HushKit { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("Quantity"), Required]
		public double Quantity { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("FaaFormFileID")]
		public int? FaaFormFileID { get; set; }

		[DataMember]
		[Column("Warranty"), MaxLength(21)]
		public byte[] Warranty { get; set; }

		[DataMember]
		[Column("WarrantyNotify"), MaxLength(21)]
		public byte[] WarrantyNotify { get; set; }

		[DataMember]
		[Column("Serviceable")]
		public bool? Serviceable { get; set; }

		[DataMember]
		[Column("Type")]
		public int? Type { get; set; }

		[DataMember]
		[Column("ShelfLife"), MaxLength(50)]
		public string ShelfLife { get; set; }

		[DataMember]
		[Column("ExpirationDate")]
		public DateTime? ExpirationDate { get; set; }

		[DataMember]
		[Column("NotificationDate")]
		public DateTime? NotificationDate { get; set; }

		[DataMember]
		[Column("Highlight")]
		public int? Highlight { get; set; }

		[DataMember]
		[Column("MPDItem"), MaxLength(50)]
		public string MPDItem { get; set; }

		[DataMember]
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("Supplier"), MaxLength(50)]
		public string Supplier { get; set; }

		[DataMember]
		[Column("LifeLimit"), MaxLength(21)]
		public byte[] LifeLimit { get; set; }

		[DataMember]
		[Column("LifeLimitNotify"), MaxLength(21)]
		public byte[] LifeLimitNotify { get; set; }

		[DataMember]
		[Column("KitRequired"), MaxLength(50)]
		public string KitRequired { get; set; }

		[DataMember]
		[Column("StartLifelength"), MaxLength(21)]
		public byte[] StartLifelength { get; set; }

		[DataMember]
		[Column("StartDate")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Column("Code"), MaxLength(256)]
		public string Code { get; set; }

		[DataMember]
		[Column("Status")]
		public short? Status { get; set; }

		[DataMember]
		[Column("IsBaseComponent"), Required]
		public bool IsBaseComponent { get; set; }

		[DataMember]
		[Column("LocationId"), Required]
		public int LocationId { get; set; }

		[DataMember]
		[Column("Incoming"), Required]
		public bool Incoming { get; set; }

		[DataMember]
		[Column("Discrepancy"), MaxLength(250)]
		public string Discrepancy { get; set; }

		[DataMember]
		[Column("IsPool"), Required]
		public bool IsPool { get; set; }

		[DataMember]
		[Column("IsDangerous"), Required]
		public bool IsDangerous { get; set; }

		[DataMember]
		[Column("QuantityInput")]
		public double? QuantityInput { get; set; }

		[DataMember]
		[Column("FromSupplierId"), Required]
		public int FromSupplierId { get; set; }

		[DataMember]
		[Column("Received"), Required]
		public int Received { get; set; }

		[DataMember]
		[Column("Packing")]
		public string Packing { get; set; }

		[DataMember]
		[Column("FromSupplierReciveDate")]
		public DateTime? FromSupplierReciveDate { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO Model { get; set; }

		[DataMember]
		[Child]
		public LocationDTO Location { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO FromSupplier { get; set; }

		[DataMember]
		[Child]
		public ICollection<ComponentLLPCategoryDataDTO> LLPData { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 5)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", new[] { 5, 6 })]
		public ICollection<KitSuppliersRelationDTO> SupplierRelations { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 5)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", new[] { 5, 6 })]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<ActualStateRecordDTO> ActualStateRecords { get; set; }

		[DataMember]
		[Child]
		public ICollection<TransferRecordDTO> TransferRecords { get; set; }

		[DataMember]
		[Child]
		public ICollection<ComponentDirectiveDTO> ComponentDirectives { get; set; }

		[DataMember]
		[Child]
		public ICollection<ComponentLLPCategoryChangeRecordDTO> ChangeLLPCategoryRecords { get; set; }


		#region Navigation

		[DataMember]
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }

		[DataMember]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }

		#endregion

	}
}