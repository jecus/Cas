using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[JsonIgnore]
		public ComponentDTO Component { get; set; }
		[JsonIgnore]
		public DirectiveDTO Directive { get; set; }
		[JsonIgnore]
		public WorkOrderDTO WorkOrder { get; set; }
		[JsonIgnore]
		public RequestDTO RequestDto { get; set; }
		[JsonIgnore]
		public ProcedureDTO Procedure { get; set; }
		[JsonIgnore]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[JsonIgnore]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }
		[JsonIgnore]
		public JobCardDTO JobCardDto { get; set; }


		#endregion
	}
}