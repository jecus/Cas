﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("Operators", Schema = "dbo")]
    [Condition("IsDeleted", 0)]

	public class CAAOperatorDTO : BaseEntity
	{
		
		[Column("OperatorID")]
		public override int ItemId { get; set; }

		
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		
		[Column("LogoType", TypeName = "image")]
		public byte[] LogoType { get; set; }

		
		[Column("ICAOCode"), MaxLength(50)]
		public string ICAOCode { get; set; }

		
		[Column("Address"), MaxLength(200)]
		public string Address { get; set; }

		
		[Column("Phone"), MaxLength(100)]
		public string Phone { get; set; }

		
		[Column("Fax"), MaxLength(100)]
		public string Fax { get; set; }


		
		[Column("LogoTypeWhite", TypeName = "image")]
		public byte[] LogoTypeWhite { get; set; }

		
		[Column("Email"), MaxLength(50)]
		public string Email { get; set; }

		
		[Column("LogotypeReportLarge", TypeName = "image")]
		public byte[] LogotypeReportLarge { get; set; }

		
		[Column("LogotypeReportVeryLarge", TypeName = "image")]
		public byte[] LogotypeReportVeryLarge { get; set; }
		
		[Column("Stamp", TypeName = "image")]
		public byte[] Stamp { get; set; }
		
				
		[Column("SettingsJSON")]
		public string SettingsJSON { get; set; }

	}
}