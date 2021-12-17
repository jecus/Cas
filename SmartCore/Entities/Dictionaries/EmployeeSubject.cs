using System;
using System.Reflection;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("EmployeeSubjects", "Dictionaries", "ItemId")]
	[Dto(typeof(EmployeeSubjectDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class EmployeeSubject : AbstractDictionary
	{
		private static Type _thisType;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		private string _shortName;

		[TableColumn("Name", 50)]
		[FormControl(150, "Short Name", 1, Order = 1)]
		[ListViewData(0.2f, "Short Name", 1)]
		[Filter("Short Name:", Order = 1)]
		[NotNull]
		public override string ShortName
		{
			get { return _shortName; }
			set
			{
				_shortName = value;
				OnPropertyChanged("ShortName");
			}
		}

		#endregion

		#region public override string FullName { get; set; }

		private string _fullName;
		private EmployeeLicenceType _licenceType;
		private static EmployeeSubject _unknown;

		/// <summary>
		/// Полное название Категории
		/// </summary>
		[TableColumn("FullName", 256)]
		[FormControl(150, "Full Name", 5, Order = 2)]
		[ListViewData(0.2f, "Full Name", 2)]
		[Filter("Full Name:", Order = 2)]
		[NotNull]
		public override string FullName
		{
			get { return _fullName; }
			set
			{
				if (_fullName != value)
				{
					_fullName = value;
					OnPropertyChanged("FullName");
				}
			}
		}

		public static PropertyInfo FullNameProperty
		{
			get { return GetCurrentType().GetProperty("FullName"); }
		}

		#endregion

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		#endregion

		[TableColumn("LicenceTypeId")]
		public int LicenceTypeId { get; set; }

		[FormControl(150, "LicenceType", 1, Order = 3)]
		[ListViewData(0.2f, "LicenceType", 3)]
		[Filter("LicenceType:", Order = 3)]
		[NotNull]
		public EmployeeLicenceType LicenceType
		{
			get { return EmployeeLicenceType.GetItemById(LicenceTypeId); }
			set { LicenceTypeId = value.ItemId; }
		}

		public static PropertyInfo LicenceTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("LicenceTypeId"); }
		}

		#region public static Department Unknown

		public static EmployeeSubject Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new EmployeeSubject
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

		#endregion

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is EmployeeSubject)
				SetProperties((EmployeeSubject)dict);
		}

		public void SetProperties(EmployeeSubject dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(EmployeeSubject));
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var locations = (EmployeeSubject)MemberwiseClone();
			locations.ItemId = -1;
			if(marked)
				locations.FullName += " Copy";
			locations.UnSetEvents();

			return locations;
		}

		#endregion

		public override string ToString()
		{
			return $"{FullName}";
		}

        #endregion

        #region public EmployeeSubject()

        public EmployeeSubject()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.EmployeeSubject;
        }

        #endregion
	}
}