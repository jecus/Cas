using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Check
{
    [Serializable]
    public class RoutineObject : StaticDictionary
    {
        #region public static CommonDictionaryCollection<RoutineObject> _Items = new CommonDictionaryCollection<RoutineObject>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<RoutineObject> _Items = new CommonDictionaryCollection<RoutineObject>();
        #endregion

        public static RoutineObject CAT = new RoutineObject(1, "CAT", "CAT", "");
        public static RoutineObject CATSPO = new RoutineObject(2, "CAT SPO", "CAT SPO", "");
        public static RoutineObject NC = new RoutineObject(3, "NC", "NC", "");
        public static RoutineObject NCSPO = new RoutineObject(4, "NC SPO", "NC SPO", "");
        public static RoutineObject AMO = new RoutineObject(5, "AMO", "AMO", "");
        public static RoutineObject CAMO = new RoutineObject(6, "CAMO", "CAMO", "");
        public static RoutineObject CAO = new RoutineObject(7, "CAO", "CAO", "");
        public static RoutineObject Airodrome = new RoutineObject(8, "Airodrome", "Airodrome", "");
        public static RoutineObject ATSANS = new RoutineObject(9, "ATS/ANS", "ATS/ANS", "");
        public static RoutineObject Fuel = new RoutineObject(10, "Fuel", "Fuel", "");
        public static RoutineObject AeMC = new RoutineObject(11, "AeMC", "AeMC", "");
        public static RoutineObject ATO = new RoutineObject(12, "ATO", "ATO", "");
        public static RoutineObject Unknown = new RoutineObject(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static RoutineObject GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static RoutineObject GetItemById(int directiveTypeId)
        {
            foreach (RoutineObject t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<RoutineObject> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<RoutineObject> Items
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
        * Свойства
        */

        /*
         * Реализация
         */
        #region public RoutineObject()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public RoutineObject()
        {
        }
        #endregion

        #region public RoutineObject(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public RoutineObject(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
	}
}
