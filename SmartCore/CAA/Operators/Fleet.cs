using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    [Serializable]
    public class Fleet : StaticDictionary
    {
        #region public static CommonDictionaryCollection<Fleet> _Items = new CommonDictionaryCollection<Fleet>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Fleet> _Items = new CommonDictionaryCollection<Fleet>();
        #endregion

        public static Fleet Aircraft = new Fleet(1, "Aircraft", "Aircraft", "");
        public static Fleet Helicopter = new Fleet(2, "Helicopter", "Helicopter", "");
        public static Fleet Ballon = new Fleet(3, "Ballon", "Ballon", "");
        public static Fleet Unmannedaircraft = new Fleet(4, "Unmanned aircraft", "Unmanned aircraft", "");
        public static Fleet Sailpnane = new Fleet(5, "Sailpnane", "Sailpnane", "");
        public static Fleet Other = new Fleet(6, "Other", "Other", "");
        public static Fleet Unknown = new Fleet(-1, "Unknown", "Unknown", "Unknown");
        
        /*
         * Методы
         */

        #region public static Fleet GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static Fleet GetItemById(int directiveTypeId)
        {
            foreach (Fleet t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<Fleet> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Fleet> Items
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
        #region public Fleet()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public Fleet()
        {
        }
        #endregion

        #region public Fleet(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public Fleet(Int32 itemID, String shortName, String fullName, String commonName)
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
