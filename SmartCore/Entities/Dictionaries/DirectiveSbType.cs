using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class DirectiveSbType : StaticDictionary
	{
		#region private static List<DirectiveSbType> _Items = new List<DirectiveSbType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<DirectiveSbType> _Items = new CommonDictionaryCollection<DirectiveSbType>();
		#endregion

		public static DirectiveSbType Mandatory = new DirectiveSbType(1, "Mandatory", "Mandatory");
		public static DirectiveSbType Recommended = new DirectiveSbType(2, "Recommended", "Recommended");
		public static DirectiveSbType Alert = new DirectiveSbType(3, "Alert", "Alert");
		public static DirectiveSbType Optional = new DirectiveSbType(4, "Optional", "Optional");
		public static DirectiveSbType Unknown = new DirectiveSbType(-1, "N/A", "N/A");


		/*
		 * Методы
		 */

		#region public static DirectiveSbType GetDocumentTypeById(Int32 DocumentTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="documentTypeId"></param>
		/// <returns></returns>
		public static DirectiveSbType GetDirectiveSbTypeById(int documentTypeId)
		{
			for (int i = 0; i < _Items.Count; i++)
				if (_Items[i].ItemId == documentTypeId)
					return _Items[i];
			//
			return Unknown;
		}
		#endregion

		#region static public List<DirectiveSbType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<DirectiveSbType> Items
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

		#region public DirectiveSbType(Int16 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public DirectiveSbType(short itemId, string shortName, string fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_Items.Add(this);
		}
		#endregion

		#region public DocumentType()

		public DirectiveSbType()
		{

		}

		#endregion

	}
}