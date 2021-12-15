using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("WorkShops", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkShopDTO : BaseEntity
	{
		
		[Column("StoreName"), MaxLength(256)]
		public string StoreName { get; set; }

		
		[Column("Location"), MaxLength(256)]
		public string Location { get; set; }

		
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }
	}
}