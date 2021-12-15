using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
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

		[JsonIgnore]
		public RequestDTO RequestDto { get; set; }

		#endregion
	}
}