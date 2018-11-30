using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public byte[] Interval { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public int ParentAircraft { get; set; }

		[DataMember]
		public int CheckTypeId { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public bool? Schedule { get; set; }

		[DataMember]
		public short Resource { get; set; }

		[DataMember]
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