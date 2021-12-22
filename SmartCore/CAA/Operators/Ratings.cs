using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    public class Ratings : StaticDictionary
    {
        #region public static CommonDictionaryCollection<Ratings> _Items = new CommonDictionaryCollection<Ratings>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Ratings> _Items = new CommonDictionaryCollection<Ratings>();
        #endregion

        public static Ratings Airframe = new Ratings(1, "Airframe", "Airframe", "");
        public static Ratings Powerplant = new Ratings(2, "Powerplant", "Powerplant", "");
        public static Ratings Propeller = new Ratings(3, "Propeller", "Propeller", "");
        public static Ratings Avionics = new Ratings(4, "Avionics", "Avionics", "");
        public static Ratings Computers = new Ratings(5, "Computers", "Computers", "");
        public static Ratings Instruments = new Ratings(6, "Instruments", "Instruments", "");
        public static Ratings Accessory = new Ratings(7, "Accessory", "Accessory", "");
        public static Ratings Specializedservices = new Ratings(8, "Specialized services", "Specialized services", "");
        public static Ratings Other = new Ratings(9, "Other", "Other", "");
        public static Ratings Unknown = new Ratings(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static Ratings GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static Ratings GetItemById(int directiveTypeId)
        {
            foreach (Ratings t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<Ratings> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Ratings> Items
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
        #region public Ratings()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public Ratings()
        {
        }
        #endregion

        #region public Ratings(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public Ratings(Int32 itemID, String shortName, String fullName, String commonName)
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
