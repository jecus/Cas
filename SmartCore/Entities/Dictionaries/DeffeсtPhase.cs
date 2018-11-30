using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class DeffeсtPhase : StaticDictionary
	{
		#region private static CommonDictionaryCollection<DeffeсtPhase> _Items = new CommonDictionaryCollection<DeffeсtPhase>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DeffeсtPhase> _Items = new CommonDictionaryCollection<DeffeсtPhase>();
		#endregion


		public static DeffeсtPhase Parked = new DeffeсtPhase(1, "Parked", "Parked");
		public static DeffeсtPhase Pushback = new DeffeсtPhase(2, "Pushback", "Pushback");
		public static DeffeсtPhase Taxi = new DeffeсtPhase(3, "Taxi", "Taxi");
		public static DeffeсtPhase RunUpPoint = new DeffeсtPhase(4, "RunUpPoint", "RunUpPoint");
		public static DeffeсtPhase TakeOff = new DeffeсtPhase(5, "TakeOff", "TakeOff");
		public static DeffeсtPhase Climb = new DeffeсtPhase(6, "Climb", "Climb");
		public static DeffeсtPhase Cruise = new DeffeсtPhase(7, "Cruise", "Cruise");
		public static DeffeсtPhase Descent = new DeffeсtPhase(8, "Descent", "Descent");
		public static DeffeсtPhase Approach = new DeffeсtPhase(9, "Approach", "Approach");
		public static DeffeсtPhase AdditionalRound = new DeffeсtPhase(10, "AdditionalRound", "AdditionalRound");
		public static DeffeсtPhase Landing = new DeffeсtPhase(11, "Landing", "Landing");
		public static DeffeсtPhase Mileage = new DeffeсtPhase(12, "Mileage", "Mileage");
		public static DeffeсtPhase LTaxi = new DeffeсtPhase(13, "LTaxi", "LTaxi");
		public static DeffeсtPhase Stop = new DeffeсtPhase(14, "Stop", "Stop");

		#region public static DeffeсtPhase UNK = new DeffeсtPhase(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static DeffeсtPhase UNK = new DeffeсtPhase(-1, "N/A", "Not applicable");
		#endregion

		/*
         * Методы
         */

		#region public static DeffeсtPhase GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static DeffeсtPhase GetItemById(Int32 maintenanceTypeId)
		{
			foreach (DeffeсtPhase t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<DeffeсtPhase> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DeffeсtPhase> Items
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
		#region public DeffeсtPhase()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public DeffeсtPhase()
		{
		}
		#endregion

		#region public DeffeсtPhase(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DeffeсtPhase(Int32 itemId, String shortName, String fullName)
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
			if (y is DeffeсtPhase)
				return FullName.CompareTo(((DeffeсtPhase)y).FullName);
			return 0;
		}
		#endregion
	}
}