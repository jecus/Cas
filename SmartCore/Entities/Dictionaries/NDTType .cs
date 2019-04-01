using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
	[Serializable]
	public class NDTType : StaticDictionary
	{
		#region private static CommonDictionaryCollection<NDTType> _Items = new CommonDictionaryCollection<NDTType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<NDTType> _Items = new CommonDictionaryCollection<NDTType>();
		#endregion


		#region public static NDTType None = new NDTType(0, "None ", "None");

		public static NDTType None = new NDTType(0, "None", "None");

		#endregion

		public static NDTType UltraSonic = new NDTType(1, "Ultra Sonic", "Ultra Sonic ");

		#region public static NDTType LFEC = new NDTType(2, "LFEC ", "Low Frequiency Eddy Current");

		public static NDTType LFEC = new NDTType(2, "LFEC", "Low Frequiency Eddy Current");

		#endregion

		#region public static NDTType HFEC = new NDTType(3, "HFEC ", "High Frequiency Eddy Current");

		public static NDTType HFEC = new NDTType(3, "HFEC", "High Frequiency Eddy Current");

		#endregion

		#region public static NDTType HFEC_and_LFEC = new NDTType(4, "HFEC and LHEC", "HFEC and LHEC");

		public static NDTType HFEC_and_LFEC = new NDTType(4, "HFEC and LHEC", "HFEC and LHEC");

		#endregion

		#region public static NDTType EddyCurrent = new NDTType(5, "Eddy current", "Eddy current");

		public static NDTType EddyCurrent = new NDTType(5, "Eddy current", "Eddy current");

		#endregion

		#region public static NDTType Borescope = new NDTType(6, "Borescope", "Borescope");

		public static NDTType Borescope = new NDTType(6, "Borescope", "Borescope");

		#endregion

		#region public static NDTType Magnetic = new NDTType(7, "Magnetic", "Magnetic");

		public static NDTType Magnetic = new NDTType(7, "Magnetic", "Magnetic");

		#endregion

		#region public static NDTType MagneticPl = new NDTType(8, "Magnetic Particle/Leak", "Magnetic Particle/Leak");

		public static NDTType MagneticPl = new NDTType(8, "Magnetic Particle/Leak", "Magnetic Particle/Leak");

		#endregion

		#region public static NDTType Penetrant = new NDTType(9, "Penetrant", "Penetrant");

		public static NDTType Penetrant = new NDTType(9, "Penetrant", "Penetrant");

		#endregion

		#region public static NDTType Acoustic = new NDTType(10, "Acoustic Emmission/Visual", "Acoustic Emmission/Visual");

		public static NDTType Acoustic = new NDTType(10, "Acoustic Emmission/Visual", "Acoustic Emmission/Visual");

		#endregion

		#region public static NDTType Radiographic = new NDTType(11, "Radiographic", "Radiographic");

		public static NDTType Radiographic = new NDTType(11, "Radiographic", "Radiographic");

		#endregion

		#region public static NDTType XRay = new NDTType(12, "X-Ray", "X-Ray");

		public static NDTType XRay = new NDTType(12, "X-Ray", "X-Ray");

		#endregion

		#region public static NDTType UNK = new NDTType(-1, "UNK", "Unknown");

		public static NDTType UNK = new NDTType(-1, "UNK", "Unknown");

		#endregion

		/*
         * Методы
         */

		#region public static CommonDictionaryCollection<NDTType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<NDTType> Items
		{
			get
			{
				return _Items;
			}
		}
		#endregion

		#region public override string ToString()

		/// <summary>
		/// Возвращает Name
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FullName;
		}

		#endregion

		#region public static NDTType GetItemById(Int32 conditionStateId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="conditionStateId"></param>
		/// <returns></returns>
		public static NDTType GetItemById(Int32 conditionStateId)
		{
			foreach (NDTType t in _Items)
				if (t.ItemId == conditionStateId)
					return t;
			
			return UNK;
		}

		#endregion

		/*
         * Реализация
         */
		#region public NDTType()

		/// <summary>
		/// Пустой крнструктор
		/// </summary>
		public NDTType()
		{

		}

		#endregion

		#region public NDTType(Int32 itemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public NDTType(Int32 itemId, String shortName, String fullName)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;

			_Items.Add(this);
		}

		#endregion

	}
}
