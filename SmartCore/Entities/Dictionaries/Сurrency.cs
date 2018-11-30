using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class Сurrency : StaticDictionary
	{
		#region private static CommonDictionaryCollection<Сurrency> _Items = new CommonDictionaryCollection<Сurrency>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<Сurrency> _Items = new CommonDictionaryCollection<Сurrency>();
		#endregion

		public static Сurrency AUD = new Сurrency(1, "AUD", "AUD");
		public static Сurrency GBP = new Сurrency(2, "GBP", "GBP");
		public static Сurrency BYN = new Сurrency(3, "BYN", "BYN");
		public static Сurrency DKK = new Сurrency(4, "DKK", "DKK");
		public static Сurrency USD = new Сurrency(5, "USD", "USD");
		public static Сurrency EUR = new Сurrency(6, "EUR", "EUR");
		public static Сurrency KZT = new Сurrency(7, "KZT", "KZT");
		public static Сurrency CAD = new Сurrency(8, "CAD", "CAD");
		public static Сurrency CNY = new Сurrency(9, "CNY", "CNY");
		public static Сurrency NOK = new Сurrency(10, "NOK", "NOK");
		public static Сurrency XDR = new Сurrency(11, "XDR", "XDR");
		public static Сurrency SGD = new Сurrency(12, "SGD", "SGD");
		public static Сurrency TRY = new Сurrency(13, "TRY", "TRY");
		public static Сurrency UAH = new Сurrency(14, "UAH", "UAH");
		public static Сurrency SEK = new Сurrency(15, "SEK", "SEK");
		public static Сurrency CHF = new Сurrency(16, "CHF", "CHF");
		public static Сurrency JPY = new Сurrency(17, "JPY", "JPY");
		public static Сurrency AZN = new Сurrency(18, "AZN", "AZN");
		public static Сurrency AMD = new Сurrency(19, "AMD", "AMD");
		public static Сurrency BGN = new Сurrency(20, "BGN", "BGN");
		public static Сurrency BRL = new Сurrency(21, "BRL", "BRL");
		public static Сurrency HUF = new Сurrency(22, "HUF", "HUF");
		public static Сurrency INR = new Сurrency(23, "INR", "INR");
		public static Сurrency KGS = new Сurrency(24, "KGS", "KGS");
		public static Сurrency MDL = new Сurrency(25, "MDL", "MDL");
		public static Сurrency PLN = new Сurrency(26, "PLN", "PLN");
		public static Сurrency RON = new Сurrency(27, "RON", "RON");
		public static Сurrency TJS = new Сurrency(28, "TJS", "TJS");
		public static Сurrency TMT = new Сurrency(29, "TMT", "TMT");
		public static Сurrency UZS = new Сurrency(30, "UZS", "UZS");
		public static Сurrency CZK = new Сurrency(31, "CZK", "CZK");
		public static Сurrency ZAR = new Сurrency(32, "ZAR", "ZAR");
		public static Сurrency KRW = new Сurrency(33, "KRW", "KRW");


		#region public static HumanDamage UNK = new HumanDamage(-1, "UNK", "Unknown", 0);
		/// <summary>
		/// неизвестный
		/// </summary>
		public static Сurrency UNK = new Сurrency(-1, "UNK", "Unknown");
		#endregion

		#region public static Сurrency GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static Сurrency GetItemById(Int32 maintenanceTypeId)
		{
			foreach (Сurrency t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<HumanDamage> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<Сurrency> Items
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
		#region public Сurrency()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public Сurrency()
		{
		}
		#endregion

		#region public Сurrency(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public Сurrency(Int32 itemId, String shortName, String fullName)
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
			if (y is Сurrency)
				return FullName.CompareTo(((Сurrency)y).FullName);
			return 0;
		}
		#endregion

	}
}