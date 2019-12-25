using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Priority : StaticDictionary
	{

		#region private static CommonDictionaryCollection<Priority> _Items = new CommonDictionaryCollection<Priority>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Priority> _Items = new CommonDictionaryCollection<Priority>();
		#endregion


		public static Priority AOG = new Priority(1, "AOG", "AOG");
		public static Priority Urgent = new Priority(2, "Urgent", "Urgent");
		public static Priority Routine = new Priority(3, "Routine", "Routine");

		#region public static Priority UNK = new Priority(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static Priority UNK = new Priority(-1, "N/A", "N/A");
		#endregion

		/*
		 * Методы
		 */

		#region public static Priority GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static Priority GetItemById(Int32 maintenanceTypeId)
		{
			foreach (Priority t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<DeffeсtCategory> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Priority> Items
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
		#region public Priority()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public Priority()
		{
		}
		#endregion

		#region public Priority(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public Priority(Int32 itemId, String shortName, String fullName)
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
			if (y is Priority)
				return FullName.CompareTo(((Priority)y).FullName);
			return 0;
		}
		#endregion
	}
}