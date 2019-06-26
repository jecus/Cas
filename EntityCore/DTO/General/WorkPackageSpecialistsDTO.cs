using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("WorkPackageSpecialists", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkPackageSpecialistsDTO : BaseEntity
	{
		
		[Column("WorkPackageId"), Required]
		public int WorkPackageId { get; set; }

		
		[Column("SpecialistId"), Required]
		public int SpecialistId { get; set; }
	}
}