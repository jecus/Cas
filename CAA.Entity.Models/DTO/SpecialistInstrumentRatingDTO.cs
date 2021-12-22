﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsInstrumentRating", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistInstrumentRatingDTO : BaseEntity
	{
		
		[Column("IssueDate")]
		public DateTime IssueDate { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("IcaoId")]
		public int IcaoId { get; set; }

		
		[Column("MC")]
		public int MC { get; set; }

		
		[Column("MV")]
		public int MV { get; set; }

		
		[Column("RVR")]
		public int RVR { get; set; }

		
		[Column("TORVR")]
		public int TORVR { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}