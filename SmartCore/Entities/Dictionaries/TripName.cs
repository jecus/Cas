using System;
using System.Reflection;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("TripName", "Dictionaries", "ItemId")]
	[Dto(typeof(TripNameDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class TripName : AbstractDictionary
	{
		private static Type _thisType;
		private static TripName _unknown;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		public override string ShortName { get; set; }

		#endregion

		#region public override string FullName { get; set; }

		private string _fullName;

		/// <summary>
		/// Полное название Категории
		/// </summary>
		[TableColumn("TripName", 256)]
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

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is TripName)
				SetProperties((TripName)dict);
		}


		public void SetProperties(TripName dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(TripName));
		}
        #endregion

        #endregion

        #region public static TripName Unknown

        public static TripName Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new TripName
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

        #endregion

        #region public TripName()

        public TripName()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.TripName;
        }

        #endregion
	}
}