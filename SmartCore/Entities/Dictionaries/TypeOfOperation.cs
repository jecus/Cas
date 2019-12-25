using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class TypeOfOperation : StaticDictionary
	{
		#region private static CommonDictionaryCollection<TypeOfOperation> _Items = new CommonDictionaryCollection<TypeOfOperation>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<TypeOfOperation> _Items = new CommonDictionaryCollection<TypeOfOperation>();
		#endregion

		public static TypeOfOperation One = new TypeOfOperation(1, "1", "");
		public static TypeOfOperation Two = new TypeOfOperation(2, "2", "");
		public static TypeOfOperation Three = new TypeOfOperation(3, "3", "");
		public static TypeOfOperation Four = new TypeOfOperation(4, "4", "");
		public static TypeOfOperation Five = new TypeOfOperation(5, "5", "");
		public static TypeOfOperation Six = new TypeOfOperation(6, "6", "");
		public static TypeOfOperation Seven = new TypeOfOperation(7, "7", "");

		#region public static TypeOfOperation UNK = new TypeOfOperation(-1, "N/A", "Not applicable");
		/// <summary>
		/// неизвестный
		/// </summary>
		public static TypeOfOperation UNK = new TypeOfOperation(-1, "N/A", "N/A");
		#endregion

		/*
	 * Методы
	 */

		#region public static TypeOfOperation GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static TypeOfOperation GetItemById(Int32 maintenanceTypeId)
		{
			foreach (TypeOfOperation t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<TypeOfOperation> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<TypeOfOperation> Items
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
			return ShortName;
		}
		#endregion

		/*
		 * Реализация
		 */
		#region public TypeOfOperation()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public TypeOfOperation()
		{
		}
		#endregion

		#region public TypeOfOperation(Int32 itemId, String shortName, String fullName)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public TypeOfOperation(Int32 itemId, String shortName, String fullName)
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
			if (y is TypeOfOperation)
				return FullName.CompareTo(((TypeOfOperation)y).FullName);
			return 0;
		}
		#endregion
	}
}