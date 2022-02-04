using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("Nomenclatures", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAANomenclatureDTO : BaseEntity, IBaseDictionary, IOperatable
	{
		
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

	    
	    [Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

        [Column("OperatorId")]
		public int OperatorId { get; set; }


		[Child]
	    public CAADepartmentDTO Department { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAADocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
