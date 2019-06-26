using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("TransferRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class TransferRecordDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("ParentID")]
		public int? ParentID { get; set; }

		
		[Column("ParentType")]
		public int? ParentType { get; set; }

		
		[Column("FromAircraftID"), Required]
		public int FromAircraftID { get; set; }

		
		[Column("FromStoreID"), Required]
		public int FromStoreID { get; set; }

		
		[Column("DestinationObjectID")]
		public int? DestinationObjectID { get; set; }

		
		[Column("DestinationObjectType")]
		public int? DestinationObjectType { get; set; }

		
		[Column("ConsumableId")]
		public int? ConsumableId { get; set; }

		
		[Column("TransferDate")]
		public DateTime? TransferDate { get; set; }

		
		[Column("DestConfirmTransferDate")]
		public DateTime? DestConfirmTransferDate { get; set; }

		
		[Column("WorkPackageID")]
		public int? WorkPackageID { get; set; }

		
		[Column("PerformanceNum"), Required]
		public int PerformanceNum { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("Reference"), MaxLength(50)]
		public string Reference { get; set; }

		
		[Column("PODR")]
		public bool? PODR { get; set; }

		
		[Column("DODR")]
		public bool? DODR { get; set; }

		
		[Column("PreConfirmTransfer")]
		public bool? PreConfirmTransfer { get; set; }

		
		[Column("Position")]
		public string Position { get; set; }

		
		[Column("FromBaseComponentID")]
		public int FromBaseComponentID { get; set; }

		
		[Column("Description"), MaxLength(250)]
		public string Description { get; set; }

		
		[Column("ReasonId"), Required]
		public int ReasonId { get; set; }

		
		[Column("State")]
		public int? State { get; set; }

		
		[Column("ReplaceComponentId"), Required]
		public int ReplaceComponentId { get; set; }

		
		[Column("IsReplaceComponentRemoved"), Required]
		public bool IsReplaceComponentRemoved { get; set; }

		
		[Column("ReceivedSpecialistId")]
		public int? ReceivedSpecialistId { get; set; }

		
		[Column("ReleasedSpecialistId")]
		public int? ReleasedSpecialistId { get; set; }

		
		[Column("FromSupplierId"), Required]
		public int FromSupplierId { get; set; }

		
		[Column("SupplierReceiptDate")]
		public DateTime? SupplierReceiptDate { get; set; }

		
		[Column("SupplierNotify"), MaxLength(21)]
		public byte[] SupplierNotify { get; set; }

		
		[Column("FromSpecialistId"), Required]
		public int FromSpecialistId { get; set; }

		
		[Child]
		public SpecialistDTO ReceivedSpecialist { get; set; }

		
		[Child]
		public SpecialistDTO ReleasedSpecialist { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		
		public ComponentDTO Component { get; set; }

		#endregion
	}
}