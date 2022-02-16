using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Check
{
    [Serializable]
    public class Option : StaticDictionary
    {
        #region public static CommonDictionaryCollection<Option> _Items = new CommonDictionaryCollection<Option>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Option> _Items = new CommonDictionaryCollection<Option>();
        #endregion

        public static Option One = new Option(1, "1", "1", "");
        public static Option Two = new Option(2, "2", "2", "");
        public static Option Three = new Option(3, "3", "3", "");
        public static Option Headquarters = new Option(4, "Headquarters", "Headquarters", "");
        public static Option Stations = new Option(5, "Stations", "Stations", "");
        public static Option Unknown = new Option(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static Option GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static Option GetItemById(int directiveTypeId)
        {
            foreach (Option t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<Option> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Option> Items
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
        #region public Option()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public Option()
        {
        }
        #endregion

        #region public Option(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public Option(Int32 itemID, String shortName, String fullName, String commonName)
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
