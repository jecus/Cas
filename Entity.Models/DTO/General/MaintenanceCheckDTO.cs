using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("Cas3MaintenanceCheck", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckDTO : BaseEntity
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("Interval")]
		public byte[] Interval { get; set; }

		
		[Column("Notify")]
		public byte[] Notify { get; set; }

		
		[Column("ParentAircraft")]
		public int ParentAircraft { get; set; }

		
		[Column("CheckTypeId")]
		public int? CheckTypeId { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Schedule")]
		public bool? Schedule { get; set; }

		
		[Column("Resource")]
		public short Resource { get; set; }

		
		[Column("Grouping")]
		public bool Grouping { get; set; }

		
		[Include]
		public MaintenanceCheckTypeDTO CheckType { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		
		//[Child]
		//public ICollection<MaintenanceDirectiveDTO> BindMpds { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }

		#endregion
	}
}