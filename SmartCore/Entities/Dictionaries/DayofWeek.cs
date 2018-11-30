using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DayofWeek : StaticDictionary
	{
		#region private static CommonDictionaryCollection<DayofWeek> _Items = new CommonDictionaryCollection<DayofWeek>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DayofWeek> _Items = new CommonDictionaryCollection<DayofWeek>();
		#endregion

		public static DayofWeek Monday = new DayofWeek(1, "Monday", "1");
		public static DayofWeek Tuesday = new DayofWeek(2, "Tuesday", "2");
		public static DayofWeek Wednesday = new DayofWeek(3, "Wednesday", "3");
		public static DayofWeek Thursday = new DayofWeek(4, "Thursday", "4");
		public static DayofWeek Friday = new DayofWeek(5, "Friday", "5");
		public static DayofWeek Saturday = new DayofWeek(6, "Saturday", "6");
		public static DayofWeek Sunday = new DayofWeek(7, "Sunday", "7");

		public static DayofWeek Unknown = new DayofWeek(-1, "Unknown", "-1");
		/*
		* Методы
		*/

		#region public static DayofWeek GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static DayofWeek GetItemById(Int32 maintenanceTypeId)
		{
			foreach (DayofWeek t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;

			return null;
		}

		#endregion

		#region static public CommonDictionaryCollection<DayofWeek> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DayofWeek> Items
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
			return $"{FullName} ({ShortName})";
		}
		#endregion

		/*
         * Реализация
         */
		#region public DayofWeek()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public DayofWeek()
		{
		}
		#endregion

		#region public DayofWeek(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public DayofWeek(Int32 itemId,  String fullName, String shortName)
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
			if (y is DayofWeek)
				return FullName.CompareTo(((DayofWeek)y).FullName);
			return 0;
		}
		#endregion
	}
}