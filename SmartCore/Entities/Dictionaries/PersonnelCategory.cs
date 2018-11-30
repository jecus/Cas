using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class PersonnelCategory : StaticDictionary
	{
		#region private static CommonDictionaryCollection<PersonnelCategory> _Items = new CommonDictionaryCollection<PersonnelCategory>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<PersonnelCategory> _Items = new CommonDictionaryCollection<PersonnelCategory>();
		#endregion


		public static PersonnelCategory FlightCrewMembersPilots = new PersonnelCategory(1, "Flight Crew Members - Pilots", "Flight Crew Members - Pilots");
		public static PersonnelCategory FlightCrewMembersOtherThanPilots = new PersonnelCategory(2, "Flight Crew Members other than Pilots", "Flight Crew Members other than Pilots");
		public static PersonnelCategory OtherThanFlightCrewMembers = new PersonnelCategory(3, "Other than Flight Crew Members", "Other than Flight Crew Members");
		public static PersonnelCategory CabinCrew  = new PersonnelCategory(4, "Cabin crew ", "Cabin crew");

		#region public static PersonnelCategory UNK = new PersonnelCategory(-1, "N/A", "N/A");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static PersonnelCategory UNK = new PersonnelCategory(-1, "N/A", "N/A");
		#endregion

		/*
		* Методы
		*/

		#region public static PersonnelCategory GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static PersonnelCategory GetItemById(Int32 maintenanceTypeId)
		{
			foreach (PersonnelCategory t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<PersonnelCategory> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<PersonnelCategory> Items
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
		public PersonnelCategory()
		{
		}
		#endregion

		#region public PersonnelCategory(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public PersonnelCategory(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is PersonnelCategory)
				return FullName.CompareTo(((PersonnelCategory)y).FullName);
			return 0;
		}
		#endregion
	}
}