using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("MTOPCheck", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MTOPCheckDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(150)]
		public string Name { get; set; }

		[DataMember]
		[Column("ParentAircraftId"), Required]
		public int ParentAircraftId { get; set; }

		[DataMember]
		[Column("CheckTypeId"), Required]
		public int CheckTypeId { get; set; }

		[DataMember]
		[Column("Thresh")]
		public byte[] Thresh { get; set; }

		[DataMember]
		[Column("Repeat")]
		public byte[] Repeat { get; set; }

		[DataMember]
		[Column("Notify")]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("IsZeroPhase")]
		public bool IsZeroPhase { get; set; }

		[DataMember]
		[Include]
		public MaintenanceCheckTypeDTO CheckType { get; set; }

		[DataMember]
		[Child]
		public ICollection<MTOPCheckRecordDTO> PerformanceRecords { get; set; }
	}
}