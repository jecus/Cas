using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class CategoryRecordDTO : BaseEntity
	{
		[DataMember]
		public int? EmployeeId { get; set; }

		[DataMember]
		public int? AircraftWorkerCategoryId { get; set; }

		[DataMember]
		public int? AircraftTypeId { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Child]
		public AccessoryDescriptionDTO AircraftModel { get; set; }

		[DataMember]
		[Child]
		public AircraftWorkerCategoryDTO AircraftWorkerCategory { get; set; }


		#region Navigation Property

		[DataMember]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[DataMember]
		public ComponentDTO Component{ get; set; }
		[DataMember]
		public DirectiveDTO Directive{ get; set; }
		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }
		[DataMember]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[DataMember]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}