using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("AGWCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAAAGWCategorieDTO : BaseEntity, IBaseDictionary
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
		public ICollection<CAASpecialistDTO> SpecialistDtos { get; set; }

		#endregion

	}
}
