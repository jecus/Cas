using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
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