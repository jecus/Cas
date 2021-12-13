using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("Stores", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class StoreDTO : BaseEntity
	{
		
		[Column("OperatorID")]
		public int OperatorID { get; set; }

		
		[Column("StoreName"), MaxLength(75)]
		public string StoreName { get; set; }

		
		[Column("Adress")]
		public string Adress { get; set; }

		
		[Column("Phone"), MaxLength(256)]
		public string Phone { get; set; }

		
		[Column("Email"), MaxLength(256)]
		public string Email { get; set; }

		
		[Column("Contact"), MaxLength(256)]
		public string Contact { get; set; }

		
		[Column("Location"), MaxLength(75)]
		public string Location { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("Code"), MaxLength(256)]
		public string Code { get; set; }
	}
}