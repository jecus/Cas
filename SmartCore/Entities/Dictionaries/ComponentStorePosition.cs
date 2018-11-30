using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class ComponentStorePosition : StaticDictionary
	{
		#region private static CommonDictionaryCollection<HumanDamage> _Items = new CommonDictionaryCollection<HumanDamage>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ComponentStorePosition> _Items = new CommonDictionaryCollection<ComponentStorePosition>();
		#endregion

		#region public static ComponentStorePosition In = new ComponentStorePosition(1, "In", "In", 1);
		/// <summary>
		/// легкие травмы
		/// </summary>
		public static ComponentStorePosition In = new ComponentStorePosition(1, "In", "In", 1);
		#endregion

		#region public static ComponentStorePosition Serviceable = new ComponentStorePosition(2, "Serviceable", "Serviceable", 2);
		/// <summary>
		/// легкие травмы
		/// </summary>
		public static ComponentStorePosition Serviceable = new ComponentStorePosition(2, "Serviceable", "Serviceable", 2);
		#endregion

		#region public static ComponentStorePosition Unserviceable = new ComponentStorePosition(3, "Unserviceable", "Unserviceable", 3);;
		/// <summary>
		/// легкие травмы
		/// </summary>
		public static ComponentStorePosition Unserviceable = new ComponentStorePosition(3, "Unserviceable", "Unserviceable", 3);
		#endregion

		#region public static HumanDamage UNK = new HumanDamage(-1, "UNK", "Unknown", 0);
		/// <summary>
		/// неизвестный
		/// </summary>
		public static ComponentStorePosition UNK = new ComponentStorePosition(-1, "UNK", "Unknown", 0);
		#endregion


		/*
		* Методы
	    */

		#region public static ComponentStorePosition GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static ComponentStorePosition GetItemById(Int32 maintenanceTypeId)
		{
			foreach (ComponentStorePosition t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<HumanDamage> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ComponentStorePosition> Items
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
		#region public ComponentStorePosition()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public ComponentStorePosition()
		{
		}
		#endregion

		#region public ComponentStorePosition(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public ComponentStorePosition(Int32 itemId, String shortName, String fullName, int weight)
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
			if (y is ComponentStorePosition)
				return FullName.CompareTo(((ComponentStorePosition)y).FullName);
			return 0;
		}
		#endregion
	}
}