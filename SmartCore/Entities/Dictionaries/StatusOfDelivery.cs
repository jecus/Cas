using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class StatusOfDelivery : StaticDictionary
	{
		#region private static List<StatusOfDelivery> _Items = new List<StatusOfDelivery>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<StatusOfDelivery> _Items = new CommonDictionaryCollection<StatusOfDelivery>();
		#endregion


		#region public static StatusOfDelivery UNK = new StatusOfDelivery(-1, "UNK", "Unknown");

		public static StatusOfDelivery UNK = new StatusOfDelivery(-1, "UNK", "Unknown");

		#endregion

		public static StatusOfDelivery Sending = new StatusOfDelivery(1, "Sending", "Sending");
		public static StatusOfDelivery Sent = new StatusOfDelivery(2, "Sent", "Sent");
		public static StatusOfDelivery Transfer = new StatusOfDelivery(3, "Transfer", "Transfer");
		public static StatusOfDelivery Delivered = new StatusOfDelivery(4, "Delivered", "Delivered");
		public static StatusOfDelivery OnCustoms = new StatusOfDelivery(5, "On Customs", "On Customs");
		public static StatusOfDelivery OnStock = new StatusOfDelivery(6, "On Stock", "On Stock");

		/*
		 * Методы
		 */
		#region public static StatusOfDelivery GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static StatusOfDelivery GetItemById(Int32 maintenanceTypeId)
		{
			foreach (StatusOfDelivery t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<StatusOfDelivery> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<StatusOfDelivery> Items
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
		#region public StatusOfDelivery()
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		public StatusOfDelivery()
		{
		}
		#endregion

		#region public StatusOfDelivery(Int32 itemID, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public StatusOfDelivery(Int32 itemId, String shortName, String fullName)
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
			if (y is StatusOfDelivery)
				return FullName.CompareTo(((StatusOfDelivery)y).FullName);
			return 0;
		}
		#endregion
	}
}