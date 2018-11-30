using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AccessoryRequiredDTO : BaseEntity
	{
		[DataMember]
		public int ParentId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public bool? IsNonRoutineKit { get; set; }

		[DataMember]
		public int? AircraftModelId { get; set; }

		[DataMember]
		public string PartNumber { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Manufacturer { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public double? Quantity { get; set; }

		[DataMember]
		public double? CostNew { get; set; }

		[DataMember]
		public double? CostServiceable { get; set; }

		[DataMember]
		public double? CostOverhaul { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? AccessoryDescriptionId { get; set; }

		[DataMember]
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