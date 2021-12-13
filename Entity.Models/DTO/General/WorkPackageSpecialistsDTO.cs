using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("WorkPackageSpecialists", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkPackageSpecialistsDTO : BaseEntity
	{
		
		[Column("WorkPackageId")]
		public int WorkPackageId { get; set; }

		
		[Column("SpecialistId")]
		public int SpecialistId { get; set; }
	}
}