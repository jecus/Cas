using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("WorkStations", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class WorkStationsDTO : BaseEntity
	{
		[Column("StoreName")]
		public string Name { get; set; }

		[Column("Location")]
		public string Location { get; set; }

		[Column("OperatorId")]
		public int OperatorId { get; set; }

		[Column("Adress")]
		public string Adress { get; set; }

		[Column("Phone")]
		public string Phone { get; set; }

		[Column("Email")]
		public string Email { get; set; }

		[Column("Contact")]
		public string Contact { get; set; }
		
		[Column("Remarks")]
		public string Remarks { get; set; }
	}
}