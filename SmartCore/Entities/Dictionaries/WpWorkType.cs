using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class WpWorkType : StaticDictionary
	{
		#region private static List<WpWorkType> _Items = new List<WpWorkType>();

		private static List<WpWorkType> _Items = new List<WpWorkType>();

		#endregion

		public static WpWorkType Zero = new WpWorkType(1, "0 Phase", "0 Phase");
		public static WpWorkType A = new WpWorkType(2, "A Phase", "A Phase");
		public static WpWorkType C = new WpWorkType(3, "C Phase", "C Phase");
		public static WpWorkType HMV = new WpWorkType(4, "HMV", "HMV");

		#region public static WpWorkType Unknown = new WpWorkType(-1, "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static WpWorkType Unknown = new WpWorkType(-1, "Unknown", "Unknown");
		#endregion
		/*
		 * Методы
		 */

		#region public static WpWorkType GetComponentTypeById(int componentTypeId)
		/// <summary>
		/// Возвращает тип базового агрегата по его Id
		/// </summary>
		/// <param name="componentTypeId"></param>
		/// <returns></returns>
		public static WpWorkType GetComponentTypeById(int componentTypeId)
		{
			foreach (WpWorkType t in _Items)
				if (t.ItemId == componentTypeId)
					return t;
			//
			return Unknown;
		}

		#endregion

		#region public static List<WpWorkType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static List<WpWorkType> Items
		{
			get { return _Items; }
		}
		#endregion

		#region public override string ToString()
		/// <summary> 
		/// Представляет тип агрегата в виде строки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ShortName;
		}
		#endregion

		/*
		 * Свойства
		 */

		/*
		 * Реализация
		 */

		#region public WpWorkType()
		/// <summary>
		/// Конструктор создает объект по умолчанию
		/// </summary>
		public WpWorkType()
		{
		}
		#endregion

		#region public WpWorkType(Int32 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает запись о типе агрегата
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public WpWorkType(int itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			//if (_Items == null) _Items = new List<DetailType>();
			_Items.Add(this);
		}
		#endregion
	}
}