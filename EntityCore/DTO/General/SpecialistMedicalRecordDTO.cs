using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("EmployeeMedicalRecors", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistMedicalRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("ClassId")]
		public int? ClassId { get; set; }

		[DataMember]
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		[DataMember]
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("Repeat"), MaxLength(21)]
		public byte[] Repeat { get; set; }

		[DataMember]
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }
	}
}