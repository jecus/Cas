using System;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("LocationsType", "Dictionaries", "ItemId")]
	[Dto(typeof(LocationsTypeDTO))]
	[CAADto(typeof(CAALocationsTypeDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class LocationsType : AbstractDictionary
	{
		private static LocationsType _unknown;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		private string _shortName;

		[TableColumn("Name", 50)]
		[FormControl(150, "Short Name", 1, Order = 1)]
		[ListViewData(0.2f, "Short Name", 1)]
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
		private Department _department;

		/// <summary>
		/// Полное название Категории
		/// </summary>
		[TableColumn("FullName", 256)]
		[FormControl(150, "Full Name", 5, Order = 2)]
		[ListViewData(0.2f, "Full Name", 2)]
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

		#endregion

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		#endregion

		[FormControl(150, "Department", 1, Order = 3)]
		[ListViewData(0.2f, "Department", 3)]
		[TableColumn("DepartmentId")]
		//[Child]
		public Department Department
		{
			get { return _department ?? Department.Unknown; }
			set { _department = value; }
		}

        #region public LocationsType()

        public LocationsType()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.LocationsType;
        }

        #endregion

		#region public static Nomenclatures Unknown

		public static LocationsType Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new LocationsType
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown",
					Department = Department.Unknown
				});
			}
		}

		#endregion

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is LocationsType)
				SetProperties((LocationsType)dict);
		}

		public void SetProperties(LocationsType dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			Department = dictionary.Department;
		}

		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var locations = (LocationsType)MemberwiseClone();
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
	}
}