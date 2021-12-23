﻿using System;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsLicenseRating", "dbo", "ItemId")]
	[Dto(typeof(SpecialistLicenseRatingDTO))]
	[CAADto(typeof(CAASpecialistLicenseRatingDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SpecialistLicenseRating : BaseEntityObject
	{
		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate { get; set; }
		#endregion

		#region public int SpecialistLicenseId { get; set; }

		[TableColumn("SpecialistLicenseId")]
		public int SpecialistLicenseId { get; set; }

		#endregion

		#region public LicenseRights Rights { get; set; }

		[TableColumn("RightsId")]
		public LicenseRights Rights
		{
			get { return _rights ?? LicenseRights.UNK; }
			set { _rights = value; }
		}

		#endregion

		#region public LicenseFunction LicenseFunction { get; set; }
		private LicenseFunction _licenseFunction;
		private LicenseRights _rights;

		[TableColumn("FunctionId")]
		public LicenseFunction LicenseFunction
		{
			get { return _licenseFunction ?? LicenseFunction.UNK; }
			set { _licenseFunction = value; }
		}

		#endregion

		public SpecialistLicenseRating()
		{
			ItemId = -1;
			IssueDate = DateTime.Today;
			SmartCoreObjectType = SmartCoreType.SpecialistLicenseRating;
		}
	}
}