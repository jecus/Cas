using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("Cas3MaintenanceCheck", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		[DataMember]
		[Column("Interval")]
		public byte[] Interval { get; set; }

		[DataMember]
		[Column("Notify")]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("ParentAircraft"), Required]
		public int ParentAircraft { get; set; }

		[DataMember]
		[Column("CheckTypeId")]
		public int? CheckTypeId { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Schedule")]
		public bool? Schedule { get; set; }

		[DataMember]
		[Column("Resource"), Required]
		public short Resource { get; set; }

		[DataMember]
		[Column("Grouping"), Required]
		public bool Grouping { get; set; }

		[DataMember]
		[Include]
		public MaintenanceCheckTypeDTO CheckType { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 3)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<MaintenanceDirectiveDTO> BindMpds { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }

		#endregion
	}
}