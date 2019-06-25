using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("SpecialistsLicenseRating", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRatingDTO : BaseEntity
	{
		[DataMember]
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId"), Required]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("RightsId"), Required]
		public int RightsId { get; set; }

		[DataMember]
		[Column("FunctionId"), Required]
		public int FunctionId { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion

	}
}