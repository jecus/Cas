using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("AircraftEquipments", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAAAircraftEquipmentDTO : BaseEntity
	{
		
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		
		[Column("AircraftId")]
		public int AircraftId { get; set; }

		
		[Column("AircraftOtherParameter")]
		public int? AircraftOtherParameterId { get; set; }

		
		[Column("AircraftEquipmetType")]
		public int AircraftEquipmetType { get; set; }


		
		[Child]
		public CAAAircraftOtherParameterDTO AircraftOtherParameter { get; set; }
	}
}