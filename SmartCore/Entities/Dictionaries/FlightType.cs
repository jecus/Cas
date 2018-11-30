using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class FlightType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<FlightType> _Items = new CommonDictionaryCollection<FlightType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<FlightType> _Items = new CommonDictionaryCollection<FlightType>();
		#endregion
		/*
         * Реализация
         */
		#region static public CommonDictionaryCollection<FlightType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<FlightType> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		public static FlightType AerialWork = new FlightType(1, "AerialWork", "AerialWork", "UnShedule");
		public static FlightType Charter = new FlightType(2, "Charter", "Charter", "UnShedule");
		public static FlightType Ferry = new FlightType(3, "Ferry", "Ferry", "UnShedule");
		public static FlightType MilitaryTransport = new FlightType(5, "MilitaryTransport", "MilitaryTransport", "UnShedule");
		public static FlightType Private = new FlightType(6, "Private", "Private", "UnShedule");
		public static FlightType Rescue = new FlightType(8, "Rescue", "Rescue", "UnShedule");
		public static FlightType Special = new FlightType(9, "Special", "Special", "UnShedule");
		public static FlightType Test = new FlightType(10, "Test", "Test", "UnShedule");
		public static FlightType Training = new FlightType(11, "Training", "Training", "UnShedule");
		public static FlightType Position = new FlightType(12, "Position", "Position", "UnShedule");
		public static FlightType Deposition = new FlightType(13, "Deposition", "Deposition", "UnShedule");
		public static FlightType Schedule = new FlightType(14, "Schedule", "Schedule", "Shedule");

		#region public static FlightType UNK = new FlightType(-1, "UNK", "Unknown");
		/// <summary>
		/// 
		/// </summary>
		public static FlightType UNK = new FlightType(-1, "UNK", "Unknown", "UNK");
		#endregion

		/*
		* Методы
		*/

		#region public FlightType()

		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public FlightType()
		{
		}

		#endregion

		#region public FlightType(String shortName, String fullName)

		/// <summary>
		/// Конструктор принимает псевдоним и полное имя статуса
		/// </summary>
		/// <param name="recordTypeId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public FlightType(Int32 recordTypeId, String shortName, String fullName, string recoredType)
		{
			ShortName = shortName;
			FullName = fullName;
			ItemId = recordTypeId;
			RecoredType = recoredType;
			_Items.Add(this);
		}

		public string RecoredType { get; set; }

		#endregion

		#region public override string ToString()
		/// <summary>
		/// Возвращает полное имя объекта
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FullName;
		}

		#endregion

		#region public static FlightType GetItemById(Int32 conditionStateId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="conditionStateId"></param>
		/// <returns></returns>
		public static FlightType GetItemById(Int32 conditionStateId)
		{
			foreach (FlightType t in _Items)
				if (t.ItemId == conditionStateId)
					return t;
			//
			return UNK;
		}

		#endregion
	}
}