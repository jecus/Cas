using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DocumentClass : StaticDictionary
	{
		#region private static List<DocumentClass> _Items = new List<DocumentClass>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DocumentClass> _Items = new CommonDictionaryCollection<DocumentClass>();
		#endregion


		public static DocumentClass Inbox = new DocumentClass(1, "Inbox", "Inbox");
		public static DocumentClass Outbox = new DocumentClass(2, "Outbox", "Outbox");
		public static DocumentClass InternalDoc = new DocumentClass(3, "Internal documents", "Internal documents");
		public static DocumentClass Unknown = new DocumentClass(-1, "Unknown", "Unknown");


		/*
         * Методы
         */

		#region public static DocumentClass GetDocumentTypeById(Int32 DocumentTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="documentTypeId"></param>
		/// <returns></returns>
		public static DocumentClass GetDocumentClassById(int documentTypeId)
		{
			for (int i = 0; i < _Items.Count; i++)
				if (_Items[i].ItemId == documentTypeId)
					return _Items[i];
			//
			return Unknown;
		}
		#endregion
		#region static public List<DocumentClass> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DocumentClass> Items
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

		#region public DocumentClass(Int16 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DocumentClass(short itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}
		#endregion

		#region public DocumentType()

		public DocumentClass()
		{

		}

		#endregion

	}
}