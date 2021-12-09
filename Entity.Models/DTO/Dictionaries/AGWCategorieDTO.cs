using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;
using FlightPassengerRecordDTO = Entity.Models.DTO.General.FlightPassengerRecordDTO;
using SpecialistDTO = Entity.Models.DTO.General.SpecialistDTO;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("AGWCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class AGWCategorieDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		
		[Column("Gender")]
		public short? Gender { get; set; }

		
		[Column("MinAge")]
		public int? MinAge { get; set; }

		
		[Column("MaxAge")]
		public int? MaxAge { get; set; }

		
		[Column("WeightSummer")]
		public int? WeightSummer { get; set; }

		
		[Column("WeightWinter")]
		public int? WeightWinter { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<FlightPassengerRecordDTO> FlightPassengerRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion

	}
}
