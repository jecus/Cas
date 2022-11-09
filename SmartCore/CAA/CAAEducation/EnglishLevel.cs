using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.CAAEducation
{
   [Serializable]
    public class EnglishLevel : StaticDictionary
    {
        #region public static CommonDictionaryCollection<EnglishLevel> _Items = new CommonDictionaryCollection<EnglishLevel>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<EnglishLevel> _Items = new CommonDictionaryCollection<EnglishLevel>();
        #endregion

        // public static EnglishLevel One = new EnglishLevel(1, "1", "1", "1");
        // public static EnglishLevel Two = new EnglishLevel(2, "2", "2", "2");
        // public static EnglishLevel Three = new EnglishLevel(3, "3", "3", "3");
        public static EnglishLevel Four = new EnglishLevel(4, "4", "4", "4");
        public static EnglishLevel Five = new EnglishLevel(5, "5", "5", "5");
        public static EnglishLevel Six = new EnglishLevel(6, "6", "6", "6");
        
        
        public static EnglishLevel Unknown = new EnglishLevel(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static EnglishLevel GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static EnglishLevel GetItemById(int directiveTypeId)
        {
            foreach (EnglishLevel t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<EnglishLevel> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<EnglishLevel> Items
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
        #region public EnglishLevel()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public EnglishLevel()
        {
        }
        #endregion

        #region public ActionProgramType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public EnglishLevel(Int32 itemID, String shortName, String fullName, String commonName)
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
