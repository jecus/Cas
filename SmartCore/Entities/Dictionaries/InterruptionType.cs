using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class InterruptionType : StaticDictionary
	{
		private string _code;
		private string _description;

		#region private static CommonDictionaryCollection<InterruptionType> _Items = new CommonDictionaryCollection<InterruptionType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<InterruptionType> _Items = new CommonDictionaryCollection<InterruptionType>();
		#endregion

		public static InterruptionType None = new InterruptionType(-1, "None", "None", "", "");
		public static InterruptionType Aircraft1 = new InterruptionType(1, "PLANNING", "PLANNING", "9", "Scheduled ground time ");
		public static InterruptionType Aircraft2 = new InterruptionType(2, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "41", "Aircraft defects");
		public static InterruptionType Aircraft3 = new InterruptionType(3, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "42", "Scheduled maintenance");
		public static InterruptionType Aircraft4 = new InterruptionType(4, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "43", "Non-scheduled maintenance");
		public static InterruptionType Aircraft5 = new InterruptionType(5, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "44", "Spares and maintenance equipment");
		public static InterruptionType Aircraft6 = new InterruptionType(6, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "45", "Aog spares");
		public static InterruptionType Aircraft7 = new InterruptionType(7, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "46", "Aircraft change for technical reason ");
		public static InterruptionType Aircraft8 = new InterruptionType(8, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "47", "Standby aircraft  ");
		public static InterruptionType Aircraft9 = new InterruptionType(9, "Technical & Aircraft Equipment ", "Technical & Aircraft Equipment ", "48", "Scheduled cabin configuration version adjustments ");
		public static InterruptionType Aircraft10 = new InterruptionType(10, "Aircraft Damage", "Aircraft Damage", "51", "Damage during flight operations ");
		public static InterruptionType Aircraft11 = new InterruptionType(11, "Aircraft Damage", "Aircraft Damage", "52", "Damage during ground operations ");
		public static InterruptionType Aircraft12 = new InterruptionType(12, "Aircraft Damage", "Aircraft Damage", "53", "Damage by previous statio or place / source of occurrence unknown ");

		/*
		 * Методы
		 */

		#region public static InterruptionType GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static InterruptionType GetItemById(Int32 maintenanceTypeId)
		{
			foreach (InterruptionType t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return None;
		}

		#endregion

		#region static public CommonDictionaryCollection<InterruptionType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<InterruptionType> Items
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
			var res = FullName;

			if (!string.IsNullOrEmpty(_code))
				res += $"| {_code}";
			if (!string.IsNullOrEmpty(_description))
				res += $"| {_description}";

			return res;
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public InterruptionType()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public InterruptionType()
		{
		}
		#endregion

		#region public InterruptionType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public InterruptionType(Int32 itemId, String shortName, String fullName, string code, string description)
		{
			_code = code;
			_description = description;
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is InterruptionType)
				return FullName.CompareTo(((InterruptionType)y).FullName);
			return 0;
		}
		#endregion
	}
}