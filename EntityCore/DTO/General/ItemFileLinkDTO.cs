using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("ItemsFilesLinks", Schema = "dbo")]
	
	public class ItemFileLinkDTO : BaseEntity
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId"), Required]
		public int ParentTypeId { get; set; }

		
		[Column("LinkType"), Required]
		public short LinkType { get; set; }

		
		[Column("FileId")]
		public int? FileId { get; set; }

		
		[Child]
		public AttachedFileDTO File { get; set; }


		#region Navigation Property

		
		public AircraftFlightDTO AircraftFlight { get; set; }
		
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }
		
		public ATLBDTO Atlb { get; set; }
		
		public AuditDTO Audit { get; set; }
		
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		
		public ComponentDTO Component{ get; set; }
		
		public DamageChartDTO DamageChart { get; set; }
		
		public ComponentLLPCategoryChangeRecordDTO CategoryChangeRecord { get; set; }
		
		public DamageDocumentDTO DamageDocument { get; set; }
		
		public DirectiveDTO Directive { get; set; }
		
		public DirectiveRecordDTO DirectiveRecord { get; set; }
		
		public DirectiveRecordDTO MaintenanceCheckRecord { get; set; }
		
		public WorkPackageDTO WorkPackage { get; set; }
		
		public TransferRecordDTO TransferRecord { get; set; }
		
		public SupplierDocumentDTO SupplierDocument { get; set; }
		
		public SpecialistTrainingDTO SpecialistTraining { get; set; }
		
		public SpecialistDTO SpecialistDto { get; set; }
		
		public RequestForQuotationDTO RequestForQuotation { get; set; }
		
		public PurchaseRequestRecordDTO PurchaseRequestRecord { get; set; }
		
		public PurchaseOrderDTO PurchaseOrder { get; set; }
		
		public ProcedureDTO Procedure { get; set; }
		
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		
		public InitialOrderDTO InitialOrderDto { get; set; }

		#endregion
	}
}