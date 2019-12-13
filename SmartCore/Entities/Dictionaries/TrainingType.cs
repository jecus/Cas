using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class TrainingType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<TrainingType> _Items = new CommonDictionaryCollection<TrainingType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<TrainingType> _Items = new CommonDictionaryCollection<TrainingType>();
		#endregion

		#region public static TrainingType Unknown = new TrainingType(-1, "Unknown", "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static TrainingType Unknown = new TrainingType(-1, "Unknown", "Unknown", "Unknown");
		#endregion

		#region public static TrainingType BaseTraining = new TrainingType(1, "Base training", "Base training", "Base training");

		public static TrainingType BaseTraining = new TrainingType(1, "Base Training", "Base Training", "Base Training");

		#endregion

		#region public static TrainingType RegularityTraining = new TrainingType(2, "Regularity training", "Regularity training", "Regularity training");

		public static TrainingType RegularityTraining = new TrainingType(2, "Regularity Training", "Regularity Training", "Regularity Training");


		#endregion

		/*
		* Методы
		*/

		#region public static TrainingType GetDirectiveTypeById(Int32 TrainingTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="directiveTypeId"></param>
		/// <returns></returns>
		public static TrainingType GetDirectiveTypeById(Int32 directiveTypeId)
		{
			foreach (TrainingType t in _Items)
				if (t.ItemId == directiveTypeId)
					return t;
			//
			return Unknown;
		}

		#endregion

		#region static public CommonDictionaryCollection<DirectiveType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<TrainingType> Items
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

		#region public TrainingType()
		/// <summary>
		/// Конструктор создает объект по умолчанию
		/// </summary>
		public TrainingType()
		{
		}
		#endregion

		#region public TrainingType(Int32 ItemId, String shortName, String fullName, String commonName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="commonName"></param>
		public TrainingType(Int32 itemId, String shortName, String fullName, String commonName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			CommonName = commonName;

			_Items.Add(this);
		}
		#endregion

	}
}
