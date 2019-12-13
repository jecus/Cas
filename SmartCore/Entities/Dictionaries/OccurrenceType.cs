using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class OccurrenceType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<ConsequenceType> _Items = new CommonDictionaryCollection<ConsequenceType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<OccurrenceType> _Items = new CommonDictionaryCollection<OccurrenceType>();
		#endregion


		public static OccurrenceType Cancellation = new OccurrenceType(1, "Cancellation", "Cancellation");
		public static OccurrenceType Delay = new OccurrenceType(2, "Delay", "Delay");
		public static OccurrenceType Diversion = new OccurrenceType(3, "Diversion", "Diversion");
		public static OccurrenceType None = new OccurrenceType(-1, "None", "None");


		/*
		 * Методы
		 */

		#region public static ConsequenceType GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static OccurrenceType GetItemById(Int32 maintenanceTypeId)
		{
			foreach (OccurrenceType t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return None;
		}

		#endregion

		#region static public CommonDictionaryCollection<ConsequenceType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<OccurrenceType> Items
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
		#region public ConsequenceType()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public OccurrenceType()
		{
		}
		#endregion

		#region public ConsequenceType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public OccurrenceType(Int32 itemId, String shortName, String fullName)
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
			if (y is OccurrenceType)
				return FullName.CompareTo(((OccurrenceType)y).FullName);
			return 0;
		}
		#endregion
	}
}