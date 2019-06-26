using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("EmployeeMedicalRecors", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistMedicalRecordDTO : BaseEntity
	{
		
		[Column("ClassId")]
		public int? ClassId { get; set; }

		
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		
		[Column("Repeat"), MaxLength(21)]
		public byte[] Repeat { get; set; }

		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }
	}
}