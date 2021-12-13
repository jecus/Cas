using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[JsonIgnore]
		public ComponentDTO Component{ get; set; }
		[JsonIgnore]
		public DirectiveDTO Directive{ get; set; }
		[JsonIgnore]
		public SpecialistDTO SpecialistDto { get; set; }
		[JsonIgnore]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[JsonIgnore]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}