using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;
using SmartCore.Management;

namespace SmartCore.Entities.General.Personnel
{

    /// <summary>
    /// Класс описывает Специалиста
    /// </summary>
    [Table("Specialists", "dbo", "ItemId")]
    [Dto(typeof(SpecialistDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class Specialist : BaseEntityObject, IFileContainer, IEmployeeFilterParams, IEmployeeWorkPackageFilterParams
	{
		
		/*
		*  Свойства
		*/

		#region public String IDNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String IdNo { get; set; }
		#endregion

        #region public String FirstName { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("FirstName")]
        [FormControl(120, "First Name")]
        [NotNull]
        public String FirstName { get; set; }
		#endregion

        #region public String LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("LastName")]
        [FormControl(120, "Last Name")]
        [NotNull]
        public String LastName { get; set; }
		#endregion

		[TableColumnAttribute("ShortName")]
		public string ShortName { get; set; }

		#region public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("DateOfBirth")]
        [FormControl(120, "Date of Birth")]
        [NotNull]
        public DateTime DateOfBirth { get; set; }
        #endregion

        #region public Gender Gender { get; set; }
	
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Gender")]
		[FormControl(120, "Sex")]
		[NotNull]
		public Gender Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		#endregion

        #region public AGWCategory AGWCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("AGWCategory")]
        [FormControl(120, "Age-Sex-Weight")]
        [NotNull]
        public AGWCategory AGWCategory { get; set; }
		#endregion

		#region public string Nationality { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Nationality")]
        [FormControl(120, "Nationality")]
        public string Nationality { get; set; }
		#endregion

		#region public Citizenship Citizenship { get; set; } 

		[TableColumn("Citizenship")]
		public Citizenship Citizenship { get; set; } 
			#endregion

        #region public String Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Address")]
        [FormControl(120, "Address")]
        public String Address { get; set; }
		#endregion

		#region public string Information { get; set; }

		[TableColumn("Information")]
		public string Information { get; set; }
		#endregion

		#region public FamilyStatus FamilyStatus { get; set; }

		private FamilyStatus _familyStatus;

		/// <summary>
		/// Семейное положение
		/// </summary>
		[TableColumnAttribute("FamilyStatus")]
		[FormControl(120, "Family Status")]
		public FamilyStatus FamilyStatus
		{
			get { return _familyStatus != null ? _familyStatus : FamilyStatus.UNK; }
			set { _familyStatus = value; }
		}

		#endregion

		#region public Education Education { get; set; }

		[TableColumn("Education")]
		public Education Education { get; set; }

		#endregion

		#region public SpecialistPosition Position { get; set; }

		[TableColumn("Position")]
		public SpecialistPosition Position { get; set; }

		#endregion

		#region public SpecialistStatus Status { get; set; }

		[TableColumn("Status")]
		public SpecialistStatus Status { get; set; }

		#endregion

		#region public Locations Location { get; set; }

		private LocationsType _location;
		[TableColumn("Location")]
		public LocationsType Facility
		{
			get { return _location ?? LocationsType.Unknown; }
			set { _location = value; }
		}

		#endregion

		#region public Image PhotoImage { get; set; }

		public Image PhotoImage
        {
            get
            {
                return DbTypes.BytesToImage(Photo);
            }
            set
            {
                Photo = DbTypes.ImageToBytes(value, ImageFormat.Png);
                OnPropertyChanged("PhotoImage");

            }
        }

        #endregion

        #region public Byte[] Photo { get; set; }

        private Byte[] _photo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Photo")]
        public Byte[] Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }
		#endregion

		#region public Image SignImage { get; set; }

		public Image SignImage
		{
			get
			{
				return DbTypes.BytesToImage(Sign);
			}
			set
			{
				Sign = DbTypes.ImageToBytes(value, ImageFormat.Png);
				OnPropertyChanged("SignImage");

			}
		}

		#endregion

		#region public Byte[] Sign { get; set; }

		private Byte[] _sign;
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Sign")]
		public Byte[] Sign
		{
			get { return _sign; }
			set
			{
				_sign = value;
				OnPropertyChanged("Sign");
			}
		}
		#endregion

		#region public String PhoneMobile { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("PhoneMobile")]
        [FormControl(120, "PhoneMobile")]
        public String PhoneMobile { get; set; }
        #endregion

        #region public String Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Phone")]
        [FormControl(120, "Phone")]
        public String Phone { get; set; }
		#endregion

		#region public string Additional { get; set; }

		[TableColumn("Additional")]
		public string Additional { get; set; }

			#endregion

		#region public String Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Email")]
        [FormControl(120, "Email")]
        public String Email { get; set; }
        #endregion

        #region public String Skype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Skype")]
        [FormControl(120, "Skype")]
        public String Skype { get; set; }
		#endregion

		#region public PersonnelCategory PersonnelCategory { get; set; }
		private PersonnelCategory _personnelCategory;

		[TableColumn("PersonnelCategoryId")]
		public PersonnelCategory PersonnelCategory
		{
			get { return _personnelCategory ?? PersonnelCategory.UNK; }
			set { _personnelCategory = value; }
		}

		#endregion

		public SpecialistMedicalRecord MedicalRecord { get; set; }

		#region public CommonCollection<SpecialistLicense> Licenses

		[Child(RelationType.OneToMany, "SpecialistId")]
		public CommonCollection<SpecialistLicense> Licenses
		{
			get { return _licenses ?? (_licenses = new CommonCollection<SpecialistLicense>()); }
			set { _licenses = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistTraining> SpecialistTrainings

		private CommonCollection<SpecialistTraining> _specialistTrainings;
		[Child(RelationType.OneToMany, "SpecialistId")]
		public CommonCollection<SpecialistTraining> SpecialistTrainings
		{
			get { return _specialistTrainings ?? (_specialistTrainings = new CommonCollection<SpecialistTraining>()); }
			set { _specialistTrainings = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistLicenseDetail> LicenseDetails;

		private CommonCollection<SpecialistLicenseDetail> _licenseDetails;
		[Child(RelationType.OneToMany, "SpecialistId")]
		public CommonCollection<SpecialistLicenseDetail> LicenseDetails
		{
			get { return _licenseDetails ?? (_licenseDetails = new CommonCollection<SpecialistLicenseDetail>()); }
			set { _licenseDetails = value; }
		}

		#endregion

		#region public CommonCollection<SpecialistLicenseRemark> LicenseRemark

		private CommonCollection<SpecialistLicenseRemark> _licenseRemark;
		[Child(RelationType.OneToMany, "SpecialistId")]
		public CommonCollection<SpecialistLicenseRemark> LicenseRemark
		{
			get { return _licenseRemark ?? (_licenseRemark = new CommonCollection<SpecialistLicenseRemark>()); }
			set { _licenseRemark = value; }
		}
		#endregion

		#region public CommonCollection<AircraftFlight> EmployeeFlights { get; set; }
		private CommonCollection<AircraftFlight> _employeeFlights;
		public CommonCollection<AircraftFlight> EmployeeFlights
		{
			get { return _employeeFlights ?? (_employeeFlights = new AircraftFlightCollection()); }
			set { _employeeFlights = value; }
		}

		#endregion

		#region public Specialization Specialization { get; set; }

		private Specialization _specialization;

		[TableColumnAttribute("SpecializationId")]
		[FormControl(120, "Occupation")]
		[NotNull]
		public Specialization Specialization
		{
			get { return _specialization ?? Specialization.Unknown; }
			set { _specialization = value; }
		}

		#endregion

		#region public string Combination { get; set; }

		[TableColumn("Combination")]
		public string Combination { get; set; }

		#endregion

		#region public bool IsSertificier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool IsSertificier { get; set; }
		#endregion

		#region public int ClassNumber { get; set; }

		[TableColumn("ClassNumber")]
		public int ClassNumber { get; set; }
		#endregion

		#region public DateTime ClassIssueDate

		private DateTime _classIssueDate;
		[TableColumn("ClassIssueDate")]
		public DateTime ClassIssueDate
		{
			get {
				DateTime check = DateTimeExtend.GetCASMinDateTime();
				if (_classIssueDate < check) _classIssueDate = DateTime.Today;
				return _classIssueDate;
			}
			set { _classIssueDate = value; }
		}
			#endregion

		#region public int GradeNumber { get; set; }

		[TableColumn("GradeNumber")]
		public int GradeNumber { get; set; }
		#endregion

		#region public DateTime GradeIssueDate

		private DateTime _gradeIssueDate;
		[TableColumn("GradeIssueDate")]
		public DateTime GradeIssueDate
		{
			get {
				DateTime check = DateTimeExtend.GetCASMinDateTime();
				if (_gradeIssueDate < check) _gradeIssueDate = DateTime.Today;
				return _gradeIssueDate;
			}
			set { _gradeIssueDate = value; }
		}

		#endregion

		#region public String Limitations { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String Limitations { get; set; }
		#endregion

		#region public AttachedFile ResumeFile { get; set; }

		private AttachedFile _resumeFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile ResumeFile
	    {
			get
			{
				return _resumeFile ?? (Files.GetFileByFileLinkType(FileLinkType.SpecialistResumeFile));
			}
			set
			{
				_resumeFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.SpecialistResumeFile);
			}
		}

		#endregion

		#region public CommonCollection<WorkPackage.WorkPackage> SpecialistWorkPackages { get; set; } 

		public CommonCollection<WorkPackage.WorkPackage> SpecialistWorkPackages
		{
			get { return _specialistWorkPackages ?? (_specialistWorkPackages = new CommonCollection<WorkPackage.WorkPackage>()); }
			set { _specialistWorkPackages = value; }
		}

		#endregion

		#region #IEmployeeFilterParams

		public List<AircraftModel> LicenseAircrafts
		{
			get { return Licenses.Where(l => l.AircraftType.ItemId > 0).Select(l => l.AircraftType).ToList(); }
		}

		public List<LicenseFunction> LicenseFunctions
		{
			get { return Licenses.SelectMany(l => l.LicenseRatings.Select(r => r.LicenseFunction)).ToList(); }
		}

		public List<LicenseRights> LicenseRights
		{
			get { return Licenses.SelectMany(l => l.LicenseRatings.Select(r => r.Rights)).ToList(); }
		}

		public Department Department
		{
			get
			{
				return Specialization.Department??Department.Unknown;
			}
		}

		#endregion

		/*
         * Паспортные данные
         */

		#region public AttachedFile PassportCopyFile { get; set; }
		private AttachedFile _passportCopyFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile PassportCopyFile
	    {
			get
			{
				return _passportCopyFile ?? (Files.GetFileByFileLinkType(FileLinkType.SpecialistPassportCopyFile));
			}
			set
			{
				_passportCopyFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.SpecialistPassportCopyFile);
			}
		}

	    #endregion

        #region public CommonCollection<Document> EmployeeDocuments

        private CommonCollection<Document> _employeeDocuments;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1310, "Parent")]
        public CommonCollection<Document> EmployeeDocuments
        {
            get { return _employeeDocuments ?? (_employeeDocuments = new CommonCollection<Document>()); }
            internal set
            {
                if (_employeeDocuments != value)
                {
                    if (_employeeDocuments != null)
                        _employeeDocuments.Clear();
                    if (value != null)
                        _employeeDocuments = value;
                }
            }
        }
        #endregion

        #region public CommonCollection<CategoryRecord> CategoriesRecords

        private CommonCollection<CategoryRecord> _employeeAircraftWorkerCategories;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1310, "Parent")]
        public CommonCollection<CategoryRecord> CategoriesRecords
        {
            get { return _employeeAircraftWorkerCategories ?? (_employeeAircraftWorkerCategories = new CommonCollection<CategoryRecord>()); }
            internal set
            {
                if (_employeeAircraftWorkerCategories != value)
                {
                    if (_employeeAircraftWorkerCategories != null)
                        _employeeAircraftWorkerCategories.Clear();
                    if (value != null)
                        _employeeAircraftWorkerCategories = value;
                }
            }
        }
        #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;
		private Gender _gender;
		private CommonCollection<SpecialistLicense> _licenses;
		private CommonCollection<WorkPackage.WorkPackage> _specialistWorkPackages;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1310)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion

		/*
		*  Методы 
		*/

		#region public Specialist()
		/// <summary>
		/// Создает Специалиста без дополнительной информации
		/// </summary>
		public Specialist()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Employee;
            Gender = Gender.Male;
            AGWCategory = null;

            DateOfBirth = new DateTime(1970,1,1);
			GradeIssueDate = DateTime.Today;
			ClassIssueDate = DateTime.Today;
        }
        #endregion
      
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(IsDeleted)
                return LastName + " " + LastName + " is deleted.";
            return LastName + " " + FirstName;
        }

		#endregion

		#region public static Department Unknown
		private static Specialist _unknown;

		public static Specialist Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Specialist
				{
					FirstName = "Unknown",
				});
			}
		}

		#endregion
	}
}
