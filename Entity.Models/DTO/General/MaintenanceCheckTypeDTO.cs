using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("Cas3MaintenanceCheckType", Schema = "dbo")]
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckTypeDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("Priority")]
		public int? Priority { get; set; }

		
		[Column("ShortName"), MaxLength(50)]
		public string ShortName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<MTOPCheckDTO> MtopCheckDtos { get; set; }
		[JsonIgnore]
		public ICollection<MaintenanceCheckDTO> MaintenanceCheckDtos { get; set; }

		#endregion
	}
}