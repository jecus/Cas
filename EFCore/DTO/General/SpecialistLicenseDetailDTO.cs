using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("SpecialistsLicenseDetail", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDetailDTO : BaseEntity
	{
		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }


		#endregion
	}
}