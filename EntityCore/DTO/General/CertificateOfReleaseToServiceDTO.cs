using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("CRSs", Schema = "dbo")]
	
	public class CertificateOfReleaseToServiceDTO : BaseEntity
	{
		
		[Column("Station"), MaxLength(128)]
		public string Station { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("CheckPerformed"), MaxLength(128)]
		public string CheckPerformed { get; set; }

		
		[Column("Reference"), MaxLength(128)]
		public string Reference { get; set; }

		
		[Column("AuthorizationB1Id")]
		public int? AuthorizationB1Id { get; set; }

		
		[Column("AuthorizationB2Id")]
		public int? AuthorizationB2Id { get; set; }

		
		[Include]
		public SpecialistDTO AuthorizationB1 { get; set; }

		
		[Include]
		public SpecialistDTO AuthorizationB2 { get; set; }
	}
}