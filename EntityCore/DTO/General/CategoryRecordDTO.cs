using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("CategoryRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class CategoryRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("EmployeeId")]
		public int? EmployeeId { get; set; }

		[DataMember]
		[Column("AircraftWorkerCategoryId")]
		public int? AircraftWorkerCategoryId { get; set; }

		[DataMember]
		[Column("AircraftTypeId")]
		public int? AircraftTypeId { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
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