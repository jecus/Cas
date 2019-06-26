using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("CategoryRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CategoryRecordDTO : BaseEntity
	{
		
		[Column("EmployeeId")]
		public int? EmployeeId { get; set; }

		
		[Column("AircraftWorkerCategoryId")]
		public int? AircraftWorkerCategoryId { get; set; }

		
		[Column("AircraftTypeId")]
		public int? AircraftTypeId { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Child]
		public AccessoryDescriptionDTO AircraftModel { get; set; }

		
		[Child]
		public AircraftWorkerCategoryDTO AircraftWorkerCategory { get; set; }


		#region Navigation Property

		
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		
		public ComponentDTO Component{ get; set; }
		
		public DirectiveDTO Directive{ get; set; }
		
		public SpecialistDTO SpecialistDto { get; set; }
		
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}