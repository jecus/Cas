using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class OpsStatus : StaticDictionary
	{
		#region private static CommonDictionaryCollection<OpsStatus> _Items = new CommonDictionaryCollection<OpsStatus>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<OpsStatus> _Items = new CommonDictionaryCollection<OpsStatus>();
		#endregion

		public static OpsStatus OPS = new OpsStatus(1, "OPS", "OPS");
		public static OpsStatus AOG = new OpsStatus(2, "AOG", "AOG");

		public static OpsStatus Unknown = new OpsStatus(-1, "Unknown", "Unknown");
		/*
		* Методы
		*/

		#region public static DayofWeek GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static OpsStatus GetItemById(Int32 maintenanceTypeId)
		{
			foreach (OpsStatus t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;

			return null;
		}

		#endregion

		#region static public CommonDictionaryCollection<DayofWeek> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<OpsStatus> Items
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
			return $"{FullName}";
		}
		#endregion

		/*
         * Реализация
         */
		#region public OpsStatus()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public OpsStatus()
		{
		}
		#endregion

		#region public OpsStatus(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public OpsStatus(Int32 itemId, String fullName, String shortName)
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
			if (y is OpsStatus)
				return FullName.CompareTo(((OpsStatus)y).FullName);
			return 0;
		}
		#endregion
	}
}