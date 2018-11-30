using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	public class IncoTerm : StaticDictionary
	{
		#region private static CommonDictionaryCollection<IncoTerm> _Items = new CommonDictionaryCollection<IncoTerm>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<IncoTerm> _Items = new CommonDictionaryCollection<IncoTerm>();
		#endregion

		public static IncoTerm EXW = new IncoTerm(1, "EXW", "EXW");
		public static IncoTerm FCA = new IncoTerm(2, "FCA", "FCA");
		public static IncoTerm CPT = new IncoTerm(3, "CPT", "CPT");
		public static IncoTerm CIP = new IncoTerm(4, "CIP", "CIP");
		public static IncoTerm DAP = new IncoTerm(5, "DAP", "DAP");
		public static IncoTerm DAT = new IncoTerm(6, "DAT", "DAT");
		public static IncoTerm DDP = new IncoTerm(7, "DDP", "DDP");
		public static IncoTerm FAS = new IncoTerm(8, "FAS", "FAS");
		public static IncoTerm FOB = new IncoTerm(9, "FOB", "FOB");
		public static IncoTerm CFR = new IncoTerm(10, "CFR", "CFR");
		public static IncoTerm CIF = new IncoTerm(11, "CIF", "CIF");
		#region public static IncoTerm UNK = new IncoTerm(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static IncoTerm UNK = new IncoTerm(-1, "N/A", "N/A");
		#endregion

		/*
         * Методы
         */

		#region public static IncoTerm GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static IncoTerm GetItemById(Int32 maintenanceTypeId)
		{
			foreach (IncoTerm t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<IncoTerm> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<IncoTerm> Items
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
		#region public IncoTerm()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public IncoTerm()
		{
		}
		#endregion

		#region public IncoTerm(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public IncoTerm(Int32 itemId, String shortName, String fullName)
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
			if (y is IncoTerm)
				return FullName.CompareTo(((IncoTerm)y).FullName);
			return 0;
		}
		#endregion
	}
}