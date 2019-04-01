using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MTOPCheckDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int ParentAircraftId { get; set; }

		[DataMember]
		public int CheckTypeId { get; set; }

		[DataMember]
		public byte[] Thresh { get; set; }

		[DataMember]
		public byte[] Repeat { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public bool IsZeroPhase { get; set; }

		[DataMember]
		[Include]
		public MaintenanceCheckTypeDTO CheckType { get; set; }

		[DataMember]
		[Child]
		public ICollection<MTOPCheckRecordDTO> PerformanceRecords { get; set; }
	}
}