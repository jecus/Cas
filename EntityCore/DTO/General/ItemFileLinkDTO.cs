using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("ItemsFilesLinks", Schema = "dbo")]
	
	public class ItemFileLinkDTO : BaseEntity
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int ParentTypeId { get; set; }

		
		[Column("LinkType")]
		public short LinkType { get; set; }

		
		[Column("FileId")]
		public int? FileId { get; set; }

		
		[Child]
		public AttachedFileDTO File { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public AircraftFlightDTO AircraftFlight { get; set; }
		[JsonIgnore]
		public ATLBDTO Atlb { get; set; }
		[JsonIgnore]
		public AuditDTO Audit { get; set; }
		[JsonIgnore]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[JsonIgnore]
		public ComponentDTO Component{ get; set; }
		[JsonIgnore]
		public DamageChartDTO DamageChart { get; set; }
		[JsonIgnore]
		public ComponentLLPCategoryChangeRecordDTO CategoryChangeRecord { get; set; }
		[JsonIgnore]
		public DamageDocumentDTO DamageDocument { get; set; }
		[JsonIgnore]
		public DirectiveDTO Directive { get; set; }
		[JsonIgnore]
		public DirectiveRecordDTO DirectiveRecord { get; set; }
		[JsonIgnore]
		public DirectiveRecordDTO MaintenanceCheckRecord { get; set; }
		[JsonIgnore]
		public WorkPackageDTO WorkPackage { get; set; }
		[JsonIgnore]
		public TransferRecordDTO TransferRecord { get; set; }
		[JsonIgnore]
		public SupplierDocumentDTO SupplierDocument { get; set; }
		[JsonIgnore]
		public SpecialistTrainingDTO SpecialistTraining { get; set; }
		[JsonIgnore]
		public SpecialistDTO SpecialistDto { get; set; }
		[JsonIgnore]
		public RequestForQuotationDTO RequestForQuotation { get; set; }
		[JsonIgnore]
		public PurchaseRequestRecordDTO PurchaseRequestRecord { get; set; }
		[JsonIgnore]
		public PurchaseOrderDTO PurchaseOrder { get; set; }
		[JsonIgnore]
		public ProcedureDTO Procedure { get; set; }
		[JsonIgnore]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[JsonIgnore]
		public InitialOrderDTO InitialOrderDto { get; set; }

		#endregion
	}
}