using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity.Abstractions
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

		[Column("Updated")]
		public DateTime Updated { get; set; }

		[NotMapped]
		public string Guid { get; set; }
	}
}