﻿using System;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("LicenseRemarkRights", "Dictionaries", "ItemId")]
	[Dto(typeof(LicenseRemarkRightDTO))]
	[CAADto(typeof(CAALicenseRemarkRightDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class LicenseRemarkRights : AbstractDictionary
	{
		#region public LicenseRemarkRights()

		public LicenseRemarkRights()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.LicenseRemarkRights;
		}

		#endregion

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

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is LicenseRemarkRights)
				SetProperties((LicenseRemarkRights)dict);
		}

		public void SetProperties(LicenseRemarkRights dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var locations = (LicenseRemarkRights)MemberwiseClone();
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
		
		
		private static LicenseRemarkRights _unknown;
		public static LicenseRemarkRights Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new LicenseRemarkRights
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}
	}
}