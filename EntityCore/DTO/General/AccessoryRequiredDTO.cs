using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("Kits", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AccessoryRequiredDTO : BaseEntity
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("IsNonRoutineKit")]
		public bool? IsNonRoutineKit { get; set; }

		
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		
		[Column("PartNumber"), MaxLength(100)]
		public string PartNumber { get; set; }

		
		[Column("Description"), MaxLength(200)]
		public string Description { get; set; }

		
		[Column("Manufacturer"), MaxLength(100)]
		public string Manufacturer { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("Quantity")]
		public double? Quantity { get; set; }

		
		[Column("CostNew")]
		public double? CostNew { get; set; }

		
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("AccessoryDescriptionId")]
		public int? AccessoryDescriptionId { get; set; }

		
		[Column("GoodStandartId")]
		public int? GoodStandartId { get; set; }

		
		[Child]
		public AccessoryDescriptionDTO Product { get; set; }

		
		[Child]
		public GoodStandartDTO Standart { get; set; }

		#region Navigation Property

		
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		
		public ComponentDTO Component { get; set; }
		
		public DirectiveDTO Directive { get; set; }
		
		public WorkOrderDTO WorkOrder { get; set; }
		
		public RequestDTO RequestDto { get; set; }
		
		public ProcedureDTO Procedure { get; set; }
		
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }
		
		public JobCardDTO JobCardDto { get; set; }


		#endregion
	}
}