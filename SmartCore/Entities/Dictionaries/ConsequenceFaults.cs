using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class ConsequenceFaults : StaticDictionary
	{
		#region private static CommonDictionaryCollection<ConsequenceFaults> _Items = new CommonDictionaryCollection<ConsequenceFaults>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ConsequenceFaults> _Items = new CommonDictionaryCollection<ConsequenceFaults>();
		#endregion

		public static ConsequenceFaults None = new ConsequenceFaults(-1, "None", "None");
		public static ConsequenceFaults MEL = new ConsequenceFaults(1, "MEL procedure applied", "MEL procedure applied");
		public static ConsequenceFaults Aborted = new ConsequenceFaults(2, "Aborted take-off", "Aborted take-off");
		public static ConsequenceFaults Flight = new ConsequenceFaults(3, "Flight deviation", "Flight deviation");
		public static ConsequenceFaults Diverted = new ConsequenceFaults(4, "Diverted landing", "Diverted landing");
		public static ConsequenceFaults Aircraft = new ConsequenceFaults(5, "Aircraft Go Around", "Aircraft Go Around");
		public static ConsequenceFaults AircraftDamage = new ConsequenceFaults(6, "Aircraft damage", "Aircraft damage");
		public static ConsequenceFaults Diversion = new ConsequenceFaults(7, "Diversion", "Diversion");

		

		/*
         * Методы
         */

		#region public static ConsequenceFaults GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static ConsequenceFaults GetItemById(Int32 maintenanceTypeId)
		{
			foreach (ConsequenceFaults t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return None;
		}

		#endregion

		#region static public CommonDictionaryCollection<ConsequenceFaults> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ConsequenceFaults> Items
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
		#region public ConsequenceFaults()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public ConsequenceFaults()
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
		public ConsequenceFaults(Int32 itemId, String shortName, String fullName)
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
			if (y is ConsequenceFaults)
				return FullName.CompareTo(((ConsequenceFaults)y).FullName);
			return 0;
		}
		#endregion
	}
}