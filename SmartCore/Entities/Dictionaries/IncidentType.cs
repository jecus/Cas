using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	/// <summary>
	/// Тип инцидента в системе безопасности полетов
	/// </summary>
	[Serializable]
	public class IncidentType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<IncidentType> _Items = new CommonDictionaryCollection<IncidentType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<IncidentType> _Items = new CommonDictionaryCollection<IncidentType>();
		#endregion

		/*
		 * Предопределенные типы
		 */

		#region public static IncidentType NotSeriousAir = new IncidentType(1, "NSA", "Incident air");
		/// <summary>
		/// не серьезный
		/// </summary>
		public static IncidentType NotSeriousAir = new IncidentType(1, "NSA", "Incident air");
		#endregion

		#region public static IncidentType NotSeriousGround = new IncidentType(2, "NSG", "Incident ground");
		/// <summary>
		/// не серьезный
		/// </summary>
		public static IncidentType NotSeriousGround = new IncidentType(2, "NSG", "Incident ground");
		#endregion

		#region public static IncidentType Serious = new IncidentType(3, "SA", "Serious incident Air");
		/// <summary>
		/// серьёзный
		/// </summary>
		public static IncidentType Serious = new IncidentType(3, "SA", "Serious incident Air");
		#endregion

		#region public static IncidentType SeriousGround = new IncidentType(4, "SG", "Serious incident ground");
		/// <summary>
		/// серьезный
		/// </summary>
		public static IncidentType SeriousGround = new IncidentType(4, "SG", "Serious incident ground");
		#endregion

		#region public static IncidentType AccidentGround = new IncidentType(5, "AG", "Accident ground");
		/// <summary>
		/// Авиационное происшествие на земле
		/// </summary>
		public static IncidentType AccidentGround = new IncidentType(5, "AG", "Accident ground");
		#endregion

		#region public static IncidentType AccidentAir = new IncidentType(6, "AA", "Accident air");
		/// <summary>
		/// Авиационное происшествие в воздухе
		/// </summary>
		public static IncidentType AccidentAir = new IncidentType(6, "AA", "Accident air");
		#endregion

		#region public static IncidentType CatastropheGround = new IncidentType(7, "CG", "Catastrophe ground");
		/// <summary>
		/// Катастрофа на земле
		/// </summary>
		public static IncidentType CatastropheGround = new IncidentType(7, "CG", "Catastrophe ground");
		#endregion

		#region public static IncidentType CatastropheAir = new IncidentType(8, "CA", "Catastrophe air");
		/// <summary>
		/// Катастрофа в воздухе
		/// </summary>
		public static IncidentType CatastropheAir = new IncidentType(86, "CA", "Catastrophe air");
		#endregion
		public static IncidentType Occurence = new IncidentType(9, "Occurence", "Occurence");
		public static IncidentType AircraftDamageOnGround = new IncidentType(10, "ADOG", "Aircraft damage on ground");
		#region public static IncidentType UNK = new IncidentType(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static IncidentType UNK = new IncidentType(-1, "N/A", "None");
		#endregion

		/*
		 * Свойства 
		 */

		/*
		 * Методы
		 */

		#region public static IncidentType GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static IncidentType GetItemById(Int32 maintenanceTypeId)
		{
			foreach (IncidentType t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<IncidentType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<IncidentType> Items
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
		#region public IncidentType()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public IncidentType()
		{
		}
		#endregion

		#region public IncidentType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public IncidentType(Int32 itemId, String shortName, String fullName)
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
			if (y is IncidentType)
				return FullName.CompareTo(((IncidentType)y).FullName);
			return 0;
		}
		#endregion
	}
}
