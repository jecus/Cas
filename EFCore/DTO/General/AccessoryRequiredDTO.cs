using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("Kits", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AccessoryRequiredDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("IsNonRoutineKit")]
		public bool? IsNonRoutineKit { get; set; }

		[DataMember]
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		[DataMember]
		[Column("PartNumber"), MaxLength(100)]
		public string PartNumber { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(200)]
		public string Description { get; set; }

		[DataMember]
		[Column("Manufacturer"), MaxLength(100)]
		public string Manufacturer { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("Quantity")]
		public double? Quantity { get; set; }

		[DataMember]
		[Column("CostNew")]
		public double? CostNew { get; set; }

		[DataMember]
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("AccessoryDescriptionId")]
		public int? AccessoryDescriptionId { get; set; }

		[DataMember]
		[Column("GoodStandartId")]
		public int? GoodStandartId { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO Product { get; set; }

		[DataMember]
		[Child]
		public GoodStandartDTO Standart { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[DataMember]
		public ComponentDTO Component { get; set; }
		[DataMember]
		public DirectiveDTO Directive { get; set; }
		[DataMember]
		public WorkOrderDTO WorkOrder { get; set; }
		[DataMember]
		public RequestDTO RequestDto { get; set; }
		[DataMember]
		public ProcedureDTO Procedure { get; set; }
		[DataMember]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[DataMember]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }
		[DataMember]
		public JobCardDTO JobCardDto { get; set; }


		#endregion
	}
}