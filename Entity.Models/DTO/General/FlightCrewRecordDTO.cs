﻿using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAS.Entity.Models.DTO.General
{
	[Table("FlightCrews", Schema = "dbo")]
	[Condition("IsDeleted", 0)]

	public class FlightCrewRecordDTO : BaseEntity
	{
		
		[Column("FlightID")]
		public int FlightID { get; set; }

		
		[Column("SpecialistID")]
		public int? SpecialistID { get; set; }

		
		[Column("SpecializationID")]
		public int? SpecializationID { get; set; }

		
		[Column("IDNo")]
		public int? IDNo { get; set; }

		
		[Column("Limitations")]
		public string Limitations { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Child]
		public SpecialistDTO Specialist { get; set; }

		
		[Include]
		public SpecializationDTO Specialization { get; set; }
	}
}