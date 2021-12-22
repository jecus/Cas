using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("ATAChapter", Schema = "Dictionaries")]
	[Condition("IsDeleted", 0)]

	public class CAAATAChapterDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("ShortName"), MaxLength(100)]
		public string ShortName { get; set; }

		
		[Column("FullName"), MaxLength(100)]
		public string FullName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAAAccessoryDescriptionDTO> AccessoryDescriptionDtos { get; set; }

        #endregion
	}
}
