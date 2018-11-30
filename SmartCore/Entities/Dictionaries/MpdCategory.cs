using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class MpdCategory : StaticDictionary
	{
		#region private static CommonDictionaryCollection<MpdCategory> _Items = new CommonDictionaryCollection<MpdCategory>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<MpdCategory> _Items = new CommonDictionaryCollection<MpdCategory>();
		#endregion

		public static MpdCategory EvidentSafety = new MpdCategory(5, "5 - Evident, Safety", "5 - Evident, Safety");
		public static MpdCategory EvidentEconomicOperational = new MpdCategory(6, "6 - Evident, Economic (Operational)", "6 - Evident, Economic (Operational)");
		public static MpdCategory EvidentEconomicNonOperational = new MpdCategory(7, "7 - Evident, Economic (Non-Operational)", "7 - Evident, Economic (Non-Operational)");
		public static MpdCategory HiddenSafety = new MpdCategory(8, "8 - Hidden, Safety", "8 - Hidden, Safety");
		public static MpdCategory HiddenNonSafety = new MpdCategory(9, "9 - Hidden, Non-Safety", "9 - Hidden, Non-Safety");
		public static MpdCategory Regulatory = new MpdCategory(0, "0 - Regulatory Authority required task (no supporting MSG-3 data available in this category)", "0 - Regulatory Authority required task (no supporting MSG-3 data available in this category)");

		#region public static MpdCategory UNK = new MpdCategory(-1, "UNK", "Unknown");

		public static MpdCategory UNK = new MpdCategory(-1, "N/A", "N/A");

		#endregion

		/*
         * Методы
         */

		#region public static CommonDictionaryCollection<MpdCategory> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<MpdCategory> Items
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
		public static MpdCategory GetItemById(Int32 conditionStateId)
		{
			foreach (MpdCategory t in _Items)
				if (t.ItemId == conditionStateId)
					return t;

			return UNK;
		}

		#endregion

		/*
         * Реализация
         */
		#region public MpdCategory()

		/// <summary>
		/// Пустой крнструктор
		/// </summary>
		public MpdCategory()
		{

		}

		#endregion

		#region public MpdCategory(Int32 itemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public MpdCategory(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}

		#endregion
	}
}