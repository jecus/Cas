using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("CRSs", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class CertificateOfReleaseToServiceDTO : BaseEntity
	{
		[DataMember]
		[Column("Station"), MaxLength(128)]
		public string Station { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("CheckPerformed"), MaxLength(128)]
		public string CheckPerformed { get; set; }

		[DataMember]
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

		[DataMember]
		[Column("AuthorizationB1Id")]
		public int? AuthorizationB1Id { get; set; }

		[DataMember]
		[Column("AuthorizationB2Id")]
		public int? AuthorizationB2Id { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO AuthorizationB1 { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO AuthorizationB2 { get; set; }
	}
}