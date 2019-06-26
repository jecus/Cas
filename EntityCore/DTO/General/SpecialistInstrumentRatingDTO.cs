using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsInstrumentRating", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistInstrumentRatingDTO : BaseEntity
	{
		[DataMember]
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("IcaoId"), Required]
		public int IcaoId { get; set; }

		[DataMember]
		[Column("MC"), Required]
		public int MC { get; set; }

		[DataMember]
		[Column("MV"), Required]
		public int MV { get; set; }

		[DataMember]
		[Column("RVR"), Required]
		public int RVR { get; set; }

		[DataMember]
		[Column("TORVR"), Required]
		public int TORVR { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}