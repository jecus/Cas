using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ComponentDTO : BaseEntity,IFileDtoContainer
	{
		[DataMember]
		public int ComponentCount { get; set; }

		[DataMember]
		public byte[] AverageUtilization { get; set; }

		[DataMember]
		public int? Acceleration { get; set; }

		[DataMember]
		public int? AccelerationAir { get; set; }

		[DataMember]
		public int JobCardsID { get; set; }

		[DataMember]
		public int? EOFileId { get; set; }

		[DataMember]
		public int? OldId { get; set; }

		[DataMember]
		public string Thrust { get; set; }

		[DataMember]
		public int BaseComponentTypeId { get; set; }

		[DataMember]
		public int ComponentType { get; set; }

		[DataMember]
		public int? ComponentLabel { get; set; }

		[DataMember]
		public int? QuantityIn { get; set; }

		[DataMember]
		public int? ATAChapterId { get; set; }

		[DataMember]
		public string PartNumber { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string SerialNumber { get; set; }

		[DataMember]
		public string BatchNumber { get; set; }

		[DataMember]
		public string IdNumber { get; set; }

		[DataMember]
		public int MaintenanceType { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? ModelId { get; set; }

		[DataMember]
		public string Manufacturer { get; set; }

		[DataMember]
		public DateTime? ManufactureDate { get; set; }

		[DataMember]
		public DateTime? DeliveryDate { get; set; }

		[DataMember]
		public byte[] Lifelength { get; set; }

		[DataMember]
		public bool LLPMark { get; set; }

		[DataMember]
		public bool LLPCategories { get; set; }

		[DataMember]
		public short LandingGear { get; set; }

		[DataMember]
		public short AvionicsInventory { get; set; }

		[DataMember]
		public string ALTPN { get; set; }

		[DataMember]
		public string MTOGW { get; set; }

		[DataMember]
		public string HushKit { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public double? CostServiceable { get; set; }

		[DataMember]
		public double? CostOverhaul { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public double Quantity { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public int? FaaFormFileID { get; set; }

		[DataMember]
		public byte[] Warranty { get; set; }

		[DataMember]
		public byte[] WarrantyNotify { get; set; }

		[DataMember]
		public bool? Serviceable { get; set; }

		[DataMember]
		public int? Type { get; set; }

		[DataMember]
		public string ShelfLife { get; set; }

		[DataMember]
		public DateTime? ExpirationDate { get; set; }

		[DataMember]
		public DateTime? NotificationDate { get; set; }

		[DataMember]
		public int? Highlight { get; set; }

		[DataMember]
		public string MPDItem { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public string Supplier { get; set; }

		[DataMember]
		public byte[] LifeLimit { get; set; }

		[DataMember]
		public byte[] LifeLimitNotify { get; set; }

		[DataMember]
		public string KitRequired { get; set; }

		[DataMember]
		public byte[] StartLifelength { get; set; }

		[DataMember]
		public DateTime? StartDate { get; set; }

		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public short? Status { get; set; }

		[DataMember]
		public bool IsBaseComponent { get; set; }

		[DataMember]
		public int LocationId { get; set; }

		[DataMember]
		public bool Incoming { get; set; }

		[DataMember]
		public string Discrepancy { get; set; }

		[DataMember]
		public bool IsPool { get; set; }

		[DataMember]
		public bool IsDangerous { get; set; }

		[DataMember]
		public double? QuantityInput { get; set; }

		[DataMember]
		public int FromSupplierId { get; set; }

		[DataMember]
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