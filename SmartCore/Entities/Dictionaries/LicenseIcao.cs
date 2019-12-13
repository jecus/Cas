using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class LicenseIcao : StaticDictionary
	{
		#region private static CommonDictionaryCollection<LicenseIcao> _Items = new CommonDictionaryCollection<LicenseIcao>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<LicenseIcao> _Items = new CommonDictionaryCollection<LicenseIcao>();
		#endregion

		public static LicenseIcao CATFirst = new LicenseIcao(1, "CAT I (550 * 60)", "CAT I (550 * 60)");
		public static LicenseIcao CATSecond = new LicenseIcao(2, "CAT II (300 * 30)", "CAT II (300 * 30)");
		public static LicenseIcao CATThirdA = new LicenseIcao(3, "CAT IIIA (200 * 30)", "CAT IIIA (200 * 30)");
		public static LicenseIcao CATThirdB = new LicenseIcao(4, "CAT IIIB (50 * 15)", "CAT IIIB (50 * 15)");
		public static LicenseIcao CATThirdC = new LicenseIcao(5, "CAT IIIC (0 * 0)", "CAT IIIC (0 * 0)");


		#region public static LicenseIcao UNK = new LicenseIcao(-1, "UNK", "Unknown");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static LicenseIcao UNK = new LicenseIcao(-1, "N/A", "N/A");
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
		public static LicenseIcao GetItemById(Int32 maintenanceTypeId)
		{
			foreach (LicenseIcao t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<LicenseIcao> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<LicenseIcao> Items
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
		#region public LicenseIcao()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public LicenseIcao()
		{
		}
		#endregion

		#region public LicenseIcao(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public LicenseIcao(Int32 itemId, String shortName, String fullName)
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
			if (y is LicenseIcao)
				return FullName.CompareTo(((LicenseIcao)y).FullName);
			return 0;
		}
		#endregion
	}
}