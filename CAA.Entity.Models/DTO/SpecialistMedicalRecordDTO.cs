using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("EmployeeMedicalRecors", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistMedicalRecordDTO : BaseEntity
	{
		
		[Column("ClassId")]
		public int? ClassId { get; set; }

		
		[Column("IssueDate")]
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