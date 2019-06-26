using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("RequestRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class RequestRecordDTO : BaseEntity
	{
		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		#region Navigation Property

		
		public RequestDTO RequestDto { get; set; }

		#endregion
	}
}