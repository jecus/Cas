using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("AircraftEquipments", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AircraftEquipmentDTO : BaseEntity
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
		public AircraftOtherParameterDTO AircraftOtherParameter { get; set; }
	}
}