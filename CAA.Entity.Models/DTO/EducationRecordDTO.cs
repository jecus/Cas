using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("EducationRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class EducationRecordsDTO : BaseEntity, IBaseDictionary
	{
		[Column("OperatorId")]
		public int OperatorId { get; set; }
		
		[Column("SpecialistId")]
		public int SpecialistId { get; set; }
		
		[Column("OccupationId")]
		public int OccupationId { get; set; }
		
		[Column("EducationId")]
		public int EducationId { get; set; }
		
		[Column("SettingsJSON")]
		public string SettingsJSON { get; set; }
	}
}
