using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class TransferRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int ParentID { get; set; }

		[DataMember]
		public int? ParentType { get; set; }

		[DataMember]
		public int FromAircraftID { get; set; }

		[DataMember]
		public int FromStoreID { get; set; }

		[DataMember]
		public int? DestinationObjectID { get; set; }

		[DataMember]
		public int? DestinationObjectType { get; set; }

		[DataMember]
		public int? ConsumableId { get; set; }

		[DataMember]
		public DateTime? TransferDate { get; set; }

		[DataMember]
		public DateTime? DestConfirmTransferDate { get; set; }

		[DataMember]
		public int? WorkPackageID { get; set; }

		[DataMember]
		public int PerformanceNum { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public bool? PODR { get; set; }

		[DataMember]
		public bool? DODR { get; set; }

		[DataMember]
		public bool? PreConfirmTransfer { get; set; }

		[DataMember]
		public string Position { get; set; }

		[DataMember]
		public int FromBaseComponentID { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int ReasonId { get; set; }

		[DataMember]
		public int? State { get; set; }

		[DataMember]
		public int ReplaceComponentId { get; set; }

		[DataMember]
		public bool IsReplaceComponentRemoved { get; set; }

		[DataMember]
		public int? ReceivedSpecialistId { get; set; }

		[DataMember]
		public int? ReleasedSpecialistId { get; set; }

		[DataMember]
		public int FromSupplierId { get; set; }

		[DataMember]
		public DateTime? SupplierReceiptDate { get; set; }

		[DataMember]
		public byte[] SupplierNotify { get; set; }

		[DataMember]
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