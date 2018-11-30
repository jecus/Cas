using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class CriticalSystemList : StaticDictionary
    {

        #region private static CommonDictionaryCollection<CriticalSystemList> _Items = new CommonDictionaryCollection<CriticalSystemList>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<CriticalSystemList> _Items = new CommonDictionaryCollection<CriticalSystemList>();
        #endregion

        /*
         * Предопределенные типы
         */

		public static CriticalSystemList AirConditioning = new CriticalSystemList(2, "Air conditioning", "Air conditioning", "");
		public static CriticalSystemList ElectricalPower = new CriticalSystemList(3, "Electrical power", "Electrical power", "");
		public static CriticalSystemList FireProtection = new CriticalSystemList(4, "Fire protection", "Fire protection", "");
		public static CriticalSystemList Fuel = new CriticalSystemList(5, "Fuel", "Fuel", "");
		public static CriticalSystemList Hydraulics = new CriticalSystemList(6, "Hydraulics", "Hydraulics", "");
		public static CriticalSystemList IceAndRain = new CriticalSystemList(7, "Ice and Rain", "Ice and Rain", "");
		public static CriticalSystemList Navigation = new CriticalSystemList(8, "Navigation", "Navigation", "");
		public static CriticalSystemList Pneumatics = new CriticalSystemList(9, "Pneumatics", "Pneumatics", "");
		public static CriticalSystemList AuxiliaryPower = new CriticalSystemList(10, "Auxiliary power", "Auxiliary power", "");
		public static CriticalSystemList Engines = new CriticalSystemList(11, "Engines", "Engines", "");

		#region public static CriticalSystemList Unknown = new CriticalSystemList(-1, "Unknown", "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static CriticalSystemList Unknown = new CriticalSystemList(-1, "N/A", "N/A", "N/A");
        #endregion

        /*
         * Методы
         */

        #region public static CriticalSystemList GetItemById(Int32 directiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static CriticalSystemList GetItemById(Int32 directiveTypeId)
        {
            foreach (CriticalSystemList t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<CriticalSystemList> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<CriticalSystemList> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is CriticalSystemList)
                return FullName.CompareTo(((CriticalSystemList)y).FullName);
            return 0;
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
        #region public CriticalSystemList()
        public CriticalSystemList()
        {

        }
        #endregion

        #region public CriticalSystemList(Int32 itemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public CriticalSystemList(Int32 itemId, String shortName, String fullName, String commonName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion

    }
}
