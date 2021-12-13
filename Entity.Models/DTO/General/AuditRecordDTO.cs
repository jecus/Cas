using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("AuditRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class AuditRecordDTO : BaseEntity
	{
		
		[Column("AuditId")]
		public int? AuditId { get; set; }

		
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		
		[Column("AuditItemTypeId")]
		public int? AuditItemTypeId { get; set; }

		
		[Column("PerfNumFromStart")]
		public int? PerfNumFromStart { get; set; }

		
		[Column("PerfNumFromRecord")]
		public int? PerfNumFromRecord { get; set; }

		
		[Column("FromRecordId")]
		public int? FromRecordId { get; set; }

		
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public AuditDTO Audit { get; set; }

		#endregion
	}
}