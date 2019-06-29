using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsCAA", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistCAADTO : BaseEntity
	{
		
		[Column("NumberCAA"), MaxLength(25)]
		public string NumberCAA { get; set; }

		
		[Column("CAAId")]
		public int CAAId { get; set; }

		
		[Column("CAAType")]
		public int CAAType { get; set; }

		
		[Column("ValidTo")]
		public DateTime ValidTo { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		
		[Column("IssueDate")]
		public DateTime? IssueDate { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}