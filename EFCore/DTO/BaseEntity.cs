using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Interfaces;

namespace EFCore.DTO
{
	[DataContract(IsReference = true)]
	public class BaseEntity : IBaseEntity
	{
		[DataMember]
		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }

		[DataMember]
		[Column("ItemId")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int ItemId { get; set; }

		[DataMember]
		[Column("CorrectorId")]
		public int CorrectorId { get; set; }
	}
}