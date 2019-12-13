using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Designation : StaticDictionary
	{
		#region private static CommonDictionaryCollection<Designation> _Items = new CommonDictionaryCollection<Designation>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Designation> _Items = new CommonDictionaryCollection<Designation>();
		#endregion


		public static Designation Purchase = new Designation(1, "Purchase", "1 - Purchase");
		public static Designation Exchange = new Designation(2, "Exchange", "2 - Exchange");
		public static Designation PurchaseConsumablesWithout = new Designation(3, "Purchase of consumables without S/N", "3 - Purchase of consumables without S/N");
		public static Designation TechnicalServices = new Designation(4, "Technical services", "4 - Technical services");
		public static Designation DocumentationOrder = new Designation(5, "Documentation Order", "5 - Documentation Order");
		public static Designation RepairOrder = new Designation(6, "Repair Order", "6 - Repair Order");
		public static Designation TransportationServices = new Designation(7, "Transportation services", "7 - Transportation services");
		public static Designation LoantOrRent = new Designation(8, "Loant or Rent", "8 - Loant or Rent");
		
		#region public static Designation UNK = new Designation(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static Designation UNK = new Designation(-1, "N/A", "Not applicable");
		#endregion

		/*
		 * Методы
		 */

		#region public static Designation GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static Designation GetItemById(Int32 maintenanceTypeId)
		{
			foreach (Designation t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<Designation> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Designation> Items
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
		#region public Designation()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public Designation()
		{
		}
		#endregion

		#region public Designation(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public Designation(Int32 itemId, String shortName, String fullName)
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
			if (y is Designation)
				return FullName.CompareTo(((Designation)y).FullName);
			return 0;
		}
		#endregion
	}
}