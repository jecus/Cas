using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Skill : StaticDictionary
	{
		#region private static CommonDictionaryCollection<Skill> _Items = new CommonDictionaryCollection<Skill>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Skill> _Items = new CommonDictionaryCollection<Skill>();
		#endregion

		public static Skill B1 = new Skill(1, "B1", "B1");
		public static Skill B2 = new Skill(2, "B2", "B2");
		public static Skill B1B2 = new Skill(3, "B1 + B2", "B1 + B2");
		public static Skill NDT = new Skill(4, "NDT", "NDT");
		public static Skill AIRP = new Skill(5, "AIRP", "AIRP");
		public static Skill ELEC = new Skill(6, "ELEC", "ELEC");
		public static Skill AVION = new Skill(7, "AVION", "AVION");
		public static Skill ENGIN = new Skill(8, "ENGIN", "ENGIN");

		#region public static Skill UNK = new Skill(-1, "UNK", "Unknown");

		public static Skill UNK = new Skill(-1, "UNK", "Unknown");

		#endregion

		/*
         * Методы
         */

		#region public static CommonDictionaryCollection<Skill> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Skill> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		#region public override string ToString()

		/// <summary>
		/// Возвращает Name
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FullName;
		}

		#endregion

		#region public static NDTType GetItemById(Int32 conditionStateId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="conditionStateId"></param>
		/// <returns></returns>
		public static Skill GetItemById(Int32 conditionStateId)
		{
			foreach (Skill t in _Items)
				if (t.ItemId == conditionStateId)
					return t;

			return UNK;
		}

		#endregion

		/*
         * Реализация
         */
		#region public Skill()

		/// <summary>
		/// Пустой крнструктор
		/// </summary>
		public Skill()
		{

		}

		#endregion

		#region public Skill(Int32 itemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public Skill(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}

		#endregion
	}
}