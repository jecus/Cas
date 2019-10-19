using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Departments", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class DepartmentDTO : BaseEntity, IBaseDictionary
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
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
		[JsonIgnore]
		public ICollection<SpecializationDTO> SpecializationDtos { get; set; }
		[JsonIgnore]
		public ICollection<NomenclatureDTO> NomenclatureDtos { get; set; }
		[JsonIgnore]
		public ICollection<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		#endregion
	}
}
