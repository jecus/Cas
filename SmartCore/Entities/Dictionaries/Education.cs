using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Education : StaticDictionary
	{
		#region private static List<Education> _Items = new List<Education>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Education> _Items = new CommonDictionaryCollection<Education>();
		#endregion


		#region public static Education UNK = new Education(-1, "UNK", "Unknown");

		public static Education UNK = new Education(-1, "UNK", "Unknown");

		#endregion

		public static Education School = new Education(1, "School", "School");
		public static Education SecondarySchool = new Education(2, "Secondary school,", "Secondary school,");
		public static Education SecondaryVocational = new Education(3, "Secondary vocational", "Secondary vocational");
		public static Education Higher = new Education(4, "Higher", "Higher");
		public static Education SecondaryAviation = new Education(5, "Secondary vocational -Aviation", "Secondary vocational -Aviation");
		public static Education HigherAviation = new Education(6, "Higher Aviation", "Higher Aviation");

		/*
		 * Методы
		 */
		#region public static Education GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static Education GetItemById(Int32 maintenanceTypeId)
		{
			foreach (Education t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<Education> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Education> Items
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
		#region public FamilyStatus()
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		public Education()
		{
		}
		#endregion

		#region public FamilyStatus(Int32 itemID, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public Education(Int32 itemId, String shortName, String fullName)
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
			if (y is Education)
				return FullName.CompareTo(((Education)y).FullName);
			return 0;
		}
		#endregion
	}
}