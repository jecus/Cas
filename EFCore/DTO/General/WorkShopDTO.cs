using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("WorkShops", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkShopDTO : BaseEntity
	{
		[DataMember]
		[Column("StoreName"), MaxLength(256)]
		public string StoreName { get; set; }

		[DataMember]
		[Column("Location"), MaxLength(256)]
		public string Location { get; set; }

		[DataMember]
		[Column("OperatorId")]
		public int? OperatorId { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(256)]
		public string Remarks { get; set; }
	}
}