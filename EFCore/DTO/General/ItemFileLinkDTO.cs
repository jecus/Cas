using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("ItemsFilesLinks", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class ItemFileLinkDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("ParentTypeId"), Required]
		public int ParentTypeId { get; set; }

		[DataMember]
		[Column("LinkType"), Required]
		public short LinkType { get; set; }

		[DataMember]
		[Column("FileId")]
		public int? FileId { get; set; }

		[DataMember]
		[Child]
		public AttachedFileDTO File { get; set; }


		#region Navigation Property

		[DataMember]
		public AircraftFlightDTO AircraftFlight { get; set; }
		[DataMember]
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }
		[DataMember]
		public ATLBDTO Atlb { get; set; }
		[DataMember]
		public AuditDTO Audit { get; set; }
		[DataMember]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[DataMember]
		public ComponentDTO Component{ get; set; }
		[DataMember]
		public DamageChartDTO DamageChart { get; set; }
		[DataMember]
		public ComponentLLPCategoryChangeRecordDTO CategoryChangeRecord { get; set; }
		[DataMember]
		public DamageDocumentDTO DamageDocument { get; set; }
		[DataMember]
		public DirectiveDTO Directive { get; set; }
		[DataMember]
		public DirectiveRecordDTO DirectiveRecord { get; set; }
		[DataMember]
		public DirectiveRecordDTO MaintenanceCheckRecord { get; set; }
		[DataMember]
		public WorkPackageDTO WorkPackage { get; set; }
		[DataMember]
		public TransferRecordDTO TransferRecord { get; set; }
		[DataMember]
		public SupplierDocumentDTO SupplierDocument { get; set; }
		[DataMember]
		public SpecialistTrainingDTO SpecialistTraining { get; set; }
		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }
		[DataMember]
		public RequestForQuotationDTO RequestForQuotation { get; set; }
		[DataMember]
		public PurchaseRequestRecordDTO PurchaseRequestRecord { get; set; }
		[DataMember]
		public PurchaseOrderDTO PurchaseOrder { get; set; }
		[DataMember]
		public ProcedureDTO Procedure { get; set; }
		[DataMember]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[DataMember]
		public InitialOrderDTO InitialOrderDto { get; set; }

		#endregion
	}
}