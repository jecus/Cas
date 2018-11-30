using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftEquipmentDTO : BaseEntity
	{
		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int AircraftId { get; set; }

		[DataMember]
		public int? AircraftOtherParameterId { get; set; }

		[DataMember]
		public int AircraftEquipmetType { get; set; }


		[DataMember]
		[Child]
		public AircraftOtherParameterDTO AircraftOtherParameter { get; set; }
	}
}