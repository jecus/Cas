﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAS.Entity.Models.DTO.General
{
	[Table("SpecialistsLicenseRemark", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRemarkDTO : BaseEntity
	{
		
		[Column("IssueDate")]
		public DateTime IssueDate { get; set; }

		
		[Column("RightsId")]
		public int? RightsId { get; set; }

		
		[Column("RestrictionId")]
		public int? RestrictionId { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		
		[Include]
		public LicenseRemarkRightDTO Rights { get; set; }

		
		[Include]
		public RestrictionDTO LicenseRestriction { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[JsonIgnore]
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}