using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Audit
{
    [Serializable]
    public class AuditRootCategory : StaticDictionary
    {
        #region public static CommonDictionaryCollection<AuditRootCategory> _Items = new CommonDictionaryCollection<AuditRootCategory>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<AuditRootCategory> _Items = new CommonDictionaryCollection<AuditRootCategory>();
        #endregion

        public static AuditRootCategory Unknown = new AuditRootCategory(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static AuditRootCategory GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static AuditRootCategory GetItemById(int directiveTypeId)
        {
            foreach (AuditRootCategory t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<AuditRootCategory> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<AuditRootCategory> Items
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
        #region public AuditRootCategory()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public AuditRootCategory()
        {
        }
        #endregion

        #region public AuditRootCategory(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public AuditRootCategory(Int32 itemID, String shortName, String fullName, String commonName)
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
