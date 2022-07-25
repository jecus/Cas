using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    [Serializable]
    public class SpecialOperations : StaticDictionary
    {
        #region public static CommonDictionaryCollection<SpecialOperations> _Items = new CommonDictionaryCollection<SpecialOperations>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<SpecialOperations> _Items = new CommonDictionaryCollection<SpecialOperations>();
        #endregion

        public static SpecialOperations Newsmedia = new SpecialOperations(1, "News media", "News media", "");
        public static SpecialOperations Flightinspection = new SpecialOperations(2, "Flight inspection", "Flight inspection", "");
        public static SpecialOperations Televisionandmovie = new SpecialOperations(3, "Television and movie", "Television and movie", "");
        public static SpecialOperations Parachuteoperation = new SpecialOperations(4, "Parachute operation", "Parachute operation", "");
        public static SpecialOperations Searchandrescue = new SpecialOperations(5, "Search and rescue", "Search and rescue", "");
        public static SpecialOperations Skydiving = new SpecialOperations(6, "Skydiving", "Skydiving", "");
        public static SpecialOperations Maintenancecheckflight = new SpecialOperations(7, "Maintenance check flight", "Maintenance check flight", "");
        public static SpecialOperations Medicalservice = new SpecialOperations(8, "Medical service", "Medical service", "");
        public static SpecialOperations Other = new SpecialOperations(9, "Other", "Other", "");
        public static SpecialOperations OtherAerialWork = new SpecialOperations(10, "Other aerial work", "Other aerial work", "");
        public static SpecialOperations Training = new SpecialOperations(11, "Training", "Training", "");
        public static SpecialOperations Sport = new SpecialOperations(12, "Sport", "Sport", "");
        public static SpecialOperations Acrobatic = new SpecialOperations(13, "Acrobatic", "Acrobatic", "");
        public static SpecialOperations Unknown = new SpecialOperations(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static SpecialOperations GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static SpecialOperations GetItemById(int directiveTypeId)
        {
            foreach (SpecialOperations t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<SpecialOperations> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<SpecialOperations> Items
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
        #region public SpecialOperations()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public SpecialOperations()
        {
        }
        #endregion

        #region public SpecialOperations(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public SpecialOperations(Int32 itemID, String shortName, String fullName, String commonName)
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
