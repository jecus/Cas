using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class LicenseFunction : StaticDictionary
	{
		private PersonnelCategory _category;
		public PersonnelCategory Category {get { return _category; } }


		#region private static CommonDictionaryCollection<LicenseFunction> _Items = new CommonDictionaryCollection<LicenseFunction>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<LicenseFunction> _Items = new CommonDictionaryCollection<LicenseFunction>();
		#endregion

		#region public static LicenseFunction UNK = new LicenseFunction(-1, "N/A", "N/A");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static LicenseFunction UNK = new LicenseFunction(-1, "N/A", "N/A");

		#endregion

		public static LicenseFunction AircraftMaintenanceTechnician = new LicenseFunction(1, "Aircraft maintenance technician", "Aircraft maintenance technician");
		public static LicenseFunction AircraftMaintenanceEngineer = new LicenseFunction(2, "Aircraft maintenance engineer", "Aircraft maintenance engineer");
		public static LicenseFunction AircraftMaintenanceMechanic = new LicenseFunction(3, "Aircraft maintenance mechanic", "Aircraft maintenance mechanic");

		public static LicenseFunction Captain = new LicenseFunction(4, "Captain", "Captain", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseFunction CoPilot = new LicenseFunction(5, "Co pilot", "Co pilot", PersonnelCategory.FlightCrewMembersPilots);
		public static LicenseFunction Trainee = new LicenseFunction(6, "Trainee", "Trainee", PersonnelCategory.FlightCrewMembersPilots);

		

		/*
		* Методы
		*/

		#region public static LicenseFunction GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static LicenseFunction GetItemById(Int32 maintenanceTypeId)
		{
			foreach (LicenseFunction t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<LicenseFunction> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<LicenseFunction> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FullName;
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public PersonnelCategory()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public LicenseFunction()
		{
		}
		#endregion

		#region public EmployeeLicenceType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public LicenseFunction(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}
		#endregion

		public LicenseFunction(Int32 itemId, String shortName, String fullName, PersonnelCategory category)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_category = category;

			_Items.Add(this);
		}

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is LicenseFunction)
				return FullName.CompareTo(((LicenseFunction)y).FullName);
			return 0;
		}
		#endregion
	}
}