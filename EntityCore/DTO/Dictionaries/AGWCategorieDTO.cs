using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AGWCategories", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AGWCategorieDTO : BaseEntity
	{
		[DataMember]
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		[DataMember]
		[Column("Gender")]
		public short? Gender { get; set; }

		[DataMember]
		[Column("MinAge")]
		public int? MinAge { get; set; }

		[DataMember]
		[Column("MaxAge")]
		public int? MaxAge { get; set; }

		[DataMember]
		[Column("WeightSummer")]
		public int? WeightSummer { get; set; }

		[DataMember]
		[Column("WeightWinter")]
		public int? WeightWinter { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<FlightPassengerRecordDTO> FlightPassengerRecordDtos { get; set; }
		[DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion

	}
}
