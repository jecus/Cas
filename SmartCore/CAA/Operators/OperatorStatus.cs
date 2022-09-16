using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    [Serializable]
    public class OperatorStatus : StaticDictionary
    {
        #region public static CommonDictionaryCollection<OperatorStatus> _Items = new CommonDictionaryCollection<OperatorStatus>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<OperatorStatus> _Items = new CommonDictionaryCollection<OperatorStatus>();
        #endregion

        public static OperatorStatus Issuing = new OperatorStatus(1, "Issuing", "Issuing", "");
        public static OperatorStatus Maintaining = new OperatorStatus(2, "Maintaining", "Maintaining", "");
        public static OperatorStatus Amending = new OperatorStatus(3, "Amending", "Amending", "");
        public static OperatorStatus Limiting = new OperatorStatus(4, "Limiting", "Limiting", "");
        public static OperatorStatus Suspending = new OperatorStatus(5, "Suspending", "Suspending", "");
        public static OperatorStatus Revoking = new OperatorStatus(6, "Revoking", "Revoking", "");
        public static OperatorStatus Valid = new OperatorStatus(7, "Valid", "Valid", "");
        public static OperatorStatus Revalidation = new OperatorStatus(8, "Revalidation", "Revalidation", "");
        public static OperatorStatus Renewal = new OperatorStatus(9, "Renewal", "Renewal", "");
        public static OperatorStatus Unknown = new OperatorStatus(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static OperatorStatus GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static OperatorStatus GetItemById(int directiveTypeId)
        {
            foreach (OperatorStatus t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<OperatorStatus> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<OperatorStatus> Items
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
        #region public OperatorStatus()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public OperatorStatus()
        {
        }
        #endregion

        #region public OperatorStatus(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public OperatorStatus(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            
            _Items.Add(this);
        }
        #endregion
    }
}