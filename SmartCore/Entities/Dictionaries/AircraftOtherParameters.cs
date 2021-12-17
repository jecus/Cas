using System;
using System.Reflection;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("AircraftOtherParameters", "Dictionaries", "ItemId")]
	[Dto(typeof(AircraftOtherParameterDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class AircraftOtherParameters : AbstractDictionary
	{
		private static Type _thisType;
		private static AircraftOtherParameters _unknown;

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

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is AircraftOtherParameters)
				SetProperties((AircraftOtherParameters)dict);
		}


		public void SetProperties(AircraftOtherParameters dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(AircraftOtherParameters));
		}
		#endregion

		#region public static AircraftOtherParameters Unknown

		public static AircraftOtherParameters Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new AircraftOtherParameters
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

		#endregion

		#region public override string ToString()

		public override string ToString()
		{
			return ShortName;
		}

		#endregion

        public AircraftOtherParameters()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.AircraftOtherParameters;
        }

	}
}