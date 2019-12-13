using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class ConsequenceOPS : StaticDictionary
	{
		#region private static CommonDictionaryCollection<ConsequenceOPS> _Items = new CommonDictionaryCollection<ConsequenceOPS>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ConsequenceOPS> _Items = new CommonDictionaryCollection<ConsequenceOPS>();
		#endregion


		public static ConsequenceOPS None = new ConsequenceOPS(-1, "None", "None");
		public static ConsequenceOPS AOG = new ConsequenceOPS(2, "AOG", "Aircraft on Ground");
		public static ConsequenceOPS OPS = new ConsequenceOPS(3, "OPS", "Operational Breakdown");


		/*
		 * Методы
		 */

		#region public static ConsequenceOPS GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static ConsequenceOPS GetItemById(Int32 maintenanceTypeId)
		{
			foreach (ConsequenceOPS t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return None;
		}

		#endregion

		#region static public CommonDictionaryCollection<ConsequenceOPS> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ConsequenceOPS> Items
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
		#region public ConsequenceOPS()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public ConsequenceOPS()
		{
		}
		#endregion

		#region public ConsequenceOPS(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public ConsequenceOPS(Int32 itemId, String shortName, String fullName)
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
			if (y is ConsequenceOPS)
				return FullName.CompareTo(((ConsequenceOPS)y).FullName);
			return 0;
		}
		#endregion
	}
}