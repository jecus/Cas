using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    [Serializable]
    public class Privileges : StaticDictionary
    {
        #region public static CommonDictionaryCollection<Privileges> _Items = new CommonDictionaryCollection<Privileges>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Privileges> _Items = new CommonDictionaryCollection<Privileges>();
        #endregion

        public static Privileges Pilot = new Privileges(1, "Pilot", "Pilot", "");
        public static Privileges Cabincrew = new Privileges(2, "Cabin crew", "Cabin crew", "");
        public static Privileges Dispatcher = new Privileges(3, "Dispatcher", "Dispatcher", "");
        public static Privileges Technician = new Privileges(4, "Technician", "Technician", "");
        public static Privileges Other = new Privileges(5, "Other", "Other", "");
        public static Privileges Unknown = new Privileges(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static Privileges GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static Privileges GetItemById(int directiveTypeId)
        {
            foreach (Privileges t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<Privileges> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Privileges> Items
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
        #region public Privileges()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public Privileges()
        {
        }
        #endregion

        #region public Privileges(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public Privileges(Int32 itemID, String shortName, String fullName, String commonName)
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
