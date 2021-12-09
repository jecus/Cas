using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.Interfaces;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("TransferRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class TransferRecordDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("ParentID")]
		public int? ParentID { get; set; }

		
		[Column("ParentType")]
		public int? ParentType { get; set; }

		
		[Column("FromAircraftID")]
		public int FromAircraftID { get; set; }

		
		[Column("FromStoreID")]
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

		
		[Column("PerformanceNum")]
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

		
		[Column("ReasonId")]
		public int ReasonId { get; set; }

		
		[Column("State")]
		public int? State { get; set; }

		
		[Column("ReplaceComponentId")]
		public int ReplaceComponentId { get; set; }

		
		[Column("IsReplaceComponentRemoved")]
		public bool IsReplaceComponentRemoved { get; set; }

		
		[Column("ReceivedSpecialistId")]
		public int? ReceivedSpecialistId { get; set; }

		
		[Column("ReleasedSpecialistId")]
		public int? ReleasedSpecialistId { get; set; }

		
		[Column("FromSupplierId")]
		public int FromSupplierId { get; set; }

		
		[Column("SupplierReceiptDate")]
		public DateTime? SupplierReceiptDate { get; set; }

		
		[Column("SupplierNotify"), MaxLength(21)]
		public byte[] SupplierNotify { get; set; }

		
		[Column("FromSpecialistId")]
		public int FromSpecialistId { get; set; }

		
		[Child]
		public SpecialistDTO ReceivedSpecialist { get; set; }

		
		[Child]
		public SpecialistDTO ReleasedSpecialist { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 2260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ComponentDTO Component { get; set; }

		#endregion
	}
}