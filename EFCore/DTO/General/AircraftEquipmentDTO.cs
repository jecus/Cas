using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("AircraftEquipments", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftEquipmentDTO : BaseEntity
	{
		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		[DataMember]
		[Column("AircraftId")]
		public int AircraftId { get; set; }

		[DataMember]
		[Column("AircraftOtherParameter")]
		public int? AircraftOtherParameterId { get; set; }

		[DataMember]
		[Column("AircraftEquipmetType")]
		public int AircraftEquipmetType { get; set; }


		[DataMember]
		[Child]
		public AircraftOtherParameterDTO AircraftOtherParameter { get; set; }
	}
}