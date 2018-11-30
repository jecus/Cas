using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistInstrumentRatingDTO : BaseEntity
	{
		[DataMember]
		public DateTime IssueDate { get; set; }

		[DataMember]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		public int IcaoId { get; set; }

		[DataMember]
		public int MC { get; set; }

		[DataMember]
		public int MV { get; set; }

		[DataMember]
		public int RVR { get; set; }

		[DataMember]
		public int TORVR { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}