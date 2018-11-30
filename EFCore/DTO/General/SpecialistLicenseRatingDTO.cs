using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRatingDTO : BaseEntity
	{
		[DataMember]
		public DateTime IssueDate { get; set; }

		[DataMember]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		public int RightsId { get; set; }

		[DataMember]
		public int FunctionId { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion

	}
}