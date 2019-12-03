using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class ShipBy : StaticDictionary
	{
		#region private static CommonDictionaryCollection<ShipBy> _Items = new CommonDictionaryCollection<ShipBy>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ShipBy> _Items = new CommonDictionaryCollection<ShipBy>();
		#endregion

		public static ShipBy AIR = new ShipBy(1, "AIR", "AIR");
		public static ShipBy GROUND = new ShipBy(2, "GROUND", "GROUND");
		public static ShipBy TBA = new ShipBy(3, "TBA", "TBA");
		#region public static ShipBy UNK = new ShipBy(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static ShipBy UNK = new ShipBy(-1, "N/A", "N/A");
		#endregion

		/*
		 * Методы
		 */

		#region public static ShipBy GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static ShipBy GetItemById(Int32 maintenanceTypeId)
		{
			foreach (ShipBy t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<ShipBy> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ShipBy> Items
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
		#region public ShipBy()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public ShipBy()
		{
		}
		#endregion

		#region public ShipBy(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public ShipBy(Int32 itemId, String shortName, String fullName)
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
			if (y is ShipBy)
				return FullName.CompareTo(((ShipBy)y).FullName);
			return 0;
		}
		#endregion
	}
}