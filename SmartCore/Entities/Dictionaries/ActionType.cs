using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class ActionType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<ActinType> _Items = new CommonDictionaryCollection<ActinType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ActionType> _Items = new CommonDictionaryCollection<ActionType>();
		#endregion


		#region public static ActinType UNK = new ActinType(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static ActionType UNK = new ActionType(-1, "N/A", "Not applicable");
		#endregion


		public static ActionType Borescope = new ActionType(24, "BI", "Borescope");
		public static ActionType Clean = new ActionType(30, "Clean", "Clean");
		public static ActionType DetailedInspection = new ActionType(14, "DET", "Detailed Inspection");
		public static ActionType GeneralVisualInspection = new ActionType(15, "GVI", "General Visual Inspection");
		public static ActionType Inspection = new ActionType(5, "INSP", "Inspection");
		public static ActionType LeakTest = new ActionType(28, "Leak Test", "Leak Test");
		public static ActionType Lubricate = new ActionType(8, "LUB", "Lubricate");
		public static ActionType NDT = new ActionType(25, "NDT", "NDT");
		public static ActionType OperationalCheck = new ActionType(18, "OPC", "Operational Check");
		public static ActionType Repair = new ActionType(26, "Repair", "Repair");
		public static ActionType Replace = new ActionType(100, "RL", "Replace");
		public static ActionType Test = new ActionType(27, "Test", "Test");
		public static ActionType Service = new ActionType(7, "SVC", "Service");

		/*
         * Методы
         */

		#region public static ActinType GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static ActionType GetItemById(Int32 maintenanceTypeId)
		{
			foreach (ActionType t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<ActinType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ActionType> Items
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
		#region public ActinType()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public ActionType()
		{
		}
		#endregion

		#region public ActinType(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public ActionType(Int32 itemId, String shortName, String fullName)
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
			if (y is ActionType)
				return FullName.CompareTo(((ActionType)y).FullName);
			return 0;
		}
		#endregion
	}
}