using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Hangars", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class HangarDTO : BaseEntity
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