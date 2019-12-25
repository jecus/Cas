using System;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsLicenseRemark", "dbo", "ItemId")]
	[Dto(typeof(SpecialistLicenseRemarkDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SpecialistLicenseRemark : BaseEntityObject
	{
		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate { get; set; }
		#endregion

		#region public LicenseRights Rights { get; set; }

		[TableColumn("RightsId")]
		public LicenseRemarkRights Rights
		{
			get { return _rights; }
			set { _rights = value; }
		}

		#endregion

		#region public LicenseFunction LicenseFunction { get; set; }
		private LicenseRestriction _licenseRestriction;
		private LicenseRemarkRights _rights;

		[TableColumn("RestrictionId")]
		public LicenseRestriction LicenseRestriction
		{
			get { return _licenseRestriction; }
			set { _licenseRestriction = value; }
		}

		#endregion

		#region public int SpecialistLicenseId { get; set; }

		[TableColumn("SpecialistLicenseId")]
		public int SpecialistLicenseId { get; set; }

		#endregion

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		#endregion

		public SpecialistLicenseRemark()
		{
			ItemId = -1;
			IssueDate = DateTime.Today;
			SmartCoreObjectType = SmartCoreType.SpecialistLicenseRemark;
		}
	}
}