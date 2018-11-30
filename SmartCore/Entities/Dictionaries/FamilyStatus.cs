using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class FamilyStatus : StaticDictionary
	{
		#region private static List<FamilyStatus> _Items = new List<FamilyStatus>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<FamilyStatus> _Items = new CommonDictionaryCollection<FamilyStatus>();
		#endregion


		#region public static FamilyStatus UNK = new FamilyStatus(-1, "UNK", "Unknown");

		public static FamilyStatus UNK = new FamilyStatus(-1, "UNK", "Unknown");

		#endregion

		public static FamilyStatus Married = new FamilyStatus(1, "Married", "Married");
		public static FamilyStatus MarrieChild = new FamilyStatus(2, "Married, child", "Married, child");
		public static FamilyStatus MarriedChildren = new FamilyStatus(3, "Married, children", "Married, children");
		public static FamilyStatus Single = new FamilyStatus(4, "Single", "Single");
		public static FamilyStatus SingleChild = new FamilyStatus(5, "Single, child", "Single, child");
		public static FamilyStatus SingleChildren = new FamilyStatus(6, "Single, children", "Single, children");

		/*
         * Методы
         */
		#region public static FamilyStatus GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static FamilyStatus GetItemById(Int32 maintenanceTypeId)
		{
			foreach (FamilyStatus t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<FamilyStatus> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<FamilyStatus> Items
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
		#region public FamilyStatus()
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		public FamilyStatus()
		{
		}
		#endregion

		#region public FamilyStatus(Int32 itemID, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public FamilyStatus(Int32 itemId, String shortName, String fullName)
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
			if (y is FamilyStatus)
				return FullName.CompareTo(((FamilyStatus)y).FullName);
			return 0;
		}
		#endregion


	}
}