using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class CertificateOfReleaseToServiceDTO : BaseEntity
	{
		[DataMember]
		public string Station { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public string CheckPerformed { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public int? AuthorizationB1Id { get; set; }

		[DataMember]
		public int? AuthorizationB2Id { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO AuthorizationB1 { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO AuthorizationB2 { get; set; }
	}
}