using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistMedicalRecordDTO : BaseEntity
	{
		[DataMember]
		public int? ClassId { get; set; }

		[DataMember]
		public DateTime IssueDate { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public byte[] Repeat { get; set; }

		[DataMember]
		public int? SpecialistId { get; set; }

		[DataMember]
		public string Remarks { get; set; }
	}
}