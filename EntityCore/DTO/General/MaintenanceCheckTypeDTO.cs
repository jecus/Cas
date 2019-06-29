using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("Cas3MaintenanceCheckType", Schema = "dbo")]
	
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