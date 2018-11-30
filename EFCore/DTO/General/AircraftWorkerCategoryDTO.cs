using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftWorkerCategoryDTO : BaseEntity
	{
		[DataMember]
		public string Category { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		[DataMember]
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

		#endregion
	}
}