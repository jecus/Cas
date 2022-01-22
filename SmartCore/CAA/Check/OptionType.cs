using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Check
{
    [Serializable]
    public class OptionType : StaticDictionary
    {
        #region public static CommonDictionaryCollection<OptionType> _Items = new CommonDictionaryCollection<OptionType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<OptionType> _Items = new CommonDictionaryCollection<OptionType>();
        #endregion

        public static OptionType Assessed = new OptionType(1, "Assessed", "Assessed", "");
        public static OptionType Coordinated = new OptionType(2, "Coordinated", "Coordinated", "");
        public static OptionType Crosschecked = new OptionType(3, "Crosschecked", "Crosschecked", "");
        public static OptionType Examined = new OptionType(4, "Examined", "Examined", "");
        public static OptionType Compared = new OptionType(5, "Examined/Compared", "Examined/Compared", "");
        public static OptionType Identified = new OptionType(6, "Identified", "Identified", "");
        public static OptionType IdentifiedAssessed = new OptionType(7, "Identified/Assessed", "Identified/Assessed", "");
        public static OptionType Interviewed = new OptionType(8, "Interviewed", "Interviewed", "");
        public static OptionType Observed = new OptionType(9, "Observed", "Observed", "");
        public static OptionType ObservedAssessed = new OptionType(10, "Observed/Assessed", "Observed/Assessed", "");
        public static OptionType Reviewed = new OptionType(11, "Reviewed", "Reviewed", "");
        public static OptionType OtherAction = new OptionType(12, "Other Action", "Other Action", "");
        public static OptionType Traced = new OptionType(13, "Traced", "Traced", "");
        public static OptionType IdentifiedExamined = new OptionType(14, "Identified/Examined", "Identified/Examined", "");
        public static OptionType Unknown = new OptionType(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static OptionType GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static OptionType GetItemById(int directiveTypeId)
        {
            foreach (OptionType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<OptionType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<OptionType> Items
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
        #region public OptionType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public OptionType()
        {
        }
        #endregion

        #region public OptionType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public OptionType(Int32 itemID, String shortName, String fullName, String commonName)
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
