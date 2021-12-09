using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.DTO;

namespace Entity.Models.DTO.General
{
	[Table("CorrectiveActions", Schema = "dbo")]
	
	public class CorrectiveActionDTO : BaseEntity
	{
		
		[Column("DiscrepancyID")]
		public int DiscrepancyID { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("ShortDescription")]
		public string ShortDescription { get; set; }

		
		[Column("ADDNo")]
		public string ADDNo { get; set; }

		
		[Column("IsClosed")]
		public bool IsClosed { get; set; }

		
		[Column("PartNumberOff"), MaxLength(50)]
		public string PartNumberOff { get; set; }

		
		[Column("SerialNumberOff"), MaxLength(50)]
		public string SerialNumberOff { get; set; }

		
		[Column("PartNumberOn"), MaxLength(50)]
		public string PartNumberOn { get; set; }

		
		[Column("SerialNumberOn"), MaxLength(50)]
		public string SerialNumberOn { get; set; }

		
		[Column("CRSID")]
		public int CRSID { get; set; }
	}
}