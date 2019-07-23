using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DirectiveReason : StaticDictionary
	{
		#region private static List<DirectiveReason> _Items = new List<DirectiveReason>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DirectiveReason> _Items = new CommonDictionaryCollection<DirectiveReason>();
		#endregion


		public static DirectiveReason Affects = new DirectiveReason(1, "Affects", "Affects");
		public static DirectiveReason Removes = new DirectiveReason(2, "Removes", "Removes");
		public static DirectiveReason Replaces = new DirectiveReason(3, "Replaces", "Replaces");
		public static DirectiveReason Revises = new DirectiveReason(4, "Revises", "Revises");
		public static DirectiveReason Supersedes = new DirectiveReason(5, "Supersedes", "Supersedes");
		public static DirectiveReason Unknown = new DirectiveReason(-1, "N/A", "N/A");


		/*
		 * Методы
		 */

		#region public static DirectiveReason GetDocumentTypeById(Int32 DocumentTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="documentTypeId"></param>
		/// <returns></returns>
		public static DirectiveReason GetDirectiveReasonById(int documentTypeId)
		{
			for (int i = 0; i < _Items.Count; i++)
				if (_Items[i].ItemId == documentTypeId)
					return _Items[i];
			//
			return Unknown;
		}
		#endregion

		#region static public List<DirectiveReason> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DirectiveReason> Items
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

		#region public DirectiveReason(Int16 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DirectiveReason(short itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}
		#endregion

		#region public DocumentType()

		public DirectiveReason()
		{

		}

		#endregion

	}
}