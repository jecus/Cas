using System;
using System.Reflection;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("Locations", "Dictionaries", "ItemId")]
	[Dto(typeof(LocationDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Locations : AbstractDictionary
	{
		private static Type _thisType;
		private static Locations _unknown;

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

		[TableColumn("LocationsTypeId")]
		[FormControl(150, "Facility", 1, Order = 3)]
		[ListViewData(0.2f, "Facility", 3)]
		[Filter("Facility:", Order = 3)]
		[NotNull]
		[Child]
		public LocationsType LocationsType { get; set; }

        #region public Locations()

        public Locations()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Locations;
        }

        #endregion

        #region public static Locations Unknown

        public static Locations Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Locations
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown",
					LocationsType = LocationsType.Unknown
				});
			}
		}

		#endregion


		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is Locations)
				SetProperties((Locations)dict);
		}

		public void SetProperties(Locations dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Locations));
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var locations = (Locations)MemberwiseClone();
			locations.ItemId = -1;
			if(marked)
				locations.FullName += " Copy";
			locations.UnSetEvents();

			return locations;
		}

		#endregion

		public override string ToString()
		{
			return $"{ShortName} ({LocationsType?.ShortName})";
		}

		#endregion
	}
}