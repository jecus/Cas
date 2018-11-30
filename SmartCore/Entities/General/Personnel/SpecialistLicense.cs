using System;
using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsLicense", "dbo", "ItemId")]
	[Dto(typeof(SpecialistLicenseDTO))]
	[Condition("IsDeleted", "0")]
	public class SpecialistLicense : BaseEntityObject
	{
		

		#region public bool Confirmation { get; set; }

		[TableColumn("Confirmation")]
		public bool Confirmation { get; set; }
		#endregion

		#region public EmployeeLicenceType EmployeeLicenceType { get; set; }

		[TableColumn("LicenseTypeID")]
		public EmployeeLicenceType EmployeeLicenceType { get; set; }
		#endregion

		#region public AircraftModel AircraftType { get; set; }

		[TableColumn("AircraftTypeID")]
		public int AircraftTypeID { get; set; }

		public AircraftModel AircraftType
		{
			get { return _aircraftType ?? AircraftModel.Unknown; }
			set { _aircraftType = value; }
		}

		#endregion

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion

		#region public DateTime ValidToDate { get; set; } 

		[TableColumn("ValidToDate")]
		public DateTime ValidToDate
		{
			get { return _validToDate < DateTimeExtend.GetCASMinDateTime() ? DateTime.Today : _validToDate; }
			set { _validToDate = value; }
		}

		#endregion

		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate
		{
			get { return _issueDate < DateTimeExtend.GetCASMinDateTime() ? DateTime.Today : _issueDate; }
			set { _issueDate = value; }
		}

		#endregion

		#region public Lifelength NotifyLifelength { get; set; }

		[TableColumn("Notify")]
		public Lifelength NotifyLifelength { get; set; }

		#endregion

		#region public CommonCollection<SpecialistCAA> CaaLicense { get; set; }

		private CommonCollection<SpecialistCAA> _caaLicense;

		[Child(RelationType.OneToMany, "SpecialistLicenseId")]
		public CommonCollection<SpecialistCAA> CaaLicense
		{
			get { return _caaLicense ?? (_caaLicense = new CommonCollection<SpecialistCAA>()); }
			set { _caaLicense = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistLicenseDetail> LicenseDetails;

		private CommonCollection<SpecialistLicenseDetail> _licenseDetails;
		[Child(RelationType.OneToMany, "SpecialistLicenseId")]
		public CommonCollection<SpecialistLicenseDetail> LicenseDetails
		{
			get { return _licenseDetails ?? (_licenseDetails = new CommonCollection<SpecialistLicenseDetail>()); }
			set { _licenseDetails = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistLicenseRating> LicenseRatings;

		private CommonCollection<SpecialistLicenseRating> _licenseRatings;

		[Child(RelationType.OneToMany, "SpecialistLicenseId")]
		public CommonCollection<SpecialistLicenseRating> LicenseRatings
		{
			get { return _licenseRatings ?? (_licenseRatings = new CommonCollection<SpecialistLicenseRating>()); }
			set { _licenseRatings = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistInstrumentRating> SpecialistInstrumentRatings

		private CommonCollection<SpecialistInstrumentRating> _specialistInstrumentRatings;
		[Child(RelationType.OneToMany, "SpecialistLicenseId")]
		public CommonCollection<SpecialistInstrumentRating> SpecialistInstrumentRatings
		{
			get { return _specialistInstrumentRatings ?? (_specialistInstrumentRatings = new CommonCollection<SpecialistInstrumentRating>()); }
			set { _specialistInstrumentRatings = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistLicenseRemark> LicenseRemark

		private CommonCollection<SpecialistLicenseRemark> _licenseRemark;
		private AircraftModel _aircraftType;
		private DateTime _issueDate;
		private DateTime _validToDate;

		[Child(RelationType.OneToMany, "SpecialistLicenseId")]
		public CommonCollection<SpecialistLicenseRemark> LicenseRemark
		{
			get { return _licenseRemark ?? (_licenseRemark = new CommonCollection<SpecialistLicenseRemark>()); }
			set { _licenseRemark = value; }
		}

		#endregion

		public SpecialistLicense()
		{
			EmployeeLicenceType = EmployeeLicenceType.UNK;
			SmartCoreObjectType = SmartCoreType.SpecialistLicense;
			IssueDate = DateTime.Today;
			ValidToDate = DateTime.Today;
		}
	}
}