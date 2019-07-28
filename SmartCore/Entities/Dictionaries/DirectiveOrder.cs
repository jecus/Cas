using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DirectiveOrder : StaticDictionary
	{
		#region private static List<DirectiveOrder> _Items = new List<DirectiveOrder>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DirectiveOrder> _Items = new CommonDictionaryCollection<DirectiveOrder>();
		#endregion


		public static DirectiveOrder Reopened = new DirectiveOrder(1, "Task Card Controlled", "Task Card Controlled");
		public static DirectiveOrder InformationOnly = new DirectiveOrder(2, "Information only", "Information only");
		public static DirectiveOrder Canceled = new DirectiveOrder(3, "Canceled", "Canceled");
		public static DirectiveOrder ExFactory = new DirectiveOrder(4, "Ex-Factory", "Ex-Factory");
		public static DirectiveOrder Terminated = new DirectiveOrder(5, "Terminated", "Terminated");
		public static DirectiveOrder PerformedPreviousOperator = new DirectiveOrder(6, "Performed by Previous Operator", "Performed by Previous Operator");
		public static DirectiveOrder Unknown = new DirectiveOrder(-1, "N/A", "N/A");


		/*
         * Методы
         */

		#region public static DirectiveOrder GetDocumentTypeById(Int32 DocumentTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="documentTypeId"></param>
		/// <returns></returns>
		public static DirectiveOrder GetDirectiveOrderById(int documentTypeId)
		{
			for (int i = 0; i < _Items.Count; i++)
				if (_Items[i].ItemId == documentTypeId)
					return _Items[i];
			//
			return Unknown;
		}
		#endregion

		#region static public List<DirectiveOrder> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DirectiveOrder> Items
		{
			get { return _Items; }
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

		#region public DirectiveOrder(Int16 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DirectiveOrder(short itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}
		#endregion

		#region public DocumentType()

		public DirectiveOrder()
		{

		}

		#endregion

	}
}