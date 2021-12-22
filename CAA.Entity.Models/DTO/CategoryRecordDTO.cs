using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("CategoryRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAACategoryRecordDTO : BaseEntity
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
		public CAAAccessoryDescriptionDTO AircraftModel { get; set; }



		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }

        #endregion
	}
}