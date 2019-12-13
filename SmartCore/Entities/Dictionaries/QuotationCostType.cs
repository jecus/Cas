using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс описывает возможные состояния директивы
    /// </summary>
    [Serializable]
    public class QuotationCostType : StaticDictionary
    {
        #region private static CommonDictionaryCollection<QuotationCostType> _Items = new CommonDictionaryCollection<QuotationCostType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<QuotationCostType> _Items = new CommonDictionaryCollection<QuotationCostType>();
        #endregion
        /*
         * Реализация
         */
        #region static public CommonDictionaryCollection<QuotationCostType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<QuotationCostType> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
         * Возможные состояния директивы
         */

        public static QuotationCostType New = new QuotationCostType(1, "New", "New");
        public static QuotationCostType Serv = new QuotationCostType(2, "Serv", "Serv");
        public static QuotationCostType OH = new QuotationCostType(3, "OH", "OH");
        public static QuotationCostType Test = new QuotationCostType(4, "Test", "Test");
        public static QuotationCostType Inspect = new QuotationCostType(5, "Inspect", "Inspect");
        public static QuotationCostType Repair = new QuotationCostType(6, "Repair", "Repair");
        public static QuotationCostType Modification = new QuotationCostType(7, "Modification", "Modification");


        #region public static QuotationCostType UNK = new QuotationCostType(-1, "UNK", "Unknown");
        /// <summary>
        /// 
        /// </summary>
        //public static QuotationCostType UNK = new QuotationCostType(-1, "UNK", "Unknown");
        #endregion
        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public QuotationCostType()

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public QuotationCostType()
        {
        }

        #endregion

        #region public QuotationCostType(String shortName, String fullName)

        /// <summary>
        /// Конструктор принимает псевдоним и полное имя статуса
        /// </summary>
        /// <param name="recordTypeId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public QuotationCostType(Int32 recordTypeId, String shortName, String fullName)
        {
            ShortName = shortName;
            FullName = fullName;
            ItemId = recordTypeId;
            _Items.Add(this);
        }

        #endregion

        #region public override string ToString()
        /// <summary>
        /// Возвращает полное имя объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }

        #endregion

        #region public static QuotationCostType GetItemById(Int32 conditionStateId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="conditionStateId"></param>
        /// <returns></returns>
        //public static QuotationCostType GetItemById(Int32 conditionStateId)
        //{
        //    foreach (QuotationCostType t in _Items)
        //        if (t.ItemId == conditionStateId)
        //            return t;
        //    //
        //    return UNK;
        //}

        #endregion

    }


}
