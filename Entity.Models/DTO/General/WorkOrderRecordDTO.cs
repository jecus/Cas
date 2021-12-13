using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("WorkOrderRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class WorkOrderRecordDTO : BaseEntity
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public WorkOrderDTO WorkOrder { get; set; }

		#endregion
	}
}