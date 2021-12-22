using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.Dictionary
{
	[Table("LicenseRemarkRights", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class CAALicenseRemarkRightDTO : BaseEntity, IBaseDictionary
	{
		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAASpecialistLicenseRemarkDTO> LicenseRemarkDtos { get; set; }

		#endregion
	}
}
