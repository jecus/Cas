using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.PEL
{
    
    [Serializable]
    public class EducationPriority : StaticDictionary
    {
        #region public static CommonDictionaryCollection<EducationPriority> _Items = new CommonDictionaryCollection<EducationPriority>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<EducationPriority> _Items = new CommonDictionaryCollection<EducationPriority>();
        #endregion
        
        public static EducationPriority Mandatory = new EducationPriority(1, "Mandatory", "Mandatory", "");
        public static EducationPriority Recommend = new EducationPriority(2, "Recommend", "Recommend", "");
        public static EducationPriority Option = new EducationPriority(3, "Option", "Option", "");
        public static EducationPriority Unknown = new EducationPriority(-1, "N/A", "Unknown", "N/A");

        /*
         * Методы
         */

        #region public static EducationPriority GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static EducationPriority GetItemById(int directiveTypeId)
        {
            foreach (EducationPriority t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<EducationPriority> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<EducationPriority> Items
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
        #region public EducationPriority()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public EducationPriority()
        {
        }
        #endregion

        #region public EducationPriority(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public EducationPriority(Int32 itemID, String shortName, String fullName, String commonName)
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
