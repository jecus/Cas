using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AGWCategorieDTO : BaseEntity
	{
		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public short? Gender { get; set; }

		[DataMember]
		public int? MinAge { get; set; }

		[DataMember]
		public int? MaxAge { get; set; }

		[DataMember]
		public int? WeightSummer { get; set; }

		[DataMember]
		public int? WeightWinter { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<FlightPassengerRecordDTO> FlightPassengerRecordDtos { get; set; }
		[DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion

	}
}
