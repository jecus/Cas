using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[Table("TransferRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class TransferRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("ParentID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Column("ParentType")]
		public int? ParentType { get; set; }

		[DataMember]
		[Column("FromAircraftID"), Required]
		public int FromAircraftID { get; set; }

		[DataMember]
		[Column("FromStoreID"), Required]
		public int FromStoreID { get; set; }

		[DataMember]
		[Column("DestinationObjectID")]
		public int? DestinationObjectID { get; set; }

		[DataMember]
		[Column("DestinationObjectType")]
		public int? DestinationObjectType { get; set; }

		[DataMember]
		[Column("ConsumableId")]
		public int? ConsumableId { get; set; }

		[DataMember]
		[Column("TransferDate")]
		public DateTime? TransferDate { get; set; }

		[DataMember]
		[Column("DestConfirmTransferDate")]
		public DateTime? DestConfirmTransferDate { get; set; }

		[DataMember]
		[Column("WorkPackageID")]
		public int? WorkPackageID { get; set; }

		[DataMember]
		[Column("PerformanceNum"), Required]
		public int PerformanceNum { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Reference"), MaxLength(50)]
		public string Reference { get; set; }

		[DataMember]
		[Column("PODR")]
		public bool? PODR { get; set; }

		[DataMember]
		[Column("DODR")]
		public bool? DODR { get; set; }

		[DataMember]
		[Column("PreConfirmTransfer")]
		public bool? PreConfirmTransfer { get; set; }

		[DataMember]
		[Column("Position")]
		public string Position { get; set; }

		[DataMember]
		[Column("FromBaseComponentID")]
		public int FromBaseComponentID { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(250)]
		public string Description { get; set; }

		[DataMember]
		[Column("ReasonId"), Required]
		public int ReasonId { get; set; }

		[DataMember]
		[Column("State")]
		public int? State { get; set; }

		[DataMember]
		[Column("ReplaceComponentId"), Required]
		public int ReplaceComponentId { get; set; }

		[DataMember]
		[Column("IsReplaceComponentRemoved"), Required]
		public bool IsReplaceComponentRemoved { get; set; }

		[DataMember]
		[Column("ReceivedSpecialistId")]
		public int? ReceivedSpecialistId { get; set; }

		[DataMember]
		[Column("ReleasedSpecialistId")]
		public int? ReleasedSpecialistId { get; set; }

		[DataMember]
		[Column("FromSupplierId"), Required]
		public int FromSupplierId { get; set; }

		[DataMember]
		[Column("SupplierReceiptDate")]
		public DateTime? SupplierReceiptDate { get; set; }

		[DataMember]
		[Column("SupplierNotify"), MaxLength(21)]
		public byte[] SupplierNotify { get; set; }

		[DataMember]
		[Column("FromSpecialistId"), Required]
		public int FromSpecialistId { get; set; }

		[DataMember]
		[Child]
		public SpecialistDTO ReceivedSpecialist { get; set; }

		[DataMember]
		[Child]
		public SpecialistDTO ReleasedSpecialist { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 2260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}