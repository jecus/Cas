using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DirectiveAffects : StaticDictionary
	{
		#region private static List<DirectiveAffects> _Items = new List<DirectiveAffects>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DirectiveAffects> _Items = new CommonDictionaryCollection<DirectiveAffects>();
		#endregion

		public static DirectiveAffects Unknown = new DirectiveAffects(-1, "Unknown", "Unknown");


		/*
		 * Методы
		 */

		#region public static DirectiveAffects GetDocumentTypeById(Int32 DocumentTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="documentTypeId"></param>
		/// <returns></returns>
		public static DirectiveAffects GetDirectiveAffectsById(int documentTypeId)
		{
			for (int i = 0; i < _Items.Count; i++)
				if (_Items[i].ItemId == documentTypeId)
					return _Items[i];
			//
			return Unknown;
		}
		#endregion

		#region static public List<DirectiveAffects> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DirectiveAffects> Items
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

		#region public DirectiveAffects(Int16 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DirectiveAffects(short itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}
		#endregion

		#region public DocumentType()

		public DirectiveAffects()
		{

		}

		#endregion

	}
}