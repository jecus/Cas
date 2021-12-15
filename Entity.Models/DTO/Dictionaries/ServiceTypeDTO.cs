using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Models.DTO.General;
using Newtonsoft.Json;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("ServiceTypes", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class ServiceTypeDTO : BaseEntity, IBaseDictionary
	{

		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

		#endregion
	}
}
