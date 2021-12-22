using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("Departments", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAADepartmentDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }
		
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		[Column("Address"), MaxLength(256)]
		public string Address { get; set; }

		[Column("Phone"), MaxLength(256)]
		public string Phone { get; set; }

		[Column("Fax"), MaxLength(256)]
		public string Fax { get; set; }

		[Column("Email"), MaxLength(256)]
		public string Email { get; set; }

		[Column("Website"), MaxLength(256)]
		public string Website { get; set; }



		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAADocumentDTO> DocumentDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAASpecializationDTO> SpecializationDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAANomenclatureDTO> NomenclatureDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAALocationsTypeDTO> LocationsTypeDtos { get; set; }
		#endregion
	}
}
