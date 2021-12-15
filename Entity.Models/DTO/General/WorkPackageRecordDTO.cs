using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("Cas3WorkPakageRecord", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkPackageRecordDTO : BaseEntity
	{
		
		[Column("WorkPakageId")]
		public int WorkPakageId { get; set; }

		
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		
		[Column("WorkPackageItemType")]
		public int? WorkPackageItemType { get; set; }

		
		[Column("PerfNumFromStart")]
		public int? PerfNumFromStart { get; set; }

		
		[Column("PerfNumFromRecord")]
		public int? PerfNumFromRecord { get; set; }

		
		[Column("FromRecordId")]
		public int? FromRecordId { get; set; }

		
		[Column("GroupNumber")]
		public int? Group { get; set; }

		
		[Column("ParentCheckId")]
		public int? ParentCheckId { get; set; }

		
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }

		[Column("IsClosed")]
		public bool IsClosed { get; set; }
	}
}