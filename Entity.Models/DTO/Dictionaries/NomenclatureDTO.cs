using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.Dictionaries
{
	[Table("Nomenclatures", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class NomenclatureDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

	    
	    [Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

	    
		[Child]
	    public DepartmentDTO Department { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
