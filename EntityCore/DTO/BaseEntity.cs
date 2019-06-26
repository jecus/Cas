using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Interfaces;

namespace EntityCore.DTO
{
	
	public class BaseEntity : IBaseEntity
	{
		
		[Column("IsDeleted")]
		public bool IsDeleted { get; set; }

		
		[Column("ItemId")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int ItemId { get; set; }

		
		[Column("Corrector")]
		public int CorrectorId { get; set; }
	}
}